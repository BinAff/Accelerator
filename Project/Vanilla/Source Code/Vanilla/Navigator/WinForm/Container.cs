using System;
using System.Windows.Forms;
using Vanilla.Navigator.Facade.Container;

namespace Vanilla.Navigator.WinForm
{
    public partial class Container : Form
    {

        private FormDto formDto;
        private Facade.Container.Server facade;

        public Container()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Form::";
            facade = new Server(this.formDto = new FormDto());
            facade.LoadForm();
            this.LoadModules();
        }

        private void tbpForm_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Form::";

            this.facade.GetModules(Facade.Group.Form);
            this.LoadModules();
        }

        private void tbpCatalogue_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Catalogue::";

            this.facade.GetModules(Facade.Group.Catalogue);
            this.LoadModules();
        }

        private void tbpReport_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Report::";

            this.facade.GetModules(Facade.Group.Report);
            this.LoadModules();
        }

        void LoadModules()
        {
            Int16 leftPos = 2;
            this.pnlModule.Controls.Clear();
            foreach (Facade.Module.Dto module in this.formDto.Dto.Modules)
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

    }

}
