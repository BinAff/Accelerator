using System;
using System.Text.RegularExpressions;
using BinAff.Utility;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using BinAff.Core;

using Facade = Vanilla.Organization.Facade;


namespace Vanilla.Organization.WinForm
{

    public partial class OrganizationForm : System.Windows.Forms.Form
    {

        private Facade.FormDto formDto;

        private Int64 id = 0;
        private String ImagePath = String.Empty;
        private Byte[] ImageData = null;

        public OrganizationForm()
        {
            InitializeComponent();
        }

        private void OrganizationForm_Load(object sender, EventArgs e)
        {
            this.LoadForm();

            if (this.formDto.Dto != null)
                LoadRecord();
        }

        private void bttnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                String file = String.Empty;
                System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
                open.InitialDirectory = "c:\\";
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    picLogo.Image = new Bitmap(open.FileName);
                    picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    ImagePath = open.FileName;

                    //file = open.FileName;
                    //String text = File.ReadAllText(file);
                    //MessageBox.Show(Converter.ReadFile(ImagePath).Length.ToString());
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        //protected override void btnOk_Click(object sender, EventArgs e)
        //{
        //    if (SaveOrganizationData()) this.Close();
        //}

        private void bttnAddContact_Click(object sender, EventArgs e)
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
                else if (txtStd.Text.Trim().Length < 3)
                {
                    errorProvider.SetError(txtStd, "Entered text cannot be less than 3");
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

        private void bttnRemoveContact_Click(object sender, EventArgs e)
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

        private void bttnAddFax_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ReturnObject<List<Facade.Fax.Dto>> retObj = new ReturnObject<List<Facade.Fax.Dto>>();

            if (String.IsNullOrEmpty(txtFaxNumber.Text.Trim()))
            {
                errorProvider.SetError(txtFaxNumber, "Please enter fax number.");
                txtFaxNumber.Focus();
            }
            else if (!ValidationRule.IsFaxNumber(txtFaxNumber.Text.Trim()))
            {
                errorProvider.SetError(txtFaxNumber, "Entered fax number is invalid.");
                txtFaxNumber.Focus();
            }
            else
            {
                retObj = GetFaxList(txtFaxNumber.Text.Trim(), (List<Facade.Fax.Dto>)lslFax.DataSource);

                if (retObj.HasError())
                    errorProvider.SetError(txtFaxNumber, "Entered fax already exists.");
                else
                {
                    lslFax.DataSource = null;
                    lslFax.DataSource = retObj.Value;
                    lslFax.DisplayMember = "Name";
                    lslFax.SelectedIndex = -1;

                    txtFaxNumber.Text = String.Empty;

                }

            }
        }

        private void bttnRemoveFax_Click(object sender, EventArgs e)
        {
            if (lslFax.SelectedItems.Count == 0) return;

            Boolean blnExists = false;
            List<Facade.Fax.Dto> faxNumberList = new List<Facade.Fax.Dto>();

            List<Facade.Fax.Dto> faxNumberPresentList = (List<Facade.Fax.Dto>)lslFax.DataSource;
            if (faxNumberPresentList != null && lslFax.SelectedItems.Count > 0)
            {
                foreach (Facade.Fax.Dto dto in faxNumberPresentList)
                {
                    blnExists = false;
                    foreach (Facade.Fax.Dto faxDto in lslFax.SelectedItems)
                    {
                        if (dto == faxDto)
                        {
                            blnExists = true;
                            break;
                        }
                    }

                    if (!blnExists) faxNumberList.Add(dto);
                }
            }

            lslFax.DataSource = null;
            if (faxNumberList != null && faxNumberList.Count > 0)
            {
                lslFax.DataSource = faxNumberList;
                lslFax.DisplayMember = "Name";
                lslFax.SelectedIndex = -1;
            }
        }

        private void bttnAddEmail_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ReturnObject<List<Facade.Email.Dto>> retObj = new ReturnObject<List<Facade.Email.Dto>>();

