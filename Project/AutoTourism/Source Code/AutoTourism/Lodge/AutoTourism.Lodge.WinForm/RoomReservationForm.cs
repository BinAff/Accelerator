using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;

using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using InvWin = Vanilla.Invoice.WinForm;

using Fac = AutoTourism.Lodge.Facade.RoomReservation;
using RuleFac = AutoTourism.Configuration.Rule.Facade;
using CustFac = AutoTourism.Customer.Facade;
using RoomFac = AutoTourism.Lodge.Configuration.Facade.Room;
using RoomCatFac = AutoTourism.Lodge.Configuration.Facade.Room.Category;
using RoomTypFac = AutoTourism.Lodge.Configuration.Facade.Room.Type;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationForm : FormWin.Document
    {

        private RuleFac.ConfigurationRuleDto configRuleDto;
        private ToolStripButton btnCancel;     

        //private List<RoomFac.Dto> bookedRooms;           
        
        public RoomReservationForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();           
        }

        protected override void Compose()
        {
            this.formDto = new Fac.FormDto 
            {
                ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new Fac.Dto()
            };

            this.facade = new Fac.ReservationServer(this.formDto as Fac.FormDto);
        }
              
        public RoomReservationForm(Fac.Dto dto)
        {
            InitializeComponent();

            //this.dto = dto;
            //this.trvForm = this.dto.trvForm;

            //if (this.dto.Id > 0)
            //{
            //    Fac.IReservation reservation = new Fac.ReservationServer(null);
            //    this.refreshDto = reservation.CloneReservaion(this.dto);
            //}
        }

        #region Events

        private void RoomBookingForm_Load(object sender, System.EventArgs e)
        {
            base.AncestorName = "Customer";
            base.AttachmentName = "Advance Payment";
            base.AddToolStripSeparator();
            this.btnCancel = base.AddToolStripButton("Í", "Wingdings 2", "Cancel Reservation");
            this.btnCancel.Click += btnCancel_Click;
            ////set default date format
            //this.dtFrom.Format = DateTimePickerFormat.Custom;
            //this.dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case

            //this.dtFromTime.Format = DateTimePickerFormat.Time;
            //this.dtFromTime.ShowUpDown = true;

            //this.formDto = new Fac.FormDto
            //{ 
            //    Dto = this.dto,
            //    ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
            //};

            ////if loaded form checkin form , then populate the modules
            //if (this.isLoadedFromCheckInForm)
            //{
            //    new Vanilla.Utility.Facade.Module.Server(this.formDto.ModuleFormDto).LoadForm();
            //}

            //LoadForm();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            this.AddRoom();
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            this.RemoveRoom();
        }

        private void cboRoomList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.AddRoom();
        }

        private void cboSelectedRoom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.RemoveRoom();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        { 
            if (this.formDto != null && this.formDto.Dto != null)
            {
                Fac.Dto dto = this.formDto.Dto as Fac.Dto;

                Boolean isOpenCancel = true;
                Int64 BookingStatusId = (txtStatus.Text == "Cancel") ? Convert.ToInt64(Status.Open) : Convert.ToInt64(Status.Canceled);

                //if (BookingStatusId == Convert.ToInt64(Status.Open))
                //{
                //    //isOpenCancel = this.ValidateReservation();
                //}
                //Status status = txtStatus.Text == "Cancel" ? Status.Canceled : Status.Open;                
                ////validation required when re-opening a room
                //Boolean isOpenCancel = !(status == Status.Open && !this.ValidateForm());

                if (isOpenCancel)
                {
                    dto.BookingStatusId = BookingStatusId;
                    (this.facade as Fac.ReservationServer).ChangeReservationStatus();                    
                  
                    base.IsModified = true;
                    this.Close();
                }
            }
        }
                      
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {            
            this.FilterAndPopulateRoomList();

            //this.PopulateFilteredRoomList();
            //this.LoadRoomReservationStatusLevels();
        }
             
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterAndPopulateRoomList();

            //this.PopulateFilteredRoomList();
            //this.LoadRoomReservationStatusLevels();
        }

        private void cboAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterAndPopulateRoomList();

            //this.PopulateFilteredRoomList();
            //this.LoadRoomReservationStatusLevels();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;
            dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);

            if (!String.IsNullOrEmpty(txtDays.Text.Trim()) && ValidationRule.IsInteger(txtDays.Text))
            {
                dto.NoOfDays = Convert.ToInt16(txtDays.Text);

                (this.facade as Fac.ReservationServer).PopulateRoomList();
                this.FilterAndPopulateRoomList();
            }

            //this.ValidateBookedRoomsAndPopulate();
            //this.LoadRoomReservationStatusLevels();
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;
            dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);

            if (!String.IsNullOrEmpty(txtDays.Text.Trim()) && ValidationRule.IsInteger(txtDays.Text))
            {
                dto.NoOfDays = Convert.ToInt16(txtDays.Text);

                (this.facade as Fac.ReservationServer).PopulateRoomList();
                this.FilterAndPopulateRoomList();
            }
             

            //this.ValidateBookedRoomsAndPopulate();
            //this.LoadRoomReservationStatusLevels();
        }
        
        #endregion

        private void PopulateRoomListFromDaysAndDateChanged()
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;
            dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);

            if (!String.IsNullOrEmpty(txtDays.Text.Trim()) && ValidationRule.IsInteger(txtDays.Text))
            {
                dto.NoOfDays = Convert.ToInt16(txtDays.Text);

                (this.facade as Fac.ReservationServer).PopulateRoomList();
                this.FilterAndPopulateRoomList();
            }
        }

        protected override void LoadForm()
        {
            this.SetDefault();

            Fac.FormDto formDto = base.formDto as Fac.FormDto;
            base.facade.LoadForm();

            //new Fac.ReservationServer(formDto).LoadForm();

            this.configRuleDto = formDto.configurationRuleDto;
            if (this.configRuleDto.DateFormat != null)            
                this.dtFrom.CustomFormat = this.configRuleDto.DateFormat;


            //--populate room category
            this.cboCategory.DataSource = null;
            if (formDto.CategoryList != null && formDto.CategoryList.Count > 0)
            {
                formDto.CategoryList.Insert(0, new RoomCatFac.Dto
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
                formDto.TypeList.Insert(0, new RoomTypFac.Dto
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

            //this.LoadReservationData();

            //this.txtArtifactPath.ReadOnly = true;
            //if (this.isLoadedFromCheckInForm)
            //    this.txtArtifactPath.Text = new Vanilla.Utility.Facade.Module.Server(null).GetRootLevelModulePath("LRSV", formDto.ModuleFormDto.FormModuleList, "Form");
            //else
            //    this.txtArtifactPath.Text = this.dto.artifactPath;

            //disable the controls if the reservation is checked in
            if (formDto.Dto != null && (formDto.Dto as Fac.Dto).isCheckedIn)
            {
                this.DisableFormControls();
            }
            else if (formDto.Dto != null && (formDto.Dto as Fac.Dto).BookingStatusId == Convert.ToInt64(Status.Canceled))
            {
                this.DisableFormControls();
                //btnCancel.Enabled = true;
            }

            //Hide open cancel button for new reservation
            if (formDto.Dto == null || formDto.Dto.Id == 0)
            {
                this.btnCancel.Visible = false;
            }
        }

        protected override void RevertForm()
        {
            //Revert the form to the original form when it is loaded
        }

        protected override void RefreshFormBefore()
        {
            errorProvider.Clear();
        }

        protected override void RefreshFormAfter()
        {
            //this.PopulateFilteredRoomList();
            txtDays.Focus();
        }

        protected override void Ok()
        {
            //if (this.SaveReservationData())
            //{
            //    if (this.isLoadedFromCheckInForm) this.SaveArtifact();

            //    base.IsModified = true;
            //    this.Close();
            //}

            if (base.Save())
            {
                base.Artifact.Module = base.formDto.Dto;
                base.IsModified = true;
                this.Close();
            }
        }
             
        protected override void PickAnsestor()
        {
            //Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerRegister, AutoTourism.Customer.WinForm", true);
            //Form form = (Form)Activator.CreateInstance(type);
            Form form = new AutoTourism.Customer.WinForm.CustomerRegister();
            form.ShowDialog(this);

            if (form.Tag != null)
            {
                this.PopulateCustomerData(form.Tag as CustFac.Dto);
            }
        }

        protected override void AddAnsestor()
        {
            ArtfFac.Dto cutomerArtifact = new ArtfFac.Dto();
            FormWin.Document form = new AutoTourism.Customer.WinForm.CustomerForm(cutomerArtifact);
            form.ArtifactSaved += form_ArtifactSaved;
            form.ShowDialog(this);
            if (form.Artifact != null && form.Artifact.Module != null)
            {
                this.PopulateCustomerData(form.Artifact.Module as CustFac.Dto);
            }
        }

        protected override FormWin.Document GetAttachment()
        {
            return new InvWin.AdvancePaymentForm();
        }

        private void form_ArtifactSaved(ArtfFac.Dto document)
        {
            base.RaiseChildArtifactSaved(document);
        }

        private void PopulateCustomerData(CustFac.Dto customerData)
        {
            //Fac.FormDto formDto = base.formDto as Fac.FormDto;
            //(formDto.Dto as Fac.Dto).Customer = document as CustFac.Dto;

            //if (this.dto == null)
            //{
            //    this.dto = new Fac.Dto();
            //}
            //this.dto.Customer = form.Tag as CustFac.Dto;

            //this.txtName.Text = (formDto.Dto as Fac.Dto).Customer.Name;

            //this.lstContact.DataSource = (formDto.Dto as Fac.Dto).Customer.ContactNumberList;
            //this.lstContact.DisplayMember = "Name";
            //this.lstContact.ValueMember = "Id";
            //this.lstContact.SelectedIndex = -1;
            //this.txtAdds.Text = (formDto.Dto as Fac.Dto).Customer.Address;
            //this.txtEmail.Text = (formDto.Dto as Fac.Dto).Customer.Email;
            (formDto.Dto as Fac.Dto).Customer = customerData;
            this.txtName.Text = customerData.Name;

            this.lstContact.DataSource = customerData.ContactNumberList;
            this.lstContact.DisplayMember = "Name";
            this.lstContact.ValueMember = "Id";
            this.lstContact.SelectedIndex = -1;
            this.txtAdds.Text = customerData.Address;
            this.txtEmail.Text = customerData.Email;
        }
               
        protected override void PopulateDataToForm()
        {
            //CustFac.Dto dto = this.formDto.Dto as CustFac.Dto
            Fac.FormDto formDto = this.formDto as Fac.FormDto;
            Fac.Dto dto = this.formDto.Dto as Fac.Dto;

            //Fac.IReservation reservation = new Fac.ReservationServer(null);

            //populate customer data
            if (dto != null && dto.Id > 0)
            {
                if (dto.Customer != null)
                {
                    this.txtName.Text = dto.Customer.Name;
                    this.lstContact.DataSource = dto.Customer.ContactNumberList;
                    this.lstContact.DisplayMember = "Name";
                    this.lstContact.ValueMember = "Id";
                    this.lstContact.SelectedIndex = -1;
                    this.txtAdds.Text = dto.Customer.Address;
                    this.txtEmail.Text = dto.Customer.Email;
                }

                //populate booking data
                if (!ValidationRule.IsMinimumDate(dto.BookingFrom))
                {
                    dtFrom.Value = dto.BookingFrom;
                    dtFromTime.Value = dto.BookingFrom;
                }
                this.txtDays.Text = dto.NoOfDays == 0 ? String.Empty : dto.NoOfDays.ToString();           
                this.txtRooms.Text = dto.NoOfRooms == 0 ? String.Empty : dto.NoOfRooms.ToString();
                //this.txtAdvance.Text = dto.Advance == 0 ? String.Empty : Converter.ConvertToIndianCurrency(dto.Advance);
                this.cboSelectedRoom.DataSource = dto.RoomList;
                this.cboSelectedRoom.DisplayMember = "Number";
                this.cboSelectedRoom.ValueMember = "Id";
                this.cboSelectedRoom.SelectedIndex = -1;

                if (dto.RoomCategory != null && dto.RoomCategory.Id > 0)
                {
                    for (int i = 0; i < cboCategory.Items.Count; i++)
                    {
                        if (dto.RoomCategory.Id == ((RoomCatFac.Dto)cboCategory.Items[i]).Id)
                        {
                            cboCategory.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else cboCategory.SelectedIndex = 0;

                if (dto.RoomType != null && dto.RoomType.Id > 0)
                {
                    for (int i = 0; i < cboType.Items.Count; i++)
                    {
                        if (dto.RoomType.Id == ((RoomTypFac.Dto)cboType.Items[i]).Id)
                        {
                            cboType.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else cboType.SelectedIndex = 0;

                cboAC.SelectedIndex = dto.ACPreference;

                //if (dto.BookingStatusId == Convert.ToInt64(Status.Open))
                //{
                //    txtStatus.Text = "Open";
                //    this.btnCancel.Text = "Í";
                //    this.btnCancel.ToolTipText = "Cancel";
                //}
                //else if (dto.BookingStatusId == Convert.ToInt64(Status.Canceled))
                //{
                //    txtStatus.Text = "Cancel";
                //    this.btnCancel.Text = "N";
                //    this.btnCancel.ToolTipText = "Reopen";
                //}
                               
                this.txtMale.Text = dto.NoOfMale == 0 ? String.Empty : dto.NoOfMale.ToString();
                this.txtFemale.Text = dto.NoOfFemale == 0 ? String.Empty : dto.NoOfFemale.ToString();
                this.txtChild.Text = dto.NoOfChild == 0 ? String.Empty : dto.NoOfChild.ToString();
                this.txtInfant.Text = dto.NoOfInfant == 0 ? String.Empty : dto.NoOfInfant.ToString();
                this.txtRemarks.Text = dto.Remark.ToString();
                this.txtReservationNo.Text = dto.ReservationNo;

                if (dto.RoomList != null && dto.RoomList.Count > 0)
                {
                    formDto.SelectedRoomList = dto.RoomList;
                }

                this.PopulateRoomListFromDaysAndDateChanged();
            }
        }

        private void DisableFormControls()
        {
            errorProvider.Clear();

            base.DisablePickAncestorButton();
            base.DisableAddAncestorButton();
            base.DisableRefreshButton();
            base.DisableOkButton();
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
                                   
            this.cboRoomList.Enabled = false;
            this.cboSelectedRoom.Enabled = false;
            this.cboAC.Enabled = false;
        }

        protected override void ClearForm()
        {
            this.txtName.Text = String.Empty;
            this.lstContact.DataSource = null;
            this.txtAdds.Text = String.Empty;
            this.txtEmail.Text = String.Empty;

            this.txtDays.Text = String.Empty;
            this.txtMale.Text = String.Empty;
            this.txtRooms.Text = String.Empty;
        
            this.cboSelectedRoom.DataSource = null;

            this.dtFrom.Value = DateTime.Now;
            this.dtFromTime.Value = DateTime.Now;

            this.cboCategory.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
            this.cboAC.SelectedIndex = 0;

            txtChild.Text = String.Empty;
            txtInfant.Text = String.Empty;
            txtFemale.Text = String.Empty;
            txtRemarks.Text = String.Empty;
        }       

        private void ResetLoad()
        {
            //Fac.IReservation reservation = new Fac.ReservationServer(null);
            //this.dto.Customer = this.refreshDto.Customer == null ? null : reservation.CloneCustomer(this.refreshDto.Customer);
            //this.dto.BookingFrom = this.refreshDto.BookingFrom;
            //this.dto.NoOfDays = this.refreshDto.NoOfDays;
            //this.dto.NoOfPersons = this.refreshDto.NoOfPersons;
            //this.dto.NoOfRooms = this.refreshDto.NoOfRooms;
            //this.dto.Advance = this.refreshDto.Advance;
            //this.dto.BookingStatusId = this.refreshDto.BookingStatusId;
            //this.dto.RoomCategory = this.refreshDto.RoomCategory;
            //this.dto.RoomType = this.refreshDto.RoomType;
            //this.dto.ACPreference = this.refreshDto.ACPreference;
            //this.dto.RoomList = this.refreshDto.RoomList;           

            //this.LoadReservationData();
        }

        private void AddRoom()
        {
            if (cboRoomList.SelectedIndex != -1)
            {
                (this.facade as Fac.ReservationServer).RemoveRoomFromAllRoomList((RoomFac.Dto)cboRoomList.SelectedItem);
                this.PopulateRoomList();
            }
        }

        private void RemoveRoom()
        {
            if (cboSelectedRoom.SelectedIndex != -1)
            {
                (this.facade as Fac.ReservationServer).AddRoomToAllRoomList((RoomFac.Dto)cboSelectedRoom.SelectedItem);
                this.PopulateRoomList();
            }
        }        

        protected override void AssignDto()
        {
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;

            dto.Id = dto == null ? 0 : dto.Id;

            dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);
            dto.NoOfDays = Convert.ToInt16(txtDays.Text);          
            dto.NoOfRooms = Convert.ToInt16(txtRooms.Text);

            //non-mandatory drop down
            dto.RoomCategory = this.cboCategory.SelectedItem == null ? null : new Table { Id = (this.cboCategory.SelectedItem as RoomCatFac.Dto).Id };
            dto.RoomType = this.cboType.SelectedItem == null ? null : new Table { Id = (this.cboType.SelectedItem as RoomTypFac.Dto).Id };
            dto.ACPreference = this.cboAC.SelectedIndex;

            //non-mandatory textBox
            dto.NoOfMale = String.IsNullOrEmpty(txtMale.Text.Trim()) ? 0 : Convert.ToInt32(txtMale.Text);
            dto.NoOfFemale = String.IsNullOrEmpty(txtFemale.Text.Trim()) ? 0 : Convert.ToInt32(txtFemale.Text);
            dto.NoOfChild = String.IsNullOrEmpty(txtChild.Text.Trim()) ? 0 : Convert.ToInt32(txtChild.Text);
            dto.NoOfInfant = String.IsNullOrEmpty(txtInfant.Text.Trim()) ? 0 : Convert.ToInt32(txtInfant.Text);
            dto.Remark = txtRemarks.Text.Trim();
            
            dto.BookingStatusId = Convert.ToInt64(Status.Open);            
            dto.RoomList = this.cboSelectedRoom.Items.Count == 0 ? null : (List<RoomFac.Dto>)this.cboSelectedRoom.DataSource;        
        }
        
        private Boolean SaveArtifact()
        {          
            //this.dto.ArtifactPath = this.txtArtifactPath.Text;
            //Vanilla.Utility.Facade.Artifact.Dto artifactDto = new Vanilla.Utility.Facade.Artifact.Dto
            //{
            //    Module = this.dto,
            //    Style = Vanilla.Utility.Facade.Artifact.Type.Document,
            //    Version = 1,
            //    CreatedBy = new Table
            //    {
            //        Id = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
            //        Name = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
            //    },
            //    CreatedAt = DateTime.Now,
            //    Category = Vanilla.Utility.Facade.Artifact.Category.Form,
            //    Path = this.dto.ArtifactPath
            //};

            //new Fac.ReservationServer(this.formDto).SaveArtifactForReservation(artifactDto);

            ////-Add artifact to customer node
            //Int16 reservationNodePosition = 0;
            //for (int i = 0; i < this.trvForm.Nodes.Count; i++)
            //{
            //    if (this.trvForm.Nodes[i].Text == "Room Reservation")
            //        break;

            //    reservationNodePosition++;
            //}

            //(this.trvForm.Nodes[reservationNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto).Artifact.Children.Add(artifactDto);
            //artifactDto.Parent = this.trvForm.Nodes[reservationNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto;

            return true;
        }

        protected override Boolean ValidateForm()
        {
            Boolean retVal = true;
            this.errorProvider.Clear();

            if (String.IsNullOrEmpty(this.txtAvailableRoomCount.Text) || Convert.ToInt32(this.txtAvailableRoomCount.Text) <= 0)
            {
                this.errorProvider.SetError(this.txtAvailableRoomCount, "No rooms available for booking.");
                this.txtAvailableRoomCount.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtName.Text))
            {
                this.errorProvider.SetError(this.txtName, "Select a customer for reservation.");
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
            //else if (String.IsNullOrEmpty(this.txtMale.Text))
            //{
            //    this.errorProvider.SetError(this.txtMale, "Please enter persons.");
            //    this.txtMale.Focus();
            //    return false;
            //}
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtMale.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtMale, "Entered '" + this.txtMale.Text + "' is Invalid.");
                this.txtMale.Focus();
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
            //else if (!ValidationRule.IsDecimal(String.IsNullOrEmpty(this.txtAdvance.Text) ? "0" : this.txtAdvance.Text.Trim().Replace(",", "")))
            //{
            //    this.errorProvider.SetError(this.txtAdvance, "Entered '" + this.txtAdvance.Text + "' is Invalid.");
            //    this.txtAdvance.Focus();
            //    return false;
            //}
            else if (ValidationRule.IsDateLessThanToday(this.dtFrom.Value))
            {
                this.errorProvider.SetError(this.dtFrom, "Booking from date cannot be less than today.");
                this.dtFrom.Focus();
                return false;
            }
            else if (this.cboSelectedRoom.Items.Count > Convert.ToInt32(this.txtRooms.Text.Trim()))
            {
                this.errorProvider.SetError(this.cboSelectedRoom, "Selected rooms cannot be greater than the no of rooms.");
                this.cboSelectedRoom.Focus();
                return false;
            }
            else if (Convert.ToInt32(this.txtRooms.Text.Trim()) > Convert.ToInt32(this.txtAvailableRoomCount.Text))
            {
                this.errorProvider.SetError(this.txtRooms, "No of rooms cannot be greater than available rooms.");
                this.cboSelectedRoom.Focus();
                return false;
            }
            //else if (this.cboRoomList.DataSource == null && this.cboSelectedRoom.DataSource == null)
            //{
            //    this.errorProvider.SetError(this.cboRoomList, "No rooms available for booking.");
            //    this.cboRoomList.Focus();
            //    return false;
            //}

            return retVal;
        }

        //private Boolean ValidateRoom(RoomFac.Dto roomDto)
        //{   
        //    Int64 roomCategoryId = 0;
        //    Int64 roomTypeId = 0;
        //    Int32 acPreference = 0;

        //    if (this.cboCategory.SelectedIndex > 0)
        //    {
        //        List<RoomCatFac.Dto> lstCategory = this.cboCategory.DataSource as List<RoomCatFac.Dto>;
        //        roomCategoryId = lstCategory[this.cboCategory.SelectedIndex].Id;                    
        //    }

        //    if (this.cboType.SelectedIndex > 0)
        //    {
        //        List<RoomTypFac.Dto> lstType = this.cboType.DataSource as List<RoomTypFac.Dto>;
        //        roomTypeId = lstType[this.cboType.SelectedIndex].Id;
        //    }

        //    acPreference = this.cboAC.SelectedIndex;

        //    Fac.IReservation reservation = new Fac.ReservationServer(null);
        //    Boolean isValidRoom = reservation.ValidateRoomWithCategoryTypeAndACPreference(roomDto, roomCategoryId, roomTypeId, acPreference);

        //    if (!isValidRoom)
        //        return false;           

        //    if (!this.IsRoomBooked(roomDto))
        //        return false;
            
        //    return true;
        //}

        //private Boolean IsRoomBooked(RoomFac.Dto roomDto)
        //{
        //    if (this.IsNoOfDaysExists())
        //    {
        //        if (this.bookedRooms != null && this.bookedRooms.Count > 0)
        //        {
        //            foreach (RoomFac.Dto room in this.bookedRooms)
        //            {
        //                if (this.IsBookedRoomBelongsToCurrentReservation(room))
        //                    return true;

        //                if (room.Id == roomDto.Id)
        //                    return false;
        //            }
        //        }
        //        return true;
        //    }

        //    return false;
        //}

        private Boolean IsBookedRoomBelongsToCurrentReservation(RoomFac.Dto bookedRoom)
        {
            //if (this.dto == null || this.dto.RoomList == null)
            //    return false;

            //foreach(RoomFac.Dto room in this.dto.RoomList)
            //{
            //    if (bookedRoom.Id == room.Id)
            //        return true;
            //}

            return false;
        }
        
        //private void ValidateBookedRoomsAndPopulate()
        //{
        //    if (this.IsNoOfDaysExists())
        //        this.bookedRooms = this.GetBookedRoomListBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt16(txtDays.Text)));
        //    else
        //        this.bookedRooms = null;
          
        //}

        private Boolean IsNoOfDaysExists()
        {            
            if (String.IsNullOrEmpty(txtDays.Text.Trim()))           
                return false;            
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())))            
                return false;

            return true;
        }

        private List<RoomFac.Dto> GetBookedRoomListBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            return new List<RoomFac.Dto>();
            //Fac.IReservation reservation = new Fac.ReservationServer(null);
            //return reservation.GetBookedRooms(startDate, endDate).Value;

            //(this.facade as Fac.ReservationServer)
        }
        
        private void FilterAndPopulateRoomList()
        {
            Fac.FormDto formDto = (base.formDto as Fac.FormDto) as Fac.FormDto;
            Fac.Dto dto = (base.formDto as Fac.FormDto).Dto as Fac.Dto;

            dto.RoomCategory = this.cboCategory.SelectedItem == null ? null : new Table { Id = (this.cboCategory.SelectedItem as RoomCatFac.Dto).Id };
            dto.RoomType = this.cboType.SelectedItem == null ? null : new Table { Id = (this.cboType.SelectedItem as RoomTypFac.Dto).Id };
            dto.ACPreference = this.cboAC.SelectedIndex;

            (this.facade as Fac.ReservationServer).PopulateRoomWithCriteria();
            this.PopulateRoomList();

            if (formDto.AllRoomList != null && formDto.AllRoomList.Count > 0)
            {
                txtFilteredRoomCount.Text = (this.facade as Fac.ReservationServer).GetTotalNoRooms().ToString();

                if (!String.IsNullOrEmpty(txtFilteredRoomCount.Text.Trim()) && !String.IsNullOrEmpty(formDto.NoOfRoomBooked.ToString()))
                {
                    txtAvailableRoomCount.Text = (Convert.ToInt32(txtFilteredRoomCount.Text) - formDto.NoOfRoomBooked).ToString();
                }
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
            if (formDto.AllRoomList != null && formDto.AllRoomList.Count > 0)
            {
                this.cboRoomList.DataSource = formDto.AllRoomList;
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
        
        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
            Fac.IReservation reservation = new Fac.ReservationServer(null);            
            return reservation.CloneReservaion(source as Fac.Dto);
        }

        public enum Status
        {
            Open = 10001,
            Closed = 10002,
            Canceled = 10003
        }

        private void SetDefault()
        {
            //set default date format
            this.dtFrom.Format = DateTimePickerFormat.Custom;
            this.dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
        }
       
    }

}
