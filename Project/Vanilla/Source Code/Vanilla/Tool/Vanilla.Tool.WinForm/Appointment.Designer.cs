namespace Vanilla.Tool.WinForm
{
    partial class Appointment
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cboImportance = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboStartTime = new System.Windows.Forms.ComboBox();
            this.cboEndTime = new System.Windows.Forms.ComboBox();
            this.cboReminderTime = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(77, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(77, 38);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(106, 20);
            this.dtpStart.TabIndex = 2;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "End";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(78, 64);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 20);
            this.dtpEnd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Type";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(353, 12);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(200, 21);
            this.cboType.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(353, 64);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(201, 20);
            this.txtLocation.TabIndex = 9;
            // 
            // cboImportance
            // 
            this.cboImportance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImportance.FormattingEnabled = true;
            this.cboImportance.Location = new System.Drawing.Point(353, 37);
            this.cboImportance.Name = "cboImportance";
            this.cboImportance.Size = new System.Drawing.Size(200, 21);
            this.cboImportance.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Importance";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(77, 90);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(477, 83);
            this.txtDescription.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Reminder";
            // 
            // dtpReminder
            // 
            this.dtpReminder.Location = new System.Drawing.Point(78, 179);
            this.dtpReminder.Name = "dtpReminder";
            this.dtpReminder.Size = new System.Drawing.Size(105, 20);
            this.dtpReminder.TabIndex = 14;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(479, 199);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cboStartTime
            // 
            this.cboStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartTime.FormattingEnabled = true;
            this.cboStartTime.Items.AddRange(new object[] {
            "12:00 AM",
            "12:15 AM",
            "12:30 AM",
            "12:45 AM",
            "1:00 AM",
            "1:15 AM",
            "1:30 AM",
            "1:45 AM",
            "2:00 AM",
            "2:15 AM",
            "2:30 AM",
            "2:45 AM",
            "3:00 AM",
            "3:15 AM",
            "3:30 AM",
            "3:45 AM",
            "4:00 AM",
            "4:15 AM",
            "4:30 AM",
            "4:45 AM",
            "5:00 AM",
            "5:15 AM",
            "5:30 AM",
            "5:45 AM",
            "6:00 AM",
            "6:15 AM",
            "6:30 AM",
            "6:45 AM",
            "7:00 AM",
            "7:15 AM",
            "7:30 AM",
            "7:45 AM",
            "8:00 AM",
            "8:15 AM",
            "8:30 AM",
            "8:45 AM",
            "9:00 AM",
            "9:15 AM",
            "9:30 AM",
            "9:45 AM",
            "10:00 AM",
            "10:15 AM",
            "10:30 AM",
            "10:45 AM",
            "11:00 AM",
            "11:15 AM",
            "11:30 AM",
            "11:45 AM",
            "12:00 PM",
            "12:15 PM",
            "12:30 PM",
            "12:45 PM",
            "1:00 PM",
            "1:15 PM",
            "1:30 PM",
            "1:45 PM",
            "2:00 PM",
            "2:15 PM",
            "2:30 PM",
            "2:45 PM",
            "3:00 PM",
            "3:15 PM",
            "3:30 PM",
            "3:45 PM",
            "4:00 PM",
            "4:15 PM",
            "4:30 PM",
            "4:45 PM",
            "5:00 PM",
            "5:15 PM",
            "5:30 PM",
            "5:45 PM",
            "6:00 PM",
            "6:15 PM",
            "6:30 PM",
            "6:45 PM",
            "7:00 PM",
            "7:15 PM",
            "7:30 PM",
            "7:45 PM",
            "8:00 PM",
            "8:15 PM",
            "8:30 PM",
            "8:45 PM",
            "9:00 PM",
            "9:15 PM",
            "9:30 PM",
            "9:45 PM",
            "10:00 PM",
            "10:15 PM",
            "10:30 PM",
            "10:45 PM",
            "11:00 PM",
            "11:15 PM",
            "11:30 PM",
            "11:45 PM"});
            this.cboStartTime.Location = new System.Drawing.Point(189, 37);
            this.cboStartTime.Name = "cboStartTime";
            this.cboStartTime.Size = new System.Drawing.Size(92, 21);
            this.cboStartTime.TabIndex = 17;
            // 
            // cboEndTime
            // 
            this.cboEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndTime.FormattingEnabled = true;
            this.cboEndTime.Items.AddRange(new object[] {
            "12:00 AM",
            "12:15 AM",
            "12:30 AM",
            "12:45 AM",
            "1:00 AM",
            "1:15 AM",
            "1:30 AM",
            "1:45 AM",
            "2:00 AM",
            "2:15 AM",
            "2:30 AM",
            "2:45 AM",
            "3:00 AM",
            "3:15 AM",
            "3:30 AM",
            "3:45 AM",
            "4:00 AM",
            "4:15 AM",
            "4:30 AM",
            "4:45 AM",
            "5:00 AM",
            "5:15 AM",
            "5:30 AM",
            "5:45 AM",
            "6:00 AM",
            "6:15 AM",
            "6:30 AM",
            "6:45 AM",
            "7:00 AM",
            "7:15 AM",
            "7:30 AM",
            "7:45 AM",
            "8:00 AM",
            "8:15 AM",
            "8:30 AM",
            "8:45 AM",
            "9:00 AM",
            "9:15 AM",
            "9:30 AM",
            "9:45 AM",
            "10:00 AM",
            "10:15 AM",
            "10:30 AM",
            "10:45 AM",
            "11:00 AM",
            "11:15 AM",
            "11:30 AM",
            "11:45 AM",
            "12:00 PM",
            "12:15 PM",
            "12:30 PM",
            "12:45 PM",
            "1:00 PM",
            "1:15 PM",
            "1:30 PM",
            "1:45 PM",
            "2:00 PM",
            "2:15 PM",
            "2:30 PM",
            "2:45 PM",
            "3:00 PM",
            "3:15 PM",
            "3:30 PM",
            "3:45 PM",
            "4:00 PM",
            "4:15 PM",
            "4:30 PM",
            "4:45 PM",
            "5:00 PM",
            "5:15 PM",
            "5:30 PM",
            "5:45 PM",
            "6:00 PM",
            "6:15 PM",
            "6:30 PM",
            "6:45 PM",
            "7:00 PM",
            "7:15 PM",
            "7:30 PM",
            "7:45 PM",
            "8:00 PM",
            "8:15 PM",
            "8:30 PM",
            "8:45 PM",
            "9:00 PM",
            "9:15 PM",
            "9:30 PM",
            "9:45 PM",
            "10:00 PM",
            "10:15 PM",
            "10:30 PM",
            "10:45 PM",
            "11:00 PM",
            "11:15 PM",
            "11:30 PM",
            "11:45 PM"});
            this.cboEndTime.Location = new System.Drawing.Point(189, 63);
            this.cboEndTime.Name = "cboEndTime";
            this.cboEndTime.Size = new System.Drawing.Size(92, 21);
            this.cboEndTime.TabIndex = 18;
            // 
            // cboReminderTime
            // 
            this.cboReminderTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReminderTime.FormattingEnabled = true;
            this.cboReminderTime.Items.AddRange(new object[] {
            "12:00 AM",
            "12:15 AM",
            "12:30 AM",
            "12:45 AM",
            "1:00 AM",
            "1:15 AM",
            "1:30 AM",
            "1:45 AM",
            "2:00 AM",
            "2:15 AM",
            "2:30 AM",
            "2:45 AM",
            "3:00 AM",
            "3:15 AM",
            "3:30 AM",
            "3:45 AM",
            "4:00 AM",
            "4:15 AM",
            "4:30 AM",
            "4:45 AM",
            "5:00 AM",
            "5:15 AM",
            "5:30 AM",
            "5:45 AM",
            "6:00 AM",
            "6:15 AM",
            "6:30 AM",
            "6:45 AM",
            "7:00 AM",
            "7:15 AM",
            "7:30 AM",
            "7:45 AM",
            "8:00 AM",
            "8:15 AM",
            "8:30 AM",
            "8:45 AM",
            "9:00 AM",
            "9:15 AM",
            "9:30 AM",
            "9:45 AM",
            "10:00 AM",
            "10:15 AM",
            "10:30 AM",
            "10:45 AM",
            "11:00 AM",
            "11:15 AM",
            "11:30 AM",
            "11:45 AM",
            "12:00 PM",
            "12:15 PM",
            "12:30 PM",
            "12:45 PM",
            "1:00 PM",
            "1:15 PM",
            "1:30 PM",
            "1:45 PM",
            "2:00 PM",
            "2:15 PM",
            "2:30 PM",
            "2:45 PM",
            "3:00 PM",
            "3:15 PM",
            "3:30 PM",
            "3:45 PM",
            "4:00 PM",
            "4:15 PM",
            "4:30 PM",
            "4:45 PM",
            "5:00 PM",
            "5:15 PM",
            "5:30 PM",
            "5:45 PM",
            "6:00 PM",
            "6:15 PM",
            "6:30 PM",
            "6:45 PM",
            "7:00 PM",
            "7:15 PM",
            "7:30 PM",
            "7:45 PM",
            "8:00 PM",
            "8:15 PM",
            "8:30 PM",
            "8:45 PM",
            "9:00 PM",
            "9:15 PM",
            "9:30 PM",
            "9:45 PM",
            "10:00 PM",
            "10:15 PM",
            "10:30 PM",
            "10:45 PM",
            "11:00 PM",
            "11:15 PM",
            "11:30 PM",
            "11:45 PM"});
            this.cboReminderTime.Location = new System.Drawing.Point(189, 177);
            this.cboReminderTime.Name = "cboReminderTime";
            this.cboReminderTime.Size = new System.Drawing.Size(92, 21);
            this.cboReminderTime.TabIndex = 19;
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 233);
            this.Controls.Add(this.cboReminderTime);
            this.Controls.Add(this.cboEndTime);
            this.Controls.Add(this.cboStartTime);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpReminder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cboImportance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Appointment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calender";
            this.Load += new System.EventHandler(this.Appointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.ComboBox cboImportance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpReminder;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cboEndTime;
        private System.Windows.Forms.ComboBox cboStartTime;
        private System.Windows.Forms.ComboBox cboReminderTime;
    }
}