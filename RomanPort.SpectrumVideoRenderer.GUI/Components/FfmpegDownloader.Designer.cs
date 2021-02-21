
namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    partial class FfmpegDownloader
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
            this.statusText = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Location = new System.Drawing.Point(12, 12);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(124, 13);
            this.statusText.TabIndex = 0;
            this.statusText.Text = "Downloading FFMPEG...";
            // 
            // statusBar
            // 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar.Location = new System.Drawing.Point(15, 34);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(451, 23);
            this.statusBar.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(472, 34);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FfmpegDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 69);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.statusText);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(575, 108);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(575, 108);
            this.Name = "FfmpegDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FfmpegDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FfmpegDownloader_FormClosing);
            this.Load += new System.EventHandler(this.FfmpegDownloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.ProgressBar statusBar;
        private System.Windows.Forms.Button btnCancel;
    }
}