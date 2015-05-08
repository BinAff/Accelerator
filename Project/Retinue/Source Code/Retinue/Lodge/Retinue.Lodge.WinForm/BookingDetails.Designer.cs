namespace Retinue.Lodge.WinForm
{
    partial class BookingDetails
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
            this.dgvBooking = new System.Windows.Forms.DataGridView();
            this.txtDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAdvance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooking
            // 
            this.dgvBooking.AllowUserToAddRows = false;
            this.dgvBooking.AllowUserToDeleteRows = false;
            this.dgvBooking.AllowUserToOrderColumns = true;
            this.dgvBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtDate,
            this.txtStartDate,
            this.txtEndDate,
            this.txtRooms,
            this.txtAdvance});
            this.dgvBooking.Location = new System.Drawing.Point(3, 3);
            this.dgvBooking.Name = "dgvBooking";
            this.dgvBooking.ReadOnly = true;
            this.dgvBooking.Size = new System.Drawing.Size(454, 196);
            this.dgvBooking.TabIndex = 1;
            // 
            // txtDate
            // 
            this.txtDate.Frozen = true;
            this.txtDate.HeaderText = "Date";
            this.txtDate.MinimumWidth = 80;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Width = 80;
            // 
            // txtStartDate
            // 
            this.txtStartDate.HeaderText = "Start Date";
            this.txtStartDate.MinimumWidth = 80;
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Width = 80;
            // 
            // txtEndDate
            // 
            this.txtEndDate.HeaderText = "End Date";
            this.txtEndDate.MinimumWidth = 80;
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Width = 80;
            // 
            // txtRooms
            // 
            this.txtRooms.HeaderText = "Rooms";
            this.txtRooms.MinimumWidth = 80;
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.ReadOnly = true;
            this.txtRooms.Width = 80;
            // 
            // txtAdvance
            // 
            this.txtAdvance.HeaderText = "Advance";
            this.txtAdvance.MinimumWidth = 80;
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.ReadOnly = true;
            this.txtAdvance.Width = 80;
            // 
            // BookingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvBooking);
            this.Name = "BookingDetails";
            this.Size = new System.Drawing.Size(463, 206);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooking;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAdvance;

    }
}
