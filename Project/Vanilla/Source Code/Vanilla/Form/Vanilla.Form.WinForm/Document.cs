using System;

using ArtfFac = Vanilla.Utility.Facade.Artifact;
using DocFac = Vanilla.Utility.Facade.Document;
using UtilWin = Vanilla.Utility.WinForm;

namespace Vanilla.Form.WinForm
{

    public partial class Document : UtilWin.Document
    {

        private ArtfFac.Dto artifact;

        public Document()
            : base()
        {
            InitializeComponent();
        }

        public Document(ArtfFac.Dto artifact)
            :this()
        {
            this.artifact = artifact;
        }

        private void SetTitle()
        {
            DocFac.FormDto formDto = this.formDto as DocFac.FormDto;
            DocFac.Dto dto = this.formDto.Dto as DocFac.Dto;

            this.Text += " :: " + this.formDto.DocumentName;
        }

        private void Document_Load(object sender, EventArgs e)
        {
            this.formDto.Document = this.artifact;
            this.formDto.Dto = this.artifact.Module as DocFac.Dto;
            this.SetTitle();
        }

        protected void RegisterArtifactObserver()
        {
            (this.facade as Facade.Document.Server).RegisterArtifactObserver();
        }

    }

}
