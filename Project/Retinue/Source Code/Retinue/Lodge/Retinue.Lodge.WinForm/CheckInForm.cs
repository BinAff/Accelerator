using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;
using PresLib = BinAff.Presentation.Library;

using ArtfFac = Vanilla.Utility.Facade.Artifact;
using UtilFac = Vanilla.Utility.Facade;
using InvFac = Vanilla.Accountant.Facade.Invoice;
using FormDocFac = Vanilla.Form.Facade.Document;

using FrmWin = Vanilla.Form.WinForm;
using InvWin = Vanilla.Accountant.WinForm;

using RoomRsvFac = Retinue.Lodge.Facade.RoomReservation;
using Fac = Retinue.Lodge.Facade.CheckIn;
using RuleFac = Retinue.Configuration.Rule.Facade;
using LodgeFac = Retinue.Lodge.Facade;
using RoomFac = Retinue.Lodge.Configuration.Facade.Room;

namespace Retinue.Lodge.WinForm
{

    public partial class CheckInForm : FrmWin.Document
    {

        private RuleFac.ConfigurationRuleDto configRuleDto;
        ToolStripButton btnCheckOut, btnGenerateInvoice, btnPay;

        public CheckInForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
            base.AncestorName = "Room Reservation";
            base.NextName = "Invoice";
            base.AttachmentName = "Advance Payment";
        }
             
