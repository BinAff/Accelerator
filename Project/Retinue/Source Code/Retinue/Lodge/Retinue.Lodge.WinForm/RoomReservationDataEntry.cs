using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using BinAff.Core;
using BinAff.Utility;
using BinAff.Presentation.Library.Extension;

using RsvFac = Retinue.Lodge.Facade.RoomReservation;
using RoomFac = Retinue.Lodge.Configuration.Facade.Room;
using RoomCatFac = Retinue.Lodge.Configuration.Facade.Room.Category;
using RoomTypeFac = Retinue.Lodge.Configuration.Facade.Room.Type;
using RoomDtlsFac = Retinue.Lodge.Facade.RoomReservation.RoomDetails;

namespace Retinue.Lodge.WinForm
{

    public partial class RoomReservationDataEntry : UserControl
    {

        internal List<RoomCatFac.Dto> CategoryList { get; set; }

        internal List<RoomTypeFac.Dto> TypeList { get; set; }

        internal List<Table> AccessoryList { get; set; }

        internal List<RoomFac.Dto> RoomList { get; set; }

        internal RsvFac.Status ReservationStatus
        {
            get
            {
                return (txtStatus.Text == "Cancel") ? RsvFac.Status.Open : RsvFac.Status.Canceled;
            }
        }

        private List<RoomFac.Dto> filteredRoomList;
        private Boolean isLoading = false;

        private RsvFac.Dto dto;

        internal delegate void OnRoomListChange(Int16 days, DateTime from);
        internal event OnRoomListChange RoomListChanged;

        public RoomReservationDataEntry()
        {
            InitializeComponent();
            this.isLoading = true;
            this.CategoryList = new List<RoomCatFac.Dto>();
            this.TypeList = new List<RoomTypeFac.Dto>();
            this.RoomList = new List<RoomFac.Dto>();
            this.tpnlContainer.Dock = DockStyle.Fill;
        }

        #region Event

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            this.AddRoom(this.lstRoomList.SelectedItem as RoomFac.Dto);
        }

