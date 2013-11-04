using System.Windows.Forms;
//using AutoTourism.Presentation.Library;
//using AutoTourism.Facade.LodgeManagement.CheckIn;
using System;
using System.Collections.Generic;
using BinAff.Utility;
using System.Text.RegularExpressions;
using BinAff.Core;

namespace AutoTourism.Lodge.WinForm
{
    public partial class CheckInForm : Form
    {
        private static CheckInForm checkInForm;        
        //private AutoTourism.Facade.LodgeManagement.CheckIn.Dto checkInDto;        
        //private AutoTourism.Facade.Rule.Dto ruleDto;
        public enum LodgeReservationStatus
        {
            Open = 10001,
            Closed = 10002,
            Cancel = 10003,
            CheckIn = 10004,
            Modify = 10005
        }

        //public CheckInForm(AutoTourism.Facade.Rule.Dto ruleDto)
        //{
        //    InitializeComponent();

        //    this.ruleDto = ruleDto;
        //    dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        //    if (this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
        //        dtCheckIn.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
        //    else
        //        dtCheckIn.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;
        //}

        //public CheckInForm(AutoTourism.Facade.LodgeManagement.CheckIn.Dto CheckInDto, AutoTourism.Facade.Rule.Dto ruleDto)
        //{
        //    InitializeComponent();

        //    this.ruleDto = ruleDto;

        //    dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        //    if (this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
        //        dtCheckIn.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
        //    else
        //        dtCheckIn.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;

        //    if (CheckInDto != null)
        //    {
        //        this.checkInDto = CheckInDto;
        //        this.LoadForm();
        //    }
        //}

        //public static CheckInForm Create(System.Windows.Forms.Form mdiParent)
        //{
        //    if (checkInForm == null || checkInForm.IsDisposed)
        //        checkInForm = new CheckInForm()
        //        {
        //            ShowInTaskbar = false,
        //            MdiParent = mdiParent
        //        };
        //    else
        //        checkInForm.Focus();

        //    return checkInForm;
        //}
                
        //private void btnPickReservation_Click(object sender, System.EventArgs e)
        //{
        //    new RoomReservationRegister(ruleDto).Show(this.Owner);
        //}

        //protected override void btnOk_Click(object sender, System.EventArgs e)
        //{
        //    if (ValidateBooking())
        //    {  
        //        Dto dto = new Dto()
        //        {
        //            Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDecimal(txtAdvance.Text.Trim()),
        //            Reservation = new Facade.LodgeManagement.Reservation.Dto()
        //            {
        //                Id = this.checkInDto.Reservation.Id,
        //                BookingFrom = dtCheckIn.Value,
        //                NoOfDays = Convert.ToInt32(txtDays.Text.Trim()),
        //                NoOfPersons = Convert.ToInt32(txtPersons.Text.Trim()),
        //                NoOfRooms = Convert.ToInt32(txtRooms.Text.Trim()),
        //                Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDecimal(txtAdvance.Text.Trim()),
        //                Customer = new Facade.CustomerManagement.Dto() { Id = this.checkInDto.Reservation.Customer.Id },
        //            },
        //            RoomList = (List<AutoTourism.Facade.Configuration.Room.Dto>)cmbCheckInRoom.DataSource,
        //        };

        //        if (dtCheckIn.Value != this.checkInDto.Reservation.BookingFrom) dto.Reservation.BookingStatusId = Convert.ToInt64(LodgeReservationStatus.Modify);
        //        else if (Convert.ToInt32(txtDays.Text.Trim()) != this.checkInDto.Reservation.NoOfDays) dto.Reservation.BookingStatusId = Convert.ToInt64(LodgeReservationStatus.Modify);
        //        else if (Convert.ToInt32(txtPersons.Text.Trim()) != this.checkInDto.Reservation.NoOfPersons) dto.Reservation.BookingStatusId = Convert.ToInt64(LodgeReservationStatus.Modify);
        //        else if (Convert.ToInt32(txtRooms.Text.Trim()) != this.checkInDto.Reservation.NoOfRooms) dto.Reservation.BookingStatusId = Convert.ToInt64(LodgeReservationStatus.Modify);

        //        ICheckIn reservation = new CheckInServer();
        //        ReturnObject<Boolean> ret = reservation.Save(dto);

        //        base.ShowMessage(ret); //Show message  

        //        this.Close();              
        //    }
        //}

