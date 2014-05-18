using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using BinAff.Core;
using BinAff.Utility;

using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;
using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using PresentationLibrary = BinAff.Presentation.Library;
using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;

namespace AutoTourism.Lodge.WinForm
{

    public partial class CheckInForm : FormWin.Document
    {

        private RuleFacade.ConfigurationRuleDto configurationRuleDto;
        private List<LodgeConfigurationFacade.Room.Dto> bookedRooms;

        private Int32 totalRooms = 0;
        private Int32 totalBookings = 0;
        private Int32 availableRooms = 0;

        private TreeView trvForm;

        public CheckInForm()
            : base()
        {
            InitializeComponent();
        }

        public CheckInForm(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();            
        }

        public CheckInForm(LodgeFacade.CheckIn.Dto CheckInDto)
        {
            InitializeComponent();

            //this.dto = CheckInDto;
            //this.formDto = new LodgeFacade.CheckIn.FormDto { dto = this.dto };

            //if (this.dto == null || this.dto.Id == 0) // new checkIn form
            //{
            //    this.btnCheckOut.Enabled = false;
            //    this.btnGenerateInvoice.Enabled = false;
            //}
            //if (this.dto != null && this.dto.StatusId == Convert.ToInt64(CheckInStatus.CheckIn)) //edit in checkIn mode
            //{
            //    this.btnOk.Enabled = false;
            //    this.btnRefresh.Enabled = false;
            //    this.btnGenerateInvoice.Enabled = false;
            //    this.DisableFormControls();
            //}
            //if (this.dto != null && this.dto.StatusId == Convert.ToInt64(CheckInStatus.CheckOut)) //edit in check out mode
            //{
            //    this.btnOk.Enabled = false;
            //    this.btnRefresh.Enabled = false;
            //    this.btnCheckOut.Enabled = false;
            //    //this.btnGenerateInvoice.Enabled = false;
            //    this.DisableFormControls();
            //}
            //this.LoadForm();
            
        }

        protected override void Compose()
        {
            base.formDto = new Facade.CheckIn.FormDto
            {
                ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new Facade.CheckIn.Dto()
            };

            this.facade = new Facade.CheckIn.CheckInServer(this.formDto as Facade.CheckIn.FormDto);
        }

        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
            Facade.CheckIn.Dto dto = source as Facade.CheckIn.Dto;

            LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(null);
            LodgeFacade.CheckIn.Dto checkInDto = new LodgeFacade.CheckIn.Dto
            {
                Date = dto.Date,
                CustomerDisplayName = dto.CustomerDisplayName,
                Reservation = dto.Reservation == null ? null : reservation.CloneReservaion(dto.Reservation)
            };

            if (dto.Reservation != null)
                dto.Reservation.Customer = reservation.CloneCustomer(dto.Reservation.Customer);

            return checkInDto as DocFac.Dto;
        }

