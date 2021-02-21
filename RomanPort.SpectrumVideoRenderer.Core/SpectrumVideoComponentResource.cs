using RomanPort.LibSDR.Components;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core
{
    public abstract class SpectrumVideoComponentResource
    {
        public unsafe abstract void OnFrame(Complex* samples, int count);
        public abstract void OnClosed();
    }
}
