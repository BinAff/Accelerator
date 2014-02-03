namespace BinAff.Tool.Installer
{
    partial class LicenseManager
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtLicsFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseLicsFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgOpenLicenseFile = new System.Windows.Forms.OpenFileDialog();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLicsFilePath
            // 
            this.txtLicsFilePath.Enabled = false;
            this.txtLicsFilePath.Location = new System.Drawing.Point(190, 12);
            this.txtLicsFilePath.Name = "txtLicsFilePath";
            this.txtLicsFilePath.Size = new System.Drawing.Size(388, 20);
            this.txtLicsFilePath.TabIndex = 6;
            this.txtLicsFilePath.TextChanged += new System.EventHandler(this.txtLicsFilePath_TextChanged);
            // 
            // btnBrowseLicsFile
            // 
            this.btnBrowseLicsFile.Location = new System.Drawing.Point(109, 10);
            this.btnBrowseLicsFile.Name = "btnBrowseLicsFile";
            this.btnBrowseLicsFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLicsFile.TabIndex = 5;
            this.btnBrowseLicsFile.Text = "Browse";
            this.btnBrowseLicsFile.UseVisualStyleBackColor = true;
            this.btnBrowseLicsFile.Click += new System.EventHandler(this.btnBrowseLicsFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Open License File:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dlgOpenLicenseFile
            // 
            this.dlgOpenLicenseFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgOpenLicenseFile_FileOk);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(422, 336);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(503, 336);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 25;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 371);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtLicsFilePath);
            this.Controls.Add(this.btnBrowseLicsFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLicsFilePath;
        private System.Windows.Forms.Button btnBrowseLicsFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dlgOpenLicenseFile;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
    }
}