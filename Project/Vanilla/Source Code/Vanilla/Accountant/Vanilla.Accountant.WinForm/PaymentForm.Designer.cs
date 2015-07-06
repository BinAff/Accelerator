namespace Vanilla.Accountant.WinForm
{
    partial class PaymentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastFourDigit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeleteLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastFourDigit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Advance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outstanding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblReservationStatus = new System.Windows.Forms.Label();
            this.tpnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.tpnlContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPayment
            // 
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeName,
            this.Amount,
            this.LastFourDigit,
            this.Remark,
            this.EditLink,
            this.DeleteLink});
            this.tpnlContainer.SetColumnSpan(this.dgvPayment, 3);
            this.dgvPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPayment.Location = new System.Drawing.Point(3, 195);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.Size = new System.Drawing.Size(546, 96);
            this.dgvPayment.TabIndex = 124;
            this.dgvPayment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayment_CellContentClick);
            // 
            // TypeName
            // 
            this.TypeName.HeaderText = "Type";
            this.TypeName.Name = "TypeName";
            this.TypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // LastFourDigit
            // 
            this.LastFourDigit.HeaderText = "Last Four Digit";
            this.LastFourDigit.Name = "LastFourDigit";
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            // 
            // EditLink
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.EditLink.DefaultCellStyle = dataGridViewCellStyle25;
            this.EditLink.HeaderText = "Edit";
            this.EditLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.EditLink.LinkColor = System.Drawing.Color.Black;
            this.EditLink.Name = "EditLink";
            this.EditLink.ReadOnly = true;
            this.EditLink.Text = "?";
            this.EditLink.UseColumnTextForLinkValue = true;
            this.EditLink.Width = 50;
            // 
            // DeleteLink
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.DeleteLink.DefaultCellStyle = dataGridViewCellStyle26;
            this.DeleteLink.HeaderText = "Delete";
            this.DeleteLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.DeleteLink.LinkColor = System.Drawing.Color.Black;
            this.DeleteLink.Name = "DeleteLink";
            this.DeleteLink.Text = "û";
            this.DeleteLink.UseColumnTextForLinkValue = true;
            this.DeleteLink.Width = 50;
            // 
            // txtAmount
            // 
            this.txtAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmount.Location = new System.Drawing.Point(206, 99);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(343, 20);
            this.txtAmount.TabIndex = 136;
            // 
            // lblAmount
            // 
            this.lblAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmount.Location = new System.Drawing.Point(3, 96);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(168, 24);
            this.lblAmount.TabIndex = 135;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChange
            // 
            this.btnChange.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnChange.Location = new System.Drawing.Point(28, 0);
            this.btnChange.Margin = new System.Windows.Forms.Padding(0);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(24, 24);
            this.btnChange.TabIndex = 134;
            this.btnChange.Text = "?";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Wingdings 2", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 133;
            this.btnAdd.Text = "Ç";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(206, 51);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(343, 21);
            this.cboPaymentType.TabIndex = 132;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 131;
            this.label2.Text = "Remark";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(206, 123);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(343, 42);
            this.txtRemark.TabIndex = 130;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 24);
            this.label5.TabIndex = 129;
            this.label5.Text = "Reference Number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLastFourDigit
            // 
            this.txtLastFourDigit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLastFourDigit.Location = new System.Drawing.Point(206, 75);
            this.txtLastFourDigit.MaxLength = 4;
            this.txtLastFourDigit.Name = "txtLastFourDigit";
            this.txtLastFourDigit.Size = new System.Drawing.Size(343, 20);
            this.txtLastFourDigit.TabIndex = 128;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 24);
            this.label6.TabIndex = 127;
            this.label6.Text = "Payment Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.InvoiceDate,
            this.InvoiceNo,
            this.InvoiceAmount,
            this.Advance,
            this.Discount,
            this.Outstanding});
            this.dgvInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvInvoice.Location = new System.Drawing.Point(0, 27);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.Size = new System.Drawing.Size(636, 123);
            this.dgvInvoice.TabIndex = 167;
            // 
            // Select
            // 
            this.Select.FillWeight = 30F;
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.Width = 30;
            // 
            // InvoiceDate
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.InvoiceDate.DefaultCellStyle = dataGridViewCellStyle27;
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.InvoiceNo.DefaultCellStyle = dataGridViewCellStyle28;
            this.InvoiceNo.FillWeight = 120F;
            this.InvoiceNo.HeaderText = "Invoice Number";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            this.InvoiceNo.Width = 150;
            // 
            // InvoiceAmount
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InvoiceAmount.DefaultCellStyle = dataGridViewCellStyle29;
            this.InvoiceAmount.FillWeight = 80F;
            this.InvoiceAmount.HeaderText = "Total";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.ReadOnly = true;
            this.InvoiceAmount.Width = 80;
            // 
            // Advance
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Advance.DefaultCellStyle = dataGridViewCellStyle30;
            this.Advance.FillWeight = 80F;
            this.Advance.HeaderText = "Advance";
            this.Advance.Name = "Advance";
            this.Advance.ReadOnly = true;
            this.Advance.Width = 80;
            // 
            // Discount
            // 
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Discount.DefaultCellStyle = dataGridViewCellStyle31;
            this.Discount.FillWeight = 80F;
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Width = 80;
            // 
            // Outstanding
            // 
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Outstanding.DefaultCellStyle = dataGridViewCellStyle32;
            this.Outstanding.FillWeight = 80F;
            this.Outstanding.HeaderText = "Outstanding";
            this.Outstanding.Name = "Outstanding";
            this.Outstanding.ReadOnly = true;
            this.Outstanding.Width = 80;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiptNo.Location = new System.Drawing.Point(206, 3);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(343, 20);
            this.txtReceiptNo.TabIndex = 1028;
            this.txtReceiptNo.TabStop = false;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 24);
            this.label17.TabIndex = 1029;
            this.label17.Text = "Receipt No";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Location = new System.Drawing.Point(206, 27);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(343, 20);
            this.txtStatus.TabIndex = 1031;
            this.txtStatus.TabStop = false;
            // 
            // lblReservationStatus
            // 
            this.lblReservationStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReservationStatus.Location = new System.Drawing.Point(3, 24);
            this.lblReservationStatus.Name = "lblReservationStatus";
            this.lblReservationStatus.Size = new System.Drawing.Size(168, 24);
            this.lblReservationStatus.TabIndex = 1030;
            this.lblReservationStatus.Text = "Status";
            this.lblReservationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpnlContainer
            // 
            this.tpnlContainer.ColumnCount = 4;
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tpnlContainer.Controls.Add(this.txtAmount, 2, 4);
            this.tpnlContainer.Controls.Add(this.label17, 0, 0);
            this.tpnlContainer.Controls.Add(this.tableLayoutPanel2, 2, 6);
            this.tpnlContainer.Controls.Add(this.txtRemark, 2, 5);
            this.tpnlContainer.Controls.Add(this.label2, 0, 5);
            this.tpnlContainer.Controls.Add(this.lblAmount, 0, 4);
            this.tpnlContainer.Controls.Add(this.dgvPayment, 0, 7);
            this.tpnlContainer.Controls.Add(this.txtStatus, 2, 1);
            this.tpnlContainer.Controls.Add(this.txtReceiptNo, 2, 0);
            this.tpnlContainer.Controls.Add(this.lblReservationStatus, 0, 1);
            this.tpnlContainer.Controls.Add(this.cboPaymentType, 2, 2);
            this.tpnlContainer.Controls.Add(this.label6, 0, 2);
            this.tpnlContainer.Controls.Add(this.label5, 0, 3);
            this.tpnlContainer.Controls.Add(this.txtLastFourDigit, 2, 3);
            this.tpnlContainer.Location = new System.Drawing.Point(0, 153);
            this.tpnlContainer.Name = "tpnlContainer";
            this.tpnlContainer.RowCount = 8;
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tpnlContainer.Size = new System.Drawing.Size(583, 315);
            this.tpnlContainer.TabIndex = 1032;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnChange, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(500, 168);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(52, 24);
            this.tableLayoutPanel2.TabIndex = 1033;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 494);
            this.Controls.Add(this.tpnlContainer);
            this.Controls.Add(this.dgvInvoice);
            this.IsVisibleCloseButton = true;
            this.IsVisibleOkButton = true;
            this.Name = "PaymentForm";
            this.Text = "Payment Form";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.Controls.SetChildIndex(this.dgvInvoice, 0);
            this.Controls.SetChildIndex(this.tpnlContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.tpnlContainer.ResumeLayout(false);
            this.tpnlContainer.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastFourDigit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblReservationStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastFourDigit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewLinkColumn EditLink;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteLink;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Advance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outstanding;
        private System.Windows.Forms.TableLayoutPanel tpnlContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

    }
}