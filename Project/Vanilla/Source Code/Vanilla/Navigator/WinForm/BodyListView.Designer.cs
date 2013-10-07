namespace Vanilla.Navigator.Presentation
{
    partial class BodyListView
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
            this.components = new System.ComponentModel.Container();
            this.lsvBody = new System.Windows.Forms.ListView();
            this.imlLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.imlSmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.spcBody = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNameValue = new System.Windows.Forms.Label();
            this.lblCreatedByValue = new System.Windows.Forms.Label();
            this.lblVersionValue = new System.Windows.Forms.Label();
            this.lblCreatedAtValue = new System.Windows.Forms.Label();
            this.lblModifiedAtValue = new System.Windows.Forms.Label();
            this.lblModifiedByValue = new System.Windows.Forms.Label();
            this.lblModifiedAt = new System.Windows.Forms.Label();
            this.lblModifiedBy = new System.Windows.Forms.Label();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spcBody)).BeginInit();
            this.spcBody.Panel1.SuspendLayout();
            this.spcBody.Panel2.SuspendLayout();
            this.spcBody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvBody
            // 
            this.lsvBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvBody.LargeImageList = this.imlLargeIcons;
            this.lsvBody.Location = new System.Drawing.Point(0, 0);
            this.lsvBody.Name = "lsvBody";
            this.lsvBody.Size = new System.Drawing.Size(642, 280);
            this.lsvBody.SmallImageList = this.imlSmallIcons;
            this.lsvBody.TabIndex = 0;
            this.lsvBody.UseCompatibleStateImageBehavior = false;
            this.lsvBody.SelectedIndexChanged += new System.EventHandler(this.lsvBody_SelectedIndexChanged);
            this.lsvBody.DoubleClick += new System.EventHandler(this.lsvBody_DoubleClick);
            // 
            // imlLargeIcons
            // 
            this.imlLargeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlLargeIcons.ImageSize = new System.Drawing.Size(32, 32);
            this.imlLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imlSmallIcons
            // 
            this.imlSmallIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlSmallIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imlSmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // spcBody
            // 
            this.spcBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcBody.Location = new System.Drawing.Point(0, 0);
            this.spcBody.Name = "spcBody";
            this.spcBody.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcBody.Panel1
            // 
            this.spcBody.Panel1.Controls.Add(this.lsvBody);
            // 
            // spcBody.Panel2
            // 
            this.spcBody.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.spcBody.Size = new System.Drawing.Size(642, 344);
            this.spcBody.SplitterDistance = 280;
            this.spcBody.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lblNameValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCreatedByValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblVersionValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCreatedAtValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblModifiedAtValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblModifiedByValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblModifiedAt, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblModifiedBy, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCreatedAt, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCreatedBy, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblVersion, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNameValue
            // 
            this.lblNameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNameValue.Location = new System.Drawing.Point(6, 31);
            this.lblNameValue.Name = "lblNameValue";
            this.lblNameValue.Size = new System.Drawing.Size(93, 26);
            this.lblNameValue.TabIndex = 11;
            this.lblNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedByValue
            // 
            this.lblCreatedByValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedByValue.Location = new System.Drawing.Point(218, 31);
            this.lblCreatedByValue.Name = "lblCreatedByValue";
            this.lblCreatedByValue.Size = new System.Drawing.Size(93, 26);
            this.lblCreatedByValue.TabIndex = 10;
            this.lblCreatedByValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersionValue
            // 
            this.lblVersionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersionValue.Location = new System.Drawing.Point(108, 31);
            this.lblVersionValue.Name = "lblVersionValue";
            this.lblVersionValue.Size = new System.Drawing.Size(101, 26);
            this.lblVersionValue.TabIndex = 9;
            this.lblVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedAtValue
            // 
            this.lblCreatedAtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedAtValue.Location = new System.Drawing.Point(320, 31);
            this.lblCreatedAtValue.Name = "lblCreatedAtValue";
            this.lblCreatedAtValue.Size = new System.Drawing.Size(101, 26);
            this.lblCreatedAtValue.TabIndex = 8;
            this.lblCreatedAtValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedAtValue
            // 
            this.lblModifiedAtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedAtValue.Location = new System.Drawing.Point(532, 31);
            this.lblModifiedAtValue.Name = "lblModifiedAtValue";
            this.lblModifiedAtValue.Size = new System.Drawing.Size(104, 26);
            this.lblModifiedAtValue.TabIndex = 7;
            this.lblModifiedAtValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedByValue
            // 
            this.lblModifiedByValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedByValue.Location = new System.Drawing.Point(430, 31);
            this.lblModifiedByValue.Name = "lblModifiedByValue";
            this.lblModifiedByValue.Size = new System.Drawing.Size(93, 26);
            this.lblModifiedByValue.TabIndex = 6;
            this.lblModifiedByValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedAt
            // 
            this.lblModifiedAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedAt.Location = new System.Drawing.Point(532, 3);
            this.lblModifiedAt.Name = "lblModifiedAt";
            this.lblModifiedAt.Size = new System.Drawing.Size(104, 25);
            this.lblModifiedAt.TabIndex = 5;
            this.lblModifiedAt.Text = "Modified At";
            this.lblModifiedAt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblModifiedBy
            // 
            this.lblModifiedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedBy.Location = new System.Drawing.Point(430, 3);
            this.lblModifiedBy.Name = "lblModifiedBy";
            this.lblModifiedBy.Size = new System.Drawing.Size(93, 25);
            this.lblModifiedBy.TabIndex = 4;
            this.lblModifiedBy.Text = "Modified By";
            this.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedAt.Location = new System.Drawing.Point(320, 3);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(101, 25);
            this.lblCreatedAt.TabIndex = 3;
            this.lblCreatedAt.Text = "Created At";
            this.lblCreatedAt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedBy.Location = new System.Drawing.Point(218, 3);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(93, 25);
            this.lblCreatedBy.TabIndex = 2;
            this.lblCreatedBy.Text = "Created By";
            this.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Location = new System.Drawing.Point(108, 3);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(101, 25);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(6, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(93, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BodyListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcBody);
            this.Name = "BodyListView";
            this.Size = new System.Drawing.Size(642, 344);
            this.Load += new System.EventHandler(this.BodyListView_Load);
            this.spcBody.Panel1.ResumeLayout(false);
            this.spcBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcBody)).EndInit();
            this.spcBody.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvBody;
        private System.Windows.Forms.ImageList imlLargeIcons;
        private System.Windows.Forms.ImageList imlSmallIcons;
        private System.Windows.Forms.SplitContainer spcBody;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblModifiedAt;
        private System.Windows.Forms.Label lblModifiedBy;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblModifiedByValue;
        private System.Windows.Forms.Label lblNameValue;
        private System.Windows.Forms.Label lblCreatedByValue;
        private System.Windows.Forms.Label lblVersionValue;
        private System.Windows.Forms.Label lblCreatedAtValue;
        private System.Windows.Forms.Label lblModifiedAtValue;
    }
}
