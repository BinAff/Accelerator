using System;
using System.Windows.Forms;

using BinAff.Facade.Cache;

using Vanilla.Tool.WinfForm;
using VanAcc = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Navigator.WinForm
{

    public partial class Container : Form
    {

        private Vanilla.Guardian.WinForm.Login loginForm;
        private Boolean isLoggedIn;
        private String selectedNodePath;

        //TyronM.MinTrayBtn mybutton;

        public Container()
        {
            InitializeComponent();
            //mybutton = new TyronM.MinTrayBtn(this);
            //mybutton.MinTrayBtnClicked += mybutton_MinTrayBtnClicked;
        }

        //void mybutton_MinTrayBtnClicked(object sender, EventArgs e)
        //{
        //    this.HideControl();
        //    this.ShowLoginForm();

        //    this.Text = this.Text.Split(new Char[]{' ', ':', ' '})[0];
        //}

        public Container(String selectedNodePath)
            : this()
        {
            this.isLoggedIn = true;
            this.selectedNodePath = selectedNodePath;
        }

        private void Container_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < tbcCategory.TabPages.Count; i++)
            //    hashTreeView.Add(tbcCategory.TabPages[i].Text, null);

            //this.ucRegister.Height = this.Height / 2 - 20;
            //this.pnlArtifact.Height = this.Height / 2 - 20;

            //this.cmsExplorer.ImageList = this.imgSmallIcon;
            //this.InitializeListView();
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
        }

        private void DockContainers()
        {
            this.pnlNote.Dock = DockStyle.Fill;
            this.ucConfiguration.Dock = DockStyle.Fill;
            this.ucRegister.Dock = DockStyle.Fill;
        }

        private void Container_Resize(object sender, EventArgs e)
        {
            this.SetControlInMiddleOfForm(this.pnlLoginFormContainer);
        }

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
                this.pnlLoginFormContainer.Hide();
                this.LoadForm();
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
            this.ManageMenuAndButtonsForRole();
        }

        #endregion

        //#region ListView Context menu events

        //private void lstViewContainer_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        //{
        //    //foreach (ListViewItem lstItem in (sender as ListView).Items)
        //    //{
        //    //    lstItem.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
        //    //}

        //    //e.Item.BackColor = System.Drawing.Color.LightBlue;
        //}

        //private void ListViewFolder_Click(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}

        //private void ListViewDocument_Click(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}

        //private void ListViewDelete_Click(object sender, EventArgs e)
        //{
        //    //ListViewItem selectedItem = lsvContainer.SelectedItems[0];
        //    //if (selectedItem != null)
        //    //{
        //    //    Facade.Artifact.Dto artifactDto = selectedItem.Tag as Facade.Artifact.Dto;

        //    //}
        //}

        //#endregion

        //#region Tree related Events and methods

        //private void TreeNodeMouseDown(TreeNode node)
        //{
        //    //Vanilla.Navigator.Facade.Artifact.Dto dtoArtifact = node.Tag as Vanilla.Navigator.Facade.Artifact.Dto;
        //    //String filename = dtoArtifact.FileName;
        //}

        //#endregion

        //#region ContextMenu Events and methods

        //private void addDirectory_Click(object sender, EventArgs e)
        //{
        //    this.trvForm.LabelEdit = true;
        //    TreeNode newNode = new TreeNode
        //    {
        //        Text = "New Directory",
        //        Tag = new Facade.Artifact.Dto(),
        //    };
        //    this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
        //    {
        //        Dto = newNode.Tag as Facade.Artifact.Dto,
        //    };
        //    this.AttachNodes(this.trvForm.SelectedNode.Tag as BinAff.Facade.Library.Dto, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

        //    if (this.trvForm.SelectedNode != null)
        //    {
        //        (this.trvForm.SelectedNode as TreeNode).Nodes.Add(newNode);
        //        newNode.Parent.Expand();

        //        this.trvForm.SelectedNode = null;
        //        newNode.BeginEdit();

        //        ListViewItem newListItem = this.CreateNewListViewItem("New Directory", 0);
        //        newListItem.Tag = this.formDto.ModuleFormDto.CurrentArtifact.Dto;
        //        this.lsvContainer.Items.Add(newListItem);
        //    }
        //}

        //private void addDocument_Click(object sender, EventArgs e)
        //{
        //    if (this.trvForm.SelectedNode != null)
        //    {
        //        TreeNode rootNode = this.FindRootNode((this.trvForm.SelectedNode as TreeNode));

        //        //Show Dialogue to capture module data
        //        BinAff.Facade.Library.Dto moduleFormDto = new Facade.Module.Server(null).InstantiateDto(rootNode.Tag as Facade.Module.Dto);
        //        Type type = Type.GetType((rootNode.Tag as Facade.Module.Dto).ComponentFormType, true);
        //        Form form = (Form)Activator.CreateInstance(type, moduleFormDto);
        //        form.ShowDialog(this);
        //        //moduleFormDto.Id = 7;// Hard coding. Just to ignore form feeling. Just remove

        //        if (moduleFormDto.Id > 0)
        //        {
        //            ListViewItem newNode = this.CreateNewListViewItem("New " + sender.ToString(), 2);
        //            newNode.Tag = new Facade.Artifact.Dto
        //            {
        //                Module = moduleFormDto,
        //            };
        //            this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
        //            {
        //                Dto = newNode.Tag as Facade.Artifact.Dto,
        //            };
        //            this.AttachNodes(this.trvForm.SelectedNode.Tag as BinAff.Facade.Library.Dto, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

        //            this.lsvContainer.LabelEdit = true;
        //            this.lsvContainer.Items.Add(newNode);
        //            newNode.BeginEdit();
        //        }
        //    }
        //}

        //#endregion

        #region Menu Management

        #region File

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            this.ShowLoginForm();
        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            new Vanilla.Navigator.Facade.Container.Server(null).Logout();
            this.HideControl();
            this.ShowLoginForm();

            this.Text = this.Text.Split(new Char[] { ' ', ':', ' ' })[0];
        }

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

        private void mnuClear_Click(object sender, EventArgs e)
        {
            //Clear recent file list
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            new Vanilla.Navigator.Facade.Container.Server(null).Logout();
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

        }

        private void mnuViewHelp_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        private void ShowControls()
        {
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

        private void HideControl()
        {
            this.pnlTool.Hide();
            this.ucRegister.Hide();
            this.pnlNote.Hide();
            this.ucConfiguration.Hide();

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

        ///// <summary>
        ///// Attach parent to new node  and instantiate path with parent path
        ///// </summary>
        ///// <param name="parent"></param>
        //private void AttachNodes(BinAff.Facade.Library.Dto parent, Vanilla.Utility.Facade.Artifact.Dto child)
        //{
        //    Vanilla.Utility.Facade.Artifact.Dto parentDto;
        //    if (parent.GetType().ToString() == "Vanilla.Utility.Facade.Module.Dto") //Adding to module
        //    {
        //        parentDto = (parent as Vanilla.Utility.Facade.Module.Dto).Artifact;
        //    }
        //    else
        //    {
        //        parentDto = parent as Vanilla.Utility.Facade.Artifact.Dto;
        //        child.Parent = parent;
        //    }
        //    if (parentDto.Children == null) parentDto.Children = new List<Vanilla.Utility.Facade.Artifact.Dto>();
        //    parentDto.Children.Add(child);
        //    child.Path = parentDto.Path;
        //}

        //private ListViewItem CreateNewListViewItem(String name, Int32 imageIndex)
        //{
        //    return new ListViewItem
        //    {
        //        Text = name,
        //        ImageIndex = imageIndex,
        //    };
        //}

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
        }

        private void ShowConfiguration()
        {
            this.ucRegister.Hide();
            this.pnlNote.Hide();
            this.ucConfiguration.Show();
            this.ucConfiguration.PopulateModuleForConfiguration();
        }

        private void ShowNote()
        {
            this.ucRegister.Hide();
            this.ucConfiguration.Hide();
            this.pnlNote.Show();
            if (this.pnlNote.Controls.Count == 0)
            {
                StickyNote stickyNote = StickyNote.Create(this.pnlNote.Controls);
                stickyNote.TopLevel = false;
                stickyNote.Show();
            }
        }

        private void ShowCalender()
        {

        }

        private void ShowEmail()
        {

        }

        private void ShowSms()
        {

        }

        #endregion

        private void Container_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Vanilla.Navigator.Facade.Container.Server(null).Logout();
        }

        #region Remove List

        //private Facade.Container.FormDto formDto;
        //private Facade.Container.Server facade;

        //private TreeNode editNode;
        //private String sortColumn;
        //private Boolean isCutAction;
        //private PresentationLib.ListViewColumnSorter lvwColumnSorter;

        //#region TreeView

        //private void trvArtifact_MouseDown(object sender, MouseEventArgs e)
        //{
        //    // Select the clicked node
        //    TreeView current = sender as TreeView;
        //    current.SelectedNode = current.GetNodeAt(e.X, e.Y);

        //    if (e.Button == MouseButtons.Right)
        //    {
        //        ToolStripMenuItem menuItem = cmsExplorer.Items[0] as ToolStripMenuItem;
        //        if (current.SelectedNode != null) //check whether right click is done on tree node
        //        {
        //            ShowHideContextMenuItems(false, current.SelectedNode, null);
        //            cmsExplorer.Show(current, e.Location);
        //        }
        //    }

        //}

        //private void trvArtifact_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        //{
        //    (sender as TreeView).LabelEdit = false;

        //    if (e.Label != null && e.Label.Trim().Length == 0)
        //    {
        //        e.CancelEdit = true; // Can not be empty text
        //        return;
        //    }
        //    //no text inserted during edit
        //    else if ((e.Node.Tag as Facade.Artifact.Dto).Id > 0 && e.Label == null)
        //    {
        //        e.CancelEdit = true; // Can not be empty text
        //        return;
        //    }
        //    //same text inserted during edit
        //    else if ((e.Node.Tag as Facade.Artifact.Dto).Id > 0 && e.Label.Trim() == e.Node.Text.Trim())
        //    {
        //        e.CancelEdit = true; // Can not be empty text
        //        return;
        //    }

        //    String artifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? e.Node.Text : e.Label.Trim();

        //    if (this.formDto.ModuleFormDto.CurrentArtifact == null)
        //    {
        //        this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
        //        {
        //            Dto = e.Node.Tag as Facade.Artifact.Dto,
        //        };
        //    }
        //    this.PopulateNewArtifact(artifactFileName, Facade.Artifact.Type.Directory, this.formDto.ModuleFormDto.CurrentArtifact.Dto);
        //    this.facade = new Facade.Container.Server(this.formDto);

        //    //update
        //    if ((e.Node.Tag as BinAff.Facade.Library.Dto).Id > 0)
        //    {
        //        this.formDto.ModuleFormDto.CurrentArtifact.Dto.Version = this.formDto.ModuleFormDto.CurrentArtifact.Dto.Version + 1;
        //        this.formDto.ModuleFormDto.CurrentArtifact.Dto.ModifiedAt = DateTime.Now;
        //        this.formDto.ModuleFormDto.CurrentArtifact.Dto.ModifiedBy = new Table
        //        {
        //            Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
        //            Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
        //        };

        //        this.facade.Change();
        //    }
        //    else    // new insert   
        //    {
        //        this.facade.Add();
        //        if (!this.facade.IsError)
        //        {
        //            //root node
        //            if (e.Node.Parent.Parent == null)
        //            {
        //                this.SelectNode((e.Node.Parent.Tag as Facade.Module.Dto).Artifact);
        //            }
        //            else
        //            {
        //                this.SelectNode(e.Node.Parent.Tag as Facade.Artifact.Dto);
        //            }
        //        }
        //    }
        //}

        //private void trvArtifact_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    this.facade.LoadForm();
        //    this.facade.LoadArtifacts(e.Node.Text);
        //}

        //private void trvArtifact_KeyUp(object sender, KeyEventArgs e)
        //{
        //    TreeView current = sender as TreeView;
        //    if (e.KeyCode == Keys.F2)
        //    {
        //        current.LabelEdit = true;
        //        current.SelectedNode.BeginEdit();
        //    }
        //}

        //private void trvForm_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    Facade.Artifact.Dto selectedNode = (sender as TreeView).SelectedNode.Tag.GetType().ToString() == "Vanilla.Navigator.Facade.Module.Dto" ?
        //        ((sender as TreeView).SelectedNode.Tag as Facade.Module.Dto).Artifact :
        //        (sender as TreeView).SelectedNode.Tag as Facade.Artifact.Dto;
        //    this.SelectNode(selectedNode);
        //    this.txtAddress.Text = selectedNode.Path;
        //    this.formDto.ModuleFormDto.Dto = this.FindRootNode((sender as TreeView).SelectedNode).Tag as Facade.Module.Dto;
        //}

        //private void PopulateNewArtifact(String fileName, Facade.Artifact.Type type, Facade.Artifact.Dto currentArtifact)
        //{
        //    currentArtifact.FileName = fileName;

        //    //below properties are required only during insert
        //    if (currentArtifact.Id == 0)
        //    {
        //        currentArtifact.Style = type;
        //        currentArtifact.Version = 1;
        //        currentArtifact.CreatedBy = new Table
        //        {
        //            Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
        //            Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
        //        };
        //        currentArtifact.CreatedAt = DateTime.Now;
        //        switch (this.tbcCategory.SelectedTab.Text)
        //        {
        //            case "Form":
        //                currentArtifact.Category = Facade.Artifact.Category.Form;
        //                break;
        //            case "Catalogue":
        //                currentArtifact.Category = Facade.Artifact.Category.Catalogue;
        //                break;
        //            case "Report":
        //                currentArtifact.Category = Facade.Artifact.Category.Report;
        //                break;
        //            default:
        //                currentArtifact.Category = Facade.Artifact.Category.Form;
        //                break;
        //        }
        //        if (type == Facade.Artifact.Type.Directory)
        //        {
        //            currentArtifact.Path += currentArtifact.FileName + this.formDto.Rule.PathSeperator;
        //        }
        //    }
        //}

        //private void SelectNode(Facade.Artifact.Dto selectedNode)
        //{
        //    this.lsvContainer.Items.Clear();
        //    if (selectedNode.Children != null && selectedNode.Children.Count > 0)
        //    {
        //        foreach (Facade.Artifact.Dto artifact in selectedNode.Children)
        //        {
        //            ListViewItem current = new ListViewItem
        //            {
        //                Text = artifact.FileName,
        //                Tag = artifact,
        //                ImageIndex = artifact.Style == Facade.Artifact.Type.Directory ? 0 : 2,
        //            };
        //            current.SubItems.AddRange(this.AddListViewSubItems(current, artifact));
        //            this.lsvContainer.Items.Add(current);
        //        }

        //        //sort list view
        //        this.sortColumn = "Name"; //this name will come from rule
        //        this.lvwColumnSorter.Order = SortOrder.Ascending;
        //        this.ResetColumnOrderInListView();

        //        this.SortListView(sortColumn);

        //    }
        //}

        //private ListViewItem.ListViewSubItem[] AddListViewSubItems(ListViewItem node, Facade.Artifact.Dto artifact)
        //{
        //    return new ListViewItem.ListViewSubItem[]
        //    {   
        //        new ListViewItem.ListViewSubItem(node, "Type")
        //        {
        //            Text = artifact.Style.ToString(),
        //        },
        //        new ListViewItem.ListViewSubItem(node, "Version")
        //        {
        //            Text = artifact.Version.ToString(),
        //        },
        //        new ListViewItem.ListViewSubItem(node, "Created By")
        //        {
        //            Text = (artifact.CreatedBy as BinAff.Core.Table).Name,
        //        },
        //        new ListViewItem.ListViewSubItem(node, "Created At")
        //        {
        //            Text = artifact.CreatedAt.ToString(),
        //        },
        //        new ListViewItem.ListViewSubItem(node, "Modified By")
        //        {
        //            Text = artifact.ModifiedBy == null ? String.Empty : (artifact.ModifiedBy as BinAff.Core.Table).Name,
        //        },
        //        new ListViewItem.ListViewSubItem(node, "Modified At")
        //        {
        //            Text = artifact.ModifiedAt == DateTime.MinValue? String.Empty : artifact.ModifiedAt.ToString(),
        //        },
        //    };
        //}

        //private void ResetColumnOrderInListView()
        //{
        //    for (int i = 0; i < this.lsvContainer.Columns.Count; i++)
        //    {
        //        this.lsvContainer.Columns[i].DisplayIndex = i;
        //    }
        //}

        //private void SortListView(String columnHeaderCaption)
        //{
        //    this.ResetListViewColumnHeader();
        //    for (int i = 0; i < lsvContainer.Columns.Count; i++)
        //    {
        //        if (lsvContainer.Columns[i].Text == columnHeaderCaption)
        //        {
        //            lvwColumnSorter.SortColumn = i;

        //            // Reverse the current sort direction for this column.
        //            if (lvwColumnSorter.Order == SortOrder.Ascending)
        //                this.lsvContainer.Columns[lvwColumnSorter.SortColumn].ImageKey = "Down.gif";
        //            else
        //                this.lsvContainer.Columns[lvwColumnSorter.SortColumn].ImageKey = "Up.gif";

        //            // Perform the sort with these new sort options.
        //            this.lsvContainer.Sort();

        //            break;
        //        }
        //    }

        //}

        //private void ResetListViewColumnHeader()
        //{
        //    //clear sort character from column caption
        //    for (int i = 0; i < lsvContainer.Columns.Count; i++)
        //    {
        //        this.lsvContainer.Columns[i].ImageKey = String.Empty;
        //        this.lsvContainer.Columns[i].ImageIndex = -1;
        //        this.lsvContainer.Columns[i].TextAlign = HorizontalAlignment.Center;
        //    }
        //}

        //private void ShowHideContextMenuItems(Boolean isListView, TreeNode treeNode, ListViewItem listViewItem)
        //{
        //    if (isListView)
        //    {
        //        for (int i = 0; i < cmsExplorer.Items.Count; i++)
        //        {
        //            cmsExplorer.Items[i].Visible = IsListViewItem(cmsExplorer.Items[i].Name, listViewItem);

        //            //attach image to context menu
        //            if ((cmsExplorer.Items[i].Name == "cmnuSort" && lvwColumnSorter.Order != SortOrder.None) || (cmsExplorer.Items[i].Name == "cmnuView"))
        //                this.SetImageInContextMenu((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems, cmsExplorer.Items[i].Name);

        //            if (cmsExplorer.Items[i].Name == "newToolStripMenuItem")
        //                this.ShowHideContextMenuNewItems((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems);

        //        }
        //    }
        //    else //Tree View
        //    {
        //        for (int i = 0; i < cmsExplorer.Items.Count; i++)
        //        {
        //            cmsExplorer.Items[i].Visible = IsTreeViewItem(cmsExplorer.Items[i].Name);

        //            if (cmsExplorer.Items[i].Name == "newToolStripMenuItem")
        //                this.ShowHideContextMenuNewItems((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems);
        //        }
        //    }
        //}

        //private TreeNode FindRootNode(TreeNode treeNode)
        //{
        //    while (treeNode.Parent != null)
        //    {
        //        treeNode = treeNode.Parent;
        //    }
        //    return treeNode;
        //}

        //#endregion

        //#region Tab

        //private void tbcCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    TabPage currentTab = (sender as TabControl).SelectedTab;

        //    if (currentTab.Text == "Form")
        //    {
        //        if (hashTreeView[currentTab.Text] == null)
        //        {
        //            this.txtAddress.Text = @"Form::";
        //            this.facade.GetCurrentModules(Facade.Artifact.Category.Form);
        //            this.LoadModules(currentTab.Text);
        //            //this.isCatalogueLoaded = true;
        //        }
        //        else
        //        {
        //            CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvForm);
        //        }

        //        //if (!this.isFormLoaded)
        //        //{
        //        //    this.txtAddress.Text = @"Form::";
        //        //    this.facade.GetCurrentModules(Facade.Category.Form);
        //        //    this.LoadModules(currentTab.Text);
        //        //    this.isFormLoaded = true;
        //        //}
        //    }
        //    else if (currentTab.Text == "Catalogue")
        //    {
        //        if (hashTreeView[currentTab.Text] == null)
        //        {
        //            this.txtAddress.Text = @"Catalogue::";
        //            this.facade.GetCurrentModules(Facade.Artifact.Category.Catalogue);
        //            this.LoadModules(currentTab.Text);
        //            //this.isCatalogueLoaded = true;
        //        }
        //        else
        //        {
        //            CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvCatalogue);
        //        }
        //        //if (!this.isCatalogueLoaded)
        //        //{
        //        //    this.txtAddress.Text = @"Catalogue::";
        //        //    this.facade.GetCurrentModules(Facade.Category.Catalogue);
        //        //    this.LoadModules(currentTab.Text);
        //        //    this.isCatalogueLoaded = true;
        //        //}
        //    }
        //    else if (currentTab.Text == "Report")
        //    {
        //        if (hashTreeView[currentTab.Text] == null)
        //        {
        //            this.txtAddress.Text = @"Report::";
        //            this.facade.GetCurrentModules(Facade.Artifact.Category.Report);
        //            this.LoadModules(currentTab.Text);
        //            //this.isCatalogueLoaded = true;
        //        }
        //        else
        //        {
        //            CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvReport);
        //        }
        //        //if (!this.isReportLoaded)
        //        //{
        //        //    this.txtAddress.Text = @"Report::";
        //        //    this.facade.GetCurrentModules(Facade.Category.Report);
        //        //    this.LoadModules(currentTab.Text);
        //        //    this.isReportLoaded = true;
        //        //}
        //    }
        //}

        //private void tbcCategory_Deselected(object sender, TabControlEventArgs e)
        //{
        //    String tabName = (sender as TabControl).SelectedTab.Text;
        //    //hashTreeView[tabName] = CopyNodes(trvForm, new TreeView());
        //    switch (tabName)
        //    {
        //        case "Form":
        //            hashTreeView[tabName] = CopyNodes(trvForm, new TreeView());
        //            break;
        //        case "Catalogue":
        //            hashTreeView[tabName] = CopyNodes(trvCatalogue, new TreeView());
        //            break;
        //        case "Report":
        //            hashTreeView[tabName] = CopyNodes(trvReport, new TreeView());
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //#endregion

        //#region Misc

        //private void SetImageInContextMenu(ToolStripItemCollection sortItems, String menuName)
        //{
        //    //clear images
        //    for (int i = 0; i < sortItems.Count; i++)
        //        sortItems[i].Image = null;

        //    //set image in list context menu
        //    for (int i = 0; i < sortItems.Count; i++)
        //    {
        //        if (menuName == "cmnuSort")
        //        {
        //            if ((this.sortColumn == sortItems[i].Text) || (lvwColumnSorter.Order.ToString() == sortItems[i].Text))
        //                sortItems[i].Image = this.imgMisc.Images["Dot.gif"];
        //        }
        //        else if (menuName == "cmnuView")
        //        {
        //            String view = String.Empty;

        //            if (sortItems[i].Text == "Large Icon")
        //                view = "LargeIcon";
        //            else if (sortItems[i].Text == "Small Icon")
        //                view = "SmallIcon";
        //            else
        //                view = sortItems[i].Text;

        //            if (view == this.lsvContainer.View.ToString())
        //                sortItems[i].Image = this.imgMisc.Images["Dot.gif"];
        //        }
        //    }

        //}

        //private void ShowHideContextMenuNewItems(ToolStripItemCollection newItems)
        //{
        //    //starting from 2nd item, since the 1st item directory will always be visible
        //    for (int i = 1; i < newItems.Count; i++)
        //        newItems[i].Visible = newItems[i].Text == tbcCategory.SelectedTab.Text;
        //}

        //private Boolean IsTreeViewItem(String contextMenuName)
        //{
        //    switch (contextMenuName)
        //    {
        //        case "cmnuCut":
        //            return true;
        //        case "cmnuCopy":
        //            return true;
        //        case "cmnuPaste":
        //            return this.editNode != null;
        //        case "cmnuSeparator2":
        //            return true;
        //        case "cmnuDelete":
        //            return true;
        //        case "cmnuRename":
        //            return true;
        //        case "cmnuSeparator3":
        //            return true;
        //        case "newToolStripMenuItem":
        //            return true;
        //        default:
        //            return false;
        //    }
        //}

        //private void RemoveChildDtoFromParentDto(TreeNode parentNode, TreeNode childNode)
        //{
        //    Facade.Artifact.Dto parentArtifactDto;

        //    //Removing node from Parent Tag
        //    if (parentNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
        //        parentArtifactDto = (parentNode.Tag as Facade.Module.Dto).Artifact;
        //    else
        //        parentArtifactDto = parentNode.Tag as Facade.Artifact.Dto;

        //    foreach (Facade.Artifact.Dto child in parentArtifactDto.Children)
        //    {
        //        if (child.Id == (childNode.Tag as Facade.Artifact.Dto).Id)
        //        {
        //            parentArtifactDto.Children.Remove(child);
        //            break;
        //        }
        //    }
        //}

        //private void AddChildDtoToParentDto(TreeNode parentNode, TreeNode childNode)
        //{
        //    Facade.Artifact.Dto parentArtifactDto;

        //    //Removing node from Parent Tag
        //    if (parentNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
        //        parentArtifactDto = (parentNode.Tag as Facade.Module.Dto).Artifact;
        //    else
        //        parentArtifactDto = parentNode.Tag as Facade.Artifact.Dto;

        //    if (parentArtifactDto.Children == null)
        //        parentArtifactDto.Children = new List<Facade.Artifact.Dto>();

        //    parentArtifactDto.Children.Add(childNode.Tag as Facade.Artifact.Dto);

        //}

        //private void AttachTagToChildNodes(TreeNode node)
        //{
        //    Facade.Artifact.Dto artifactDto = node.Tag as Facade.Artifact.Dto;
        //    for (int i = 0; i < node.Nodes.Count; i++)
        //    {
        //        node.Nodes[i].Tag = artifactDto.Children[i] as Facade.Artifact.Dto;
        //        if (node.Nodes[i].Nodes != null && node.Nodes[i].Nodes.Count > 0)
        //            AttachTagToChildNodes(node.Nodes[i]);
        //    }
        //}

        //#endregion

        //#region ListView

        //private void lstViewContainer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        //{
        //    if (e.Label != null && e.Label.Trim().Length == 0)
        //        e.CancelEdit = true;

        //    ListViewItem selectedItem = (sender as ListView).FocusedItem;
        //    String artifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? selectedItem.Text.Trim() : e.Label.Trim();
        //    this.PopulateNewArtifact(artifactFileName, Facade.Artifact.Type.Document, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

        //    this.facade = new Facade.Container.Server(this.formDto);
        //    this.facade.Add();

        //    selectedItem.Text = this.formDto.ModuleFormDto.CurrentArtifact.Dto.FileName;
        //    selectedItem.SubItems.AddRange(this.AddListViewSubItems(selectedItem, this.formDto.ModuleFormDto.CurrentArtifact.Dto));

        //    PresentationLib.MessageBox.Type dialogueType;
        //    if (this.facade.IsError)
        //    {
        //        dialogueType = PresentationLib.MessageBox.Type.Error;
        //        this.lsvContainer.Items.Remove(selectedItem);
        //    }
        //    else
        //    {
        //        dialogueType = PresentationLib.MessageBox.Type.Information;
        //    }
        //    new PresentationLib.MessageBox
        //    {
        //        DialogueType = dialogueType,
        //        Heading = "Splash",
        //    }.Show(this.facade.DisplayMessageList);
        //}

        //private void lstViewContainer_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        ListViewItem selectedItem = lsvContainer.GetItemAt(e.X, e.Y);
        //        ShowHideContextMenuItems(true, null, selectedItem);
        //        cmsExplorer.Show(Cursor.Position);
        //    }
        //}

        //private void lstViewContainer_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F2)
        //    {
        //        lsvContainer.LabelEdit = true;
        //        foreach (ListViewItem item in lsvContainer.SelectedItems)
        //            item.BeginEdit();
        //    }
        //}

        //private void lstViewContainer_DoubleClick(object sender, EventArgs e)
        //{
        //    Facade.Artifact.Dto currentArtifact = ((sender as ListView).SelectedItems[0].Tag as Facade.Artifact.Dto);
        //    if (currentArtifact.Style == Facade.Artifact.Type.Directory)
        //    {
        //        this.SelectNode(currentArtifact);
        //        this.txtAddress.Text = currentArtifact.Path;
        //    }
        //    else
        //    {
        //        //Currently hard coding. Need to change
        //        //TreeNode rootNode = FindRootNode(selectedNode);
        //        //Type type = Type.GetType((rootNode.Tag as Facade.Module.Dto).ComponentFormType, true);
        //        Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm", true);
        //        Form form = (Form)Activator.CreateInstance(type, currentArtifact.Module);

        //        form.ShowDialog(this);
        //    }
        //}

        //private void lsvContainer_ColumnClick(object sender, ColumnClickEventArgs e)
        //{
        //    this.ResetListViewColumnHeader();

        //    this.sortColumn = this.lsvContainer.Columns[e.Column].Text;

        //    //Determine if clicked column is already the column that is being sorted.   
        //    if (e.Column == lvwColumnSorter.SortColumn)
        //    {
        //        if (lvwColumnSorter.Order == SortOrder.Ascending)
        //            lvwColumnSorter.Order = SortOrder.Descending;
        //        else
        //            lvwColumnSorter.Order = SortOrder.Ascending;
        //    }

        //    this.SortListView(this.sortColumn);

        //}

        //private Boolean IsListViewItem(String contextMenuName, ListViewItem listViewItem)
        //{
        //    switch (contextMenuName)
        //    {
        //        case "cmnuOpen":
        //            return listViewItem != null;
        //        case "cmnuView":
        //            return listViewItem == null;
        //        case "cmnuSort":
        //            return listViewItem == null;
        //        case "cmnuRefresh":
        //            return listViewItem == null;
        //        case "newToolStripMenuItem":
        //            return listViewItem == null;
        //        case "cmnuDelete":
        //            return listViewItem != null;
        //        case "cmnuRename":
        //            return listViewItem != null;
        //        case "cmnuCut":
        //            return listViewItem != null;
        //        case "cmnuCopy":
        //            return ((listViewItem != null) && ((listViewItem.Tag as Facade.Artifact.Dto).Style == Facade.Artifact.Type.Directory));
        //        case "cmnuPaste":
        //            return ((listViewItem != null) && (this.editNode != null) && ((listViewItem.Tag as Facade.Artifact.Dto).Style == Facade.Artifact.Type.Directory));
        //        case "cmnuSeparator1":
        //            return true;
        //        case "cmnuSeparator2":
        //            return listViewItem != null;
        //        default:
        //            return false;
        //    }
        //}

        //#endregion

        //#region Menu

        //public void Cut()
        //{
        //    this.editNode = null;

        //    if (this.trvForm.SelectedNode != null && this.trvForm.SelectedNode.Parent != null)
        //    {
        //        this.editNode = this.trvForm.SelectedNode;
        //        this.isCutAction = true;
        //    }
        //}

        //public void Copy()
        //{
        //    this.editNode = null;

        //    if (this.trvForm.SelectedNode != null && this.trvForm.SelectedNode.Parent != null)
        //    {
        //        this.editNode = this.trvForm.SelectedNode;
        //        this.isCutAction = false;
        //    }
        //}

        //public void Paste()
        //{
        //    if (this.trvForm.SelectedNode != null && this.editNode != null)
        //    {
        //        Int64 newParentId = 0;

        //        foreach (TreeNode node in this.trvForm.SelectedNode.Nodes)
        //        {
        //            if (node.Text.Trim() == this.editNode.Text.Trim())
        //            {
        //                new PresentationLib.MessageBox
        //                {
        //                    DialogueType = PresentationLib.MessageBox.Type.Error,
        //                    Heading = "Splash"
        //                }.Show("Duplicate node exists. Cannot do the paste operation.");
        //                return;
        //            }
        //        }

        //        if (this.trvForm.SelectedNode.Parent != null)
        //            newParentId = (this.trvForm.SelectedNode.Tag as Facade.Artifact.Dto).Id;

        //        Facade.Artifact.Dto artifactDto;

        //        Table currentLoggedInUser = new Table
        //        {
        //            Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
        //            Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
        //        };

        //        BinAff.Facade.Library.Dto parent = new BinAff.Facade.Library.Dto { Id = newParentId };

        //        String path = String.Empty;
        //        if (this.trvForm.SelectedNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
        //            path = (this.trvForm.SelectedNode.Tag as Facade.Module.Dto).Artifact.Path;
        //        else
        //            path = (this.trvForm.SelectedNode.Tag as Facade.Artifact.Dto).Path;

        //        if (this.isCutAction)
        //        {
        //            artifactDto = new Facade.Container.Server(null).GetArtifactDtoByValue(editNode.Tag as Facade.Artifact.Dto);
        //            artifactDto.Version = artifactDto.Version + 1;
        //            artifactDto.ModifiedAt = DateTime.Now;
        //            artifactDto.ModifiedBy = currentLoggedInUser;
        //        }
        //        else
        //        {
        //            artifactDto = new Facade.Container.Server(null).GetArtifactDtoByValueForCopy(editNode.Tag as Facade.Artifact.Dto);
        //            artifactDto.CreatedAt = DateTime.Now;
        //            artifactDto.CreatedBy = currentLoggedInUser;
        //        }

        //        artifactDto.Parent = parent;
        //        artifactDto.Path = path + artifactDto.FileName + this.formDto.Rule.PathSeperator;

        //        this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
        //        {
        //            Dto = artifactDto,
        //        };

        //        this.facade = new Facade.Container.Server(this.formDto);
        //        this.facade.Paste(this.isCutAction);

        //        if (!this.facade.IsError)
        //        {
        //            TreeNode selectNode; //this node will be the focussed node
        //            TreeNode actorNode;

        //            if (this.isCutAction)
        //            {
        //                actorNode = this.editNode;
        //                selectNode = actorNode.Parent;

        //                //remove child dto from tag
        //                this.RemoveChildDtoFromParentDto(actorNode.Parent, actorNode);

        //                //remove node from tree
        //                this.trvForm.Nodes.Remove(actorNode);
        //            }
        //            else
        //            {
        //                actorNode = this.editNode.Clone() as TreeNode;
        //                selectNode = this.FindRootNode(this.trvForm.SelectedNode as TreeNode);
        //            }

        //            (this.trvForm.SelectedNode as TreeNode).Nodes.Add(actorNode);
        //            actorNode.Tag = this.formDto.ModuleFormDto.CurrentArtifact.Dto;
        //            this.AddChildDtoToParentDto(this.trvForm.SelectedNode, actorNode);
        //            this.AttachTagToChildNodes(actorNode);

        //            this.trvForm.SelectedNode = selectNode;

        //            //Adding items to listView for the selected node
        //            if (selectNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
        //            {
        //                this.SelectNode((selectNode.Tag as Facade.Module.Dto).Artifact);
        //            }
        //            else
        //            {
        //                this.SelectNode(selectNode.Tag as Facade.Artifact.Dto);
        //            }
        //        }
        //    }
        //    this.editNode = null;
        //}

        //public void Delete()
        //{
        //    if (this.trvForm.SelectedNode != null)
        //    {
        //        //donot delete the root node
        //        if (this.trvForm.SelectedNode.Parent == null)
        //        {
        //            return;
        //        }

        //        this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
        //        {
        //            Dto = (this.trvForm.SelectedNode as TreeNode).Tag as Facade.Artifact.Dto,
        //        };

        //        this.facade = new Facade.Container.Server(this.formDto);
        //        this.facade.Delete();

        //        if (!this.facade.IsError)
        //        {
        //            Boolean isFirstLevelNode = false;
        //            Facade.Artifact.Dto parentNode;

        //            //Removing node from Parent Tag
        //            if (this.trvForm.SelectedNode.Parent.Parent == null) //First level nodes [nodes whose parent id is null]      
        //            {
        //                isFirstLevelNode = true;
        //                parentNode = (this.trvForm.SelectedNode.Parent.Tag as Facade.Module.Dto).Artifact;
        //            }
        //            else
        //            {
        //                parentNode = this.trvForm.SelectedNode.Parent.Tag as Facade.Artifact.Dto;
        //            }

        //            foreach (Facade.Artifact.Dto child in parentNode.Children)
        //            {
        //                if (child.Id == (this.trvForm.SelectedNode.Tag as Facade.Artifact.Dto).Id)
        //                {
        //                    parentNode.Children.Remove(child);
        //                    break;
        //                }
        //            }

        //            TreeNode node = this.trvForm.SelectedNode.Parent;
        //            this.trvForm.SelectedNode.Remove();
        //            this.trvForm.SelectedNode = node;

        //            //populating the path
        //            if (isFirstLevelNode)
        //            {
        //                //populating list view for the selected node
        //                this.SelectNode((node.Tag as Facade.Module.Dto).Artifact);
        //                this.txtAddress.Text = (node.Tag as Facade.Module.Dto).Artifact.Path;
        //            }
        //            else
        //            {
        //                this.SelectNode(node.Tag as Facade.Artifact.Dto);
        //                this.txtAddress.Text = (node.Tag as Facade.Artifact.Dto).Path;
        //            }

        //            this.formDto.ModuleFormDto.Dto = this.FindRootNode(node).Tag as Facade.Module.Dto;
        //        }
        //    }
        //}

        //public void SelectAll()
        //{
        //    foreach (ListViewItem item in this.lsvContainer.Items)
        //    {
        //        item.Selected = true;
        //    }
        //    this.lsvContainer.Focus();
        //}

        //public void InvertSelection()
        //{
        //    foreach (ListViewItem item in this.lsvContainer.Items)
        //    {
        //        item.Selected = !item.Selected;
        //    }
        //}

        //#region Sort
        //SortOrder sortOrder = SortOrder.Ascending;
        //public void Sort(String sortColumn)
        //{
        //    this.sortColumn = sortColumn;
        //    this.lvwColumnSorter.Order = this.sortOrder;
        //    this.SortListView(this.sortColumn);
        //}

        //public void Sort(SortOrder sortOrder)
        //{
        //    this.sortOrder = sortOrder;
        //    this.lvwColumnSorter.Order = this.sortOrder;
        //    this.SortListView(this.sortColumn);
        //}

        //public void Sort(String sortColumn, SortOrder sortOrder)
        //{
        //    this.sortColumn = sortColumn;
        //    this.sortOrder = sortOrder;
        //    this.lvwColumnSorter.Order = this.sortOrder;
        //    this.SortListView(this.sortColumn);
        //}

        //#endregion

        //#endregion

        //public TreeNode CreateTreeNodes(Vanilla.Utility.Facade.Artifact.Dto node)
        //{
        //    TreeNode treeNode = new TreeNode(node.FileName)
        //    {
        //        Tag = node,
        //    };
        //    if (node.Children != null && node.Children.Count > 0)
        //    {
        //        foreach (Vanilla.Utility.Facade.Artifact.Dto child in node.Children)
        //        {
        //            if (child.Style == Vanilla.Utility.Facade.Artifact.Type.Directory)
        //            {
        //                treeNode.Nodes.Add(this.CreateTreeNodes(child));
        //            }
        //        }
        //    }
        //    return treeNode;
        //}

        //private TreeView CopyNodes(TreeView fromTreeView, TreeView toTreeView)
        //{
        //    TreeNode[] myTreeNodeArray = new TreeNode[fromTreeView.Nodes.Count];

        //    // Copy the tree nodes to the 'myTreeNodeArray' array.
        //    fromTreeView.Nodes.CopyTo(myTreeNodeArray, 0);

        //    // Remove all the tree nodes from the 'myTreeViewBase' TreeView.
        //    fromTreeView.Nodes.Clear();

        //    // Add the 'myTreeNodeArray' to the 'myTreeViewCustom' TreeView.
        //    toTreeView.Nodes.AddRange(myTreeNodeArray);

        //    return toTreeView;
        //}

        #endregion

    }

}

