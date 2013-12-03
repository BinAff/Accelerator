using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vanilla.Navigator.WinForm
{

    public partial class Configuration : UserControl
    {

        public Configuration()
        {
            InitializeComponent();
        }

        internal void PopulateModuleForConfiguration()
        {
            //This should be dynamic
            Button btnLodge = new Button
            {
                Text = "Lodge",
                Visible = true,
                Height = 30,
                Width = this.pnlMain.Panel1.Width,
                Dock = DockStyle.Top,
            };
            this.pnlMain.Panel1.Controls.Add(btnLodge);
            btnLodge.Click += btnLodge_Click;
            //

            Button btnGeneral = new Button
            {
                Text = "General",
                Visible = true,
                Height = 30,
                Width = this.pnlMain.Panel1.Width,
                Dock = DockStyle.Top,
            };
            this.pnlMain.Panel1.Controls.Add(btnGeneral);
            btnGeneral.Click += btnGeneral_Click;
        }

        void btnGeneral_Click(object sender, EventArgs e)
        {
            this.lsvConfiguration.Items.Clear();
            this.lsvConfiguration.Items.Add(new ListViewItem("Customer"));
            this.lsvConfiguration.Items.Add(new ListViewItem("User"));
            this.lsvConfiguration.Items.Add(new ListViewItem("Config Manager")
            {
                Tag = new Vanilla.Configuration.WinForm.ConfigManager
                {
                    TopLevel = true,
                }
            });
        }

        private void lsvConfiguration_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as ListView).FocusedItem.Tag != null)
            {
                ((sender as ListView).FocusedItem.Tag as Form).ShowDialog();
            }
        }

        void btnLodge_Click(object sender, EventArgs e)
        {
            this.lsvConfiguration.Items.Clear();

            //Currently Hard coding
            this.lsvConfiguration.Items.Add(new ListViewItem("Lodge")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.WinForm.Lodge", "AutoTourism.Lodge.WinForm")
            }); 
            
            this.lsvConfiguration.Items.Add(new ListViewItem("General Configuration")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.Configuration.WinForm.ConfigManager", "AutoTourism.Lodge.Configuration.WinForm")
            });

            this.lsvConfiguration.Items.Add(new ListViewItem("Building")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.Configuration.WinForm.Building", "AutoTourism.Lodge.Configuration.WinForm")
            });

            this.lsvConfiguration.Items.Add(new ListViewItem("Room")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.Configuration.WinForm.Room", "AutoTourism.Lodge.Configuration.WinForm")
            });
        }

        private Form InstantiateObject(String dataType, String assembly)
        {
            Type type = Type.GetType(dataType + ", " + assembly, true);
            return Activator.CreateInstance(type) as Form;
        }

    }
}
