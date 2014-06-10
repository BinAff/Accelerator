namespace AutoTourism
{
    partial class CustomerFile
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
            this.button1 = new System.Windows.Forms.Button();
            this.commercialInstruments1 = new Vanilla.Invoice.WinForm.CommercialInstruments();
            this.personalInformation1 = new AutoTourism.Customer.WinForm.PersonalInformation();
            this.stay1 = new AutoTourism.Lodge.WinForm.Stay();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // commercialInstruments1
            // 
            this.commercialInstruments1.Location = new System.Drawing.Point(12, 287);
            this.commercialInstruments1.Name = "commercialInstruments1";
            this.commercialInstruments1.Size = new System.Drawing.Size(819, 369);
            this.commercialInstruments1.TabIndex = 2;
            // 
            // personalInformation1
            // 
            this.personalInformation1.Location = new System.Drawing.Point(12, 12);
            this.personalInformation1.Name = "personalInformation1";
            this.personalInformation1.Size = new System.Drawing.Size(353, 240);
            this.personalInformation1.TabIndex = 0;
            // 
            // stay1
            // 
            this.stay1.Location = new System.Drawing.Point(372, 13);
            this.stay1.Name = "stay1";
            this.stay1.Size = new System.Drawing.Size(459, 265);
            this.stay1.TabIndex = 3;
            // 
            // CustomerFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 664);
            this.Controls.Add(this.stay1);
            this.Controls.Add(this.commercialInstruments1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.personalInformation1);
            this.Name = "CustomerFile";
            this.Text = "Customer File";
            this.ResumeLayout(false);

        }

        #endregion

        private Customer.WinForm.PersonalInformation personalInformation1;
        private System.Windows.Forms.Button button1;
        private Vanilla.Invoice.WinForm.CommercialInstruments commercialInstruments1;
        private Lodge.WinForm.Stay stay1;

    }
}