using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;

using LodgeFacade = AutoTourism.Lodge.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using CustomerFacade = AutoTourism.Customer.Facade;
using PresentationLibrary = BinAff.Presentation.Library;

using AutoTourism.Customer.WinForm;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationForm : PresentationLibrary.Form
    {      

        private LodgeFacade.RoomReservation.Dto dto;
        private LodgeFacade.RoomReservation.FormDto formDto;
        private RuleFacade.ConfigurationRuleDto configurationRuleDto;

        public RoomReservationForm(LodgeFacade.RoomReservation.Dto dto)
        {
            InitializeComponent();
            this.dto = dto;
        }

        private void RoomBookingForm_Load(object sender, System.EventArgs e)
        {          
            //set default date format
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case

            dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dtFromTime.ShowUpDown = true;

            this.formDto = new LodgeFacade.RoomReservation.FormDto() { Dto = this.dto };

            LoadForm();

            //dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //if (this.ruleDto == null || this.ruleDto.ConfigurationRule == null || this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
            //    dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
            //else
            //    dtFrom.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;

            //dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            //dtFromTime.ShowUpDown = true;

            //if (this.dto != null) LoadForm();
        }  

        private void btnPickCustomer_Click(object sender, System.EventArgs e)
        {
            Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerRegister, AutoTourism.Customer.WinForm", true);
            Form form = (Form)Activator.CreateInstance(type);
            form.ShowDialog(this);
            
            if (form.Tag != null)
            {                
                this.dto.Customer = form.Tag as CustomerFacade.Dto;

                String Name = (this.dto.Customer.Initial == null ? String.Empty : this.dto.Customer.Initial.Name);
                Name += (Name == String.Empty) ? (this.dto.Customer.FirstName == null ? String.Empty : this.dto.Customer.FirstName) : " " + (this.dto.Customer.FirstName == null ? String.Empty : this.dto.Customer.FirstName);
                Name += (Name == String.Empty) ? (this.dto.Customer.MiddleName == null ? String.Empty : this.dto.Customer.MiddleName) : " " + (this.dto.Customer.MiddleName == null ? String.Empty : this.dto.Customer.MiddleName);
                Name += (Name == String.Empty) ? (this.dto.Customer.LastName == null ? String.Empty : this.dto.Customer.LastName) : " " + (this.dto.Customer.LastName == null ? String.Empty : this.dto.Customer.LastName);

                txtName.Text = Name;
                lstContact.DataSource = this.dto.Customer.ContactNumberList;
                lstContact.DisplayMember = "Name";
                lstContact.ValueMember = "Id";
                lstContact.SelectedIndex = -1;
                txtAdds.Text = this.dto.Customer.Address;
                txtEmail.Text = this.dto.Customer.Email;
            }
            
        }
        
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            LodgeConfigurationFacade.Room.Dto roomDto = null;
            if (cboRoomList.SelectedIndex != -1)
            {
                roomDto = (LodgeConfigurationFacade.Room.Dto)cboRoomList.SelectedItem;
                AddToList(roomDto, cboSelectedRoom);
                RemoveFromList(roomDto, cboRoomList);
            }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            LodgeConfigurationFacade.Room.Dto roomDto = null;
            if (cboSelectedRoom.SelectedIndex != -1)
            {
                roomDto = (LodgeConfigurationFacade.Room.Dto)cboSelectedRoom.SelectedItem;
                AddToList(roomDto, cboRoomList);
                RemoveFromList(roomDto, cboSelectedRoom);
            }
        }

        private void LoadForm()
        {            
            BinAff.Facade.Library.Server facade = new LodgeFacade.RoomReservation.ReservationServer(formDto);
            facade.LoadForm();

            this.configurationRuleDto = formDto.configurationRuleDto;
            if(this.configurationRuleDto.DateFormat != null)
                dtFrom.CustomFormat = this.configurationRuleDto.DateFormat;
            
            //this.PopulateRoomList();

            //--populate room category
            this.cboCategory.DataSource = null;
            if (this.formDto.CategoryList != null && this.formDto.CategoryList.Count > 0)
            {
                this.cboCategory.DataSource = this.formDto.CategoryList;
                this.cboCategory.ValueMember = "Id";
                this.cboCategory.DisplayMember = "Name";
                this.cboCategory.SelectedIndex = -1;
            }

            //--populate room type
            this.cboType.DataSource = null;
            if (this.formDto.TypeList != null && this.formDto.TypeList.Count > 0)
            {
                this.cboType.DataSource = this.formDto.TypeList;
                this.cboType.ValueMember = "Id";
                this.cboType.DisplayMember = "Name";
                this.cboType.SelectedIndex = -1;
            }

            //populate customer data
            if (this.dto != null && this.dto.Id > 0)
            {               
                if (this.dto.Customer != null)
                {
                    String Name = (this.dto.Customer.Initial == null ? String.Empty : this.dto.Customer.Initial.Name);
                    Name += (Name == String.Empty) ? (this.dto.Customer.FirstName == null ? String.Empty : this.dto.Customer.FirstName) : " " + (this.dto.Customer.FirstName == null ? String.Empty : this.dto.Customer.FirstName);
                    Name += (Name == String.Empty) ? (this.dto.Customer.MiddleName == null ? String.Empty : this.dto.Customer.MiddleName) : " " + (this.dto.Customer.MiddleName == null ? String.Empty : this.dto.Customer.MiddleName);
                    Name += (Name == String.Empty) ? (this.dto.Customer.LastName == null ? String.Empty : this.dto.Customer.LastName) : " " + (this.dto.Customer.LastName == null ? String.Empty : this.dto.Customer.LastName);

                    txtName.Text = Name;
                    lstContact.DataSource = this.dto.Customer.ContactNumberList;
                    lstContact.DisplayMember = "Name";
                    lstContact.ValueMember = "Id";
                    lstContact.SelectedIndex = -1;
                    txtAdds.Text = this.dto.Customer.Address;
                    txtEmail.Text = this.dto.Customer.Email;
                }

                //populate booking data
                if (!ValidationRule.IsMinimumDate(this.dto.BookingFrom))
                {
                    dtFrom.Value = this.dto.BookingFrom;
                    dtFromTime.Value = this.dto.BookingFrom;
                }
                txtDays.Text = this.dto.NoOfDays == 0 ? String.Empty : this.dto.NoOfDays.ToString();
                txtPersons.Text = this.dto.NoOfPersons == 0 ? String.Empty : this.dto.NoOfPersons.ToString();
                txtRooms.Text = this.dto.NoOfRooms == 0 ? String.Empty : this.dto.NoOfRooms.ToString();
                txtAdvance.Text = this.dto.Advance == 0 ? String.Empty : Converter.ConvertToIndianCurrency(this.dto.Advance);
                cboSelectedRoom.DataSource = this.dto.RoomList;
                cboSelectedRoom.DisplayMember = "Number";
                cboSelectedRoom.ValueMember = "Id";
                cboSelectedRoom.SelectedIndex = -1;
                
                if (this.dto.RoomCategory != null && this.dto.RoomCategory.Id > 0)
                {
                    for (int i = 0; i < cboCategory.Items.Count; i++)
                    {
                        if (this.dto.RoomCategory.Id == ((LodgeConfigurationFacade.Room.Category.Dto)cboCategory.Items[i]).Id)
                        {
                            cboCategory.SelectedIndex = i;
                            break;
                        }
                    }
                }

                if (this.dto.RoomType != null && this.dto.RoomType.Id > 0)
                {
                    for (int i = 0; i < cboType.Items.Count; i++)
                    {
                        if (this.dto.RoomType.Id == ((LodgeConfigurationFacade.Room.Type.Dto)cboType.Items[i]).Id)
                        {
                            cboType.SelectedIndex = i;
                            break;
                        }
                    }
                }

                chkIsAC.Checked = this.dto.IsAC;

                if (this.dto.BookingStatusId == Convert.ToInt64(LodgeReservationStatus.open))
                {
                    txtReservationStatus.Text = "Open";
                    btnCancelOpen.Text = "Cancel";
                }
                else if (this.dto.BookingStatusId == Convert.ToInt64(LodgeReservationStatus.cancel))
                {
                    txtReservationStatus.Text = "Cancel";
                    btnCancelOpen.Text = "Re Open";
                }
                

                //if ((Convert.ToInt64(LodgeReservationStatus.open) != this.dto.BookingStatusId) && (this.dto.BookingStatusId != 0))
                //    btnOk.Enabled = false;
            }
        }

        //private void PopulateRoomList()
        //{
        //    this.cboRoomList.DataSource = null;
        //    List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();

        //    if (this.formDto.roomList != null && this.formDto.roomList.Count > 0)
        //    {
        //        if (this.dto.RoomList == null || this.dto.RoomList.Count == 0)
        //            RoomList = this.formDto.roomList;
        //        else
        //        {
        //            foreach (LodgeConfigurationFacade.Room.Dto roomDto in this.formDto.roomList)
        //            {
        //                Boolean blnNotExist = true;
        //                foreach (LodgeConfigurationFacade.Room.Dto bookedRoomDto in this.dto.RoomList)
        //                {
        //                    if (roomDto.Id == bookedRoomDto.Id)
        //                    {
        //                        blnNotExist = false;
        //                        break;
        //                    }
        //                }
        //                if (blnNotExist) RoomList.Add(roomDto);
        //            }
        //        }

        //        this.cboRoomList.DataSource = RoomList;
        //        this.cboRoomList.DisplayMember = "Number";
        //        this.cboRoomList.ValueMember = "Id";
        //        this.cboRoomList.SelectedIndex = -1;
        //    }
        //}

        private void Clear()
        {
            this.Tag = null;
            txtName.Text = String.Empty;
            lstContact.DataSource = null;
            txtAdds.Text = String.Empty;
            txtEmail.Text = String.Empty;

            txtDays.Text = String.Empty;
            txtPersons.Text = String.Empty;
            txtRooms.Text = String.Empty;
            txtAdvance.Text = String.Empty;
            cboSelectedRoom.DataSource = null;

            dtFrom.Value = DateTime.Now;
            dtFromTime.Value = DateTime.Now;

            //populate booking data
            if (this.dto != null)
            {
                if (!ValidationRule.IsMinimumDate(this.dto.BookingFrom))
                {
                    dtFrom.Value = this.dto.BookingFrom;
                    dtFromTime.Value = this.dto.BookingFrom;
                }
            }

            //this.PopulateRoomList();
            this.PopulateFilteredRoomList();
        }

        private void AddToList(LodgeConfigurationFacade.Room.Dto roomDto, System.Windows.Forms.ListControl cboRoom)
        {
            Boolean Include = false;
            List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (((System.Windows.Forms.ComboBox)cboRoom).Items.Count == 0)
                RoomList.Add(roomDto);
            else
            {
                foreach (LodgeConfigurationFacade.Room.Dto dto in (List<LodgeConfigurationFacade.Room.Dto>)cboRoom.DataSource)
                {
                    if (dto.Id < roomDto.Id)
                        RoomList.Add(dto);
                    else
                    {
                        RoomList.Add(roomDto);
                        RoomList.Add(dto);
                        Include = true;
                    }
                }
                if (!Include) RoomList.Add(roomDto);
            }

            cboRoom.DataSource = null;
            cboRoom.DataSource = RoomList;
            cboRoom.DisplayMember = "Number";
            cboRoom.ValueMember = "Id";
            cboRoom.SelectedIndex = -1;
        }

        private void RemoveFromList(LodgeConfigurationFacade.Room.Dto roomDto, System.Windows.Forms.ListControl cboRoom)
        {
            List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();
            foreach (LodgeConfigurationFacade.Room.Dto dto in (List<LodgeConfigurationFacade.Room.Dto>)cboRoom.DataSource)
                if (dto.Id != roomDto.Id) RoomList.Add(dto);

            cboRoom.DataSource = null;
            cboRoom.DataSource = RoomList;
            cboRoom.DisplayMember = "Number";
            cboRoom.ValueMember = "Id";
            cboRoom.SelectedIndex = -1;
        }

        private Boolean SaveReservationData()
        {
            Boolean retVal = this.ValidateBooking();

            if (retVal)
            {
                if (this.dto == null) this.dto = new LodgeFacade.RoomReservation.Dto();
                this.dto.Id = this.dto == null ? 0 : this.dto.Id;
                this.dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);
                this.dto.NoOfDays = Convert.ToInt16(txtDays.Text);
                this.dto.NoOfPersons = Convert.ToInt16(txtPersons.Text);
                this.dto.NoOfRooms = Convert.ToInt16(txtRooms.Text);
                this.dto.Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtAdvance.Text.Replace(",", ""));
                this.dto.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>)[this.cboCategory.SelectedIndex].Id };
                this.dto.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>)[this.cboType.SelectedIndex].Id };
                this.dto.IsAC = this.chkIsAC.Checked;
                this.dto.Customer = new CustomerFacade.Dto()
                    {
                        Id = this.dto.Customer.Id,
                        FirstName = this.dto.Customer.FirstName,
                        MiddleName = this.dto.Customer.MiddleName,
                        LastName = this.dto.Customer.LastName,
                        Address = this.dto.Customer.Address,
                        City = this.dto.Customer.City,
                        Pin = this.dto.Customer.Pin,
                        Email = this.dto.Customer.Email,
                        IdentityProofType = new Table
                        {
                            Id = this.dto.Customer.IdentityProofType.Id,
                            Name = this.dto.Customer.IdentityProofType.Name
                        },
                        IdentityProofName = this.dto.Customer.IdentityProofName,
                        State = new Table
                        {
                            Id = this.dto.Customer.State.Id,
                            Name = this.dto.Customer.State.Name
                        },
                        ContactNumberList = this.dto.Customer.ContactNumberList,
                        Initial = new Table 
                        {
                            Id = this.dto.Customer.Initial.Id,
                            Name = this.dto.Customer.Initial.Name
                        }                        
                    };
                this.dto.RoomList = this.cboSelectedRoom.Items.Count == 0 ? null : (List<LodgeConfigurationFacade.Room.Dto>)this.cboSelectedRoom.DataSource;

                LodgeFacade.RoomReservation.FormDto formDto = new LodgeFacade.RoomReservation.FormDto()
                {
                    Dto = this.dto,
                };
                BinAff.Facade.Library.Server facade = new LodgeFacade.RoomReservation.ReservationServer(formDto);
                if (formDto.Dto.Id == 0)
                {
                    facade.Add();
                }
                else
                {
                    facade.Change();
                }

                if (facade.IsError)
                {
                    retVal = false;
                    new PresentationLibrary.MessageBox
                    {
                        DialogueType = facade.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                        Heading = "Splash",
                    }.Show(facade.DisplayMessageList);
                }
            }
            return retVal;
        }

        private Boolean ValidateBooking()
        {
            Boolean retVal = true;
            errorProvider.Clear();

            if (txtName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(btnPickCustomer, "Select a customer for reservation.");
                btnPickCustomer.Focus();
                return false;
            }
            else if (ValidationRule.IsDateLessThanToday(dtFrom.Value))
            {
                errorProvider.SetError(dtFrom, "Booking date cannot be less than today.");
                dtFrom.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtDays.Text.Trim()))
            {
                errorProvider.SetError(txtDays, "Please enter days.");
                txtDays.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())))
            {
                errorProvider.SetError(txtDays, "Entered " + txtDays.Text + " is Invalid.");
                txtDays.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtPersons.Text.Trim()))
            {
                errorProvider.SetError(txtPersons, "Please enter persons.");
                txtPersons.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtPersons.Text.Trim())))
            {
                errorProvider.SetError(txtPersons, "Entered " + txtPersons.Text + " is Invalid.");
                txtPersons.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtRooms.Text.Trim()))
            {
                errorProvider.SetError(txtRooms, "Please enter rooms.");
                txtRooms.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtRooms.Text.Trim())))
            {
                errorProvider.SetError(txtRooms, "Entered " + txtRooms.Text + " is Invalid.");
                txtRooms.Focus();
                return false;
            }
            else if (!ValidationRule.IsDecimal(txtAdvance.Text.Trim() == String.Empty ? "0" : txtAdvance.Text.Trim().Replace(",", "")))
            {
                errorProvider.SetError(txtAdvance, "Entered " + txtAdvance.Text + " is Invalid.");
                txtAdvance.Focus();
                return false;
            }
            else if (ValidationRule.IsDateLessThanToday(dtFrom.Value))
            {
                errorProvider.SetError(dtFrom, "Booking from date cannot be less than today.");
                dtFrom.Focus();
                return false;
            }
            else if (cboSelectedRoom.Items.Count > Convert.ToInt32(txtRooms.Text.Trim()))
            {
                errorProvider.SetError(cboSelectedRoom, "Selected rooms cannot be greater than the no of rooms.");
                cboSelectedRoom.Focus();
                return false;
            }

            return retVal;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.SaveReservationData())
            {
                base.IsModified = true;
                this.Close();
            }
        }
              
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.formDto.Dto.Id > 0)
                LoadForm();
            else
                this.Clear();
        }

        private void btnCancelOpen_Click(object sender, EventArgs e)
        {
            if (this.formDto != null && this.formDto.Dto != null)
            {
                this.formDto.Dto.BookingStatusId = btnCancelOpen.Text == "Cancel" ? Convert.ToInt64(LodgeReservationStatus.cancel) : Convert.ToInt64(LodgeReservationStatus.open);                              
                LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(this.formDto);
                reservation.ChangeReservationStatus();
                base.IsModified = true;
                this.Close();
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateFilteredRoomList();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateFilteredRoomList();
        }

        private void chkIsAC_CheckedChanged(object sender, EventArgs e)
        {
            this.PopulateFilteredRoomList();
        }

        private void PopulateFilteredRoomList()
        {
            this.cboRoomList.DataSource = null;
            List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (this.formDto.roomList != null && this.formDto.roomList.Count > 0)
            {
                foreach (LodgeConfigurationFacade.Room.Dto roomDto in this.formDto.roomList)
                {
                    if (this.ValidateRoom(roomDto))
                        RoomList.Add(roomDto);
                }
            }


            List<LodgeConfigurationFacade.Room.Dto> SelectedRoomList = new List<LodgeConfigurationFacade.Room.Dto>();
            List<LodgeConfigurationFacade.Room.Dto> AvailableRoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (RoomList != null && RoomList.Count > 0)
            {
                if (this.dto.RoomList == null || this.dto.RoomList.Count == 0)
                {
                    SelectedRoomList = null;
                    AvailableRoomList = RoomList;
                }
                else
                {
                    Boolean isSelected = false;
                    foreach (LodgeConfigurationFacade.Room.Dto roomDto in RoomList)
                    {
                        isSelected = false;
                        foreach (LodgeConfigurationFacade.Room.Dto validRoomDto in this.dto.RoomList)
                        {
                            if (roomDto.Id == validRoomDto.Id)
                            {
                                isSelected = true;
                                break;
                            }
                        }

                        if (isSelected)
                            SelectedRoomList.Add(roomDto);
                        else
                            AvailableRoomList.Add(roomDto);
                    }
                }
            }
            else
            {
                SelectedRoomList = null;
                AvailableRoomList = null;                
            }

            this.cboSelectedRoom.DataSource = SelectedRoomList;
            if (SelectedRoomList != null && SelectedRoomList.Count > 0)
            {
                this.cboSelectedRoom.DisplayMember = "Number";
                this.cboSelectedRoom.ValueMember = "Id";
                this.cboSelectedRoom.SelectedIndex = -1;
            }

            this.cboRoomList.DataSource = AvailableRoomList;
            if (AvailableRoomList != null && AvailableRoomList.Count > 0)
            {
                this.cboRoomList.DisplayMember = "Number";
                this.cboRoomList.ValueMember = "Id";
                this.cboRoomList.SelectedIndex = -1;
            }
        }

        private Boolean ValidateRoom(LodgeConfigurationFacade.Room.Dto roomDto)
        {            
            if (this.cboCategory.SelectedIndex > -1)
            { 
              List<LodgeConfigurationFacade.Room.Category.Dto> lstCategory = this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>;
              if (lstCategory[this.cboCategory.SelectedIndex].Id != roomDto.Category.Id)
                  return false;
            }

            if (this.cboType.SelectedIndex > -1)
            {                
                List<LodgeConfigurationFacade.Room.Type.Dto> lstType = this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>;
                if (lstType[this.cboType.SelectedIndex].Id != roomDto.Type.Id)
                    return false;
            }

            return (chkIsAC.Checked == roomDto.IsAirconditioned);

        }

        public enum LodgeReservationStatus
        {
            open = 10001,
            closed = 10002,
            cancel = 10003,
            checkin = 10004
        }

    }
}
