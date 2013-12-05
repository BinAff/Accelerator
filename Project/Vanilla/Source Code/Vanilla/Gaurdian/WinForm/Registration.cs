using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Presentation.Library;
using BinAff.Utility;

namespace Vanilla.Guardian.WinForm
{

    public partial class Registration : System.Windows.Forms.Form
    {

        Facade.Register.FormDto formDto;

        public Registration()
        {
            InitializeComponent();
            this.formDto = new Facade.Register.FormDto
            {
                Dto = new Facade.Register.Dto(),
                RoleList = new List<Facade.Role.Dto>(),
                Rule = new Facade.Rule.Dto(),
            };
        }
        
        private void Registration_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SubmitData();
        }

        protected void LoadData()
        {
            BinAff.Facade.Library.Server facade = new Facade.Register.Server(this.formDto);
            facade.LoadForm();

            this.txtPassword.Text = this.formDto.Rule.DefaultPassword;
            this.BindRoleList();
        }

        protected void Clear()
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
                    {
                        this.chkLstRole.Items.Add(dto.Name, false);
                    }
                }
            }
        }

        protected void SubmitData()
        {
            if (this.ValidateUser())
            {
                this.formDto.Dto.LoginId = txtUserName.Text.Trim();
                this.formDto.Dto.Password = txtPassword.Text;
                this.formDto.Dto.RoleList = new List<Facade.Role.Dto>();                

                for (Int32 i = 0; i < this.chkLstRole.CheckedItems.Count; i++)
                {
                    foreach (Facade.Role.Dto dto in this.formDto.RoleList)
                    {
                        if (dto.Name == this.chkLstRole.CheckedItems[i].ToString())
                        {
                            this.formDto.Dto.RoleList.Add(dto);
                            break;
                        }
                    }
                }

                Facade.Register.Server facade = new Facade.Register.Server(this.formDto);
                facade.Add();
                new MessageBox
                {
                    DialogueType = facade.IsError ? MessageBox.Type.Error : MessageBox.Type.Information,
                    Heading = "Splash",
                }.Show(facade.DisplayMessageList);
                if(!facade.IsError) this.Close();
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
