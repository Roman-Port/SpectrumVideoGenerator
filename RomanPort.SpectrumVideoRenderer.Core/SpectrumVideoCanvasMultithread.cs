using RomanPort.LibSDR.Components;
using RomanPort.LibSDR.Components.General;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RomanPort.SpectrumVideoRenderer.Core
{
    public unsafe class SpectrumVideoCanvasMultithread : SpectrumVideoCanvas
    {
        public SpectrumVideoCanvasMultithread(SpectrumVideoCanvasConfig config, IOutputProvider outputProvider) : base(config, outputProvider)
        {
            
        }

        private Thread threadWorker;

        /// <summary>
        /// Starts worker threads for everything
        /// </summary>
        public void Start()
        {
            //Launch worker
            threadWorker = new Thread(Run);
            threadWorker.Name = "Canvas Worker Thread A";
            threadWorker.IsBackground = true;
            threadWorker.Start();
        }
    }
}
