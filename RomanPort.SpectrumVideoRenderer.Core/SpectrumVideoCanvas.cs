using RomanPort.LibSDR.Components;
using RomanPort.LibSDR.Components.Decimators;
using RomanPort.LibSDR.Components.FFT.Generators;
using RomanPort.LibSDR.Components.General;
using RomanPort.LibSDR.Components.Resamplers.Arbitrary;
using RomanPort.LibSDR.Demodulators;
using RomanPort.LibSDR.Demodulators.Analog.Broadcast;
using RomanPort.SimpleFontRenderer;
using RomanPort.SpectrumVideoRenderer.Core.ComponentResources;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using RomanPort.SpectrumVideoRenderer.Core.Outputs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace RomanPort.SpectrumVideoRenderer.Core
{
    public delegate void SpectrumVideoCanvas_FrameEventArgs(SpectrumVideoCanvas canvas);
    
    public unsafe class SpectrumVideoCanvas : IDisposable, CanvasContext
    {
        public SpectrumVideoCanvas(SpectrumVideoCanvasConfig config, IOutputProvider outputProvider) : this(WrapSource(config), config, outputProvider)
        {

        }

        private static SpectrumVideoSource WrapSource(SpectrumVideoCanvasConfig config)
        {
            if (!SpectrumVideoSource.OpenSource(config.source, out SpectrumVideoSource source))
                throw new Exception("Source file is incorrectly configured for " + config.label);
            return source;
        }

        public SpectrumVideoCanvas(SpectrumVideoSource source, SpectrumVideoCanvasConfig config, IOutputProvider outputProvider)
        {
            //Set
            width = config.video_output.width;
            label = config.label;
            decimation = config.baseband.decimation;
            frameRate = config.video_output.frameRate;
            this.outputProvider = outputProvider;
            this.source = source;

            //Create IQ decimator and oscilator
            oscillator = new Oscillator(SampleRate, config.baseband.freqOffset);
            decimator = new ComplexDecimator(SampleRate, DecimatedSampleRate, config.baseband.decimation, config.baseband.decimationAttenuation, DecimatedSampleRate * config.baseband.decimationTransitionRatio);

            //Create all audio resources
            foreach (var o in config.audio_outputs)
                AddResource(new AudioResource(o, this));

            //Create all components
            components = new SpectrumVideoComponent[config.components.Count];
            componentOffsets = new int[config.components.Count];
            for (int i = 0; i < components.Length; i++)
                components[i] = ComponentFactory.MakeComponent(this, config.components[i]);

            //Get the image dimensions by calculating the total height
            height = 0;
            for (int i = 0; i < components.Length; i++)
            {
                componentOffsets[i] = height * ImageWidth;
                height += components[i].Height;
            }

            //Create misc
            videoOutput = outputProvider.GetVideoOutput(config.video_output.filename, ImageWidth, ImageHeight, config.video_output.frameRate, BufferSize);
            frameBuffer = UnsafeBuffer.Create(ImageWidth * ImageHeight, out frameBufferPtr);
            buffer = UnsafeBuffer.Create(BufferSize, out bufferPtr);
            textGenerator = FontStore.CreateRenderer(ImageWidth, ImageHeight);

            //Fill the entire canvas with black
            for (int i = 0; i < ImageWidth * ImageHeight; i++)
                frameBufferPtr[i] = new UnsafeColor(0, 0, 0);

            //Init all components
            for (int i = 0; i < components.Length; i++)
            {
                components[i].Init();
                components[i].InitFrame(frameBufferPtr + componentOffsets[i]);
            }
        }

        //General variables
        private IOutputProvider outputProvider;
        private int height;
        private SpectrumVideoComponent[] components;
        private int[] componentOffsets;
        private List<SpectrumVideoComponentResource> resources = new List<SpectrumVideoComponentResource>();
        private FontRenderer textGenerator;
        private IOutputPipe videoOutput;
        private SpectrumVideoSource source;

        //Config
        private string label;
        private int width;
        private int decimation;
        private int frameRate;

        //Our managed buffers 
        private UnsafeBuffer frameBuffer;
        private UnsafeColor* frameBufferPtr;
        private UnsafeBuffer buffer;
        private Complex* bufferPtr;

        //IQ mutators
        private Oscillator oscillator;
        private ComplexDecimator decimator;

        //Events
        public event SpectrumVideoCanvas_FrameEventArgs OnFrameProcessed;

        //Getters
        public string Label { get => label; }
        public int FrameRate { get => frameRate; }
        public int ImageHeight { get => height; }
        public int ImageWidth { get => width; }
        public int Size { get => ImageHeight * ImageWidth; }
        public int SampleRate { get => source.SampleRate; }
        public int DecimatedSampleRate { get => SampleRate / decimation; }
        public int BufferSize { get => SampleRate / FrameRate; }
        public long TotalFrames { get => source.LengthSamples / BufferSize; }
        public int ComputedFrames { get; private set; }
        public double Progress { get => (double)ComputedFrames / TotalFrames; }

        public FontRenderer TextRenderer => textGenerator;

        public IOutputProvider OutputProvider => outputProvider;

        public void RequestThumbnail(UnsafeColor* previewPixels, int previewWidth, int previewHeight)
        {
            //If we have no pointer yet, abort
            if (frameBufferPtr == null)
                return;

            //Get multipliers
            float previewDrawScaleX = (float)previewWidth / ImageWidth;
            float previewDrawScaleY = (float)previewHeight / ImageHeight;

            //Copy
            for (int x = 0; x < previewWidth; x++)
            {
                for (int y = 0; y < previewHeight; y++)
                {
                    int srcX = (int)(x / previewDrawScaleX);
                    int srcY = (int)(y / previewDrawScaleY);
                    previewPixels[(y * previewWidth) + x] = frameBufferPtr[(srcY * ImageWidth) + srcX];
                }
            }
        }

        public void Run()
        {
            while (TickFrame()) ;
            Close();
        }

        public bool TickFrame()
        {
            //Read
            int count = source.Read(bufferPtr, BufferSize);
            if (count != BufferSize)
                return false;

            //Offset and decimate
            oscillator.Mix(bufferPtr, count);
            if (decimator.DecimationRate != 1)
                count = decimator.Process(bufferPtr, count);

            //Push to resources
            foreach (var r in resources)
                r.OnFrame(bufferPtr, count);

            //Process frame
            for (int i = 0; i < components.Length; i++)
                components[i].RenderFrame(frameBufferPtr + componentOffsets[i]);

            //Output frame
            videoOutput.Write((byte*)frameBufferPtr, ImageWidth * ImageHeight * sizeof(UnsafeColor));

            //Emit events
            ComputedFrames++;
            OnFrameProcessed?.Invoke(this);

            return true;
        }

        public void Close()
        {
            //Close video
            videoOutput.ClosePipe();

            //Close resources
            foreach (var r in resources)
                r.OnClosed();
        }

        public void Dispose()
        {
            //Dispose of local buffers
            frameBuffer.Dispose();

            //Dispose of all components
            for (int i = 0; i < components.Length; i++)
                components[i].Dispose();
        }

        public T FindComponentResource<T>(Expression<Func<T, bool>> query) where T : SpectrumVideoComponentResource
        {
            //Build query
            var compiled = query.Compile();
            
            //Search
            foreach(var r in resources)
            {
                if(r is T && compiled(r as T))
                {
                    return r as T;
                }
            }

            return null;
        }

        public T AddResource<T>(T component) where T : SpectrumVideoComponentResource
        {
            resources.Add(component);
            return component;
        }
    }
}
