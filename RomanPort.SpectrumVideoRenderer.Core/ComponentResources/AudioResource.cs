using RomanPort.LibSDR.Components;
using RomanPort.LibSDR.Components.Decimators;
using RomanPort.LibSDR.Components.Resamplers.Arbitrary;
using RomanPort.LibSDR.Demodulators;
using RomanPort.LibSDR.Demodulators.Analog.Broadcast;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using RomanPort.SpectrumVideoRenderer.Core.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.ComponentResources
{
    public unsafe class AudioResource : SpectrumVideoComponentResource
    {
        public AudioResource(SpectrumVideoDemodConfig config, CanvasContext ctx)
        {
            //Set
            this.label = config.label;

            //Get demodulator
            switch (config.demodType)
            {
                case "WBFM": demodulator = new WbFmDemodulator(); break;
                default: throw new Exception("Unknown demodulator type.");
            }

            //Make buffers
            bufferSize = ctx.BufferSize;
            generalBuffer = UnsafeBuffer.Create(ctx.BufferSize, out generalBufferComplexPtr);
            generalBufferFloatPtr = (float*)generalBufferComplexPtr;
            audioABuffer = UnsafeBuffer.Create(ctx.BufferSize, out audioABufferPtr);
            audioBBuffer = UnsafeBuffer.Create(ctx.BufferSize, out audioBBufferPtr);

            //Init audio
            demodDecimator = ComplexDecimator.CalculateDecimator(ctx.DecimatedSampleRate, config.demodBandwidth, 20, config.demodBandwidth * 0.05f, out float demodSampleRate);
            float actualAudioRate = demodulator.Configure(ctx.BufferSize, demodSampleRate, config.outputSampleRate);
            audioResampler = new ArbitraryStereoResampler(actualAudioRate, config.outputSampleRate, ctx.BufferSize);

            //Create output
            output = ctx.OutputProvider.GetAudioOutput(config.outputFilename, config.outputSampleRate, bufferSize);
        }

        private string label;
        private int bufferSize;
        private UnsafeBuffer generalBuffer;
        private Complex* generalBufferComplexPtr; //bufferSize
        private float* generalBufferFloatPtr; //bufferSize * 2
        private UnsafeBuffer audioABuffer;
        private float* audioABufferPtr;
        private UnsafeBuffer audioBBuffer;
        private float* audioBBufferPtr;
        private ComplexDecimator demodDecimator;
        private IAudioDemodulator demodulator;
        private ArbitraryStereoResampler audioResampler;
        private IOutputPipe output;

        public string Label { get => label; }
        public IAudioDemodulator Demodulator { get => demodulator; }
        
        public override void OnFrame(Complex* samples, int count)
        {
            //Decimate + filter into our buffer
            count = demodDecimator.Process(samples, generalBufferComplexPtr, count);

            //Demodulate
            count = demodulator.DemodulateStereo(generalBufferComplexPtr, audioABufferPtr, audioBBufferPtr, count);

            //Resample
            audioResampler.Input(audioABufferPtr, audioBBufferPtr, count);
            count = audioResampler.Output(audioABufferPtr, audioBBufferPtr, bufferSize);
            while (count != 0)
            {
                //Zipper into the general buffer
                for(int i = 0; i<count; i++)
                {
                    generalBufferFloatPtr[(i * 2) + 0] = audioABufferPtr[i];
                    generalBufferFloatPtr[(i * 2) + 1] = audioBBufferPtr[i];
                }

                //Send to output
                output.Write((byte*)generalBufferFloatPtr, count * sizeof(float) * 2);

                //Read
                count = audioResampler.Output(audioABufferPtr, audioBBufferPtr, bufferSize);
            }
        }

        public override void OnClosed()
        {
            output.ClosePipe();
        }
    }
}
