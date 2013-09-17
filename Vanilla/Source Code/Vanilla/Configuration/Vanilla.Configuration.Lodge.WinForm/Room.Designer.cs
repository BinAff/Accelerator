namespace AutoTourism.Configuration
{
    partial class Room
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
            this.cboFloor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBuilding = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsAC = new System.Windows.Forms.CheckBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRoomList = new System.Windows.Forms.ComboBox();
            this.chkIsDormitory = new System.Windows.Forms.CheckBox();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.imlPhotos = new System.Windows.Forms.ImageList(this.components);
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.lstImage = new System.Windows.Forms.ListBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(261, 231);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(193, 21);
            this.cboType.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Type";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(261, 204);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(193, 21);
            this.cboCategory.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Category";
            // 
            // cboFloor
            // 
            this.cboFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFloor.FormattingEnabled = true;
            this.cboFloor.Location = new System.Drawing.Point(261, 177);
            this.cboFloor.Name = "cboFloor";
            this.cboFloor.Size = new System.Drawing.Size(37, 21);
            this.cboFloor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Floor";
            // 
            // cboBuilding
            // 
            this.cboBuilding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuilding.FormattingEnabled = true;
            this.cboBuilding.Location = new System.Drawing.Point(261, 150);
            this.cboBuilding.Name = "cboBuilding";
            this.cboBuilding.Size = new System.Drawing.Size(193, 21);
            this.cboBuilding.TabIndex = 4;
            this.cboBuilding.SelectedIndexChanged += new System.EventHandler(this.cboBuilding_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Building";
            // 
            // chkIsAC
            // 
            this.chkIsAC.AutoSize = true;
            this.chkIsAC.Location = new System.Drawing.Point(201, 258);
            this.chkIsAC.Name = "chkIsAC";
            this.chkIsAC.Size = new System.Drawing.Size(97, 17);
            this.chkIsAC.TabIndex = 8;
            this.chkIsAC.Text = "Air Conditioned";
            this.chkIsAC.UseVisualStyleBackColor = true;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(261, 42);
            this.txtNumber.MaxLength = 50;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(193, 20);
            this.txtNumber.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Number";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(261, 94);
            this.txtDesc.MaxLength = 255;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(193, 50);
            this.txtDesc.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(261, 68);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(193, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Name";
            // 
            // cboRoomList
            // 
            this.cboRoomList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboRoomList.FormattingEnabled = true;
            this.cboRoomList.Location = new System.Drawing.Point(8, 41);
            this.cboRoomList.Name = "cboRoomList";
            this.cboRoomList.Size = new System.Drawing.Size(184, 234);
            this.cboRoomList.Sorted = true;
            this.cboRoomList.TabIndex = 54;
            this.cboRoomList.SelectedIndexChanged += new System.EventHandler(this.cboRoomList_SelectedIndexChanged);
            // 
            // chkIsDormitory
            // 
            this.chkIsDormitory.AutoSize = true;
            this.chkIsDormitory.Location = new System.Drawing.Point(346, 258);
            this.chkIsDormitory.Name = "chkIsDormitory";
            this.chkIsDormitory.Size = new System.Drawing.Size(70, 17);
            this.chkIsDormitory.TabIndex = 9;
            this.chkIsDormitory.Text = "Dormitory";
            this.chkIsDormitory.UseVisualStyleBackColor = true;
            // 
            // picPhoto
            // 
            this.picPhoto.Location = new System.Drawing.Point(659, 41);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(134, 125);
            this.picPhoto.TabIndex = 75;
            this.picPhoto.TabStop = false;
            // 
            // imlPhotos
            // 
            this.imlPhotos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlPhotos.ImageSize = new System.Drawing.Size(16, 16);
            this.imlPhotos.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Location = new System.Drawing.Point(464, 253);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(81, 22);
            this.btnDeleteImage.TabIndex = 77;
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(551, 253);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(81, 22);
            this.btnAddImage.TabIndex = 78;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // lstImage
            // 
            this.lstImage.FormattingEnabled = true;
            this.lstImage.Location = new System.Drawing.Point(464, 42);
            this.lstImage.Name = "lstImage";
            this.lstImage.Size = new System.Drawing.Size(168, 199);
            this.lstImage.TabIndex = 79;
            this.lstImage.SelectedIndexChanged += new System.EventHandler(this.lstImage_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 285);
            this.Controls.Add(this.lstImage);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.chkIsDormitory);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboFloor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboBuilding);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkIsAC);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRoomList);
            this.Name = "Room";
            this.Text = "Room Configuration";
            this.Load += new System.EventHandler(this.Room_Load);
            this.Controls.SetChildIndex(this.cboRoomList, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtDesc, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtNumber, 0);
            this.Controls.SetChildIndex(this.chkIsAC, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboBuilding, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboFloor, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboCategory, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboType, 0);
            this.Controls.SetChildIndex(this.chkIsDormitory, 0);
            this.Controls.SetChildIndex(this.picPhoto, 0);
            this.Controls.SetChildIndex(this.btnDeleteImage, 0);
            this.Controls.SetChildIndex(this.btnAddImage, 0);
            this.Controls.SetChildIndex(this.lstImage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFloor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBuilding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsAC;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRoomList;
        private System.Windows.Forms.CheckBox chkIsDormitory;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.ImageList imlPhotos;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.ListBox lstImage;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}