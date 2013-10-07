using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace BinAff.Presentation.Library
{

    public partial class Navigator : System.Windows.Forms.Form
    {

        [Category("Design")]
        public Panel LeftPanel
        {
            get
            {
                return this.pnlLeft;
            }
        }

        [Category("Design")]
        public Panel RightPanel
        {
            get
            {
                return this.pnlRight;
            }
        }

        [Category("Design")]
        public Panel Body
        {
            get
            {
                return this.pnlBody;
            }
        }

        [Category("Design")]
        public String Status
        {
            set
            {
                this.lblStatus.Text = value;
            }
        }

        public Navigator()
        {
            InitializeComponent();
        }

    }

}
