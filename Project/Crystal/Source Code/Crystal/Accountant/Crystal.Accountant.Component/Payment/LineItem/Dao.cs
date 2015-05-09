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
            base.CreateStoredProcedure = "Accountant.PaymentLineItemInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Accountant.PaymentLineItemRead";
            base.ReadAllStoredProcedure = "Accountant.PaymentLineItemReadAll";
            base.ReadForParentStoredProcedure = "Accountant.PaymentLineItemReadForParent";
            base.UpdateStoredProcedure = "Accountant.PaymentLineItemUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Accountant.PaymentLineItemDelete";
            base.NumberOfRowsAffectedInDelete = -1;
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

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = data.Id;
            dt.Reference = Convert.IsDBNull(dr["Reference"]) ? String.Empty : Convert.ToString(dr["Reference"]);
            dt.Amount = Convert.IsDBNull(dr["Amount"]) ? 0 : Convert.ToDouble(dr["Amount"]);
            dt.Type = new Type.Data()
            {
                Id = Convert.IsDBNull(dr["PaymentTypeId"]) ? 0 : Convert.ToInt64(dr["PaymentTypeId"])
            };
            dt.Remark = Convert.IsDBNull(dr["Remark"]) ? String.Empty : Convert.ToString(dr["Remark"]);
            return dt;
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