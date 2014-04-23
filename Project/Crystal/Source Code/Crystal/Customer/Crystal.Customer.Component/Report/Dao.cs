using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Customer.Component.Report
{
    public class Dao : Crystal.Report.Component.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Customer].[ReportInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Customer].[ReportRead]";
            base.ReadAllStoredProcedure = "[Customer].[ReportReadAll]";           
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            return base.CreateDataObject(ds, data);
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            return base.CreateDataObjectList(ds);            
        }

        public override List<BinAff.Core.Data> GetData(DateTime fromDate, DateTime toDate)
        {
            List<BinAff.Core.Data> customerList = new List<BinAff.Core.Data>();

            base.CreateCommand("[Customer].[ReportCustomer]");
            base.AddInParameter("@StartDate", DbType.DateTime, fromDate.Date);
            base.AddInParameter("@EndDate", DbType.DateTime, toDate.Date);
            DataSet ds = base.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    customerList.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["CustomerId"]) ? 0 : Convert.ToInt64(row["CustomerId"]),
                        CheckInDate = Convert.IsDBNull(row["CheckInDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["CheckInDate"]),
                        RoomCheckInId = Convert.IsDBNull(row["RoomCheckInId"]) ? 0 : Convert.ToInt32(row["RoomCheckInId"]),
                        ReservationId = Convert.IsDBNull(row["ReservationId"]) ? 0 : Convert.ToInt32(row["ReservationId"]),
                        CheckInStatusId = Convert.IsDBNull(row["CheckInStatusId"]) ? 0 : Convert.ToInt32(row["CheckInStatusId"]),
                        InvoiceNumber = Convert.IsDBNull(row["InvoiceNumber"]) ? String.Empty : Convert.ToString(row["InvoiceNumber"]),
                        BookingFrom = Convert.IsDBNull(row["BookingFrom"]) ? DateTime.MinValue : Convert.ToDateTime(row["BookingFrom"]),
                        NoOfDays = Convert.IsDBNull(row["NoOfDays"]) ? 0 : Convert.ToInt32(row["NoOfDays"]),
                        NoOfPersons = Convert.IsDBNull(row["NoOfPersons"]) ? 0 : Convert.ToInt32(row["NoOfPersons"]),
                        NoOfRooms = Convert.IsDBNull(row["NoOfRooms"]) ? 0 : Convert.ToInt32(row["NoOfRooms"]),
                        Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]),
                        RoomCategoryId = Convert.IsDBNull(row["RoomCategoryId"]) ? 0 : Convert.ToInt64(row["RoomCategoryId"]),
                        RoomTypeId = Convert.IsDBNull(row["RoomTypeId"]) ? 0 : Convert.ToInt64(row["RoomTypeId"]),
                        Advance = Convert.IsDBNull(row["Advance"]) ? 0 : Convert.ToDouble(row["Advance"]),

                        //Initial = Convert.IsDBNull(row["InitialName"]) ? String.Empty : Convert.ToString(row["InitialName"]),
                        FirstName = Convert.IsDBNull(row["FirstName"]) ? String.Empty : Convert.ToString(row["FirstName"]),
                        MiddleName = Convert.IsDBNull(row["MiddleName"]) ? String.Empty : Convert.ToString(row["MiddleName"]),
                        LastName = Convert.IsDBNull(row["LastName"]) ? String.Empty : Convert.ToString(row["LastName"]),
                        Address = Convert.IsDBNull(row["Address"]) ? String.Empty : Convert.ToString(row["Address"]),
                        State = Convert.IsDBNull(row["StateName"]) ? String.Empty : Convert.ToString(row["StateName"]),
                        City = Convert.IsDBNull(row["City"]) ? String.Empty : Convert.ToString(row["City"]),
                        Pin = Convert.IsDBNull(row["Pin"]) ? 0 : Convert.ToInt32(row["Pin"]),
                        Email = Convert.IsDBNull(row["Email"]) ? String.Empty : Convert.ToString(row["Email"]),
                        IdentityProofType = Convert.IsDBNull(row["IdentityProofType"]) ? String.Empty : Convert.ToString(row["IdentityProofType"]),
                        IdentityProofName = Convert.IsDBNull(row["IdentityProofName"]) ? String.Empty : Convert.ToString(row["IdentityProofName"]),
                        ContactNumber = Convert.IsDBNull(row["ContactNo"]) ? String.Empty : Convert.ToString(row["ContactNo"])
                    });
                }
            }

            return customerList;
        }

    }
}
