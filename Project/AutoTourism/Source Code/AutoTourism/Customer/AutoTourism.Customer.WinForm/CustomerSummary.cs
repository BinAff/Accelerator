using System;
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

        public void LoadForm(Facade.Dto dto)
        {
            Facade.Dto data = dto as Facade.Dto;
            if (data != null)
            {
                this.txtName.Text = data.Name;
                if (data.ContactNumberList != null) this.lstContact.Bind(data.ContactNumberList, "Name");
                this.txtAdds.Text = data.Address + Environment.NewLine
                    + data.City + " - " + data.Pin + Environment.NewLine
                    + data.State.Name + ", " + data.Country.Name;
                this.txtEmail.Text = data.Email;
            }
        }

        public void ClearForm()
        {
            this.txtName.Text = String.Empty;
            this.lstContact.Items.Clear();
            this.txtAdds.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
        }

        public Boolean IsEmpty()
        {
            if (!String.IsNullOrEmpty(this.txtName.Text))
            {
                return false;
            }
            return true;
        }

    }

}
