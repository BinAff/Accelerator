using System;
using System.Text;
using System.Collections.Generic;

using BinAff.Core;

//using AutoTourism.Facade.CustomerManagement;
//using AutoTourism.Facade.LodgeManagement.Reservation;

//using AutoTourism.Presentation.Library;
using PresentationLibrary = BinAff.Presentation.Library;
using CustomerFacade = AutoTourism.Customer.Facade;

namespace AutoTourism.Customer.WinForm
{

    public partial class CustomerRegister : PresentationLibrary.Form
    {
        private CustomerFacade.FormDto formDto;
        //private List<Facade.LodgeManagement.Reservation.Dto> reservationDtoList;
        //private Facade.CustomerManagement.Rule.Dto customerRule;

        //public CustomerRegister(AutoTourism.Facade.CustomerManagement.Rule.Dto customerRuleDto)
        //{
        //    InitializeComponent();

        //    base.IsOpenButton = false;
        //    base.IsCloseButton = false;

        //    this.customerRule = customerRuleDto;
        //}

        public CustomerRegister()
        {
            InitializeComponent();
        }

        private void CustomerRegister_Load(object sender, System.EventArgs e)
        {
            LoadForm();
            Clear();

            //-- code below will be removed from here            
            btnBook.Hide();
        }

        private void cboContact_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    if (this.cboCustomer.SelectedIndex != -1)
            //    {
            //        this.contextMenu.Items["menuItemView"].Visible = true;

            //        this.contextMenu.Items["menuItemRegister"].Visible = false;
            //        this.contextMenu.Show(this.cboCustomer, e.Location);
            //    }
            //    else
            //    {
            //        this.contextMenu.Items["menuItemView"].Visible = false;

            //        this.contextMenu.Items["menuItemRegister"].Visible = true;
            //        this.contextMenu.Show(this.cboCustomer, e.Location);
            //    }
            //}
        }

        private void cboCustomer_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (cboCustomer.SelectedIndex != -1)
            //{
            //    AutoTourism.Facade.CustomerManagement.Dto dto = (AutoTourism.Facade.CustomerManagement.Dto)cboCustomer.SelectedItem;
            //    txtName.Text = (dto.Initial == null ? String.Empty : dto.Initial.Name)
            //        + dto.FirstName + " " + dto.MiddleName + " " + dto.LastName;
            //    txtAdds.Text = dto.Address;
            //    txtEmail.Text = dto.Email;
            //    this.lblIdProofTypeName.Text = dto.IdentityProofType.Name;
            //    this.txtIdentityProofNo.Text = dto.IdentityProofName;

            //    lstContact.DataSource = null;
            //    if (dto.ContactNumberList != null && dto.ContactNumberList.Count > 0)
            //    {
            //        lstContact.DataSource = dto.ContactNumberList;
            //        lstContact.DisplayMember = "Name";
            //        lstContact.ValueMember = "Id";
            //        lstContact.SelectedIndex = -1;
            //    }

            //    //load booking data
            //    IReservation reservation = new ReservationServer();
            //    ReturnObject<List<AutoTourism.Facade.LodgeManagement.Reservation.Dto>> reservationList = reservation.GetBooking(dto.Id);
            //    if (!reservationList.HasError() && reservationList.Value != null)
            //    {
            //        //populate the Global variable with reservation data
            //        this.reservationDtoList = reservationList.Value;

            //        AutoTourism.Facade.CustomerManagement.FormDto formDto = new Facade.CustomerManagement.FormDto()
            //        {
            //            ReservationList = new List<LodgeReservationDto>(),
            //        };

            //        foreach (AutoTourism.Facade.LodgeManagement.Reservation.Dto reservationDto in reservationList.Value)
            //        {
            //            formDto.ReservationList.Add(new LodgeReservationDto()
            //            {
            //                Id = reservationDto.Id,
            //                BookingDate = DateTime.Today.ToShortDateString(),
            //                StartDate = reservationDto.BookingFrom.ToShortDateString(),
            //                EndDate = reservationDto.BookingFrom.AddDays(reservationDto.NoOfDays).ToShortDateString(),
            //                Rooms = GetRooms(reservationDto.RoomList),
            //                Advance = reservationDto.Advance,
            //            });
            //        }

            //        dgvBooking.Columns[0].DataPropertyName = "BookingDate";
            //        dgvBooking.Columns[1].DataPropertyName = "StartDate";
            //        dgvBooking.Columns[2].DataPropertyName = "EndDate";
            //        dgvBooking.Columns[3].DataPropertyName = "Rooms";
            //        dgvBooking.Columns[4].DataPropertyName = "Advance";
            //        dgvBooking.Columns[4].HeaderText = "Advance Taken";
            //        dgvBooking.AutoGenerateColumns = false;
            //        dgvBooking.DataSource = formDto.ReservationList;

