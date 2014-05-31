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
using BinAff.Utility;
using PresentationLibrary = BinAff.Presentation.Library;
using BinAff.Core;

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

            Facade.Dto dto = base.Artifact.Module as Facade.Dto;

            if (Convert.ToDouble(txtGrandTotal.Text) < 1)
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show(new List<String> { "Invalid amount. Please check the payment amount?" });

                return;
            }

            if (ValidationRule.IsDouble(txtDiscount.Text))
                dto.discount = Convert.ToDouble(txtDiscount.Text);

            this.RegisterArtifactObserver();
            ReturnObject<Boolean> ret = (base.facade as Facade.Server).GenerateInvoice();

            if (!ret.Value)
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show(ret.MessageList);
            }

            this.Tag = ret.Value;
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Disabled initially, enabled after generation
            //new Invoice().ShowDialog();            
          
            System.Windows.Forms.Form form = new Vanilla.Invoice.WinForm.Invoice();           
            form.ShowDialog();           
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
        
            this.facade = new Facade.Server(base.formDto as Facade.FormDto);
        }

        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
            return new DocFac.Dto();
        }

        protected override void LoadForm()
        {            
            Facade.Dto dto = base.Artifact.Module as Facade.Dto;

            //enabling disabling buttons
            if (dto.Id == 0)
            {
                btnPrint.Enabled = false;
                btnCancel.Enabled = false;
            }
            else
            {
                btnGenerate.Enabled = false;
                txtDiscount.Enabled = false;
                txtInvoice.Text = dto.invoiceNumber;
                txtDate.Text = dto.date.ToString();
                txtDiscount.Text = dto.discount.ToString();               
            }

            List<Data> invoiceList = new List<Data>();

            Double lineItemTotal = 0;
            foreach (Facade.LineItem.Dto lineItem in dto.productList)
            {
                invoiceList.Add(new Data
                {                  
                    Start = lineItem.startDate.ToShortDateString(),
                    End = lineItem.endDate.ToShortDateString(),
                    Description = lineItem.description,
                    UnitRate = lineItem.unitRate.ToString(),
                    Count = lineItem.count.ToString(),
                    Total = (lineItem.unitRate * lineItem.count).ToString(),
                    ServiceTax = lineItem.ServiceTax.ToString(),
                    LuxuaryTax = lineItem.LuxuaryTax.ToString(),
                    GrandTotal = (lineItem.ServiceTax + lineItem.LuxuaryTax + (lineItem.unitRate * lineItem.count)).ToString()
                });
                lineItemTotal += lineItem.ServiceTax + lineItem.LuxuaryTax + (lineItem.unitRate * lineItem.count);
            }

            this.BindToGrid(invoiceList);
         
            txtTotal.Text = lineItemTotal.ToString();
            txtAdvance.Text = dto.advance.ToString();
            txtGrandTotal.Text = (lineItemTotal - dto.advance - dto.discount).ToString();

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

        private void BindToGrid(List<Data> invoiceList)
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

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Facade.Dto dto = base.Artifact.Module as Facade.Dto;
            Double discount = 0;

            if (ValidationRule.IsDouble(txtDiscount.Text))
                discount = Convert.ToDouble(txtDiscount.Text);

            if (ValidationRule.IsDouble(txtDiscount.Text))
            {
                Double total = String.IsNullOrEmpty(txtTotal.Text) ? 0 : Convert.ToDouble(txtTotal.Text);
                txtGrandTotal.Text = (total - dto.advance - discount).ToString();
            }
        }
    }

}
