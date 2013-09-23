namespace Vanilla.Configuration.Lodge.WinForm
{
    partial class Rule
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIsPin = new System.Windows.Forms.CheckBox();
            this.chkIsIdProof = new System.Windows.Forms.CheckBox();
            this.chkIsAltContactNo = new System.Windows.Forms.CheckBox();
            this.chkIsEmail = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServiceTax = new System.Windows.Forms.Label();
            this.lblLuxuryTax = new System.Windows.Forms.Label();
            this.txtServiceTax = new System.Windows.Forms.TextBox();
            this.txtLuxuryTax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsPin);
            this.groupBox1.Controls.Add(this.chkIsIdProof);
            this.groupBox1.Controls.Add(this.chkIsAltContactNo);
            this.groupBox1.Controls.Add(this.chkIsEmail);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 114);
            this.groupBox1.TabIndex = 5;
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
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Location = new System.Drawing.Point(130, 155);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(160, 20);
            this.txtPassword.TabIndex = 109;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "Default User Password";
            // 
            // lblServiceTax
            // 
            this.lblServiceTax.AutoSize = true;
            this.lblServiceTax.Location = new System.Drawing.Point(18, 193);
            this.lblServiceTax.Name = "lblServiceTax";
            this.lblServiceTax.Size = new System.Drawing.Size(64, 13);
            this.lblServiceTax.TabIndex = 133;
            this.lblServiceTax.Text = "Service Tax";
            // 
            // lblLuxuryTax
            // 
            this.lblLuxuryTax.AutoSize = true;
            this.lblLuxuryTax.Location = new System.Drawing.Point(21, 221);
            this.lblLuxuryTax.Name = "lblLuxuryTax";
            this.lblLuxuryTax.Size = new System.Drawing.Size(59, 13);
            this.lblLuxuryTax.TabIndex = 134;
            this.lblLuxuryTax.Text = "Luxury Tax";
            // 
            // txtServiceTax
            // 
            this.txtServiceTax.Location = new System.Drawing.Point(117, 193);
            this.txtServiceTax.Name = "txtServiceTax";
            this.txtServiceTax.Size = new System.Drawing.Size(67, 20);
            this.txtServiceTax.TabIndex = 135;
            // 
            // txtLuxuryTax
            // 
            this.txtLuxuryTax.Location = new System.Drawing.Point(117, 221);
            this.txtLuxuryTax.Name = "txtLuxuryTax";
            this.txtLuxuryTax.Size = new System.Drawing.Size(67, 20);
            this.txtLuxuryTax.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 137;
            this.label1.Text = "(%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 138;
            this.label3.Text = "(%)";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Rule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 263);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLuxuryTax);
            this.Controls.Add(this.txtServiceTax);
            this.Controls.Add(this.lblLuxuryTax);
            this.Controls.Add(this.lblServiceTax);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Rule";
            this.Text = "Rule Configuration";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.lblServiceTax, 0);
            this.Controls.SetChildIndex(this.lblLuxuryTax, 0);
            this.Controls.SetChildIndex(this.txtServiceTax, 0);
            this.Controls.SetChildIndex(this.txtLuxuryTax, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIsPin;
        private System.Windows.Forms.CheckBox chkIsIdProof;
        private System.Windows.Forms.CheckBox chkIsAltContactNo;
        private System.Windows.Forms.CheckBox chkIsEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServiceTax;
        private System.Windows.Forms.Label lblLuxuryTax;
        private System.Windows.Forms.TextBox txtServiceTax;
        private System.Windows.Forms.TextBox txtLuxuryTax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}