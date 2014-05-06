using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;
using PresLib = BinAff.Presentation.Library;

using CustFac = AutoTourism.Customer.Facade;
using ConfRuleFac = AutoTourism.Configuration.Rule.Facade;
using UtilFac = Vanilla.Utility.Facade;
using FormWin = Vanilla.Form.WinForm;

namespace AutoTourism.Customer.WinForm
{

    public partial class CustomerForm : FormWin.Document
    {   

        private System.Drawing.Color MandatoryColor = System.Drawing.Color.FromArgb(255, 255, 240, 240);

        private CustFac.Dto dto;
        //private CustFac.FormDto formDto;
        private ConfRuleFac.CustomerRuleDto customerRule;
        private Boolean isLoadedFromRoomReservationForm = false;
        private System.Windows.Forms.TreeView trvForm;
        private CustFac.Dto refreshDto;

        #region Rule property

        private Boolean isPinNumberMandatory = false;
        public Boolean IsPinNumberMandatory
        {
            get
            {
                return this.isPinNumberMandatory;
            }
            set
            {
                this.isPinNumberMandatory = value;
                if (this.isPinNumberMandatory)
                {
                    this.txtPin.BackColor = MandatoryColor;
                }
            }
        }

        private Boolean isEmailMandatory = false;
        public Boolean IsEmailMandatory
        {
            get
            {
                return this.isEmailMandatory;
            }
            set
            {
                this.isEmailMandatory = value;
                if (this.isEmailMandatory)
                {
                    this.txtEmail.BackColor = MandatoryColor;
                }
            }
        }

        private Boolean isIdentityMandatory = false;
        public Boolean IsIdentityMandatory
        {
            get
            {
                return this.isIdentityMandatory;
            }
            set
            {
                this.isIdentityMandatory = value;
                if (this.isIdentityMandatory)
                {
                    this.txtIdentityProofName.BackColor = MandatoryColor;
                }
            }
        }

        private Boolean isAlternateContactNoMandatory = false;
        public Boolean IsAlternateContactNoMandatory
        {
            get
            {
                return this.isAlternateContactNoMandatory;
            }
            set
            {
                this.isAlternateContactNoMandatory = value;
                if (this.isAlternateContactNoMandatory)
                {
                    this.lstContact.BackColor = MandatoryColor;
                }
            }
        }

        #endregion

        #region Constructor

        public CustomerForm(System.Windows.Forms.TreeView trvForm)
        {
            InitializeComponent();
            this.isLoadedFromRoomReservationForm = true;
            this.trvForm = trvForm;
        }

        public CustomerForm(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
            this.dto = artifact.Module as CustFac.Dto;
            this.AssignDto();
        }
      
        public CustomerForm(CustFac.Dto dto)
        {
            InitializeComponent();
            this.dto = dto;
            this.AssignDto();
        }

        private void AssignDto()
        {
            if (this.dto.Id > 0)
            {
                this.refreshDto = new CustFac.Dto
                {
                    //Initial = this.dto.Initial == null ? null : new Table
                    //{
                    //    Id = this.dto.Initial.Id,
                    //    Name = this.dto.Initial.Name
                    //},
                    FirstName = this.dto.FirstName,
                    MiddleName = this.dto.MiddleName,
                    LastName = this.dto.LastName,
                    Address = this.dto.Address,
                    State = this.dto.State == null ? null : new Table
                    {
                        Id = this.dto.State.Id,
                        Name = this.dto.State.Name
                    },
                    City = this.dto.City,
                    Pin = this.dto.Pin,
                    ContactNumberList = this.CloneContactNumber(this.dto.ContactNumberList),
                    Email = this.dto.Email,
                    IdentityProofType = this.dto.IdentityProofType == null ? null : new Table
                    {
                        Id = this.dto.IdentityProofType.Id,
                        Name = this.dto.IdentityProofType.Name
                    },
                    IdentityProofName = this.dto.IdentityProofName
                };
            }
        }

        #endregion  

        protected override void Compose()
        {
            base.formDto = new Facade.FormDto
            {
                ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
            };
            base.facade = new CustFac.Server(base.formDto as Facade.FormDto);
        }

        private void SetMandatoryRule()
        {
            this.IsPinNumberMandatory = this.customerRule.IsPinNumber;
            this.IsEmailMandatory = this.customerRule.IsEmail;
            this.IsIdentityMandatory = this.customerRule.IsIdentityProof;
            this.IsAlternateContactNoMandatory = this.customerRule.IsAlternateContactNumber;          
        }

        private void CustomerForm_Load(object sender, System.EventArgs e)
        {
            //if loaded form room reservation form , then populate the modules
            if (this.isLoadedFromRoomReservationForm)
            {
                new Vanilla.Utility.Facade.Module.Server((this.formDto as Facade.FormDto).ModuleFormDto).LoadForm();
            }

            this.LoadForm();

            if (this.dto != null)
            {
                this.LoadCustomerData();
            }
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
                    {
                        errorProvider.SetError(txtLandLine, "Entered contact already exists.");
                    }
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
            CustFac.FormDto formDto = base.formDto as Facade.FormDto;
            base.facade.LoadForm();

            this.customerRule = formDto.RuleDto;
            SetMandatoryRule();

            if (formDto.IdentityProofTypeList != null && formDto.IdentityProofTypeList.Count > 0)
            {
                this.cboProofType.DataSource = formDto.IdentityProofTypeList;
                this.cboProofType.DisplayMember = "Name";
                this.cboProofType.ValueMember = "Id";
                this.cboProofType.SelectedIndex = -1;
            }
            //if (formDto.InitialList != null && formDto.InitialList.Count > 0)
            //{
            //    this.cboInitial.DataSource = formDto.InitialList;
            //    this.cboInitial.DisplayMember = "Name";
            //    this.cboInitial.ValueMember = "Id";
            //    this.cboInitial.SelectedIndex = -1;
            //}
            if (formDto.StateList != null && formDto.StateList.Count > 0)
            {
                this.cboState.DataSource = formDto.StateList;
                this.cboState.DisplayMember = "Name";
                this.cboState.ValueMember = "Id";
                this.cboState.SelectedIndex = -1;
            }
            if (formDto.IdentityProofTypeList != null && formDto.IdentityProofTypeList.Count > 0)
            {
                this.cboProofType.DataSource = formDto.IdentityProofTypeList;
                this.cboProofType.DisplayMember = "Name";
                this.cboProofType.ValueMember = "Id";
                this.cboProofType.SelectedIndex = -1;
            }
            this.txtArtifactPath.ReadOnly = true;
            if (this.isLoadedFromRoomReservationForm)
            {
                this.txtArtifactPath.Text = new Vanilla.Utility.Facade.Module.Server(null).GetRootLevelModulePath("CUST", (this.formDto as Facade.FormDto).ModuleFormDto.FormModuleList, "Form");
            }
            else
            {
                this.txtArtifactPath.Text = this.dto.artifactPath;
            }
        }
        
