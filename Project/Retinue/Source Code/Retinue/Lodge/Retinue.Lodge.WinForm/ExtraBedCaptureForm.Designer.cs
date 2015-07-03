namespace Retinue.Lodge.WinForm
{
    partial class ExtraBedCaptureForm
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
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtTotalGuest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraAccomodation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraAccomodationAvailed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRooms
            // 
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvRooms.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Number,
            this.RoomName,
            this.Bed,
            this.ExtraAccomodation,
            this.ExtraAccomodationAvailed});
            this.dgvRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRooms.Location = new System.Drawing.Point(0, 22);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(423, 142);
            this.dgvRooms.TabIndex = 1037;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnOk);
            this.pnlHeader.Controls.Add(this.txtTotalGuest);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(423, 22);
            this.pnlHeader.TabIndex = 1038;
            // 
            // btnOk
            // 
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Font = new System.Drawing.Font("Wingdings 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnOk.Location = new System.Drawing.Point(388, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(35, 22);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "P";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtTotalGuest
            // 
            this.txtTotalGuest.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTotalGuest.Location = new System.Drawing.Point(100, 0);
            this.txtTotalGuest.Name = "txtTotalGuest";
            this.txtTotalGuest.ReadOnly = true;
            this.txtTotalGuest.Size = new System.Drawing.Size(45, 20);
            this.txtTotalGuest.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Guests:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Id
            // 
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 41;
            // 
            // Number
            // 
            this.Number.Frozen = true;
            this.Number.HeaderText = "Number";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 69;
            // 
            // RoomName
            // 
            this.RoomName.Frozen = true;
            this.RoomName.HeaderText = "Room Name";
            this.RoomName.Name = "RoomName";
            this.RoomName.ReadOnly = true;
            this.RoomName.Width = 91;
            // 
            // Bed
            // 
            this.Bed.Frozen = true;
            this.Bed.HeaderText = "Bed";
            this.Bed.Name = "Bed";
            this.Bed.ReadOnly = true;
            this.Bed.Width = 51;
            // 
            // ExtraAccomodation
            // 
            this.ExtraAccomodation.HeaderText = "Extra Bed";
            this.ExtraAccomodation.Name = "ExtraAccomodation";
            this.ExtraAccomodation.ReadOnly = true;
            this.ExtraAccomodation.Width = 78;
            // 
            // ExtraAccomodationAvailed
            // 
            this.ExtraAccomodationAvailed.HeaderText = "Availed";
            this.ExtraAccomodationAvailed.Name = "ExtraAccomodationAvailed";
            this.ExtraAccomodationAvailed.Width = 67;
            // 
            // ExtraBedCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 164);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtraBedCaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extra Bed Capture Form";
            this.Load += new System.EventHandler(this.ExtraBedCaptureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalGuest;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraAccomodation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraAccomodationAvailed;
    }
}