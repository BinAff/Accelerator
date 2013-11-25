namespace Vanilla.Navigator.WinForm
{
    partial class Container
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
            this.pnlMain = new System.Windows.Forms.SplitContainer();
            this.tbcCategory = new System.Windows.Forms.TabControl();
            this.tbpForm = new System.Windows.Forms.TabPage();
            this.trvForm = new System.Windows.Forms.TreeView();
            this.tbpCatalogue = new System.Windows.Forms.TabPage();
            this.trvCatalogue = new System.Windows.Forms.TreeView();
            this.tbpReport = new System.Windows.Forms.TabPage();
            this.trvReport = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.btnNote = new System.Windows.Forms.Button();
            this.btnSms = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnCalender = new System.Windows.Forms.Button();
            this.lstViewContainer = new System.Windows.Forms.ListView();
            this.lblAudit = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmsExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.Panel1.SuspendLayout();
            this.pnlMain.Panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tbcCategory.SuspendLayout();
            this.tbpForm.SuspendLayout();
            this.tbpCatalogue.SuspendLayout();
            this.tbpReport.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.cmsExplorer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnlMain.Location = new System.Drawing.Point(0, 23);
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlMain.Panel1
            // 
            this.pnlMain.Panel1.Controls.Add(this.tbcCategory);
            this.pnlMain.Panel1.Controls.Add(this.panel1);
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.lstViewContainer);
            this.pnlMain.Panel2.Controls.Add(this.lblAudit);
            this.pnlMain.Size = new System.Drawing.Size(591, 371);
            this.pnlMain.SplitterDistance = 179;
            this.pnlMain.TabIndex = 0;
            // 
            // tbcCategory
            // 
            this.tbcCategory.Controls.Add(this.tbpForm);
            this.tbcCategory.Controls.Add(this.tbpCatalogue);
            this.tbcCategory.Controls.Add(this.tbpReport);
            this.tbcCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcCategory.Location = new System.Drawing.Point(0, 0);
            this.tbcCategory.Name = "tbcCategory";
            this.tbcCategory.SelectedIndex = 0;
            this.tbcCategory.Size = new System.Drawing.Size(175, 344);
            this.tbcCategory.TabIndex = 2;
            this.tbcCategory.SelectedIndexChanged += new System.EventHandler(this.tbcCategory_SelectedIndexChanged);
            this.tbcCategory.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tbcCategory_Deselected);
            // 
            // tbpForm
            // 
            this.tbpForm.Controls.Add(this.trvForm);
            this.tbpForm.Location = new System.Drawing.Point(4, 22);
            this.tbpForm.Name = "tbpForm";
            this.tbpForm.Padding = new System.Windows.Forms.Padding(3);
            this.tbpForm.Size = new System.Drawing.Size(167, 318);
            this.tbpForm.TabIndex = 0;
            this.tbpForm.Text = "Form";
            this.tbpForm.UseVisualStyleBackColor = true;
            // 
            // trvForm
            // 
            this.trvForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvForm.Location = new System.Drawing.Point(3, 3);
            this.trvForm.Name = "trvForm";
            this.trvForm.Size = new System.Drawing.Size(161, 312);
            this.trvForm.TabIndex = 6;
            this.trvForm.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.trvArtifact_AfterLabelEdit);
            this.trvForm.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvArtifact_AfterSelect);
            this.trvForm.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvForm_NodeMouseClick);
            this.trvForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trvArtifact_KeyUp);
            this.trvForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvArtifact_MouseDown);
            // 
            // tbpCatalogue
            // 
            this.tbpCatalogue.Controls.Add(this.trvCatalogue);
            this.tbpCatalogue.Location = new System.Drawing.Point(4, 22);
            this.tbpCatalogue.Name = "tbpCatalogue";
            this.tbpCatalogue.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCatalogue.Size = new System.Drawing.Size(167, 318);
            this.tbpCatalogue.TabIndex = 1;
            this.tbpCatalogue.Text = "Catalogue";
            this.tbpCatalogue.UseVisualStyleBackColor = true;
            // 
            // trvCatalogue
            // 
            this.trvCatalogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvCatalogue.Location = new System.Drawing.Point(3, 3);
            this.trvCatalogue.Name = "trvCatalogue";
            this.trvCatalogue.Size = new System.Drawing.Size(161, 312);
            this.trvCatalogue.TabIndex = 0;
            this.trvCatalogue.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.trvArtifact_AfterLabelEdit);
            this.trvCatalogue.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvArtifact_AfterSelect);
            this.trvCatalogue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trvArtifact_KeyUp);
            this.trvCatalogue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvArtifact_MouseDown);
            // 
            // tbpReport
            // 
            this.tbpReport.Controls.Add(this.trvReport);
            this.tbpReport.Location = new System.Drawing.Point(4, 22);
            this.tbpReport.Name = "tbpReport";
            this.tbpReport.Padding = new System.Windows.Forms.Padding(3);
            this.tbpReport.Size = new System.Drawing.Size(167, 318);
            this.tbpReport.TabIndex = 2;
            this.tbpReport.Text = "Report";
            this.tbpReport.UseVisualStyleBackColor = true;
            // 
            // trvReport
            // 
            this.trvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvReport.Location = new System.Drawing.Point(3, 3);
            this.trvReport.Name = "trvReport";
            this.trvReport.Size = new System.Drawing.Size(161, 312);
            this.trvReport.TabIndex = 0;
            this.trvReport.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.trvArtifact_AfterLabelEdit);
            this.trvReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvArtifact_AfterSelect);
            this.trvReport.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trvArtifact_KeyUp);
            this.trvReport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvArtifact_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfiguration);
            this.panel1.Controls.Add(this.btnNote);
            this.panel1.Controls.Add(this.btnSms);
            this.panel1.Controls.Add(this.btnEmail);
            this.panel1.Controls.Add(this.btnCalender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 344);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 23);
            this.panel1.TabIndex = 2;
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguration.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConfiguration.Font = new System.Drawing.Font("Webdings", 10F);
            this.btnConfiguration.Location = new System.Drawing.Point(92, 0);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(23, 23);
            this.btnConfiguration.TabIndex = 1;
            this.btnConfiguration.Text = "@";
            this.btnConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnConfiguration, "Configuration");
            this.btnConfiguration.UseVisualStyleBackColor = true;
            // 
            // btnNote
            // 
            this.btnNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNote.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNote.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNote.Font = new System.Drawing.Font("Webdings", 10F);
            this.btnNote.Location = new System.Drawing.Point(69, 0);
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(23, 23);
            this.btnNote.TabIndex = 2;
            this.btnNote.Text = "ë";
            this.btnNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnNote, "Note");
            this.btnNote.UseVisualStyleBackColor = true;
            // 
            // btnSms
            // 
            this.btnSms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSms.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSms.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSms.Font = new System.Drawing.Font("Webdings", 10F);
            this.btnSms.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSms.Location = new System.Drawing.Point(46, 0);
            this.btnSms.Name = "btnSms";
            this.btnSms.Size = new System.Drawing.Size(23, 23);
            this.btnSms.TabIndex = 3;
            this.btnSms.Text = "À";
            this.btnSms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnSms, "SMS");
            this.btnSms.UseVisualStyleBackColor = true;
            // 
            // btnEmail
            // 
            this.btnEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmail.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEmail.Font = new System.Drawing.Font("Webdings", 10F);
            this.btnEmail.Location = new System.Drawing.Point(23, 0);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(23, 23);
            this.btnEmail.TabIndex = 4;
            this.btnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnEmail, "Email");
            this.btnEmail.UseVisualStyleBackColor = true;
            // 
            // btnCalender
            // 
            this.btnCalender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalender.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCalender.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalender.Font = new System.Drawing.Font("Webdings", 10F);
            this.btnCalender.Location = new System.Drawing.Point(0, 0);
            this.btnCalender.Name = "btnCalender";
            this.btnCalender.Size = new System.Drawing.Size(23, 23);
            this.btnCalender.TabIndex = 5;
            this.btnCalender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnCalender, "Calender");
            this.btnCalender.UseVisualStyleBackColor = true;
            // 
            // lstViewContainer
            // 
            this.lstViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViewContainer.Location = new System.Drawing.Point(0, 0);
            this.lstViewContainer.Name = "lstViewContainer";
            this.lstViewContainer.Size = new System.Drawing.Size(404, 344);
            this.lstViewContainer.TabIndex = 1;
            this.lstViewContainer.UseCompatibleStateImageBehavior = false;
            this.lstViewContainer.View = System.Windows.Forms.View.Details;
            this.lstViewContainer.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstViewContainer_AfterLabelEdit);
            this.lstViewContainer.DoubleClick += new System.EventHandler(this.lstViewContainer_DoubleClick);
            this.lstViewContainer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstViewContainer_KeyUp);
            // 
            // lblAudit
            // 
            this.lblAudit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAudit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAudit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAudit.Location = new System.Drawing.Point(0, 344);
            this.lblAudit.Name = "lblAudit";
            this.lblAudit.Size = new System.Drawing.Size(404, 23);
            this.lblAudit.TabIndex = 0;
            this.lblAudit.Text = "label1";
            this.lblAudit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(46, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(522, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnUp.Location = new System.Drawing.Point(0, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 23);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "Ç";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBack.Location = new System.Drawing.Point(23, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Å";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnEnter.Location = new System.Drawing.Point(568, 0);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(23, 23);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "Æ";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // pnlAddress
            // 
            this.pnlAddress.Controls.Add(this.txtAddress);
            this.pnlAddress.Controls.Add(this.btnEnter);
            this.pnlAddress.Controls.Add(this.btnBack);
            this.pnlAddress.Controls.Add(this.btnUp);
            this.pnlAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAddress.Location = new System.Drawing.Point(0, 0);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(591, 23);
            this.pnlAddress.TabIndex = 5;
            // 
            // cmsExplorer
            // 
            this.cmsExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.cmsExplorer.Name = "cmsExplorer";
            this.cmsExplorer.Size = new System.Drawing.Size(96, 26);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 394);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlAddress);
            this.Name = "Container";
            this.Text = "Navigator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Container_Load);
            this.pnlMain.Panel1.ResumeLayout(false);
            this.pnlMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tbcCategory.ResumeLayout(false);
            this.tbpForm.ResumeLayout(false);
            this.tbpCatalogue.ResumeLayout(false);
            this.tbpReport.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.cmsExplorer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer pnlMain;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.Label lblAudit;
        private System.Windows.Forms.ListView lstViewContainer;
        private System.Windows.Forms.TreeView trvForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.Button btnNote;
        private System.Windows.Forms.Button btnCalender;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnSms;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabControl tbcCategory;
        private System.Windows.Forms.TabPage tbpForm;
        private System.Windows.Forms.TabPage tbpCatalogue;
        private System.Windows.Forms.TabPage tbpReport;
        private System.Windows.Forms.ContextMenuStrip cmsExplorer;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.TreeView trvCatalogue;
        private System.Windows.Forms.TreeView trvReport;

    }
}