using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Invoice.Component.Report
{
    public class Dao : Crystal.Report.Component.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Invoice].[ReportInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Invoice].[ReportRead]";
            base.ReadAllStoredProcedure = "[Invoice].[ReportReadAll]";           
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            //base.AddInParameter("@From", DbType.DateTime, ((Data)this.Data).FromDate);
            //base.AddInParameter("@To", DbType.DateTime, ((Data)this.Data).ToDate);
            //base.AddInParameter("@CategoryId", DbType.Int64, ((Data)this.Data).category.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            return base.CreateDataObject(ds, data);
            //Data dt = (Data)data;
            //DataRow row;
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    row = ds.Tables[0].Rows[0];

            //    dt.Id = data.Id;
            //    dt.FromDate = Convert.IsDBNull(row["Start"]) ? DateTime.MinValue : Convert.ToDateTime(row["Start"]);
            //    dt.ToDate = Convert.IsDBNull(row["End"]) ? DateTime.MinValue : Convert.ToDateTime(row["End"]);
            //    dt.category = Convert.IsDBNull(row["ReportCategoryId"]) ? null : new Crystal.Report.Component.Category.Data { Id = Convert.ToInt64(row["ReportCategoryId"]) };
            //}

            //return dt;
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            return base.CreateDataObjectList(ds);
            //List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();

            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        ret.Add(new Data
            //        {
            //            Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
            //            Date = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]),
            //            FromDate = Convert.IsDBNull(row["FromDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["FromDate"]),
            //            ToDate = Convert.IsDBNull(row["ToDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["ToDate"])
            //        });
            //    }
            //}
            //return ret;
        }

        public List<BinAff.Core.Data> GetSalesData(DateTime fromDate, DateTime toDate)
        {
            List<BinAff.Core.Data> invoiceList = new List<BinAff.Core.Data>();

            base.CreateCommand("[Invoice].[ReportSales]");
            base.AddInParameter("@StartDate", DbType.DateTime, fromDate.Date);
            base.AddInParameter("@EndDate", DbType.DateTime, toDate.Date);
            DataSet ds = base.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    invoiceList.Add(new Component.Data
                    {
                        Id = Convert.IsDBNull(row["id"]) ? 0 : Convert.ToInt64(row["id"]),
                        Date = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]),
                        InvoiceNumber = Convert.IsDBNull(row["InvoiceNumber"]) ? String.Empty : Convert.ToString(row["InvoiceNumber"]),
                        Seller = new Seller
                        {
                            Name = Convert.IsDBNull(row["SellerName"]) ? String.Empty : Convert.ToString(row["SellerName"]),
                            Address = Convert.IsDBNull(row["SellerAddress"]) ? String.Empty : Convert.ToString(row["SellerAddress"]),
                            ContactNumber = Convert.IsDBNull(row["SellerContactNo"]) ? String.Empty : Convert.ToString(row["SellerContactNo"]),
                            Email = Convert.IsDBNull(row["SellerEmail"]) ? String.Empty : Convert.ToString(row["SellerEmail"]),
                            Liscence = Convert.IsDBNull(row["SellerLicence"]) ? String.Empty : Convert.ToString(row["SellerLicence"])
                        },
                        Buyer = new Buyer 
                        {
                            Name = Convert.IsDBNull(row["BuyerName"]) ? String.Empty : Convert.ToString(row["BuyerName"]),
                            Address = Convert.IsDBNull(row["BuyerAddress"]) ? String.Empty : Convert.ToString(row["BuyerAddress"]),
                            ContactNumber = Convert.IsDBNull(row["BuyerContactNo"]) ? String.Empty : Convert.ToString(row["BuyerContactNo"]),
                            Email = Convert.IsDBNull(row["BuyerEmail"]) ? String.Empty : Convert.ToString(row["BuyerEmail"])
                        },
                    });
                }
            }

            return invoiceList;
        }

    }
}
