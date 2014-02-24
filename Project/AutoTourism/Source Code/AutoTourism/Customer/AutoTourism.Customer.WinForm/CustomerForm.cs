﻿using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

using CustomerFacade = AutoTourism.Customer.Facade;
using PresentationLibrary = BinAff.Presentation.Library;
using ConfigurationRuleFacade = AutoTourism.Configuration.Rule.Facade;


namespace AutoTourism.Customer.WinForm
{

    public partial class CustomerForm : PresentationLibrary.Form
    {   

        private System.Drawing.Color MandatoryColor = System.Drawing.Color.FromArgb(255, 255, 240, 240);

        private CustomerFacade.Dto dto;
        private CustomerFacade.FormDto formDto;
        private ConfigurationRuleFacade.CustomerRuleDto customerRule;
        private Boolean isLoadedFromRoomReservationForm = false;

        #region Rule property

        private Boolean _IsPinNumberMandatory = false;
        public Boolean IsPinNumberMandatory
        {
            get {
                return this._IsPinNumberMandatory;
            }
            set {
                this._IsPinNumberMandatory = value;
                if (this._IsPinNumberMandatory)
                    txtPin.BackColor = MandatoryColor;
            }
        }

        private Boolean _IsEmailMandatory = false;
        public Boolean IsEmailMandatory
        {
            get
            {
                return this._IsEmailMandatory;
            }
            set
            {
                this._IsEmailMandatory = value;
                if (this._IsEmailMandatory)
                    txtEmail.BackColor = MandatoryColor;
            }
        }

        private Boolean _IsIdentityMandatory = false;
        public Boolean IsIdentityMandatory
        {
            get
            {
                return this._IsIdentityMandatory;
            }
            set
            {
                this._IsIdentityMandatory = value;
                if (this._IsIdentityMandatory)
                    txtIdentityProofName.BackColor = MandatoryColor;
            }
        }

        private Boolean _IsAlternateContactNoMandatory = false;
        public Boolean IsAlternateContactNoMandatory
        {
            get
            {
                return this._IsAlternateContactNoMandatory;
            }
            set
            {
                this._IsAlternateContactNoMandatory = value;
                if (this._IsAlternateContactNoMandatory)                    
                    lstContact.BackColor = MandatoryColor;
            }
        }

        #endregion

        #region Constructor

        public CustomerForm()
        {
            InitializeComponent();
            this.isLoadedFromRoomReservationForm = true;
        }
      
        public CustomerForm(CustomerFacade.Dto dto)
        {
            InitializeComponent();
            this.dto = dto;  
        }

        #endregion

        private void SetMandatoryRule()
        {
            this.IsPinNumberMandatory = this.customerRule.IsPinNumber;
            this.IsEmailMandatory = this.customerRule.IsEmail;
            this.IsIdentityMandatory = this.customerRule.IsIdentityProof;
            this.IsAlternateContactNoMandatory = this.customerRule.IsAlternateContactNumber;          
        }

        private void CustomerForm_Load(object sender, System.EventArgs e)
        {
            this.formDto = new CustomerFacade.FormDto()
            {
                Dto = this.dto,
                ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
            };

            //if loaded form room reservation form , then populate the modules
            if (this.isLoadedFromRoomReservationForm)
                new Vanilla.Utility.Facade.Module.Server(this.formDto.ModuleFormDto).LoadForm();

            this.LoadForm();

            if (this.dto != null)
                this.LoadCustomerData();
        }

