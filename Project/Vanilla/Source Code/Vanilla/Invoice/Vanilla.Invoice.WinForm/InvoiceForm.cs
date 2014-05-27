using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vanilla.Invoice.WinForm
{

    public partial class InvoiceForm : System.Windows.Forms.Form
    {

        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Will be disabled after generation
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Disabled initially, enabled after generation
            //new Invoice().ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Can be added later
            //Disabled initially, enabled after generation
        }

    }

}
