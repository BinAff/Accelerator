namespace Retinue.Customer.WinForm
{
    partial class CustomerRule
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
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIsPin = new System.Windows.Forms.CheckBox();
            this.chkIsIdProof = new System.Windows.Forms.CheckBox();
            this.chkIsAltContactNo = new System.Windows.Forms.CheckBox();
            this.chkIsEmail = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(305, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 141;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsPin);
            this.groupBox1.Controls.Add(this.chkIsIdProof);
            this.groupBox1.Controls.Add(this.chkIsAltContactNo);
            this.groupBox1.Controls.Add(this.chkIsEmail);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 114);
            this.groupBox1.TabIndex = 140;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer details mandatory fields";
            // 
            // chkIsPin
            // 
            this.chkIsPin.AutoSize = true;
            this.chkIsPin.Location = new System.Drawing.Point(6, 19);
            this.chkIsPin.Name = "chkIsPin";
            this.chkIsPin.Size = new System.Drawing.Size(82, 17);
            this.chkIsPin.TabIndex = 0;
            this.chkIsPin.Text = "PIN number";
            this.chkIsPin.UseVisualStyleBackColor = true;
            // 
            // chkIsIdProof
            // 
            this.chkIsIdProof.AutoSize = true;
            this.chkIsIdProof.Location = new System.Drawing.Point(6, 88);
            this.chkIsIdProof.Name = "chkIsIdProof";
            this.chkIsIdProof.Size = new System.Drawing.Size(87, 17);
            this.chkIsIdProof.TabIndex = 3;
            this.chkIsIdProof.Text = "Identity proof";
            this.chkIsIdProof.UseVisualStyleBackColor = true;
            // 
            // chkIsAltContactNo
            // 
            this.chkIsAltContactNo.AutoSize = true;
            this.chkIsAltContactNo.Location = new System.Drawing.Point(6, 42);
            this.chkIsAltContactNo.Name = "chkIsAltContactNo";
            this.chkIsAltContactNo.Size = new System.Drawing.Size(145, 17);
            this.chkIsAltContactNo.TabIndex = 1;
            this.chkIsAltContactNo.Text = "Alternate contact number";
            this.chkIsAltContactNo.UseVisualStyleBackColor = true;
            // 
            // chkIsEmail
            // 
            this.chkIsEmail.AutoSize = true;
            this.chkIsEmail.Location = new System.Drawing.Point(6, 65);
            this.chkIsEmail.Name = "chkIsEmail";
            this.chkIsEmail.Size = new System.Drawing.Size(51, 17);
            this.chkIsEmail.TabIndex = 2;
            this.chkIsEmail.Text = "Email";
            this.chkIsEmail.UseVisualStyleBackColor = true;
            // 
            // CustomerRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 138);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Rules";
            this.Load += new System.EventHandler(this.CustomerRule_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIsPin;
        private System.Windows.Forms.CheckBox chkIsIdProof;
        private System.Windows.Forms.CheckBox chkIsAltContactNo;
        private System.Windows.Forms.CheckBox chkIsEmail;
    }
}