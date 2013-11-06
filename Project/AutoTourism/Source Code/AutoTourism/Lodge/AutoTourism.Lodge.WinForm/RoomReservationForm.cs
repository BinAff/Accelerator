using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;

using LodgeFacade = AutoTourism.Lodge.Facade;
using RuleFacade = Autotourism.Configuration.Rule.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

//using AutoTourism.Facade.LodgeManagement.Reservation;

//using AutoTourism.Presentation.Library;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationForm : Form
    {

        //private static RoomReservation bookingForm;
        private LodgeFacade.RoomReservation.Dto bookingDto;
        private RuleFacade.Dto ruleDto;

        public enum LodgeReservationStatus
        {
            open = 10001,
            closed = 10002,
            cancel = 10003,
            checkin = 10004
        }

        private RoomReservationForm()
        {
            InitializeComponent();
        }

        public RoomReservationForm(LodgeFacade.RoomReservation.Dto bookingDto, RuleFacade.Dto ruleDto)
        {
            InitializeComponent();
            this.bookingDto = bookingDto;
            this.ruleDto = ruleDto;
        }

        private void RoomBookingForm_Load(object sender, System.EventArgs e)
        {
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            if (this.ruleDto == null || this.ruleDto.ConfigurationRule == null || this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
                dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
            else
                dtFrom.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;

            dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dtFromTime.ShowUpDown = true;

            if (this.bookingDto != null) LoadForm();
        }
                
        //public static RoomReservation Create(System.Windows.Forms.Form mdiParent)
        //{
        //    if (bookingForm == null || bookingForm.IsDisposed)
        //        bookingForm = new RoomReservation
        //        {
        //            ShowInTaskbar = false,
        //            MdiParent = mdiParent
        //        };
        //    else
        //        bookingForm.Focus();
        //    return bookingForm;
        //}

        private void btnPickCustomer_Click(object sender, System.EventArgs e)
        {
            //this.Close();
            //new CustomerRegister(this.ruleDto).Show(this.Owner);         
        }

        //protected override void btnOk_Click(object sender, System.EventArgs e)
        //{
            //if (ValidateBooking() && this.BookingDto != null)
            //{ 
            //    DateTime bookingDateTime = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);
            //    Dto dto = new Dto()
            //    {
            //        Id = this.BookingDto.Id,
            //        BookingFrom = bookingDateTime,
            //        NoOfDays = Convert.ToInt32(txtDays.Text),
            //        NoOfPersons = Convert.ToInt32(txtPersons.Text),
            //        NoOfRooms = Convert.ToInt32(txtRooms.Text),
            //        Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDecimal(txtAdvance.Text.Replace(",", "")),
            //        Customer = new Facade.CustomerManagement.Dto()
            //        {
            //            Id = this.BookingDto.Customer.Id,
            //        },
            //        RoomList = this.cboSelectedRoom.Items.Count == 0 ? null : (List<Facade.Configuration.Room.Dto>)this.cboSelectedRoom.DataSource,
            //    };

            //    IReservation reservation = new ReservationServer();
            //    ReturnObject<Boolean> ret = reservation.Save(dto);

            //    base.ShowMessage(ret); //Show message  

            //    this.Close();
                 
            //}
        //}

        private void btnAddRoom_Click(object sender, EventArgs e)
        {           
            //Facade.Configuration.Room.Dto roomDto = null;
            //if (cboRoomList.SelectedIndex != -1)
            //{
            //    roomDto = (Facade.Configuration.Room.Dto)cboRoomList.SelectedItem;
            //    AddToList(roomDto, cboSelectedRoom);
            //    RemoveFromList(roomDto, cboRoomList);
            //}
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            //Facade.Configuration.Room.Dto roomDto = null;
            //if (cboSelectedRoom.SelectedIndex != -1)
            //{
            //    roomDto = (Facade.Configuration.Room.Dto)cboSelectedRoom.SelectedItem;
            //    AddToList(roomDto, cboRoomList);
            //    RemoveFromList(roomDto, cboSelectedRoom);
            //}
        }

        private void LoadForm()
        {
            LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer();
            ReturnObject<LodgeFacade.RoomReservation.FormDto> ret = reservation.LoadForm();

            List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (ret.Value.roomList != null && ret.Value.roomList.Count > 0)
            {
                if (this.bookingDto.RoomList == null || this.bookingDto.RoomList.Count == 0)
                    RoomList = ret.Value.roomList;
                else
                {
                    foreach (LodgeConfigurationFacade.Room.Dto roomDto in ret.Value.roomList)
                    {
                        Boolean blnNotExist = true;
                        foreach (LodgeConfigurationFacade.Room.Dto bookedRoomDto in this.bookingDto.RoomList)
                        {
                            if (roomDto.Id == bookedRoomDto.Id)
                            {
                                blnNotExist = false;
                                break;
                            }
                        }
                        if (blnNotExist) RoomList.Add(roomDto);
                    }
                }

                this.cboRoomList.DataSource = RoomList;
                this.cboRoomList.DisplayMember = "Number";
                this.cboRoomList.ValueMember = "Id";
                this.cboRoomList.SelectedIndex = -1;
            }

            ////populate customer data
            //if (this.BookingDto != null)
            //{
            //    if (this.BookingDto.Customer != null)
            //    {
            //        txtName.Text = (this.BookingDto.Customer.Initial == null ? String.Empty : this.BookingDto.Customer.Initial.Name) + " "
            //            + this.BookingDto.Customer.FirstName + " "
            //            + this.BookingDto.Customer.MiddleName + " "
            //            + this.BookingDto.Customer.LastName;
            //        lstContact.DataSource = this.BookingDto.Customer.ContactNumberList;
            //        lstContact.DisplayMember = "Name";
            //        lstContact.ValueMember = "Id";
            //        lstContact.SelectedIndex = -1;
            //        txtAdds.Text = this.BookingDto.Customer.Address;
            //        txtEmail.Text = this.BookingDto.Customer.Email;
            //    }

            //    //populate booking data
            //    if (!ValidationRule.IsMinimumDate(this.BookingDto.BookingFrom))
            //    {
            //        dtFrom.Value = this.BookingDto.BookingFrom;
            //        dtFromTime.Value = this.BookingDto.BookingFrom;
            //    }
            //    txtDays.Text = this.BookingDto.NoOfDays == 0 ? String.Empty : this.BookingDto.NoOfDays.ToString();
            //    txtPersons.Text = this.BookingDto.NoOfPersons == 0 ? String.Empty : this.BookingDto.NoOfPersons.ToString();
            //    txtRooms.Text = this.BookingDto.NoOfRooms == 0 ? String.Empty : this.BookingDto.NoOfRooms.ToString();
            //    txtAdvance.Text = this.BookingDto.Advance == 0 ? String.Empty : Converter.ConvertToIndianCurrency(this.BookingDto.Advance);
            //    cboSelectedRoom.DataSource = this.BookingDto.RoomList;
            //    cboSelectedRoom.DisplayMember = "Number";
            //    cboSelectedRoom.ValueMember = "Id";
            //    cboSelectedRoom.SelectedIndex = -1;

            //    if ((Convert.ToInt64(LodgeReservationStatus.open) != this.BookingDto.BookingStatusId) && (this.BookingDto.BookingStatusId != 0))
            //        base.DisableOkButton();
            //}
        }

        private void Clear()
        {
            
        }

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

    }
}
