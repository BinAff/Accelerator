using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using BinAff.Core;
using BinAff.Utility;

using Vanilla.Customer.Facade;

//using BinAff.Core;

//using AutoTourism.Facade.CustomerManagement;
//using AutoTourism.Facade.Library;
//using BinAff.Utility;
//using AutoTourism.Presentation.Library;

namespace Vanilla.Customer.WinForm
{

    public partial class CustomerForm : System.Windows.Forms.Form
    {
        private Facade.FormDto formDto;

        private System.Drawing.Color MandatoryColor = System.Drawing.Color.FromArgb(255, 255, 240, 240);

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
            this.formDto = new FormDto();
        }

        public CustomerForm(Dto dto)
            : this()
        {
            this.formDto.Dto = dto;
        }

        public CustomerForm(Dto dto, Facade.Rule.Dto customerRuleDto)
            : this(dto)
        {
            this.formDto.Rule = customerRuleDto;

            SetMandatoryRule();
        }

        #endregion

        private void SetMandatoryRule()
        {
            this.IsPinNumberMandatory = this.formDto.Rule.IsPinNumber;
            this.IsEmailMandatory = this.formDto.Rule.IsEmail;
            this.IsIdentityMandatory = this.formDto.Rule.IsIdentityProof;
            this.IsAlternateContactNoMandatory = this.formDto.Rule.IsAlternateContactNumber;
        }

        private void CustomerForm_Load(object sender, System.EventArgs e)
        {
            this.LoadForm();

            if (this.formDto.Dto != null)
                LoadCustomerData();
        }

