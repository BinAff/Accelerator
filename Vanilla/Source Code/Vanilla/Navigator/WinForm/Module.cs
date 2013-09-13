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
            this.lblName.Text = this.formDto.Dto.Name;
        }

        private void Module_Click(object sender, System.EventArgs e)
        {
            this.LoadArtifacts();
        }

        private void LoadArtifacts()
        {
            Crystal.Navigator.Component.Artifact.Data artifact = new Crystal.Navigator.Component.Artifact.Data();
            (new Crystal.Navigator.Component.Artifact.Server(artifact) as ICrud).Read();
            //this.artifactList = server.Read().Value;
        }

    }

}
