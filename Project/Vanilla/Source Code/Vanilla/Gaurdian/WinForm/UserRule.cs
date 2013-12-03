using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vanilla.Guardian.WinForm
{

    public partial class UserRule : Form
    {

        private Facade.Rule.FormDto formDto;

        public UserRule()
        {
            InitializeComponent();
        }

        private void CustomerRule_Load(object sender, EventArgs e)
        {
            this.formDto = new Facade.Rule.FormDto
            {
                Dto = new Facade.Rule.Dto
                {
                    Id = 1,
                }
            };
            Facade.Rule.Server facade = new Facade.Rule.Server(this.formDto);
            facade.LoadForm();
            if (this.formDto.Dto != null)
            {
                this.txtPassword.Text = this.formDto.Dto.DefaultPassword;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.formDto.Dto.DefaultPassword = this.txtPassword.Text.Trim();

            Facade.Rule.Server facade = new Facade.Rule.Server(this.formDto);
            facade.Add();
            new BinAff.Presentation.Library.MessageBox
            {
                DialogueType = facade.IsError ? BinAff.Presentation.Library.MessageBox.Type.Error : BinAff.Presentation.Library.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
            this.Close();
        }

    }

}
