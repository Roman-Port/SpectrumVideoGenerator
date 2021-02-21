using RomanPort.LibSDR.Components.IO;
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
    public partial class SampleFormatPromptForm : Form
    {
        public SampleFormatPromptForm()
        {
            InitializeComponent();
        }

        public int SampleRate { get => (int)sampleRate.Value; }
        public SampleFormat SampleFormat
        {
            get
            {
                if (sampleFloat.Checked)
                    return SampleFormat.Float32;
                if (sampleShort.Checked)
                    return SampleFormat.Short16;
                if (sampleByte.Checked)
                    return SampleFormat.Byte;
                throw new Exception("Invalid selection");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