            //    }
            //}

        }

        private void cboCustomer_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (cboCustomer.SelectedIndex != -1)
            //{
            //    this.View();
            //}
        }

        //protected override void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    this.Clear();
        //    this.LoadForm();
        //}

        //protected override void btnAdd_Click(object sender, EventArgs e)
        //{
        //    this.Register();
        //}

        //protected override void btnDelete_Click(object sender, EventArgs e)
        //{
        //    //To Do
        //}

        //protected override void btnChange_Click(object sender, EventArgs e)
        //{
        //    this.View();
        //}

        private void btnBook_Click(object sender, System.EventArgs e)
        {
            this.Book();
        }

        private void dgvBooking_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //if (this.cboCustomer.SelectedIndex != -1 && this.reservationDtoList != null)
            //{   
            //    AutoTourism.Facade.LodgeManagement.Reservation.Dto reservationDto = this.reservationDtoList[e.RowIndex];
            //    AutoTourism.Facade.LodgeManagement.Reservation.Dto bookingDto = new Facade.LodgeManagement.Reservation.Dto()
            //    {
            //        Id = reservationDto.Id,
            //        BookingFrom = reservationDto.BookingFrom,
            //        NoOfDays = reservationDto.NoOfDays,
            //        NoOfPersons = reservationDto.NoOfPersons,
            //        NoOfRooms = reservationDto.NoOfRooms,
            //        Advance = reservationDto.Advance,
            //        Customer = (AutoTourism.Facade.CustomerManagement.Dto)this.cboCustomer.SelectedItem,
            //        RoomList = reservationDto.RoomList,
            //    };

            //    this.Close();
            //    //new Lodge.RoomReservation(bookingDto,).Show(this.Owner);
            //}

        }

        private void menuItemView_Click(object sender, System.EventArgs e)
        {
            //this.View();
        }

        private void menuItemUpdate_Click(object sender, System.EventArgs e)
        {
            //this.View();
        }

        private void menuItemDelete_Click(object sender, System.EventArgs e)
        {
            //Delete
        }

        private void menuItemBook_Click(object sender, System.EventArgs e)
        {
            this.Book();
        }

        private void menuItemRegister_Click(object sender, System.EventArgs e)
        {
            this.Register();
        }

        private void LoadForm()
        {
            CustomerFacade.FormDto formDto = new CustomerFacade.FormDto();
            BinAff.Facade.Library.Server facade = new CustomerFacade.Server(formDto);
            facade.LoadForm();

            this.formDto = formDto;
            if (formDto.DtoList != null && formDto.DtoList.Count > 0)
            {
                this.cboCustomer.DataSource = formDto.DtoList;
                this.cboCustomer.DisplayMember = "FirstName";
                this.cboCustomer.ValueMember = "Id";
                this.cboCustomer.SelectedIndex = -1;
            }            

        }

        private void Clear()
        {
            this.txtName.Text = String.Empty;
            this.txtAdds.Text = String.Empty;
            this.lstContact.DataSource = null;
            this.txtEmail.Text = String.Empty;

            dgvBooking.DataSource = null;
        }

        //private String GetRooms(List<Facade.Configuration.Room.Dto> roomList)
        //{
        //    if (roomList == null || roomList.Count == 0)
        //        return String.Empty;

        //    StringBuilder strbRoom = new StringBuilder();
        //    foreach (Facade.Configuration.Room.Dto room in roomList)
        //        strbRoom.Append(", " + room.Number.ToString());

        //    return strbRoom.ToString().Substring(1);
        //}

        private void Register()
        {
            new CustomerForm
            {
                MdiParent = this.MdiParent,
            }.Show();
        }

        //private void View()
        //{
        //    new CustomerForm((Facade.CustomerManagement.Dto)this.cboCustomer.SelectedItem)
        //    {
        //        MdiParent = this.MdiParent,
        //    }.Show();
        //}

        private void Book()
        {
            //if (this.cboCustomer.SelectedIndex != -1)
            //{
            //    AutoTourism.Facade.LodgeManagement.Reservation.Dto bookingDto = new Facade.LodgeManagement.Reservation.Dto()
            //    {
            //        Customer = (AutoTourism.Facade.CustomerManagement.Dto)this.cboCustomer.SelectedItem,
            //    };
            //    new Lodge.RoomReservation(bookingDto, customerRule)
            //    {
            //        MdiParent = this.MdiParent,
            //    }.Show();

            //    this.Close();
            //}
        }
                
    }

}
