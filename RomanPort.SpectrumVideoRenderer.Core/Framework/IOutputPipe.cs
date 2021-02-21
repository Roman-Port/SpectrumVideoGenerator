using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    public interface IOutputPipe
    {
        unsafe void Write(byte* ptr, int read);
        void ClosePipe();
    }
}
