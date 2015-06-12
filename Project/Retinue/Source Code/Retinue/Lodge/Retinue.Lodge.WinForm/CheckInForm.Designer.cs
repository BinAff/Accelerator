namespace Retinue.Lodge.WinForm
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
            this.txtArrivedFrom = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCheckInRemark = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.tpnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.ucRoomReservation = new Retinue.Lodge.WinForm.RoomReservationDataEntry();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tpnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtArrivedFrom
            // 
            this.txtArrivedFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.txtArrivedFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArrivedFrom.Location = new System.Drawing.Point(217, 411);
            this.txtArrivedFrom.Name = "txtArrivedFrom";
            this.txtArrivedFrom.Size = new System.Drawing.Size(396, 20);
            this.txtArrivedFrom.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 408);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 1032;
            this.label15.Text = "Arrived From";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 360);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 1034;
            this.label18.Text = "Purpose";
            // 
            // txtCheckInRemark
            // 
            this.txtCheckInRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckInRemark.Location = new System.Drawing.Point(217, 435);
            this.txtCheckInRemark.Multiline = true;
            this.txtCheckInRemark.Name = "txtCheckInRemark";
            this.txtCheckInRemark.Size = new System.Drawing.Size(396, 42);
            this.txtCheckInRemark.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 432);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 1036;
            this.label19.Text = "Remarks";
            // 
            // txtPurpose
            // 
            this.txtPurpose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(214)))));
            this.txtPurpose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPurpose.Location = new System.Drawing.Point(217, 363);
            this.txtPurpose.Multiline = true;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(396, 42);
            this.txtPurpose.TabIndex = 16;
            // 
            // tpnlContainer
            // 
            this.tpnlContainer.ColumnCount = 3;
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tpnlContainer.Controls.Add(this.label18, 0, 1);
            this.tpnlContainer.Controls.Add(this.txtPurpose, 2, 1);
            this.tpnlContainer.Controls.Add(this.txtCheckInRemark, 2, 3);
            this.tpnlContainer.Controls.Add(this.label15, 0, 2);
            this.tpnlContainer.Controls.Add(this.label19, 0, 3);
            this.tpnlContainer.Controls.Add(this.txtArrivedFrom, 2, 2);
            this.tpnlContainer.Controls.Add(this.ucRoomReservation, 0, 0);
            this.tpnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlContainer.Location = new System.Drawing.Point(0, 27);
            this.tpnlContainer.Name = "tpnlContainer";
            this.tpnlContainer.RowCount = 4;
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tpnlContainer.Size = new System.Drawing.Size(616, 472);
            this.tpnlContainer.TabIndex = 1038;
            // 
            // ucRoomReservation
            // 
            this.tpnlContainer.SetColumnSpan(this.ucRoomReservation, 3);
            this.ucRoomReservation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRoomReservation.Location = new System.Drawing.Point(3, 3);
            this.ucRoomReservation.Name = "ucRoomReservation";
            this.ucRoomReservation.Size = new System.Drawing.Size(610, 354);
            this.ucRoomReservation.TabIndex = 1037;
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 499);
            this.Controls.Add(this.tpnlContainer);
            this.Name = "CheckInForm";
            this.ShowInTaskbar = false;
            this.Text = "Check In Form";
            this.Controls.SetChildIndex(this.tpnlContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tpnlContainer.ResumeLayout(false);
            this.tpnlContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArrivedFrom;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCheckInRemark;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.TableLayoutPanel tpnlContainer;
        private RoomReservationDataEntry ucRoomReservation;

    }
}