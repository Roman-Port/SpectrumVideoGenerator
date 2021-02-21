using Newtonsoft.Json;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using RomanPort.SpectrumVideoRenderer.GUI.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.GUI
{
    public partial class CanvasEditor : Form
    {
        public CanvasEditor(SpectrumVideoCanvasConfig config)
        {
            this.config = config;
            InitializeComponent();

            //Bind
            canvasPreview.OnCanvasPreviewSizeChanged += CanvasPreview_OnCanvasPreviewSizeChanged;

            //Link
            ConfigureList(componentList, config.components);
            ConfigureList(demodList, config.audio_outputs);
        }

        private SpectrumVideoCanvasConfig config;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set preview canvas
            canvasPreview.SetNewSource(config.source);
            canvasPreview.InvalidateCanvas(config);

            //Set options
            videoWidth.Value = config.video_output.width;
            videoRate.Value = config.video_output.frameRate;
            freqOffset.Value = (decimal)config.baseband.freqOffset;
            decimationRate.Value = config.baseband.decimation;
            decimationAtten.Value = (decimal)config.baseband.decimationAttenuation;
            decimationRatio.Value = (decimal)config.baseband.decimationTransitionRatio;
            label.Text = config.label;
        }

        private void CanvasPreview_OnCanvasPreviewSizeChanged(int delta)
        {
            MaximumSize = new Size(MaximumSize.Width + delta, MaximumSize.Height);
            MinimumSize = new Size(Width + delta, MinimumSize.Height);
            Width += delta;
        }

        private void ConfigureList<T>(ConfigListView<T> view, List<T> list)
        {
            view.Configure(list);
            view.OnChanged += (ConfigListView<T> l) => canvasPreview.InvalidateCanvas(config);
        }

        private void videoWidth_ValueChanged(object sender, EventArgs e)
        {
            config.video_output.width = (int)videoWidth.Value;
            canvasPreview.InvalidateCanvas(config);
        }

        private void videoRate_ValueChanged(object sender, EventArgs e)
        {
            config.video_output.frameRate = (int)videoRate.Value;
            canvasPreview.InvalidateCanvas(config);
        }

        private void freqOffset_ValueChanged(object sender, EventArgs e)
        {
            config.baseband.freqOffset = (long)freqOffset.Value;
            canvasPreview.InvalidateCanvas(config);
        }

        private void decimationRate_ValueChanged(object sender, EventArgs e)
        {
            config.baseband.decimation = (int)decimationRate.Value;
            canvasPreview.InvalidateCanvas(config);
        }

        private void decimationRatio_ValueChanged(object sender, EventArgs e)
        {
            config.baseband.decimationTransitionRatio = (float)decimationRatio.Value;
            canvasPreview.InvalidateCanvas(config);
        }

        private void decimationAtten_ValueChanged(object sender, EventArgs e)
        {
            config.baseband.decimationAttenuation = (int)decimationAtten.Value;
            canvasPreview.InvalidateCanvas(config);
        }

        private void label_TextChanged(object sender, EventArgs e)
        {
            config.label = label.Text;
        }

        private void btnVideoOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Title = "Save Video";
            fd.Filter = "Video Files (*.mp4)|*.mp4";
            if (fd.ShowDialog() == DialogResult.OK)
                config.video_output.filename = fd.FileName;
        }

        private void CanvasEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            canvasPreview.Stop();
        }
    }
}
