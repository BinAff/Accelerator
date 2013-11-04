﻿namespace AutoTourism.Lodge.WinForm
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
            this.dtCheckIn = new System.Windows.Forms.DateTimePicker();
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
            this.btnPickReservation = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboRoomList);
            this.groupBox2.Controls.Add(this.btnRemoveRoom);
            this.groupBox2.Controls.Add(this.cmbCheckInRoom);
            this.groupBox2.Controls.Add(this.btnAddRoom);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(13, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 145);
            this.groupBox2.TabIndex = 107;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Room";
            // 
            // cboRoomList
            // 
            this.cboRoomList.BackColor = System.Drawing.Color.Lavender;
            this.cboRoomList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboRoomList.FormattingEnabled = true;
            this.cboRoomList.Location = new System.Drawing.Point(10, 19);
            this.cboRoomList.Name = "cboRoomList";
            this.cboRoomList.Size = new System.Drawing.Size(70, 124);
            this.cboRoomList.TabIndex = 90;
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRoom.Location = new System.Drawing.Point(88, 47);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(32, 22);
            this.btnRemoveRoom.TabIndex = 93;
            this.btnRemoveRoom.Text = "◄";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            //this.btnRemoveRoom.Click += new System.EventHandler(this.btnRemoveRoom_Click);
            // 
            // cmbCheckInRoom
            // 
            this.cmbCheckInRoom.BackColor = System.Drawing.Color.Lavender;
            this.cmbCheckInRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbCheckInRoom.FormattingEnabled = true;
            this.cmbCheckInRoom.Location = new System.Drawing.Point(126, 19);
            this.cmbCheckInRoom.Name = "cmbCheckInRoom";
            this.cmbCheckInRoom.Size = new System.Drawing.Size(70, 124);
            this.cmbCheckInRoom.TabIndex = 91;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.Location = new System.Drawing.Point(88, 19);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(32, 22);
            this.btnAddRoom.TabIndex = 92;
            this.btnAddRoom.Text = "►";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            //this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // txtAdvance
            // 
            this.txtAdvance.BackColor = System.Drawing.Color.Lavender;
            this.txtAdvance.Location = new System.Drawing.Point(105, 141);
            this.txtAdvance.MaxLength = 10;
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Size = new System.Drawing.Size(74, 20);
            this.txtAdvance.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "Advance Amount";
            // 
            // txtRooms
            // 
            this.txtRooms.BackColor = System.Drawing.Color.Lavender;
            this.txtRooms.Location = new System.Drawing.Point(105, 115);
            this.txtRooms.MaxLength = 3;
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.Size = new System.Drawing.Size(32, 20);
            this.txtRooms.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "No of Rooms";
            // 
            // txtPersons
            // 
            this.txtPersons.BackColor = System.Drawing.Color.Lavender;
            this.txtPersons.Location = new System.Drawing.Point(105, 89);
            this.txtPersons.MaxLength = 4;
            this.txtPersons.Name = "txtPersons";
            this.txtPersons.Size = new System.Drawing.Size(32, 20);
            this.txtPersons.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 101;
            this.label3.Text = "No of Persons";
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.Color.Lavender;
            this.txtDays.Location = new System.Drawing.Point(105, 63);
            this.txtDays.MaxLength = 4;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(32, 20);
            this.txtDays.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 97;
            this.label2.Text = "No of Days";
            // 
            // dtCheckIn
            // 
            this.dtCheckIn.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dtCheckIn.CalendarTitleBackColor = System.Drawing.Color.LightSteelBlue;
            this.dtCheckIn.CalendarTitleForeColor = System.Drawing.Color.Lavender;
            this.dtCheckIn.Location = new System.Drawing.Point(105, 37);
            this.dtCheckIn.Name = "dtCheckIn";
            this.dtCheckIn.Size = new System.Drawing.Size(115, 20);
            this.dtCheckIn.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 98;
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
            this.groupBox1.Enabled = false;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(226, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 245);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Lavender;
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
            this.txtAdds.BackColor = System.Drawing.Color.Lavender;
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
            this.lstContact.BackColor = System.Drawing.Color.Lavender;
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
            this.txtName.BackColor = System.Drawing.Color.Lavender;
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
            this.btnPickReservation.Location = new System.Drawing.Point(344, 292);
            this.btnPickReservation.Name = "btnPickReservation";
            this.btnPickReservation.Size = new System.Drawing.Size(154, 23);
            this.btnPickReservation.TabIndex = 97;
            this.btnPickReservation.Text = "Pick Reservation";
            this.btnPickReservation.UseVisualStyleBackColor = true;
            //this.btnPickReservation.Click += new System.EventHandler(this.btnPickReservation_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 326);
            this.Controls.Add(this.btnPickReservation);
            this.Controls.Add(this.txtRooms);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtCheckIn);
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
            this.Controls.SetChildIndex(this.txtPersons, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtAdvance, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtDays, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtCheckIn, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtRooms, 0);
            this.Controls.SetChildIndex(this.btnPickReservation, 0);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.DateTimePicker dtCheckIn;
        private System.Windows.Forms.Label label1;
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
    }
}