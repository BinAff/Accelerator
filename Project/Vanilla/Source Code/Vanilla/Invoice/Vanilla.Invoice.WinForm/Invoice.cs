using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PresentationLibrary = BinAff.Presentation.Library;
using BinAff.Core;

namespace Vanilla.Invoice.WinForm
{
    public partial class Invoice : PresentationLibrary.Form
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
            List<Data> invoiceList = this.PopulateReportData();
           
            this.rvInvoice.DocumentMapCollapsed = true;
            this.rvInvoice.ShowPrintButton = false;
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("AutoTourism"));
            path += @"Vanilla\Source Code\Vanilla\Invoice\Vanilla.Invoice.WinForm\Invoice.rdlc";

            this.rvInvoice.LocalReport.ReportPath = path;
            string sDataSourceName = "Invoice";

            String lineItemTotal = "122";
            ReportParameter[] p = new ReportParameter[13];
            p[0] = new ReportParameter("InvoiceNumber", this.dto.invoiceNumber);
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

        private List<Data> PopulateReportData()
        {
            List<Data> invoiceList = new List<Data>();

            Double lineItemTotal = 0;
            foreach (Facade.LineItem.Dto lineItem in this.dto.productList)
            {
                invoiceList.Add(new Data
                {
                    colId = "L",
                    Start = lineItem.startDate.ToShortDateString(),
                    End = lineItem.endDate.ToShortDateString(),
                    Description = lineItem.description,
                    UnitRate = lineItem.unitRate.ToString(),
                    Count = lineItem.count.ToString(),
                    Total = (lineItem.unitRate * lineItem.count).ToString()
                });
                lineItemTotal += (lineItem.unitRate * lineItem.count);
            }

            //add tax
            Facade.IInvoice invoiceServer = new Facade.Server(null);
            Double total = lineItemTotal;
            List<Table> taxList = invoiceServer.CalulateTaxList(lineItemTotal, this.dto.taxationList);
            if (taxList != null && taxList.Count > 0)
            {
                foreach (Table tax in taxList)
                {
                    total += tax.Value;

                    invoiceList.Add(new Data
                    {
                        colId = "Tx",
                        name = tax.Name,
                        value = tax.Value.ToString()
                    });
                }
            }

            invoiceList.Add(new Data
            {
                colId = "T",
                name = "Total",
                value = total.ToString()
            });

            Double grandTotal = total;
            if (this.dto.advance > 0)
            {
                grandTotal = grandTotal - this.dto.advance;
                invoiceList.Add(new Data
                {
                    colId = "A",
                    name = "Advance",
                    value = this.dto.advance.ToString()
                });
            }

            if (this.dto.discount > 0)
            {
                grandTotal = grandTotal - this.dto.discount;
                invoiceList.Add(new Data
                {
                    colId = "D",
                    name = "Discount",
                    value = this.dto.discount.ToString()
                });
            }

            invoiceList.Add(new Data
            {
                colId = "Gt",
                name = "Grand Total",
                value = grandTotal.ToString()
            });
            

            return invoiceList;
        }

    }
}
