using System;
using System.Collections.Generic;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;

using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;

namespace AutoTourism.Lodge.WinForm
{

    public partial class CheckInRegister : Form
    {

        private RuleFacade.Dto ruleDto;

        public CheckInRegister(RuleFacade.Dto ruleDto)
        {
            InitializeComponent();
            //base.IsOkButton = false;

            this.ruleDto = ruleDto;
            LoadForm();
        }

        //public static CheckInRegister Create(System.Windows.Forms.Form mdiParent)
        //{
        //    if (checkInRegister == null || checkInRegister.IsDisposed)
        //        checkInRegister = new CheckInRegister
        //        {
        //            ShowInTaskbar = false,
        //            MdiParent = mdiParent
        //        };
        //    else
        //        checkInRegister.Focus();
        //    return checkInRegister;
        //}

        private void LoadForm()
        {

            dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtBookingTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            if (this.ruleDto == null || this.ruleDto.ConfigurationRule == null || this.ruleDto.ConfigurationRule.DateFormat == String.Empty)            
            {
                dtCheckIn.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
                dtBookingTo.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
            }
            else
            {
                dtCheckIn.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;
                dtBookingTo.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;
            }


            List<Table> ReservationStatusList = new List<Table>();

            ReservationStatusList.Add(new Table()
            {
                Id = 0,
                Name = "All",
            });
            ReservationStatusList.Add(new Table()
            {
                Id = Convert.ToInt64(LodgeReservationStatus.CheckIn),
                Name = LodgeReservationStatus.CheckIn.ToString(),
            });
            ReservationStatusList.Add(new Table()
            {
                Id = Convert.ToInt64(LodgeReservationStatus.Closed),
                Name = LodgeReservationStatus.Closed.ToString(),
            });
            cmbReservationStatus.DataSource = ReservationStatusList;
            cmbReservationStatus.DisplayMember = "Name";
            cmbReservationStatus.ValueMember = "Id";

            //dgvCheckIn
            dgvCheckIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < dgvCheckIn.Columns.Count; i++) dgvCheckIn.Columns[i].ReadOnly = true;
            dgvCheckIn.MultiSelect = false;

            LodgeFacade.CheckInRegister.ICheckInRegister checkInRegister = new LodgeFacade.CheckInRegister.Server();
            ReturnObject<LodgeFacade.CheckInRegister.FormDto> ret = checkInRegister.LoadCheckInRegisterForm(Convert.ToInt64(LodgeReservationStatus.CheckIn), dtCheckIn.Value, dtBookingTo.Value);


            if (ret.Value.CheckInRegisterDtoList != null && ret.Value.CheckInRegisterDtoList.Count > 0)
                PopulateCheckInRegisterData(ret.Value.CheckInRegisterDtoList);

        }

        private void Clear()
        {
            dgvCheckIn.DataSource = null;

            txtFromDate.Text = String.Empty;
            txtDays.Text = String.Empty;
            txtPersons.Text = String.Empty;
            txtRooms.Text = String.Empty;
            txtAdvance.Text = String.Empty;
            lstRooms.DataSource = null; ;

            txtName.Text = String.Empty;
            lstContact.DataSource = null;
            txtAdds.Text = String.Empty;
            txtEmail.Text = String.Empty; 
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LodgeFacade.CheckInRegister.ICheckInRegister checkInRegister = new LodgeFacade.CheckInRegister.Server();
            ReturnObject<List<LodgeFacade.CheckInRegister.Dto>> ret = checkInRegister.Search(Convert.ToInt64(((Table)cmbReservationStatus.SelectedItem).Id), dtCheckIn.Value, dtBookingTo.Value);
                     
            Clear();

            if (ret.Value != null && ret.Value.Count > 0)
                PopulateCheckInRegisterData(ret.Value);
        }


        private void checkOutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer();           
            //ReturnObject<Boolean> retVal = new ReturnObject<bool>();

            //if (dgvCheckIn.DataSource != null && dgvCheckIn.SelectedRows.Count > 0)
            //{
            //    LodgeFacade.CheckInRegister.Dto dto = ((List<LodgeFacade.CheckInRegister.Dto>)dgvCheckIn.DataSource)[dgvCheckIn.SelectedRows[0].Index];

