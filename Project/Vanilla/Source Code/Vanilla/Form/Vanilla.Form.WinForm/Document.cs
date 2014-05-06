using ArtfFac = Vanilla.Utility.Facade.Artifact;
using UtilWin = Vanilla.Utility.WinForm;

namespace Vanilla.Form.WinForm
{

    public partial class Form : UtilWin.Document
    {

        public ArtfFac.Dto ArtifactDto { get; set; }

        public Form()
        {
            InitializeComponent();
        }

    }

}
