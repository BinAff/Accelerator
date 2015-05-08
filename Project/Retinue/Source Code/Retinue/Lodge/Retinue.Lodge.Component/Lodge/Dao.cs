using System;
using System.Data;
using System.Collections.Generic;
using State = Crystal.Configuration.Component.State;

namespace Retinue.Lodge.Component.Lodge
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "LodgeInsert";
            base.NumberOfRowsAffectedInCreate = 1;             
            base.ReadStoredProcedure = "LodgeRead";
            base.ReadAllStoredProcedure = "LodgeReadAll";
            base.UpdateStoredProcedure = "LodgeUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "LodgeDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
            base.AddInParameter("@Logo", DbType.Binary, (object)(((Data)this.Data).Logo));
            base.AddInParameter("@LicenceNumber", DbType.String, ((Data)this.Data).LicenceNumber);
            base.AddInParameter("@Tan", DbType.String, ((Data)this.Data).Tan);
            base.AddInParameter("@Address", DbType.String, ((Data)this.Data).Address);
            base.AddInParameter("@City", DbType.String, ((Data)this.Data).City);
            base.AddInParameter("@StateId", DbType.String, ((Data)this.Data).State.Id);
            base.AddInParameter("@Pin", DbType.Int32, ((Data)this.Data).Pin);
            base.AddInParameter("@ContactName", DbType.String, ((Data)this.Data).ContactName);
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
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Logo = Convert.IsDBNull(row["Logo"]) ? null : (Byte[])row["Logo"],
                        LicenceNumber = Convert.IsDBNull(row["LicenceNumber"]) ? String.Empty : Convert.ToString(row["LicenceNumber"]),
                        Tan = Convert.IsDBNull(row["Tan"]) ? String.Empty : Convert.ToString(row["Tan"]),
                        Address = Convert.IsDBNull(row["Address"]) ? String.Empty : Convert.ToString(row["Address"]),
                        City = Convert.IsDBNull(row["City"]) ? String.Empty : Convert.ToString(row["City"]),
                        State = new State.Data(){
                            Id = Convert.IsDBNull(row["StateId"]) ? 0 : Convert.ToInt64(row["StateId"]),
                        },
                        Pin = Convert.IsDBNull(row["Pin"]) ? 0 : Convert.ToInt32(row["Pin"]),
                        ContactName = Convert.IsDBNull(row["ContactName"]) ? String.Empty : Convert.ToString(row["ContactName"]),
                    });
                }
            }
            return ret;
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];                
                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]);
                dt.Logo = Convert.IsDBNull(row["Logo"]) ? null : (Byte[])row["Logo"];
                dt.LicenceNumber = Convert.IsDBNull(row["LicenceNumber"]) ? String.Empty : Convert.ToString(row["LicenceNumber"]);
                dt.Tan = Convert.IsDBNull(row["Tan"]) ? String.Empty : Convert.ToString(row["Tan"]);
                dt.Address = Convert.IsDBNull(row["Address"]) ? String.Empty : Convert.ToString(row["Address"]);
                dt.City = Convert.IsDBNull(row["City"]) ? String.Empty : Convert.ToString(row["City"]);
                dt.State = Convert.IsDBNull(row["StateId"]) ? null : new State.Data
                {
                    Id = Convert.ToInt64(row["StateId"])
                };
                dt.Pin = Convert.IsDBNull(row["Pin"]) ? 0 : Convert.ToInt32(row["Pin"]);
                dt.ContactName = Convert.IsDBNull(row["ContactName"]) ? String.Empty : Convert.ToString(row["ContactName"]);
            }
            return dt;
        }        

        public override bool Create()
        {
            Boolean retValue = base.Create(); //Save own record

            if (retValue)
            {
                base.CreateConnection();

                retValue = this.CreateLodgeContactNumber(((Data)this.Data).ContactNumberList, this.Data.Id);
                if (((Data)this.Data).EmailList != null)
                {
                    if (retValue) retValue = this.CreateLodgeEmail(((Data)this.Data).EmailList, this.Data.Id);
                }
                if(((Data)this.Data).FaxList != null)
                {
                    if (retValue) retValue = this.CreateLodgeFax(((Data)this.Data).FaxList, this.Data.Id);
                }

                base.CloseConnection();
            }

            return retValue;
        }

        public override BinAff.Core.Data Read()
        {
            Data data = (Data)base.Read();
            if (data.Id > 0)
            {
                this.CreateConnection();

                this.CreateCommand("LodgeContactNumberRead");
                this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
                DataSet dsContactNumber = this.ExecuteDataSet();
                data.ContactNumberList = CreateContactNumberDataObject(dsContactNumber);

                this.CreateCommand("LodgeEmailRead");
                this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
                DataSet dsEmail = this.ExecuteDataSet();
                data.EmailList = CreateEmailDataObject(dsEmail);

                this.CreateCommand("LodgeFaxRead");
                this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
                DataSet dsFax = this.ExecuteDataSet();
                data.FaxList = CreateFaxDataObject(dsFax);


                this.CloseConnection();
            }
            return data;
        }

        public override Boolean Update()
        {
            Boolean retValue = true;

            base.CreateConnection();

            //delete dependent tables
            retValue = DeleteLodgeContactNumber(this.Data.Id);
            if (retValue) retValue = DeleteLodgeEmail(this.Data.Id);
            if (retValue) retValue = DeleteLodgeFax(this.Data.Id);

            //Insert dependent tables
            if (retValue) retValue = ((Data)this.Data).ContactNumberList == null ? retValue : CreateLodgeContactNumber(((Data)this.Data).ContactNumberList, this.Data.Id);
            if (retValue) retValue = ((Data)this.Data).EmailList == null ? retValue : CreateLodgeEmail(((Data)this.Data).EmailList, this.Data.Id);
            if (retValue) retValue = ((Data)this.Data).FaxList == null ? retValue : CreateLodgeFax(((Data)this.Data).FaxList, this.Data.Id);

            base.CloseConnection();

            //Insert Lodge
            if (retValue) retValue = base.Update();

            return retValue;
        }

        public override Boolean Delete()
        {
            base.CreateConnection();
            Boolean isDeletedSuccessfully = this.DeleteLodgeContactNumber(this.Data.Id);
            if (isDeletedSuccessfully) isDeletedSuccessfully = this.DeleteLodgeEmail(this.Data.Id);
            if (isDeletedSuccessfully) isDeletedSuccessfully = this.DeleteLodgeFax(this.Data.Id);
            base.CloseConnection();

            if (isDeletedSuccessfully)
                isDeletedSuccessfully = base.Delete();

            return isDeletedSuccessfully;
        }

        private Boolean CreateLodgeContactNumber(List<ContactNumberData> ContactNumberList, Int64 lodgeId)
        {
            Boolean isCreatedSuccessfully = true;
            if (((Data)this.Data).ContactNumberList == null) return false;

            foreach (ContactNumberData contactData in ((Data)this.Data).ContactNumberList)
            {
                if (isCreatedSuccessfully)
                {
                    base.CreateCommand("LodgeContactNumberInsert");
                    base.AddInParameter("@LodgeId", DbType.Int64, lodgeId);
                    base.AddInParameter("@ContactNumber", DbType.String, contactData.ContactNumber);
                    base.AddOutParameter("@Id", DbType.Int64, contactData.Id);
                    Int32 ret = base.ExecuteNonQuery();
                    if (ret == -2146232060) isCreatedSuccessfully = false; //Foreign key violation
                    if (isCreatedSuccessfully)
                        isCreatedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
                }
            }

            return isCreatedSuccessfully;
        }

        private Boolean CreateLodgeEmail(List<EmailData> EmailList, Int64 lodgeId)
        {
            Boolean isCreatedSuccessfully = true;
            if (((Data)this.Data).EmailList == null) return false;
            foreach (EmailData emailData in ((Data)this.Data).EmailList)
            {
                if (isCreatedSuccessfully)
                {
                    base.CreateCommand("LodgeEmailInsert");
                    base.AddInParameter("@LodgeId", DbType.Int64, lodgeId);
                    base.AddInParameter("@Email", DbType.String, emailData.Email);
                    base.AddOutParameter("@Id", DbType.Int64, emailData.Id);
                    Int32 ret = base.ExecuteNonQuery();
                    if (ret == -2146232060) isCreatedSuccessfully = false;//Foreign key violation
                    if (isCreatedSuccessfully)
                        isCreatedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
                }
            }
            return isCreatedSuccessfully;
        }

        private Boolean CreateLodgeFax(List<FaxData> FaxList, Int64 lodgeId)
        {
            Boolean isCreatedSuccessfully = true;
            if (((Data)this.Data).FaxList == null) return false;
            foreach (FaxData faxData in ((Data)this.Data).FaxList)
            {
                base.CreateCommand("LodgeFaxInsert");
                base.AddInParameter("@LodgeId", DbType.Int64, lodgeId);
                base.AddInParameter("@Fax", DbType.String, faxData.Fax);
                base.AddOutParameter("@Id", DbType.Int64, faxData.Id);
                Int32 ret = base.ExecuteNonQuery();
                if (ret == -2146232060) isCreatedSuccessfully = false;//Foreign key violation
                if (isCreatedSuccessfully)
                    isCreatedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
            }

            return isCreatedSuccessfully;
        }

        private Boolean DeleteLodgeContactNumber(Int64 lodgeId)
        {
            Boolean isDeletedSuccessfully = true;
            this.CreateCommand("LodgeContactNumberDelete");
            this.AddInParameter("@Id", DbType.Int64, lodgeId);

            Int32 ret = this.ExecuteNonQuery();
            if (ret == -2146232060) isDeletedSuccessfully = false;//Foreign key violation
            isDeletedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            return isDeletedSuccessfully;
        }

        private Boolean DeleteLodgeEmail(Int64 lodgeId)
        {
            Boolean isDeletedSuccessfully = true;
            this.CreateCommand("LodgeEmailDelete");
            this.AddInParameter("@Id", DbType.Int64, lodgeId);

            Int32 ret = this.ExecuteNonQuery();
            if (ret == -2146232060) isDeletedSuccessfully = false;//Foreign key violation
            isDeletedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            return isDeletedSuccessfully;
        }

        private Boolean DeleteLodgeFax(Int64 lodgeId)
        {
            Boolean isDeletedSuccessfully = true;
            this.CreateCommand("LodgeFaxDelete");
            this.AddInParameter("@Id", DbType.Int64, lodgeId);

            Int32 ret = this.ExecuteNonQuery();
            if (ret == -2146232060) isDeletedSuccessfully = false;//Foreign key violation
            isDeletedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            return isDeletedSuccessfully;
        }

        private List<ContactNumberData> CreateContactNumberDataObject(DataSet ds)
        {
            List<ContactNumberData> ContactNumberList = new List<ContactNumberData>();
            DataRow row;
            ContactNumberData data;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    row = ds.Tables[0].Rows[i];
                    data = new ContactNumberData()
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        ContactNumber = Convert.IsDBNull(row["ContactNumber"]) ? String.Empty : Convert.ToString(row["ContactNumber"])
                    };

                    ContactNumberList.Add(data);
                }
            }
            return ContactNumberList;
        }

        private List<EmailData> CreateEmailDataObject(DataSet ds)
        {
            List<EmailData> EmailList = new List<EmailData>();
            DataRow row;
            EmailData data;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    row = ds.Tables[0].Rows[i];
                    data = new EmailData()
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Email = Convert.IsDBNull(row["Email"]) ? String.Empty : Convert.ToString(row["Email"])
                    };

                    EmailList.Add(data);
                }
            }
            return EmailList;
        }

        private List<FaxData> CreateFaxDataObject(DataSet ds)
        {
            List<FaxData> FaxList = new List<FaxData>();
            DataRow row;
            FaxData data;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    row = ds.Tables[0].Rows[i];
                    data = new FaxData()
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Fax = Convert.IsDBNull(row["Fax"]) ? String.Empty : Convert.ToString(row["Fax"])
                    };

                    FaxList.Add(data);
                }
            }
            return FaxList;
        }

        /// <summary>
        /// Check if state exists in Lodge defination
        /// </summary>
        /// <param name="state">State data to be found in customer</param>
        /// <returns></returns>
        internal List<Data> IsStateDeletable(State.Data state)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("LodgeIsStateIdDeletable");
            this.AddInParameter("@StateId", DbType.Int64, state.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"])
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }


    }

}
