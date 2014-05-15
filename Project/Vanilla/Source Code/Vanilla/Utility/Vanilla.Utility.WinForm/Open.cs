using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Presentation.Library.Extension;

using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Utility.WinForm
{

    public partial class Open : System.Windows.Forms.Form
    {

        public ArtfFac.Category Category { get; set; }

        public Open()
        {
            InitializeComponent();
        }

        private void Open_Load(object sender, System.EventArgs e)
        {
            this.ucRegister.Category = this.Category;
            this.ucRegister.LoadForm();
            this.ucRegister.FormLoad += ucRegister_FormLoad;
            this.ucRegister.ReportLoad += ucRegister_ReportLoad;
            this.ucRegister.DocumentShown += ucRegister_DocumentShown;

            this.cboExtension.DisplayMember = "Name";
            this.cboExtension.Bind(this.GetExtensionList());
            this.cboExtension.SelectedIndex = 0;
        }

        void ucRegister_FormLoad(Facade.Artifact.Dto currentArtifact)
        {
            this.ShowDocumentForm(currentArtifact);
        }

        void ucRegister_ReportLoad(Facade.Artifact.Dto currentArtifact, Facade.Register.Server registerFacade)
        {
            this.ShowDocumentForm(currentArtifact);
        }
        
        void ucRegister_DocumentShown()
        {
            this.Close();
        }
        
        private void ShowDocumentForm(Facade.Artifact.Dto document)
        {
            document.Module.artifactPath = document.Path;
            Document report = this.GetDocumentForm(document);
            report.MdiParent = this.Owner as System.Windows.Forms.Form;
            report.AuditInfoChanged += report_AuditInfoChanged;
            report.Show();
        }

        private void report_AuditInfoChanged(Document document)
        {
            
        }

        protected virtual Document GetDocumentForm(Facade.Artifact.Dto currentArtifact)
        {
            throw new NotImplementedException();
        }

        protected virtual List<Table> GetExtensionList()
        {
            throw new NotImplementedException();
        }

    }

}
