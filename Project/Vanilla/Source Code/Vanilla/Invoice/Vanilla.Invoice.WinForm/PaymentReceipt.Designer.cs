﻿namespace Vanilla.Invoice.WinForm
{
    partial class PaymentReceipt
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
            this.rvInvoice = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvInvoice
            // 
            this.rvInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvInvoice.Location = new System.Drawing.Point(0, 0);
            this.rvInvoice.Name = "rvInvoice";
            this.rvInvoice.Size = new System.Drawing.Size(747, 438);
            this.rvInvoice.TabIndex = 0;
            // 
            // PaymentReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 438);
            this.Controls.Add(this.rvInvoice);
            this.Name = "PaymentReceipt";
            this.Text = "Payment Receipt";
            this.Load += new System.EventHandler(this.PaymentReceipt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvInvoice;
    }
}