        //private Boolean ValidateBooking()
        //{
        //    Boolean retVal = true;
        //    errorProvider.Clear();

        //    if (this.checkInDto == null)
        //    {
        //        errorProvider.SetError(btnPickReservation, "Select a reservation for check in.");
        //        btnPickReservation.Focus();
        //        return false;
        //    }
        //    else if (ValidationRule.IsDateLessThanToday(dtCheckIn.Value))
        //    {
        //        errorProvider.SetError(dtCheckIn, "CheckIn date cannot be less than today.");
        //        dtCheckIn.Focus();
        //        return false;
        //    }
        //    else if (String.IsNullOrEmpty(txtDays.Text.Trim()))
        //    {
        //        errorProvider.SetError(txtDays, "Please enter days.");
        //        txtDays.Focus();
        //        return false;
        //    }
        //    else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())))
        //    {
        //        errorProvider.SetError(txtDays, "Entered " + txtDays.Text + " is Invalid.");
        //        txtDays.Focus();
        //        return false;
        //    }
        //    else if (String.IsNullOrEmpty(txtPersons.Text.Trim()))
        //    {
        //        errorProvider.SetError(txtPersons, "Please enter persons.");
        //        txtPersons.Focus();
        //        return false;
        //    }
        //    else if (!(new Regex(@"^[0-9]*$").IsMatch(txtPersons.Text.Trim())))
        //    {
        //        errorProvider.SetError(txtPersons, "Entered " + txtPersons.Text + " is Invalid.");
        //        txtPersons.Focus();
        //        return false;
        //    }
        //    else if (String.IsNullOrEmpty(txtRooms.Text.Trim()))
        //    {
        //        errorProvider.SetError(txtRooms, "Please enter rooms.");
        //        txtRooms.Focus();
        //        return false;
        //    }
        //    else if (!(new Regex(@"^[0-9]*$").IsMatch(txtRooms.Text.Trim())))
        //    {
        //        errorProvider.SetError(txtRooms, "Entered " + txtRooms.Text + " is Invalid.");
        //        txtRooms.Focus();
        //        return false;
        //    }
        //    else if (!ValidationRule.IsDecimal(txtAdvance.Text.Trim() == String.Empty ? "0" : txtAdvance.Text.Trim().Replace(",", "")))
        //    {
        //        errorProvider.SetError(txtAdvance, "Entered " + txtAdvance.Text + " is Invalid.");
        //        txtAdvance.Focus();
        //        return false;
        //    }
        //    else if (cmbCheckInRoom.Items.Count > Convert.ToInt32(txtRooms.Text.Trim()))
        //    {
        //        errorProvider.SetError(cmbCheckInRoom, "Selected rooms cannot be greater than the no of rooms.");
        //        cmbCheckInRoom.Focus();
        //        return false;
        //    }
        //    else if (cmbCheckInRoom.DataSource == null)
        //    {
        //        errorProvider.SetError(cmbCheckInRoom, "Select rooms for checkin.");
        //        cmbCheckInRoom.Focus();
        //        return false;
        //    }

        //    return retVal;
        //}

        //protected override void LoadForm()
        //{            
        //    dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        //    if(this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
        //        dtCheckIn.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
        //    else
        //        dtCheckIn.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;

        //    //populate reservation data
        //    if (this.checkInDto != null && this.checkInDto.Reservation != null)
        //    {
        //        dtCheckIn.Value = this.checkInDto.Reservation.BookingFrom;
        //        txtDays.Text = this.checkInDto.Reservation.NoOfDays.ToString();
        //        txtPersons.Text = this.checkInDto.Reservation.NoOfPersons.ToString();
        //        txtRooms.Text = this.checkInDto.Reservation.NoOfRooms.ToString();
        //        txtAdvance.Text = this.checkInDto.Reservation.Advance.ToString();

        //        cmbCheckInRoom.DataSource = this.checkInDto.Reservation.RoomList;
        //        cmbCheckInRoom.DisplayMember = "Number";
        //        cmbCheckInRoom.ValueMember = "Id";
        //        cmbCheckInRoom.SelectedIndex = -1;

