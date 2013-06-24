using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Vanilla.Navigator.Presentation
{

    public partial class MenuSummary : UserControl
    {

        public delegate void ChangePath(MenuSummary sender);
        public event ChangePath PathChanged;

        [Category("Definition")]
        public String Label
        {
            get
            {
                return this.lblLabel.Text;
            }
            set
            {
                if (value != null && this.lblLabel.Text != value)
                    this.lblLabel.Text = value;
            }
        }

        [Category("Definition")]
        public Image Image
        {
            get
            {
                return this.picImage.Image;
            }
            set
            {
                if (value != null && this.picImage.Image != value)
                    this.picImage.Image = value;
            }
        }

        public DetailMenu detailMenu;
        [Category("Definition")]
        public DetailMenu DetailMenu
        {
            get
            {
                return this.detailMenu;
            }
            set
            {
                if (value != null && this.detailMenu != value)
                {
                    this.detailMenu = value;
                    this.detailMenu.Dock = DockStyle.Fill;
                }
            }
        }

        private Body body;
        [Category("Definition")]
        public Body Body
        {
            get
            {
                return this.body;
            }
            set
            {
                if (value != null && this.body != value)
                {
                    this.body = value;
                    this.body.Dock = DockStyle.Fill;
                    this.body.PathChanged += new Body.ChangePath(Body_PathChange);
                }
            }
        }

        public MenuSummary()
        {
            InitializeComponent();
        }

        private void Body_PathChange()
        {
            this.detailMenu.Navigate(this.body.SelectedItem.Path);
            PathChanged(this);
            this.body.Focus();
        }

        private void MenuSummary_SizeChanged(object sender, EventArgs e)
        {
            this.picImage.Width = this.Height;
        }

        private void lblLabel_Click(object sender, EventArgs e)
        {
            this.HandleClick(e);
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            this.HandleClick(e);
        }

        private void HandleClick(EventArgs e)
        {           
            if (this.detailMenu.Artifact != null)
            {
                this.Body.AttachArtifacts(this.detailMenu.Artifact.Children);
            }
            this.OnClick(e);
        }

        public void Highlight()
        {
            this.BackColor = Color.DarkBlue;
            this.lblLabel.ForeColor = Color.White;
            this.lblLabel.Font = new Font(this.lblLabel.Font, FontStyle.Bold);
        }

        public void Reset()
        {
            this.BackColor = Color.LightGray;
            this.lblLabel.ForeColor = Color.Black;
            this.lblLabel.Font = new Font(this.lblLabel.Font, FontStyle.Regular);
        }

    }

}
