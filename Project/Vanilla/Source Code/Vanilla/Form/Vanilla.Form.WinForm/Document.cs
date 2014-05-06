using System;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
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
            Facade.Document.FormDto formDto = this.formDto as Facade.Document.FormDto;
            Facade.Document.Dto dto = this.formDto.Dto as Facade.Document.Dto;

            this.Text = String.Format("{0} :: {1} Form", this.formDto.DocumentName,
                formDto.Document.ComponentDefinition.Name);
        }

        private void Document_Load(object sender, EventArgs e)
        {
            this.formDto.Document = this.artifact;
            this.SetTitle();
        }

    }

}
