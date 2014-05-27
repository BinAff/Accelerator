using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Invoice.Component.Taxation.Slab
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
            base.ReadStoredProcedure = "[Invoice].[SlabRead]";
            base.ReadAllStoredProcedure = "[Invoice].[SlabReadAll]";
            base.ReadForParentStoredProcedure = "[Invoice].[SlabReadForParent]";
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

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.Limit = Convert.IsDBNull(row["Limit"]) ? 0 : Convert.ToDouble(row["Limit"]);
                dt.Amount = Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDouble(row["Amount"]);
                dt.Start = Convert.IsDBNull(row["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["StartDate"]);
                dt.End = Convert.IsDBNull(row["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["EndDate"]);               
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
                        Limit = Convert.IsDBNull(row["Limit"]) ? 0 : Convert.ToDouble(row["Limit"]),
                        Amount = Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDouble(row["Amount"]),
                        Start = Convert.IsDBNull(row["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["StartDate"]),
                        End = Convert.IsDBNull(row["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["EndDate"]),
                    });
                }
            }
            return ret;
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            ((Taxation.Data)this.ParentData).SlabList = dataList;
        }

        protected override void AttachChildDataToParent()
        {
            ((Taxation.Data)this.ParentData).SlabList = new List<BinAff.Core.Data>
            {
                { this.Data }
            };
        }

    }

}
