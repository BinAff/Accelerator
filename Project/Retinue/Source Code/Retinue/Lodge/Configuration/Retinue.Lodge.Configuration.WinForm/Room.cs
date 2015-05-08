using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using BinAff.Utility;
using BinAff.Core;
using BinAff.Presentation.Library.Extension;

using FacadeRoom = Retinue.Lodge.Configuration.Facade.Room;
using FacadeBuilding = Retinue.Lodge.Configuration.Facade.Building;
using System.Text.RegularExpressions;

namespace Retinue.Lodge.Configuration.WinForm
{

    public partial class Room : Form
    {

        private Facade.Room.FormDto formDto;

        private List<FacadeRoom.Image.Dto> imageDtoList = new List<FacadeRoom.Image.Dto>();

        public Room()
        {
            InitializeComponent();
            this.formDto = new Facade.Room.FormDto();
        }

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
            if (!ValidateForm()) return;
            this.Save(); 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.cboRoomList.SelectedIndex == -1) return;

            if (MessageBox.Show("Are you sure you want to delete the room.?", "Room Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                FacadeRoom.IRoom room = new FacadeRoom.Server(this.formDto);
                ReturnObject<Boolean> ret = room.Delete(new FacadeRoom.Dto
                {
                    Id = ((FacadeRoom.Dto)this.cboRoomList.SelectedItem).Id
                });

                //new PresentationLibrary.MessageBox(ret.MessageList).ShowDialog(this); //Show message
            }
            else
            {
                Clear();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.cboRoomList.SelectedIndex == -1)
            {
                //new PresentationLibrary.MessageBox("Please select one room", PresentationLibrary.MessageBox.Type.Alert).ShowDialog(this);//Show message
                return;
            }

            if (!ValidateForm()) return;
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
            if (cboBuilding.SelectedItem != null)
            {
                this.cboFloor.Enabled = true;
                this.cboFloor.Bind((this.cboBuilding.SelectedItem as FacadeBuilding.Dto).FloorList, "Name");
            }
            else
            {
                this.cboFloor.Enabled = false;
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
                        Image newImage;
                        using (MemoryStream ms = new MemoryStream(dto.Image, 0, dto.Image.Length))
                        {
                            ms.Write(dto.Image, 0, dto.Image.Length);
                            newImage = Image.FromStream(ms, true);
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
            if (cboRoomList.SelectedItem != null)
            {
                FacadeRoom.Dto dto = cboRoomList.SelectedItem as FacadeRoom.Dto;
                this.txtNumber.Text = dto.Number;
                this.txtName.Text = dto.Name;
                this.txtDesc.Text = dto.Description;
                this.chkIsAC.Checked = dto.IsAirconditioned;
                this.txtAccomodation.Text = dto.Accomodation.ToString();
                this.txtExtraAccomodation.Text = dto.ExtraAccomodation.ToString();

                if (dto.StatusId == 10001)
                    lblRoomStatus.Text = "Open";
                else if (dto.StatusId == 10002)
                    lblRoomStatus.Text = "Closed";
                else if (dto.StatusId == 10003)
                    lblRoomStatus.Text = "Occupied";

                this.cboBuilding.SelectedItem = this.formDto.BuildingList.FindLast((p) => { return p.Id == dto.Building.Id; });
                this.cboFloor.SelectedItem = (this.cboBuilding.SelectedItem as FacadeBuilding.Dto).FloorList.FindLast((p) => { return p.Id == dto.Floor.Id; });
                this.cboCategory.SelectedItem = this.formDto.CategoryList.FindLast((p) => { return p.Id == dto.Category.Id; });
                this.cboType.SelectedItem = this.formDto.TypeList.FindLast((p) => { return p.Id == dto.Type.Id; });
                //chkIsDormitory.Checked = dto.IsDormitory;

                this.imageDtoList = dto.ImageList;
                PopulateImageList(null);
            }
        }

        private void LoadForm()
        {
            new FacadeRoom.Server(this.formDto).LoadForm();
            this.cboRoomList.Bind(this.formDto.DtoList, "Display");
            this.cboBuilding.Bind(this.formDto.BuildingList, "Name");
            this.cboCategory.Bind(this.formDto.CategoryList, "Name");
            this.cboType.Bind(this.formDto.TypeList, "Name");
        }

        private void Clear()
        {
            this.lblRoomStatus.Text = String.Empty;
            this.cboRoomList.SelectedIndex = -1;
            this.txtNumber.Text = String.Empty;
            this.txtName.Text = String.Empty;
            this.txtDesc.Text = String.Empty;
            this.cboBuilding.SelectedItem = null;
            this.cboFloor.SelectedItem = null;
            this.cboFloor.Enabled = false;
            this.cboCategory.SelectedItem = null;
            this.cboType.SelectedItem = null;
            this.txtAccomodation.Text = String.Empty;
            this.txtExtraAccomodation.Text = String.Empty;
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

        private Boolean ValidateForm()
        {
            this.errorProvider.Clear();

            if (String.IsNullOrEmpty(this.txtNumber.Text.Trim()))
            {
                this.errorProvider.SetError(txtNumber, "Please enter room number.");
                txtNumber.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtNumber.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtNumber, "Please enter numeric value.");
                this.txtNumber.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.errorProvider.SetError(txtName, "Please enter room name.");
                this.txtName.Focus();
                return false;
            }
            else if (this.cboBuilding.SelectedIndex == -1)
            {
                this.errorProvider.SetError(cboBuilding, "Please select a building.");
                this.cboBuilding.Focus();
                return false;
            }
            else if (this.cboFloor.SelectedIndex == -1)
            {
                this.errorProvider.SetError(cboFloor, "Please select a floor.");
                this.cboFloor.Focus();
                return false;
            }
            else if (this.cboCategory.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.cboCategory, "Please select a category.");
                this.cboCategory.Focus();
                return false;
            }
            else if (this.cboType.SelectedIndex == -1)
            {
                this.errorProvider.SetError(this.cboType, "Please select a type.");
                this.cboType.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtAccomodation.Text))
            {
                this.errorProvider.SetError(this.txtAccomodation, "Please enter accomodation.");
                this.txtAccomodation.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtAccomodation.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtAccomodation, "Please enter numeric value.");
                this.txtAccomodation.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtExtraAccomodation.Text))
            {
                this.errorProvider.SetError(this.txtExtraAccomodation, "Please enter extra accomodation.");
                this.txtExtraAccomodation.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtExtraAccomodation.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtExtraAccomodation, "Please enter numeric value.");
                this.txtExtraAccomodation.Focus();
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
            this.formDto.Dto = new FacadeRoom.Dto
            {
                Id = this.cboRoomList.SelectedItem == null ? 0 : (this.cboRoomList.SelectedItem as FacadeRoom.Dto).Id,
                Number = this.txtNumber.Text.Trim(),
                Name = this.txtName.Text.Trim(),
                Description = this.txtDesc.Text.Trim(),
                Building = this.cboBuilding.SelectedItem as FacadeBuilding.Dto,
                Floor = cboFloor.SelectedItem as Table,
                Category = cboCategory.SelectedItem as FacadeRoom.Category.Dto,
                Type = cboType.SelectedItem as FacadeRoom.Type.Dto,
                Accomodation = Convert.ToInt16(this.txtAccomodation.Text.Trim()),
                ExtraAccomodation = Convert.ToInt16(this.txtExtraAccomodation.Text.Trim()),
                IsAirconditioned = this.chkIsAC.Checked,
                ImageList = (this.imageDtoList == null || this.imageDtoList.Count == 0) ? null : imageDtoList,
                StatusId = Convert.ToInt64(RoomStatus.Open)             
            };

            if (ValidateUnique(this.formDto.Dto))
            {
                new BinAff.Presentation.Library.MessageBox
                {
                    DialogueType = BinAff.Presentation.Library.MessageBox.Type.Error,
                    Heading = "Lodge",
                }.Show("Duplicate room entry!!");
            }
            else {               
                FacadeRoom.Server facade = new FacadeRoom.Server(this.formDto);                
                if (this.formDto.Dto.Id == 0)                
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

            foreach (FacadeRoom.Dto dto in this.cboRoomList.Items)
            {
                if (dto.Number == txtNumber.Text.Trim() && dto.Id != roomDto.Id && dto.Building.Id == roomDto.Building.Id)
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
