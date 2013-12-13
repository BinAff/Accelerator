using System;
using System.Windows.Forms;

using PresLib = BinAff.Presentation.Library;

using VanRegister = Vanilla.Guardian.Facade.UserRegister;
using VanAcc = Vanilla.Guardian.Facade.Account;
using BinAff.Core;
using System.Collections.Generic;

namespace Vanilla.Guardian.WinForm
{

    public partial class UserRegister : Form
    {

        private Facade.UserRegister.FormDto formDto;

        public UserRegister()
        {
            InitializeComponent();
            this.formDto = new Facade.UserRegister.FormDto
            {
                Dto = new Facade.UserRegister.Dto(),
            };
        }

        private void UserRegister_Load(object sender, EventArgs e)
        {
            this.LoadForm();
        }

        private void LoadForm()
        {
            VanRegister.Server facade = new VanRegister.Server(this.formDto);
            facade.LoadForm();

            if (facade.IsError)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show(facade.DisplayMessageList);
            }
            else
            {
                this.BindRole();
                this.BindAccount();
            }
        }

        private void Clear()
        {
            this.txtDateOfBirth.Text = String.Empty;
            this.txtName.Text = String.Empty;
            this.lstContact.DataSource = null;
            for (Int32 i = 0; i < this.chkLstRole.Items.Count; i++)
            {
                this.chkLstRole.SetItemChecked(i, false);
            }
        }

        private void BindRole()
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

        private void BindAccount()
        {
            this.cboUser.DataSource = this.formDto.DtoList;
            this.cboUser.DisplayMember = "LoginId";
            this.cboUser.ValueMember = "Id";
            this.cboUser.SelectedIndex = -1;
        }

        private void cboUser_Click(object sender, EventArgs e)
        {
            this.Clear();
            VanAcc.Dto current = this.cboUser.SelectedItem as VanAcc.Dto;
            this.txtName.Text = current.Profile.Name;
            if (current.Profile.DateOfBirth != null)
            {
                DateTime dateOfBirth = (DateTime)current.Profile.DateOfBirth;
                this.txtDateOfBirth.Text = dateOfBirth.ToShortDateString();
            }

            if (current.Profile.ContactNumberList != null && current.Profile.ContactNumberList.Count > 0)
            {
                this.lstContact.DataSource = current.Profile.ContactNumberList;
                this.lstContact.DisplayMember = "Name";
                this.lstContact.ValueMember = "Id";
            }
            if (current.RoleList != null && current.RoleList.Count > 0)
            {
                Int32 count = this.chkLstRole.Items.Count;
                for (Int32 i = 0; i < count; i++)
                {
                    if (current.RoleList.Find((p) => { return p.Name == this.chkLstRole.Items[i].ToString(); }) != null)
                    {
                        this.chkLstRole.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new Registration().ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Facade.Account.Dto currentAccount = this.cboUser.SelectedItem as Facade.Account.Dto;
            this.formDto.Dto.Id = currentAccount.Id;
            this.formDto.Dto.RoleList = new List<Facade.Role.Dto>();
            foreach (String itemChecked in this.chkLstRole.CheckedItems)
            {
                this.formDto.Dto.RoleList.Add(this.formDto.RoleList.Find((p) => 
                { 
                    return (String.Compare(p.Name, itemChecked) == 0); 
                }));
            }
            VanRegister.Server facade = new VanRegister.Server(this.formDto);
            facade.Change();
            if (!facade.IsError) currentAccount.RoleList = this.formDto.Dto.RoleList;
            new PresLib.MessageBox
            {
                DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadForm();
            this.Clear();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            Facade.Account.Dto currentAccount = this.cboUser.SelectedItem as Facade.Account.Dto;
            this.formDto.Dto.Id = currentAccount.Id;
            VanRegister.Server facade = new VanRegister.Server(this.formDto);
            facade.ResetPassword();
            new PresLib.MessageBox
            {
                DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
        }

    }

}
