using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

using CustFac = AutoTourism.Customer.Facade;
using ConfRuleFac = AutoTourism.Configuration.Rule.Facade;
using UtilFac = Vanilla.Utility.Facade;
using FormWin = Vanilla.Form.WinForm;
using DocFac = Vanilla.Utility.Facade.Document;

namespace AutoTourism.Customer.WinForm
{

    public partial class CustomerForm : FormWin.Document
    {   

        private ConfRuleFac.CustomerRuleDto customerRule;
        private Boolean isLoadedFromRoomReservationForm = false;
        private System.Windows.Forms.TreeView trvForm;

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
        }
      
        public CustomerForm(CustFac.Dto dto)
        {
            InitializeComponent();       
        }

        #endregion  

        private void CustomerForm_Load(object sender, System.EventArgs e)
        {
            if (DesignMode) return;
            //if loaded form room reservation form , then populate the modules
            //if (this.isLoadedFromRoomReservationForm)
            //{
            //    new Vanilla.Utility.Facade.Module.Server((this.formDto as Facade.FormDto).ModuleFormDto).LoadForm();
            //}

            //DIDN'T CHECK THE IMPACT IF FORM IS OPEN FROM RESERVATION FORM
            //this.LoadForm();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.txtStd.Text = String.Empty;
            this.txtLandLine.Text = String.Empty;
            this.txtMobile.Text = String.Empty;
            base.RefreshFrom();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (base.Save())
            {
                base.Artifact.Module = base.formDto.Dto;
                base.IsModified = true;
                this.Close();
            }
        }

        protected override void Compose()
        {
            base.formDto = new Facade.FormDto
            {
                ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
            };
            base.facade = new CustFac.Server(base.formDto as Facade.FormDto);
        }

