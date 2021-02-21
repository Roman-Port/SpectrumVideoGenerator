
namespace RomanPort.SpectrumVideoRenderer.GUI
{
    partial class CanvasEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.freqOffset = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.decimationAtten = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.decimationRatio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.decimationRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVideoOutput = new System.Windows.Forms.Button();
            this.videoWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.videoRate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.componentList = new RomanPort.SpectrumVideoRenderer.GUI.Components.Lists.ComponentListView();
            this.demodList = new RomanPort.SpectrumVideoRenderer.GUI.Components.Lists.AudioDemodulatorListView();
            this.canvasPreview = new RomanPort.SpectrumVideoRenderer.GUI.Components.CanvasPreview();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimationAtten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimationRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimationRate)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoRate)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.freqOffset);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.decimationAtten);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.decimationRatio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.decimationRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(310, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 59);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Baseband";
            // 
            // freqOffset
            // 
            this.freqOffset.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freqOffset.Location = new System.Drawing.Point(9, 32);
            this.freqOffset.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.freqOffset.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.freqOffset.Name = "freqOffset";
            this.freqOffset.Size = new System.Drawing.Size(106, 20);
            this.freqOffset.TabIndex = 7;
            this.freqOffset.ThousandsSeparator = true;
            this.freqOffset.ValueChanged += new System.EventHandler(this.freqOffset_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Freq Offset";
            // 
            // decimationAtten
            // 
            this.decimationAtten.Location = new System.Drawing.Point(289, 32);
            this.decimationAtten.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.decimationAtten.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.decimationAtten.Name = "decimationAtten";
            this.decimationAtten.Size = new System.Drawing.Size(78, 20);
            this.decimationAtten.TabIndex = 5;
            this.decimationAtten.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.decimationAtten.ValueChanged += new System.EventHandler(this.decimationAtten_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Attenuation";
            // 
            // decimationRatio
            // 
            this.decimationRatio.DecimalPlaces = 2;
            this.decimationRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.decimationRatio.Location = new System.Drawing.Point(205, 32);
            this.decimationRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.decimationRatio.Name = "decimationRatio";
            this.decimationRatio.Size = new System.Drawing.Size(78, 20);
            this.decimationRatio.TabIndex = 3;
            this.decimationRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.decimationRatio.ValueChanged += new System.EventHandler(this.decimationRatio_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transition Ratio";
            // 
            // decimationRate
            // 
            this.decimationRate.Location = new System.Drawing.Point(121, 32);
            this.decimationRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.decimationRate.Name = "decimationRate";
            this.decimationRate.Size = new System.Drawing.Size(78, 20);
            this.decimationRate.TabIndex = 1;
            this.decimationRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.decimationRate.ValueChanged += new System.EventHandler(this.decimationRate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Decimation";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnVideoOutput);
            this.groupBox2.Controls.Add(this.videoWidth);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.videoRate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(310, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 59);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video";
            // 
            // btnVideoOutput
            // 
            this.btnVideoOutput.Location = new System.Drawing.Point(261, 16);
            this.btnVideoOutput.Name = "btnVideoOutput";
            this.btnVideoOutput.Size = new System.Drawing.Size(106, 36);
            this.btnVideoOutput.TabIndex = 8;
            this.btnVideoOutput.Text = "Choose Output...";
            this.btnVideoOutput.UseVisualStyleBackColor = true;
            this.btnVideoOutput.Click += new System.EventHandler(this.btnVideoOutput_Click);
            // 
            // videoWidth
            // 
            this.videoWidth.Location = new System.Drawing.Point(9, 32);
            this.videoWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.videoWidth.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.videoWidth.Name = "videoWidth";
            this.videoWidth.Size = new System.Drawing.Size(106, 20);
            this.videoWidth.TabIndex = 7;
            this.videoWidth.ThousandsSeparator = true;
            this.videoWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.videoWidth.ValueChanged += new System.EventHandler(this.videoWidth_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Width";
            // 
            // videoRate
            // 
            this.videoRate.Location = new System.Drawing.Point(121, 32);
            this.videoRate.Maximum = new decimal(new int[] {
            260,
            0,
            0,
            0});
            this.videoRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.videoRate.Name = "videoRate";
            this.videoRate.Size = new System.Drawing.Size(78, 20);
            this.videoRate.TabIndex = 1;
            this.videoRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.videoRate.ValueChanged += new System.EventHandler(this.videoRate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Frame Rate";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(310, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 59);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General";
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(9, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(358, 20);
            this.label.TabIndex = 7;
            this.label.TextChanged += new System.EventHandler(this.label_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Label";
            // 
            // componentList
            // 
            this.componentList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.componentList.Label = "Components";
            this.componentList.Location = new System.Drawing.Point(310, 360);
            this.componentList.Name = "componentList";
            this.componentList.Size = new System.Drawing.Size(373, 251);
            this.componentList.TabIndex = 2;
            // 
            // demodList
            // 
            this.demodList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.demodList.Label = "Audio Demodulators";
            this.demodList.Location = new System.Drawing.Point(310, 207);
            this.demodList.Name = "demodList";
            this.demodList.Size = new System.Drawing.Size(373, 147);
            this.demodList.TabIndex = 1;
            // 
            // canvasPreview
            // 
            this.canvasPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.canvasPreview.Location = new System.Drawing.Point(12, 12);
            this.canvasPreview.Name = "canvasPreview";
            this.canvasPreview.Size = new System.Drawing.Size(289, 599);
            this.canvasPreview.TabIndex = 0;
            // 
            // CanvasEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 623);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.componentList);
            this.Controls.Add(this.demodList);
            this.Controls.Add(this.canvasPreview);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(711, 10000);
            this.MinimumSize = new System.Drawing.Size(711, 662);
            this.Name = "CanvasEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CanvasEditor_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimationAtten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimationRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimationRate)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoRate)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.CanvasPreview canvasPreview;
        private Components.Lists.AudioDemodulatorListView demodList;
        private Components.Lists.ComponentListView componentList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown decimationAtten;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown decimationRatio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown decimationRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown freqOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnVideoOutput;
        private System.Windows.Forms.NumericUpDown videoWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown videoRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox label;
    }
}

