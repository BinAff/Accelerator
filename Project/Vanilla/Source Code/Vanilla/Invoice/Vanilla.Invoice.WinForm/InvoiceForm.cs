using System;
using System.Collections.Generic;

using BinAff.Utility;
using BinAff.Core;
using PresLib = BinAff.Presentation.Library;

using FrmWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;

using PayFac = Vanilla.Invoice.Facade.Payment;
using InvFac = Vanilla.Invoice.Facade;

namespace Vanilla.Invoice.WinForm
{

    public partial class InvoiceForm : FrmWin.Document
    {

        public InvoiceForm(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Disabled initially, enabled after generation
            //new Invoice().ShowDialog();            
          
            System.Windows.Forms.Form form = new Vanilla.Invoice.WinForm.InvoiceReceipt();           
            form.ShowDialog();           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Can be added later
            //Disabled initially, enabled after generation
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Facade.Dto dto = base.Artifact.Module as Facade.Dto;
            Double discount = 0;

            if (ValidationRule.IsDouble(txtDiscount.Text))
                discount = Convert.ToDouble(txtDiscount.Text);

            if (ValidationRule.IsDouble(txtDiscount.Text))
            {
                Double total = String.IsNullOrEmpty(txtTotal.Text) ? 0 : Convert.ToDouble(txtTotal.Text);
                txtGrandTotal.Text = (total - dto.Advance - discount).ToString();
            }
        }

        protected override void Compose()
        {
            base.formDto = new Facade.FormDto
            {
                ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new Facade.Dto()
            };

            this.facade = new Facade.Server(base.formDto as Facade.FormDto);
        }

        protected override void LoadForm()
        {
            Facade.Dto dto = base.Artifact.Module as Facade.Dto;
            if(String.IsNullOrEmpty(dto.InvoiceNumber)) dto.InvoiceNumber = Common.GenerateInvoiceNumber();
            new Facade.Server(new InvFac.FormDto
            {
                Dto = dto,
            }).LoadForm();
        }

        protected override void PopulateDataToForm()
        {
            Facade.Dto dto = base.Artifact.Module as Facade.Dto;

            this.txtInvoice.Text = dto.InvoiceNumber;
            this.txtDate.Text = dto.Date.ToString();
            this.txtDiscount.Text = dto.Discount.ToString();

            List<Data> invoiceList = new List<Data>();

            this.BindLineitemGrid(dto.ProductList);
            this.BindAdvancePaymentGrid(dto.AdvancePaymentList); //Currently there is not direct link from advance payment and invoice!
            this.txtTotal.Text = dto.Total.ToString();
            this.txtAdvance.Text = dto.Advance.ToString();
            this.txtGrandTotal.Text = (dto.Total - dto.Advance - dto.Discount).ToString();
        }

        protected override void DisableFormControls()
        {
            Facade.Dto dto = base.Artifact.Module as Facade.Dto;
            if (dto.Id == 0)
            {
                this.btnPrint.Enabled = false;
                this.btnCancel.Enabled = false;
            }
            else
            {
                base.DisableOkButton();
                base.DisableAddAncestorButton();
                base.DisablePickAncestorButton();
                this.txtDiscount.Enabled = false;
            }
        }

        protected override Boolean ValidateForm()
        {
            errorProvider.Clear();
            if (!String.IsNullOrEmpty(this.txtDiscount.Text) && Convert.ToDouble(this.txtDiscount.Text.Trim()) < 0)
            {
                errorProvider.SetError(this.txtDiscount, "Please enter valid discount.");
                this.txtDiscount.Focus();
                return false;
            }
            return true;
        }

        protected override void AssignDto()
        {
            //This is special case where dto will always have value, even it is new invoice
            (base.Artifact.Module as Facade.Dto).Discount = Convert.ToDouble(this.txtDiscount.Text.Trim());
        }

        private void BindLineitemGrid(List<Facade.LineItem.Dto> invoiceList)
        {
            if (invoiceList != null && invoiceList.Count > 0)
            {
                dgvProduct.Columns[0].DataPropertyName = "StartDate";
                dgvProduct.Columns[1].DataPropertyName = "EndDate";
                dgvProduct.Columns[2].DataPropertyName = "Description";
                dgvProduct.Columns[3].DataPropertyName = "UnitRate";
                dgvProduct.Columns[4].DataPropertyName = "Count";
                dgvProduct.Columns[5].DataPropertyName = "Total";
                dgvProduct.Columns[6].DataPropertyName = "ServiceTax";
                dgvProduct.Columns[7].DataPropertyName = "LuxuryTax";
                dgvProduct.Columns[8].DataPropertyName = "GrandTotal";

                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = invoiceList;               
            }
        }

        private void BindAdvancePaymentGrid(List<PayFac.Dto> list)
        {
            if (list != null && list.Count > 0)
            {
                dgvAdvance.Columns[0].DataPropertyName = "Date";
                dgvAdvance.Columns[1].DataPropertyName = "ReceiptNumber";
                dgvAdvance.Columns[2].DataPropertyName = "TotalAmount";

                dgvAdvance.AutoGenerateColumns = false;
                dgvAdvance.DataSource = list;
            }
        }

    }

}