using System.Collections.Generic;
using System.Windows.Forms;

using UtilFac = Vanilla.Utility.Facade;
using Vanilla.Utility.WinForm.Extender;

namespace Vanilla.Navigator.WinForm
{

    public partial class SearchResult : UserControl
    {

        internal List<UtilFac.Artifact.Dto> artifactList { get; set; }

        public SearchResult()
        {
            InitializeComponent();
        }

        private void SearchResult_Load(object sender, System.EventArgs e)
        {
            this.lsvSearchResult.Initialize();
        }

        public void Bind()
        {
            this.lsvSearchResult.AttachChildren(this.artifactList);
        }

    }

}