        protected override void LoadForm()
        {
            //set default date format
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case

            dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dtFromTime.ShowUpDown = true;

            Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            base.facade.LoadForm();

            EnableDisableFormControls();            


            this.configurationRuleDto = formDto.configurationRuleDto;

            //--populate room category
            this.cboCategory.DataSource = null;
            if (formDto.CategoryList != null && formDto.CategoryList.Count > 0)
            {
                formDto.CategoryList.Insert(0, new LodgeConfigurationFacade.Room.Category.Dto
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
                formDto.TypeList.Insert(0, new LodgeConfigurationFacade.Room.Type.Dto
                {
                    Name = "All"
                });
                this.cboType.DataSource = formDto.TypeList;
                this.cboType.ValueMember = "Id";
                this.cboType.DisplayMember = "Name";
                this.cboType.SelectedIndex = 0;
            }

            List<Table> lstAC = new List<Table>();
            lstAC.Add(new Table { Id = 0, Name = "All" });
            lstAC.Add(new Table { Id = 1, Name = "AC" });
            lstAC.Add(new Table { Id = 2, Name = "Non AC" });
            this.cboAC.DataSource = lstAC;
            this.cboAC.ValueMember = "Id";
            this.cboAC.DisplayMember = "Name";
            this.cboAC.SelectedIndex = 0;            

            this.txtArtifactPath.ReadOnly = true;
            this.txtArtifactPath.Text = base.Artifact.Path;
        }

        protected override void PopulateDataToForm()
        {
            //Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            Facade.CheckIn.Dto dto = this.formDto.Dto as Facade.CheckIn.Dto;

            //populate checkIn form
            if (dto != null && dto.Id > 0)
            {
                CustomerFacade.Dto customerDto = dto.Reservation.Customer;
                dto.CustomerDisplayName = customerDto.Name;

                this.LoadCheckInData();

                //disable buttons to pick/add reservatiol
                btnPickReservation.Enabled = false;
                btnAddReservation.Enabled = false;

                //LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(null);
                //refreshDto = new LodgeFacade.CheckIn.Dto
                //{
                //    Date = this.formDto.dto.Date,
                //    CustomerDisplayName = this.formDto.dto.CustomerDisplayName,
                //    Reservation = reservation.CloneReservaion(this.formDto.dto.Reservation)
                //};
                //this.refreshDto.Reservation.Customer = reservation.CloneCustomer(this.formDto.dto.Reservation.Customer);
            }
        }

        protected override Boolean ValidateForm()
        {
            //Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            Boolean retVal = true;
            errorProvider.Clear();

            if (dto == null || dto.Reservation == null || dto.Reservation.Customer == null)
            {
                errorProvider.SetError(btnPickReservation, "Reservation is available for check in.");
                btnPickReservation.Focus();
                return false;
            }
            else if (ValidationRule.IsDateLessThanToday(dtFrom.Value))
            {
                errorProvider.SetError(dtFrom, "Booking date cannot be less than today.");
                dtFrom.Focus();
                return false;
            }
            else if (!ValidationRule.IsDateEqual(dtFrom.Value, DateTime.Today))
            {
                errorProvider.SetError(dtFrom, "Booking date cannot be greater than today.");
                dtFrom.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtDays.Text.Trim()))
            {
                errorProvider.SetError(txtDays, "Please enter days.");
                txtDays.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())) || Convert.ToInt16(txtDays.Text) == 0)
            {
                errorProvider.SetError(txtDays, "Entered " + txtDays.Text + " is Invalid.");
                txtDays.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtPersons.Text.Trim()))
            {
                errorProvider.SetError(txtPersons, "Please enter persons.");
                txtPersons.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtPersons.Text.Trim())) || Convert.ToInt16(txtPersons.Text) == 0)
            {
                errorProvider.SetError(txtPersons, "Entered " + txtPersons.Text + " is Invalid.");
                txtPersons.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtRooms.Text.Trim()))
            {
                errorProvider.SetError(txtRooms, "Please enter rooms.");
                txtRooms.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtRooms.Text.Trim())) || Convert.ToInt16(txtRooms.Text) == 0)
            {
                errorProvider.SetError(txtRooms, "Entered " + txtRooms.Text + " is Invalid.");
                txtRooms.Focus();
                return false;
            }
            else if (!ValidationRule.IsDecimal(txtAdvance.Text.Trim() == String.Empty ? "0" : txtAdvance.Text.Trim().Replace(",", "")))
            {
                errorProvider.SetError(txtAdvance, "Entered " + txtAdvance.Text + " is Invalid.");
                txtAdvance.Focus();
                return false;
            }
            else if (cmbCheckInRoom.DataSource == null || cmbCheckInRoom.Items.Count == 0)
            {
                errorProvider.SetError(cmbCheckInRoom, "Select rooms for checkin.");
                cmbCheckInRoom.Focus();
                return false;
            }
            else if (cmbCheckInRoom.Items.Count > Convert.ToInt32(txtRooms.Text.Trim()))
            {
                errorProvider.SetError(cmbCheckInRoom, "Selected rooms cannot be greater than the no of rooms.");
                cmbCheckInRoom.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtRooms.Text.Trim()) > this.availableRooms)
            {
                errorProvider.SetError(txtRooms, "No of rooms cannot be greater than available rooms.");
                cmbCheckInRoom.Focus();
                return false;
            }
            return retVal;
        }

        protected override void AssignDto()
        {
            Facade.CheckIn.Dto dto = (base.formDto as Facade.CheckIn.FormDto).Dto as Facade.CheckIn.Dto;
            dto.Id = dto == null ? 0 : dto.Id;

         
            dto.Date = DateTime.Now;

            if (dto.Reservation == null) dto.Reservation = new LodgeFacade.RoomReservation.Dto();
            dto.Reservation.Id = dto.Reservation == null ? 0 : dto.Reservation.Id;

            dto.Reservation.isCheckedIn = true;
            dto.Reservation.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFrom.Value.Hour, dtFrom.Value.Minute, dtFrom.Value.Second);
            dto.Reservation.BookingFrom = DateTime.Now;

            dto.Reservation.NoOfDays = Convert.ToInt16(txtDays.Text);
            dto.Reservation.NoOfPersons = Convert.ToInt16(txtPersons.Text);
            dto.Reservation.NoOfRooms = Convert.ToInt16(txtRooms.Text);
            dto.Reservation.Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtAdvance.Text.Replace(",", ""));
            dto.Reservation.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>)[this.cboCategory.SelectedIndex].Id };
            dto.Reservation.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>)[this.cboType.SelectedIndex].Id };
            dto.Reservation.ACPreference = this.cboAC.SelectedIndex;
            dto.Reservation.RoomList = (List<LodgeConfigurationFacade.Room.Dto>)cmbCheckInRoom.DataSource;
            
        }
                
        private Boolean SaveCheckInData()
        {
            return true;
            //Boolean retVal = this.ValidateCheckIn();

            //if (retVal)
            //{
            //    if (this.formDto.dto == null) this.formDto.dto = new LodgeFacade.CheckIn.Dto();
            //    this.formDto.dto.Id = this.formDto.dto == null ? 0 : this.formDto.dto.Id;
            //    //this.formDto.dto.Date = new DateTime(dtCheckIn.Value.Year, dtCheckIn.Value.Month, dtCheckIn.Value.Day, dtCheckIn.Value.Hour, dtCheckIn.Value.Minute, dtCheckIn.Value.Second);
            //    this.formDto.dto.Date = DateTime.Now;

            //    if (this.formDto.dto.Reservation == null) this.formDto.dto.Reservation = new LodgeFacade.RoomReservation.Dto();
            //    this.formDto.dto.Reservation.Id = this.formDto.dto.Reservation == null ? 0 : this.formDto.dto.Reservation.Id;

            //    this.formDto.dto.Reservation.isCheckedIn = true;
            //    this.formDto.dto.Reservation.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFrom.Value.Hour, dtFrom.Value.Minute, dtFrom.Value.Second);
            //    this.formDto.dto.Reservation.BookingFrom = DateTime.Now;

            //    this.formDto.dto.Reservation.NoOfDays = Convert.ToInt16(txtDays.Text);
            //    this.formDto.dto.Reservation.NoOfPersons = Convert.ToInt16(txtPersons.Text);
            //    this.formDto.dto.Reservation.NoOfRooms = Convert.ToInt16(txtRooms.Text);
            //    this.formDto.dto.Reservation.Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtAdvance.Text.Replace(",", ""));
            //    this.formDto.dto.Reservation.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>)[this.cboCategory.SelectedIndex].Id };
            //    this.formDto.dto.Reservation.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>)[this.cboType.SelectedIndex].Id };
            //    this.formDto.dto.Reservation.ACPreference = this.cboAC.SelectedIndex;
            //    this.formDto.dto.Reservation.RoomList = (List<LodgeConfigurationFacade.Room.Dto>)cmbCheckInRoom.DataSource;

            //    BinAff.Facade.Library.Server facade = new LodgeFacade.CheckIn.CheckInServer(formDto);

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
            //        new PresentationLibrary.MessageBox
            //        {
            //            DialogueType = facade.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
            //            Heading = "Splash",
            //        }.Show(facade.DisplayMessageList);
            //    }
            //}

            //return retVal;
        }

        //private void UpdateRoomReservationNodeInTree(LodgeFacade.RoomReservation.Dto reservationDto)
        //{
        //    //-Add artifact to customer node
        //    Int16 reservationNodePosition = 0;
        //    for (int i = 0; i < this.dto.trvForm.Nodes.Count; i++)
        //    {
        //        if (this.dto.trvForm.Nodes[i].Text == "Room Reservation")
        //            break;

        //        reservationNodePosition++;
        //    }

        //    //Boolean isNodeUpdated = false;
        //    //List<Vanilla.Utility.Facade.Artifact.Dto> artifactList = (this.dto.trvForm.Nodes[reservationNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto).Artifact.Children;
        //    //this.UpdateTreeNode(isNodeUpdated, reservationDto, artifactList);
        //}

        //private void UpdateTreeNode(Boolean isNodeUpdated, LodgeFacade.RoomReservation.Dto reservationDto, List<Vanilla.Utility.Facade.Artifact.Dto> artifactList)
        //{
        //    if (isNodeUpdated) return;

        //    foreach (Vanilla.Utility.Facade.Artifact.Dto dto in artifactList)
        //    {
        //        if (dto.Style == Vanilla.Utility.Facade.Artifact.Type.Document)
        //        {
        //            if (dto.Module.Id == reservationDto.Id)
        //            {
        //                dto.Module = reservationDto;
        //                isNodeUpdated = true;
        //                break;
        //            }
        //        }
        //    }

        //    if (!isNodeUpdated)
        //    {
        //        foreach (Vanilla.Utility.Facade.Artifact.Dto dto in artifactList)
        //        {
        //            if (dto.Style == Vanilla.Utility.Facade.Artifact.Type.Folder && dto.Children != null)
        //            {
        //                this.UpdateTreeNode(isNodeUpdated, reservationDto, dto.Children);
        //                if (isNodeUpdated) break;
        //            }
        //        }
        //    }
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (this.SaveCheckInData())
            //{
            //    this.dto.StatusId = Convert.ToInt64(CheckInStatus.CheckIn);
            //    base.IsModified = true;
            //    this.Close();
            //}

            if (base.Save())
            {
                Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;
                dto.StatusId = Convert.ToInt64(CheckInStatus.CheckIn);
                base.IsModified = true;
                this.Close();
            }
        }

        //private Boolean ValidateCheckIn()
        //{
        //    Boolean retVal = true;
        //    errorProvider.Clear();

        //    if (this.formDto == null || this.formDto.dto == null || this.formDto.dto.Reservation == null || this.formDto.dto.Reservation.Customer == null)
        //    {
        //        errorProvider.SetError(btnPickReservation, "Reservation is available for check in.");
        //        btnPickReservation.Focus();
        //        return false;
        //    }
        //    else if (ValidationRule.IsDateLessThanToday(dtFrom.Value))
        //    {
        //        errorProvider.SetError(dtFrom, "Booking date cannot be less than today.");
        //        dtFrom.Focus();
        //        return false;
        //    }
        //    else if (!ValidationRule.IsDateEqual(dtFrom.Value, DateTime.Today))
        //    {
        //        errorProvider.SetError(dtFrom, "Booking date cannot be greater than today.");
        //        dtFrom.Focus();
        //        return false;
        //    }
        //    else if (String.IsNullOrEmpty(txtDays.Text.Trim()))
        //    {
        //        errorProvider.SetError(txtDays, "Please enter days.");
        //        txtDays.Focus();
        //        return false;
        //    }
        //    else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())) || Convert.ToInt16(txtDays.Text) == 0)
        //    {
        //        errorProvider.SetError(txtDays, "Entered " + txtDays.Text + " is Invalid.");
        //        txtDays.Focus();
        //        return false;
        //    }
        //    else if (String.IsNullOrEmpty(txtPersons.Text.Trim()))
        //    {
        //        errorProvider.SetError(txtPersons, "Please enter persons.");
        //        txtPersons.Focus();
        //        return false;
        //    }
        //    else if (!(new Regex(@"^[0-9]*$").IsMatch(txtPersons.Text.Trim())) || Convert.ToInt16(txtPersons.Text) == 0)
        //    {
        //        errorProvider.SetError(txtPersons, "Entered " + txtPersons.Text + " is Invalid.");
        //        txtPersons.Focus();
        //        return false;
        //    }
        //    else if (String.IsNullOrEmpty(txtRooms.Text.Trim()))
        //    {
        //        errorProvider.SetError(txtRooms, "Please enter rooms.");
        //        txtRooms.Focus();
        //        return false;
        //    }
        //    else if (!(new Regex(@"^[0-9]*$").IsMatch(txtRooms.Text.Trim())) || Convert.ToInt16(txtRooms.Text) == 0)
        //    {
        //        errorProvider.SetError(txtRooms, "Entered " + txtRooms.Text + " is Invalid.");
        //        txtRooms.Focus();
        //        return false;
        //    }
        //    else if (!ValidationRule.IsDecimal(txtAdvance.Text.Trim() == String.Empty ? "0" : txtAdvance.Text.Trim().Replace(",", "")))
        //    {
        //        errorProvider.SetError(txtAdvance, "Entered " + txtAdvance.Text + " is Invalid.");
        //        txtAdvance.Focus();
        //        return false;
        //    }
        //    else if (cmbCheckInRoom.DataSource == null || cmbCheckInRoom.Items.Count == 0)
        //    {
        //        errorProvider.SetError(cmbCheckInRoom, "Select rooms for checkin.");
        //        cmbCheckInRoom.Focus();
        //        return false;
        //    }
        //    else if (cmbCheckInRoom.Items.Count > Convert.ToInt32(txtRooms.Text.Trim()))
        //    {
        //        errorProvider.SetError(cmbCheckInRoom, "Selected rooms cannot be greater than the no of rooms.");
        //        cmbCheckInRoom.Focus();
        //        return false;
        //    }
        //    else if (Convert.ToInt32(txtRooms.Text.Trim()) > this.availableRooms)
        //    {
        //        errorProvider.SetError(txtRooms, "No of rooms cannot be greater than available rooms.");
        //        cmbCheckInRoom.Focus();
        //        return false;
        //    }
        //    return retVal;
        //}
        
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            LodgeConfigurationFacade.Room.Dto roomDto = null;
            if (cboRoomList.SelectedIndex != -1)
            {
                roomDto = (LodgeConfigurationFacade.Room.Dto)cboRoomList.SelectedItem;
                AddToList(roomDto, cmbCheckInRoom);
                RemoveFromList(roomDto, cboRoomList);
            }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            LodgeConfigurationFacade.Room.Dto roomDto = null;
            if (cmbCheckInRoom.SelectedIndex != -1)
            {
                roomDto = (LodgeConfigurationFacade.Room.Dto)cmbCheckInRoom.SelectedItem;
                AddToList(roomDto, cboRoomList);
                RemoveFromList(roomDto, cmbCheckInRoom);
            }
        }

        private void AddToList(LodgeConfigurationFacade.Room.Dto roomDto, System.Windows.Forms.ListControl cboRoom)
        {
            Boolean Include = false;
            List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (((System.Windows.Forms.ComboBox)cboRoom).Items.Count == 0)
                RoomList.Add(roomDto);
            else
            {
                foreach (LodgeConfigurationFacade.Room.Dto dto in (List<LodgeConfigurationFacade.Room.Dto>)cboRoom.DataSource)
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

        private void RemoveFromList(LodgeConfigurationFacade.Room.Dto roomDto, System.Windows.Forms.ListControl cboRoom)
        {
            List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();
            foreach (LodgeConfigurationFacade.Room.Dto dto in (List<LodgeConfigurationFacade.Room.Dto>)cboRoom.DataSource)
                if (dto.Id != roomDto.Id) RoomList.Add(dto);

            cboRoom.DataSource = null;
            cboRoom.DataSource = RoomList;
            cboRoom.DisplayMember = "Number";
            cboRoom.ValueMember = "Id";
            cboRoom.SelectedIndex = -1;
        }

        private void btnPickReservation_Click_1(object sender, EventArgs e)
        {
            Form form = new RoomReservationRegister();
            form.ShowDialog(this);

            if (form.Tag != null)
                this.PopulateReservationData(form);

        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            //Form form = new RoomReservationForm(this.dto.trvForm);
            //form.ShowDialog(this);

            //if (form.Tag != null)
            //    this.PopulateReservationData(form);
        }

        private void LoadCheckInData()
        {
            //Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            //populate reservation data
            if (!ValidationRule.IsMinimumDate(dto.Reservation.BookingFrom))
            {
                dtFrom.Value = dto.Reservation.BookingFrom;
                dtFromTime.Value = dto.Reservation.BookingFrom;
            }

            txtDays.Text = dto.Reservation.NoOfDays.ToString();
            txtPersons.Text = dto.Reservation.NoOfPersons.ToString();
            txtRooms.Text = dto.Reservation.NoOfRooms.ToString();
            txtAdvance.Text = dto.Reservation.Advance == 0 ? String.Empty : dto.Reservation.Advance.ToString();

            if (dto.Reservation.RoomCategory != null && dto.Reservation.RoomCategory.Id > 0)
            {
                for (int i = 0; i < cboCategory.Items.Count; i++)
                {
                    if (dto.Reservation.RoomCategory.Id == ((LodgeConfigurationFacade.Room.Category.Dto)cboCategory.Items[i]).Id)
                    {
                        cboCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
            else cboCategory.SelectedIndex = 0;

            if (dto.Reservation.RoomType != null && dto.Reservation.RoomType.Id > 0)
            {
                for (int i = 0; i < cboType.Items.Count; i++)
                {
                    if (dto.Reservation.RoomType.Id == ((LodgeConfigurationFacade.Room.Type.Dto)cboType.Items[i]).Id)
                    {
                        cboType.SelectedIndex = i;
                        break;
                    }
                }
            }
            else cboType.SelectedIndex = 0;

            cboAC.SelectedIndex = dto.Reservation.ACPreference;

            //populate customer data
            txtName.Text = dto.CustomerDisplayName;
            lstContact.DataSource = dto.Reservation.Customer.ContactNumberList;
            lstContact.DisplayMember = "Name";
            lstContact.ValueMember = "Id";
            lstContact.SelectedIndex = -1;
            txtAdds.Text = dto.Reservation.Customer.Address;
            txtEmail.Text = dto.Reservation.Customer.Email;
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateFilteredRoomList();
            this.LoadRoomReservationStatusLevels();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateFilteredRoomList();
            this.LoadRoomReservationStatusLevels();
        }

        private void cboAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateFilteredRoomList();
            this.LoadRoomReservationStatusLevels();
        }

        private void PopulateFilteredRoomList()
        {
            Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            this.cboRoomList.DataSource = null;
            List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (formDto.roomList != null && formDto.roomList.Count > 0)
            {
                foreach (LodgeConfigurationFacade.Room.Dto roomDto in formDto.roomList)
                {
                    if (this.ValidateRoom(roomDto))
                        RoomList.Add(roomDto);
                }
            }


            List<LodgeConfigurationFacade.Room.Dto> SelectedRoomList = new List<LodgeConfigurationFacade.Room.Dto>();
            List<LodgeConfigurationFacade.Room.Dto> AvailableRoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (RoomList != null && RoomList.Count > 0)
            {
                if (dto == null || dto.Reservation == null || dto.Reservation.RoomList == null || dto.Reservation.RoomList.Count == 0)
                {
                    SelectedRoomList = null;
                    AvailableRoomList = RoomList;
                }
                else
                {
                    Boolean isSelected = false;
                    foreach (LodgeConfigurationFacade.Room.Dto roomDto in RoomList)
                    {
                        isSelected = false;
                        foreach (LodgeConfigurationFacade.Room.Dto validRoomDto in dto.Reservation.RoomList)
                        {
                            if (roomDto.Id == validRoomDto.Id)
                            {
                                isSelected = true;
                                break;
                            }
                        }

                        if (isSelected)
                            SelectedRoomList.Add(roomDto);
                        else
                            AvailableRoomList.Add(roomDto);
                    }
                }
            }
            else
            {
                SelectedRoomList = null;
                AvailableRoomList = null;
            }

            this.cmbCheckInRoom.DataSource = SelectedRoomList;
            if (SelectedRoomList != null && SelectedRoomList.Count > 0)
            {
                this.cmbCheckInRoom.DisplayMember = "Number";
                this.cmbCheckInRoom.ValueMember = "Id";
                this.cmbCheckInRoom.SelectedIndex = -1;
            }

            this.cboRoomList.DataSource = AvailableRoomList;
            if (AvailableRoomList != null && AvailableRoomList.Count > 0)
            {
                this.cboRoomList.DisplayMember = "Number";
                this.cboRoomList.ValueMember = "Id";
                this.cboRoomList.SelectedIndex = -1;
            }
        }

        private Boolean ValidateRoom(LodgeConfigurationFacade.Room.Dto roomDto)
        {
            Int64 roomCategoryId = 0;
            Int64 roomTypeId = 0;
            Int32 acPreference = 0;

            if (this.cboCategory.SelectedIndex > 0)
            {
                List<LodgeConfigurationFacade.Room.Category.Dto> lstCategory = this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>;
                roomCategoryId = lstCategory[this.cboCategory.SelectedIndex].Id;
            }

            if (this.cboType.SelectedIndex > 0)
            {
                List<LodgeConfigurationFacade.Room.Type.Dto> lstType = this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>;
                roomTypeId = lstType[this.cboType.SelectedIndex].Id;
            }

            acPreference = this.cboAC.SelectedIndex;

            LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(null);
            Boolean isValidRoom = reservation.ValidateRoomWithCategoryTypeAndACPreference(roomDto, roomCategoryId, roomTypeId, acPreference);

            if (!isValidRoom)
                return false;

            //if (!this.isRoomBooked(roomDto))
            //    return false;

            return true;

        }

        private Boolean isRoomBooked(LodgeConfigurationFacade.Room.Dto roomDto)
        {
            if (isNoOfDaysExists())
            {
                if (this.bookedRooms != null && this.bookedRooms.Count > 0)
                {
                    foreach (LodgeConfigurationFacade.Room.Dto room in this.bookedRooms)
                    {
                        if (isBookedRoomBelongsToCurrentReservation(room))
                            return true;

                        if (room.Id == roomDto.Id)
                            return false;
                    }
                }
                //return true;
            }

            return false;
        }

        private Boolean isBookedRoomBelongsToCurrentReservation(LodgeConfigurationFacade.Room.Dto bookedRoom)
        {
            //if (this.formDto.dto == null || this.formDto.dto.Reservation == null || this.formDto.dto.Reservation.RoomList == null)
            //    return false;

            //foreach (LodgeConfigurationFacade.Room.Dto room in this.formDto.dto.Reservation.RoomList)
            //{
            //    if (bookedRoom.Id == room.Id)
            //        return true;
            //}

            return false;
        }

        private void PopulateReservationData(Form form)
        {
            //Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            LodgeFacade.RoomReservationRegister.Dto roomReservationRegisterDto = form.Tag as LodgeFacade.RoomReservationRegister.Dto;
            dto.CustomerDisplayName = roomReservationRegisterDto.Name;
            dto.Date = roomReservationRegisterDto.BookingFrom;
            dto.Reservation = new LodgeFacade.RoomReservation.Dto
            {
                Id = roomReservationRegisterDto.Id,
                NoOfDays = roomReservationRegisterDto.NoOfDays,
                NoOfPersons = roomReservationRegisterDto.NoOfPersons,
                NoOfRooms = roomReservationRegisterDto.NoOfRooms,
                Advance = roomReservationRegisterDto.Advance,
                RoomCategory = roomReservationRegisterDto.RoomCategory,
                RoomType = roomReservationRegisterDto.RoomType,
                ACPreference = roomReservationRegisterDto.ACPreference,
                RoomList = roomReservationRegisterDto.RoomList,
                BookingFrom = roomReservationRegisterDto.BookingFrom,
                Customer = roomReservationRegisterDto.Customer
            };

            this.LoadCheckInData();
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            this.ValidateBookedRoomsAndPopulate();
            this.LoadRoomReservationStatusLevels();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            this.ValidateBookedRoomsAndPopulate();
            this.LoadRoomReservationStatusLevels();
        }

        private void ValidateBookedRoomsAndPopulate()
        {
            if (isNoOfDaysExists())
                this.bookedRooms = this.GetBookedRoomListBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt16(txtDays.Text)));
            else
                this.bookedRooms = null;

            this.PopulateFilteredRoomList();
        }

        private Boolean isNoOfDaysExists()
        {
            if (String.IsNullOrEmpty(txtDays.Text.Trim()))
                return false;
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())))
                return false;

            return true;
        }

        private List<LodgeConfigurationFacade.Room.Dto> GetBookedRoomListBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(null);
            return reservation.GetBookedRooms(startDate, endDate).Value;
        }

        private void LoadRoomReservationStatusLevels()
        {
            Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            Int64 roomCategoryId = 0;
            Int64 roomTypeId = 0;
            Int32 acPreference = 0;

            if (this.cboCategory.SelectedIndex > 0)
            {
                List<LodgeConfigurationFacade.Room.Category.Dto> lstCategory = this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>;
                roomCategoryId = lstCategory[this.cboCategory.SelectedIndex].Id;
            }

            if (this.cboType.SelectedIndex > 0)
            {
                List<LodgeConfigurationFacade.Room.Type.Dto> lstType = this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>;
                roomTypeId = lstType[this.cboType.SelectedIndex].Id;
            }

            acPreference = this.cboAC.SelectedIndex;

            int TotalRoomsWithMatchingCategoryTypeAndACPreference = 0;
            int TotalRoomsBookedWithMatchingCategoryTypeAndACPreference = 0;
            int AvailableRoomsCount = 0;

            LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(null);
            List<LodgeConfigurationFacade.Room.Dto> filteredRoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (formDto.roomList != null && formDto.roomList.Count > 0)
            {
                filteredRoomList = reservation.GetFilteredRoomsWithCategoryTypeAndACPreference(formDto.roomList, 0, 0, 0);
                this.totalRooms = filteredRoomList.Count;
                //lblTotalRooms.Text = "Total Rooms : = " + filteredRoomList.Count.ToString();
                txtTotalRoom.Text = filteredRoomList.Count.ToString();

                filteredRoomList = reservation.GetFilteredRoomsWithCategoryTypeAndACPreference(formDto.roomList, roomCategoryId, roomTypeId, acPreference);
                if (filteredRoomList != null)
                    TotalRoomsWithMatchingCategoryTypeAndACPreference = filteredRoomList.Count;
            }
            //lblTotalRoomCount.Text = "Total no of rooms for the selected category, type and AC preference = " + TotalRoomsWithMatchingCategoryTypeAndACPreference.ToString();
            txtTotalRoomWithFilter.Text = TotalRoomsWithMatchingCategoryTypeAndACPreference.ToString();

            if (isNoOfDaysExists())
            {
                Int64 reservationId = (dto == null || dto.Reservation == null) ? 0 : dto.Reservation.Id;
                this.totalBookings = reservation.GetNoOfRoomsBookedBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)), reservationId);
                //lblTotalBooking.Text = "Total Bookings between selected dates : = " + this.totalBookings.ToString();
                txtTotalBooked.Text = this.totalBookings.ToString();

                //reservation.GetNoOfRoomsBookedBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)), reservationId, 0, 0, 0).ToString();

                TotalRoomsBookedWithMatchingCategoryTypeAndACPreference = reservation.GetNoOfRoomsBookedBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)), reservationId, roomCategoryId, roomTypeId, acPreference);
                //lblTotalBookedRoomCount.Text = "Total no of rooms booked for the selected category, type and AC preference from " +
                //    dtFrom.Value.ToShortDateString() + " and " + dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)).ToShortDateString() + " = " +
                //    TotalRoomsBookedWithMatchingCategoryTypeAndACPreference.ToString();

                AvailableRoomsCount = TotalRoomsWithMatchingCategoryTypeAndACPreference - TotalRoomsBookedWithMatchingCategoryTypeAndACPreference;
                Int32 totalAvailableRooms = this.totalRooms - this.totalBookings;
                this.availableRooms = (AvailableRoomsCount > totalAvailableRooms) ? totalAvailableRooms : AvailableRoomsCount;

                //lblAvailableRooms.Text = "No of Rooms available for booking = " + this.availableRooms.ToString();
                txtAvailableRooms.Text = this.availableRooms.ToString();

                if (this.availableRooms == 0)
                    this.cboRoomList.DataSource = null;

            }
            else
            {
                txtAvailableRooms.Text = String.Empty;
                //lblTotalBookedRoomCount.Text = String.Empty;
                //lblAvailableRooms.Text = String.Empty;
                this.availableRooms = 0;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //errorProvider.Clear();

            //if (this.formDto.dto != null && this.formDto.dto.Id > 0)
            //    this.ResetLoad();
            //else
            //    this.Clear();

            //this.PopulateFilteredRoomList();
        }

        private void ResetLoad()
        {
            //LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(null);
            //this.formDto.dto.Date = this.refreshDto.Date;
            //this.formDto.dto.CustomerDisplayName = this.refreshDto.CustomerDisplayName;
            //this.formDto.dto.Reservation = reservation.CloneReservaion(this.refreshDto.Reservation);
            //this.formDto.dto.Reservation.Customer = reservation.CloneCustomer(this.refreshDto.Reservation.Customer);

            //this.LoadCheckInData();
        }

        private void Clear()
        {
            txtTotalRoom.Text = String.Empty;
            txtTotalBooked.Text = String.Empty;
            txtTotalRoomWithFilter.Text = String.Empty;
            txtAvailableRooms.Text = String.Empty;

            dtFrom.Value = DateTime.Now;
            dtFromTime.Value = DateTime.Now;

            txtDays.Text = String.Empty;
            txtPersons.Text = String.Empty;
            txtRooms.Text = String.Empty;
            txtAdvance.Text = String.Empty;
            cmbCheckInRoom.DataSource = null;

            this.cboCategory.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
            this.cboAC.SelectedIndex = 0;

            txtName.Text = String.Empty;
            lstContact.DataSource = null;
            txtAdds.Text = String.Empty;
            txtEmail.Text = String.Empty;

            //this.formDto.dto = new LodgeFacade.CheckIn.Dto();
        }
        
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Facade.CheckIn.FormDto formDto = base.formDto as Facade.CheckIn.FormDto;
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;

            Int32 noOfDays = new Calender().DaysBetweenTwoDays(dto.Date, DateTime.Today);

            if (noOfDays != dto.Reservation.NoOfDays)
            {
                if (noOfDays == 0)
                    dto.Reservation.NoOfDays = 1;
                else
                    dto.Reservation.NoOfDays = noOfDays;

                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Alert,
                    Heading = "Splash"
                }.Show("CheckOut date is not matching with reservation end date. Reservation end date will be changed with checkout.");
            }

            dto.Reservation.BookingStatusId = Convert.ToInt64(CheckInStatus.CheckOut);
            LodgeFacade.CheckIn.ICheckIn checkIn = new LodgeFacade.CheckIn.CheckInServer(formDto);
            checkIn.CheckOut();

            dto.StatusId = Convert.ToInt64(CheckInStatus.CheckOut);
            //base.IsModified = true;
            this.Close();
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            //if (this.dto.InvoiceNumber == null || this.dto.InvoiceNumber == String.Empty)
            //{
            //    Vanilla.Utility.Facade.Artifact.Dto artifactDto = new Vanilla.Utility.Facade.Artifact.Dto();
            //    ReturnObject<Boolean> ret = this.GenerateInvoice(artifactDto);
            //    if (!ret.Value)
            //    {
            //        new PresentationLibrary.MessageBox
            //        {
            //            DialogueType = PresentationLibrary.MessageBox.Type.Error,
            //            Heading = "Splash",
            //        }.Show(ret.MessageList);
            //        return;
            //    }

            //    if (this.dto.InvoiceNumber != null && this.dto.InvoiceNumber != String.Empty)
            //        this.AddInvoiceNodeToTree(artifactDto);
            //}

            //if (this.dto.InvoiceNumber != null && this.dto.InvoiceNumber != String.Empty)
            //    this.DisplayInvoice();

            //this.Close();
        }

        private ReturnObject<Boolean> GenerateInvoice(Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool> { Value = true };

            //Facade.Taxation.ITaxation taxation = new Facade.Taxation.TaxationServer();
            //List<Facade.Taxation.Dto> taxationList = taxation.ReadLodgeTaxation();

            //Vanilla.Invoice.Facade.Dto invoiceDto = new Vanilla.Invoice.Facade.Dto();            
            //invoiceDto.advance = this.dto.Reservation.Advance;
            //invoiceDto.buyer = this.dto.Reservation.Customer == null ? null : new Vanilla.Invoice.Facade.Buyer.Dto 
            //{
            //    Name = this.dto.Reservation.Customer.Name,
            //    Address = this.dto.Reservation.Customer.Address,
            //    Email = this.dto.Reservation.Customer.Email,
            //    ContactNumber = this.dto.Reservation.Customer.ContactNumberList == null ? null : this.dto.Reservation.Customer.ContactNumberList[0].Name
            //};
            //this.PopulateSellerInfo(invoiceDto);
            //List<LodgeConfigurationFacade.Room.Dto> roomList = this.dto.Reservation.RoomList;
            //this.SetRoomDetail(roomList);
            //invoiceDto.productList = this.GroupRoomList(roomList);
            //this.AttachTariff(invoiceDto.productList);
            //invoiceDto.taxationList = this.ConvertToInvoiceTaxationDto(taxationList);                    
           
            //Form form = new Vanilla.Invoice.WinForm.Payment(invoiceDto, this.dto.trvForm);
            //form.ShowDialog(this);

            //if (invoiceDto.paymentList != null && invoiceDto.paymentList.Count > 0)
            //{
            //    Vanilla.Invoice.Facade.FormDto invoiceFormDto = form.Tag as Vanilla.Invoice.Facade.FormDto;
            //    LodgeFacade.CheckIn.ICheckIn checkIn = new LodgeFacade.CheckIn.CheckInServer(this.formDto);

            //    Table currentUser = new Table
            //    {
            //        Id = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
            //        Name = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
            //    };

            //    ret = checkIn.PaymentInsert(invoiceFormDto, currentUser, artifactDto);

            //    if (ret.Value)
            //        this.dto.InvoiceNumber = invoiceFormDto.dto.invoiceNumber;
            //}

            return ret;
        }

        private List<Vanilla.Invoice.Facade.Taxation.Dto> ConvertToInvoiceTaxationDto(List<Facade.Taxation.Dto> taxationList)
        {
            List<Vanilla.Invoice.Facade.Taxation.Dto> invoiceTaxationDtoList = new List<Vanilla.Invoice.Facade.Taxation.Dto>();
            if (taxationList != null && taxationList.Count > 0)
            {
                foreach (Facade.Taxation.Dto dto in taxationList)
                {
                    invoiceTaxationDtoList.Add(new Vanilla.Invoice.Facade.Taxation.Dto
                    {
                        Id = dto.Id,
                        Name = dto.Name,
                        Amount = dto.Amount,
                        isPercentage = dto.isPercentage
                    });
                }
            }

            return invoiceTaxationDtoList;
        }

        private List<Vanilla.Invoice.Facade.LineItem.Dto> GroupRoomList(List<LodgeConfigurationFacade.Room.Dto> roomList)
        {
            List<Vanilla.Invoice.Facade.LineItem.Dto> productList = new List<Vanilla.Invoice.Facade.LineItem.Dto>();
            //Boolean blnAdd = false;

            //if (roomList != null && roomList.Count > 0)
            //{
            //    foreach (LodgeConfigurationFacade.Room.Dto dtoRoom in roomList)
            //    {
            //        Vanilla.Invoice.Facade.LineItem.Dto productDto = new Vanilla.Invoice.Facade.LineItem.Dto()
            //        {
            //            Id = dtoRoom.Id,
            //            startDate = this.dto.Reservation.BookingFrom,
            //            roomCategoryId = dtoRoom.Category == null ? 0 : dtoRoom.Category.Id,
            //            roomTypeId = dtoRoom.Type == null ? 0 : dtoRoom.Type.Id,
            //            roomIsAC = dtoRoom.IsAirconditioned,                        
            //            description = this.GetRoomDescription(dtoRoom.Id),
            //            count = 1, //count is basically rooms of same type [i.e. same typeid, categoryId, and Ac] 
            //            endDate = this.dto.Reservation.BookingFrom.AddDays(this.dto.Reservation.NoOfDays)
            //        };

            //        if (productList.Count == 0)
            //        {
            //            productList.Add(productDto);
            //        }
            //        else
            //        {
            //            blnAdd = true;
            //            foreach (Vanilla.Invoice.Facade.LineItem.Dto roomDto in productList)
            //            {
            //                if (productDto.roomCategoryId == roomDto.roomCategoryId && productDto.roomTypeId == roomDto.roomTypeId && productDto.roomIsAC == roomDto.roomIsAC)
            //                {
            //                    roomDto.count++;
            //                    blnAdd = false;
            //                    break;
            //                }
            //            }
            //            if (blnAdd)
            //            {
            //                productList.Add(productDto);
            //            }
            //        }
            //    }
            //}

            return productList;
        }

        private void AttachTariff(List<Vanilla.Invoice.Facade.LineItem.Dto> roomList)
        { 
            //hit Lodge Room Tariff component
            LodgeConfigurationFacade.Tariff.ITariff tariff = new LodgeConfigurationFacade.Tariff.TariffServer(null);
            List<LodgeConfigurationFacade.Tariff.Dto> tariffList = tariff.ReadAllCurrentTariff().Value;         

            if (tariffList != null && tariffList.Count > 0)
            {
                foreach (Vanilla.Invoice.Facade.LineItem.Dto roomDto in roomList)
                {
                    foreach (LodgeConfigurationFacade.Tariff.Dto tariffDto in tariffList)
                    {
                        if (roomDto.roomCategoryId == tariffDto.Category.Id && roomDto.roomTypeId == tariffDto.Type.Id && roomDto.roomIsAC == tariffDto.IsAC)
                        {
                            roomDto.unitRate = tariffDto.Rate;
                            roomDto.total = roomDto.unitRate * roomDto.count;
                            break;
                        }
                    }
                }
            }
        }

        private void PopulateSellerInfo(Vanilla.Invoice.Facade.Dto invoiceDto)
        {            
            //populate seller info
            LodgeFacade.FormDto formDto = new LodgeFacade.FormDto();
            LodgeFacade.Server facade = new LodgeFacade.Server(formDto);
            facade.LoadForm();

            invoiceDto.seller = formDto.Lodge == null ? null : new Vanilla.Invoice.Facade.Seller.Dto 
            {
                Id = formDto.Lodge.Id,
                Name = formDto.Lodge.Name,
                Address = formDto.Lodge.Address,
                Liscence = formDto.Lodge.LicenceNumber,
                Email = formDto.Lodge.EmailList == null ? null : formDto.Lodge.EmailList[0].Name,
                ContactNumber = formDto.Lodge.ContactNumberList == null ? null : formDto.Lodge.ContactNumberList[0].Name
            };
            
        }

        private void SetRoomDetail(List<LodgeConfigurationFacade.Room.Dto> roomList)
        {
            //foreach (LodgeConfigurationFacade.Room.Dto dto in roomList)
            //{
            //    foreach (LodgeConfigurationFacade.Room.Dto roomDto in this.formDto.roomList)
            //    {
            //        if (dto.Id == roomDto.Id)
            //        {
            //            dto.Category = new LodgeConfigurationFacade.Room.Category.Dto { Id = roomDto.Category.Id };
            //            dto.Type = new LodgeConfigurationFacade.Room.Type.Dto { Id = roomDto.Type.Id };
            //            dto.IsAirconditioned = roomDto.IsAirconditioned;
            //            break;
            //        }
            //    }
            //}
        }

        private void DisplayInvoice()
        {
            //String invoiceNumber = this.dto.InvoiceNumber;
            //Facade.CheckIn.ICheckIn checkInServer = new Facade.CheckIn.CheckInServer(null);
            //Vanilla.Invoice.Facade.Dto invoiceDto = checkInServer.ReadInvoice(invoiceNumber);

            //PresentationLibrary.Form form = new Vanilla.Invoice.WinForm.Invoice(invoiceDto);
            //form.ShowDialog(this);
        }

        private String GetRoomDescription(Int64 roomId)
        {
            String roomDescription = String.Empty;
            //if (this.formDto.roomList != null && this.formDto.roomList.Count > 0)
            //{
            //    foreach (LodgeConfigurationFacade.Room.Dto dto in this.formDto.roomList)
            //    {
            //        if (dto.Id == roomId)
            //        {
            //            roomDescription = dto.Category.Name +", "+ dto.Type.Name +", "+ (dto.IsAirconditioned ? "AC" : "Non AC");
            //            break;
            //        }
            //    }
            //}

            return roomDescription;
        }

        private void AddInvoiceNodeToTree(Vanilla.Utility.Facade.Artifact.Dto artifactDto)
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

        private void EnableDisableFormControls()
        {            
            //Facade.CheckIn.Dto dto = (base.formDto as Facade.CheckIn.FormDto).dto;
            Facade.CheckIn.Dto dto = base.formDto.Dto as Facade.CheckIn.Dto;
            if (dto == null || dto.Id == 0) // new checkIn form
            {
                this.btnCheckOut.Enabled = false;
                this.btnGenerateInvoice.Enabled = false;
            }
            if (dto != null && dto.StatusId == Convert.ToInt64(CheckInStatus.CheckIn)) //edit in checkIn mode
            {
                this.btnOk.Enabled = false;
                this.btnRefresh.Enabled = false;
                this.btnGenerateInvoice.Enabled = false;
                this.DisableFormControls();
            }
            if (dto != null && dto.StatusId == Convert.ToInt64(CheckInStatus.CheckOut)) //edit in check out mode
            {
                this.btnOk.Enabled = false;
                this.btnRefresh.Enabled = false;
                this.btnCheckOut.Enabled = false;
                //this.btnGenerateInvoice.Enabled = false;
                this.DisableFormControls();
            }
        }

        private void DisableFormControls()
        {
            dtFrom.Enabled = false;
            dtFromTime.Enabled = false;
            txtDays.Enabled = false;
            txtPersons.Enabled = false;
            txtRooms.Enabled = false;
            txtAdvance.Enabled = false;
            cboCategory.Enabled = false;
            cboType.Enabled = false;
            cboAC.Enabled = false;
            cboRoomList.Enabled = false;
            cmbCheckInRoom.Enabled = false;
            btnAddRoom.Enabled = false;
            btnRemoveRoom.Enabled = false;
        }

        public enum CheckInStatus
        {
            CheckIn = 10001,
            CheckOut = 10002
        }

    }

}
