using System;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Presentation.Library.Extension;

using CustFac = Retinue.Customer.Facade;

namespace Retinue.Customer.WinForm
{

    public partial class PersonalInformation : UserControl
    {

        public PersonalInformation()
        {
            InitializeComponent();
        }

        private void PersonalInformation_Load(object sender, EventArgs e)
        {
            LoadForm();
            Clear();
        }

        private void LoadForm()
        {
            if (DesignMode) return;
            CustFac.FormDto formDto = new CustFac.FormDto();
            BinAff.Facade.Library.Server facade = new CustFac.Server(formDto);
            facade.LoadForm();
            CustFac.Dto dto = formDto.Dto as CustFac.Dto;
            //if (ret.Value.DtoList != null && ret.Value.DtoList.Count > 0)
            //{
            //    //Populate Initial List
            //    this.cboCustomer.DataSource = ret.Value.DtoList;
            //    this.cboCustomer.DisplayMember = "FirstName";
            //    this.cboCustomer.ValueMember = "Id";
            //    this.cboCustomer.SelectedIndex = -1;
            //}
            txtName.Text = dto.Name;
            txtAdds.Text = dto.FullAddress;
            txtEmail.Text = dto.Email;
            this.lblIdProofTypeName.Text = dto.IdentityProofType.Name;
            this.txtIdentityProofNo.Text = dto.IdentityProofName;
            //lstContact.DataSource = null;
            if (dto.ContactNumberList != null && dto.ContactNumberList.Count > 0)
            {
                lstContact.Bind(dto.ContactNumberList);
                //lstContact.DataSource = dto.ContactNumberList;
                lstContact.DisplayMember = "Name";
                lstContact.ValueMember = "Id";
                lstContact.SelectedIndex = -1;
            }
        }

        public void Clear()
        {
            this.txtName.Text = String.Empty;
            this.txtAdds.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            this.txtIdentityProofNo.Text = String.Empty;
        }

    }

}
