using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

using BinAff.Facade.Cache;
using PresLib = BinAff.Presentation.Library;

using Vanilla.Tool.WinForm;
using Vanilla.Utility.WinForm;
using VanAcc = Vanilla.Guardian.Facade.Account;
using UtilFac = Vanilla.Utility.Facade;
using RptFac = Vanilla.Report.Facade;
using RptWin = Vanilla.Report.WinForm;
using FrmWin = Vanilla.Form.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Navigator.WinForm
{

    public partial class Container : System.Windows.Forms.Form
    {

        private Guardian.WinForm.Login loginForm;
        private Boolean isLoggedIn;
        private String selectedNodePath;

        private Timer connectionTimer;

        private FrmWin.Container formExecutable;
        private RptWin.Container reportExecutable;
        public List<RptFac.Category.Dto> reportCategoryList = new List<RptFac.Category.Dto>();

        #region Constructors - Singleton

        private static Container currentInstance;

        public static Container CreateInstance(String selectedNodePath)
        {
            if (currentInstance == null) currentInstance = new Container(selectedNodePath);
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
        }
        
        private Container(String selectedNodePath)
            : this()
        {
            this.isLoggedIn = true;
            this.selectedNodePath = selectedNodePath;
        }

        #endregion

        #region Event

        private void Container_Load(object sender, EventArgs e)
        {
            this.DockContainers();
            this.HideControl();
            if (this.isLoggedIn)
            {
                this.LoadForm();
                //this.SelectNode(this.selectedNodePath);
            }
            else
            {
                this.ShowLoginForm();
            }
            this.Resize += Container_Resize;
            this.connectionTimer = new Timer
            {
                Interval = 2000,
            };
            this.connectionTimer.Tick += connectionTimer_Tick;
            //this.connectionTimer.Start();

            //Hard code :: Need to remove
            this.reportCategoryList.Add(new Report.Facade.Category.Dto { Id = 10001, Extension = "drpt", Name = "Daily" });
            this.reportCategoryList.Add(new Report.Facade.Category.Dto { Id = 10002, Extension = "wrpt", Name = "Weekly" });
            this.reportCategoryList.Add(new Report.Facade.Category.Dto { Id = 10003, Extension = "mrpt", Name = "Monthly" });
            this.reportCategoryList.Add(new Report.Facade.Category.Dto { Id = 10004, Extension = "qrpt", Name = "Quarterly" });
            this.reportCategoryList.Add(new Report.Facade.Category.Dto { Id = 10005, Extension = "yrpt", Name = "Yearly" });
            //

            this.RemoveAuditInfo();

            this.ucRegister.ArtifactClicked += ucRegister_ArtifactClicked;

            //this.ucRegister.ReportAdded += ucRegister_ReportAdded;
            this.ucRegister.ReportLoad += ucRegister_ReportLoad;
            this.ucRegister.ReportCategoryGet += ucRegister_ReportCategoryGet;

            this.ucRegister.FormLoad += ucRegister_FormLoad;
        }

        private void ucRegister_ArtifactClicked()
        {
            this.ShowAuditInfo(this.ucRegister.CurrentArtifact);
        }

        //private Document ucRegister_ReportAdded(UtilFac.Artifact.Dto currentArtifact, UtilFac.Register.Server registerFacade, BinAff.Facade.Library.Dto moduleFormDto)
        //{
        //    if (!this.ShowForms()) return null;
        //    (moduleFormDto as RptFac.Document.Dto).Category = (currentArtifact.Module as RptFac.Document.Dto).Category;
        //    return new RptWin.Document(new RptFac.Document.FormDto
        //    {
        //        Dto = moduleFormDto as Report.Facade.Document.Dto,
        //        Document = currentArtifact,
        //    })
        //    {
        //        MdiParent = this.reportExecutable,
        //    };
        //}

        private void ucRegister_ReportLoad(UtilFac.Artifact.Dto currentArtifact)
        {
            if (!this.ShowReports()) return;
            RptWin.Document report = new RptWin.Document(currentArtifact)
            {
                MdiParent = this.reportExecutable
            };
            report.AuditInfoChanged += report_AuditInfoChanged;
            report.Show();
        }

        private void report_AuditInfoChanged(ArtfFac.Dto artifact)
        {
            this.ucRegister.ChangeForReportChange(artifact);
        }

        private void ucRegister_ReportCategoryGet(UtilFac.Artifact.Dto currentArtifact, string categoryName)
        {
            currentArtifact.Module = new Report.Facade.Document.Dto
            {
                Category = this.reportCategoryList.Find((p) => { return String.Compare(p.Name, categoryName, true) == 0; }),
            };
            currentArtifact.Extension = (currentArtifact.Module as Report.Facade.Document.Dto).Category.Extension;
        }

        private void ucRegister_FormLoad(UtilFac.Artifact.Dto currentArtifact)
        {
            if (!this.ShowForms()) return;

            Type type = Type.GetType(currentArtifact.ComponentDefinition.ComponentFormType, true);
            //currentArtifact.Module.artifactPath = currentArtifact.Path;
            FrmWin.Document form = (FrmWin.Document)Activator.CreateInstance(type, currentArtifact);
            form.MdiParent = this.formExecutable;
            form.ChildArtifactSaved += form_ChildArtifactSaved;
            form.AuditInfoChanged += form_AuditInfoChanged;
            form.AttachmentArtifactLoaded += form_AttachmentArtifactLoaded;
            form.Show();
        }

        void form_ChildArtifactSaved(ArtfFac.Dto artifact)
        {
            this.ucRegister.AttachDocument(artifact);
        }

        private void form_AuditInfoChanged(ArtfFac.Dto artifact)
        {
            this.ucRegister.ChangeForFormChange(artifact);
        }

        void form_AttachmentArtifactLoaded(Document document)
        {
            document.ChildArtifactSaved += form_ChildArtifactSaved;
            document.AuditInfoChanged += form_AuditInfoChanged;
        }

        private void connectionTimer_Tick(object sender, EventArgs e)
        {
            //this.ShowConnectionStatus();
        }

        private void Container_Resize(object sender, EventArgs e)
        {
            this.SetControlInMiddleOfForm(this.pnlLoginFormContainer);
        }

        private void Container_FormClosed(object sender, FormClosedEventArgs e)
        {
            StickyNote.Quit();
            new Facade.Container.Server(null).Logout();
        }

        private void DockContainers()
        {
            this.pnlCalender.Dock = DockStyle.Fill;
            this.pnlNote.Dock = DockStyle.Fill;
            this.ucConfiguration.Dock = DockStyle.Fill;
            this.ucRegister.Dock = DockStyle.Fill;
        }

        #endregion

        #region Login Form

        private void ShowLoginForm()
        {
            this.loginForm = new Guardian.WinForm.Login
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            this.pnlLoginFormContainer.Show();
            this.pnlLoginFormContainer.Height = this.loginForm.Height;
            this.pnlLoginFormContainer.Width = this.loginForm.Width;
            this.SetControlInMiddleOfForm(this.pnlLoginFormContainer);
            this.pnlLoginFormContainer.Controls.Add(this.loginForm);

            this.loginForm.Show();
            this.loginForm.FormClosed += loginForm_FormClosed;
        }

        private void SetControlInMiddleOfForm(Control control)
        {
            control.Top = this.Height / 2 - control.Height / 2;
            control.Left = this.Width / 2 - control.Width / 2;
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Vanilla.Guardian.WinForm.Login).IsAuthenticated)
            {
                this.progressBar.Visible = true;
                this.progressBar.Value = this.progressBar.Minimum;
                //Application.DoEvents(); //Forcefully all pending events are processed
                this.pnlLoginFormContainer.Hide();
                this.LoadForm();
                this.progressBar.Value = this.progressBar.Maximum;
                this.progressBar.Visible = false;
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
            }
        }

        private void LoadForm()
        {
            this.ShowControls();
            this.progressBar.Value = (Int32)Math.Abs(this.progressBar.Maximum * 0.9);
            this.ManageMenuAndButtonsForRole();
        }

        private void ShowControls()
        {
            Timer t = new Timer { Interval = 10 };
            t.Tick += delegate(object sender, EventArgs e)
            {
                this.progressBar.Value = (Int32)Math.Abs(this.ucRegister.GetStatus() * 0.8);
            };
            t.Start();
            this.ucRegister.LoadForm();

            t.Stop();

            this.progressBar.Value = (Int32)Math.Abs(this.progressBar.Maximum * 0.8);
            this.ucRegister.Show();
            this.pnlTool.Show();

            this.mnuLogin.Visible = false;
            this.mnuLogOut.Visible = true;
            this.mnuNew.Visible = true;
            this.mnuOpen.Visible = true;
            this.mnuFileSeperator2.Visible = true;
            this.mnuRecentFile.Visible = true;
            this.mnuFileSeperator3.Visible = true;
            this.mnuEdit.Visible = true;
            this.mnuView.Visible = true;
            this.mnuUserManagement.Visible = true;
        }

        private void ManageMenuAndButtonsForRole()
        {
            Facade.Container.RoleManager roleMgr = new Facade.Container.RoleManager((Server.Current.Cache["User"] as VanAcc.Dto).RoleList);

            #region Tool

            this.mnuRegisterUser.Visible = roleMgr.IsAdmin || roleMgr.IsSuperAdmin ? true : false;
            this.mnuChangeAccount.Visible = roleMgr.IsAdmin || roleMgr.IsSuperAdmin ? true : false;
            this.mnuChangeOwnProfile.Visible = roleMgr.IsSuperAdmin ? false : true;

            this.mnuAdvanceSearch.Visible = roleMgr.IsSuperAdmin || roleMgr.IsReceptionist ? true : false;
            this.mnuRoomReservation.Visible = roleMgr.IsSuperAdmin || roleMgr.IsReceptionist ? true : false;
            this.mnuCheckin.Visible = roleMgr.IsSuperAdmin || roleMgr.IsReceptionist ? true : false;

            #endregion

            this.btnConfiguration.Enabled = roleMgr.IsAdmin || roleMgr.IsSuperAdmin ? true : false;
        }

        #endregion

        #region Menu Management

        #region File

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            this.ShowLoginForm();
        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            this.LogOut();
        }

        private void mnuNewFolder_Click(object sender, EventArgs e)
        {
            this.ucRegister.AddFolder();
        }

        private void mnuNewForm_Click(object sender, EventArgs e)
        {
            this.ucRegister.AddDocument();
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            //Clear recent file list
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            new Facade.Container.Server(null).Logout();
            this.Close();
        }

        #endregion

        #region Edit

        private void mnuCut_Click(object sender, EventArgs e)
        {
            this.ucRegister.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            this.ucRegister.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            this.ucRegister.Paste();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            this.ucRegister.Delete();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            this.ucRegister.SelectAll();
        }

        private void mnuInvertSelection_Click(object sender, EventArgs e)
        {
            this.ucRegister.InvertSelection();
        }

        #endregion

        #region View

        private void mnuForms_Click(object sender, EventArgs e)
        {

        }

        private void mnuReports_Click(object sender, EventArgs e)
        {

        }

        private void mnuRegister_Click(object sender, EventArgs e)
        {
            this.ShowRegister();
        }

        private void mnuConfiguration_Click(object sender, EventArgs e)
        {
            this.ShowConfiguration();
        }

        private void mnuStickyNote_Click(object sender, EventArgs e)
        {
            this.ShowNote();
        }

        private void mnuCalender_Click(object sender, EventArgs e)
        {
            this.ShowCalender();
        }

        private void mnuEmail_Click(object sender, EventArgs e)
        {
            this.ShowEmail();
        }

        private void mnuSMS_Click(object sender, EventArgs e)
        {
            this.ShowSms();
        }

        #region Sort

        private void mnuCreatedAt_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort("Created At");
        }

        private void mnuCreatedBy_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort("Created By");
        }

        private void mnuModifiedAt_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort("Modified At");
        }

        private void mnuModifiedBy_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort("Modified By");
        }

        private void cmnuSortName_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort("Name");
        }

        private void mnuType_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort("Type");
        }

        private void mnuVersion_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort("Version");
        }

        private void mnuAscending_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort(SortOrder.Ascending);
        }

        private void mnuDescending_Click(object sender, EventArgs e)
        {
            this.ucRegister.Sort(SortOrder.Descending);
        }

        #endregion

        private void mnuLargeIcon_Click(object sender, EventArgs e)
        {
            this.ucRegister.SetViewForList(View.LargeIcon);
        }

        private void mnuSmallIcon_Click(object sender, EventArgs e)
        {
            this.ucRegister.SetViewForList(View.SmallIcon);
        }

        private void mnuList_Click(object sender, EventArgs e)
        {
            this.ucRegister.SetViewForList(View.List);
        }

        private void mnuDetail_Click(object sender, EventArgs e)
        {
            this.ucRegister.SetViewForList(View.Details);
        }

        private void mnuTile_Click(object sender, EventArgs e)
        {
            this.ucRegister.SetViewForList(View.Tile);
        }

        #endregion

        #region Tool

        private void mnuRegisterUser_Click(object sender, EventArgs e)
        {
            Guardian.WinForm.Registration form = new Guardian.WinForm.Registration();
            form.ShowDialog();
        }

        private void mnuChangeOwnProfile_Click(object sender, EventArgs e)
        {
            Guardian.WinForm.MyAccount form = new Guardian.WinForm.MyAccount();
            form.ShowDialog();
        }

        private void mnuChangeAccount_Click(object sender, EventArgs e)
        {
            Guardian.WinForm.UserRegister form = new Guardian.WinForm.UserRegister();
            form.ShowDialog();
        }

        private void mnuRoomReservation_Click(object sender, EventArgs e)
        {

        }

        private void mnuCheckin_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Help

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog(this);
        }

        private void mnuViewHelp_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region Context Menu

        private void mnuNewWindow_Click(object sender, EventArgs e)
        {

            //TreeNode selectedNode = this.trvForm.SelectedNode;

            //Facade.Artifact.Dto currentDto;
            //if (selectedNode.Tag.GetType().ToString() == "Vanilla.Navigator.Facade.Module.Dto")
            //{
            //    currentDto = (selectedNode.Tag as Facade.Module.Dto).Artifact;
            //}
            //else
            //{
            //    currentDto = selectedNode.Tag as Facade.Artifact.Dto;
            //}
            //new System.Threading.Thread(new System.Threading.ThreadStart(delegate()
            //{
            //    Application.Run(new Container(currentDto.Path));
            //})).Start();
        }

        #endregion

        private void LogOut()
        {
            new Facade.Container.Server(null).Logout();
            this.HideControl();
            this.ShowLoginForm();

            this.Text = this.Text.Split(new Char[] { ' ', ':', ' ' })[0];
        }

        private void HideControl()
        {
            this.pnlTool.Hide();
            this.ucRegister.Hide();
            this.pnlNote.Hide();
            this.ucConfiguration.Hide();
            this.pnlCalender.Hide();

            this.mnuLogin.Visible = true;
            this.mnuLogOut.Visible = false;
            this.mnuNew.Visible = false;
            this.mnuOpen.Visible = false;
            this.mnuFileSeperator2.Visible = false;
            this.mnuRecentFile.Visible = false;
            this.mnuFileSeperator3.Visible = false;

            this.mnuEdit.Visible = false;

            this.mnuView.Visible = false;

            this.mnuUserManagement.Visible = false;
            this.mnuAdvanceSearch.Visible = false;

        }

        private void ShowConnectionStatus()
        {
            if (new Facade.Container.Server(null).IsConnected())
            {
                this.shapeOnlineStatus.BackColor = this.shapeOnlineStatus.BorderColor = Color.Green;
                this.btnConnect.Hide();
            }
            else
            {
                this.shapeOnlineStatus.BackColor = this.shapeOnlineStatus.BorderColor = Color.Red;
                this.btnConnect.Show();
            }
            this.connectionTimer.Stop();
        }

        #region Tool Box

        private void btnHideShow_Click(object sender, EventArgs e)
        {
            if (this.btnRegister.Width == 0)
            {
                Int32 width = 25;
                this.btnRegister.Width = width;
                this.btnCalender.Width = width;
                this.btnEmail.Width = width;
                this.btnSms.Width = width;
                this.btnNote.Width = width;
                this.btnConfiguration.Width = width;
                this.pnlTool.Width = width * 7;
                this.btnHideShow.Text = "7";
                this.toolTip.SetToolTip(this.btnHideShow, "Hide");
            }
            else
            {
                this.btnRegister.Width = 0;
                this.btnCalender.Width = 0;
                this.btnEmail.Width = 0;
                this.btnSms.Width = 0;
                this.btnNote.Width = 0;
                this.btnConfiguration.Width = 0;
                this.pnlTool.Width = this.btnHideShow.Width;
                this.btnHideShow.Text = "8";
                this.toolTip.SetToolTip(this.btnHideShow, "Show");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.ShowRegister();
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            this.ShowConfiguration();
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            this.ShowNote();
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            this.ShowCalender();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            this.ShowEmail();
        }

        private void btnSms_Click(object sender, EventArgs e)
        {
            this.ShowSms();
        }

        #endregion

        #region Containers Hide/Show

        private void ShowRegister()
        {
            this.ucRegister.Show();
            this.ucConfiguration.Hide();
            this.pnlNote.Hide();
            this.pnlCalender.Hide();
        }

        private void ShowConfiguration()
        {
            this.ucRegister.Hide();
            this.pnlNote.Hide();
            this.pnlCalender.Hide();
            this.ucConfiguration.Show();
            this.ucConfiguration.PopulateModuleForConfiguration();
        }

        private void ShowNote()
        {
            this.ucRegister.Hide();
            this.ucConfiguration.Hide();
            this.pnlCalender.Hide();
            this.pnlNote.Show();
            StickyNote.LoadStickyFromFileSystem(this.pnlNote.Controls);
            if (this.pnlNote.Controls.Count == 0)
            {
                StickyNote stickyNote = StickyNote.Create(this.pnlNote.Controls);                
                stickyNote.TopLevel = false;
                stickyNote.Show();
            }
        }

        private void ShowCalender()
        {
            this.ucRegister.Hide();
            this.ucConfiguration.Hide();
            this.pnlNote.Hide();
            this.pnlCalender.Show();
            this.pnlCalender.Controls.Clear();
            Tool.WinForm.Calender calender = new Tool.WinForm.Calender
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            this.pnlCalender.Controls.Add(calender);
            calender.Show();
        }

        private void ShowEmail()
        {

        }

        private void ShowSms()
        {

        }

        #endregion

        #region Status Bar

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.ShowConnectionStatus();
        }

        #endregion

        private void ShowAuditInfo(UtilFac.Artifact.Dto selectedNode)
        {
            if (selectedNode != null)
            {
                this.lblFileName.Text = selectedNode.FullFileName;
                if (selectedNode.AuditInfo != null)
                {
                    if (selectedNode.AuditInfo.Version > 0)
                    {
                        this.lblType.Text = selectedNode.Style.ToString();
                        this.lblVersion.Text = selectedNode.AuditInfo.Version.ToString();
                    }

                    if (selectedNode.AuditInfo.CreatedBy == null)
                    {
                        this.lblCreatedBy.Text = String.Empty;
                        this.lblCreatedAt.Text = String.Empty;
                    }
                    else
                    {
                        this.lblCreation.Text = "Creation";
                        this.lblModification.Text = "Modification";
                        this.lblCreatedBy.Text = selectedNode.AuditInfo.CreatedBy.Name;
                        this.lblCreatedAt.Text = selectedNode.AuditInfo.CreatedAt.ToString();
                    }

                    if (selectedNode.AuditInfo.ModifiedBy == null)
                    {
                        this.lblModifiedBy.Text = String.Empty;
                        this.lblModifiedAt.Text = String.Empty;
                    }
                    else
                    {
                        this.lblModifiedBy.Text = selectedNode.AuditInfo.ModifiedBy.Name;
                        this.lblModifiedAt.Text = ((DateTime)selectedNode.AuditInfo.ModifiedAt).ToString();
                    }
                }
                else
                {
                    this.RemoveAuditInfo();
                    this.lblType.Text = "Addon";
                }
            }
        }

        private void RemoveAuditInfo()
        {
            this.lblFileName.Text = String.Empty;
            this.lblType.Text = String.Empty;
            this.lblVersion.Text = String.Empty;
            this.lblCreatedBy.Text = String.Empty;
            this.lblCreatedAt.Text = String.Empty;
            this.lblModifiedBy.Text = String.Empty;
            this.lblModifiedAt.Text = String.Empty;
            this.lblCreation.Text = String.Empty;
            this.lblModification.Text = String.Empty;
        }

        #region Other Executables

        private Boolean ShowForms()
        {
            if (this.formExecutable == null)
            {
                this.formExecutable = FrmWin.Container.CreateInstance(Server.Current.Cache["User"] as VanAcc.Dto);
                this.formExecutable.FormClosed += formExecutable_FormClosed;
            }
            this.formExecutable.Show();
            if (!this.formExecutable.Login(Server.Current.Cache["User"] as VanAcc.Dto))
            {
                this.LogOut();
                return false;
            }
            return true;
        }

        private Boolean ShowReports()
        {
            if (this.reportExecutable == null)
            {
                this.reportExecutable = RptWin.Container.CreateInstance(Server.Current.Cache["User"] as VanAcc.Dto);
                this.reportExecutable.FormClosed += reportExecutable_FormClosed;
            }
            this.reportExecutable.Show();
            if (!this.reportExecutable.Login(Server.Current.Cache["User"] as VanAcc.Dto))
            {
                this.LogOut();
                return false;
            }
            return true;
        }

        private void formExecutable_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.formExecutable = null;
        }

        private void reportExecutable_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.reportExecutable = null;
        }

        #endregion

    }

}

