
namespace RomanPort.SpectrumVideoRenderer.GUI
{
    partial class RenderForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.ProgressBar();
            this.statusRight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusText
            // 
            this.statusText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusText.Location = new System.Drawing.Point(12, 9);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(340, 13);
            this.statusText.TabIndex = 0;
            this.statusText.Text = "Rendering...";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(596, 29);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusBar
            // 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar.Location = new System.Drawing.Point(15, 29);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(575, 23);
            this.statusBar.TabIndex = 2;
            // 
            // statusRight
            // 
            this.statusRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusRight.Location = new System.Drawing.Point(358, 9);
            this.statusRight.Name = "statusRight";
            this.statusRight.Size = new System.Drawing.Size(313, 13);
            this.statusRight.TabIndex = 3;
            this.statusRight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 64);
            this.Controls.Add(this.statusRight);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.statusText);
            this.MaximizeBox = false;
            this.Name = "RenderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendering";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RenderForm_FormClosing);
            this.Load += new System.EventHandler(this.RenderForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar statusBar;
        private System.Windows.Forms.Label statusRight;
    }
}