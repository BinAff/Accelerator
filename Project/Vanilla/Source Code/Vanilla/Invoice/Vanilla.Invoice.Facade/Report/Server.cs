using System.Collections.Generic;
using BinAff.Core;
using CrystalInvoiceReport = Crystal.Invoice.Component.Report;
using CrystalReport = Crystal.Report.Component;


namespace Vanilla.Invoice.Facade.Report
{
    public class Server : BinAff.Facade.Library.Server, IReport
    {
        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            //throw new NotImplementedException();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {            
            Crystal.Invoice.Component.Report.Data invoiceReportData = data as Crystal.Invoice.Component.Report.Data;
            return new Dto
            {
                Id = invoiceReportData.Id,
                date = invoiceReportData.Date,
                //fromDate = invoiceReportData.FromDate,
                //toDate = invoiceReportData.ToDate,
                category = invoiceReportData.category == null ? null : new Vanilla.Report.Facade.Category.Dto{ Id = invoiceReportData.category.Id }
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrystalInvoiceReport.Data
            {
                Date = reportDto.date,
                //FromDate = reportDto.fromDate,
                //ToDate = reportDto.toDate,
                category = new Crystal.Report.Component.Category.Data { Id = reportDto.category.Id }
            };
        }

        public override void Add()
        {            
            FormDto formDto = this.FormDto as FormDto;

            CrystalInvoiceReport.Data invoiceReportData = this.Convert(formDto.dto) as CrystalInvoiceReport.Data;           
            ICrud crud = new CrystalInvoiceReport.Server(invoiceReportData);
            ReturnObject<bool> retVal = crud.Save();

            if (retVal.Value && invoiceReportData.Id > 0)
                formDto.dto.Id = invoiceReportData.Id;

            this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);           
        }

        List<Facade.Dto> IReport.GetDailyReport(System.DateTime date)
        {            
            CrystalReport.IReport report = new CrystalInvoiceReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetDailyReport(date);
            return this.GetSalesData(reportDataList);
        }

        List<Facade.Dto> IReport.GetWeeklyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalInvoiceReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetWeeklyReport(date);
            return this.GetSalesData(reportDataList);
        }
                
        List<Facade.Dto> IReport.GetMonthlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalInvoiceReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetMonthlyReport(date);
            return this.GetSalesData(reportDataList);
        }
                
        private List<Facade.Dto> GetSalesData(List<BinAff.Core.Data> reportDataList)
        {
            List<Facade.Dto> invoiceList = new List<Facade.Dto>();
            if (reportDataList != null && reportDataList.Count > 0)
            {
                foreach (Crystal.Invoice.Component.Data data in reportDataList)
                {
                    invoiceList.Add(new Facade.Dto
                    {
                        Id = data.Id,
                        date = data.Date,
                        invoiceNumber = data.InvoiceNumber,
                        seller = data.Seller == null ? null : new Facade.Seller.Dto
                        {
                            Name = data.Seller.Name,
                            Address = data.Seller.Address,
                            ContactNumber = data.Seller.ContactNumber,
                            Email = data.Seller.Email,
                            Liscence = data.Seller.Liscence
                        },
                        buyer = data.Buyer == null ? null : new Facade.Buyer.Dto
                        {
                            Name = data.Buyer.Name,
                            Address = data.Buyer.Address,
                            ContactNumber = data.Buyer.ContactNumber,
                            Email = data.Buyer.Email
                        }
                    });
                }
            }
            return invoiceList;
        }


       
    }
}