        private void btnAddContact_Click(object sender, System.EventArgs e)
        {
            errorProvider.Clear();

            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>();
            if (String.IsNullOrEmpty(txtLandLine.Text.Trim()) && String.IsNullOrEmpty(txtMobile.Text.Trim()))
            {
                errorProvider.SetError(txtLandLine, "Please enter a contact.");
                txtLandLine.Focus();
                return;
            }

            //check landline
            if (!String.IsNullOrEmpty(txtLandLine.Text.Trim()))
            {
                //check and validate STD
                if (String.IsNullOrEmpty(txtStd.Text.Trim()))
                {
                    errorProvider.SetError(txtStd, "Please enter Code.");
                    txtStd.Focus();
                }
                //Validate STD
                else if (txtStd.Text.Trim().Length < 2)
                {
                    errorProvider.SetError(txtStd, "Entered text cannot be less than 2");
                    txtStd.Focus();
                }
                else if (!(new Regex(@"^[0-9]*$").IsMatch(txtStd.Text.Trim())))
                {
                    errorProvider.SetError(txtStd, "Entered " + txtStd.Text + " is Invalid.");
                    txtStd.Focus();
                }

                else if (txtLandLine.Text.Trim().Length < 6)
                {
                    errorProvider.SetError(txtLandLine, "Entered text cannot be less than 6");
                    txtLandLine.Focus();
                }
                else if (!(new Regex(@"^[0-9]*$").IsMatch(txtLandLine.Text.Trim())))
                {
                    errorProvider.SetError(txtLandLine, "Entered " + txtLandLine.Text + " is Invalid.");
                    txtLandLine.Focus();
                }
                else //Add the landline number to List
                {
                    retObj = GetContactNumberList(txtIsd.Text + "-" + txtStd.Text + "-" + txtLandLine.Text, (List<Table>)lstContact.DataSource);                    

                    if (retObj.HasError())
                        errorProvider.SetError(txtLandLine, "Entered contact already exists.");
                    else
                    {
                        lstContact.DataSource = null;
                        lstContact.DataSource = retObj.Value;
                        lstContact.DisplayMember = "Name";
                        lstContact.SelectedIndex = -1;

                        txtStd.Text = String.Empty;
                        txtLandLine.Text = String.Empty;
                    }
                }
            }

            //check mobile number
            if (!String.IsNullOrEmpty(txtMobile.Text.Trim()))
            {
                if (!(new Regex(@"^[0-9]*$").IsMatch(txtMobile.Text.Trim())))
                {
                    errorProvider.SetError(txtMobile, "Entered " + txtMobile.Text + " is Invalid.");
                    txtMobile.Focus();
                }
                else if (txtMobile.Text.Trim().Length < 10)
                {
                    errorProvider.SetError(txtMobile, "Entered text cannot be less than 10");
                    txtMobile.Focus();
                }
                else
                {
                    retObj = GetContactNumberList(txtMobilePrefix.Text + "-" + txtMobile.Text, (List<Table>)lstContact.DataSource);
                    
                    if (retObj.HasError())
                        errorProvider.SetError(txtLandLine, "Entered contact already exists.");
                    else
                    {
                        lstContact.DataSource = null;
                        lstContact.DataSource = retObj.Value;
                        lstContact.DisplayMember = "Name";
                        lstContact.SelectedIndex = -1;

                        txtMobile.Text = String.Empty;
                    }
                }
            }
        }

        private void bttnRemove_Click(object sender, EventArgs e)
        {
            if (lstContact.SelectedItems.Count == 0) return;

            Boolean blnExists = false;
            List<Table> contactNumberList = new List<Table>();

            List<Table> contactNumberPresentList = (List<Table>)lstContact.DataSource;
            if (contactNumberPresentList != null && lstContact.SelectedItems.Count > 0)
            {
                foreach (Table dto in contactNumberPresentList)
                {
                    blnExists = false;
                    foreach (Table contactDto in lstContact.SelectedItems)
                    {
                        if (dto == contactDto)
                        {
                            blnExists = true;
                            break;
                        }
                    }

                    if (!blnExists) contactNumberList.Add(dto);
                }
            }

            lstContact.DataSource = null;
            if (contactNumberList != null && contactNumberList.Count > 0)
            {
                lstContact.DataSource = contactNumberList;
                lstContact.DisplayMember = "Name";
                lstContact.SelectedIndex = -1;
            }
        }
        
