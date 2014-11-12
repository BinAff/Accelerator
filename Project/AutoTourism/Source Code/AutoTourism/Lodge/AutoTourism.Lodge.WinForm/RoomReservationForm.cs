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
using AccFac = Vanilla.Guardian.Facade.Account;
using CacheFac = Vanilla.Utility.Facade;

namespace AutoTourism.Lodge.WinForm
{

    public partial class RoomReservationForm : FormWin.Document
    {

        private RuleFac.ConfigurationRuleDto configRuleDto;
        private ToolStripButton btnCancel;

        public enum Status
        {
            Open = 10001,
            //Closed = 10002,
            Canceled = 10003
        }
        
        public RoomReservationForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
        }

        protected override void Compose()
        {
            base.formDto = new Fac.FormDto 
            {
                ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new Fac.Dto()
            };

            base.facade = new Fac.ReservationServer(this.formDto as Fac.FormDto);
        }
              
        public RoomReservationForm(Fac.Dto dto)
        {
            InitializeComponent();
        }

        #region Events

        private void RoomBookingForm_Load(object sender, System.EventArgs e)
        {
            base.AncestorName = "Customer";
            base.AttachmentName = "Advance Payment";
        }

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
                Int64 BookingStatusId = (txtStatus.Text == "Cancel") ? Convert.ToInt64(Status.Open) : Convert.ToInt64(Status.Canceled);

