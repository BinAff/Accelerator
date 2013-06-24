using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Invoice.Component.LineItem
{
    public class Dao : BinAff.Core.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Invoice].[LineItemInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Invoice].[LineItemRead]";
            base.ReadForParentStoredProcedure = "[Invoice].[LineItemReadForParent]";
            base.ReadAllStoredProcedure = "[Invoice].[LineItemReadAll]";
            base.UpdateStoredProcedure = "[Invoice].[LineItemUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Invoice].[LineItemDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Start", DbType.DateTime, ((Data)this.Data).Start);
            base.AddInParameter("@End", DbType.DateTime, ((Data)this.Data).End);
            base.AddInParameter("@Description", DbType.String, ((Data)this.Data).Description);
            base.AddInParameter("@UnitRate", DbType.Double, ((Data)this.Data).UnitRate);
            base.AddInParameter("@Count", DbType.Int32, ((Data)this.Data).Count);
            base.AddInParameter("@InvoiceId", DbType.Int64, this.ParentData.Id);
        }
        
        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.Start = Convert.IsDBNull(row["Start"]) ? DateTime.MinValue : Convert.ToDateTime(row["Start"]);
                dt.End = Convert.IsDBNull(row["End"]) ? DateTime.MinValue : Convert.ToDateTime(row["End"]);
                dt.Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]);
                dt.UnitRate = Convert.IsDBNull(row["UnitRate"]) ? 0 : Convert.ToDouble(row["UnitRate"]);
                dt.Count = Convert.IsDBNull(row["Count"]) ? 0 : Convert.ToInt32(row["Count"]);
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
                        Start = Convert.IsDBNull(row["Start"]) ? DateTime.MinValue : Convert.ToDateTime(row["Start"]),
                        End = Convert.IsDBNull(row["End"]) ? DateTime.MinValue : Convert.ToDateTime(row["End"]),
                        Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]),
                        UnitRate = Convert.IsDBNull(row["UnitRate"]) ? 0 : Convert.ToDouble(row["UnitRate"]),
                        Count = Convert.IsDBNull(row["Count"]) ? 0 : Convert.ToInt32(row["Count"]),
                    });
                }
            }
            return ret;
        }

        protected override void AttachChildDataToParent()
        {
            ((Invoice.Component.Data)this.ParentData).LineItem = new List<BinAff.Core.Data> { (Data)this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                ((Invoice.Component.Data)this.ParentData).LineItem = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    ((Invoice.Component.Data)this.ParentData).LineItem.Add((Data)data);
                }
            }

        }
    }
}
