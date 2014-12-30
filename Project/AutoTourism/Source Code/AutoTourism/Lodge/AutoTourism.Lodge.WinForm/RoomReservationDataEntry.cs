using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using BinAff.Core;
using BinAff.Utility;
using BinAff.Presentation.Library.Extension;

using CustFac = AutoTourism.Customer.Facade;
using RoomRsvFac = AutoTourism.Lodge.Facade.RoomReservation;
using RoomFac = AutoTourism.Lodge.Configuration.Facade.Room;
using RoomCatFac = AutoTourism.Lodge.Configuration.Facade.Room.Category;
using RoomTypeFac = AutoTourism.Lodge.Configuration.Facade.Room.Type;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationDataEntry : UserControl
    {

        public List<RoomCatFac.Dto> CategoryList { get; set; }
        public List<RoomTypeFac.Dto> TypeList { get; set; }
        public List<RoomFac.Dto> RoomList { get; set; }
        public RoomRsvFac.Status ReservationStatus
        {
            get
            {
                return (txtStatus.Text == "Cancel") ? RoomRsvFac.Status.Open : RoomRsvFac.Status.Canceled;
            }
        }

        private List<RoomFac.Dto> filteredRoomList;
        private Boolean isLoading = false;

        RoomRsvFac.Dto dto;

        public delegate void OnRoomListChange(Int16 days, DateTime from);
        public event OnRoomListChange RoomListChanged;

        public RoomReservationDataEntry()
        {
            InitializeComponent();
            this.isLoading = true;
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
            this.RemoveRoom(this.lstSelectedRoom.SelectedItem as RoomFac.Dto);
        }

        private void lstSelectedRoom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.RemoveRoom(this.lstSelectedRoom.SelectedItem as RoomFac.Dto);
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!this.isLoading) this.PopulateRoomListsAndCounts();
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

        public void DisableFormControls()
        {
            this.btnAddRoom.Enabled = false;
            this.btnRemoveRoom.Enabled = false;

            this.cboCategory.Enabled = false;
            this.cboType.Enabled = false;

            this.dtFrom.Enabled = false;
            this.dtFromTime.Enabled = false;
            this.txtDays.ReadOnly = true;
            this.txtMale.ReadOnly = true;
            this.txtFemale.ReadOnly = true;
            this.txtChild.ReadOnly = true;
            this.txtInfant.ReadOnly = true;
            this.txtRemarks.ReadOnly = true;

            this.txtRooms.ReadOnly = true;

            this.lstRoomList.Enabled = false;
            this.lstSelectedRoom.Enabled = false;
            this.cboAC.Enabled = false;
        }

        private void SetDefault()
        {
            this.dtFrom.Format = DateTimePickerFormat.Custom;
            this.dtFrom.CustomFormat = "dd/MM/yyyy"; //--MM should be in upper case
            if (this.dto == null || this.dto.Id == 0)
            {
                this.dtFrom.Value = DateTime.Now;
                this.dtFromTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
            }
        }

        private void ResetRoomList()
        {
            Int16 days = Convert.ToInt16(String.IsNullOrEmpty(this.txtDays.Text) ? 0 : Convert.ToInt16(this.txtDays.Text.Trim()));
            DateTime from = new DateTime(this.dtFrom.Value.Year, this.dtFrom.Value.Month, this.dtFrom.Value.Day,
                this.dtFromTime.Value.Hour, this.dtFromTime.Value.Minute, 0);
            this.RoomListChanged(days, from);
            this.PopulateRoomListsAndCounts();
        }

        public void PopulateCustomerSummary(CustFac.Dto customer)
        {
            this.dto.Customer = customer;
            this.ucCustomerSummary.LoadForm(this.dto.Customer);
        }

        public void LoadForm(RoomRsvFac.Dto dto)
        {
            this.dto = dto;
            this.SetDefault();
            this.cboCategory.Bind(this.CategoryList, "Name");
            this.cboType.Bind(this.TypeList, "Name");
            this.cboAC.Bind(new List<Table>
            {
                new Table { Id = 0, Name = "All" },
                new Table { Id = 1, Name = "AC" },
                new Table { Id = 2, Name = "Non AC" }
            }, "Name");
        }

        public void ClearForm()
        {
            this.dtFrom.Value = DateTime.Now;
            this.dtFromTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, 0, 0);
            this.txtDays.Text = String.Empty;
            this.txtRooms.Text = String.Empty;
            this.cboCategory.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
            this.cboAC.SelectedIndex = 0;
            this.lstRoomList.Items.Clear();
            this.lstSelectedRoom.Items.Clear();
            this.txtMale.Text = String.Empty;
            this.txtFemale.Text = String.Empty;
            this.txtChild.Text = String.Empty;
            this.txtInfant.Text = String.Empty;
            this.txtRemarks.Text = String.Empty;
            this.txtStatus.Text = String.Empty;

            this.ucCustomerSummary.ClearForm();

            this.txtFilteredRoomCount.Text = String.Empty;
            this.txtAvailableRoomCount.Text = String.Empty;
        }

        public Boolean IsEmpty()
        {
            //if (String.IsNullOrEmpty(this.txtName.Text))
            //{
            //    return false;
            //}
            return true;
        }

        public Boolean ValidateForm(ErrorProvider errorProvider)
        {
            Boolean retVal = true;
            errorProvider.Clear();

            if (this.ucCustomerSummary.IsEmpty())
            {
                errorProvider.SetError(this.ucCustomerSummary, "Select a customer for reservation.");
                //base.FocusPickAncestor();
                return false;
            }
            else if (ValidationRule.IsDateLessThanToday(this.dtFrom.Value))
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
            else if (this.lstSelectedRoom.Items.Count > Convert.ToInt32(this.txtRooms.Text.Trim()))
            {
                errorProvider.SetError(this.lstSelectedRoom, "Selected rooms cannot be greater than the no of rooms.");
                this.lstSelectedRoom.Focus();
                return false;
            }
            else if (Convert.ToInt32(this.txtRooms.Text.Trim()) > Convert.ToInt32(this.txtAvailableRoomCount.Text))
            {
                errorProvider.SetError(this.txtRooms, "No of rooms cannot be greater than available rooms.");
                this.lstSelectedRoom.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtAvailableRoomCount.Text) || Convert.ToInt32(this.txtAvailableRoomCount.Text) <= 0)
            {
                errorProvider.SetError(this.txtAvailableRoomCount, "No rooms available for booking.");
                this.txtAvailableRoomCount.Focus();
                return false;
            }

            return retVal;
        }

        public void PopulateDataToForm()
        {
            if (this.dto == null) return;
            if (this.dto.isCheckedIn)
            {
                this.txtStatus.Text = "Checked In";
            }
            else if (this.dto.BookingStatus == RoomRsvFac.Status.Open)
            {
                this.txtStatus.Text = "Open";
            }
            else if (this.dto.BookingStatus == RoomRsvFac.Status.Canceled)
            {
                this.txtStatus.Text = "Cancel";
            }

            if (this.dto != null && dto.Id > 0)
            {
                if (this.dto.Customer != null)
                {
                    this.ucCustomerSummary.LoadForm(this.dto.Customer);
                }

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
                this.txtRooms.Text = this.dto.NoOfRooms == 0 ? String.Empty : this.dto.NoOfRooms.ToString();
                this.txtDays.Text = this.dto.NoOfDays == 0 ? String.Empty : this.dto.NoOfDays.ToString();

                if (this.dto.RoomList != null && this.dto.RoomList.Count > 0)
                {
                    this.lstSelectedRoom.Bind(this.dto.RoomList, "Name");
                    this.PopulateRoomListsAndCounts();
                }
            }
            this.isLoading = false;
        }

        public RoomRsvFac.Dto AssignDto(RoomRsvFac.Dto dto)
        {
            dto.Id = dto == null ? 0 : dto.Id;

            dto.BookingFrom = new DateTime(this.dtFrom.Value.Year, this.dtFrom.Value.Month, this.dtFrom.Value.Day,
                this.dtFromTime.Value.Hour, this.dtFromTime.Value.Minute, this.dtFromTime.Value.Second);
            dto.NoOfDays = Convert.ToInt16(this.txtDays.Text);
            dto.NoOfRooms = Convert.ToInt16(this.txtRooms.Text);

            //non-mandatory
            dto.RoomCategory = this.GetSelectedCategory(this.cboCategory.SelectedItem as RoomCatFac.Dto);
            dto.RoomType = this.GetSelectedType(this.cboType.SelectedItem as RoomTypeFac.Dto);
            dto.ACPreference = this.cboAC.SelectedIndex;
            dto.NoOfMale = String.IsNullOrEmpty(this.txtMale.Text.Trim()) ? 0 : Convert.ToInt32(this.txtMale.Text);
            dto.NoOfFemale = String.IsNullOrEmpty(this.txtFemale.Text.Trim()) ? 0 : Convert.ToInt32(this.txtFemale.Text);
            dto.NoOfChild = String.IsNullOrEmpty(this.txtChild.Text.Trim()) ? 0 : Convert.ToInt32(this.txtChild.Text);
            dto.NoOfInfant = String.IsNullOrEmpty(this.txtInfant.Text.Trim()) ? 0 : Convert.ToInt32(this.txtInfant.Text);
            dto.Remark = this.txtRemarks.Text.Trim();

            dto.BookingStatus = RoomRsvFac.Status.Open;
            return dto;
        }

        private Table GetSelectedCategory(RoomCatFac.Dto selectedItem)
        {
            return selectedItem == null ? null : new Table
            {
                Id = selectedItem.Id,
                Name = selectedItem.Name,
            };
        }

        private Table GetSelectedType(RoomTypeFac.Dto selectedItem)
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
                this.dto.RoomList.Add(selectedItem);
                this.lstSelectedRoom.Items.Add(selectedItem);
                this.PopulateCount();
            }
        }

        private void RemoveRoom(RoomFac.Dto selectedItem)
        {
            if (selectedItem != null)
            {
                this.dto.RoomList.Remove(selectedItem);
                this.lstSelectedRoom.Items.Remove(selectedItem);
                this.filteredRoomList.Add(selectedItem);
                this.lstRoomList.Items.Add(selectedItem);
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
                    && this.dto.RoomList.FindLast((q) => { return q.Id == p.Id; }) == null;
            });
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
                    + (this.dto.RoomList != null && this.dto.RoomList.Count > 0 ? this.dto.RoomList.Count : 0)).ToString();
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