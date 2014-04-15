namespace AutoTourism.Customer.WinForm.Report
{
    partial class Quarterly
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.rvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(355, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose the date:";
            // 
            // dpSearchDate
            // 
            this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpSearchDate.Location = new System.Drawing.Point(149, 12);
            this.dpSearchDate.Name = "dpSearchDate";
            this.dpSearchDate.Size = new System.Drawing.Size(200, 20);
            this.dpSearchDate.TabIndex = 6;
            this.dpSearchDate.ValueChanged += new System.EventHandler(this.dpSearchDate_ValueChanged);
            // 
            // rvReport
            // 
            this.rvReport.Location = new System.Drawing.Point(3, 38);
            this.rvReport.Name = "rvReport";
            this.rvReport.Size = new System.Drawing.Size(907, 347);
            this.rvReport.TabIndex = 9;
            // 
            // Quarterly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 388);
            this.Controls.Add(this.rvReport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpSearchDate);
            this.Name = "Quarterly";
            this.Text = "Customer Report : Quarterly";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.Quarterly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpSearchDate;
        private Microsoft.Reporting.WinForms.ReportViewer rvReport;
    }
}