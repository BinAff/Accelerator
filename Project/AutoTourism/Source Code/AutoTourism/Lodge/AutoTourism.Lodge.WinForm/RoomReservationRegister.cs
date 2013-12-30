using System;
using System.Windows.Forms;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

using RuleFacade = Autotourism.Configuration.Rule.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;


namespace AutoTourism.Lodge.WinForm
{  

    public partial class RoomReservationRegister : Form
    {

        private RuleFacade.ConfigurationRuleDto configurationRuleDto;
       
        public RoomReservationRegister(RuleFacade.ConfigurationRuleDto ruleDto)
        {
            InitializeComponent();
            this.configurationRuleDto = ruleDto;
            //base.IsOkButton = false;

            dtBookingFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtBookingTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            if (this.configurationRuleDto == null ||this.configurationRuleDto.DateFormat == String.Empty)
            {
                dtBookingFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
                dtBookingTo.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
            }
            else
            {
                dtBookingFrom.CustomFormat = this.configurationRuleDto.DateFormat;
                dtBookingTo.CustomFormat = this.configurationRuleDto.DateFormat;
            }

            dgvReservation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < dgvReservation.Columns.Count; i++) dgvReservation.Columns[i].ReadOnly = true;
            dgvReservation.MultiSelect = false;

            LoadForm();
        }

        private void LoadForm()
        {
            LodgeFacade.RoomReservationRegister.IReservationRegister reservationRegister = new LodgeFacade.RoomReservationRegister.ReservationRegisterServer();
            ReturnObject<LodgeFacade.RoomReservationRegister.FormDto> ret = reservationRegister.LoadRegisterForm(Convert.ToInt64(LodgeReservationStatus.Open), dtBookingFrom.Value, dtBookingTo.Value);

            if (ret.Value.RoomReservationDtoList != null && ret.Value.RoomReservationDtoList.Count > 0)
                PopulateReservationData(ret.Value.RoomReservationDtoList);

            if (ret.Value.StatusList != null && ret.Value.StatusList.Count > 0)
            {
                ret.Value.StatusList.Insert(0, new Table() { Id = 00000, Name = "All" });
                cmbReservationStatus.DataSource = ret.Value.StatusList;
                cmbReservationStatus.DisplayMember = "Name";
                cmbReservationStatus.ValueMember = "Id";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LodgeFacade.RoomReservationRegister.IReservationRegister reservationRegister = new LodgeFacade.RoomReservationRegister.ReservationRegisterServer();
            ReturnObject<List<LodgeFacade.RoomReservationRegister.Dto>> ret = reservationRegister.Search(((Table)cmbReservationStatus.SelectedItem).Id, dtBookingFrom.Value, dtBookingTo.Value);

            dgvReservation.DataSource = null;
            if (ret.Value != null && ret.Value.Count > 0)
                PopulateReservationData(ret.Value);
        }
        
        private void dgvReservation_CellMouseDown(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            dgvReservation.Rows[e.RowIndex].Selected = true;
            if (dgvReservation.DataSource != null)
                PopulateReservationDetails(((List<LodgeFacade.RoomReservationRegister.Dto>)dgvReservation.DataSource)[e.RowIndex]);
        }

        private void dgvReservation_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //if (dgvReservation.DataSource != null)
            //    this.OpenForm(((List<RoomReservationRegisterDto>)dgvReservation.DataSource)[e.RowIndex]);
        }

        private void PopulateReservationData(List<LodgeFacade.RoomReservationRegister.Dto> RoomRegistrationRegisterList)
        {
            if (RoomRegistrationRegisterList != null && RoomRegistrationRegisterList.Count > 0)
            {
                dgvReservation.Columns[0].DataPropertyName = "BookingDate";
                dgvReservation.Columns[1].DataPropertyName = "Name";
                dgvReservation.Columns[2].DataPropertyName = "ContactNumber";
                dgvReservation.Columns[3].DataPropertyName = "BookingFrom";
                dgvReservation.Columns[4].DataPropertyName = "BookingTo";
                dgvReservation.Columns[5].DataPropertyName = "Room";
                dgvReservation.Columns[6].DataPropertyName = "Advance";
                dgvReservation.Columns[6].HeaderText = "Advance Taken";
                dgvReservation.AutoGenerateColumns = false;

                dgvReservation.DataSource = RoomRegistrationRegisterList;

                PopulateReservationDetails(RoomRegistrationRegisterList[0]);
            }
        }

