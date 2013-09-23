using System;
//using AutoTourism.Facade.Configuration.Lodge;
//using BinAff.Core;
//using System.Text.RegularExpressions;
//using BinAff.Utility;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
//using AutoTourism.Presentation.Library;

namespace Vanilla.Configuration.Lodge.WinForm
{

    //public partial class Lodge : OkForm
    public partial class Lodge : Form
    {

        private Int64 id = 0;
        private String ImagePath = String.Empty;
        private Byte[] ImageData = null;

        public Lodge()
        {
            InitializeComponent();
        }

        private void Lodge_Load(object sender, EventArgs e)
        {
            //LoadForm();
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
        //    if (SaveLodgeData()) this.Close();
        //}

        private void bttnAddContact_Click(object sender, EventArgs e)
        {
            //errorProvider.Clear();

            //ReturnObject<List<ContactNumberDto>> retObj = new ReturnObject<List<ContactNumberDto>>();
            //if (String.IsNullOrEmpty(txtLandLine.Text.Trim()) && String.IsNullOrEmpty(txtMobile.Text.Trim()))
            //{
            //    errorProvider.SetError(txtLandLine, "Please enter a contact.");
            //    txtLandLine.Focus();
            //    return;
            //}

            ////check landline
            //if (!String.IsNullOrEmpty(txtLandLine.Text.Trim()))
            //{
            //    //check and validate STD
            //    if (String.IsNullOrEmpty(txtStd.Text.Trim()))
            //    {
            //        errorProvider.SetError(txtStd, "Please enter Code.");
            //        txtStd.Focus();
            //    }
            //    //Validate STD
            //    else if (txtStd.Text.Trim().Length < 3)
            //    {
            //        errorProvider.SetError(txtStd, "Entered text cannot be less than 3");
            //        txtStd.Focus();
            //    }
            //    else if (!(new Regex(@"^[0-9]*$").IsMatch(txtStd.Text.Trim())))
            //    {
            //        errorProvider.SetError(txtStd, "Entered " + txtStd.Text + " is Invalid.");
            //        txtStd.Focus();
            //    }

            //    else if (txtLandLine.Text.Trim().Length < 6)
            //    {
            //        errorProvider.SetError(txtLandLine, "Entered text cannot be less than 6");
            //        txtLandLine.Focus();
            //    }
            //    else if (!(new Regex(@"^[0-9]*$").IsMatch(txtLandLine.Text.Trim())))
            //    {
            //        errorProvider.SetError(txtLandLine, "Entered " + txtLandLine.Text + " is Invalid.");
            //        txtLandLine.Focus();
            //    }
            //    else //Add the landline number to List
            //    {
            //        retObj = GetContactNumberList(txtIsd.Text + "-" + txtStd.Text + "-" + txtLandLine.Text, (List<ContactNumberDto>)lstContact.DataSource);

            //        if (retObj.HasError())
            //            errorProvider.SetError(txtLandLine, "Entered contact already exists.");
            //        else
            //        {
            //            lstContact.DataSource = null;
            //            lstContact.DataSource = retObj.Value;
            //            lstContact.DisplayMember = "Name";
            //            lstContact.SelectedIndex = -1;

            //            txtStd.Text = String.Empty;
            //            txtLandLine.Text = String.Empty;
            //        }
            //    }
            //}


            ////check mobile number
            //if (!String.IsNullOrEmpty(txtMobile.Text.Trim()))
            //{
            //    if (!(new Regex(@"^[0-9]*$").IsMatch(txtMobile.Text.Trim())))
            //    {
            //        errorProvider.SetError(txtMobile, "Entered " + txtMobile.Text + " is Invalid.");
            //        txtMobile.Focus();
            //    }
            //    else if (txtMobile.Text.Trim().Length < 10)
            //    {
            //        errorProvider.SetError(txtMobile, "Entered text cannot be less than 10");
            //        txtMobile.Focus();
            //    }
            //    else
            //    {
            //        retObj = GetContactNumberList(txtMobilePrefix.Text + "-" + txtMobile.Text, (List<ContactNumberDto>)lstContact.DataSource);

            //        if (retObj.HasError())
            //            errorProvider.SetError(txtLandLine, "Entered contact already exists.");
            //        else
            //        {
            //            lstContact.DataSource = null;
            //            lstContact.DataSource = retObj.Value;
            //            lstContact.DisplayMember = "Name";
            //            lstContact.SelectedIndex = -1;

            //            txtMobile.Text = String.Empty;
            //        }
            //    }
            //}

        }

        private void bttnRemoveContact_Click(object sender, EventArgs e)
        {
            //if (lstContact.SelectedItems.Count == 0) return;

            //Boolean blnExists = false;
            //List<ContactNumberDto> contactNumberList = new List<ContactNumberDto>();

            //List<ContactNumberDto> contactNumberPresentList = (List<ContactNumberDto>)lstContact.DataSource;
            //if (contactNumberPresentList != null && lstContact.SelectedItems.Count > 0)
            //{
            //    foreach (ContactNumberDto dto in contactNumberPresentList)
            //    {
            //        blnExists = false;
            //        foreach (ContactNumberDto contactDto in lstContact.SelectedItems)
            //        {
            //            if (dto == contactDto)
            //            {
            //                blnExists = true;
            //                break;
            //            }
            //        }

            //        if (!blnExists) contactNumberList.Add(dto);
            //    }
            //}

            //lstContact.DataSource = null;
            //if (contactNumberList != null && contactNumberList.Count > 0)
            //{
            //    lstContact.DataSource = contactNumberList;
            //    lstContact.DisplayMember = "Name";
            //    lstContact.SelectedIndex = -1;
            //}
        }

        private void bttnAddFax_Click(object sender, EventArgs e)
        {
            //errorProvider.Clear();
            //ReturnObject<List<FaxDto>> retObj = new ReturnObject<List<FaxDto>>();

            //if (String.IsNullOrEmpty(txtFaxNumber.Text.Trim()))
            //{
            //    errorProvider.SetError(txtFaxNumber, "Please enter fax number.");
            //    txtFaxNumber.Focus();
            //}
            //else if (!ValidationRule.IsFaxNumber(txtFaxNumber.Text.Trim()))
            //{
            //    errorProvider.SetError(txtFaxNumber, "Entered fax number is invalid.");
            //    txtFaxNumber.Focus();
            //}
            //else
            //{
            //    retObj = GetFaxList(txtFaxNumber.Text.Trim(), (List<FaxDto>)lslFax.DataSource);

            //    if (retObj.HasError())
            //        errorProvider.SetError(txtFaxNumber, "Entered fax already exists.");
            //    else
            //    {
            //        lslFax.DataSource = null;
            //        lslFax.DataSource = retObj.Value;
            //        lslFax.DisplayMember = "Name";
            //        lslFax.SelectedIndex = -1;

            //        txtFaxNumber.Text = String.Empty;

            //    }

            //}
        }

        private void bttnRemoveFax_Click(object sender, EventArgs e)
        {
            //if (lslFax.SelectedItems.Count == 0) return;

            //Boolean blnExists = false;
            //List<FaxDto> faxNumberList = new List<FaxDto>();

            //List<FaxDto> faxNumberPresentList = (List<FaxDto>)lslFax.DataSource;
            //if (faxNumberPresentList != null && lslFax.SelectedItems.Count > 0)
            //{
            //    foreach (FaxDto dto in faxNumberPresentList)
            //    {
            //        blnExists = false;
            //        foreach (FaxDto faxDto in lslFax.SelectedItems)
            //        {
            //            if (dto == faxDto)
            //            {
            //                blnExists = true;
            //                break;
            //            }
            //        }

            //        if (!blnExists) faxNumberList.Add(dto);
            //    }
            //}

            //lslFax.DataSource = null;
            //if (faxNumberList != null && faxNumberList.Count > 0)
            //{
            //    lslFax.DataSource = faxNumberList;
            //    lslFax.DisplayMember = "Name";
            //    lslFax.SelectedIndex = -1;
            //}
        }

        private void bttnAddEmail_Click(object sender, EventArgs e)
        {
            //errorProvider.Clear();
            //ReturnObject<List<EmailDto>> retObj = new ReturnObject<List<EmailDto>>();

            //if (String.IsNullOrEmpty(txtEmail.Text.Trim()))
            //{
            //    errorProvider.SetError(txtEmail, "Please enter email.");
            //    txtEmail.Focus();
            //}
            //else if (!ValidationRule.IsEmailId(txtEmail.Text.Trim()))
            //{
            //    errorProvider.SetError(txtEmail, "Entered email is invalid.");
            //    txtEmail.Focus();
            //}
            //else
            //{
            //    retObj = GetEmailList(txtEmail.Text.Trim(), (List<EmailDto>)lstEmail.DataSource);

            //    if (retObj.HasError())
            //        errorProvider.SetError(txtEmail, "Entered email already exists.");
            //    else
            //    {
            //        lstEmail.DataSource = null;
            //        lstEmail.DataSource = retObj.Value;
            //        lstEmail.DisplayMember = "Name";
            //        lstEmail.SelectedIndex = -1;

            //        txtEmail.Text = String.Empty;

            //    }

            //}
        }

        private void bttnRemoveEmail_Click(object sender, EventArgs e)
        {
            //if (lstEmail.SelectedItems.Count == 0) return;

            //Boolean blnExists = false;
            //List<EmailDto> emailList = new List<EmailDto>();

            //List<EmailDto> emailPresentList = (List<EmailDto>)lstEmail.DataSource;
            //if (emailPresentList != null && lstEmail.SelectedItems.Count > 0)
            //{
            //    foreach (EmailDto dto in emailPresentList)
            //    {
            //        blnExists = false;
            //        foreach (EmailDto emailDto in lstEmail.SelectedItems)
            //        {
            //            if (dto == emailDto)
            //            {
            //                blnExists = true;
            //                break;
            //            }
            //        }

            //        if (!blnExists) emailList.Add(dto);
            //    }
            //}

            //lstEmail.DataSource = null;
            //if (emailList != null && emailList.Count > 0)
            //{
            //    lstEmail.DataSource = emailList;
            //    lstEmail.DisplayMember = "Name";
            //    lstEmail.SelectedIndex = -1;
            //}
        }

        //protected override void LoadForm()
        //{
            //ILodge Lodge = new LodgeServer();
            //ReturnObject<FormDto> ret = Lodge.LoadForm();

            ////populate Type List
            //if (ret.Value.StateList != null && ret.Value.StateList.Count > 0)
            //{
            //    this.cboState.DataSource = ret.Value.StateList;
            //    this.cboState.DisplayMember = "Name";
            //    this.cboState.ValueMember = "Id";
            //    this.cboState.SelectedIndex = -1;
            //}

            //if (ret.Value.Lodge != null)
            //{
            //    this.id = ret.Value.Lodge.Id;
            //    txtName.Text = ret.Value.Lodge.Name;
            //    this.ImageData = ret.Value.Lodge.logo == null ? null : (byte[])ret.Value.Lodge.logo;

            //    if (this.ImageData != null)
            //    {
            //        //Initialize image variable
            //        Image newImage;
            //        //Read image data into a memory stream
            //        using (MemoryStream ms = new MemoryStream(this.ImageData, 0, this.ImageData.Length))
            //        {
            //            ms.Write(this.ImageData, 0, this.ImageData.Length);

            //            //Set image variable value using memory stream.
            //            newImage = Image.FromStream(ms, true);
            //            //set picture
            //            this.picLogo.Image = newImage;
            //            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //        }
            //    }


            //    txtLiscNo.Text = ret.Value.Lodge.LicenceNumber;
            //    txtTan.Text = ret.Value.Lodge.Tan;
            //    txtAdds.Text = ret.Value.Lodge.Address;
            //    txtCity.Text = ret.Value.Lodge.City;

            //    for (int i = 0; i < cboState.Items.Count; i++)
            //    {
            //        if (ret.Value.Lodge.State.Id == ((AutoTourism.Facade.Configuration.State.Dto)cboState.Items[i]).Id)
            //        {
            //            cboState.SelectedIndex = i;
            //            break;
            //        }
            //    }

            //    txtPin.Text = ret.Value.Lodge.Pin.ToString();
            //    txtConatcName.Text = ret.Value.Lodge.ContactName;

            //    lstContact.DataSource = null;
            //    lstContact.DataSource = ret.Value.Lodge.ContactNumberList;
            //    lstContact.DisplayMember = "Name";
            //    lstContact.SelectedIndex = -1;

            //    lslFax.DataSource = null;
            //    lslFax.DataSource = ret.Value.Lodge.FaxList;
            //    lslFax.DisplayMember = "Name";
            //    lslFax.SelectedIndex = -1;

            //    lstEmail.DataSource = null;
            //    lstEmail.DataSource = ret.Value.Lodge.EmailList;
            //    lstEmail.DisplayMember = "Name";
            //    lstEmail.SelectedIndex = -1;
            //}
        //}

        private Boolean ValidateLodge()
        {
            //errorProvider.Clear();

            ////validate mandatory
            //if (String.IsNullOrEmpty(txtName.Text.Trim()))
            //{
            //    errorProvider.SetError(txtName, "Please enter lodge name.");
            //    txtName.Focus();
            //    return false;
            //}
            //else if (!(new Regex(@"^[a-zA-Z_0-9 ]*$").IsMatch(txtName.Text.Trim())))
            //{
            //    errorProvider.SetError(txtName, "Entered " + txtName.Text + " is Invalid.");
            //    txtName.Focus();
            //    return false;
            //}
            //else if (!(new Regex(@"^[a-zA-Z_0-9/]*$").IsMatch(txtLiscNo.Text.Trim())))
            //{
            //    errorProvider.SetError(txtLiscNo, "Entered " + txtLiscNo.Text + " is Invalid.");
            //    txtLiscNo.Focus();
            //    return false;
            //}
            //else if (!String.IsNullOrEmpty(txtTan.Text.Trim()) && !ValidationRule.IsTANNumber(txtTan.Text.Trim()))
            //{
            //    errorProvider.SetError(txtTan, "Entered " + txtTan.Text + " is Invalid.");
            //    txtTan.Focus();
            //    return false;
            //}
            //else if (String.IsNullOrEmpty(txtAdds.Text.Trim()))
            //{
            //    errorProvider.SetError(txtAdds, "Please enter lodge address.");
            //    txtAdds.Focus();
            //    return false;
            //}
            //else if (String.IsNullOrEmpty(txtCity.Text.Trim()))
            //{
            //    errorProvider.SetError(txtCity, "Please enter city.");
            //    txtCity.Focus();
            //    return false;
            //}
            //else if (!(new Regex(@"^[a-zA-Z]*$").IsMatch(txtCity.Text.Trim())))
            //{
            //    errorProvider.SetError(txtCity, "Entered " + txtCity.Text + " is Invalid.");
            //    txtCity.Focus();
            //    return false;
            //}
            //else if (cboState.SelectedIndex == -1)
            //{
            //    errorProvider.SetError(cboState, "Please select a state.");
            //    cboState.Focus();
            //    return false;
            //}
            //else if (String.IsNullOrEmpty(txtPin.Text.Trim()))
            //{
            //    errorProvider.SetError(txtPin, "Please enter pin.");
            //    txtPin.Focus();
            //    return false;
            //}
            //else if (!ValidationRule.IsPinCode(txtPin.Text.Trim()))
            //{
            //    errorProvider.SetError(txtPin, "Entered pin code is invalid.");
            //    txtPin.Focus();
            //    return false;
            //}

            //else if (lstContact.Items.Count == 0)
            //{
            //    errorProvider.SetError(lstContact, "Please enter contact.");
            //    txtLandLine.Focus();
            //    return false;
            //}
            //else if (String.IsNullOrEmpty(txtConatcName.Text.Trim()))
            //{
            //    errorProvider.SetError(txtConatcName, "Please enter contact name.");
            //    txtConatcName.Focus();
            //    return false;
            //}
            //else if (!(new Regex(@"^[a-zA-Z_0-9 ]*$").IsMatch(txtConatcName.Text.Trim())))
            //{
            //    errorProvider.SetError(txtConatcName, "Entered " + txtConatcName.Text + " is Invalid.");
            //    txtConatcName.Focus();
            //    return false;
            //}


            return true;
        }

        //private ReturnObject<List<ContactNumberDto>> GetContactNumberList(String val, List<ContactNumberDto> ContactNumberList)
        //{
        //    ReturnObject<List<ContactNumberDto>> retObj = new ReturnObject<List<ContactNumberDto>>()
        //    {
        //        Value = new List<ContactNumberDto>()
        //    };

        //    if (ContactNumberList == null || ContactNumberList.Count == 0)
        //        retObj.Value.Add(new ContactNumberDto()
        //        {
        //            Name = val
        //        });
        //    else
        //    {
        //        foreach (ContactNumberDto dto in ContactNumberList)
        //        {
        //            if (dto.Name.ToUpper() == val.ToUpper())
        //            {
        //                retObj.Value = ContactNumberList;

        //                retObj.MessageList = new List<BinAff.Core.Message>();
        //                retObj.MessageList.Add(new BinAff.Core.Message()
        //                {
        //                    Description = "Duplicate",
        //                    Category = BinAff.Core.Message.Type.Error
        //                });
        //                return retObj;
        //            }
        //        }
        //        ContactNumberList.Add(new ContactNumberDto()
        //        {
        //            Name = val
        //        });
        //        retObj.Value = ContactNumberList;
        //    }

        //    return retObj;
        //}

        //private ReturnObject<List<FaxDto>> GetFaxList(String val, List<FaxDto> FaxList)
        //{
        //    ReturnObject<List<FaxDto>> retObj = new ReturnObject<List<FaxDto>>()
        //    {
        //        Value = new List<FaxDto>()
        //    };

        //    if (FaxList == null || FaxList.Count == 0)
        //        retObj.Value.Add(new FaxDto()
        //        {
        //            Name = val
        //        });
        //    else
        //    {
        //        foreach (FaxDto dto in FaxList)
        //        {
        //            if (dto.Name.ToUpper() == val.ToUpper())
        //            {
        //                retObj.Value = FaxList;

        //                retObj.MessageList = new List<BinAff.Core.Message>();
        //                retObj.MessageList.Add(new BinAff.Core.Message()
        //                {
        //                    Description = "Duplicate",
        //                    Category = BinAff.Core.Message.Type.Error
        //                });
        //                return retObj;
        //            }
        //        }
        //        FaxList.Add(new FaxDto()
        //        {
        //            Name = val
        //        });
        //        retObj.Value = FaxList;
        //    }

        //    return retObj;
        //}

        //private ReturnObject<List<EmailDto>> GetEmailList(String val, List<EmailDto> EmailList)
        //{
        //    ReturnObject<List<EmailDto>> retObj = new ReturnObject<List<EmailDto>>()
        //    {
        //        Value = new List<EmailDto>()
        //    };

        //    if (EmailList == null || EmailList.Count == 0)
        //        retObj.Value.Add(new EmailDto()
        //        {
        //            Name = val
        //        });
        //    else
        //    {
        //        foreach (EmailDto dto in EmailList)
        //        {
        //            if (dto.Name.ToUpper() == val.ToUpper())
        //            {
        //                retObj.Value = EmailList;

        //                retObj.MessageList = new List<BinAff.Core.Message>();
        //                retObj.MessageList.Add(new BinAff.Core.Message()
        //                {
        //                    Description = "Duplicate",
        //                    Category = BinAff.Core.Message.Type.Error
        //                });
        //                return retObj;
        //            }
        //        }
        //        EmailList.Add(new EmailDto()
        //        {
        //            Name = val
        //        });
        //        retObj.Value = EmailList;
        //    }

        //    return retObj;
        //}

        //private List<ContactNumberDto> GetContactNumberList()
        //{
        //    List<ContactNumberDto> contactNumberList = null;

        //    if (lstContact.DataSource != null && lstContact.Items.Count > 0)
        //    {
        //        contactNumberList = new List<ContactNumberDto>();
        //        foreach (ContactNumberDto dto in lstContact.Items)
        //            contactNumberList.Add(dto);
        //    }
        //    return contactNumberList;
        //}

        //private List<FaxDto> GetFaxList()
        //{
        //    List<FaxDto> faxList = null;

        //    if (lslFax.DataSource != null && lslFax.Items.Count > 0)
        //    {
        //        faxList = new List<FaxDto>();
        //        foreach (FaxDto dto in lslFax.Items)
        //            faxList.Add(dto);
        //    }
        //    return faxList;
        //}

        //private List<EmailDto> GetEmailList()
        //{
        //    List<EmailDto> emailList = null;

        //    if (lstEmail.DataSource != null && lstEmail.Items.Count > 0)
        //    {
        //        emailList = new List<EmailDto>();
        //        foreach (EmailDto dto in lstEmail.Items)
        //            emailList.Add(dto);
        //    }
        //    return emailList;
        //}

        //protected override void Clear()
        //{
        //    this.txtStd.Text = String.Empty;
        //    this.txtLandLine.Text = String.Empty;
        //    this.txtMobile.Text = String.Empty;
        //    this.txtFaxNumber.Text = String.Empty;
        //    this.txtEmail.Text = String.Empty;
        //}

        private Boolean SaveLodgeData()
        {
            Boolean retVal = false;

            //if (ValidateLodge())
            //{
            //    FormDto formDto = new FormDto()
            //    {
            //        Lodge = new Dto()
            //        {
            //            Id = this.id,
            //            Name = txtName.Text.Trim(),
            //            logo = ImagePath == String.Empty ? ImageData : Reader.ReadFile(ImagePath),
            //            LicenceNumber = txtLiscNo.Text.Trim(),
            //            Tan = txtTan.Text.Trim(),
            //            Address = txtAdds.Text.Trim(),
            //            City = txtCity.Text.Trim(),
            //            State = new Facade.Configuration.State.Dto()
            //            {
            //                Id = ((Facade.Configuration.State.Dto)cboState.SelectedItem).Id,
            //            },
            //            Pin = Convert.ToInt32(txtPin.Text.Trim()),
            //            ContactName = txtConatcName.Text.Trim(),
            //            ContactNumberList = GetContactNumberList(),
            //            FaxList = GetFaxList(),
            //            EmailList = GetEmailList(),
            //        },
            //    };


            //    ILodge lodge = new LodgeServer();
            //    ReturnObject<Boolean> ret = lodge.SaveLodge(formDto.Lodge);

            //    base.ShowMessage(ret); //Show message     

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
            //}

            return retVal;
        }

    }

}
