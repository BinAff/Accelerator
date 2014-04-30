
using PresentationLibrary = BinAff.Presentation.Library;
using FacadeArtifact = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Utility.WinForm
{
    public partial class Form : PresentationLibrary.Form
    {
        public FacadeArtifact.Dto ArtifactDto { get; protected set; }

        public Form()
        {
            InitializeComponent();
        }
    }
}
