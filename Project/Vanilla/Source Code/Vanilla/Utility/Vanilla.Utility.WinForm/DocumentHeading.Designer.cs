namespace Vanilla.Utility.WinForm
{
    partial class DocumentHeading
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
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnClose.Location = new System.Drawing.Point(383, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 16);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.toolTip.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeading.Location = new System.Drawing.Point(0, 0);
            this.lblHeading.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblHeading.Size = new System.Drawing.Size(35, 15);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "label1";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeading.TextChanged += new System.EventHandler(this.lblHeading_TextChanged);
            this.lblHeading.Click += new System.EventHandler(this.lblHeading_Click);
            // 
            // DocumentHeading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnClose);
            this.Name = "DocumentHeading";
            this.Size = new System.Drawing.Size(403, 16);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
