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
            base.CreateStoredProcedure = "[Invoice].[PaymentInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Invoice].[PaymentRead]";
            base.ReadAllStoredProcedure = "[Invoice].[PaymentReadAll]";
            base.UpdateStoredProcedure = "[Invoice].[PaymentUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Invoice].[PaymentDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {   
            base.AddInParameter("@CardNumber", DbType.String, ((Data)this.Data).CardNumber);
            base.AddInParameter("@Remark", DbType.String, ((Data)this.Data).Remark);
            base.AddInParameter("@PaymentTypeId", DbType.Int64, ((Data)this.Data).Type.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.Date = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]);
                dt.CardNumber = Convert.IsDBNull(row["CardNumber"]) ? String.Empty : Convert.ToString(row["CardNumber"]);
                dt.Remark = Convert.IsDBNull(row["Remark"]) ? String.Empty : Convert.ToString(row["Remark"]);
                dt.Type = new Type.Data()
                {
                    Id = Convert.IsDBNull(row["PaymentTypeId"]) ? 0 : Convert.ToInt64(row["PaymentTypeId"])
                };
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
                        Date = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]),
                        CardNumber = Convert.IsDBNull(row["CardNumber"]) ? String.Empty : Convert.ToString(row["CardNumber"]),
                        Remark = Convert.IsDBNull(row["Remark"]) ? String.Empty : Convert.ToString(row["Remark"]),
                        Type = new Type.Data()
                        {
                            Id = Convert.IsDBNull(row["PaymentTypeId"]) ? 0 : Convert.ToInt64(row["PaymentTypeId"])
                        },
                    });
                }
            }
            return ret;
        }

        public List<Data> IsPaymentTypeDeletable(Payment.Type.Data paymentType)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("[Invoice].[IsPaymentTypeDeletable]");
            this.AddInParameter("@PaymentTypeId", DbType.Int64, paymentType.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        CardNumber = Convert.IsDBNull(row["CardNumber"]) ? String.Empty : Convert.ToString(row["CardNumber"])
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

    }
}
