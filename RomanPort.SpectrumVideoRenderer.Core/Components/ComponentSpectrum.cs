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
    public class ComponentSpectrum : BaseComponentSpectrum
    {
        public ComponentSpectrum(CanvasContext ctx, JObject cfg) : base(ctx)
        {
            attack = UtilReadConfigValue(cfg, "attack", 0.4f);
            decay = UtilReadConfigValue(cfg, "decay", 0.3f);
            centerFreq = UtilReadConfigValue(cfg, "centerFreq", 92500000);
            fftBins = UtilReadConfigValue(cfg, "fftBins", 2048);
            fftOffset = UtilReadConfigValue(cfg, "fftOffset", 0);
            fftScale = UtilReadConfigValue(cfg, "fftScale", 100);
            height = UtilReadConfigValue(cfg, "height", 200);
            horizFreqDivision = UtilReadConfigValue(cfg, "horizFreqDivision", 100000);
        }

        internal static void RegisterSelf()
        {
            ComponentFactory.RegisterComponent("MAIN_SPECTRUM", new ComponentInfo
            {
                name = "Spectrum",
                description = "Spectrum of the main FFT.",
                type = typeof(ComponentSpectrum),
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
                        id = "centerFreq",
                        name = "Center Frequency (used for display only, Hz)",
                        defaultValue = 92500000,
                        type = ComponentOptionType.Frequency
                    },
                    new ComponentOption
                    {
                        id = "horizFreqDivision",
                        name = "Horizontal Frequency Label Division (Hz)",
                        defaultValue = 100000,
                        type = ComponentOptionType.Integer
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
                    }
                }
            });
        }

        //Config
        private float attack;
        private float decay;
        private long centerFreq;
        private int fftBins;
        private float fftOffset;
        private float fftScale;
        private int height;
        private int horizFreqDivision;

        //Misc
        private IFftMutatorSource fft;
        private int bandwidth;

        public override IFftMutatorSource Fft => fft;

        public override float FftOffset => fftOffset;

        public override float FftRange => fftScale;

        public override int Height => height;

        public override unsafe void InitFrame(UnsafeColor* ptr)
        {
            //Call main
            base.InitFrame(ptr);

            long division = horizFreqDivision;
            long hzPerPixel = (long)bandwidth / SpectrumWidth;
            long freqOffset = centerFreq - (bandwidth / 2);
            long freq = 0;
            if (freqOffset % division != 0)
                freq += division - (freqOffset % division);
            while (true)
            {
                //Calculate
                long px = freq / hzPerPixel;
                if (px > SpectrumWidth)
                    break;

                //Render
                AddHorizontalMarker(ptr, ctx, (int)px, freq + freqOffset);

                //Update
                freq += division;
            }

            //Automatically process the points
            AutoAddVerticalMarkers(ptr, ctx);
        }

        private unsafe void FindHorizMarkers(UnsafeColor* ptr)
        {
            long division = horizFreqDivision;
            double hzPerPixel = (double)bandwidth / SpectrumWidth;
            long freq = ((centerFreq / 2) / division) * division; //Find the leftmost frequency, aligned to the division set
            while (true)
            {
                //Calculate
                int px = (int)(freq / hzPerPixel);
                if (px > SpectrumWidth)
                    break;

                //Render
                if(px >= 0)
                    AddHorizontalMarker(ptr, ctx, px, freq);

                //Update
                freq += division;
            }
        }

        public override void Init()
        {
            //Set values
            this.bandwidth = ctx.DecimatedSampleRate;

            //Get FFT
            IFftMutatorSource fft = FftResource.GetFFT(ctx, "MAIN", fftBins, false);

            //Wrap our FFT
            this.fft = new FFTSmoothener(fft, attack, decay);
        }

        public override void Dispose()
        {

        }
    }
}
