using BinAff.Core;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vanilla.Navigator.WinForm
{

    public partial class Module : UserControl
    {

        public Facade.Module.FormDto formDto { get; set; }

        private Facade.Artifact.Dto dto;

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
            Facade.Module.Server facade = new Facade.Module.Server(this.formDto);
            facade.LoadForm();
            if (facade.DisplayMessageList != null && facade.DisplayMessageList.Count > 0)
            {
                //MessageBox.Show(
            }
        }

        

    }

}
