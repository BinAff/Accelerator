using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysInvRpt = Crystal.Invoice.Component.Report;
using CrysRpt = Crystal.Report.Component;

namespace Vanilla.Invoice.Facade.Report
{

    public class Server : Vanilla.Report.Facade.Document.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrysInvRpt.Data
            {
                Id = reportDto.Id,
                Date = reportDto.Date,
                Category = new CrysRpt.Category.Data
                {
                    Id = reportDto.Category.Id
                },
            };
        }

        protected override CrysRpt.IReport CreateComponentInstance(CrysRpt.Category.Data reportCategory)
        {
            return new CrysInvRpt.Server(new CrysInvRpt.Data
            {
                Category = reportCategory,
            });
        }

        protected override ICrud CreateComponentInstance(CrysRpt.Data rptData)
        {
            return new CrysInvRpt.Server(rptData as CrysInvRpt.Data);
        }

        public override Vanilla.Report.Facade.Document.Dto SetReportCredential()
        {
            (this.FormDto as FormDto).Dto.DataSource = "Sales";

            //Path is wrong
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("AutoTourism"));
            path += @"Vanilla\Source Code\Vanilla\Invoice\Vanilla.Invoice.WinForm\Report\" + (this.FormDto as FormDto).Dto.ReportName;

            (this.FormDto as FormDto).Dto.Path = path;
            return (this.FormDto as FormDto).Dto;
        }

        protected override BinAff.Facade.Library.Dto ConvertReportData(CrysRpt.Data data)
        {
            CrysInvRpt.Data reportData = data as CrysInvRpt.Data;
            return new Dto
            {
                Id = reportData.Id,
                InvoiceNumber = reportData.InvoiceNumber,
                InvoiceDate = reportData.InvoiceDate,
                Amount = reportData.Amount,
                AmountPaid = reportData.AmountPaid,
                Discount = reportData.Discount,
                Tax = reportData.Tax,

                SellerName = reportData.SellerName,
                SellerAddress = reportData.SellerAddress,
                SellerContactNo = reportData.SellerContactNo,
                SellerEmail = reportData.SellerEmail,
                SellerLicence = reportData.SellerLicence,

                BuyerName = reportData.BuyerName,
                BuyerAddress = reportData.BuyerAddress,
                BuyerContactNo = reportData.BuyerContactNo,
            };
        }

        //public override void LoadForm()
        //{
        //    //throw new NotImplementedException();
        //}

        //public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        //{            
        //    Crystal.Invoice.Component.Report.Data invoiceReportData = data as Crystal.Invoice.Component.Report.Data;
        //    return new Dto
        //    {
        //        Id = invoiceReportData.Id,
        //        date = invoiceReportData.Date,
        //        //fromDate = invoiceReportData.FromDate,
        //        //toDate = invoiceReportData.ToDate,
        //        category = invoiceReportData.Category == null ? null : new Vanilla.Report.Facade.Category.Dto{ Id = invoiceReportData.Category.Id }
        //    };
        //}

        //public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        //{
        //    Dto reportDto = dto as Dto;
        //    return new CrystalInvoiceReport.Data
        //    {
        //        Date = reportDto.date,
        //        //FromDate = reportDto.fromDate,
        //        //ToDate = reportDto.toDate,
        //        Category = new Crystal.Report.Component.Category.Data { Id = reportDto.category.Id }
        //    };
        //}

        //public override void Add()
        //{            
        //    FormDto formDto = this.FormDto as FormDto;

        //    CrystalInvoiceReport.Data invoiceReportData = this.Convert(formDto.Dto) as CrystalInvoiceReport.Data;           
        //    ICrud crud = new CrystalInvoiceReport.Server(invoiceReportData);
        //    ReturnObject<bool> retVal = crud.Save();

        //    if (retVal.Value && invoiceReportData.Id > 0)
        //        formDto.Dto.Id = invoiceReportData.Id;

        //    this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);           
        //}

        //List<Facade.Dto> IReport.GetDailyReport(System.DateTime date)
        //{            
        //    CrystalReport.IReport report = new CrystalInvoiceReport.Server(null);
        //    List<BinAff.Core.Data> reportDataList = report.GetReport(date);
        //    return this.GetSalesData(reportDataList);
        //}

        //List<Facade.Dto> IReport.GetWeeklyReport(System.DateTime date)
        //{
        //    CrystalReport.IReport report = new CrystalInvoiceReport.Server(null);
        //    List<BinAff.Core.Data> reportDataList = report.GetReport(date);
        //    return this.GetSalesData(reportDataList);
        //}
                
        //List<Facade.Dto> IReport.GetMonthlyReport(System.DateTime date)
        //{
        //    CrystalReport.IReport report = new CrystalInvoiceReport.Server(null);
        //    List<BinAff.Core.Data> reportDataList = report.GetReport(date);
        //    return this.GetSalesData(reportDataList);
        //}

        //List<Facade.Dto> IReport.GetQuarterlyReport(System.DateTime date)
        //{
        //    CrystalReport.IReport report = new CrystalInvoiceReport.Server(null);
        //    List<BinAff.Core.Data> reportDataList = report.GetReport(date);
        //    return this.GetSalesData(reportDataList);
        //}

        //List<Facade.Dto> IReport.GetYearlyReport(System.DateTime date)
        //{
        //    CrystalReport.IReport report = new CrystalInvoiceReport.Server(null);
        //    List<BinAff.Core.Data> reportDataList = report.GetReport(date);
        //    return this.GetSalesData(reportDataList);
        //}
                
        //private List<Facade.Dto> GetSalesData(List<BinAff.Core.Data> reportDataList)
        //{
        //    List<Facade.Dto> invoiceList = new List<Facade.Dto>();
        //    if (reportDataList != null && reportDataList.Count > 0)
        //    {
        //        foreach (Crystal.Invoice.Component.Data data in reportDataList)
        //        {
        //            invoiceList.Add(new Facade.Dto
        //            {
        //                Id = data.Id,
        //                date = data.Date,
        //                invoiceNumber = data.InvoiceNumber,
        //                seller = data.Seller == null ? null : new Facade.Seller.Dto
        //                {
        //                    Name = data.Seller.Name,
        //                    Address = data.Seller.Address,
        //                    ContactNumber = data.Seller.ContactNumber,
        //                    Email = data.Seller.Email,
        //                    Liscence = data.Seller.Liscence
        //                },
        //                buyer = data.Buyer == null ? null : new Facade.Buyer.Dto
        //                {
        //                    Name = data.Buyer.Name,
        //                    Address = data.Buyer.Address,
        //                    ContactNumber = data.Buyer.ContactNumber,
        //                    Email = data.Buyer.Email
        //                }
        //            });
        //        }
        //    }
        //    return invoiceList;
        //}

    }

}
