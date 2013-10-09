using System;
using System.Collections.Generic;
using System.Data;

using Cust = Crystal.Customer.Component;

namespace Crystal.Navigator.Form.Customer
{

    public class Dao : Crystal.Navigator.Component.Form.Dao
    {

        public Dao(Data data) 
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Navigator.CustomerFormInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Navigator.CustomerFormRead";
            base.ReadAllStoredProcedure = "Navigator.CustomerFormReadAll";
            base.UpdateStoredProcedure = "Navigator.CustomerFormUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Navigator.CustomerFormDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override BinAff.Core.Data InstantiateModuleDataObject()
        {
            return new Cust.Data();
        }

        //protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        //{
        //    Data dt = data as Data;
        //    DataRow row;
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        row = ds.Tables[0].Rows[0];

        //        dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
        //        dt.ModuleData = new Cust.Data
        //        {
        //            Id = Convert.IsDBNull(row["CustomerId"]) ? 0 : Convert.ToInt64(row["CustomerId"]),
        //        };
        //    }
        //    return dt;
        //}

        //protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        //{
        //    List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            ret.Add(new Data
        //            {
        //                Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
        //                ModuleData = new Cust.Data
        //                {
        //                    Id = Convert.IsDBNull(row["CustomerId"]) ? 0 : Convert.ToInt64(row["CustomerId"]),
        //                },
        //            });
        //        }
        //    }
        //    return ret;
        //}
       
    }

}
