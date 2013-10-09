using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Presentation.Library;
using BinAff.Utility;

namespace Vanilla.Guardian.WinForm
{

    public partial class Registration : Dialog
    {

        Facade.Account.FormDto formDto;

        public Registration()
        {
            InitializeComponent();
        }

        protected override void SubmitData()
        {
            if (this.ValidateUser())
            {
                Facade.Account.Dto accountDto = new Facade.Account.Dto()
                {
                    LoginId = txtUserName.Text,
                    Password = txtPassword.Text,
                    RoleList = new List<Facade.Role.Dto>()
                };

                for (Int32 i = 0; i < this.chkLstRole.CheckedItems.Count; i++)
                {
                    foreach (Facade.Role.Dto dto in this.formDto.RoleList)
                    {
                        if (dto.Name == this.chkLstRole.CheckedItems[i].ToString())
                        {
                            accountDto.RoleList.Add(dto);
                            break;
                        }
                    }
                }

                Facade.Account.Server accountFacade = new Facade.Account.Server(new Facade.Account.FormDto
                {
                    Dto = accountDto,
                });
                accountFacade.Add();
                //Show message
                //new BinAff.Presentation.Library.MessageBox(retVal.MessageList).ShowDialog();
                //base.ShowMessage(retVal); 
                //this.Close();
            }
        }

        protected override void LoadData()
        {
            this.formDto = new Facade.Account.FormDto();
            BinAff.Facade.Library.Server facade = new Facade.Account.Server(formDto);

            this.txtPassword.Text = this.formDto.Rule.DefaultPassword;

            this.BindRoleList(); //Populate Role list
        }

        protected override void ClearData()
        {
            errorProvider.Clear();
            this.txtUserName.Text = String.Empty;
            this.BindRoleList(); //Populate Role list
        }

        private void BindRoleList()
        {
            this.chkLstRole.Items.Clear();
            if (this.formDto.RoleList != null && this.formDto.RoleList.Count > 0)
            {
                foreach (Facade.Role.Dto dto in this.formDto.RoleList)
                {
                    if (dto.Name != "SuperAdmin")
                        this.chkLstRole.Items.Add(dto.Name, false);
                }
            }
        }

        /// <summary>
        /// Client side validation of user registration
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateUser()
        { 
            Boolean retVal = true;
            errorProvider.Clear();
            if (ValidationRule.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorProvider.SetError(txtUserName, "Enter user name.");
                txtUserName.Focus();
                return false;
            }
            else if (!ValidationRule.IsAlphaNumeric(txtUserName.Text.Trim()))
            {
                errorProvider.SetError(txtUserName, "Entered " + txtUserName.Text + " is Invalid.");
                txtUserName.Focus();
                return false;
            }
            else if (this.chkLstRole.CheckedItems.Count <= 0)
            {
                errorProvider.SetError(chkLstRole, "Please select a role.");
                chkLstRole.Focus();
                return false;
            }

            return retVal;

        }

        //private void SetUserRule()
        //{
        //    this.DefaultPassword = this.userRule.DefaultUserPassword;
        //}

    }

}
