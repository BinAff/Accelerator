
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using BinAff.Core;
using BinAff.Utility;

using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;
using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using PresentationLibrary = BinAff.Presentation.Library;

namespace AutoTourism.Lodge.WinForm
{
    public partial class CheckInForm : PresentationLibrary.Form
    {
        private LodgeFacade.CheckIn.Dto dto;
        private LodgeFacade.CheckIn.FormDto formDto;
        private RuleFacade.ConfigurationRuleDto configurationRuleDto;
      
        //public enum LodgeReservationStatus
        //{
        //    Open = 10001,
        //    Closed = 10002,
        //    Cancel = 10003,
        //    CheckIn = 10004,
        //    Modify = 10005
        //}

        public CheckInForm(LodgeFacade.CheckIn.Dto CheckInDto)
        {
            InitializeComponent();

            this.dto = CheckInDto;
            this.formDto = new LodgeFacade.CheckIn.FormDto { dto = this.dto };

            dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtCheckIn.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case

            this.LoadForm();

            //dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //if (this.ruleDto == null || this.ruleDto.ConfigurationRule == null || this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
            //    dtCheckIn.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
            //else
            //    dtCheckIn.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;

            //if (CheckInDto != null)
            //{
            //    this.checkInDto = CheckInDto;
            //    this.LoadForm();
            //}
        }

        //public CheckInForm(LodgeFacade.CheckIn.Dto CheckInDto, RuleFacade.Dto ruleDto)
        //{
        //    InitializeComponent();

        //    this.ruleDto = ruleDto;

        //    dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        //    if (this.ruleDto == null || this.ruleDto.ConfigurationRule == null || this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
        //        dtCheckIn.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
        //    else
        //        dtCheckIn.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;

        //    if (CheckInDto != null)
        //    {
        //        this.checkInDto = CheckInDto;
        //        this.LoadForm();
        //    }
        //}

