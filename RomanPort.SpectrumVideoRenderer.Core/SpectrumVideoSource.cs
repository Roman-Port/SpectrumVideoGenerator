using RomanPort.LibSDR.Components;
using RomanPort.LibSDR.Components.IO;
using RomanPort.LibSDR.Components.IO.RAW;
using RomanPort.LibSDR.Components.IO.WAV;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core
{
    public unsafe class SpectrumVideoSource : IDisposable
    {
        public SpectrumVideoSource(FileStream fs, ISampleReader reader)
        {
            this.fs = fs;
            this.reader = reader;
        }

        public static bool OpenSource(SpectrumVideoFileConfig cfg, out SpectrumVideoSource source)
        {
            //Set default
            source = null;
            
            //Make sure file exists
            if (!File.Exists(cfg.pathname))
                return false;

            //Open stream
            FileStream fs = new FileStream(cfg.pathname, FileMode.Open, FileAccess.Read);

            //Attempt to load as a WAV file
            ISampleReader reader;
            try
            {
                reader = new WavFileReader(fs);
            } catch
            {
                //Fall back to loading RAW files
                fs.Position = 0;
                if (cfg.raw_rate == 0)
                    return false;
                reader = new StreamSampleReader(fs, cfg.raw_format, cfg.raw_rate, 0, 2, 32768);
            }

            //Get source
            source = new SpectrumVideoSource(fs, reader);
            return true;
        }

        public int SampleRate { get => reader.SampleRate; }
        public long PositionSamples { get => reader.PositionSamples; set => reader.PositionSamples = value; }
        public long LengthSamples { get => reader.LengthSamples; }

        private ISampleReader reader;
        private FileStream fs;

        public int Read(Complex* ptr, int count)
        {
            return reader.Read(ptr, count);
        }

        public void Close()
        {
            fs.Close();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
