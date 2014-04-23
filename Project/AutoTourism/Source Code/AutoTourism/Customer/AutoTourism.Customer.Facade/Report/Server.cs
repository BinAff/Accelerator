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

        protected override CrysRpt.IReport CreateComponentInstance(CrysRpt.Category.Data reportCategory)
        {
            return new CrysCustRpt.Server(new CrysCustRpt.Data
            {
                Category = reportCategory,
            });
        }

        public override void SetReportCredential()
        {
            (this.FormDto as FormDto).Dto.DataSource = "Customer";
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("AutoTourism"));
            path += @"AutoTourism\Source Code\AutoTourism\Customer\AutoTourism.Customer.WinForm\Report\Daily.rdlc";
            (this.FormDto as FormDto).Dto.Path = path;
        }

        protected override BinAff.Facade.Library.Dto ConvertReportData(CrysRpt.Data data)
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
