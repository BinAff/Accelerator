namespace Vanilla.Utility.WinForm
{
    partial class SidePanel
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
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlControlBar = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.pnlTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTitleBar.Controls.Add(this.btnShow);
            this.pnlTitleBar.Controls.Add(this.lblTitleBar);
            this.pnlTitleBar.Controls.Add(this.btnHide);
            this.pnlTitleBar.Controls.Add(this.btnClose);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(326, 26);
            this.pnlTitleBar.TabIndex = 0;
            // 
            // lblTitleBar
            // 
            this.lblTitleBar.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleBar.Location = new System.Drawing.Point(0, 0);
            this.lblTitleBar.Name = "lblTitleBar";
            this.lblTitleBar.Size = new System.Drawing.Size(278, 22);
            this.lblTitleBar.TabIndex = 2;
            this.lblTitleBar.Text = "Panel Title Bar";
            this.lblTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.SystemColors.Control;
            this.btnHide.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHide.FlatAppearance.BorderSize = 0;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Webdings", 8F);
            this.btnHide.Location = new System.Drawing.Point(278, 0);
            this.btnHide.Margin = new System.Windows.Forms.Padding(0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(22, 22);
            this.btnHide.TabIndex = 1;
            this.btnHide.Text = "ë";
            this.btnHide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHide.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHide.UseMnemonic = false;
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnClose.Location = new System.Drawing.Point(300, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlOptions.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.pnlOptions.ColumnCount = 1;
            this.pnlOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOptions.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.pnlOptions.Location = new System.Drawing.Point(0, 207);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.RowCount = 1;
            this.pnlOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlOptions.Size = new System.Drawing.Size(326, 20);
            this.pnlOptions.TabIndex = 1;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Location = new System.Drawing.Point(0, 57);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(59, 150);
            this.pnlContainer.TabIndex = 2;
            // 
            // pnlControlBar
            // 
            this.pnlControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlBar.Location = new System.Drawing.Point(0, 26);
            this.pnlControlBar.Name = "pnlControlBar";
            this.pnlControlBar.Size = new System.Drawing.Size(326, 31);
            this.pnlControlBar.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.SystemColors.Control;
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Webdings", 8F);
            this.btnShow.Location = new System.Drawing.Point(256, 0);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(22, 22);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "L";
            this.btnShow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShow.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnShow.UseMnemonic = false;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // SidePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlControlBar);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlTitleBar);
            this.Name = "SidePanel";
            this.Size = new System.Drawing.Size(326, 227);
            this.Load += new System.EventHandler(this.SidePanel_Load);
            this.Resize += new System.EventHandler(this.SidePanel_Resize);
            this.pnlTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitleBar;
        private System.Windows.Forms.TableLayoutPanel pnlOptions;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlControlBar;
        private System.Windows.Forms.Button btnShow;

    }
}
