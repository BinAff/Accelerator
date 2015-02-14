using System;
using System.Collections.Generic;

using BinAff.Utility;
using BinAff.Core;
using PresLib = BinAff.Presentation.Library;

using FrmWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;

using PayFac = Vanilla.Invoice.Facade.Payment;

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
            (base.facade as Facade.Server).AssignLineItemWiseTax(dto.ProductList);
        }

        protected override void PopulateDataToForm()
        {
            Facade.Dto dto = base.Artifact.Module as Facade.Dto;

            this.txtInvoice.Text = dto.InvoiceNumber;
            this.txtDate.Text = dto.Date.ToString();
            this.txtDiscount.Text = dto.Discount.ToString();

            List<Data> invoiceList = new List<Data>();
            Double lineItemTotal = 0;
            if (dto.ProductList != null)
            {
                foreach (Facade.LineItem.Dto lineItem in dto.ProductList)
                {
                    invoiceList.Add(new Data
                    {
                        Start = lineItem.StartDate.ToShortDateString(),
                        End = lineItem.EndDate.ToShortDateString(),
                        Description = lineItem.Description,
                        UnitRate = lineItem.UnitRate.ToString(),
                        Count = lineItem.Count.ToString(),
                        Total = (lineItem.UnitRate * lineItem.Count).ToString(),
                        ServiceTax = lineItem.ServiceTax.ToString(),
                        LuxuaryTax = lineItem.LuxuaryTax.ToString(),
                        GrandTotal = (lineItem.ServiceTax + lineItem.LuxuaryTax + (lineItem.UnitRate * lineItem.Count)).ToString()
                    });
                    lineItemTotal += lineItem.ServiceTax + lineItem.LuxuaryTax + (lineItem.UnitRate * lineItem.Count);
                }
            }

            this.BindLineitemGrid(invoiceList);
            this.BindAdvancePaymentGrid(dto.AdvancePaymentList);
            this.txtTotal.Text = lineItemTotal.ToString();
            this.txtAdvance.Text = dto.Advance.ToString();
            this.txtGrandTotal.Text = (lineItemTotal - dto.Advance - dto.Discount).ToString();
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
                txtDiscount.Enabled = false;
                //txtInvoice.Text = dto.InvoiceNumber;
                //txtDate.Text = dto.Date.ToString();
                //txtDiscount.Text = dto.Discount.ToString();
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

        private void BindLineitemGrid(List<Data> invoiceList)
        {
            if (invoiceList != null && invoiceList.Count > 0)
            {
                dgvProduct.Columns[0].DataPropertyName = "Start";
                dgvProduct.Columns[1].DataPropertyName = "End";
                dgvProduct.Columns[2].DataPropertyName = "Description";
                dgvProduct.Columns[3].DataPropertyName = "UnitRate";
                dgvProduct.Columns[4].DataPropertyName = "Count";
                dgvProduct.Columns[5].DataPropertyName = "Total";
                dgvProduct.Columns[6].DataPropertyName = "ServiceTax";
                dgvProduct.Columns[7].DataPropertyName = "LuxuaryTax";
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