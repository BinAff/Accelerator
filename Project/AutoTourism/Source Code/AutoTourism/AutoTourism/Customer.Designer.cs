namespace AutoTourism
{
    partial class Customer
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
            this.reservationList1 = new AutoTourism.Lodge.WinForm.ReservationList();
            this.SuspendLayout();
            // 
            // reservationList1
            // 
            this.reservationList1.Location = new System.Drawing.Point(32, 181);
            this.reservationList1.Name = "reservationList1";
            this.reservationList1.Size = new System.Drawing.Size(455, 181);
            this.reservationList1.TabIndex = 0;
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 374);
            this.Controls.Add(this.reservationList1);
            this.Name = "Customer";
            this.Text = "Customer";
            this.ResumeLayout(false);

        }

        #endregion

        private Lodge.WinForm.ReservationList reservationList1;
    }
}