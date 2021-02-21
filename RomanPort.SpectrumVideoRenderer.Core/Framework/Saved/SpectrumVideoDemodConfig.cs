using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework.Saved
{
    public class SpectrumVideoDemodConfig
    {
        public string label = "Default";
        public float demodBandwidth = 200000;
        public string demodType = "WBFM";
        public int outputSampleRate = 48000;
        public string outputFilename = "default.wav";
        public bool multiplex = false;

        public override string ToString()
        {
            return demodType;
        }
    }
}