/* MinTrayBtn Class
 * Adds a 'Minimize to tray' Button to the Caption bar of the Form
 *
 * Created: 15.04.2005
 * Updated: 11.07.2005
 * Version: 0.8.5
 *
 * Changes: 11.07.2005 - Variable Caption Button size (adjusts itself to the system metrics)
 *                     - Fixed drawing issues on changes of the window width 
 * 
 *          20.05.2005 - added WM_GETTEXT for Drawing Button	(Draws the Button after the Text in the Title bar has changed)
 * 
 * Copyright (C) 2005, Tyron Madlener <mytodo@v-cm.net>
 */

//namespace TyronM
//{

//    using System;
//    using System.Drawing;
//    using System.Windows.Forms;
//    using System.Runtime.InteropServices;

//    public delegate void MinTrayBtnClickedEventHandler(object sender, EventArgs e);

//    /// <summary>
//    /// Summary description for Class.
//    /// </summary>
//    public class MinTrayBtn : NativeWindow
//    {
//        bool pressed = false;
//        Size wnd_size = new Size();
//        public bool captured;
//        Form parent;
//        public event MinTrayBtnClickedEventHandler MinTrayBtnClicked;

//        #region Constants
//        const int WM_SIZE = 5;
//        const int WM_SYNCPAINT = 136;
//        const int WM_MOVE = 3;
//        const int WM_ACTIVATE = 6;
//        const int WM_LBUTTONDOWN = 513;
//        const int WM_LBUTTONUP = 514;
//        const int WM_LBUTTONDBLCLK = 515;
//        const int WM_MOUSEMOVE = 512;

