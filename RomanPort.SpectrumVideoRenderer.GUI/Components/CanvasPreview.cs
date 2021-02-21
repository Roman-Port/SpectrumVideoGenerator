using RomanPort.LibSDR.Components;
using RomanPort.SpectrumVideoRenderer.Core;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using RomanPort.SpectrumVideoRenderer.Core.Outputs.Pipes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    public delegate void CanvasPreview_SizeChangedArgs(int delta);

    public unsafe partial class CanvasPreview : UserControl, IOutputProvider, IOutputPipe, IDisposable
    {
        public CanvasPreview()
        {
            InitializeComponent();
        }

        private SpectrumVideoCanvasConfig config;
        private volatile bool previewInvalidated = true;
        private volatile bool previewRunning = true;
        private bool previewError = false;

        private Thread worker;
        private SpectrumVideoSource source;
        private string statusString = "";
        private System.Windows.Forms.Timer statusTimer;

        private UnsafeBuffer imageBuffer;
        private UnsafeColor* imageBufferPtr;
        private int imageBufferWidth;
        private int imageBufferHeight;
        private int scrollOffset;

        private int imageWidth;
        private int imageHeight;
        private int imageFrameRate;

        public event CanvasPreview_SizeChangedArgs OnCanvasPreviewSizeChanged;

        public void SetNewSource(SpectrumVideoFileConfig sourceCfg)
        {
            if (!SpectrumVideoSource.OpenSource(sourceCfg, out source))
                throw new Exception("Source file is incorrectly configured.");
        }

        public void InvalidateCanvas(SpectrumVideoCanvasConfig config)
        {
            this.config = config;
            previewInvalidated = true;
            previewError = false;
        }

        public void Stop()
        {
            previewRunning = false;
        }

        private void PreviewWorker()
        {
            SpectrumVideoCanvas canvas = null;
            int frames = 0;
            Stopwatch timer = new Stopwatch();
            while (previewRunning)
            {
                //If the config is not yet set, abort
                if(config == null)
                {
                    Thread.Sleep(100);
                    continue;
                }
                
                //Process
                try
                {
                    //Update preview if needed
                    if (previewInvalidated)
                    {
                        //Dispose of old bits
                        canvas?.Dispose();

                        //Create new canvas
                        statusString = "Creating...";
                        canvas = new SpectrumVideoCanvas(source, config, this);

                        //Set flag
                        timer.Restart();
                        frames = 0;
                        previewInvalidated = false;
                    }

                    //If the canvas has no components, stop
                    if(config.components.Count == 0)
                    {
                        statusString = "No components! Add one in the \"components\" section.";
                        Thread.Sleep(100);
                        continue;
                    }

                    //Tick canvas
                    if (!canvas.TickFrame())
                        source.PositionSamples = 0; //Reached end. Rewind
                    frames++;

                    //Create status
                    double timeSinceStart = timer.Elapsed.TotalSeconds;
                    double progress = (double)frames / canvas.TotalFrames;
                    statusString = $"{imageWidth}x{imageHeight}, {(frames / timeSinceStart).ToString("0.00")} FPS, {((frames / timeSinceStart) / imageFrameRate).ToString("0.00")}x, {SpectrumVideoUtils.FormatTime((long)(timeSinceStart / progress))} estimated time";
                } catch (Exception ex)
                {
                    //Notify of the error
                    MessageBox.Show($"There's a problem with the canvas using the settings you've given: {ex.Message}\n\nThis error was thrown {ex.StackTrace}", "Canvas Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusString = "Error with the canvas settings";

                    //Set flags
                    previewError = true;
                    config = null;
                }
            }

            //Stop
            canvas?.Dispose();
            Dispose();
        }

        public void Dispose()
        {
            source.Close();
            imageBuffer.Dispose();
        }

        public IOutputPipe GetVideoOutput(string filename, int width, int height, int framerate, int bufferSize)
        {
            //Set settings
            imageWidth = width;
            imageHeight = height;
            imageFrameRate = framerate;

            //Configure UI
            Invoke((MethodInvoker)delegate
            {
                //Resize
                int delta = (width - previewCanvas.Width);
                Width += delta;
                OnCanvasPreviewSizeChanged?.Invoke(delta);

                //Set up scrollbar regardless
                ConfigureScrollbar();
            });

            return this;
        }

        public IOutputPipe GetAudioOutput(string filename, int rate, int bufferSize)
        {
            return new NullPipe();
        }

        public void Write(byte* ptr, int read)
        {
            Utils.Memcpy(imageBufferPtr, ptr + (scrollOffset * imageBufferWidth * 4), Math.Min(imageBufferWidth * imageBufferHeight * 4, read));
            previewCanvas.Invalidate();
        }

        private void UpdateScrollbar()
        {
            //previewCanvasScroll.Minimum = 0;
            //previewCanvasScroll.Maximum = Math.Max(0, imageHeight - previewHeight);
        }

        private void CanvasPreview_Load(object sender, EventArgs e)
        {
            //Make worker
            worker = new Thread(PreviewWorker);
            worker.Name = "Preview Canvas Worker";
            worker.IsBackground = true;
            worker.Start();

            //Create UI update timer
            statusTimer = new System.Windows.Forms.Timer();
            statusTimer.Interval = 10;
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            status.Text = statusString;
        }

        private void previewCanvasScroll_Scroll(object sender, ScrollEventArgs e)
        {
            scrollOffset = previewCanvasScroll.Value;
        }

        private void CanvasPreview_SizeChanged(object sender, EventArgs e)
        {
            //Set settings
            imageBufferWidth = previewCanvas.Width;
            imageBufferHeight = previewCanvas.Height;

            //Create new image buffer
            imageBuffer?.Dispose();
            imageBuffer = UnsafeBuffer.Create(imageBufferWidth * imageBufferHeight, out imageBufferPtr);

            //Configure scroll
            ConfigureScrollbar();

            //Apply
            previewCanvas.Image = new Bitmap(imageBufferWidth, imageBufferHeight, imageBufferWidth * sizeof(UnsafeColor), System.Drawing.Imaging.PixelFormat.Format32bppArgb, (IntPtr)imageBufferPtr);
        }

        private void ConfigureScrollbar()
        {
            //Configure scrollbar
            int max = Math.Max(0, imageHeight - imageBufferHeight);
            scrollOffset = Math.Min(scrollOffset, max);

            //Set
            previewCanvasScroll.Maximum = max;
            previewCanvasScroll.Value = scrollOffset;
        }

        public void ClosePipe()
        {
            //Do nothing
        }
    }
}
