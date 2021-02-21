using Newtonsoft.Json.Linq;
using RomanPort.LibSDR.Components.FFT;
using RomanPort.LibSDR.Demodulators;
using RomanPort.SimpleFontRenderer;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core
{
    public abstract class SpectrumVideoComponent : IDisposable
    {
        public abstract int Height { get; }
        public int Width { get => ctx.ImageWidth; }

        public readonly CanvasContext ctx;

        public SpectrumVideoComponent(CanvasContext ctx)
        {
            this.ctx = ctx;
        }

        public abstract void Init();
        public unsafe abstract void InitFrame(UnsafeColor* ptr);
        public unsafe abstract void RenderFrame(UnsafeColor* ptr);

        public T UtilReadConfigValue<T>(JObject obj, string key, T defaultValue)
        {
            if (!obj.ContainsKey(key))
                return defaultValue;
            else
                return (T)Convert.ChangeType(obj[key], typeof(T));
        }

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

        public unsafe void FillArea(UnsafeColor* ptr, int startX, int startY, int fillWidth, int fillHeight, UnsafeColor color)
        {
            for (int y = 0; y < fillHeight; y++)
            {
                UnsafeColor* lnDst = ptr + ((y + startY) * Width) + startX;
                for (int x = 0; x < fillWidth; x++)
                {
                    lnDst[x] = color;
                }
            }
        }

        public unsafe void Fill(UnsafeColor* ptr, UnsafeColor color)
        {
            FillArea(ptr, 0, Height, color);
        }

        public abstract void Dispose();
    }
}
