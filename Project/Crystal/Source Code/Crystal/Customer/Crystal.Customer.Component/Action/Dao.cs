using System;
using System.Collections.Generic;
using System.Data;
using BinAff.Core;

namespace Crystal.Customer.Component.Action
{

    public abstract class Dao : BinAff.Core.Dao
    {

        protected String SearchStoredProcedure { get; set; }

        protected String UpdateStatusStoredProcedure { get; set; }

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@StatusId", DbType.Int64, (this.Data as Data).Status.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.Status = Convert.IsDBNull(dr["StatusId"]) ? null : new Action.Status.Data() { Id = Convert.ToInt64(dr["StatusId"]) };

            return dt;
        }

        public List<Data> Search(Status.Data status, System.DateTime startDate, System.DateTime endDate)
        {
            if (this.SearchStoredProcedure == null) throw new Exception("Search stored procedure not specified");
            ReturnObject<List<Action.Data>> retVal = new ReturnObject<List<Action.Data>>();

            List<Action.Data> dataList = new List<Action.Data>();
            this.CreateConnection();
            this.CreateCommand(this.SearchStoredProcedure);
            this.AddInParameter("@StartDate", DbType.DateTime, startDate);
            this.AddInParameter("@EndDate", DbType.DateTime, endDate);
            this.AddInParameter("@StatusId", DbType.Int64, status.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Int64 tempId = -1;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Int64 reservationId = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                    Data data;
                    if (tempId != reservationId)
                    {
                        data = this.CreateDataObject(row, this.CreateDataObjectInstance()) as Data;
                        data.ProductList = new List<BinAff.Core.Data>();
                    }
                    else
                    {
                        data = dataList.Find((p) => { return p.Id == reservationId; });
                    }
                    data.ProductList.Add(Createproduct(Convert.IsDBNull(row["ProductId"]) ? 0 : Convert.ToInt64(row["ProductId"])));
                    if (tempId != reservationId)
                    {
                        dataList.Add(data);
                    }
                    tempId = reservationId;
                }
            }

            this.CloseConnection();

            return dataList;
        }

        public virtual Boolean UpdateStatus()
        {
            if (this.UpdateStatusStoredProcedure == null) throw new Exception("Update status stored procedure not specified");

            List<Action.Data> dataList = new List<Action.Data>();
            this.CreateConnection();
            this.CreateCommand(this.UpdateStatusStoredProcedure);
            this.AddInParameter("@ProductId", DbType.Int64, this.Data.Id);
            this.AddInParameter("@StatusId", DbType.Int64, (this.Data as Data).Status.Id);
            Int32 i = this.ExecuteNonQuery();
            this.CloseConnection();
            return i != -2146232060;
        }

        public abstract Data CreateDataObjectInstance();

        protected abstract Product.Component.Data Createproduct(Int64 productId);

        public abstract List<Action.Data> IsProductDeletable(BinAff.Core.Data subject);

    }

}
