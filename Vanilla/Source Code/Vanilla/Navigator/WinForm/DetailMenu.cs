using System;
using System.Windows.Forms;

using Crystal.Navigator.Component;

namespace Vanilla.Navigator.Presentation
{

    public partial class DetailMenu : UserControl
    {
        
        /// <summary>
        /// Heading of detail menu
        /// </summary>
        public String Heading
        {
            get
            {
                return this.lblHeading.Text;
            }
            set
            {
                if (value != null && this.lblHeading.Text != value)
                    this.lblHeading.Text = value;
            }
        }

        public Crystal.Navigator.Component.Artifact.Data Artifact { get; protected set; }

        public Crystal.Navigator.Component.Artifact.Data SelectedArtifact { get; set; }

        public DetailMenu()
        {
            InitializeComponent();
        }
        
        public virtual void Navigate(String path)
        {
            throw new NotImplementedException();
        }

    }

}
