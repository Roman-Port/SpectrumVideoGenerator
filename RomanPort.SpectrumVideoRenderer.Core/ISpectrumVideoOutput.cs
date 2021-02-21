using RomanPort.SpectrumVideoRenderer.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core
{
    public interface ISpectrumVideoOutput
    {
        unsafe void Open(int width, int height, int audioRate, int bufferSize);

        unsafe void OutputFrame();
        unsafe void OutputAudio(int count);

        unsafe UnsafeColor* FrameBufferPtr { get; }
        unsafe float* AudioBufferPtr { get; }

        unsafe void Close();
    }
}
