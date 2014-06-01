using System;

using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;
using PayFac = Vanilla.Invoice.Facade.Payment; 

namespace Vanilla.Invoice.WinForm
{

    //public partial class PaymentForm : FormWin.Document
    public partial class PaymentForm : System.Windows.Forms.Form
    {
        PayFac.FormDto formDto = new PayFac.FormDto();
        public PaymentForm()
        {
            InitializeComponent();
            this.LoadForm();
        }

        //public PaymentForm(UtilFac.Artifact.Dto artifact)
        //    : base(artifact)
        //{
        //    InitializeComponent();
        //}

        private void btnPay_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        //protected override void Compose()
        //{
        //    //base.formDto = new Facade.FormDto
        //    //{
        //    //    ModuleFormDto = new UtilFac.Module.FormDto(),
        //    //    Dto = new Facade.Dto()
        //    //};
        //}

        //protected override DocFac.Dto CloneDto(DocFac.Dto source)
        //{
        //    return new DocFac.Dto();
        //}

        //protected override void LoadForm()
        //{
        //    //BinAff.Facade.Library.Server facade = new Facade.Server(formDto);
        //    //facade.LoadForm();

        //    //Facade.FormDto formDto = base.formDto as Facade.FormDto;
        //    //base.facade.LoadForm();
        //}

        //protected override void PopulateDataToForm()
        //{

        //}

        //protected override Boolean ValidateForm()
        //{
        //    return true;
        //}

        //protected override void AssignDto()
        //{
        //}

        protected void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new PayFac.Server(formDto);
            facade.LoadForm();

            //--populate payment type category
            this.cboPaymentType.DataSource = null;
            if (formDto.typeList != null && formDto.typeList.Count > 0)
            {
                this.cboPaymentType.DataSource = formDto.typeList;
                this.cboPaymentType.ValueMember = "Id";
                this.cboPaymentType.DisplayMember = "Name";
                this.cboPaymentType.SelectedIndex = 0;
            }
        }

    }

}
