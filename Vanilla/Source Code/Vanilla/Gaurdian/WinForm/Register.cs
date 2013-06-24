using System;
using System.Text;
using System.Collections.Generic;
//using System.Windows.Forms;

using BinAff.Core;
using BinAff.Presentation.Library;

//using AutoTourism.Facade.Guardian.User;
//using AutoTourism.Presentation.Library;

namespace Vanilla.Guardian.WinForm
{

    public partial class Register : System.Windows.Forms.UserControl
    {
        private Facade.Rule.Dto userRule;
        private Facade.Account.Dto formDto;

        public Register()
        {
            InitializeComponent();
        }

        public Register(Vanilla.Guardian.Facade.Rule.Dto userRuleDto)
        {
            InitializeComponent();
            //this.lblDOB.Enabled = false;

            this.userRule = userRuleDto;            
        }

        private void UserRegister_Load(object sender, EventArgs e)
        {
            LoadForm();
            Clear();
        }
       
        //protected override void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (this.lsvUser.SelectedIndices.Count > 0)
        //    {
        //        //Show message
        //        new MessageBox("Please select a user.", MessageBox.Type.Alert).ShowDialog(this);
        //        return;
        //    }

        //    if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the user.?", "User Delete",
        //                    System.Windows.Forms.MessageBoxButtons.YesNo,
        //                    System.Windows.Forms.MessageBoxIcon.Question)
        //                      == System.Windows.Forms.DialogResult.Yes)
        //    {
        //        //IUser user = new UserServer();
        //        //ReturnObject<Boolean> retVal = user.Delete(((Dto)(this.cboUser.SelectedItem)).Id);

        //        //base.ShowMessage(retVal); //Show message
        //    }
        //    else Clear();
        //}
        
        //protected override void btnAdd_Click(object sender, System.EventArgs e)
        //{
        //    //new UserRegistrationForm(userRule).ShowDialog(this);            
        //    LoadForm();
        //    Clear();
        //}
        
        protected void LoadForm()
        {
            //IUser usr = new UserServer();            
            //this.formDto = usr.LoadForm().Value;

            //Populate user dropdown
            //this.cboUser.DataSource = this.formDto.UserList;
            //this.cboUser.DisplayMember = "LoginId";
            //this.cboUser.ValueMember = "Id";
            //this.cboUser.SelectedIndex = -1;
        }

        private Boolean IsRoleExist(Facade.Role.Dto dto, List<Facade.Role.Dto> dtoList)
        {
            if (dtoList != null && dtoList.Count > 0)
            {
                foreach (Facade.Role.Dto dtoRole in dtoList)
                {
                    if (dto.Id == dtoRole.Id)
                        return true;
                }
            }

            return false;
        }

        protected void Clear()
        {
            //errorProvider.Clear();
            ////this.cboUser.SelectedIndex = -1;
            //this.txtName.Text = String.Empty;
            //this.txtDateOfBirth.Text = String.Empty;
            //this.lstContact.Items.Clear();
            //this.chkLstRole.Items.Clear();

            //if (this.formDto.RoleList != null && this.formDto.RoleList.Count > 0)
            //{
            //    foreach (Facade.Role.Dto dtoRole in this.formDto.RoleList)
            //    {
            //        if (dtoRole.Name != "SuperAdmin")
            //            this.chkLstRole.Items.Add(dtoRole.Name, false);
            //    }
            //}
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            //if (this.cboUser.SelectedIndex == -1)
            //{
            //    //Show message
            //    new MessageBox("Please select a user", MessageBox.Type.Alert).ShowDialog(this);
            //    return;
            //}

            //AutoTourism.Facade.Guardian.User.Dto userDto = new AutoTourism.Facade.Guardian.User.Dto();           
            //userDto.Id = ((AutoTourism.Facade.Guardian.User.Dto)cboUser.SelectedItem).Id;
            //userDto.LoginId = ((AutoTourism.Facade.Guardian.User.Dto)cboUser.SelectedItem).LoginId;
            //userDto.Password = (userRule != null && userRule.DefaultUserPassword != String.Empty) ? userRule.DefaultUserPassword : "infotech@1";
            ////userDto.RoleId = 1; // this is a dummy value. Will not be used inside SP            
                       
            //IUser user = new UserServer();
            //ReturnObject<Boolean> retVal = user.ResetPassword(userDto);
            //if (retVal.Value)
            //    new MessageBox("Password reset to default.", MessageBox.Type.Information).ShowDialog(this);                 
        }

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////clear items
            //txtName.Text = String.Empty;
            //txtDateOfBirth.Text = String.Empty;
            //this.chkLstRole.Items.Clear();
            //this.lstContact.DataSource = null;

