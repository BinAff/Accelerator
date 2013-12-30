using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;

using LodgeFacade = AutoTourism.Lodge.Facade;
using RuleFacade = Autotourism.Configuration.Rule.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using CustomerFacade = AutoTourism.Customer.Facade;
using AutoTourism.Customer.WinForm;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationForm : Form
    {      

        private LodgeFacade.RoomReservation.Dto bookingDto;
        //private RuleFacade.ConfigurationRuleDto configurationRuleDto;

        //public RoomReservationForm()
        //{
        //    InitializeComponent();
        //}

        public RoomReservationForm(LodgeFacade.RoomReservation.Dto bookingDto)
        {
            InitializeComponent();
            this.bookingDto = bookingDto;
        }

        //public RoomReservationForm(LodgeFacade.RoomReservation.Dto bookingDto, RuleFacade.Dto ruleDto)
        //{
        //    InitializeComponent();
        //    this.bookingDto = bookingDto;
        //    this.ruleDto = ruleDto;
        //}

        private void RoomBookingForm_Load(object sender, System.EventArgs e)
        {          
            //set default date format
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case

            dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dtFromTime.ShowUpDown = true;

            LoadForm();

            //dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //if (this.ruleDto == null || this.ruleDto.ConfigurationRule == null || this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
            //    dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
            //else
            //    dtFrom.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;

            //dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            //dtFromTime.ShowUpDown = true;

            //if (this.bookingDto != null) LoadForm();
        }  

        private void btnPickCustomer_Click(object sender, System.EventArgs e)
        {   
            new CustomerRegister().ShowDialog();
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
            LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer();
            ReturnObject<LodgeFacade.RoomReservation.FormDto> ret = reservation.LoadForm();

            //populate rule
            if (ret.Value.configurationRuleDto != null && ret.Value.configurationRuleDto.DateFormat != null)
            {
                //this.configurationRuleDto = ret.Value.configurationRuleDto;
                dtFrom.CustomFormat = ret.Value.configurationRuleDto.DateFormat;
            }

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

            //populate customer data
            if (this.bookingDto != null && this.bookingDto.Id > 0)
            {
                if (this.bookingDto.Customer != null)
                {                   
                    txtName.Text = (this.bookingDto.Customer.Initial == null ? String.Empty : this.bookingDto.Customer.Initial.Name);
                    Name += (Name == String.Empty) ? (this.bookingDto.Customer.FirstName == null ? String.Empty : this.bookingDto.Customer.FirstName) : " " + (this.bookingDto.Customer.FirstName == null ? String.Empty : this.bookingDto.Customer.FirstName);
                    Name += (Name == String.Empty) ? (this.bookingDto.Customer.MiddleName == null ? String.Empty : this.bookingDto.Customer.MiddleName) : " " + (this.bookingDto.Customer.MiddleName == null ? String.Empty : this.bookingDto.Customer.MiddleName);
                    Name += (Name == String.Empty) ? (this.bookingDto.Customer.LastName == null ? String.Empty : this.bookingDto.Customer.LastName) : " " + (this.bookingDto.Customer.LastName == null ? String.Empty : this.bookingDto.Customer.LastName);
                

                    lstContact.DataSource = this.bookingDto.Customer.ContactNumberList;
                    lstContact.DisplayMember = "Name";
                    lstContact.ValueMember = "Id";
                    lstContact.SelectedIndex = -1;
                    txtAdds.Text = this.bookingDto.Customer.Address;
                    txtEmail.Text = this.bookingDto.Customer.Email;
                }

                //populate booking data
                if (!ValidationRule.IsMinimumDate(this.bookingDto.BookingFrom))
                {
                    dtFrom.Value = this.bookingDto.BookingFrom;
                    dtFromTime.Value = this.bookingDto.BookingFrom;
                }
                txtDays.Text = this.bookingDto.NoOfDays == 0 ? String.Empty : this.bookingDto.NoOfDays.ToString();
                txtPersons.Text = this.bookingDto.NoOfPersons == 0 ? String.Empty : this.bookingDto.NoOfPersons.ToString();
                txtRooms.Text = this.bookingDto.NoOfRooms == 0 ? String.Empty : this.bookingDto.NoOfRooms.ToString();
                txtAdvance.Text = this.bookingDto.Advance == 0 ? String.Empty : Converter.ConvertToIndianCurrency(this.bookingDto.Advance);
                cboSelectedRoom.DataSource = this.bookingDto.RoomList;
                cboSelectedRoom.DisplayMember = "Number";
                cboSelectedRoom.ValueMember = "Id";
                cboSelectedRoom.SelectedIndex = -1;

                if ((Convert.ToInt64(LodgeReservationStatus.open) != this.bookingDto.BookingStatusId) && (this.bookingDto.BookingStatusId != 0))
                    btnOk.Enabled = false;
            }
        }

        private void Clear()
        {
            
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
            if (ValidateBooking() && this.bookingDto != null)
            {
                DateTime bookingDateTime = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);
                LodgeFacade.RoomReservation.Dto dto = new LodgeFacade.RoomReservation.Dto()
                {
                    Id = this.bookingDto.Id,
                    BookingFrom = bookingDateTime,
                    NoOfDays = Convert.ToInt16(txtDays.Text),
                    NoOfPersons = Convert.ToInt16(txtPersons.Text),
                    NoOfRooms = Convert.ToInt16(txtRooms.Text),
                    Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtAdvance.Text.Replace(",", "")),
                    Customer = new CustomerFacade.Dto()
                    {
                        Id = this.bookingDto.Customer.Id,
                    },
                    RoomList = this.cboSelectedRoom.Items.Count == 0 ? null : (List<LodgeConfigurationFacade.Room.Dto>)this.cboSelectedRoom.DataSource,
                };

                LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer();
                ReturnObject<Boolean> ret = reservation.Save(dto);

                //base.ShowMessage(ret); //Show message  

                this.Close();

            }
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
