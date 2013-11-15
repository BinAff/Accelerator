using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Customer.Component
{
    public class Dao : BinAff.Core.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Customer.CustomerInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Customer.CustomerRead";
            base.ReadAllStoredProcedure = "Customer.CustomerReadAll";
            base.UpdateStoredProcedure = "Customer.CustomerUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Customer.CustomerDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@InitialId", DbType.Int64, ((Data)this.Data).Initial == null ? 0 : ((Data)this.Data).Initial.Id);
            base.AddInParameter("@FirstName", DbType.String, ((Data)this.Data).FirstName);
            base.AddInParameter("@MiddleName", DbType.String, ((Data)this.Data).MiddleName == null ? String.Empty : ((Data)this.Data).MiddleName);
            base.AddInParameter("@LastName", DbType.String, ((Data)this.Data).LastName == null ? String.Empty : ((Data)this.Data).LastName);
            base.AddInParameter("@Address", DbType.String, ((Data)this.Data).Address);
            base.AddInParameter("@StateId", DbType.Int64, ((Data)this.Data).State.Id);
            base.AddInParameter("@City", DbType.String, ((Data)this.Data).City);
            base.AddInParameter("@Pin", DbType.Int32, ((Data)this.Data).Pin);
            base.AddInParameter("@Email", DbType.String, ((Data)this.Data).Email == null ? String.Empty : ((Data)this.Data).Email);
            base.AddInParameter("@IdentityProofId", DbType.Int32, ((Data)this.Data).IdentityProofType == null ? 0 : ((Data)this.Data).IdentityProofType.Id);
            base.AddInParameter("@IdentityProofName", DbType.String, ((Data)this.Data).IdentityProof == null ? String.Empty : ((Data)this.Data).IdentityProof);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.Initial = Convert.IsDBNull(dr["InitialId"]) ? null : new Configuration.Component.Initial.Data()
            {
                Id = Convert.ToInt64(dr["InitialId"]),
            };
            dt.FirstName = Convert.IsDBNull(dr["FirstName"]) ? String.Empty : Convert.ToString(dr["FirstName"]);
            dt.MiddleName = Convert.IsDBNull(dr["MiddleName"]) ? String.Empty : Convert.ToString(dr["MiddleName"]);
            dt.LastName = Convert.IsDBNull(dr["LastName"]) ? String.Empty : Convert.ToString(dr["LastName"]);
            dt.Address = Convert.IsDBNull(dr["Address"]) ? String.Empty : Convert.ToString(dr["Address"]);
            dt.State = Convert.IsDBNull(dr["StateId"]) ? null : new Configuration.Component.State.Data()
            {
                Id = Convert.ToInt64(dr["StateId"]),
            };
            dt.City = Convert.IsDBNull(dr["City"]) ? String.Empty : Convert.ToString(dr["City"]);
            dt.Pin = Convert.IsDBNull(dr["Pin"]) ? 0 : Convert.ToInt32(dr["Pin"]);
            dt.Email = Convert.IsDBNull(dr["Email"]) ? String.Empty : Convert.ToString(dr["Email"]);
            dt.IdentityProofType = Convert.IsDBNull(dr["IdentityProofId"]) ? null : new Configuration.Component.IdentityProofType.Data()
            {
                Id = Convert.ToInt64(dr["IdentityProofId"]),
            };
            dt.IdentityProof = Convert.IsDBNull(dr["IdentityProofName"]) ? String.Empty : Convert.ToString(dr["IdentityProofName"]);

            return data;
        }

        public override Boolean Create()
        {
            Boolean retValue = base.Create(); //Save own record

            if (retValue)
            {
                base.CreateConnection();

                if (((Data)this.Data).ContactNumberList != null)
                    retValue = this.CreateCustomerContactNumber(((Data)this.Data).ContactNumberList, this.Data.Id);

                base.CloseConnection();
            }

            return retValue;
        }
              
        protected override Boolean ReadAfter()
        {
            Data data = this.Data as Data;
            this.CreateCommand("Customer.CustomerContactNumberRead");
            this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
            DataSet dsContactNumber = this.ExecuteDataSet();
            data.ContactNumberList = CreateContactNumberDataObject(dsContactNumber);
            return true;
        }

        public override Boolean Update()
        {
            Boolean retValue = true;

            base.CreateConnection();

            //delete dependent tables
            retValue = DeleteCustomerContactNumber(this.Data.Id);

            //Insert dependent tables
            if (retValue) retValue = ((Data)this.Data).ContactNumberList == null ? retValue : CreateCustomerContactNumber(((Data)this.Data).ContactNumberList, this.Data.Id);

            base.CloseConnection();

            //Insert Lodge
            if (retValue) retValue = base.Update();

            return retValue;
        }

        public override Boolean Delete()
        {
            base.CreateConnection();
            Boolean isDeletedSuccessfully = this.DeleteCustomerContactNumber(this.Data.Id);
            base.CloseConnection();

            if (isDeletedSuccessfully)
                isDeletedSuccessfully = base.Delete();

            return isDeletedSuccessfully;
        }

        private Boolean CreateCustomerContactNumber(List<ContactNumber.Data> ContactNumberList, Int64 CustomerId)
        {
            Boolean isCreatedSuccessfully = true;
            if (((Data)this.Data).ContactNumberList == null) return false;

            foreach (ContactNumber.Data contactData in ((Data)this.Data).ContactNumberList)
            {
                if (isCreatedSuccessfully)
                {
                    base.CreateCommand("Customer.CustomerContactNumberInsert");
                    base.AddInParameter("@CustomerId", DbType.Int64, CustomerId);
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

        private Boolean DeleteCustomerContactNumber(Int64 CustomerId)
        {
            Boolean isDeletedSuccessfully = true;
            this.CreateCommand("Customer.CustomerContactNumberDelete");
            this.AddInParameter("@Id", DbType.Int64, CustomerId);

            Int32 ret = this.ExecuteNonQuery();
            if (ret == -2146232060) isDeletedSuccessfully = false;//Foreign key violation
            isDeletedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            return isDeletedSuccessfully;
        }

        private List<ContactNumber.Data> CreateContactNumberDataObject(DataSet ds)
        {
            List<ContactNumber.Data> ContactNumberList = new List<ContactNumber.Data>();
            DataRow row;
            ContactNumber.Data data;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    row = ds.Tables[0].Rows[i];
                    data = new ContactNumber.Data()
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        ContactNumber = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"])
                    };

                    ContactNumberList.Add(data);
                }
            }
            return ContactNumberList;
        }

        public List<Int64> ReadDuplicate()
        {
            List<Int64> retIds = new List<Int64>();
            Data data = (Data)this.Data;
            String contactNumberList = String.Empty;
            Int32 len = (data.ContactNumberList != null) ? data.ContactNumberList.Count : 0;
            if (len > 0)
            {
                for (Int32 i = 0; i < len; i++)
                {
                    contactNumberList += data.ContactNumberList[i].ContactNumber;
                    if (i < len - 1) contactNumberList += ",";
                }
            }

            this.CreateConnection();
            this.CreateCommand("Customer.CustomerReadDuplicate");
            this.AddInParameter("@Email", DbType.String, data.Email);
            this.AddInParameter("@IdentityProofId", DbType.Int64, data.IdentityProofType == null ? 0 : data.IdentityProofType.Id);
            this.AddInParameter("@IdentityProofName", DbType.String, data.IdentityProof);
            this.AddInParameter("@ContactNumber", DbType.String, contactNumberList);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(dr["Id"]) && Convert.ToInt64(dr["Id"]) != this.Data.Id) retIds.Add(Convert.ToInt64(dr["Id"]));
                }
            }
            this.CloseConnection();
            return retIds;
        }

        public Boolean IsCustomerExists()
        {
            this.CreateConnection();

            this.CreateCommand("Customer.CustomerCheck");
            this.AddInParameter("@Email", DbType.String, ((Data)this.Data).Email);
            this.AddInParameter("@IdentityProofId", DbType.Int64, ((Data)this.Data).IdentityProofType == null ? 0 : ((Data)this.Data).IdentityProofType.Id);
            this.AddInParameter("@IdentityProofName", DbType.String, ((Data)this.Data).IdentityProof);
            DataSet dsCustomer = this.ExecuteDataSet();

            if (dsCustomer != null && dsCustomer.Tables.Count > 0 && dsCustomer.Tables[0].Rows.Count > 0)
                return true;

            if (((Data)this.Data).ContactNumberList != null && ((Data)this.Data).ContactNumberList.Count > 0)
            {
                foreach (ContactNumber.Data contactData in ((Data)this.Data).ContactNumberList)
                {
                    this.CreateCommand("CustomerContactCheck");
                    this.AddInParameter("@ContactNumber", DbType.String, contactData.ContactNumber);
                    DataSet dsContactNumber = this.ExecuteDataSet();

                    if (dsContactNumber != null && dsContactNumber.Tables.Count > 0 && dsContactNumber.Tables[0].Rows.Count > 0)
                        return true;
                }
            }

            this.CloseConnection();
            return false;
        }

        public List<Data> IsInitialDeletable(Configuration.Component.Initial.Data initial)
        {          
            this.CreateConnection();
            this.CreateCommand("Customer.IsInitialDeletable");
            this.AddInParameter("@InitialId", DbType.Int64, initial.Id);
            DataSet ds = this.ExecuteDataSet();

            List<Data> dataList = GetDataList(ds);

            this.CloseConnection();
            return dataList;
        }

        internal List<Data> IsIdentityProofTypeDeletable(Configuration.Component.IdentityProofType.Data identityProofType)
        {          
            this.CreateConnection();
            this.CreateCommand("Customer.IsIdentityProofIdDeletable");
            this.AddInParameter("@IdentityProofId", DbType.Int64, identityProofType.Id);
            DataSet ds = this.ExecuteDataSet();
            List<Data> dataList = GetDataList(ds);           

            this.CloseConnection();
            return dataList;
        }

        internal List<Data> IsStateDeletable(Configuration.Component.State.Data state)
        {          
            this.CreateConnection();
            this.CreateCommand("Customer.IsStateIdDeletable");
            this.AddInParameter("@StateId", DbType.Int64, state.Id);
            DataSet ds = this.ExecuteDataSet();
            List<Data> dataList = GetDataList(ds);
           
            this.CloseConnection();
            return dataList;
        }

        private List<Data> GetDataList(DataSet ds) {
            List<Data> dataList = new List<Data>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        FirstName = Convert.IsDBNull(row["FirstName"]) ? String.Empty : Convert.ToString(row["FirstName"]),
                        LastName = Convert.IsDBNull(row["LastName"]) ? String.Empty : Convert.ToString(row["LastName"]),
                        ContactNumberList = new List<ContactNumber.Data>
                        { 
                            new ContactNumber.Data
                            {
                                ContactNumber = Convert.IsDBNull(row["ContactNumber"]) ? String.Empty : Convert.ToString(row["ContactNumber"]),
                            }
                        }
                    });
                }
            }
            return dataList;
        }

    }
}
