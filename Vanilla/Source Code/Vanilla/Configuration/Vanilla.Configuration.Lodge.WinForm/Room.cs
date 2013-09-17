using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//using BinAff.Core;
//using BinAff.Utility;

//using AutoTourism.Facade.Configuration.Room;

//using AutoTourism.Presentation.Library;

namespace AutoTourism.Configuration
{

    public partial class Room : Form
    {
        public enum RoomStatus
        {
            Unoccupied = 10001,
            Occupied = 10002,
            Closed = 10003
        }

        //private AutoTourism.Facade.UserManagement.User.Dto userDto = null;
        //private List<ImageDto> ImageDtoList = new List<ImageDto>();

        public Room()
        {
            InitializeComponent();
        }
        //public Room(AutoTourism.Facade.UserManagement.User.Dto UserDto)
        //{
        //    InitializeComponent();
        //    this.userDto = UserDto;
        //    base.IsOpenButton = true;
        //    base.IsCloseButton = true;
        //}

        private void Room_Load(object sender, EventArgs e)
        {
            LoadForm();
            Clear();
        }

        protected override void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadForm();
            Clear();
        }
        
        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            //if (!ValidateRoom()) return;
            
            //Dto roomDto = new Dto() {
            //    Number = this.txtNumber.Text.Trim(),
            //    Name = this.txtName.Text.Trim(),
            //    Description = this.txtDesc.Text.Trim(),
            //    Building = cboBuilding.SelectedItem == null ? null : new Facade.Configuration.Building.Dto()
            //    {
            //        Id = ((Facade.Configuration.Building.Dto)cboBuilding.SelectedItem).Id,
            //    },
            //    Floor = Convert.ToInt32(cboFloor.SelectedItem),
            //    Category = cboCategory.SelectedItem == null ? null : new Facade.Configuration.RoomCategory.Dto()
            //    {
            //        Id = ((Facade.Configuration.RoomCategory.Dto)cboCategory.SelectedItem).Id,
            //    },
            //    Type = cboType.SelectedItem == null ? null : new Facade.Configuration.RoomType.Dto()
            //    {
            //        Id = ((Facade.Configuration.RoomType.Dto)cboType.SelectedItem).Id,
            //    },
            //    IsAirconditioned = this.chkIsAC.Checked,
            //    IsDormitory = this.chkIsDormitory.Checked,

            //    ImageList = this.ImageDtoList.Count == 0 ? null : ImageDtoList,                
            //};

            //Save(roomDto);                          
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            //if (this.cboRoomList.SelectedIndex == -1)
            //{
            //    //Show message
            //    new MessageBox("Please select one room", MessageBox.Type.Alert).ShowDialog(this);
            //    return;
            //}

            //if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the room.?", "Room Delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //{
            //    IRoom room = new RoomServer();
            //    ReturnObject<Boolean> ret = room.Delete(new Dto()
            //    {
            //        Id = ((Dto)this.cboRoomList.SelectedItem).Id
            //    });

