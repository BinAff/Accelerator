﻿using System;
using System.Collections.Generic;
using System.Data;

using BinAff.Core;

namespace Retinue.Lodge.Component.Room.Reservation
{

    public class Dao : Crystal.Reservation.Component.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Lodge.RoomReservationInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Lodge.RoomReservationRead";
            base.ReadAllStoredProcedure = "Lodge.RoomReservationReadAll";
            base.UpdateStoredProcedure = "Lodge.RoomReservationUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Lodge.RoomReservationDelete";
            base.NumberOfRowsAffectedInDelete = -1;
            base.SearchStoredProcedure = "Lodge.RoomReservationSearch";
            base.UpdateStatusStoredProcedure = "Lodge.RoomReservationUpdateStatus";
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@NoOfDays", DbType.Int16, ((Data)this.Data).NoOfDays);          
            base.AddInParameter("@NoOfRooms", DbType.Int16, ((Data)this.Data).NoOfRooms);        
        
            if (((Data)this.Data).RoomCategory != null && ((Data)this.Data).RoomCategory.Id > 0)
                base.AddInParameter("@RoomCategoryId", DbType.Int64,((Data)this.Data).RoomCategory.Id);

            if (((Data)this.Data).RoomType != null && ((Data)this.Data).RoomType.Id > 0)
                base.AddInParameter("@RoomTypeId", DbType.Int64, ((Data)this.Data).RoomType.Id);

            base.AddInParameter("@ACPreference", DbType.Int16, ((Data)this.Data).ACPreference);

            base.AddInParameter("@NoOfMale", DbType.Int16, ((Data)this.Data).NoOfMale);
            base.AddInParameter("@NoOfFemale", DbType.Int16, ((Data)this.Data).NoOfFemale);
            base.AddInParameter("@NoOfChild", DbType.Int16, ((Data)this.Data).NoOfChild);
            base.AddInParameter("@NoOfInfant", DbType.Int16, ((Data)this.Data).NoOfInfant);
            base.AddInParameter("@Remark", DbType.String, ((Data)this.Data).Remark);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            base.CreateDataObject(dr, data);
            Data dt = data as Data;

            dt.Date = Convert.IsDBNull(dr["CreatedDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedDate"]);           
            dt.ActivityDate = Convert.IsDBNull(dr["BookingFrom"]) ? DateTime.MinValue : Convert.ToDateTime(dr["BookingFrom"]);                       
            dt.NoOfDays = Convert.ToInt16(dr["NoOfDays"]);
            dt.NoOfRooms = Convert.ToInt16(dr["NoOfRooms"]);
            dt.Date = Convert.IsDBNull(dr["CreatedDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedDate"]);
            //dt.IsCheckedIn = Convert.ToBoolean(dr["IsCheckedIn"]);
            dt.RoomCategory = Convert.IsDBNull(dr["RoomCategoryId"]) ? null : new Category.Data { Id = Convert.ToInt64(dr["RoomCategoryId"]) };
            dt.RoomType = Convert.IsDBNull(dr["RoomTypeId"]) ? null : new Type.Data { Id = Convert.ToInt64(dr["RoomTypeId"]) };
            dt.ACPreference = Convert.IsDBNull(dr["AcRoomPreference"]) ? 0 :  Convert.ToInt32(dr["AcRoomPreference"]) ;
            dt.NoOfMale = Convert.IsDBNull(dr["NoOfMale"]) ? 0 : Convert.ToInt32(dr["NoOfMale"]);
            dt.NoOfFemale = Convert.IsDBNull(dr["NoOfFemale"]) ? 0 : Convert.ToInt32(dr["NoOfFemale"]);
            dt.NoOfChild = Convert.IsDBNull(dr["NoOfChild"]) ? 0 : Convert.ToInt32(dr["NoOfChild"]);
            dt.NoOfInfant = Convert.IsDBNull(dr["NoOfInfant"]) ? 0 : Convert.ToInt32(dr["NoOfInfant"]);
            dt.Remark = Convert.IsDBNull(dr["Remark"]) ? String.Empty : dr["Remark"].ToString();
            
