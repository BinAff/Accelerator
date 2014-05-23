using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PresentationLibrary = BinAff.Presentation.Library;
using BinAff.Core;

using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;

namespace Vanilla.Invoice.WinForm
{
    public partial class Invoice : FormWin.Document
    {
        //private Facade.Dto dto;
        //private Facade.FormDto formDto;

        public Invoice(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();            
        }

        //public Invoice()
        //{
        //    InitializeComponent();
        //    //this.invoiceData = data;
        //    //LoadReport();
        //    //LoadFormData();

        //    //if (this.invoiceData.Payment == null || ValidationRule.IsMinimumDate(this.invoiceData.Payment.Date))
        //    //    btnPrint.Visible = false;
        //    //else
        //    //{
        //    //    btnPayAndPrint.Visible = false;
        //    //    this.cboPaymentType.Enabled = false;
        //    //    this.txtLastFourDigit.Enabled = false;
        //    //    this.txtRemark.Enabled = false;
        //    //}

        //}

        //public Invoice(Facade.Dto dto)
        //{
        //    InitializeComponent();

        //    //this.dto = dto;
        //    //this.formDto = new Facade.FormDto { dto = this.dto };
          
        //    //this.LoadForm();            
        //    //this.LoadReport();
        //}

        protected override void Compose()
        {
            base.formDto = new Facade.FormDto
            {
                ModuleFormDto = new UtilFac.Module.FormDto(),
                Dto = new Facade.Dto()
            };

            //this.facade = new Facade.Server(this.formDto as Facade.FormDto);
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
            
            this.LoadReport();
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

        private void LoadReport()
        {
            Facade.Dto dto = base.Artifact.Module as Facade.Dto;
            //Facade.Dto dto = base.formDto.Dto as Facade.Dto;

            List<Data> invoiceList = this.PopulateReportData(dto);

            this.rvInvoice.DocumentMapCollapsed = true;
            this.rvInvoice.ShowPrintButton = false;
            String path = System.IO.Directory.GetCurrentDirectory();
            path = Application.StartupPath + "\\Report\\Invoice.rdlc";

            this.rvInvoice.LocalReport.ReportPath = path;
            string sDataSourceName = "Invoice";

            String lineItemTotal = "122";
            ReportParameter[] p = new ReportParameter[13];
            p[0] = new ReportParameter("InvoiceNumber", dto.invoiceNumber);
            p[1] = new ReportParameter("SellerName", dto.seller.Name);
            p[2] = new ReportParameter("SellerAddress", dto.seller.Address);
            p[3] = new ReportParameter("SellerContactNo", dto.seller.ContactNumber);
            p[4] = new ReportParameter("SellerEmail", dto.seller.Email);
            p[5] = new ReportParameter("SellerLicenceNo", dto.seller.Liscence);
            p[6] = new ReportParameter("BuyerName", dto.buyer.Name);
            p[7] = new ReportParameter("BuyerContactNo", dto.buyer.ContactNumber);
            p[8] = new ReportParameter("BuyerAddress", dto.buyer.Address);
            p[9] = new ReportParameter("Total", lineItemTotal.ToString()); //Change
            p[10] = new ReportParameter("Discount", dto.discount.ToString()); //Change
            p[11] = new ReportParameter("Tax", "4"); //Change
            p[12] = new ReportParameter("Advance", dto.advance.ToString());

            this.rvInvoice.LocalReport.SetParameters(p);

            Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
            rptDataSoruce.Name = sDataSourceName;
            rptDataSoruce.Value = invoiceList;

            this.rvInvoice.Visible = true;
            this.rvInvoice.LocalReport.DataSources.Add(rptDataSoruce);
            this.rvInvoice.RefreshReport();
                        
        }

        private List<Data> PopulateReportData(Facade.Dto dto)
        {
            //Facade.Dto dto = base.formDto.Dto as Facade.Dto;
            List<Data> invoiceList = new List<Data>();

            Double lineItemTotal = 0;
            foreach (Facade.LineItem.Dto lineItem in dto.productList)
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
            List<Table> taxList = invoiceServer.CalulateTaxList(lineItemTotal, dto.taxationList);
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
            if (dto.advance > 0)
            {
                grandTotal = grandTotal - dto.advance;
                invoiceList.Add(new Data
                {
                    colId = "A",
                    name = "Advance",
                    value = dto.advance.ToString()
                });
            }

            if (dto.discount > 0)
            {
                grandTotal = grandTotal - dto.discount;
                invoiceList.Add(new Data
                {
                    colId = "D",
                    name = "Discount",
                    value = dto.discount.ToString()
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