        protected override void LoadForm()
        {
            CustFac.FormDto formDto = base.formDto as Facade.FormDto;
            base.facade.LoadForm();

            this.customerRule = formDto.RuleDto;
            this.SetMandatoryRule();

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
                this.cboIdentityProofType.DataSource = formDto.IdentityProofTypeList;
                this.cboIdentityProofType.DisplayMember = "Name";
                this.cboIdentityProofType.ValueMember = "Id";
                this.cboIdentityProofType.SelectedIndex = -1;
            }
            this.txtArtifactPath.ReadOnly = true;
            //if (this.isLoadedFromRoomReservationForm)
            //{
            //    this.txtArtifactPath.Text = new Vanilla.Utility.Facade.Module.Server(null).GetRootLevelModulePath("CUST", (this.formDto as Facade.FormDto).ModuleFormDto.FormModuleList, "Form");
            //}
            //else
            //{
            //    this.txtArtifactPath.Text = this.formDto.Dto.artifactPath;
            //}
        }

        protected override void PopulateDataToForm()
        {
            CustFac.Dto dto = this.formDto.Dto as CustFac.Dto;
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
            this.txtFName.Text = dto.FirstName;
            this.txtMName.Text = dto.MiddleName;
            this.txtLName.Text = dto.LastName;
            this.txtAdds.Text = dto.Address;
            if (dto.State != null && dto.State.Id > 0)
            {
                for (int i = 0; i < cboState.Items.Count; i++)
                {
                    if (dto.State.Id == ((Table)cboState.Items[i]).Id)
                    {
                        this.cboState.SelectedIndex = i;
                        break;
                    }
                }
            }
            this.txtCity.Text = dto.City;
            this.txtPin.Text = dto.Pin == 0 ? String.Empty : dto.Pin.ToString();
            if (dto.ContactNumberList != null && dto.ContactNumberList.Count > 0)
            {
                this.lstContact.DataSource = dto.ContactNumberList;
                this.lstContact.DisplayMember = "Name";
                this.lstContact.ValueMember = "Id";
                this.lstContact.SelectedIndex = -1;
            }
            this.txtEmail.Text = dto.Email;
            if (dto.IdentityProofType != null && dto.IdentityProofType.Id > 0)
            {
                for (int i = 0; i < cboIdentityProofType.Items.Count; i++)
                {
                    if (dto.IdentityProofType.Id == ((Table)cboIdentityProofType.Items[i]).Id)
                    {
                        this.cboIdentityProofType.SelectedIndex = i;
                        break;
                    }
                }
            }
            this.txtIdentityProofName.Text = dto.IdentityProofName;
        }

        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
            CustFac.Dto dto = source as CustFac.Dto;
            if (dto.Id > 0)
            {
                return new CustFac.Dto
                {
                    //Initial = dto.Initial == null ? null : new Table
                    //{
                    //    Id = dto.Initial.Id,
                    //    Name = dto.Initial.Name
                    //},
                    FirstName = dto.FirstName,
                    MiddleName = dto.MiddleName,
                    LastName = dto.LastName,
                    Address = dto.Address,
                    State = dto.State == null ? null : new Table
                    {
                        Id = dto.State.Id,
                        Name = dto.State.Name
                    },
                    City = dto.City,
                    Pin = dto.Pin,
                    ContactNumberList = this.CloneContactNumber(dto.ContactNumberList),
                    Email = dto.Email,
                    IdentityProofType = dto.IdentityProofType == null ? null : new Table
                    {
                        Id = dto.IdentityProofType.Id,
                        Name = dto.IdentityProofType.Name
                    },
                    IdentityProofName = dto.IdentityProofName
                };
            }
            return null;
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
            //this.dto.Initial = cboInitial.SelectedIndex == -1 ? null : new Table()
            //{
            //    Id = ((Table)cboInitial.SelectedItem).Id,
            //};
            dto.FirstName = txtFName.Text.Trim();
            dto.MiddleName = txtMName.Text.Trim();
            dto.LastName = txtLName.Text.Trim();
            dto.Address = txtAdds.Text.Trim();
            dto.State = cboState.SelectedIndex == -1 ? null : new Table()
            {
                Id = ((Table)cboState.SelectedItem).Id,
            };
            dto.City = txtCity.Text.Trim();
            dto.Pin = txtPin.Text == String.Empty ? 0 : Convert.ToInt32(txtPin.Text);
            dto.ContactNumberList = GetContactNumberDtoList();
            dto.Email = txtEmail.Text.Trim();
            dto.IdentityProofType = cboIdentityProofType.SelectedIndex == -1 ? null : new Table()
            {
                Id = ((Table)cboIdentityProofType.SelectedItem).Id,
            };
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
            this.cboState.SelectedIndex = -1;
            this.txtCity.Text = String.Empty;
            this.txtPin.Text = String.Empty;           
            this.lstContact.DataSource = null;
            this.txtEmail.Text = String.Empty;
            this.cboIdentityProofType.SelectedIndex = -1;
            this.txtIdentityProofName.Text = String.Empty;
        }

        protected override void RevertForm()
        {
            CustFac.Dto initialDto = base.InitialDto as CustFac.Dto;
            CustFac.Dto dto = this.formDto.Dto as CustFac.Dto;
            
            //this.dto.Initial = this.refreshDto.Initial == null ? null : new Table
            //{
            //    Id = this.dto.Initial.Id,
            //    Name = this.dto.Initial.Name
            //};
            dto.FirstName = initialDto.FirstName;
            dto.MiddleName = initialDto.MiddleName;
            dto.LastName = initialDto.LastName;
            dto.Address = initialDto.Address;
            dto.State = initialDto.State == null ? null : new Table
            {
                Id = initialDto.State.Id,
                Name = initialDto.State.Name
            };
            dto.City = initialDto.City;
            dto.Pin = initialDto.Pin;
            dto.ContactNumberList = this.CloneContactNumber(initialDto.ContactNumberList);
            dto.Email = initialDto.Email;
            dto.IdentityProofType = initialDto.IdentityProofType == null ? null : new Table
            {
                Id = initialDto.IdentityProofType.Id,
                Name = initialDto.IdentityProofType.Name
            };
            dto.IdentityProofName = initialDto.IdentityProofName;
        }

        private void SetMandatoryRule()
        {
            this.IsPinNumberMandatory = this.customerRule.IsPinNumber;
            this.IsEmailMandatory = this.customerRule.IsEmail;
            this.IsIdentityMandatory = this.customerRule.IsIdentityProof;
            this.IsAlternateContactNoMandatory = this.customerRule.IsAlternateContactNumber;
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

        private ReturnObject<List<Table>> GetContactNumberList(String val, List<Table> ContactNumberList)
        {
            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>()
            {
                Value = new List<Table>()
            };

            if (ContactNumberList == null || ContactNumberList.Count == 0)
            {
                retObj.Value.Add(new Table { Name = val });
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

        private Boolean SaveArtifact()
        {
            this.formDto.Document.Path = this.txtArtifactPath.Text;
            Vanilla.Utility.Facade.Artifact.Dto artifactDto = new Vanilla.Utility.Facade.Artifact.Dto
            {
                Module = this.formDto.Dto,
                Style = Vanilla.Utility.Facade.Artifact.Type.Document,
                AuditInfo = new UtilFac.Artifact.Audit.Dto
                {
                    Version = 1,
                    CreatedBy = new Table
                    {
                        Id = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                        Name = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
                    },
                    CreatedAt = DateTime.Now,
                },
                Category = Vanilla.Utility.Facade.Artifact.Category.Form,
                Path = this.formDto.Document.Path
            };
            new CustFac.Server(this.formDto as Facade.FormDto).SaveArtifactForCustomer(artifactDto);

            //-Add artifact to customer node
            Int16 customerNodePosition = 0;
            for (int i = 0; i < this.trvForm.Nodes.Count; i++)
            {
                if (this.trvForm.Nodes[i].Text == "Customer")
                {
                    break;
                }
                customerNodePosition++;
            }
            (this.trvForm.Nodes[customerNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto).Artifact.Children.Add(artifactDto);
            artifactDto.Parent = this.trvForm.Nodes[customerNodePosition].Tag as Vanilla.Utility.Facade.Module.Dto;
            return true;
        }

    }

}
