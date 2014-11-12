using System;
using System.Windows.Forms;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Presentation.Library.Extension;

using ArtfFac = Vanilla.Utility.Facade.Artifact;
using ModDefFac = Vanilla.Utility.Facade.Module.Definition;

namespace Vanilla.Utility.WinForm
{

    public partial class Dialog : Form
    {

        public Boolean IsActionDone { get; protected set; }

        public ArtfFac.Category Category
        {
            get
            {
                return this.ucRegister.Category;
            }
            set
            {
                this.ucRegister.Category = value;
            }
        }

        public ModDefFac.Dto ModuleForFilter
        {
            get
            {
                return this.Register.TreeFilter;
            }
            set
            {
                this.Register.TreeFilter = value;
            }
        }

        public ArtfFac.Dto Document { get; protected internal set; }

        protected Register Register 
        {
            get
            {
                return this.ucRegister;
            }
        }

        protected String DocumentName
        {
            get
            {
                return this.txtDocName.Text.Trim();
            }
        }

        public Dialog()
        {
            InitializeComponent();
        }

        private void Dialog_Load(object sender, System.EventArgs e)
        {
            this.btnAction.Text = this.SetActionName();
            this.ucRegister.Category = this.Category;
            this.ucRegister.TreeFilter = this.ModuleForFilter;
            this.ucRegister.DocumentClicked += ucRegister_DocumentClicked;
            this.ucRegister.DocumentDoubleClicked += ucRegister_DocumentDoubleClicked;

            this.cboExtension.DisplayMember = "Name";
        }

        protected virtual String SetActionName()
        {
            return "Action";
        }

        private void Dialog_Shown(object sender, EventArgs e)
        {
            if (DesignMode) return;
            this.ucRegister.LoadForm();
            this.cboExtension.Bind(this.GetExtensionList());
            this.cboExtension.SelectedIndex = 0;
        }

        void ucRegister_DocumentClicked()
        {
            this.txtDocName.Text = this.ucRegister.CurrentArtifact.FullFileName;
        }

        void ucRegister_DocumentDoubleClicked()
        {
            this.DoAction();
            this.Close();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            this.DoAction();
            this.Close();
        }

        private void txtDocName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DoAction();
            }
        }

        /// <summary>
        /// Do when Action button is clicked
        /// </summary>
        protected virtual void DoAction()
        {
            throw new NotImplementedException();
        }

        protected virtual List<Table> GetExtensionList()
        {
            throw new NotImplementedException();
        }
        
    }

}