        private void LoadForm()
        {
            CustomerFacade.FormDto formDto = new CustomerFacade.FormDto();
            BinAff.Facade.Library.Server facade = new CustomerFacade.Server(formDto);
            facade.LoadForm();

            this.customerRule = formDto.customerRuleDto;
            SetMandatoryRule();

            if (formDto.IdentityProofTypeList != null && formDto.IdentityProofTypeList.Count > 0)
            {
                //Populate IdentityProof List
                this.cboProofType.DataSource = formDto.IdentityProofTypeList;
                this.cboProofType.DisplayMember = "Name";
                this.cboProofType.ValueMember = "Id";
                this.cboProofType.SelectedIndex = -1;
            }
            if (formDto.InitialList != null && formDto.InitialList.Count > 0)
            {
                //Populate Initial List
                this.cboInitial.DataSource = formDto.InitialList;
                this.cboInitial.DisplayMember = "Name";
                this.cboInitial.ValueMember = "Id";
                this.cboInitial.SelectedIndex = -1;
            }

            if (formDto.StateList != null && formDto.StateList.Count > 0)
            {
                //Populate State List
                this.cboState.DataSource = formDto.StateList;
                this.cboState.DisplayMember = "Name";
                this.cboState.ValueMember = "Id";
                this.cboState.SelectedIndex = -1;
            }

            if (formDto.IdentityProofTypeList != null && formDto.IdentityProofTypeList.Count > 0)
            {
                //Populate IdentityProof List
                this.cboProofType.DataSource = formDto.IdentityProofTypeList;
                this.cboProofType.DisplayMember = "Name";
                this.cboProofType.ValueMember = "Id";
                this.cboProofType.SelectedIndex = -1;
            }

            this.txtArtifactPath.ReadOnly = true;
            if (this.isLoadedFromRoomReservationForm)
                this.txtArtifactPath.Text = new Vanilla.Utility.Facade.Module.Server(null).GetRootLevelModulePath("CUST", this.formDto.ModuleFormDto.FormModuleList, "Form");
            
        }
        
        private void LoadCustomerData()
        {
            if (this.dto.Initial != null && this.dto.Initial.Id > 0)
            {
                for (int i = 0; i < cboInitial.Items.Count; i++)
                {
                    if (this.dto.Initial.Id == ((Table)cboInitial.Items[i]).Id)
                    {
                        cboInitial.SelectedIndex = i;
                        break;
                    }
                }
            }

            txtFName.Text = this.dto.FirstName;
            txtMName.Text = this.dto.MiddleName;
            txtLName.Text = this.dto.LastName;
            txtAdds.Text = this.dto.Address;

            if (this.dto.State != null && this.dto.State.Id > 0)
            {
                for (int i = 0; i < cboState.Items.Count; i++)
                {
                    if (this.dto.State.Id == ((Table)cboState.Items[i]).Id)
                    {
                        cboState.SelectedIndex = i;
                        break;
                    }
                }
            }

            txtCity.Text = this.dto.City;
            txtPin.Text = this.dto.Pin == 0 ? String.Empty : this.dto.Pin.ToString();

            if (this.dto.ContactNumberList != null && this.dto.ContactNumberList.Count > 0)
            {
                this.lstContact.DataSource = this.dto.ContactNumberList;
                this.lstContact.DisplayMember = "Name";
                this.lstContact.ValueMember = "Id";
                this.lstContact.SelectedIndex = -1;
            }
            txtEmail.Text = this.dto.Email;

            if (this.dto.IdentityProofType != null && this.dto.IdentityProofType.Id > 0)
            {
                for (int i = 0; i < cboProofType.Items.Count; i++)
                {
                    if (this.dto.IdentityProofType.Id == ((Table)cboProofType.Items[i]).Id)
                    {
                        cboProofType.SelectedIndex = i;
                        break;
                    }
                }
            }

            txtIdentityProofName.Text = this.dto.IdentityProofName;
        }

        private ReturnObject<List<Table>> GetContactNumberList(String val, List<Table> ContactNumberList)
        {
            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>()
            {
                Value = new List<Table>()
            };

            if (ContactNumberList == null || ContactNumberList.Count == 0)
                retObj.Value.Add(new Table()
                {
                    Name = val
                });
            else
            {
                foreach (Table dto in ContactNumberList)
                {
                    if (dto.Name.ToUpper() == val.ToUpper())
                    {
                        retObj.Value = ContactNumberList;

                        retObj.MessageList = new List<BinAff.Core.Message>();
                        retObj.MessageList.Add(new BinAff.Core.Message()
                        {
                            Description = "Duplicate",
                            Category = BinAff.Core.Message.Type.Error
                        });
                        return retObj;
                    }
                }
                ContactNumberList.Add(new Table()
                {
                    Name = val
                });
                retObj.Value = ContactNumberList;
            }

            return retObj;
        }

