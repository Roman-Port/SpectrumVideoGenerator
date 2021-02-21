
namespace RomanPort.SpectrumVideoRenderer.Framework
{
    partial class LabeledIntegerSelector
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
            this.selector = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selector)).BeginInit();
            this.SuspendLayout();
            // 
            // selector
            // 
            this.selector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selector.Location = new System.Drawing.Point(0, 18);
            this.selector.Name = "selector";
            this.selector.Size = new System.Drawing.Size(191, 20);
            this.selector.TabIndex = 4;
            this.selector.ThousandsSeparator = true;
            this.selector.ValueChanged += new System.EventHandler(this.selector_ValueChanged);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(-3, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(194, 15);
            this.label.TabIndex = 3;
            this.label.Text = "Bandwidth";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabeledIntegerSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selector);
            this.Controls.Add(this.label);
            this.Name = "LabeledIntegerSelector";
            this.Size = new System.Drawing.Size(191, 39);
            ((System.ComponentModel.ISupportInitialize)(this.selector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown selector;
        private System.Windows.Forms.Label label;
    }
}
