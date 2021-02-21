
namespace RomanPort.SpectrumVideoRenderer
{
    partial class Form1
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
            this.spectrumList = new System.Windows.Forms.ListBox();
            this.spectrumConfig = new RomanPort.SpectrumVideoRenderer.SpectrumConfigView();
            this.btnRender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected File";
            // 
            // spectrumList
            // 
            this.spectrumList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spectrumList.FormattingEnabled = true;
            this.spectrumList.Location = new System.Drawing.Point(12, 75);
            this.spectrumList.Name = "spectrumList";
            this.spectrumList.Size = new System.Drawing.Size(120, 654);
            this.spectrumList.TabIndex = 0;
            // 
            // spectrumConfig
            // 
            this.spectrumConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spectrumConfig.Location = new System.Drawing.Point(138, 71);
            this.spectrumConfig.Name = "spectrumConfig";
            this.spectrumConfig.Size = new System.Drawing.Size(491, 666);
            this.spectrumConfig.TabIndex = 1;
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(529, 743);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(100, 23);
            this.btnRender.TabIndex = 2;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 777);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.spectrumConfig);
            this.Controls.Add(this.spectrumList);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox spectrumList;
        private SpectrumConfigView spectrumConfig;
        private System.Windows.Forms.Button btnRender;
    }
}

