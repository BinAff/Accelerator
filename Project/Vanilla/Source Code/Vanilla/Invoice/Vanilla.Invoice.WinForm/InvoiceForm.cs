using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;

namespace Vanilla.Invoice.WinForm
{

    public partial class InvoiceForm : FormWin.Document
    {

        public InvoiceForm()
        {
            InitializeComponent();
        }

        public InvoiceForm(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Will be disabled after generation
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Disabled initially, enabled after generation
            //new Invoice().ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Can be added later
            //Disabled initially, enabled after generation
        }

        protected override void Compose()
        {
            base.formDto = new Facade.FormDto
            {
                ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new Facade.Dto()
            };
        }

        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
            return new DocFac.Dto();
        }

        protected override void LoadForm()
        {
            //BinAff.Facade.Library.Server facade = new Facade.Server(formDto);
            //facade.LoadForm();

            //Facade.FormDto formDto = base.formDto as Facade.FormDto;
            //base.facade.LoadForm();
        }

        protected override void PopulateDataToForm()
        {

        }

        protected override Boolean ValidateForm()
        {
            return true;
        }

        protected override void AssignDto()
        {
        }

    }

}
