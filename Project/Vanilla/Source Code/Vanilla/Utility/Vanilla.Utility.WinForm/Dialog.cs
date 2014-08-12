﻿using System;
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

        public ModDefFac.Dto ModuleForFilter { get; set; }

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

        public delegate void OnFolderSaved(ArtfFac.Dto document);
        public event OnFolderSaved FolderSaved;

        public Dialog()
        {
            InitializeComponent();
        }

        private void Open_Load(object sender, System.EventArgs e)
        {
            this.btnAction.Text = this.SetActionName();
            this.ucRegister.Category = this.Category;
            this.ucRegister.TreeFilter = this.ModuleForFilter;
            this.ucRegister.DocumentClicked += ucRegister_DocumentClicked;

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

        private void ucRegister_FolderSaved(ArtfFac.Dto folder)
        {
            this.FolderSaved(folder);
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
