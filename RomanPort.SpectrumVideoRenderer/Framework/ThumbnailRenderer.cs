using RomanPort.LibSDR.Framework;
using RomanPort.LibSDR.Framework.Components.IO.WAV;
using RomanPort.LibSDR.Framework.Util;
using RomanPort.LibSDR.UI.Framework;
using RomanPort.SpectrumVideoRenderer.Framework.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.Framework
{
    public unsafe class ThumbnailRenderer : RawDrawableView
    {
        protected override void DrawableViewReset(int width, int height)
        {
            //Fill with black
            for (int y = 0; y < height; y++)
            {
                UnsafeColor* lnDst = pixels + (y * width);
                for (int x = 0; x < width; x++)
                {
                    lnDst[x] = new UnsafeColor(0, 0, 0);
                }
            }
        }

        protected override void RenderDrawableView(int width, int height)
        {
            
        }

        public bool IsPreviewing { get => isPreviewing; }

        private ViewGenerator view;
        private WavFileReader reader;
        private int bufferSize;
        private UnsafeBuffer fullSizeBuffer;
        private UnsafeColor* fullSizePtr;
        private UnsafeBuffer iqBuffer;
        private Complex* iqPtr;
        private UnsafeBuffer audioBuffer;
        private float* audioLPtr;
        private float* audioRPtr;
        private Thread worker;
        private volatile bool isPreviewing;

        public void BeginPreviewing(WavFileReader reader, int bufferSize, ViewGenerator view)
        {
            //Set
            this.view = view;
            this.bufferSize = bufferSize;
            this.reader = reader;
            isPreviewing = true;

            //Create buffers
            fullSizeBuffer = UnsafeBuffer.Create(view.Width * view.Height, out fullSizePtr);
            iqBuffer = UnsafeBuffer.Create(bufferSize, out iqPtr);
            audioBuffer = UnsafeBuffer.Create(bufferSize * 2, out audioLPtr);
            audioRPtr = audioLPtr + bufferSize;

            //Spawn worker thread
            worker = new Thread(WorkerThread);
            worker.IsBackground = true;
            worker.Start();
        }

        public void StopPreviewing()
        {
            isPreviewing = false;
        }

        private void WorkerThread()
        {
            //Run
            while (isPreviewing)
            {
                //Run
                ProcessFrame();

                //Update
                Invoke((MethodInvoker)delegate
                {
                    Invalidate();
                });
            }

            //Clean up
            fullSizeBuffer.Dispose();
            iqBuffer.Dispose();
            audioBuffer.Dispose();
        }

        private void ProcessFrame()
        {
            //Load samples
            int read = reader.Read(iqPtr, bufferSize);

            //Process
            view.ProcessFrame(iqPtr, fullSizePtr, audioLPtr, audioRPtr, read);

            //Resize to the bounds of this image
            float resizeScaleX = view.Width / (float)pixelsWidth;
            float resizeScaleY = view.Width / (float)pixelsHeight;
            float resizeScale = Math.Max(resizeScaleX, resizeScaleY);

            //Transfer
            for (int y = 0; y<pixelsHeight; y++)
            {
                if ((int)(y * resizeScale) >= view.Height)
                    break;
                UnsafeColor* lnSrc = fullSizePtr + ((int)(y * resizeScale) * view.Width);
                UnsafeColor* lnDst = pixels + (y * pixelsWidth);
                for(int x = 0; x<pixelsWidth; x++)
                {
                    if((int)(x * resizeScale) < view.Width)
                        lnDst[x] = lnSrc[(int)(x * resizeScale)];
                }
            }

            Invalidate();
        }
    }
}
