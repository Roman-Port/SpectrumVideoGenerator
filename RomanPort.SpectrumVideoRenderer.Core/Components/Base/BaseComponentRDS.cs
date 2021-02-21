using Newtonsoft.Json.Linq;
using RomanPort.LibSDR.Components.Digital.RDS;
using RomanPort.LibSDR.Demodulators.Analog.Broadcast;
using RomanPort.SpectrumVideoRenderer.Core.ComponentResources;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Components.Base
{
    public abstract class BaseComponentRDS : SpectrumVideoComponent
    {
        public BaseComponentRDS(CanvasContext ctx, JObject cfg) : base(ctx)
        {
            demodulatorLabel = UtilReadConfigValue<string>(cfg, "demodulator_label", null);
        }
        
        private WbFmDemodulator demodulator;
        private RDSDecoder rds;
        private string demodulatorLabel;

        public RDSDecoder RdsDecoder { get => rds; }
        public WbFmDemodulator WbFmDemodulator { get => demodulator; }

        public override void Init()
        {
            demodulator = (WbFmDemodulator)ctx.FindComponentResource<AudioResource>(x => x.Label == demodulatorLabel).Demodulator;
            rds = demodulator.UseRds();
        }
    }
}
