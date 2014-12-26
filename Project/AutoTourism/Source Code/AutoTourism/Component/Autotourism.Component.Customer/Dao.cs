using System;
using System.Data;
using System.Collections.Generic;

using BinAff.Core;

using RoomRsrvCrys = Crystal.Lodge.Component.Room.Reservation;
using ChkInCrys = Crystal.Lodge.Component.Room.CheckIn;
using CharCrys = Crystal.Customer.Component.Characteristic;

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
            Data data = (this.Data as Data);
            if (this.Data != null && (data.RoomReserver.Active != null && (data.RoomReserver.Active as RoomRsrvCrys.Data).Id == 0))
            {
                isNewReservation = true;
            }

            if (this.Data != null && (data.Checkin.Active != null && (data.Checkin.Active as ChkInCrys.Data).Id == 0))
            {
                isNewCheckIn = true;
            }
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
            Boolean blnRetVal = true;
            if (!isNewReservation)
            {
                this.DeleteCustomerReservationList();
            }
            blnRetVal = this.InsertCustomerReservationList();
            if (isNewCheckIn)
            {
                blnRetVal = this.InsertCustomerCheckInList();
            }
            return blnRetVal;
        }

        protected override Boolean ReadAfter()
        {
            base.ReadAfter();
            this.ReadCustomerRoomReservationLink();
            this.ReadCustomerRoomCheckInLink();
            return true;
        }

        private Boolean DeleteCustomerReservationList()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;            

            //This condition will be null, if the customer has no reservation
            if (data.RoomReserver.Active != null)
            {
                this.CreateCommand("[AutoTourism].[CustomerRoomReservationLinkDelete]");                
                this.AddInParameter("@RoomReservationId", DbType.Int64, data.RoomReserver.Active.Id);
                try
                {
                    Int32 ret = this.ExecuteNonQuery();
                }
                catch (Exception ex) 
                { 
                
                }

                //if (ret == -2146232060)
                //    return false;//Foreign key violation
                //else
                //    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            }
            return retVal;
        }
        
        private Boolean InsertCustomerReservationList()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;

            //This condition will be null, if the customer has no reservation
            if (data.RoomReserver.Active != null)
            {
                this.CreateCommand("AutoTourism.CustomerRoomReservationLinkInsert");
                this.AddInParameter("@CustomerId", DbType.Int64, data.Id);
                this.AddInParameter("@RoomReservationId", DbType.Int64, data.RoomReserver.Active.Id);
                this.AddOutParameter("@Id", DbType.Int64, 0);
                Int32 ret = this.ExecuteNonQuery();
                if (ret == -2146232060)
                {
                    return false;//Foreign key violation
                }
                else
                {
                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
                }
            }
            return retVal;
        }

        private Boolean InsertCustomerCheckInList()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;

            //This condition will be null, if the customer has no reservation
            if (data.RoomReserver.Active != null)
            {
                this.CreateCommand("AutoTourism.CustomerRoomCheckInLinkInsert");
                this.AddInParameter("@CustomerId", DbType.Int64, data.Id);
                this.AddInParameter("@RoomCheckInId", DbType.Int64, data.Checkin.Active.Id);
                this.AddOutParameter("@Id", DbType.Int64, 0);
                Int32 ret = this.ExecuteNonQuery();
                if (ret == -2146232060)
                {
                    return false;//Foreign key violation
                }
                else
                {
                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
                }
            }
            return retVal;
        }

        private void ReadCustomerRoomReservationLink()
        {
            this.CreateCommand("AutoTourism.CustomerRoomReservationLinkRead");
            this.AddInParameter("@CustomerId", DbType.Int64, this.Data.Id);
            DataSet ds = this.ExecuteDataSet();
            (this.Data as Data).RoomReserver = new Crystal.Lodge.Component.Room.Reserver.Data();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                (this.Data as Data).RoomReserver.AllList = new List<BinAff.Core.Data>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    RoomRsrvCrys.Data data = new RoomRsrvCrys.Data
                    {
                        Id = Convert.IsDBNull(row["RoomReservationId"]) ? 0 : Convert.ToInt64(row["RoomReservationId"]),
                    };
                    //TO DO: Need to check why read is required. some createchildren is missing.
                    (new RoomRsrvCrys.Server(data) as ICrud).Read();
                    (this.Data as Data).RoomReserver.AllList.Add(data);
                }
            }
        }

        private void ReadCustomerRoomCheckInLink()
        {
            this.CreateCommand("AutoTourism.CustomerRoomCheckInLinkRead");
            this.AddInParameter("@CustomerId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            (this.Data as Data).Checkin = new Crystal.Lodge.Component.Room.CheckInContainer.Data();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                (this.Data as Data).Checkin.AllList = new List<BinAff.Core.Data>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ChkInCrys.Data data = new ChkInCrys.Data
                    {
                        Id = Convert.IsDBNull(row["RoomCheckInId"]) ? 0 : Convert.ToInt64(row["RoomCheckInId"]),
                    };
                    //TO DO: Need to check why read is required. some createchildren is missing.
                    (new ChkInCrys.Server(data) as ICrud).Read();
                    (this.Data as Data).Checkin.AllList.Add(data);
                }
            }
        }        

        public Int64 ReadCustomerIdForReservation(Int64 reservationId)
        {
            Int64 customerId = 0;
            this.CreateCommand("AutoTourism.GetCustomerIdForReservation");
            this.AddInParameter("@ReservationId", DbType.Int64, reservationId);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            {
                customerId = Convert.ToInt64(ds.Tables[0].Rows[0]["CustomerId"]);
            }
            return customerId;
        }

    }

}