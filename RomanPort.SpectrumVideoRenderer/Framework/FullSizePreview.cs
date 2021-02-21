using RomanPort.SpectrumVideoRenderer.Framework.Generator;
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
    public partial class FullSizePreview : Form
    {
        public FullSizePreview(ViewGenerator view, Form1 ctx)
        {
            InitializeComponent();
            this.view = view;
            this.ctx = ctx;
            MaximumSize = new Size(view.Width + PADDING + PADDING, view.Height + PADDING + PADDING);
            MinimumSize = MaximumSize;
            Size = MaximumSize;
        }

        private const int PADDING = 12;

        private ViewGenerator view;
        private Form1 ctx;

        private void FullSizePreview_Load(object sender, EventArgs e)
        {
            thumbnailRenderer.BeginPreviewing(ctx.Reader, ctx.BufferSize, view);
        }
    }
}
