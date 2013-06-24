using System;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using WinForm = System.Windows.Forms;

using BinAff.Presentation.Library;

using Crystal.Navigator.Component;

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

        protected WinForm.View ViewStyle
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
            this.SelectNode((WinForm.ListView)sender);
            this.OnClick(e);
        }

        private void lsvBody_DoubleClick(object sender, EventArgs e)
        {
            this.SelectNode((WinForm.ListView)sender);
            this.OnDoubleClick(e);
        }

        private void SelectNode(WinForm.ListView listView)
        {
            if (this.SelectedItem == null) this.SelectedItem = new Artifact();
            if (listView != null && listView.SelectedItems != null && listView.SelectedItems.Count > 0)
            {
                this.SelectedItem = (Artifact)this.rootNodes[listView.SelectedItems[0].Index].Tag;
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

        protected virtual List<Artifact> CreateNodes()
        {
            return null;
        }

        private ListViewItemWithImage[] ConvertToListViewItem(List<Artifact> items)
        {
            if (items != null && items.Count > 0)
            {
                ListViewItemWithImage[] retArray = new ListViewItemWithImage[items.Count];
                Int32 i = 0;
                foreach (Artifact artf in items)
                {
                    retArray[i] = CreateListViewItem(artf);
                    retArray[i++].Tag = artf;
                }
                return retArray;
            }

            return null;
        }

        public ListViewItemWithImage CreateListViewItem(Artifact artf)
        {
            return new ListViewItemWithImage
            {
                Text = artf.FileName,
                Tag = artf,
                ImageIndex = (artf.Style == Artifact.Type.Document) ? 0 : 1,
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
            this.lblCreatedByValue.Text = base.SelectedItem.CreatedBy.Name;
            this.lblCreatedAtValue.Text = base.SelectedItem.CreatedAt.ToShortDateString();
            this.lblModifiedByValue.Text = base.SelectedItem.ModifiedBy.Name;
            this.lblModifiedAtValue.Text = base.SelectedItem.ModifiedAt == DateTime.MinValue? String.Empty : base.SelectedItem.ModifiedAt.ToShortDateString();
        }

        protected sealed override void HandleDoubleClick()
        {
            if (base.SelectedItem != null && base.SelectedItem.Style == Artifact.Type.Document)
            {
                //Open form by passing artifact
                Thread t = new Thread(new ThreadStart(delegate()
                {
                    WinForm.Application.Run(GetStartUpForm());
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
        protected virtual WinForm.Form GetStartUpForm()
        {
            return new WinForm.Form();
        }

    }

}
