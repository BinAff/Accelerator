using System;
using System.Windows.Forms;
using System.Collections.Generic;

using BinAff.Facade.Cache;

using AccFac = Vanilla.Guardian.Facade.Account;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using ContFac = Vanilla.Utility.Facade.Container;

using GuardWin = Vanilla.Guardian.WinForm;

namespace Vanilla.Utility.WinForm
{

    public partial class Container : Form
    {

        protected Facade.Container.FormDto formDto;

        private GuardWin.Login loginForm;
        private Boolean isLoginFormOpen;
        private Boolean isAlreadyLoggedIn;

        protected DocumentCollection documentCollection = new DocumentCollection();

        protected Facade.Container.Server facade;

        private Int16 childrenCount;
        private Boolean isLoginFormOpening;

        private Container executable;

        protected Boolean IsPathShown
        {
            get
            {
                return this.lblPath.Visible;
            }
            set
            {
                this.lblPath.Visible = value;
                this.tlsPath.Visible = value;
            }
        }

        protected Container()
        {
            InitializeComponent();
            this.isLoginFormOpen = false;
            this.isAlreadyLoggedIn = false;
            this.childrenCount = 0;
        }

        public Boolean AddDocument(Document child)
        {
            if (this.isLoginFormOpen)
            {
                this.Login();
                this.loginForm.Close();
            }
            child.HeadingClicked += child_HeadingClicked;
            this.ActivateDocument(child);
            this.BringToFront();

            //Check if the document is already open or not
            if (this.documentCollection.Find((p) =>
            {
                if (child.formDto != null && child.formDto.Document != null)
                {
                    return child.formDto.Document.Id == p.formDto.Document.Id;
                }
                return false;
            }) == null)
            {
                documentCollection.Add(child);
                if (this.documentCollection.Count != this.childrenCount)
                {
                    this.childrenCount++;
                    child.FormClosed += currentForm_FormClosed;
                    this.ManageRecentFile(child.DocumentPath, child.ComponentCode);
                }
            }
            else //Duplicate document
            {
                //this.ActivateDocument(this.activeDocument);
                return false;
            }
            return true;
        }

        void child_HeadingClicked(object sender1, EventArgs e1)
        {
            if (this.documentCollection.Current.Heading != sender1)
            {
                this.ActivateDocument((sender1 as DocumentHeading).Document);
            }
        }

        private void ActivateDocument(Document document)
        {
            this.tlsVersion.Text = document.AuditInfo.Version.ToString();
            this.tlsCreatedBy.Text = document.AuditInfo.CreatedBy.Name;
            this.tlsCreatedAt.Text = document.AuditInfo.CreatedAt.ToString();
            if (document.AuditInfo.ModifiedBy != null)
            {
                this.tlsModifiedBy.Text = document.AuditInfo.ModifiedBy.Name;
                this.tlsModifiedAt.Text = document.AuditInfo.ModifiedAt.ToString();
            }
            this.tlsPath.Text = document.DocumentPath;

            this.documentCollection.Activate(document);

            this.LoadSummary(document);
            this.LoadReference(document);
        }

        protected virtual void LoadSummary(Document child)
        {
            
        }

        protected virtual void LoadReference(Document child)
        {

        }

        private void currentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.childrenCount--;

            if (this.documentCollection.Count > 1)
            {
                this.documentCollection.Remove(sender as Document);
                if (this.documentCollection.Current == sender as Document)
                {
                    this.ActivateDocument(this.documentCollection[this.documentCollection.Count - 1] as Document);
                }
                (sender as Document).Heading.Dispose();
            }
            else
            {
                if (!this.isLoginFormOpening) this.Close();
            }
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
            foreach (Form frm in this.documentCollection)
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
            this.GetNewDialogue().ShowDialog(this);
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            this.GetOpenDialogue().ShowDialog(this);
        }

        #endregion

        protected virtual OpenDialog GetOpenDialogue()
        {
            throw new NotImplementedException();
        }

        protected virtual SaveDialog GetNewDialogue()
        {
            throw new NotImplementedException();
        }

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
            this.AddDocument(form);
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
            //currentArtifact.Module.artifactPath = currentArtifact.Path;
            return (Document)Activator.CreateInstance(type, currentArtifact);
        }

        private void mnuLeftPanel_Click(object sender, EventArgs e)
        {
            this.OnLeftPanleClick();
        }

        protected virtual void OnLeftPanleClick()
        {
            throw new NotImplementedException();
        }

        private void mnuRightPanel_Click(object sender, EventArgs e)
        {
            this.OnRightPanleClick();
        }

        protected virtual void OnRightPanleClick()
        {
            throw new NotImplementedException();
        }

    }

}