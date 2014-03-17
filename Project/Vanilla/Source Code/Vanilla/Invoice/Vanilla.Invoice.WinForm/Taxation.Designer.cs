namespace Vanilla.Invoice.WinForm
{
    partial class Taxation
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
            this.lslList = new System.Windows.Forms.ListBox();
            this.lblTaxName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkIsPerc = new System.Windows.Forms.CheckBox();
            this.lblTaxVal = new System.Windows.Forms.Label();
            this.txtTaxValue = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lslList
            // 
            this.lslList.FormattingEnabled = true;
            this.lslList.Location = new System.Drawing.Point(10, 12);
            this.lslList.Name = "lslList";
            this.lslList.Size = new System.Drawing.Size(172, 108);
            this.lslList.Sorted = true;
            this.lslList.TabIndex = 153;
            // 
            // lblTaxName
            // 
            this.lblTaxName.AutoSize = true;
            this.lblTaxName.Location = new System.Drawing.Point(200, 15);
            this.lblTaxName.Name = "lblTaxName";
            this.lblTaxName.Size = new System.Drawing.Size(56, 13);
            this.lblTaxName.TabIndex = 154;
            this.lblTaxName.Text = "Tax Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(262, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 155;
            // 
            // chkIsPerc
            // 
            this.chkIsPerc.AutoSize = true;
            this.chkIsPerc.Location = new System.Drawing.Point(263, 68);
            this.chkIsPerc.Name = "chkIsPerc";
            this.chkIsPerc.Size = new System.Drawing.Size(92, 17);
            this.chkIsPerc.TabIndex = 156;
            this.chkIsPerc.Text = "Is Percentage";
            this.chkIsPerc.UseVisualStyleBackColor = true;
            // 
            // lblTaxVal
            // 
            this.lblTaxVal.AutoSize = true;
            this.lblTaxVal.Location = new System.Drawing.Point(201, 49);
            this.lblTaxVal.Name = "lblTaxVal";
            this.lblTaxVal.Size = new System.Drawing.Size(55, 13);
            this.lblTaxVal.TabIndex = 157;
            this.lblTaxVal.Text = "Tax Value";
            // 
            // txtTaxValue
            // 
            this.txtTaxValue.Location = new System.Drawing.Point(262, 42);
            this.txtTaxValue.Name = "txtTaxValue";
            this.txtTaxValue.Size = new System.Drawing.Size(93, 20);
            this.txtTaxValue.TabIndex = 158;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(436, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 159;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(436, 39);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 160;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // Taxation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 130);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTaxValue);
            this.Controls.Add(this.lblTaxVal);
            this.Controls.Add(this.chkIsPerc);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblTaxName);
            this.Controls.Add(this.lslList);
            this.Name = "Taxation";
            this.Text = "Taxation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lslList;
        private System.Windows.Forms.Label lblTaxName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkIsPerc;
        private System.Windows.Forms.Label lblTaxVal;
        private System.Windows.Forms.TextBox txtTaxValue;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChange;
    }
}