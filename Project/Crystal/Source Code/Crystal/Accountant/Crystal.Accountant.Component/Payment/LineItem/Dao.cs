using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Accountant.Component.Payment.LineItem
{
    
    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Invoice.PaymentLineItemInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Invoice.PaymentLineItemRead";
            base.ReadAllStoredProcedure = "Invoice.PaymentLineItemReadAll";
            base.UpdateStoredProcedure = "Invoice.PaymentLineItemUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Invoice.PaymentLineItemDelete";
            base.NumberOfRowsAffectedInDelete = -1;
            base.ReadForParentStoredProcedure = "Invoice.PaymentLineItemReadForParent";
        }

        protected override void AssignParameter(string procedureName)
        {
            Data data = this.Data as Data;
            base.AddInParameter("@Reference", DbType.String, data.Reference);
            base.AddInParameter("@Amount", DbType.Double, data.Amount);
            base.AddInParameter("@PaymentTypeId", DbType.Int64, data.Type.Id);
            base.AddInParameter("@Remark", DbType.String, data.Remark);
            base.AddInParameter("@PaymentId", DbType.Int64, this.ParentData.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.Reference = Convert.IsDBNull(row["Reference"]) ? String.Empty : Convert.ToString(row["Reference"]);
                dt.Amount = Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDouble(row["Amount"]);
                dt.Type = new Type.Data()
                {
                    Id = Convert.IsDBNull(row["PaymentTypeId"]) ? 0 : Convert.ToInt64(row["PaymentTypeId"])
                };
                dt.Remark = Convert.IsDBNull(row["Remark"]) ? String.Empty : Convert.ToString(row["Remark"]);
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
                        Reference = Convert.IsDBNull(row["Reference"]) ? String.Empty : Convert.ToString(row["Reference"]),
                        Amount = Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDouble(row["Amount"]),
                        Type = new Type.Data()
                        {
                            Id = Convert.IsDBNull(row["PaymentTypeId"]) ? 0 : Convert.ToInt64(row["PaymentTypeId"])
                        },
                        Remark = Convert.IsDBNull(row["Remark"]) ? String.Empty : Convert.ToString(row["Remark"]),
                    });
                }
            }
            return ret;
        }

        protected override void AttachChildDataToParent()
        {
            Payment.Data payment = this.ParentData as Payment.Data;
            if (payment.LineItemList == null) payment.LineItemList = new List<BinAff.Core.Data>();
            payment.LineItemList.Add(this.Data as Data);
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            (this.ParentData as Payment.Data).LineItemList = dataList;
        }

    }

}
