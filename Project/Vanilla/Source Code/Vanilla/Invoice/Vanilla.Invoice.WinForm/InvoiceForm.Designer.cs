namespace Vanilla.Invoice.WinForm
{
    partial class InvoiceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTax = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuxuaryTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTax)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTax
            // 
            this.dgvTax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTax.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.value});
            this.dgvTax.Location = new System.Drawing.Point(814, 3);
            this.dgvTax.Name = "dgvTax";
            this.dgvTax.Size = new System.Drawing.Size(269, 86);
            this.dgvTax.TabIndex = 154;
            // 
            // name
            // 
            this.name.HeaderText = "Tax";
            this.name.Name = "name";
            // 
            // value
            // 
            this.value.HeaderText = "Amount";
            this.value.Name = "value";
            // 
            // txtAdvance
            // 
            this.txtAdvance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdvance.Location = new System.Drawing.Point(966, 31);
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.ReadOnly = true;
            this.txtAdvance.Size = new System.Drawing.Size(118, 20);
            this.txtAdvance.TabIndex = 162;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(910, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 161;
            this.label7.Text = "Advance";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrandTotal.Location = new System.Drawing.Point(965, 83);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(118, 20);
            this.txtGrandTotal.TabIndex = 160;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(896, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 159;
            this.label4.Text = "Grand Total";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscount.Location = new System.Drawing.Point(966, 57);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(118, 20);
            this.txtDiscount.TabIndex = 158;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(965, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(118, 20);
            this.txtTotal.TabIndex = 157;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(911, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 156;
            this.label3.Text = "Discount";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(928, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 155;
            this.label1.Text = "Total";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(846, 109);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 163;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1008, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 164;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(927, 109);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 165;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 166;
            this.label2.Text = "Invoice Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(798, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 167;
            this.label5.Text = "Invoice Date";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(100, 6);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.ReadOnly = true;
            this.txtInvoice.Size = new System.Drawing.Size(208, 20);
            this.txtInvoice.TabIndex = 168;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(872, 6);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(208, 20);
            this.txtDate.TabIndex = 169;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTax);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 292);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 95);
            this.panel1.TabIndex = 170;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnGenerate);
            this.panel2.Controls.Add(this.txtAdvance);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtGrandTotal);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDiscount);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1092, 140);
            this.panel2.TabIndex = 171;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtDate);
            this.panel4.Controls.Add(this.txtInvoice);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1092, 31);
            this.panel4.TabIndex = 173;
            // 
            // dgvProduct
            // 
            this.dgvProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Start,
            this.End,
            this.Description,
            this.UnitRate,
            this.Count,
            this.Amount,
            this.ServiceTax,
            this.LuxuaryTax,
            this.TotalAmount});
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduct.Location = new System.Drawing.Point(10, 0);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(1072, 261);
            this.dgvProduct.TabIndex = 174;
            // 
            // Start
            // 
            this.Start.FillWeight = 80F;
            this.Start.HeaderText = "Start Date";
            this.Start.MaxInputLength = 10;
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            this.Start.Width = 80;
            // 
            // End
            // 
            this.End.FillWeight = 80F;
            this.End.HeaderText = "End Date";
            this.End.MaxInputLength = 10;
            this.End.MinimumWidth = 10;
            this.End.Name = "End";
            this.End.ReadOnly = true;
            this.End.Width = 80;
            // 
            // Description
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Description.DefaultCellStyle = dataGridViewCellStyle3;
            this.Description.HeaderText = "Description";
            this.Description.MaxInputLength = 500;
            this.Description.MinimumWidth = 300;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 300;
            // 
            // UnitRate
            // 
            this.UnitRate.FillWeight = 80F;
            this.UnitRate.HeaderText = "Unit Rate";
            this.UnitRate.MaxInputLength = 10;
            this.UnitRate.Name = "UnitRate";
            this.UnitRate.ReadOnly = true;
            this.UnitRate.Width = 80;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.MaxInputLength = 2;
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 50;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MaxInputLength = 10;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // ServiceTax
            // 
            this.ServiceTax.FillWeight = 110F;
            this.ServiceTax.HeaderText = "Service Tax (%)";
            this.ServiceTax.MaxInputLength = 10;
            this.ServiceTax.Name = "ServiceTax";
            this.ServiceTax.ReadOnly = true;
            this.ServiceTax.Width = 110;
            // 
            // LuxuaryTax
            // 
            this.LuxuaryTax.FillWeight = 110F;
            this.LuxuaryTax.HeaderText = "Luxuary Tax (%)";
            this.LuxuaryTax.MaxInputLength = 10;
            this.LuxuaryTax.Name = "LuxuaryTax";
            this.LuxuaryTax.ReadOnly = true;
            this.LuxuaryTax.Width = 110;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.MaxInputLength = 10;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvProduct);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 31);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel3.Size = new System.Drawing.Size(1092, 261);
            this.panel3.TabIndex = 175;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 527);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "InvoiceForm";
            this.Text = "Invoice Generation Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTax)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTax;
        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn End;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuxuaryTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.Panel panel3;
    }
}