namespace AutoTourism.Lodge.Configuration.WinForm
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trvOption
            // 
            this.trvOption.Location = new System.Drawing.Point(10, 11);
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
            this.lslList.Location = new System.Drawing.Point(169, 37);
            this.lslList.Name = "lslList";
            this.lslList.Size = new System.Drawing.Size(286, 147);
            this.lslList.TabIndex = 135;
            this.lslList.Click += new System.EventHandler(this.lslList_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(169, 11);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(286, 20);
            this.txtName.TabIndex = 134;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(467, 69);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 136;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(467, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 137;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(467, 40);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 138;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // ConfigManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 195);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lslList);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.trvOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvOption;
        private System.Windows.Forms.ListBox lslList;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChange;


    }
}