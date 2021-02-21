using RomanPort.LibSDR.Framework;
using RomanPort.LibSDR.Framework.Components.IO.WAV;
using RomanPort.LibSDR.Framework.Components.Resamplers.Arbitrary;
using RomanPort.LibSDR.Framework.Util;
using RomanPort.LibSDR.UI.Framework;
using RomanPort.SpectrumVideoRenderer.Framework.Generator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer
{
    public partial class RenderingForm : Form
    {
        public RenderingForm(WavFileReader wav, ViewGenerator generator)
        {
            InitializeComponent();
            this.wav = wav;
            this.generator = generator;
        }

        private WavFileReader wav;
        private ViewGenerator generator;
        private Thread workerThread;
        private volatile bool requestClose;
        private volatile bool hasCompleted;

        private unsafe void RunWorker()
        {
            //Open pixel buffer
            byte[] pixelBuffer = new byte[generator.Height * generator.Width * sizeof(UnsafeColor)];
            GCHandle pixelBufferHandle = GCHandle.Alloc(pixelBuffer, GCHandleType.Pinned);
            UnsafeColor* pixelBufferPtr = (UnsafeColor*)pixelBufferHandle.AddrOfPinnedObject();

            //Create IQ buffer
            UnsafeBuffer iqBuffer = UnsafeBuffer.Create(generator.BufferSize, sizeof(Complex));
            Complex* iqBufferPtr = (Complex*)iqBuffer;

            //Create audio buffers
            byte[] audioBuffer = new byte[generator.BufferSize * 2 * sizeof(float)];
            GCHandle audioBufferHandle = GCHandle.Alloc(audioBuffer, GCHandleType.Pinned);
            float* audioBufferPtr = (float*)audioBufferHandle.AddrOfPinnedObject();
            float* audioLBufferPtr = audioBufferPtr;
            float* audioRBufferPtr = (audioLBufferPtr + generator.BufferSize);

            //Create resampler
            ArbitraryFloatResampler resamplerA = new ArbitraryFloatResampler(generator.OutputAudioRate, 48000, generator.BufferSize);
            ArbitraryFloatResampler resamplerB = new ArbitraryFloatResampler(generator.OutputAudioRate, 48000, generator.BufferSize);

            //Create pipes for FFMPEG
            string videoPipeName = $"SpectrumVideoRenderer{Process.GetCurrentProcess().Id}Video";
            string audioPipeName = $"SpectrumVideoRenderer{Process.GetCurrentProcess().Id}Audio";
            NamedPipeServerStream videoPipe = new NamedPipeServerStream(videoPipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 10000, 10000);
            NamedPipeServerStream audioPipe = new NamedPipeServerStream(audioPipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 10000, 10000);

            //Start FFMPEG
            Process encoder = Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-y -f rawvideo -pix_fmt bgra -s {generator.Width}x{generator.Height} -r 30 -i \\\\.\\pipe\\{videoPipeName} -f f32le -ar 48000 -ac 2 -i \\\\.\\pipe\\{audioPipeName} E:\\test_video.mp4",
                RedirectStandardInput = true,
                UseShellExecute = false
            });

            //Make sure WAV is at the beginning
            wav.PositionSamples = 0;

            //Process
            DateTime startTime = DateTime.UtcNow;
            DateTime lastProgressUpdate = DateTime.MinValue;
            int read;
            do
            {
                //Read
                read = wav.Read(iqBufferPtr, generator.BufferSize);

                //Process
                int audioRead = generator.ProcessFrame(iqBufferPtr, pixelBufferPtr, audioLBufferPtr, audioRBufferPtr, read);

                //Write pixels
                if (!videoPipe.IsConnected)
                    videoPipe.WaitForConnection();
                videoPipe.WriteAsync(pixelBuffer, 0, pixelBuffer.Length);

                //Add samples to resamplers
                resamplerA.Input(audioLBufferPtr, audioRead, 1);
                resamplerB.Input(audioRBufferPtr, audioRead, 1);

                //Read audio back and merge it into one stream
                do
                {
                    //Read
                    resamplerA.Output(audioBufferPtr, generator.BufferSize, 2);
                    audioRead = resamplerB.Output(audioBufferPtr + 1, generator.BufferSize, 2);

                    //Write to stream
                    if (!audioPipe.IsConnected)
                        audioPipe.WaitForConnection();
                    audioPipe.WriteAsync(audioBuffer, 0, audioRead * 2 * sizeof(float));
                } while (audioRead != 0);

                //Update status if needed
                if((DateTime.UtcNow - lastProgressUpdate).TotalMilliseconds > 100)
                {
                    float progress = (float)wav.PositionSamples / wav.LengthSamples;
                    long totalSeconds = (long)((DateTime.UtcNow - startTime).TotalSeconds / progress);
                    long remainingSeconds = (long)(totalSeconds - (DateTime.UtcNow - startTime).TotalSeconds);
                    string statusText = $"Rendering... {(remainingSeconds / 60 / 60).ToString().PadLeft(2, '0')}:{((remainingSeconds / 60) % 60).ToString().PadLeft(2, '0')}:{(remainingSeconds % 60).ToString().PadLeft(2, '0')} remaining, {Math.Round(progress*100, 2)}%";
                    Invoke((MethodInvoker)delegate
                    {
                        status.Text = statusText;
                        progressBar.Value = (int)(progress * 1000);
                    });
                    lastProgressUpdate = DateTime.UtcNow;
                }
            } while (read != 0 && !requestClose);

            //Update status
            Invoke((MethodInvoker)delegate
            {
                status.Text = "Finishing up rendering...";
                btnCancel.Enabled = false;
            });

            //Tell FFMPEG to stop and wait for it to do so
            audioPipe.Close();
            videoPipe.Close();
            encoder.WaitForExit();

            //Clean up
            audioBufferHandle.Free();
            pixelBufferHandle.Free();
            iqBuffer.Dispose();
            resamplerA.Dispose();
            resamplerB.Dispose();

            //Close
            hasCompleted = true;
            Invoke((MethodInvoker)delegate
            {
                Close();
            });
        }

        private void RenderingForm_Load(object sender, EventArgs e)
        {
            workerThread = new Thread(RunWorker);
            workerThread.IsBackground = true;
            workerThread.Name = "Renderer Worker";
            workerThread.Start();
        }

        private void RenderingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!hasCompleted)
            {
                RequestClose();
                e.Cancel = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RequestClose();
        }

        private void RequestClose()
        {
            btnCancel.Text = "Exiting...";
            btnCancel.Enabled = false;
            requestClose = true;
        }
    }
}
