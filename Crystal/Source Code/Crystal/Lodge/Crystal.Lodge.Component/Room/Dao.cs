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
            base.CreateStoredProcedure = "[Lodge].[RoomInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Lodge].[RoomRead]";
            base.ReadAllStoredProcedure = "[Lodge].[RoomReadAll]";
            base.UpdateStoredProcedure = "[Lodge].[RoomUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Lodge].[RoomDelete]";
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
            base.AddInParameter("@StatusId", DbType.Int64, ((Data)this.Data).Status.Id);
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
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]),
                        Category = new Category.Data()
                        {
                            Id = Convert.IsDBNull(row["CategoryId"]) ? 0 : Convert.ToInt32(row["CategoryId"])
                        },
                        Type = new Type.Data()
                        {
                            Id = Convert.IsDBNull(row["TypeId"]) ? 0 : Convert.ToInt32(row["TypeId"])
                        },
                        Building = new Building.Data()
                        {
                            Id = Convert.IsDBNull(row["BuildingId"]) ? 0 : Convert.ToInt32(row["BuildingId"])
                        },
                        Floor = new Building.Floor.Data()
                        {
                            Id = Convert.IsDBNull(row["FloorId"]) ? 0 : Convert.ToInt32(row["FloorId"])
                        },
                        IsAirConditioned = Convert.IsDBNull(row["IsAirConditioned"]) ? false : Convert.ToBoolean(row["IsAirConditioned"]),
                        Status = new Status.Data
                        {
                            Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"])
                        },
                    });
                }
            }
            return ret;
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            //Data dt = (Data)data;
            Data dt = (Data)base.CreateDataObject(ds, data);
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];               

                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                //dt.Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]);
                //dt.Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]);
                //dt.Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]);
                dt.Category = new Category.Data()
                {
                    Id = Convert.IsDBNull(row["CategoryId"]) ? 0 : Convert.ToInt32(row["CategoryId"])
                };
                dt.Type = new Type.Data() {
                    Id = Convert.IsDBNull(row["TypeId"]) ? 0 : Convert.ToInt32(row["TypeId"])
                };
                dt.Building = new Building.Data() {
                    Id = Convert.IsDBNull(row["BuildingId"]) ? 0 : Convert.ToInt32(row["BuildingId"])
                };
                dt.Floor = new Building.Floor.Data() {
                    Id = Convert.IsDBNull(row["FloorId"]) ? 0 : Convert.ToInt32(row["FloorId"])
                };
                dt.IsAirConditioned = Convert.IsDBNull(row["IsAirConditioned"]) ? false : Convert.ToBoolean(row["IsAirConditioned"]);
              
                dt.Status = new Status.Data
                {
                    Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"])
                };
            }
            return dt;
        }

        public Boolean ModifyStatus(Int64 StatusId)
        {
            Boolean retVal = true;
            Data data = (Data)this.Data;

            base.CreateConnection();
            this.CreateCommand("[Lodge].[RoomModifyStatus]");
            this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
            this.AddInParameter("@StatusId", DbType.Int64, StatusId);
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

        public List<Data> GetAllCheckedInRoomsForBuilding()
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("RoomReadCheckedInRoom");
            this.AddInParameter("@BuildingId", DbType.Int64, ((Data)this.Data).Building.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> GetReservedRoomsForBuilding()
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("RoomReadBookedRoom");
            this.AddInParameter("@BuildingId", DbType.Int64, ((Data)this.Data).Building.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> GetOpenRoomsForBuilding()
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("RoomReadOpenRoom");
            this.AddInParameter("@BuildingId", DbType.Int64, ((Data)this.Data).Building.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                        //Status = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"]),
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> GetCloseRoomsForBuilding()
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("RoomReadCloseRoom");
            this.AddInParameter("@BuildingId", DbType.Int64, ((Data)this.Data).Building.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),                        
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> IsBuildingDeletable(Crystal.Lodge.Component.Building.Data building)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsRoomBuildingDeletable]");
            this.AddInParameter("@BuildingId", DbType.Int64, building.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> IsRoomCategoryDeletable(Crystal.Lodge.Component.Room.Category.Data roomCategory)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsRoomCategoryDeletable]");
            this.AddInParameter("@RoomCategoryId", DbType.Int64, roomCategory.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> IsRoomTypeDeletable(Crystal.Lodge.Component.Room.Type.Data roomType)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsRoomTypeDeletable]");
            this.AddInParameter("@TypeId", DbType.Int64, roomType.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> IsRoomStatusDeletable(Crystal.Lodge.Component.Room.Status.Data roomStatus)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsRoomStatusDeletable]");
            this.AddInParameter("@RoomStatusId", DbType.Int64, roomStatus.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> IsBuildingFloorDeletable(Crystal.Lodge.Component.Building.Floor.Data buildingFloor)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsBuildingFloorDeletable]");
            this.AddInParameter("@FloorId", DbType.Int64, buildingFloor.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]),
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }
       
    }

}
