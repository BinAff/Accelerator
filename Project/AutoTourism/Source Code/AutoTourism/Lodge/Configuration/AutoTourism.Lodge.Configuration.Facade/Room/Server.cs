using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

using CrysComp = Crystal.Lodge.Component.Room;
using BuildingCrys = Crystal.Lodge.Component.Building;
using LodgeObserver = Crystal.Lodge.Observer;

using BuildingFac = AutoTourism.Lodge.Configuration.Facade.Building;

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
            formDto.RoomList = this.ReadAll<Dto>();

            Building.FormDto buildingFormDto = new BuildingFac.FormDto();
            Building.Server buildFacade = new BuildingFac.Server(buildingFormDto);
            buildFacade.LoadForm();

            if (this.DisplayMessageList == null) this.DisplayMessageList = new List<string>();

            this.DisplayMessageList.AddRange(buildFacade.DisplayMessageList);
            formDto.BuildingList = buildingFormDto.DtoList;

            formDto.CategoryList = new Category.Server(null).ReadAll<Category.Dto>();
            formDto.TypeList = new Type.Server(null).ReadAll<Type.Dto>();
        }

        public override void Add()
        {
            CrysComp.Data data = this.Convert((this.FormDto as FormDto).Room) as CrysComp.Data;
            ReturnObject<Boolean> ret = (new CrysComp.Server(data) as ICrud).Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Change()
        {
            CrysComp.Data data = this.Convert((this.FormDto as FormDto).Room) as CrysComp.Data;
            ReturnObject<Boolean> ret = (new CrysComp.Server(data) as ICrud).Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        protected override ICrud AssignComponentServer(Data data)
        {
            return new CrysComp.Server(data as CrysComp.Data);
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrysComp.Data room = data as CrysComp.Data;
            return new Dto
            {
                Id = data.Id,
                Number = room.Number,
                Name = room.Name,
                Description = room.Description,
                Building = new Building.Server(null).Convert(room.Building) as Building.Dto,
                Floor = room.Floor == null ? null : new Table
                {
                    Id = room.Floor.Id,
                    Name = room.Floor.Name
                },
                Category = new Room.Category.Server(null).Convert(room.Category) as Room.Category.Dto,
                Type = new Room.Type.Server(null).Convert(room.Type) as Room.Type.Dto,
                IsAirconditioned = room.IsAirConditioned,
                ImageList = room.ImageList == null ? null : GetImageList(room.ImageList),
                StatusId = room.Status.Id,
                //IsDormitory = room.IsDormitory,
            };
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto room = dto as Dto;
            return new CrysComp.Data
            {
                Id = dto.Id,
                Number = room.Number,
                Name = room.Name,
                Description = room.Description,
                Building = room.Building == null ? null : new BuildingCrys.Data() { Id = room.Building.Id },
                Floor = new BuildingCrys.Floor.Data
                {
                    Id = room.Floor.Id,
                    Name = room.Floor.Name
                },
                Category = room.Category == null ? null : new CrysComp.Category.Data() { Id = room.Category.Id },
                Type = room.Type == null ? null : new CrysComp.Type.Data() { Id = room.Type.Id },
                IsAirConditioned = room.IsAirconditioned,
                Status = new CrysComp.Status.Data
                {
                    Id = room.StatusId
                },
                ImageList = room.ImageList == null ? null : GetImageDataList(room.ImageList),               
            };
        }

        #region IRoom

        ReturnObject<Boolean> IRoom.Delete(Dto dto)
        {
            return this.DeleteRoom(dto);
        }

        ReturnObject<Boolean> IRoom.Open(Dto dto)
        {
            return this.Open(dto);
        }

        ReturnObject<Boolean> IRoom.Close(BuildingFac.ReasonDto dto)
        {
            return this.Close(dto);
        }

        //ReturnObject<Boolean> IRoom.CloseWithNoCheck(BuildingFac.ReasonDto dto)
        //{
        //    return this.CloseWithNoCheck(dto);
        //}

        #endregion

        private List<Image.Dto> GetImageList(List<BinAff.Core.Data> imageList)
        {
            List<Image.Dto> imageDtoList = new List<Image.Dto>();
            foreach (CrysComp.Image.Data data in imageList)
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
               
        private ReturnObject<Boolean> DeleteRoom(Dto dto)
        {           
            CrysComp.Server crud = new CrysComp.Server(new CrysComp.Data
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
                imageDataList.Add(new CrysComp.Image.Data()
                {
                    Id = data.Id,
                    Image = data.Image,
                    Name = data.Name,
                });
            }
            return imageDataList;
        }

        private ReturnObject<Boolean> Close(BuildingFac.ReasonDto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            CrysComp.Data data = new Crystal.Lodge.Component.Room.Data
            {
                Id = dto.Id, //room id
                ClosureReasonList = new List<BinAff.Core.Data>(),
                Building = new BuildingCrys.Data
                {
                    Id = dto.Building.Id
                },
            };
            data.ClosureReasonList.Add(new CrysComp.ClosureReason.Data
            {
                Reason = dto.Reason,
                //UserId = dto.UserAccount.Id,
                BuildingId = dto.Building.Id,

            });

            CrysComp.IRoom crud = new CrysComp.Server(data);

            //validate checkedin rooms.  Cannot close checkedin rooms
            List<CrysComp.Data> checkInRoomList = crud.GetCheckedInRoomsForBuilding();
            if (checkInRoomList.Count > 0)
            {
                foreach (CrysComp.Data checkInData in checkInRoomList)
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
            List<CrysComp.Data> reservedRoomList = crud.GetBookedRoomsForBuilding();
            if (reservedRoomList.Count > 0)
            {
                foreach (CrysComp.Data checkInData in reservedRoomList)
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

        //private ReturnObject<Boolean> CloseWithNoCheck(BuildingFac.ReasonDto dto)
        //{
        //    CrysComp.Data data = new CrysComp.Data()
        //    {
        //        ClosureReasonList = new List<BinAff.Core.Data>(),                
        //    };
        //    data.ClosureReasonList.Add(new CrysComp.ClosureReason.Data()
        //    {               
        //        Reason = dto.Reason,
        //        UserId = dto.UserAccount.Id,
        //    });

        //    CrysComp.IRoom crud = new CrysComp.Server(data);
        //    return crud.Close();
        //}

        private ReturnObject<Boolean> Open(Dto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();

            ICrud buildingCrud = new BuildingCrys.Server(new BuildingCrys.Data() { Id = dto.Building.Id });
            ReturnObject<BinAff.Core.Data> buildingData = buildingCrud.Read();

            //Cannot open open for a building which is closed
            if (((BuildingCrys.Data)buildingData.Value).Status.Id == System.Convert.ToInt64(BuildingStatus.Close))
            {
                ret.MessageList = new List<Message>
                        {
                            new Message("Unable to open the room. Building is closed.", Message.Type.Error)
                        };
                ret.Value = false;
                return ret;
            }

            CrysComp.IRoom crud = new CrysComp.Server(new CrysComp.Data()
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