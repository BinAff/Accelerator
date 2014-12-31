using System.Collections.Generic;
using BinAff.Core;
using CrystalCheckInReport = Crystal.Lodge.Component.CheckInReport;
using CrystalReport = Crystal.Report.Component;
using UtilityReport = Vanilla.Utility.Facade.Report;

namespace AutoTourism.Lodge.Facade.CheckInReport
{
    public class Server : BinAff.Facade.Library.Server, UtilityReport.IReport
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
            CrystalCheckInReport.Data checkInReportData = data as CrystalCheckInReport.Data;
            return new Dto
            {
                Id = checkInReportData.Id,
                Date = checkInReportData.Date,
                Category = checkInReportData.Category == null ? null : new Vanilla.Utility.Facade.Report.Category.Dto { Id = checkInReportData.Category.Id }                               
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrystalCheckInReport.Data
            {
                Date = reportDto.Date,               
                Category = new Crystal.Report.Component.Category.Data { Id = reportDto.Category.Id }
            };
        }

        public override void Add()
        {            
            FormDto formDto = this.FormDto as FormDto;

            CrystalCheckInReport.Data customerReportData = this.Convert(formDto.Dto) as CrystalCheckInReport.Data;
            ICrud crud = new CrystalCheckInReport.Server(customerReportData);
            ReturnObject<bool> retVal = crud.Save();

            if (retVal.Value && customerReportData.Id > 0)
                formDto.Dto.Id = customerReportData.Id;

            this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);           
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetDailyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCheckInReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetReport(date);
            return this.GetCheckInData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetWeeklyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCheckInReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetReport(date);
            return this.GetCheckInData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetMonthlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCheckInReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetReport(date);
            return this.GetCheckInData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetQuarterlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCheckInReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetReport(date);
            return this.GetCheckInData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetYearlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCheckInReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetReport(date);
            return this.GetCheckInData(reportDataList);
        }

        private List<UtilityReport.Dto> GetCheckInData(List<BinAff.Core.Data> reportDataList)
        {
            List<UtilityReport.Dto> checkInList = new List<UtilityReport.Dto>();
            if (reportDataList != null && reportDataList.Count > 0)
            {
                foreach (Crystal.Customer.Component.Data data in reportDataList)
                {
                    checkInList.Add(new UtilityReport.Dto
                    {
                        Id = data.Id,
                     
                        //date = data.Date,
                        //invoiceNumber = data.InvoiceNumber,
                        //seller = data.Seller == null ? null : new Facade.Seller.Dto
                        //{
                        //    Name = data.Seller.Name,
                        //    Address = data.Seller.Address,
                        //    ContactNumber = data.Seller.ContactNumber,
                        //    Email = data.Seller.Email,
                        //    Liscence = data.Seller.Liscence
                        //},
                        //buyer = data.Buyer == null ? null : new Facade.Buyer.Dto
                        //{
                        //    Name = data.Buyer.Name,
                        //    Address = data.Buyer.Address,
                        //    ContactNumber = data.Buyer.ContactNumber,
                        //    Email = data.Buyer.Email
                        //}
                    });
                }
            }
            return checkInList;
        }
    }
}
