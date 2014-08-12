using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Invoice.Component.Payment
{

    public class Dao : BinAff.Core.Dao
    {
        
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Invoice.PaymentInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Invoice.PaymentRead";
            base.ReadAllStoredProcedure = "Invoice.PaymentReadAll";
            base.UpdateStoredProcedure = "Invoice.PaymentUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Invoice.PaymentDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            Data data = this.Data as Data;
            if (data.Invoice == null || data.Invoice.Id == 0)
            {
                base.AddInParameter("@InvoiceId", DbType.Int64, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@InvoiceId", DbType.Int64, data.Invoice.Id);
            }
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.Invoice = new Component.Data
                {
                    Id = Convert.IsDBNull(row["InvoiceId"]) ? 0 : Convert.ToInt64(row["InvoiceId"])
                };
                dt.Date = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]);
            }
            return dt;
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ret.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Invoice = new Component.Data
                        {
                            Id = Convert.IsDBNull(row["InvoiceId"]) ? 0 : Convert.ToInt64(row["InvoiceId"])
                        },
                        Date = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]),
                    });
                }
            }
            return ret;
        }

        public List<Data> IsPaymentTypeDeletable(Payment.Type.Data paymentType)
        {
            //List<Data> dataList = new List<Data>();
            //this.CreateConnection();
            //this.CreateCommand("[Invoice].[IsPaymentTypeDeletable]");
            //this.AddInParameter("@PaymentTypeId", DbType.Int64, paymentType.Id);
            //DataSet ds = this.ExecuteDataSet();
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        dataList.Add(new Data
            //        {
            //            Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
            //            CardNumber = Convert.IsDBNull(row["CardNumber"]) ? String.Empty : Convert.ToString(row["CardNumber"])
            //        });
            //    }
            //}

            //this.CloseConnection();
            //return dataList;
            throw new NotImplementedException();
        }

        public List<BinAff.Core.Data> ReadPayment(Int64 invoiceId)
        {           
            //this.CreateCommand("[Invoice].[PaymentInvoiceRead]");
            //this.AddInParameter("@InvoiceId", DbType.Int64, invoiceId);
            //DataSet ds = this.ExecuteDataSet();            
            //return this.CreateDataObjectList(ds);
            throw new NotImplementedException();
        }

    }

}
