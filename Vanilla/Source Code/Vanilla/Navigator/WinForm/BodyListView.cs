using System;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using WinForm = System.Windows.Forms;

using BinAff.Presentation.Library;

using Crystal.Navigator.Component;
using System.Windows.Forms;

namespace Vanilla.Navigator.Presentation
{

    public partial class BodyListView : Body
    {

        private ListViewItemWithImage[] rootNodes;
        protected ListViewItemWithImage[] RootNodes
        {
            get
            {
                return this.rootNodes;
            }
            private set
            {
                if (value == null)
                {
                    this.rootNodes = value;
                    this.lsvBody.Clear();
                }
                else if (this.rootNodes != value)
                {
                    this.rootNodes = value;
                    this.lsvBody.Clear();
                    this.lsvBody.Items.AddRange(this.rootNodes);
                }
            }
        }

        protected View ViewStyle
        {
            get
            {
                return this.lsvBody.View;
            }
            set
            {
                if (this.lsvBody.View != value)
                {
                    this.lsvBody.View = value;
                }
            }
        }

        public BodyListView()
        {
            InitializeComponent();
        }

        private void BodyListView_Load(object sender, EventArgs e)
        {
            this.AttachImages();
        }

        private void lsvBody_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectNode((ListView)sender);
            this.OnClick(e);
        }

        private void lsvBody_DoubleClick(object sender, EventArgs e)
        {
            this.SelectNode((ListView)sender);
            this.OnDoubleClick(e);
        }

        private void SelectNode(ListView listView)
        {
            if (this.SelectedItem == null) this.SelectedItem = new Crystal.Navigator.Component.Artifact.Data();
            if (listView != null && listView.SelectedItems != null && listView.SelectedItems.Count > 0)
            {
                this.SelectedItem = (Crystal.Navigator.Component.Artifact.Data)this.rootNodes[listView.SelectedItems[0].Index].Tag;
            }
        }
        
        protected void ClearImages()
        {
            this.imlLargeIcons.Images.Clear();
        }

        protected void AddImage(Image img)
        {
            this.imlLargeIcons.Images.Add(img);
        }

        protected virtual void AttachImages()
        {
        }

        protected virtual List<Crystal.Navigator.Component.Artifact.Data> CreateNodes()
        {
            return null;
        }

        private ListViewItemWithImage[] ConvertToListViewItem(List<Crystal.Navigator.Component.Artifact.Data> items)
        {
            if (items != null && items.Count > 0)
            {
                ListViewItemWithImage[] retArray = new ListViewItemWithImage[items.Count];
                Int32 i = 0;
                foreach (Crystal.Navigator.Component.Artifact.Data artf in items)
                {
                    retArray[i] = CreateListViewItem(artf);
                    retArray[i++].Tag = artf;
                }
                return retArray;
            }

            return null;
        }

        public ListViewItemWithImage CreateListViewItem(Crystal.Navigator.Component.Artifact.Data artf)
        {
            return new ListViewItemWithImage
            {
                Text = artf.FileName,
                Tag = artf,
                ImageIndex = (artf.Style == Crystal.Navigator.Component.Artifact.Data.Type.Document) ? 0 : 1,
            };
        }

        /// <summary>
        /// Handle click event
        /// <remarks>
        /// Populate in description area
        /// </remarks>
        /// </summary>
        protected override void HandleClick()
        {
            this.lblNameValue.Text = base.SelectedItem.FileName;
            this.lblVersionValue.Text = base.SelectedItem.Version.ToString();
            this.lblCreatedByValue.Text = base.SelectedItem.CreatedBy.Profile.Name;
            this.lblCreatedAtValue.Text = base.SelectedItem.CreatedAt.ToShortDateString();
            this.lblModifiedByValue.Text = base.SelectedItem.ModifiedBy.Profile.Name;
            this.lblModifiedAtValue.Text = base.SelectedItem.ModifiedAt == DateTime.MinValue? String.Empty : base.SelectedItem.ModifiedAt.ToShortDateString();
        }

        protected sealed override void HandleDoubleClick()
        {
            if (base.SelectedItem != null && base.SelectedItem.Style == Crystal.Navigator.Component.Artifact.Data.Type.Document)
            {
                //Open form by passing artifact
                Thread t = new Thread(new ThreadStart(delegate()
                {
                    Application.Run(GetStartUpForm());
                }));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            else
            {
                //Navigate to proper content
                base.VisibleItems = base.SelectedItem.Children;                
            }
        }

        /// <summary>
        /// Bind data to container inside body
        /// </summary>
        protected override void BindToContainer()
        {
            this.RootNodes = this.ConvertToListViewItem(this.VisibleItems);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual System.Windows.Forms.Form GetStartUpForm()
        {
            return new System.Windows.Forms.Form();
        }

    }

}
