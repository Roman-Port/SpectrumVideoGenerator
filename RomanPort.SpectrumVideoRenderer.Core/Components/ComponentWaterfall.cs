using Newtonsoft.Json.Linq;
using RomanPort.LibSDR.Components;
using RomanPort.LibSDR.Components.FFT;
using RomanPort.LibSDR.Components.FFT.Mutators;
using RomanPort.LibSDR.Demodulators;
using RomanPort.SpectrumVideoRenderer.Core.ComponentResources;
using RomanPort.SpectrumVideoRenderer.Core.Components.Base;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.ComponentRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Components
{
    public unsafe class ComponentWaterfall : SpectrumVideoComponent
    {
        public ComponentWaterfall(CanvasContext ctx, JObject cfg) : base(ctx)
        {
            attack = UtilReadConfigValue(cfg, "attack", 0.4f);
            decay = UtilReadConfigValue(cfg, "decay", 0.3f);
            fftBins = UtilReadConfigValue(cfg, "fftBins", 2048);
            fftOffset = UtilReadConfigValue(cfg, "fftOffset", 0);
            fftScale = UtilReadConfigValue(cfg, "fftScale", 100);
            height = UtilReadConfigValue(cfg, "height", 200);
        }

        internal static void RegisterSelf()
        {
            ComponentFactory.RegisterComponent("MAIN_WATERFALL", new ComponentInfo
            {
                name = "Waterfall",
                description = "Waterfall of the main FFT.",
                type = typeof(ComponentWaterfall),
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
                    }
                }
            });
        }

        //Config
        private float attack;
        private float decay;
        private int height;
        private int fftBins;
        private float fftOffset;
        private float fftScale;

        //Misc
        private UnsafeColor[] precomputedColors;
        private UnsafeBuffer swapBuffer;
        private UnsafeColor* swapPtr;
        private UnsafeBuffer fftBuffer;
        private float* fftPtr;
        private IFftMutatorSource fft;

        public int WaterfallWidth { get => Width - BaseComponentSpectrum.PADDING_LEFT - BaseComponentSpectrum.PADDING_RIGHT; }

        public override int Height => height;

        public override void Init()
        {
            //Precompute colors
            precomputedColors = new UnsafeColor[byte.MaxValue];
            for (int i = 0; i < byte.MaxValue; i++)
                precomputedColors[i] = GetColor((float)i / (byte.MaxValue - 1));

            //Create swap
            swapBuffer = UnsafeBuffer.Create(Width * (Height - 1), out swapPtr);
            fftBuffer = UnsafeBuffer.Create(Width, out fftPtr);

            //Get FFT
            IFftMutatorSource fft = FftResource.GetFFT(ctx, "MAIN", fftBins, false);

            //Wrap our FFT
            var smoothener = new FFTSmoothener(fft, attack, decay);
            this.fft = new FFTResizer(smoothener, WaterfallWidth);
        }

        public override unsafe void InitFrame(UnsafeColor* ptr)
        {
            //Fill with black
            for (int y = 0; y < Height; y++)
            {
                UnsafeColor* lnDst = ptr + (y * Width);
                for (int x = 0; x < Width; x++)
                {
                    lnDst[x] = new UnsafeColor(0, 0, 0);
                }
            }
        }

        public override unsafe void RenderFrame(UnsafeColor* ptr)
        {
            //Shift data downwards by copying it into the swap and then back
            Utils.Memcpy(swapPtr, ptr, Width * (Height - 1) * sizeof(UnsafeColor));
            Utils.Memcpy(ptr + Width, swapPtr, Width * (Height - 1) * sizeof(UnsafeColor));

            //Get an FFT snapshot
            float* fftPtr = fft.ProcessFFT(out int fftBins);

            //Convert
            int index;
            for (int i = 0; i < WaterfallWidth; i++)
            {
                fftPtr[i] += fftOffset;
                fftPtr[i] /= fftScale;
                fftPtr[i] *= precomputedColors.Length;
                index = (int)Math.Abs(fftPtr[i]);
                index = Math.Max(Math.Min(precomputedColors.Length - 1, index), 0);
                ptr[i + BaseComponentSpectrum.PADDING_LEFT] = precomputedColors[index];
            }
        }

        private static readonly int[][] WATERFALL_GRADIENT_COLORS = new int[][]
        {
            new int[] {0, 0, 32},
            new int[] {0, 0, 48},
            new int[] {0, 0, 80},
            new int[] {0, 0, 145},
            new int[] {30, 144, 255},
            new int[] {255, 255, 255},
            new int[] {255, 255, 0},
            new int[] {254, 109, 22},
            new int[] {255, 0, 0},
            new int[] {198, 0, 0},
            new int[] {159, 0, 0},
            new int[] {117, 0, 0},
            new int[] {74, 0, 0 }
        };

        private UnsafeColor GetColor(float percent)
        {
            //Make sure percent is within range
            percent = 1 - percent;
            percent = Math.Max(0, percent);
            percent = Math.Min(1, percent);

            //Calculate
            var scale = WATERFALL_GRADIENT_COLORS.Length - 1;

            //Get the two colors to mix
            var mix2 = WATERFALL_GRADIENT_COLORS[(int)Math.Floor(percent * scale)];
            var mix1 = WATERFALL_GRADIENT_COLORS[(int)Math.Ceiling(percent * scale)];

            //Get ratio
            var ratio = (percent * scale) - Math.Floor(percent * scale);

            //Mix
            return new UnsafeColor(
                (byte)(Math.Ceiling((mix1[0] * ratio) + (mix2[0] * (1 - ratio)))),
                (byte)(Math.Ceiling((mix1[1] * ratio) + (mix2[1] * (1 - ratio)))),
                (byte)(Math.Ceiling((mix1[2] * ratio) + (mix2[2] * (1 - ratio))))
            );
        }

        public override void Dispose()
        {
            swapBuffer.Dispose();
            fftBuffer.Dispose();
        }
    }
}
