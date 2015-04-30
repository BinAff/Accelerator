using System;
using System.Collections.Generic;
using System.Data;

using InvComp = Crystal.Invoice.Component;

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
            base.ReadForParentStoredProcedure = "Invoice.PaymentReadForParent";
            base.UpdateStoredProcedure = "Invoice.PaymentUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Invoice.PaymentDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            Data data = this.Data as Data;
            base.AddInParameter("@Date", DbType.DateTime, data.Date);
            if (data.Invoice == null || data.Invoice.Id == 0)
            {
                base.AddInParameter("@InvoiceId", DbType.Int64, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@InvoiceId", DbType.Int64, data.Invoice.Id);
            }
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.SerialNumber = Convert.IsDBNull(dr["SerialNumber"]) ? 0 : Convert.ToInt32(dr["SerialNumber"]);
            if (!Convert.IsDBNull(dr["InvoiceId"]))
            {
                dt.Invoice = new Component.Data
                {
                    Id = Convert.ToInt64(dr["InvoiceId"])
                };
            }            
            dt.Date = Convert.IsDBNull(dr["Date"]) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);

            return dt;
        }

        protected override void AttachChildDataToParent()
        {
            (this.ParentData as InvComp.Data).PaymentList = new List<BinAff.Core.Data> { this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            (this.ParentData as InvComp.Data).PaymentList = dataList;
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

        internal Boolean AttachInvoice()
        {
            Data data = base.Data as Data;
            base.CreateConnection();
            base.CreateCommand("Invoice.PaymentAttachInvoice");
            base.AddInParameter("@Id", DbType.Int32, data.Id);
            base.AddInParameter("@InvoiceId", DbType.Int32, data.Invoice.Id);
            Int32 i = base.ExecuteNonQuery();
            base.CloseConnection();
            if (i != 1) return false;
            return true;
        }

    }

}
