namespace Vanilla.Utility.WinForm
{
    partial class Dialog
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
            this.tlpFile = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.cboExtension = new System.Windows.Forms.ComboBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.ucRegister = new Vanilla.Utility.WinForm.Register();
            this.tlpFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpFile
            // 
            this.tlpFile.ColumnCount = 4;
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.82796F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.17204F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpFile.Controls.Add(this.label1, 0, 0);
            this.tlpFile.Controls.Add(this.txtDocName, 1, 0);
            this.tlpFile.Controls.Add(this.cboExtension, 2, 0);
            this.tlpFile.Controls.Add(this.btnAction, 3, 0);
            this.tlpFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpFile.Location = new System.Drawing.Point(0, 407);
            this.tlpFile.Name = "tlpFile";
            this.tlpFile.RowCount = 1;
            this.tlpFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFile.Size = new System.Drawing.Size(591, 28);
            this.tlpFile.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDocName
            // 
            this.txtDocName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDocName.Location = new System.Drawing.Point(45, 3);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(314, 20);
            this.txtDocName.TabIndex = 2;
            this.txtDocName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDocName_KeyUp);
            // 
            // cboExtension
            // 
            this.cboExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExtension.FormattingEnabled = true;
            this.cboExtension.Location = new System.Drawing.Point(365, 3);
            this.cboExtension.Name = "cboExtension";
            this.cboExtension.Size = new System.Drawing.Size(124, 21);
            this.cboExtension.TabIndex = 4;
            // 
            // btnAction
            // 
            this.btnAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAction.Location = new System.Drawing.Point(495, 3);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(93, 22);
            this.btnAction.TabIndex = 5;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // ucRegister
            // 
            this.ucRegister.Address = null;
            this.ucRegister.Category = Vanilla.Utility.Facade.Artifact.Category.Form;
            this.ucRegister.DialogueMode = Vanilla.Utility.WinForm.DialogueMode.None;
            this.ucRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRegister.Location = new System.Drawing.Point(0, 0);
            this.ucRegister.Name = "ucRegister";
            this.ucRegister.Padding = new System.Windows.Forms.Padding(2, 2, 2, 4);
            this.ucRegister.ParentFolder = null;
            this.ucRegister.Size = new System.Drawing.Size(591, 407);
            this.ucRegister.TabIndex = 0;
            this.ucRegister.TreeFilter = null;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 435);
            this.Controls.Add(this.ucRegister);
            this.Controls.Add(this.tlpFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Dialog_Load);
            this.Shown += new System.EventHandler(this.Dialog_Shown);
            this.tlpFile.ResumeLayout(false);
            this.tlpFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Register ucRegister;
        private System.Windows.Forms.TableLayoutPanel tlpFile;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.ComboBox cboExtension;
        private System.Windows.Forms.Label label1;
    }
}