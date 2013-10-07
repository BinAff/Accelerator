namespace Vanilla.Navigator.Presentation
{
    partial class MenuSummary
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
            this.lblLabel = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLabel
            // 
            this.lblLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLabel.Location = new System.Drawing.Point(49, 0);
            this.lblLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(163, 49);
            this.lblLabel.TabIndex = 3;
            this.lblLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLabel.Click += new System.EventHandler(this.lblLabel_Click);
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Transparent;
            this.picImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(49, 49);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 2;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // MenuSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.picImage);
            this.Name = "MenuSummary";
            this.Size = new System.Drawing.Size(212, 49);
            this.Resize += new System.EventHandler(this.MenuSummary_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.PictureBox picImage;
    }
}
