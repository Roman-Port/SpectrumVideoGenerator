using RomanPort.SpectrumVideoRenderer.Core.Framework.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    public unsafe class FontWriter
    {
        public static SdrFontPack FONT_8;
        public static SdrFontPack FONT_10;
        public static SdrFontPack FONT_12;
        public static SdrFontPack FONT_12_BOLD;
        public static SdrFontPack FONT_15;

        static FontWriter()
        {
            FONT_8 = SdrFontPack.LoadFromEmbeddedResource("FONT_SYSTEM_REGULAR_8");
            FONT_10 = SdrFontPack.LoadFromEmbeddedResource("FONT_SYSTEM_REGULAR_10");
            FONT_12 = SdrFontPack.LoadFromEmbeddedResource("FONT_SYSTEM_REGULAR_12");
            FONT_12_BOLD = SdrFontPack.LoadFromEmbeddedResource("FONT_SYSTEM_BOLD_12");
            FONT_15 = SdrFontPack.LoadFromEmbeddedResource("FONT_SYSTEM_REGULAR_15");
        }
    }
}
