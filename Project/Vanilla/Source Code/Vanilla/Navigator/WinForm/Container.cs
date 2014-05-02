using System;
using System.Windows.Forms;

using BinAff.Facade.Cache;

using Vanilla.Tool.WinForm;
using VanAcc = Vanilla.Guardian.Facade.Account;
using System.Drawing;

namespace Vanilla.Navigator.WinForm
{

    public partial class Container : Form
    {

        //[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        //static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

        //private const uint WM_SETICON = 0x80u;
        //private const int ICON_SMALL = 0;
        //private const int ICON_BIG = 1;

        //[System.Runtime.InteropServices.DllImport("User32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        //public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        //[System.Runtime.InteropServices.DllImport("User32.dll")]
        //private static extern IntPtr GetWindowDC(IntPtr hWnd);

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    const int WM_NCPAINT = 0x85;
        //    if (m.Msg == WM_NCPAINT)
        //    {
        //        IntPtr hdc = GetWindowDC(m.HWnd);
        //        //if ((int)hdc != 0)
        //        //{
        //        //    System.Drawing.Graphics g = System.Drawing.Graphics.FromHdc(hdc);
                    
        //        //    //g.FillRectangle(System.Drawing.Brushes.Green, new System.Drawing.Rectangle(0, 0, this.Width, 23));
        //        //    //g.Flush();
        //        //    g.FillRectangle(System.Drawing.Brushes.White, new System.Drawing.Rectangle(0, 0, 40, 40));
        //        //    g.Flush();
        //        //    ReleaseDC(m.HWnd, hdc);
        //        //}
        //    }
        //}

        private Vanilla.Guardian.WinForm.Login loginForm;
        private Boolean isLoggedIn;
        private String selectedNodePath;

        private Timer connectionTimer;
        
        public Container()
        {
            InitializeComponent();

            //SendMessage(this.Handle, WM_SETICON, ICON_SMALL, Properties.Resources.SmallIcon.Handle);
            //SendMessage(this.Handle, WM_SETICON, ICON_BIG, Properties.Resources.BigIcon.Handle);
        }
        
        public Container(String selectedNodePath)
            : this()
        {
            this.isLoggedIn = true;
            this.selectedNodePath = selectedNodePath;
        }

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
            this.connectionTimer.Start();            
        }

        void connectionTimer_Tick(object sender, EventArgs e)
        {
            this.ShowConnectionStatus();
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

        private void ShowControls()
        {
            Timer t = new Timer { Interval = 10 };
            t.Tick += t_Tick;
            t.Start();
            this.ucRegister.LoadForm();
            this.ucRegister.LoggedOut += ucRegister_LoggedOut;
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

        void ucRegister_LoggedOut()
        {
            this.LogOut();
        }

        private void LogOut()
        {
            new Facade.Container.Server(null).Logout();
            this.HideControl();
            this.ShowLoginForm();

            this.Text = this.Text.Split(new Char[] { ' ', ':', ' ' })[0];
        }

        void t_Tick(object sender, EventArgs e)
        {
            this.progressBar.Value = (Int32)Math.Abs(this.ucRegister.GetStatus() * 0.8);
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

        private void ShowConnectionStatus()
        {
            if (new Facade.Container.Server(null).IsConnected())
            {
                this.shapeOnlineStatus.BackColor = this.shapeOnlineStatus.BorderColor = Color.Green;
                this.btnConnect.Hide();
                this.connectionTimer.Stop();
            }
            else
            {
                this.shapeOnlineStatus.BackColor = this.shapeOnlineStatus.BorderColor = Color.Red;
                this.btnConnect.Show();
            }
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

    }

    internal class DwmApi 
    { 
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmEnableBlurBehindWindow(IntPtr hWnd, DWM_BLURBEHIND pBlurBehind);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, MARGINS pMargins);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmEnableComposition(bool bEnable);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmGetColorizationColor(out int pcrColorization, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]out bool pfOpaqueBlend);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern IntPtr DwmRegisterThumbnail(IntPtr dest, IntPtr source);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmUnregisterThumbnail(IntPtr hThumbnail);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmUpdateThumbnailProperties(IntPtr hThumbnail, DWM_THUMBNAIL_PROPERTIES props);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmQueryThumbnailSourceSize(IntPtr hThumbnail, out System.Drawing.Size size);
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public class DWM_THUMBNAIL_PROPERTIES
        {
            public uint dwFlags;
            public RECT rcDestination;
            public RECT rcSource;
            public byte opacity;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public bool fVisible; [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public bool fSourceClientAreaOnly;
            public const uint DWM_TNP_RECTDESTINATION = 0x00000001;
            public const uint DWM_TNP_RECTSOURCE = 0x00000002;
            public const uint DWM_TNP_OPACITY = 0x00000004;
            public const uint DWM_TNP_VISIBLE = 0x00000008;
            public const uint DWM_TNP_SOURCECLIENTAREAONLY = 0x00000010;
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public class MARGINS
        {
            public int cxLeftWidth, cxRightWidth, cyTopHeight, cyBottomHeight;
            public MARGINS(int left, int top, int right, int bottom)
            {
                cxLeftWidth = left;
                cyTopHeight = top;
                cxRightWidth = right;
                cyBottomHeight = bottom;
            }
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public class DWM_BLURBEHIND
        {
            public uint dwFlags;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public bool fEnable; public IntPtr hRegionBlur;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public bool fTransitionOnMaximized;
            public const uint DWM_BB_ENABLE = 0x00000001;
            public const uint DWM_BB_BLURREGION = 0x00000002;
            public const uint DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004;
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
        }
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

