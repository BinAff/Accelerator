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
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show(facade.DisplayMessageList);
            }
            else
            {
                this.IsAuthenticated = true;
                this.CurrentUser = formDto.Dto;
                //Add user to global variable
                this.Close();
            }
            
        }

    }

}
