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

        public List<BinAff.Core.Data> GetCustomerData(DateTime fromDate, DateTime toDate)
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
                        Id = Convert.IsDBNull(row["id"]) ? 0 : Convert.ToInt64(row["id"]),
                        Initial = Convert.IsDBNull(row["InitialName"]) ? String.Empty : Convert.ToString(row["InitialName"]),
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
