namespace AutoTourism.Lodge.WinForm
{
    partial class RoomReservationRegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRooms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPersons = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtBookingFrom = new System.Windows.Forms.DateTimePicker();
            this.dtBookingTo = new System.Windows.Forms.DateTimePicker();
            this.dgvReservation = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Advance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuItemCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuItemCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).BeginInit();
            this.contextMenuGrid.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAdvance
            // 
            this.txtAdvance.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdvance.Enabled = false;
            this.txtAdvance.ForeColor = System.Drawing.Color.Black;
            this.txtAdvance.Location = new System.Drawing.Point(109, 125);
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Size = new System.Drawing.Size(148, 20);
            this.txtAdvance.TabIndex = 105;
            this.txtAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(15, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Advance Amount";
            // 
            // txtRooms
            // 
            this.txtRooms.BackColor = System.Drawing.SystemColors.Window;
            this.txtRooms.Enabled = false;
            this.txtRooms.ForeColor = System.Drawing.Color.Black;
            this.txtRooms.Location = new System.Drawing.Point(110, 99);
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.Size = new System.Drawing.Size(32, 20);
            this.txtRooms.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "No of Rooms";
            // 
            // txtPersons
            // 
            this.txtPersons.BackColor = System.Drawing.SystemColors.Window;
            this.txtPersons.Enabled = false;
            this.txtPersons.ForeColor = System.Drawing.Color.Black;
            this.txtPersons.Location = new System.Drawing.Point(110, 73);
            this.txtPersons.Name = "txtPersons";
            this.txtPersons.Size = new System.Drawing.Size(32, 20);
            this.txtPersons.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "No of Persons";
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.SystemColors.Window;
            this.txtDays.Enabled = false;
            this.txtDays.ForeColor = System.Drawing.Color.Black;
            this.txtDays.Location = new System.Drawing.Point(110, 47);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(32, 20);
            this.txtDays.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(15, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "No of Days";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAdds);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lstContact);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(267, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 217);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.Enabled = false;
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(104, 185);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(154, 20);
            this.txtEmail.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(9, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 84;
            this.label8.Text = "EMail";
            // 
            // txtAdds
            // 
            this.txtAdds.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdds.Enabled = false;
            this.txtAdds.ForeColor = System.Drawing.Color.Black;
            this.txtAdds.Location = new System.Drawing.Point(104, 111);
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.Size = new System.Drawing.Size(154, 66);
            this.txtAdds.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(9, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 82;
            this.label7.Text = "Address";
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.SystemColors.Window;
            this.lstContact.Enabled = false;
            this.lstContact.ForeColor = System.Drawing.Color.Black;
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(104, 48);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(154, 56);
            this.lstContact.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(9, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Contact Numbers";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Enabled = false;
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(104, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 20);
            this.txtName.TabIndex = 23;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Enabled = false;
            this.lblName.Location = new System.Drawing.Point(9, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "Name";
            // 
            // lstRooms
            // 
            this.lstRooms.BackColor = System.Drawing.SystemColors.Window;
            this.lstRooms.Enabled = false;
            this.lstRooms.ForeColor = System.Drawing.Color.Black;
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.Location = new System.Drawing.Point(110, 151);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(148, 82);
            this.lstRooms.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(15, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Booked Room";
            // 
            // dtBookingFrom
            // 
            this.dtBookingFrom.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dtBookingFrom.CalendarTitleBackColor = System.Drawing.Color.LightSteelBlue;
            this.dtBookingFrom.CalendarTitleForeColor = System.Drawing.Color.Lavender;
            this.dtBookingFrom.Location = new System.Drawing.Point(79, 10);
            this.dtBookingFrom.Name = "dtBookingFrom";
            this.dtBookingFrom.Size = new System.Drawing.Size(115, 20);
            this.dtBookingFrom.TabIndex = 107;
            // 
            // dtBookingTo
            // 
            this.dtBookingTo.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dtBookingTo.CalendarTitleBackColor = System.Drawing.Color.LightSteelBlue;
            this.dtBookingTo.CalendarTitleForeColor = System.Drawing.Color.Lavender;
            this.dtBookingTo.Location = new System.Drawing.Point(215, 10);
            this.dtBookingTo.Name = "dtBookingTo";
            this.dtBookingTo.Size = new System.Drawing.Size(119, 20);
            this.dtBookingTo.TabIndex = 108;
            // 
            // dgvReservation
            // 
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvReservation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.CustomerName,
            this.ContactNo,
            this.StartDate,
            this.EndDate,
            this.Rooms,
            this.Advance});
            this.dgvReservation.ContextMenuStrip = this.contextMenuGrid;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReservation.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvReservation.Location = new System.Drawing.Point(12, 46);
            this.dgvReservation.Name = "dgvReservation";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvReservation.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvReservation.Size = new System.Drawing.Size(747, 274);
            this.dgvReservation.TabIndex = 109;
            this.dgvReservation.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservation_RowEnter);
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.Name = "CustomerName";
            // 
            // ContactNo
            // 
            this.ContactNo.HeaderText = "ContactNo";
            this.ContactNo.Name = "ContactNo";
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Booking From";
            this.StartDate.Name = "StartDate";
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "Booking To";
            this.EndDate.Name = "EndDate";
            // 
            // Rooms
            // 
            this.Rooms.HeaderText = "Rooms";
            this.Rooms.Name = "Rooms";
            // 
            // Advance
            // 
            this.Advance.HeaderText = "Advance";
            this.Advance.Name = "Advance";
            // 
            // contextMenuGrid
            // 
            this.contextMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuItemCheckIn,
            this.cMenuItemCancel,
            this.cMenuItemDelete,
            this.cMenuItemView});
            this.contextMenuGrid.Name = "contextMenuGrid";
            this.contextMenuGrid.Size = new System.Drawing.Size(121, 92);
            // 
            // cMenuItemCheckIn
            // 
            this.cMenuItemCheckIn.Name = "cMenuItemCheckIn";
            this.cMenuItemCheckIn.Size = new System.Drawing.Size(120, 22);
            this.cMenuItemCheckIn.Text = "Check In";
            // 
            // cMenuItemCancel
            // 
            this.cMenuItemCancel.Name = "cMenuItemCancel";
            this.cMenuItemCancel.Size = new System.Drawing.Size(120, 22);
            this.cMenuItemCancel.Text = "Cancel";
            // 
            // cMenuItemDelete
            // 
            this.cMenuItemDelete.Name = "cMenuItemDelete";
            this.cMenuItemDelete.Size = new System.Drawing.Size(120, 22);
            this.cMenuItemDelete.Text = "Delete";
            // 
            // cMenuItemView
            // 
            this.cMenuItemView.Name = "cMenuItemView";
            this.cMenuItemView.Size = new System.Drawing.Size(120, 22);
            this.cMenuItemView.Text = "View";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 110;
            this.label10.Text = "Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFromDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lstRooms);
            this.groupBox2.Controls.Add(this.txtAdvance);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtRooms);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPersons);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDays);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(110, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 246);
            this.groupBox2.TabIndex = 133;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reservation Details";
            // 
            // txtFromDate
            // 
            this.txtFromDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtFromDate.Enabled = false;
            this.txtFromDate.ForeColor = System.Drawing.Color.Black;
            this.txtFromDate.Location = new System.Drawing.Point(110, 20);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(148, 20);
            this.txtFromDate.TabIndex = 107;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(356, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 134;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(437, 11);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 23);
            this.btnSelect.TabIndex = 135;
            this.btnSelect.Text = "Select And Close";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // RoomReservationRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 580);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtBookingTo);
            this.Controls.Add(this.dtBookingFrom);
            this.Controls.Add(this.dgvReservation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomReservationRegister";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room Reservation Register";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).EndInit();
            this.contextMenuGrid.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRooms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPersons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstRooms;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DateTimePicker dtBookingFrom;
        private System.Windows.Forms.DateTimePicker dtBookingTo;
        private System.Windows.Forms.DataGridView dgvReservation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemCheckIn;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemCancel;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem cMenuItemView;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Advance;
        private System.Windows.Forms.Button btnSelect;
        //private Presentation.Library.Button.Search btnSearch;

    }
}