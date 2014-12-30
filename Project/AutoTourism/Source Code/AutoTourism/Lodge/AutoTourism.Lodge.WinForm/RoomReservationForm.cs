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
                Status BookingStatusId = this.ucRoomReservationDataEntry.ReservationStatus;

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

            Fac.FormDto formDto = base.formDto as Fac.FormDto;
            Fac.Dto dto = formDto.Dto as Fac.Dto;
            //customer data is getting read at load, so updating the initial dto for customer
            if (dto.Id > 0)
            {
                (this.InitialDto as Fac.Dto).Customer = dto.Customer;
            }
            ////////////////////////Need to check//////////////////////////////
            //this.configRuleDto = formDto.ConfigurationRule;
            //if (this.configRuleDto.DateFormat != null) this.dtFrom.CustomFormat = this.configRuleDto.DateFormat;
            /////////////////////////////////////////////////////////////////////

            if (dto.Id == 0) this.btnCancel.Visible = false; //Hide open cancel button for new reservation

            //disable the controls if the reservation is checked in or the reservation has been cancelled
            if (this.InitialDto != null)
            {
                Fac.Dto initialDto = this.InitialDto as Fac.Dto;
                if ((initialDto.isCheckedIn) || (initialDto.BookingStatus == Status.Canceled))
                {
                    this.DisableFormControls();
                }
            }

            this.ucRoomReservationDataEntry.CategoryList = formDto.CategoryList;
            this.ucRoomReservationDataEntry.TypeList = formDto.TypeList;
            this.ucRoomReservationDataEntry.RoomList = formDto.AllRoomList;
            this.ucRoomReservationDataEntry.RoomListChanged += ucRoomReservationDataEntry_RoomListChanged;
            this.ucRoomReservationDataEntry.LoadForm((base.formDto as Fac.FormDto).Dto as Fac.Dto);
        }

        private void ucRoomReservationDataEntry_RoomListChanged(Int16 days, DateTime from)
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;
            dto.BookingFrom = new DateTime(from.Year, from.Month, from.Day, from.Hour, from.Minute, from.Second);
            if (days > 0)
            {
                dto.NoOfDays = days;
                (this.facade as Fac.Server).RemoveAllBookedRoom();
            }
            this.ucRoomReservationDataEntry.RoomList = (formDto as FormDto).AllRoomList;
        }

        protected override void PopulateDataToForm()
        {
            this.ucRoomReservationDataEntry.PopulateDataToForm();
        }

        protected override void LoadData()
        {
            base.facade.LoadForm();
        }

        protected override void RefreshFormBefore()
        {
            errorProvider.Clear();
        }

        //protected override void RevertForm()
        //{
        //    return;
        //    //(base.formDto as Fac.FormDto).Dto = this.CloneDto(this.InitialDto) as Fac.Dto;
        //}

        //protected override void RefreshFormAfter()
        //{           
        //    txtDays.Focus();
        //}

        protected override FormWin.Document GetAnsestorForm()
        {
            return new AutoTourism.Customer.WinForm.CustomerForm(new ArtfFac.Dto());
        }

        protected override void PopulateAnsestorData(FrmDocFac.Dto dto)
        {
            this.ucRoomReservationDataEntry.PopulateCustomerSummary(dto as CustFac.Dto);
            //CustFac.Dto customerData = dto as CustFac.Dto;
            //if (customerData != null)
            //{
            //    (formDto.Dto as Fac.Dto).Customer = customerData;
            //    this.ucCustomerSummary.LoadForm(customerData);
            //}
        }

        protected override FormWin.Document GetAttachment()
        {
            return new InvWin.PaymentForm(new ArtfFac.Dto());
        }

        protected override void ClearForm()
        {
            this.ucRoomReservationDataEntry.ClearForm();
        }               

        protected override void AssignDto()
        {
            this.ucRoomReservationDataEntry.AssignDto((base.formDto as Fac.FormDto).Dto as Fac.Dto);
        }

        protected override Boolean ValidateForm()
        {
            return this.ucRoomReservationDataEntry.ValidateForm(this.errorProvider);
        }
        
        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
            return (this.facade as Fac.Server).CloneReservaion(source as Fac.Dto);              
        }

        //private void SetDefault()
        //{
        //    this.dtFrom.Format = DateTimePickerFormat.Custom;
        //    this.dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
        //}

        private void DisableFormControls()
        {
            errorProvider.Clear();

            base.DisablePickAncestorButton();
            base.DisableAddAncestorButton();
            base.DisableRefreshButton();
            base.DisableOkButton();
            base.DisableAttachButton();
            this.btnCancel.Enabled = false;

            this.ucRoomReservationDataEntry.DisableFormControls();
        }

        private void PopulateRoomListFromDaysAndDateChanged()
        {
            //Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            //dto.Id = dto == null ? 0 : dto.Id;
            //dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);

            //if (!String.IsNullOrEmpty(txtDays.Text.Trim()) && ValidationRule.IsInteger(txtDays.Text))
            //{
            //    dto.NoOfDays = Convert.ToInt16(txtDays.Text);

            //    (this.facade as Fac.Server).RemoveAllBookedRoom();
            //    this.FilterAndPopulateRoomList();
            //}
        }

        private void AddRoom()
        {
            //if (lstRoomList.SelectedIndex != -1)
            //{
            //    (this.facade as Fac.Server).RemoveRoomFromAllRoomList((RoomFac.Dto)lstRoomList.SelectedItem);
            //    this.PopulateRoomList();
            //}
        }

        private void RemoveRoom()
        {
            //if (lstSelectedRoom.SelectedIndex != -1)
            //{
            //    (this.facade as Fac.Server).AddRoomToAllRoomList((RoomFac.Dto)lstSelectedRoom.SelectedItem);
            //    this.PopulateRoomList();
            //}
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
            //((base.formDto as Fac.FormDto).Dto as Fac.Dto).RoomCategory = this.GetSelectedCategory(this.cboCategory.SelectedItem as RoomCatFac.Dto);
            this.FilterAndPopulateRoomList();
        }

        private void FilterForType()
        {
            //((base.formDto as Fac.FormDto).Dto as Fac.Dto).RoomType = this.GetSelectedType(this.cboType.SelectedItem as RoomTypFac.Dto);
            this.FilterAndPopulateRoomList();
        }

        private void FilterForAccessory()
        {
            //((base.formDto as Fac.FormDto).Dto as Fac.Dto).ACPreference = (Int32)(this.cboAC.SelectedItem == null ? null : new Table { Id = (this.cboAC.SelectedItem as Table).Id }).Id;
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
                //this.txtFilteredRoomCount.Text = (this.facade as Fac.Server).GetTotalNoRooms().ToString();

                //int filteredRoomCount = 0;
                //if (!String.IsNullOrEmpty(this.txtFilteredRoomCount.Text))
                //{
                //    filteredRoomCount = Convert.ToInt32(this.txtFilteredRoomCount.Text);
                //}

                //int AvailableRoomCount = filteredRoomCount < formDto.AvailableRoomCount ? filteredRoomCount : formDto.AvailableRoomCount;
                //this.txtAvailableRoomCount.Text = AvailableRoomCount.ToString();
            }
            else
            {
                //this.txtFilteredRoomCount.Text = String.Empty;
                //this.txtAvailableRoomCount.Text = String.Empty;
            }
        }

        private void PopulateRoomList()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            //this.lstRoomList.Bind(formDto.RoomList, "Number");
            //this.lstSelectedRoom.Bind(formDto.SelectedRoomList, "Number");
        }
       
    }

}