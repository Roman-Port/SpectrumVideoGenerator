using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.Framework
{
    public partial class LabeledIntegerSelector : UserControl
    {
        public LabeledIntegerSelector()
        {
            InitializeComponent();
        }

        public event EventHandler ValueChanged;

        public string Title { get => label.Text; set => label.Text = value; }
        public long Value { get => (long)selector.Value; set => selector.Value = value; }
        public long Maximum { get => (long)selector.Maximum; set => selector.Maximum = value; }
        public long Minimum { get => (long)selector.Minimum; set => selector.Minimum = value; }

        private void selector_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, e);
        }
    }
}
