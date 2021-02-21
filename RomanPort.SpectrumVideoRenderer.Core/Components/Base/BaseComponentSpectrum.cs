using Newtonsoft.Json.Linq;
using RomanPort.LibSDR.Components.FFT;
using RomanPort.LibSDR.Components.FFT.Mutators;
using RomanPort.SimpleFontRenderer;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Components.Base
{
    public unsafe abstract class BaseComponentSpectrum : SpectrumVideoComponent
    {
        public BaseComponentSpectrum(CanvasContext ctx) : base(ctx)
        {

        }

        public abstract IFftMutatorSource Fft { get; }
        public abstract float FftOffset { get; }
        public abstract float FftRange { get; }

        public int SpectrumHeight { get => Height - BOTTOM_HEIGHT; }
        public int SpectrumWidth { get => Width - PADDING_LEFT - PADDING_RIGHT; }

        private UnsafeColor[] gradientDark;
        private UnsafeColor[] gradient;

        private FFTResizer fftResized;

        private List<int> horizMarkerPixels = new List<int>();
        private List<int> vertMarkerPixels = new List<int>();

        private static readonly UnsafeColor GRADIENT_TOP_BRIGHT = new UnsafeColor(112, 180, 255);
        private static readonly UnsafeColor GRADIENT_BOTTOM_BRIGHT = new UnsafeColor(0, 0, 80);
        private static readonly UnsafeColor GRADIENT_TOP_DARK = new UnsafeColor(112 / BACKGROUND_DIM_RATIO, 180 / BACKGROUND_DIM_RATIO, 255 / BACKGROUND_DIM_RATIO);
        private static readonly UnsafeColor GRADIENT_BOTTOM_DARK = new UnsafeColor(0 / BACKGROUND_DIM_RATIO, 0 / BACKGROUND_DIM_RATIO, 80 / BACKGROUND_DIM_RATIO);

        private static FontPack FONT_LABELS = FontStore.SYSTEM_REGULAR_10;

        private const int BACKGROUND_DIM_RATIO = 4;

        public static int BOTTOM_HEIGHT = 30;
        public static int BOTTOM_TEXT_PADDING = (BOTTOM_HEIGHT - FONT_LABELS.height) / 2;
        public static int BOTTOM_TEXT_OFFSET = BOTTOM_TEXT_PADDING + FONT_LABELS.height;
        public static float MARKER_MIX_PERCENT = 0.75f;
        public static int LEFT_TEXT_WIDTH = FONT_LABELS.MeasureWidth(4);
        public static int LEFT_TEXT_PADDING = 2;
        public static int PADDING_LEFT = LEFT_TEXT_PADDING + LEFT_TEXT_WIDTH + LEFT_TEXT_PADDING;
        public static int PADDING_RIGHT = 0;        

        public override unsafe void InitFrame(UnsafeColor* ptr)
        {
            //Precompute gradients
            gradient = new UnsafeColor[SpectrumHeight];
            gradientDark = new UnsafeColor[SpectrumHeight];
            for (int i = 0; i < SpectrumHeight; i++)
            {
                gradient[i] = InterpColor((float)i / (SpectrumHeight - 1), GRADIENT_BOTTOM_BRIGHT, GRADIENT_TOP_BRIGHT);
                gradientDark[i] = InterpColor((float)i / (SpectrumHeight - 1), GRADIENT_BOTTOM_DARK, GRADIENT_TOP_DARK);
            }

            //Create FFT
            fftResized = new FFTResizer(Fft, SpectrumWidth);

            //Fill with black
            Fill(ptr, new UnsafeColor(0, 0, 0));
        }

        public override unsafe void RenderFrame(UnsafeColor* ptr)
        {
            //Offset pointer by the padding
            ptr += PADDING_LEFT;
            byte* ptrByte = (byte*)ptr;

            //Get an FFT snapshot
            float* fftPtr = fftResized.ProcessFFT(out int fftBins);

            //Convert
            for (int i = 0; i < SpectrumWidth; i++)
                fftPtr[i] = ((Math.Abs(fftPtr[i]) - FftOffset) / FftRange) * SpectrumHeight;

            //Loop
            float max;
            float value;
            float min;
            for (var x = 0; x < SpectrumWidth; x += 1)
            {
                //Get where this pixel is
                if(x == 0)
                {
                    //Cant access first
                    max = Math.Max(fftPtr[x], fftPtr[x + 1]);
                    value = fftPtr[x];
                    min = Math.Min(fftPtr[x], fftPtr[x + 1]);
                } else if (x == SpectrumWidth - 1)
                {
                    //Can't access last
                    max = Math.Max(fftPtr[x - 1], fftPtr[x]);
                    value = fftPtr[x];
                    min = Math.Min(fftPtr[x - 1], fftPtr[x]);
                } else
                {
                    //Normal
                    max = Math.Max(fftPtr[x - 1], Math.Max(fftPtr[x], fftPtr[x + 1]));
                    value = fftPtr[x];
                    min = Math.Min(fftPtr[x - 1], Math.Min(fftPtr[x], fftPtr[x + 1]));
                }

                //Loop
                for (var y = 0; y < SpectrumHeight; y++)
                {
                    //Get offset
                    var offset = ((y * Width) + x);

                    //Determine color
                    if (y > max)
                    {
                        //Full gradient
                        ptr[offset] = gradient[y];
                    }
                    else if (y == value)
                    {
                        //Point
                        ptr[offset] = new UnsafeColor(255, 255, 255);
                    }
                    else if (y <= max && y > value)
                    {
                        //Interp top
                        var c = InterpColor((float)Math.Pow((y - value) / (max - value), 3), gradient[y], new UnsafeColor(255, 255, 255));
                        ptr[offset + 0] = c;
                    }
                    else if (y < value && y >= min)
                    {
                        //Intep bottom
                        var c = InterpColor((float)Math.Pow((y - min) / (value - min), 3), new UnsafeColor(255, 255, 255), gradientDark[y]);
                        ptr[offset + 0] = c;
                    }
                    else
                    {
                        //Dark gradient
                        ptr[offset] = gradientDark[y];
                    }
                }
            }

            //Draw markers
            foreach(var x in horizMarkerPixels)
            {
                for (int y = 0; y < SpectrumHeight; y++)
                    FastInterpColor((byte*)(ptr + (y * Width) + x));
            }
            foreach(var y in vertMarkerPixels)
            {
                for (int x = 0; x < SpectrumWidth; x++)
                    FastInterpColor((byte*)(ptr + (y * Width) + x));
            }
        }

        private static void FastInterpColor(byte* ptr)
        {
            ptr[0] = (byte)((ptr[0] >> 1) | 128);
            ptr[1] = (byte)((ptr[1] >> 1) | 128);
            ptr[2] = (byte)((ptr[2] >> 1) | 128);
            ptr[3] = (byte)((ptr[3] >> 1) | 128);
        }

        private static UnsafeColor InterpColor(float percent, UnsafeColor c1, UnsafeColor c2)
        {
            var invPercent = 1 - percent;
            return new UnsafeColor(
                (byte)((c1.r * percent) + (c2.r * invPercent)),
                (byte)((c1.g * percent) + (c2.g * invPercent)),
                (byte)((c1.b * percent) + (c2.b * invPercent))
            );
        }

        protected void AddHorizontalMarker(UnsafeColor* ptr, CanvasContext ctx, int pixel, long freq)
        {
            //Convert the freq into a string
            string freqString;
            if (freq > 1000000)
                freqString = RendererUtils.FixedDecimalToString((freq / 1000000.0), 1) + "M";
            else
                freqString = (freq / 1000) + "k";;

            //Calculate width
            int labelWidth = FONT_LABELS.MeasureWidth(freqString.Length);

            //Determine the pixel to draw on
            int drawPixel = pixel - (labelWidth / 2);
            if (drawPixel < 0)
                drawPixel = 0;
            if (drawPixel + labelWidth > SpectrumWidth)
                drawPixel = SpectrumWidth - labelWidth;

            //Draw
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, drawPixel + PADDING_LEFT, Height - BOTTOM_TEXT_OFFSET),
                new char[][] { freqString.ToCharArray() },
                FONT_LABELS,
                FontAlignHorizontal.Center,
                FontAlignVertical.Top,
                labelWidth,
                FONT_LABELS.height,
                new FontColor(1),
                new FontColor(0)
            );

            //Add to render queue
            horizMarkerPixels.Add(pixel);
        }

        protected void AddVerticalMarker(UnsafeColor* ptr, CanvasContext ctx, int pixel, int db)
        {
            //Convert dB into a string
            string dbString = "-" + db.ToString();

            //Determine draw position
            int drawPixel = pixel - (FONT_LABELS.height / 2);
            if (drawPixel < 0)
                drawPixel = 0;
            if (drawPixel + FONT_LABELS.height > SpectrumHeight)
                drawPixel = SpectrumHeight - FONT_LABELS.height;

            //Draw
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, LEFT_TEXT_PADDING, drawPixel),
                new char[][] { dbString.ToCharArray() },
                FONT_LABELS,
                FontAlignHorizontal.Right,
                FontAlignVertical.Center,
                LEFT_TEXT_WIDTH,
                FONT_LABELS.height,
                new FontColor(1),
                new FontColor(0)
            );

            //Add to render queue
            vertMarkerPixels.Add(pixel);
        }

        protected void AutoAddVerticalMarkers(UnsafeColor* ptr, CanvasContext ctx)
        {
            //Determine scale in dB per line
            var scale = 10;
            float dbPerPixel = SpectrumHeight / FftRange;

            //Find lines to draw
            for (var db = 0; true; db += scale)
            {
                //Convert to pixel space
                var pixel = (int)((db - (int)FftOffset) * dbPerPixel);

                //Check if we've reached the end
                if (pixel > SpectrumHeight) { break; }
                if (pixel < 0) { continue; }

                //Add point
                AddVerticalMarker(ptr, ctx, pixel, db);
            }
        }
    }
}
