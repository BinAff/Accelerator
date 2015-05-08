﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Organization.Component.Unit.Status
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Organization.UnitStatusInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Organization.UnitStatusRead";
            base.ReadAllStoredProcedure = "Organization.UnitStatusReadAll";
            base.UpdateStoredProcedure = "Organization.UnitStatusUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Organization.UnitStatusDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Name", System.Data.DbType.String, ((Data)this.Data).Name);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            if (dr != null)
            {
                dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
                dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);
            }
            return dt;
        }

    }

}
