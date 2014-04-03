using System;
using System.Windows.Forms;

using BinAff.Core;

using CustFac = AutoTourism.Customer.Facade;

namespace AutoTourism.Customer.WinForm
{

    public partial class PersonalInformation : Form
    {

        public CustFac.Dto CurrentItem { get; private set; }

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
            //CustFac.ICustomer customer = new CustFac.CustomerServer();
            //ReturnObject<CustFac.FormDto> ret = customer.LoadCustomerRegisterForm();

            //if (ret.Value.DtoList != null && ret.Value.DtoList.Count > 0)
            //{
            //    //Populate Initial List
            //    this.cboCustomer.DataSource = ret.Value.DtoList;
            //    this.cboCustomer.DisplayMember = "FirstName";
            //    this.cboCustomer.ValueMember = "Id";
            //    this.cboCustomer.SelectedIndex = -1;
            //}
            CustFac.FormDto formDto = new CustFac.FormDto();
            BinAff.Facade.Library.Server facade = new CustFac.Server(formDto);
            facade.LoadForm();
            if (formDto.DtoList != null && formDto.DtoList.Count > 0)
            {
                //Populate Initial List
                this.cboCustomer.DataSource = formDto.DtoList;
                this.cboCustomer.DisplayMember = "FirstName";
                this.cboCustomer.ValueMember = "Id";
                this.cboCustomer.SelectedIndex = -1;
            }
        }
        
        private void cboCustomer_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (cboCustomer.SelectedIndex != -1)
            {
                CustFac.Dto dto = (CustFac.Dto)cboCustomer.SelectedItem;
                this.CurrentItem = dto;
                String Name = (dto.Initial == null ? String.Empty : dto.Initial.Name);
                Name += (Name == String.Empty) ? (dto.FirstName == null ? String.Empty : dto.FirstName) : " " + (dto.FirstName == null ? String.Empty : dto.FirstName);
                Name += (Name == String.Empty) ? (dto.MiddleName == null ? String.Empty : dto.MiddleName) : " " + (dto.MiddleName == null ? String.Empty : dto.MiddleName);
                Name += (Name == String.Empty) ? (dto.LastName == null ? String.Empty : dto.LastName) : " " + (dto.LastName == null ? String.Empty : dto.LastName);
                
                txtName.Text = Name;
                txtAdds.Text = dto.Address;
                txtEmail.Text = dto.Email;
                this.lblIdProofTypeName.Text = dto.IdentityProofType.Name;
                this.txtIdentityProofNo.Text = dto.IdentityProofName;

                lstContact.DataSource = null;
                if (dto.ContactNumberList != null && dto.ContactNumberList.Count > 0)
                {
                    lstContact.DataSource = dto.ContactNumberList;
                    lstContact.DisplayMember = "Name";
                    lstContact.ValueMember = "Id";
                    lstContact.SelectedIndex = -1;
                }
            }
        }

        private void Clear()
        {
            this.txtName.Text = String.Empty;
            this.txtAdds.Text = String.Empty;
            this.lstContact.DataSource = null;
            this.txtEmail.Text = String.Empty;
            this.txtIdentityProofNo.Text = String.Empty;
        }

    }

}
