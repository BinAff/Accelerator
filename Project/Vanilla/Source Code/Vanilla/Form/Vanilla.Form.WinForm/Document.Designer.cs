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
            this.pnlAttachment = new System.Windows.Forms.Panel();
            this.dgvAttachmentList = new System.Windows.Forms.DataGridView();
            this.AttachedFormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachedFormType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExpandCollapse = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnAddAncestor = new System.Windows.Forms.Button();
            this.btnPickAncestor = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.pnlAttachment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAttachment
            // 
            this.pnlAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAttachment.Controls.Add(this.dgvAttachmentList);
            this.pnlAttachment.Location = new System.Drawing.Point(15, 234);
            this.pnlAttachment.Name = "pnlAttachment";
            this.pnlAttachment.Size = new System.Drawing.Size(411, 161);
            this.pnlAttachment.TabIndex = 7;
            this.pnlAttachment.Visible = false;
            // 
            // dgvAttachmentList
            // 
            this.dgvAttachmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttachedFormName,
            this.AttachedFormType});
            this.dgvAttachmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachmentList.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachmentList.Name = "dgvAttachmentList";
            this.dgvAttachmentList.Size = new System.Drawing.Size(411, 161);
            this.dgvAttachmentList.TabIndex = 0;
            // 
            // AttachedFormName
            // 
            this.AttachedFormName.FillWeight = 200F;
            this.AttachedFormName.HeaderText = "Name";
            this.AttachedFormName.Name = "AttachedFormName";
            this.AttachedFormName.Width = 200;
            // 
            // AttachedFormType
            // 
            this.AttachedFormType.FillWeight = 150F;
            this.AttachedFormType.HeaderText = "Type";
            this.AttachedFormType.Name = "AttachedFormType";
            this.AttachedFormType.Width = 150;
            // 
            // btnExpandCollapse
            // 
            this.btnExpandCollapse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExpandCollapse.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnExpandCollapse.Location = new System.Drawing.Point(0, 0);
            this.btnExpandCollapse.Margin = new System.Windows.Forms.Padding(0);
            this.btnExpandCollapse.Name = "btnExpandCollapse";
            this.btnExpandCollapse.Size = new System.Drawing.Size(34, 20);
            this.btnExpandCollapse.TabIndex = 6;
            this.btnExpandCollapse.Text = "×";
            this.toolTip.SetToolTip(this.btnExpandCollapse, "Attachments");
            this.btnExpandCollapse.UseVisualStyleBackColor = true;
            this.btnExpandCollapse.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOk.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnOk.Location = new System.Drawing.Point(0, 54);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(34, 34);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "ü";
            this.toolTip.SetToolTip(this.btnOk, "Ok");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRefresh.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRefresh.Location = new System.Drawing.Point(0, 20);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Q";
            this.toolTip.SetToolTip(this.btnRefresh, "Refresh form");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnAddAncestor);
            this.pnlRight.Controls.Add(this.btnPickAncestor);
            this.pnlRight.Controls.Add(this.btnOk);
            this.pnlRight.Controls.Add(this.btnRefresh);
            this.pnlRight.Controls.Add(this.btnExpandCollapse);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(392, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(34, 432);
            this.pnlRight.TabIndex = 8;
            // 
            // btnAddAncestor
            // 
            this.btnAddAncestor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddAncestor.Font = new System.Drawing.Font("Wingdings 2", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAddAncestor.Location = new System.Drawing.Point(0, 122);
            this.btnAddAncestor.Name = "btnAddAncestor";
            this.btnAddAncestor.Size = new System.Drawing.Size(34, 34);
            this.btnAddAncestor.TabIndex = 8;
            this.btnAddAncestor.Text = "Ç";
            this.toolTip.SetToolTip(this.btnAddAncestor, "Add");
            this.btnAddAncestor.UseVisualStyleBackColor = true;
            this.btnAddAncestor.Click += new System.EventHandler(this.btnAddAncestor_Click);
            // 
            // btnPickAncestor
            // 
            this.btnPickAncestor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPickAncestor.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnPickAncestor.Location = new System.Drawing.Point(0, 88);
            this.btnPickAncestor.Margin = new System.Windows.Forms.Padding(0);
            this.btnPickAncestor.Name = "btnPickAncestor";
            this.btnPickAncestor.Size = new System.Drawing.Size(34, 34);
            this.btnPickAncestor.TabIndex = 7;
            this.btnPickAncestor.Text = "Ì";
            this.toolTip.SetToolTip(this.btnPickAncestor, "Pick");
            this.btnPickAncestor.UseVisualStyleBackColor = true;
            this.btnPickAncestor.Click += new System.EventHandler(this.btnPickAncestor_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 432);
            this.Controls.Add(this.pnlAttachment);
            this.Controls.Add(this.pnlRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Document";
            this.Text = "Forms";
            this.Shown += new System.EventHandler(this.Document_Shown);
            this.pnlAttachment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel pnlAttachment;
        private System.Windows.Forms.DataGridView dgvAttachmentList;
        private System.Windows.Forms.Button btnExpandCollapse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlRight;
        protected System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnAddAncestor;
        private System.Windows.Forms.Button btnPickAncestor;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttachedFormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttachedFormType;
        protected System.Windows.Forms.ErrorProvider errorProvider;

    }
}