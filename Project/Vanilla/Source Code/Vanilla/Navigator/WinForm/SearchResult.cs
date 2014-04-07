using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        }

    }

}