//        const int WM_PAINT = 15;

//        const int WM_GETTEXT = 13;

//        const int WM_NCCREATE = 129;
//        const int WM_NCLBUTTONDOWN = 161;
//        const int WM_NCLBUTTONUP = 162;
//        const int WM_NCMOUSEMOVE = 160;
//        const int WM_NCACTIVATE = 134;
//        const int WM_NCPAINT = 133;
//        const int WM_NCHITTEST = 132;
//        const int WM_NCLBUTTONDBLCLK = 163;

//        const int VK_LBUTTON = 1;

//        const int SM_CXSIZE = 30;
//        const int SM_CYSIZE = 31;
//        #endregion

//        #region WinAPI Imports
//        [DllImport("user32")]
//        public static extern int GetWindowDC(int hwnd);

//        [DllImport("user32")]
//        public static extern short GetAsyncKeyState(int vKey);

//        [DllImport("user32")]
//        public static extern int SetCapture(int hwnd);

//        [DllImport("user32")]
//        public static extern bool ReleaseCapture();

//        [DllImport("user32")]
//        public static extern int GetSysColor(int nIndex);

//        [DllImport("user32")]
//        public static extern int GetSystemMetrics(int nIndex);
//        #endregion

//        #region Constructor and Handle-Handler ^^
//        public MinTrayBtn(Form parent)
//        {
//            parent.HandleCreated += new EventHandler(this.OnHandleCreated);
//            parent.HandleDestroyed += new EventHandler(this.OnHandleDestroyed);
//            parent.TextChanged += new EventHandler(this.OnTextChanged);

