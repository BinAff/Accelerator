using System;
using System.Data;
using System.Collections.Generic;

using GenTariff = Crystal.Tariff.Component;

namespace Retinue.Lodge.Component.Room.Tariff
{
    public class Dao : GenTariff.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Lodge.RoomTariffInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Lodge.RoomTariffRead";
            base.ReadAllStoredProcedure = "Lodge.RoomTariffReadAll";
            base.UpdateStoredProcedure = "Lodge.RoomTariffUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Lodge.RoomTariffDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@CategoryId", DbType.Int64, ((Data)this.Data).category.Id);
            base.AddInParameter("@TypeId", DbType.Int64, ((Data)this.Data).type.Id);
            base.AddInParameter("@IsAC", DbType.Boolean, ((Data)this.Data).isAC);           
        }

        protected override Crystal.Product.Component.Data BindItem(Int64 itemId)
        {
            return new Room.Data
            {
                Id = itemId
            };
        }

        protected override GenTariff.Data CreateDataObject()
        {
            return new Data();
        }

        public Boolean ModifyForCategoryAndType(Category.Data category, Type.Data type, double rate)
        {
            Boolean retVal = true;      

            base.CreateConnection();
            this.CreateCommand("Lodge.RoomTariffModifyRate");
            this.AddInParameter("@CategoryId", DbType.Int64, category.Id);
            this.AddInParameter("@TypeId", DbType.Int64, type.Id);
            this.AddInParameter("@Rate", DbType.Double, rate);
            Int32 ret = this.ExecuteNonQuery();
            base.CloseConnection();

            if (ret == -2146232060)
                retVal = false;//Foreign key violation
            else
                retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            return retVal;
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
                base.AddInParameter("@CategoryId", DbType.Int64, data.category.Id);
                base.AddInParameter("@TypeId", DbType.Int64, data.type.Id);
                base.AddInParameter("@IsAC", DbType.Boolean, data.isAC);
                base.AddInParameter("@StartDate", DbType.DateTime, data.StartDate);
                base.AddInParameter("@EndDate", DbType.DateTime, data.EndDate);
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
                        StartDate = Convert.IsDBNull(row["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["StartDate"]),
                        EndDate = Convert.IsDBNull(row["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["EndDate"]),
                        Rate = Convert.IsDBNull(row["Rate"]) ? 0 : Convert.ToDouble(row["Rate"]),
                        category = Convert.IsDBNull(row["CategoryId"]) ? null : new Category.Data() { Id = Convert.ToInt64(row["CategoryId"]) },
                        type = Convert.IsDBNull(row["TypeId"]) ? null : new Room.Type.Data() { Id = Convert.ToInt64(row["TypeId"]) },
                        isAC = Convert.IsDBNull(row["IsAirConditioned"]) ? false : Convert.ToBoolean(row["IsAirConditioned"])                     
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
                dt.StartDate = Convert.IsDBNull(row["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["StartDate"]);
                dt.EndDate = Convert.IsDBNull(row["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["EndDate"]);
                dt.Rate = Convert.IsDBNull(row["Rate"]) ? 0 : Convert.ToDouble(row["Rate"]);
                dt.category = Convert.IsDBNull(row["CategoryId"]) ? null : new Category.Data() { Id = Convert.ToInt64(row["CategoryId"]) };
                dt.type = Convert.IsDBNull(row["TypeId"]) ? null : new Room.Type.Data() { Id = Convert.ToInt64(row["TypeId"]) };
                dt.isAC = Convert.IsDBNull(row["IsAirConditioned"]) ? false : Convert.ToBoolean(row["IsAirConditioned"]);
            }
            return dt;
        }

    }
}