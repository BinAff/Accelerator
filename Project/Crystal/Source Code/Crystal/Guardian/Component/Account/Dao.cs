using System;
using System.Data;
using System.Collections.Generic;

namespace Crystal.Guardian.Component.Account
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Guardian.AccountInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Guardian.AccountRead";
            base.ReadAllStoredProcedure = "Guardian.AccountReadAll";
            base.UpdateStoredProcedure = "Guardian.AccountUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Guardian.AccountDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@LoginId", DbType.String, ((Data)this.Data).LoginId);
            base.AddInParameter("@Password", DbType.String, ((Data)this.Data).Password);
            //base.AddInParameter("@RoleId", DbType.Int32, ((Data)this.Data).Roles[0].Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) //First table is for User
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                    dt.LoginId = Convert.IsDBNull(row["LoginId"]) ? String.Empty : Convert.ToString(row["LoginId"]);
                    dt.Password = Convert.IsDBNull(row["Password"]) ? String.Empty : Convert.ToString(row["Password"]);
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0) //Second table is for Role
                {
                    dt.RoleList = new List<BinAff.Core.Data>();
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        dt.RoleList.Add(new Role.Data
                        {
                            Id = Convert.IsDBNull(row["RoleId"]) ? 0 : Convert.ToInt64(row["RoleId"])
                        });
                    }
                }
            }
            return dt;
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();
            Boolean IsRoleExist = false;

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables.Count == 2) IsRoleExist = true;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Data data = new Data();
                    //TO DO :: Need to add user
                    data.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                    data.LoginId = Convert.IsDBNull(row["LoginId"]) ? String.Empty : Convert.ToString(row["LoginId"]);
                    data.Password = Convert.IsDBNull(row["Password"]) ? String.Empty : Convert.ToString(row["Password"]);
                    if (IsRoleExist) //Second table is for Role
                    {
                        data.RoleList = new List<BinAff.Core.Data>();
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            if ((Convert.IsDBNull(dr["UserId"]) ? 0 : Convert.ToInt64(dr["UserId"])) == data.Id)
                            {
                                data.RoleList.Add(new Role.Data
                                {
                                    Id = Convert.IsDBNull(dr["RoleId"]) ? 0 : Convert.ToInt64(dr["RoleId"])
                                });
                            }
                        }
                        if (data.RoleList.Count == 0) data.RoleList = null; //If there is no role attached, nullify
                    }
                    ret.Add(data);
                }
            }
            return ret;
        }

        /// <summary>
        /// Abstract method to override in child for Reading
        /// </summary>
        /// <returns></returns>
        public List<BinAff.Core.Data> ReadAll(String ReadStoredProcedure)
        {   
            base.CreateConnection();
            base.CreateCommand(ReadStoredProcedure);            

            DataSet ds = this.ExecuteDataSet();
            BinAff.Core.Data dt;
            Data data;
            List<BinAff.Core.Data> lstData = new List<BinAff.Core.Data>();
            if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dt = this.CreateDataObject(ds, this.Data);
                    data = new Account.Data()
                    {
                        Id = dt.Id,
                        LoginId = ((Data)dt).LoginId,
                        Password = ((Data)dt).Password,
                    };
                    lstData.Add(data);         
                }
            }
            
            this.CloseConnection();            
            return lstData;
        }

        public Boolean ChangePassword()
        {
            base.CreateConnection();
            base.CreateCommand("UserResetPassword");
            base.AddInParameter("@Id", DbType.Int64, this.Data.Id);
            base.AddInParameter("@Password", DbType.String, ((Data)this.Data).Password);

            Int32 i = this.ExecuteNonQuery();
            this.CloseConnection();

            return i == 1 ? true : false; //Return if affected rows are 1
        }

        public Boolean ChangeRoles()
        {         
            return this.UpdateUserRoles(((Data)this.Data).RoleList, this.Data.Id);
        }

        ///// <summary>
        ///// Abstract method to override in child for Reading
        ///// </summary>
        ///// <returns></returns>
        //public BinAff.Core.ReturnObject<Data> GetUser(String ReadStoredProcedure)
        //{
        //    BinAff.Core.ReturnObject<Data> retVal = new BinAff.Core.ReturnObject<Data>();
        //    try
        //    {
        //        this.CreateConnection();
        //        this.CreateCommand(ReadStoredProcedure);
        //        this.AssignParameter(ReadStoredProcedure);
        //        DataSet ds = this.ExecuteDataSet();


        //        BinAff.Core.Data dt;
        //        Data data;

        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            dt = this.CreateDataObject(ds, this.Data);
        //            data = new User.Data()
        //            {
        //                Id = dt.Id,
        //                LoginId = ((Data)dt).LoginId,
        //                Password = ((Data)dt).Password,
        //            };
        //            retVal.Value = data;
        //        }
        //        this.CloseConnection();            
        //    }
        //    catch(Exception ex){
        //        BinAff.Utility.Logger.Log(ex.Message, ex.StackTrace, "Crystal User management");
        //    }
            
        //    return retVal;
        //}

        public Data GetUserByLoginId()
        {
            this.CreateConnection();
            this.CreateCommand("Guardian.SearchUserByLoginId");
            this.AddInParameter("@LoginId", DbType.String, ((Data)this.Data).LoginId);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.CreateDataObject(ds, this.Data);
            }
            this.CloseConnection();

            return this.Data as Data;
        }

        ///// <summary>
        ///// Read User
        ///// </summary>
        ///// <remarks>
        ///// Since Role is independent children of User, it will be handled here
        ///// </remarks>
        ///// <returns></returns>
        //public override BinAff.Core.Data Read()
        //{
        //    if (this.ReadStoredProcedure == null) throw new Exception("Read stored procedure not specified");
        //    this.CreateConnection();
        //    this.CreateCommand(this.ReadStoredProcedure);
        //    this.AddInParameter("@Id", DbType.Int64, this.Data.Id);

        //    DataSet ds = this.ExecuteDataSet();
        //    this.Data = CreateDataObject(ds, this.Data);
        //    this.CloseConnection();
        //    return this.Data;
        //}

        /// <summary>
        /// Create User
        /// </summary>
        /// <remarks>
        /// Since Role is independent children of User, it will be handled here
        /// </remarks>
        /// <returns></returns>
        protected override Boolean CreateAfter()
        {
            Boolean retVal = false;
            base.CreateConnection();
            if ((this.Data as Data).RoleList != null && (this.Data as Data).RoleList.Count > 0)
            {
                retVal = this.CreateUserRoles(((Data)this.Data).RoleList, this.Data.Id);
            }
            base.CloseConnection();
            return retVal;
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <remarks>
        /// Since Role is independent children of User, it will be handled here
        /// </remarks>
        /// <returns></returns>
        protected override Boolean UpdateAfter()
        {
            Boolean retVal = false;
            base.CreateConnection();
            if (((Data)this.Data).RoleList != null)
            {
                retVal = this.UpdateUserRoles(((Data)this.Data).RoleList, this.Data.Id);
            }
            base.CloseConnection();
            return retVal;
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <remarks>
        /// Since Role is independent children of User, it will be handled here
        /// </remarks>
        /// <returns></returns>
        protected override Boolean DeleteBefore()
        {
            return this.DeleteUserRoles(this.Data.Id);
        }

        private Boolean CreateUserRoles(List<BinAff.Core.Data> roleList,Int64 userId)
        {
            Boolean isCreatedSuccessfully = true;
            Int64 userRoleId;
            foreach (BinAff.Core.Data roleData in roleList)
            {
                if (isCreatedSuccessfully)
                {
                    userRoleId = 0;
                    base.CreateCommand("Guardian.UserRoleInsert");
                    base.AddInParameter("@UserId", DbType.Int64, userId);
                    base.AddInParameter("@RoleId", DbType.Int64, roleData.Id);
                    base.AddOutParameter("@Id", DbType.Int64, userRoleId);
                    Int32 ret = base.ExecuteNonQuery();
                    if (ret == -2146232060) isCreatedSuccessfully = false; //Foreign key violation                  
                }
            }

            return isCreatedSuccessfully;        
        }

        private Boolean UpdateUserRoles(List<BinAff.Core.Data> roleList, Int64 userId)
        {
            Boolean retVal = this.DeleteUserRoles(userId);
            if (retVal)
            {
                base.CreateConnection();
                if (((Data)this.Data).RoleList != null)
                {
                    retVal = this.CreateUserRoles(roleList, userId);
                }
                base.CloseConnection();
            }
            return retVal;
        }

        private Boolean DeleteUserRoles(Int64 userId)
        {
            Boolean isDeletedSuccessfully = true;

            base.CreateConnection();
            base.CreateCommand("UserRoleDelete");
            base.AddInParameter("@UserId", DbType.Int64, userId);           
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) isDeletedSuccessfully = false; //Foreign key violation                  
            base.CloseConnection();

            return isDeletedSuccessfully;
        }

        private Boolean DeleteUserContactNumber(Int64 userId)
        {
            Boolean isDeletedSuccessfully = true;
            base.CreateConnection();
            base.CreateCommand("UserContactNumberDelete");
            base.AddInParameter("@UserId", DbType.Int64, userId);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) isDeletedSuccessfully = false; //Foreign key violation   
            base.CloseConnection();
            return isDeletedSuccessfully;
        }

        private Boolean CreateUserContactNumber(List<Profile.ContactNumber.Data> contactNumberList, Int64 userId)
        {
            Boolean isCreatedSuccessfully = true;
            Int64 userRoleId = 0;
            base.CreateConnection();

            foreach (Profile.ContactNumber.Data data in contactNumberList)
            {
                if (isCreatedSuccessfully)
                {
                    userRoleId = 0;
                    base.CreateCommand("UserContactNumberInsert");
                    base.AddInParameter("@UserId", DbType.Int64, userId);
                    base.AddInParameter("@ContactNumber", DbType.String, data.ContactNumber);
                    base.AddOutParameter("@Id", DbType.Int64, userRoleId);
                    Int32 ret = base.ExecuteNonQuery();
                    if (ret == -2146232060) isCreatedSuccessfully = false; //Foreign key violation                  
                }
            }

            base.CloseConnection();
            return isCreatedSuccessfully;
        }

    }

}
