namespace BinAff.Tool.Installer
{
    partial class Legal
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
            this.btnNext = new System.Windows.Forms.Button();
            this.chkAccept = new System.Windows.Forms.CheckBox();
            this.rtxtAgreement = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(503, 336);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // chkAccept
            // 
            this.chkAccept.AutoSize = true;
            this.chkAccept.Location = new System.Drawing.Point(12, 313);
            this.chkAccept.Name = "chkAccept";
            this.chkAccept.Size = new System.Drawing.Size(234, 17);
            this.chkAccept.TabIndex = 1;
            this.chkAccept.Text = "I accept the terms in the License Agreement";
            this.chkAccept.UseVisualStyleBackColor = true;
            this.chkAccept.CheckedChanged += new System.EventHandler(this.chkAccept_CheckedChanged);
            // 
            // rtxtAgreement
            // 
            this.rtxtAgreement.Location = new System.Drawing.Point(12, 12);
            this.rtxtAgreement.Name = "rtxtAgreement";
            this.rtxtAgreement.Size = new System.Drawing.Size(566, 295);
            this.rtxtAgreement.TabIndex = 3;
            this.rtxtAgreement.TabStop = false;
            this.rtxtAgreement.Text = "";
            // 
            // Legal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 371);
            this.Controls.Add(this.rtxtAgreement);
            this.Controls.Add(this.chkAccept);
            this.Controls.Add(this.btnNext);
            this.Name = "Legal";
            this.Text = "Legal Agreement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chkAccept;
        private System.Windows.Forms.RichTextBox rtxtAgreement;
    }
}