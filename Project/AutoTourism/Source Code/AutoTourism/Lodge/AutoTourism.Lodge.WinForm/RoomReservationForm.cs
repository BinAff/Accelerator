using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;
using BinAff.Presentation.Library.Extension;

using AccFac = Vanilla.Guardian.Facade.Account;
using DocFac = Vanilla.Utility.Facade.Document;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using FrmDocFac = Vanilla.Form.Facade.Document;
using InvWin = Vanilla.Invoice.WinForm;
using FormWin = Vanilla.Form.WinForm;

using Fac = AutoTourism.Lodge.Facade.RoomReservation;
using RuleFac = AutoTourism.Configuration.Rule.Facade;
using CustFac = AutoTourism.Customer.Facade;
using RoomFac = AutoTourism.Lodge.Configuration.Facade.Room;
using RoomCatFac = AutoTourism.Lodge.Configuration.Facade.Room.Category;
using RoomTypFac = AutoTourism.Lodge.Configuration.Facade.Room.Type;
using AutoTourism.Lodge.Facade.RoomReservation;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationForm : FormWin.Document
    {

        private RuleFac.ConfigurationRuleDto configRuleDto;
        private ToolStripButton btnCancel;
        
        public RoomReservationForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();

            base.AncestorName = "Customer";
            base.AttachmentName = "Advance Payment";
        }

        protected override void Compose()
        {
            base.formDto = new Fac.FormDto
            {
                //ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new Fac.Dto()
            };

            base.facade = new Fac.Server(this.formDto as Fac.FormDto);
        }
              
        public RoomReservationForm(Fac.Dto dto)
        {
            InitializeComponent();
        }

        #region Events

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            this.AddRoom();
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            this.RemoveRoom();
        }

        private void lstRoomList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.AddRoom();
        }

        private void lstSelectedRoom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.RemoveRoom();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {           
            if (this.formDto != null && this.formDto.Dto != null)
            {
                Fac.Dto dto = this.formDto.Dto as Fac.Dto;
                Status BookingStatusId = (txtStatus.Text == "Cancel") ? Status.Open : Status.Canceled;

                base.formDto.Document.AuditInfo.ModifiedBy = new Table
                {
                    Id = (BinAff.Facade.Cache.Server.Current.Cache["User"] as AccFac.Dto).Id,
                    Name = (BinAff.Facade.Cache.Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
                };
                base.formDto.Document.AuditInfo.ModifiedAt = DateTime.Now;
              
                base.RegisterArtifactObserver();
                dto.BookingStatus = BookingStatusId;
                (this.facade as Fac.Server).ChangeReservationStatus();                    
                  
                base.IsModified = true;
                base.RaiseAuditInfoChanged(this.Artifact);
                this.Close();
               
            }
        }
                      
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterForCategory();
        }
             
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterForType();
        }

        private void cboAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterForAccessory();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            this.PopulateRoomListFromDaysAndDateChanged();           
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            this.PopulateRoomListFromDaysAndDateChanged();           
        }
        
        #endregion
        
        protected override void LoadForm()
        {
            base.AddToolStripSeparator();
            this.btnCancel = base.AddToolStripButton("Í", "Wingdings 2", "Cancel Reservation");
            this.btnCancel.Click += btnCancel_Click;

            this.SetDefault();

            Fac.FormDto formDto = base.formDto as Fac.FormDto;
            Fac.Dto dto = formDto.Dto as Fac.Dto;

            //customer data is getting read at load, so updating the initial dto for customer
            if (dto.Id > 0)
            {
                (this.InitialDto as Fac.Dto).Customer = dto.Customer;
            }

            this.configRuleDto = formDto.ConfigurationRule;
            if (this.configRuleDto.DateFormat != null) this.dtFrom.CustomFormat = this.configRuleDto.DateFormat;

            this.cboCategory.Bind(formDto.CategoryList, "Name");
            this.cboType.Bind(formDto.TypeList, "Name");
            this.cboAC.Bind(new List<Table>
            {
                new Table { Id = 0, Name = "All" },
                new Table { Id = 1, Name = "AC" },
                new Table { Id = 2, Name = "Non AC" }
            }, "Name"); 

            //Hide open cancel button for new reservation
            if (dto.Id == 0) this.btnCancel.Visible = false;

            //disable the controls if the reservation is checked in or the reservation has been cancelled
            if (this.InitialDto != null)
            {
                Fac.Dto initialDto = this.InitialDto as Fac.Dto;
                if ((initialDto.isCheckedIn) || (initialDto.BookingStatus == Status.Canceled))
                {
                    this.DisableFormControls();
                }
            }
        }

        protected override void PopulateDataToForm()
        {
            Fac.Dto dto = base.formDto.Dto as Fac.Dto;

            if (dto.isCheckedIn)
            {
                txtStatus.Text = "Checked In";
            }
            else if (dto.BookingStatus == Status.Open)
            {
                txtStatus.Text = "Open";
            }
            else if (dto.BookingStatus == Status.Canceled)
            {
                txtStatus.Text = "Cancel";
            }

            if (dto != null && dto.Id > 0)
            {
                this.PopulateAnsestorData(dto.Customer as CustFac.Dto);

                Fac.FormDto formDto = this.formDto as Fac.FormDto;
                if (dto.RoomCategory != null && dto.RoomCategory.Id > 0)
                {
                    this.cboCategory.SelectedItem = formDto.CategoryList.FindLast((p) => { return p.Id == dto.RoomCategory.Id; });
                }
                else
                {
                    this.cboCategory.SelectedIndex = 0;
                }

                if (dto.RoomType != null && dto.RoomType.Id > 0)
                {
                    this.cboType.SelectedItem = formDto.TypeList.FindLast((p) => { return p.Id == dto.RoomType.Id; });
                }
                else
                {
                    this.cboType.SelectedIndex = 0;
                }

                cboAC.SelectedIndex = dto.ACPreference;

                this.txtMale.Text = dto.NoOfMale == 0 ? String.Empty : dto.NoOfMale.ToString();
                this.txtFemale.Text = dto.NoOfFemale == 0 ? String.Empty : dto.NoOfFemale.ToString();
                this.txtChild.Text = dto.NoOfChild == 0 ? String.Empty : dto.NoOfChild.ToString();
                this.txtInfant.Text = dto.NoOfInfant == 0 ? String.Empty : dto.NoOfInfant.ToString();
                this.txtRemarks.Text = dto.Remark.ToString();
                this.txtReservationNo.Text = dto.ReservationNo;

                if (dto.RoomList != null && dto.RoomList.Count > 0) formDto.SelectedRoomList = dto.RoomList;

                //populate booking data
                if (!ValidationRule.IsMinimumDate(dto.BookingFrom))
                {
                    dtFrom.Value = dto.BookingFrom;
                    dtFromTime.Value = dto.BookingFrom;
                }
                this.txtRooms.Text = dto.NoOfRooms == 0 ? String.Empty : dto.NoOfRooms.ToString();
                this.txtDays.Text = dto.NoOfDays == 0 ? String.Empty : dto.NoOfDays.ToString();

                //this.PopulateRoomListFromDaysAndDateChanged();
            }
        }

        protected override void LoadData()
        {
            base.facade.LoadForm();
        }

        protected override void RefreshFormBefore()
        {
            errorProvider.Clear();
        }

        protected override void RevertForm()
        {
            return;
            //(base.formDto as Fac.FormDto).Dto = this.CloneDto(this.InitialDto) as Fac.Dto;
        }

        protected override void RefreshFormAfter()
        {           
            txtDays.Focus();
        }

        protected override FormWin.Document GetAnsestorForm()
        {
            return new AutoTourism.Customer.WinForm.CustomerForm(new ArtfFac.Dto());
        }

        protected override void PopulateAnsestorData(FrmDocFac.Dto dto)
        {
            CustFac.Dto customerData = dto as CustFac.Dto;
            if (customerData != null)
            {
                (formDto.Dto as Fac.Dto).Customer = customerData;
                this.ucCustomerSummary.LoadForm(customerData);
            }
        }

        protected override FormWin.Document GetAttachment()
        {
            return new InvWin.PaymentForm(new ArtfFac.Dto());
        }

        protected override void ClearForm()
        {
            this.dtFrom.Value = DateTime.Now;
            this.dtFromTime.Value = DateTime.Now;
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

        protected override void AssignDto()
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;

            dto.BookingFrom = new DateTime(this.dtFrom.Value.Year, this.dtFrom.Value.Month, this.dtFrom.Value.Day,
                this.dtFromTime.Value.Hour, 0, 0);
            dto.NoOfDays = Convert.ToInt16(this.txtDays.Text);          
            dto.NoOfRooms = Convert.ToInt16(this.txtRooms.Text);

            //non-mandatory drop down
            dto.RoomCategory = this.GetSelectedCategory(this.cboCategory.SelectedItem as RoomCatFac.Dto);
            dto.RoomType = this.GetSelectedType(this.cboType.SelectedItem as RoomTypFac.Dto);
            dto.ACPreference = this.cboAC.SelectedIndex;

            //non-mandatory textBox
            dto.NoOfMale = String.IsNullOrEmpty(this.txtMale.Text.Trim()) ? 0 : Convert.ToInt32(this.txtMale.Text);
            dto.NoOfFemale = String.IsNullOrEmpty(this.txtFemale.Text.Trim()) ? 0 : Convert.ToInt32(this.txtFemale.Text);
            dto.NoOfChild = String.IsNullOrEmpty(this.txtChild.Text.Trim()) ? 0 : Convert.ToInt32(this.txtChild.Text);
            dto.NoOfInfant = String.IsNullOrEmpty(this.txtInfant.Text.Trim()) ? 0 : Convert.ToInt32(this.txtInfant.Text);
            dto.Remark = this.txtRemarks.Text.Trim();
            
            dto.BookingStatus = Status.Open;
            dto.RoomList = ((base.formDto as Fac.FormDto) as Fac.FormDto).SelectedRoomList;
        }

        protected override Boolean ValidateForm()
        {
            Boolean retVal = true;
            this.errorProvider.Clear();

            if (this.ucCustomerSummary.IsEmpty())
            {
                this.errorProvider.SetError(this.ucCustomerSummary, "Select a customer for reservation.");
                base.FocusPickAncestor();
                return false;
            }             
            else if (ValidationRule.IsDateLessThanToday(this.dtFrom.Value))
            {
                this.errorProvider.SetError(this.dtFrom, "Booking date cannot be less than today.");
                this.dtFrom.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtDays.Text.Trim()))
            {
                this.errorProvider.SetError(this.txtDays, "Please enter days.");
                this.txtDays.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtDays.Text.Trim())))
            {
                this.errorProvider.SetError(txtDays, "Entered '" + this.txtDays.Text + "' is Invalid.");
                this.txtDays.Focus();
                return false;
            }  
            else if (String.IsNullOrEmpty(this.txtRooms.Text))
            {
                this.errorProvider.SetError(this.txtRooms, "Please enter rooms.");
                this.txtRooms.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtRooms.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtRooms, "Entered '" + this.txtRooms.Text + "' is Invalid.");
                this.txtRooms.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtMale.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtMale, "Entered '" + this.txtMale.Text + "' is Invalid.");
                this.txtMale.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtFemale.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtFemale, "Entered '" + this.txtFemale.Text + "' is Invalid.");
                this.txtFemale.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtChild.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtChild, "Entered '" + this.txtChild.Text + "' is Invalid.");
                this.txtChild.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtInfant.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtInfant, "Entered '" + this.txtInfant.Text + "' is Invalid.");
                this.txtInfant.Focus();
                return false;
            }          
            else if (this.lstSelectedRoom.Items.Count > Convert.ToInt32(this.txtRooms.Text.Trim()))
            {
                this.errorProvider.SetError(this.lstSelectedRoom, "Selected rooms cannot be greater than the no of rooms.");
                this.lstSelectedRoom.Focus();
                return false;
            }
            else if (Convert.ToInt32(this.txtRooms.Text.Trim()) > Convert.ToInt32(this.txtAvailableRoomCount.Text))
            {
                this.errorProvider.SetError(this.txtRooms, "No of rooms cannot be greater than available rooms.");
                this.lstSelectedRoom.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtAvailableRoomCount.Text) || Convert.ToInt32(this.txtAvailableRoomCount.Text) <= 0)
            {
                this.errorProvider.SetError(this.txtAvailableRoomCount, "No rooms available for booking.");
                this.txtAvailableRoomCount.Focus();
                return false;
            } 

            return retVal;
        }
        
        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
            return (this.facade as Fac.Server).CloneReservaion(source as Fac.Dto);              
        }

        private void SetDefault()
        {
            this.dtFrom.Format = DateTimePickerFormat.Custom;
            this.dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
        }

        private void DisableFormControls()
        {
            errorProvider.Clear();

            base.DisablePickAncestorButton();
            base.DisableAddAncestorButton();
            base.DisableRefreshButton();
            base.DisableOkButton();
            base.DisableAttachButton();
            this.btnCancel.Enabled = false;
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

        private void PopulateRoomListFromDaysAndDateChanged()
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;
            dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);

            if (!String.IsNullOrEmpty(txtDays.Text.Trim()) && ValidationRule.IsInteger(txtDays.Text))
            {
                dto.NoOfDays = Convert.ToInt16(txtDays.Text);

                (this.facade as Fac.Server).RemoveAllBookedRoom();
                this.FilterAndPopulateRoomList();
            }
        }

        private void AddRoom()
        {
            if (lstRoomList.SelectedIndex != -1)
            {
                (this.facade as Fac.Server).RemoveRoomFromAllRoomList((RoomFac.Dto)lstRoomList.SelectedItem);
                this.PopulateRoomList();
            }
        }

        private void RemoveRoom()
        {
            if (lstSelectedRoom.SelectedIndex != -1)
            {
                (this.facade as Fac.Server).AddRoomToAllRoomList((RoomFac.Dto)lstSelectedRoom.SelectedItem);
                this.PopulateRoomList();
            }
        }

        private Table GetSelectedCategory(RoomCatFac.Dto selectedItem)
        {
            return selectedItem == null ? null : new Table
            {
                Id = selectedItem.Id,
                Name = selectedItem.Name,
            };
        }

        private Table GetSelectedType(RoomTypFac.Dto selectedItem)
        {
            return selectedItem == null ? null : new Table
            {
                Id = selectedItem.Id,
                Name = selectedItem.Name,
            };
        }

        private void FilterForCategory()
        {
            ((base.formDto as Fac.FormDto).Dto as Fac.Dto).RoomCategory = this.GetSelectedCategory(this.cboCategory.SelectedItem as RoomCatFac.Dto);
            this.FilterAndPopulateRoomList();
        }

        private void FilterForType()
        {
            ((base.formDto as Fac.FormDto).Dto as Fac.Dto).RoomType = this.GetSelectedType(this.cboType.SelectedItem as RoomTypFac.Dto);
            this.FilterAndPopulateRoomList();
        }

        private void FilterForAccessory()
        {
            ((base.formDto as Fac.FormDto).Dto as Fac.Dto).ACPreference = (Int32)(this.cboAC.SelectedItem == null ? null : new Table { Id = (this.cboAC.SelectedItem as Table).Id }).Id;
            this.FilterAndPopulateRoomList();
        }

        private void FilterAndPopulateRoomList()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;

            (this.facade as Fac.Server).PopulateRoomWithCriteria();
            this.PopulateRoomList();

            if ((formDto.RoomList != null && formDto.RoomList.Count > 0) || (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 0))
            {
                this.txtFilteredRoomCount.Text = (this.facade as Fac.Server).GetTotalNoRooms().ToString();

                int filteredRoomCount = 0;
                if (!String.IsNullOrEmpty(this.txtFilteredRoomCount.Text))
                {
                    filteredRoomCount = Convert.ToInt32(this.txtFilteredRoomCount.Text);
                }

                int AvailableRoomCount = filteredRoomCount < formDto.AvailableRoomCount ? filteredRoomCount : formDto.AvailableRoomCount;
                this.txtAvailableRoomCount.Text = AvailableRoomCount.ToString();
            }
            else
            {
                this.txtFilteredRoomCount.Text = String.Empty;
                this.txtAvailableRoomCount.Text = String.Empty;
            }
        }

        private void PopulateRoomList()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            this.lstRoomList.Bind(formDto.RoomList, "Number");
            this.lstSelectedRoom.Bind(formDto.SelectedRoomList, "Number");
        }
       
    }

}