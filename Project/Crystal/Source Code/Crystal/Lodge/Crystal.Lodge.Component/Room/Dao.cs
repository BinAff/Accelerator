using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Lodge.Component.Room
{

    public class Dao : Product.Component.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Lodge.RoomInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Lodge.RoomRead";
            base.ReadAllStoredProcedure = "Lodge.RoomReadAll";
            base.UpdateStoredProcedure = "Lodge.RoomUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Lodge.RoomDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);           
            base.AddInParameter("@CategoryId", DbType.Int64, ((Data)this.Data).Category.Id);
            base.AddInParameter("@TypeId", DbType.Int64, ((Data)this.Data).Type.Id);
            base.AddInParameter("@BuildingId", DbType.Int64, ((Data)this.Data).Building.Id);
            base.AddInParameter("@FloorId", DbType.Int32, ((Data)this.Data).Floor.Id);
            base.AddInParameter("@IsAirConditioned", DbType.Boolean, ((Data)this.Data).IsAirConditioned);
            base.AddInParameter("@Accomodation", DbType.Int16, (this.Data as Data).Accomodation);
            base.AddInParameter("@ExtraAccomodation", DbType.Int16, (this.Data as Data).ExtraAccomodation);
            base.AddInParameter("@StatusId", DbType.Int64, ((Data)this.Data).Status.Id);
        }        
        
        //protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        //{
        //    List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            ret.Add(new Data
        //            {   
        //                Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
        //                Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
        //                Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
        //                Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]),
        //                Category = new Category.Data()
        //                {
        //                    Id = Convert.IsDBNull(row["CategoryId"]) ? 0 : Convert.ToInt32(row["CategoryId"])
        //                },
        //                Type = new Type.Data()
        //                {
        //                    Id = Convert.IsDBNull(row["TypeId"]) ? 0 : Convert.ToInt32(row["TypeId"])
        //                },
        //                Building = new Building.Data()
        //                {
        //                    Id = Convert.IsDBNull(row["BuildingId"]) ? 0 : Convert.ToInt32(row["BuildingId"])
        //                },
        //                Floor = new Building.Floor.Data()
        //                {
        //                    Id = Convert.IsDBNull(row["FloorId"]) ? 0 : Convert.ToInt32(row["FloorId"])
        //                },
        //                IsAirConditioned = Convert.IsDBNull(row["IsAirConditioned"]) ? false : Convert.ToBoolean(row["IsAirConditioned"]),
        //                Status = new Status.Data
        //                {
        //                    Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"])
        //                },
        //            });
        //        }
        //    }
        //    return ret;
        //}

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            if (dr != null)
            {
                dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
                dt.Number = Convert.IsDBNull(dr["Number"]) ? String.Empty : Convert.ToString(dr["Number"]);
                dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);
                dt.Description = Convert.IsDBNull(dr["Description"]) ? String.Empty : Convert.ToString(dr["Description"]);
                dt.Category = new Category.Data
                {
                    Id = Convert.IsDBNull(dr["CategoryId"]) ? 0 : Convert.ToInt32(dr["CategoryId"])
                };
                dt.Type = new Type.Data
                {
                    Id = Convert.IsDBNull(dr["TypeId"]) ? 0 : Convert.ToInt32(dr["TypeId"])
                };
                dt.Building = new Building.Data
                {
                    Id = Convert.IsDBNull(dr["BuildingId"]) ? 0 : Convert.ToInt32(dr["BuildingId"])
                };
                dt.Floor = new Building.Floor.Data
                {
                    Id = Convert.IsDBNull(dr["FloorId"]) ? 0 : Convert.ToInt32(dr["FloorId"])
                };
                dt.IsAirConditioned = Convert.IsDBNull(dr["IsAirConditioned"]) ? false : Convert.ToBoolean(dr["IsAirConditioned"]);
                dt.Accomodation = Convert.IsDBNull(dr["Accomodation"]) ? (Int16)0 : Convert.ToInt16(dr["Accomodation"]);
                dt.ExtraAccomodation = Convert.IsDBNull(dr["ExtraAccomodation"]) ? (Int16)0 : Convert.ToInt16(dr["ExtraAccomodation"]);
                dt.Status = new Status.Data
                {
                    Id = Convert.IsDBNull(dr["StatusId"]) ? 0 : Convert.ToInt64(dr["StatusId"])
                };
            }
            return dt;
        }

        //protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        //{
        //    //Data dt = (Data)data;
        //    Data dt = (Data)base.CreateDataObject(ds, data);
        //    DataRow row;
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        row = ds.Tables[0].Rows[0];               

        //        dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
        //        //dt.Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]);
        //        //dt.Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]);
        //        //dt.Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]);
        //        dt.Category = new Category.Data()
        //        {
        //            Id = Convert.IsDBNull(row["CategoryId"]) ? 0 : Convert.ToInt32(row["CategoryId"])
        //        };
        //        dt.Type = new Type.Data() {
        //            Id = Convert.IsDBNull(row["TypeId"]) ? 0 : Convert.ToInt32(row["TypeId"])
        //        };
        //        dt.Building = new Building.Data() {
        //            Id = Convert.IsDBNull(row["BuildingId"]) ? 0 : Convert.ToInt32(row["BuildingId"])
        //        };
        //        dt.Floor = new Building.Floor.Data() {
        //            Id = Convert.IsDBNull(row["FloorId"]) ? 0 : Convert.ToInt32(row["FloorId"])
        //        };
        //        dt.IsAirConditioned = Convert.IsDBNull(row["IsAirConditioned"]) ? false : Convert.ToBoolean(row["IsAirConditioned"]);
              
        //        dt.Status = new Status.Data
        //        {
        //            Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"])
        //        };
        //    }
        //    return dt;
        //}

        internal Boolean ModifyStatus(Int64 statusId)
        {
            Boolean retVal = true;
            Data data = (Data)this.Data;

            base.CreateConnection();
            this.CreateCommand("Lodge.RoomModifyStatus");
            this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
            this.AddInParameter("@StatusId", DbType.Int64, statusId);
            Int32 ret = this.ExecuteNonQuery();
            base.CloseConnection();

            if (ret == -2146232060)
                retVal = false;//Foreign key violation
            else
                retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            return retVal;
        }       

        //private Boolean CreateRoomImage(List<Image.Data> ImageList, Int64 RoomId)
        //{
        //    Boolean isCreatedSuccessfully = true;
        //    if (((Data)this.Data).ImageList == null) return false;

        //    foreach (Image.Data ImgData in ((Data)this.Data).ImageList)
        //    {
        //        if (isCreatedSuccessfully)
        //        {
        //            base.CreateCommand("RoomImageInsert");
        //            base.AddInParameter("@RoomId", DbType.Int64, RoomId);
        //            base.AddInParameter("@Image", DbType.Binary, (object)ImgData.Image);
        //            base.AddInParameter("@Name", DbType.String, ImgData.Name);
        //            base.AddOutParameter("@Id", DbType.Int64, ImgData.Id);
        //            Int32 ret = base.ExecuteNonQuery();
        //            if (ret == -2146232060) isCreatedSuccessfully = false; //Foreign key violation
        //            if (isCreatedSuccessfully)
        //                isCreatedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //        }
        //    }

        //    return isCreatedSuccessfully;
        //}

        //private Boolean DeleteRoomImage(Int64 RoomId)
        //{
        //    //base.CreateConnection();

        //    Boolean isDeletedSuccessfully = true;
        //    this.CreateCommand("RoomImageDelete");
        //    this.AddInParameter("@Id", DbType.Int64, RoomId);

        //    Int32 ret = this.ExecuteNonQuery();
        //    if (ret == -2146232060) isDeletedSuccessfully = false;//Foreign key violation
        //    isDeletedSuccessfully = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

        //    //base.CloseConnection();

        //    return isDeletedSuccessfully;
        //}

        //private List<BinAff.Core.Data> CreateRoomImageList(DataSet ds)
        //{
        //    List<BinAff.Core.Data> ImageList = new List<BinAff.Core.Data>();
        //    DataRow row;
        //    Image.Data data;
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            row = ds.Tables[0].Rows[i];
        //            data = new Image.Data()
        //            {
        //                Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
        //                Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
        //                Image = Convert.IsDBNull(row["Image"]) ? null : (Byte[])row["Image"],
        //            };

        //            ImageList.Add(data);
        //        }
        //    }
        //    return ImageList;
        //}

        //public Boolean Close()
        //{
        //    Boolean retVal = true;
        //    Data data = (Data)this.Data;
        //    if (data != null && data.ClosureReasonList != null && data.ClosureReasonList.Count > 0)
        //    {
        //        base.CreateConnection();

        //        foreach (ClosureReason.Data closeData in data.ClosureReasonList)
        //        {
        //            if (retVal)
        //            {
        //                this.CreateCommand("RoomClosureInsert");
        //                this.AddInParameter("@UserId", DbType.Int64, closeData.UserId);
        //                //this.AddInParameter("@RoomId", DbType.Int64, closeData.RoomId);
        //                this.AddInParameter("@Reason", DbType.String, closeData.Reason);
        //                this.AddOutParameter("@Id", DbType.Int64, this.Data.Id);

        //                Int32 ret = this.ExecuteNonQuery();

        //                if (ret == -2146232060)
        //                {
        //                    retVal = false;//Foreign key violation
        //                    break;
        //                }
        //                else
        //                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //            }
        //            else break;
        //        }

        //        base.CloseConnection();
        //    }
        //    return retVal;
        //}
              
        //public Boolean Open()
        //{
        //    base.CreateConnection();
        //    this.CreateCommand("RoomOpen");
        //    this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
        //    Int32 ret = this.ExecuteNonQuery();
        //    base.CloseConnection();
        //    if (ret == -2146232060) return false;//Foreign key violation
        //    return ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //}

        //public Boolean UpdateStatus()
        //{
        //    base.CreateConnection();
        //    this.CreateCommand("RoomStatusUpdate");
        //    this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
        //    this.AddInParameter("@StatusId", DbType.Int64, ((Data)this.Data).Status);
        //    Int32 ret = this.ExecuteNonQuery();
        //    base.CloseConnection();
        //    if (ret == -2146232060) return false;//Foreign key violation
        //    return ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //}

        internal List<Data> GetAllCheckedInRoomsForBuilding()
        {
            return this.GetRoomList("Lodge.RoomReadCheckedInRoom");
        }

        internal List<Data> GetReservedRoomsForBuilding()
        {
            return this.GetRoomList("Lodge.RoomReadBookedRoom");
        }

        internal List<Data> GetOpenRoomsForBuilding()
        {
            return this.GetRoomList("Lodge.RoomReadOpenRoom");
        }

        internal List<Data> GetCloseRoomsForBuilding()
        {
            return this.GetRoomList("Lodge.RoomReadClosedRoom");
        }

        private List<Data> GetRoomList(String spName)
        {
            return this.QuerySp(spName, "@BuildingId", (this.Data as Data).Building.Id);
        }

        internal List<Data> IsBuildingDeletable(Building.Data building)
        {
            return this.QuerySp("Lodge.RoomIsBuildingDeletable", "@BuildingId", building.Id);
        }

        internal List<Data> IsRoomCategoryDeletable(Category.Data roomCategory)
        {
            return this.QuerySp("Lodge.RoomIsRoomCategoryDeletable", "@RoomCategoryId", roomCategory.Id);
        }

        internal List<Data> IsRoomTypeDeletable(Type.Data roomType)
        {
            return this.QuerySp("Lodge.RoomIsRoomTypeDeletable", "@TypeId", roomType.Id);
        }

        internal List<Data> IsRoomStatusDeletable(Status.Data roomStatus)
        {
            return this.QuerySp("Lodge.RoomIsRoomStatusDeletable", "@RoomStatusId", roomStatus.Id);
        }

        internal List<Data> IsBuildingFloorDeletable(Building.Floor.Data buildingFloor)
        {
            return this.QuerySp("Lodge.RoomIsBuildingFloorDeletable", "@FloorId", buildingFloor.Id);
        }

        internal List<Data> QuerySp(String spName, String parameterName, Int64 value)
        {
            this.CreateConnection();
            this.CreateCommand(spName);
            this.AddInParameter(parameterName, DbType.Int64, value);
            List<Data> dataList = base.CreateDataObjectList(this.ExecuteDataSet()).ConvertAll((p) => { return p as Data; });
            this.CloseConnection();
            return dataList;
        }
       
    }

}