            if (String.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                errorProvider.SetError(txtEmail, "Please enter email.");
                txtEmail.Focus();
            }
            else if (!ValidationRule.IsEmailId(txtEmail.Text.Trim()))
            {
                errorProvider.SetError(txtEmail, "Entered email is invalid.");
                txtEmail.Focus();
            }
            else
            {
                retObj = GetEmailList(txtEmail.Text.Trim(), (List<Facade.Email.Dto>)lstEmail.DataSource);

                if (retObj.HasError())
                    errorProvider.SetError(txtEmail, "Entered email already exists.");
                else
                {
                    lstEmail.DataSource = null;
                    lstEmail.DataSource = retObj.Value;
                    lstEmail.DisplayMember = "Name";
                    lstEmail.SelectedIndex = -1;

                    txtEmail.Text = String.Empty;

                }

            }
        }

        private void bttnRemoveEmail_Click(object sender, EventArgs e)
        {
            if (lstEmail.SelectedItems.Count == 0) return;

            Boolean blnExists = false;
            List<Facade.Email.Dto> emailList = new List<Facade.Email.Dto>();

            List<Facade.Email.Dto> emailPresentList = (List<Facade.Email.Dto>)lstEmail.DataSource;
            if (emailPresentList != null && lstEmail.SelectedItems.Count > 0)
            {
                foreach (Facade.Email.Dto dto in emailPresentList)
                {
                    blnExists = false;
                    foreach (Facade.Email.Dto emailDto in lstEmail.SelectedItems)
                    {
                        if (dto == emailDto)
                        {
                            blnExists = true;
                            break;
                        }
                    }

                    if (!blnExists) emailList.Add(dto);
                }
            }

            lstEmail.DataSource = null;
            if (emailList != null && emailList.Count > 0)
            {
                lstEmail.DataSource = emailList;
                lstEmail.DisplayMember = "Name";
                lstEmail.SelectedIndex = -1;
            }
        }

        protected void LoadForm()
        {
            this.formDto = new Facade.FormDto();
            Facade.Server organization = new Facade.Server(this.formDto);
            organization.LoadForm();

            //populate Type List
            if (this.formDto.StateList != null && this.formDto.StateList.Count > 0)
            {
                this.cboState.DataSource = this.formDto.StateList;
                this.cboState.DisplayMember = "Name";
                this.cboState.ValueMember = "Id";
                this.cboState.SelectedIndex = -1;
            }
        }

