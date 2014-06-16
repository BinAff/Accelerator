using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Presentation.Library.Extension;

using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Utility.WinForm
{

    public partial class Open : Dialog
    {

        public Open()
            : base()
        {
            InitializeComponent();
            this.Register.DialogueMode = DialogueMode.Open;
        }

        private void Open_Load(object sender, EventArgs e)
        {
            this.Register.FormLoad += Register_FormLoad;
            this.Register.ReportLoad += Register_ReportLoad;
            this.Register.DocumentShown += Register_DocumentShown;
        }

        void Register_ReportLoad(ArtfFac.Dto currentArtifact)
        {
            this.ShowDocumentForm(currentArtifact);
        }

        void Register_FormLoad(ArtfFac.Dto currentArtifact)
        {
            this.ShowDocumentForm(currentArtifact);
        }

        private void Register_DocumentShown()
        {
            this.Close();
        }

        private void ShowDocumentForm(Facade.Artifact.Dto document)
        {
            //document.Module.artifactPath = document.Path;
            Document doc = this.GetDocumentForm(document);
            doc.MdiParent = this.Owner as System.Windows.Forms.Form;
            doc.AuditInfoChanged += doc_AuditInfoChanged;
            doc.Show();
        }

        private void doc_AuditInfoChanged(Document document)
        {

        }

        protected virtual Document GetDocumentForm(Facade.Artifact.Dto currentArtifact)
        {
            throw new NotImplementedException();
        }

        protected override String SetActionName()
        {
            return "Open";
        }

        protected override void DoAction()
        {
            this.Register.ShowDocument();
        }

    }

}