        private void lstRoomList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.AddRoom(this.lstRoomList.SelectedItem as RoomFac.Dto);
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            this.RemoveRoom(this.lstSelectedRoom.SelectedItem as RoomDtlsFac.Dto);
        }

        private void lstSelectedRoom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.RemoveRoom(this.lstSelectedRoom.SelectedItem as RoomDtlsFac.Dto);
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoading) this.PopulateRoomListsAndCounts();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoading) this.PopulateRoomListsAndCounts();
        }

        private void cboAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateRoomListsAndCounts();
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            if (this.RoomListChanged != null)
            {
                this.ResetRoomList();
            }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (this.RoomListChanged != null)
            {
                this.ResetRoomList();
            }
        }

        #endregion

        private void ResetRoomList()
        {
            Int16 days = Convert.ToInt16(String.IsNullOrEmpty(this.txtDays.Text) ? 0 : Convert.ToInt16(this.txtDays.Text.Trim()));
            DateTime from = new DateTime(this.dtFrom.Value.Year, this.dtFrom.Value.Month, this.dtFrom.Value.Day,
                this.dtFromTime.Value.Hour, this.dtFromTime.Value.Minute, 0);
            if (this.dto != null) this.RoomListChanged(days, from);
            this.PopulateRoomListsAndCounts();
        }

        internal void LoadForm(RsvFac.Dto dto)
        {
            this.dto = dto;
            this.cboCategory.Bind(this.CategoryList, "Name");
            this.cboType.Bind(this.TypeList, "Name");
            this.cboAC.Bind(this.AccessoryList, "Name");
            if (this.dto == null || this.dto.Id == 0) this.isLoading = false;
        }

        internal void SetDefault()
        {
            this.dtFrom.Format = DateTimePickerFormat.Custom;
            this.dtFrom.CustomFormat = "dd/MM/yyyy"; //--MM should be in upper case
            if (this.dto == null || this.dto.Id == 0)
            {
                try
                {
                    //this.dtFrom.Checked = false;
                    this.dtFrom.Value = DateTime.Now;
                }
                catch
                {
                    throw;
                }
                //this.dtFrom.Checked = true;

                //Commented Old Code
                //this.dtFromTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                //    DateTime.Now.Minute >= 45 ? DateTime.Now.Hour + 1 : DateTime.Now.Hour,
                //    DateTime.Now.Minute < 14 ? 15 : DateTime.Now.Minute < 29 ? 30 : DateTime.Now.Minute < 44 ? 45 : 00, 00);

                //22-05-2015- Hassan
                int dYear = DateTime.Now.Year;
                int dMonth = DateTime.Now.Month;
                int dDay = DateTime.Now.Day;
                int dHour = DateTime.Now.Hour;
                int dMinute = DateTime.Now.Minute;
                int daysInMonth = DateTime.DaysInMonth(dYear, dMonth);

                //Hour and Minute calculation
                if (dMinute >= 45)
                {
                    dHour = DateTime.Now.Hour + 1;
                    dMinute = 00;
                }
                if (dMinute > 0 && dMinute < 14)
                {
                    dMinute = 15;
                }
                else if (dMinute < 29 && dMinute > 15)
                {
                    dMinute = 30;
                }

                //Day, Month and Year Calculation
                if (dHour > 23)
                {
                    dDay += 1;
                    dHour = 0;
                    dMinute = 0;
                }
                if (dDay > daysInMonth)
                {
                    dMonth += 1;
                    dDay = 1;
                    dHour = 0;
                    dMinute = 0;
                }
                if (dMonth > 12)
                {
                    dYear += 1;
                    dMonth = 1;
                    dDay = 1;
                    dHour = 0;
                    dMinute = 0;
                }
                this.dtFromTime.Value = new DateTime(dYear, dMonth, dDay, dHour, dMinute, 00);

                this.cboCategory.SelectedIndex = 0;
                this.cboType.SelectedIndex = 0;
                this.cboAC.SelectedIndex = 0;
            }
        }

        internal void ClearForm()
        {
            this.dtFrom.Value = DateTime.Now;
            this.dtFromTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, 0, 0);
            this.txtDays.Text = String.Empty;
            this.txtRooms.Text = String.Empty;
            this.cboCategory.SelectedIndex = -1;
            this.cboType.SelectedIndex = -1;
            this.cboAC.SelectedIndex = -1;
            this.lstRoomList.Items.Clear();
            this.lstSelectedRoom.Items.Clear();
            this.txtMale.Text = String.Empty;
            this.txtFemale.Text = String.Empty;
            this.txtChild.Text = String.Empty;
            this.txtInfant.Text = String.Empty;
            this.txtRemarks.Text = String.Empty;
            this.txtStatus.Text = String.Empty;

            this.txtFilteredRoomCount.Text = String.Empty;
            this.txtAvailableRoomCount.Text = String.Empty;
        }

        internal Boolean IsEmpty()
        {
            //if (String.IsNullOrEmpty(this.txtName.Text))
            //{
            //    return false;
            //}
            return true;
        }

        internal BinAff.Core.Message ManageExtraBed()
        {
            BinAff.Core.Message message = new BinAff.Core.Message();
            Int32 availableBed = 0;
            Int32 availableExtraBed = 0;
            Int32 totalNoOfGuest = (String.IsNullOrEmpty(this.txtMale.Text.Trim()) ? 0 : Convert.ToInt32(this.txtMale.Text))
                + (String.IsNullOrEmpty(this.txtFemale.Text.Trim()) ? 0 : Convert.ToInt32(this.txtFemale.Text));
            Int32 noOfRooms = Convert.ToInt32(this.txtRooms.Text);
            RoomTypeFac.Dto roomType = this.cboType.SelectedItem as RoomTypeFac.Dto;
            if (this.dto.RoomList == null)
            {
                if (totalNoOfGuest == 1 && noOfRooms == 1)
                {
                    return message;
                }
                else if (roomType == null || roomType.Name == "All")
                {
                    message.Description = "Unable to calculate accomodation for guests. Room type is required for sugession. Do you want to Continue?";
                    message.Category = BinAff.Core.Message.Type.Question;
                    return message;
                }
                else
                {
                    availableBed = roomType.Accomodation * noOfRooms;
                    availableExtraBed = roomType.ExtraAccomodation * noOfRooms;
                }
            }
            else
            {
                foreach (RoomDtlsFac.Dto product in this.dto.RoomList)
                {
                    availableBed += product.Room.Accomodation;
                    availableExtraBed += product.Room.ExtraAccomodation;
                }
            }
            if (totalNoOfGuest > availableBed + availableExtraBed)
            {
                message.Description = String.Format("Available bed: {0} + {1} = {2}", availableBed, availableExtraBed, availableBed + availableExtraBed) + Environment.NewLine;
                message.Description += String.Format("Total Guest: {0}({1})", totalNoOfGuest, this.dto.NoOfChild) + Environment.NewLine + Environment.NewLine;
                message.Description += String.Format("Reservation not allowed.", totalNoOfGuest, this.dto.NoOfChild);
                message.Category = BinAff.Core.Message.Type.Error;
            }
            else if (totalNoOfGuest == availableBed + availableExtraBed)
            {
                message.Description = String.Format("Available bed: {0}", availableBed) + Environment.NewLine;
                message.Description += String.Format("Available extra bed: {0}", availableExtraBed) + Environment.NewLine;
                message.Description += String.Format("Total guests: {0}(Child - {1})", totalNoOfGuest, this.dto.NoOfChild) + Environment.NewLine + Environment.NewLine;
                message.Description += String.Format("Extra bed required: {0}", totalNoOfGuest - availableBed) + Environment.NewLine;
                message.Category = BinAff.Core.Message.Type.Information;
                if (this.dto.RoomList != null && this.dto.RoomList.Count > 0)
                {
                    foreach (RoomDtlsFac.Dto product in this.dto.RoomList)
                    {
                        product.ExtraAccomodation = product.Room.ExtraAccomodation;
                    }
                }
            }
            else if (totalNoOfGuest > availableBed)
            {
                message.Description = String.Format("Available bed: {0}", availableBed) + Environment.NewLine;
                message.Description += String.Format("Available extra bed: {0}", availableExtraBed) + Environment.NewLine;
                message.Description += String.Format("Total guests: {0}(Child - {1})", totalNoOfGuest, this.dto.NoOfChild) + Environment.NewLine + Environment.NewLine;
                message.Description += String.Format("Extra bed required: {0}", totalNoOfGuest - availableBed) + Environment.NewLine + Environment.NewLine;
                message.Category = BinAff.Core.Message.Type.Information;
                if (this.lstSelectedRoom.Items == null || this.lstSelectedRoom.Items.Count == 0)
                {
                    message.Description += String.Format("Since rooms are not choosen, assumption is every '{0}' will have {1} extra bed.",
                        roomType.Name, roomType.ExtraAccomodation);
                }
                else
                {
                    ExtraBedCaptureForm frm = new ExtraBedCaptureForm
                    {
                        TotalGuest = totalNoOfGuest,
                    };

                    foreach (RoomDtlsFac.Dto product in this.lstSelectedRoom.Items)
                    {
                        RoomDtlsFac.Dto existingProduct = this.dto.RoomList.Find((p) =>
                        {
                            return p.Room.Id == product.Room.Id;
                        });
                        frm.DataSource.Add(existingProduct != null ? existingProduct : new RoomDtlsFac.Dto
                        {
                            ExtraAccomodation = product.ExtraAccomodation,
                            Room = product.Room
                        });
                    }
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        this.dto.RoomList = frm.DataSource;
                    }
                    else
                    {
                        message.Description = "Extra room details is not captured";
                        message.Category = BinAff.Core.Message.Type.Error;
                    }
                }
            }
            return message;
        }

        internal Boolean ValidateForm(ErrorProvider errorProvider)
        {
            Boolean retVal = true;
            errorProvider.Clear();

            if (ValidationRule.IsDateLessThanToday(this.dtFrom.Value))
            {
                errorProvider.SetError(this.dtFrom, "Booking date cannot be less than today.");
                this.dtFrom.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtDays.Text.Trim()))
            {
                errorProvider.SetError(this.txtDays, "Please enter days.");
                this.txtDays.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtDays.Text.Trim())))
            {
                errorProvider.SetError(this.txtDays, "Entered '" + this.txtDays.Text + "' is Invalid.");
                this.txtDays.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtRooms.Text))
            {
                errorProvider.SetError(this.txtRooms, "Please enter rooms.");
                this.txtRooms.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtRooms.Text.Trim())))
            {
                errorProvider.SetError(this.txtRooms, "Entered '" + this.txtRooms.Text + "' is Invalid.");
                this.txtRooms.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtMale.Text.Trim())))
            {
                errorProvider.SetError(this.txtMale, "Entered '" + this.txtMale.Text + "' is Invalid.");
                this.txtMale.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtFemale.Text.Trim())))
            {
                errorProvider.SetError(this.txtFemale, "Entered '" + this.txtFemale.Text + "' is Invalid.");
                this.txtFemale.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtChild.Text.Trim())))
            {
                errorProvider.SetError(this.txtChild, "Entered '" + this.txtChild.Text + "' is Invalid.");
                this.txtChild.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtInfant.Text.Trim())))
            {
                errorProvider.SetError(this.txtInfant, "Entered '" + this.txtInfant.Text + "' is Invalid.");
                this.txtInfant.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtAvailableRoomCount.Text) || Convert.ToInt32(this.txtAvailableRoomCount.Text) + this.lstSelectedRoom.Items.Count <= 0)
            {
                errorProvider.SetError(this.txtAvailableRoomCount, "No rooms available for booking.");
                this.txtAvailableRoomCount.Focus();
                return false;
            }
            else if (this.lstSelectedRoom.Items.Count > Convert.ToInt32(this.txtRooms.Text.Trim()))
            {
                errorProvider.SetError(this.lstSelectedRoom, "Selected rooms cannot be greater than the no of rooms.");
                this.lstSelectedRoom.Focus();
                return false;
            }
            else if (Convert.ToInt32(this.txtRooms.Text) > Convert.ToInt32(this.txtAvailableRoomCount.Text) + this.lstSelectedRoom.Items.Count)
            {
                errorProvider.SetError(this.txtRooms, "No of rooms cannot be greater than available rooms.");
                this.lstSelectedRoom.Focus();
                return false;
            }

            return retVal;
        }

        internal void PopulateDataToForm()
        {
            if (this.dto == null) return;
            switch (this.dto.Status)
            {
                case RsvFac.Status.Open:
                case RsvFac.Status.Canceled:
                    this.txtStatus.Text = this.dto.Status.ToString();
                    break;
                case RsvFac.Status.CheckedIn:
                    this.txtStatus.Text = "Checked In";
                    break;
                case RsvFac.Status.CheckOut:
                    this.txtStatus.Text = "Checked Out";
                    break;
                case RsvFac.Status.Invoiced:
                    this.txtStatus.Text = "Invoiced";
                    break;
                case RsvFac.Status.Paid:
                    this.txtStatus.Text = "Paid";
                    break;
            }

            if (this.dto != null && dto.Id > 0)
            {
                if (this.dto.RoomCategory != null && this.dto.RoomCategory.Id > 0 && this.CategoryList != null)
                {
                    this.cboCategory.SelectedItem = this.CategoryList.FindLast((p) => { return p.Id == this.dto.RoomCategory.Id; });
                }
                else
                {
                    this.cboCategory.SelectedIndex = 0;
                }

                if (this.dto.RoomType != null && this.dto.RoomType.Id > 0 & this.TypeList != null)
                {
                    this.cboType.SelectedItem = this.TypeList.FindLast((p) => { return p.Id == this.dto.RoomType.Id; });
                }
                else
                {
                    this.cboType.SelectedIndex = 0;
                }
                this.isLoading = false;//Stop here the loading phase to enable category and type search
                this.cboAC.SelectedIndex = this.dto.ACPreference;

                this.txtMale.Text = this.dto.NoOfMale == 0 ? String.Empty : this.dto.NoOfMale.ToString();
                this.txtFemale.Text = this.dto.NoOfFemale == 0 ? String.Empty : this.dto.NoOfFemale.ToString();
                this.txtChild.Text = this.dto.NoOfChild == 0 ? String.Empty : this.dto.NoOfChild.ToString();
                this.txtInfant.Text = this.dto.NoOfInfant == 0 ? String.Empty : this.dto.NoOfInfant.ToString();
                this.txtRemarks.Text = this.dto.Remark.ToString();
                this.txtReservationNo.Text = this.dto.ReservationNo;

                if (!ValidationRule.IsMinimumDate(this.dto.BookingFrom))
                {
                    this.dtFromTime.Value = this.dto.BookingFrom;
                    this.dtFrom.Value = this.dto.BookingFrom;
                }
                if (this.dto.To != null)
                {
                    DateTime to = (DateTime)this.dto.To;
                    this.txtToDate.Text = to.ToShortDateString();
                    this.txtToTime.Text = to.ToShortTimeString();
                }
                this.txtRooms.Text = this.dto.NoOfRooms == 0 ? String.Empty : this.dto.NoOfRooms.ToString();
                this.txtDays.Text = this.dto.NoOfDays == 0 ? String.Empty : this.dto.NoOfDays.ToString();

                if (this.dto.RoomList != null && this.dto.RoomList.Count > 0)
                {
                    this.lstSelectedRoom.Bind(this.dto.RoomList, "Name");
                    this.PopulateRoomListsAndCounts();
                }
            }
        }

        internal RsvFac.Dto AssignDto(RsvFac.Dto dto)
        {
            dto.Id = dto == null ? 0 : dto.Id;

            dto.BookingFrom = new DateTime(this.dtFrom.Value.Year, this.dtFrom.Value.Month, this.dtFrom.Value.Day,
                this.dtFromTime.Value.Hour, this.dtFromTime.Value.Minute, this.dtFromTime.Value.Second);
            dto.NoOfDays = Convert.ToInt16(this.txtDays.Text);
            dto.NoOfRooms = Convert.ToInt16(this.txtRooms.Text);

            //non-mandatory
            dto.RoomCategory = this.GetSelectedCategory(this.cboCategory.SelectedItem as RoomCatFac.Dto);
            dto.RoomType = this.cboType.SelectedItem as RoomTypeFac.Dto;
            dto.ACPreference = this.cboAC.SelectedIndex;
            dto.NoOfMale = String.IsNullOrEmpty(this.txtMale.Text.Trim()) ? 0 : Convert.ToInt32(this.txtMale.Text);
            dto.NoOfFemale = String.IsNullOrEmpty(this.txtFemale.Text.Trim()) ? 0 : Convert.ToInt32(this.txtFemale.Text);
            dto.NoOfChild = String.IsNullOrEmpty(this.txtChild.Text.Trim()) ? 0 : Convert.ToInt32(this.txtChild.Text);
            dto.NoOfInfant = String.IsNullOrEmpty(this.txtInfant.Text.Trim()) ? 0 : Convert.ToInt32(this.txtInfant.Text);
            dto.Remark = this.txtRemarks.Text.Trim();
            //dto.To = Convert.ToDateTime(this.txtTo.Text);

            dto.Status = RsvFac.Status.Open;
            return dto;
        }

        internal void AssignTo(DateTime? to)
        {
            this.dto.To = to;
        }

        #region Control

        internal void DisableFormControls()
        {
            this.btnAddRoom.Enabled = false;
            this.btnRemoveRoom.Enabled = false;

            this.cboCategory.Enabled = false;
            this.cboType.Enabled = false;

            this.dtFrom.Enabled = false;
            this.dtFromTime.Enabled = false;

            this.txtDays.ReadOnly = true;
            this.txtDays.BackColor = SystemColors.Control;
            this.txtMale.ReadOnly = true;
            this.txtFemale.ReadOnly = true;
            this.txtChild.ReadOnly = true;
            this.txtInfant.ReadOnly = true;
            this.txtRemarks.ReadOnly = true;

            this.txtRooms.ReadOnly = true;
            this.txtRooms.BackColor = SystemColors.Control;

            this.lstRoomList.Enabled = false;
            this.lstSelectedRoom.Enabled = false;
            this.cboAC.Enabled = false;
        }

        internal void DisableRemarks()
        {
            this.txtRemarks.Enabled = false;
        }

        internal void EnableNoOfDays()
        {
            this.txtDays.ReadOnly = false;
        }

        #endregion

        private Table GetSelectedCategory(RoomCatFac.Dto selectedItem)
        {
            return selectedItem == null ? null : new Table
            {
                Id = selectedItem.Id,
                Name = selectedItem.Name,
            };
        }

        private void AddRoom(RoomFac.Dto selectedItem)
        {
            if (selectedItem != null)
            {
                this.filteredRoomList.Remove(selectedItem);
                this.lstRoomList.Items.Remove(selectedItem);

                if (this.dto == null) this.dto = new RsvFac.Dto();
                if (this.dto.RoomList == null)
                {
                    this.dto.RoomList = new List<RoomDtlsFac.Dto>();
                    this.lstSelectedRoom.Bind(this.dto.RoomList, "Name");
                }
                this.dto.RoomList.Add(new RoomDtlsFac.Dto
                {
                    Room = selectedItem,
                });
                this.lstSelectedRoom.Items.Add(new RoomDtlsFac.Dto
                {
                    Room = selectedItem,
                });

                this.PopulateCount();
            }
        }

        private void RemoveRoom(RoomDtlsFac.Dto selectedItem)
        {
            if (selectedItem != null)
            {
                this.dto.RoomList.Remove(selectedItem);
                this.lstSelectedRoom.Items.Remove(selectedItem);

                this.filteredRoomList.Add(selectedItem.Room);
                this.lstRoomList.Items.Add(selectedItem.Room);
                this.PopulateCount();
            }
        }

        private void PopulateRoomListsAndCounts()
        {
            this.lstRoomList.Bind(this.FilterList(this.cboCategory.SelectedItem as RoomCatFac.Dto,
                this.cboType.SelectedItem as RoomTypeFac.Dto,
                this.cboAC.SelectedItem as Table), "Name");
            this.PopulateCount();
        }

        private List<RoomFac.Dto> FilterList(RoomCatFac.Dto category, RoomTypeFac.Dto type, Table accessory)
        {
            Int64 categoryId = category == null ? 0 : category.Id;
            Int64 typeId = type == null ? 0 : type.Id;
            Boolean isAc = this.IsAcc(accessory);
            this.filteredRoomList = this.RoomList.FindAll((p) =>
            {
                return (p.Category.Id == categoryId || category == null || category.Name == "All")
                    && (p.Type.Id == typeId || type == null || type.Name == "All")
                    && (p.IsAirconditioned == isAc || accessory == null || accessory.Name == "All")
                    && (this.dto == null || this.dto.RoomList == null || this.dto.RoomList.FindLast((q) => { return q.Id == p.Id; }) == null);
            });
            if (this.dto != null && this.dto.RoomList != null)
            {
                foreach (RoomDtlsFac.Dto product in this.dto.RoomList)
                {
                    this.filteredRoomList.Remove(this.filteredRoomList.Find((p) => { return p.Id == product.Room.Id; }));
                }
            }

            return this.filteredRoomList;
        }

        private Boolean IsAcc(Table accessory)
        {
            //Need to change the function
            if (this.cboAC.SelectedItem != null)
            {
                return (this.cboAC.SelectedItem as Table).Name == "AC";
            }
            return false;
        }

        private void PopulateCount()
        {
            if ((this.filteredRoomList != null && this.filteredRoomList.Count > 0))
            {
                this.txtFilteredRoomCount.Text = (this.filteredRoomList.Count
                    + (this.dto != null && this.dto.RoomList != null && this.dto.RoomList.Count > 0 ? this.dto.RoomList.Count : 0)).ToString();
                this.txtAvailableRoomCount.Text = this.filteredRoomList.Count.ToString();
            }
            else
            {
                this.txtFilteredRoomCount.Text = "0";
                this.txtAvailableRoomCount.Text = "0";
            }
        }

    }

}