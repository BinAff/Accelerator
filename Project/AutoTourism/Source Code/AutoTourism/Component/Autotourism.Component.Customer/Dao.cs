using System;
using System.Data;
using System.Collections.Generic;

namespace AutoTourism.Component.Customer
{
    public class Dao : Crystal.Customer.Component.Dao
    {

        private Boolean isNewReservation;
        private Boolean isNewCheckIn;

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            if (this.Data != null && ((this.Data as Data).RoomReserver.Active != null && ((this.Data as Data).RoomReserver.Active as Crystal.Lodge.Component.Room.Reservation.Data).Id == 0))
            {
                isNewReservation = true;
            }

            if (this.Data != null && ((this.Data as Data).Checkin.Active != null && ((this.Data as Data).Checkin.Active as Crystal.Lodge.Component.Room.CheckIn.Data).Id == 0))
            {
                isNewCheckIn = true;
            }
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            dt = base.CreateDataObject(ds, data) as Data;
            return dt;
        }

        protected override Boolean CreateAfter()
        {
            Boolean retVal = false;
            retVal = this.InsertCustomerReservationList();
            retVal = this.InsertCustomerCheckInList();
            return retVal;
        }

        protected override Boolean UpdateAfter()
        {
            if (isNewReservation)
            {
                return this.InsertCustomerReservationList();
            }

            if (isNewCheckIn)
            {
                return this.InsertCustomerCheckInList();
            }

            return true;
        }

        protected override Boolean ReadAfter()
        {
            base.ReadAfter();
            this.ReadCustomerRoomReservationLink();
            this.ReadCustomerRoomCheckInLink();
            ////TO DO : Read the relationship between Customer and room reservation
            //this.CreateCommand("[AutoTourism].[CustomerRoomReservationLinkRead]");
            //this.AddInParameter("@CustomerId", DbType.Int64, this.Data.Id);

            //DataSet ds = this.ExecuteDataSet();
            //(this.Data as Data).RoomReserver = new Crystal.Lodge.Component.Room.Reserver.Data();
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    (this.Data as Data).RoomReserver.AllList = new List<BinAff.Core.Data>();
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        Crystal.Lodge.Component.Room.Reservation.Data data = new Crystal.Lodge.Component.Room.Reservation.Data
            //        {
            //            Id = Convert.IsDBNull(row["RoomReservationId"]) ? 0 : Convert.ToInt64(row["RoomReservationId"]),
            //        };
            //        //TO DO: Need to check why read is required. some createchildren is missing.
            //        BinAff.Core.ICrud server = new Crystal.Lodge.Component.Room.Reservation.Server(data);
            //        server.Read();
            //        (this.Data as Data).RoomReserver.AllList.Add(data);

            //    }
            //}

            return true;
        }

        private Boolean InsertCustomerReservationList()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;
            Int64 customerReservationId = 0;            

            //This condition will be null, if the customer has no reservation
            if (((BinAff.Core.Data)(((Crystal.Customer.Component.Characteristic.Data)(data.RoomReserver)).Active)) != null)
            {
                Int64 ReservationId = ((BinAff.Core.Data)(((Crystal.Customer.Component.Characteristic.Data)(data.RoomReserver)).Active)).Id;

                this.CreateCommand("[AutoTourism].[CustomerRoomReservationLinkInsert]");
                this.AddInParameter("@CustomerId", DbType.Int64, data.Id);
                this.AddInParameter("@RoomReservationId", DbType.Int64, ReservationId);
                this.AddInParameter("@Id", DbType.Int64, customerReservationId);
                Int32 ret = this.ExecuteNonQuery();

                if (ret == -2146232060)
                    return false;//Foreign key violation
                else
                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            }
            return retVal;
        }

        private Boolean InsertCustomerCheckInList()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;
            Int64 customerCheckInId = 0;

            //This condition will be null, if the customer has no reservation
            if (((BinAff.Core.Data)(((Crystal.Customer.Component.Characteristic.Data)(data.RoomReserver)).Active)) != null)
            {
                Int64 CheckInId = ((BinAff.Core.Data)(((Crystal.Customer.Component.Characteristic.Data)(data.Checkin)).Active)).Id;

                this.CreateCommand("[AutoTourism].[CustomerRoomCheckInLinkInsert]");
                this.AddInParameter("@CustomerId", DbType.Int64, data.Id);
                this.AddInParameter("@RoomCheckInId", DbType.Int64, CheckInId);
                this.AddInParameter("@Id", DbType.Int64, customerCheckInId);
                Int32 ret = this.ExecuteNonQuery();

                if (ret == -2146232060)
                    return false;//Foreign key violation
                else
                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            }
            return retVal;
        }

        private void ReadCustomerRoomReservationLink() {
            this.CreateCommand("[AutoTourism].[CustomerRoomReservationLinkRead]");
            this.AddInParameter("@CustomerId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            (this.Data as Data).RoomReserver = new Crystal.Lodge.Component.Room.Reserver.Data();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                (this.Data as Data).RoomReserver.AllList = new List<BinAff.Core.Data>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Crystal.Lodge.Component.Room.Reservation.Data data = new Crystal.Lodge.Component.Room.Reservation.Data
                    {
                        Id = Convert.IsDBNull(row["RoomReservationId"]) ? 0 : Convert.ToInt64(row["RoomReservationId"]),
                    };
                    //TO DO: Need to check why read is required. some createchildren is missing.
                    BinAff.Core.ICrud server = new Crystal.Lodge.Component.Room.Reservation.Server(data);
                    server.Read();
                    (this.Data as Data).RoomReserver.AllList.Add(data);

                }
            }
        }

        private void ReadCustomerRoomCheckInLink()
        {
            this.CreateCommand("[AutoTourism].[CustomerRoomCheckInLinkRead]");
            this.AddInParameter("@CustomerId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            (this.Data as Data).Checkin = new Crystal.Lodge.Component.Room.CheckInContainer.Data();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                (this.Data as Data).Checkin.AllList = new List<BinAff.Core.Data>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Crystal.Lodge.Component.Room.CheckIn.Data data = new Crystal.Lodge.Component.Room.CheckIn.Data
                    {
                        Id = Convert.IsDBNull(row["RoomCheckInId"]) ? 0 : Convert.ToInt64(row["RoomCheckInId"]),
                    };
                    //TO DO: Need to check why read is required. some createchildren is missing.
                    BinAff.Core.ICrud server = new Crystal.Lodge.Component.Room.CheckIn.Server(data);
                    server.Read();
                    (this.Data as Data).Checkin.AllList.Add(data);

                }
            }
        }
    }

}