        private void btnAddContact_Click(object sender, System.EventArgs e)
        {
            errorProvider.Clear();

            ReturnObject<List<Facade.ContactNumber.Dto>> retObj = new ReturnObject<List<Facade.ContactNumber.Dto>>();
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
                    retObj = GetContactNumberList(txtIsd.Text + "-" + txtStd.Text + "-" + txtLandLine.Text, (List<Facade.ContactNumber.Dto>)lstContact.DataSource);

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
                    retObj = GetContactNumberList(txtMobilePrefix.Text + "-" + txtMobile.Text, (List<Facade.ContactNumber.Dto>)lstContact.DataSource);

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
            List<Facade.ContactNumber.Dto> contactNumberList = new List<Facade.ContactNumber.Dto>();

            List<Facade.ContactNumber.Dto> contactNumberPresentList = (List<Facade.ContactNumber.Dto>)lstContact.DataSource;
            if (contactNumberPresentList != null && lstContact.SelectedItems.Count > 0)
            {
                foreach (Facade.ContactNumber.Dto dto in contactNumberPresentList)
                {
                    blnExists = false;
                    foreach (Facade.ContactNumber.Dto contactDto in lstContact.SelectedItems)
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveCustomerData()) this.Close();
        }

        protected void LoadForm()
        {
            Facade.Server customer = new Facade.Server(this.formDto);
            customer.LoadForm();

            if (this.formDto.InitialList != null && this.formDto.InitialList.Count > 0)
            {
                //Populate Initial List
                this.cboInitial.DataSource = this.formDto.InitialList;
                this.cboInitial.DisplayMember = "Name";
                this.cboInitial.ValueMember = "Id";
                this.cboInitial.SelectedIndex = -1;
            }

            if (this.formDto.StateList != null && this.formDto.StateList.Count > 0)
            {
                //Populate State List
                this.cboState.DataSource = this.formDto.StateList;
                this.cboState.DisplayMember = "Name";
                this.cboState.ValueMember = "Id";
                this.cboState.SelectedIndex = -1;
            }

            if (this.formDto.IdentityProofTypeList != null && this.formDto.IdentityProofTypeList.Count > 0)
            {
                //Populate IdentityProof List
                this.cboProofType.DataSource = this.formDto.IdentityProofTypeList;
                this.cboProofType.DisplayMember = "Name";
                this.cboProofType.ValueMember = "Id";
                this.cboProofType.SelectedIndex = -1;
            }
        }

        protected void Clear()
        {
            
        }

        private void LoadCustomerData()
        {
            if (this.formDto.Dto.Initial != null && this.formDto.Dto.Initial.Id > 0)
            {
                for (int i = 0; i < cboInitial.Items.Count; i++)
                {
                    if (this.formDto.Dto.Initial.Id == ((Facade.Initial.Dto)cboInitial.Items[i]).Id)
                    {
                        cboInitial.SelectedIndex = i;
                        break;
                    }
                }
            }

            txtFName.Text = this.formDto.Dto.FirstName;
            txtMName.Text = this.formDto.Dto.MiddleName;
            txtLName.Text = this.formDto.Dto.LastName;
            txtAdds.Text = this.formDto.Dto.Address;

            if (this.formDto.Dto.State != null && this.formDto.Dto.State.Id > 0)
            {
                for (int i = 0; i < cboState.Items.Count; i++)
                {
                    if (this.formDto.Dto.State.Id == ((Facade.State.Dto)cboState.Items[i]).Id)
                    {
                        cboState.SelectedIndex = i;
                        break;
                    }
                }
            }

            txtCity.Text = this.formDto.Dto.City;
            txtPin.Text = this.formDto.Dto.Pin == 0 ? String.Empty : this.formDto.Dto.Pin.ToString();

            if (this.formDto.Dto.ContactNumberList != null && this.formDto.Dto.ContactNumberList.Count > 0)
            {
                this.lstContact.DataSource = this.formDto.Dto.ContactNumberList;
                this.lstContact.DisplayMember = "Name";
                this.lstContact.ValueMember = "Id";
                this.lstContact.SelectedIndex = -1;
            }
            txtEmail.Text = this.formDto.Dto.Email;

            if (this.formDto.Dto.IdentityProofType != null && this.formDto.Dto.IdentityProofType.Id > 0)
            {
                for (int i = 0; i < cboProofType.Items.Count; i++)
                {
                    if (this.formDto.Dto.IdentityProofType.Id == ((Facade.IdentityProofType.Dto)cboProofType.Items[i]).Id)
                    {
                        cboProofType.SelectedIndex = i;
                        break;
                    }
                }
            }

            txtIdentityProofName.Text = this.formDto.Dto.IdentityProofName;
        }

        private ReturnObject<List<Facade.ContactNumber.Dto>> GetContactNumberList(String val, List<Facade.ContactNumber.Dto> ContactNumberList)
        {
            ReturnObject<List<Facade.ContactNumber.Dto>> retObj = new ReturnObject<List<Facade.ContactNumber.Dto>>()
            {
                Value = new List<Facade.ContactNumber.Dto>()
            };

            if (ContactNumberList == null || ContactNumberList.Count == 0)
                retObj.Value.Add(new Facade.ContactNumber.Dto()
                {
                    Name = val
                });
            else
            {
                foreach (Facade.ContactNumber.Dto dto in ContactNumberList)
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
                ContactNumberList.Add(new Facade.ContactNumber.Dto
                {
                    Name = val
                });
                retObj.Value = ContactNumberList;
            }

            return retObj;
        }

        private List<Facade.ContactNumber.Dto> GetContactNumberDtoList()
        {
            List<Facade.ContactNumber.Dto> contactNumberList = null;

            if (lstContact.DataSource != null && lstContact.Items.Count > 0)
            {
                contactNumberList = new List<Facade.ContactNumber.Dto>();
                foreach (Facade.ContactNumber.Dto dto in lstContact.Items)
                    contactNumberList.Add(dto);
            }
            return contactNumberList;
        }

        private Boolean SaveCustomerData()
        {
            Boolean retVal = false;

            if (ValidateCustomer())
            {
                FormDto formDto = new FormDto()
                {
                    Dto = new Dto
                    {
                        Id = this.formDto.Dto == null ? 0 : this.formDto.Dto.Id,
                        Initial = cboInitial.SelectedIndex == -1 ? null : new Facade.Initial.Dto()
                        {
                            Id = ((Facade.Initial.Dto)cboInitial.SelectedItem).Id,
                        },
                        FirstName = txtFName.Text.Trim(),
                        MiddleName = txtMName.Text.Trim(),
                        LastName = txtLName.Text.Trim(),
                        Address = txtAdds.Text.Trim(),
                        State = cboState.SelectedIndex == -1 ? null : new Facade.State.Dto()
                        {
                            Id = ((Facade.State.Dto)cboState.SelectedItem).Id,
                        },
                        City = txtCity.Text.Trim(),
                        Pin = txtPin.Text == String.Empty ? 0 : Convert.ToInt32(txtPin.Text),
                        ContactNumberList = GetContactNumberDtoList(),
                        Email = txtEmail.Text.Trim(),
                        IdentityProofType = cboProofType.SelectedIndex == -1 ? null : new Facade.IdentityProofType.Dto()
                        {
                            Id = ((Facade.IdentityProofType.Dto)cboProofType.SelectedItem).Id,
                        },
                        IdentityProofName = txtIdentityProofName.Text.Trim(),
                    },
                };

                Facade.Server customer = new Facade.Server(formDto);
                ReturnObject<Boolean> ret = customer.Save();
                retVal = ret.Value;
                //base.ShowMessage(ret);//Show message
            }
            return retVal;
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

    }

}