//            this.parent = parent;
//        }

//        // Listen for the control's window creation and then hook into it.
//        internal void OnHandleCreated(object sender, EventArgs e)
//        {
//            // Window is now created, assign handle to NativeWindow.
//            AssignHandle(((Form)sender).Handle);
//        }
//        internal void OnHandleDestroyed(object sender, EventArgs e)
//        {
//            // Window was destroyed, release hook.
//            ReleaseHandle();
//        }

//        // Changing the Text invalidates the Window, so we got to Draw the Button again
//        private void OnTextChanged(object sender, EventArgs e)
//        {
//            DrawButton();
//        }
//        #endregion

//        #region WndProc
//        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
//        protected override void WndProc(ref Message m)
//        {
//            //label3.Text = "Button pressed: " + pressed;
//            //label4.Text = "Mouse captured: " + captured;

//            // Change the Pressed-State of the Button when the User pressed the
//            // left mouse button and moves the cursor over the button
//            if (m.Msg == WM_MOUSEMOVE)
//            {
//                Point pnt2 = new Point((int)m.LParam);
//                Size rel_pos2 = new Size(parent.PointToClient(new Point(parent.Location.X, parent.Location.Y)));
//                // Not needed because SetCapture seems to convert the cordinates anyway
//                //pnt2 = PointToClient(pnt2);
//                pnt2 -= rel_pos2;
//                //label2.Text = "Cursor @"+pnt2.X+"/"+pnt2.Y;

