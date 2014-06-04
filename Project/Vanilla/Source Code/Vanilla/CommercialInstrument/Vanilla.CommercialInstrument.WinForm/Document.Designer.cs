namespace Vanilla.CommercialInstrument.WinForm
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
            this.rvViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvViewer
            // 
            this.rvViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvViewer.Location = new System.Drawing.Point(0, 0);
            this.rvViewer.Name = "rvViewer";
            this.rvViewer.Size = new System.Drawing.Size(792, 573);
            this.rvViewer.TabIndex = 0;
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.rvViewer);
            this.Name = "Document";
            this.Text = "Commercial Instruments";
            this.Load += new System.EventHandler(this.Document_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvViewer;
    }
}

