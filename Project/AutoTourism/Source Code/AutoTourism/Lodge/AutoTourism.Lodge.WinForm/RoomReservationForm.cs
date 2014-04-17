using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;
using PresLib = BinAff.Presentation.Library;

//using LodgeFacade = AutoTourism.Lodge.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using ConfigFacade = AutoTourism.Lodge.Configuration.Facade;
using CustomerFacade = AutoTourism.Customer.Facade;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationForm : PresLib.Form
    {

        private Facade.RoomReservation.Dto dto;
        private Facade.RoomReservation.FormDto formDto;
        private RuleFacade.ConfigurationRuleDto configRuleDto;
        private Boolean isLoadedFromCheckInForm = false;
        private TreeView trvForm;
        private Facade.RoomReservation.Dto refreshDto;
        private List<ConfigFacade.Room.Dto> bookedRooms;

        private Int32 totalRooms = 0;
        private Int32 totalBookings = 0;
        private Int32 availableRooms = 0;

        public enum Status
        {
            Open = 10001,
            Closed = 10002,
            Canceled = 10003
        }


        public RoomReservationForm(TreeView trvForm)
        {
            InitializeComponent();
            this.isLoadedFromCheckInForm = true;
            this.trvForm = trvForm;
        }

        public RoomReservationForm(Facade.RoomReservation.Dto dto)
        {
            InitializeComponent();
            this.dto = dto;
            this.trvForm = this.dto.trvForm;

            if (this.dto.Id > 0)
            {
                Facade.RoomReservation.IReservation reservation = new Facade.RoomReservation.ReservationServer(null);
                this.refreshDto = reservation.CloneReservaion(this.dto);
            }
        }

        private void RoomBookingForm_Load(object sender, System.EventArgs e)
        {          
            //set default date format
            this.dtFrom.Format = DateTimePickerFormat.Custom;
            this.dtFrom.CustomFormat = "MM/dd/yyyy"; //--MM should be in upper case

            this.dtFromTime.Format = DateTimePickerFormat.Time;
            this.dtFromTime.ShowUpDown = true;

            this.formDto = new Facade.RoomReservation.FormDto
            { 
                Dto = this.dto,
                ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
            };

            //if loaded form checkin form , then populate the modules
            if (this.isLoadedFromCheckInForm)
            {
                new Vanilla.Utility.Facade.Module.Server(this.formDto.ModuleFormDto).LoadForm();
            }

            LoadForm();
        }  

        private void btnPickCustomer_Click(object sender, System.EventArgs e)
        {
            Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerRegister, AutoTourism.Customer.WinForm", true);
            Form form = (Form)Activator.CreateInstance(type);
            form.ShowDialog(this);

            if (form.Tag != null)
            {
                this.PopulateCustomerData(form);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm", true);
            Form form = (Form)Activator.CreateInstance(type, this.trvForm);
            form.ShowDialog(this);

            if (form.Tag != null)
            {
                this.PopulateCustomerData(form);
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            ConfigFacade.Room.Dto roomDto = null;
            if (cboRoomList.SelectedIndex != -1)
            {
                roomDto = (ConfigFacade.Room.Dto)cboRoomList.SelectedItem;
                AddToList(roomDto, cboSelectedRoom);
                RemoveFromList(roomDto, cboRoomList);
            }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            ConfigFacade.Room.Dto roomDto = null;
            if (cboSelectedRoom.SelectedIndex != -1)
            {
                roomDto = (ConfigFacade.Room.Dto)cboSelectedRoom.SelectedItem;
                AddToList(roomDto, cboRoomList);
                RemoveFromList(roomDto, cboSelectedRoom);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.SaveReservationData())
            {
                if (this.isLoadedFromCheckInForm) this.SaveArtifact();

                base.IsModified = true;
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (this.formDto.Dto != null && this.formDto.Dto.Id > 0)
            {
                this.ResetLoad();
            }
            else
            {
                this.Clear();
            }
            this.PopulateFilteredRoomList();
        }

        private void btnCancelOpen_Click(object sender, EventArgs e)
        {
            if (this.formDto != null && this.formDto.Dto != null)
            {
                Status status = btnCancelOpen.Text == "Cancel" ? Status.Canceled : Status.Open;

                //validation required when re-opening a room
                Boolean isOpenCancel = !(status == Status.Open && !this.ValidateBooking());

                if (isOpenCancel)
                {
                    Facade.RoomReservation.IReservation reservation = new Facade.RoomReservation.ReservationServer(this.formDto);
                    reservation.ChangeReservationStatus();
                    this.formDto.Dto.BookingStatusId = Convert.ToInt64(status);
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
            new Facade.RoomReservation.ReservationServer(formDto).LoadForm();

            this.configRuleDto = this.formDto.configurationRuleDto;
            if (this.configRuleDto.DateFormat != null)
            {
                this.dtFrom.CustomFormat = this.configRuleDto.DateFormat;
            }

            //--populate room category
            this.cboCategory.DataSource = null;
            if (this.formDto.CategoryList != null && this.formDto.CategoryList.Count > 0)
            {
                this.formDto.CategoryList.Insert(0, new ConfigFacade.Room.Category.Dto
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
                this.formDto.TypeList.Insert(0, new ConfigFacade.Room.Type.Dto
                {
                    Name = "All"
                });

                this.cboType.DataSource = this.formDto.TypeList;
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

            this.LoadReservationData();

            this.txtArtifactPath.ReadOnly = true;
            if (this.isLoadedFromCheckInForm)
                this.txtArtifactPath.Text = new Vanilla.Utility.Facade.Module.Server(null).GetRootLevelModulePath("LRSV", this.formDto.ModuleFormDto.FormModuleList, "Form");
            else
                this.txtArtifactPath.Text = this.dto.artifactPath;

            //disable the controls if the reservation is checked in
            if (this.formDto.Dto != null && this.formDto.Dto.isCheckedIn)
            {
                this.DisableFormControls();
            }
            else if (this.formDto.Dto != null && this.formDto.Dto.BookingStatusId == Convert.ToInt64(Status.Canceled))
            {
                this.DisableFormControls();
                btnCancelOpen.Enabled = true;
            }

            //Hide open cancel button for new reservation
            if (this.formDto.Dto == null || this.formDto.Dto.Id == 0)
            {
                this.btnCancelOpen.Visible = false;
            }
        }

        private void PopulateCustomerData(Form form)
        {
            if (this.dto == null)
            {
                this.dto = new Facade.RoomReservation.Dto();
            }
            this.dto.Customer = form.Tag as CustomerFacade.Dto;
            this.txtName.Text = this.dto.Customer.Name;

            this.lstContact.DataSource = this.dto.Customer.ContactNumberList;
            this.lstContact.DisplayMember = "Name";
            this.lstContact.ValueMember = "Id";
            this.lstContact.SelectedIndex = -1;
            this.txtAdds.Text = this.dto.Customer.Address;
            this.txtEmail.Text = this.dto.Customer.Email;            
        }
        
        private void LoadReservationData()
        {
            Facade.RoomReservation.IReservation reservation = new Facade.RoomReservation.ReservationServer(null);
            //populate customer data
            if (this.dto != null && this.dto.Id > 0)
            {
                if (this.dto.Customer != null)
                {
                    this.txtName.Text = this.dto.Customer.Name;
                    this.lstContact.DataSource = this.dto.Customer.ContactNumberList;
                    this.lstContact.DisplayMember = "Name";
                    this.lstContact.ValueMember = "Id";
                    this.lstContact.SelectedIndex = -1;
                    this.txtAdds.Text = this.dto.Customer.Address;
                    this.txtEmail.Text = this.dto.Customer.Email;

                    //populating customer in refresh dto
                    if (this.refreshDto != null)
                    {
                        this.refreshDto.Customer = reservation.CloneCustomer(this.dto.Customer);
                    }
                }

                //populate booking data
                if (!ValidationRule.IsMinimumDate(this.dto.BookingFrom))
                {
                    dtFrom.Value = this.dto.BookingFrom;
                    dtFromTime.Value = this.dto.BookingFrom;
                }
                this.txtDays.Text = this.dto.NoOfDays == 0 ? String.Empty : this.dto.NoOfDays.ToString();
                this.txtPersons.Text = this.dto.NoOfPersons == 0 ? String.Empty : this.dto.NoOfPersons.ToString();
                this.txtRooms.Text = this.dto.NoOfRooms == 0 ? String.Empty : this.dto.NoOfRooms.ToString();
                this.txtAdvance.Text = this.dto.Advance == 0 ? String.Empty : Converter.ConvertToIndianCurrency(this.dto.Advance);
                this.cboSelectedRoom.DataSource = this.dto.RoomList;
                this.cboSelectedRoom.DisplayMember = "Number";
                this.cboSelectedRoom.ValueMember = "Id";
                this.cboSelectedRoom.SelectedIndex = -1;

                if (this.dto.RoomCategory != null && this.dto.RoomCategory.Id > 0)
                {
                    for (int i = 0; i < cboCategory.Items.Count; i++)
                    {
                        if (this.dto.RoomCategory.Id == ((ConfigFacade.Room.Category.Dto)cboCategory.Items[i]).Id)
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
                        if (this.dto.RoomType.Id == ((ConfigFacade.Room.Type.Dto)cboType.Items[i]).Id)
                        {
                            cboType.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else cboType.SelectedIndex = 0;
                                
                cboAC.SelectedIndex = this.dto.ACPreference;
                
                if (this.dto.BookingStatusId == Convert.ToInt64(Status.Open))
                {
                    txtStatus.Text = "Open";
                    btnCancelOpen.Text = "Cancel";
                }
                else if (this.dto.BookingStatusId == Convert.ToInt64(Status.Canceled))
                {
                    txtStatus.Text = "Cancel";
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
            this.txtName.Text = String.Empty;
            this.lstContact.DataSource = null;
            this.txtAdds.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            
            this.txtDays.Text = String.Empty;
            this.txtPersons.Text = String.Empty;
            this.txtRooms.Text = String.Empty;
            this.txtAdvance.Text = String.Empty;
            this.cboSelectedRoom.DataSource = null;
            
            this.dtFrom.Value = DateTime.Now;
            this.dtFromTime.Value = DateTime.Now;

            this.cboCategory.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
            this.cboAC.SelectedIndex = 0;
        }

        private void ResetLoad()
        {
            Facade.RoomReservation.IReservation reservation = new Facade.RoomReservation.ReservationServer(null);
            this.dto.Customer = this.refreshDto.Customer == null ? null : reservation.CloneCustomer(this.refreshDto.Customer);
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

        private void AddToList(ConfigFacade.Room.Dto roomDto, System.Windows.Forms.ListControl cboRoom)
        {
            Boolean include = false;
            List<ConfigFacade.Room.Dto> RoomList = new List<ConfigFacade.Room.Dto>();

            if (((System.Windows.Forms.ComboBox)cboRoom).Items.Count == 0)
            {
                RoomList.Add(roomDto);
            }
            else
            {
                foreach (ConfigFacade.Room.Dto dto in (List<ConfigFacade.Room.Dto>)cboRoom.DataSource)
                {
                    if (dto.Id < roomDto.Id || include == true)
                        RoomList.Add(dto);
                    else
                    {
                        RoomList.Add(roomDto);
                        RoomList.Add(dto);
                        include = true;
                    }
                }
                if (!include) RoomList.Add(roomDto);
            }

            cboRoom.DataSource = null;
            cboRoom.DataSource = RoomList;
            cboRoom.DisplayMember = "Number";
            cboRoom.ValueMember = "Id";
            cboRoom.SelectedIndex = -1;
        }

        private void RemoveFromList(ConfigFacade.Room.Dto roomDto, System.Windows.Forms.ListControl cboRoom)
        {
            List<ConfigFacade.Room.Dto> RoomList = new List<ConfigFacade.Room.Dto>();
            foreach (ConfigFacade.Room.Dto dto in (List<ConfigFacade.Room.Dto>)cboRoom.DataSource)
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
                if (this.dto == null) this.dto = new Facade.RoomReservation.Dto();
                this.dto.Id = this.dto == null ? 0 : this.dto.Id;
                this.dto.BookingFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, dtFromTime.Value.Second);
                this.dto.NoOfDays = Convert.ToInt16(txtDays.Text);
                this.dto.NoOfPersons = Convert.ToInt16(txtPersons.Text);
                this.dto.NoOfRooms = Convert.ToInt16(txtRooms.Text);
                this.dto.Advance = txtAdvance.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtAdvance.Text.Replace(",", ""));
                this.dto.RoomCategory = this.cboCategory.SelectedIndex == -1 ? null : new Table { Id = (this.cboCategory.DataSource as List<ConfigFacade.Room.Category.Dto>)[this.cboCategory.SelectedIndex].Id };
                this.dto.RoomType = this.cboType.SelectedIndex == -1 ? null : new Table { Id = (this.cboType.DataSource as List<ConfigFacade.Room.Type.Dto>)[this.cboType.SelectedIndex].Id };
                this.dto.ACPreference = this.cboAC.SelectedIndex;
                this.dto.BookingStatusId = Convert.ToInt64(Status.Open);
                this.dto.Customer = new CustomerFacade.Dto
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
                    //Initial = new Table 
                    //{
                    //    Id = this.dto.Customer.Initial.Id,
                    //    Name = this.dto.Customer.Initial.Name
                    //}                        
                };
                this.dto.RoomList = this.cboSelectedRoom.Items.Count == 0 ? null : (List<ConfigFacade.Room.Dto>)this.cboSelectedRoom.DataSource;

                Facade.RoomReservation.FormDto formDto = new Facade.RoomReservation.FormDto()
                {
                    Dto = this.dto,
                };
                BinAff.Facade.Library.Server facade = new Facade.RoomReservation.ReservationServer(formDto);

                if (formDto.Dto.Id == 0)
                {
                    facade.Add();
                }
                else
                {
                    facade.Change();
                }

                if(this.isLoadedFromCheckInForm)
                {
                    this.Tag = new Facade.RoomReservationRegister.Dto
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
                    new PresLib.MessageBox
                    {
                        DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
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

            new Facade.RoomReservation.ReservationServer(this.formDto).SaveArtifactForReservation(artifactDto);

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
            this.errorProvider.Clear();

            if (String.IsNullOrEmpty(this.txtName.Text))
            {
                this.errorProvider.SetError(this.btnPickCustomer, "Select a customer for reservation.");
                this.btnPickCustomer.Focus();
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
            else if (String.IsNullOrEmpty(this.txtPersons.Text))
            {
                this.errorProvider.SetError(this.txtPersons, "Please enter persons.");
                this.txtPersons.Focus();
                return false;
            }
            else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtPersons.Text.Trim())))
            {
                this.errorProvider.SetError(this.txtPersons, "Entered '" + this.txtPersons.Text + "' is Invalid.");
                this.txtPersons.Focus();
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
            else if (!ValidationRule.IsDecimal(String.IsNullOrEmpty(this.txtAdvance.Text) ? "0" : this.txtAdvance.Text.Trim().Replace(",", "")))
            {
                this.errorProvider.SetError(this.txtAdvance, "Entered '" + this.txtAdvance.Text + "' is Invalid.");
                this.txtAdvance.Focus();
                return false;
            }
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
            else if (Convert.ToInt32(this.txtRooms.Text.Trim()) > this.availableRooms)
            {
                this.errorProvider.SetError(this.txtRooms, "No of rooms cannot be greater than available rooms.");
                this.cboSelectedRoom.Focus();
                return false;
            }
            else if (this.cboRoomList.DataSource == null && this.cboSelectedRoom.DataSource == null)
            {
                this.errorProvider.SetError(this.cboRoomList, "No rooms available for booking.");
                this.cboRoomList.Focus();
                return false;
            }

            return retVal;
        }
                
        private void PopulateFilteredRoomList()
        {
            this.cboRoomList.DataSource = null;
            List<ConfigFacade.Room.Dto> roomList = new List<ConfigFacade.Room.Dto>();

            if (this.formDto.roomList != null && this.formDto.roomList.Count > 0)
            {
                foreach (ConfigFacade.Room.Dto roomDto in this.formDto.roomList)
                {
                    if (this.ValidateRoom(roomDto)) roomList.Add(roomDto);
                }
            }

            List<ConfigFacade.Room.Dto> selectedRoomList = new List<ConfigFacade.Room.Dto>();
            List<ConfigFacade.Room.Dto> availableRoomList = new List<ConfigFacade.Room.Dto>();

            if (roomList != null && roomList.Count > 0)
            {
                if (this.dto == null || this.dto.RoomList == null || this.dto.RoomList.Count == 0)
                {
                    selectedRoomList = null;
                    availableRoomList = roomList;
                }
                else
                {
                    Boolean isSelected = false;
                    foreach (ConfigFacade.Room.Dto roomDto in roomList)
                    {
                        isSelected = false;
                        foreach (ConfigFacade.Room.Dto validRoomDto in this.dto.RoomList)
                        {
                            if (roomDto.Id == validRoomDto.Id)
                            {
                                isSelected = true;
                                break;
                            }
                        }

                        if (isSelected)
                        {
                            selectedRoomList.Add(roomDto);
                        }
                        else
                        {
                            availableRoomList.Add(roomDto);
                        }
                    }
                }
            }
            else
            {
                selectedRoomList = null;
                availableRoomList = null;                
            }

            this.cboSelectedRoom.DataSource = selectedRoomList;
            if (selectedRoomList != null && selectedRoomList.Count > 0)
            {
                this.cboSelectedRoom.DisplayMember = "Number";
                this.cboSelectedRoom.ValueMember = "Id";
                this.cboSelectedRoom.SelectedIndex = -1;
            }

            this.cboRoomList.DataSource = availableRoomList;
            if (availableRoomList != null && availableRoomList.Count > 0)
            {
                this.cboRoomList.DisplayMember = "Number";
                this.cboRoomList.ValueMember = "Id";
                this.cboRoomList.SelectedIndex = -1;
            }
        }

        private Boolean ValidateRoom(ConfigFacade.Room.Dto roomDto)
        {   
            Int64 roomCategoryId = 0;
            Int64 roomTypeId = 0;
            Int32 acPreference = 0;

            if (this.cboCategory.SelectedIndex > 0)
            {
                List<ConfigFacade.Room.Category.Dto> lstCategory = this.cboCategory.DataSource as List<ConfigFacade.Room.Category.Dto>;
                roomCategoryId = lstCategory[this.cboCategory.SelectedIndex].Id;                    
            }

            if (this.cboType.SelectedIndex > 0)
            {
                List<ConfigFacade.Room.Type.Dto> lstType = this.cboType.DataSource as List<ConfigFacade.Room.Type.Dto>;
                roomTypeId = lstType[this.cboType.SelectedIndex].Id;
            }

            acPreference = this.cboAC.SelectedIndex;

            Facade.RoomReservation.IReservation reservation = new Facade.RoomReservation.ReservationServer(null);
            Boolean isValidRoom = reservation.ValidateRoomWithCategoryTypeAndACPreference(roomDto, roomCategoryId, roomTypeId, acPreference);

            if (!isValidRoom)
                return false;           

            if (!this.IsRoomBooked(roomDto))
                return false;
            
            return true;
        }

        private Boolean IsRoomBooked(ConfigFacade.Room.Dto roomDto)
        {
            if (this.IsNoOfDaysExists())
            {
                if (this.bookedRooms != null && this.bookedRooms.Count > 0)
                {
                    foreach (ConfigFacade.Room.Dto room in this.bookedRooms)
                    {
                        if (this.IsBookedRoomBelongsToCurrentReservation(room))
                            return true;

                        if (room.Id == roomDto.Id)
                            return false;
                    }                    
                }
                return true;
            }
            
            return false;
        }

        private Boolean IsBookedRoomBelongsToCurrentReservation(ConfigFacade.Room.Dto bookedRoom)
        {
            if (this.dto == null || this.dto.RoomList == null)
                return false;

            foreach(ConfigFacade.Room.Dto room in this.dto.RoomList)
            {
                if (bookedRoom.Id == room.Id)
                    return true;
            }

            return false;
        }
        
        private void ValidateBookedRoomsAndPopulate()
        {
            if (this.IsNoOfDaysExists())
                this.bookedRooms = this.GetBookedRoomListBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt16(txtDays.Text)));
            else
                this.bookedRooms = null;

            this.PopulateFilteredRoomList();
        }

        private Boolean IsNoOfDaysExists()
        {            
            if (String.IsNullOrEmpty(txtDays.Text.Trim()))           
                return false;            
            else if (!(new Regex(@"^[0-9]*$").IsMatch(txtDays.Text.Trim())))            
                return false;

            return true;
        }
        
        private List<ConfigFacade.Room.Dto> GetBookedRoomListBetweenTwoDates(DateTime startDate, DateTime endDate)
        {  
            Facade.RoomReservation.IReservation reservation = new Facade.RoomReservation.ReservationServer(null);
            return reservation.GetBookedRooms(startDate,endDate).Value;
        }
        
        //private CustomerFacade.Dto CloneCustomer(CustomerFacade.Dto customerDto)
        //{
        //    CustomerFacade.Dto customer = new CustomerFacade.Dto
        //    {
        //        Id = customerDto.Id,
        //        Initial = customerDto.Initial == null ? null : new Table
        //        {
        //            Id = customerDto.Initial.Id,
        //            Name = customerDto.Initial.Name
        //        },
        //        FirstName = customerDto.FirstName,
        //        MiddleName = customerDto.MiddleName,
        //        LastName = customerDto.LastName,
        //        ContactNumberList = customerDto.ContactNumberList == null ? null : this.CloneContactNumber(customerDto.ContactNumberList),
        //        Address = customerDto.Address,
        //        Email = customerDto.Email
        //    };
        //    return customer;
        //}

        //private List<Table> CloneContactNumber(List<Table> contactNumberList)
        //{
        //    List<Table> lstContactNumber = new List<Table>();
        //    foreach (Table contactNo in contactNumberList)
        //    {
        //        lstContactNumber.Add(new Table
        //        {
        //            Id = contactNo.Id,
        //            Name = contactNo.Name
        //        });
        //    }
        //    return lstContactNumber;
        //}

        //private List<ConfigFacade.Room.Dto> CloneRoomList(List<ConfigFacade.Room.Dto> roomList)
        //{
        //    List<ConfigFacade.Room.Dto> lstRoom = new List<ConfigFacade.Room.Dto>();

        //    foreach (ConfigFacade.Room.Dto room in roomList)
        //        lstRoom.Add(new ConfigFacade.Room.Dto
        //        {
        //            Id = room.Id,
        //            Action = room.Action,
        //            artifactPath = room.artifactPath,
        //            Building = room.Building,
        //            Category = room.Category,
        //            Description = room.Description,
        //            fileName = room.fileName,
        //            Floor = room.Floor,
        //            ImageList = room.ImageList,
        //            IsAirconditioned = room.IsAirconditioned,
        //            Name = room.Name,
        //            Number = room.Number,
        //            StatusId = room.StatusId,
        //            trvForm = room.trvForm,
        //            Type = room.Type
        //        });

        //    return lstRoom;
        //}

        private void LoadRoomReservationStatusLevels()
        {
            Int64 roomCategoryId = 0;
            Int64 roomTypeId = 0;
            Int32 acPreference = 0;

            if (this.cboCategory.SelectedIndex > 0)
            {
                List<ConfigFacade.Room.Category.Dto> lstCategory = this.cboCategory.DataSource as List<ConfigFacade.Room.Category.Dto>;
                roomCategoryId = lstCategory[this.cboCategory.SelectedIndex].Id;
            }

            if (this.cboType.SelectedIndex > 0)
            {
                List<ConfigFacade.Room.Type.Dto> lstType = this.cboType.DataSource as List<ConfigFacade.Room.Type.Dto>;
                roomTypeId = lstType[this.cboType.SelectedIndex].Id;
            }

            acPreference = this.cboAC.SelectedIndex;

            int TotalRoomsWithMatchingCategoryTypeAndACPreference = 0;
            int TotalRoomsBookedWithMatchingCategoryTypeAndACPreference = 0;
            int AvailableRoomsCount = 0;

            Facade.RoomReservation.IReservation reservation = new Facade.RoomReservation.ReservationServer(null);
            List<ConfigFacade.Room.Dto> filteredRoomList = new List<ConfigFacade.Room.Dto>();

            if (this.formDto.roomList != null && this.formDto.roomList.Count > 0)
            { 
                filteredRoomList = reservation.GetFilteredRoomsWithCategoryTypeAndACPreference(this.formDto.roomList, 0, 0, 0);
                this.totalRooms = filteredRoomList.Count;
                lblTotalRoomsLodge.Text = "Total Rooms : = " + filteredRoomList.Count.ToString();

                filteredRoomList = reservation.GetFilteredRoomsWithCategoryTypeAndACPreference(this.formDto.roomList, roomCategoryId, roomTypeId, acPreference);
                if (filteredRoomList != null)
                    TotalRoomsWithMatchingCategoryTypeAndACPreference = filteredRoomList.Count;
            }
            txtFilteredRoomCount.Text = TotalRoomsWithMatchingCategoryTypeAndACPreference.ToString();

            if (IsNoOfDaysExists())
            {
                Int64 reservationId = this.dto == null ? 0 : this.dto.Id;
                this.totalBookings = reservation.GetNoOfRoomsBookedBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)), reservationId);
                txtTotalBooking.Text = this.totalBookings.ToString();
               
                TotalRoomsBookedWithMatchingCategoryTypeAndACPreference = reservation.GetNoOfRoomsBookedBetweenTwoDates(dtFrom.Value, dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)), reservationId, roomCategoryId, roomTypeId, acPreference);
                //lblTotalBookedRoomCount.Text = "Total no of rooms booked for the selected category, type and AC preference from " +
                //    dtFrom.Value.ToShortDateString() + " and " + dtFrom.Value.AddDays(Convert.ToInt32(txtDays.Text)).ToShortDateString() + " = " +
                //    TotalRoomsBookedWithMatchingCategoryTypeAndACPreference.ToString();

                AvailableRoomsCount = TotalRoomsWithMatchingCategoryTypeAndACPreference - TotalRoomsBookedWithMatchingCategoryTypeAndACPreference;
                Int32 totalAvailableRooms = this.totalRooms - this.totalBookings;                                
                this.availableRooms = (AvailableRoomsCount > totalAvailableRooms) ? totalAvailableRooms : AvailableRoomsCount;

                txtFilteredAvailableRoomCount.Text = this.availableRooms.ToString();

                if (this.availableRooms == 0)
                    this.cboRoomList.DataSource = null;
                
            }
            else
            {
                //lblTotalBookedRoomCount.Text = String.Empty;
                txtFilteredAvailableRoomCount.Text = String.Empty;
                this.availableRooms = 0;
            }
        }

       
    }

}
