using System.Collections.Generic;
using BinAff.Core;
using CrystalCustomerReport = Crystal.Customer.Component.Report;
using CrystalReport = Crystal.Report.Component;
using UtilityReport = Vanilla.Utility.Facade.Report;

namespace AutoTourism.Customer.Facade.Report
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
            CrystalCustomerReport.Data customerReportData = data as CrystalCustomerReport.Data;
            return new Dto
            {
                Id = customerReportData.Id,
                date = customerReportData.Date,
                category = customerReportData.Category == null ? null : new Vanilla.Utility.Facade.Report.Category.Dto{ Id = customerReportData.Category.Id }                               
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrystalCustomerReport.Data
            {
                Date = reportDto.date,               
                Category = new Crystal.Report.Component.Category.Data { Id = reportDto.category.Id }
            };
        }

        public override void Add()
        {            
            FormDto formDto = this.FormDto as FormDto;

            CrystalCustomerReport.Data customerReportData = this.Convert(formDto.dto) as CrystalCustomerReport.Data;
            ICrud crud = new CrystalCustomerReport.Server(customerReportData);
            ReturnObject<bool> retVal = crud.Save();

            if (retVal.Value && customerReportData.Id > 0)
                formDto.dto.Id = customerReportData.Id;

            this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);           
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetDailyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetDailyReport(date);
            return this.GetCustomerData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetWeeklyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetWeeklyReport(date);
            return this.GetCustomerData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetMonthlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetMonthlyReport(date);
            return this.GetCustomerData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetQuarterlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetQuarterlyReport(date);
            return this.GetCustomerData(reportDataList);
        }

        List<UtilityReport.Dto> UtilityReport.IReport.GetYearlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetYearlyReport(date);
            return this.GetCustomerData(reportDataList);
        }

        private List<UtilityReport.Dto> GetCustomerData(List<BinAff.Core.Data> reportDataList)
        {
            List<UtilityReport.Dto> customerList = new List<UtilityReport.Dto>();
            if (reportDataList != null && reportDataList.Count > 0)
            {
                foreach (CrystalCustomerReport.Data data in reportDataList)
                {                    
                    customerList.Add(new Dto
                    {
                        Id = data.Id,
                        CheckInDate = data.CheckInDate,
                        RoomCheckInId = data.RoomCheckInId,
                        ReservationId = data.ReservationId,
                        CheckInStatusId = data.CheckInStatusId,
                        InvoiceNumber = data.InvoiceNumber,
                        BookingFrom = data.BookingFrom,
                        NoOfDays = data.NoOfDays,
                        NoOfPersons = data.NoOfPersons,
                        NoOfRooms = data.NoOfRooms,
                        Description = data.Description,
                        RoomCategoryId = data.RoomCategoryId,
                        RoomTypeId = data.RoomTypeId,
                        Advance = data.Advance,

                        Initial = data.Initial,
                        FirstName = data.FirstName,
                        MiddleName = data.MiddleName,
                        LastName = data.LastName,
                        Address = data.Address,
                        State = data.State,
                        City = data.City,
                        Pin = data.Pin,
                        Email = data.Email,
                        IdentityProofType = data.IdentityProofType,
                        IdentityProofName = data.IdentityProofName,
                        ContactNumber= data.ContactNumber
                    });
                }
            }
            return customerList;
        }
    }
}
