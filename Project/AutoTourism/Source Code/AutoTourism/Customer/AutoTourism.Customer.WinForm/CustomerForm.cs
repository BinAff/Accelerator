using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

using CustomerFacade = AutoTourism.Customer.Facade;
using PresentationLibrary = BinAff.Presentation.Library;


namespace AutoTourism.Customer.WinForm
{

    public partial class CustomerForm : Form
    {   

        private System.Drawing.Color MandatoryColor = System.Drawing.Color.FromArgb(255, 255, 240, 240);

        private CustomerFacade.Dto customerDto;
        //private AutoTourism.Facade.CustomerManagement.Rule.Dto customerRule;

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
        }

        //public CustomerForm(Dto dto, AutoTourism.Facade.CustomerManagement.Rule.Dto customerRuleDto)
        //{
        //    InitializeComponent();
        //    this.customerDto = dto;
        //    this.customerRule = customerRuleDto;

        //    SetMandatoryRule();
        //}

        //public CustomerForm(Facade.CustomerManagement.Dto data)
        //{
        //    InitializeComponent();
        //    this.customerDto = data;
        //}

        #endregion

        private void SetMandatoryRule()
        {
            //this.IsPinNumberMandatory = this.customerRule.IsPinNumber;
            //this.IsEmailMandatory = this.customerRule.IsEmail;
            //this.IsIdentityMandatory = this.customerRule.IsIdentityProof;
            //this.IsAlternateContactNoMandatory = this.customerRule.IsAlternateContactNumber;
        }

        private void CustomerForm_Load(object sender, System.EventArgs e)
        {
            this.LoadForm();

            //if (this.customerDto != null)
            //    LoadCustomerData();
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
            CustomerFacade.ICustomer customer = new CustomerFacade.CustomerServer();            
            ReturnObject<CustomerFacade.FormDto> ret = customer.LoadForm();

            if (ret.Value.InitialList != null && ret.Value.InitialList.Count > 0)
            {
                //Populate Initial List
                this.cboInitial.DataSource = ret.Value.InitialList;
                this.cboInitial.DisplayMember = "Name";
                this.cboInitial.ValueMember = "Id";
                this.cboInitial.SelectedIndex = -1;
            }

            if (ret.Value.StateList != null && ret.Value.StateList.Count > 0)
            {
                //Populate State List
                this.cboState.DataSource = ret.Value.StateList;
                this.cboState.DisplayMember = "Name";
                this.cboState.ValueMember = "Id";
                this.cboState.SelectedIndex = -1;
            }

            if (ret.Value.IdentityProofTypeList != null && ret.Value.IdentityProofTypeList.Count > 0)
            {
                //Populate IdentityProof List
                this.cboProofType.DataSource = ret.Value.IdentityProofTypeList;
                this.cboProofType.DisplayMember = "Name";
                this.cboProofType.ValueMember = "Id";
                this.cboProofType.SelectedIndex = -1;
            }
        }
        
        private void LoadCustomerData()
        {
            //if (this.customerDto.Initial != null && this.customerDto.Initial.Id > 0)
            //{
            //    for (int i = 0; i < cboInitial.Items.Count; i++)
            //    {
            //        if (this.customerDto.Initial.Id == ((AutoTourism.Facade.Configuration.Initial.Dto)cboInitial.Items[i]).Id)
            //        {
            //            cboInitial.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}

            //txtFName.Text = this.customerDto.FirstName;
            //txtMName.Text = this.customerDto.MiddleName;
            //txtLName.Text = this.customerDto.LastName;
            //txtAdds.Text = this.customerDto.Address;

            //if (this.customerDto.State != null && this.customerDto.State.Id > 0)
            //{
            //    for (int i = 0; i < cboState.Items.Count; i++)
            //    {
            //        if (this.customerDto.State.Id == ((AutoTourism.Facade.Configuration.State.Dto)cboState.Items[i]).Id)
            //        {
            //            cboState.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}

            //txtCity.Text = this.customerDto.City;
            //txtPin.Text = this.customerDto.Pin == 0 ? String.Empty : this.customerDto.Pin.ToString();

            //if (this.customerDto.ContactNumberList != null && this.customerDto.ContactNumberList.Count > 0)
            //{
            //    this.lstContact.DataSource = this.customerDto.ContactNumberList;
            //    this.lstContact.DisplayMember = "Name";
            //    this.lstContact.ValueMember = "Id";
            //    this.lstContact.SelectedIndex = -1;
            //}
            //txtEmail.Text = this.customerDto.Email;

            //if (this.customerDto.IdentityProofType != null && this.customerDto.IdentityProofType.Id > 0)
            //{
            //    for (int i = 0; i < cboProofType.Items.Count; i++)
            //    {
            //        if (this.customerDto.IdentityProofType.Id == ((AutoTourism.Facade.Configuration.IdentityProofType.Dto)cboProofType.Items[i]).Id)
            //        {
            //            cboProofType.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}

            //txtIdentityProofName.Text = this.customerDto.IdentityProofName;
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
            Boolean retVal = false;

            if (ValidateCustomer())
            {
                CustomerFacade.FormDto formDto = new CustomerFacade.FormDto()
                {
                    dto = new CustomerFacade.Dto()
                    {
                        Id = this.customerDto == null ? 0 : this.customerDto.Id,
                        Initial = cboInitial.SelectedIndex == -1 ? null : new Table()
                        {
                            Id = ((Table)cboInitial.SelectedItem).Id,
                        },
                        FirstName = txtFName.Text.Trim(),
                        MiddleName = txtMName.Text.Trim(),
                        LastName = txtLName.Text.Trim(),
                        Address = txtAdds.Text.Trim(),
                        State = cboState.SelectedIndex == -1 ? null : new Table()
                        {
                            Id = ((Table)cboState.SelectedItem).Id,
                        },
                        City = txtCity.Text.Trim(),
                        Pin = txtPin.Text == String.Empty ? 0 : Convert.ToInt32(txtPin.Text),
                        ContactNumberList = GetContactNumberDtoList(),
                        Email = txtEmail.Text.Trim(),
                        IdentityProofType = cboProofType.SelectedIndex == -1 ? null : new Table()
                        {
                            Id = ((Table)cboProofType.SelectedItem).Id,
                        },
                        IdentityProofName = txtIdentityProofName.Text.Trim(),
                    },
                };

                CustomerFacade.ICustomer customer = new CustomerFacade.CustomerServer();
                ReturnObject<Boolean> ret = customer.Save(formDto.dto);
                retVal = ret.Value;               

                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Information,
                    Heading = "Splash",
                }.Show(ret.MessageList);


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

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SaveCustomerData()) this.Close();
        }

    }

}
