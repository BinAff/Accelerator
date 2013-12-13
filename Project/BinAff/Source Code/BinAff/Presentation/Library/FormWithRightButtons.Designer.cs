namespace BinAff.Presentation.Library
{
    partial class FormWithRightButtons
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlCommandBar = new System.Windows.Forms.Panel();
            this.pnlCommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::BinAff.Presentation.Library.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(2, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 2;
            this.toolTips.SetToolTip(this.btnAdd, "Add new record");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Image = global::BinAff.Presentation.Library.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(2, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnRefresh.TabIndex = 1;
            this.toolTips.SetToolTip(this.btnRefresh, "Refresh form");
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::BinAff.Presentation.Library.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(2, 53);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 3;
            this.toolTips.SetToolTip(this.btnDelete, "Delete record");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChange.BackColor = System.Drawing.Color.White;
            this.btnChange.Image = global::BinAff.Presentation.Library.Properties.Resources.Change;
            this.btnChange.Location = new System.Drawing.Point(2, 78);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(25, 25);
            this.btnChange.TabIndex = 4;
            this.toolTips.SetToolTip(this.btnChange, "Change record");
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(653, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(2, 291);
            this.pnlRight.TabIndex = 131;
            // 
            // pnlCommandBar
            // 
            this.pnlCommandBar.Controls.Add(this.btnRefresh);
            this.pnlCommandBar.Controls.Add(this.btnAdd);
            this.pnlCommandBar.Controls.Add(this.btnDelete);
            this.pnlCommandBar.Controls.Add(this.btnChange);
            this.pnlCommandBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCommandBar.Location = new System.Drawing.Point(625, 0);
            this.pnlCommandBar.Name = "pnlCommandBar";
            this.pnlCommandBar.Size = new System.Drawing.Size(28, 291);
            this.pnlCommandBar.TabIndex = 132;
            // 
            // Form
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(655, 291);
            this.Controls.Add(this.pnlCommandBar);
            this.Controls.Add(this.pnlRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlCommandBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlCommandBar;
    }
}