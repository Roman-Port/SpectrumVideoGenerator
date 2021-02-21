using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core
{
    public static class SpectrumVideoUtils
    {
        public static string EstimateTime(double secondsSinceStart, double progress)
        {
            double secondsTotal = secondsSinceStart / progress;
            long secondsRemaining = (long)(secondsTotal - secondsSinceStart);
            return FormatTime(secondsRemaining);
        }

        public static string FormatTime(long seconds)
        {
            return $"{((seconds / 60) / 60).ToString().PadLeft(2, '0')}:{((seconds / 60) % 60).ToString().PadLeft(2, '0')}:{(seconds % 60).ToString().PadLeft(2, '0')}";
        }
    }
}
