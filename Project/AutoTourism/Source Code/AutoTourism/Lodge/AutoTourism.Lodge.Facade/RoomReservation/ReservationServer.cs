using System;
using System.Collections.Generic;

using BinAff.Core;

using CrystalLodge = Crystal.Lodge.Component;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using CrystalReservation = Crystal.Reservation.Component;
using CrystalCustomer = Crystal.Customer.Component;
using AutoCustomer = AutoTourism.Component.Customer;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class ReservationServer : BinAff.Facade.Library.Server, IReservation
    {
        //-- RoomStaus ID is mapped with database table RoomReservationStatus
        public enum RoomStatus
        {
            Open = 10001,
            Close = 10002,
            Cancel = 10003,
            CheckIn = 10004,
            Modify = 10005
        }

        public ReservationServer(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.roomList = this.ReadAllRoom().Value;
            formDto.configurationRuleDto = this.ReadConfigurationRule().Value;
            formDto.CategoryList = new LodgeConfigurationFacade.Room.Server(null).ReadAllCategory().Value;
            formDto.TypeList = new LodgeConfigurationFacade.Room.Server(null).ReadAllType().Value;

            if (formDto.Dto != null && formDto.Dto.Id > 0)
                formDto.Dto.Customer = this.GetCustomerDtoForReservation(formDto.Dto.Id);
            //{                
            //    //AutoCustomer.ICustomer autoCustomer = new AutoCustomer.Server(null);
            //    //formDto.Dto.Customer = ConvertToCustomerDto(autoCustomer.GetCustomerForReservation(formDto.Dto.Id));
            //}
        }

        public Customer.Facade.Dto GetCustomerDtoForReservation(Int64 reservationId)
        {
            AutoCustomer.ICustomer autoCustomer = new AutoCustomer.Server(null);
            return ConvertToCustomerDto(autoCustomer.GetCustomerForReservation(reservationId));
        }

        public Customer.Facade.Dto ConvertToCustomerDto(Crystal.Customer.Component.Data customerData)
        {
            BinAff.Facade.Library.Dto dto = new AutoTourism.Customer.Facade.Server(null).Convert(customerData);
            return dto as Customer.Facade.Dto;
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CrystalLodge.Room.Reservation.Data reservation = data as CrystalLodge.Room.Reservation.Data;
            return new Dto
            {
                Id = data.Id,
                NoOfDays = reservation.NoOfDays,
                NoOfPersons = reservation.NoOfPersons,
                NoOfRooms = reservation.NoOfRooms,
                BookingFrom = reservation.ActivityDate,
                Advance = reservation.Advance,                
                BookingStatusId = reservation.Status.Id,
                RoomList = reservation.ProductList == null ? null : GetRoomDtoList(reservation.ProductList),
                RoomCategory = reservation.RoomCategory == null ? null : new Table { Id = reservation.RoomCategory.Id },
                RoomType = reservation.RoomType == null ? null : new Table { Id = reservation.RoomType.Id },
                //IsAC = reservation.IsAC,
                ACPreference = reservation.ACPreference,
                BookingDate = reservation.Date,
                isCheckedIn = reservation.IsCheckedIn
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {            
            Dto reservation = dto as Dto;
            return new CrystalLodge.Room.Reservation.Data
            {
                Id = dto.Id,
                NoOfDays = reservation.NoOfDays,
                NoOfPersons = reservation.NoOfPersons,
                NoOfRooms = reservation.NoOfRooms,
                Advance = reservation.Advance,
                ActivityDate = reservation.BookingFrom,
                Date = DateTime.Now,
                ProductList = reservation.RoomList == null ? null : GetRoomDataList(reservation.RoomList),
                Status = new Crystal.Customer.Component.Action.Status.Data
                {
                    Id = System.Convert.ToInt64(RoomStatus.Open)
                },
                Description = String.Empty,//description will be added later if required
                RoomCategory = reservation.RoomCategory == null ? null : new CrystalLodge.Room.Category.Data { Id = reservation.RoomCategory.Id },
                RoomType = reservation.RoomType == null ? null : new CrystalLodge.Room.Type.Data { Id = reservation.RoomType.Id },
                ACPreference = reservation.ACPreference
            };
        }

        private ReturnObject<RuleFacade.ConfigurationRuleDto> ReadConfigurationRule()
        {
            return new RuleFacade.RuleServer().ReadConfigurationRule();
        }
        
        private ReturnObject<List<LodgeConfigurationFacade.Room.Dto>> ReadAllRoom()
        {
            return new LodgeConfigurationFacade.Room.Server(null).ReadAllRoom();
        }

        public override void Add()
        {
            this.Save();
        }

        public override void Change()
        {
            this.Save();
        }

        private void Save()
        {
            Dto reservationDto = (this.FormDto as FormDto).Dto;

            AutoTourism.Component.Customer.Data autoCustomer = new Component.Customer.Data() 
            { 
                Id = reservationDto.Customer.Id,
                FirstName = reservationDto.Customer.FirstName,
                MiddleName = reservationDto.Customer.MiddleName,
                LastName = reservationDto.Customer.LastName,
                Address = reservationDto.Customer.Address,
                City = reservationDto.Customer.City,
                Pin = reservationDto.Customer.Pin,
                Email = reservationDto.Customer.Email,
                IdentityProof = reservationDto.Customer.IdentityProofName == null ? String.Empty : reservationDto.Customer.IdentityProofName,
                State = new Crystal.Configuration.Component.State.Data
                {
                    Id = reservationDto.Customer.State.Id,
                    Name = reservationDto.Customer.State.Name
                },
                ContactNumberList = this.ConvertToContactNumberData(reservationDto.Customer.ContactNumberList),
                Initial = new Crystal.Configuration.Component.Initial.Data
                {
                    Id = reservationDto.Customer.Initial.Id,
                    Name = reservationDto.Customer.Initial.Name
                },
                IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data
                {
                    Id = reservationDto.Customer.IdentityProofType.Id,
                    Name = reservationDto.Customer.IdentityProofType.Name
                },
                RoomReserver = new CrystalLodge.Room.Reserver.Data()
            };

            autoCustomer.RoomReserver.Active = this.Convert(reservationDto) as CrystalCustomer.Action.Data;
            autoCustomer.RoomReserver.Active.ProductList = reservationDto.RoomList == null ? null : this.GetRoomDataList(reservationDto.RoomList);

            ICrud crud = new AutoTourism.Component.Customer.Server(autoCustomer);
            ReturnObject<Boolean> ret = crud.Save();

            if (autoCustomer.RoomReserver.Active != null)
                (this.FormDto as FormDto).Dto.Id = autoCustomer.RoomReserver.Active.Id;

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);           
        }

        public List<CrystalCustomer.ContactNumber.Data> ConvertToContactNumberData(List<Table> contactNumberList)
        {
            List<CrystalCustomer.ContactNumber.Data> lstContactNumber = new List<CrystalCustomer.ContactNumber.Data>();
            if (contactNumberList != null && contactNumberList.Count > 0)
            {
                foreach (Table table in contactNumberList)
                {
                    lstContactNumber.Add(new CrystalCustomer.ContactNumber.Data 
                    { 
                        Id = table.Id,
                        ContactNumber = table.Name
                    });
                }
            }

            return lstContactNumber;
        }

        public List<Data> GetRoomDataList(List<LodgeConfigurationFacade.Room.Dto> RoomList)
        {
            List<Data> RoomDataList = new List<Data>();
            foreach (LodgeConfigurationFacade.Room.Dto dto in RoomList)
            {
                RoomDataList.Add(new CrystalLodge.Room.Data
                {
                    Id = dto.Id,
                    Number = dto.Number,
                });
            }
            return RoomDataList;
        }

        public List<LodgeConfigurationFacade.Room.Dto> GetRoomDtoList(List<Data> RoomList)
        {
            List<LodgeConfigurationFacade.Room.Dto> RoomDtoList = new List<LodgeConfigurationFacade.Room.Dto>();
            foreach (CrystalLodge.Room.Data data in RoomList)
            {
                RoomDtoList.Add(new LodgeConfigurationFacade.Room.Dto
                {
                    Id = data.Id,
                    Number = data.Number,
                    Name = data.Name
                });
            }
            return RoomDtoList;
        }

        private ReturnObject<List<Dto>> GetCustomerBooking(Int64 customerId)
        {
            List<Dto> bookingList = new List<Dto>();

            //Crystal.Lodge.Reservation.IReservation reservation = new Server(new Crystal.Lodge.Reservation.Data
            //{
            //    Customer = new Crystal.CustomerManagement.Data()
            //    {
            //        Id = customerId,
            //    },
            //});

            //ReturnObject<List<BinAff.Core.Data>> reservationDataList = reservation.GetBooking();

        //    foreach (BinAff.Core.Data data in reservationDataList.Value)
        //    {
        //        bookingList.Add(new Dto()
        //        {
        //            Id = data.Id,
        //            BookingDate = ((Crystal.Lodge.Reservation.Data)data).BookingDate,
        //            BookingFrom = ((Crystal.Lodge.Reservation.Data)data).BookingFrom,
        //            NoOfDays = ((Crystal.Lodge.Reservation.Data)data).NoOfDays,
        //            NoOfPersons = ((Crystal.Lodge.Reservation.Data)data).NoOfPersons,
        //            NoOfRooms = ((Crystal.Lodge.Reservation.Data)data).NoOfRooms,
        //            Advance = ((Crystal.Lodge.Reservation.Data)data).Advance,
        //            BookingStatusId = ((Crystal.Lodge.Reservation.Data)data).BookingStatusId,
        //            RoomList = GetRoomDtoList(((Crystal.Lodge.Reservation.Data)data).RoomList),
        //        });
        //    }

            return new ReturnObject<List<Dto>>()
            {
                Value = bookingList,
            };

        }        

        ReturnObject<bool> IReservation.ChangeReservationStatus()
        {
            return this.UpdateReservationStatus();
        }

        private ReturnObject<Boolean> UpdateReservationStatus()
        {
            Dto reservationDto = (this.FormDto as FormDto).Dto;

            CrystalCustomer.Action.IAction roomReservation = new CrystalLodge.Room.Reservation.Server(new CrystalLodge.Room.Reservation.Data 
            {
                Id = reservationDto.Id,
                Status = new CrystalCustomer.Action.Status.Data
                {
                    Id = reservationDto.BookingStatusId
                }            
            });
            return roomReservation.UpdateStatus();
        }

        public void SaveArtifactForReservation(Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            Vanilla.Utility.Facade.Module.Dto reservationModuleDto = new Vanilla.Utility.Facade.Module.Server(null).GetModule("LRSV", (this.FormDto as FormDto).ModuleFormDto.FormModuleList);
            String fileName = new Vanilla.Utility.Facade.Artifact.Server(null).GetArtifactName(reservationModuleDto.Artifact, Vanilla.Utility.Facade.Artifact.Type.Document, "Form");         
            artifactDto.FileName = fileName;

            if (reservationModuleDto != null)
                reservationModuleDto.Artifact.Children.Add(artifactDto);

            (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Vanilla.Utility.Facade.Artifact.FormDto
            {
                Dto = artifactDto
            };

            (this.FormDto as FormDto).ModuleFormDto.Dto = reservationModuleDto;
            Vanilla.Utility.Facade.Module.Server moduleFacade = new Vanilla.Utility.Facade.Module.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();
                       
        }
        
        ReturnObject<List<LodgeConfigurationFacade.Room.Dto>> IReservation.GetBookedRooms(DateTime startDate, DateTime endDate)
        {
            Crystal.Customer.Component.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, startDate, endDate);

            List<LodgeConfigurationFacade.Room.Dto> lstRoomDto = new List<LodgeConfigurationFacade.Room.Dto>();

            if (ret.Value != null)
            {
                foreach (Crystal.Customer.Component.Action.Data roomData in ret.Value)
                {
                    if (roomData.ProductList != null && roomData.ProductList.Count > 0)
                    {
                        foreach(CrystalLodge.Room.Data data in roomData.ProductList)
                            lstRoomDto.Add(new LodgeConfigurationFacade.Room.Dto { Id = data.Id });
                    }
                }
            }

            return new ReturnObject<List<LodgeConfigurationFacade.Room.Dto>>
            {
                Value = lstRoomDto
            };
        }
        
        Boolean IReservation.ValidateRoomWithCategoryTypeAndACPreference(LodgeConfigurationFacade.Room.Dto room, long categoryId, long typeId, int acPreference)
        {
            return this.ValidateRoomWithCategoryTypeAndACPreference(room, categoryId, typeId, acPreference);
        }

        List<LodgeConfigurationFacade.Room.Dto> IReservation.GetFilteredRoomsWithCategoryTypeAndACPreference(List<LodgeConfigurationFacade.Room.Dto> roomList, long categoryId, long typeId, int acPreference)
        {
            List<LodgeConfigurationFacade.Room.Dto> lstRoom = new List<LodgeConfigurationFacade.Room.Dto>();

            foreach (LodgeConfigurationFacade.Room.Dto room in roomList)
            {
                if (this.ValidateRoomWithCategoryTypeAndACPreference(room, categoryId, typeId, acPreference))
                    lstRoom.Add(room);
            }

            return lstRoom;
        }
        
        Int32 IReservation.GetNoOfRoomsBookedBetweenTwoDates(DateTime startDate, DateTime endDate, Int64 reservationId)
        {
            int retVal = 0;
            Crystal.Customer.Component.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, startDate, endDate);

            if (ret.Value != null && ret.Value.Count > 0)
            {
                List<Crystal.Customer.Component.Action.Data> actionList = this.RemoveDuplicateReservation(ret.Value);
                foreach (CrystalLodge.Room.Reservation.Data reservationData in actionList)
                {
                    if (reservationData.Id != reservationId)
                        retVal += reservationData.NoOfRooms;
                }
            }

            return retVal;          
        }

        Int32 IReservation.GetNoOfRoomsBookedBetweenTwoDates(DateTime startDate, DateTime endDate, long reservationId, long categoryId, long typeId, int acPreference)
        {
            int retVal = 0;
            Crystal.Customer.Component.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, startDate, endDate);

            if (ret.Value != null && ret.Value.Count > 0)
            {
                List<Crystal.Customer.Component.Action.Data> actionList = this.RemoveDuplicateReservation(ret.Value);
                foreach (CrystalLodge.Room.Reservation.Data reservationData in actionList)
                {
                    if (reservationData.Id != reservationId && ValidateRoomWithCategoryTypeAndACPreference(reservationData,categoryId,typeId,acPreference))
                        retVal += reservationData.NoOfRooms;
                }
            }

            return retVal;      
        }

        private List<Crystal.Customer.Component.Action.Data> RemoveDuplicateReservation(List<Crystal.Customer.Component.Action.Data> actionList)
        {
            List<Crystal.Customer.Component.Action.Data> lstAction = new List<CrystalCustomer.Action.Data>();
            Boolean isExists;
            foreach (Crystal.Customer.Component.Action.Data roomData in actionList)
            {
                if (lstAction.Count == 0)
                    lstAction.Add(roomData);
                else
                {
                    isExists = false;
                    foreach(Crystal.Customer.Component.Action.Data uniqueRoomData in lstAction)
                    {
                        if (uniqueRoomData.Id == roomData.Id)
                        {
                            isExists = true;
                            break;
                        }
                    }
                    if (!isExists) lstAction.Add(roomData);
                }
            }
            

            return lstAction;
        }

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeConfigurationFacade.Room.Dto room, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            if (categoryId > 0 && categoryId != room.Category.Id)
                return false;

            if (typeId > 0 && typeId != room.Type.Id)
                return false;

            if (acPreference > 0)
            {
                Boolean isAC = acPreference == 1 ? true : false;
                if (isAC != room.IsAirconditioned)
                    return false;
            }

            return true;
        }

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(CrystalLodge.Room.Reservation.Data reservationData, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            Int64 catId = reservationData.RoomCategory == null ? 0 : reservationData.RoomCategory.Id;
            Int64 typId = reservationData.RoomType == null ? 0 : reservationData.RoomType.Id;

            if (categoryId == 0 && typeId == 0 && acPreference == 0)
                return true;
            else if (catId == categoryId && typId == typeId && reservationData.ACPreference == acPreference)
                return true;
            
            return false;
        }        
    }

}
