using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;
using BinAff.Utility;

using ComponentBuilding = Crystal.Lodge.Component.Building;
using ComponentRoom = Crystal.Lodge.Component.Room;

namespace AutoTourism.Lodge.Configuration.Facade.Building
{

    public class Server : IBuilding 
    {

        #region IBuildingType

        ReturnObject<FormDto> IBuilding.LoadForm()
        {
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    BuildingList = this.ReadAllBuilding().Value,
                    TypeList = this.ReadAllBuildingType().Value,
                }
            };

            return ret;
        }

        ReturnObject<Boolean> IBuilding.Add(Dto dto)
        {
            return this.Add(dto);
        }

        ReturnObject<Boolean> IBuilding.Change(Dto dto)
        {
            return this.Change(dto);
        }

        ReturnObject<Boolean> IBuilding.Delete(Dto dto)
        {
            return this.Delete(dto);
        }

        ReturnObject<Boolean> IBuilding.Open(Dto dto)
        {
            return this.Open(dto);
        }

        ReturnObject<Boolean> IBuilding.Close(ReasonDto dto)
        {
            return this.Close(dto);
        }

        ReturnObject<Boolean> IBuilding.CloseWithNoCheck(ReasonDto dto)
        {
            return this.CloseWithNoCheck(dto);
        }


        #endregion

        internal ReturnObject<List<Dto>> ReadAllBuilding()
        {
            ReturnObject<List<Dto>> retObj = new ReturnObject<List<Dto>>();
            ICrud crud = new ComponentBuilding.Server(new ComponentBuilding.Data());
            ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
            {
                return new ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };
            }

            ReturnObject<List<Dto>> ret = new ReturnObject<List<Dto>>
            {
                Value = new List<Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {
                ret.Value.Add(new Dto
                {
                    Id = data.Id,
                    Name = ((ComponentBuilding.Data)data).Name,
                    Type = new Type.Dto
                    {
                        Id = ((ComponentBuilding.Data)data).Type.Id,
                        Name = ((ComponentBuilding.Data)data).Type.Name,
                    },
                    FloorList = GetFloorList(((ComponentBuilding.Data)data).FloorList),
                    Status = new Table{
                        Id = ((ComponentBuilding.Data)data).Status.Id,
                        Name = ((ComponentBuilding.Data)data).Status.Name,
                    },
                    
                    //-- Below code are for second phase implementation
                    //DefaultFloor = ((Crystal.Lodge.Component.Building.Data)data).DefaultFloor,  
                    //IsDefault = ((Crystal.Lodge.Component.Building.Data)data).IsDefault,                    
                });
            }

            return ret;
        }

        private ReturnObject<List<Type.Dto>> ReadAllBuildingType()
        {
            ICrud crud = new ComponentBuilding.Type.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            if (dataList.HasError())
            {
                return new ReturnObject<List<Type.Dto>>
                {
                    MessageList = dataList.MessageList
                };
            }

            ReturnObject<List<Type.Dto>> ret = new ReturnObject<List<Type.Dto>>()
            {
                Value = new List<Type.Dto>() 
            };           

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in dataList.Value)
            {
                ret.Value.Add(new Type.Dto
                {
                    Id = data.Id,
                    Name = ((ComponentBuilding.Type.Data)data).Name
                });
            }
         
            return ret;
        }

        private ReturnObject<Boolean> Add(Dto dto)
        {
            //ICrud organizationCrud = new ComponentOrganization.Server(new ComponentOrganization.Data { Id = 1 });
            //ReturnObject<Data> organizationData = organizationCrud.Read();

            ICrud crud = new ComponentBuilding.Server(new ComponentBuilding.Data
            {
                Name = dto.Name,
                FloorList = GetFloorListForBuildingComponent(dto.FloorList),
                Type = new ComponentBuilding.Type.Data
                {
                    Id = dto.Type.Id,
                    Name = dto.Type.Name,
                },
                //Organization = (ComponentOrganization.Data)organizationData.Value,
                Status = new ComponentBuilding.Status.Data { Id = dto.Status.Id }
                //DefaultFloor = dto.DefaultFloor,
                //IsDefault = dto.IsDefault,
            });

            return crud.Save();            
        }

        private ReturnObject<Boolean> Change(Dto dto)
        {
            ICrud crud = new ComponentBuilding.Server(new ComponentBuilding.Data
            {
                Id = dto.Id,
                Name = dto.Name,
                FloorList = GetFloorListForBuildingComponent(dto.FloorList),
                Type = new ComponentBuilding.Type.Data
                {
                    Id = dto.Type.Id,
                    Name = dto.Type.Name,
                }                
                //DefaultFloor = dto.DefaultFloor,
                //IsDefault = dto.IsDefault,
            });
            return crud.Save();
        }

        private ReturnObject<Boolean> Delete(Dto dto)
        {   
            ////Register Observers
            //Crystal.Lodge.Component.Observer.Building building = new Crystal.Lodge.Component.Observer.Building();

            //BinAff.Core.ICrud crud = building.RegisterObserver(new Crystal.Lodge.Component.Building.Data
            //{
            //    Id = dto.Id
            //});
            //return crud.Delete();

            return null;
        }

        private ReturnObject<Boolean> Close(ReasonDto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            ComponentBuilding.Data data = new ComponentBuilding.Data
            {
                ClosureReasonList = new List<Data>()                
            };
            data.ClosureReasonList.Add(new ComponentBuilding.ClosureReason.Data
            {
                Reason = dto.Reason,               
                //UserId = dto.UserAccount.Id,
            });           

            //validate checkedin rooms.  Cannot close checkedin rooms
            ComponentRoom.IRoom roomServer = new ComponentRoom.Server(new Crystal.Lodge.Component.Room.Data()
            {
                Building = new ComponentBuilding.Data()
                {
                    Id = dto.Building.Id,
                }
            });
            List<ComponentRoom.Data> checkInRoomList = roomServer.GetCheckedInRoomsForBuilding();
            Int32 count = checkInRoomList.Count;
            if (count > 0)
            {
                String msg = "Unable to close building. Following rooms are occupied: ";
                //Show max 4
                for (Int16 i = 0; i < (count > 4 ? 4 : count); i++)
                {
                    msg += checkInRoomList[i].Number;
                    if (i < 3 && i < count - 1) msg += ", ";
                }
                if (count > 4) msg += ",...";
                ret.MessageList = new List<Message>
                {
                    new Message(msg, Message.Type.Error)
                };
                ret.Value = false;
                return ret;
            }

            //validate booked rooms. Notify before closing booked rooms.
            List<ComponentRoom.Data> reservedRoomList = roomServer.GetBookedRoomsForBuilding();
            count = reservedRoomList.Count;
            if (count > 0)
            {
                String msg = "Following rooms are booked in this building : ";
                //Show max 4
                for (Int16 i = 0; i < (count > 4 ? 4 : count); i++)
                {
                    msg += reservedRoomList[i].Number;
                    if (i < 3 && i < count - 1) msg += ", ";
                }
                if (count > 4) msg += ",...";
                msg += "\n\rAre you sure to close the building?";
                ret.MessageList = new List<Message>
                {
                    new Message(msg, Message.Type.Error)
                };
                ret.Value = true;
                return ret;
            }
            
            return CloseWithNoCheck(dto);

        }

        private ReturnObject<Boolean> CloseWithNoCheck(ReasonDto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                //----------
                //-- Close Room
                ComponentRoom.IRoom roomServer = new ComponentRoom.Server(new Crystal.Lodge.Component.Room.Data()
                {
                    Building = new ComponentBuilding.Data()
                    {
                        Id = dto.Building.Id,
                    }
                });
                List<ComponentRoom.Data> checkInRoomList = roomServer.GetOpenRoomsForBuilding();
                Int32 count = checkInRoomList.Count;
                if (count > 0)
                {
                    foreach (ComponentRoom.Data roomData in checkInRoomList)
                    {
                        ComponentRoom.Data roomServerData = new ComponentRoom.Data()
                        {
                            ClosureReasonList = new List<Data>()                            
                        };
                        roomServerData.ClosureReasonList.Add(new ComponentRoom.ClosureReason.Data()
                        {                           
                            Id = roomData.Id,
                            BuildingId = dto.Id,
                            Reason = "Building is closed.",
                            UserId = dto.UserAccount.Id,
                        });

                        ComponentRoom.IRoom crud = new ComponentRoom.Server(roomServerData);
                        ret = crud.Close();
                        if (!ret.Value || ret.HasError()) return ret;
                    }
                }
                //--------------
                //-- Close building
                ComponentBuilding.Data data = new ComponentBuilding.Data
                {
                    ClosureReasonList = new List<Data>(),
                    Id = dto.Building.Id
                };
                data.ClosureReasonList.Add(new ComponentBuilding.ClosureReason.Data
                {
                    Reason = dto.Reason,                   
                    //UserId = dto.UserAccount.Id,
                });

                ComponentBuilding.IBuilding buildingCrud = new ComponentBuilding.Server(data);
                ret = buildingCrud.Close();
                if (!ret.Value || ret.HasError()) return ret;

                T.Complete();
            }

            return ret;
        }

        private ReturnObject<Boolean> Open(Dto dto)
        {
            //open the closed building
            ComponentBuilding.IBuilding crud = new ComponentBuilding.Server(new ComponentBuilding.Data
            {
                Id = dto.Id
            });
            return crud.Open();

            //ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            //using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            //{
            //    //Real all closed rooms
            //    Crystal.Lodge.Configuration.Room.IRoom roomServer = new Crystal.Lodge.Configuration.Room.Server(new Crystal.Lodge.Configuration.Room.Data()
            //    {
            //        Building = new Crystal.Lodge.Configuration.Building.Data()
            //        {
            //            Id = dto.Id,
            //        }
            //    });

            //    List<Crystal.Lodge.Configuration.Room.Data> checkInRoomList = roomServer.GetCloseRoomsForBuilding();
            //    Int32 count = checkInRoomList.Count;

            //    if (count > 0)
            //    {
            //        //open all closed rooms
            //        foreach (Crystal.Lodge.Configuration.Room.Data roomData in checkInRoomList)
            //        {
            //            Crystal.Lodge.Configuration.Room.IRoom roomCrud = new Crystal.Lodge.Configuration.Room.Server(new Crystal.Lodge.Configuration.Room.Data()
            //            {
            //                Id = roomData.Id
            //            });
            //            ret = roomCrud.Open();

            //            if (!ret.Value || ret.HasError()) return ret;
            //        }
            //    }

            //    //open the closed building
            //    Crystal.Lodge.Configuration.Building.IBuilding crud = new Server(new Crystal.Lodge.Configuration.Building.Data
            //    {
            //        Id = dto.Id
            //    });
            //    ret = crud.Open();
            //    if (!ret.Value || ret.HasError()) return ret;

            //    T.Complete();
            //}

            //return ret;
        }

        private List<Table> GetFloorList(List<BinAff.Core.Data> FloorList)
        {
            List<Table> FloorListDto = new List<Table>();
            if (FloorList != null && FloorList.Count > 0)
            {
                foreach (BinAff.Core.Data data in FloorList)
                {
                    ComponentBuilding.Floor.Data floorData = (ComponentBuilding.Floor.Data)data;
                    if (ValidationRule.IsInteger(floorData.Name))
                    {
                        FloorListDto.Add(new Table() {
                            Id = floorData.Id,
                            Name = floorData.Name
                        });
                    }
                        //FloorListDto.Add(Convert.ToInt32(floorData.Name));
                }
            }
            return FloorListDto;
        }

        private List<BinAff.Core.Data> GetFloorListForBuildingComponent(List<Table> FloorList)
        {
            List<BinAff.Core.Data> FloorListData = new List<BinAff.Core.Data>();
            if (FloorList != null && FloorList.Count > 0)
            {
                foreach (Table i in FloorList)
                {
                    FloorListData.Add(new ComponentBuilding.Floor.Data{
                        Name = i.Name
                    });                   
                }
            }
            return FloorListData;
        }
        
    }

}