
using System;
using System.Text;
using System.Collections.Generic;

using BinAff.Core;

using CrystalLodge = Crystal.Lodge.Component;
using CrystalCustomer = Crystal.Customer.Component;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class CheckInServer : BinAff.Facade.Library.Server, ICheckIn
    {
        
        public enum CheckInStatus
        {
            CheckIn = 10001,
            CheckOut = 10002
        }

        public CheckInServer(FormDto formDto)
            : base(formDto)
        {

        }

        //public enum LodgeReservationStatus
        //{
        //    Open = 10001,
        //    Closed = 10002,
        //    Cancel = 10003,
        //    CheckIn = 10004,
        //    Modify = 10005
        //}

        //public enum RoomStatus
        //{
        //    Unoccupied = 10001,
        //    Occupied = 10002,
        //    Closed = 10003
        //}

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.roomList = this.ReadAllRoom().Value;
            formDto.configurationRuleDto = this.ReadConfigurationRule().Value;
            formDto.CategoryList = new LodgeConfigurationFacade.Room.Server(null).ReadAllCategory().Value;
            formDto.TypeList = new LodgeConfigurationFacade.Room.Server(null).ReadAllType().Value;           
        }

        //ReturnObject<Boolean> ICheckIn.Save(Dto dto)
        //{
        //    return this.SaveCheckIn(dto);
        //}

        private ReturnObject<RuleFacade.ConfigurationRuleDto> ReadConfigurationRule()
        {
            return new RuleFacade.RuleServer().ReadConfigurationRule();
        }

        //private ReturnObject<Boolean> SaveCheckIn(Dto dto)
        //{
        //    ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
        //    {
        //        Value = true,
        //        MessageList = new List<Message>()
        //    };

            //using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            //{
            //    Crystal.Lodge.Reservation.Data reservationData = new Crystal.Lodge.Reservation.Data() { 
            //        Id = dto.Reservation.Id,    
            //        BookingStatusId = dto.Reservation.BookingStatusId,
            //        BookingFrom = dto.Reservation.BookingFrom,
            //        NoOfDays = dto.Reservation.NoOfDays,
            //        NoOfPersons = dto.Reservation.NoOfPersons,
            //        NoOfRooms = dto.Reservation.NoOfRooms,
            //        Advance = dto.Advance,
            //        Customer = dto.Reservation.Customer == null ? null : new Crystal.CustomerManagement.Data()
            //        {
            //            Id = dto.Reservation.Customer.Id,
            //        },
            //        RoomList = dto.RoomList == null ? null : GetRoomDataList(dto.RoomList),
            //    };

            //    if (dto.Reservation.BookingStatusId == Convert.ToInt64(LodgeReservationStatus.Modify))
            //    {
            //        //Step1 : Call Reservation Component to update the ReservationStatus To Modify
            //        Crystal.Lodge.Reservation.IReservation reservation = new Crystal.Lodge.Reservation.Server(reservationData);
            //        retObj = reservation.UpdateReservationStatus();
            //        if (!retObj.Value) return retObj;

            //        //Step2 : Call Reservation Component to create a new Reservation
            //        reservationData.Id = 0; //for new insert
            //        ICrud crudReservation = new Crystal.Lodge.Reservation.Server(reservationData);
            //        retObj = crudReservation.Save();
            //        if (!retObj.Value) return retObj;

            //    }

            //    //Call Reservation Component to update the Reservation Status to CheckIn                   
            //    reservationData.BookingStatusId = Convert.ToInt64(LodgeReservationStatus.CheckIn);
            //    Crystal.Lodge.Reservation.IReservation rsrvn = new Crystal.Lodge.Reservation.Server(reservationData);
            //    retObj = rsrvn.UpdateReservationStatus();
            //    if (!retObj.Value) return retObj;

            //    //Save CheckIn Data
            //    ICrud crud = new Server(new Crystal.Lodge.CheckIn.Data
            //    {
            //        Id = dto.Id,
            //        Advance = dto.Advance,
            //        Reservation = new Crystal.Lodge.Reservation.Data() { Id = reservationData.Id },
            //        RoomList = dto.RoomList == null ? null : GetRoomDataList(dto.RoomList),
            //    });

            //    retObj = crud.Save();
            //    if (!retObj.Value) return retObj;

            //    Crystal.Lodge.Reservation.IReservation resrvn = new Crystal.Lodge.Reservation.Server(reservationData);
            //    Boolean retVal = resrvn.CreateRoomBooked(reservationData.RoomList, reservationData.Id);
            //    if (!retVal) {
            //        retObj.Value = false;
            //        return retObj;
            //    } 

            //    //Room Room component to change the room status to occupied
            //    foreach (Crystal.Lodge.Configuration.Room.Data data in reservationData.RoomList)
            //    {
            //        Crystal.Lodge.Configuration.Room.IRoom roomServer = new Crystal.Lodge.Configuration.Room.Server(new Crystal.Lodge.Configuration.Room.Data() {
            //            Id = data.Id,
            //            StatusId = Convert.ToInt64(RoomStatus.Occupied),
            //        });
            //        retObj = roomServer.UpdateRoomStatus();
            //        if (!retObj.Value) return retObj;
            //    }

              
            //    T.Complete();
            //}

            //retObj.MessageList.Clear();
            //retObj.MessageList.Add(new Message("Reservation is checked in successfully.",Message.Type.Information));
        //    return retObj;
                        
        //}

        //private List<CrystalLodge.Room.Data> GetRoomDataList(List<LodgeConfigurationFacade.Room.Dto> RoomList)
        //{
        //    List<CrystalLodge.Room.Data> RoomDataList = new List<CrystalLodge.Room.Data>();
        //    foreach (LodgeConfigurationFacade.Room.Dto dto in RoomList)
        //    {
        //        RoomDataList.Add(new CrystalLodge.Room.Data()
        //        {
        //            Id = dto.Id,
        //            Number = dto.Number,
        //        });
        //    }
        //    return RoomDataList;
        //}

        private ReturnObject<List<LodgeConfigurationFacade.Room.Dto>> ReadAllRoom()
        {
            return new LodgeConfigurationFacade.Room.Server(null).ReadAllRoom();
        }
                      

        //private List<AutoTourism.Facade.Configuration.Room.Dto> GetRoomDtoList(List<Crystal.Lodge.Configuration.Room.Data> RoomDataList)
        //{
        //    List<AutoTourism.Facade.Configuration.Room.Dto> retVal = null;
        //    if (RoomDataList != null)
        //    {
        //        retVal = new List<Configuration.Room.Dto>();
        //        foreach (Crystal.Lodge.Configuration.Room.Data data in RoomDataList)
        //        {
        //            retVal.Add(new Configuration.Room.Dto()
        //            {
        //                Id = data.Id,
        //                Number = data.Number,
        //                Name = data.Name,
        //                IsAirconditioned = data.IsAirConditioned,
        //                Description = data.Description,
        //                Building = new Configuration.Building.Dto()
        //                {
        //                    Id = data.Building.Id,
        //                },
        //                IsDormitory = data.IsDormitory,
        //                StatusId = data.StatusId,
        //                Category = new Configuration.RoomCategory.Dto() { Id = data.Category.Id },
        //                Type = new Configuration.RoomType.Dto() { Id = data.Type.Id }
        //            });
        //        }
        //    }
        //    return retVal;
        //}

        //private AutoTourism.Facade.CustomerManagement.Dto ReadCustomer(Int64 customerId)
        //{

        //    ICrud crud = new Crystal.CustomerManagement.Server(new Crystal.CustomerManagement.Data() { Id = customerId });
        //    ReturnObject<BinAff.Core.Data> data = crud.Read();

        //    AutoTourism.Facade.CustomerManagement.Dto customerDto = new CustomerManagement.Dto()
        //    {
        //        Id = data.Value.Id,
        //        Initial = ((Crystal.CustomerManagement.Data)data.Value).Initial == null ? null : new Configuration.Initial.Dto()
        //        {
        //            Id = ((Crystal.CustomerManagement.Data)data.Value).Initial.Id,
        //            Name = ((Crystal.CustomerManagement.Data)data.Value).Initial.Name,
        //        },
        //        FirstName = ((Crystal.CustomerManagement.Data)data.Value).FirstName,
        //        MiddleName = ((Crystal.CustomerManagement.Data)data.Value).MiddleName,
        //        LastName = ((Crystal.CustomerManagement.Data)data.Value).LastName,
        //        Address = ((Crystal.CustomerManagement.Data)data.Value).Address,
        //        State = ((Crystal.CustomerManagement.Data)data.Value).State == null ? null : new Configuration.State.Dto()
        //        {
        //            Id = ((Crystal.CustomerManagement.Data)data.Value).State.Id,
        //            Name = ((Crystal.CustomerManagement.Data)data.Value).State.Name,
        //        },
        //        City = ((Crystal.CustomerManagement.Data)data.Value).City,
        //        Pin = ((Crystal.CustomerManagement.Data)data.Value).Pin,
        //        ContactNumberList = ((Crystal.CustomerManagement.Data)data.Value).ContactNumberList == null ? null : GetContactNumberList(((Crystal.CustomerManagement.Data)data.Value).ContactNumberList),
        //        Email = ((Crystal.CustomerManagement.Data)data.Value).Email,
        //        IdentityProofType = ((Crystal.CustomerManagement.Data)data.Value).IdentityProofType == null ? null : new Configuration.IdentityProofType.Dto()
        //        {
        //            Id = ((Crystal.CustomerManagement.Data)data.Value).IdentityProofType.Id,
        //            Name = ((Crystal.CustomerManagement.Data)data.Value).IdentityProofType.Name,
        //        },
        //        IdentityProofName = ((Crystal.CustomerManagement.Data)data.Value).IdentityProof,

        //    };


        //    return customerDto;
        //}
        
        //private List<AutoTourism.Facade.Library.ContactNumberDto> GetContactNumberList(List<Crystal.CustomerManagement.ContactNumberData> ContactNumberDataList)
        //{
        //    List<AutoTourism.Facade.Library.ContactNumberDto> ContactNumberDtoList = new List<AutoTourism.Facade.Library.ContactNumberDto>();
        //    foreach (Crystal.CustomerManagement.ContactNumberData data in ContactNumberDataList)
        //    {
        //        ContactNumberDtoList.Add(new AutoTourism.Facade.Library.ContactNumberDto()
        //        {
        //            Id = data.Id,
        //            Name = data.ContactNumber,
        //        });
        //    }
        //    return ContactNumberDtoList;
        //}

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto checkIn = dto as Dto;
            return new CrystalLodge.Room.CheckIn.Data
            {
                Id = dto.Id,
                Advance = checkIn.reservationDto.Advance,
                Reservation = new RoomReservation.ReservationServer(null).Convert(checkIn.reservationDto) as CrystalLodge.Room.Reservation.Data,
                ActivityDate = checkIn.Date,
                Status = new CrystalCustomer.Action.Status.Data
                {
                    Id = System.Convert.ToInt64(CheckInStatus.CheckIn)
                },
            };
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CrystalLodge.Room.CheckIn.Data checkIn = data as CrystalLodge.Room.CheckIn.Data;
            CrystalLodge.Room.Reservation.Data reservation = checkIn.Reservation;
            return new Dto
            {
                Id = data.Id,
                Date = checkIn.ActivityDate,
                statusId = (checkIn.Status == null || checkIn.Status.Id == 0 ) ? 0 : checkIn.Status.Id,
                reservationDto = new RoomReservation.Dto 
                {
                    Id = reservation.Id,
                    NoOfDays = reservation.NoOfDays,
                    NoOfPersons = reservation.NoOfPersons,
                    NoOfRooms = reservation.NoOfRooms,
                    BookingFrom = reservation.ActivityDate,
                    Advance = reservation.Advance,
                    BookingStatusId = reservation.Status.Id,
                    RoomList = reservation.ProductList == null ? null : new LodgeFacade.RoomReservation.ReservationServer(null).GetRoomDtoList(reservation.ProductList),
                    RoomCategory = reservation.RoomCategory == null ? null : new Table { Id = reservation.RoomCategory.Id },
                    RoomType = reservation.RoomType == null ? null : new Table { Id = reservation.RoomType.Id },
                    ACPreference = reservation.ACPreference,
                    BookingDate = reservation.Date,
                    Customer = new LodgeFacade.RoomReservation.ReservationServer(null).GetCustomerDtoForReservation(reservation.Id)
                }
            };
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
            Dto checkInDto = (this.FormDto as FormDto).dto;
           
            LodgeFacade.RoomReservation.Dto reservationDto = checkInDto.reservationDto;

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
                ContactNumberList = new RoomReservation.ReservationServer(null).ConvertToContactNumberData(reservationDto.Customer.ContactNumberList),
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
                RoomReserver = new CrystalLodge.Room.Reserver.Data(),
                Checkin = new CrystalLodge.Room.CheckInContainer.Data()
            };

            autoCustomer.RoomReserver.Active = new RoomReservation.ReservationServer(null).Convert(reservationDto) as CrystalCustomer.Action.Data;
            autoCustomer.RoomReserver.Active.ProductList = reservationDto.RoomList == null ? null : new RoomReservation.ReservationServer(null).GetRoomDataList(reservationDto.RoomList);

            autoCustomer.Checkin.Active = this.Convert(checkInDto) as CrystalCustomer.Action.Data;

            ICrud crud = new AutoTourism.Component.Customer.Server(autoCustomer);
            ReturnObject<Boolean> ret = crud.Save();

            if (autoCustomer.Checkin.Active != null)
                (this.FormDto as FormDto).dto.Id = autoCustomer.Checkin.Active.Id;

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information); 
        }
        
        void ICheckIn.CheckOut()
        {            
            //updating reservation
            LodgeFacade.RoomReservation.FormDto reservationFormDto = new LodgeFacade.RoomReservation.FormDto
            {
                Dto = ((this.FormDto) as FormDto).dto.reservationDto
            };
            new LodgeFacade.RoomReservation.ReservationServer(reservationFormDto).Change();

            //update checkIn status
            CrystalLodge.Room.CheckIn.ICheckIn checkIn = new CrystalLodge.Room.CheckIn.Server(new CrystalLodge.Room.CheckIn.Data { Id = ((this.FormDto) as FormDto).dto.Id });
            checkIn.ModifyCheckInStatus(System.Convert.ToInt64(CheckInStatus.CheckOut));
        }
    }
}