//                if (pressed)
//                {
//                    Point pnt = new Point((int)m.LParam);
//                    Size rel_pos = new Size(parent.PointToClient(new Point(parent.Location.X, parent.Location.Y)));
//                    //pnt = PointToClient(pnt);
//                    pnt -= rel_pos;

//                    if (!MouseinBtn(pnt))
//                    {
//                        pressed = false;
//                        DrawButton();
//                    }

//                }
//                else
//                {
//                    if ((GetAsyncKeyState(VK_LBUTTON) & (-32768)) != 0)
//                    {
//                        Point pnt = new Point((int)m.LParam);
//                        Size rel_pos = new Size(parent.PointToClient(new Point(parent.Location.X, parent.Location.Y)));
//                        //pnt = PointToClient(pnt);
//                        pnt -= rel_pos;

//                        if (MouseinBtn(pnt))
//                        {
//                            pressed = true;
//                            DrawButton();
//                        }
//                    }
//                }
//            }

//            // Ignore Double-Clicks on the Traybutton
//            if (m.Msg == WM_NCLBUTTONDBLCLK)
//            {
//                Point pnt = new Point((int)m.LParam);
//                Size rel_pos = new Size(parent.PointToClient(new Point(parent.Location.X, parent.Location.Y)));
//                pnt = parent.PointToClient(pnt);
//                pnt -= rel_pos;
//                if (MouseinBtn(pnt))
//                {
//                    return;
//                }
//            }