        //        txtName.Text = (this.checkInDto.Reservation.Customer.Initial == null ? String.Empty : 
        //            this.checkInDto.Reservation.Customer.Initial.Name) + " " +
        //            this.checkInDto.Reservation.Customer.FirstName + " " +
        //            this.checkInDto.Reservation.Customer.MiddleName + " " +
        //            this.checkInDto.Reservation.Customer.LastName;
        //        lstContact.DataSource = this.checkInDto.Reservation.Customer.ContactNumberList;
        //        lstContact.DisplayMember = "Name";
        //        lstContact.ValueMember = "Id";
        //        lstContact.SelectedIndex = -1;
        //        txtAdds.Text = this.checkInDto.Reservation.Customer.Address;
        //        txtEmail.Text = this.checkInDto.Reservation.Customer.Email;
        //    }

        //    //populate room list
        //    ICheckIn checkIn = new CheckInServer();
        //    FormDto formDto = checkIn.LoadForm().Value;

        //    List<Facade.Configuration.Room.Dto> RoomList = new List<Facade.Configuration.Room.Dto>();
        //    if (formDto.roomList != null && formDto.roomList.Count > 0)
        //    {
        //        if (this.checkInDto.Reservation.RoomList == null || this.checkInDto.Reservation.RoomList.Count == 0)
        //            RoomList = formDto.roomList;
        //        else
        //        {
        //            foreach (Facade.Configuration.Room.Dto roomDto in formDto.roomList)
        //            {
        //                Boolean blnNotExist = true;
        //                foreach (Facade.Configuration.Room.Dto bookedRoomDto in this.checkInDto.Reservation.RoomList)
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

        //protected override void Clear()
        //{
            
        //}

        //private void btnAddRoom_Click(object sender, EventArgs e)
        //{
        //    Facade.Configuration.Room.Dto roomDto = null;
        //    if (cboRoomList.SelectedIndex != -1)
        //    {
        //        roomDto = (Facade.Configuration.Room.Dto)cboRoomList.SelectedItem;
        //        AddToList(roomDto, cmbCheckInRoom);
        //        RemoveFromList(roomDto, cboRoomList);
        //    }
        //}

        //private void btnRemoveRoom_Click(object sender, EventArgs e)
        //{
        //    Facade.Configuration.Room.Dto roomDto = null;
        //    if (cmbCheckInRoom.SelectedIndex != -1)
        //    {
        //        roomDto = (Facade.Configuration.Room.Dto)cmbCheckInRoom.SelectedItem;
        //        AddToList(roomDto, cboRoomList);
        //        RemoveFromList(roomDto, cmbCheckInRoom);
        //    }
        //}

        //private void AddToList(Facade.Configuration.Room.Dto roomDto, System.Windows.Forms.ListControl cboRoom)
        //{
        //    Boolean Include = false;
        //    List<Facade.Configuration.Room.Dto> RoomList = new List<Facade.Configuration.Room.Dto>();

        //    if (((System.Windows.Forms.ComboBox)cboRoom).Items.Count == 0)
        //        RoomList.Add(roomDto);
        //    else
        //    {
        //        foreach (Facade.Configuration.Room.Dto dto in (List<Facade.Configuration.Room.Dto>)cboRoom.DataSource)
        //        {
        //            if (dto.Id < roomDto.Id)
        //                RoomList.Add(dto);
        //            else
        //            {
        //                RoomList.Add(roomDto);
        //                RoomList.Add(dto);
        //                Include = true;
        //            }
        //        }
        //        if (!Include) RoomList.Add(roomDto);
        //    }

        //    cboRoom.DataSource = null;
        //    cboRoom.DataSource = RoomList;
        //    cboRoom.DisplayMember = "Number";
        //    cboRoom.ValueMember = "Id";
        //    cboRoom.SelectedIndex = -1;
        //}

        //private void RemoveFromList(Facade.Configuration.Room.Dto roomDto, System.Windows.Forms.ListControl cboRoom)
        //{
        //    List<Facade.Configuration.Room.Dto> RoomList = new List<Facade.Configuration.Room.Dto>();
        //    foreach (Facade.Configuration.Room.Dto dto in (List<Facade.Configuration.Room.Dto>)cboRoom.DataSource)
        //        if (dto.Id != roomDto.Id) RoomList.Add(dto);

        //    cboRoom.DataSource = null;
        //    cboRoom.DataSource = RoomList;
        //    cboRoom.DisplayMember = "Number";
        //    cboRoom.ValueMember = "Id";
        //    cboRoom.SelectedIndex = -1;
        //}

    }
}
