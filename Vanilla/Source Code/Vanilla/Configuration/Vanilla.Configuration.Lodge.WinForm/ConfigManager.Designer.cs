namespace Vanilla.Configuration.Lodge.WinForm
{
    partial class ConfigManager
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Building Type");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Room Category");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Room Type");
            this.trvOption = new System.Windows.Forms.TreeView();
            this.lslList = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // trvOption
            // 
            this.trvOption.Location = new System.Drawing.Point(12, 42);
            this.trvOption.Name = "trvOption";
            treeNode1.Name = "Building Type";
            treeNode1.Text = "Building Type";
            treeNode2.Name = "Room Category";
            treeNode2.Text = "Room Category";
            treeNode3.Name = "Room Type";
            treeNode3.Text = "Room Type";
            this.trvOption.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.trvOption.Size = new System.Drawing.Size(148, 173);
            this.trvOption.TabIndex = 133;
            this.trvOption.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvOption_AfterSelect);
            // 
            // lslList
            // 
            this.lslList.FormattingEnabled = true;
            this.lslList.Location = new System.Drawing.Point(166, 68);
            this.lslList.Name = "lslList";
            this.lslList.Size = new System.Drawing.Size(286, 147);
            this.lslList.TabIndex = 135;
            this.lslList.Click += new System.EventHandler(this.lslList_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(166, 42);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(286, 20);
            this.txtName.TabIndex = 134;
            // 
            // ConfigManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 229);
            this.Controls.Add(this.lslList);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.trvOption);
            this.Name = "ConfigManager";
            this.Text = "Configuration Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvOption;
        private System.Windows.Forms.ListBox lslList;
        private System.Windows.Forms.TextBox txtName;


    }
}