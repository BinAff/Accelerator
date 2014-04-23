using System.Collections.Generic;
using BinAff.Core;
using CrystalRoomReservationReport = Crystal.Lodge.Component.RoomReservationReport;
using CrystalReport = Crystal.Report.Component;
using UtilityReport = Vanilla.Utility.Facade.Report;

namespace AutoTourism.Lodge.Facade.RoomReservationReport
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
            CrystalRoomReservationReport.Data roomReservationReportData = data as CrystalRoomReservationReport.Data;
            return new Dto
            {
                Id = roomReservationReportData.Id,
                Date = roomReservationReportData.Date,
                category = roomReservationReportData.Category == null ? null : new Vanilla.Utility.Facade.Report.Category.Dto { Id = roomReservationReportData.Category.Id }                               
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrystalRoomReservationReport.Data
            {
                Date = reportDto.Date,               
                Category = new Crystal.Report.Component.Category.Data { Id = reportDto.category.Id }
            };
        }

        public override void Add()
        {            
            FormDto formDto = this.FormDto as FormDto;

            CrystalRoomReservationReport.Data customerReportData = this.Convert(formDto.dto) as CrystalRoomReservationReport.Data;
            ICrud crud = new CrystalRoomReservationReport.Server(customerReportData);
            ReturnObject<bool> retVal = crud.Save();

            if (retVal.Value && customerReportData.Id > 0)
                formDto.dto.Id = customerReportData.Id;

            this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);           
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetDailyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalRoomReservationReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetDailyReport(date);
            return this.GetRoomReservationData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetWeeklyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalRoomReservationReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetWeeklyReport(date);
            return this.GetRoomReservationData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetMonthlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalRoomReservationReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetMonthlyReport(date);
            return this.GetRoomReservationData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetQuarterlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalRoomReservationReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetQuarterlyReport(date);
            return this.GetRoomReservationData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetYearlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalRoomReservationReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetYearlyReport(date);
            return this.GetRoomReservationData(reportDataList);
        }

        private List<UtilityReport.Dto> GetRoomReservationData(List<BinAff.Core.Data> reportDataList)
        {
            List<UtilityReport.Dto> roomReservationList = new List<UtilityReport.Dto>();
            if (reportDataList != null && reportDataList.Count > 0)
            {
                foreach (Crystal.Customer.Component.Data data in reportDataList)
                {
                    roomReservationList.Add(new UtilityReport.Dto
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
            return roomReservationList;
        }





        
    }
}
