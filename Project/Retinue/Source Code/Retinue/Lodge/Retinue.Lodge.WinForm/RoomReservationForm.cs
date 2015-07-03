using System;
using System.Collections.Generic;
using System.Windows.Forms;

using BinAff.Core;
using PresLib = BinAff.Presentation.Library;

using AccFac = Vanilla.Guardian.Facade.Account;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using FrmDocFac = Vanilla.Form.Facade.Document;

using InvWin = Vanilla.Accountant.WinForm;
using FormWin = Vanilla.Form.WinForm;
using UtilWin = Vanilla.Utility.WinForm;

using Fac = Retinue.Lodge.Facade.RoomReservation;
using RuleFac = Retinue.Configuration.Rule.Facade;
using CustFac = Retinue.Customer.Facade;
using Retinue.Lodge.Facade.RoomReservation;

namespace Retinue.Lodge.WinForm
{

    public partial class RoomReservationForm : FormWin.Document
    {

        private RuleFac.ConfigurationRuleDto configRuleDto;
        private ToolStripButton btnCancel;
        
        public RoomReservationForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
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

        #region Override from framework

        protected override void Compose()
        {
            base.AttachmentName = "Advance Payment";
            base.SummaryList = new List<UtilWin.SidePanel.Option>
            {
                new UtilWin.SidePanel.Option
                {
                    Name = "Customer",
                    Content = new Customer.WinForm.CustomerSummary(),
                },
                //new UtilWin.SidePanel.Option
                //{
                //    Name = "Check in",
                //    //Content = new InvoiceSummary(),
                //},
            };

            base.formDto = new Fac.FormDto
            {
                Dto = new Fac.Dto()
            };
            base.facade = new Fac.Server(this.formDto as Fac.FormDto);
        }
        
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

            (this.SummaryList[0].Content as Customer.WinForm.CustomerSummary).LoadForm(((base.formDto as Fac.FormDto).Dto as Fac.Dto).Customer);
        }

        protected override void PopulateDataToForm()
        {
            this.ucRoomReservationDataEntry.PopulateDataToForm();
        }

        protected override void SetDefault()
        {
            this.ucRoomReservationDataEntry.SetDefault();
        }

        protected override void LoadData()
        {
            base.facade.LoadForm();
        }

        protected override Boolean ValidateForm()
        {
            Customer.WinForm.CustomerSummary customerSummery = base.SummaryList[0].Content as Customer.WinForm.CustomerSummary;
            if (customerSummery.IsEmpty())
            {
                errorProvider.SetError(customerSummery, "Select a customer for reservation.");
                return false;
            }
            else
            {
                return this.ucRoomReservationDataEntry.ValidateForm(this.errorProvider);
            }
        }

        protected override Boolean SaveBefore()
        {
            BinAff.Core.Message message = this.ucRoomReservationDataEntry.ManageExtraBed();
            if (String.IsNullOrEmpty(message.Description))
            {
                return true;
            }
            else
            {
                switch (message.Category)
                {
                    case BinAff.Core.Message.Type.Question:
                        DialogResult ans = new PresLib.MessageBox(this).Confirm(message);
                        if (ans == System.Windows.Forms.DialogResult.OK) return true;
                        return false;
                    case BinAff.Core.Message.Type.Information:
                        new PresLib.MessageBox(this).Show(message);
                        return true;
                    case BinAff.Core.Message.Type.Error:
                        new PresLib.MessageBox(this).Show(message);
                        return false;
                    default:
                        new PresLib.MessageBox(this).Show(message);
                        return false;
                }
            }
        }

        protected override void RefreshFormBefore()
        {
            errorProvider.Clear();
        }

        protected override FormWin.Document GetAnsestorForm()
        {
            return new Retinue.Customer.WinForm.CustomerForm(new ArtfFac.Dto());
        }

        protected override void PopulateAnsestorData(FrmDocFac.Dto dto)
        {
            ((base.formDto as FormDto).Dto as Dto).Customer = dto as CustFac.Dto;
            (this.SummaryList[0].Content as Customer.WinForm.CustomerSummary).LoadForm(dto as CustFac.Dto);
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

        protected override void DisableFormControls()
        {
            if (this.InitialDto != null)
            {
                Fac.Dto initialDto = this.InitialDto as Fac.Dto;
                if (initialDto.Status == Status.CheckedIn || initialDto.Status == Status.CheckOut || initialDto.Status == Status.Canceled)
                {
                    base.errorProvider.Clear();

                    base.IsEnabledRefreshButton = false;
                    base.IsEnabledSaveButton = false;
                    base.IsEnabledDeleteButton = false;

                    base.IsEnabledOpenLinkButton = false;
                    base.IsEnabledAddLinkButton = false;
                    base.IsEnabledAttchment = false;

                    this.btnCancel.Enabled = false;

                    this.ucRoomReservationDataEntry.DisableFormControls();
                }
                else
                {
                    base.IsEnabledRefreshButton = true;
                    base.IsEnabledSaveButton = true;
                    base.IsEnabledDeleteButton = true;

                    base.IsEnabledOpenLinkButton = true;
                    base.IsEnabledAddLinkButton = true;
                    base.IsEnabledAttchment = true;

                    this.btnCancel.Enabled = true;
                }
            }
        }

        #endregion

    }

}