namespace Retinue.Lodge.WinForm
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
            this.ucRoomReservationDataEntry = new Retinue.Lodge.WinForm.RoomReservationDataEntry();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ucRoomReservationDataEntry
            // 
            this.ucRoomReservationDataEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRoomReservationDataEntry.Location = new System.Drawing.Point(0, 27);
            this.ucRoomReservationDataEntry.Name = "ucRoomReservationDataEntry";
            this.ucRoomReservationDataEntry.Size = new System.Drawing.Size(717, 514);
            this.ucRoomReservationDataEntry.TabIndex = 101;
            // 
            // RoomReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 541);
            this.Controls.Add(this.ucRoomReservationDataEntry);
            this.IsVisibleCloseButton = true;
            this.IsVisibleOkButton = true;
            this.Name = "RoomReservationForm";
            this.ShowInTaskbar = false;
            this.Text = "Room Reservation Form";
            this.Controls.SetChildIndex(this.ucRoomReservationDataEntry, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoomReservationDataEntry ucRoomReservationDataEntry;

    }
}