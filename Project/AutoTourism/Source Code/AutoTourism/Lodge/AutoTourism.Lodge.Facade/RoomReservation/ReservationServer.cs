using System;
using System.Collections.Generic;

using BinAff.Core;

using CrystalLodge = Crystal.Lodge.Component;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using RuleFacade = Autotourism.Configuration.Rule.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class ReservationServer : BinAff.Facade.Library.Server
    {

        public ReservationServer(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.roomList = this.ReadAllRoom().Value;
            formDto.configurationRuleDto = this.ReadConfigurationRule().Value;

            //formDto.InitialList = this.ReadAllInitial();
            //formDto.StateList = this.ReadAllState().Value;
            //formDto.IdentityProofTypeList = this.ReadAllIdentityProof().Value;
            //formDto.DtoList = this.ReadAllCustomer().Value;
            //formDto.customerRuleDto = this.ReadCustomerRule().Value;
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
                Advance = reservation.Advance               
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
                Description=String.Empty,//description will be added later if required
            };
        }


        #region "IReservation"

        //ReturnObject<FormDto> IReservation.LoadForm()
        //{
        //    ReturnObject<FormDto> ret = new ReturnObject<FormDto>()
        //    {
        //        Value = new FormDto()
        //        {
        //            roomList = this.ReadAllRoom().Value,
        //            configurationRuleDto = this.ReadConfigurationRule().Value
        //        }
        //    };

        //    return ret;
        //}

        //ReturnObject<Boolean> IReservation.Save(Dto dto)
        //{
        //    return this.SaveReservation(dto);
        //}

        //ReturnObject<List<Dto>> IReservation.GetBooking(Int64 customerId)
        //{
        //    return this.GetCustomerBooking(customerId);
        //}

        //ReturnObject<Boolean> IReservation.ChangeReservationStatus(Dto dto)
        //{
        //    return this.UpdateReservationStatus(dto);
        //}
        #endregion

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
            ICrud crud = new CrystalLodge.Room.Reservation.Server(this.Convert((this.FormDto as FormDto).Dto) as CrystalLodge.Room.Reservation.Data);
            ReturnObject<Boolean> ret = crud.Save();

            (this.FormDto as FormDto).Dto.Id = (crud as Crud).Data.Id;
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);           
        }

        private List<Data> GetRoomDataList(List<LodgeConfigurationFacade.Room.Dto> RoomList)
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
               
        //private AutoTourism.Facade.CustomerManagement.Dto ReadCustomer(Int64 customerId)
        //{               

        //    ICrud crud = new Crystal.CustomerManagement.Server(new Crystal.CustomerManagement.Data(){Id=customerId});
        //    ReturnObject<BinAff.Core.Data> data = crud.Read();

        //    AutoTourism.Facade.CustomerManagement.Dto customerDto = new CustomerManagement.Dto() {
        //        Id = data.Value.Id,
        //        Initial = ((Crystal.CustomerManagement.Data)data.Value).Initial == null ? null : new Configuration.Initial.Dto()
        //            {
        //                Id = ((Crystal.CustomerManagement.Data)data.Value).Initial.Id,
        //                Name = ((Crystal.CustomerManagement.Data)data.Value).Initial.Name,
        //            },
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


        private ReturnObject<Boolean> UpdateReservationStatus(Dto dto)
        {
            ICrud crud = new CrystalLodge.Room.Reservation.Server(new CrystalLodge.Room.Reservation.Data
            {
                Id = dto.Id,
                Status = new Crystal.Customer.Component.Action.Status.Data { 
                    Id = dto.BookingStatusId
                }
                //BookingStatusId = dto.BookingStatusId,
            });
            return crud.Save();
        }

        //-- RoomStaus ID is mapped with database table RoomReservationStatus
        public enum RoomStatus
        {
            Open = 10001,
            Close = 10002,
            Cancel = 10003,
            CheckIn = 10004,
            Modify = 10005
        }

    }

}