            return dt;
        }

        public override Crystal.Customer.Component.Action.Data CreateDataObjectInstance()
        {
            return new Data();
        }

        protected override Crystal.Product.Component.Data Createproduct(Int64 productId)
        {
            Room.Data roomData = new Room.Data{Id = productId};
            ICrud roomServer = new Room.Server(roomData);
            roomServer.Read();
            return roomData;
        }

        //protected override Boolean UpdateAfter()
        //{
        //    if(this.DeleteRoomList())
        //        return this.InsertRoomList();
        //    return false;
        //}

        protected override Boolean DeleteBefore()
        {
            Boolean retVal = true;

            retVal = this.DeleteCustomerRoomReservationLink();
            //if (retVal) retVal = this.DeleteRoomList();

            return retVal;
        }

        //internal Boolean UpdateExtraRoomDetails()
        //{
        //    Data data = this.Data as Data;

        //    this.CreateCommand("Lodge.RoomReservationDetailsRead");
        //    this.AddInParameter("@ReservationId", DbType.Int64, data.Id);

        //    DataSet ds = this.ExecuteDataSet();

        //    if (ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            (data.ProductList.Find((p) =>
        //            {
        //                return p.Id == Convert.ToInt64(dr["RoomId"]);
        //            }) as Room.Data).ExtraAccomodation = Convert.ToInt16(Convert.IsDBNull(dr["ExtraAccomodation"]) ? 0 : dr["ExtraAccomodation"]);
        //        }
        //    }

        //    return true;
        //}

        //private Boolean InsertRoomList()
        //{
        //    Data data = this.Data as Data;
        //    Boolean retVal = true;
        //    Int64 reservationId = 0;
        //    if (data.ProductList != null)
        //    {
        //        foreach (Room.Data roomData in data.ProductList)
        //        {
        //            this.CreateCommand("Lodge.RoomReservationDetailsInsert");
        //            this.AddInParameter("@RoomId", DbType.Int64, roomData.Id);
        //            this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
        //            this.AddInParameter("@ExtraAccomodation", DbType.Int16, roomData.ExtraAccomodation);
        //            this.AddInParameter("@Id", DbType.Int64, reservationId);
        //            Int32 ret = this.ExecuteNonQuery();

        //            if (ret == -2146232060)
        //                return false;//Foreign key violation
        //            else
        //                retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //        }               
        //    }

        //    return retVal;
        //}

        //private Boolean DeleteRoomList()
        //{
        //    Data data = this.Data as Data;
        //    Boolean retVal = true;          
           
        //    this.CreateCommand("Lodge.RoomReservationDetailsDelete");           
        //    this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
        //    Int32 ret = this.ExecuteNonQuery();

        //    if (ret == -2146232060)
        //        retVal = false;//Foreign key violation
        //    else
        //        retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
                

        //    return retVal;
        //}

        public override List<Crystal.Customer.Component.Action.Data> IsProductDeletable(BinAff.Core.Data subject)
        {
            //TO DO : Room   
            List<Crystal.Customer.Component.Action.Data> dataList = new List<Crystal.Customer.Component.Action.Data>();
            this.CreateConnection();
            this.CreateCommand("Lodge.IsCheckInDeletable");
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

        private Boolean DeleteCustomerRoomReservationLink()
        {
            Boolean status = true;         
            base.CreateCommand("AutoTourism.CustomerRoomReservationLinkDelete");
            base.AddInParameter("@RoomReservationId", DbType.Int64, this.Data.Id);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation
            base.CloseConnection();
            return status;
        }

        public Int64 ReadReservationId(Int64 ArtifactId)
        {
            Int64 RoomReservationId = 0;
            this.CreateCommand("Lodge.ReadRoomReservationId");
            this.AddInParameter("@ArtifactId", DbType.Int64, ArtifactId);

            DataSet ds = this.ExecuteDataSet();

            if (ds.Tables.Count > 0)
            {
                RoomReservationId = Convert.IsDBNull(ds.Tables[0].Rows[0]["RoomReservationId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["RoomReservationId"]);               
            }

            return RoomReservationId;
        }
       
    }

}