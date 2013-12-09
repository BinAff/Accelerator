using BinAff.Core;
using BinAff.Facade.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vanilla.Guardian.WinForm
{
    public partial class Profile : Form
    {

        Facade.Profile.FormDto formDto;

        public Profile()
        {
            InitializeComponent();
            this.formDto = new Facade.Profile.FormDto
            {
                Dto = new Facade.Account.Dto
                {
                    Profile = new Facade.Profile.Dto
                    {
                        Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                    },
                }
            };
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            this.LoadForm();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>();
            if (String.IsNullOrEmpty(this.txtLandLine.Text.Trim()) && String.IsNullOrEmpty(this.txtMobile.Text.Trim()))
            {
                this.errorProvider.SetError(this.txtLandLine, "Please enter a contact.");
                this.txtLandLine.Focus();
                return;
            }

            //check landline
            if (!String.IsNullOrEmpty(this.txtLandLine.Text.Trim()))
            {
                //check and validate STD
                if (String.IsNullOrEmpty(this.txtStd.Text.Trim()))
                {
                    this.errorProvider.SetError(this.txtStd, "Please enter Code.");
                    this.txtStd.Focus();
                }
                //Validate STD
                else if (this.txtStd.Text.Trim().Length < 2)
                {
                    this.errorProvider.SetError(this.txtStd, "Entered text cannot be less than 2");
                    this.txtStd.Focus();
                }
                else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtStd.Text.Trim())))
                {
                    errorProvider.SetError(this.txtStd, "Entered " + this.txtStd.Text + " is Invalid.");
                    this.txtStd.Focus();
                }

                else if (this.txtLandLine.Text.Trim().Length < 6)
                {
                    this.errorProvider.SetError(this.txtLandLine, "Entered text cannot be less than 6");
                    this.txtLandLine.Focus();
                }
                else if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtLandLine.Text.Trim())))
                {
                    this.errorProvider.SetError(this.txtLandLine, "Entered " + this.txtLandLine.Text + " is Invalid.");
                    this.txtLandLine.Focus();
                }
                else //Add the landline number to List
                {
                    retObj = this.GetContactNumberList(this.txtIsd.Text + "-" + this.txtStd.Text + "-" + this.txtLandLine.Text, (List<Table>)this.lstContact.DataSource);

                    if (retObj.HasError())
                    {
                        this.errorProvider.SetError(this.txtLandLine, "Entered contact already exists.");
                    }
                    else
                    {
                        this.lstContact.DataSource = null;
                        this.lstContact.DataSource = retObj.Value;
                        this.lstContact.DisplayMember = "Name";
                        this.lstContact.SelectedIndex = -1;

                        this.txtStd.Text = String.Empty;
                        this.txtLandLine.Text = String.Empty;
                    }
                }
            }

            //check mobile number
            if (!String.IsNullOrEmpty(this.txtMobile.Text.Trim()))
            {
                if (!(new Regex(@"^[0-9]*$").IsMatch(this.txtMobile.Text.Trim())))
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
                    retObj = this.GetContactNumberList(this.txtMobilePrefix.Text + "-" + this.txtMobile.Text, (List<Table>)this.lstContact.DataSource);

                    if (retObj.HasError())
                    {
                        this.errorProvider.SetError(this.txtLandLine, "Entered contact already exists.");
                    }
                    else
                    {
                        this.lstContact.DataSource = null;
                        this.lstContact.DataSource = retObj.Value;
                        this.lstContact.DisplayMember = "Name";
                        this.lstContact.SelectedIndex = -1;

                        this.txtMobile.Text = String.Empty;
                    }
                }
            }
        }

        private void bttnRemove_Click(object sender, EventArgs e)
        {
            if (this.lstContact.SelectedItems.Count == 0) return;

            Boolean blnExists = false;
            List<Table> contactNumberList = new List<Table>();

            List<Table> contactNumberPresentList = (List<Table>)this.lstContact.DataSource;
            if (contactNumberPresentList != null && this.lstContact.SelectedItems.Count > 0)
            {
                foreach (Table dto in contactNumberPresentList)
                {
                    blnExists = false;
                    foreach (Table contactDto in this.lstContact.SelectedItems)
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

            this.lstContact.DataSource = null;
            if (contactNumberList != null && contactNumberList.Count > 0)
            {
                this.lstContact.DataSource = contactNumberList;
                this.lstContact.DisplayMember = "Name";
                this.lstContact.SelectedIndex = -1;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new Facade.Profile.Server(formDto);
            facade.LoadForm();

            this.cboInitial.DataSource = this.formDto.InitialList;
            this.cboInitial.DisplayMember = "Name";
            this.cboInitial.ValueMember = "Id";
            if (this.formDto.Dto.Profile.Initial != null)
            {
                for (int i = 0; i < this.cboInitial.Items.Count; i++)
                {
                    if (this.formDto.Dto.Profile.Initial.Id == ((BinAff.Core.Table)cboInitial.Items[i]).Id)
                    {
                        this.cboInitial.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.txtFName.Text = this.formDto.Dto.Profile.FirstName;
            this.txtLName.Text = this.formDto.Dto.Profile.LastName;
            this.txtMName.Text = this.formDto.Dto.Profile.MiddleName;

            this.lstContact.DataSource = this.formDto.Dto.Profile.ContactNumberList;
            this.lstContact.DisplayMember = "Name";
            this.lstContact.ValueMember = "Id";
        }

        private ReturnObject<List<Table>> GetContactNumberList(String val, List<Table> contactNumberList)
        {
            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>
            {
                Value = new List<Table>()
            };

            if (contactNumberList == null || contactNumberList.Count == 0)
            {
                retObj.Value.Add(new Table
                {
                    Name = val
                });
            }
            else
            {
                foreach (Table dto in contactNumberList)
                {
                    if (String.Compare(dto.Name, val, true) == 0)
                    {
                        retObj.Value = contactNumberList;
                        retObj.MessageList = new List<BinAff.Core.Message> 
                        { 
                            new BinAff.Core.Message
                            {
                                Description = "Duplicate",
                                Category = BinAff.Core.Message.Type.Error
                            }, 
                        };
                        return retObj;
                    }
                }
                contactNumberList.Add(new Table
                {
                    Name = val
                });
                retObj.Value = contactNumberList;
            }

            return retObj;
        }

    }
}
