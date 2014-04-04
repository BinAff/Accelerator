namespace Vanilla.Invoice.WinForm.Report
{
    partial class Weekly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Weekly));
            this.rvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            //this.btnSearch = new AutoTourism.Presentation.Library.Button.Search();
            this.dpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // rvReport
            // 
            this.rvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReport.Location = new System.Drawing.Point(0, 33);
            this.rvReport.Name = "rvReport";
            this.rvReport.Size = new System.Drawing.Size(699, 331);
            this.rvReport.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.label1);
            //this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.dpSearchDate);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(699, 33);
            this.pnlSearch.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose the date for Week:";
            // 
            // btnSearch
            // 
            //this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            //this.btnSearch.BackColor = System.Drawing.Color.White;
            //this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            //this.btnSearch.Location = new System.Drawing.Point(352, 4);
            //this.btnSearch.Name = "btnSearch";
            //this.btnSearch.Size = new System.Drawing.Size(26, 26);
            //this.btnSearch.TabIndex = 1;
            //this.btnSearch.UseVisualStyleBackColor = false;
            //this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dpSearchDate
            // 
            this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpSearchDate.Location = new System.Drawing.Point(146, 7);
            this.dpSearchDate.Name = "dpSearchDate";
            this.dpSearchDate.Size = new System.Drawing.Size(200, 20);
            this.dpSearchDate.TabIndex = 0;
            // 
            // Weekly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 364);
            this.Controls.Add(this.rvReport);
            this.Controls.Add(this.pnlSearch);
            this.Name = "Weekly";
            this.Text = "Sales Report : Weekly";
            this.Load += new System.EventHandler(this.Weekly_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReport;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label1;
        //private AutoTourism.Presentation.Library.Button.Search btnSearch;
        private System.Windows.Forms.DateTimePicker dpSearchDate;
    }
}