//            // Button released and eventually clicked
//            if (m.Msg == WM_LBUTTONUP)
//            {
//                ReleaseCapture();
//                captured = false;

//                if (pressed)
//                {
//                    pressed = false;
//                    DrawButton();

//                    Point pnt = new Point((int)m.LParam);
//                    Size rel_pos = new Size(parent.PointToClient(new Point(parent.Location.X, parent.Location.Y)));
//                    pnt -= rel_pos;
//                    if (MouseinBtn(pnt))
//                    {
//                        //TrayButton_clicked();
//                        EventArgs e = new EventArgs();
//                        if (MinTrayBtnClicked != null)
//                            MinTrayBtnClicked(this, e);
//                        return;
//                    }
//                }
//            }

//            // Clicking the Button - Capture the Mouse and await until the Uses relases the Button again
//            if (m.Msg == WM_NCLBUTTONDOWN)
//            {
//                Point pnt = new Point((int)m.LParam);
//                Size rel_pos = new Size(parent.PointToClient(new Point(parent.Location.X, parent.Location.Y)));
//                pnt = parent.PointToClient(pnt);
//                pnt -= rel_pos;

//                if (MouseinBtn(pnt))
//                {
//                    pressed = true;
//                    DrawButton();
//                    SetCapture((int)parent.Handle);
//                    captured = true;
//                    return;
//                }
//            }

