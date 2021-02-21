using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    public partial class AudioConfigDialog : Form
    {
        public AudioConfigDialog(SpectrumVideoDemodConfig cfg)
        {
            this.cfg = cfg;
            InitializeComponent();
        }

        private SpectrumVideoDemodConfig cfg;

        private void btnChooseOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Title = "Save Audio File";
            fd.Filter = "WAV files (*.wav)|*.wav";
            if (fd.ShowDialog() == DialogResult.OK)
                inputPath.Text = fd.FileName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            cfg.label = inputLabel.Text;
            cfg.outputFilename = inputPath.Text;
            cfg.demodBandwidth = (float)inputBandwidth.Value;
            cfg.outputSampleRate = (int)inputSampleRate.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AudioConfigDialog_Load(object sender, EventArgs e)
        {
            inputLabel.Text = cfg.label;
            inputPath.Text = cfg.outputFilename;
            inputBandwidth.Value = (decimal)cfg.demodBandwidth;
            inputSampleRate.Value = cfg.outputSampleRate;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
