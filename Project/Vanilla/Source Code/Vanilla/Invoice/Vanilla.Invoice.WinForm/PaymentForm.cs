using System;

using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;

namespace Vanilla.Invoice.WinForm
{

    public partial class PaymentForm : FormWin.Document
    {

        public PaymentForm()
        {
            InitializeComponent();
        }

        public PaymentForm(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected override void Compose()
        {
            //base.formDto = new Facade.FormDto
            //{
            //    ModuleFormDto = new UtilFac.Module.FormDto(),
            //    Dto = new Facade.Dto()
            //};
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
