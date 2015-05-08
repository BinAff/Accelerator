using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Organization.Component.Unit.ClosureReason
{
    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Organization.UnitClosureReasonInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Organization.UnitClosureReasonRead";
            base.ReadAllStoredProcedure = "Organization.UnitClosureReasonReadAll";
            base.ReadForParentStoredProcedure = "Organization.UnitClosureReasonReadForParent";
            base.UpdateStoredProcedure = "Organization.UnitClosureReasonUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Organization.UnitClosureReasonDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Reason", System.Data.DbType.String, ((Data)this.Data).Reason);
            base.AddInParameter("@UnitId", System.Data.DbType.String, this.ParentData.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            if (dr != null)
            {
                dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
                dt.Reason = Convert.IsDBNull(dr["Reason"]) ? String.Empty : Convert.ToString(dr["Reason"]);
                dt.ClosedDate = Convert.IsDBNull(dr["ClosedDate"]) ? DateTime.MaxValue : Convert.ToDateTime(dr["ClosedDate"]);
            }
            return dt;
        }

        protected override void AttachChildDataToParent()
        {
            (this.ParentData as Unit.Data).ClosureReasonList = new List<BinAff.Core.Data> { this.Data as Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                (this.ParentData as Unit.Data).ClosureReasonList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    (this.ParentData as Unit.Data).ClosureReasonList.Add(data as Data);
                }
            }

        }

    }

}