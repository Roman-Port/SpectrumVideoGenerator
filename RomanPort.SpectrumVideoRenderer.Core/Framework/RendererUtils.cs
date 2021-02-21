using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    public static class RendererUtils
    {
        public static string FixedDecimalToString(double value, int decimals)
        {
            //Get decimals as a string
            double multiplier = Math.Pow(10, decimals);
            string decimalsString = ((long)(value * multiplier) % multiplier).ToString().PadRight(decimals, '0');

            //Get the rest of the number as a string and combine it
            return ((long)value).ToString() + "." + decimalsString;
        }
    }
}