        private Boolean ValidateOrganization()
        {
            errorProvider.Clear();

            if (ValidationRule.IsNullOrEmpty(txtName.Text.Trim())) {
                errorProvider.SetError(txtName, "Please enter lodge name.");
                txtName.Focus();
                return false;
            }
            else if (!ValidationRule.IsNullOrEmpty(txtTan.Text.Trim()) && !ValidationRule.IsTANNumber(txtTan.Text.Trim())) {
                errorProvider.SetError(txtTan, "Entered " + txtTan.Text + " is Invalid.");
                txtTan.Focus();
                return false;
            }
            else if (ValidationRule.IsNullOrEmpty(txtAdds.Text.Trim())) {
                errorProvider.SetError(txtAdds, "Please enter lodge address.");
                txtAdds.Focus();
                return false;
            }
            else if (ValidationRule.IsNullOrEmpty(txtCity.Text.Trim())) {
                errorProvider.SetError(txtCity, "Please enter city.");
                txtCity.Focus();
                return false;
            }
            else if (cboState.SelectedIndex == -1)
            {
                errorProvider.SetError(cboState, "Please select a state.");
                cboState.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtPin.Text.Trim()))
            {
                errorProvider.SetError(txtPin, "Please enter pin.");
                txtPin.Focus();
                return false;
            }
            else if (!ValidationRule.IsNullOrEmpty(txtPin.Text.Trim()) && !ValidationRule.IsPinCode(txtPin.Text.Trim())) {
                errorProvider.SetError(txtPin, "Entered pin code is invalid.");
                txtPin.Focus();
                return false;
            }
            else if (lstContact.Items.Count == 0)
            {
                errorProvider.SetError(lstContact, "Please enter contact number.");
                txtLandLine.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtConatcName.Text.Trim()))
            {
                errorProvider.SetError(txtConatcName, "Please enter contact name.");
                txtConatcName.Focus();
                return false;
            }
            else if (!ValidationRule.IsNullOrEmpty(txtTan.Text.Trim()) && !ValidationRule.IsTANNumber(txtTan.Text.Trim())) {
                errorProvider.SetError(txtTan, "Entered Tan number is invalid.");
                txtTan.Focus();
                return false;
            } 


            
            return true;
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
                ContactNumberList.Add(new Facade.ContactNumber.Dto()
                {
                    Name = val
                });
                retObj.Value = ContactNumberList;
            }

            return retObj;
        }

        private ReturnObject<List<Facade.Fax.Dto>> GetFaxList(String val, List<Facade.Fax.Dto> FaxList)
        {
            ReturnObject<List<Facade.Fax.Dto>> retObj = new ReturnObject<List<Facade.Fax.Dto>>()
            {
                Value = new List<Facade.Fax.Dto>()
            };

            if (FaxList == null || FaxList.Count == 0)
                retObj.Value.Add(new Facade.Fax.Dto()
                {
                    Name = val
                });
            else
            {
                foreach (Facade.Fax.Dto dto in FaxList)
                {
                    if (dto.Name.ToUpper() == val.ToUpper())
                    {
                        retObj.Value = FaxList;

                        retObj.MessageList = new List<BinAff.Core.Message>();
                        retObj.MessageList.Add(new BinAff.Core.Message()
                        {
                            Description = "Duplicate",
                            Category = BinAff.Core.Message.Type.Error
                        });
                        return retObj;
                    }
                }
                FaxList.Add(new Facade.Fax.Dto()
                {
                    Name = val
                });
                retObj.Value = FaxList;
            }

            return retObj;
        }

        private ReturnObject<List<Facade.Email.Dto>> GetEmailList(String val, List<Facade.Email.Dto> EmailList)
        {
            ReturnObject<List<Facade.Email.Dto>> retObj = new ReturnObject<List<Facade.Email.Dto>>()
            {
                Value = new List<Facade.Email.Dto>()
            };

            if (EmailList == null || EmailList.Count == 0)
                retObj.Value.Add(new Facade.Email.Dto()
                {
                    Name = val
                });
            else
            {
                foreach (Facade.Email.Dto dto in EmailList)
                {
                    if (dto.Name.ToUpper() == val.ToUpper())
                    {
                        retObj.Value = EmailList;

                        retObj.MessageList = new List<BinAff.Core.Message>();
                        retObj.MessageList.Add(new BinAff.Core.Message()
                        {
                            Description = "Duplicate",
                            Category = BinAff.Core.Message.Type.Error
                        });
                        return retObj;
                    }
                }
                EmailList.Add(new Facade.Email.Dto()
                {
                    Name = val
                });
                retObj.Value = EmailList;
            }

            return retObj;
        }

        private List<Facade.ContactNumber.Dto> GetContactNumberList()
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

        private List<Facade.Fax.Dto> GetFaxList()
        {
            List<Facade.Fax.Dto> faxList = null;

            if (lslFax.DataSource != null && lslFax.Items.Count > 0)
            {
                faxList = new List<Facade.Fax.Dto>();
                foreach (Facade.Fax.Dto dto in lslFax.Items)
                    faxList.Add(dto);
            }
            return faxList;
        }

        private List<Facade.Email.Dto> GetEmailList()
        {
            List<Facade.Email.Dto> emailList = null;

            if (lstEmail.DataSource != null && lstEmail.Items.Count > 0)
            {
                emailList = new List<Facade.Email.Dto>();
                foreach (Facade.Email.Dto dto in lstEmail.Items)
                    emailList.Add(dto);
            }
            return emailList;
        }

        //protected override void Clear()
        //{
        //    this.txtStd.Text = String.Empty;
        //    this.txtLandLine.Text = String.Empty;
        //    this.txtMobile.Text = String.Empty;
        //    this.txtFaxNumber.Text = String.Empty;
        //    this.txtEmail.Text = String.Empty;
        //}

        private Boolean SaveOrganizationData()
        {
            Boolean retVal = false;

            if (ValidateOrganization())
            {
                this.formDto.Dto = new Facade.Dto()
                {
                    Id = this.id,
                    Name = txtName.Text.Trim(),
                    Logo = ImagePath == String.Empty ? ImageData : Reader.ReadFile(ImagePath),
                    LicenceNumber = txtLiscNo.Text.Trim(),
                    Tan = txtTan.Text.Trim(),
                    Address = txtAdds.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    State = new Facade.State.Dto(){
                        Id = ((Facade.State.Dto)cboState.SelectedItem).Id,
                    },                  
                    Pin = Convert.ToInt32(txtPin.Text.Trim()),
                    ContactName = txtConatcName.Text.Trim(),
                    ContactNumberList = GetContactNumberList(),
                    FaxList = GetFaxList(),
                    EmailList = GetEmailList(),

                };
                
                retVal = new Facade.Server(this.formDto).Save().Value;  //This line needs to be removed later -- Biraj

                //base.ShowMessage(ret); //Show message     

                ////Show message
                //if (ret.HasError() || !ret.Value)
                //{
                //    //Show error
                //    StringBuilder str = new StringBuilder();
                //    foreach (BinAff.Core.Message msg in ret.MessageList)
                //    {
                //        str.Append(msg.Description + "\n");
                //    }
                //    MessageBox.Show(str.ToString(), "Error!!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                //}
                //else
                //{
                //    //Show message
                //    MessageBox.Show(ret.MessageList[0].Description, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                //    retVal = true;
                //    Clear();
                //}
            }

            return retVal;
           
        }

        private void LoadRecord()
        {
            if (this.formDto.Dto != null)
            {
                this.id = this.formDto.Dto.Id;
                txtName.Text = this.formDto.Dto.Name;
                this.ImageData = this.formDto.Dto.Logo == null ? null : (byte[])this.formDto.Dto.Logo;

                if (this.ImageData != null)
                {
                    //Initialize image variable
                    Image newImage;
                    //Read image data into a memory stream
                    using (MemoryStream ms = new MemoryStream(this.ImageData, 0, this.ImageData.Length))
                    {
                        ms.Write(this.ImageData, 0, this.ImageData.Length);

                        //Set image variable value using memory stream.
                        newImage = Image.FromStream(ms, true);
                        //set picture
                        this.picLogo.Image = newImage;
                        this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    }
                }


                txtLiscNo.Text = this.formDto.Dto.LicenceNumber;
                txtTan.Text = this.formDto.Dto.Tan;
                txtAdds.Text = this.formDto.Dto.Address;
                txtCity.Text = this.formDto.Dto.City;

                for (int i = 0; i < cboState.Items.Count; i++)
                {
                    if (this.formDto.Dto.State.Id == ((Facade.State.Dto)cboState.Items[i]).Id)
                    {
                        cboState.SelectedIndex = i;
                        break;
                    }
                }

                txtPin.Text = this.formDto.Dto.Pin.ToString();
                txtConatcName.Text = this.formDto.Dto.ContactName;

                lstContact.DataSource = null;
                lstContact.DataSource = this.formDto.Dto.ContactNumberList;
                lstContact.DisplayMember = "Name";
                lstContact.SelectedIndex = -1;

                lslFax.DataSource = null;
                lslFax.DataSource = this.formDto.Dto.FaxList;
                lslFax.DisplayMember = "Name";
                lslFax.SelectedIndex = -1;

                lstEmail.DataSource = null;
                lstEmail.DataSource = this.formDto.Dto.EmailList;
                lstEmail.DisplayMember = "Name";
                lstEmail.SelectedIndex = -1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SaveOrganizationData()) this.Close();
        }

    }

}
