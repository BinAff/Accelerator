namespace AutoTourism.Lodge.Configuration.WinForm
{
    partial class RoomTariff
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
            this.components = new System.ComponentModel.Container();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsAC = new System.Windows.Forms.CheckBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTariff = new System.Windows.Forms.DataGridView();
            this.txtCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.rdoCurrent = new System.Windows.Forms.RadioButton();
            this.rdoFuture = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTariff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(616, 65);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(142, 21);
            this.cboType.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(561, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Type";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(616, 38);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(142, 21);
            this.cboCategory.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(561, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Category";
            // 
            // chkIsAC
            // 
            this.chkIsAC.AutoSize = true;
            this.chkIsAC.Location = new System.Drawing.Point(561, 92);
            this.chkIsAC.Name = "chkIsAC";
            this.chkIsAC.Size = new System.Drawing.Size(97, 17);
            this.chkIsAC.TabIndex = 79;
            this.chkIsAC.Text = "Air Conditioned";
            this.chkIsAC.UseVisualStyleBackColor = true;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(616, 167);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(142, 20);
            this.txtRate.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(561, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Rate";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(616, 115);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(142, 20);
            this.dtStartDate.TabIndex = 82;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(616, 141);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(142, 20);
            this.dtEndDate.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(561, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 85;
            this.label5.Text = "End Date";
            // 
            // dgvTariff
            // 
            this.dgvTariff.AllowUserToAddRows = false;
            this.dgvTariff.AllowUserToDeleteRows = false;
            this.dgvTariff.AllowUserToOrderColumns = true;
            this.dgvTariff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTariff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCategory,
            this.txtType,
            this.txtAC,
            this.txtStartDate,
            this.txtEndDate,
            this.txtPrice});
            this.dgvTariff.Location = new System.Drawing.Point(12, 41);
            this.dgvTariff.Name = "dgvTariff";
            this.dgvTariff.ReadOnly = true;
            this.dgvTariff.Size = new System.Drawing.Size(543, 226);
            this.dgvTariff.TabIndex = 86;
            this.dgvTariff.SelectionChanged += new System.EventHandler(this.dgvTariff_SelectionChanged);
            // 
            // txtCategory
            // 
            this.txtCategory.Frozen = true;
            this.txtCategory.HeaderText = "Category";
            this.txtCategory.MinimumWidth = 80;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Width = 80;
            // 
            // txtType
            // 
            this.txtType.HeaderText = "Type";
            this.txtType.MinimumWidth = 80;
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Width = 80;
            // 
            // txtAC
            // 
            this.txtAC.HeaderText = "IsAC";
            this.txtAC.MinimumWidth = 80;
            this.txtAC.Name = "txtAC";
            this.txtAC.ReadOnly = true;
            this.txtAC.Width = 80;
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
            // txtPrice
            // 
            this.txtPrice.HeaderText = "Price";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // rdoCurrent
            // 
            this.rdoCurrent.AutoSize = true;
            this.rdoCurrent.Location = new System.Drawing.Point(12, 12);
            this.rdoCurrent.Name = "rdoCurrent";
            this.rdoCurrent.Size = new System.Drawing.Size(59, 17);
            this.rdoCurrent.TabIndex = 133;
            this.rdoCurrent.TabStop = true;
            this.rdoCurrent.Text = "Current";
            this.rdoCurrent.UseVisualStyleBackColor = true;
            this.rdoCurrent.CheckedChanged += new System.EventHandler(this.rdoCurrent_CheckedChanged);
            // 
            // rdoFuture
            // 
            this.rdoFuture.AutoSize = true;
            this.rdoFuture.Location = new System.Drawing.Point(77, 12);
            this.rdoFuture.Name = "rdoFuture";
            this.rdoFuture.Size = new System.Drawing.Size(55, 17);
            this.rdoFuture.TabIndex = 134;
            this.rdoFuture.TabStop = true;
            this.rdoFuture.Text = "Future";
            this.rdoFuture.UseVisualStyleBackColor = true;
            this.rdoFuture.CheckedChanged += new System.EventHandler(this.rdoFuture_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(138, 12);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 135;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(770, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 136;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(770, 44);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 137;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // RoomTariff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 279);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoFuture);
            this.Controls.Add(this.rdoCurrent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.chkIsAC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvTariff);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.txtRate);
            this.Name = "RoomTariff";
            this.Text = "Tariff";
            this.TransparencyKey = System.Drawing.Color.Empty;
            ((System.ComponentModel.ISupportInitialize)(this.dgvTariff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsAC;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvTariff;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrice;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoFuture;
        private System.Windows.Forms.RadioButton rdoCurrent;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChange;
    }
}