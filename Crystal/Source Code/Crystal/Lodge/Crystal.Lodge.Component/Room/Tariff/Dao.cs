using System;
using System.Data;
using System.Collections.Generic;

using GenTariff = Crystal.Tariff.Component;

namespace Crystal.Lodge.Component.Room.Tariff
{
    public class Dao : GenTariff.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Lodge].[RoomTariffInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Lodge].[RoomTariffRead]";
            base.ReadAllStoredProcedure = "[Lodge].[RoomTariffReadAll]";
            base.UpdateStoredProcedure = "[Lodge].[RoomTariffUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Lodge].[RoomTariffDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override Product.Component.Data BindItem(Int64 itemId)
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
            this.CreateCommand("[Lodge].[RoomTariffModifyRate]");
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
            this.CreateCommand("[Lodge].[IsTariffDeletable]");
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

        internal Boolean ReadDuplicate()
        {
            Data data = (Data)this.Data;
            this.CreateConnection();
            this.CreateCommand("[Lodge].[TariffReadDuplicate]");
            this.AddInParameter("@RoomId", DbType.String, data.Product.Id);
            this.AddInParameter("@StartDate", DbType.String, data.StartDate);
            this.AddInParameter("@EndDate", DbType.String, data.EndDate);

            DataSet ds = this.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(dr["Id"]) && Convert.ToInt64(dr["Id"]) != this.Data.Id) return true;
                }
            }

            return false;
        }
    }
}
