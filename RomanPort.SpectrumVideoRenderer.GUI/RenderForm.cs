using RomanPort.SpectrumVideoRenderer.Core;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using RomanPort.SpectrumVideoRenderer.Core.Outputs;
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

namespace RomanPort.SpectrumVideoRenderer.GUI
{
    public partial class RenderForm : Form
    {
        public RenderForm(List<SpectrumVideoCanvasConfig> canvasConfigs)
        {
            InitializeComponent();
            this.canvasConfigs = canvasConfigs;
        }

        private List<SpectrumVideoCanvasConfig> canvasConfigs;
        private volatile bool abort;
        private volatile bool exiting;
        private Thread worker;

        private void RenderForm_Load(object sender, EventArgs e)
        {
            worker = new Thread(Worker);
            worker.Name = "Render Worker";
            worker.IsBackground = true;
            worker.Start();
        }

        private void Worker()
        {
            foreach(var c in canvasConfigs)
            {
                //Compile canvas
                FfmpegOutputProvider output = new FfmpegOutputProvider();
                var canvas = new SpectrumVideoCanvas(c, output);

                //Start timer
                Stopwatch timer = new Stopwatch();
                timer.Start();

                //Loop
                while(!abort && canvas.TickFrame())
                {
                    //Set UI
                    Invoke((MethodInvoker)delegate
                    {
                        statusText.Text = $"Rendering \"{canvas.Label}\"... ({canvas.ComputedFrames} of {canvas.TotalFrames} frames)";
                        statusRight.Text = SpectrumVideoUtils.EstimateTime(timer.Elapsed.Seconds, canvas.Progress) + " remaining";
                        statusBar.Maximum = (int)canvas.TotalFrames;
                        statusBar.Value = canvas.ComputedFrames;
                    });
                }

                //Clean up
                canvas.Close();
                canvas.Dispose();

                //Check if we should abort
                if (abort)
                    break;
            }

            //Done
            Invoke((MethodInvoker)delegate
            {
                exiting = true;
                DialogResult = abort ? DialogResult.Cancel : DialogResult.OK;
                Close();
            });
        }

        private void RenderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!exiting)
            {
                e.Cancel = true;
                abort = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            abort = true;
            btnCancel.Text = "Canceling...";
            btnCancel.Enabled = false;
        }
    }
}