            //    base.ShowMessage(ret);//Show message
            //}
            //else Clear();
        }

        protected override void btnChange_Click(object sender, EventArgs e)
        {
            //if (this.cboRoomList.SelectedIndex == -1)
            //{                
            //    new MessageBox("Please select one room", MessageBox.Type.Alert).ShowDialog(this);//Show message
            //    return;
            //}

            //if (!ValidateRoom()) return;

            //Dto roomDto = new Dto()
            //{
            //    Id = ((Dto)this.cboRoomList.SelectedItem).Id,
            //    Number = this.txtNumber.Text.Trim(),
            //    Name = this.txtName.Text.Trim(),
            //    Description = this.txtDesc.Text.Trim(),
            //    Building = cboBuilding.SelectedItem == null ? null : new Facade.Configuration.Building.Dto()
            //    {
            //        Id = ((Facade.Configuration.Building.Dto)cboBuilding.SelectedItem).Id,
            //    },
            //    Floor = Convert.ToInt32(cboFloor.SelectedItem),
            //    Category = cboCategory.SelectedItem == null ? null : new Facade.Configuration.RoomCategory.Dto()
            //    {
            //        Id = ((Facade.Configuration.RoomCategory.Dto)cboCategory.SelectedItem).Id,
            //    },
            //    Type = cboType.SelectedItem == null ? null : new Facade.Configuration.RoomType.Dto()
            //    {
            //        Id = ((Facade.Configuration.RoomType.Dto)cboType.SelectedItem).Id,
            //    },
            //    IsAirconditioned = this.chkIsAC.Checked,
            //    IsDormitory = this.chkIsDormitory.Checked,

            //    ImageList = this.ImageDtoList.Count == 0 ? null : ImageDtoList,
            //};

            //Save(roomDto);

        }

        protected override void btnClose_Click(object sender, EventArgs e)
        {
            //if (this.cboRoomList.SelectedIndex == -1)
            //{
            //    //Show message
            //    new MessageBox("Please select one room", MessageBox.Type.Alert).ShowDialog(this);
            //    return;
            //}
            //Facade.Configuration.Room.Dto dto = (Facade.Configuration.Room.Dto)this.cboRoomList.SelectedItem;            
            //if (dto.StatusId == Convert.ToInt64(RoomStatus.Closed))
            //{
            //    ReturnObject<Boolean> ret = new ReturnObject<Boolean>()
            //    {
            //        Value = true,
            //        MessageList = new List<Message>(),
            //    };
            //    ret.MessageList.Add(new Message("Room is already closed.", Message.Type.Information));
            //    base.ShowMessage(ret);
            //}
            //else
            //{
            //    new ReasonDialog(Convert.ToString(EnumDefination.FormName.Room), this.userDto, dto.Id, dto.Building.Id).ShowDialog(this);

            //    LoadForm();
            //    Clear();
            //}

        }

        protected override void btnOpen_Click(object sender, EventArgs e)
        {
            //if (this.cboRoomList.SelectedIndex == -1)
            //{
            //    new MessageBox("Please select one room", MessageBox.Type.Alert).ShowDialog(this);//Show message
            //    return;
            //}

            //if (((Dto)this.cboRoomList.SelectedItem).StatusId != Convert.ToInt64(RoomStatus.Closed))
            //{
            //    new MessageBox("Unable to open room. Only closed rooms can be opened", MessageBox.Type.Error).ShowDialog(this);//Show message
            //    return;
            //}

            //IRoom room = new RoomServer();
            //ReturnObject<Boolean> ret = room.Open(new Dto()
            //{
            //    Id = ((Dto)this.cboRoomList.SelectedItem).Id,
            //    Building = new Facade.Configuration.Building.Dto() {
            //        Id = ((Dto)this.cboRoomList.SelectedItem).Building.Id
            //    }
            //});

            //base.ShowMessage(ret);//Show message
        }

        private void cboBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboBuilding.SelectedIndex != -1)
            //{
            //    Facade.Configuration.Building.Dto dto = (Facade.Configuration.Building.Dto)cboBuilding.SelectedItem;
            //    if (dto.Floor != null && dto.Floor.Count > 0)
            //    {
            //        this.cboFloor.DataSource = null;
            //        this.cboFloor.DataSource = dto.Floor;

            //        for (int i = 0; i < dto.Floor.Count; i++ )
            //        {
            //            if (dto.Floor[i] == dto.DefaultFloor)
            //            {
            //                this.cboFloor.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //    }
            //    else this.cboFloor.DataSource = null;
            //}
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            //errorProvider.Clear();            
            
            //try
            //{
            //    System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
            //    open.InitialDirectory = "c:\\";
            //    open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            //    if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {                  
            //        String ImgName = GetImageName(open.FileName);

            //        if(IsImageExist(ImgName, (List<String>)this.lstImage.DataSource))                    
            //            errorProvider.SetError(lstImage, "Image already included.");
            //        else
            //        {                        
            //            //POPULATE this.ImageDtoList                        
            //            Byte[] img = Converter.ReadFile(open.FileName);
            //            this.ImageDtoList.Add(new ImageDto() {
            //                Name = GetImageName(open.FileName),
            //                Image = Converter.ReadFile(open.FileName),
            //            });

            //            PopulateImageList(img);
                        
            //        }

            //    }
            //}
            //catch (Exception)
            //{
            //    throw new ApplicationException("Failed loading image");
            //}
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            //if (lstImage.SelectedItems.Count == 0) return;

            //Boolean blnExists = false;
            //List<ImageDto> imageDtoNewList = new List<ImageDto>();
            //List<String> ImageList = new List<string>();

            //if (lstImage.SelectedItems.Count > 0)
            //{
            //    foreach (ImageDto dto in this.ImageDtoList)
            //    {
            //        blnExists = false;
            //        foreach (String imgName in lstImage.SelectedItems)
            //        {
            //            if (dto.Name == imgName)
            //            {
            //                blnExists = true;
            //                break;
            //            }
            //        }

            //        if (!blnExists) imageDtoNewList.Add(dto);
            //    }

            //    this.ImageDtoList = new List<ImageDto>();
            //    this.ImageDtoList = imageDtoNewList;

            //    for (int i = this.ImageDtoList.Count - 1; i >= 0; i--)
            //        ImageList.Add(this.ImageDtoList[i].Name);

            //    lstImage.DataSource = null;
            //    this.picPhoto.Image = null;

            //    if (ImageList != null && ImageList.Count > 0)
            //    {
            //        lstImage.DataSource = ImageList;
            //        lstImage.SelectedIndex = 0;
            //    }
            //}
        }

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.lstImage.SelectedIndex != -1)
            //{
            //    foreach (ImageDto dto in this.ImageDtoList)
            //    {
            //        if (dto.Name == (String)this.lstImage.SelectedItem)
            //        {
            //            //Initialize image variable
            //            Image newImage;
            //            //Read image data into a memory stream
            //            using (MemoryStream ms = new MemoryStream(dto.Image, 0, dto.Image.Length))
            //            {
            //                ms.Write(dto.Image, 0, dto.Image.Length);

            //                //Set image variable value using memory stream.
            //                newImage = Image.FromStream(ms, true);
            //                //set picture
            //                this.picPhoto.Image = newImage;
            //                this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //            }

            //            break;
            //        }

            //    }
            //}
        }

        private void cboRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboRoomList.SelectedIndex != -1)
            //{
            //    Dto dto = (Dto)cboRoomList.SelectedItem;
            //    txtNumber.Text = dto.Number;
            //    txtName.Text = dto.Name;
            //    txtDesc.Text = dto.Description;

            //    //Building Dropdown
            //    List<Facade.Configuration.Building.Dto> buildingDtoList = (List<Facade.Configuration.Building.Dto>)cboBuilding.DataSource;
            //    if(buildingDtoList != null && buildingDtoList.Count>0)
            //    {
            //        for (int i = 0; i < buildingDtoList.Count; i++)
            //        {
            //            if (buildingDtoList[i].Id == dto.Building.Id)
            //            {
            //                cboBuilding.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //    }

            //    //Floor dropdown
            //    List<Int32> floorList = (List<Int32>)cboFloor.DataSource;
            //    if (floorList != null && floorList.Count > 0)
            //    {
            //        for (int i = 0; i < floorList.Count; i++)
            //        {
            //            if (floorList[i] == dto.Floor)
            //            {
            //                cboFloor.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //    }

            //    //Category Dropdown
            //    List<Facade.Configuration.RoomCategory.Dto> categoryList = (List<Facade.Configuration.RoomCategory.Dto>)cboCategory.DataSource;
            //    if (categoryList != null && categoryList.Count > 0)
            //    {
            //        for (int i = 0; i < categoryList.Count; i++)
            //        {
            //            if (categoryList[i].Id == dto.Category.Id)
            //            {
            //                cboCategory.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //    }

            //    //Type Dropdown
            //    List<Facade.Configuration.RoomType.Dto> typeList = (List<Facade.Configuration.RoomType.Dto>)cboType.DataSource;
            //    if (typeList != null && typeList.Count > 0)
            //    {
            //        for (int i = 0; i < typeList.Count; i++)
            //        {
            //            if (typeList[i].Id == dto.Type.Id)
            //            {
            //                cboType.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //    }

            //    chkIsAC.Checked = dto.IsAirconditioned;
            //    chkIsDormitory.Checked = dto.IsDormitory;

            //    this.ImageDtoList = dto.ImageList;
            //    PopulateImageList(null);
            //}
        }
   
        protected override void LoadForm()
        {
            //IRoom room = new RoomServer();
            //ReturnObject<FormDto> ret = room.LoadForm();

            ////populate Room List
            //this.cboRoomList.DataSource = null;
            //if (ret.Value.RoomList != null && ret.Value.RoomList.Count > 0)
            //{                
            //    this.cboRoomList.DataSource = ret.Value.RoomList;
            //    this.cboRoomList.ValueMember = "Id";
            //    this.cboRoomList.DisplayMember = "Name";
            //    this.cboRoomList.SelectedIndex = -1;                
            //}

            ////populate Building List
            //this.cboBuilding.DataSource = null;
            //if (ret.Value.BuildingList != null && ret.Value.BuildingList.Count > 0)
            //{                
            //    this.cboBuilding.DataSource = ret.Value.BuildingList;
            //    this.cboBuilding.ValueMember = "Id";
            //    this.cboBuilding.DisplayMember = "Name";
            //    this.cboBuilding.SelectedIndex = -1;  
              
            //    //select default building
            //    for (int i = 0; i < ret.Value.BuildingList.Count; i++)
            //    {
            //        if (ret.Value.BuildingList[i].IsDefault)
            //        {
            //            this.cboBuilding.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}

            //this.cboCategory.DataSource = null;
            //if (ret.Value.CategoryList != null && ret.Value.CategoryList.Count > 0)
            //{                
            //    this.cboCategory.DataSource = ret.Value.CategoryList;
            //    this.cboCategory.ValueMember = "Id";
            //    this.cboCategory.DisplayMember = "Name";
            //    this.cboCategory.SelectedIndex = -1;
            //}

            //this.cboType.DataSource = null;
            //if (ret.Value.TypeList != null && ret.Value.TypeList.Count > 0)
            //{                
            //    this.cboType.DataSource = ret.Value.TypeList;
            //    this.cboType.ValueMember = "Id";
            //    this.cboType.DisplayMember = "Name";
            //    this.cboType.SelectedIndex = -1;
            //}
           
        }

        protected override void Clear()
        {
            //this.cboRoomList.SelectedIndex = -1;
            //this.txtNumber.Text = String.Empty;
            //this.txtName.Text = String.Empty;
            //this.txtDesc.Text = String.Empty;
            ////this.cboBuilding.SelectedIndex = -1;
            ////this.cboFloor.SelectedIndex = -1;
            //this.cboCategory.SelectedIndex = -1;
            //this.cboType.SelectedIndex = -1;
            //this.chkIsAC.Checked = false;
            //this.chkIsDormitory.Checked = false;            
            //this.picPhoto.Image = null;
            //this.lstImage.DataSource = null;
            //this.ImageDtoList = new List<ImageDto>();

            
            ////select default building
            //List<Facade.Configuration.Building.Dto> retVal = (List<Facade.Configuration.Building.Dto>)this.cboBuilding.DataSource;
           
            //for (int i = 0; i < retVal.Count; i++)
            //{
            //    if (retVal[i].IsDefault)
            //    {
            //        this.cboBuilding.SelectedIndex = i;
            //        break;
            //    }
            //}
        }
      
        private Boolean IsImageExist(String RoomImageName, List<String> ImageList)
        {   
            //if (ImageList == null || ImageList.Count == 0)
            //    return false;
            //else
            //{
            //    foreach (String ImageName in ImageList)
            //    {
            //        if (ImageName.ToUpper() == RoomImageName.ToUpper())                    
            //            return true;
            //    }
            //}

            return false;
        }        

        private String GetImageName(String ImagePath)
        {
            String[] ImageName = ImagePath.Replace(@"\", "$").Split('$');
            String PicName = ImageName[ImageName.Length - 1];
            return PicName.Split('.')[0];            
        }

        private Boolean ValidateRoom()
        {
            errorProvider.Clear();

            //validate mandatory
            if (String.IsNullOrEmpty(txtNumber.Text.Trim()))
            {
                errorProvider.SetError(txtNumber, "Please enter room number.");
                txtNumber.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtNumber.Text.Trim())))
            {
                errorProvider.SetError(txtNumber, "Entered " + txtNumber.Text + " is Invalid.");
                txtNumber.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorProvider.SetError(txtName, "Please enter room name.");
                txtName.Focus();
                return false;
            }
            else if (cboBuilding.SelectedIndex == -1)
            {
                errorProvider.SetError(cboBuilding, "Please select a building.");
                cboBuilding.Focus();
                return false;
            }
            else if (cboFloor.SelectedIndex == -1)
            {
                errorProvider.SetError(cboFloor, "Please select a floor.");
                cboFloor.Focus();
                return false;
            }
            else if (cboCategory.SelectedIndex == -1)
            {
                errorProvider.SetError(cboCategory, "Please select a category.");
                cboCategory.Focus();
                return false;
            }
            else if (cboType.SelectedIndex == -1)
            {
                errorProvider.SetError(cboType, "Please select a type.");
                cboType.Focus();
                return false;
            }

            return true;
        }

        private void PopulateImageList(Byte[] ImgData)
        {
            //lstImage.DataSource = null;
            //this.picPhoto.Image = null;

            //if (this.ImageDtoList != null && this.ImageDtoList.Count > 0)
            //{                
            //    List<String> ImageList = new List<string>();
            //    for (int i = this.ImageDtoList.Count - 1; i >= 0; i--)
            //        ImageList.Add(this.ImageDtoList[i].Name);
                                
            //    lstImage.DataSource = ImageList;

            //    Byte[] Img = ImgData == null ? this.ImageDtoList[this.ImageDtoList.Count - 1].Image : ImgData;
                
            //    //Initialize image variable
            //    Image newImage;
            //    //Read image data into a memory stream
            //    using (MemoryStream ms = new MemoryStream(Img, 0, Img.Length))
            //    {
            //        ms.Write(Img, 0, Img.Length);

            //        //Set image variable value using memory stream.
            //        newImage = Image.FromStream(ms, true);
            //        //set picture
            //        this.picPhoto.Image = newImage;
            //        this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //    }
            //}
        }

        //private bool ValidateUnique(Dto roomDto)
        //{
        //    if (this.cboRoomList == null || this.cboRoomList.Items.Count == 0) return false;

        //    List<Dto> list = (List<Dto>)this.cboRoomList.DataSource;
        //    foreach (Dto dto in list)
        //    {
        //        if (dto.Number == txtNumber.Text.Trim() && dto.Id != roomDto.Id)
        //        {
        //            //Show message
        //            new MessageBox("Room already exists", MessageBox.Type.Information).ShowDialog(this);
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private void Save(Dto roomDto)
        //{
        //    if (!ValidateUnique(roomDto))
        //    {
        //        ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
        //        IRoom room = new RoomServer();
        //        ret = roomDto.Id == 0 ? room.Add(roomDto) : room.Change(roomDto);

        //        base.ShowMessage(ret);//Show message
        //    }
        //}
        
    }
}
