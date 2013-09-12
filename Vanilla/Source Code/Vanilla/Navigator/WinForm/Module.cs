using BinAff.Core;
using System.Windows.Forms;

namespace Vanilla.Navigator.WinForm
{

    public partial class Module : UserControl
    {

        public Facade.Module.FormDto formDto { get; set; }

        private Facade.Artifact.Dto artifactList;

        public Module()
        {
            InitializeComponent();
        }

        private void Module_Load(object sender, System.EventArgs e)
        {
            this.LoadArtifacts();
        }

        private void LoadArtifacts()
        {
            //Crystal.Navigator.Component.Artifact.Data artifact = new Crystal.Navigator.Component.Artifact.Data()
            //ICrud server = new Crystal.Navigator.Component.Artifact.Server(artifact);
            //server.Read();
            ////this.artifactList = server.Read().Value;
        }

    }

}
