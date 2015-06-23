namespace Retinue.Lodge.WinForm
{
    partial class ReservationSummary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tpnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.ucCustomerSummary = new Retinue.Customer.WinForm.CustomerSummary();
            this.tpnlGuest = new System.Windows.Forms.TableLayoutPanel();
            this.txtInfant = new System.Windows.Forms.TextBox();
            this.txtFemale = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChild = new System.Windows.Forms.TextBox();
            this.tplHeading = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtReservationNo = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblReservationStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRooms = new System.Windows.Forms.TextBox();
            this.tpnlFrom = new System.Windows.Forms.TableLayoutPanel();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Display = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraBed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpnlContainer.SuspendLayout();
            this.tpnlGuest.SuspendLayout();
            this.tplHeading.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tpnlFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // tpnlContainer
            // 
            this.tpnlContainer.ColumnCount = 3;
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tpnlContainer.Controls.Add(this.ucCustomerSummary, 0, 0);
            this.tpnlContainer.Controls.Add(this.tpnlGuest, 0, 5);
            this.tpnlContainer.Controls.Add(this.tplHeading, 0, 1);
            this.tpnlContainer.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tpnlContainer.Controls.Add(this.tpnlFrom, 2, 2);
            this.tpnlContainer.Controls.Add(this.label1, 0, 2);
            this.tpnlContainer.Controls.Add(this.dgvRoom, 0, 4);
            this.tpnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlContainer.Location = new System.Drawing.Point(0, 0);
            this.tpnlContainer.Name = "tpnlContainer";
            this.tpnlContainer.RowCount = 7;
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlContainer.Size = new System.Drawing.Size(556, 413);
            this.tpnlContainer.TabIndex = 0;
            // 
            // ucCustomerSummary
            // 
            this.tpnlContainer.SetColumnSpan(this.ucCustomerSummary, 3);
            this.ucCustomerSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCustomerSummary.Location = new System.Drawing.Point(0, 0);
            this.ucCustomerSummary.Margin = new System.Windows.Forms.Padding(0);
            this.ucCustomerSummary.Name = "ucCustomerSummary";
            this.ucCustomerSummary.Size = new System.Drawing.Size(556, 196);
            this.ucCustomerSummary.TabIndex = 1;
            // 
            // tpnlGuest
            // 
            this.tpnlGuest.ColumnCount = 8;
            this.tpnlContainer.SetColumnSpan(this.tpnlGuest, 3);
            this.tpnlGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tpnlGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tpnlGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tpnlGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tpnlGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tpnlGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tpnlGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tpnlGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tpnlGuest.Controls.Add(this.txtInfant, 7, 0);
            this.tpnlGuest.Controls.Add(this.txtFemale, 3, 0);
            this.tpnlGuest.Controls.Add(this.label11, 6, 0);
            this.tpnlGuest.Controls.Add(this.label10, 4, 0);
            this.tpnlGuest.Controls.Add(this.label9, 2, 0);
            this.tpnlGuest.Controls.Add(this.txtMale, 1, 0);
            this.tpnlGuest.Controls.Add(this.label3, 0, 0);
            this.tpnlGuest.Controls.Add(this.txtChild, 5, 0);
            this.tpnlGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlGuest.Location = new System.Drawing.Point(0, 385);
            this.tpnlGuest.Margin = new System.Windows.Forms.Padding(0);
            this.tpnlGuest.Name = "tpnlGuest";
            this.tpnlGuest.RowCount = 1;
            this.tpnlGuest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlGuest.Size = new System.Drawing.Size(556, 26);
            this.tpnlGuest.TabIndex = 1;
            // 
            // txtInfant
            // 
            this.txtInfant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfant.Location = new System.Drawing.Point(500, 3);
            this.txtInfant.MaxLength = 3;
            this.txtInfant.Name = "txtInfant";
            this.txtInfant.ReadOnly = true;
            this.txtInfant.Size = new System.Drawing.Size(53, 20);
            this.txtInfant.TabIndex = 119;
            // 
            // txtFemale
            // 
            this.txtFemale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFemale.Location = new System.Drawing.Point(224, 3);
            this.txtFemale.MaxLength = 3;
            this.txtFemale.Name = "txtFemale";
            this.txtFemale.ReadOnly = true;
            this.txtFemale.Size = new System.Drawing.Size(49, 20);
            this.txtFemale.TabIndex = 116;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(417, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 26);
            this.label11.TabIndex = 120;
            this.label11.Text = "Infant";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(279, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 26);
            this.label10.TabIndex = 117;
            this.label10.Text = "Child";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(141, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 26);
            this.label9.TabIndex = 115;
            this.label9.Text = "Female";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMale
            // 
            this.txtMale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMale.Location = new System.Drawing.Point(86, 3);
            this.txtMale.MaxLength = 3;
            this.txtMale.Name = "txtMale";
            this.txtMale.ReadOnly = true;
            this.txtMale.Size = new System.Drawing.Size(49, 20);
            this.txtMale.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 26);
            this.label3.TabIndex = 85;
            this.label3.Text = "Male";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChild
            // 
            this.txtChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChild.Location = new System.Drawing.Point(362, 3);
            this.txtChild.MaxLength = 3;
            this.txtChild.Name = "txtChild";
            this.txtChild.ReadOnly = true;
            this.txtChild.Size = new System.Drawing.Size(49, 20);
            this.txtChild.TabIndex = 118;
            // 
            // tplHeading
            // 
            this.tplHeading.ColumnCount = 4;
            this.tpnlContainer.SetColumnSpan(this.tplHeading, 3);
            this.tplHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tplHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tplHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tplHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tplHeading.Controls.Add(this.label17, 0, 0);
            this.tplHeading.Controls.Add(this.txtReservationNo, 1, 0);
            this.tplHeading.Controls.Add(this.txtStatus, 3, 0);
            this.tplHeading.Controls.Add(this.lblReservationStatus, 2, 0);
            this.tplHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplHeading.Location = new System.Drawing.Point(0, 196);
            this.tplHeading.Margin = new System.Windows.Forms.Padding(0);
            this.tplHeading.Name = "tplHeading";
            this.tplHeading.RowCount = 1;
            this.tplHeading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplHeading.Size = new System.Drawing.Size(556, 24);
            this.tplHeading.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 24);
            this.label17.TabIndex = 1028;
            this.label17.Text = "Reservation No";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReservationNo
            // 
            this.txtReservationNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReservationNo.Location = new System.Drawing.Point(114, 3);
            this.txtReservationNo.Name = "txtReservationNo";
            this.txtReservationNo.ReadOnly = true;
            this.txtReservationNo.Size = new System.Drawing.Size(160, 20);
            this.txtReservationNo.TabIndex = 1029;
            this.txtReservationNo.TabStop = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Location = new System.Drawing.Point(391, 3);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(162, 20);
            this.txtStatus.TabIndex = 1031;
            this.txtStatus.TabStop = false;
            // 
            // lblReservationStatus
            // 
            this.lblReservationStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReservationStatus.Location = new System.Drawing.Point(280, 0);
            this.lblReservationStatus.Name = "lblReservationStatus";
            this.lblReservationStatus.Size = new System.Drawing.Size(105, 24);
            this.lblReservationStatus.TabIndex = 1030;
            this.lblReservationStatus.Text = "Status";
            this.lblReservationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tpnlContainer.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtDays, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtRooms, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 244);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(556, 24);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(280, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 24);
            this.label4.TabIndex = 1019;
            this.label4.Text = "Total Rooms";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDays
            // 
            this.txtDays.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDays.Location = new System.Drawing.Point(114, 3);
            this.txtDays.MaxLength = 3;
            this.txtDays.Name = "txtDays";
            this.txtDays.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(50, 20);
            this.txtDays.TabIndex = 1018;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 1017;
            this.label2.Text = "No of Days";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRooms
            // 
            this.txtRooms.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtRooms.Location = new System.Drawing.Point(391, 3);
            this.txtRooms.MaxLength = 3;
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.ReadOnly = true;
            this.txtRooms.Size = new System.Drawing.Size(50, 20);
            this.txtRooms.TabIndex = 1020;
            // 
            // tpnlFrom
            // 
            this.tpnlFrom.ColumnCount = 2;
            this.tpnlFrom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tpnlFrom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tpnlFrom.Controls.Add(this.txtTime, 1, 0);
            this.tpnlFrom.Controls.Add(this.txtDate, 0, 0);
            this.tpnlFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlFrom.Location = new System.Drawing.Point(193, 220);
            this.tpnlFrom.Margin = new System.Windows.Forms.Padding(0);
            this.tpnlFrom.Name = "tpnlFrom";
            this.tpnlFrom.RowCount = 1;
            this.tpnlFrom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlFrom.Size = new System.Drawing.Size(363, 24);
            this.tpnlFrom.TabIndex = 1033;
            // 
            // txtTime
            // 
            this.txtTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTime.Location = new System.Drawing.Point(257, 3);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(103, 20);
            this.txtTime.TabIndex = 2;
            // 
            // txtDate
            // 
            this.txtDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDate.Location = new System.Drawing.Point(3, 3);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(248, 20);
            this.txtDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 1032;
            this.label1.Text = "From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvRoom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoom.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.RoomName,
            this.Display,
            this.ExtraBed});
            this.tpnlContainer.SetColumnSpan(this.dgvRoom, 3);
            this.dgvRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoom.Location = new System.Drawing.Point(3, 271);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoom.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoom.Size = new System.Drawing.Size(550, 111);
            this.dgvRoom.TabIndex = 1034;
            // 
            // Number
            // 
            this.Number.FillWeight = 50F;
            this.Number.Frozen = true;
            this.Number.HeaderText = "Number";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 50;
            // 
            // RoomName
            // 
            this.RoomName.Frozen = true;
            this.RoomName.HeaderText = "Name";
            this.RoomName.Name = "RoomName";
            this.RoomName.ReadOnly = true;
            // 
            // Display
            // 
            this.Display.FillWeight = 200F;
            this.Display.HeaderText = "Details";
            this.Display.Name = "Display";
            this.Display.ReadOnly = true;
            this.Display.Width = 200;
            // 
            // ExtraBed
            // 
            this.ExtraBed.FillWeight = 80F;
            this.ExtraBed.HeaderText = "Extra Bed";
            this.ExtraBed.Name = "ExtraBed";
            this.ExtraBed.ReadOnly = true;
            this.ExtraBed.Width = 80;
            // 
            // ReservationSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tpnlContainer);
            this.Name = "ReservationSummary";
            this.Size = new System.Drawing.Size(556, 413);
            this.tpnlContainer.ResumeLayout(false);
            this.tpnlGuest.ResumeLayout(false);
            this.tpnlGuest.PerformLayout();
            this.tplHeading.ResumeLayout(false);
            this.tplHeading.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tpnlFrom.ResumeLayout(false);
            this.tpnlFrom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpnlContainer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtReservationNo;
        private System.Windows.Forms.Label lblReservationStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tpnlFrom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRooms;
        private System.Windows.Forms.TableLayoutPanel tplHeading;
        private System.Windows.Forms.TableLayoutPanel tpnlGuest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFemale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChild;
        private System.Windows.Forms.TextBox txtInfant;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.DataGridView dgvRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Display;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraBed;
        private Customer.WinForm.CustomerSummary ucCustomerSummary;
    }
}
