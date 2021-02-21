
namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    partial class SampleFormatPromptForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.sampleFloat = new System.Windows.Forms.RadioButton();
            this.sampleShort = new System.Windows.Forms.RadioButton();
            this.sampleByte = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.sampleRate = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sample Format";
            // 
            // sampleFloat
            // 
            this.sampleFloat.AutoSize = true;
            this.sampleFloat.Location = new System.Drawing.Point(15, 25);
            this.sampleFloat.Name = "sampleFloat";
            this.sampleFloat.Size = new System.Drawing.Size(60, 17);
            this.sampleFloat.TabIndex = 1;
            this.sampleFloat.TabStop = true;
            this.sampleFloat.Text = "Float32";
            this.sampleFloat.UseVisualStyleBackColor = true;
            // 
            // sampleShort
            // 
            this.sampleShort.AutoSize = true;
            this.sampleShort.Location = new System.Drawing.Point(81, 25);
            this.sampleShort.Name = "sampleShort";
            this.sampleShort.Size = new System.Drawing.Size(62, 17);
            this.sampleShort.TabIndex = 2;
            this.sampleShort.TabStop = true;
            this.sampleShort.Text = "Short16";
            this.sampleShort.UseVisualStyleBackColor = true;
            // 
            // sampleByte
            // 
            this.sampleByte.AutoSize = true;
            this.sampleByte.Location = new System.Drawing.Point(149, 25);
            this.sampleByte.Name = "sampleByte";
            this.sampleByte.Size = new System.Drawing.Size(46, 17);
            this.sampleByte.TabIndex = 3;
            this.sampleByte.TabStop = true;
            this.sampleByte.Text = "Byte";
            this.sampleByte.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sample Rate";
            // 
            // sampleRate
            // 
            this.sampleRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampleRate.Location = new System.Drawing.Point(15, 61);
            this.sampleRate.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.sampleRate.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sampleRate.Name = "sampleRate";
            this.sampleRate.Size = new System.Drawing.Size(227, 20);
            this.sampleRate.TabIndex = 5;
            this.sampleRate.ThousandsSeparator = true;
            this.sampleRate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(15, 288);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(227, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SampleFormatPromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 323);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.sampleRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sampleByte);
            this.Controls.Add(this.sampleShort);
            this.Controls.Add(this.sampleFloat);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SampleFormatPromptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure Binary File";
            ((System.ComponentModel.ISupportInitialize)(this.sampleRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton sampleFloat;
        private System.Windows.Forms.RadioButton sampleShort;
        private System.Windows.Forms.RadioButton sampleByte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown sampleRate;
        private System.Windows.Forms.Button btnOk;
    }
}