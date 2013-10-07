namespace Vanilla.Navigator.Presentation
{
    partial class Controller
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.spcBody = new System.Windows.Forms.SplitContainer();
            this.spcMenu = new System.Windows.Forms.SplitContainer();
            this.btnHideLeftPanel = new System.Windows.Forms.Button();
            this.btnShowLeftPanel = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spcBody)).BeginInit();
            this.spcBody.Panel1.SuspendLayout();
            this.spcBody.Panel2.SuspendLayout();
            this.spcBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMenu)).BeginInit();
            this.spcMenu.Panel1.SuspendLayout();
            this.spcMenu.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcBody
            // 
            this.spcBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcBody.Location = new System.Drawing.Point(0, 21);
            this.spcBody.Name = "spcBody";
            // 
            // spcBody.Panel1
            // 
            this.spcBody.Panel1.Controls.Add(this.spcMenu);
            // 
            // spcBody.Panel2
            // 
            this.spcBody.Panel2.AutoScroll = true;
            this.spcBody.Panel2.Controls.Add(this.btnShowLeftPanel);
            this.spcBody.Size = new System.Drawing.Size(434, 355);
            this.spcBody.SplitterDistance = 191;
            this.spcBody.SplitterWidth = 14;
            this.spcBody.TabIndex = 0;
            // 
            // spcMenu
            // 
            this.spcMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMenu.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcMenu.Location = new System.Drawing.Point(0, 0);
            this.spcMenu.Name = "spcMenu";
            this.spcMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMenu.Panel1
            // 
            this.spcMenu.Panel1.AutoScroll = true;
            this.spcMenu.Panel1.Controls.Add(this.btnHideLeftPanel);
            // 
            // spcMenu.Panel2
            // 
            this.spcMenu.Panel2.AutoScroll = true;
            this.spcMenu.Size = new System.Drawing.Size(191, 355);
            this.spcMenu.SplitterDistance = 249;
            this.spcMenu.TabIndex = 0;
            // 
            // btnHideLeftPanel
            // 
            this.btnHideLeftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideLeftPanel.Location = new System.Drawing.Point(173, -1);
            this.btnHideLeftPanel.Name = "btnHideLeftPanel";
            this.btnHideLeftPanel.Size = new System.Drawing.Size(14, 28);
            this.btnHideLeftPanel.TabIndex = 0;
            this.btnHideLeftPanel.Text = "<\r\n";
            this.btnHideLeftPanel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHideLeftPanel.UseVisualStyleBackColor = true;
            this.btnHideLeftPanel.Click += new System.EventHandler(this.btnHideLeftPanel_Click);
            // 
            // btnShowLeftPanel
            // 
            this.btnShowLeftPanel.Location = new System.Drawing.Point(3, 0);
            this.btnShowLeftPanel.Name = "btnShowLeftPanel";
            this.btnShowLeftPanel.Size = new System.Drawing.Size(14, 28);
            this.btnShowLeftPanel.TabIndex = 1;
            this.btnShowLeftPanel.Text = ">";
            this.btnShowLeftPanel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowLeftPanel.UseVisualStyleBackColor = true;
            this.btnShowLeftPanel.Visible = false;
            this.btnShowLeftPanel.Click += new System.EventHandler(this.btnShowLeftPanel_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(42, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(371, 21);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.txtAddress);
            this.pnlNavigation.Controls.Add(this.btnGo);
            this.pnlNavigation.Controls.Add(this.btnBack);
            this.pnlNavigation.Controls.Add(this.btnUp);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 0);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(434, 21);
            this.pnlNavigation.TabIndex = 5;
            // 
            // btnGo
            // 
            this.btnGo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGo.BackgroundImage")));
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGo.Location = new System.Drawing.Point(413, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(21, 21);
            this.btnGo.TabIndex = 6;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.Location = new System.Drawing.Point(21, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(21, 21);
            this.btnBack.TabIndex = 5;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUp.BackgroundImage")));
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUp.Location = new System.Drawing.Point(0, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(21, 21);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.spcBody);
            this.Controls.Add(this.pnlNavigation);
            this.Name = "Controller";
            this.Size = new System.Drawing.Size(434, 376);
            this.spcBody.Panel1.ResumeLayout(false);
            this.spcBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcBody)).EndInit();
            this.spcBody.ResumeLayout(false);
            this.spcMenu.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMenu)).EndInit();
            this.spcMenu.ResumeLayout(false);
            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcBody;
        private System.Windows.Forms.SplitContainer spcMenu;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnHideLeftPanel;
        private System.Windows.Forms.Button btnShowLeftPanel;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnBack;
    }
}
