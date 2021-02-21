using RomanPort.LibSDR.Demodulators;
using RomanPort.SimpleFontRenderer;
using RomanPort.SpectrumVideoRenderer.Core.Outputs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    public interface CanvasContext
    {
        int DecimatedSampleRate { get; }
        int ImageWidth { get; }
        int ImageHeight { get; }
        int BufferSize { get; }
        IOutputProvider OutputProvider { get; }
        FontRenderer TextRenderer { get; }
        T FindComponentResource<T>(Expression<Func<T, bool>> query) where T : SpectrumVideoComponentResource;
        T AddResource<T>(T component) where T : SpectrumVideoComponentResource;
    }
}
