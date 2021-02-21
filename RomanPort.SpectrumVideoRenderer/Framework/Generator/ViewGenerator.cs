using RomanPort.LibSDR.Demodulators;
using RomanPort.LibSDR.Demodulators.Analog.Broadcast;
using RomanPort.LibSDR.Framework;
using RomanPort.LibSDR.Framework.Components.Decimators;
using RomanPort.LibSDR.Framework.Components.FFT;
using RomanPort.LibSDR.Framework.Components.FFT.Processors;
using RomanPort.LibSDR.Framework.Util;
using RomanPort.LibSDR.UI.Framework;
using RomanPort.SpectrumVideoRenderer.Framework.Saved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.SpectrumVideoRenderer.Framework.Generator
{
    public unsafe class ViewGenerator
    {
        public ViewGenerator(SavedViewData info, int bufferSize, float sampleRate)
        {
            //Set
            this.info = info;
            this.bufferSize = bufferSize;

            //Configure offset
            mutator = new DownConverter(1);
            mutator.SampleRate = sampleRate;
            mutator.Frequency = info.offset;

            //Configure decimator
            decimator = new ComplexDecimator(sampleRate, sampleRate / info.decimation, (int)info.decimation);
            sampleRate /= info.decimation;
            
            //Get component list and image size
            components = info.CreateComponents(sampleRate, out width, out height);

            //Find out what workers are required
            foreach(var c in components)
            {
                fftRequired = fftRequired || c.RequiresFft;
                demodulatorRequired = demodulatorRequired || c.RequiresAudio;
            }

            //Create these workers
            if (fftRequired)
                fft = new FFTProcessorComplex(info.fftSize);
            if (demodulatorRequired)
            {
                //Set up decimator
                audioDecimationRate = DecimationUtil.CalculateDecimationRate(sampleRate, info.audioBandwidth, out audioOutputRate);
                audioDecimator = new ComplexDecimator(sampleRate, info.audioBandwidth, audioDecimationRate);

                //Set up demodulator
                demodulator = new WbFmDemodulator();
                demodulator.Configure(bufferSize, audioOutputRate);
            }

            //Initialize all
            foreach (var c in components)
                c.Init(info, fft, demodulator);

            //Create buffers
            iqBuffer = UnsafeBuffer.Create(bufferSize, sizeof(Complex));
            iqPtr = (Complex*)iqBuffer;
        }

        public int Width { get => width; }
        public int Height { get => height; }
        public int BufferSize { get => bufferSize; }
        public float OutputAudioRate { get => audioOutputRate; }

        private SavedViewData info;
        private int bufferSize;
        private List<BaseViewComponent> components;
        private int width;
        private int height;
        private bool fftRequired;
        private bool demodulatorRequired;
        private DownConverter mutator;
        private ComplexDecimator decimator;
        private bool isFirstFrame = true;

        private int audioDecimationRate;
        private float audioOutputRate;
        private ComplexDecimator audioDecimator;

        private UnsafeBuffer iqBuffer;
        private Complex* iqPtr;

        private IAudioDemodulator demodulator;
        private FFTProcessorComplex fft;

        public int ProcessFrame(Complex* incomingSamples, UnsafeColor* pixels, float* left, float* right, int count)
        {
            //Copy to our internal working buffer since this is destructive
            Utils.Memcpy(iqPtr, incomingSamples, count * sizeof(Complex));

            //Mutate and decimate
            mutator.Process(iqPtr, count);
            count = decimator.Process(iqPtr, count);
            
            //Perform steps
            if (fftRequired)
                fft.AddSamples(iqPtr, count);
            int audioProcessed = -1;
            if (demodulatorRequired)
                audioProcessed = ProcessAudio(left, right, count);

            //Render components
            foreach (var c in components)
            {
                if (isFirstFrame)
                    c.InitFrame(pixels);
                c.RenderFrame(pixels);
                pixels += (c.Width * c.Height);
            }
            isFirstFrame = false;

            return audioProcessed;
        }

        private int ProcessAudio(float* left, float* right, int count)
        {
            //Decimate
            count = audioDecimator.Process(iqPtr, count);
            
            //Demodulate
            demodulator.DemodulateStereo(iqPtr, left, right, count);

            return count;
        }
    }
}
