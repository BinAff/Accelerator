using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;
using BinAff.Presentation.Library.Extension;

using AccFac = Vanilla.Guardian.Facade.Account;
using CustFac = Retinue.Customer.Facade;
using ConfRuleFac = Retinue.Configuration.Rule.Facade;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using UtilFac = Vanilla.Utility.Facade;
using FormWin = Vanilla.Form.WinForm;
using DocFac = Vanilla.Utility.Facade.Document;

namespace Retinue.Customer.WinForm
{

    public partial class CustomerForm : FormWin.Document
    {   

        private Boolean isLoadedFromRoomReservationForm = false;

        #region Constructor

        public CustomerForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
        }
      
        public CustomerForm(CustFac.Dto dto)
            : base()
        {
            InitializeComponent();       
        }

        #endregion  

        private void CustomerForm_Load(object sender, System.EventArgs e)
        {
            base.AncestorName = "...";
            //base.AttachmentName = "...";

            //if loaded form room reservation form , then populate the modules
            //if (this.isLoadedFromRoomReservationForm)
            //{
            //    new Vanilla.Utility.Facade.Module.Server((this.formDto as Facade.FormDto).ModuleFormDto).LoadForm();
            //}

            //DIDN'T CHECK THE IMPACT IF FORM IS OPEN FROM RESERVATION FORM
            //this.LoadForm();
        }

