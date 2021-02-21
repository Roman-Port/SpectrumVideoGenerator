
namespace RomanPort.SpectrumVideoRenderer.Framework
{
    partial class LabeledFloatSlider
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
            this.label = new System.Windows.Forms.Label();
            this.selector = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.selector)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(-2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(194, 15);
            this.label.TabIndex = 5;
            this.label.Text = "Bandwidth";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selector
            // 
            this.selector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selector.LargeChange = 500;
            this.selector.Location = new System.Drawing.Point(-8, 15);
            this.selector.Name = "selector";
            this.selector.Size = new System.Drawing.Size(206, 45);
            this.selector.SmallChange = 100;
            this.selector.TabIndex = 6;
            this.selector.TickFrequency = 200;
            this.selector.Scroll += new System.EventHandler(this.selector_Scroll);
            // 
            // LabeledFloatSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selector);
            this.Controls.Add(this.label);
            this.Name = "LabeledFloatSlider";
            this.Size = new System.Drawing.Size(191, 45);
            ((System.ComponentModel.ISupportInitialize)(this.selector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TrackBar selector;
    }
}
