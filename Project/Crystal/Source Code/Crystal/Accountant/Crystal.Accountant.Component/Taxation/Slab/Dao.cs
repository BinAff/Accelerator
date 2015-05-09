using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Accountant.Component.Tax.Slab
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            //base.CreateStoredProcedure = "[Invoice].[TaxationInsert]";
            //base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Accountant.TaxSlabRead";
            base.ReadAllStoredProcedure = "Accountant.TaxSlabReadAll";
            base.ReadForParentStoredProcedure = "Accountant.TaxSlabReadForParent";
            //base.UpdateStoredProcedure = "[Invoice].[TaxationUpdate]";
            //base.NumberOfRowsAffectedInUpdate = -1;
            //base.DeleteStoredProcedure = "[Invoice].[TaxationDelete]";
            //base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            //TO DO :: For save screen
            //base.AddInParameter("@Amount", DbType.Double, ((Data)this.Data).Amount);
            //base.AddInParameter("@IsPercentage", DbType.Boolean, ((Data)this.Data).isPercentage);
            //base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = data.Id;
            dt.Limit = Convert.IsDBNull(dr["Limit"]) ? 0 : Convert.ToDouble(dr["Limit"]);
            dt.Amount = Convert.IsDBNull(dr["Amount"]) ? 0 : Convert.ToDouble(dr["Amount"]);
            dt.Start = Convert.IsDBNull(dr["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["StartDate"]);
            dt.End = Convert.IsDBNull(dr["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["EndDate"]);
            return dt;
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            ((Tax.Data)this.ParentData).SlabList = dataList;
        }

        protected override void AttachChildDataToParent()
        {
            ((Tax.Data)this.ParentData).SlabList = new List<BinAff.Core.Data>
            {
                { this.Data }
            };
        }

    }

}