                base.formDto.Document.AuditInfo.ModifiedBy = new Table
                {
                    Id = (BinAff.Facade.Cache.Server.Current.Cache["User"] as AccFac.Dto).Id,
                    Name = (BinAff.Facade.Cache.Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
                };
                base.formDto.Document.AuditInfo.ModifiedAt = DateTime.Now;
              
                base.RegisterArtifactObserver();
                dto.BookingStatusId = BookingStatusId;
                (this.facade as Fac.ReservationServer).ChangeReservationStatus();                    
                  
                base.IsModified = true;
                base.RaiseAuditInfoChanged(this);
                this.Close();
               
            }
        }
                      
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {            
            this.FilterAndPopulateRoomList();
        }
             
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterAndPopulateRoomList();
        }

        private void cboAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterAndPopulateRoomList();
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
            Fac.Dto Dto = formDto.Dto as Fac.Dto;
            base.facade.LoadForm();

            //customer data is getting read at load, so updating the initial dto for customer
            if (Dto.Id > 0)        
                (this.InitialDto as Fac.Dto).Customer = Dto.Customer;

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

            //Hide open cancel button for new reservation
            if (Dto.Id == 0)            
                this.btnCancel.Visible = false;
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

        //protected override void Ok()
        //{   
        //    if (base.Save())
        //    {
        //        base.Artifact.Module = base.formDto.Dto;
        //        base.IsModified = true;
        //        //this.Close();
        //    }
        //}
             
        protected override void PickAnsestor()
        {
            FormWin.OpenDialog search = new FormWin.OpenDialog
            {
                ModuleForFilter = (this.facade as Fac.ReservationServer).GetAncestorComponentCode(),
                Mode = FormWin.OpenDialog.ActionMode.Search,
            };
            search.ShowDialog(this);
            if (search.IsActionDone)
            {
                this.PopulateCustomerData(search.Document.Module as CustFac.Dto);
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
            return new InvWin.PaymentForm(new ArtfFac.Dto());
        }

        private void form_ArtifactSaved(ArtfFac.Dto document)
        {
            base.RaiseChildArtifactSaved(document);
        }
                            
        protected override void PopulateDataToForm()
        {           
            Fac.FormDto formDto = this.formDto as Fac.FormDto;              
            Fac.Dto dto = this.CloneDto(this.InitialDto) as Fac.Dto;

            //disable the controls if the reservation is checked in or the reservation has been cancelled
            if ((dto.isCheckedIn) || (dto.BookingStatusId == Convert.ToInt64(Status.Canceled)))
                this.DisableFormControls();
            
            if (dto.isCheckedIn)
                txtStatus.Text = "Checked In";
            else if (dto.BookingStatusId == Convert.ToInt64(Status.Open))            
                txtStatus.Text = "Open";            
            else if (dto.BookingStatusId == Convert.ToInt64(Status.Canceled))            
                txtStatus.Text = "Cancel";            

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

                ////populate booking data
                //if (!ValidationRule.IsMinimumDate(dto.BookingFrom))
                //{
                //    dtFrom.Value = dto.BookingFrom;
                //    dtFromTime.Value = dto.BookingFrom;
                //}
                //this.txtDays.Text = dto.NoOfDays == 0 ? String.Empty : dto.NoOfDays.ToString();           
                this.txtRooms.Text = dto.NoOfRooms == 0 ? String.Empty : dto.NoOfRooms.ToString(); 

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

                this.txtMale.Text = dto.NoOfMale == 0 ? String.Empty : dto.NoOfMale.ToString();
                this.txtFemale.Text = dto.NoOfFemale == 0 ? String.Empty : dto.NoOfFemale.ToString();
                this.txtChild.Text = dto.NoOfChild == 0 ? String.Empty : dto.NoOfChild.ToString();
                this.txtInfant.Text = dto.NoOfInfant == 0 ? String.Empty : dto.NoOfInfant.ToString();
                this.txtRemarks.Text = dto.Remark.ToString();
                this.txtReservationNo.Text = dto.ReservationNo;

                if (dto.RoomList != null && dto.RoomList.Count > 0)
                    formDto.SelectedRoomList = dto.RoomList;

                //populate booking data
                if (!ValidationRule.IsMinimumDate(dto.BookingFrom))
                {
                    dtFrom.Value = dto.BookingFrom;
                    dtFromTime.Value = dto.BookingFrom;
                }
                this.txtDays.Text = dto.NoOfDays == 0 ? String.Empty : dto.NoOfDays.ToString();                   

                //this.PopulateRoomListFromDaysAndDateChanged();
            }
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
            this.lstRoomList.DataSource = null;
            this.lstSelectedRoom.DataSource = null;            
            this.txtMale.Text = String.Empty;
            this.txtFemale.Text = String.Empty;
            this.txtChild.Text = String.Empty;
            this.txtInfant.Text = String.Empty;
            this.txtRemarks.Text = String.Empty;


            this.txtStatus.Text = String.Empty;
            this.txtName.Text = String.Empty;
            this.lstContact.DataSource = null;
            this.txtAdds.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            this.txtFilteredRoomCount.Text = String.Empty;
            this.txtAvailableRoomCount.Text = String.Empty;

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
            dto.RoomList = this.lstSelectedRoom.Items.Count == 0 ? null : (List<RoomFac.Dto>)this.lstSelectedRoom.DataSource;        
        }

        protected override Boolean ValidateForm()
        {
            Boolean retVal = true;
            this.errorProvider.Clear();

            if (String.IsNullOrEmpty(this.txtName.Text))
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
            return (this.facade as Fac.ReservationServer).CloneReservaion(source as Fac.Dto);              
        }

        private void SetDefault()
        {
            //set default date format
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

                (this.facade as Fac.ReservationServer).RemoveAllBookedRoom();
                this.FilterAndPopulateRoomList();
            }
        }

        private void PopulateCustomerData(CustFac.Dto customerData)
        {
            (formDto.Dto as Fac.Dto).Customer = customerData;
            this.txtName.Text = customerData.Name;

            this.lstContact.DataSource = customerData.ContactNumberList;
            this.lstContact.DisplayMember = "Name";
            this.lstContact.ValueMember = "Id";
            this.lstContact.SelectedIndex = -1;
            this.txtAdds.Text = customerData.Address;
            this.txtEmail.Text = customerData.Email;
        }

        private void AddRoom()
        {
            if (lstRoomList.SelectedIndex != -1)
            {
                (this.facade as Fac.ReservationServer).RemoveRoomFromAllRoomList((RoomFac.Dto)lstRoomList.SelectedItem);
                this.PopulateRoomList();
            }
        }

        private void RemoveRoom()
        {
            if (lstSelectedRoom.SelectedIndex != -1)
            {
                (this.facade as Fac.ReservationServer).AddRoomToAllRoomList((RoomFac.Dto)lstSelectedRoom.SelectedItem);
                this.PopulateRoomList();
            }
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
         
            if ((formDto.RoomList != null && formDto.RoomList.Count > 0) || (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 0))
            {
                txtFilteredRoomCount.Text = (this.facade as Fac.ReservationServer).GetTotalNoRooms().ToString();

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

            this.lstRoomList.DataSource = null;
            if (formDto.RoomList != null && formDto.RoomList.Count > 0)
            {
                this.lstRoomList.DataSource = formDto.RoomList;
                this.lstRoomList.DisplayMember = "Number";
                this.lstRoomList.ValueMember = "Id";
                this.lstRoomList.SelectedIndex = -1;
            }

            this.lstSelectedRoom.DataSource = null;
            if (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 0)
            {
                this.lstSelectedRoom.DataSource = formDto.SelectedRoomList;
                this.lstSelectedRoom.DisplayMember = "Number";
                this.lstSelectedRoom.ValueMember = "Id";
                this.lstSelectedRoom.SelectedIndex = -1;
            }
        }
       
    }

}