        #region Events

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            (this.facade as LodgeFac.CheckIn.Server).CheckOut();
            new PresLib.MessageBox(this)
            {
                DialogueType = PresLib.MessageBox.Type.Alert,
                Heading = "Splash"
            }.Show(this.facade.DisplayMessageList);
            this.ucRoomReservation.AssignTo((this.formDto.Dto as Fac.Dto).CheckOutTime);
            this.ucRoomReservation.PopulateDataToForm();
            this.DisableFormControls();
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            UtilFac.Artifact.Dto inv;
            if ((base.formDto.Dto as Facade.CheckIn.Dto).Invoice == null)
            {
                inv = new UtilFac.Artifact.Dto
                {
                    Module = new InvFac.Dto(),
                };
                (base.facade as Facade.CheckIn.Server).PopulateInvoiceDto(inv.Module as InvFac.Dto);                
            }
            else
            {
                inv = this.GetInvoiceArtifact();
            }

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                FrmWin.Document form = new InvWin.InvoiceForm(inv)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                };
                if (inv.Id == 0)
                {
                    form.ArtifactSaved += delegate(ArtfFac.Dto document)
                    {
                        base.RaiseChildArtifactSaved(document);
                    };
                }
                form.ShowDialog();
                String invoiceNumber = (inv.Module as InvFac.Dto).InvoiceNumber;
                if (invoiceNumber != String.Empty && form.IsModified)
                {
                    (base.formDto.Dto as Fac.Dto).Invoice = inv.Module as InvFac.Dto;
                    ReturnObject<Boolean> ret = (base.facade as Facade.CheckIn.Server).LinkInvoice();
                    if (ret.HasError())
                    {
                        new BinAff.Presentation.Library.MessageBox().Show(ret.MessageList);
                    }
                    else
                    {
                        T.Complete();
                        this.btnGenerateInvoice.ToolTipText = "View Invoice";
                    }
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //FrmWin.Document form = new Vanilla.Invoice.WinForm.PaymentForm();        
            //form.ShowDialog();
            new Vanilla.Accountant.WinForm.PaymentForm().ShowDialog();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterAndPopulateRoomList();   
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterAndPopulateRoomList();   
        }

        private void cboAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterAndPopulateRoomList();         
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            this.PopulateRoomListFromDaysAndDateChanged();          
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            this.PopulateRoomListFromDaysAndDateChanged();  
        }

        private void ucRoomReservation_RoomListChanged(Int16 days, DateTime from)
        {
            RoomRsvFac.Dto dto = ((base.formDto as Fac.FormDto).Dto as Fac.Dto).Reservation;
            dto.BookingFrom = new DateTime(from.Year, from.Month, from.Day, from.Hour, from.Minute, from.Second);
            if (days > 0)
            {
                dto.NoOfDays = days;
                (this.facade as Fac.Server).RemoveAllBookedRoom();
            }
            this.ucRoomReservation.RoomList = (base.formDto as Fac.FormDto).AllRoomList;
        }

        #endregion

        #region Override from framework

        protected override void Compose()
        {
            this.formDto = new Fac.FormDto
            {
                ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new Fac.Dto 
                {
                    Reservation = new LodgeFac.RoomReservation.Dto()
                }
            };

            this.facade = new Fac.Server(this.formDto as Fac.FormDto);
        }
        
        protected override void LoadForm()
        {
            base.AddToolStripSeparator();
            this.btnCheckOut = base.AddToolStripButton("R", "Wingdings 3", "Checkout");
            this.btnCheckOut.Click += btnCheckOut_Click;
            this.btnGenerateInvoice = base.AddToolStripButton("2", "Wingdings 2", "Generate Invoice");
            this.btnGenerateInvoice.Click += btnGenerateInvoice_Click;
            this.btnPay = base.AddToolStripButton("<", "Wingdings 2", "Pay");
            this.btnPay.Click += btnPay_Click;

            Fac.FormDto formDto = base.formDto as Fac.FormDto;
            Fac.Dto dto = formDto.Dto as Fac.Dto;

            base.facade.LoadForm();
            this.ucRoomReservation.CategoryList = formDto.CategoryList;
            this.ucRoomReservation.TypeList = formDto.TypeList;
            this.ucRoomReservation.AccessoryList = new List<Table>
            {
                new Table { Id = 0, Name = "All" },
                new Table { Id = 1, Name = "AC" },
                new Table { Id = 2, Name = "Non AC" }
            };
            this.ucRoomReservation.RoomList = formDto.AllRoomList;
            this.ucRoomReservation.RoomListChanged += ucRoomReservation_RoomListChanged;
            this.ucRoomReservation.LoadForm(dto.Reservation);            
           
            //this.configRuleDto = formDto.ConfigurationRuleDto;
            //if (this.configRuleDto.DateFormat != null) this.dtFrom.CustomFormat = this.configRuleDto.DateFormat;
        }

        protected override void PopulateDataToForm()
        {
            Fac.Dto dto = this.formDto.Dto as Fac.Dto;
            if (dto != null && dto.Id > 0)
            {
                this.txtPurpose.Text = dto.Purpose;
                this.txtArrivedFrom.Text = dto.ArrivedFrom;
                this.txtCheckInRemark.Text = dto.Remark;
                this.ucRoomReservation.PopulateDataToForm();
            }
            this.btnGenerateInvoice.ToolTipText = ((base.formDto.Dto as Facade.CheckIn.Dto).Invoice == null ? "Generate" : "View") + " Invoice";
        }

        protected override void SetDefault()
        {
            this.ucRoomReservation.SetDefault();
        }

        protected override Boolean ValidateForm()
        {           
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            this.errorProvider.Clear();
            if (String.IsNullOrEmpty(this.txtPurpose.Text))
            {
                errorProvider.SetError(this.txtPurpose, "Please enter purpose.");
                this.txtPurpose.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtArrivedFrom.Text))
            {
                errorProvider.SetError(this.txtArrivedFrom, "Please enter arrived from.");
                this.txtArrivedFrom.Focus();
                return false;
            }
            //Validate form that total number of bed in rooms is not more than the total number of guest
            //Logic will be written in server
            return this.ucRoomReservation.ValidateForm(this.errorProvider);
        }

        protected override void AssignDto()
        {
            Facade.CheckIn.Dto dto = (base.formDto as Facade.CheckIn.FormDto).Dto as Facade.CheckIn.Dto;
            dto.Id = dto == null ? 0 : dto.Id;         
            dto.Date = DateTime.Now;
            this.ucRoomReservation.AssignDto(dto.Reservation);
            dto.Reservation.Status = RoomRsvFac.Status.CheckedIn;
            dto.Status = RoomRsvFac.Status.CheckedIn;

            dto.Purpose = txtPurpose.Text.Trim();
            dto.ArrivedFrom = txtArrivedFrom.Text.Trim();
            dto.Remark = txtCheckInRemark.Text.Trim();            
        }

        protected override Boolean SaveBefore()
        {
            //Alert if the extra room is there
            //Calculate and assign ExtraAccomodation field in SelectedRoom. Logic will be in server.
            return base.SaveBefore();
        }

        protected override FrmWin.Document GetAnsestorForm()
        {
            return new RoomReservationForm(new ArtfFac.Dto());
        }

        protected override void PopulateAnsestorData(FormDocFac.Dto dto)
        {
            LodgeFac.RoomReservation.Dto reservation = dto as LodgeFac.RoomReservation.Dto;
            this.ucRoomReservation.LoadForm(reservation);
            ((base.formDto as Fac.FormDto).Dto as Fac.Dto).Reservation = reservation;
            this.ucRoomReservation.PopulateDataToForm();
            if (reservation.Status == RoomRsvFac.Status.CheckedIn)
            {
                base.IsEnabledSaveButton = false;
                new PresLib.MessageBox(this).Show(new BinAff.Core.Message("Reservation already checked in. Check in not allowed", BinAff.Core.Message.Type.Information));
            }
            else
            {
                base.IsEnabledSaveButton = true;
            }
        }

        protected override void RefreshFormBefore()
        {
            errorProvider.Clear();
        }

        protected override void ClearForm()
        {
            this.ucRoomReservation.ClearForm();
            this.txtPurpose.Text = String.Empty;
            this.txtArrivedFrom.Text = String.Empty;
            this.txtCheckInRemark.Text = String.Empty;
        }

        protected override FrmWin.Document GetAttachment()
        {
            return new InvWin.PaymentForm(new ArtfFac.Dto());
        }

        protected override void DisableFormControls()
        {
            base.errorProvider.Clear();
            this.ucRoomReservation.DisableRemarks();
            Facade.CheckIn.Dto dto = this.formDto.Dto as Facade.CheckIn.Dto;
            if (dto.Id > 0)
            {
                this.ucRoomReservation.DisableFormControls();
                this.txtPurpose.Enabled = false;
                this.txtArrivedFrom.Enabled = false;
                this.txtCheckInRemark.Enabled = false;
                base.DisablePickAncestorButton();
                base.DisableAddAncestorButton();

                base.IsEnabledRefreshButton = false;
                base.IsEnabledSaveButton = false;
                base.IsEnabledDeleteButton = false;

                switch (dto.Reservation.Status)
                {
                    case RoomRsvFac.Status.CheckedIn:
                        this.ucRoomReservation.EnableNoOfDays();
                        this.btnCheckOut.Enabled = true;
                        this.btnGenerateInvoice.Enabled = false;
                        this.btnPay.Enabled = false;
                        base.IsEnabledAttchment = true;
                        break;
                    case RoomRsvFac.Status.CheckOut:
                        this.btnCheckOut.Enabled = false;
                        this.btnGenerateInvoice.Enabled = true;
                        this.btnPay.Enabled = false;
                        base.IsEnabledAttchment = false;
                        break;
                    case RoomRsvFac.Status.Invoiced:
                        this.btnCheckOut.Enabled = false;
                        base.IsEnabledAttchment = false;
                        break;
                    case RoomRsvFac.Status.Paid:
                        this.btnCheckOut.Enabled = false;
                        this.btnPay.Enabled = false;
                        base.IsEnabledAttchment = false;
                        break;
                }
            }
            else
            {
                this.btnCheckOut.Enabled = false;
                this.btnGenerateInvoice.Enabled = false;
                this.btnPay.Enabled = false;
            }
        }

        #endregion

        #region Private

        private void ResetLoad()
        {
            //LodgeFac.RoomReservation.IReservation reservation = new LodgeFac.RoomReservation.ReservationServer(null);
            //this.formDto.dto.Date = this.refreshDto.Date;
            //this.formDto.dto.CustomerDisplayName = this.refreshDto.CustomerDisplayName;
            //this.formDto.dto.Reservation = reservation.CloneReservaion(this.refreshDto.Reservation);
            //this.formDto.dto.Reservation.Customer = reservation.CloneCustomer(this.refreshDto.Reservation.Customer);

            //this.LoadCheckInData();
        }       

        private UtilFac.Artifact.Dto GetInvoiceArtifact()
        {
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;
            Facade.CheckIn.Server checkInServer = new Facade.CheckIn.Server(base.formDto as LodgeFac.CheckIn.FormDto);

            return checkInServer.ReadInvoice();
        }

        private void AddInvoiceNodeToTree(UtilFac.Artifact.Dto artifactDto)
        {
            ////-Add artifact to Invoice node
            //this.trvForm = this.dto.trvForm;
            //Int16 reservationNodePosition = 0;
            //for (int i = 0; i < this.trvForm.Nodes.Count; i++)
            //{
            //    if (this.trvForm.Nodes[i].Text == "Invoice")
            //        break;

            //    reservationNodePosition++;
            //}

            //(this.trvForm.Nodes[reservationNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto).Artifact.Children.Add(artifactDto);
            //artifactDto.Parent = this.trvForm.Nodes[reservationNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto;

        }

        private void PopulateRoomListFromDaysAndDateChanged()
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;
            dto.Reservation = dto.Reservation == null ? new LodgeFac.RoomReservation.Dto() : dto.Reservation;

            //dto.Reservation.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);

            //if (!String.IsNullOrEmpty(txtDays.Text.Trim()) && ValidationRule.IsInteger(txtDays.Text))
            //{
            //    dto.Reservation.NoOfDays = Convert.ToInt16(txtDays.Text);

            //    (this.facade as Fac.Server).RemoveAllBookedRoom();
            //    this.FilterAndPopulateRoomList();
            //}
        }

        private void FilterAndPopulateRoomList()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;

            if (dto.Reservation == null)
                dto.Reservation = new LodgeFac.RoomReservation.Dto();

            //dto.Reservation.RoomCategory = this.cboCategory.SelectedItem == null ? null : new Table { Id = (this.cboCategory.SelectedItem as RoomCatFac.Dto).Id };
            //dto.Reservation.RoomType = this.cboType.SelectedItem == null ? null : new Table { Id = (this.cboType.SelectedItem as RoomTypFac.Dto).Id };
            //dto.Reservation.ACPreference = this.cboAC.SelectedIndex;

            (this.facade as Fac.Server).PopulateRoomWithCriteria();
            this.PopulateRoomList();

            //if ((formDto.RoomList != null && formDto.RoomList.Count > 0) ||  (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 0))
            //{              
            //    txtFilteredRoomCount.Text = (this.facade as Fac.Server).GetTotalNoRooms().ToString();

            //    int FilteredRoomCount = 0;
            //    if (!String.IsNullOrEmpty(txtFilteredRoomCount.Text))
            //        FilteredRoomCount = Convert.ToInt32(txtFilteredRoomCount.Text);

            //    int AvailableRoomCount = FilteredRoomCount < formDto.AvailableRoomCount ? FilteredRoomCount : formDto.AvailableRoomCount;
            //    txtAvailableRoomCount.Text = AvailableRoomCount.ToString();
            //}
            //else
            //{
            //    txtFilteredRoomCount.Text = String.Empty;
            //    txtAvailableRoomCount.Text = String.Empty;
            //}
        }

        private void PopulateRoomList()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            //this.lstRoomList.Bind(formDto.RoomList, "Number");
            //this.lstSelectedRoom.Bind(formDto.SelectedRoomList, "Number");
        }

        private void AddRoom(RoomFac.Dto selectedItem)
        {
            //this.lstRoomList.Items.Remove(selectedItem);
            //this.lstSelectedRoom.Items.Add(selectedItem);
        }

        private void RemoveRoom(RoomFac.Dto selectedItem)
        {
            //this.lstSelectedRoom.Items.Remove(selectedItem);
            //this.lstRoomList.Items.Add(selectedItem);
            ////if (cboSelectedRoom.SelectedIndex != -1)
            ////{
            ////    (this.facade as Fac.Server).AddRoomToAllRoomList((RoomFac.Dto)cboSelectedRoom.SelectedItem);
            ////    this.PopulateRoomList();
            ////}
        }

        private void RemoveFromList(RoomFac.Dto roomDto, ListControl cboRoom)
        {
            //List<RoomFac.Dto> RoomList = new List<RoomFac.Dto>();
            //foreach (RoomFac.Dto dto in (List<RoomFac.Dto>)cboRoom.DataSource)
            //{
            //    if (dto.Id != roomDto.Id) RoomList.Add(dto);
            //}

            //cboRoom.DataSource = null;
            //cboRoom.DataSource = RoomList;
            //cboRoom.DisplayMember = "Number";
            //cboRoom.ValueMember = "Id";
            //cboRoom.SelectedIndex = -1;
        }

        private Boolean ValidateRoom(RoomFac.Dto roomDto)
        {
            //Int64 roomCategoryId = 0;
            //Int64 roomTypeId = 0;
            //Int32 acPreference = 0;

            //if (this.cboCategory.SelectedIndex > 0)
            //{
            //    List<RoomFac.Category.Dto> lstCategory = this.cboCategory.DataSource as List<RoomFac.Category.Dto>;
            //    roomCategoryId = lstCategory[this.cboCategory.SelectedIndex].Id;
            //}

            //if (this.cboType.SelectedIndex > 0)
            //{
            //    List<RoomFac.Type.Dto> lstType = this.cboType.DataSource as List<RoomFac.Type.Dto>;
            //    roomTypeId = lstType[this.cboType.SelectedIndex].Id;
            //}

            //acPreference = this.cboAC.SelectedIndex;

            ////LodgeFac.RoomReservation.IReservation reservation = new LodgeFac.RoomReservation.ReservationServer(null);
            ////Boolean isValidRoom = reservation.ValidateRoomWithCategoryTypeAndACPreference(roomDto, roomCategoryId, roomTypeId, acPreference);

            ////if (!isValidRoom) return false;

            ////if (!this.isRoomBooked(roomDto))
            ////    return false;

            return true;
        }

        private Boolean IsRoomAlreadyReserved(RoomFac.Dto bookedRoom)
        {
            //if (this.formDto.dto == null || this.formDto.dto.Reservation == null || this.formDto.dto.Reservation.RoomList == null)
            //    return false;

            //foreach (RoomFac.Dto room in this.formDto.dto.Reservation.RoomList)
            //{
            //    if (bookedRoom.Id == room.Id)
            //        return true;
            //}

            return false;
        }

        private Boolean IsNoOfDaysExists()
        {
            //if (String.IsNullOrEmpty(txtDays.Text.Trim())) return false;
            //else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim()))) return false;

            return true;
        }

        private Boolean SaveCheckInData()
        {
            return true;
            //Boolean retVal = this.ValidateCheckIn();

            //if (retVal)
            //{
            //    if (this.formDto.dto == null) this.formDto.dto = new LodgeFac.CheckIn.Dto();
            //    this.formDto.dto.Id = this.formDto.dto == null ? 0 : this.formDto.dto.Id;
            //    //this.formDto.dto.Date = new DateTime(dtCheckIn.Value.Year, dtCheckIn.Value.Month, dtCheckIn.Value.Day, dtCheckIn.Value.Hour, dtCheckIn.Value.Minute, dtCheckIn.Value.Second);
            //    this.formDto.dto.Date = DateTime.Now;

            //    if (this.formDto.dto.Reservation == null) this.formDto.dto.Reservation = new LodgeFac.RoomReservation.Dto();
            //    this.formDto.dto.Reservation.Id = this.formDto.dto.Reservation == null ? 0 : this.formDto.dto.Reservation.Id;

            //    this.formDto.dto.Reservation.isCheckedIn = true;
            //    this.formDto.dto.Reservation.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFrom.Value.Hour, dtFrom.Value.Minute, dtFrom.Value.Second);
            //    this.formDto.dto.Reservation.BookingFrom = DateTime.Now;

            //    this.formDto.dto.Reservation.NoOfDays = Convert.ToInt16(txtDays.Text);
            //    this.formDto.dto.Reservation.NoOfPersons = Convert.ToInt16(txtMale.Text);
            //    this.formDto.dto.Reservation.NoOfRooms = Convert.ToInt16(txtRooms.Text);
            //    this.formDto.dto.Reservation.Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtAdvance.Text.Replace(",", ""));
            //    this.formDto.dto.Reservation.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.DataSource as List<RoomFac.Category.Dto>)[this.cboCategory.SelectedIndex].Id };
            //    this.formDto.dto.Reservation.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.DataSource as List<RoomFac.Type.Dto>)[this.cboType.SelectedIndex].Id };
            //    this.formDto.dto.Reservation.ACPreference = this.cboAC.SelectedIndex;
            //    this.formDto.dto.Reservation.RoomList = (List<RoomFac.Dto>)cboSelectedRoom.DataSource;

            //    BinAff.Facade.Library.Server facade = new LodgeFac.CheckIn.CheckInServer(formDto);

            //    if (this.formDto.dto.Id == 0)
            //    {
            //        facade.Add();
            //    }
            //    else
            //    {
            //        facade.Change();
            //    }

            //    //checkIn Id passs back to register
            //    this.dto.Id = this.formDto.dto.Id;
            //    this.dto.Date = this.formDto.dto.Date;
            //    this.dto.Reservation = this.formDto.dto.Reservation;

            //    //Update reservation tree node
            //    //this.UpdateRoomReservationNodeInTree(this.formDto.dto.Reservation);

            //    if (facade.IsError)
            //    {
            //        retVal = false;
            //        new PresLib.MessageBox
            //        {
            //            DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
            //            Heading = "Splash",
            //        }.Show(facade.DisplayMessageList);
            //    }
            //}

            //return retVal;
        }

        private void AddToList(RoomFac.Dto roomDto, ListControl cboRoom)
        {
            //Boolean Include = false;
            //List<RoomFac.Dto> RoomList = new List<RoomFac.Dto>();

            //if (((System.Windows.Forms.ComboBox)cboRoom).Items.Count == 0)
            //{
            //    RoomList.Add(roomDto);
            //}
            //else
            //{
            //    foreach (RoomFac.Dto dto in (List<RoomFac.Dto>)cboRoom.DataSource)
            //    {
            //        if (dto.Id < roomDto.Id || Include == true)
            //            RoomList.Add(dto);
            //        else
            //        {
            //            RoomList.Add(roomDto);
            //            RoomList.Add(dto);
            //            Include = true;
            //        }
            //    }
            //    if (!Include) RoomList.Add(roomDto);
            //}

            //cboRoom.DataSource = null;
            //cboRoom.DataSource = RoomList;
            //cboRoom.DisplayMember = "Number";
            //cboRoom.ValueMember = "Id";
            //cboRoom.SelectedIndex = -1;
        }

        #endregion

    }

}