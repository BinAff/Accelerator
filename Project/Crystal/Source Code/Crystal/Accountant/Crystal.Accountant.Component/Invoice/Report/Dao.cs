using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Accountant.Component.Invoice.Report
{

    public class Dao : Crystal.Report.Component.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Accountant.InvoiceReportInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Accountant.InvoiceReportRead";
            base.ReadAllStoredProcedure = "Accountant.InvoiceReportReadAll";           
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
        }

        public override List<BinAff.Core.Data> GetData(DateTime fromDate, DateTime toDate)
        {
            List<BinAff.Core.Data> invoiceList = new List<BinAff.Core.Data>();

            base.CreateCommand("Accountant.InvoiceReportSales"); //SP missing in DB
            base.AddInParameter("@StartDate", DbType.DateTime, fromDate.Date);
            base.AddInParameter("@EndDate", DbType.DateTime, toDate.Date);
            DataSet ds = base.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    invoiceList.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["id"]) ? 0 : Convert.ToInt64(row["id"]),
                        InvoiceDate = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]),
                        InvoiceNumber = Convert.IsDBNull(row["InvoiceNumber"]) ? String.Empty : Convert.ToString(row["InvoiceNumber"]),
                        Amount = Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDouble(row["Amount"]),
                        Discount = Convert.IsDBNull(row["Discount"]) ? 0 : Convert.ToDouble(row["Discount"]),
                        Tax = Convert.IsDBNull(row["Tax"]) ? 0 : Convert.ToDouble(row["Tax"]),
                        AmountPaid = Convert.IsDBNull(row["AmountPaid"]) ? 0 : Convert.ToDouble(row["AmountPaid"]),

                        BuyerName = Convert.IsDBNull(row["BuyerName"]) ? String.Empty : Convert.ToString(row["BuyerName"]),
                        BuyerContactNo = Convert.IsDBNull(row["BuyerContactNo"]) ? String.Empty : Convert.ToString(row["BuyerContactNo"]),
                        BuyerAddress = Convert.IsDBNull(row["BuyerAddress"]) ? String.Empty : Convert.ToString(row["BuyerAddress"]),

                        SellerName = Convert.IsDBNull(row["SellerName"]) ? String.Empty : Convert.ToString(row["SellerName"]),
                        SellerLicence = Convert.IsDBNull(row["SellerLicence"]) ? String.Empty : Convert.ToString(row["SellerLicence"]),
                        SellerAddress = Convert.IsDBNull(row["SellerAddress"]) ? String.Empty : Convert.ToString(row["SellerAddress"]),
                        SellerContactNo = Convert.IsDBNull(row["SellerContactNo"]) ? String.Empty : Convert.ToString(row["SellerContactNo"]),
                        SellerEmail = Convert.IsDBNull(row["SellerEmail"]) ? String.Empty : Convert.ToString(row["SellerEmail"]),

                    });
                    //invoiceList.Add(new Component.Data
                    //{
                    //    Id = Convert.IsDBNull(row["id"]) ? 0 : Convert.ToInt64(row["id"]),
                    //    Date = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]),
                    //    InvoiceNumber = Convert.IsDBNull(row["InvoiceNumber"]) ? String.Empty : Convert.ToString(row["InvoiceNumber"]),
                    //    Seller = new Seller
                    //    {
                    //        Name = Convert.IsDBNull(row["SellerName"]) ? String.Empty : Convert.ToString(row["SellerName"]),
                    //        Address = Convert.IsDBNull(row["SellerAddress"]) ? String.Empty : Convert.ToString(row["SellerAddress"]),
                    //        ContactNumber = Convert.IsDBNull(row["SellerContactNo"]) ? String.Empty : Convert.ToString(row["SellerContactNo"]),
                    //        Email = Convert.IsDBNull(row["SellerEmail"]) ? String.Empty : Convert.ToString(row["SellerEmail"]),
                    //        Liscence = Convert.IsDBNull(row["SellerLicence"]) ? String.Empty : Convert.ToString(row["SellerLicence"])
                    //    },
                    //    Buyer = new Buyer 
                    //    {
                    //        Name = Convert.IsDBNull(row["BuyerName"]) ? String.Empty : Convert.ToString(row["BuyerName"]),
                    //        Address = Convert.IsDBNull(row["BuyerAddress"]) ? String.Empty : Convert.ToString(row["BuyerAddress"]),
                    //        ContactNumber = Convert.IsDBNull(row["BuyerContactNo"]) ? String.Empty : Convert.ToString(row["BuyerContactNo"]),
                    //        Email = Convert.IsDBNull(row["BuyerEmail"]) ? String.Empty : Convert.ToString(row["BuyerEmail"])
                    //    },
                    //});
                }
            }

            return invoiceList;
        }

    }

}