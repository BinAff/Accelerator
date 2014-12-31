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
            this.txtArrivedFrom = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCheckInRemark = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.pnlReservation = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArrivedFrom
            // 
            this.txtArrivedFrom.Location = new System.Drawing.Point(91, 399);
            this.txtArrivedFrom.Multiline = true;
            this.txtArrivedFrom.Name = "txtArrivedFrom";
            this.txtArrivedFrom.Size = new System.Drawing.Size(447, 50);
            this.txtArrivedFrom.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 402);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 1032;
            this.label15.Text = "Arrived From";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 344);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 1034;
            this.label18.Text = "Purpose";
            // 
            // txtCheckInRemark
            // 
            this.txtCheckInRemark.Location = new System.Drawing.Point(92, 455);
            this.txtCheckInRemark.Multiline = true;
            this.txtCheckInRemark.Name = "txtCheckInRemark";
            this.txtCheckInRemark.Size = new System.Drawing.Size(447, 50);
            this.txtCheckInRemark.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 458);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 1036;
            this.label19.Text = "Remarks";
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(91, 341);
            this.txtPurpose.Multiline = true;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(447, 50);
            this.txtPurpose.TabIndex = 16;
            // 
            // pnlReservation
            // 
            this.pnlReservation.Location = new System.Drawing.Point(8, 34);
            this.pnlReservation.Name = "pnlReservation";
            this.pnlReservation.Size = new System.Drawing.Size(848, 301);
            this.pnlReservation.TabIndex = 1037;
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 512);
            this.Controls.Add(this.pnlReservation);
            this.Controls.Add(this.txtCheckInRemark);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtArrivedFrom);
            this.Controls.Add(this.label15);
            this.Name = "CheckInForm";
            this.ShowInTaskbar = false;
            this.Text = "Check In Form";
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtArrivedFrom, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtPurpose, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtCheckInRemark, 0);
            this.Controls.SetChildIndex(this.pnlReservation, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.Panel pnlReservation;

    }
}