using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;
using BinAff.Utility;

using CrystalComponent = Crystal.Lodge.Component.Building;
using ComponentRoom = Crystal.Lodge.Component.Room;
using BinAff.Core.Observer;

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
        
        void IBuilding.Open()
        {
            this.Open();
        }

        void IBuilding.Close(ReasonDto dto)
        {
            this.Close(dto);
        }

        void IBuilding.CloseWithNoCheck(ReasonDto dto)
        {
            this.CloseWithNoCheck(dto);
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
            Type.Server typeFacade = new Type.Server(new Type.FormDto
            {
                DtoList = formDto.TypeList
            });
            typeFacade.LoadForm();
            this.DisplayMessageList.AddRange(typeFacade.DisplayMessageList);
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
                FloorList = this.Convert(value.FloorList),
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
            CrystalComponent.Server crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Id = (this.FormDto as FormDto).Dto.Id
            });
            (new Crystal.Lodge.Observer.RoomType() as IRegistrar).Register(crud); //Register Observers

            ReturnObject<Boolean> ret = (crud as ICrud).Delete();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        private void Close(ReasonDto reason)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            #region Commented by Arpan... Not sure what is happening here
            //CrystalComponent.Data data = new CrystalComponent.Data
            //{
            //    ClosureReasonList = new List<Data>()                
            //};
            //data.ClosureReasonList.Add(new CrystalComponent.ClosureReason.Data
            //{
            //    Reason = reason.Reason,               
            //    //UserId = dto.UserAccount.Id,
            //});
            #endregion

            ret = this.CheckForCheckIn(reason);
            if (ret.Value) //Rooms are not checked in
            {
                ret = this.CheckForReservation(reason);
                if (ret.Value) //Rooms are not reserved
                {
                    ret = this.CloseInternal(reason);
                }
            }
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        /// <summary>
        /// Validate the room is occupied or not
        /// </summary>
        /// <param name="checkInRoomList"></param>
        /// <returns></returns>
        private ReturnObject<Boolean> CheckForCheckIn(ReasonDto reason)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            ComponentRoom.IRoom roomServer = new ComponentRoom.Server(new Crystal.Lodge.Component.Room.Data
            {
                Building = new CrystalComponent.Data
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
            }
            ret.Value = !ret.HasError();
            return ret;
        }

        private ReturnObject<Boolean> CheckForReservation(ReasonDto reason)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            //validate booked rooms. Notify before closing booked rooms.
            ComponentRoom.IRoom roomServer = new ComponentRoom.Server(new Crystal.Lodge.Component.Room.Data
            {
                Building = new CrystalComponent.Data
                {
                    Id = reason.Building.Id,
                }
            });
            List<ComponentRoom.Data> reservedRoomList = roomServer.GetBookedRoomsForBuilding();
            Int32 count = reservedRoomList.Count;
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
            }
            ret.Value = !ret.HasError();
            return ret;
        }

        private ReturnObject<Boolean> CloseInternal(ReasonDto reason)
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
            ret.Value = !ret.HasError();
            return ret;
        }

        private void CloseWithNoCheck(ReasonDto reason)
        {
            ReturnObject<Boolean> ret = this.CloseInternal(reason);
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        private void Open()
        {
            //open the closed building
            CrystalComponent.IBuilding crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Id = (this.FormDto as FormDto).Dto.Id
            });
            ReturnObject<Boolean> ret = crud.Open();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            
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