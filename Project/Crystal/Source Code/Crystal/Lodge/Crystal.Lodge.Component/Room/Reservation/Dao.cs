﻿using System;
using System.Collections.Generic;
using System.Data;
using BinAff.Core;

namespace Crystal.Lodge.Component.Room.Reservation
{

    public class Dao : Crystal.Reservation.Component.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Lodge].[RoomReservationInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Lodge].[RoomReservationRead]";
            base.ReadAllStoredProcedure = "[Lodge].[RoomReservationReadAll]";
            base.UpdateStoredProcedure = "[Lodge].[RoomReservationUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Lodge].[RoomReservationDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
            base.SearchStoredProcedure = "[Lodge].[RoomReservationSearch]";
            base.UpdateStatusStoredProcedure = "[Lodge].[RoomReservationUpdateStatus]";
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@NoOfDays", DbType.Int16, ((Data)this.Data).NoOfDays);
            base.AddInParameter("@NoOfPersons", DbType.Int16, ((Data)this.Data).NoOfPersons);
            base.AddInParameter("@NoOfRooms", DbType.Int16, ((Data)this.Data).NoOfRooms);
            base.AddInParameter("@Description", DbType.String, ((Data)this.Data).Description);
            base.AddInParameter("@Advance", DbType.Double, ((Data)this.Data).Advance);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            base.CreateDataObject(dr, data);
            Data dt = (Data)data;
           
            dt.ActivityDate = Convert.IsDBNull(dr["BookingFrom"]) ? DateTime.MinValue : Convert.ToDateTime(dr["BookingFrom"]);           
            dt.NoOfDays = Convert.ToInt16(dr["NoOfDays"]);
            dt.NoOfPersons = Convert.ToInt16(dr["NoOfPersons"]);
            dt.NoOfRooms = Convert.ToInt16(dr["NoOfRooms"]);
            dt.Description = Convert.IsDBNull(dr["Description"]) ? String.Empty : Convert.ToString(dr["Description"]);
            dt.Advance = Convert.IsDBNull(dr["Advance"]) ? 0 : Convert.ToDouble(dr["Advance"]);
            dt.Date = Convert.IsDBNull(dr["CreatedDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedDate"]);
            dt.IsCheckedIn = Convert.ToBoolean(dr["IsCheckedIn"]);

            return dt;
        }

        public override Crystal.Customer.Component.Action.Data CreateDataObjectInstance()
        {
            return new Data();
        }

        protected override Product.Component.Data Createproduct(Int64 productId)
        {
            Room.Data roomData = new Room.Data{Id = productId};
            ICrud roomServer = new Room.Server(roomData);
            roomServer.Read();
            return roomData;
        }

        protected override Boolean CreateAfter()
        {
            return this.InsertRoomList();
        }

        protected override Boolean UpdateAfter()
        {
            if(this.DeleteRoomList())
                return this.InsertRoomList();
            return false;
        }

        protected override Boolean DeleteBefore()
        {
            return this.DeleteRoomList();
        }

        protected override Boolean ReadAfter()
        {
            Data data = this.Data as Data;

            this.CreateCommand("[Lodge].[RoomReservationDetailsRead]");     
            this.AddInParameter("@ReservationId", DbType.Int64, data.Id);

            DataSet ds = this.ExecuteDataSet();

            if (ds.Tables.Count > 0)
            {
                data.ProductList = new List<BinAff.Core.Data>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Room.Data room = new Room.Data
                    {
                        Id = Convert.IsDBNull(dr["RoomId"]) ? 0 : Convert.ToInt64(dr["RoomId"])
                    };
                    ICrud roomServer = new Room.Server(room);
                    roomServer.Read();
                    data.ProductList.Add(room);
                }
            }

            return true;
        }

        private Boolean InsertRoomList()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;
            Int64 reservationId = 0;
            if (data.ProductList != null)
            {          
                foreach(BinAff.Core.Data roomData in data.ProductList){
                    this.CreateCommand("[Lodge].[RoomReservationDetailsInsert]");
                    this.AddInParameter("@RoomId", DbType.Int64, roomData.Id);
                    this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
                    this.AddInParameter("@Id", DbType.Int64, reservationId);
                    Int32 ret = this.ExecuteNonQuery();

                    if (ret == -2146232060)
                        return false;//Foreign key violation
                    else
                        retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
                }               
            }

            return retVal;
        }

        private Boolean DeleteRoomList()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;          
           
            this.CreateCommand("[Lodge].[RoomReservationDetailsDelete]");           
            this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
            Int32 ret = this.ExecuteNonQuery();

            if (ret == -2146232060)
                retVal = false;//Foreign key violation
            else
                retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
                

            return retVal;
        }

        public override List<Customer.Component.Action.Data> IsProductDeletable(BinAff.Core.Data subject)
        {
            //TO DO : Room   
            List<Customer.Component.Action.Data> dataList = new List<Customer.Component.Action.Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsCheckInDeletable]");
            this.AddInParameter("@RoomId", DbType.Int64, subject.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Date = Convert.IsDBNull(row["BookingFrom"]) ? DateTime.MinValue : Convert.ToDateTime(row["BookingFrom"]),
                        NoOfDays = Convert.ToInt16(row["NoOfDays"]),
                       
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public ReturnObject<Boolean> ModifyReservationToOccupied()
        {
            ReturnObject<Boolean> retVal = new ReturnObject<Boolean>();
            Data data = this.Data as Data;

            this.CreateConnection();
            this.CreateCommand("[Lodge].[UpdateReservationStatusToCheckIn]");
            this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
            Int32 ret = this.ExecuteNonQuery();

            if (ret == -2146232060)
                retVal.Value = false;//Foreign key violation
            else
                retVal.Value = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            this.CloseConnection();
            return retVal;        
        }

    }

}
