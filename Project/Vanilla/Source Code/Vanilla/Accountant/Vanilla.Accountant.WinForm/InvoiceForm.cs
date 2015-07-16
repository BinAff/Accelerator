using System;
using System.Collections.Generic;

using BinAff.Utility;
using BinAff.Core;
using PresLib = BinAff.Presentation.Library;

using UtilFac = Vanilla.Utility.Facade;

using FrmWin = Vanilla.Form.WinForm;
using UtilWin = Vanilla.Utility.WinForm;

using PayFac = Vanilla.Accountant.Facade.Payment;
using InvFac = Vanilla.Accountant.Facade.Invoice;

namespace Vanilla.Accountant.WinForm
{

    public partial class InvoiceForm : FrmWin.Document
    {
        System.Windows.Forms.ToolStripButton btnCancel;
        System.Windows.Forms.ToolStripButton btnPay;
        System.Windows.Forms.ToolStripButton btnPrint;

        public InvoiceForm(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
            this.btnCancel = base.AddToolStripButton("Í", "Wingdings 2", "Cancel");
            this.btnCancel.Click += btnCancel_Click;
            this.btnPay = base.AddToolStripButton("<", "Wingdings 2", "Pay");
            this.btnPay.Click += btnPay_Click;
            this.btnPrint = base.AddToolStripButton("6", "Wingdings 2", "Print");
            this.btnPrint.Click += btnPrint_Click;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            this.tpnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Can be added later
            //Disabled initially, enabled after generation
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //Can be added later
            //Disabled initially, enabled after generation
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Disabled initially, enabled after generation
            //new Invoice().ShowDialog();            
          
            System.Windows.Forms.Form form = new Vanilla.Accountant.WinForm.InvoiceReceipt();           
            form.ShowDialog();           
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            InvFac.Dto dto = base.Artifact.Module as InvFac.Dto;
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
            base.formDto = new InvFac.FormDto
            {
                ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new InvFac.Dto()
            };

            this.facade = new InvFac.Server(base.formDto as InvFac.FormDto);

            this.SummaryList = new List<UtilWin.SidePanel.Option>
            {
                new UtilWin.SidePanel.Option
                {
                    Name = "Check In",
                    //Content = new Customer.WinForm.CustomerSummary(),
                },
                //new UtilWin.SidePanel.Option
                //{
                //    Name = "Payment",
                //    //Content = new InvoiceSummary(),
                //},
            };
        }

        protected override void LoadForm()
        {
            new InvFac.Server(new InvFac.FormDto
            {
                Dto = base.Artifact.Module as InvFac.Dto,
            }).LoadForm();
        }

        protected override void PopulateDataToForm()
        {
            InvFac.Dto dto = base.Artifact.Module as InvFac.Dto;

            this.txtInvoice.Text = dto.InvoiceNumber;
            this.txtDate.Text = dto.Date.ToString();
            this.txtDiscount.Text = dto.Discount.ToString();

            List<Data> invoiceList = new List<Data>();

            this.BindLineitemGrid(dto.ProductList);
            this.BindAdvancePaymentGrid(dto.AdvancePaymentList); //Currently there is not direct link from advance payment and invoice!
            this.txtTotal.Text = Converter.ConvertToIndianCurrency(dto.Total);
            this.txtAdvance.Text = Converter.ConvertToIndianCurrency(dto.Advance);
            this.txtGrandTotal.Text = Converter.ConvertToIndianCurrency(dto.Total - dto.Advance - dto.Discount);
        }

        protected override void DisableFormControls()
        {
            base.IsEnabledRefreshButton = true;

            InvFac.Dto dto = base.Artifact.Module as InvFac.Dto;
            if (dto.Id == 0)
            {
                base.IsEnabledSaveButton = true;
                base.IsEnabledDeleteButton = true;

                this.btnCancel.Enabled = false;
                this.btnPay.Enabled = false;
                this.btnPrint.Enabled = false;
            }
            else
            {
                base.IsEnabledSaveButton = false;
                base.IsEnabledDeleteButton = false;

                base.IsEnabledAddLinkButton = false;
                base.IsEnabledOpenLinkButton = false;

                this.txtDiscount.ReadOnly = true;

                this.btnCancel.Enabled = true;
                this.btnPay.Enabled = true;
                this.btnPrint.Enabled = true;
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
            (base.Artifact.Module as Facade.Invoice.Dto).Discount = Convert.ToDouble(this.txtDiscount.Text.Trim());
        }

        private void BindLineitemGrid(List<Facade.Invoice.LineItem.Dto> invoiceList)
        {
            if (invoiceList != null && invoiceList.Count > 0)
            {
                this.dgvProduct.Columns[0].DataPropertyName = "StartDate";
                this.dgvProduct.Columns[1].DataPropertyName = "EndDate";
                this.dgvProduct.Columns[2].DataPropertyName = "Description";
                this.dgvProduct.Columns[3].DataPropertyName = "UnitRate";
                this.dgvProduct.Columns[4].DataPropertyName = "Count";
                this.dgvProduct.Columns[5].DataPropertyName = "Total";
                this.dgvProduct.Columns[6].DataPropertyName = "ServiceTax";
                this.dgvProduct.Columns[7].DataPropertyName = "LuxuryTax";
                this.dgvProduct.Columns[8].DataPropertyName = "GrandTotal";
                
                this.dgvProduct.AutoGenerateColumns = false;
                this.dgvProduct.DataSource = invoiceList;               
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

        private void txtDiscount_Enter(object sender, EventArgs e)
        {

        }

    }

}