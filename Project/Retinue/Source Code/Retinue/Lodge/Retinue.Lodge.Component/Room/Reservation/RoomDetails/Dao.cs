using System;
using System.Collections.Generic;
using System.Data;

namespace Retinue.Lodge.Component.Room.Reservation.RoomDetails
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Lodge.ReservationDetailsInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Lodge.ReservationDetailsRead";
            base.ReadForParentStoredProcedure = "Lodge.ReservationDetailsReadForParent";
            //base.UpdateStoredProcedure = "Lodge.ReservationDetailsUpdate";
            //base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Lodge.ReservationDetailsDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            Data data = this.Data as Data;
            this.AddInParameter("@RoomId", DbType.Int64, data.Room.Id);
            this.AddInParameter("@ReservationId", DbType.Int64, this.ParentData.Id);
            this.AddInParameter("@ExtraAccomodation", DbType.Int16, data.ExtraAccomodation);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Room = Convert.IsDBNull(dr["RoomId"]) ? null : new Room.Data { Id = Convert.ToInt64(dr["RoomId"]) };
            dt.ExtraAccomodation = Convert.ToInt16(dr["ExtraAccomodation"]);
            return dt;
        }

        protected override void AttachChildDataToParent()
        {
            (this.ParentData as Reservation.Data).ProductList = new List<BinAff.Core.Data>
            {
                this.Data
            };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                (this.ParentData as Reservation.Data).ProductList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    (this.ParentData as Reservation.Data).ProductList.Add(data);
                }
            }
        }

    }

}