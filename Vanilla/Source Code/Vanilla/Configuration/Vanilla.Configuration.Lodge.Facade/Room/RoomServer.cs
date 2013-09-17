using System;
using System.Collections.Generic;

using BinAff.Core;

using Crystal.Lodge.Component.Room;
using AutoTourism.Facade.Library;

namespace AutoTourism.Facade.Configuration.Room
{

    public class RoomServer : IRoom 
    {
        public enum BuildingStatus
        {
            Open = 10001,
            Close = 10002
        }
       
        #region IBuildingType

        ReturnObject<FormDto> IRoom.LoadForm()
        {
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    RoomList = this.ReadAllRoom().Value,
                    BuildingList = this.ReadAllBuilding().Value,
                    CategoryList = this.ReadAllCategory().Value,
                    TypeList = this.ReadAllType().Value,
                }
            };
          
            return ret;     
        }

        ReturnObject<Boolean> IRoom.Add(Dto dto)
        {
            return this.AddRoom(dto);
        }
       
        ReturnObject<Boolean> IRoom.Delete(Dto dto)
        {
            return this.DeleteRoom(dto);
        }

        ReturnObject<Boolean> IRoom.Change(Dto dto)
        {
            return this.ChangeRoom(dto);
        }

        ReturnObject<Boolean> IRoom.Open(Dto dto)
        {
            return this.Open(dto);
        }

        ReturnObject<Boolean> IRoom.Close(ReasonDto dto)
        {
            return this.Close(dto);
        }

        ReturnObject<Boolean> IRoom.CloseWithNoCheck(ReasonDto dto)
        {
            return this.CloseWithNoCheck(dto);
        }

        #endregion
              
        private ReturnObject<List<Dto>> ReadAllRoom()
        {
            BinAff.Core.ReturnObject<List<Dto>> retObj = new BinAff.Core.ReturnObject<List<Dto>>();
            BinAff.Core.ICrud crud = new Crystal.Lodge.Configuration.Room.Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
                return new BinAff.Core.ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };

            BinAff.Core.ReturnObject<List<Dto>> ret = new BinAff.Core.ReturnObject<List<Dto>>()
            {
                Value = new List<Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {                
                ret.Value.Add(new Dto
                {
                    Id = data.Id,
                    Number = ((Crystal.Lodge.Configuration.Room.Data)data).Number,
                    Name = ((Crystal.Lodge.Configuration.Room.Data)data).Name,
                    Description = ((Crystal.Lodge.Configuration.Room.Data)data).Description,
                    Building = new Building.Dto()
                    {
                        Id = ((Crystal.Lodge.Configuration.Room.Data)data).Building.Id,
                    },
                    Floor = ((Crystal.Lodge.Configuration.Room.Data)data).Floor,
                    Category = new RoomCategory.Dto()
                    {
                        Id = ((Crystal.Lodge.Configuration.Room.Data)data).Category.Id,
                    },
                    Type = new RoomType.Dto()
                    {
                        Id = ((Crystal.Lodge.Configuration.Room.Data)data).Type.Id,
                    },
                    IsAirconditioned = ((Crystal.Lodge.Configuration.Room.Data)data).IsAirConditioned,
                    IsDormitory = ((Crystal.Lodge.Configuration.Room.Data)data).IsDormitory,
                    ImageList = ((Crystal.Lodge.Configuration.Room.Data)data).ImageList == null ? null : GetImageList(((Crystal.Lodge.Configuration.Room.Data)data).ImageList),
                    StatusId = ((Crystal.Lodge.Configuration.Room.Data)data).StatusId,
                });                
            }

            return ret;
        }

        private List<ImageDto> GetImageList(List<ImageData> ImageList)
        {
            List<ImageDto> ImageDtoList = new List<ImageDto>();
            foreach (ImageData data in ImageList)
            {
                ImageDtoList.Add(new ImageDto()
                {
                    Id = data.Id,
                    Image = data.Image,       
                    Name = data.Name,
                });
            }
            return ImageDtoList;
        }

        private ReturnObject<List<Building.Dto>> ReadAllBuilding()
        {
            BinAff.Core.ReturnObject<List<Dto>> retObj = new BinAff.Core.ReturnObject<List<Dto>>();
            BinAff.Core.ICrud crud = new Crystal.Lodge.Configuration.Building.Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
                return new BinAff.Core.ReturnObject<List<Building.Dto>>
                {
                    MessageList = lstData.MessageList
                };

            BinAff.Core.ReturnObject<List<Building.Dto>> ret = new BinAff.Core.ReturnObject<List<Building.Dto>>()
            {
                Value = new List<Building.Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {
                ret.Value.Add(new Building.Dto
                {
                    Id = data.Id,                    
                    Name = ((Crystal.Lodge.Configuration.Building.Data)data).Name,
                    DefaultFloor = ((Crystal.Lodge.Configuration.Building.Data)data).DefaultFloor,
                    IsDefault = ((Crystal.Lodge.Configuration.Building.Data)data).IsDefault,
                    Floor = ((Crystal.Lodge.Configuration.Building.Data)data).Floor == null ? null : GetFloorList(((Crystal.Lodge.Configuration.Building.Data)data).Floor),
                    
                });
            }

            return ret;
        }

        private List<Int32> GetFloorList(List<Int32> FloorList)
        {
            List<Int32> FloorDtoList = new List<Int32>();
            foreach (Int32 data in FloorList)
            {
                FloorDtoList.Add(data);
            }
            return FloorDtoList;
        }

        private ReturnObject<List<RoomCategory.Dto>> ReadAllCategory()
        {
            BinAff.Core.ReturnObject<List<RoomCategory.Dto>> retObj = new BinAff.Core.ReturnObject<List<RoomCategory.Dto>>();
            BinAff.Core.ICrud crud = new Crystal.Lodge.Configuration.Room.Category.Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
                return new BinAff.Core.ReturnObject<List<RoomCategory.Dto>>
                {
                    MessageList = lstData.MessageList
                };

            BinAff.Core.ReturnObject<List<RoomCategory.Dto>> ret = new BinAff.Core.ReturnObject<List<RoomCategory.Dto>>()
            {
                Value = new List<RoomCategory.Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {
                ret.Value.Add(new RoomCategory.Dto
                {
                    Id = data.Id,                    
                    Name = ((Crystal.Lodge.Configuration.Room.Category.Data)data).Name,                    
                });
            }

            return ret;
        }

        private ReturnObject<List<RoomType.Dto>> ReadAllType()
        {
            BinAff.Core.ReturnObject<List<RoomType.Dto>> retObj = new BinAff.Core.ReturnObject<List<RoomType.Dto>>();
            BinAff.Core.ICrud crud = new Crystal.Lodge.Configuration.Room.Type.Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
                return new BinAff.Core.ReturnObject<List<RoomType.Dto>>
                {
                    MessageList = lstData.MessageList
                };

            BinAff.Core.ReturnObject<List<RoomType.Dto>> ret = new BinAff.Core.ReturnObject<List<RoomType.Dto>>()
            {
                Value = new List<RoomType.Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {
                ret.Value.Add(new RoomType.Dto
                {
                    Id = data.Id,                    
                    Name = ((Crystal.Lodge.Configuration.Room.Type.Data)data).Name,                   
                });
            }

            return ret;
        }

        private ReturnObject<Boolean> AddRoom(Dto dto)
        {
            ICrud crud = new Crystal.Lodge.Configuration.Room.Server(new Crystal.Lodge.Configuration.Room.Data
            {
                Number = dto.Number,
                Name = dto.Name,
                Description = dto.Description,
                Building = dto.Building == null ? null : new Crystal.Lodge.Configuration.Building.Data() { Id = dto.Building.Id },
                Floor = dto.Floor,
                Category = dto.Category == null ? null : new Crystal.Lodge.Configuration.Room.Category.Data() { Id = dto.Category.Id },
                Type = dto.Type == null ? null : new Crystal.Lodge.Configuration.Room.Type.Data() { Id = dto.Type.Id },
                IsAirConditioned = dto.IsAirconditioned,
                IsDormitory = dto.IsDormitory,

                ImageList = dto.ImageList == null ? null : GetImageDataList(dto.ImageList),
            });
            return crud.Save();
        }

        private ReturnObject<Boolean> DeleteRoom(Dto dto)
        {
            //Register Observers
            Crystal.Lodge.Configuration.Observer.Room room = new Crystal.Lodge.Configuration.Observer.Room();

            BinAff.Core.ICrud crud = room.RegisterObserver(new Crystal.Lodge.Configuration.Room.Data
            {
                Id = dto.Id
            });
            return crud.Delete();

        }

        private ReturnObject<Boolean> ChangeRoom(Dto dto)
        {
            ICrud crud = new Crystal.Lodge.Configuration.Room.Server(new Crystal.Lodge.Configuration.Room.Data
            {
                Id = dto.Id,
                Number = dto.Number,
                Name = dto.Name,
                Description = dto.Description,
                Building = new Crystal.Lodge.Configuration.Building.Data() { Id = dto.Building.Id },
                Floor = dto.Floor,
                Category = new Crystal.Lodge.Configuration.Room.Category.Data() { Id = dto.Category.Id },
                Type = new Crystal.Lodge.Configuration.Room.Type.Data() { Id = dto.Type.Id },
                IsAirConditioned = dto.IsAirconditioned,
                IsDormitory = dto.IsDormitory,

                ImageList = dto.ImageList == null ? null : GetImageDataList(dto.ImageList),
            });
            return crud.Save();
        }

        private List<ImageData> GetImageDataList(List<ImageDto> ImageList)
        {
            List<ImageData> ImageDataList = new List<ImageData>();            
            foreach (ImageDto data in ImageList)
            {
                ImageDataList.Add(new ImageData()
                {
                    Id = data.Id,
                    Image = data.Image,                    
                    Name = data.Name,
                });
            }
            return ImageDataList;
        }

        private ReturnObject<Boolean> Close(ReasonDto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            Crystal.Lodge.Configuration.Room.Data data = new Crystal.Lodge.Configuration.Room.Data()
            {
                ClosureReasonList = new List<ClosureData>(),
                Building = new Crystal.Lodge.Configuration.Building.Data() { Id = dto.BuildingId },
            };
            data.ClosureReasonList.Add(new ClosureData()
            {
                RoomId = dto.Id,
                Reason = dto.Reason,                
                UserId = dto.UserId,                
            });

            Crystal.Lodge.Configuration.Room.IRoom crud = new Crystal.Lodge.Configuration.Room.Server(data);

            //validate checkedin rooms.  Cannot close checkedin rooms
            List<Crystal.Lodge.Configuration.Room.Data> checkInRoomList =  crud.GetCheckedInRoomsForBuilding();
            if (checkInRoomList.Count > 0)
            {
                foreach (Crystal.Lodge.Configuration.Room.Data checkInData in checkInRoomList)
                {
                    if (checkInData.Id == dto.Id)
                    {
                        ret.MessageList = new List<Message>
                        {
                            new Message("Unable to close the room. This room is occupied.", Message.Type.Error)
                        };
                        return ret;
                    }
                }
            }

            //validate booked rooms. Notify before closing booked rooms.
            List<Crystal.Lodge.Configuration.Room.Data> reservedRoomList = crud.GetBookedRoomsForBuilding();
            if (reservedRoomList.Count > 0)
            {
                foreach (Crystal.Lodge.Configuration.Room.Data checkInData in reservedRoomList)
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

        private ReturnObject<Boolean> CloseWithNoCheck(ReasonDto dto)
        {   
            Crystal.Lodge.Configuration.Room.Data data = new Crystal.Lodge.Configuration.Room.Data()
            {
                ClosureReasonList = new List<ClosureData>(),                
            };
            data.ClosureReasonList.Add(new ClosureData()
            {
                RoomId = dto.Id,
                Reason = dto.Reason,
                UserId = dto.UserId,
            });

            Crystal.Lodge.Configuration.Room.IRoom crud = new Crystal.Lodge.Configuration.Room.Server(data);
            return crud.Close();
        }
        
        private ReturnObject<Boolean> Open(Dto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            ICrud buildingCrud = new Crystal.Lodge.Configuration.Building.Server(new Crystal.Lodge.Configuration.Building.Data() { Id = dto.Building.Id });
            ReturnObject<BinAff.Core.Data> buildingData = buildingCrud.Read();

            if (((Crystal.Lodge.Configuration.Building.Data)buildingData.Value).Status.Id == Convert.ToInt64(BuildingStatus.Close))
            {
                ret.MessageList = new List<Message>
                        {
                            new Message("Unable to open the room. Building is closed.", Message.Type.Error)
                        };
                ret.Value = false;
                return ret;
            }

            Crystal.Lodge.Configuration.Room.IRoom crud = new Crystal.Lodge.Configuration.Room.Server(new Crystal.Lodge.Configuration.Room.Data()
            {
                Id = dto.Id
            });
            ret = crud.Open();
            return ret;

        }
                       
    }
}
