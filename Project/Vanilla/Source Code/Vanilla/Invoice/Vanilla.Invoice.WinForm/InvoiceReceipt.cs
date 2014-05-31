
using System;
using System.Collections.Generic;

using FacadeReceipt = Vanilla.Invoice.Facade.Receipt;
using FacadeTax = Vanilla.Invoice.Facade.Taxation;

namespace Vanilla.Invoice.WinForm
{
    public partial class InvoiceReceipt : System.Windows.Forms.Form
    {
        String invoiceNumber = "INVO-30-05-201404324";
        String LuxuaryTax = "Luxuary Tax";
        String ServiceTax = "Service Tax";

        public InvoiceReceipt()
        {
            InitializeComponent();
            this.PopulateDataToForm();
        }

        private void PopulateDataToForm()
        {
            FacadeReceipt.Dto receipt = new FacadeReceipt.Server().GetInvoice(invoiceNumber);

            List<Data> LineItemList = this.PopulateReportData(receipt.ProductList);
            
        }

        private List<Data> PopulateReportData(List<Facade.LineItem.Dto> lineItemList)
        {
            List<Data> LineItemList = new List<Data>();

            foreach (Facade.LineItem.Dto lineItem in lineItemList)
            {
                LineItemList.Add(new Data
                {                  
                    Start = lineItem.startDate.ToShortDateString(),
                    End = lineItem.endDate.ToShortDateString(),
                    Description = lineItem.description,
                    UnitRate = lineItem.unitRate.ToString(),
                    Count = lineItem.count.ToString(),
                    Total = (lineItem.unitRate * lineItem.count).ToString(),
                    //ServiceTax = CalculateTaxAmount(lineItem.TaxList, ServiceTax).ToString(),
                    //LuxuaryTax = CalculateTaxAmount(lineItem.TaxList, LuxuaryTax).ToString(),
                    //GrandTotal = (lineItem.ServiceTax + lineItem.LuxuaryTax + (lineItem.unitRate * lineItem.count)).ToString()
                });
               
            }

            return LineItemList;
        }

        private Double CalculateTaxAmount(List<FacadeTax.Dto> taxList, String taxName, Double total)
        {
            Double taxValue = 0;

            foreach (FacadeTax.Dto dto in taxList)
            {
                if (taxName == dto.Name)
                {
                    if (dto.isPercentage)                       
                        taxValue = total * (dto.Amount / 100);                    
                    else
                        taxValue = dto.Amount;
                   
                    break;
                }
            }

            return taxValue;
        }
       
    }
}
