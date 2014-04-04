namespace Vanilla.Invoice.WinForm.Report
{
    partial class Daily
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
            this.rvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // rvReport
            // 
            this.rvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReport.Location = new System.Drawing.Point(0, 32);
            this.rvReport.Name = "rvReport";
            this.rvReport.Size = new System.Drawing.Size(733, 326);
            this.rvReport.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnSave);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.dpSearchDate);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(733, 32);
            this.pnlSearch.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(433, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(352, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose the date:";
            // 
            // dpSearchDate
            // 
            this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpSearchDate.Location = new System.Drawing.Point(146, 7);
            this.dpSearchDate.Name = "dpSearchDate";
            this.dpSearchDate.Size = new System.Drawing.Size(200, 20);
            this.dpSearchDate.TabIndex = 0;
            // 
            // Daily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 358);
            this.Controls.Add(this.rvReport);
            this.Controls.Add(this.pnlSearch);
            this.Name = "Daily";
            this.Text = "Sales Report : Daily";
            this.Load += new System.EventHandler(this.Daily_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReport;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpSearchDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        //private AutoTourism.Presentation.Library.Button.Search btnSearch;
    }
}