namespace BinAff.Tool.License
{
    partial class FileGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileGenerator));
            this.btnGenerateLicenseFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lstSourceModule = new System.Windows.Forms.ListBox();
            this.lstLicensedModule = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProductDesc = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateLicenseFile
            // 
            this.btnGenerateLicenseFile.Location = new System.Drawing.Point(319, 335);
            this.btnGenerateLicenseFile.Name = "btnGenerateLicenseFile";
            this.btnGenerateLicenseFile.Size = new System.Drawing.Size(127, 23);
            this.btnGenerateLicenseFile.TabIndex = 2;
            this.btnGenerateLicenseFile.Text = "Generate License File";
            this.btnGenerateLicenseFile.UseVisualStyleBackColor = true;
            this.btnGenerateLicenseFile.Click += new System.EventHandler(this.btnGenerateLicenseFile_Click);
            // 
            // lstSourceModule
            // 
            this.lstSourceModule.FormattingEnabled = true;
            this.lstSourceModule.Location = new System.Drawing.Point(12, 210);
            this.lstSourceModule.Name = "lstSourceModule";
            this.lstSourceModule.Size = new System.Drawing.Size(194, 121);
            this.lstSourceModule.Sorted = true;
            this.lstSourceModule.TabIndex = 3;
            this.lstSourceModule.DoubleClick += new System.EventHandler(this.lstSourceModule_DoubleClick);
            // 
            // lstLicensedModule
            // 
            this.lstLicensedModule.FormattingEnabled = true;
            this.lstLicensedModule.Location = new System.Drawing.Point(252, 208);
            this.lstLicensedModule.Name = "lstLicensedModule";
            this.lstLicensedModule.Size = new System.Drawing.Size(194, 121);
            this.lstLicensedModule.Sorted = true;
            this.lstLicensedModule.TabIndex = 4;
            this.lstLicensedModule.DoubleClick += new System.EventHandler(this.lstLicensedModule_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(218, 260);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "►";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(218, 289);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(22, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "x";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(60, 43);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(364, 56);
            this.textBox2.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtProductDesc);
            this.groupBox2.Controls.Add(this.txtProductId);
            this.groupBox2.Controls.Add(this.cboProduct);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 196);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product";
            // 
            // txtProductDesc
            // 
            this.txtProductDesc.Location = new System.Drawing.Point(240, 53);
            this.txtProductDesc.Multiline = true;
            this.txtProductDesc.Name = "txtProductDesc";
            this.txtProductDesc.ReadOnly = true;
            this.txtProductDesc.Size = new System.Drawing.Size(177, 126);
            this.txtProductDesc.TabIndex = 11;
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(240, 24);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnly = true;
            this.txtProductId.Size = new System.Drawing.Size(177, 20);
            this.txtProductId.TabIndex = 10;
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(18, 24);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(210, 164);
            this.cboProduct.Sorted = true;
            this.cboProduct.TabIndex = 0;
            this.cboProduct.Click += new System.EventHandler(this.cboProduct_Click);
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 365);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstLicensedModule);
            this.Controls.Add(this.lstSourceModule);
            this.Controls.Add(this.btnGenerateLicenseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Generator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License File Generator";
            this.Load += new System.EventHandler(this.Generator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateLicenseFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListBox lstSourceModule;
        private System.Windows.Forms.ListBox lstLicensedModule;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProductDesc;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.ComboBox cboProduct;
    }
}