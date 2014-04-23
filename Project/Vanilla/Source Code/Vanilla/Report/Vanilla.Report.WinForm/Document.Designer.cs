namespace Vanilla.Report.WinForm
{
    partial class Document
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
            this.pnlReportDetail = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.dpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.rvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlReportDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReportDetail
            // 
            this.pnlReportDetail.Controls.Add(this.btnSave);
            this.pnlReportDetail.Controls.Add(this.dpSearchDate);
            this.pnlReportDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlReportDetail.Name = "pnlReportDetail";
            this.pnlReportDetail.Size = new System.Drawing.Size(723, 38);
            this.pnlReportDetail.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(209, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dpSearchDate
            // 
            this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpSearchDate.Location = new System.Drawing.Point(3, 8);
            this.dpSearchDate.Name = "dpSearchDate";
            this.dpSearchDate.Size = new System.Drawing.Size(200, 20);
            this.dpSearchDate.TabIndex = 0;
            this.dpSearchDate.ValueChanged += new System.EventHandler(this.dpSearchDate_ValueChanged);
            // 
            // rvReport
            // 
            this.rvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReport.Location = new System.Drawing.Point(0, 38);
            this.rvReport.Name = "rvReport";
            this.rvReport.Size = new System.Drawing.Size(723, 358);
            this.rvReport.TabIndex = 8;
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 396);
            this.Controls.Add(this.rvReport);
            this.Controls.Add(this.pnlReportDetail);
            this.Name = "Document";
            this.Text = "Document";
            this.Load += new System.EventHandler(this.Document_Load);
            this.pnlReportDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReportDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dpSearchDate;
        private Microsoft.Reporting.WinForms.ReportViewer rvReport;
    }
}