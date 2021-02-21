
namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    partial class CanvasPreview
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
            this.previewCanvas = new System.Windows.Forms.PictureBox();
            this.previewCanvasScroll = new System.Windows.Forms.VScrollBar();
            this.status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.previewCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // previewCanvas
            // 
            this.previewCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewCanvas.Location = new System.Drawing.Point(0, 0);
            this.previewCanvas.Name = "previewCanvas";
            this.previewCanvas.Size = new System.Drawing.Size(269, 355);
            this.previewCanvas.TabIndex = 3;
            this.previewCanvas.TabStop = false;
            // 
            // previewCanvasScroll
            // 
            this.previewCanvasScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewCanvasScroll.Location = new System.Drawing.Point(272, 0);
            this.previewCanvasScroll.Name = "previewCanvasScroll";
            this.previewCanvasScroll.Size = new System.Drawing.Size(17, 355);
            this.previewCanvasScroll.TabIndex = 2;
            this.previewCanvasScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.previewCanvasScroll_Scroll);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.status.Location = new System.Drawing.Point(0, 354);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(289, 19);
            this.status.TabIndex = 4;
            this.status.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CanvasPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.previewCanvas);
            this.Controls.Add(this.previewCanvasScroll);
            this.Controls.Add(this.status);
            this.Name = "CanvasPreview";
            this.Size = new System.Drawing.Size(289, 373);
            this.Load += new System.EventHandler(this.CanvasPreview_Load);
            this.SizeChanged += new System.EventHandler(this.CanvasPreview_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.previewCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox previewCanvas;
        private System.Windows.Forms.VScrollBar previewCanvasScroll;
        private System.Windows.Forms.Label status;
    }
}
