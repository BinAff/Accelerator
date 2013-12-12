﻿using System;
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
            if (this.pnlMain.Panel1.Controls.Count == 0)
            {
                //This should be dynamic
                Button btnLodge = new Button
                {
                    Text = "Lodge",
                    Dock = DockStyle.Top,
                };
                this.pnlMain.Panel1.Controls.Add(btnLodge);
                btnLodge.Click += btnLodge_Click;
                //

                Button btnGeneral = new Button
                {
                    Text = "General",
                    Dock = DockStyle.Top,
                };
                this.pnlMain.Panel1.Controls.Add(btnGeneral);
                btnGeneral.Click += btnGeneral_Click;
            }
        }

        void btnGeneral_Click(object sender, EventArgs e)
        {
            this.lsvConfiguration.Items.Clear();
            this.lsvConfiguration.Items.Add(new ListViewItem("Customer")
            {
                Tag = this.InstantiateObject("AutoTourism.Customer.WinForm.CustomerRule", "AutoTourism.Customer.WinForm"),
            });
            this.lsvConfiguration.Items.Add(new ListViewItem("User")
            {
                Tag = new Vanilla.Guardian.WinForm.UserRule(),
            });
            this.lsvConfiguration.Items.Add(new ListViewItem("State")
            {
                Tag = new Vanilla.Configuration.WinForm.State(),
            });
            this.lsvConfiguration.Items.Add(new ListViewItem("Identity Proof Type")
            {
                Tag = new Vanilla.Configuration.WinForm.IdentityProofType(),
            });
            this.lsvConfiguration.Items.Add(new ListViewItem("Initial")
            {
                Tag = new Vanilla.Configuration.WinForm.Initial(),
            });
            this.lsvConfiguration.Items.Add(new ListViewItem("Payment Type")
            {
                Tag = new Vanilla.Configuration.WinForm.PaymentType(),
            });
            this.lsvConfiguration.Items.Add(new ListViewItem("Security Question")
            {
                Tag = new Vanilla.Configuration.WinForm.SecurityQuestion(),
            });
        }

        private void lsvConfiguration_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as ListView).FocusedItem.Tag != null)
            {
                ((sender as ListView).FocusedItem.Tag as Form).ShowDialog(this);
            }
        }

        void btnLodge_Click(object sender, EventArgs e)
        {
            this.lsvConfiguration.Items.Clear();

            //Currently Hard coding
            this.lsvConfiguration.Items.Add(new ListViewItem("Lodge")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.WinForm.Lodge", "AutoTourism.Lodge.WinForm"),
            });

            this.lsvConfiguration.Items.Add(new ListViewItem("Building Type")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.Configuration.WinForm.BuildingType", "AutoTourism.Lodge.Configuration.WinForm"),
            });

            this.lsvConfiguration.Items.Add(new ListViewItem("Room Type")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.Configuration.WinForm.RoomType", "AutoTourism.Lodge.Configuration.WinForm"),
            });

            this.lsvConfiguration.Items.Add(new ListViewItem("Room Category")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.Configuration.WinForm.RoomCategory", "AutoTourism.Lodge.Configuration.WinForm"),
            });

            this.lsvConfiguration.Items.Add(new ListViewItem("Building")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.Configuration.WinForm.Building", "AutoTourism.Lodge.Configuration.WinForm"),
            });

            this.lsvConfiguration.Items.Add(new ListViewItem("Room")
            {
                Tag = this.InstantiateObject("AutoTourism.Lodge.Configuration.WinForm.Room", "AutoTourism.Lodge.Configuration.WinForm"),
            });
        }

        private Form InstantiateObject(String dataType, String assembly)
        {
            Type type = Type.GetType(dataType + ", " + assembly, true);
            return Activator.CreateInstance(type) as Form;
        }

    }
}
