using RomanPort.LibSDR.Demodulators;
using RomanPort.LibSDR.Framework.Components.FFT;
using RomanPort.LibSDR.UI.Framework;
using RomanPort.SpectrumVideoRenderer.Framework.Saved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.SpectrumVideoRenderer.Framework.Generator
{
    public abstract class BaseViewComponent
    {
        public abstract bool RequiresFft { get; }
        public abstract bool RequiresAudio { get; }
        public int Width { get => width; }
        public int Height { get => height; }

        private int width;
        private int height;

        public BaseViewComponent(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public abstract void Init(SavedViewData info, FFTInterface fft, IAudioDemodulator demodulator);
        public unsafe abstract void InitFrame(UnsafeColor* ptr);
        public unsafe abstract void RenderFrame(UnsafeColor* ptr);

        public unsafe void FillArea(UnsafeColor* ptr, int startY, int height, UnsafeColor color)
        {
            for (int y = 0; y < height; y++)
            {
                UnsafeColor* lnDst = ptr + ((y + startY) * Width);
                for (int x = 0; x < Width; x++)
                {
                    lnDst[x] = color;
                }
            }
        }

        public unsafe void Fill(UnsafeColor* ptr, UnsafeColor color)
        {
            FillArea(ptr, 0, height, color);
        }
    }
}
