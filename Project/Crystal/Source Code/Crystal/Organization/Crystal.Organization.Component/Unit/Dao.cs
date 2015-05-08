using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Crystal.Organization.Component.Unit
{

    public abstract class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@Name", DbType.String, (this.Data as Data).Name);
            base.AddInParameter("@TypeId", DbType.Int32, (this.Data as Data).Type.Id);
            base.AddInParameter("@StatusId", DbType.Int32, (this.Data as Data).Status == null ? 0 : (this.Data as Data).Status.Id);
            //base.AddInParameter("@OrganizationId", DbType.Int32, (this.Data as Data).Organization.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);
            dt.Type = new Type.Data()
            {
                Id = Convert.IsDBNull(dr["TypeId"]) ? 0 : Convert.ToInt64(dr["TypeId"])
            };
            dt.Status = new Status.Data()
            {
                Id = Convert.IsDBNull(dr["StatusId"]) ? 0 : Convert.ToInt64(dr["StatusId"])
            };
            //dt.Organization = new Organization.Component.Data()
            //{
            //    Id = Convert.IsDBNull(dr["OrganizationId"]) ? 0 : Convert.ToInt64(dr["OrganizationId"])
            //};
            return dt;
        }

        public virtual List<Data> IsStatusDeletable(Status.Data status)
        {
            throw new NotImplementedException();
        }

        public virtual List<Data> IsTypeDeletable(Type.Data type)
        {
            throw new NotImplementedException();
        }

        public virtual List<Data> IsOrganizationDeletable(Crystal.Organization.Component.Data organization)
        {
            throw new NotImplementedException();
        }

        public virtual Boolean ModifyStatus(Int64 StatusId)
        {
            throw new NotImplementedException();
        }

    }

}
