namespace AutoTourism.Lodge.WinForm
{
    partial class RoomReservationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPickCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPersons = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRooms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.cboRoomList = new System.Windows.Forms.ComboBox();
            this.cboSelectedRoom = new System.Windows.Forms.ComboBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtFromTime = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancelOpen = new System.Windows.Forms.Button();
            this.lblReservationStatus = new System.Windows.Forms.Label();
            this.txtReservationStatus = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtArtifactPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cboAC = new System.Windows.Forms.ComboBox();
            this.lblAC = new System.Windows.Forms.Label();
            this.lblTotalRoomCount = new System.Windows.Forms.Label();
            this.lblTotalBookedRoomCount = new System.Windows.Forms.Label();
            this.lblAvailableRooms = new System.Windows.Forms.Label();
            this.lblTotalRooms = new System.Windows.Forms.Label();
            this.lblTotalBooking = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(10, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.Enabled = false;
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(103, 168);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(154, 20);
            this.txtEmail.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 171);
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
            this.txtAdds.Location = new System.Drawing.Point(103, 94);
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.Size = new System.Drawing.Size(154, 64);
            this.txtAdds.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 97);
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
            this.lstContact.Location = new System.Drawing.Point(103, 45);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(154, 43);
            this.lstContact.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 42);
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
            this.txtName.Location = new System.Drawing.Point(103, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 20);
            this.txtName.TabIndex = 23;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "Name";
            // 
            // btnPickCustomer
            // 
            this.btnPickCustomer.Location = new System.Drawing.Point(10, 122);
            this.btnPickCustomer.Name = "btnPickCustomer";
            this.btnPickCustomer.Size = new System.Drawing.Size(97, 23);
            this.btnPickCustomer.TabIndex = 96;
            this.btnPickCustomer.Text = "Pick Customer";
            this.btnPickCustomer.UseVisualStyleBackColor = true;
            this.btnPickCustomer.Click += new System.EventHandler(this.btnPickCustomer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "From";
            // 
            // dtFrom
            // 
            this.dtFrom.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.dtFrom.CalendarTitleBackColor = System.Drawing.Color.LightSteelBlue;
            this.dtFrom.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.dtFrom.Location = new System.Drawing.Point(388, 122);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(108, 20);
            this.dtFrom.TabIndex = 1;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.txtDays.Location = new System.Drawing.Point(388, 149);
            this.txtDays.MaxLength = 3;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(32, 20);
            this.txtDays.TabIndex = 3;
            this.txtDays.TextChanged += new System.EventHandler(this.txtDays_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "No of Days";
            // 
            // txtPersons
            // 
            this.txtPersons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.txtPersons.Location = new System.Drawing.Point(556, 149);
            this.txtPersons.MaxLength = 3;
            this.txtPersons.Name = "txtPersons";
            this.txtPersons.Size = new System.Drawing.Size(32, 20);
            this.txtPersons.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "No of Persons";
            // 
            // txtRooms
            // 
            this.txtRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.txtRooms.Location = new System.Drawing.Point(388, 178);
            this.txtRooms.MaxLength = 3;
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.Size = new System.Drawing.Size(32, 20);
            this.txtRooms.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "No of Rooms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Advance Amount";
            // 
            // txtAdvance
            // 
            this.txtAdvance.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdvance.Location = new System.Drawing.Point(535, 178);
            this.txtAdvance.MaxLength = 10;
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Size = new System.Drawing.Size(53, 20);
            this.txtAdvance.TabIndex = 6;
            this.txtAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboRoomList
            // 
            this.cboRoomList.BackColor = System.Drawing.SystemColors.Window;
            this.cboRoomList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboRoomList.FormattingEnabled = true;
            this.cboRoomList.Location = new System.Drawing.Point(6, 26);
            this.cboRoomList.Name = "cboRoomList";
            this.cboRoomList.Size = new System.Drawing.Size(108, 124);
            this.cboRoomList.TabIndex = 90;
            // 
            // cboSelectedRoom
            // 
            this.cboSelectedRoom.BackColor = System.Drawing.SystemColors.Window;
            this.cboSelectedRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboSelectedRoom.FormattingEnabled = true;
            this.cboSelectedRoom.Location = new System.Drawing.Point(169, 26);
            this.cboSelectedRoom.Name = "cboSelectedRoom";
            this.cboSelectedRoom.Size = new System.Drawing.Size(107, 124);
            this.cboSelectedRoom.TabIndex = 91;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.Location = new System.Drawing.Point(125, 26);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(32, 22);
            this.btnAddRoom.TabIndex = 7;
            this.btnAddRoom.Text = "►";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRoom.Location = new System.Drawing.Point(125, 54);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(32, 22);
            this.btnRemoveRoom.TabIndex = 8;
            this.btnRemoveRoom.Text = "◄";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            this.btnRemoveRoom.Click += new System.EventHandler(this.btnRemoveRoom_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboRoomList);
            this.groupBox2.Controls.Add(this.btnRemoveRoom);
            this.groupBox2.Controls.Add(this.cboSelectedRoom);
            this.groupBox2.Controls.Add(this.btnAddRoom);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(296, 303);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 150);
            this.groupBox2.TabIndex = 94;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preffered Room";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(292, 256);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 96;
            this.lblType.Text = "Type";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(294, 232);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 95;
            this.lblCategory.Text = "Category";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(388, 253);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(188, 21);
            this.cboType.TabIndex = 93;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(388, 229);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(188, 21);
            this.cboCategory.TabIndex = 92;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dtFromTime
            // 
            this.dtFromTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.dtFromTime.CalendarTitleBackColor = System.Drawing.Color.LightSteelBlue;
            this.dtFromTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.dtFromTime.Location = new System.Drawing.Point(502, 121);
            this.dtFromTime.Name = "dtFromTime";
            this.dtFromTime.Size = new System.Drawing.Size(86, 20);
            this.dtFromTime.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(604, 151);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 95;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(604, 122);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 96;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancelOpen
            // 
            this.btnCancelOpen.Location = new System.Drawing.Point(604, 178);
            this.btnCancelOpen.Name = "btnCancelOpen";
            this.btnCancelOpen.Size = new System.Drawing.Size(75, 23);
            this.btnCancelOpen.TabIndex = 97;
            this.btnCancelOpen.Text = "Cancel";
            this.btnCancelOpen.UseVisualStyleBackColor = true;
            this.btnCancelOpen.Click += new System.EventHandler(this.btnCancelOpen_Click);
            // 
            // lblReservationStatus
            // 
            this.lblReservationStatus.AutoSize = true;
            this.lblReservationStatus.Location = new System.Drawing.Point(293, 209);
            this.lblReservationStatus.Name = "lblReservationStatus";
            this.lblReservationStatus.Size = new System.Drawing.Size(97, 13);
            this.lblReservationStatus.TabIndex = 98;
            this.lblReservationStatus.Text = "Reservation Status";
            // 
            // txtReservationStatus
            // 
            this.txtReservationStatus.AutoSize = true;
            this.txtReservationStatus.Location = new System.Drawing.Point(553, 209);
            this.txtReservationStatus.Name = "txtReservationStatus";
            this.txtReservationStatus.Size = new System.Drawing.Size(35, 13);
            this.txtReservationStatus.TabIndex = 99;
            this.txtReservationStatus.Text = "label9";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(113, 122);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(97, 23);
            this.btnAddCustomer.TabIndex = 100;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(12, 462);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 101;
            this.lblFilePath.Text = "File Path:";
            // 
            // txtArtifactPath
            // 
            this.txtArtifactPath.Location = new System.Drawing.Point(69, 459);
            this.txtArtifactPath.Name = "txtArtifactPath";
            this.txtArtifactPath.Size = new System.Drawing.Size(513, 20);
            this.txtArtifactPath.TabIndex = 102;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(588, 459);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 103;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // cboAC
            // 
            this.cboAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAC.FormattingEnabled = true;
            this.cboAC.Items.AddRange(new object[] {
            "All"});
            this.cboAC.Location = new System.Drawing.Point(388, 276);
            this.cboAC.Name = "cboAC";
            this.cboAC.Size = new System.Drawing.Size(108, 21);
            this.cboAC.TabIndex = 104;
            this.cboAC.SelectedIndexChanged += new System.EventHandler(this.cboAC_SelectedIndexChanged);
            // 
            // lblAC
            // 
            this.lblAC.AutoSize = true;
            this.lblAC.Location = new System.Drawing.Point(294, 281);
            this.lblAC.Name = "lblAC";
            this.lblAC.Size = new System.Drawing.Size(76, 13);
            this.lblAC.TabIndex = 105;
            this.lblAC.Text = "AC Preference";
            // 
            // lblTotalRoomCount
            // 
            this.lblTotalRoomCount.AutoSize = true;
            this.lblTotalRoomCount.Location = new System.Drawing.Point(17, 50);
            this.lblTotalRoomCount.Name = "lblTotalRoomCount";
            this.lblTotalRoomCount.Size = new System.Drawing.Size(339, 13);
            this.lblTotalRoomCount.TabIndex = 106;
            this.lblTotalRoomCount.Text = "Total no of rooms for the selected category, type and AC preference = ";
            // 
            // lblTotalBookedRoomCount
            // 
            this.lblTotalBookedRoomCount.AutoSize = true;
            this.lblTotalBookedRoomCount.Location = new System.Drawing.Point(17, 72);
            this.lblTotalBookedRoomCount.Name = "lblTotalBookedRoomCount";
            this.lblTotalBookedRoomCount.Size = new System.Drawing.Size(101, 13);
            this.lblTotalBookedRoomCount.TabIndex = 107;
            this.lblTotalBookedRoomCount.Text = "Total rooms booked";
            // 
            // lblAvailableRooms
            // 
            this.lblAvailableRooms.AutoSize = true;
            this.lblAvailableRooms.Location = new System.Drawing.Point(18, 95);
            this.lblAvailableRooms.Name = "lblAvailableRooms";
            this.lblAvailableRooms.Size = new System.Drawing.Size(81, 13);
            this.lblAvailableRooms.TabIndex = 108;
            this.lblAvailableRooms.Text = "Available rooms";            
            // 
            // lblTotalRooms
            // 
            this.lblTotalRooms.AutoSize = true;
            this.lblTotalRooms.Location = new System.Drawing.Point(18, 22);
            this.lblTotalRooms.Name = "lblTotalRooms";
            this.lblTotalRooms.Size = new System.Drawing.Size(62, 13);
            this.lblTotalRooms.TabIndex = 109;
            this.lblTotalRooms.Text = "Total Room";
            // 
            // lblTotalBooking
            // 
            this.lblTotalBooking.AutoSize = true;
            this.lblTotalBooking.Location = new System.Drawing.Point(327, 22);
            this.lblTotalBooking.Name = "lblTotalBooking";
            this.lblTotalBooking.Size = new System.Drawing.Size(73, 13);
            this.lblTotalBooking.TabIndex = 110;
            this.lblTotalBooking.Text = "Total Booking";
            // 
            // RoomReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 484);
            this.Controls.Add(this.lblTotalBooking);
            this.Controls.Add(this.lblTotalRooms);
            this.Controls.Add(this.lblAvailableRooms);
            this.Controls.Add(this.lblTotalBookedRoomCount);
            this.Controls.Add(this.lblTotalRoomCount);
            this.Controls.Add(this.lblAC);
            this.Controls.Add(this.cboAC);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtArtifactPath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnPickCustomer);
            this.Controls.Add(this.txtReservationStatus);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblReservationStatus);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.btnCancelOpen);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFromTime);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtAdvance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRooms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPersons);
            this.Name = "RoomReservationForm";
            this.Text = "Room Registration Form";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.RoomBookingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPersons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRooms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.ComboBox cboRoomList;
        private System.Windows.Forms.ComboBox cboSelectedRoom;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnRemoveRoom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPickCustomer;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker dtFromTime;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancelOpen;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label txtReservationStatus;
        private System.Windows.Forms.Label lblReservationStatus;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.TextBox txtArtifactPath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cboAC;
        private System.Windows.Forms.Label lblAC;
        private System.Windows.Forms.Label lblAvailableRooms;
        private System.Windows.Forms.Label lblTotalBookedRoomCount;
        private System.Windows.Forms.Label lblTotalRoomCount;
        private System.Windows.Forms.Label lblTotalBooking;
        private System.Windows.Forms.Label lblTotalRooms;
    }
}