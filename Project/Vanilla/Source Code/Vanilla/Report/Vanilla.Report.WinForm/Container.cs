using System;
using System.Windows.Forms;

using BinAff.Facade.Cache;

using VanAcc = Vanilla.Guardian.Facade.Account;
using UtilWin = Vanilla.Utility.WinForm;

namespace Vanilla.Report.WinForm
{

    public partial class Container : Form
    {

        private Vanilla.Guardian.WinForm.Login loginForm;
        private Boolean isLoginFormOpen;
        private Boolean isAlreadyLoggedIn;

        private static Container currentInstance;

        public static Container CreateInstance(VanAcc.Dto account)
        {
            if (currentInstance == null) currentInstance = new Container(account);
            return currentInstance;
        }

        public static Container CreateInstance()
        {
            if (currentInstance == null) currentInstance = new Container();
            return currentInstance;
        }

        private Container()
        {
            InitializeComponent();
            this.isLoginFormOpen = false;
            this.isAlreadyLoggedIn = false;
            this.MdiChildActivate += Container_MdiChildActivate;
        }

        void Container_MdiChildActivate(object sender, EventArgs e)
        {
            //if (this.isLoginFormOpen && this.isAlreadyLoggedIn)
            if (this.isLoginFormOpen)
            {
                this.Login();
                this.loginForm.Close();
            }
        }

        private Container(VanAcc.Dto account)
            : this()
        {
            if (account != null)
            {
                Server.Current.Cache["User"] = account;
            }
        }

        #region Events

        private void Container_Load(object sender, EventArgs e)
        {
            if (Server.Current.Cache["User"] == null)
            {
                this.ShowLoginForm();
                this.ShowControlBeforeLogin();
            }
            else
            {
                this.mnuLogin.Visible = false;
                //if (this.currentChild != null)
                //{
                //    this.currentChild.MdiParent = this;
                //    this.currentChild.Show();
                //}
            }
        }

        #region Menu

        #region File

        private void mnuLogin_Click(object sender, EventArgs e)
        {            
            this.ShowLoginForm();
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            new Facade.Container.Server(null).Logout();
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            this.ShowControlBeforeLogin();
            this.ShowLoginForm();

            this.Text = this.Text.Split(new Char[] { ' ', ':', ' ' })[0];
            this.isAlreadyLoggedIn = false;
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            new Form
            {
                Text = "New Form",
                MdiParent = this,
            }.Show();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            new UtilWin.Open().ShowDialog(this);
        }

        #endregion

        #region Windows

        private void mnuArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        #endregion

        #endregion

        #endregion

        private void ShowControlBeforeLogin()
        {
            this.mnuLogin.Visible = true;
            this.mnuLogout.Visible = false;
            this.mnuNew.Visible = false;
            this.mnuOpen.Visible = false;
            this.mnuRecentFiles.Visible = false;
            this.mnuFileSeperator1.Visible = false;
            this.mnuFileSeperator2.Visible = false;

            this.mnuEdit.Visible = false;

            this.mnuWindows.Visible = false;
        }

        private void ShowControlAfterLogin()
        {
            this.mnuLogin.Visible = false;
            this.mnuLogout.Visible = true;
            this.mnuNew.Visible = true;
            this.mnuOpen.Visible = true;
            this.mnuRecentFiles.Visible = true;
            this.mnuFileSeperator1.Visible = true;
            this.mnuFileSeperator2.Visible = true;

            this.mnuEdit.Visible = true;

            this.mnuWindows.Visible = true;
        }

        private void ShowLoginForm()
        {
            this.loginForm = new Guardian.WinForm.Login
            {
                TopLevel = false,
                WindowState = FormWindowState.Normal,
                Dock = DockStyle.Fill,
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
            };
            this.loginForm.FormClosed += loginForm_FormClosed;
            this.loginForm.Show();
            this.isLoginFormOpen = true;
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Vanilla.Guardian.WinForm.Login).IsAuthenticated)
            {
                this.Login();
            }
            this.isLoginFormOpen = false;
        }

        private void Login()
        {
            this.isAlreadyLoggedIn = true;
            VanAcc.Dto loggedInUser = (Server.Current.Cache["User"] as VanAcc.Dto);
            String heading = this.Text + " : " + loggedInUser.Profile.Name + " - ";
            if (loggedInUser.RoleList != null)
            {
                Int32 i = loggedInUser.RoleList.Count - 1;
                while (i >= 0)
                {
                    heading += loggedInUser.RoleList[i].Name;
                    if (i-- != 0) heading += "/";
                }
            }
            this.Text = heading;
            this.ShowControlAfterLogin();
        }

        public Boolean Login(VanAcc.Dto user)
        {
            VanAcc.Dto loggedInUser = (Server.Current.Cache["User"] as VanAcc.Dto);
            if (loggedInUser == null) return false;
            if (String.Compare(user.LoginId, loggedInUser.LoginId) == 0
                && String.Compare(user.Password, loggedInUser.Password) == 0)
            {
                this.Login();
                return true;
            }
            return false;
        }
        
    }

}
