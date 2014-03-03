﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;

using LodgeFacade = AutoTourism.Lodge.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using CustomerFacade = AutoTourism.Customer.Facade;
using PresentationLibrary = BinAff.Presentation.Library;

using AutoTourism.Customer.WinForm;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationForm : PresentationLibrary.Form
    {      

        private LodgeFacade.RoomReservation.Dto dto;
        private LodgeFacade.RoomReservation.FormDto formDto;
        private RuleFacade.ConfigurationRuleDto configurationRuleDto;
        private Boolean isLoadedFromCheckInForm = false;
        private System.Windows.Forms.TreeView trvForm;
        private LodgeFacade.RoomReservation.Dto refreshDto;
        private List<LodgeConfigurationFacade.Room.Dto> bookedRooms;

        private Int32 totalRooms = 0;
        private Int32 totalBookings = 0;
        private Int32 availableRooms = 0;

        public RoomReservationForm(System.Windows.Forms.TreeView trvForm)
        {
            InitializeComponent();
            this.isLoadedFromCheckInForm = true;
            this.trvForm = trvForm;
        }

        public RoomReservationForm(LodgeFacade.RoomReservation.Dto dto)
        {
            InitializeComponent();
            this.dto = dto;
            this.trvForm = this.dto.trvForm;

            if (this.dto.Id > 0)
            {
                this.refreshDto = new LodgeFacade.RoomReservation.Dto
                {                    
                    BookingFrom = this.dto.BookingFrom,
                    NoOfDays = this.dto.NoOfDays,
                    NoOfPersons = this.dto.NoOfPersons,
                    NoOfRooms = this.dto.NoOfRooms,
                    Advance = this.dto.Advance,
                    BookingStatusId = this.dto.BookingStatusId,
                    RoomCategory = this.dto.RoomCategory == null ? null : new Table
                    {
                        Id = this.dto.RoomCategory.Id,
                        Name = this.dto.RoomCategory.Name
                    },
                    RoomType = this.dto.RoomType == null ? null : new Table 
                    { 
                        Id = this.dto.RoomType.Id,
                        Name = this.dto.RoomType.Name
                    },
                    ACPreference = this.dto.ACPreference,
                    RoomList = this.dto.RoomList == null ? null : this.CloneRoomList(this.dto.RoomList)
                };
            }
        }

        private void RoomBookingForm_Load(object sender, System.EventArgs e)
        {          
            //set default date format
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case

            dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dtFromTime.ShowUpDown = true;

            this.formDto = new LodgeFacade.RoomReservation.FormDto() 
            { 
                Dto = this.dto,
                ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
            };

            //if loaded form checkin form , then populate the modules
            if(this.isLoadedFromCheckInForm)
                new Vanilla.Utility.Facade.Module.Server(this.formDto.ModuleFormDto).LoadForm();

            LoadForm();

            //dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //if (this.ruleDto == null || this.ruleDto.ConfigurationRule == null || this.ruleDto.ConfigurationRule.DateFormat == String.Empty)
            //    dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case
            //else
            //    dtFrom.CustomFormat = this.ruleDto.ConfigurationRule.DateFormat;

            //dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            //dtFromTime.ShowUpDown = true;

            //if (this.dto != null) LoadForm();
        }  

        private void btnPickCustomer_Click(object sender, System.EventArgs e)
        {
            Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerRegister, AutoTourism.Customer.WinForm", true);
            Form form = (Form)Activator.CreateInstance(type);
            form.ShowDialog(this);

            if (form.Tag != null)
                this.PopulateCustomerData(form);
            
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm", true);
            Form form = (Form)Activator.CreateInstance(type,this.trvForm);
            form.ShowDialog(this);

            if (form.Tag != null)
                this.PopulateCustomerData(form);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            LodgeConfigurationFacade.Room.Dto roomDto = null;
            if (cboRoomList.SelectedIndex != -1)
            {
                roomDto = (LodgeConfigurationFacade.Room.Dto)cboRoomList.SelectedItem;
                AddToList(roomDto, cboSelectedRoom);
                RemoveFromList(roomDto, cboRoomList);
            }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            LodgeConfigurationFacade.Room.Dto roomDto = null;
            if (cboSelectedRoom.SelectedIndex != -1)
            {
                roomDto = (LodgeConfigurationFacade.Room.Dto)cboSelectedRoom.SelectedItem;
                AddToList(roomDto, cboRoomList);
                RemoveFromList(roomDto, cboSelectedRoom);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.SaveReservationData())
            {
                if (this.isLoadedFromCheckInForm)
                    this.SaveArtifact();

                base.IsModified = true;
                this.Close();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (this.formDto.Dto != null && this.formDto.Dto.Id > 0)
                this.ResetLoad();
            else
                this.Clear();

            this.PopulateFilteredRoomList();
        }

        private void btnCancelOpen_Click(object sender, EventArgs e)
        {
            Boolean isOpenCancel = true;

            if (this.formDto != null && this.formDto.Dto != null)
            {
                Int64 bookingId = btnCancelOpen.Text == "Cancel" ? Convert.ToInt64(LodgeReservationStatus.cancel) : Convert.ToInt64(LodgeReservationStatus.open);

                //validation required when re-opening a room
                if (bookingId == 10001 && !this.ValidateBooking())
                    isOpenCancel = false;

                if (isOpenCancel)
                {
                    LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(this.formDto);
                    reservation.ChangeReservationStatus();
                    this.formDto.Dto.BookingStatusId = bookingId;
                    this.dto.BookingStatusId = this.formDto.Dto.BookingStatusId;
                    base.IsModified = true;
                    this.Close();
                }                
            }
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

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {           
            this.ValidateBookedRoomsAndPopulate();
            this.LoadRoomReservationStatusLevels();
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            this.ValidateBookedRoomsAndPopulate();
            this.LoadRoomReservationStatusLevels();
        }

        private void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new LodgeFacade.RoomReservation.ReservationServer(formDto);
            facade.LoadForm();

            this.configurationRuleDto = formDto.configurationRuleDto;
            if (this.configurationRuleDto.DateFormat != null)
                dtFrom.CustomFormat = this.configurationRuleDto.DateFormat;

            //--populate room category
            this.cboCategory.DataSource = null;
            if (this.formDto.CategoryList != null && this.formDto.CategoryList.Count > 0)
            {
                this.formDto.CategoryList.Insert(0, new LodgeConfigurationFacade.Room.Category.Dto
                {
                    Name = "All"
                });

                this.cboCategory.DataSource = this.formDto.CategoryList;
                this.cboCategory.ValueMember = "Id";
                this.cboCategory.DisplayMember = "Name";
                this.cboCategory.SelectedIndex = 0;
            }

            //--populate room type
            this.cboType.DataSource = null;
            if (this.formDto.TypeList != null && this.formDto.TypeList.Count > 0)
            {
                this.formDto.TypeList.Insert(0, new LodgeConfigurationFacade.Room.Type.Dto
                {
                    Name = "All"
                });

                this.cboType.DataSource = this.formDto.TypeList;
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

            this.LoadReservationData();

            this.txtArtifactPath.ReadOnly = true;
            if (this.isLoadedFromCheckInForm)
                this.txtArtifactPath.Text = new Vanilla.Utility.Facade.Module.Server(null).GetRootLevelModulePath("LRSV", this.formDto.ModuleFormDto.FormModuleList, "Form");
            else
                this.txtArtifactPath.Text = this.dto.artifactPath;

            //disable the controls if the reservation is checked in
            if (this.formDto.Dto != null && this.formDto.Dto.isCheckedIn)
                this.DisableFormControls();
            else if (this.formDto.Dto != null && this.formDto.Dto.BookingStatusId == Convert.ToInt64(LodgeReservationStatus.cancel))
            {
                this.DisableFormControls();
                btnCancelOpen.Enabled = true;
            }

            //Hide open cancel button for new reservation
            if (this.formDto.Dto == null || this.formDto.Dto.Id == 0)
                this.btnCancelOpen.Visible = false;
        }

        private void PopulateCustomerData(Form form)
        {            
            if (this.dto == null)
                this.dto = new LodgeFacade.RoomReservation.Dto();

            this.dto.Customer = form.Tag as CustomerFacade.Dto;

            String Name = (this.dto.Customer.Initial == null ? String.Empty : this.dto.Customer.Initial.Name);
            Name += (Name == String.Empty) ? (this.dto.Customer.FirstName == null ? String.Empty : this.dto.Customer.FirstName) : " " + (this.dto.Customer.FirstName == null ? String.Empty : this.dto.Customer.FirstName);
            Name += (Name == String.Empty) ? (this.dto.Customer.MiddleName == null ? String.Empty : this.dto.Customer.MiddleName) : " " + (this.dto.Customer.MiddleName == null ? String.Empty : this.dto.Customer.MiddleName);
            Name += (Name == String.Empty) ? (this.dto.Customer.LastName == null ? String.Empty : this.dto.Customer.LastName) : " " + (this.dto.Customer.LastName == null ? String.Empty : this.dto.Customer.LastName);

            txtName.Text = Name;
            lstContact.DataSource = this.dto.Customer.ContactNumberList;
            lstContact.DisplayMember = "Name";
            lstContact.ValueMember = "Id";
            lstContact.SelectedIndex = -1;
            txtAdds.Text = this.dto.Customer.Address;
            txtEmail.Text = this.dto.Customer.Email;
            
        }
        
        private void LoadReservationData()
        {
            //populate customer data
            if (this.dto != null && this.dto.Id > 0)
            {
                if (this.dto.Customer != null)
                {
                    String Name = (this.dto.Customer.Initial == null ? String.Empty : this.dto.Customer.Initial.Name);
                    Name += (Name == String.Empty) ? (this.dto.Customer.FirstName == null ? String.Empty : this.dto.Customer.FirstName) : " " + (this.dto.Customer.FirstName == null ? String.Empty : this.dto.Customer.FirstName);
                    Name += (Name == String.Empty) ? (this.dto.Customer.MiddleName == null ? String.Empty : this.dto.Customer.MiddleName) : " " + (this.dto.Customer.MiddleName == null ? String.Empty : this.dto.Customer.MiddleName);
                    Name += (Name == String.Empty) ? (this.dto.Customer.LastName == null ? String.Empty : this.dto.Customer.LastName) : " " + (this.dto.Customer.LastName == null ? String.Empty : this.dto.Customer.LastName);

                    txtName.Text = Name;
                    lstContact.DataSource = this.dto.Customer.ContactNumberList;
                    lstContact.DisplayMember = "Name";
                    lstContact.ValueMember = "Id";
                    lstContact.SelectedIndex = -1;
                    txtAdds.Text = this.dto.Customer.Address;
                    txtEmail.Text = this.dto.Customer.Email;

                    //populating customer in refresh dto
                    if (this.refreshDto != null)
                    {
                        this.refreshDto.Customer = this.CloneCustomer(this.dto.Customer);
                    }
                }

                //populate booking data
                if (!ValidationRule.IsMinimumDate(this.dto.BookingFrom))
                {
                    dtFrom.Value = this.dto.BookingFrom;
                    dtFromTime.Value = this.dto.BookingFrom;
                }
                txtDays.Text = this.dto.NoOfDays == 0 ? String.Empty : this.dto.NoOfDays.ToString();
                txtPersons.Text = this.dto.NoOfPersons == 0 ? String.Empty : this.dto.NoOfPersons.ToString();
                txtRooms.Text = this.dto.NoOfRooms == 0 ? String.Empty : this.dto.NoOfRooms.ToString();
                txtAdvance.Text = this.dto.Advance == 0 ? String.Empty : Converter.ConvertToIndianCurrency(this.dto.Advance);
                cboSelectedRoom.DataSource = this.dto.RoomList;
                cboSelectedRoom.DisplayMember = "Number";
                cboSelectedRoom.ValueMember = "Id";
                cboSelectedRoom.SelectedIndex = -1;

                if (this.dto.RoomCategory != null && this.dto.RoomCategory.Id > 0)
                {
                    for (int i = 0; i < cboCategory.Items.Count; i++)
                    {
                        if (this.dto.RoomCategory.Id == ((LodgeConfigurationFacade.Room.Category.Dto)cboCategory.Items[i]).Id)
                        {
                            cboCategory.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else cboCategory.SelectedIndex = 0;

                if (this.dto.RoomType != null && this.dto.RoomType.Id > 0)
                {
                    for (int i = 0; i < cboType.Items.Count; i++)
                    {
                        if (this.dto.RoomType.Id == ((LodgeConfigurationFacade.Room.Type.Dto)cboType.Items[i]).Id)
                        {
                            cboType.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else cboType.SelectedIndex = 0;
                                
                cboAC.SelectedIndex = this.dto.ACPreference;
                
                if (this.dto.BookingStatusId == Convert.ToInt64(LodgeReservationStatus.open))
                {
                    txtReservationStatus.Text = "Open";
                    btnCancelOpen.Text = "Cancel";
                }
                else if (this.dto.BookingStatusId == Convert.ToInt64(LodgeReservationStatus.cancel))
                {
                    txtReservationStatus.Text = "Cancel";
                    btnCancelOpen.Text = "Re Open";
                }
            }
        }

        private void DisableFormControls()
        {
            errorProvider.Clear();

            this.btnPickCustomer.Enabled = false;
            this.btnAddCustomer.Enabled = false;
            this.btnRefresh.Enabled = false;
            this.btnOk.Enabled = false;
            this.btnCancelOpen.Enabled = false;
            this.btnBrowse.Enabled = false;
            this.btnAddRoom.Enabled = false;
            this.btnRemoveRoom.Enabled = false;

            this.cboCategory.Enabled = false;
            this.cboType.Enabled = false;

            this.dtFrom.Enabled = false;
            this.dtFromTime.Enabled = false;
            this.txtDays.Enabled = false;
            this.txtPersons.Enabled = false;
            this.txtRooms.Enabled = false;
            this.txtAdvance.Enabled = false;
                        
            this.cboRoomList.Enabled = false;
            this.cboSelectedRoom.Enabled = false;
            this.cboAC.Enabled = false;
            this.txtArtifactPath.Enabled = false;
        }

        private void Clear()
        {            
            txtName.Text = String.Empty;
            lstContact.DataSource = null;
            txtAdds.Text = String.Empty;
            txtEmail.Text = String.Empty;

            txtDays.Text = String.Empty;
            txtPersons.Text = String.Empty;
            txtRooms.Text = String.Empty;
            txtAdvance.Text = String.Empty;
            cboSelectedRoom.DataSource = null;

            dtFrom.Value = DateTime.Now;
            dtFromTime.Value = DateTime.Now;

            this.cboCategory.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
            this.cboAC.SelectedIndex = 0;
            //this.chkIsAC.Checked = false;
          
        }

        private void ResetLoad()
        {            
            this.dto.Customer = this.refreshDto.Customer == null ? null : this.CloneCustomer(this.refreshDto.Customer);
            this.dto.BookingFrom = this.refreshDto.BookingFrom;
            this.dto.NoOfDays = this.refreshDto.NoOfDays;
            this.dto.NoOfPersons = this.refreshDto.NoOfPersons;
            this.dto.NoOfRooms = this.refreshDto.NoOfRooms;
            this.dto.Advance = this.refreshDto.Advance;
            this.dto.BookingStatusId = this.refreshDto.BookingStatusId;
            this.dto.RoomCategory = this.refreshDto.RoomCategory;
            this.dto.RoomType = this.refreshDto.RoomType;
            this.dto.ACPreference = this.refreshDto.ACPreference;
            this.dto.RoomList = this.refreshDto.RoomList;           

            this.LoadReservationData();
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

        private Boolean SaveReservationData()
        {
            Boolean retVal = this.ValidateBooking();

            if (retVal)
            {
                if (this.dto == null) this.dto = new LodgeFacade.RoomReservation.Dto();
                this.dto.Id = this.dto == null ? 0 : this.dto.Id;
                this.dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);
                this.dto.NoOfDays = Convert.ToInt16(txtDays.Text);
                this.dto.NoOfPersons = Convert.ToInt16(txtPersons.Text);
                this.dto.NoOfRooms = Convert.ToInt16(txtRooms.Text);
                this.dto.Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtAdvance.Text.Replace(",", ""));
                this.dto.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.DataSource as List<LodgeConfigurationFacade.Room.Category.Dto>)[this.cboCategory.SelectedIndex].Id };
                this.dto.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.DataSource as List<LodgeConfigurationFacade.Room.Type.Dto>)[this.cboType.SelectedIndex].Id };
                this.dto.ACPreference = this.cboAC.SelectedIndex;
                this.dto.Customer = new CustomerFacade.Dto()
                    {
                        Id = this.dto.Customer.Id,
                        FirstName = this.dto.Customer.FirstName,
                        MiddleName = this.dto.Customer.MiddleName,
                        LastName = this.dto.Customer.LastName,
                        Address = this.dto.Customer.Address,
                        City = this.dto.Customer.City,
                        Pin = this.dto.Customer.Pin,
                        Email = this.dto.Customer.Email,
                        IdentityProofType = new Table
                        {
                            Id = this.dto.Customer.IdentityProofType.Id,
                            Name = this.dto.Customer.IdentityProofType.Name
                        },
                        IdentityProofName = this.dto.Customer.IdentityProofName,
                        State = new Table
                        {
                            Id = this.dto.Customer.State.Id,
                            Name = this.dto.Customer.State.Name
                        },
                        ContactNumberList = this.dto.Customer.ContactNumberList,
                        Initial = new Table 
                        {
                            Id = this.dto.Customer.Initial.Id,
                            Name = this.dto.Customer.Initial.Name
                        }                        
                    };
                this.dto.RoomList = this.cboSelectedRoom.Items.Count == 0 ? null : (List<LodgeConfigurationFacade.Room.Dto>)this.cboSelectedRoom.DataSource;

                LodgeFacade.RoomReservation.FormDto formDto = new LodgeFacade.RoomReservation.FormDto()
                {
                    Dto = this.dto,
                };
                BinAff.Facade.Library.Server facade = new LodgeFacade.RoomReservation.ReservationServer(formDto);
                
                if (formDto.Dto.Id == 0)                
                    facade.Add();                
                else                
                    facade.Change();

                if(this.isLoadedFromCheckInForm)
                {
                    this.Tag = new LodgeFacade.RoomReservationRegister.Dto
                    {
                        Id = this.dto.Id,
                        Name = txtName.Text, //display name
                        BookingFrom = this.dto.BookingFrom,
                        NoOfDays = this.dto.NoOfDays,
                        NoOfPersons = this.dto.NoOfPersons,
                        NoOfRooms = this.dto.NoOfRooms,
                        Advance = this.dto.Advance,
                        RoomCategory = this.dto.RoomCategory,
                        RoomType = this.dto.RoomType,
                        ACPreference = this.dto.ACPreference,
                        RoomList = this.dto.RoomList,
                        Customer = this.dto.Customer
                    };
                }

                if (facade.IsError)
                {
                    retVal = false;
                    new PresentationLibrary.MessageBox
                    {
                        DialogueType = facade.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                        Heading = "Splash",
                    }.Show(facade.DisplayMessageList);
                }
            }
            return retVal;
        }

        private Boolean SaveArtifact()
        {          
            this.dto.ArtifactPath = this.txtArtifactPath.Text;
            Vanilla.Utility.Facade.Artifact.Dto artifactDto = new Vanilla.Utility.Facade.Artifact.Dto
            {
                Module = this.dto,
                Style = Vanilla.Utility.Facade.Artifact.Type.Document,
                Version = 1,
                CreatedBy = new Table
                {
                    Id = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                    Name = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
                },
                CreatedAt = DateTime.Now,
                Category = Vanilla.Utility.Facade.Artifact.Category.Form,
                Path = this.dto.ArtifactPath
            };

            new LodgeFacade.RoomReservation.ReservationServer(this.formDto).SaveArtifactForReservation(artifactDto);

            //-Add artifact to customer node
            Int16 reservationNodePosition = 0;
            for (int i = 0; i < this.trvForm.Nodes.Count; i++)
            {
                if (this.trvForm.Nodes[i].Text == "Room Reservation")
                    break;

                reservationNodePosition++;
            }

            (this.trvForm.Nodes[reservationNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto).Artifact.Children.Add(artifactDto);
            artifactDto.Parent = this.trvForm.Nodes[reservationNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto;

            return true;
        }

        private Boolean ValidateBooking()
        {
            Boolean retVal = true;
            errorProvider.Clear();

            if (txtName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(btnPickCustomer, "Select a customer for reservation.");
                btnPickCustomer.Focus();
                return false;
            }
            else if (ValidationRule.IsDateLessThanToday(dtFrom.Value))
            {
                errorProvider.SetError(dtFrom, "Booking date cannot be less than today.");
                dtFrom.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtDays.Text.Trim()))
            {
                errorProvider.SetError(txtDays, "Please enter days.");
                txtDays.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())))
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
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtPersons.Text.Trim())))
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
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtRooms.Text.Trim())))
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
            else if (ValidationRule.IsDateLessThanToday(dtFrom.Value))
            {
                errorProvider.SetError(dtFrom, "Booking from date cannot be less than today.");
                dtFrom.Focus();
                return false;
            }
            else if (cboSelectedRoom.Items.Count > Convert.ToInt32(txtRooms.Text.Trim()))
            {
                errorProvider.SetError(cboSelectedRoom, "Selected rooms cannot be greater than the no of rooms.");
                cboSelectedRoom.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtRooms.Text.Trim()) > this.availableRooms)
            {
                errorProvider.SetError(txtRooms, "No of rooms cannot be greater than available rooms.");
                cboSelectedRoom.Focus();
                return false;
            }
            else if (this.cboRoomList.DataSource == null && this.cboSelectedRoom.DataSource == null)
            {
                errorProvider.SetError(cboRoomList, "No rooms available for booking.");
                cboRoomList.Focus();
                return false;
            }

            return retVal;
        }
                
        private void PopulateFilteredRoomList()
        {
            this.cboRoomList.DataSource = null;
            List<LodgeConfigurationFacade.Room.Dto> RoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (this.formDto.roomList != null && this.formDto.roomList.Count > 0)
            {
                foreach (LodgeConfigurationFacade.Room.Dto roomDto in this.formDto.roomList)
                {
                    if (this.ValidateRoom(roomDto))
                        RoomList.Add(roomDto);
                }
            }


            List<LodgeConfigurationFacade.Room.Dto> SelectedRoomList = new List<LodgeConfigurationFacade.Room.Dto>();
            List<LodgeConfigurationFacade.Room.Dto> AvailableRoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (RoomList != null && RoomList.Count > 0)
            {
                if (this.dto == null || this.dto.RoomList == null || this.dto.RoomList.Count == 0)
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
                        foreach (LodgeConfigurationFacade.Room.Dto validRoomDto in this.dto.RoomList)
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

            this.cboSelectedRoom.DataSource = SelectedRoomList;
            if (SelectedRoomList != null && SelectedRoomList.Count > 0)
            {
                this.cboSelectedRoom.DisplayMember = "Number";
                this.cboSelectedRoom.ValueMember = "Id";
                this.cboSelectedRoom.SelectedIndex = -1;
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

            if (!this.isRoomBooked(roomDto))
                return false;
            
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
                return true;
            }
            
            return false;
        }

        private Boolean isBookedRoomBelongsToCurrentReservation(LodgeConfigurationFacade.Room.Dto bookedRoom)
        {
            if (this.dto == null || this.dto.RoomList == null)
                return false;

            foreach(LodgeConfigurationFacade.Room.Dto room in this.dto.RoomList)
            {
                if (bookedRoom.Id == room.Id)
                    return true;
            }

            return false;
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
            return reservation.GetBookedRooms(startDate,endDate).Value;
        }
        
        private CustomerFacade.Dto CloneCustomer(CustomerFacade.Dto customerDto)
        {
            CustomerFacade.Dto customer = new CustomerFacade.Dto
            {
                Id = customerDto.Id,
                Initial = customerDto.Initial == null ? null : new Table
                {
                    Id = customerDto.Initial.Id,
                    Name = customerDto.Initial.Name
                },
                FirstName = customerDto.FirstName,
                MiddleName = customerDto.MiddleName,
                LastName = customerDto.LastName,
                ContactNumberList = customerDto.ContactNumberList == null ? null : this.CloneContactNumber(customerDto.ContactNumberList),
                Address = customerDto.Address,
                Email = customerDto.Email
            };
            return customer;
        }

        private List<Table> CloneContactNumber(List<Table> contactNumberList)
        {
            List<Table> lstContactNumber = new List<Table>();
            foreach (Table contactNo in contactNumberList)
            {
                lstContactNumber.Add(new Table
                {
                    Id = contactNo.Id,
                    Name = contactNo.Name
                });
            }
            return lstContactNumber;
        }

        private List<LodgeConfigurationFacade.Room.Dto> CloneRoomList(List<LodgeConfigurationFacade.Room.Dto> roomList)
        {
            List<LodgeConfigurationFacade.Room.Dto> lstRoom = new List<LodgeConfigurationFacade.Room.Dto>();

            foreach (LodgeConfigurationFacade.Room.Dto room in roomList)
                lstRoom.Add(new LodgeConfigurationFacade.Room.Dto
                {
                    Id = room.Id,
                    Action = room.Action,
                    artifactPath = room.artifactPath,
                    Building = room.Building,
                    Category = room.Category,
                    Description = room.Description,
                    fileName = room.fileName,
                    Floor = room.Floor,
                    ImageList = room.ImageList,
                    IsAirconditioned = room.IsAirconditioned,
                    Name = room.Name,
                    Number = room.Number,
                    StatusId = room.StatusId,
                    trvForm = room.trvForm,
                    Type = room.Type
                });

            return lstRoom;
        }

        private void LoadRoomReservationStatusLevels()
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

            int TotalRoomsWithMatchingCategoryTypeAndACPreference = 0;
            int TotalRoomsBookedWithMatchingCategoryTypeAndACPreference = 0;
            int AvailableRoomsCount = 0;

            LodgeFacade.RoomReservation.IReservation reservation = new LodgeFacade.RoomReservation.ReservationServer(null);
            List<LodgeConfigurationFacade.Room.Dto> filteredRoomList = new List<LodgeConfigurationFacade.Room.Dto>();

            if (this.formDto.roomList != null && this.formDto.roomList.Count > 0)
            { 
                filteredRoomList = reservation.GetFilteredRoomsWithCategoryTypeAndACPreference(this.formDto.roomList, 0, 0, 0);
                this.totalRooms = filteredRoomList.Count;
                lblTotalRooms.Text = "Total Rooms : = " + filteredRoomList.Count.ToString();

                filteredRoomList = reservation.GetFilteredRoomsWithCategoryTypeAndACPreference(this.formDto.roomList, roomCategoryId, roomTypeId, acPreference);
                if (filteredRoomList != null)
                    TotalRoomsWithMatchingCategoryTypeAndACPreference = filteredRoomList.Count;
            }
            lblTotalRoomCount.Text = "Total no of rooms for the selected category, type and AC preference = " + TotalRoomsWithMatchingCategoryTypeAndACPreference.ToString();

            if (isNoOfDaysExists())
            {
                Int64 reservationId = this.dto == null ? 0 : this.dto.Id;
                this.totalBookings = reservation.GetNoOfRoomsBookedBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)), reservationId);
                lblTotalBooking.Text = "Total Bookings between selected dates : = " + this.totalBookings.ToString();
                    
                //reservation.GetNoOfRoomsBookedBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)), reservationId, 0, 0, 0).ToString();

                TotalRoomsBookedWithMatchingCategoryTypeAndACPreference = reservation.GetNoOfRoomsBookedBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)), reservationId, roomCategoryId, roomTypeId, acPreference);
                lblTotalBookedRoomCount.Text = "Total no of rooms booked for the selected category, type and AC preference from " +
                    dtFrom.Value.ToShortDateString() + " and " + dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)).ToShortDateString() + " = " +
                    TotalRoomsBookedWithMatchingCategoryTypeAndACPreference.ToString();

                AvailableRoomsCount = TotalRoomsWithMatchingCategoryTypeAndACPreference - TotalRoomsBookedWithMatchingCategoryTypeAndACPreference;
                Int32 totalAvailableRooms = this.totalRooms - this.totalBookings;                                
                this.availableRooms = (AvailableRoomsCount > totalAvailableRooms) ? totalAvailableRooms : AvailableRoomsCount;

                lblAvailableRooms.Text = "No of Rooms available for booking = " + this.availableRooms.ToString();

                if (this.availableRooms == 0)
                    this.cboRoomList.DataSource = null;
                
            }
            else
            {
                lblTotalBookedRoomCount.Text = String.Empty;
                lblAvailableRooms.Text = String.Empty;
                this.availableRooms = 0;
            }
        }

        public enum LodgeReservationStatus
        {
            open = 10001,
            closed = 10002,
            cancel = 10003,
            checkin = 10004
        }      

    }
}
