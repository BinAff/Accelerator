namespace Vanilla.Form.WinForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlAttachment = new System.Windows.Forms.Panel();
            this.dgvAttachmentList = new System.Windows.Forms.DataGridView();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnOk = new System.Windows.Forms.ToolStripButton();
            this.btnAddAncestor = new System.Windows.Forms.ToolStripButton();
            this.pnlAttachment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAttachment
            // 
            this.pnlAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAttachment.Controls.Add(this.dgvAttachmentList);
            this.pnlAttachment.Location = new System.Drawing.Point(924, 565);
            this.pnlAttachment.Name = "pnlAttachment";
            this.pnlAttachment.Size = new System.Drawing.Size(26, 15);
            this.pnlAttachment.TabIndex = 7;
            this.pnlAttachment.Visible = false;
            // 
            // dgvAttachmentList
            // 
            this.dgvAttachmentList.AllowUserToAddRows = false;
            this.dgvAttachmentList.AllowUserToResizeRows = false;
            this.dgvAttachmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Path,
            this.Delete});
            this.dgvAttachmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachmentList.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachmentList.MultiSelect = false;
            this.dgvAttachmentList.Name = "dgvAttachmentList";
            this.dgvAttachmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachmentList.Size = new System.Drawing.Size(26, 15);
            this.dgvAttachmentList.TabIndex = 0;
            this.dgvAttachmentList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttachmentList_CellContentDoubleClick);
            this.dgvAttachmentList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttachmentList_CellMouseClick);
            // 
            // Path
            // 
            this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Path.HeaderText = "Full Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 50F;
            this.Delete.HeaderText = "Action";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.Width = 50;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOk,
            this.btnAddAncestor});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(962, 31);
            this.toolStrip.TabIndex = 100;
            // 
            // btnOk
            // 
            this.btnOk.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOk.Font = new System.Drawing.Font("Wingdings 2", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(28, 28);
            this.btnOk.Text = "P";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAddAncestor
            // 
            this.btnAddAncestor.AutoSize = false;
            this.btnAddAncestor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddAncestor.Font = new System.Drawing.Font("Wingdings 2", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAddAncestor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAncestor.Name = "btnAddAncestor";
            this.btnAddAncestor.Size = new System.Drawing.Size(28, 28);
            this.btnAddAncestor.Text = "Ç";
            this.btnAddAncestor.ToolTipText = "Add ";
            this.btnAddAncestor.Click += new System.EventHandler(this.btnAddAncestor_Click);
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 592);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.pnlAttachment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Document";
            this.Text = "Forms";
            this.Controls.SetChildIndex(this.pnlAttachment, 0);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.pnlAttachment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Panel pnlAttachment;
        private System.Windows.Forms.DataGridView dgvAttachmentList;
        protected System.Windows.Forms.ToolTip toolTip;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripButton btnAddAncestor;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewLinkColumn Action;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.ToolStripButton btnOk;

    }
}