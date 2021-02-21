
namespace RomanPort.SpectrumVideoRenderer.Framework
{
    partial class FullSizePreview
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
            this.thumbnailRenderer = new RomanPort.SpectrumVideoRenderer.Framework.ThumbnailRenderer();
            this.SuspendLayout();
            // 
            // thumbnailRenderer
            // 
            this.thumbnailRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailRenderer.Location = new System.Drawing.Point(12, 12);
            this.thumbnailRenderer.Name = "thumbnailRenderer";
            this.thumbnailRenderer.Size = new System.Drawing.Size(776, 426);
            this.thumbnailRenderer.TabIndex = 0;
            // 
            // FullSizePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.thumbnailRenderer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullSizePreview";
            this.Text = "FullSizePreview";
            this.Load += new System.EventHandler(this.FullSizePreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ThumbnailRenderer thumbnailRenderer;
    }
}