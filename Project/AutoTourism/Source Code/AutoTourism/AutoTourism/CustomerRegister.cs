
using System;
using System.Windows.Forms;

using AutoTourism.Customer.WinForm;

namespace AutoTourism
{
    public partial class CustomerRegister : Form
    {
        public CustomerRegister()
        {
            InitializeComponent();
        }

        private void CustomerRegister_Load(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = new PersonalInformation()
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = System.Drawing.Color.White
            };
            panel1.Controls.Add(personalInformation);
            personalInformation.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = panel1.Controls[0] as PersonalInformation;
            foreach (Control control in personalInformation.Controls)
            {
                if (control.Name == "cboCustomer")
                    (control as ComboBox).SelectedIndex = -1;
                else if (control.Name == "lblIdProofTypeName")
                    (control as Label).Text = String.Empty;
                else if (control.GetType() == typeof(TextBox))                
                    (control as TextBox).Text = String.Empty;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new CustomerForm().ShowDialog();
        }
    }
}
