
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

using AutoTourism.Customer.WinForm;
using AutoTourism.Lodge.WinForm;

using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;
using RuleFacade = Autotourism.Configuration.Rule.Facade;

namespace AutoTourism
{
    public partial class CustomerRegister : Form
    {
        private RuleFacade.Dto ruleDto;

        public CustomerRegister()
        {
            InitializeComponent();            
        }

        public CustomerRegister(RuleFacade.Dto ruleDto)
        {
            InitializeComponent();
            this.ruleDto = ruleDto;
        }

        private void CustomerRegister_Load(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = new PersonalInformation
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = System.Drawing.Color.White
            };
            panel1.Controls.Add(personalInformation);
            personalInformation.Show();

            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer")
                {
                    (control as ComboBox).MouseClick += CustomerRegister_MouseClick;
                    break;
                }
            }
        }

        void CustomerRegister_MouseClick(object sender, MouseEventArgs e)
        {            
            PersonalInformation personalInformation = panel1.Controls[0] as PersonalInformation;
            
            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer" && ((control as ComboBox).SelectedIndex != -1))
                {
                    //load booking data
                    LoadBookingDetail((CustomerFacade.Dto)(control as ComboBox).SelectedItem);
                    break;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = panel1.Controls[0] as PersonalInformation;

            //clear customer form
            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer")
                    (control as ComboBox).SelectedIndex = -1;
                else if (control.Name == "lblIdProofTypeName")
                    (control as Label).Text = String.Empty;
                else if (control.GetType() == typeof(TextBox))                
                    (control as TextBox).Text = String.Empty;
            }

            //clear booking detail grid
            DataGridView dgvBooking = null;
            foreach (Control bookingDetailsControl in this.bookingDetails1.Controls)
            {
                if (bookingDetailsControl.Name == "dgvBooking")
                {
                    dgvBooking = bookingDetailsControl as DataGridView;
                    dgvBooking.DataSource = null;
                    break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new CustomerForm().ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {           
            PersonalInformation personalInformation = panel1.Controls[0] as PersonalInformation;
            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer" && ((control as ComboBox).SelectedIndex != -1))
                {
                    CustomerFacade.Dto customerDto = (CustomerFacade.Dto)(control as ComboBox).SelectedItem;
                    new CustomerForm(customerDto).ShowDialog();
                    break;
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = panel1.Controls[0] as PersonalInformation;            
            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer" && ((control as ComboBox).SelectedIndex != -1))
                {                   
                    new RoomReservationForm(new LodgeFacade.RoomReservation.Dto
                                                {
                                                    Customer = (CustomerFacade.Dto)(control as ComboBox).SelectedItem
                                                }, this.ruleDto).ShowDialog();
                    break;
                }
            }
        }       
       
        private void LoadBookingDetail(CustomerFacade.Dto customerDto)
        {
            DataGridView dgvBooking = null;
            foreach (Control bookingDetailsControl in this.bookingDetails1.Controls)
            {
                if (bookingDetailsControl.Name == "dgvBooking")
                {
                    dgvBooking = bookingDetailsControl as DataGridView;

                    dgvBooking.Columns[0].DataPropertyName = "BookingDate";
                    dgvBooking.Columns[1].DataPropertyName = "StartDate";
                    dgvBooking.Columns[2].DataPropertyName = "EndDate";
                    dgvBooking.Columns[3].DataPropertyName = "Rooms";
                    dgvBooking.Columns[4].DataPropertyName = "Advance";
                    dgvBooking.Columns[4].HeaderText = "Advance Taken";
                    dgvBooking.AutoGenerateColumns = false;

                    break;
                }
            }

            LodgeFacade.BookingDetails.FormDto bookingDetailsFormDto = new LodgeFacade.BookingDetails.FormDto
            {
                bookingDetailList = new List<LodgeFacade.BookingDetails.Dto>()
            };


            //if (customerDto != null && customerDto.reservationList != null && customerDto.reservationList.Count > 0)
            //{
            //    foreach (CustomerFacade.Lodge.Reservation.Dto reservationDto in customerDto.reservationList)
            //    {
            //        bookingDetailsFormDto.bookingDetailList.Add(new LodgeFacade.BookingDetails.Dto
            //        {
            //            Id = reservationDto.Id,
            //            BookingDate = DateTime.Today.ToShortDateString(),
            //            StartDate = reservationDto.BookingFrom.ToShortDateString(),
            //            EndDate = reservationDto.BookingFrom.AddDays(reservationDto.NoOfDays).ToShortDateString(),
            //            Rooms = GetRooms(reservationDto.RoomList),
            //            Advance = reservationDto.Advance,
            //        });
            //    }
            //}

            if (dgvBooking != null)
                dgvBooking.DataSource = bookingDetailsFormDto.bookingDetailList;
        }

        private String GetRooms(List<CustomerFacade.Lodge.Room.Dto> roomList)
        {
            if (roomList == null || roomList.Count == 0)
                return String.Empty;

            StringBuilder strbRoom = new StringBuilder();
            foreach (CustomerFacade.Lodge.Room.Dto room in roomList)
                strbRoom.Append(", " + room.Number.ToString());

            return strbRoom.ToString().Substring(1);
        }

       
    }
}
