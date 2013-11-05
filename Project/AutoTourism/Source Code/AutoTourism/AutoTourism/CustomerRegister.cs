
using System;
using System.Windows.Forms;
using System.Collections.Generic;

using AutoTourism.Customer.WinForm;
using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;


namespace AutoTourism
{
    public partial class CustomerRegister : Form
    {
        public CustomerRegister()
        {
            InitializeComponent();
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
            CustomerFacade.Dto customerDto = new CustomerFacade.Dto(); ;
            PersonalInformation personalInformation = panel1.Controls[0] as PersonalInformation;
            
            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer" && ((control as ComboBox).SelectedIndex != -1))
                {
                    customerDto = (CustomerFacade.Dto)(control as ComboBox).SelectedItem;

                    //load booking data
                    if (customerDto.reservationList != null && customerDto.reservationList.Count > 0)
                    {
                        LodgeFacade.BookingDetails.FormDto bookingDetailsFormDto = new LodgeFacade.BookingDetails.FormDto { 
                            bookingDetailList = new List<LodgeFacade.BookingDetails.Dto>()
                        };

                        foreach (CustomerFacade.Lodge.Reservation.Dto reservationDto in customerDto.reservationList)
                        {
                            bookingDetailsFormDto.bookingDetailList.Add(new LodgeFacade.BookingDetails.Dto
                            {
                                Id = reservationDto.Id,
                                BookingDate = DateTime.Today.ToShortDateString(),
                                StartDate = reservationDto.BookingFrom.ToShortDateString(),
                                EndDate = reservationDto.BookingFrom.AddDays(reservationDto.NoOfDays).ToShortDateString(),
                                //Rooms = GetRooms(reservationDto.RoomList),
                                Advance = reservationDto.Advance,
                            });
                        }

                        if (bookingDetailsFormDto.bookingDetailList != null && bookingDetailsFormDto.bookingDetailList.Count > 0)
                        {
                            foreach (Control bookingDetailsControl in this.bookingDetails1.Controls)
                            {
                                if (bookingDetailsControl.Name == "dgvBooking")
                                {
                                    DataGridView dgvBooking = bookingDetailsControl as DataGridView;

                                    dgvBooking.Columns[0].DataPropertyName = "BookingDate";
                                    dgvBooking.Columns[1].DataPropertyName = "StartDate";
                                    dgvBooking.Columns[2].DataPropertyName = "EndDate";
                                    dgvBooking.Columns[3].DataPropertyName = "Rooms";
                                    dgvBooking.Columns[4].DataPropertyName = "Advance";
                                    dgvBooking.Columns[4].HeaderText = "Advance Taken";
                                    dgvBooking.AutoGenerateColumns = false;
                                    dgvBooking.DataSource = bookingDetailsFormDto.bookingDetailList;

                                    break;
                                }
                            }
                        }                      
                    }

                    break;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = panel1.Controls[0] as PersonalInformation;
            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer")
                    (control as ComboBox).SelectedIndex = -1;
                else if (control.Name == "lblIdProofTypeName")
                    (control as Label).Text = String.Empty;
                else if (control.GetType() == typeof(TextBox))                
                    (control as TextBox).Text = String.Empty;
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

            //AutoTourism.Facade.LodgeManagement.Reservation.Dto bookingDto = new Facade.LodgeManagement.Reservation.Dto()
            //{
            //    Customer = (AutoTourism.Facade.CustomerManagement.Dto)this.cboCustomer.SelectedItem,
            //};
            //new Lodge.RoomReservation(bookingDto, ruleDto)
            //{
            //    MdiParent = this.MdiParent,
            //}.Show();

            //this.Close();

            this.f();
            PersonalInformation personalInformation = panel1.Controls[0] as PersonalInformation;
            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer" && ((control as ComboBox).SelectedIndex != -1))
                {
                    CustomerFacade.Dto customerDto = (CustomerFacade.Dto)(control as ComboBox).SelectedItem;
                    //new CustomerForm(customerDto).ShowDialog();
                    break;
                }
            }
        }

        private void f()
        {
            PersonalInformation p = this.panel1.Controls[0] as PersonalInformation;
            //PersonalInformation p = this.panel1.Controls.Find("personalInformation", true)[0] as PersonalInformation;
            Int64 customerId = p.CurrentItem.Id; //id for customer
        }
    }
}
