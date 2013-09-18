using System;
using System.Collections.Generic;

using BinAff.Core;

//using Room = Crystal.Lodge.Component.Room;
using Vanilla.Configuration.Lodge.Facade.Building;
//using AutoTourism.Facade.Library;

namespace Vanilla.Configuration.Lodge.Facade.Room
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
            BinAff.Core.ICrud crud = new Crystal.Lodge.Component.Room.Server(null);
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
                    Number = ((Crystal.Lodge.Component.Room.Data)data).Number,
                    Name = ((Crystal.Lodge.Component.Room.Data)data).Name,
                    Description = ((Crystal.Lodge.Component.Room.Data)data).Description,
                    Building = new Building.Dto()
                    {
                        Id = ((Crystal.Lodge.Component.Room.Data)data).Building.Id,
                    },
                    //Floor = ((Crystal.Lodge.Component.Room.Data)data).Floor,
                    Category = new RoomCategory.Dto()
                    {
                        Id = ((Crystal.Lodge.Component.Room.Data)data).Category.Id,
                    },
                    Type = new RoomType.Dto()
                    {
                        Id = ((Crystal.Lodge.Component.Room.Data)data).Type.Id,
                    },
                    IsAirconditioned = ((Crystal.Lodge.Component.Room.Data)data).IsAirConditioned,
                    //IsDormitory = ((Crystal.Lodge.Component.Room.Data)data).IsDormitory,
                    //ImageList = ((Crystal.Lodge.Component.Room.Data)data).ImageList == null ? null : GetImageList(((Crystal.Lodge.Component.Room.Data)data).ImageList),
                    //StatusId = ((Crystal.Lodge.Component.Room.Data)data).StatusId,
                });                
            }

            return ret;
        }

        private List<ImageDto> GetImageList(List<Crystal.Lodge.Component.Room.Image.Data> ImageList)
        {
            List<ImageDto> ImageDtoList = new List<ImageDto>();
            foreach (Crystal.Lodge.Component.Room.Image.Data data in ImageList)
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
            BinAff.Core.ICrud crud = new Crystal.Lodge.Component.Building.Server(null);
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
                    Name = ((Crystal.Lodge.Component.Building.Data)data).Name,
                    //DefaultFloor = ((Crystal.Lodge.Component.Building.Data)data).DefaultFloor,
                    //IsDefault = ((Crystal.Lodge.Component.Building.Data)data).IsDefault,
                    //Floor = ((Crystal.Lodge.Component.Building.Data)data).Floor == null ? null : GetFloorList(((Crystal.Lodge.Configuration.Building.Data)data).Floor),
                    
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
            BinAff.Core.ICrud crud = new Crystal.Lodge.Component.Room.Category.Server(null);
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
                    Name = ((Crystal.Lodge.Component.Room.Category.Data)data).Name,                    
                });
            }

            return ret;
        }

        private ReturnObject<List<RoomType.Dto>> ReadAllType()
        {
            BinAff.Core.ReturnObject<List<RoomType.Dto>> retObj = new BinAff.Core.ReturnObject<List<RoomType.Dto>>();
            BinAff.Core.ICrud crud = new Crystal.Lodge.Component.Room.Type.Server(null);
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
                    Name = ((Crystal.Lodge.Component.Room.Type.Data)data).Name,                   
                });
            }

            return ret;
        }

        private ReturnObject<Boolean> AddRoom(Dto dto)
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data
            {
                Number = dto.Number,
                Name = dto.Name,
                Description = dto.Description,
                Building = dto.Building == null ? null : new Crystal.Lodge.Component.Building.Data() { Id = dto.Building.Id },
                //Floor = dto.Floor,
                Category = dto.Category == null ? null : new Crystal.Lodge.Component.Room.Category.Data() { Id = dto.Category.Id },
                Type = dto.Type == null ? null : new Crystal.Lodge.Component.Room.Type.Data() { Id = dto.Type.Id },
                IsAirConditioned = dto.IsAirconditioned,
                //IsDormitory = dto.IsDormitory,

                //ImageList = dto.ImageList == null ? null : GetImageDataList(dto.ImageList),
            });
            return crud.Save();
        }

        private ReturnObject<Boolean> DeleteRoom(Dto dto)
        {
            //Register Observers
            //Crystal.Lodge.Component.Observer.Room room = new Crystal.Lodge.Component.Observer.Room();

            //BinAff.Core.ICrud crud = room.RegisterObserver(new Crystal.Lodge.Component.Room.Data
            //{
            //    Id = dto.Id
            //});
            //return crud.Delete();
            return null;

        }

        private ReturnObject<Boolean> ChangeRoom(Dto dto)
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data
            {
                Id = dto.Id,
                Number = dto.Number,
                Name = dto.Name,
                Description = dto.Description,
                Building = new Crystal.Lodge.Component.Building.Data() { Id = dto.Building.Id },
                //Floor = dto.Floor,
                Category = new Crystal.Lodge.Component.Room.Category.Data() { Id = dto.Category.Id },
                Type = new Crystal.Lodge.Component.Room.Type.Data() { Id = dto.Type.Id },
                IsAirConditioned = dto.IsAirconditioned,
                //IsDormitory = dto.IsDormitory,

                //ImageList = dto.ImageList == null ? null : GetImageDataList(dto.ImageList),
            });
            return crud.Save();
        }

        private List<Crystal.Lodge.Component.Room.Image.Data> GetImageDataList(List<ImageDto> ImageList)
        {
            List<Crystal.Lodge.Component.Room.Image.Data> ImageDataList = new List<Crystal.Lodge.Component.Room.Image.Data>();            
            foreach (ImageDto data in ImageList)
            {
                ImageDataList.Add(new Crystal.Lodge.Component.Room.Image.Data()
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

            Crystal.Lodge.Component.Room.Data data = new Crystal.Lodge.Component.Room.Data()
            {
                //ClosureReasonList = new List<ClosureData>(),
                //Building = new Crystal.Lodge.Component.Building.Data() { Id = dto.Building.Id },
            };
            //data.ClosureReasonList.Add(new ClosureData()
            //{
            //    RoomId = dto.Id,
            //    Reason = dto.Reason,                
            //    UserId = dto.UserId,                
            //});

            Crystal.Lodge.Component.Room.IRoom crud = new Crystal.Lodge.Component.Room.Server(data);

            //validate checkedin rooms.  Cannot close checkedin rooms
            List<Crystal.Lodge.Component.Room.Data> checkInRoomList = crud.GetCheckedInRoomsForBuilding();
            if (checkInRoomList.Count > 0)
            {
                foreach (Crystal.Lodge.Component.Room.Data checkInData in checkInRoomList)
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
            List<Crystal.Lodge.Component.Room.Data> reservedRoomList = crud.GetBookedRoomsForBuilding();
            if (reservedRoomList.Count > 0)
            {
                foreach (Crystal.Lodge.Component.Room.Data checkInData in reservedRoomList)
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
            Crystal.Lodge.Component.Room.Data data = new Crystal.Lodge.Component.Room.Data()
            {
                //ClosureReasonList = new List<ClosureData>(),                
            };
            //data.ClosureReasonList.Add(new ClosureData()
            //{
            //    RoomId = dto.Id,
            //    Reason = dto.Reason,
            //    UserId = dto.UserAccount.Id,
            //});

            Crystal.Lodge.Component.Room.IRoom crud = new Crystal.Lodge.Component.Room.Server(data);
            return crud.Close();
        }
        
        private ReturnObject<Boolean> Open(Dto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            ICrud buildingCrud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data() { Id = dto.Building.Id });
            ReturnObject<BinAff.Core.Data> buildingData = buildingCrud.Read();

            if (((Crystal.Lodge.Component.Building.Data)buildingData.Value).Status.Id == Convert.ToInt64(BuildingStatus.Close))
            {
                ret.MessageList = new List<Message>
                        {
                            new Message("Unable to open the room. Building is closed.", Message.Type.Error)
                        };
                ret.Value = false;
                return ret;
            }

            Crystal.Lodge.Component.Room.IRoom crud = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data()
            {
                Id = dto.Id
            });
            ret = crud.Open();
            return ret;

        }
                       
    }
}
