namespace Vanilla.Accountant.WinForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuxuaryTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAdvance = new System.Windows.Forms.DataGridView();
            this.AdvanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdvanceReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdvanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpnlContainer = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvance)).BeginInit();
            this.tpnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAdvance
            // 
            this.txtAdvance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAdvance.Location = new System.Drawing.Point(405, 411);
            this.txtAdvance.MaxLength = 20;
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.ReadOnly = true;
            this.txtAdvance.Size = new System.Drawing.Size(759, 20);
            this.txtAdvance.TabIndex = 162;
            this.txtAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 408);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(376, 24);
            this.label7.TabIndex = 161;
            this.label7.Text = "Advance";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGrandTotal.Location = new System.Drawing.Point(405, 459);
            this.txtGrandTotal.MaxLength = 20;
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(759, 20);
            this.txtGrandTotal.TabIndex = 160;
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 462);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(376, 13);
            this.label4.TabIndex = 159;
            this.label4.Text = "Grand Total";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiscount.Location = new System.Drawing.Point(405, 435);
            this.txtDiscount.MaxLength = 20;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(759, 20);
            this.txtDiscount.TabIndex = 158;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.Enter += new System.EventHandler(this.txtDiscount_Enter);
            // 
            // txtTotal
            // 
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotal.Location = new System.Drawing.Point(405, 387);
            this.txtTotal.MaxLength = 20;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(759, 20);
            this.txtTotal.TabIndex = 157;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 24);
            this.label3.TabIndex = 156;
            this.label3.Text = "Discount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 24);
            this.label1.TabIndex = 155;
            this.label1.Text = "Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 24);
            this.label2.TabIndex = 166;
            this.label2.Text = "Invoice Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(376, 24);
            this.label5.TabIndex = 167;
            this.label5.Text = "Invoice Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvoice.Location = new System.Drawing.Point(405, 3);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.ReadOnly = true;
            this.txtInvoice.Size = new System.Drawing.Size(759, 20);
            this.txtInvoice.TabIndex = 168;
            // 
            // txtDate
            // 
            this.txtDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDate.Location = new System.Drawing.Point(405, 27);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(759, 20);
            this.txtDate.TabIndex = 169;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 294);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(376, 13);
            this.label6.TabIndex = 167;
            this.label6.Text = "Advance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.ExtraRate,
            this.ExtraCount,
            this.Amount,
            this.ServiceTax,
            this.LuxuaryTax,
            this.Total});
            this.tpnlContainer.SetColumnSpan(this.dgvProduct, 3);
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduct.Location = new System.Drawing.Point(3, 51);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(1161, 234);
            this.dgvProduct.TabIndex = 174;
            // 
            // Start
            // 
            this.Start.FillWeight = 80F;
            this.Start.HeaderText = "Start Date";
            this.Start.MaxInputLength = 10;
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            // 
            // End
            // 
            this.End.FillWeight = 80F;
            this.End.HeaderText = "End Date";
            this.End.MaxInputLength = 10;
            this.End.MinimumWidth = 10;
            this.End.Name = "End";
            this.End.ReadOnly = true;
            // 
            // Description
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Description.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.Count.FillWeight = 50F;
            this.Count.HeaderText = "Count";
            this.Count.MaxInputLength = 2;
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 50;
            // 
            // ExtraRate
            // 
            this.ExtraRate.FillWeight = 80F;
            this.ExtraRate.HeaderText = "Extra Rate";
            this.ExtraRate.Name = "ExtraRate";
            this.ExtraRate.ReadOnly = true;
            this.ExtraRate.Width = 80;
            // 
            // ExtraCount
            // 
            this.ExtraCount.FillWeight = 50F;
            this.ExtraCount.HeaderText = "Count";
            this.ExtraCount.Name = "ExtraCount";
            this.ExtraCount.ReadOnly = true;
            this.ExtraCount.Width = 50;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MaxInputLength = 10;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 80;
            // 
            // ServiceTax
            // 
            this.ServiceTax.FillWeight = 105F;
            this.ServiceTax.HeaderText = "Service Tax (%)";
            this.ServiceTax.MaxInputLength = 10;
            this.ServiceTax.Name = "ServiceTax";
            this.ServiceTax.ReadOnly = true;
            this.ServiceTax.Width = 105;
            // 
            // LuxuaryTax
            // 
            this.LuxuaryTax.FillWeight = 105F;
            this.LuxuaryTax.HeaderText = "Luxury Tax (%)";
            this.LuxuaryTax.MaxInputLength = 10;
            this.LuxuaryTax.Name = "LuxuaryTax";
            this.LuxuaryTax.ReadOnly = true;
            this.LuxuaryTax.Width = 105;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MaxInputLength = 10;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 80;
            // 
            // dgvAdvance
            // 
            this.dgvAdvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdvance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AdvanceDate,
            this.AdvanceReceiptNo,
            this.AdvanceAmount});
            this.dgvAdvance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdvance.Location = new System.Drawing.Point(405, 291);
            this.dgvAdvance.Name = "dgvAdvance";
            this.dgvAdvance.Size = new System.Drawing.Size(759, 90);
            this.dgvAdvance.TabIndex = 155;
            // 
            // AdvanceDate
            // 
            this.AdvanceDate.HeaderText = "Date";
            this.AdvanceDate.Name = "AdvanceDate";
            // 
            // AdvanceReceiptNo
            // 
            this.AdvanceReceiptNo.HeaderText = "Receipt No";
            this.AdvanceReceiptNo.Name = "AdvanceReceiptNo";
            this.AdvanceReceiptNo.Width = 200;
            // 
            // AdvanceAmount
            // 
            this.AdvanceAmount.HeaderText = "Amount";
            this.AdvanceAmount.Name = "AdvanceAmount";
            this.AdvanceAmount.ReadOnly = true;
            // 
            // tpnlContainer
            // 
            this.tpnlContainer.ColumnCount = 4;
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlContainer.Controls.Add(this.txtGrandTotal, 2, 7);
            this.tpnlContainer.Controls.Add(this.txtAdvance, 2, 5);
            this.tpnlContainer.Controls.Add(this.label4, 0, 7);
            this.tpnlContainer.Controls.Add(this.txtDiscount, 2, 6);
            this.tpnlContainer.Controls.Add(this.label7, 0, 5);
            this.tpnlContainer.Controls.Add(this.label3, 0, 6);
            this.tpnlContainer.Controls.Add(this.label2, 0, 0);
            this.tpnlContainer.Controls.Add(this.dgvProduct, 0, 2);
            this.tpnlContainer.Controls.Add(this.label5, 0, 1);
            this.tpnlContainer.Controls.Add(this.txtTotal, 2, 4);
            this.tpnlContainer.Controls.Add(this.txtDate, 2, 1);
            this.tpnlContainer.Controls.Add(this.txtInvoice, 2, 0);
            this.tpnlContainer.Controls.Add(this.label1, 0, 4);
            this.tpnlContainer.Controls.Add(this.dgvAdvance, 2, 3);
            this.tpnlContainer.Controls.Add(this.label6, 0, 3);
            this.tpnlContainer.Location = new System.Drawing.Point(12, 44);
            this.tpnlContainer.Name = "tpnlContainer";
            this.tpnlContainer.RowCount = 8;
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.Size = new System.Drawing.Size(1189, 494);
            this.tpnlContainer.TabIndex = 176;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 529);
            this.Controls.Add(this.tpnlContainer);
            this.IsVisibleCloseButton = true;
            this.IsVisibleOkButton = true;
            this.Name = "InvoiceForm";
            this.ShowInTaskbar = false;
            this.Text = "Invoice Generation Form";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.Controls.SetChildIndex(this.tpnlContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvance)).EndInit();
            this.tpnlContainer.ResumeLayout(false);
            this.tpnlContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridView dgvAdvance;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdvanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdvanceReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdvanceAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tpnlContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn End;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuxuaryTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}