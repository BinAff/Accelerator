using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Customer.Component.Action.Status
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            //base.CreateStoredProcedure = "[Reservation].[StatusInsert]";
            //base.NumberOfRowsAffectedInCreate = 1;
            //base.ReadStoredProcedure = "[Reservation].[StatusRead]";
            //base.ReadAllStoredProcedure = "[Reservation].[StatusReadAll]";
            //base.UpdateStoredProcedure = "[Reservation].[StatusUpdate]";
            //base.NumberOfRowsAffectedInUpdate = -1;
            //base.DeleteStoredProcedure = "[Reservation].[StatusDelete]";
            //base.NumberOfRowsAffectedInDelete = -1;

            base.CreateStoredProcedure = "[Customer].[ActionStatusInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Customer].[ActionStatusRead]";
            base.ReadAllStoredProcedure = "[Customer].[ActionStatusReadAll]";
            base.UpdateStoredProcedure = "[Customer].[ActionStatusUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Customer].[ActionStatusDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
        }
        
        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = (Data)data;

            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);

            return dt;
        }
    }

}