        private void cboNationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNationList.SelectedItem != null)
            {
                new CustFac.Server(base.formDto as Facade.FormDto).LoadStateForCountry(cboNationList.SelectedItem as Table);
                this.cboStateList.Bind((base.formDto as Facade.FormDto).StateList, "Name");
            }
        }

        private void btnAddContact_Click(object sender, System.EventArgs e)
        {
            this.errorProvider.Clear();

            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>();
            if (String.IsNullOrEmpty(this.txtLandLine.Text) && String.IsNullOrEmpty(this.txtMobile.Text))
            {
                this.errorProvider.SetError(this.txtLandLine, "Please enter a contact.");
                this.txtLandLine.Focus();
                return;
            }

            //check landline
            if (!String.IsNullOrEmpty(this.txtLandLine.Text))
            {
                if (String.IsNullOrEmpty(this.txtStd.Text))
                {
                    this.errorProvider.SetError(this.txtStd, "Please enter Code.");
                    this.txtStd.Focus();
                }
                else if (this.txtStd.Text.Trim().Length < 2)
                {
                    this.errorProvider.SetError(this.txtStd, "STD code cannot be less than 2");
                    this.txtStd.Focus();
                }
                else if (!ValidationRule.IsNumeric(this.txtStd.Text))
                {
                    this.errorProvider.SetError(this.txtStd, "Entered " + this.txtStd.Text + " is Invalid.");
                    this.txtStd.Focus();
                }
                else if (this.txtLandLine.Text.Trim().Length < 6)
                {
                    this.errorProvider.SetError(this.txtLandLine, "Entered text cannot be less than 6");
                    this.txtLandLine.Focus();
                }
                else if (!ValidationRule.IsNumeric(this.txtLandLine.Text))
                {
                    this.errorProvider.SetError(this.txtLandLine, "Entered " + this.txtLandLine.Text + " is Invalid.");
                    this.txtLandLine.Focus();
                }
                else //Add the landline number to List
                {
                    String contactNumber = this.txtIsd.Text + "-" + this.txtStd.Text + "-" + this.txtLandLine.Text;
                    if (this.IsDuplicateContactNumber(contactNumber))
                    {
                        this.errorProvider.SetError(this.txtLandLine, "Entered contact number already exists.");
                    }
                    else
                    {
                        this.AddContactNumber(contactNumber);
                        this.txtStd.Text = String.Empty;
                        this.txtLandLine.Text = String.Empty;
                    }
                }
            }

            //check mobile number
            if (!String.IsNullOrEmpty(this.txtMobile.Text))
            {
                if (!ValidationRule.IsNumeric(this.txtMobile.Text))
                {
                    this.errorProvider.SetError(this.txtMobile, "Entered " + this.txtMobile.Text + " is Invalid.");
                    this.txtMobile.Focus();
                }
                else if (this.txtMobile.Text.Trim().Length < 10)
                {
                    this.errorProvider.SetError(this.txtMobile, "Entered text cannot be less than 10");
                    this.txtMobile.Focus();
                }
                else
                {
                    String contactNumber = this.txtMobilePrefix.Text + "-" + this.txtMobile.Text;
                    if (this.IsDuplicateContactNumber(contactNumber))
                    {
                        this.errorProvider.SetError(this.txtMobile, "Entered contact number already exists.");
                        this.txtMobile.Focus();
                    }
                    else
                    {
                        this.AddContactNumber(contactNumber);
                        txtMobile.Text = String.Empty;
                    }
                }
            }
        }

        private void bttnRemove_Click(object sender, EventArgs e)
        {
            if (this.lstContact.SelectedItems.Count == 0) return;
            ((base.formDto as Facade.FormDto).Dto as Facade.Dto).ContactNumberList.Remove(this.lstContact.SelectedItem as Table);
            this.lstContact.Items.Remove(this.lstContact.SelectedItem as Table);
        }

        protected override void Compose()
        {
            base.formDto = new Facade.FormDto
            {
                ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto(),
            };
            base.facade = new CustFac.Server(base.formDto as Facade.FormDto);
        }

        protected override void DisableFormControls()
        {
            base.DisablePickAncestorButton();
            base.DisableAddAncestorButton();
            base.IsEnabledAttchment = false;
        }

        protected override void LoadForm()
        {
            CustFac.FormDto formDto = base.formDto as Facade.FormDto;
            base.facade.LoadForm();
            this.cboNationList.Bind(formDto.CountryList, "Name");
            this.cboIdentityProofType.Bind(formDto.IdentityProofTypeList, "Name");
            
            //Copy document name and populate to names in form
            if (this.formDto.Dto == null || this.formDto.Dto.Id == 0)
            {
                String[] nameToken = this.formDto.Document.FileName.Split(' ');
                switch (nameToken.Length)
                {
                    case 1:
                        this.txtFName.Text = nameToken[0];
                        break;
                    case 2:
                        this.txtFName.Text = nameToken[0];
                        this.txtLName.Text = nameToken[1];
                        break;
                    case 3:
                        this.txtFName.Text = nameToken[0];
                        this.txtMName.Text = nameToken[1];
                        this.txtLName.Text = nameToken[2];
                        break;
                    default:
                        this.txtFName.Text = nameToken[0];
                        this.txtMName.Text = nameToken[1];
                        this.txtLName.Text = nameToken[2];
                        break;
                }
            }
        }

        protected override void PopulateDataToForm()
        {
            CustFac.Dto dto = this.formDto.Dto as CustFac.Dto;

            this.txtFName.Text = dto.FirstName;
            this.txtMName.Text = dto.MiddleName;
            this.txtLName.Text = dto.LastName;
            this.txtAdds.Text = dto.Address;
            if (dto.Country != null) this.cboNationList.SelectedItem = (this.formDto as Facade.FormDto).CountryList.FindLast((p) => { return p.Id == dto.Country.Id; });
            if (this.cboNationList.SelectedItem != null)
            {
                this.cboStateList.SelectedItem = (this.formDto as Facade.FormDto).StateList.FindLast((p) => { return p.Id == dto.State.Id; });
            }
            this.txtCity.Text = dto.City;
            this.txtPin.Text = dto.Pin == 0 ? String.Empty : dto.Pin.ToString();
            this.lstContact.Bind(dto.ContactNumberList, "Name");
            this.txtEmail.Text = dto.Email;
            if (dto.IdentityProofType != null) this.cboIdentityProofType.SelectedItem = (this.formDto as Facade.FormDto).IdentityProofTypeList.FindLast((p) => { return p.Id == dto.IdentityProofType.Id; });
            this.txtIdentityProofName.Text = dto.IdentityProofName;
        }

        protected override void RefreshFormBefore()
        {
            this.errorProvider.Clear();
            this.txtStd.Text = String.Empty;
            this.txtLandLine.Text = String.Empty;
            this.txtMobile.Text = String.Empty;
        }

        protected override void RefreshFormAfter()
        {
            this.txtFName.Focus();
        }

        protected override Boolean ValidateForm()
        {
            errorProvider.Clear();
            //validate mandatory
            if (String.IsNullOrEmpty(txtFName.Text.Trim()))
            {
                errorProvider.SetError(txtFName, "Please enter first name.");
                txtFName.Focus();
                return false;
            }
            else if (!(new Regex(@"^[a-zA-Z\s]*$").IsMatch(txtFName.Text.Trim())))
            {
                errorProvider.SetError(txtFName, "Entered " + txtFName.Text + " is Invalid.");
                txtFName.Focus();
                return false;
            }
            else if (!(new Regex(@"^[a-zA-Z\s]*$").IsMatch(txtMName.Text.Trim())))
            {
                errorProvider.SetError(txtMName, "Entered " + txtMName.Text + " is Invalid.");
                txtMName.Focus();
                return false;
            }
            else if (!(new Regex(@"^[a-zA-Z\s]*$").IsMatch(txtLName.Text.Trim())))
            {
                errorProvider.SetError(txtLName, "Entered " + txtLName.Text + " is Invalid.");
                txtLName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtAdds.Text.Trim()))
            {
                errorProvider.SetError(txtAdds, "Please enter address.");
                txtAdds.Focus();
                return false;
            }
            else if (cboNationList.SelectedIndex == -1)
            {
                errorProvider.SetError(cboNationList, "Please select a nation.");
                cboNationList.Focus();
                return false;
            }
            else if (cboStateList.SelectedIndex == -1)
            {
                errorProvider.SetError(cboStateList, "Please select a state.");
                cboStateList.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                errorProvider.SetError(txtCity, "Please enter city.");
                txtCity.Focus();
                return false;
            }
            else if (!(new Regex(@"^[a-zA-Z]*$").IsMatch(txtCity.Text.Trim())))
            {
                errorProvider.SetError(txtCity, "Entered " + txtCity.Text + " is Invalid.");
                txtCity.Focus();
                return false;
            }

            else if ((base.formDto as Facade.FormDto).RuleDto.IsPinNumber && String.IsNullOrEmpty(txtPin.Text.Trim()))
            {
                errorProvider.SetError(txtPin, "Please enter pin number.");
                txtPin.Focus();
                return false;
            }
            else if ((txtPin.Text.Trim() != String.Empty) && (!ValidationRule.IsPinCode(txtPin.Text.Trim())))
            {
                errorProvider.SetError(txtPin, "Entered pin code is invalid.");
                txtPin.Focus();
                return false;
            }

            else if (lstContact.Items.Count == 0)
            {
                errorProvider.SetError(lstContact, "Please enter contact.");
                return false;
            }
            else if ((base.formDto as Facade.FormDto).RuleDto.IsAlternateContactNumber && lstContact.Items.Count < 2)
            {
                errorProvider.SetError(lstContact, "Please enter alternate contact.");
                return false;
            }
            else if ((base.formDto as Facade.FormDto).RuleDto.IsEmail && String.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                errorProvider.SetError(txtEmail, "Please enter Email.");
                txtEmail.Focus();
                return false;
            }
            else if ((txtEmail.Text.Trim() != String.Empty) && (!ValidationRule.IsEmailId(txtEmail.Text.Trim())))
            {
                errorProvider.SetError(txtEmail, "Entered " + txtEmail.Text + " is Invalid.");
                txtEmail.Focus();
                return false;
            }
            else if ((base.formDto as Facade.FormDto).RuleDto.IsIdentityProof)
            {
                if (String.IsNullOrEmpty(txtIdentityProofName.Text.Trim()))
                {
                    errorProvider.SetError(txtIdentityProofName, "Please enter Identity Proof Name.");
                    txtIdentityProofName.Focus();
                    return false;
                }
                else if (cboIdentityProofType.SelectedIndex == -1)
                {
                    errorProvider.SetError(cboIdentityProofType, "Please enter Identity Proof Type.");
                    cboIdentityProofType.Focus();
                    return false;
                }
            }
            return true;
        }

        protected override void AssignDto()
        {
            if (base.formDto.Dto == null) base.formDto.Dto = new CustFac.Dto();
            CustFac.Dto dto = base.formDto.Dto as CustFac.Dto;

            dto.Id = dto == null ? 0 : dto.Id;
           
            dto.FirstName = txtFName.Text.Trim();
            dto.MiddleName = txtMName.Text.Trim();
            dto.LastName = txtLName.Text.Trim();
            dto.Address = txtAdds.Text.Trim();
            dto.Country = this.cboNationList.SelectedItem as Table;
            dto.State = this.cboStateList.SelectedItem as Table;
            dto.City = txtCity.Text.Trim();
            dto.Pin = txtPin.Text == String.Empty ? 0 : Convert.ToInt32(txtPin.Text);
            dto.ContactNumberList = this.lstContact.RetrieveItems<Table>();
            dto.Email = txtEmail.Text.Trim();
            dto.IdentityProofType = this.cboIdentityProofType.SelectedItem as Table; ;
            dto.IdentityProofName = txtIdentityProofName.Text.Trim();
        }

        protected override Boolean SaveAfter()
        {
            if (this.isLoadedFromRoomReservationForm)
            {
                this.Tag = base.formDto.Dto;
            }
            return true;
        }

        protected override void ClearForm()
        {
            this.formDto.Dto = new CustFac.Dto();
            
            //this.cboInitial.SelectedIndex = -1;
            this.txtFName.Text = String.Empty;
            this.txtMName.Text = String.Empty;
            this.txtLName.Text = String.Empty;
            this.txtAdds.Text = String.Empty;
            this.cboNationList.SelectedIndex = -1;
            this.cboStateList.Items.Clear();
            this.txtCity.Text = String.Empty;
            this.txtPin.Text = String.Empty;
            this.lstContact.Items.Clear();
            this.txtEmail.Text = String.Empty;
            this.cboIdentityProofType.SelectedIndex = -1;
            this.txtIdentityProofName.Text = String.Empty;
        }

        private Boolean IsDuplicateContactNumber(String contactNumber)
        {
            if ((base.formDto as Facade.FormDto).Dto != null)
            {
                List<Table> contactNumberList = ((base.formDto as Facade.FormDto).Dto as Facade.Dto).ContactNumberList;
                return contactNumberList == null ? false : contactNumberList.FindAll((p) =>
                {
                    return String.Compare(p.Name, contactNumber) == 0;
                }).Count > 0;
            }
            return false;
        }

        private void AddContactNumber(String contactNumber)
        {
            Table contact = new Table { Name = contactNumber };
            if ((base.formDto as Facade.FormDto).Dto == null) (base.formDto as Facade.FormDto).Dto = new CustFac.Dto();
            if (((base.formDto as Facade.FormDto).Dto as Facade.Dto).ContactNumberList == null) ((base.formDto as Facade.FormDto).Dto as Facade.Dto).ContactNumberList = new List<Table>();
            ((base.formDto as Facade.FormDto).Dto as Facade.Dto).ContactNumberList.Add(contact);
            if (this.lstContact.Items.Count > 0)
            {
                this.lstContact.Items.Add(contact);
            }
            else
            {
                this.lstContact.Bind(((base.formDto as Facade.FormDto).Dto as Facade.Dto).ContactNumberList, "Name");
            }
        }

    }

}