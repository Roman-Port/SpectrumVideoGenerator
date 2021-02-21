using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework.Saved
{
    public class SpectrumVideoCanvasConfig
    {
        public string label = "Default Canvas";

        public SpectrumVideoBasebandConfig baseband = new SpectrumVideoBasebandConfig();
        public SpectrumVideoOutputConfig video_output = new SpectrumVideoOutputConfig();
        public List<SpectrumVideoDemodConfig> audio_outputs = new List<SpectrumVideoDemodConfig>();
        public List<SpectrumVideoComponentConfig> components = new List<SpectrumVideoComponentConfig>();
        public SpectrumVideoFileConfig source = new SpectrumVideoFileConfig();

        public override string ToString()
        {
            return label;
        }
    }
}
