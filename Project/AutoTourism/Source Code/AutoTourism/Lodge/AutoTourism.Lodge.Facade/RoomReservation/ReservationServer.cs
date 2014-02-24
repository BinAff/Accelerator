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
                IsAC = reservation.IsAC,
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
                IsAC = reservation.IsAC
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

        public void SaveArtifactForReservation(Dto dto,Table loggedInUser)
        {
            Vanilla.Utility.Facade.Module.Dto reservationModuleDto = new Vanilla.Utility.Facade.Module.Server(null).GetModule("LRSV", (this.FormDto as FormDto).ModuleFormDto.FormModuleList);
            String fileName = new Vanilla.Utility.Facade.Artifact.Server(null).GetArtifactName(reservationModuleDto.Artifact, Vanilla.Utility.Facade.Artifact.Type.Document, "Form");
            
            Vanilla.Utility.Facade.Artifact.Dto artifactDto = new Vanilla.Utility.Facade.Artifact.Dto
            {
                Module = dto as BinAff.Facade.Library.Dto,
                FileName = fileName,
                Style = Vanilla.Utility.Facade.Artifact.Type.Document,
                Version = 1,
                CreatedBy = new Table
                {
                    Id = loggedInUser.Id,
                    Name = loggedInUser.Name
                },               
                CreatedAt = DateTime.Now,
                Category = Vanilla.Utility.Facade.Artifact.Category.Form,
                Path = dto.ArtifactPath
                
            };            

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
