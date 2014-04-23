using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Lodge.Component.RoomReservationReport
{

    public class Dao : Crystal.Report.Component.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Lodge].[RoomReservationReportInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Lodge].[RoomReservationReportRead]";
            base.ReadAllStoredProcedure = "[Lodge].[RoomReservationReportReadAll]";           
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            return base.CreateDataObject(ds, data);
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            return base.CreateDataObjectList(ds);            
        }

        public override List<BinAff.Core.Data> GetData(DateTime fromDate, DateTime toDate)
        {
            List<BinAff.Core.Data> roomReservationList = new List<BinAff.Core.Data>();

            base.CreateCommand("[Lodge].[ReportRoomReservation]");
            base.AddInParameter("@StartDate", DbType.DateTime, fromDate.Date);
            base.AddInParameter("@EndDate", DbType.DateTime, toDate.Date);
            DataSet ds = base.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    roomReservationList.Add(new Room.Reservation.Data
                    {
                        Id = Convert.IsDBNull(row["id"]) ? 0 : Convert.ToInt64(row["id"])
                    });
                }
            }

            return roomReservationList;
        }

    }

}