        private void PopulateReservationDetails(LodgeFacade.RoomReservationRegister.Dto dto)
        {
            //populate reservation data
            txtFromDate.Text = dto.BookingFrom.ToString();//
            txtDays.Text = dto.NoOfDays == 0 ? String.Empty : dto.NoOfDays.ToString();
            txtPersons.Text = dto.NoOfPersons == 0 ? String.Empty : dto.NoOfPersons.ToString();
            txtRooms.Text = dto.NoOfRooms == 0 ? String.Empty : dto.NoOfRooms.ToString();
            txtAdvance.Text = dto.Advance == 0 ? String.Empty : Converter.ConvertToIndianCurrency(dto.Advance);
            lstRooms.DataSource = dto.RoomList;
            lstRooms.DisplayMember = "Number";
            lstRooms.ValueMember = "Id";
            lstRooms.SelectedIndex = -1;

            if (dto.Customer != null)
            {
                //populate customer data           

                txtName.Text = (dto.Customer.Initial == null ? String.Empty : dto.Customer.Initial.Name);
                Name += (Name == String.Empty) ? (dto.Customer.FirstName == null ? String.Empty : dto.Customer.FirstName) : " " + (dto.Customer.FirstName == null ? String.Empty : dto.Customer.FirstName);
                Name += (Name == String.Empty) ? (dto.Customer.MiddleName == null ? String.Empty : dto.Customer.MiddleName) : " " + (dto.Customer.MiddleName == null ? String.Empty : dto.Customer.MiddleName);
                Name += (Name == String.Empty) ? (dto.Customer.LastName == null ? String.Empty : dto.Customer.LastName) : " " + (dto.Customer.LastName == null ? String.Empty : dto.Customer.LastName);
                
                lstContact.DataSource = dto.Customer.ContactNumberList;
                lstContact.DisplayMember = "Name";
                lstContact.ValueMember = "Id";
                lstContact.SelectedIndex = -1;
                txtAdds.Text = dto.Customer.Address;
                txtEmail.Text = dto.Customer.Email;
            }
        }

        private void cMenuItemCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvReservation.DataSource != null && dgvReservation.SelectedRows.Count > 0)
            {
                LodgeFacade.RoomReservationRegister.Dto dto = ((List<LodgeFacade.RoomReservationRegister.Dto>)dgvReservation.DataSource)[dgvReservation.SelectedRows[0].Index];

                LodgeFacade.CheckIn.Dto checkInDto = dto == null ? null : new LodgeFacade.CheckIn.Dto()
                {
                    Reservation = new LodgeFacade.RoomReservation.Dto
                    {
                        Id = dto.Id,
                        BookingDate = dto.BookingDate,
                        BookingFrom = dto.BookingFrom,
                        NoOfDays = dto.NoOfDays,
                        NoOfPersons = dto.NoOfPersons,
                        NoOfRooms = dto.NoOfRooms,
                        Advance = dto.Advance,
                        BookingStatusId = dto.BookingStatusId,

                        RoomList = dto.RoomList,
                        Customer = dto.Customer,
                    }
                };

                //new CheckInForm(checkInDto, this.ruleDto).ShowDialog();
            }
        }

        private void cMenuItemCancel_Click(object sender, EventArgs e)
        {
            //To Do
        }

        private void cMenuItemDelete_Click(object sender, EventArgs e)
        {
            //To Do
        }

        private void cMenuItemView_Click(object sender, EventArgs e)
        {
            //if (dgvReservation.DataSource != null && dgvReservation.SelectedRows.Count > 0)
            //{
            //    RoomReservationRegisterDto dto = ((List<RoomReservationRegisterDto>)dgvReservation.DataSource)[this.dgvReservation.SelectedCells[0].RowIndex];
            //    //RoomReservationRegisterDto dto = ((List<RoomReservationRegisterDto>)dgvReservation.DataSource)[dgvReservation.SelectedRows[0].Index];
            //    this.OpenForm(dto);
            //}
        }

        private void OpenForm(LodgeFacade.RoomReservationRegister.Dto dto)
        {
            //if (dgvReservation.DataSource != null)
            //{
            //    AutoTourism.Facade.LodgeManagement.Reservation.Dto bookingDto = new Facade.LodgeManagement.Reservation.Dto()
            //    {
            //        Id = dto.Id,
            //        BookingFrom = dto.BookingFrom,
            //        NoOfDays = dto.NoOfDays,
            //        NoOfPersons = dto.NoOfPersons,
            //        NoOfRooms = dto.NoOfRooms,
            //        Advance = dto.Advance,
            //        Customer = dto.Customer,
            //        RoomList = dto.RoomList,
            //    };
            //    new RoomReservation(bookingDto, this.ruleDto)
            //    {
            //        MdiParent = this.MdiParent
            //    }.Show();
            //}
        }

        public enum LodgeReservationStatus
        {
            Open = 10001,
            Closed = 10002,
            Cancel = 10003,
            CheckIn = 10004
        }

          

    }

}
