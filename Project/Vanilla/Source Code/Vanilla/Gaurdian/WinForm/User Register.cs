using System;
using System.Windows.Forms;

using PresLib = BinAff.Presentation.Library;

using VanReg = Vanilla.Guardian.Facade.UserRegister;
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
            VanReg.Server facade = new VanReg.Server(this.formDto);
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
            this.txtLoginId.Text = String.Empty;
            this.txtDateOfBirth.Text = String.Empty;
            this.txtName.Text = String.Empty;
            this.lstContact.DataSource = null;
            for (Int32 i = 0; i < this.chkLstRole.Items.Count; i++)
            {
                this.chkLstRole.SetItemChecked(i, false);
            }
            this.grvLoginHistory.DataSource = null;
            this.grvLoginHistory.Refresh();
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
            this.txtLoginId.Text = current.LoginId;
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
            this.grvLoginHistory.AutoGenerateColumns = false;
            this.grvLoginHistory.DataSource = current.LoginHistory;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            DialogResult dig = new Registration().ShowDialog();
            if (registration.IsOkClicked)
            {
                this.LoadForm();
                this.Clear();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Facade.Account.Dto currentAccount = this.cboUser.SelectedItem as Facade.Account.Dto;
            this.formDto.Dto.Id = currentAccount.Id;
            this.formDto.Dto.LoginId = this.txtLoginId.Text.Trim();
            this.formDto.Dto.RoleList = new List<Facade.Role.Dto>();
            foreach (String itemChecked in this.chkLstRole.CheckedItems)
            {
                this.formDto.Dto.RoleList.Add(this.formDto.RoleList.Find((p) => 
                { 
                    return (String.Compare(p.Name, itemChecked) == 0); 
                }));
            }
            VanReg.Server facade = new VanReg.Server(this.formDto);
            facade.Change();
            if (!facade.IsError) currentAccount.RoleList = this.formDto.Dto.RoleList;
            new PresLib.MessageBox
            {
                DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
            this.LoadForm();
            this.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete the record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            this.formDto.Dto = new VanReg.Dto
            {
                Id = (this.cboUser.SelectedItem as VanAcc.Dto).Id,
            };
            VanReg.Server facade = new VanReg.Server(this.formDto);
            facade.Delete();

            if (facade.IsError)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Error",
                }.Show(facade.DisplayMessageList);
            }
            else
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Information,
                    Heading = "Information",
                }.Show(facade.DisplayMessageList);
            }
            this.LoadForm();
            this.Clear();
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
            VanReg.Server facade = new VanReg.Server(this.formDto);
            facade.ResetPassword();
            new PresLib.MessageBox
            {
                DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
        }

    }

}
