using System;
using System.Collections.Generic;

using BinAff.Core;

using FacadeBuilding = AutoTourism.Lodge.Configuration.Facade.Building;
using ComponentRoom = Crystal.Lodge.Component.Room;
using ComponentBuilding = Crystal.Lodge.Component.Building;
using LodgeObserver = Crystal.Lodge.Observer;
using BinAff.Core.Observer;

namespace AutoTourism.Lodge.Configuration.Facade.Room
{

    public class Server : BinAff.Facade.Library.Server, IRoom
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.RoomList = this.ReadAllRoom().Value;

            Building.FormDto buildingFormDto = new FacadeBuilding.FormDto();
            Building.Server buildFacade = new FacadeBuilding.Server(buildingFormDto);
            buildFacade.LoadForm();
            this.DisplayMessageList.AddRange(buildFacade.DisplayMessageList);
            formDto.BuildingList = buildingFormDto.DtoList;

            formDto.CategoryList = this.ReadAllCategory().Value;
            formDto.TypeList = this.ReadAllType().Value;
        }

        public override void Add()
        {
            ComponentRoom.Data data = this.Convert((this.FormDto as FormDto).Room) as ComponentRoom.Data;
            ReturnObject<Boolean> ret = (new ComponentRoom.Server(data) as ICrud).Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Change()
        {
            ComponentRoom.Data data = this.Convert((this.FormDto as FormDto).Room) as ComponentRoom.Data;
            ReturnObject<Boolean> ret = (new ComponentRoom.Server(data) as ICrud).Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        protected override BinAff.Facade.Library.Dto Convert(Data data)
        {
            ComponentRoom.Data room = data as ComponentRoom.Data;
            return new Dto
            {
                Id = data.Id,
                Number = room.Number,
                Name = room.Name,
                Description = room.Description,
                Building = new Building.Dto
                {
                    Id = room.Building.Id,
                },
                Floor = room.Floor == null ? null : new Table
                {
                    Id = room.Floor.Id,
                    Name = room.Floor.Name
                },
                Category = new Room.Category.Dto
                {
                    Id = room.Category.Id,
                },
                Type = new Room.Type.Dto
                {
                    Id = room.Type.Id,
                },
                IsAirconditioned = room.IsAirConditioned,
                ImageList = room.ImageList == null ? null : GetImageList(room.ImageList),
                StatusId = room.Status.Id,
                //IsDormitory = room.IsDormitory,
            };
        }

        protected override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto room = dto as Dto;
            return new ComponentRoom.Data
            {
                Id = dto.Id,
                Number = room.Number,
                Name = room.Name,
                Description = room.Description,
                Building = room.Building == null ? null : new ComponentBuilding.Data() { Id = room.Building.Id },
                Floor = new ComponentBuilding.Floor.Data
                {
                    Id = room.Floor.Id,
                    Name = room.Floor.Name
                },
                Category = room.Category == null ? null : new ComponentRoom.Category.Data() { Id = room.Category.Id },
                Type = room.Type == null ? null : new ComponentRoom.Type.Data() { Id = room.Type.Id },
                IsAirConditioned = room.IsAirconditioned,
                Status = new ComponentRoom.Status.Data
                {
                    Id = room.StatusId
                },
                ImageList = room.ImageList == null ? null : GetImageDataList(room.ImageList),               
            };
        }

        #region IBuildingType

        ReturnObject<Boolean> IRoom.Delete(Dto dto)
        {
            return this.DeleteRoom(dto);
        }

        ReturnObject<Boolean> IRoom.Open(Dto dto)
        {
            return this.Open(dto);
        }

        ReturnObject<Boolean> IRoom.Close(FacadeBuilding.ReasonDto dto)
        {
            return this.Close(dto);
        }

        //ReturnObject<Boolean> IRoom.CloseWithNoCheck(FacadeBuilding.ReasonDto dto)
        //{
        //    return this.CloseWithNoCheck(dto);
        //}

        #endregion

        private ReturnObject<List<Dto>> ReadAllRoom()
        {
            ReturnObject<List<Dto>> retObj = new ReturnObject<List<Dto>>();
            ICrud crud = new ComponentRoom.Server(null);
            ReturnObject<List<Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
                return new BinAff.Core.ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };

            ReturnObject<List<Dto>> ret = new ReturnObject<List<Dto>>()
            {
                Value = new List<Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {
                ret.Value.Add(new Dto
                {
                    Id = data.Id,
                    Number = ((ComponentRoom.Data)data).Number,
                    Name = ((ComponentRoom.Data)data).Name,
                    Description = ((ComponentRoom.Data)data).Description,
                    Building = new Building.Dto()
                    {
                        Id = ((ComponentRoom.Data)data).Building.Id,
                    },
                    Floor = ((ComponentRoom.Data)data).Floor == null ? null : new Table()
                    {
                        Id = ((ComponentRoom.Data)data).Floor.Id,
                        Name = ((ComponentRoom.Data)data).Floor.Name
                    },
                    Category = new Room.Category.Dto()
                    {
                        Id = ((ComponentRoom.Data)data).Category.Id,
                    },
                    Type = new Room.Type.Dto()
                    {
                        Id = ((ComponentRoom.Data)data).Type.Id,
                    },
                    IsAirconditioned = ((ComponentRoom.Data)data).IsAirConditioned,
                    ImageList = ((ComponentRoom.Data)data).ImageList == null ? null : GetImageList(((ComponentRoom.Data)data).ImageList),
                    StatusId = ((ComponentRoom.Data)data).Status.Id,
                    //IsDormitory = ((Crystal.Lodge.Component.Room.Data)data).IsDormitory,
                });
            }

            return ret;
        }

        private List<Image.Dto> GetImageList(List<BinAff.Core.Data> imageList)
        {
            List<Image.Dto> imageDtoList = new List<Image.Dto>();
            foreach (ComponentRoom.Image.Data data in imageList)
            {
                imageDtoList.Add(new Image.Dto
                {
                    Id = data.Id,
                    Image = data.Image,
                    Name = data.Name,
                });
            }
            return imageDtoList;
        }

        private List<Int32> GetFloorList(List<Int32> floorList)
        {
            List<Int32> floorDtoList = new List<Int32>();
            foreach (Int32 data in floorList)
            {
                floorDtoList.Add(data);
            }
            return floorDtoList;
        }

        private ReturnObject<List<Room.Category.Dto>> ReadAllCategory()
        {
            ReturnObject<List<Room.Category.Dto>> retObj = new ReturnObject<List<Room.Category.Dto>>();
            ICrud crud = new ComponentRoom.Category.Server(null);
            ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
            {
                return new ReturnObject<List<Room.Category.Dto>>
                {
                    MessageList = lstData.MessageList
                };
            }

            ReturnObject<List<Room.Category.Dto>> ret = new ReturnObject<List<Room.Category.Dto>>()
            {
                Value = new List<Room.Category.Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {
                ret.Value.Add(new Room.Category.Dto
                {
                    Id = data.Id,
                    Name = ((ComponentRoom.Category.Data)data).Name,
                });
            }

            return ret;
        }

        private ReturnObject<List<Room.Type.Dto>> ReadAllType()
        {
            ReturnObject<List<Room.Type.Dto>> retObj = new ReturnObject<List<Room.Type.Dto>>();
            ICrud crud = new ComponentRoom.Type.Server(null);
            ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
            {
                return new ReturnObject<List<Room.Type.Dto>>
                {
                    MessageList = lstData.MessageList
                };
            }

            ReturnObject<List<Room.Type.Dto>> ret = new ReturnObject<List<Room.Type.Dto>>()
            {
                Value = new List<Room.Type.Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {
                ret.Value.Add(new Room.Type.Dto
                {
                    Id = data.Id,
                    Name = ((ComponentRoom.Type.Data)data).Name,
                });
            }

            return ret;
        }
               
        private ReturnObject<Boolean> DeleteRoom(Dto dto)
        {           
            ComponentRoom.Server crud = new ComponentRoom.Server(new ComponentRoom.Data
            {
                Id = dto.Id
            });       
            (new LodgeObserver.Room() as IRegistrar).Register(crud); //Register Observers

            return (crud as ICrud).Delete();

        }
                
        private List<BinAff.Core.Data> GetImageDataList(List<Image.Dto> imageList)
        {
            List<BinAff.Core.Data> imageDataList = new List<BinAff.Core.Data>();
            foreach (Image.Dto data in imageList)
            {
                imageDataList.Add(new ComponentRoom.Image.Data()
                {
                    Id = data.Id,
                    Image = data.Image,
                    Name = data.Name,
                });
            }
            return imageDataList;
        }

        private ReturnObject<Boolean> Close(FacadeBuilding.ReasonDto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            ComponentRoom.Data data = new Crystal.Lodge.Component.Room.Data
            {
                Id = dto.Id, //room id
                ClosureReasonList = new List<BinAff.Core.Data>(),
                Building = new ComponentBuilding.Data
                {
                    Id = dto.Building.Id
                },
            };
            data.ClosureReasonList.Add(new ComponentRoom.ClosureReason.Data
            {
                Reason = dto.Reason,
                //UserId = dto.UserAccount.Id,
                BuildingId = dto.Building.Id,

            });

            ComponentRoom.IRoom crud = new ComponentRoom.Server(data);

            //validate checkedin rooms.  Cannot close checkedin rooms
            List<ComponentRoom.Data> checkInRoomList = crud.GetCheckedInRoomsForBuilding();
            if (checkInRoomList.Count > 0)
            {
                foreach (ComponentRoom.Data checkInData in checkInRoomList)
                {
                    if (checkInData.Id == dto.Id)
                    {
                        ret.MessageList = new List<Message>
                        {
                            new Message("Unable to close the room. This room is already occupied.", Message.Type.Error)
                        };
                        return ret;
                    }
                }
            }

            //validate booked rooms. Notify before closing booked rooms.
            List<ComponentRoom.Data> reservedRoomList = crud.GetBookedRoomsForBuilding();
            if (reservedRoomList.Count > 0)
            {
                foreach (ComponentRoom.Data checkInData in reservedRoomList)
                {
                    if (checkInData.Id == dto.Id)
                    {
                        ret.MessageList = new List<Message>
                        {
                            new Message("This room has reservation. Are you sure to close the room ?", Message.Type.Information)
                        };
                        return ret;
                    }
                }
            }

            return crud.Close();
        }

        //private ReturnObject<Boolean> CloseWithNoCheck(FacadeBuilding.ReasonDto dto)
        //{
        //    ComponentRoom.Data data = new ComponentRoom.Data()
        //    {
        //        ClosureReasonList = new List<BinAff.Core.Data>(),                
        //    };
        //    data.ClosureReasonList.Add(new ComponentRoom.ClosureReason.Data()
        //    {               
        //        Reason = dto.Reason,
        //        UserId = dto.UserAccount.Id,
        //    });

        //    ComponentRoom.IRoom crud = new ComponentRoom.Server(data);
        //    return crud.Close();
        //}

        private ReturnObject<Boolean> Open(Dto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            ICrud buildingCrud = new ComponentBuilding.Server(new ComponentBuilding.Data() { Id = dto.Building.Id });
            ReturnObject<BinAff.Core.Data> buildingData = buildingCrud.Read();

            //Cannot open open for a building which is closed
            if (((ComponentBuilding.Data)buildingData.Value).Status.Id == System.Convert.ToInt64(BuildingStatus.Close))
            {
                ret.MessageList = new List<Message>
                        {
                            new Message("Unable to open the room. Building is closed.", Message.Type.Error)
                        };
                ret.Value = false;
                return ret;
            }

            ComponentRoom.IRoom crud = new ComponentRoom.Server(new ComponentRoom.Data()
            {
                Id = dto.Id
            });

            return crud.Open();
        }

        public enum BuildingStatus
        {
            Open = 10001,
            Close = 10002
        }

    }

}

