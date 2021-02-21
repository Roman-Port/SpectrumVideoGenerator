using RomanPort.LibSDR.Components;
using RomanPort.LibSDR.Components.FFT;
using RomanPort.LibSDR.Components.FFT.Generators;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.ComponentResources
{
    public unsafe class FftResource : SpectrumVideoComponentResource, IFftMutatorSource
    {
        public FftResource(string tag, int bins, bool isHalf)
        {
            //Set
            this.tag = tag;
            this.bins = bins;
            this.isHalf = isHalf;

            //Create
            fft = new FFTGenerator(bins, isHalf);
            buffer = UnsafeBuffer.Create(bins, out bufferPtr);
        }

        public static FftResource GetFFT(CanvasContext ctx, string tag, int bins, bool isHalf)
        {
            //Try to find
            FftResource resource = ctx.FindComponentResource<FftResource>(x => x.Tag == tag && x.Bins == bins && x.IsHalf == isHalf);
            if (resource != null)
                return resource;

            //Add
            return ctx.AddResource(new FftResource(tag, bins, isHalf));
        }

        private FFTGenerator fft;
        private UnsafeBuffer buffer;
        private float* bufferPtr;
        private bool fftCacheValid;

        private string tag;
        private int bins;
        private bool isHalf;

        public string Tag { get => tag; }
        public int Bins { get => bins; }
        public bool IsHalf { get => isHalf; }

        public override void OnFrame(Complex* samples, int count)
        {
            fft.AddSamples(samples, count);
            fftCacheValid = false;
        }

        public float* ProcessFFT(out int fftBins)
        {
            //Check if cache is dirty
            if(!fftCacheValid)
            {
                float* frame = fft.ProcessFFT(out fftBins);
                Utils.Memcpy(bufferPtr, frame, fftBins * sizeof(float));
                fftCacheValid = true;
            }

            //Respond with cache
            fftBins = bins;
            return bufferPtr;
        }

        public override void OnClosed()
        {
            
        }
    }
}
