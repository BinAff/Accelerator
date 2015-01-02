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
                dto.Status = BookingStatusId;
                (this.facade as Fac.Server).ChangeReservationStatus();                    
                  
                base.IsModified = true;
                base.RaiseAuditInfoChanged(this.Artifact);
                this.Close();
            }
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
                if (initialDto.Status == Status.CheckedIn || initialDto.Status == Status.CheckOut || initialDto.Status == Status.Canceled)
                {
                    this.DisableFormControls();
                }
            }

            this.ucRoomReservationDataEntry.CategoryList = formDto.CategoryList;
            this.ucRoomReservationDataEntry.TypeList = formDto.TypeList;
            this.ucRoomReservationDataEntry.AccessoryList = new List<Table>
            {
                new Table { Id = 0, Name = "All" },
                new Table { Id = 1, Name = "AC" },
                new Table { Id = 2, Name = "Non AC" }
            };
            this.ucRoomReservationDataEntry.RoomList = formDto.AllRoomList;
            this.ucRoomReservationDataEntry.RoomListChanged += ucRoomReservationDataEntry_RoomListChanged;
            this.ucRoomReservationDataEntry.LoadForm((base.formDto as Fac.FormDto).Dto as Fac.Dto);
        }

        protected override void PopulateDataToForm()
        {
            this.ucRoomReservationDataEntry.PopulateDataToForm();
        }

        protected override void LoadData()
        {
            base.facade.LoadForm();
        }

        protected override Boolean ValidateForm()
        {
            return this.ucRoomReservationDataEntry.ValidateForm(this.errorProvider);
        }

        protected override void RefreshFormBefore()
        {
            errorProvider.Clear();
        }

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

        private void DisableFormControls()
        {
            base.errorProvider.Clear();
            base.DisableRefreshButton();
            base.DisableOkButton();
            base.DisableDeleteButton();
            base.DisablePickAncestorButton();
            base.DisableAddAncestorButton();
            base.DisableAttachButton();
            this.btnCancel.Enabled = false;

            this.ucRoomReservationDataEntry.DisableFormControls();
        }
       
    }

}