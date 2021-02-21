using RomanPort.LibSDR.Components.IO.WAV;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Outputs
{
    public abstract class WavAudioOutputProvider : IOutputProvider
    {
        public IOutputPipe GetAudioOutput(string filename, int rate, int bufferSize)
        {
            return new WavAudioPipe(filename, rate, bufferSize);
        }

        public abstract IOutputPipe GetVideoOutput(string filename, int width, int height, int framerate, int bufferSize);

        class WavAudioPipe : IOutputPipe
        {
            public WavAudioPipe(string filename, int rate, int bufferSize)
            {
                wav = new WavFileWriter(new FileStream(filename, FileMode.Create), rate, 2, LibSDR.Components.IO.SampleFormat.Short16, bufferSize);
            }

            private WavFileWriter wav;
            
            public unsafe void Write(byte* ptr, int read)
            {
                //Convert
                float* fPtr = (float*)ptr;
                read /= sizeof(float);

                //Clamp
                for(int i = 0; i<read; i++)
                {
                    if (fPtr[i] > 1)
                        fPtr[i] = 1;
                    if (fPtr[i] < -1)
                        fPtr[i] = -1;
                }

                //Write
                wav.Write(fPtr, read);
            }

            public void ClosePipe()
            {
                wav.FinalizeFile();
            }
        }
    }
}
