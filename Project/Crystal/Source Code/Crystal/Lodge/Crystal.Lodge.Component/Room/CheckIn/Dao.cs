using System;
using System.Collections.Generic;
using System.Data;

using BinAff.Core;

namespace Crystal.Lodge.Component.Room.CheckIn
{

    public class Dao : Crystal.Activity.Component.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Lodge.CheckInInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Lodge.CheckInRead";
            base.UpdateStoredProcedure = "Lodge.CheckInUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Lodge.CheckInDelete";
            base.NumberOfRowsAffectedInDelete = -1;
            base.SearchStoredProcedure = "";
            base.UpdateStatusStoredProcedure = "Lodge.CheckinUpdateStatus";
        }

        protected override void AssignParameter(String procedureName)
        {
            Data data = this.Data as Data;
            base.AssignParameter(procedureName);
            base.AddInParameter("@ReservationId", DbType.Int64, data.Reservation.Id);

            base.AddInParameter("@Purpose", DbType.String, data.Purpose);
            base.AddInParameter("@ArrivedFrom", DbType.String, data.ArrivedFrom);
            base.AddInParameter("@Remark", DbType.Int64, data.Remark);

            if (data.Invoice != null)
            {
                base.AddInParameter("@InvoiceId", DbType.Int64, data.Invoice.Id);
            }
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            base.CreateDataObject(dr, data);
            Data dt = (Data)data;
            dt.invoiceNumber = Convert.IsDBNull(dr["InvoiceNumber"]) ? String.Empty : Convert.ToString(dr["InvoiceNumber"]);
            dt.Reservation = Convert.IsDBNull(dr["ReservationId"]) ? null : new Crystal.Lodge.Component.Room.Reservation.Data
            { 
                Id = Convert.ToInt64(dr["ReservationId"]) 
            };
            dt.ActivityDate = Convert.IsDBNull(dr["CheckInDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CheckInDate"]);
            dt.Date = Convert.IsDBNull(dr["CreatedDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedDate"]);
            dt.Purpose = Convert.IsDBNull(dr["Purpose"]) ? String.Empty : Convert.ToString(dr["Purpose"]);
            dt.ArrivedFrom = Convert.IsDBNull(dr["ArrivedFrom"]) ? String.Empty : Convert.ToString(dr["ArrivedFrom"]);
            dt.Remark = Convert.IsDBNull(dr["Remark"]) ? String.Empty : Convert.ToString(dr["Remark"]);
            dt.Invoice = Convert.IsDBNull(dr["InvoiceId"]) ? null : new Crystal.Invoice.Component.Data
            {
                Id = Convert.ToInt64(dr["InvoiceId"])
            };

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

        protected override Boolean DeleteBefore()
        {
          return this.DeleteCustomerRoomCheckInLink();
        }

        protected override Boolean ReadAfter()
        {
            Data data = this.Data as Data;
            this.CreateCommand("Lodge.RoomReservationRoomLinkRead");     
            this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds.Tables.Count > 0)
            {
                data.ProductList = new List<BinAff.Core.Data>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    data.ProductList.Add(new Room.Data
                    {
                        Id = Convert.IsDBNull(dr["RoomId"]) ? 0 : Convert.ToInt64(dr["RoomId"])
                    });
                }
            }

            return true;
        }

        //private Boolean InsertRoomList()
        //{
        //    Data data = this.Data as Data;
        //    Boolean retVal = true;
        //    Int64 reservationId = 0;
        //    if (data.ProductList != null)
        //    {          
        //        foreach(BinAff.Core.Data roomData in data.ProductList){
        //            this.CreateCommand("[Lodge].[RoomReservationDetailsInsert]");
        //            this.AddInParameter("@RoomId", DbType.Int64, roomData.Id);
        //            //this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
        //            this.AddInParameter("@ReservationId", DbType.Int64, data.Reservation.Id);
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
           
        //    this.CreateCommand("[Lodge].[RoomReservationDetailsDelete]");           
        //    this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
        //    Int32 ret = this.ExecuteNonQuery();

        //    if (ret == -2146232060)
        //        retVal = false;//Foreign key violation
        //    else
        //        retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;                

        //    return retVal;
        //}

        internal List<Data> IsReservationDeletable(Reservation.Data data)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("Lodge.IsReservationDeletable");
            this.AddInParameter("@ReservationId", DbType.Int64, data.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Date = Convert.IsDBNull(row["CheckInDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["CheckInDate"]),
                        Reservation = new Reservation.Data()
                        {
                            NoOfDays = Convert.ToInt16(row["NoOfDays"]),
                        }
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public override List<Customer.Component.Action.Data> IsProductDeletable(BinAff.Core.Data subject)
        {
            //TO DO : Room and Reservation
            List<Customer.Component.Action.Data> dataList = new List<Customer.Component.Action.Data>();
            this.CreateConnection();
            this.CreateCommand("Lodge.CheckInIsRoomDeletable");
            this.AddInParameter("@RoomId", DbType.Int64, subject.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Date = Convert.IsDBNull(row["CheckInDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["CheckInDate"]),
                        Reservation = new Reservation.Data()
                        {
                            NoOfDays = Convert.ToInt16(row["NoOfDays"]),
                        }
                    });
                }
            }
            this.CloseConnection();
            return dataList;
        }

        internal ReturnObject<Boolean> ModifyCheckInStatus(Customer.Component.Action.Status.Data status)
        {
            ReturnObject<Boolean> retVal = new ReturnObject<Boolean>();
            Data data = this.Data as Data;

            this.CreateConnection();
            this.CreateCommand("Lodge.UpdateCheckInStatus");
            this.AddInParameter("@Id", DbType.Int64, data.Id);
            this.AddInParameter("@StatusId", DbType.Int64, status.Id);
            Int32 ret = this.ExecuteNonQuery();

            if (ret == -2146232060)
                retVal.Value = false;//Foreign key violation
            else
                retVal.Value = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            this.CloseConnection();
            return retVal;
        }

        internal Boolean LinkInvoice()
        {
            Boolean status = false;
            Data data = this.Data as Data;

            this.CreateConnection();
            this.CreateCommand("Lodge.CheckInLinkInvoice");
            this.AddInParameter("@Id", DbType.Int64, data.Id);
            this.AddInParameter("@StatusId", DbType.Int64, data.Status.Id);
            this.AddInParameter("@InvoiceId", DbType.Int64, data.Invoice.Id);
            Int32 ret = this.ExecuteNonQuery();
            this.CloseConnection();

            if (ret == -2146232060)
                status = false;//Foreign key violation
            else
                status = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            return status; ;
        }

        internal List<Room.Data> ReadCheckedInRoomList()
        {
            Data data = (Data)base.Data;
            List<Room.Data> roomDataList = new List<Room.Data>();
            this.CreateCommand("Lodge.ReadAllCheckInRooms");
            this.AddInParameter("@ReservationId", DbType.Int64, data.Reservation.Id);
            DataSet ds = this.ExecuteDataSet();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {                
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    roomDataList.Add(new Room.Data 
                    {
                        Id = Convert.IsDBNull(dr["RoomId"]) ? 0 : Convert.ToInt64(dr["RoomId"])
                    });                    
                }
            }
            return roomDataList;
        }
                
        private bool DeleteCustomerRoomCheckInLink()
        {
            Boolean status = true;
            base.CreateCommand("[AutoTourism].[CustomerRoomCheckInLinkDelete]");
            base.AddInParameter("@RoomCheckInId", DbType.Int64, this.Data.Id);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation
            base.CloseConnection();
            return status;
        }

        public Int64 ReadCheckInId(Int64 ArtifactId)
        {
            Int64 RoomReservationId = 0;
            this.CreateCommand("[Lodge].[ReadRoomCheckInId]");
            this.AddInParameter("@ArtifactId", DbType.Int64, ArtifactId);

            DataSet ds = this.ExecuteDataSet();

            if (ds.Tables.Count > 0)
            {
                RoomReservationId = Convert.IsDBNull(ds.Tables[0].Rows[0]["CheckInId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["CheckInId"]);
            }

            return RoomReservationId;
        }

    }

}
