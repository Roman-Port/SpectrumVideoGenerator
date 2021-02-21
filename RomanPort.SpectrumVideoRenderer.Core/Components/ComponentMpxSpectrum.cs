using Newtonsoft.Json.Linq;
using RomanPort.LibSDR.Components.FFT;
using RomanPort.LibSDR.Components.FFT.Mutators;
using RomanPort.LibSDR.Demodulators;
using RomanPort.LibSDR.Demodulators.Analog.Broadcast;
using RomanPort.SpectrumVideoRenderer.Core.ComponentResources;
using RomanPort.SpectrumVideoRenderer.Core.Components.Base;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.ComponentRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Components
{
    public class ComponentMpxSpectrum : BaseComponentSpectrum
    {
        public ComponentMpxSpectrum(CanvasContext ctx, JObject cfg) : base(ctx)
        {
            attack = UtilReadConfigValue(cfg, "attack", 0.4f);
            decay = UtilReadConfigValue(cfg, "decay", 0.3f);
            fftBins = UtilReadConfigValue(cfg, "fftBins", 2048);
            fftOffset = UtilReadConfigValue(cfg, "fftOffset", 0);
            fftScale = UtilReadConfigValue(cfg, "fftScale", 100);
            height = UtilReadConfigValue(cfg, "height", 200);
            demodulatorLabel = UtilReadConfigValue<string>(cfg, "demodulator_label", null);
        }

        internal static void RegisterSelf()
        {
            ComponentFactory.RegisterComponent("MPX_SPECTRUM", new ComponentInfo
            {
                name = "MPX Spectrum",
                description = "Spectrum of the WBFM MPX FFT.",
                type = typeof(ComponentMpxSpectrum),
                options = new List<ComponentOption>
                {
                    new ComponentOption
                    {
                        id = "attack",
                        name = "Attack",
                        defaultValue = 0.4f,
                        type = ComponentOptionType.Slider
                    },
                    new ComponentOption
                    {
                        id = "decay",
                        name = "Decay",
                        defaultValue = 0.3f,
                        type = ComponentOptionType.Slider
                    },
                    new ComponentOption
                    {
                        id = "fftBins",
                        name = "FFT Bins",
                        defaultValue = 2048,
                        type = ComponentOptionType.Integer
                    },
                    new ComponentOption
                    {
                        id = "fftOffset",
                        name = "FFT Offset (dB)",
                        defaultValue = 0,
                        type = ComponentOptionType.Integer
                    },
                    new ComponentOption
                    {
                        id = "fftScale",
                        name = "FFT Range (dB)",
                        defaultValue = 100,
                        type = ComponentOptionType.Integer
                    },
                    new ComponentOption
                    {
                        id = "height",
                        name = "Height (pixels)",
                        defaultValue = 200,
                        type = ComponentOptionType.Integer
                    },
                    new ComponentOption
                    {
                        id = "demodulator_label",
                        name = "Demodulator Label (MUST be WBFM)",
                        defaultValue = "",
                        type = ComponentOptionType.Text
                    },
                }
            });
        }

        //Config
        private float attack;
        private float decay;
        private int fftBins;
        private float fftOffset;
        private float fftScale;
        private int height;
        private string demodulatorLabel;

        //Misc
        private WbFmDemodulator demodulator;
        private IFftMutatorSource fft;

        private const float MPX_CROP_WIDTH = 100000;

        public override IFftMutatorSource Fft => fft;

        public override float FftOffset => fftOffset;

        public override float FftRange => fftScale;

        public override int Height => height;

        public override unsafe void InitFrame(UnsafeColor* ptr)
        {
            //Call main
            base.InitFrame(ptr);

            long hzPerPixel = (long)demodulator.MpxSampleRate / 2 / SpectrumWidth;
            long freq = 0;
            while(true)
            {
                //Calculate
                long px = freq / hzPerPixel;
                if (px > SpectrumWidth)
                    break;

                //Render
                AddHorizontalMarker(ptr, ctx, (int)px, freq);

                //Update
                freq += 19000;
            }


            //Automatically process the points
            AutoAddVerticalMarkers(ptr, ctx);
        }

        public override void Init()
        {
            //Set values
            this.demodulator = (WbFmDemodulator)ctx.FindComponentResource<AudioResource>(x => x.Label == demodulatorLabel).Demodulator;

            //Get the FFT of the demodulator
            var demodFft = this.demodulator.EnableMpxFFT(fftBins);

            //Wrap our FFT
            this.fft = new FFTSmoothener(demodFft, attack, decay);
        }

        public override void Dispose()
        {
            
        }
    }
}
