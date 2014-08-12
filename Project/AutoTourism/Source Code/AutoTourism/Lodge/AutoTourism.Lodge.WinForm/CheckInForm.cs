using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using BinAff.Core;
using BinAff.Utility;
using PresLib = BinAff.Presentation.Library;

//using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;
using InvFac = Vanilla.Invoice.Facade;

using FormWin = Vanilla.Form.WinForm;

using RoomCatFac = AutoTourism.Lodge.Configuration.Facade.Room.Category;
using RoomTypFac = AutoTourism.Lodge.Configuration.Facade.Room.Type;

using Fac = AutoTourism.Lodge.Facade.CheckIn;
using RuleFac = AutoTourism.Configuration.Rule.Facade;
using LodgeFac = AutoTourism.Lodge.Facade;
using CustFac = AutoTourism.Customer.Facade;
using RoomFac = AutoTourism.Lodge.Configuration.Facade.Room;
using TarrifFac = AutoTourism.Lodge.Configuration.Facade.Tariff;
using FrmWin = Vanilla.Form.WinForm;
using System.Transactions;

namespace AutoTourism.Lodge.WinForm
{

    public partial class CheckInForm : FormWin.Document
    {

        private RuleFac.ConfigurationRuleDto configRuleDto;        

        public enum Status
        {
            Open = 10001,
            CheckOut = 10002
        }
      
        ToolStripButton btnCheckOut, btnGenerateInvoice, btnPay;

        public CheckInForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();           
        }
                
        #region Events

        private void CheckInForm_Load(object sender, EventArgs e)
        {
            base.AncestorName = "Room Reservation";
            base.AddToolStripSeparator();
            this.btnCheckOut = base.AddToolStripButton("R", "Wingdings 3", "Checkout");
            this.btnCheckOut.Click += btnCheckOut_Click;
            this.btnGenerateInvoice = base.AddToolStripButton("2", "Wingdings 2", "Generate Invoice");
            this.btnGenerateInvoice.Click += btnGenerateInvoice_Click;
            this.btnPay = base.AddToolStripButton("<", "Wingdings 2", "Pay");
            this.btnPay.Click += btnPay_Click;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            Int32 noOfDays = new Calender().DaysBetweenTwoDays(dto.Date, DateTime.Today);

            if (noOfDays != dto.Reservation.NoOfDays)
            {
                dto.Reservation.NoOfDays = noOfDays == 0 ? 1 : noOfDays;
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Alert,
                    Heading = "Splash"
                }.Show("CheckOut date is not matching with reservation end date. Reservation end date will be changed with checkout.");
            }

            //dto.Reservation.BookingStatusId = Convert.ToInt64(CheckInStatus.CheckOut);
            (this.facade as LodgeFac.CheckIn.CheckInServer).CheckOut();

            //dto.StatusId = Convert.ToInt64(CheckInStatus.CheckOut);
            //base.IsModified = true;
            this.Close();
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;
            String invNumber = String.Empty;
            Vanilla.Invoice.Facade.Dto invoiceDto = new Vanilla.Invoice.Facade.Dto();
            UtilFac.Artifact.Dto inv;
            if (dto.InvoiceNumber == null || dto.InvoiceNumber == String.Empty)
            {
                invoiceDto.invoiceNumber = Common.GenerateInvoiceNumber();
                invNumber = invoiceDto.invoiceNumber;
                (base.facade as Facade.CheckIn.CheckInServer).PopulateInvoiceDto(invoiceDto);
                inv = new UtilFac.Artifact.Dto
                {
                    Module = invoiceDto
                };
            }
            else
            {
                inv = this.GetInvoiceArtifact();
            }

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                if (invNumber != String.Empty)
                    (base.facade as Facade.CheckIn.CheckInServer).UpdateInvoiceNumber(invNumber);

                FrmWin.Document form = new Vanilla.Invoice.WinForm.InvoiceForm(inv);
                if (inv.Id == 0) form.ArtifactSaved += form_ArtifactSaved;
                form.ShowDialog();
                form.MdiParent = this.MdiParent;