//            // Drawing the Button and getting the Real Size of the Window
//            if (m.Msg == WM_ACTIVATE || m.Msg == WM_SIZE || m.Msg == WM_SYNCPAINT || m.Msg == WM_NCACTIVATE || m.Msg == WM_NCCREATE || m.Msg == WM_NCPAINT || m.Msg == WM_NCACTIVATE || m.Msg == WM_NCHITTEST || m.Msg == WM_PAINT)
//            {
//                if (m.Msg == WM_SIZE)
//                {
//                    wnd_size = new Size(new Point((int)m.LParam));
//                }
//                DrawButton();
//            }

//            base.WndProc(ref m);
//        }
//        #endregion

//        #region Button-Specific Functions
//        public bool MouseinBtn(Point click)
//        {
//            int btn_width = GetSystemMetrics(SM_CXSIZE);
//            int btn_height = GetSystemMetrics(SM_CYSIZE);
//            Size btn_size = new Size(btn_width, btn_height);

//            Point pos = new Point(wnd_size.Width - 3 * btn_width - 12 - (btn_width - 18), 6);


//            return click.X >= pos.X && click.X <= pos.X + btn_size.Width &&
//                   click.Y >= pos.Y && click.Y <= pos.Y + btn_size.Height;
//        }

//        public void DrawButton()
//        {
//            Graphics g = Graphics.FromHdc((IntPtr)GetWindowDC((int)parent.Handle)); //m.HWnd));
//            DrawButton(g, pressed);
//        }

