namespace AutoTourism.Lodge.WinForm
{
    partial class CheckInForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboRoomList = new System.Windows.Forms.ComboBox();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.cmbCheckInRoom = new System.Windows.Forms.ComboBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRooms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPersons = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPickReservation = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAddReservation = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtArtifactPath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblAC = new System.Windows.Forms.Label();
            this.cboAC = new System.Windows.Forms.ComboBox();
            this.lblBookingFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtFromTime = new System.Windows.Forms.DateTimePicker();
            this.lblTotalRoom = new System.Windows.Forms.Label();
            this.txtTotalRoom = new System.Windows.Forms.TextBox();
            this.lblBookedRoom = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTotalBooked = new System.Windows.Forms.TextBox();
            this.lblAvailableRoom = new System.Windows.Forms.Label();
            this.txtAvailableRooms = new System.Windows.Forms.TextBox();
            this.lblTotalRoomWithFilter = new System.Windows.Forms.Label();
            this.txtTotalRoomWithFilter = new System.Windows.Forms.TextBox();
            this.lblBookedRoomsWithFilter = new System.Windows.Forms.Label();
            this.txtTotalBookedRoomsWithFilter = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboAC);
            this.groupBox2.Controls.Add(this.lblAC);
            this.groupBox2.Controls.Add(this.cboType);
            this.groupBox2.Controls.Add(this.lblType);
            this.groupBox2.Controls.Add(this.lblCategory);
            this.groupBox2.Controls.Add(this.cboCategory);
            this.groupBox2.Controls.Add(this.cboRoomList);
            this.groupBox2.Controls.Add(this.btnRemoveRoom);
            this.groupBox2.Controls.Add(this.cmbCheckInRoom);
            this.groupBox2.Controls.Add(this.btnAddRoom);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(9, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 217);
            this.groupBox2.TabIndex = 107;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Room";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(101, 47);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(182, 21);
            this.cboType.TabIndex = 97;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(8, 47);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 96;
            this.lblType.Text = "Type";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(8, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 95;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(101, 20);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(182, 21);
            this.cboCategory.TabIndex = 94;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // cboRoomList
            // 
            this.cboRoomList.BackColor = System.Drawing.SystemColors.Window;
            this.cboRoomList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboRoomList.FormattingEnabled = true;
            this.cboRoomList.Location = new System.Drawing.Point(5, 95);
            this.cboRoomList.Name = "cboRoomList";
            this.cboRoomList.Size = new System.Drawing.Size(70, 124);
            this.cboRoomList.TabIndex = 90;
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRoom.Location = new System.Drawing.Point(83, 123);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(32, 22);
            this.btnRemoveRoom.TabIndex = 93;
            this.btnRemoveRoom.Text = "◄";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            this.btnRemoveRoom.Click += new System.EventHandler(this.btnRemoveRoom_Click);
            // 
            // cmbCheckInRoom
            // 
            this.cmbCheckInRoom.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCheckInRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbCheckInRoom.FormattingEnabled = true;
            this.cmbCheckInRoom.Location = new System.Drawing.Point(121, 95);
            this.cmbCheckInRoom.Name = "cmbCheckInRoom";
            this.cmbCheckInRoom.Size = new System.Drawing.Size(70, 124);
            this.cmbCheckInRoom.TabIndex = 91;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.Location = new System.Drawing.Point(83, 95);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(32, 22);
            this.btnAddRoom.TabIndex = 92;
            this.btnAddRoom.Text = "►";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // txtAdvance
            // 
            this.txtAdvance.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdvance.Location = new System.Drawing.Point(260, 156);
            this.txtAdvance.MaxLength = 10;
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Size = new System.Drawing.Size(74, 20);
            this.txtAdvance.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "Advance Amount";
            // 
            // txtRooms
            // 
            this.txtRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtRooms.Location = new System.Drawing.Point(101, 155);
            this.txtRooms.MaxLength = 3;
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.Size = new System.Drawing.Size(32, 20);
            this.txtRooms.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "No of Rooms";
            // 
            // txtPersons
            // 
            this.txtPersons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtPersons.Location = new System.Drawing.Point(260, 131);
            this.txtPersons.MaxLength = 4;
            this.txtPersons.Name = "txtPersons";
            this.txtPersons.Size = new System.Drawing.Size(32, 20);
            this.txtPersons.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 101;
            this.label3.Text = "No of Persons";
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtDays.Location = new System.Drawing.Point(101, 131);
            this.txtDays.MaxLength = 4;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(32, 20);
            this.txtDays.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 97;
            this.label2.Text = "No of Days";
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
            this.groupBox1.Enabled = false;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(359, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 245);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(104, 216);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(154, 20);
            this.txtEmail.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 84;
            this.label8.Text = "EMail";
            // 
            // txtAdds
            // 
            this.txtAdds.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdds.ForeColor = System.Drawing.Color.Black;
            this.txtAdds.Location = new System.Drawing.Point(104, 94);
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.Size = new System.Drawing.Size(154, 116);
            this.txtAdds.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 82;
            this.label7.Text = "Address";
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.SystemColors.Window;
            this.lstContact.ForeColor = System.Drawing.Color.Black;
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(104, 45);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(154, 43);
            this.lstContact.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Contact Numbers";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(104, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 20);
            this.txtName.TabIndex = 23;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "Name";
            // 
            // btnPickReservation
            // 
            this.btnPickReservation.Location = new System.Drawing.Point(359, 356);
            this.btnPickReservation.Name = "btnPickReservation";
            this.btnPickReservation.Size = new System.Drawing.Size(154, 23);
            this.btnPickReservation.TabIndex = 97;
            this.btnPickReservation.Text = "Pick Reservation";
            this.btnPickReservation.UseVisualStyleBackColor = true;
            this.btnPickReservation.Click += new System.EventHandler(this.btnPickReservation_Click_1);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(647, 109);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 108;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(647, 145);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 109;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAddReservation
            // 
            this.btnAddReservation.Location = new System.Drawing.Point(519, 356);
            this.btnAddReservation.Name = "btnAddReservation";
            this.btnAddReservation.Size = new System.Drawing.Size(154, 23);
            this.btnAddReservation.TabIndex = 110;
            this.btnAddReservation.Text = "Add Reservation";
            this.btnAddReservation.UseVisualStyleBackColor = true;
            this.btnAddReservation.Click += new System.EventHandler(this.btnAddReservation_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(587, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 113;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtArtifactPath
            // 
            this.txtArtifactPath.Location = new System.Drawing.Point(68, 407);
            this.txtArtifactPath.Name = "txtArtifactPath";
            this.txtArtifactPath.Size = new System.Drawing.Size(513, 20);
            this.txtArtifactPath.TabIndex = 112;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(11, 410);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 111;
            this.lblFilePath.Text = "File Path:";
            // 
            // lblAC
            // 
            this.lblAC.AutoSize = true;
            this.lblAC.Location = new System.Drawing.Point(8, 75);
            this.lblAC.Name = "lblAC";
            this.lblAC.Size = new System.Drawing.Size(76, 13);
            this.lblAC.TabIndex = 98;
            this.lblAC.Text = "AC Preference";
            // 
            // cboAC
            // 
            this.cboAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAC.FormattingEnabled = true;
            this.cboAC.Location = new System.Drawing.Point(101, 72);
            this.cboAC.Name = "cboAC";
            this.cboAC.Size = new System.Drawing.Size(121, 21);
            this.cboAC.TabIndex = 99;
            // 
            // lblBookingFrom
            // 
            this.lblBookingFrom.AutoSize = true;
            this.lblBookingFrom.Location = new System.Drawing.Point(8, 105);
            this.lblBookingFrom.Name = "lblBookingFrom";
            this.lblBookingFrom.Size = new System.Drawing.Size(72, 13);
            this.lblBookingFrom.TabIndex = 114;
            this.lblBookingFrom.Text = "Booking From";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(98, 105);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(102, 20);
            this.dtFrom.TabIndex = 115;
            // 
            // dtFromTime
            // 
            this.dtFromTime.Location = new System.Drawing.Point(206, 105);
            this.dtFromTime.Name = "dtFromTime";
            this.dtFromTime.Size = new System.Drawing.Size(101, 20);
            this.dtFromTime.TabIndex = 116;
            // 
            // lblTotalRoom
            // 
            this.lblTotalRoom.AutoSize = true;
            this.lblTotalRoom.Location = new System.Drawing.Point(12, 16);
            this.lblTotalRoom.Name = "lblTotalRoom";
            this.lblTotalRoom.Size = new System.Drawing.Size(67, 13);
            this.lblTotalRoom.TabIndex = 117;
            this.lblTotalRoom.Text = "Total Rooms";
            // 
            // txtTotalRoom
            // 
            this.txtTotalRoom.Location = new System.Drawing.Point(130, 9);
            this.txtTotalRoom.Name = "txtTotalRoom";
            this.txtTotalRoom.Size = new System.Drawing.Size(49, 20);
            this.txtTotalRoom.TabIndex = 118;
            // 
            // lblBookedRoom
            // 
            this.lblBookedRoom.AutoSize = true;
            this.lblBookedRoom.Location = new System.Drawing.Point(12, 45);
            this.lblBookedRoom.Name = "lblBookedRoom";
            this.lblBookedRoom.Size = new System.Drawing.Size(107, 13);
            this.lblBookedRoom.TabIndex = 119;
            this.lblBookedRoom.Text = "Total Booked Rooms";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 173);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 120;
            // 
            // txtTotalBooked
            // 
            this.txtTotalBooked.Location = new System.Drawing.Point(130, 38);
            this.txtTotalBooked.Name = "txtTotalBooked";
            this.txtTotalBooked.Size = new System.Drawing.Size(49, 20);
            this.txtTotalBooked.TabIndex = 121;
            // 
            // lblAvailableRoom
            // 
            this.lblAvailableRoom.AutoSize = true;
            this.lblAvailableRoom.Location = new System.Drawing.Point(12, 71);
            this.lblAvailableRoom.Name = "lblAvailableRoom";
            this.lblAvailableRoom.Size = new System.Drawing.Size(86, 13);
            this.lblAvailableRoom.TabIndex = 122;
            this.lblAvailableRoom.Text = "Available Rooms";
            // 
            // txtAvailableRooms
            // 
            this.txtAvailableRooms.Location = new System.Drawing.Point(130, 68);
            this.txtAvailableRooms.Name = "txtAvailableRooms";
            this.txtAvailableRooms.Size = new System.Drawing.Size(49, 20);
            this.txtAvailableRooms.TabIndex = 100;
            // 
            // lblTotalRoomWithFilter
            // 
            this.lblTotalRoomWithFilter.AutoSize = true;
            this.lblTotalRoomWithFilter.Location = new System.Drawing.Point(368, 16);
            this.lblTotalRoomWithFilter.Name = "lblTotalRoomWithFilter";
            this.lblTotalRoomWithFilter.Size = new System.Drawing.Size(117, 13);
            this.lblTotalRoomWithFilter.TabIndex = 123;
            this.lblTotalRoomWithFilter.Text = "Total Rooms (with filter)";
            // 
            // txtTotalRoomWithFilter
            // 
            this.txtTotalRoomWithFilter.Location = new System.Drawing.Point(544, 9);
            this.txtTotalRoomWithFilter.Name = "txtTotalRoomWithFilter";
            this.txtTotalRoomWithFilter.Size = new System.Drawing.Size(73, 20);
            this.txtTotalRoomWithFilter.TabIndex = 124;
            // 
            // lblBookedRoomsWithFilter
            // 
            this.lblBookedRoomsWithFilter.AutoSize = true;
            this.lblBookedRoomsWithFilter.Location = new System.Drawing.Point(368, 45);
            this.lblBookedRoomsWithFilter.Name = "lblBookedRoomsWithFilter";
            this.lblBookedRoomsWithFilter.Size = new System.Drawing.Size(157, 13);
            this.lblBookedRoomsWithFilter.TabIndex = 125;
            this.lblBookedRoomsWithFilter.Text = "Total Booked Rooms (with filter)";
            // 
            // txtTotalBookedRoomsWithFilter
            // 
            this.txtTotalBookedRoomsWithFilter.Location = new System.Drawing.Point(544, 42);
            this.txtTotalBookedRoomsWithFilter.Name = "txtTotalBookedRoomsWithFilter";
            this.txtTotalBookedRoomsWithFilter.Size = new System.Drawing.Size(73, 20);
            this.txtTotalBookedRoomsWithFilter.TabIndex = 126;
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 439);
            this.Controls.Add(this.txtTotalBookedRoomsWithFilter);
            this.Controls.Add(this.lblBookedRoomsWithFilter);
            this.Controls.Add(this.txtTotalRoomWithFilter);
            this.Controls.Add(this.lblTotalRoomWithFilter);
            this.Controls.Add(this.txtAvailableRooms);
            this.Controls.Add(this.lblAvailableRoom);
            this.Controls.Add(this.txtTotalBooked);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblBookedRoom);
            this.Controls.Add(this.txtTotalRoom);
            this.Controls.Add(this.lblTotalRoom);
            this.Controls.Add(this.dtFromTime);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.lblBookingFrom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtArtifactPath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnAddReservation);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPickReservation);
            this.Controls.Add(this.txtRooms);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtAdvance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPersons);
            this.Name = "CheckInForm";
            this.Text = "Check In Form";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboRoomList;
        private System.Windows.Forms.Button btnRemoveRoom;
        private System.Windows.Forms.ComboBox cmbCheckInRoom;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRooms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPersons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnPickReservation;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnAddReservation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtArtifactPath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblAC;
        private System.Windows.Forms.ComboBox cboAC;
        private System.Windows.Forms.Label lblBookingFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtFromTime;
        private System.Windows.Forms.TextBox txtAvailableRooms;
        private System.Windows.Forms.Label lblAvailableRoom;
        private System.Windows.Forms.TextBox txtTotalBooked;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblBookedRoom;
        private System.Windows.Forms.TextBox txtTotalRoom;
        private System.Windows.Forms.Label lblTotalRoom;
        private System.Windows.Forms.TextBox txtTotalBookedRoomsWithFilter;
        private System.Windows.Forms.Label lblBookedRoomsWithFilter;
        private System.Windows.Forms.TextBox txtTotalRoomWithFilter;
        private System.Windows.Forms.Label lblTotalRoomWithFilter;
    }
}