        private void LoadCustomerData()
        {
            //if (this.dto.Initial != null && this.dto.Initial.Id > 0)
            //{
            //    for (int i = 0; i < cboInitial.Items.Count; i++)
            //    {
            //        if (this.dto.Initial.Id == ((Table)cboInitial.Items[i]).Id)
            //        {
            //            cboInitial.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}
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
            {
                retObj.Value.Add(new Table
                {
                    Name = val
                });
            }
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
                ContactNumberList.Add(new Table
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
                {
                    contactNumberList.Add(dto);
                }
            }
            return contactNumberList;
        }

        private Boolean SaveCustomerData()
        {
            Boolean retVal = this.ValidateCustomer();

            if (retVal)
            {
                if (this.dto == null) this.dto = new CustFac.Dto();
                this.dto.Id = this.dto == null ? 0 : this.dto.Id;
                //this.dto.Initial = cboInitial.SelectedIndex == -1 ? null : new Table()
                //{
                //    Id = ((Table)cboInitial.SelectedItem).Id,
                //};
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
               
                CustFac.FormDto formDto = base.formDto as Facade.FormDto;
                formDto.Dto = this.dto;

                UtilFac.Document.Server facade = new CustFac.Server(formDto);
                if (formDto.Dto.Id == 0)
                {
                    facade.ArtifactDto = (formDto as Vanilla.Utility.Facade.Document.FormDto).Document;
                    facade.Add();
                }
                else
                {
                    facade.Change();
                }

                if (this.isLoadedFromRoomReservationForm)
                {
                    this.Tag = this.dto;
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
            new CustFac.Server(this.formDto as Facade.FormDto).SaveArtifactForCustomer(artifactDto);

            //-Add artifact to customer node
            Int16 customerNodePosition = 0;
            for (int i = 0; i < this.trvForm.Nodes.Count; i++)
            {
                if (this.trvForm.Nodes[i].Text == "Customer")
                    break;

                customerNodePosition++;
            }
            (this.trvForm.Nodes[customerNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto).Artifact.Children.Add(artifactDto);
            artifactDto.Parent = this.trvForm.Nodes[customerNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto;
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
            this.txtStd.Text = String.Empty;
            this.txtLandLine.Text = String.Empty;
            this.txtMobile.Text = String.Empty;

            if (this.dto.Id > 0)
            {
                this.ResetLoad();
            }
            else
            {
                this.Clear();
            }
        }

        private void Clear()
        {
            this.dto = new CustFac.Dto();
            
            //this.cboInitial.SelectedIndex = -1;
            this.txtFName.Text = String.Empty;
            this.txtMName.Text = String.Empty;
            this.txtLName.Text = String.Empty;
            this.txtAdds.Text = String.Empty;
            this.cboState.SelectedIndex = -1;
            this.txtCity.Text = String.Empty;
            this.txtPin.Text = String.Empty;           
            this.lstContact.DataSource = null;
            this.txtEmail.Text = String.Empty;
            this.cboProofType.SelectedIndex = -1;
            this.txtIdentityProofName.Text = String.Empty;
        }

        private void ResetLoad()
        {            
            //this.dto.Initial = this.refreshDto.Initial == null ? null : new Table
            //{
            //    Id = this.dto.Initial.Id,
            //    Name = this.dto.Initial.Name
            //};
            this.dto.FirstName = this.refreshDto.FirstName;
            this.dto.MiddleName = this.refreshDto.MiddleName;
            this.dto.LastName = this.refreshDto.LastName;
            this.dto.Address = this.refreshDto.Address;
            this.dto.State = this.refreshDto.State == null ? null : new Table
            {
                Id = this.refreshDto.State.Id,
                Name = this.refreshDto.State.Name
            };
            this.dto.City = this.refreshDto.City;
            this.dto.Pin = this.refreshDto.Pin;
            this.dto.ContactNumberList = this.CloneContactNumber(this.refreshDto.ContactNumberList);
            this.dto.Email = this.refreshDto.Email;
            this.dto.IdentityProofType = this.refreshDto.IdentityProofType == null ? null : new Table
            {
                Id = this.refreshDto.IdentityProofType.Id,
                Name = this.refreshDto.IdentityProofType.Name
            };
            this.dto.IdentityProofName = this.refreshDto.IdentityProofName;
            this.LoadCustomerData();
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
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SaveCustomerData())
            {
                if (this.isLoadedFromRoomReservationForm)
                {
                    this.SaveArtifact();
                }
                base.IsModified = true;
                this.Close();
            }
        }

    }

}