//        public void DrawButton(Graphics g, bool pressed)
//        {
//            int btn_width = GetSystemMetrics(SM_CXSIZE);
//            int btn_height = GetSystemMetrics(SM_CYSIZE);

//            Point pos = new Point(wnd_size.Width - 3 * btn_width - 12 - (btn_width - 18), 6);

//            // real button size
//            btn_width -= 2;
//            btn_height -= 4;

//            Color light = SystemColors.ControlLightLight;
//            Color icon = SystemColors.ControlText;
//            Color background = SystemColors.Control;
//            Color shadow1 = SystemColors.ControlDark;
//            Color shadow2 = SystemColors.ControlDarkDark;

//            Color tmp1, tmp2;

//            if (pressed)
//            {
//                tmp1 = shadow2;
//                tmp2 = light;
//            }
//            else
//            {
//                tmp1 = light;
//                tmp2 = shadow2;
//            }

//            g.DrawLine(new Pen(tmp1), pos, new Point(pos.X + btn_width - 1, pos.Y));
//            g.DrawLine(new Pen(tmp1), pos, new Point(pos.X, pos.Y + btn_height - 1));

//            if (pressed)
//            {
//                g.DrawLine(new Pen(shadow1), pos.X + 1, pos.Y + 1, pos.X + btn_width - 2, pos.Y + 1);
//                g.DrawLine(new Pen(shadow1), pos.X + 1, pos.Y + 1, pos.X + 1, pos.Y + btn_height - 2);
//            }
//            else
//            {
//                g.DrawLine(new Pen(shadow1), pos.X + btn_width - 2, pos.Y + 1, pos.X + btn_width - 2, pos.Y + btn_height - 2);
//                g.DrawLine(new Pen(shadow1), pos.X + 1, pos.Y + btn_height - 2, pos.X + btn_width - 2, pos.Y + btn_height - 2);
//            }

//            g.DrawLine(new Pen(tmp2), pos.X + btn_width - 1, pos.Y + 0, pos.X + btn_width - 1, pos.Y + btn_height - 1);
//            g.DrawLine(new Pen(tmp2), pos.X + 0, pos.Y + btn_height - 1, pos.X + btn_width - 1, pos.Y + btn_height - 1);

//            g.FillRectangle(new SolidBrush(background), pos.X + 1 + Convert.ToInt32(pressed), pos.Y + 1 + Convert.ToInt32(pressed), btn_width - 3, btn_height - 3);

//            g.FillRectangle(new SolidBrush(icon), pos.X + (float)0.5625 * btn_width + Convert.ToInt32(pressed), pos.Y + (float)0.6428 * btn_height + Convert.ToInt32(pressed), btn_width * (float)0.1875, btn_height * (float)0.143);
//        }
//        #endregion

//    }
//}

