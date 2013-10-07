using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Crystal.Navigator.Component;

namespace Vanilla.Navigator.Presentation
{

    public partial class Body : UserControl
    {

        public delegate void ChangePath();
        public event ChangePath PathChanged;

        protected String PathSeperator { get; private set; }

        private List<Crystal.Navigator.Component.Artifact.Data> visibleItems;
        protected virtual List<Crystal.Navigator.Component.Artifact.Data> VisibleItems
        {
            get
            {
                return this.visibleItems;
            }
            set
            {
                if (visibleItems != value)
                {
                    this.visibleItems = value;
                    this.BindToContainer();
                }
            }
        }

        public Crystal.Navigator.Component.Artifact.Data SelectedItem { get; protected set; }

        public Body()
        {
            InitializeComponent();
        }

        private void Body_Load(object sender, EventArgs e)
        {
            this.PathSeperator = new Crystal.Navigator.Rule.Data().PathSeperator;
            this.BindToContainer();
        }

        private void Body_Click(object sender, EventArgs e)
        {
            this.HandleClick();
        }

        private void Body_DoubleClick(object sender, EventArgs e)
        {
            if (PathChanged != null) PathChanged();
            this.HandleDoubleClick();
        }

        /// <summary>
        /// Select children under given path
        /// </summary>
        /// <param name="path">Path of current folder</param>
        public void SelectChildern(Crystal.Navigator.Component.Artifact.Data selectedNode)
        {
            this.VisibleItems = selectedNode.Children;
        }

        /// <summary>
        /// Attach artifacts to body container
        /// </summary>
        /// <param name="artifacts"></param>
        public void AttachArtifacts(List<Crystal.Navigator.Component.Artifact.Data> artifacts)
        {
            this.VisibleItems = artifacts;
        }

        /// <summary>
        /// Handle click event on user control
        /// </summary>
        protected virtual void HandleClick()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handle double click event on user control
        /// </summary>
        protected virtual void HandleDoubleClick()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Bind data to container inside body
        /// </summary>
        protected virtual void BindToContainer()
        {
            throw new NotImplementedException();
        }

    }

}