            //    LodgeFacade.RoomReservation.Dto reservationDto = new LodgeFacade.RoomReservation.Dto()
            //    {
            //        Id = dto.Reservation.Id,
            //        BookingStatusId = Convert.ToInt64(LodgeReservationStatus.Closed),
            //    };

            //    retVal = reservation.ChangeReservationStatus(reservationDto);

            //    //base.ShowMessage(retVal); //Show message  
            //}
        }

        //private void viewToolStripMenuItem_Click(object sender, System.EventArgs e)
        //{
        //    if (dgvCheckIn.DataSource != null)
        //        this.OpenForm(((List<CheckInRegisterDto>) dgvCheckIn.DataSource)[dgvCheckIn.SelectedRows[0].Index]);
        //}

        //private void invoiceToolStripMenuItem_Click(object sender, System.EventArgs e)
        //{
        //     if (dgvCheckIn.DataSource != null && dgvCheckIn.SelectedRows.Count > 0)
        //         this.OpenInvoice(((List<CheckInRegisterDto>)dgvCheckIn.DataSource)[dgvCheckIn.SelectedRows[0].Index]);
        //}

        private void dgvCheckIn_CellMouseDown(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            dgvCheckIn.Rows[e.RowIndex].Selected = true;
            if (dgvCheckIn.DataSource != null)
                PopulateCheckInDetails(((List<LodgeFacade.CheckInRegister.Dto>)dgvCheckIn.DataSource)[e.RowIndex]);
        }
        
        //private void dgvReservation_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        //{
        //    if (dgvCheckIn.DataSource != null)
        //        this.OpenForm(((List<CheckInRegisterDto>)dgvCheckIn.DataSource)[e.RowIndex]);
        //}

        private void PopulateCheckInRegisterData(List<LodgeFacade.CheckInRegister.Dto> checkInRegisterList)
        {
            if (checkInRegisterList != null && checkInRegisterList.Count > 0)
            {
                dgvCheckIn.Columns[0].DataPropertyName = "CheckInDate";
                dgvCheckIn.Columns[1].DataPropertyName = "Name";
                dgvCheckIn.Columns[2].DataPropertyName = "ContactNumber";
                dgvCheckIn.Columns[3].DataPropertyName = "StartDate";
                dgvCheckIn.Columns[4].DataPropertyName = "EndDate";
                dgvCheckIn.Columns[5].DataPropertyName = "Room";
                dgvCheckIn.Columns[6].DataPropertyName = "Advance";

                dgvCheckIn.AutoGenerateColumns = false;
                dgvCheckIn.DataSource = checkInRegisterList;

                PopulateCheckInDetails(checkInRegisterList[0]);
            }
        }

        private void PopulateCheckInDetails(LodgeFacade.CheckInRegister.Dto dto)
        {
            //populate reservation data
            txtFromDate.Text = dto.StartDate.ToString();//
            txtDays.Text = dto.Reservation.NoOfDays == 0 ? String.Empty : dto.Reservation.NoOfDays.ToString();
            //txtPersons.Text = dto.Reservation.NoOfPersons == 0 ? String.Empty : dto.Reservation.NoOfPersons.ToString();
            txtRooms.Text = dto.Reservation.NoOfRooms == 0 ? String.Empty : dto.Reservation.NoOfRooms.ToString();
            txtAdvance.Text = dto.Advance == 0 ? String.Empty : Converter.ConvertToIndianCurrency(dto.Advance);
            lstRooms.DataSource = dto.Reservation.RoomList;
            lstRooms.DisplayMember = "Number";
            lstRooms.ValueMember = "Id";
            lstRooms.SelectedIndex = -1;

            if (dto.Reservation.Customer != null)
            {
                //populate customer data
                txtName.Text = dto.Reservation.Customer.Name;
                //txtName.Text = (dto.Reservation.Customer.Initial == null ? String.Empty : dto.Reservation.Customer.Initial.Name) + " "
                //    + dto.Reservation.Customer.FirstName + " "
                //    + dto.Reservation.Customer.MiddleName + " "
                //    + dto.Reservation.Customer.LastName;
                lstContact.DataSource = dto.Reservation.Customer.ContactNumberList;
                lstContact.DisplayMember = "Name";
                lstContact.ValueMember = "Id";
                lstContact.SelectedIndex = -1;
                txtAdds.Text = dto.Reservation.Customer.Address;
                txtEmail.Text = dto.Reservation.Customer.Email;
            }
        }
        
        //private void OpenForm(CheckInRegisterDto dto)
        //{
        //    AutoTourism.Facade.LodgeManagement.CheckIn.Dto checkInDto = new Dto()
        //    {
        //        Reservation = new AutoTourism.Facade.LodgeManagement.Reservation.Dto()
        //        {
        //            Id = dto.Reservation.Id,
        //            BookingDate = dto.Reservation.BookingDate,
        //            BookingFrom = dto.Reservation.BookingFrom,
        //            NoOfDays = dto.Reservation.NoOfDays,
        //            NoOfPersons = dto.Reservation.NoOfPersons,
        //            NoOfRooms = dto.Reservation.NoOfRooms,
        //            Advance = dto.Reservation.Advance,
        //            BookingStatusId = dto.Reservation.BookingStatusId,

        //            RoomList = dto.Reservation.RoomList,
        //            Customer = dto.Reservation.Customer,
        //        }
        //    };

        //    new CheckInForm(checkInDto, ruleDto) 
        //    { 
        //        MdiParent = this.MdiParent
        //    }.Show();            
        //}

        //private void OpenInvoice(CheckInRegisterDto dto)
        //{
        //    Boolean blnAdd = true;
        //    AutoTourism.Facade.LodgeManagement.Invoice.FormDto formDto = new Facade.LodgeManagement.Invoice.FormDto();
        //    formDto.checkInRegisterDto = dto;
        //    formDto.invoiceList = new List<Facade.LodgeManagement.Invoice.Dto>();

        //    if (dto.Reservation.RoomList != null && dto.Reservation.RoomList.Count > 0)
        //    {
        //        foreach (AutoTourism.Facade.Configuration.Room.Dto dtoRoom in dto.Reservation.RoomList)
        //        {
        //            AutoTourism.Facade.LodgeManagement.Invoice.Dto dtoInvoice = new Facade.LodgeManagement.Invoice.Dto()
        //            {
        //                startDate = dto.StartDate.ToShortDateString(),
        //                roomCategoryId = dtoRoom.Category.Id,
        //                roomTypeId = dtoRoom.Type.Id,
        //                roomIsAC = dtoRoom.IsAirconditioned,
        //                description = dtoRoom.Description,
        //                count = 1, //count is basically rooms of same type [i.e. same typeid, categoryId, and Ac] 
        //                endDate = dto.EndDate.ToShortDateString(),
        //            };

        //            if (formDto.invoiceList.Count == 0)
        //                formDto.invoiceList.Add(dtoInvoice);
        //            else
        //            {
        //                blnAdd = true;
        //                foreach (AutoTourism.Facade.LodgeManagement.Invoice.Dto invoiceDto in formDto.invoiceList)
        //                {
        //                    if (dtoRoom.Category.Id == invoiceDto.roomCategoryId && dtoRoom.Type.Id == invoiceDto.roomTypeId &&
        //                        dtoRoom.IsAirconditioned == invoiceDto.roomIsAC)
        //                    {
        //                        invoiceDto.count += 1;
        //                        blnAdd = false;
        //                        break;
        //                    }
        //                }
        //                if(blnAdd)
        //                    formDto.invoiceList.Add(dtoInvoice);
        //            }
        //        }
        //    }
        //    new Invoice(formDto, this.ruleDto.TaxRule)
        //    { 
        //        MdiParent = this.MdiParent
        //    }.Show();
        //}

        public enum LodgeReservationStatus
        {
            Open = 10001,
            Closed = 10002,
            Cancel = 10003,
            CheckIn = 10004
        }
        
    }

}
