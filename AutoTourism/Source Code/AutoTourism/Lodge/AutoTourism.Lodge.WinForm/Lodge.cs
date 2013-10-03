using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;

using LodgeFacade = AutoTourism.Lodge.Facade;

namespace AutoTourism.Lodge.WinForm
{

    public partial class Lodge : Form 
    {

        private AutoTourism.Lodge.Facade.FormDto formDto;

        private Int64 id = 0;
        private String ImagePath = String.Empty;
        private Byte[] ImageData = null;

        public Lodge()
        {
            this.formDto = new LodgeFacade.FormDto();
            InitializeComponent();
        }

        private void Lodge_Load(object sender, EventArgs e)
        {
            this.LoadForm();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SaveLodgeData()) this.Close();
        }
        
        private void bttnAddContact_Click(object sender, EventArgs e)
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
                else if (!ValidationRule.IsTelephoneNumber(txtLandLine.Text.Trim()))
                {
                    errorProvider.SetError(txtLandLine, "Entered " + txtLandLine.Text + " is Invalid.");
                    txtStd.Focus();
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
                if (txtMobile.Text.Trim().Length < 10)
                {
                    errorProvider.SetError(txtMobile, "Entered text cannot be less than 10");
                    txtMobile.Focus();
                }
                else if (!ValidationRule.IsMobileNo(txtMobile.Text.Trim()))
                {
                    errorProvider.SetError(txtMobile, "Entered " + txtMobile.Text + " is Invalid.");
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

        private void bttnRemoveContact_Click(object sender, EventArgs e)
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

        private void bttnAddFax_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>();

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
                retObj = GetFaxList(txtFaxNumber.Text.Trim(), (List<Table>)lslFax.DataSource);

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
            List<Table> faxNumberList = new List<Table>();

            List<Table> faxNumberPresentList = (List<Table>)lslFax.DataSource;
            if (faxNumberPresentList != null && lslFax.SelectedItems.Count > 0)
            {
                foreach (Table dto in faxNumberPresentList)
                {
                    blnExists = false;
                    foreach (Table faxDto in lslFax.SelectedItems)
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
            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>();

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
                retObj = GetEmailList(txtEmail.Text.Trim(), (List<Table>)lstEmail.DataSource);

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
            List<Table> emailList = new List<Table>();

            List<Table> emailPresentList = (List<Table>)lstEmail.DataSource;
            if (emailPresentList != null && lstEmail.SelectedItems.Count > 0)
            {
                foreach (Table dto in emailPresentList)
                {
                    blnExists = false;
                    foreach (Table emailDto in lstEmail.SelectedItems)
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

        private void LoadForm()
        {
            LodgeFacade.Server facade = new LodgeFacade.Server(this.formDto);
            facade.LoadForm();
            if (facade.IsError)
            {
                //Show message
                MessageBox.Show("Error"); //Change
                return;
            }
            
            //populate Type List
            if (this.formDto.StateList != null && this.formDto.StateList.Count > 0)
            {
                this.cboState.DataSource = this.formDto.StateList;
                this.cboState.DisplayMember = "Name";
                this.cboState.ValueMember = "Id";
                this.cboState.SelectedIndex = -1;
            }

            if (this.formDto.Lodge != null)
            {
                this.id = this.formDto.Lodge.Id;
                txtName.Text = this.formDto.Lodge.Name;
                this.ImageData = this.formDto.Lodge.logo == null ? null : (byte[])this.formDto.Lodge.logo;

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

                txtLiscNo.Text = this.formDto.Lodge.LicenceNumber;
                txtTan.Text = this.formDto.Lodge.Tan;
                txtAdds.Text = this.formDto.Lodge.Address;
                txtCity.Text = this.formDto.Lodge.City;

                for (int i = 0; i < cboState.Items.Count; i++)
                {
                    if (this.formDto.Lodge.State.Id == ((Table)cboState.Items[i]).Id)
                    {
                        cboState.SelectedIndex = i;
                        break;
                    }
                }

                txtPin.Text = this.formDto.Lodge.Pin.ToString();
                txtConatcName.Text = this.formDto.Lodge.ContactName;

                lstContact.DataSource = null;
                lstContact.DataSource = this.formDto.Lodge.ContactNumberList;
                lstContact.DisplayMember = "Name";
                lstContact.SelectedIndex = -1;

                lslFax.DataSource = null;
                lslFax.DataSource = this.formDto.Lodge.FaxList;
                lslFax.DisplayMember = "Name";
                lslFax.SelectedIndex = -1;

                lstEmail.DataSource = null;
                lstEmail.DataSource = this.formDto.Lodge.EmailList;
                lstEmail.DisplayMember = "Name";
                lstEmail.SelectedIndex = -1;
            }
        }

        private Boolean ValidateData()
        {
            errorProvider.Clear();

            //validate mandatory
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorProvider.SetError(txtName, "Please enter lodge name.");
                txtName.Focus();
                return false;
            }
            else if (!(new Regex(@"^[a-zA-Z_0-9 ]*$").IsMatch(txtName.Text.Trim())))
            {
                errorProvider.SetError(txtName, "Entered " + txtName.Text + " is Invalid.");
                txtName.Focus();
                return false;
            }
            else if (!(new Regex(@"^[a-zA-Z_0-9/]*$").IsMatch(txtLiscNo.Text.Trim())))
            {
                errorProvider.SetError(txtLiscNo, "Entered " + txtLiscNo.Text + " is Invalid.");
                txtLiscNo.Focus();
                return false;
            }
            else if (!String.IsNullOrEmpty(txtTan.Text.Trim()) && !ValidationRule.IsTANNumber(txtTan.Text.Trim()))
            {
                errorProvider.SetError(txtTan, "Entered " + txtTan.Text + " is Invalid.");
                txtTan.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtAdds.Text.Trim()))
            {
                errorProvider.SetError(txtAdds, "Please enter lodge address.");
                txtAdds.Focus();
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
            else if (!ValidationRule.IsPinCode(txtPin.Text.Trim()))
            {
                errorProvider.SetError(txtPin, "Entered pin code is invalid.");
                txtPin.Focus();
                return false;
            }

            else if (lstContact.Items.Count == 0)
            {
                errorProvider.SetError(lstContact, "Please enter contact.");
                txtLandLine.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtConatcName.Text.Trim()))
            {
                errorProvider.SetError(txtConatcName, "Please enter contact name.");
                txtConatcName.Focus();
                return false;
            }
            else if (!(new Regex(@"^[a-zA-Z_0-9 ]*$").IsMatch(txtConatcName.Text.Trim())))
            {
                errorProvider.SetError(txtConatcName, "Entered " + txtConatcName.Text + " is Invalid.");
                txtConatcName.Focus();
                return false;
            }

            return true;
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
                        retObj.MessageList.Add(new BinAff.Core.Message
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

        private ReturnObject<List<Table>> GetFaxList(String val, List<Table> FaxList)
        {
            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>
            {
                Value = new List<Table>()
            };

            if (FaxList == null || FaxList.Count == 0)
                retObj.Value.Add(new Table
                {
                    Name = val
                });
            else
            {
                foreach (Table dto in FaxList)
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
                FaxList.Add(new Table
                {
                    Name = val
                });
                retObj.Value = FaxList;
            }

            return retObj;
        }

        private ReturnObject<List<Table>> GetEmailList(String val, List<Table> EmailList)
        {
            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>
            {
                Value = new List<Table>()
            };

            if (EmailList == null || EmailList.Count == 0)
                retObj.Value.Add(new Table
                {
                    Name = val
                });
            else
            {
                foreach (Table dto in EmailList)
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
                EmailList.Add(new Table
                {
                    Name = val
                });
                retObj.Value = EmailList;
            }

            return retObj;
        }

        private List<Table> GetContactNumberList()
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

        private List<Table> GetFaxList()
        {
            List<Table> faxList = null;

            if (lslFax.DataSource != null && lslFax.Items.Count > 0)
            {
                faxList = new List<Table>();
                foreach (Table dto in lslFax.Items)
                    faxList.Add(dto);
            }
            return faxList;
        }

        private List<Table> GetEmailList()
        {
            List<Table> emailList = null;

            if (lstEmail.DataSource != null && lstEmail.Items.Count > 0)
            {
                emailList = new List<Table>();
                foreach (Table dto in lstEmail.Items)
                    emailList.Add(dto);
            }
            return emailList;
        }

        private void Clear()
        {
            this.txtStd.Text = String.Empty;
            this.txtLandLine.Text = String.Empty;
            this.txtMobile.Text = String.Empty;
            this.txtFaxNumber.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
        }

        private Boolean SaveLodgeData()
        {
            if (ValidateData())
            {
                this.formDto = new LodgeFacade.FormDto
                {
                    Lodge = new LodgeFacade.Dto
                    {
                        Id = this.id,
                        Name = txtName.Text.Trim(),
                        logo = ImagePath == String.Empty ? ImageData : Reader.ReadFile(ImagePath),
                        LicenceNumber = txtLiscNo.Text.Trim(),
                        Tan = txtTan.Text.Trim(),
                        Address = txtAdds.Text.Trim(),
                        City = txtCity.Text.Trim(),
                        State = new Table
                        {
                            Id = (cboState.SelectedItem as Table).Id,
                        },
                        Pin = Convert.ToInt32(txtPin.Text.Trim()),
                        ContactName = txtConatcName.Text.Trim(),
                        ContactNumberList = GetContactNumberList(),
                        FaxList = GetFaxList(),
                        EmailList = GetEmailList(),
                    },
                };

                LodgeFacade.Server facade = new LodgeFacade.Server(this.formDto);
                facade.Add();
                if (facade.IsError)
                {
                    //Show message
                    MessageBox.Show(this, "Error");//Change
                    return false;
                }
                else
                {
                    MessageBox.Show(this, "Data saved successfully", "Splash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return true;
        }

    }

}
