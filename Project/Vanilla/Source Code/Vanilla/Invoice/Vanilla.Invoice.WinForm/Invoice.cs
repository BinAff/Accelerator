using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Vanilla.Invoice.WinForm
{
    public partial class Invoice : Form
    {
        private Facade.Dto dto;
        private Facade.FormDto formDto;
        
        public Invoice()
        {
            InitializeComponent();
            //this.invoiceData = data;
            //LoadReport();
            //LoadFormData();

            //if (this.invoiceData.Payment == null || ValidationRule.IsMinimumDate(this.invoiceData.Payment.Date))
            //    btnPrint.Visible = false;
            //else
            //{
            //    btnPayAndPrint.Visible = false;
            //    this.cboPaymentType.Enabled = false;
            //    this.txtLastFourDigit.Enabled = false;
            //    this.txtRemark.Enabled = false;
            //}

        }

        public Invoice(Facade.Dto dto)
        {
            InitializeComponent();

            this.dto = dto;
            this.formDto = new Facade.FormDto { dto = this.dto };
          
            this.LoadForm();            
            this.LoadReport();
        }

        private void LoadReport()
        {
            List<Data> invoiceList = new List<Data>();

            Double lineItemTotal = 0;
            foreach (Facade.LineItem.Dto lineItem in this.dto.productList)
            {
                invoiceList.Add(new Data
                {
                    Start = lineItem.startDate.ToShortDateString(),
                    End = lineItem.endDate.ToShortDateString(),
                    Description = String.Empty,
                    UnitRate = lineItem.unitRate.ToString(),
                    Count = lineItem.count.ToString(),
                    Total = lineItem.total.ToString()
                });
                lineItemTotal += lineItem.total;
            }
           
            this.rvInvoice.DocumentMapCollapsed = true;
            this.rvInvoice.ShowPrintButton = false;
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("AutoTourism"));
            path += @"Vanilla\Source Code\Vanilla\Invoice\Vanilla.Invoice.WinForm\Invoice.rdlc";

            this.rvInvoice.LocalReport.ReportPath = path;
            string sDataSourceName = "Invoice";

            ReportParameter[] p = new ReportParameter[13];
            p[0] = new ReportParameter("InvoiceNumber", "Inv1001");
            p[1] = new ReportParameter("SellerName", this.dto.seller.Name);
            p[2] = new ReportParameter("SellerAddress", this.dto.seller.Address);
            p[3] = new ReportParameter("SellerContactNo", this.dto.seller.ContactNumber);
            p[4] = new ReportParameter("SellerEmail", this.dto.seller.Email);
            p[5] = new ReportParameter("SellerLicenceNo", this.dto.seller.Liscence);
            p[6] = new ReportParameter("BuyerName", this.dto.buyer.Name);
            p[7] = new ReportParameter("BuyerContactNo", this.dto.buyer.ContactNumber);
            p[8] = new ReportParameter("BuyerAddress", this.dto.buyer.Address);
            p[9] = new ReportParameter("Total", lineItemTotal.ToString()); //Change
            p[10] = new ReportParameter("Discount", "0"); //Change
            p[11] = new ReportParameter("Tax", "4"); //Change
            p[12] = new ReportParameter("Advance",this.dto.advance.ToString()); 

            this.rvInvoice.LocalReport.SetParameters(p);

            Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
            rptDataSoruce.Name = sDataSourceName;
            rptDataSoruce.Value = invoiceList;

            this.rvInvoice.Visible = true;
            this.rvInvoice.LocalReport.DataSources.Add(rptDataSoruce);
            this.rvInvoice.RefreshReport();
                        
        }
                  
        private void LoadForm()
        {
            //BinAff.Facade.Library.Server facade = new Facade.Server(formDto);
            //facade.LoadForm();
        }

    }
}