                if (invNumber != String.Empty && form.Tag != null && Convert.ToBoolean(form.Tag) == true)
                    T.Complete();
            }
            //form.Show();


            //UtilFac.Artifact.Dto inv = new UtilFac.Artifact.Dto
            //{               
            //    Module = invoiceDto
            //};
            //FrmWin.Document form = new Vanilla.Invoice.WinForm.Invoice(inv);

            //if (dto.InvoiceNumber == null || dto.InvoiceNumber == String.Empty)
            //{
            //    ReturnObject<Boolean> ret = this.GenerateInvoice();

            //    Vanilla.Invoice.Facade.Dto invoiceDto = new Vanilla.Invoice.Facade.Dto();
            //    (base.facade as Facade.CheckIn.CheckInServer).PopulateInvoiceDto(invoiceDto);

            //    if (!ret.Value)
            //    {
            //        new PresLib.MessageBox
            //        {
            //            DialogueType = PresLib.MessageBox.Type.Error,
            //            Heading = "Splash",
            //        }.Show(ret.MessageList);
            //        return;
            //    }
            //}

            //if (!String.IsNullOrEmpty(dto.InvoiceNumber))
            //{
            //    UtilFac.Artifact.Dto inv = this.GetInvoiceArtifact();
            //    FrmWin.Document form = new Vanilla.Invoice.WinForm.Invoice(inv);
            //    if(inv.Id == 0 ) form.ArtifactSaved += form_ArtifactSaved;
            //    form.ShowDialog();
            //    form.MdiParent = this.MdiParent;
            //    form.Show();
            //}

            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //FrmWin.Document form = new Vanilla.Invoice.WinForm.PaymentForm();        
            //form.ShowDialog();
            new Vanilla.Invoice.WinForm.PaymentForm().ShowDialog();
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

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            this.AddRoom();
            //RoomFac.Dto roomDto = null;
            //if (this.cboRoomList.SelectedIndex != -1)
            //{
            //    roomDto = (RoomFac.Dto)this.cboRoomList.SelectedItem;
            //    this.AddToList(roomDto, cboSelectedRoom);
            //    this.RemoveFromList(roomDto, cboRoomList);
            //}
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            this.RemoveRoom();           
        }

        #endregion

        void form_ArtifactSaved(UtilFac.Artifact.Dto document)
        {
            base.RaiseChildArtifactSaved(document);
        }

        #region Protected

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

            this.facade = new Fac.CheckInServer(this.formDto as Fac.FormDto);
        }

        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
           return (this.facade as Fac.CheckInServer).CloneCheckIn(source as Fac.Dto);          
        }
        
        protected override void LoadForm()
        {
            this.SetDefault();

            Fac.FormDto formDto = base.formDto as Fac.FormDto;
            Fac.Dto Dto = formDto.Dto as Fac.Dto;

            Int32 ACPreference = 0;
            Int64 RoomCategory = 0;
            Int64 RoomType = 0;
            if (Dto.Id > 0)
            {
                ACPreference = Dto.Reservation.ACPreference;
                RoomCategory = Dto.Reservation.RoomCategory == null ? 0 : Dto.Reservation.RoomCategory.Id;
                RoomType = Dto.Reservation.RoomType == null ? 0 : Dto.Reservation.RoomType.Id;
            }

            base.facade.LoadForm();    
           
            this.configRuleDto = formDto.ConfigurationRuleDto;
            if (this.configRuleDto.DateFormat != null)
                this.dtFrom.CustomFormat = this.configRuleDto.DateFormat;

            //--populate room category
            this.cboCategory.DataSource = null;
            if (formDto.CategoryList != null && formDto.CategoryList.Count > 0)
            {
                formDto.CategoryList.Insert(0, new RoomFac.Category.Dto
                {
                    Name = "All"
                });

                this.cboCategory.DataSource = formDto.CategoryList;
                this.cboCategory.ValueMember = "Id";
                this.cboCategory.DisplayMember = "Name";
                this.cboCategory.SelectedIndex = 0;
            }

            //--populate room type
            this.cboType.DataSource = null;
            if (formDto.TypeList != null && formDto.TypeList.Count > 0)
            {
                formDto.TypeList.Insert(0, new RoomFac.Type.Dto
                {
                    Name = "All"
                });
                this.cboType.DataSource = formDto.TypeList;
                this.cboType.ValueMember = "Id";
                this.cboType.DisplayMember = "Name";
                this.cboType.SelectedIndex = 0;
            }

            List<Table> lstAC = new List<Table>
            {
                new Table { Id = 0, Name = "All" },
                new Table { Id = 1, Name = "AC" },
                new Table { Id = 2, Name = "Non AC" }
            };
            this.cboAC.DataSource = lstAC;
            this.cboAC.ValueMember = "Id";
            this.cboAC.DisplayMember = "Name";
            this.cboAC.SelectedIndex = 0;
          
            if (Dto.Id > 0)
            {  
                Dto.Reservation.ACPreference = ACPreference;
                Dto.Reservation.RoomCategory = RoomCategory == 0 ? null : new Table { Id = RoomCategory };
                Dto.Reservation.RoomType = RoomType == 0 ? null : new Table { Id = RoomType };
            }
        }

        protected override void PopulateDataToForm()
        {
            Facade.CheckIn.Dto dto = this.formDto.Dto as Facade.CheckIn.Dto;

            //populate checkIn form
            if (dto != null && dto.Id > 0)
            {
                dto.CustomerDisplayName = dto.Reservation.Customer.Name;

                this.LoadCheckInData();

                //disable buttons to pick/add reservatiol
                //base.DisableAddAncestorButton();
                //base.DisablePickAncestorButton();
            }

            this.DisableFormControls();

        }

        protected override Boolean ValidateForm()
        {           
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            Boolean retVal = true;
            this.errorProvider.Clear();

            if (dto == null || dto.Reservation == null || dto.Reservation.Customer == null)
            {
                this.errorProvider.SetError(this.txtName, "Reservation is available for check in.");
                base.FocusPickAncestor();
                return false;
            }
            else if (ValidationRule.IsDateLessThanToday(this.dtFrom.Value))
            {
                this.errorProvider.SetError(this.dtFrom, "Check In date cannot be less than today.");
                this.dtFrom.Focus();
                return false;
            }
            else if (!ValidationRule.IsDateEqual(this.dtFrom.Value, DateTime.Today))
            {
                this.errorProvider.SetError(this.dtFrom, "Check In date cannot be greater than today.");
                this.dtFrom.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtDays.Text.Trim()))
            {
                this.errorProvider.SetError(this.txtDays, "Please enter days.");
                this.txtDays.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtDays.Text.Trim())) || Convert.ToInt16(this.txtDays.Text) == 0)
            {
                this.errorProvider.SetError(this.txtDays, "Entered " + txtDays.Text + " is Invalid.");
                this.txtDays.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtRooms.Text.Trim()))
            {
                this.errorProvider.SetError(this.txtRooms, "Please enter rooms.");
                this.txtRooms.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtRooms.Text.Trim())) || Convert.ToInt16(this.txtRooms.Text) == 0)
            {
                this.errorProvider.SetError(this.txtRooms, "Entered " + this.txtRooms.Text + " is Invalid.");
                this.txtRooms.Focus();
                return false;
            }

            else if (this.cboSelectedRoom.DataSource == null || this.cboSelectedRoom.Items.Count == 0)
            {
                this.errorProvider.SetError(this.cboSelectedRoom, "Select rooms for checkin.");
                this.cboSelectedRoom.Focus();
                return false;
            }
            else if (this.cboSelectedRoom.Items.Count != Convert.ToInt32(this.txtRooms.Text.Trim()))
            {
                this.errorProvider.SetError(this.cboSelectedRoom, "Selected rooms cannot be greater or less than the no of rooms.");
                this.cboSelectedRoom.Focus();
                return false;
            }
            else if (this.cboSelectedRoom.Items.Count > (String.IsNullOrEmpty(this.txtAvailableRoomCount.Text) ? 0 : Convert.ToInt32(this.txtAvailableRoomCount.Text)))
            {
                this.errorProvider.SetError(this.txtRooms, "No of rooms cannot be greater than available rooms.");
                this.cboSelectedRoom.Focus();
                return false;
            }
            return retVal;
        }

        protected override void AssignDto()
        {
            Facade.CheckIn.Dto dto = (base.formDto as Facade.CheckIn.FormDto).Dto as Facade.CheckIn.Dto;
            dto.Id = dto == null ? 0 : dto.Id;

         
            dto.Date = DateTime.Now;
            dto.Reservation.isCheckedIn = true;

            //-- Reservation will always exists during check in
            //if (dto.Reservation == null) dto.Reservation = new LodgeFac.RoomReservation.Dto();
            //dto.Reservation.Id = dto.Reservation == null ? 0 : dto.Reservation.Id;
           
            dto.Reservation.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFrom.Value.Hour, dtFrom.Value.Minute, dtFrom.Value.Second);
            dto.Reservation.NoOfDays = Convert.ToInt16(this.txtDays.Text);
            dto.Reservation.NoOfRooms = Convert.ToInt16(this.txtRooms.Text);

            //non-mandatory drop down       
            //dto.Reservation.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.DataSource as List<RoomFac.Category.Dto>)[this.cboCategory.SelectedIndex].Id };
            //dto.Reservation.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.DataSource as List<RoomFac.Type.Dto>)[this.cboType.SelectedIndex].Id };
            dto.Reservation.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.SelectedItem as RoomFac.Category.Dto).Id };
            dto.Reservation.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.SelectedItem as RoomFac.Type.Dto).Id };
            dto.Reservation.ACPreference = this.cboAC.SelectedIndex;

            //non-mandatory textBox
            dto.Reservation.NoOfMale = String.IsNullOrEmpty(txtMale.Text.Trim()) ? 0 : Convert.ToInt32(txtMale.Text);
            dto.Reservation.NoOfFemale = String.IsNullOrEmpty(txtFemale.Text.Trim()) ? 0 : Convert.ToInt32(txtFemale.Text);
            dto.Reservation.NoOfChild = String.IsNullOrEmpty(txtChild.Text.Trim()) ? 0 : Convert.ToInt32(txtChild.Text);
            dto.Reservation.NoOfInfant = String.IsNullOrEmpty(txtInfant.Text.Trim()) ? 0 : Convert.ToInt32(txtInfant.Text);
            dto.Reservation.Remark = txtReservationRemarks.Text.Trim();

            dto.Reservation.RoomList = (List<RoomFac.Dto>)this.cboSelectedRoom.DataSource;

            dto.Purpose = txtPurpose.Text.Trim();
            dto.ArrivedFrom = txtArrivedFrom.Text.Trim();
            dto.Remark = txtCheckInRemark.Text.Trim();
            
        }
        
        protected override void Ok()
        {
            if (base.Save())
            {
                Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;
                //dto.StatusId = Convert.ToInt64(CheckInStatus.CheckIn);
                base.IsModified = true;
                //this.Close();
            }
        }

        protected override void PickAnsestor()
        {
            Form form = new RoomReservationRegister();
            form.ShowDialog(this);

            if (form.Tag != null)
            {
                this.PopulateReservationData(form.Tag as LodgeFac.RoomReservationRegister.Dto);
            }
        }

        protected override void AddAnsestor()
        {
            //Form form = new RoomReservationForm(this.dto.trvForm);
            //form.ShowDialog(this);

            //if (form.Tag != null)
            //    this.PopulateReservationData(form);
        }
      
        protected override void RefreshFormBefore()
        {
            errorProvider.Clear();
        }

        protected override void RevertForm()
        {            
            (base.formDto as Fac.FormDto).Dto = this.CloneDto(this.InitialDto) as Fac.Dto;
        }

        protected override void ClearForm()
        {
            dtFrom.Value = DateTime.Now;
            dtFromTime.Value = DateTime.Now;
            txtDays.Text = String.Empty;
            txtRooms.Text = String.Empty;
            this.cboCategory.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
            this.cboAC.SelectedIndex = 0;
            txtMale.Text = String.Empty;
            txtFemale.Text = String.Empty;
            txtChild.Text = String.Empty;
            txtInfant.Text = String.Empty;
            txtPurpose.Text = String.Empty;
            txtArrivedFrom.Text = String.Empty;
            txtCheckInRemark.Text = String.Empty;
            cboRoomList.DataSource = null;
            cboSelectedRoom.DataSource = null;
            

            txtReservationNo.Text = String.Empty;
            txtStatus.Text = String.Empty;
            txtName.Text = String.Empty;
            lstContact.DataSource = null;
            txtAdds.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtFilteredRoomCount.Text = String.Empty;
            txtAvailableRoomCount.Text = String.Empty;
            txtReservationRemarks.Text = String.Empty;

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

            Facade.CheckIn.ICheckIn checkInServer = new Facade.CheckIn.CheckInServer(base.formDto as LodgeFac.CheckIn.FormDto);

            InvFac.IInvoice invoice = new InvFac.Server(null);
            InvFac.Dto invoiceDto = invoice.GetInvoice(dto.InvoiceNumber);

            //Vanilla.Invoice.Facade.Dto invoiceDto = checkInServer.ReadInvoice(dto.InvoiceNumber);

            UtilFac.Artifact.Dto invoiceArtifact = (base.facade as Facade.CheckIn.CheckInServer).GetInvoiceArtifact(dto.InvoiceNumber);

            return new UtilFac.Artifact.Dto
            {
                Id = invoiceArtifact == null ? 0 : invoiceArtifact.Id,
                Module = invoiceDto
            };
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

        private void DisableFormControls()
        {
            errorProvider.Clear();

            Facade.CheckIn.Dto dto = this.formDto.Dto as Facade.CheckIn.Dto;
            Boolean blnDisable = false;
            
            if(dto.Id > 0)
                blnDisable = (ValidationRule.IsDateLessThanToday(dto.Date) || (dto.StatusId == Convert.ToInt64(Status.CheckOut))) ? true : false;

            if (blnDisable)
            {
                dtFrom.Enabled = false;
                dtFromTime.Enabled = false;
                txtDays.Enabled = false;
                txtRooms.Enabled = false;
                cboCategory.Enabled = false;
                cboType.Enabled = false;
                cboAC.Enabled = false;
                txtMale.Enabled = false;
                txtFemale.Enabled = false;
                txtChild.Enabled = false;
                txtInfant.Enabled = false;
                txtPurpose.Enabled = false;
                txtArrivedFrom.Enabled = false;
                txtCheckInRemark.Enabled = false;
                cboRoomList.Enabled = false;
                cboSelectedRoom.Enabled = false;
                btnAddRoom.Enabled = false;
                btnRemoveRoom.Enabled = false;

                base.DisablePickAncestorButton();
                base.DisableAddAncestorButton();
                base.DisableRefreshButton();
                base.DisableOkButton();
                this.btnCheckOut.Enabled = false;
            }
        }

        private void SetDefault()
        {
            //set default date format
            this.dtFrom.Format = DateTimePickerFormat.Custom;
            this.dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
        }

        private void PopulateRoomListFromDaysAndDateChanged()
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;
            dto.Reservation = dto.Reservation == null ? new LodgeFac.RoomReservation.Dto() : dto.Reservation;

            dto.Reservation.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);

            if (!String.IsNullOrEmpty(txtDays.Text.Trim()) && ValidationRule.IsInteger(txtDays.Text))
            {
                dto.Reservation.NoOfDays = Convert.ToInt16(txtDays.Text);

                (this.facade as Fac.CheckInServer).RemoveAllBookedRoom();
                this.FilterAndPopulateRoomList();
            }
        }

        private void FilterAndPopulateRoomList()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;

            if (dto.Reservation == null)
                dto.Reservation = new LodgeFac.RoomReservation.Dto();

            dto.Reservation.RoomCategory = this.cboCategory.SelectedItem == null ? null : new Table { Id = (this.cboCategory.SelectedItem as RoomCatFac.Dto).Id };
            dto.Reservation.RoomType = this.cboType.SelectedItem == null ? null : new Table { Id = (this.cboType.SelectedItem as RoomTypFac.Dto).Id };
            dto.Reservation.ACPreference = this.cboAC.SelectedIndex;

            (this.facade as Fac.CheckInServer).PopulateRoomWithCriteria();
            this.PopulateRoomList();

            if ((formDto.RoomList != null && formDto.RoomList.Count > 0) ||  (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 0))
            {              
                txtFilteredRoomCount.Text = (this.facade as Fac.CheckInServer).GetTotalNoRooms().ToString();

                int FilteredRoomCount = 0;
                if (!String.IsNullOrEmpty(txtFilteredRoomCount.Text))
                    FilteredRoomCount = Convert.ToInt32(txtFilteredRoomCount.Text);

                int AvailableRoomCount = FilteredRoomCount < formDto.AvailableRoomCount ? FilteredRoomCount : formDto.AvailableRoomCount;
                txtAvailableRoomCount.Text = AvailableRoomCount.ToString();
            }
            else
            {
                txtFilteredRoomCount.Text = String.Empty;
                txtAvailableRoomCount.Text = String.Empty;
            }

        }

        private void PopulateRoomList()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;

            this.cboRoomList.DataSource = null;
            if (formDto.RoomList != null && formDto.RoomList.Count > 0)
            {
                this.cboRoomList.DataSource = formDto.RoomList;
                this.cboRoomList.DisplayMember = "Number";
                this.cboRoomList.ValueMember = "Id";
                this.cboRoomList.SelectedIndex = -1;
            }

            this.cboSelectedRoom.DataSource = null;
            if (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 0)
            {
                this.cboSelectedRoom.DataSource = formDto.SelectedRoomList;
                this.cboSelectedRoom.DisplayMember = "Number";
                this.cboSelectedRoom.ValueMember = "Id";
                this.cboSelectedRoom.SelectedIndex = -1;
            }
        }

        private void AddRoom()
        {
            if (cboRoomList.SelectedIndex != -1)
            {
                (this.facade as Fac.CheckInServer).RemoveRoomFromAllRoomList((RoomFac.Dto)cboRoomList.SelectedItem);
                this.PopulateRoomList();
            }
        }

        private void RemoveRoom()
        {
            if (cboSelectedRoom.SelectedIndex != -1)
            {
                (this.facade as Fac.CheckInServer).AddRoomToAllRoomList((RoomFac.Dto)cboSelectedRoom.SelectedItem);
                this.PopulateRoomList();
            }
        }

        private void RemoveFromList(RoomFac.Dto roomDto, ListControl cboRoom)
        {
            List<RoomFac.Dto> RoomList = new List<RoomFac.Dto>();
            foreach (RoomFac.Dto dto in (List<RoomFac.Dto>)cboRoom.DataSource)
                if (dto.Id != roomDto.Id) RoomList.Add(dto);

            cboRoom.DataSource = null;
            cboRoom.DataSource = RoomList;
            cboRoom.DisplayMember = "Number";
            cboRoom.ValueMember = "Id";
            cboRoom.SelectedIndex = -1;
        }

        private void LoadCheckInData()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;

            Int32 ACPreference = dto.Reservation.ACPreference;
            Table RoomCategory = dto.Reservation.RoomCategory;
            Table RoomType = dto.Reservation.RoomType;

            this.txtReservationNo.Text = dto.Reservation.ReservationNo;

            if (dto.Id > 0)
                txtStatus.Text = (dto.StatusId == Convert.ToInt64(Status.Open)) ? "Checked In" : "Checked Out";
            else
                txtStatus.Text = "Open";

            this.txtRooms.Text = dto.Reservation.NoOfRooms.ToString();
            txtPurpose.Text = dto.Purpose;
            txtArrivedFrom.Text = dto.ArrivedFrom;
            txtCheckInRemark.Text = dto.Remark;

            dto.Reservation.RoomCategory = RoomCategory;
            if (dto.Reservation.RoomCategory != null && dto.Reservation.RoomCategory.Id > 0)
            {
                for (int i = 0; i < this.cboCategory.Items.Count; i++)
                {
                    if (dto.Reservation.RoomCategory.Id == ((RoomFac.Category.Dto)this.cboCategory.Items[i]).Id)
                    {
                        this.cboCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                this.cboCategory.SelectedIndex = 0;
            }

            dto.Reservation.RoomType = RoomType;
            if (dto.Reservation.RoomType != null && dto.Reservation.RoomType.Id > 0)
            {
                for (int i = 0; i < this.cboType.Items.Count; i++)
                {
                    if (dto.Reservation.RoomType.Id == ((RoomFac.Type.Dto)this.cboType.Items[i]).Id)
                    {
                        this.cboType.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                this.cboType.SelectedIndex = 0;
            }

            dto.Reservation.ACPreference = ACPreference;
            this.cboAC.SelectedIndex = dto.Reservation.ACPreference;

            if (dto.Reservation.RoomList != null && dto.Reservation.RoomList.Count > 0)
            {
                formDto.SelectedRoomList = dto.Reservation.RoomList;
            }


            this.txtMale.Text = dto.Reservation.NoOfMale.ToString();
            this.txtFemale.Text = dto.Reservation.NoOfFemale.ToString();
            this.txtChild.Text = dto.Reservation.NoOfChild.ToString();
            this.txtInfant.Text = dto.Reservation.NoOfInfant.ToString();
            this.txtReservationRemarks.Text = dto.Reservation.Remark;

            //populate customer data
            this.txtName.Text = dto.CustomerDisplayName;
            this.lstContact.DataSource = dto.Reservation.Customer.ContactNumberList;
            this.lstContact.DisplayMember = "Name";
            this.lstContact.ValueMember = "Id";
            this.lstContact.SelectedIndex = -1;
            this.txtAdds.Text = dto.Reservation.Customer.Address;
            this.txtEmail.Text = dto.Reservation.Customer.Email;

            //below code is added last , since dtFrom and txtDays controls has changed event associated with it
            //populate reservation data
            if (!ValidationRule.IsMinimumDate(dto.Reservation.BookingFrom))
            {
                this.dtFrom.Value = dto.Reservation.BookingFrom;
                this.dtFromTime.Value = dto.Reservation.BookingFrom;
            }

            this.txtDays.Text = String.Empty; //line added purposefully to fire event PopulateRoomListFromDaysAndDateChanged during refresh
            this.txtDays.Text = dto.Reservation.NoOfDays.ToString();
        }

        private Boolean ValidateRoom(RoomFac.Dto roomDto)
        {
            Int64 roomCategoryId = 0;
            Int64 roomTypeId = 0;
            Int32 acPreference = 0;

            if (this.cboCategory.SelectedIndex > 0)
            {
                List<RoomFac.Category.Dto> lstCategory = this.cboCategory.DataSource as List<RoomFac.Category.Dto>;
                roomCategoryId = lstCategory[this.cboCategory.SelectedIndex].Id;
            }

            if (this.cboType.SelectedIndex > 0)
            {
                List<RoomFac.Type.Dto> lstType = this.cboType.DataSource as List<RoomFac.Type.Dto>;
                roomTypeId = lstType[this.cboType.SelectedIndex].Id;
            }

            acPreference = this.cboAC.SelectedIndex;

            //LodgeFac.RoomReservation.IReservation reservation = new LodgeFac.RoomReservation.ReservationServer(null);
            //Boolean isValidRoom = reservation.ValidateRoomWithCategoryTypeAndACPreference(roomDto, roomCategoryId, roomTypeId, acPreference);

            //if (!isValidRoom) return false;

            //if (!this.isRoomBooked(roomDto))
            //    return false;

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

        private void PopulateReservationData(LodgeFac.RoomReservationRegister.Dto roomReservationRegisterDto)
        {
            //Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;

            dto.CustomerDisplayName = roomReservationRegisterDto.Name;
            dto.Date = roomReservationRegisterDto.BookingFrom;
            dto.Reservation = new LodgeFac.RoomReservation.Dto
            {
                Id = roomReservationRegisterDto.Id,
                NoOfDays = roomReservationRegisterDto.NoOfDays,
                //NoOfPersons = roomReservationRegisterDto.NoOfPersons,
                NoOfRooms = roomReservationRegisterDto.NoOfRooms,             
                RoomCategory = roomReservationRegisterDto.RoomCategory,
                RoomType = roomReservationRegisterDto.RoomType,
                ACPreference = roomReservationRegisterDto.ACPreference,
                RoomList = roomReservationRegisterDto.RoomList,
                BookingFrom = roomReservationRegisterDto.BookingFrom,

                NoOfMale = roomReservationRegisterDto.NoOfMale,
                NoOfFemale = roomReservationRegisterDto.NoOfFemale,
                NoOfChild = roomReservationRegisterDto.NoOfChild,
                NoOfInfant = roomReservationRegisterDto.NoOfInfant,
                Remark = roomReservationRegisterDto.Remark,
                ReservationNo = roomReservationRegisterDto.ReservationNo,

                Customer = roomReservationRegisterDto.Customer,
                BookingStatusId = roomReservationRegisterDto.BookingStatusId
            };

            this.LoadCheckInData();
        }

        private Boolean IsNoOfDaysExists()
        {
            if (String.IsNullOrEmpty(txtDays.Text.Trim())) return false;
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim()))) return false;

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
            Boolean Include = false;
            List<RoomFac.Dto> RoomList = new List<RoomFac.Dto>();

            if (((System.Windows.Forms.ComboBox)cboRoom).Items.Count == 0)
            {
                RoomList.Add(roomDto);
            }
            else
            {
                foreach (RoomFac.Dto dto in (List<RoomFac.Dto>)cboRoom.DataSource)
                {
                    if (dto.Id < roomDto.Id || Include == true)
                        RoomList.Add(dto);
                    else
                    {
                        RoomList.Add(roomDto);
                        RoomList.Add(dto);
                        Include = true;
                    }
                }
                if (!Include) RoomList.Add(roomDto);
            }

            cboRoom.DataSource = null;
            cboRoom.DataSource = RoomList;
            cboRoom.DisplayMember = "Number";
            cboRoom.ValueMember = "Id";
            cboRoom.SelectedIndex = -1;
        }

        #endregion

    }

}
