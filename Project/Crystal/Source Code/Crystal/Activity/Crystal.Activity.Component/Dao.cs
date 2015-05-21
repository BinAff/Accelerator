using System;
using System.Data;

namespace Crystal.Activity.Component
{

    public abstract class Dao : Crystal.Customer.Component.Action.Dao
    {

        protected String UpdateComplitionStoredProcedure { get; set; }

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@ActivityDate", DbType.DateTime, (this.Data as Data).ActivityDate);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            if (Convert.IsDBNull(dr["CompletionTime"]))
            {
                dt.CompletionTime = null;
            }
            else
            {
                dt.CompletionTime = Convert.ToDateTime(dr["CompletionTime"]);
            }

            return dt;
        }

        public virtual Boolean UpdateComplition()
        {
            if (this.UpdateComplitionStoredProcedure == null) throw new Exception("Update complition stored procedure not specified");

            base.CreateConnection();
            base.CreateCommand(this.UpdateComplitionStoredProcedure);
            base.AddInParameter("@ProductId", DbType.Int64, this.Data.Id);
            base.AddInParameter("@StatusId", DbType.Int64, (this.Data as Data).Status.Id);
            base.AddOutParameter("@CompletionTime", DbType.DateTime, (this.Data as Data).CompletionTime);
            Int32 i = this.ExecuteNonQuery();
            (this.Data as Data).CompletionTime = Convert.ToDateTime(this.GetValueFromParameter("@CompletionTime"));
            this.CloseConnection();
            return i != -2146232060;
        }

    }

}