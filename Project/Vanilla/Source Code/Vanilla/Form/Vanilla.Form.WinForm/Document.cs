using PresLib = BinAff.Presentation.Library;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Form.WinForm
{

    public partial class Form : PresLib.Form
    {

        public ArtfFac.Dto ArtifactDto { get; set; }

        public Form()
        {
            InitializeComponent();
        }

    }

}
