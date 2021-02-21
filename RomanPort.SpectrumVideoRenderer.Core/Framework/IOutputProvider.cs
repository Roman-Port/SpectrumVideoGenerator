using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    public interface IOutputProvider
    {
        IOutputPipe GetVideoOutput(string filename, int width, int height, int framerate, int bufferSize);
        IOutputPipe GetAudioOutput(string filename, int rate, int bufferSize);
    }
}
