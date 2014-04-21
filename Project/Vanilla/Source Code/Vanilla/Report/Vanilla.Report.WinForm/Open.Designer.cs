namespace Vanilla.Report.WinForm
{
    partial class Open
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
            this.ucRegister = new Vanilla.Navigator.WinForm.Register();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboExtension = new System.Windows.Forms.ComboBox();
            this.pnlFile = new System.Windows.Forms.Panel();
            this.pnlFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucRegister
            // 
            this.ucRegister.Address = null;
            this.ucRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRegister.Location = new System.Drawing.Point(0, 0);
            this.ucRegister.Name = "ucRegister";
            this.ucRegister.Size = new System.Drawing.Size(591, 414);
            this.ucRegister.TabIndex = 0;
            // 
            // txtDocName
            // 
            this.txtDocName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDocName.Location = new System.Drawing.Point(87, 0);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(333, 20);
            this.txtDocName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Document Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboExtension
            // 
            this.cboExtension.Dock = System.Windows.Forms.DockStyle.Right;
            this.cboExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExtension.FormattingEnabled = true;
            this.cboExtension.Items.AddRange(new object[] {
            "All Report (*.$rpt)",
            "Daily Report (*.drpt)",
            "Weekly Report (*.wrpt)",
            "Monthly Report (*.mrpt)",
            "Quarterly Report (*.qrpt)",
            "Yearly Report (*.yrpt)"});
            this.cboExtension.Location = new System.Drawing.Point(420, 0);
            this.cboExtension.Name = "cboExtension";
            this.cboExtension.Size = new System.Drawing.Size(171, 21);
            this.cboExtension.TabIndex = 3;
            // 
            // pnlFile
            // 
            this.pnlFile.Controls.Add(this.txtDocName);
            this.pnlFile.Controls.Add(this.label1);
            this.pnlFile.Controls.Add(this.cboExtension);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFile.Location = new System.Drawing.Point(0, 414);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(591, 21);
            this.pnlFile.TabIndex = 4;
            // 
            // Open
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 435);
            this.Controls.Add(this.ucRegister);
            this.Controls.Add(this.pnlFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Open";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Document";
            this.Load += new System.EventHandler(this.Open_Load);
            this.pnlFile.ResumeLayout(false);
            this.pnlFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Navigator.WinForm.Register ucRegister;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboExtension;
        private System.Windows.Forms.Panel pnlFile;
    }
}