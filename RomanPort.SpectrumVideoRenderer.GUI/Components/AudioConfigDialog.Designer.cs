
namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    partial class AudioConfigDialog
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
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputLabel = new System.Windows.Forms.TextBox();
            this.inputPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChooseOutput = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.inputBandwidth = new System.Windows.Forms.NumericUpDown();
            this.inputSampleRate = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputBandwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSampleRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(222, 421);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Label";
            // 
            // inputLabel
            // 
            this.inputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputLabel.Location = new System.Drawing.Point(15, 25);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(282, 20);
            this.inputLabel.TabIndex = 2;
            // 
            // inputPath
            // 
            this.inputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputPath.Location = new System.Drawing.Point(15, 64);
            this.inputPath.Name = "inputPath";
            this.inputPath.Size = new System.Drawing.Size(201, 20);
            this.inputPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Path";
            // 
            // btnChooseOutput
            // 
            this.btnChooseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseOutput.Location = new System.Drawing.Point(222, 62);
            this.btnChooseOutput.Name = "btnChooseOutput";
            this.btnChooseOutput.Size = new System.Drawing.Size(75, 23);
            this.btnChooseOutput.TabIndex = 5;
            this.btnChooseOutput.Text = "Choose...";
            this.btnChooseOutput.UseVisualStyleBackColor = true;
            this.btnChooseOutput.Click += new System.EventHandler(this.btnChooseOutput_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Demod Bandwidth";
            // 
            // inputBandwidth
            // 
            this.inputBandwidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputBandwidth.Location = new System.Drawing.Point(15, 103);
            this.inputBandwidth.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.inputBandwidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.inputBandwidth.Name = "inputBandwidth";
            this.inputBandwidth.Size = new System.Drawing.Size(282, 20);
            this.inputBandwidth.TabIndex = 7;
            this.inputBandwidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // inputSampleRate
            // 
            this.inputSampleRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSampleRate.Location = new System.Drawing.Point(15, 142);
            this.inputSampleRate.Maximum = new decimal(new int[] {
            960000,
            0,
            0,
            0});
            this.inputSampleRate.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.inputSampleRate.Name = "inputSampleRate";
            this.inputSampleRate.Size = new System.Drawing.Size(282, 20);
            this.inputSampleRate.TabIndex = 9;
            this.inputSampleRate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Output Sample Rate";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(141, 421);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AudioConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 456);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.inputSampleRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputBandwidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChooseOutput);
            this.Controls.Add(this.inputPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioConfigDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure Audio";
            this.Load += new System.EventHandler(this.AudioConfigDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputBandwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSampleRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputLabel;
        private System.Windows.Forms.TextBox inputPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown inputBandwidth;
        private System.Windows.Forms.NumericUpDown inputSampleRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
    }
}