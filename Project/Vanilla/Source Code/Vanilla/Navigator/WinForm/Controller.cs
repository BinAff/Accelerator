using System;
using System.Windows.Forms;

using Vanilla.Navigator.WinForm.Properties;

namespace Vanilla.Navigator.Presentation
{

    public partial class Controller : UserControl
    {

        private MenuSummary[] items;
        public MenuSummary[] Items
        {
            get
            {
                return this.items;
            }
            set
            {
                if (value != null && this.items != value)
                {
                    this.items = value;
                    this.LoadMenuSummeryList(value);
                }
            }
        }

        private MenuSummary currentItem;        

        public Controller()
        {
            InitializeComponent();
        }

        private void btnHideLeftPanel_Click(object sender, EventArgs e)
        {
            this.spcBody.Panel1Collapsed = true;
            this.btnShowLeftPanel.Show();
        }

        private void btnShowLeftPanel_Click(object sender, EventArgs e)
        {
            this.spcBody.Panel1Collapsed = false;
            this.btnShowLeftPanel.Hide();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Navidate();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Navidate();
            }
        }

        /// <summary>
        /// Load all menu summary items and attach appropriate events
        /// </summary>
        /// <param name="controls"></param>
        private void LoadMenuSummeryList(MenuSummary[] controls)
        {
            this.spcMenu.Panel2.Controls.Clear();
            if (controls.Length > 0)
            {
                this.spcMenu.SplitterDistance = this.spcMenu.Height - controls.Length * controls[0].Height - Settings.Default.SplitterHeightAdjustment;
            }
            Int32 controlCount = controls.Length;
            if (controls != null && controlCount > 0)
            {
                while (controlCount > 0)
                {
                    this.spcMenu.Panel2.Controls.Add(controls[--controlCount]);
                    controls[controlCount].Dock = DockStyle.Top;
                    controls[controlCount].PathChanged += new MenuSummary.ChangePath(MenuSummary_PathChanged);
                    controls[controlCount].Click += new EventHandler(MenuSummary_Click);
                    controls[controlCount].DetailMenu.Click += new EventHandler(DetailMenu_Click);
                }
            }
        }

        private void MenuSummary_PathChanged(MenuSummary sender)
        {
            txtAddress.Text = sender.DetailMenu.SelectedArtifact.Path;
        }

        private void MenuSummary_Click(object sender, EventArgs e)
        {
            this.SelectMenu((MenuSummary)sender);
        }

        private void DetailMenu_Click(object sender, EventArgs e)
        {
            //Show address in address bar
            this.txtAddress.Text = this.currentItem.DetailMenu.SelectedArtifact.Path;

            //Transfer selected node information from detail menu to body
            this.currentItem.Body.SelectChildern(this.currentItem.DetailMenu.SelectedArtifact);
        }

        private void Navidate()
        {
            String[] tokens = this.txtAddress.Text.Split(new String[] { new Crystal.Navigator.Rule.Data().ModuleSeperator }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length > 0)
            {
                MenuSummary menu = GetMenuSummary(tokens[0]);
                this.SelectMenu(menu);
                if (tokens.Length == 2)
                {
                    menu.DetailMenu.Navigate(this.txtAddress.Text);
                }
            }
        }

        /// <summary>
        /// Populate detail menu and body for selected menu
        /// </summary>
        /// <param name="menuSummary">Menu summary</param>
        private void SelectMenu(MenuSummary menuSummary)
        {

            if (this.currentItem != null) this.currentItem.Reset();
            if (menuSummary != null) menuSummary.Highlight();

            //Attach body in panel
            this.spcBody.Panel2.Controls.Clear();
            this.spcBody.Panel2.Controls.Add(this.btnShowLeftPanel);
            if (menuSummary != null)
            {
                this.spcBody.Panel2.Controls.Add(menuSummary.Body);
            }

            //Attach detail menu in panel
            this.spcMenu.Panel1.Controls.Clear();
            this.spcMenu.Panel1.Controls.Add(this.btnHideLeftPanel);
            if (menuSummary != null)
            {
                this.spcMenu.Panel1.Controls.Add(menuSummary.DetailMenu);
            }
            this.currentItem = menuSummary;
        }

        private MenuSummary GetMenuSummary(String menuName)
        {
            Int32 count = this.items.Length;
            for (Int32 i = 0; i < count; i++)
            {
                if (this.items[i].Label == menuName) return items[i];
            }
            return null;
        }

    }

}
