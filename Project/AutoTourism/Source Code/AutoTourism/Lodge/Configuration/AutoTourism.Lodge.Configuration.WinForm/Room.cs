using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using BinAff.Utility;
using BinAff.Core;

using FacadeRoom = AutoTourism.Lodge.Configuration.Facade.Room;
using FacadeBuilding = AutoTourism.Lodge.Configuration.Facade.Building;
using PresentationLibrary = BinAff.Presentation.Library;




namespace AutoTourism.Lodge.Configuration.WinForm
{

    public partial class Room : Form
    {

        private Facade.Room.FormDto formDto;

        //private AutoTourism.Facade.UserManagement.User.Dto userDto = null;
        private List<FacadeRoom.Image.Dto> imageDtoList = new List<FacadeRoom.Image.Dto>();

        public Room()
        {
            InitializeComponent();
            this.formDto = new Facade.Room.FormDto();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadForm();
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateRoom()) return;

            this.Save(); 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.cboRoomList.SelectedIndex == -1)
            {
                //Show message
                //new PresentationLibrary.MessageBox("Please select one room", PresentationLibrary.MessageBox.Type.Alert).ShowDialog(this);
                return;
            }

            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the room.?", "Room Delete",
                            System.Windows.Forms.MessageBoxButtons.YesNo,
                            System.Windows.Forms.MessageBoxIcon.Question)
                              == System.Windows.Forms.DialogResult.Yes)
            {
                FacadeRoom.IRoom room = new FacadeRoom.Server(this.formDto);
                ReturnObject<Boolean> ret = room.Delete(new FacadeRoom.Dto()
                {
                    Id = ((FacadeRoom.Dto)this.cboRoomList.SelectedItem).Id
                });
                
                //new PresentationLibrary.MessageBox(ret.MessageList).ShowDialog(this); //Show message  
            }
            else Clear();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.cboRoomList.SelectedIndex == -1)
            {
                //new PresentationLibrary.MessageBox("Please select one room", PresentationLibrary.MessageBox.Type.Alert).ShowDialog(this);//Show message
                return;
            }

            if (!ValidateRoom()) return;
            this.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.cboRoomList.SelectedIndex == -1)
            {
                //Show message
                //new PresentationLibrary.MessageBox("Please select one room", PresentationLibrary.MessageBox.Type.Alert).ShowDialog(this);
                return;
            }
            FacadeRoom.Dto dto = (FacadeRoom.Dto)this.cboRoomList.SelectedItem;
            if (dto.StatusId == Convert.ToInt64(RoomStatus.Close))
            {
                ReturnObject<Boolean> ret = new ReturnObject<Boolean>()
                {
                    Value = true,
                    MessageList = new List<BinAff.Core.Message>(),
                };
                ret.MessageList.Add(new BinAff.Core.Message("Room is already closed.", BinAff.Core.Message.Type.Information));
                //new PresentationLibrary.MessageBox(ret.MessageList).ShowDialog(this); //Show message 
            }
            else
            {
                //new ReasonDialog(Convert.ToString(EnumDefination.FormName.Room), this.userDto, dto.Id, dto.Building.Id).ShowDialog(this);
                //todo : userInfo Dto needs to be populated
                new ReasonDialog("Room", dto, null).ShowDialog(this);

                LoadForm();
                Clear();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (this.cboRoomList.SelectedIndex == -1)
            {
                //new PresentationLibrary.MessageBox("Please select one room", PresentationLibrary.MessageBox.Type.Alert).ShowDialog(this);//Show message
                return;
            }

            if (((FacadeRoom.Dto)this.cboRoomList.SelectedItem).StatusId != Convert.ToInt64(RoomStatus.Close))
            {
                //new PresentationLibrary.MessageBox("Unable to open room. Only closed rooms can be opened", PresentationLibrary.MessageBox.Type.Error).ShowDialog(this);//Show message
                return;
            }

            FacadeRoom.IRoom room = new FacadeRoom.Server(this.formDto);
            ReturnObject<Boolean> ret = room.Open(new FacadeRoom.Dto()
            {
                Id = ((FacadeRoom.Dto)this.cboRoomList.SelectedItem).Id,
                Building = new FacadeBuilding.Dto()
                {
                    Id = ((FacadeRoom.Dto)this.cboRoomList.SelectedItem).Building.Id
                }
            });

            //new PresentationLibrary.MessageBox(ret.MessageList).ShowDialog(this); //Show message 
            LoadForm();
            Clear();
        }

        private void cboBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuilding.SelectedIndex != -1)
            {
                FacadeBuilding.Dto dto = (FacadeBuilding.Dto)cboBuilding.SelectedItem;
                if (dto.FloorList != null && dto.FloorList.Count > 0)
                {
                    this.cboFloor.DataSource = null;
                    this.cboFloor.DataSource = dto.FloorList;
                    this.cboFloor.DisplayMember = "Name";
                    this.cboFloor.ValueMember = "Id";
                }
                else this.cboFloor.DataSource = null;
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            try
            {
                System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
                open.InitialDirectory = "c:\\";
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String ImgName = GetImageName(open.FileName);

                    if (IsImageExist(ImgName, (List<String>)this.lstImage.DataSource))
                        errorProvider.SetError(lstImage, "Image already included.");
                    else
                    {
                        //POPULATE this.ImageDtoList                        
                        Byte[] img = Converter.ReadFile(open.FileName);
                        this.imageDtoList.Add(new FacadeRoom.Image.Dto
                        {
                            Name = GetImageName(open.FileName),
                            Image = Converter.ReadFile(open.FileName),
                        });

                        PopulateImageList(img);

                    }

                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (lstImage.SelectedItems.Count == 0) return;

            Boolean blnExists = false;
            List<FacadeRoom.Image.Dto> imageDtoNewList = new List<FacadeRoom.Image.Dto>();
            List<String> ImageList = new List<string>();

            if (lstImage.SelectedItems.Count > 0)
            {
                foreach (FacadeRoom.Image.Dto dto in this.imageDtoList)
                {
                    blnExists = false;
                    foreach (String imgName in lstImage.SelectedItems)
                    {
                        if (dto.Name == imgName)
                        {
                            blnExists = true;
                            break;
                        }
                    }

                    if (!blnExists) imageDtoNewList.Add(dto);
                }

                this.imageDtoList = new List<FacadeRoom.Image.Dto>();
                this.imageDtoList = imageDtoNewList;

                for (int i = this.imageDtoList.Count - 1; i >= 0; i--)
                    ImageList.Add(this.imageDtoList[i].Name);

                lstImage.DataSource = null;
                this.picPhoto.Image = null;

                if (ImageList != null && ImageList.Count > 0)
                {
                    lstImage.DataSource = ImageList;
                    lstImage.SelectedIndex = 0;
                }
            }
        }

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstImage.SelectedIndex != -1)
            {
                foreach (FacadeRoom.Image.Dto dto in this.imageDtoList)
                {
                    if (dto.Name == (String)this.lstImage.SelectedItem)
                    {
                        //Initialize image variable
                        Image newImage;
                        //Read image data into a memory stream
                        using (MemoryStream ms = new MemoryStream(dto.Image, 0, dto.Image.Length))
                        {
                            ms.Write(dto.Image, 0, dto.Image.Length);

                            //Set image variable value using memory stream.
                            newImage = Image.FromStream(ms, true);
                            //set picture
                            this.picPhoto.Image = newImage;
                            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        }

                        break;
                    }

                }
            }
        }

        private void cboRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoomList.SelectedIndex != -1)
            {
                FacadeRoom.Dto dto = (FacadeRoom.Dto)cboRoomList.SelectedItem;
                txtNumber.Text = dto.Number;
                txtName.Text = dto.Name;
                txtDesc.Text = dto.Description;

                if (dto.StatusId == 10001)
                    lblRoomStatus.Text = "Open";
                else if (dto.StatusId == 10002)
                    lblRoomStatus.Text = "Closed";
                else if (dto.StatusId == 10003)
                    lblRoomStatus.Text = "Occupied";

                //Building Dropdown
                List<FacadeBuilding.Dto> buildingDtoList = (List<FacadeBuilding.Dto>)cboBuilding.DataSource;
                if (buildingDtoList != null && buildingDtoList.Count > 0)
                {
                    for (int i = 0; i < buildingDtoList.Count; i++)
                    {
                        if (buildingDtoList[i].Id == dto.Building.Id)
                        {
                            cboBuilding.SelectedIndex = i;
                            break;
                        }
                    }
                }

                //Floor dropdown
                List<Table> floorList = (List<Table>)cboFloor.DataSource;
                if (floorList != null && floorList.Count > 0)
                {
                    for (int i = 0; i < floorList.Count; i++)
                    {
                        if (floorList[i].Id == dto.Floor.Id)
                        {
                            cboFloor.SelectedIndex = i;
                            break;
                        }
                    }
                }

                //Category Dropdown
                List<FacadeRoom.Category.Dto> categoryList = (List<FacadeRoom.Category.Dto>)cboCategory.DataSource;
                if (categoryList != null && categoryList.Count > 0)
                {
                    for (int i = 0; i < categoryList.Count; i++)
                    {
                        if (categoryList[i].Id == dto.Category.Id)
                        {
                            cboCategory.SelectedIndex = i;
                            break;
                        }
                    }
                }

                //Type Dropdown
                List<FacadeRoom.Type.Dto> typeList = (List<FacadeRoom.Type.Dto>)cboType.DataSource;
                if (typeList != null && typeList.Count > 0)
                {
                    for (int i = 0; i < typeList.Count; i++)
                    {
                        if (typeList[i].Id == dto.Type.Id)
                        {
                            cboType.SelectedIndex = i;
                            break;
                        }
                    }
                }

                chkIsAC.Checked = dto.IsAirconditioned;
                //chkIsDormitory.Checked = dto.IsDormitory;

                this.imageDtoList = dto.ImageList;
                PopulateImageList(null);
            }
        }

        private void LoadForm()
        {
            new FacadeRoom.Server(this.formDto).LoadForm();

            //populate Room List            
            this.cboRoomList.DataSource = null;
            if (this.formDto.RoomList != null && this.formDto.RoomList.Count > 0)
            {
                this.cboRoomList.DataSource = this.formDto.RoomList;
                this.cboRoomList.ValueMember = "Id";
                this.cboRoomList.DisplayMember = "Name";
                this.cboRoomList.SelectedIndex = -1;
            }

            //populate Building List
            this.cboBuilding.DataSource = null;
            if (this.formDto.BuildingList != null && this.formDto.BuildingList.Count > 0)
            {
                this.cboBuilding.DataSource = this.formDto.BuildingList;
                this.cboBuilding.ValueMember = "Id";
                this.cboBuilding.DisplayMember = "Name";
                this.cboBuilding.SelectedIndex = -1;
            }

            this.cboCategory.DataSource = null;
            if (this.formDto.CategoryList != null && this.formDto.CategoryList.Count > 0)
            {
                this.cboCategory.DataSource = this.formDto.CategoryList;
                this.cboCategory.ValueMember = "Id";
                this.cboCategory.DisplayMember = "Name";
                this.cboCategory.SelectedIndex = -1;
            }

            this.cboType.DataSource = null;
            if (this.formDto.TypeList != null && this.formDto.TypeList.Count > 0)
            {
                this.cboType.DataSource = this.formDto.TypeList;
                this.cboType.ValueMember = "Id";
                this.cboType.DisplayMember = "Name";
                this.cboType.SelectedIndex = -1;
            }
        }

        private void Clear()
        {
            this.lblRoomStatus.Text = String.Empty;
            this.cboRoomList.SelectedIndex = -1;
            this.txtNumber.Text = String.Empty;
            this.txtName.Text = String.Empty;
            this.txtDesc.Text = String.Empty;
            this.cboBuilding.SelectedIndex = -1;
            this.cboFloor.DataSource = null;
            this.cboCategory.SelectedIndex = -1;
            this.cboType.SelectedIndex = -1;
            this.chkIsAC.Checked = false;          
            this.picPhoto.Image = null;
            this.lstImage.DataSource = null;
            this.imageDtoList = new List<FacadeRoom.Image.Dto>();
        }
      
        private Boolean IsImageExist(String roomImageName, List<String> imageList)
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

        private String GetImageName(String imagePath)
        {
            String[] imageName = imagePath.Replace(@"\", "$").Split('$');
            return imageName[imageName.Length - 1].Split('.')[0];            
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
            //else if (!(new Regex(@"^[0-9]*$").IsMatch(txtNumber.Text.Trim())))
            //{
            //    errorProvider.SetError(txtNumber, "Entered " + txtNumber.Text + " is Invalid.");
            //    txtNumber.Focus();
            //    return false;
            //}
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

        private void PopulateImageList(Byte[] image)
        {
            lstImage.DataSource = null;
            this.picPhoto.Image = null;

            if (this.imageDtoList != null && this.imageDtoList.Count > 0)
            {
                List<String> ImageList = new List<string>();
                for (int i = this.imageDtoList.Count - 1; i >= 0; i--)
                    ImageList.Add(this.imageDtoList[i].Name);

                lstImage.DataSource = ImageList;

                Byte[] Img = image == null ? this.imageDtoList[this.imageDtoList.Count - 1].Image : image;

                //Initialize image variable
                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(Img, 0, Img.Length))
                {
                    ms.Write(Img, 0, Img.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                    //set picture
                    this.picPhoto.Image = newImage;
                    this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void Save()
        {
            this.formDto.Room = new FacadeRoom.Dto
            {
                Id = this.cboRoomList.SelectedItem == null ? 0 : ((FacadeRoom.Dto)this.cboRoomList.SelectedItem).Id,
                Number = this.txtNumber.Text.Trim(),
                Name = this.txtName.Text.Trim(),
                Description = this.txtDesc.Text.Trim(),
                Building = cboBuilding.SelectedItem == null ? null : new FacadeBuilding.Dto
                {
                    Id = ((FacadeBuilding.Dto)cboBuilding.SelectedItem).Id,
                },
                Floor = (Table)cboFloor.SelectedItem,
                Category = cboCategory.SelectedItem == null ? null : new FacadeRoom.Category.Dto
                {
                    Id = ((FacadeRoom.Category.Dto)cboCategory.SelectedItem).Id,
                },
                Type = cboType.SelectedItem == null ? null : new FacadeRoom.Type.Dto
                {
                    Id = ((FacadeRoom.Type.Dto)cboType.SelectedItem).Id,
                },
                IsAirconditioned = this.chkIsAC.Checked,
                ImageList = (this.imageDtoList == null || this.imageDtoList.Count == 0) ? null : imageDtoList,
                StatusId = Convert.ToInt64(RoomStatus.Open)             
            };

            if (!ValidateUnique(this.formDto.Room))
            {               
                FacadeRoom.Server facade = new FacadeRoom.Server(this.formDto);                
                if (this.formDto.Room.Id == 0)                
                    facade.Add();
                else                
                    facade.Change();

                if (facade.IsError)
                {
                    //Show message
                    MessageBox.Show(this, "Error"); //Change
                    return;
                }
                else                
                    MessageBox.Show(this, "Data saved successfully", "Splash", MessageBoxButtons.OK, MessageBoxIcon.Information);                

                this.LoadForm();
                this.Clear();
            }
        }
        
        private bool ValidateUnique(FacadeRoom.Dto roomDto)
        {
            if (this.cboRoomList == null || this.cboRoomList.Items.Count == 0) return false;

            List<FacadeRoom.Dto> list = (List<FacadeRoom.Dto>)this.cboRoomList.DataSource;
            foreach (FacadeRoom.Dto dto in list)
            {
                if (dto.Number == txtNumber.Text.Trim() && dto.Id != roomDto.Id)
                {
                    //Show message                    
                    //new PresentationLibrary.MessageBox("Room already exists.", PresentationLibrary.MessageBox.Type.Information).ShowDialog(this);
                    return true;
                }
            }
            return false;
        }
        
        public enum RoomStatus
        {          
            Open = 10001,
            Close = 10002,
            Occupied = 10003
        }

    }

}
