using System;
using System.Data;
using System.Collections.Generic;

namespace Crystal.Guardian.Component.Account.Profile
{

    /// <summary>
    /// Data access class of User Profile 
    /// </summary>
    /// <remarks>
    /// Profile is depended on User component
    /// </remarks>
    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Guardian.ProfileInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Guardian.ProfileRead";
            base.ReadForParentStoredProcedure = "Guardian.ProfileRead";
            base.UpdateStoredProcedure = "Guardian.ProfileUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Guardian.ProfileDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);

            base.AddInParameter("@UserId", DbType.Int64, ((Data)this.Data).UserId);
            base.AddInParameter("@Initial", DbType.Int64, ((Data)this.Data).Initial.Id);
            base.AddInParameter("@FirstName", DbType.String, ((Data)this.Data).FirstName);
            base.AddInParameter("@MiddleName", DbType.String, ((Data)this.Data).MiddleName);
            base.AddInParameter("@LastName", DbType.String, ((Data)this.Data).LastName);       
            base.AddInParameter("@Dob", DbType.Date, Convert.ToDateTime(((Data)this.Data).DateOfBirth));            
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                
                dt.Id = this.ParentData.Id;
                dt.UserId = dt.Id;

                if (!Convert.IsDBNull(row["Initial"]))
                {
                    dt.Initial = new Configuration.Component.Initial.Data
                    {
                        Id = Convert.ToInt32(row["Initial"])
                    };
                }
                dt.FirstName = Convert.IsDBNull(row["FirstName"]) ? String.Empty : Convert.ToString(row["FirstName"]);
                dt.MiddleName = Convert.IsDBNull(row["MiddleName"]) ? String.Empty : Convert.ToString(row["MiddleName"]);
                dt.LastName = Convert.IsDBNull(row["LastName"]) ? String.Empty : Convert.ToString(row["LastName"]);
                if (Convert.IsDBNull(row["Dob"]))
                {
                    dt.DateOfBirth = null;
                }
                else
                {
                    dt.DateOfBirth = Convert.ToDateTime(row["Dob"]);
                }
            }
            this.Data = dt;
            return dt;
        }

        public override BinAff.Core.Data ReadForParent()
        {
            //This is the special case. Here Profile is weak entity. So this function
            //is overriden.
            if (this.ReadForParentStoredProcedure == null) throw new Exception("Read for parent stored procedure not specified");
            this.CreateConnection();
            this.CreateCommand(this.ReadForParentStoredProcedure);
            this.AddInParameter("Id", DbType.Int64, this.ParentData.Id);

            DataSet ds = this.ExecuteDataSet();
            this.Data = CreateDataObject(ds, this.Data);
            this.CloseConnection();
            this.Data.Id = this.ParentData.Id;
            this.AttachChildDataToParent();
            return this.Data;
        }

        protected override void AttachChildDataToParent()
        {
            ((Account.Data)this.ParentData).Profile = (Data)this.Data;
        }

        /// <summary>
        /// Check if initial exists in any of Profile or not
        /// </summary>
        /// <param name="initial">Initial data to be found in customer</param>
        /// <returns></returns>
        public List<Data> IsInitialDeletable(Configuration.Component.Initial.Data initial)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("ProfileIsInitialDeletable");
            this.AddInParameter("@InitialId", DbType.Int64, initial.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        FirstName = Convert.IsDBNull(row["FirstName"]) ? String.Empty : Convert.ToString(row["FirstName"]),
                        LastName = Convert.IsDBNull(row["LastName"]) ? String.Empty : Convert.ToString(row["LastName"])
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }


    }

}
