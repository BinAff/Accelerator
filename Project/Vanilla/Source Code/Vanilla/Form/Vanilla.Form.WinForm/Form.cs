using System;

namespace BinAff.Presentation.Library
{

    public partial  class Form : System.Windows.Forms.Form
    {

        public Boolean IsModified { get; protected set; }

        public Form()
        {
            InitializeComponent();            
        }

    }

}
