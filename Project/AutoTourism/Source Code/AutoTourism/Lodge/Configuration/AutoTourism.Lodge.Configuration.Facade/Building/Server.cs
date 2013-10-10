using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;
using BinAff.Utility;

using CrystalComponent = Crystal.Lodge.Component.Building;
using ComponentRoom = Crystal.Lodge.Component.Room;

namespace AutoTourism.Lodge.Configuration.Facade.Building
{

    public class Server : BinAff.Facade.Library.Server, IBuilding
    {

        public Server(FormDto formDto)
            : base(formDto)
        {
            this.FormDto = formDto;
        }

        #region IBuildingType
        
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

        public override void LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CrystalComponent.Server(null) as ICrud).ReadAll();
            this.DisplayMessageList = dataList.GetMessage((this.IsError = dataList.HasError()) ? Message.Type.Error : Message.Type.Information);

            //Populate data in dto from business entity
            FormDto formDto = this.FormDto as FormDto;
            foreach (CrystalComponent.Data data in dataList.Value)
            {
                formDto.DtoList.Add(this.Convert(data) as Dto);
            }

            //Populate building type list
            Type.FormDto typeFormDto = new Type.FormDto();
            Type.Server typeFacade = new Type.Server(typeFormDto);
            typeFacade.LoadForm();
            this.DisplayMessageList.AddRange(typeFacade.DisplayMessageList);
            formDto.TypeList = typeFormDto.DtoList;
        }

        public override void Add()
        {
            this.Save();
        }

        public override void Change()
        {
            this.Save();
        }

        protected override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrystalComponent.Data value = data as CrystalComponent.Data;
            return new Dto
            {
                Id = data.Id,
                Name = value.Name,
                Type = new Type.Dto
                {
                    Id = value.Type.Id,
                    Name = value.Type.Name,
                },
                FloorList = this.Convert(value.FloorList),
                Status = new Table
                {
                    Id = value.Status.Id,
                    Name = value.Status.Name,
                },

                //-- Below code are for second phase implementation
                //DefaultFloor = value.DefaultFloor,  
                //IsDefault = value.IsDefault,                    
            };
        }

        protected override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto value = dto as Dto;
            return new CrystalComponent.Data
            {
                Id = value.Id,
                Name = value.Name,
                FloorList = Convert(value.FloorList),
                Type = new CrystalComponent.Type.Data
                {
                    Id = value.Type.Id,
                    Name = value.Type.Name,
                },
                Status = new CrystalComponent.Status.Data { Id = value.Status.Id }
                //DefaultFloor = value.DefaultFloor,
                //IsDefault = value.IsDefault,
            };
        }

        private void Save()
        {
            ICrud crud = new CrystalComponent.Server(this.Convert((this.FormDto as FormDto).Dto) as CrystalComponent.Data);
            ReturnObject<Boolean> ret = crud.Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        private List<BinAff.Core.Data> Convert(List<Table> tableList)
        {
            List<BinAff.Core.Data> FloorListData = new List<BinAff.Core.Data>();
            if (tableList != null && tableList.Count > 0)
            {
                foreach (Table i in tableList)
                {
                    FloorListData.Add(new CrystalComponent.Floor.Data
                    {
                        Name = i.Name
                    });
                }
            }
            return FloorListData;
        }

        private List<Table> Convert(List<BinAff.Core.Data> floorList)
        {
            List<Table> FloorListDto = new List<Table>();
            if (floorList != null && floorList.Count > 0)
            {
                foreach (BinAff.Core.Data data in floorList)
                {
                    CrystalComponent.Floor.Data floorData = (CrystalComponent.Floor.Data)data;
                    if (ValidationRule.IsInteger(floorData.Name))
                    {
                        FloorListDto.Add(new Table()
                        {
                            Id = floorData.Id,
                            Name = floorData.Name
                        });
                    }
                }
            }
            return FloorListDto;
        }

        public override void Delete()
        {   
            ////Register Observers
            //Crystal.Lodge.Component.Observer.Building building = new Crystal.Lodge.Component.Observer.Building();

            //BinAff.Core.ICrud crud = building.RegisterObserver(new Crystal.Lodge.Component.Building.Data
            //{
            //    Id = dto.Id
            //});
            //return crud.Delete();

        }

        private ReturnObject<Boolean> Close(ReasonDto reason)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            CrystalComponent.Data data = new CrystalComponent.Data
            {
                ClosureReasonList = new List<Data>()                
            };
            data.ClosureReasonList.Add(new CrystalComponent.ClosureReason.Data
            {
                Reason = reason.Reason,               
                //UserId = dto.UserAccount.Id,
            });           

            //validate checkedin rooms.  Cannot close checkedin rooms
            ComponentRoom.IRoom roomServer = new ComponentRoom.Server(new Crystal.Lodge.Component.Room.Data
            {
                Building = new CrystalComponent.Data()
                {
                    Id = reason.Building.Id,
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
            
            return CloseWithNoCheck(reason);

        }

        private ReturnObject<Boolean> CloseWithNoCheck(ReasonDto reason)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                //----------
                //-- Close Room
                ComponentRoom.IRoom roomServer = new ComponentRoom.Server(new Crystal.Lodge.Component.Room.Data()
                {
                    Building = new CrystalComponent.Data
                    {
                        Id = reason.Building.Id,
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
                            BuildingId = reason.Id,
                            Reason = "Building is closed.",
                            UserId = reason.UserAccount.Id,
                        });

                        ComponentRoom.IRoom crud = new ComponentRoom.Server(roomServerData);
                        ret = crud.Close();
                        if (!ret.Value || ret.HasError()) return ret;
                    }
                }
                //--------------
                //-- Close building
                CrystalComponent.Data data = new CrystalComponent.Data
                {
                    ClosureReasonList = new List<Data>(),
                    Id = reason.Building.Id
                };
                data.ClosureReasonList.Add(new CrystalComponent.ClosureReason.Data
                {
                    Reason = reason.Reason,                   
                    //UserId = dto.UserAccount.Id,
                });

                CrystalComponent.IBuilding buildingCrud = new CrystalComponent.Server(data);
                ret = buildingCrud.Close();
                if (!ret.Value || ret.HasError()) return ret;

                T.Complete();
            }

            return ret;
        }

        private ReturnObject<Boolean> Open(Dto dto)
        {
            //open the closed building
            CrystalComponent.IBuilding crud = new CrystalComponent.Server(new CrystalComponent.Data
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
        
    }

}