            //populate fields
            //Facade.Guardian.User.Dto dto = (Facade.Guardian.User.Dto)cboUser.SelectedItem;
            //if(dto != null)
            //{
            //    if (dto.Profile != null)
            //    {
            //        txtName.Text = dto.Profile.Initial == null ? String.Empty : (dto.Profile.Initial.Name + " ")
            //            + (dto.Profile.FirstName == null ? String.Empty : (dto.Profile.FirstName + " "))
            //            + (dto.Profile.MiddleName == null ? String.Empty : (dto.Profile.MiddleName + " "))
            //            + (dto.Profile.LastName == null ? String.Empty : (dto.Profile.LastName + " "));
            //        txtDateOfBirth.Text = Convert.ToDateTime(dto.Profile.DateOfBirth).ToShortDateString();
            //    }
                               
            //    //this.chkLstRole.Items.Clear();
            //    if (this.formDto.RoleList != null && this.formDto.RoleList.Count > 0)
            //    {
            //        foreach (Facade.Guardian.Role.Dto dtoRole in this.formDto.RoleList)
            //        {
            //            if (dtoRole.Name != "SuperAdmin")
            //                this.chkLstRole.Items.Add(dtoRole.Name, IsRoleExist(dtoRole, dto.RoleList));
            //        }
            //    }

            //    if (dto.ContactNumberList != null && dto.ContactNumberList.Count > 0)
            //    {
            //        this.lstContact.DataSource = dto.ContactNumberList;
            //        this.lstContact.DisplayMember = "ContactNumber";
            //        this.lstContact.SelectedIndex = -1;
            //    }
            //}
        }

        //protected override void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    LoadForm();
        //    Clear();
        //}

        //protected override void btnChange_Click(object sender, EventArgs e)
        //{
        //    //if (this.cboUser.SelectedIndex == -1)
        //    //{
        //    //    //Show message
        //    //    new MessageBox("Please select a user", MessageBox.Type.Alert).ShowDialog(this);
        //    //    return;
        //    //}

        //    //if (ValidateRole())
        //    //{
        //    //    IUser user = new UserServer();
        //    //    Facade.Guardian.User.Dto userDto = (Facade.Guardian.User.Dto)this.cboUser.SelectedItem;
        //    //    userDto.RoleList = new List<Facade.Guardian.Role.Dto>();

        //    //    for (int intCnt = 0; intCnt < this.chkLstRole.CheckedItems.Count; intCnt++)
        //    //    {
        //    //        foreach (Facade.Guardian.Role.Dto roleDto in this.formDto.RoleList)
        //    //        {
        //    //            if (this.chkLstRole.CheckedItems[intCnt].ToString() == roleDto.Name)
        //    //            {
        //    //                userDto.RoleList.Add(roleDto);
        //    //                break;
        //    //            }
        //    //        }                    
        //    //    }
                    

        //    //    ReturnObject<Boolean> ret = user.ChangeRoles((Facade.Guardian.User.Dto)this.cboUser.SelectedItem);
        //    //    base.ShowMessage(ret); //Show message   
        //    //}
        //}

        private Boolean ValidateRole()
        {            
            //errorProvider.Clear();

            //if (this.chkLstRole.CheckedItems.Count <= 0)
            //{
            //    errorProvider.SetError(chkLstRole, "Please select a role.");
            //    chkLstRole.Focus();
            //    return false;
            //}
                
            return true;
        }
    }

}
