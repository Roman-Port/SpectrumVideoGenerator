using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    [StructLayout(LayoutKind.Explicit, Size = 4, CharSet = CharSet.Ansi)]
    public struct UnsafeColor
    {
        [FieldOffset(3)]
        public byte a;
        [FieldOffset(2)]
        public byte r;
        [FieldOffset(1)]
        public byte g;
        [FieldOffset(0)]
        public byte b;

        public static readonly UnsafeColor WHITE = new UnsafeColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public static readonly UnsafeColor BLACK = new UnsafeColor(byte.MinValue, byte.MinValue, byte.MinValue);
        public static readonly UnsafeColor GRAY = new UnsafeColor(130, 130, 130);

        public UnsafeColor(byte r, byte g, byte b, byte a = byte.MaxValue)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}
