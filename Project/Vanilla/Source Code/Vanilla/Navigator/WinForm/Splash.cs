using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Vanilla.Navigator.WinForm
{

    public partial class Splash : System.Windows.Forms.Form
    {

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            new Facade.Splash.Server(null).LoadForm();
            Thread t = new Thread(delegate()
            {
                Application.Run(Vanilla.Navigator.WinForm.Container.CreateInstance());
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            
            this.Close();
        }

    }

}
