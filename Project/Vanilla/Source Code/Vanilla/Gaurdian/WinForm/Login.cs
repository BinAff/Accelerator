using BinAff.Facade.Cache;
using System;
using System.Windows.Forms;
using PresentationLibrary = BinAff.Presentation.Library;

namespace Vanilla.Guardian.WinForm
{

    public partial class Login : Form
    {

        public Boolean IsAuthenticated { get; private set; }
        public Facade.Account.Dto CurrentUser { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {
                this.TryLogin();
            }
        }

        private Boolean Validate()
        {
            errorProvider.Clear();

            if (String.IsNullOrEmpty(this.txtUserId.Text.Trim()))
            {
                errorProvider.SetError(this.txtUserId, "User id cannot be empty");
                this.txtUserId.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                errorProvider.SetError(this.txtPassword, "Password cannot be empty");
                this.txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void TryLogin()
        {
            Facade.Login.FormDto formDto = new Facade.Login.FormDto
            {
                AccountFormDto = new Facade.Account.FormDto
                {
                    Dto = new Facade.Account.Dto
                    {
                        LoginId = this.txtUserId.Text,
                        Password = this.txtPassword.Text,
                    }
                }
            };
            Facade.Login.Server facade = new Facade.Login.Server(formDto);
            facade.Login();
            if (facade.IsError)
            {
                this.lblMessage.Text = facade.DisplayMessageList[0];
            }
            else //Login Success
            {
                this.IsAuthenticated = true;
                this.CurrentUser = formDto.AccountFormDto.Dto;
                //Add user to global variable
                Server.Current.Cache["User"] = this.CurrentUser;
                //Add Login info to log
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Validate())
            {
                this.TryLogin();
            }
        }

    }

}
