using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysCustRpt = Crystal.Customer.Component.Report;
using CrysRpt = Crystal.Report.Component;

using UtilityReport = Vanilla.Utility.Facade.Report;

namespace AutoTourism.Customer.Facade.Report
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
            return new CrysCustRpt.Data
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
            return new CrysCustRpt.Server(new CrysCustRpt.Data
            {
                Category = reportCategory,
                Date = (this.FormDto as FormDto).Dto.Date,
            });
        }

        protected override ICrud CreateComponentInstance(CrysRpt.Data rptData)
        {
            return new CrysCustRpt.Server(rptData as CrysCustRpt.Data);
        }

        public override Vanilla.Report.Facade.Document.Dto SetReportCredential()
        {
            (this.FormDto as FormDto).Dto.DataSource = "Customer";

            //Path is wrong
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("Vanilla"));
            path += @"AutoTourism\Source Code\AutoTourism\Customer\AutoTourism.Customer.WinForm\Report\" + (this.FormDto as FormDto).Dto.ReportName;
            
            (this.FormDto as FormDto).Dto.Path = path;
            return (this.FormDto as FormDto).Dto;
        }

        protected override Vanilla.Report.Facade.Document.Dto ConvertReportData(CrysRpt.Data data)
        {
            CrysCustRpt.Data reportData = data as CrysCustRpt.Data;            
            return new Dto
            {
                Id = reportData.Id,
                CheckInDate = reportData.CheckInDate,
                RoomCheckInId = reportData.RoomCheckInId,
                ReservationId = reportData.ReservationId,
                CheckInStatusId = reportData.CheckInStatusId,
                InvoiceNumber = reportData.InvoiceNumber,
                BookingFrom = reportData.BookingFrom,
                NoOfDays = reportData.NoOfDays,
                NoOfPersons = reportData.NoOfPersons,
                NoOfRooms = reportData.NoOfRooms,
                Description = reportData.Description,
                RoomCategoryId = reportData.RoomCategoryId,
                RoomTypeId = reportData.RoomTypeId,
                Advance = reportData.Advance,

                FirstName = reportData.FirstName,
                MiddleName = reportData.MiddleName,
                LastName = reportData.LastName,
                Address = reportData.Address,
                State = reportData.State,
                City = reportData.City,
                Pin = reportData.Pin,
                Email = reportData.Email,
                IdentityProofType = reportData.IdentityProofType,
                IdentityProofName = reportData.IdentityProofName,
                ContactNumber = reportData.ContactNumber
            };
        }

    }

}
