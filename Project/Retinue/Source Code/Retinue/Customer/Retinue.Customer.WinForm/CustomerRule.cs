using System;
using System.Windows.Forms;

using CustomerFacadeRule = Retinue.Customer.Facade.Rule;

namespace Retinue.Customer.WinForm
{

    public partial class CustomerRule : Form
    {

        private CustomerFacadeRule.FormDto formDto;

        public CustomerRule()
        {
            InitializeComponent();
        }

        private void CustomerRule_Load(object sender, EventArgs e)
        {
            this.formDto = new CustomerFacadeRule.FormDto
            {
                Dto = new CustomerFacadeRule.Dto
                {
                    Id = 1,
                }
            };
            CustomerFacadeRule.Server facade = new CustomerFacadeRule.Server(this.formDto);
            facade.LoadForm();
            if (this.formDto.Dto != null)
            {
                this.chkIsPin.Checked = this.formDto.Dto.IsPinNumber;
                this.chkIsAltContactNo.Checked = this.formDto.Dto.IsAlternateContactNumber;
                this.chkIsEmail.Checked = this.formDto.Dto.IsEmail;
                this.chkIsIdProof.Checked = this.formDto.Dto.IsIdentityProof;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.formDto.Dto.IsPinNumber = this.chkIsPin.Checked;
            this.formDto.Dto.IsAlternateContactNumber = this.chkIsAltContactNo.Checked;
            this.formDto.Dto.IsEmail = this.chkIsEmail.Checked;
            this.formDto.Dto.IsIdentityProof = this.chkIsIdProof.Checked;

            CustomerFacadeRule.Server facade = new CustomerFacadeRule.Server(this.formDto);
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
