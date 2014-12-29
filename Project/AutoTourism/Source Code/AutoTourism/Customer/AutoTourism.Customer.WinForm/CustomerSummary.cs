using System.Windows.Forms;

using BinAff.Presentation.Library.Extension;

namespace AutoTourism.Customer.WinForm
{

    public partial class CustomerSummary : UserControl
    {

        public CustomerSummary()
        {
            InitializeComponent();
        }

        public void Load(Facade.Dto dto)
        {
            Facade.Dto data = dto as Facade.Dto;
            if (data != null)
            {
                this.txtName.Text = data.Name;

                this.lstContact.Bind(data.ContactNumberList, "Name");
                this.txtAdds.Text = data.Address;
                this.txtEmail.Text = data.Email;
            }
        }

    }

}