        private Boolean SaveCheckInData()
        {
            Boolean retVal = this.ValidateCheckIn();

            if (retVal)
            {
                if (this.formDto.dto == null) this.formDto.dto = new LodgeFacade.CheckIn.Dto();
                this.formDto.dto.Id = this.formDto.dto == null ? 0 : this.formDto.dto.Id;
                this.formDto.dto.Date = new DateTime(dtCheckIn.Value.Year, dtCheckIn.Value.Month, dtCheckIn.Value.Day, dtCheckIn.Value.Hour, dtCheckIn.Value.Minute, dtCheckIn.Value.Second);

                if (this.formDto.dto.reservationDto == null) this.formDto.dto.reservationDto = new LodgeFacade.RoomReservation.Dto();
                this.formDto.dto.reservationDto.Id = this.formDto.dto.reservationDto == null ? 0 : this.formDto.dto.reservationDto.Id;

                this.formDto.dto.reservationDto.isCheckedIn = true;
                this.formDto.dto.reservationDto.BookingFrom = new DateTime(dtCheckIn.Value.Year, dtCheckIn.Value.Month, dtCheckIn.Value.Day, dtCheckIn.Value.Hour, dtCheckIn.Value.Minute, dtCheckIn.Value.Second);
                this.formDto.dto.reservationDto.NoOfDays = Convert.ToInt16(txtDays.Text);
                this.formDto.dto.reservationDto.NoOfPersons = Convert.ToInt16(txtPersons.Text);
                this.formDto.dto.reservationDto.NoOfRooms = Convert.ToInt16(txtRooms.Text);
                this.formDto.dto.reservationDto.Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtAdvance.Text.Replace(",", ""));
                this.formDto.dto.reservationDto.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>)[this.cboCategory.SelectedIndex].Id };
                this.formDto.dto.reservationDto.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>)[this.cboType.SelectedIndex].Id };
                this.formDto.dto.reservationDto.IsAC = this.chkIsAC.Checked;
                this.formDto.dto.reservationDto.RoomList = (List<LodgeConfigurationFacade.Room.Dto>)cmbCheckInRoom.DataSource;               

                BinAff.Facade.Library.Server facade = new LodgeFacade.CheckIn.CheckInServer(formDto);

                if (this.formDto.dto.Id == 0)
                    facade.Add();
                else
                    facade.Change();

                //checkIn Id passs back to register
                this.dto.Id = this.formDto.dto.Id;       

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

        private void btnOk_Click(object sender, EventArgs e)
        {
            //this.dto.Id = 5;
            //this.Close();

            if (this.SaveCheckInData())
            {
                base.IsModified = true;
                this.Close();
            }
        }
        
        private Boolean ValidateCheckIn()
        {
            Boolean retVal = true;
            errorProvider.Clear();

            //if (this.dto == null)
            //{
            //    errorProvider.SetError(btnPickReservation, "Select a reservation for check in.");
            //    btnPickReservation.Focus();
            //    return false;
            //}
            //if (txtName.Text.Trim() == String.Empty)
            //{
            //    errorProvider.SetError(btnPickReservation, "Select a customer for reservation.");
            //    btnPickReservation.Focus();
            //    return false;
            //}

            if (this.formDto == null || this.formDto.dto == null || this.formDto.dto.reservationDto == null || this.formDto.dto.reservationDto.Customer == null)
            {
                errorProvider.SetError(btnPickReservation, "Select a customer for reservation.");
                btnPickReservation.Focus();
                return false;
            }
            else if (ValidationRule.IsDateLessThanToday(dtCheckIn.Value))
            {
                errorProvider.SetError(dtCheckIn, "CheckIn date cannot be less than today.");
                dtCheckIn.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtDays.Text.Trim()))
            {
                errorProvider.SetError(txtDays, "Please enter days.");
                txtDays.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())) || Convert.ToInt16(txtDays.Text) == 0)
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
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtPersons.Text.Trim())) || Convert.ToInt16(txtPersons.Text) == 0)
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
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtRooms.Text.Trim())) || Convert.ToInt16(txtRooms.Text) == 0)
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
            else if (cmbCheckInRoom.DataSource == null)
            {
                errorProvider.SetError(cmbCheckInRoom, "Select rooms for checkin.");
                cmbCheckInRoom.Focus();
                return false;
            }
            else if (cmbCheckInRoom.Items.Count > Convert.ToInt32(txtRooms.Text.Trim()))
            {
                errorProvider.SetError(cmbCheckInRoom, "Selected rooms cannot be greater than the no of rooms.");
                cmbCheckInRoom.Focus();
                return false;
            }

            return retVal;
        }

        private void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new LodgeFacade.CheckIn.CheckInServer(formDto);
            facade.LoadForm();

            this.configurationRuleDto = formDto.configurationRuleDto;
            if (this.configurationRuleDto.DateFormat != null)
                dtCheckIn.CustomFormat = this.configurationRuleDto.DateFormat;

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

            //populate reservation data
            //if (this.checkInDto != null && this.checkInDto.Reservation != null)
            //{
            //    dtCheckIn.Value = this.checkInDto.Reservation.BookingFrom;
            //    txtDays.Text = this.checkInDto.Reservation.NoOfDays.ToString();
            //    txtPersons.Text = this.checkInDto.Reservation.NoOfPersons.ToString();
            //    txtRooms.Text = this.checkInDto.Reservation.NoOfRooms.ToString();
            //    txtAdvance.Text = this.checkInDto.Reservation.Advance.ToString();

            //    cmbCheckInRoom.DataSource = this.checkInDto.Reservation.RoomList;
            //    cmbCheckInRoom.DisplayMember = "Number";
            //    cmbCheckInRoom.ValueMember = "Id";
            //    cmbCheckInRoom.SelectedIndex = -1;

            //    txtName.Text = (this.checkInDto.Reservation.Customer.Initial == null ? String.Empty :
            //        this.checkInDto.Reservation.Customer.Initial.Name) + " " +
            //        this.checkInDto.Reservation.Customer.FirstName + " " +
            //        this.checkInDto.Reservation.Customer.MiddleName + " " +
            //        this.checkInDto.Reservation.Customer.LastName;
            //    lstContact.DataSource = this.checkInDto.Reservation.Customer.ContactNumberList;
            //    lstContact.DisplayMember = "Name";
            //    lstContact.ValueMember = "Id";
            //    lstContact.SelectedIndex = -1;
            //    txtAdds.Text = this.checkInDto.Reservation.Customer.Address;
            //    txtEmail.Text = this.checkInDto.Reservation.Customer.Email;
            //}


            ////populate room list
            //LodgeFacade.CheckIn.ICheckIn checkIn = new LodgeFacade.CheckIn.CheckInServer();
            //LodgeFacade.CheckIn.FormDto formDto = checkIn.LoadForm().Value;

            ////populate rule
            //if (formDto.configurationRuleDto != null && formDto.configurationRuleDto.DateFormat != null)
            //{
            //    dtCheckIn.CustomFormat = formDto.configurationRuleDto.DateFormat;
            //}

            //List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();
            //if (formDto.roomList != null && formDto.roomList.Count > 0)
            //{
            //    if (this.checkInDto.Reservation == null || this.checkInDto.Reservation.RoomList == null || this.checkInDto.Reservation.RoomList.Count == 0)
            //        RoomList = formDto.roomList;
            //    else
            //    {
            //        foreach (LodgeConfigurationFacade.Room.Dto roomDto in formDto.roomList)
            //        {
            //            Boolean blnNotExist = true;
            //            foreach (LodgeConfigurationFacade.Room.Dto bookedRoomDto in this.checkInDto.Reservation.RoomList)
            //            {
            //                if (roomDto.Id == bookedRoomDto.Id)
            //                {
            //                    blnNotExist = false;
            //                    break;
            //                }
            //            }
            //            if (blnNotExist) RoomList.Add(roomDto);
            //        }
            //    }

            //    this.cboRoomList.DataSource = RoomList;
            //    this.cboRoomList.DisplayMember = "Number";
            //    this.cboRoomList.ValueMember = "Id";
            //    this.cboRoomList.SelectedIndex = -1;
            //}

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            LodgeConfigurationFacade.Room.Dto roomDto = null;
            if (cboRoomList.SelectedIndex != -1)
            {
                roomDto = (LodgeConfigurationFacade.Room.Dto)cboRoomList.SelectedItem;
                AddToList(roomDto, cmbCheckInRoom);
                RemoveFromList(roomDto, cboRoomList);
            }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            LodgeConfigurationFacade.Room.Dto roomDto = null;
            if (cmbCheckInRoom.SelectedIndex != -1)
            {
                roomDto = (LodgeConfigurationFacade.Room.Dto)cmbCheckInRoom.SelectedItem;
                AddToList(roomDto, cboRoomList);
                RemoveFromList(roomDto, cmbCheckInRoom);
            }
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

        private void btnPickReservation_Click_1(object sender, EventArgs e)
        { 
            Form form = new RoomReservationRegister();
            form.ShowDialog(this);

            if (form.Tag != null)
            {                
                LodgeFacade.RoomReservationRegister.Dto roomReservationRegisterDto = form.Tag as LodgeFacade.RoomReservationRegister.Dto;
                this.formDto.dto = new LodgeFacade.CheckIn.Dto
                {
                    customerDisplayName = roomReservationRegisterDto.Name,
                    Date = roomReservationRegisterDto.BookingFrom,
                    reservationDto = new LodgeFacade.RoomReservation.Dto
                    {
                        Id = roomReservationRegisterDto.Id,
                        NoOfDays = roomReservationRegisterDto.NoOfDays,
                        NoOfPersons = roomReservationRegisterDto.NoOfPersons,
                        NoOfRooms = roomReservationRegisterDto.NoOfRooms,
                        Advance = roomReservationRegisterDto.Advance,
                        RoomCategory = roomReservationRegisterDto.RoomCategory,
                        RoomType = roomReservationRegisterDto.RoomType,
                        IsAC = roomReservationRegisterDto.IsAC,
                        RoomList = roomReservationRegisterDto.RoomList,
                        BookingFrom = roomReservationRegisterDto.BookingFrom,
                        Customer = roomReservationRegisterDto.Customer
                        //Customer = new CustomerFacade.Dto
                        //{
                        //    Id = roomReservationRegisterDto.Customer.Id,
                        //    FirstName = roomReservationRegisterDto.Customer.FirstName,
                        //    ContactNumberList = roomReservationRegisterDto.Customer.ContactNumberList,
                        //    Address = roomReservationRegisterDto.Customer.Address,
                        //    Email = roomReservationRegisterDto.Customer.Email,
                        //    State = new Table { Id = roomReservationRegisterDto.Customer.State.Id },
                        //    IdentityProofType = new Table { Id = roomReservationRegisterDto.Customer.IdentityProofType.Id },
                        //    IdentityProofName = roomReservationRegisterDto.Customer.IdentityProofName,
                        //    Initial = new Table { Id = roomReservationRegisterDto.Customer.Initial.Id }
                        //}
                    }
                };

                this.LoadCheckInData();                
            }
        }

        private void LoadCheckInData()
        {
            //populate reservation data
            dtCheckIn.Value = this.formDto.dto.reservationDto.BookingFrom;
            txtDays.Text = this.formDto.dto.reservationDto.NoOfDays.ToString();
            txtPersons.Text = this.formDto.dto.reservationDto.NoOfPersons.ToString();
            txtRooms.Text = this.formDto.dto.reservationDto.NoOfRooms.ToString();
            txtAdvance.Text = this.formDto.dto.reservationDto.Advance == 0 ? String.Empty : this.formDto.dto.reservationDto.Advance.ToString();
            chkIsAC.Checked = this.formDto.dto.reservationDto.IsAC;

            if (this.formDto.dto.reservationDto.RoomCategory != null && this.formDto.dto.reservationDto.RoomCategory.Id > 0)
            {
                for (int i = 0; i < cboCategory.Items.Count; i++)
                {
                    if (this.formDto.dto.reservationDto.RoomCategory.Id == ((LodgeConfigurationFacade.Room.Category.Dto)cboCategory.Items[i]).Id)
                    {
                        cboCategory.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (this.formDto.dto.reservationDto.RoomType != null && this.formDto.dto.reservationDto.RoomType.Id > 0)
            {
                for (int i = 0; i < cboType.Items.Count; i++)
                {
                    if (this.formDto.dto.reservationDto.RoomType.Id == ((LodgeConfigurationFacade.Room.Type.Dto)cboType.Items[i]).Id)
                    {
                        cboType.SelectedIndex = i;
                        break;
                    }
                }
            }

            //populate customer data
            txtName.Text = this.formDto.dto.customerDisplayName;
            lstContact.DataSource = this.formDto.dto.reservationDto.Customer.ContactNumberList;
            lstContact.DisplayMember = "Name";
            lstContact.ValueMember = "Id";
            lstContact.SelectedIndex = -1;
            txtAdds.Text = this.formDto.dto.reservationDto.Customer.Address;
            txtEmail.Text = this.formDto.dto.reservationDto.Customer.Email;
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
                if (this.formDto.dto.reservationDto == null || this.formDto.dto.reservationDto.RoomList == null || this.formDto.dto.reservationDto.RoomList.Count == 0)
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
                        foreach (LodgeConfigurationFacade.Room.Dto validRoomDto in this.formDto.dto.reservationDto.RoomList)
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

            this.cmbCheckInRoom.DataSource = SelectedRoomList;
            if (SelectedRoomList != null && SelectedRoomList.Count > 0)
            {
                this.cmbCheckInRoom.DisplayMember = "Number";
                this.cmbCheckInRoom.ValueMember = "Id";
                this.cmbCheckInRoom.SelectedIndex = -1;
            }

            this.cboRoomList.DataSource = AvailableRoomList;
            if (AvailableRoomList != null && AvailableRoomList.Count > 0)
            {
                this.cboRoomList.DisplayMember = "Number";
                this.cboRoomList.ValueMember = "Id";
                this.cboRoomList.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// this function is same as in RoomReservationForm.cs
        /// </summary>
        /// <param name="roomDto"></param>
        /// <returns></returns>
        private Boolean ValidateRoom(LodgeConfigurationFacade.Room.Dto roomDto)
        {

            if (this.cboCategory.SelectedIndex > -1)
            {
                List<LodgeConfigurationFacade.Room.Category.Dto> lstCategory = this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>;
                if (lstCategory[this.cboCategory.SelectedIndex].Id != roomDto.Category.Id)
                    return false;
            }
            else
                return false; // since category is mandatory while creating room

            if (this.cboType.SelectedIndex > -1)
            {
                List<LodgeConfigurationFacade.Room.Type.Dto> lstType = this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>;
                if (lstType[this.cboType.SelectedIndex].Id != roomDto.Type.Id)
                    return false;
            }
            else
                return false; // since type is mandatory while creating room

            return (chkIsAC.Checked == roomDto.IsAirconditioned);

        }
               
    }
}
