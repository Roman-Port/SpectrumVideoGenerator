using RomanPort.SpectrumVideoRenderer.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Outputs
{
    public class FfmpegOutputProvider : WavAudioOutputProvider
    {
        public override unsafe IOutputPipe GetVideoOutput(string filename, int width, int height, int framerate, int bufferSize)
        {
            return new FfmpegUtil($"-y -f rawvideo -pix_fmt bgra -s {width}x{height} -r {framerate} -i - {FfmpegUtil.EscapeFilename(filename)}", width * height * sizeof(UnsafeColor));
        }
    }
}
