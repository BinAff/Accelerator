namespace Vanilla.Invoice.WinForm
{
    partial class Invoice
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
            //this.rvInvoice = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.btnPayAndPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastFourDigit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rvInvoice
            // 
            //this.rvInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.rvInvoice.Location = new System.Drawing.Point(0, 0);
            //this.rvInvoice.Name = "rvInvoice";
            //this.rvInvoice.Size = new System.Drawing.Size(588, 435);
            //this.rvInvoice.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.cboPaymentType);
            this.panel1.Controls.Add(this.btnPayAndPrint);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLastFourDigit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 146);
            this.panel1.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(326, 117);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(186, 3);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(121, 21);
            this.cboPaymentType.TabIndex = 7;
            // 
            // btnPayAndPrint
            // 
            this.btnPayAndPrint.Location = new System.Drawing.Point(218, 117);
            this.btnPayAndPrint.Name = "btnPayAndPrint";
            this.btnPayAndPrint.Size = new System.Drawing.Size(89, 23);
            this.btnPayAndPrint.TabIndex = 6;
            this.btnPayAndPrint.Text = "Pay And Print";
            this.btnPayAndPrint.UseVisualStyleBackColor = true;
            this.btnPayAndPrint.Click += new System.EventHandler(this.btnPayAndPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(186, 57);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(358, 54);
            this.txtRemark.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Four Digit of card number";
            // 
            // txtLastFourDigit
            // 
            this.txtLastFourDigit.Location = new System.Drawing.Point(186, 30);
            this.txtLastFourDigit.MaxLength = 4;
            this.txtLastFourDigit.Name = "txtLastFourDigit";
            this.txtLastFourDigit.Size = new System.Drawing.Size(100, 20);
            this.txtLastFourDigit.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payment Type";
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 581);
            //this.Controls.Add(this.rvInvoice);
            this.Controls.Add(this.panel1);
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //private Microsoft.Reporting.WinForms.ReportViewer rvInvoice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPayAndPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastFourDigit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Button btnPrint;


    }
}