
namespace RomanPort.SpectrumVideoRenderer
{
    partial class SpectrumConfigView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spectrumOffset = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.spectrumDecay = new RomanPort.SpectrumVideoRenderer.Framework.LabeledFloatSlider();
            this.spectrumRange = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.spectrumAttack = new RomanPort.SpectrumVideoRenderer.Framework.LabeledFloatSlider();
            this.spectrumHeight = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.spectrumEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imgHeightLabel = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.decimation = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.offset = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.fftSize = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.imageWidth = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdsBarEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.waterfallSpeed = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.waterfallDecay = new RomanPort.SpectrumVideoRenderer.Framework.LabeledFloatSlider();
            this.waterfallAttack = new RomanPort.SpectrumVideoRenderer.Framework.LabeledFloatSlider();
            this.waterfallHeight = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.waterfallEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.audioOutputSampleRate = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.audioBandwidth = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.audioEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.mpxOffset = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.mpxDecay = new RomanPort.SpectrumVideoRenderer.Framework.LabeledFloatSlider();
            this.mpxRange = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.mpxAttack = new RomanPort.SpectrumVideoRenderer.Framework.LabeledFloatSlider();
            this.mpxHeight = new RomanPort.SpectrumVideoRenderer.Framework.LabeledIntegerSelector();
            this.mpxEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.thumbnailRenderer = new RomanPort.SpectrumVideoRenderer.Framework.ThumbnailRenderer();
            this.btnGeneratePreview = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spectrumOffset);
            this.groupBox1.Controls.Add(this.spectrumDecay);
            this.groupBox1.Controls.Add(this.spectrumRange);
            this.groupBox1.Controls.Add(this.spectrumAttack);
            this.groupBox1.Controls.Add(this.spectrumHeight);
            this.groupBox1.Controls.Add(this.spectrumEnabled);
            this.groupBox1.Location = new System.Drawing.Point(247, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // spectrumOffset
            // 
            this.spectrumOffset.Location = new System.Drawing.Point(123, 60);
            this.spectrumOffset.Maximum = ((long)(10000));
            this.spectrumOffset.Minimum = ((long)(0));
            this.spectrumOffset.Name = "spectrumOffset";
            this.spectrumOffset.Size = new System.Drawing.Size(111, 39);
            this.spectrumOffset.TabIndex = 6;
            this.spectrumOffset.Title = "Offset (dB)";
            this.spectrumOffset.Value = ((long)(0));
            // 
            // spectrumDecay
            // 
            this.spectrumDecay.Location = new System.Drawing.Point(123, 104);
            this.spectrumDecay.Maximum = 1F;
            this.spectrumDecay.Minimum = 0F;
            this.spectrumDecay.Name = "spectrumDecay";
            this.spectrumDecay.Size = new System.Drawing.Size(111, 45);
            this.spectrumDecay.TabIndex = 3;
            this.spectrumDecay.Title = "Decay";
            this.spectrumDecay.Value = 0.5F;
            // 
            // spectrumRange
            // 
            this.spectrumRange.Location = new System.Drawing.Point(6, 60);
            this.spectrumRange.Maximum = ((long)(10000));
            this.spectrumRange.Minimum = ((long)(10));
            this.spectrumRange.Name = "spectrumRange";
            this.spectrumRange.Size = new System.Drawing.Size(111, 39);
            this.spectrumRange.TabIndex = 5;
            this.spectrumRange.Title = "Range (dB)";
            this.spectrumRange.Value = ((long)(200));
            // 
            // spectrumAttack
            // 
            this.spectrumAttack.Location = new System.Drawing.Point(6, 104);
            this.spectrumAttack.Maximum = 1F;
            this.spectrumAttack.Minimum = 0F;
            this.spectrumAttack.Name = "spectrumAttack";
            this.spectrumAttack.Size = new System.Drawing.Size(111, 45);
            this.spectrumAttack.TabIndex = 2;
            this.spectrumAttack.Title = "Attack";
            this.spectrumAttack.Value = 0.5F;
            // 
            // spectrumHeight
            // 
            this.spectrumHeight.Location = new System.Drawing.Point(6, 19);
            this.spectrumHeight.Maximum = ((long)(10000));
            this.spectrumHeight.Minimum = ((long)(10));
            this.spectrumHeight.Name = "spectrumHeight";
            this.spectrumHeight.Size = new System.Drawing.Size(228, 39);
            this.spectrumHeight.TabIndex = 1;
            this.spectrumHeight.Title = "Height";
            this.spectrumHeight.Value = ((long)(200));
            this.spectrumHeight.ValueChanged += new System.EventHandler(this.RefreshHeightLabel);
            // 
            // spectrumEnabled
            // 
            this.spectrumEnabled.AutoSize = true;
            this.spectrumEnabled.Location = new System.Drawing.Point(9, 0);
            this.spectrumEnabled.Name = "spectrumEnabled";
            this.spectrumEnabled.Size = new System.Drawing.Size(71, 17);
            this.spectrumEnabled.TabIndex = 0;
            this.spectrumEnabled.Text = "Spectrum";
            this.spectrumEnabled.UseVisualStyleBackColor = true;
            this.spectrumEnabled.CheckedChanged += new System.EventHandler(this.RefreshHeightLabel);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.imgHeightLabel);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Controls.Add(this.decimation);
            this.groupBox2.Controls.Add(this.offset);
            this.groupBox2.Controls.Add(this.fftSize);
            this.groupBox2.Controls.Add(this.imageWidth);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 191);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Settings";
            // 
            // imgHeightLabel
            // 
            this.imgHeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgHeightLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.imgHeightLabel.Location = new System.Drawing.Point(125, 34);
            this.imgHeightLabel.Name = "imgHeightLabel";
            this.imgHeightLabel.Size = new System.Drawing.Size(109, 23);
            this.imgHeightLabel.TabIndex = 7;
            this.imgHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(125, 19);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(109, 15);
            this.label.TabIndex = 6;
            this.label.Text = "Image Height";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // decimation
            // 
            this.decimation.Location = new System.Drawing.Point(6, 143);
            this.decimation.Maximum = ((long)(10000));
            this.decimation.Minimum = ((long)(1));
            this.decimation.Name = "decimation";
            this.decimation.Size = new System.Drawing.Size(228, 39);
            this.decimation.TabIndex = 5;
            this.decimation.Title = "Decimation Factor";
            this.decimation.Value = ((long)(1));
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(6, 102);
            this.offset.Maximum = ((long)(100000));
            this.offset.Minimum = ((long)(0));
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(228, 39);
            this.offset.TabIndex = 4;
            this.offset.Title = "Offset (Hz)";
            this.offset.Value = ((long)(0));
            // 
            // fftSize
            // 
            this.fftSize.Location = new System.Drawing.Point(6, 60);
            this.fftSize.Maximum = ((long)(65536));
            this.fftSize.Minimum = ((long)(512));
            this.fftSize.Name = "fftSize";
            this.fftSize.Size = new System.Drawing.Size(228, 39);
            this.fftSize.TabIndex = 3;
            this.fftSize.Title = "FFT Size";
            this.fftSize.Value = ((long)(2048));
            // 
            // imageWidth
            // 
            this.imageWidth.Location = new System.Drawing.Point(6, 19);
            this.imageWidth.Maximum = ((long)(10000));
            this.imageWidth.Minimum = ((long)(10));
            this.imageWidth.Name = "imageWidth";
            this.imageWidth.Size = new System.Drawing.Size(113, 39);
            this.imageWidth.TabIndex = 1;
            this.imageWidth.Title = "Image Width";
            this.imageWidth.Value = ((long)(400));
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.rdsBarEnabled);
            this.groupBox3.Location = new System.Drawing.Point(247, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 47);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "The RDS bar will show RDS info at the top.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdsBarEnabled
            // 
            this.rdsBarEnabled.AutoSize = true;
            this.rdsBarEnabled.Location = new System.Drawing.Point(9, 0);
            this.rdsBarEnabled.Name = "rdsBarEnabled";
            this.rdsBarEnabled.Size = new System.Drawing.Size(68, 17);
            this.rdsBarEnabled.TabIndex = 0;
            this.rdsBarEnabled.Text = "RDS Bar";
            this.rdsBarEnabled.UseVisualStyleBackColor = true;
            this.rdsBarEnabled.CheckedChanged += new System.EventHandler(this.RefreshHeightLabel);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.waterfallSpeed);
            this.groupBox4.Controls.Add(this.waterfallDecay);
            this.groupBox4.Controls.Add(this.waterfallAttack);
            this.groupBox4.Controls.Add(this.waterfallHeight);
            this.groupBox4.Controls.Add(this.waterfallEnabled);
            this.groupBox4.Location = new System.Drawing.Point(247, 216);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(242, 140);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Offset/range are controlled by spectrum";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waterfallSpeed
            // 
            this.waterfallSpeed.Location = new System.Drawing.Point(123, 19);
            this.waterfallSpeed.Maximum = ((long)(10000));
            this.waterfallSpeed.Minimum = ((long)(1));
            this.waterfallSpeed.Name = "waterfallSpeed";
            this.waterfallSpeed.Size = new System.Drawing.Size(111, 39);
            this.waterfallSpeed.TabIndex = 4;
            this.waterfallSpeed.Title = "Speed";
            this.waterfallSpeed.Value = ((long)(1));
            // 
            // waterfallDecay
            // 
            this.waterfallDecay.Location = new System.Drawing.Point(123, 88);
            this.waterfallDecay.Maximum = 1F;
            this.waterfallDecay.Minimum = 0F;
            this.waterfallDecay.Name = "waterfallDecay";
            this.waterfallDecay.Size = new System.Drawing.Size(111, 45);
            this.waterfallDecay.TabIndex = 3;
            this.waterfallDecay.Title = "Decay";
            this.waterfallDecay.Value = 0.5F;
            // 
            // waterfallAttack
            // 
            this.waterfallAttack.Location = new System.Drawing.Point(6, 88);
            this.waterfallAttack.Maximum = 1F;
            this.waterfallAttack.Minimum = 0F;
            this.waterfallAttack.Name = "waterfallAttack";
            this.waterfallAttack.Size = new System.Drawing.Size(111, 45);
            this.waterfallAttack.TabIndex = 2;
            this.waterfallAttack.Title = "Attack";
            this.waterfallAttack.Value = 0.5F;
            // 
            // waterfallHeight
            // 
            this.waterfallHeight.Location = new System.Drawing.Point(6, 19);
            this.waterfallHeight.Maximum = ((long)(10000));
            this.waterfallHeight.Minimum = ((long)(10));
            this.waterfallHeight.Name = "waterfallHeight";
            this.waterfallHeight.Size = new System.Drawing.Size(111, 39);
            this.waterfallHeight.TabIndex = 1;
            this.waterfallHeight.Title = "Height";
            this.waterfallHeight.Value = ((long)(200));
            this.waterfallHeight.ValueChanged += new System.EventHandler(this.RefreshHeightLabel);
            // 
            // waterfallEnabled
            // 
            this.waterfallEnabled.AutoSize = true;
            this.waterfallEnabled.Location = new System.Drawing.Point(9, 0);
            this.waterfallEnabled.Name = "waterfallEnabled";
            this.waterfallEnabled.Size = new System.Drawing.Size(68, 17);
            this.waterfallEnabled.TabIndex = 0;
            this.waterfallEnabled.Text = "Waterfall";
            this.waterfallEnabled.UseVisualStyleBackColor = true;
            this.waterfallEnabled.CheckedChanged += new System.EventHandler(this.RefreshHeightLabel);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox6);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Controls.Add(this.audioOutputSampleRate);
            this.groupBox5.Controls.Add(this.audioBandwidth);
            this.groupBox5.Controls.Add(this.audioEnabled);
            this.groupBox5.Location = new System.Drawing.Point(247, 362);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(242, 134);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(184, 107);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(57, 17);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.Text = "Stereo";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 107);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Broadcast FM";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // audioOutputSampleRate
            // 
            this.audioOutputSampleRate.Location = new System.Drawing.Point(6, 62);
            this.audioOutputSampleRate.Maximum = ((long)(192000));
            this.audioOutputSampleRate.Minimum = ((long)(10));
            this.audioOutputSampleRate.Name = "audioOutputSampleRate";
            this.audioOutputSampleRate.Size = new System.Drawing.Size(228, 39);
            this.audioOutputSampleRate.TabIndex = 2;
            this.audioOutputSampleRate.Title = "Output Sample Rate";
            this.audioOutputSampleRate.Value = ((long)(48000));
            // 
            // audioBandwidth
            // 
            this.audioBandwidth.Location = new System.Drawing.Point(6, 19);
            this.audioBandwidth.Maximum = ((long)(10000));
            this.audioBandwidth.Minimum = ((long)(10));
            this.audioBandwidth.Name = "audioBandwidth";
            this.audioBandwidth.Size = new System.Drawing.Size(228, 39);
            this.audioBandwidth.TabIndex = 1;
            this.audioBandwidth.Title = "Filter Bandwidth";
            this.audioBandwidth.Value = ((long)(200));
            // 
            // audioEnabled
            // 
            this.audioEnabled.AutoSize = true;
            this.audioEnabled.Location = new System.Drawing.Point(9, 0);
            this.audioEnabled.Name = "audioEnabled";
            this.audioEnabled.Size = new System.Drawing.Size(53, 17);
            this.audioEnabled.TabIndex = 0;
            this.audioEnabled.Text = "Audio";
            this.audioEnabled.UseVisualStyleBackColor = true;
            this.audioEnabled.CheckedChanged += new System.EventHandler(this.RefreshHeightLabel);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.mpxOffset);
            this.groupBox6.Controls.Add(this.mpxDecay);
            this.groupBox6.Controls.Add(this.mpxRange);
            this.groupBox6.Controls.Add(this.mpxAttack);
            this.groupBox6.Controls.Add(this.mpxHeight);
            this.groupBox6.Controls.Add(this.mpxEnabled);
            this.groupBox6.Location = new System.Drawing.Point(247, 502);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(242, 157);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            // 
            // mpxOffset
            // 
            this.mpxOffset.Location = new System.Drawing.Point(123, 60);
            this.mpxOffset.Maximum = ((long)(10000));
            this.mpxOffset.Minimum = ((long)(0));
            this.mpxOffset.Name = "mpxOffset";
            this.mpxOffset.Size = new System.Drawing.Size(111, 39);
            this.mpxOffset.TabIndex = 6;
            this.mpxOffset.Title = "Offset (dB)";
            this.mpxOffset.Value = ((long)(0));
            // 
            // mpxDecay
            // 
            this.mpxDecay.Location = new System.Drawing.Point(123, 104);
            this.mpxDecay.Maximum = 1F;
            this.mpxDecay.Minimum = 0F;
            this.mpxDecay.Name = "mpxDecay";
            this.mpxDecay.Size = new System.Drawing.Size(111, 45);
            this.mpxDecay.TabIndex = 3;
            this.mpxDecay.Title = "Decay";
            this.mpxDecay.Value = 0.5F;
            // 
            // mpxRange
            // 
            this.mpxRange.Location = new System.Drawing.Point(6, 60);
            this.mpxRange.Maximum = ((long)(10000));
            this.mpxRange.Minimum = ((long)(10));
            this.mpxRange.Name = "mpxRange";
            this.mpxRange.Size = new System.Drawing.Size(111, 39);
            this.mpxRange.TabIndex = 5;
            this.mpxRange.Title = "Range (dB)";
            this.mpxRange.Value = ((long)(200));
            // 
            // mpxAttack
            // 
            this.mpxAttack.Location = new System.Drawing.Point(6, 104);
            this.mpxAttack.Maximum = 1F;
            this.mpxAttack.Minimum = 0F;
            this.mpxAttack.Name = "mpxAttack";
            this.mpxAttack.Size = new System.Drawing.Size(111, 45);
            this.mpxAttack.TabIndex = 2;
            this.mpxAttack.Title = "Attack";
            this.mpxAttack.Value = 0.5F;
            // 
            // mpxHeight
            // 
            this.mpxHeight.Location = new System.Drawing.Point(6, 19);
            this.mpxHeight.Maximum = ((long)(10000));
            this.mpxHeight.Minimum = ((long)(10));
            this.mpxHeight.Name = "mpxHeight";
            this.mpxHeight.Size = new System.Drawing.Size(228, 39);
            this.mpxHeight.TabIndex = 1;
            this.mpxHeight.Title = "Height";
            this.mpxHeight.Value = ((long)(200));
            this.mpxHeight.ValueChanged += new System.EventHandler(this.RefreshHeightLabel);
            // 
            // mpxEnabled
            // 
            this.mpxEnabled.AutoSize = true;
            this.mpxEnabled.Location = new System.Drawing.Point(9, 0);
            this.mpxEnabled.Name = "mpxEnabled";
            this.mpxEnabled.Size = new System.Drawing.Size(97, 17);
            this.mpxEnabled.TabIndex = 0;
            this.mpxEnabled.Text = "MPX Spectrum";
            this.mpxEnabled.UseVisualStyleBackColor = true;
            this.mpxEnabled.CheckedChanged += new System.EventHandler(this.RefreshHeightLabel);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button1);
            this.groupBox7.Controls.Add(this.thumbnailRenderer);
            this.groupBox7.Controls.Add(this.btnGeneratePreview);
            this.groupBox7.Location = new System.Drawing.Point(3, 197);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(238, 462);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Preview";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(163, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Full Size";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // thumbnailRenderer
            // 
            this.thumbnailRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailRenderer.Location = new System.Drawing.Point(6, 19);
            this.thumbnailRenderer.Name = "thumbnailRenderer";
            this.thumbnailRenderer.Size = new System.Drawing.Size(225, 406);
            this.thumbnailRenderer.TabIndex = 1;
            // 
            // btnGeneratePreview
            // 
            this.btnGeneratePreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneratePreview.Location = new System.Drawing.Point(3, 431);
            this.btnGeneratePreview.Name = "btnGeneratePreview";
            this.btnGeneratePreview.Size = new System.Drawing.Size(154, 23);
            this.btnGeneratePreview.TabIndex = 0;
            this.btnGeneratePreview.Text = "Start Previewing";
            this.btnGeneratePreview.UseVisualStyleBackColor = true;
            this.btnGeneratePreview.Click += new System.EventHandler(this.btnGeneratePreview_Click);
            // 
            // SpectrumConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SpectrumConfigView";
            this.Size = new System.Drawing.Size(493, 663);
            this.Load += new System.EventHandler(this.SpectrumConfigView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox spectrumEnabled;
        private Framework.LabeledIntegerSelector spectrumHeight;
        private System.Windows.Forms.GroupBox groupBox2;
        private Framework.LabeledIntegerSelector imageWidth;
        private Framework.LabeledFloatSlider spectrumAttack;
        private Framework.LabeledFloatSlider spectrumDecay;
        private Framework.LabeledIntegerSelector fftSize;
        private Framework.LabeledIntegerSelector spectrumOffset;
        private Framework.LabeledIntegerSelector spectrumRange;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox rdsBarEnabled;
        private System.Windows.Forms.GroupBox groupBox4;
        private Framework.LabeledIntegerSelector waterfallSpeed;
        private Framework.LabeledFloatSlider waterfallDecay;
        private Framework.LabeledFloatSlider waterfallAttack;
        private Framework.LabeledIntegerSelector waterfallHeight;
        private System.Windows.Forms.CheckBox waterfallEnabled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private Framework.LabeledIntegerSelector audioOutputSampleRate;
        private Framework.LabeledIntegerSelector audioBandwidth;
        private System.Windows.Forms.CheckBox audioEnabled;
        private System.Windows.Forms.GroupBox groupBox6;
        private Framework.LabeledIntegerSelector mpxOffset;
        private Framework.LabeledFloatSlider mpxDecay;
        private Framework.LabeledIntegerSelector mpxRange;
        private Framework.LabeledFloatSlider mpxAttack;
        private Framework.LabeledIntegerSelector mpxHeight;
        private System.Windows.Forms.CheckBox mpxEnabled;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.RadioButton radioButton1;
        private Framework.LabeledIntegerSelector decimation;
        private Framework.LabeledIntegerSelector offset;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnGeneratePreview;
        private Framework.ThumbnailRenderer thumbnailRenderer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label imgHeightLabel;
        private System.Windows.Forms.Label label;
    }
}
