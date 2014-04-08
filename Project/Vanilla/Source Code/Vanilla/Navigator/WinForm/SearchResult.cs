using System;
using System.Collections.Generic;
using System.Windows.Forms;

using PresLib = BinAff.Presentation.Library;

using UtilFac = Vanilla.Utility.Facade;
using Vanilla.Utility.WinForm.Extender;

namespace Vanilla.Navigator.WinForm
{

    public partial class SearchResult : UserControl
    {

        private Facade.SearchResult.FormDto formDto;

        public SearchResult()
        {
            InitializeComponent();
        }

        private void SearchResult_Load(object sender, System.EventArgs e)
        {
            this.lsvSearchResult.Initialize();
        }

        public void LoadResult(String artifactName)
        {
            this.formDto = new Facade.SearchResult.FormDto
            {
                Dto = new Facade.SearchResult.Dto
                {
                    ArtifactName = artifactName,
                },
            };
            new Facade.SearchResult.Server(this.formDto).LoadForm();
            this.lsvSearchResult.AttachChildren(this.formDto.ArtifactList);
        }

        private void lsvSearchResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.formDto.CurrentArtifact = ((sender as ListView).SelectedItems[0].Tag as Vanilla.Utility.Facade.Artifact.Dto);
            Facade.SearchResult.Server facade = new Facade.SearchResult.Server(this.formDto);
            facade.Read();
            if (facade.IsError)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Navigator"
                }.Show("Error to open document / folder.");
            }
            else
            {
                if (this.formDto.CurrentArtifact.Style == UtilFac.Artifact.Type.Document)
                {
                    PresLib.Form form = (PresLib.Form)Activator.CreateInstance(Type.GetType(this.formDto.CurrentArtifact.ComponentDefinition.ComponentFormType, true), this.formDto.CurrentArtifact.Module);
                    form.ShowDialog(this);
                }
                else
                {
                    //Navigate to register in proper place
                }
            }
        }

    }

}
