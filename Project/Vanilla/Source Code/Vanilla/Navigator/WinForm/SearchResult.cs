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

        public Facade.SearchResult.FormDto FormDto { get; private set; }

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
            this.FormDto = new Facade.SearchResult.FormDto
            {
                Dto = new Facade.SearchResult.Dto
                {
                    ArtifactName = artifactName,
                },
            };
            new Facade.SearchResult.Server(this.FormDto).LoadForm();
            this.lsvSearchResult.AttachChildren(this.FormDto.ArtifactList,false);
        }

        private void lsvSearchResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.FormDto.CurrentArtifact = ((sender as ListView).SelectedItems[0].Tag as Vanilla.Utility.Facade.Artifact.Dto);
            Facade.SearchResult.Server facade = new Facade.SearchResult.Server(this.FormDto);
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
                this.OnDoubleClick(e);
            }
        }

    }

}
