using System;
using System.Windows.Forms;
using Vanilla.Navigator.Facade.Container;

namespace Vanilla.Navigator.WinForm
{
    public partial class Container : Form
    {

        FormDto formDto;

        public Container()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Form::";
            this.formDto = new FormDto();
            Facade.Container.Server container = new Server(this.formDto);
            container.LoadForm();
            this.LoadCurrentModules();
        }

        private void tbpForm_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Form::";

            this.formDto.CurrentModules = this.formDto.FormModules;
            this.LoadCurrentModules();
        }

        void LoadCurrentModules()
        {
            Int16 leftPos = 2;
            this.pnlModule.Controls.Clear();
            foreach (Facade.Module.Dto module in this.formDto.CurrentModules)
            {
                this.pnlModule.Controls.Add(new Module
                {
                    formDto = new Facade.Module.FormDto
                    {
                        Dto = module,
                    },
                    Left = leftPos,
                });
                leftPos += 28;
            }
        }

        private void tbpCatalogue_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Catalogue::";

            this.formDto.CurrentModules = this.formDto.CatalogueModules;
            this.LoadCurrentModules();
        }

        private void tbpReport_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Report::";

            this.formDto.CurrentModules = this.formDto.ReportModules;
            this.LoadCurrentModules();
        }

    }

}