        private List<Table> GetContactNumberDtoList()
        {
            List<Table> contactNumberList = null;

            if (lstContact.DataSource != null && lstContact.Items.Count > 0)
            {
                contactNumberList = new List<Table>();
                foreach (Table dto in lstContact.Items)
                    contactNumberList.Add(dto);
            }
            return contactNumberList;
        }

        private Boolean SaveCustomerData()
        {
            Boolean retVal = this.ValidateCustomer();

            if (retVal)
            {
                if (this.dto == null) this.dto = new CustomerFacade.Dto();
                this.dto.Id = this.dto == null ? 0 : this.dto.Id;
                this.dto.Initial = cboInitial.SelectedIndex == -1 ? null : new Table()
                {
                    Id = ((Table)cboInitial.SelectedItem).Id,
                };
                this.dto.FirstName = txtFName.Text.Trim();
                this.dto.MiddleName = txtMName.Text.Trim();
                this.dto.LastName = txtLName.Text.Trim();
                this.dto.Address = txtAdds.Text.Trim();
                this.dto.State = cboState.SelectedIndex == -1 ? null : new Table()
                {
                    Id = ((Table)cboState.SelectedItem).Id,
                };
                this.dto.City = txtCity.Text.Trim();
                this.dto.Pin = txtPin.Text == String.Empty ? 0 : Convert.ToInt32(txtPin.Text);
                this.dto.ContactNumberList = GetContactNumberDtoList();
                this.dto.Email = txtEmail.Text.Trim();
                this.dto.IdentityProofType = cboProofType.SelectedIndex == -1 ? null : new Table()
                {
                    Id = ((Table)cboProofType.SelectedItem).Id,
                };
                this.dto.IdentityProofName = txtIdentityProofName.Text.Trim();
                CustomerFacade.FormDto formDto = new CustomerFacade.FormDto()
                {
                    Dto = this.dto,
                };

                BinAff.Facade.Library.Server facade = new CustomerFacade.Server(formDto);
                if (formDto.Dto.Id == 0)
                {
                    facade.Add();
                }
                else
                {
                    facade.Change();
                }

                if (this.isLoadedFromRoomReservationForm)
                    this.Tag = this.dto;                

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
            Table CreatedBy = new Table
            {
                Id = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                Name = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
            };

            new CustomerFacade.Server(this.formDto).SaveArtifactForCustomer(this.dto, CreatedBy);
            return true;
        }

        private Boolean ValidateCustomer()
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
            else if (cboState.SelectedIndex == -1)
            {
                errorProvider.SetError(cboState, "Please select a state.");
                cboState.Focus();
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

            else if (this.IsPinNumberMandatory && String.IsNullOrEmpty(txtPin.Text.Trim()))
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
            else if (this.IsAlternateContactNoMandatory && lstContact.Items.Count < 2)
            {
                errorProvider.SetError(lstContact, "Please enter alternate contact.");
                return false;
            }
            else if (this.IsEmailMandatory && String.IsNullOrEmpty(txtEmail.Text.Trim()))
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
            else if (this.IsIdentityMandatory)
            {
                if (String.IsNullOrEmpty(txtIdentityProofName.Text.Trim()))
                {
                    errorProvider.SetError(txtIdentityProofName, "Please enter Identity Proof Name.");
                    txtIdentityProofName.Focus();
                    return false;
                }
                else if (cboProofType.SelectedIndex == -1)
                {
                    errorProvider.SetError(cboProofType, "Please enter Identity Proof Type.");
                    cboProofType.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SaveCustomerData())
            {
                if (this.isLoadedFromRoomReservationForm)
                    this.SaveArtifact();

                base.IsModified = true;
                this.Close();
            }
        }
    }

}
