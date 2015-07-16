using System;
using System.Data;
using System.Collections.Generic;

namespace Retinue.Lodge.Component.Room.Tariff
{

    public class Dao : Crystal.Tariff.Component.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Lodge.TariffInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Lodge.TariffRead";
            base.ReadAllStoredProcedure = "Lodge.TariffReadAll";
            base.UpdateStoredProcedure = "Lodge.TariffUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Lodge.TariffDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@CategoryId", DbType.Int64, ((Data)this.Data).Category.Id);
            base.AddInParameter("@TypeId", DbType.Int64, ((Data)this.Data).Type.Id);
            base.AddInParameter("@IsAC", DbType.Boolean, ((Data)this.Data).IsAC);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            base.CreateDataObject(dr, data);
            Data dt = data as Data;
            dt.Category = Convert.IsDBNull(dr["CategoryId"]) ? null : new Category.Data() { Id = Convert.ToInt64(dr["CategoryId"]) };
            dt.Type = Convert.IsDBNull(dr["TypeId"]) ? null : new Room.Type.Data() { Id = Convert.ToInt64(dr["TypeId"]) };
            dt.IsAC = Convert.IsDBNull(dr["IsAirConditioned"]) ? false : Convert.ToBoolean(dr["IsAirConditioned"]);
            return dt;
        }

        protected override Crystal.Product.Component.Data BindItem(Int64 itemId)
        {
            return new Room.Data
            {
                Id = itemId
            };
        }

        public override List<Crystal.Tariff.Component.Data> IsProductDeletable(BinAff.Core.Data subject)
        {
            List<Crystal.Tariff.Component.Data> dataList = new List<Crystal.Tariff.Component.Data>();
            this.CreateConnection();
            this.CreateCommand("Lodge.IsTariffDeletable");
            this.AddInParameter("@RoomId", DbType.Int64, subject.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        StartDate = Convert.IsDBNull(row["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["StartDate"]),
                        EndDate = Convert.IsDBNull(row["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["EndDate"])
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        //validation is not required for lodge since here tariff is not generated for a product
        internal Boolean ReadDuplicate()
        {
            return false;
        }
       
        internal List<BinAff.Core.Data> GetExistingTariff()
        {
            List<BinAff.Core.Data> retList = new List<BinAff.Core.Data>();
            Data data = this.Data as Data;
            if (data != null)
            {
                this.CreateConnection();
                this.CreateCommand("Lodge.TariffIsExist");
                base.AddInParameter("@CategoryId", DbType.Int64, data.Category.Id);
                base.AddInParameter("@TypeId", DbType.Int64, data.Type.Id);
                base.AddInParameter("@IsAC", DbType.Boolean, data.IsAC);
                base.AddInParameter("@StartDate", DbType.DateTime, data.StartDate);
                base.AddInParameter("@EndDate", DbType.DateTime, data.EndDate);
                base.AddInParameter("@IsExtra", DbType.Boolean, data.IsExtra);
                DataSet ds = this.ExecuteDataSet();
                retList = (ds != null && ds.Tables[0].Rows.Count > 0) ? (List<BinAff.Core.Data>)CreateDataObjectList(ds) : null;
                this.CloseConnection();
            }
            return retList;
        }

        internal List<BinAff.Core.Data> ReadAllCurrentTariff()
        {
            this.CreateConnection();
            this.CreateCommand("Lodge.TariffReadAllCurrent");

            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> dataList = CreateDataObjectList(ds);
            this.CloseConnection();

            return dataList;
        }

        internal List<BinAff.Core.Data> ReadAllFutureTariff()
        {
            this.CreateConnection();
            this.CreateCommand("Lodge.TariffReadAllFuture");
            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> dataList = CreateDataObjectList(ds);
            this.CloseConnection();

            return dataList;
        }

    }

}