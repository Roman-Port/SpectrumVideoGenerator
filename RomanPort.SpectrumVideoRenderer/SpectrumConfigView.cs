using RomanPort.LibSDR.Framework.Components.IO.WAV;
using RomanPort.SpectrumVideoRenderer.Framework;
using RomanPort.SpectrumVideoRenderer.Framework.Generator;
using RomanPort.SpectrumVideoRenderer.Framework.Generator.Components;
using RomanPort.SpectrumVideoRenderer.Framework.Saved;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer
{
    public partial class SpectrumConfigView : UserControl
    {
        public SpectrumConfigView()
        {
            InitializeComponent();
        }

        private Form1 ctx;

        public void LoadInfo(SavedViewData info, Form1 ctx)
        {
            this.ctx = ctx;
            imageWidth.Value = info.imageWidth;
            fftSize.Value = info.fftSize;
            offset.Minimum = 0;
            offset.Maximum = info.sampleRate / 2;
            offset.Value = info.offset;
            decimation.Minimum = 1;
            decimation.Maximum = 200;
            decimation.Value = info.decimation;
            rdsBarEnabled.Checked = info.rdsBarEnabled;
            spectrumEnabled.Checked = info.spectrumEnabled;
            spectrumHeight.Value = info.spectrumHeight;
            spectrumRange.Value = info.spectrumRange;
            spectrumOffset.Value = info.spectrumOffset;
            spectrumAttack.Value = info.spectrumAttack;
            spectrumDecay.Value = info.spectrumDecay;
            waterfallEnabled.Checked = info.waterfallEnabled;
            waterfallHeight.Value = info.waterfallHeight;
            waterfallSpeed.Value = info.waterfallSpeed;
            waterfallAttack.Value = info.waterfallAttack;
            waterfallDecay.Value = info.waterfallDecay;
            audioEnabled.Checked = info.audioEnabled;
            audioBandwidth.Maximum = info.sampleRate/2;
            audioBandwidth.Minimum = 10;
            audioBandwidth.Value = info.audioBandwidth;
            audioOutputSampleRate.Value = info.audioOutputSampleRate;
            //demodulator
            mpxEnabled.Checked = info.mpxEnabled;
            mpxHeight.Value = info.mpxHeight;
            mpxRange.Value = info.mpxRange;
            mpxOffset.Value = info.mpxOffset;
            mpxAttack.Value = info.mpxAttack;
            mpxDecay.Value = info.mpxDecay;
        }

        public SavedViewData SaveInfo()
        {
            return new SavedViewData
            {
                name = "",
                outputPath = "",
                imageWidth = (int)imageWidth.Value,
                fftSize = (int)fftSize.Value,
                offset = offset.Value,
                decimation = decimation.Value,
                rdsBarEnabled = rdsBarEnabled.Checked,
                spectrumEnabled = spectrumEnabled.Checked,
                spectrumHeight = (int)spectrumHeight.Value,
                spectrumRange = (int)spectrumRange.Value,
                spectrumOffset = (int)spectrumOffset.Value,
                spectrumAttack = spectrumAttack.Value,
                spectrumDecay = spectrumDecay.Value,
                waterfallEnabled = waterfallEnabled.Checked,
                waterfallHeight = (int)waterfallHeight.Value,
                waterfallSpeed = (int)waterfallSpeed.Value,
                waterfallAttack = waterfallAttack.Value,
                waterfallDecay = waterfallDecay.Value,
                audioEnabled = audioEnabled.Checked,
                audioBandwidth = audioBandwidth.Value,
                audioOutputSampleRate = audioOutputSampleRate.Value,
                audioDemodulator = GetChosenDemodulator(),
                mpxEnabled = mpxEnabled.Checked,
                mpxHeight = (int)mpxHeight.Value,
                mpxRange = (int)mpxRange.Value,
                mpxOffset = (int)mpxOffset.Value,
                mpxAttack = mpxAttack.Value,
                mpxDecay = mpxDecay.Value
            };
        }

        public SavedDataDemodulator GetChosenDemodulator()
        {
            if (radioButton1.Checked && !checkBox6.Checked)
                return SavedDataDemodulator.BCAST_FM_MONO;
            else if (radioButton1.Checked && checkBox6.Checked)
                return SavedDataDemodulator.BCAST_FM_STEREO;
            else
                throw new Exception("Unknown demodulator");
        }

        private void btnGeneratePreview_Click(object sender, EventArgs e)
        {
            if(thumbnailRenderer.IsPreviewing)
            {
                //Stop
                thumbnailRenderer.StopPreviewing();
                btnGeneratePreview.Text = "Start Previewing";
                button1.Enabled = true;
            } else
            {
                //Start
                ViewGenerator generator = new ViewGenerator(SaveInfo(), ctx.BufferSize, ctx.Reader.SampleRate);
                thumbnailRenderer.BeginPreviewing(ctx.Reader, ctx.BufferSize, generator);
                btnGeneratePreview.Text = "Stop Previewing";
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewGenerator generator = new ViewGenerator(SaveInfo(), ctx.BufferSize, ctx.Reader.SampleRate);
            FullSizePreview window = new FullSizePreview(generator, ctx);
            window.ShowDialog();
        }

        public ViewGenerator GetGenerator()
        {
            return new ViewGenerator(SaveInfo(), ctx.BufferSize, ctx.Reader.SampleRate);
        }

        private void RefreshHeightLabel(object sender, EventArgs e)
        {
            RefreshHeightLabel();
        }

        private void RefreshHeightLabel()
        {
            long height = 0;
            if (rdsBarEnabled.Checked)
                height += ComponentRDSBar.RDS_BAR_HEIGHT;
            if (spectrumEnabled.Checked)
                height += spectrumHeight.Value;
            if (waterfallEnabled.Checked)
                height += waterfallHeight.Value;
            if (mpxEnabled.Checked)
                height += mpxHeight.Value;
            imgHeightLabel.Text = height.ToString();
        }

        private void SpectrumConfigView_Load(object sender, EventArgs e)
        {
            RefreshHeightLabel();
        }
    }
}
