using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework.Saved
{
    public class SpectrumVideoBasebandConfig
    {
        public float freqOffset = 0;
        public int decimation = 1;
        public float decimationAttenuation = 20;
        public float decimationTransitionRatio = 0.05f;
    }
}
