using RomanPort.LibSDR.Components;
using RomanPort.LibSDR.Components.IO.Buffers;
using RomanPort.SpectrumVideoRenderer.Core.Outputs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    public unsafe class FfmpegUtil : IOutputPipe
    {
        public FfmpegUtil(string args, int bufferSize)
        {
            //Create FFMPEG
            ffmpeg = Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });

            //Create buffer
            buffer = new byte[bufferSize];
            bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            bufferPtr = (byte*)bufferHandle.AddrOfPinnedObject();
        }

        public static string EscapeFilename(string filename)
        {
            return "\"" + filename.Replace("\"", "\\\"") + "\"";
        }

        private Process ffmpeg;
        private byte[] buffer;
        private GCHandle bufferHandle;
        private byte* bufferPtr;

        public void Write(byte* ptr, int count)
        {
            while(count > 0)
            {
                //Get block
                int block = Math.Min(count, buffer.Length);

                //Copy
                Utils.Memcpy(bufferPtr, ptr, block);

                //Write
                ffmpeg.StandardInput.BaseStream.Write(buffer, 0, block);
                ffmpeg.StandardInput.BaseStream.Flush();

                //Update state
                ptr += block;
                count -= block;
            }
        }

        public void ClosePipe()
        {
            ffmpeg.StandardInput.BaseStream.Close();
            ffmpeg.WaitForExit();
        }
    }
}
