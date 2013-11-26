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
            errorProvider.Clear();

            if (String.IsNullOrEmpty(this.txtUserId.Text.Trim()))
            {
                errorProvider.SetError(this.txtUserId, "User id cannot be empty");
                this.txtUserId.Focus();
                return;
            }

            if (String.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                errorProvider.SetError(this.txtPassword, "Password cannot be empty");
                this.txtPassword.Focus();
                return;
            }

            Facade.Login.FormDto formDto = new Facade.Login.FormDto
            {
                Dto = new Facade.Account.Dto
                {
                    LoginId = this.txtUserId.Text,
                    Password = this.txtPassword.Text,
                }
            };
            Facade.Login.Server facade = new Facade.Login.Server(formDto);
            facade.Login();
            if (facade.IsError)
            {
                this.lblMessage.Text = facade.DisplayMessageList[0];
            }
            else
            {
                this.IsAuthenticated = true;
                this.CurrentUser = formDto.Dto;
                //Add user to global variable
                this.Close();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
