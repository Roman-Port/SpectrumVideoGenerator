using RomanPort.SpectrumVideoRenderer.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Outputs.Pipes
{
    public class NullPipe : IOutputPipe
    {
        public void ClosePipe()
        {
            throw new NotImplementedException();
        }

        public unsafe void Write(byte* ptr, int read)
        {
            
        }
    }
}
