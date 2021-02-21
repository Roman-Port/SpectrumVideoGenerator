using RomanPort.SimpleFontRenderer;
using RomanPort.SimpleFontRenderer.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    public static class FontStore
    {
        public static readonly FontPack SYSTEM_REGULAR_10;
        public static readonly FontPack SYSTEM_REGULAR_15;
        public static readonly FontPack SYSTEM_REGULAR_20;

        public static readonly FontPack SYSTEM_BOLD_10;
        public static readonly FontPack SYSTEM_BOLD_15;
        public static readonly FontPack SYSTEM_BOLD_20;

        public static readonly FontPack SYSTEM_NARROW_10;
        public static readonly FontPack SYSTEM_NARROW_15;
        public static readonly FontPack SYSTEM_NARROW_20;

        public static readonly FontPack SYSTEM_NARROW_BOLD_10;
        public static readonly FontPack SYSTEM_NARROW_BOLD_15;
        public static readonly FontPack SYSTEM_NARROW_BOLD_20;

        public static readonly FontPack SYSTEM_TALL_BOLD_20;

        static FontStore()
        {
            //Regular
            LoadFontVarients("SYSTEM_REGULAR_10", out SYSTEM_REGULAR_10, out SYSTEM_NARROW_10);
            LoadFontVarients("SYSTEM_REGULAR_15", out SYSTEM_REGULAR_15, out SYSTEM_NARROW_15);
            LoadFontVarients("SYSTEM_REGULAR_20", out SYSTEM_REGULAR_20, out SYSTEM_NARROW_20);

            //Bold
            LoadFontVarients("SYSTEM_BOLD_10", out SYSTEM_BOLD_10, out SYSTEM_NARROW_BOLD_10);
            LoadFontVarients("SYSTEM_BOLD_15", out SYSTEM_BOLD_15, out SYSTEM_NARROW_BOLD_15);
            LoadFontVarients("SYSTEM_BOLD_20", out SYSTEM_BOLD_20, out SYSTEM_NARROW_BOLD_20);

            //Misc
            SYSTEM_TALL_BOLD_20 = SYSTEM_BOLD_20.MakeScaledPack(1, 2);
        }

        public static FontRenderer CreateRenderer(int imageWidth, int imageHeight)
        {
            return new FontRenderer(imageWidth, imageHeight, new BgraPixelFormat());
        }

        private static void LoadFontVarients(string id, out FontPack standard, out FontPack narrow)
        {
            standard = LoadFromResource(id);
            narrow = standard.MakeScaledPack(0.75f, 1);
        }

        private static FontPack LoadFromResource(string id)
        {
            FontPack pack;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RomanPort.SpectrumVideoRenderer.Core.Framework.FontPacks." + id + ".sdrf"))
                pack = FontPack.FromStream(stream);
            return pack;
        }
    }
}
