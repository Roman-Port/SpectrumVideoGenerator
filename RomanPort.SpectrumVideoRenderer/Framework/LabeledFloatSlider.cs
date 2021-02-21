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
    public partial class LabeledFloatSlider : UserControl
    {
        public LabeledFloatSlider()
        {
            InitializeComponent();
        }

        public event EventHandler ValueChanged;

        private const float SCALE = 1000;

        public string Title { get => label.Text; set => label.Text = value; }
        public float Value { get => selector.Value / SCALE; set => selector.Value = (int)(value * SCALE); }
        public float Maximum { get => selector.Maximum / SCALE; set => selector.Maximum = (int)(value * SCALE); }
        public float Minimum { get => selector.Minimum / SCALE; set => selector.Minimum = (int)(value * SCALE); }

        private void selector_Scroll(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, e);
        }
    }
}
