namespace Vanilla.Invoice.WinForm
{
    partial class InvoiceReceipt
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
            this.rvInvoiceReceipt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvInvoiceReceipt
            // 
            this.rvInvoiceReceipt.Location = new System.Drawing.Point(2, 2);
            this.rvInvoiceReceipt.Name = "rvInvoiceReceipt";
            this.rvInvoiceReceipt.Size = new System.Drawing.Size(895, 540);
            this.rvInvoiceReceipt.TabIndex = 0;
            // 
            // InvoiceReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 536);
            this.Controls.Add(this.rvInvoiceReceipt);
            this.Name = "InvoiceReceipt";
            this.Text = "InvoiceReceipt";
            this.Load += new System.EventHandler(this.InvoiceReceipt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvInvoiceReceipt;
    }
}