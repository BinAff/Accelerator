using System;
using System.Windows.Forms;
using System.Collections.Generic;

using BinAff.Facade.Cache;

using AccFac = Vanilla.Guardian.Facade.Account;
using GuardWin = Vanilla.Guardian.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using ContFac = Vanilla.Utility.Facade.Container;

namespace Vanilla.Utility.WinForm
{

    public partial class Container : Form
    {

        private GuardWin.Login loginForm;
        private Boolean isLoginFormOpen;
        private Boolean isAlreadyLoggedIn;

        protected Facade.Container.Server facade;

        private Int16 mdiChildrenCount;
        private Boolean isMdiChildClosing;
        private Boolean isLoginFormOpening;

        private Container executable;

        protected Container()
        {
            InitializeComponent();
            this.isLoginFormOpen = false;
            this.isAlreadyLoggedIn = false;
            this.mdiChildrenCount = 0;
            this.MdiChildActivate += Container_MdiChildActivate;
        }

        private void Container_MdiChildActivate(object sender, EventArgs e)
        {
            Document currentForm = this.ActiveMdiChild as Document;
            if (this.isMdiChildClosing)
            {
                this.isMdiChildClosing = false;
                return;
            }
            if (this.isLoginFormOpen)
            {
                this.Login();
                this.loginForm.Close();
            }
            if (currentForm != null && currentForm.Text != "Login")
            {
                if (this.isLoginFormOpening) return;
                                
                if (this.MdiChildren.Length != this.mdiChildrenCount)
                {
                    this.mdiChildrenCount++;
                    currentForm.FormClosed += currentForm_FormClosed;                    
                    this.ManageRecentFile(currentForm.DocumentPath, currentForm.ComponentCode);
                }
                this.tlsVersion.Text = currentForm.Version;
                this.tlsCreatedBy.Text = currentForm.CreatedBy;
                this.tlsCreatedAt.Text = currentForm.CreatedAt;
                this.tlsModifiedBy.Text = currentForm.ModifiedBy;
                this.tlsModifiedAt.Text = currentForm.ModifiedAt;
            }

        }

        private void currentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.isMdiChildClosing = true;
            this.mdiChildrenCount--;
            if (this.mdiChildrenCount == 0 && !this.isLoginFormOpening) this.Close();
        }

        protected Container(AccFac.Dto account)
            : this()
        {
            if (account != null)
            {
                Server.Current.Cache["User"] = account;
            }
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.Compose();
            if (Server.Current.Cache["User"] == null)
            {
                this.ShowLoginForm();
                this.ShowControlBeforeLogin();
            }
            else
            {
                List<ContFac.Server.XmlBucket> recentItemList = this.facade.ReadRecentFile(Application.StartupPath + @"\Files\Recent.xml");
                this.AttachRecentDocuments(recentItemList);
                this.ShowControlAfterLogin();
            }
        }

        protected virtual void Compose()
        {
            
        }

        #region Menu

        #region File

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            this.ShowLoginForm();
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            this.facade.Logout();

            this.isLoginFormOpening = true;
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            this.IsMdiContainer = true; //No clue why it is being false
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
            new Open().ShowDialog(this);
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

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        #endregion

        #endregion

        public Boolean Login(AccFac.Dto user)
        {
            AccFac.Dto loggedInUser = (Server.Current.Cache["User"] as AccFac.Dto);
            if (loggedInUser == null) return false;
            if (String.Compare(user.LoginId, loggedInUser.LoginId) == 0
                && String.Compare(user.Password, loggedInUser.Password) == 0)
            {
                this.Login();
                return true;
            }
            return false;
        }

        private void Login()
        {
            this.isAlreadyLoggedIn = true;
            AccFac.Dto loggedInUser = (Server.Current.Cache["User"] as AccFac.Dto);
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
            this.isLoginFormOpening = false;
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Vanilla.Guardian.WinForm.Login).IsAuthenticated)
            {
                this.Login();
            }
            this.isLoginFormOpen = false;
        }

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

            this.ShowControlBeforeLoginExtra();
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

            this.ShowControlAfterLoginExtra();
        }

        protected virtual void ShowControlBeforeLoginExtra()
        {
            
        }

        protected virtual void ShowControlAfterLoginExtra()
        {
            
        }

        private void ManageRecentFile(String documentPath, String componentCode)
        {
            List<ContFac.Server.XmlBucket> recentItemList = this.facade.SaveRecentFile(documentPath, componentCode, Application.StartupPath + @"\Files\Recent.xml");
            this.AttachRecentDocuments(recentItemList);
        }

        private void AttachRecentDocuments(List<ContFac.Server.XmlBucket> recentItemList)
        {            
            this.mnuRecentFiles.DropDownItems.Clear();
            if (recentItemList != null)
            {
                foreach (ContFac.Server.XmlBucket recentItem in recentItemList)
                {
                    ToolStripMenuItem recentItemMenu = new ToolStripMenuItem(recentItem.Path)
                    {
                        Tag = recentItem.Code,
                    };
                    recentItemMenu.Click += recentItemMenu_Click;
                    this.mnuRecentFiles.DropDownItems.Add(recentItemMenu);
                }
                if (recentItemList.Count > 0)
                {
                    this.mnuRecentFiles.DropDownItems.Add(new ToolStripSeparator());
                    ToolStripMenuItem clearMenu = new ToolStripMenuItem("Clear");
                    clearMenu.Click += clearMenu_Click;
                    this.mnuRecentFiles.DropDownItems.Add(clearMenu);
                }
            }
        }

        private void recentItemMenu_Click(object sender, EventArgs e)
        {
            String path = (sender as ToolStripMenuItem).Text;
            String componentCode = (sender as ToolStripMenuItem).Tag as String;
            if (this.executable == null)
            {
                this.executable = this.CreateExecutableInstance(Server.Current.Cache["User"] as AccFac.Dto);
                this.executable.FormClosed += executable_FormClosed;
            }
            this.executable.Show();
            ArtfFac.Dto currentArtifact = new ArtfFac.Server(null).Read(path, this.facade.GetCategory(), componentCode);
            Document form = this.InstantiateForm(currentArtifact);
            form.MdiParent = this.executable;
            form.Show();
        }

        private void clearMenu_Click(object sender, EventArgs e)
        {
            this.mnuRecentFiles.DropDownItems.Clear();
            this.facade.RemoveRecentFile(Application.StartupPath + @"\Files\Recent.xml");
        }

        private void executable_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.executable = null;
        }

        protected virtual Container CreateExecutableInstance(AccFac.Dto dto)
        {
            throw new NotImplementedException();
        }

        protected virtual Document InstantiateForm(ArtfFac.Dto currentArtifact)
        {
            currentArtifact.ComponentDefinition.ComponentFormType = this.facade.GetComponentFormType(currentArtifact.ComponentDefinition.Code); 
            Type type = Type.GetType(currentArtifact.ComponentDefinition.ComponentFormType, true);
            currentArtifact.Module.artifactPath = currentArtifact.Path;
            return (Document)Activator.CreateInstance(type, currentArtifact);
        }

    }

}
