using System;
using System.Windows.Forms;

using BinAff.Presentation.Library.Extension;
using BinAff.Utility;

using DocFac = Vanilla.Form.Facade.Document;

using RoomRsvFac = Retinue.Lodge.Facade.RoomReservation;

namespace Retinue.Lodge.WinForm
{

    public partial class ReservationSummary : UserControl
    {

        public ReservationSummary()
        {
            InitializeComponent();
        }

        public void LoadForm(DocFac.Dto dto)
        {
            RoomRsvFac.Dto data = dto as RoomRsvFac.Dto;
            if (data != null)
            {
                this.txtReservationNo.Text = data.ReservationNo;
                switch (data.Status)
                {
                    case RoomRsvFac.Status.Open:
                    case RoomRsvFac.Status.Canceled:
                        this.txtStatus.Text = data.ToString();
                        break;
                    case RoomRsvFac.Status.CheckedIn:
                        this.txtStatus.Text = "Checked In";
                        break;
                    case RoomRsvFac.Status.CheckOut:
                        this.txtStatus.Text = "Checked Out";
                        break;
                    case RoomRsvFac.Status.Invoiced:
                        this.txtStatus.Text = "Invoiced";
                        break;
                    case RoomRsvFac.Status.Paid:
                        this.txtStatus.Text = "Paid";
                        break;
                }

                if (dto.Id > 0)
                {
                    if (data.Customer != null)
                    {
                        this.ucCustomerSummary.LoadForm(data.Customer);
                    }

                    if (!ValidationRule.IsMinimumDate(data.BookingFrom))
                    {
                        this.txtDate.Text = data.BookingFrom.ToShortDateString();
                        this.txtTime.Text = data.BookingFrom.ToShortTimeString();
                    }

                    this.txtDays.Text = data.NoOfDays == 0 ? String.Empty : data.NoOfDays.ToString();
                    this.txtRooms.Text = data.NoOfRooms == 0 ? String.Empty : data.NoOfRooms.ToString();

                    if (data.RoomList != null && data.RoomList.Count > 0)
                    {
                        this.dgvRoom.AutoGenerateColumns = false;
                        this.dgvRoom.Columns[0].DataPropertyName = "Number";
                        this.dgvRoom.Columns[1].DataPropertyName = "Name";
                        this.dgvRoom.Columns[2].DataPropertyName = "Style";
                        this.dgvRoom.Columns[3].DataPropertyName = "ExtraAccomodation";
                        this.dgvRoom.DataSource = data.RoomList;
                    }

                    this.txtMale.Text = data.NoOfMale == 0 ? String.Empty : data.NoOfMale.ToString();
                    this.txtFemale.Text = data.NoOfFemale == 0 ? String.Empty : data.NoOfFemale.ToString();
                    this.txtChild.Text = data.NoOfChild == 0 ? String.Empty : data.NoOfChild.ToString();
                    this.txtInfant.Text = data.NoOfInfant == 0 ? String.Empty : data.NoOfInfant.ToString();                    
                }
            }
        }

        public void ClearForm()
        {
            this.ucCustomerSummary.ClearForm();
            this.txtReservationNo.Text = String.Empty;
            this.txtStatus.Text = String.Empty;
            this.txtDate.Text = String.Empty;
            this.txtTime.Text = String.Empty;
            this.txtDays.Text = String.Empty;
            this.txtRooms.Text = String.Empty;
            this.dgvRoom.Rows.Clear();
            this.txtMale.Text = String.Empty;
            this.txtFemale.Text = String.Empty;
            this.txtChild.Text = String.Empty;
            this.txtInfant.Text = String.Empty;
        }

        public Boolean IsEmpty()
        {
            if (!this.ucCustomerSummary.IsEmpty()) //Add other conds
            {
                return false;
            }
            return true;
        }

    }

}