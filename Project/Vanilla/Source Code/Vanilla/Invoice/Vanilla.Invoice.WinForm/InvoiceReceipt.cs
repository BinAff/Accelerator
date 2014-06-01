﻿
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;

using FacadeReceipt = Vanilla.Invoice.Facade.Receipt;
using FacadeTax = Vanilla.Invoice.Facade.Taxation;

namespace Vanilla.Invoice.WinForm
{
    public partial class InvoiceReceipt : System.Windows.Forms.Form
    {
        String invoiceNumber = "INVO-30-05-201404324";
        String gLuxuaryTax = "Luxuary Tax";
        String gServiceTax = "Service Tax";

        public InvoiceReceipt()
        {
            InitializeComponent();
            this.PopulateDataToForm();
        }

        private void PopulateDataToForm()
        {
            FacadeReceipt.Dto receipt = new FacadeReceipt.Server().GetInvoice(invoiceNumber);

            List<Data> LineItemList = this.FormLineItemData(receipt.ProductList);

            this.rvInvoiceReceipt.DocumentMapCollapsed = true;
            this.rvInvoiceReceipt.ShowPrintButton = false;
            String path = System.IO.Directory.GetCurrentDirectory();
            path = Application.StartupPath + "\\Report\\InvoiceReceipt.rdlc";

            this.rvInvoiceReceipt.LocalReport.ReportPath = path;
            //string sDataSourceName = "InvoiceReceipt";

            String lineItemTotal = String.Empty;
            ReportParameter[] p = new ReportParameter[1];
            p[0] = new ReportParameter("InvoiceNumber", receipt.InvoiceNumber);
            //p[1] = new ReportParameter("SellerName", receipt.Seller.Name);
            //p[2] = new ReportParameter("SellerAddress", receipt.Seller.Address);
            //p[3] = new ReportParameter("SellerContactNo", receipt.Seller.ContactNumber);
            //p[4] = new ReportParameter("SellerEmail", receipt.Seller.Email);
            //p[5] = new ReportParameter("SellerLicenceNo", receipt.Seller.Liscence);
            //p[6] = new ReportParameter("BuyerName", receipt.Buyer.Name);
            //p[7] = new ReportParameter("BuyerContactNo", receipt.Buyer.ContactNumber);
            //p[8] = new ReportParameter("BuyerAddress", receipt.Buyer.Address);
            //p[9] = new ReportParameter("Total", lineItemTotal.ToString()); //Change
            //p[10] = new ReportParameter("Discount", receipt.Discount.ToString()); //Change
            //p[11] = new ReportParameter("Tax", "4"); //Change
            //p[12] = new ReportParameter("Advance", receipt.Advance.ToString());

            this.rvInvoiceReceipt.LocalReport.SetParameters(p);

            Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
            rptDataSoruce.Name = "InvoiceReceipt";
            rptDataSoruce.Value = LineItemList;

            this.rvInvoiceReceipt.Visible = true;
            this.rvInvoiceReceipt.LocalReport.DataSources.Add(rptDataSoruce);
            this.rvInvoiceReceipt.RefreshReport();
            
        }

        private List<Data> FormLineItemData(List<Facade.LineItem.Dto> lineItemList)
        {
            List<Data> LineItemList = new List<Data>();
            FacadeReceipt.Server receiptServer = new FacadeReceipt.Server();

            foreach (Facade.LineItem.Dto lineItem in lineItemList)
            {
                Data data = new Data
                {
                    Start = lineItem.startDate.ToShortDateString(),
                    End = lineItem.endDate.ToShortDateString(),
                    Description = lineItem.description,
                    UnitRate = lineItem.unitRate.ToString(),
                    Count = lineItem.count.ToString(),
                    Total = (lineItem.unitRate * lineItem.count).ToString(),
                };
                data.ServiceTax = receiptServer.CalculateTaxAmount(lineItem.TaxList, gServiceTax, Convert.ToDouble(data.Total)).ToString();
                data.LuxuaryTax = receiptServer.CalculateTaxAmount(lineItem.TaxList, gLuxuaryTax, Convert.ToDouble(data.Total)).ToString();
                data.GrandTotal = (Convert.ToDouble(data.ServiceTax) + Convert.ToDouble(data.LuxuaryTax) + Convert.ToDouble(data.Total)).ToString();
                LineItemList.Add(data);
            }

            return LineItemList;
        }

        private void InvoiceReceipt_Load(object sender, EventArgs e)
        {

            this.rvInvoiceReceipt.RefreshReport();
        }
       
    }
}
