﻿using System;
using System.Collections.Generic;

using BinAff.Core;

using LodgeCrys = Crystal.Lodge.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using CustCrys = Crystal.Customer.Component;
using RoomRsvCrys = Crystal.Lodge.Component.Room.Reservation;
using RoomRsvArtf = Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact;

using LodgeConfigFac = AutoTourism.Lodge.Configuration.Facade;
using RuleFac = AutoTourism.Configuration.Rule.Facade;
using CustAuto = AutoTourism.Component.Customer;
using CustFac = AutoTourism.Customer.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{

    public class ReservationServer : Vanilla.Form.Facade.Document.Server, IReservation
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
            formDto.CategoryList = new LodgeConfigFac.Room.Server(null).ReadAllCategory().Value;
            formDto.TypeList = new LodgeConfigFac.Room.Server(null).ReadAllType().Value;

            if (formDto.Dto != null && formDto.Dto.Id > 0)
            {
                (formDto.Dto as Facade.RoomReservation.Dto).Customer = this.GetCustomerDtoForReservation(formDto.Dto.Id);
            }
            //{                
            //    //CustAuto.ICustomer autoCustomer = new CustAuto.Server(null);
            //    //formDto.Dto.Customer = ConvertToCustomerDto(autoCustomer.GetCustomerForReservation(formDto.Dto.Id));
            //}
        }

        public Customer.Facade.Dto GetCustomerDtoForReservation(Int64 reservationId)
        {
            CustAuto.ICustomer autoCustomer = new CustAuto.Server(null);
            return ConvertToCustomerDto(autoCustomer.GetCustomerForReservation(reservationId));
        }

        public Customer.Facade.Dto ConvertToCustomerDto(Crystal.Customer.Component.Data customerData)
        {
            if (customerData == null)
                return null;

            BinAff.Facade.Library.Dto dto = new AutoTourism.Customer.Facade.Server(null).Convert(customerData);
            return dto as Customer.Facade.Dto;
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            LodgeCrys.Room.Reservation.Data reservation = data as LodgeCrys.Room.Reservation.Data;
            return new Dto
            {
                Id = data.Id,
                NoOfDays = reservation.NoOfDays,
                NoOfPersons = reservation.NoOfPersons,
                NoOfRooms = reservation.NoOfRooms,
                BookingFrom = reservation.ActivityDate,
                Advance = reservation.Advance,                
                BookingStatusId = reservation.Status == null ? 0 : reservation.Status.Id,
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
            return new LodgeCrys.Room.Reservation.Data
            {
                Id = dto.Id,
                NoOfDays = reservation.NoOfDays,
                NoOfPersons = reservation.NoOfPersons,
                NoOfRooms = reservation.NoOfRooms,
                Advance = reservation.Advance,
                ActivityDate = reservation.BookingFrom,
                Date = DateTime.Now,
                ProductList = reservation.RoomList == null ? null : GetRoomDataList(reservation.RoomList),
                Status =  new Crystal.Customer.Component.Action.Status.Data
                {
                    //Id = System.Convert.ToInt64(RoomStatus.Open)
                    Id = reservation.BookingStatusId
                },
                Description = String.Empty,//description will be added later if required
                RoomCategory = reservation.RoomCategory == null ? null : new LodgeCrys.Room.Category.Data { Id = reservation.RoomCategory.Id },
                RoomType = reservation.RoomType == null ? null : new LodgeCrys.Room.Type.Data { Id = reservation.RoomType.Id },
                ACPreference = reservation.ACPreference
            };
        }

        private ReturnObject<RuleFac.ConfigurationRuleDto> ReadConfigurationRule()
        {
            return new RuleFac.RuleServer().ReadConfigurationRule();
        }
        
        private ReturnObject<List<LodgeConfigFac.Room.Dto>> ReadAllRoom()
        {
            return new LodgeConfigFac.Room.Server(null).ReadAllRoom();
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
            Boolean isNew = (this.FormDto as FormDto).Dto.Id == 0;
            using (System.Transactions.TransactionScope T = new System.Transactions.TransactionScope())
            {
                CustAuto.Server custServer = new CustAuto.Server(this.ConvertCustomer());
                ReturnObject<Boolean> ret = (custServer as ICrud).Save();
                CustAuto.Data customer = (custServer as BinAff.Core.Crud).Data as CustAuto.Data;
                if (customer.RoomReserver.Active != null)
                {
                    (this.FormDto as FormDto).Dto.Id = customer.RoomReserver.Active.Id;
                }

                //Call observer...
                //This is work around because for this form artifact is different than component server.
                //Here customer component has to call bu need to update room reservation artifact
                if (this.componentServer == null) this.componentServer = this.GetComponentServer();
                if (isNew)
                {
                    (this.componentServer as BinAff.Core.Crud).Data.Id = (this.FormDto as FormDto).Dto.Id;
                    (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForCreate();
                }
                else
                {
                    (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForUpdate();
                }
                this.UpdateAuditInformation();

                this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
                T.Complete();
            }
        }

        private CustAuto.Data ConvertCustomer()
        {
            Dto dto = (this.FormDto as FormDto).Dto as Dto;
            AutoTourism.Component.Customer.Data autoCustomer = new Component.Customer.Data()
            {
                Id = dto.Customer.Id,
                FirstName = dto.Customer.FirstName,
                MiddleName = dto.Customer.MiddleName,
                LastName = dto.Customer.LastName,
                Address = dto.Customer.Address,
                City = dto.Customer.City,
                Pin = dto.Customer.Pin,
                Email = dto.Customer.Email,
                IdentityProof = dto.Customer.IdentityProofName == null ? String.Empty : dto.Customer.IdentityProofName,
                State = dto.Customer.State == null ? null : new Crystal.Configuration.Component.State.Data
                {
                    Id = dto.Customer.State.Id,
                    Name = dto.Customer.State.Name
                },
                ContactNumberList = this.ConvertToContactNumberData(dto.Customer.ContactNumberList),
                //Initial = new Crystal.Configuration.Component.Initial.Data
                //{
                //    Id = reservationDto.Customer.Initial.Id,
                //    Name = reservationDto.Customer.Initial.Name
                //},
                IdentityProofType = dto.Customer.IdentityProofType == null ? null : new Crystal.Configuration.Component.IdentityProofType.Data
                {
                    Id = dto.Customer.IdentityProofType.Id,
                    Name = dto.Customer.IdentityProofType.Name
                },
                RoomReserver = new LodgeCrys.Room.Reserver.Data()
            };

            autoCustomer.RoomReserver.Active = this.Convert(dto) as CustCrys.Action.Data;
            autoCustomer.RoomReserver.Active.ProductList = dto.RoomList == null ? null : this.GetRoomDataList(dto.RoomList);

            return autoCustomer;
        }

        public List<CustCrys.ContactNumber.Data> ConvertToContactNumberData(List<Table> contactNumberList)
        {
            List<CustCrys.ContactNumber.Data> lstContactNumber = new List<CustCrys.ContactNumber.Data>();
            if (contactNumberList != null && contactNumberList.Count > 0)
            {
                foreach (Table table in contactNumberList)
                {
                    lstContactNumber.Add(new CustCrys.ContactNumber.Data 
                    { 
                        Id = table.Id,
                        ContactNumber = table.Name
                    });
                }
            }

            return lstContactNumber;
        }

        public List<Data> GetRoomDataList(List<LodgeConfigFac.Room.Dto> RoomList)
        {
            List<Data> RoomDataList = new List<Data>();
            foreach (LodgeConfigFac.Room.Dto dto in RoomList)
            {
                RoomDataList.Add(new LodgeCrys.Room.Data
                {
                    Id = dto.Id,
                    Number = dto.Number,
                });
            }
            return RoomDataList;
        }

        public List<LodgeConfigFac.Room.Dto> GetRoomDtoList(List<Data> RoomList)
        {
            List<LodgeConfigFac.Room.Dto> RoomDtoList = new List<LodgeConfigFac.Room.Dto>();
            foreach (LodgeCrys.Room.Data data in RoomList)
            {
                RoomDtoList.Add(new LodgeConfigFac.Room.Dto
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

        private ReturnObject<Boolean> UpdateReservationStatus()
        {
            Dto reservationDto = (this.FormDto as FormDto).Dto as Dto;

            CustCrys.Action.IAction roomReservation = new LodgeCrys.Room.Reservation.Server(new LodgeCrys.Room.Reservation.Data 
            {
                Id = reservationDto.Id,
                Status = new CustCrys.Action.Status.Data
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
            {
                reservationModuleDto.Artifact.Children.Add(artifactDto);
            }

            (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Vanilla.Utility.Facade.Artifact.FormDto
            {
                Dto = artifactDto
            };

            (this.FormDto as FormDto).ModuleFormDto.Dto = reservationModuleDto;
            Vanilla.Utility.Facade.Module.Server moduleFacade = new Vanilla.Utility.Facade.Module.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();                       
        }
        
        ReturnObject<Boolean> IReservation.ChangeReservationStatus()
        {
            return this.UpdateReservationStatus();
        }

        ReturnObject<List<LodgeConfigFac.Room.Dto>> IReservation.GetBookedRooms(DateTime startDate, DateTime endDate)
        {
            Crystal.Customer.Component.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, startDate, endDate);

            List<LodgeConfigFac.Room.Dto> lstRoomDto = new List<LodgeConfigFac.Room.Dto>();

            if (ret.Value != null)
            {
                foreach (Crystal.Customer.Component.Action.Data roomData in ret.Value)
                {
                    if (roomData.ProductList != null && roomData.ProductList.Count > 0)
                    {
                        foreach (LodgeCrys.Room.Data data in roomData.ProductList)
                        {
                            if(data.Id > 0)
                                lstRoomDto.Add(new LodgeConfigFac.Room.Dto { Id = data.Id });
                        }
                    }
                }
            }

            return new ReturnObject<List<LodgeConfigFac.Room.Dto>>
            {
                Value = lstRoomDto
            };
        }

        Boolean IReservation.ValidateRoomWithCategoryTypeAndACPreference(LodgeConfigFac.Room.Dto room, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            return this.ValidateRoomWithCategoryTypeAndACPreference(room, categoryId, typeId, acPreference);
        }

        public List<LodgeConfigFac.Room.Dto> FilterRoomList(List<LodgeConfigFac.Room.Dto> roomList, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            List<LodgeConfigFac.Room.Dto> lstRoom = new List<LodgeConfigFac.Room.Dto>();

            foreach (LodgeConfigFac.Room.Dto room in roomList)
            {
                if (this.ValidateRoomWithCategoryTypeAndACPreference(room, categoryId, typeId, acPreference))
                {
                    lstRoom.Add(room);
                }
            }

            return lstRoom;
        }

        public Int32 GetReservedRoomList(DateTime startDate, DateTime endDate, Int64 reservationId)
        {
            int retVal = 0;
            Crystal.Customer.Component.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, startDate, endDate);

            if (ret.Value != null && ret.Value.Count > 0)
            {
                List<Crystal.Customer.Component.Action.Data> actionList = this.RemoveDuplicateReservation(ret.Value);
                foreach (LodgeCrys.Room.Reservation.Data reservationData in actionList)
                {
                    if (reservationData.Id != reservationId)
                        retVal += reservationData.NoOfRooms;
                }
            }

            return retVal;          
        }

        public Int32 GetReservedRoomList(DateTime startDate, DateTime endDate, Int64 reservationId, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            int retVal = 0;
            Crystal.Customer.Component.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, startDate, endDate);

            if (ret.Value != null && ret.Value.Count > 0)
            {
                List<Crystal.Customer.Component.Action.Data> actionList = this.RemoveDuplicateReservation(ret.Value);
                foreach (LodgeCrys.Room.Reservation.Data reservationData in actionList)
                {
                    if (reservationData.Id != reservationId && ValidateRoomWithCategoryTypeAndACPreference(reservationData, categoryId, typeId, acPreference))
                        retVal += reservationData.NoOfRooms;
                }

                //foreach (Crystal.Customer.Component.Action.Data actionData in ret.Value)
                //{
                //    if (actionData.Id != reservationId && actionData.ProductList != null && actionData.ProductList.Count > 0)
                //    {
                //        foreach (LodgeCrys.Room.Data data in actionData.ProductList)
                //        {
                //            if(ValidateRoomWithCategoryTypeAndACPreference(data,categoryId,typeId,acPreference))
                //                retVal += 1;
                //        }
                //    }
                //}
            }

            return retVal;      
        }

        Customer.Facade.Dto IReservation.CloneCustomer(Customer.Facade.Dto customerDto)
        {
            return new CustFac.Dto
            {
                Id = customerDto.Id,
                //Initial = customerDto.Initial == null ? null : new Table
                //{
                //    Id = customerDto.Initial.Id,
                //    Name = customerDto.Initial.Name
                //},
                FirstName = customerDto.FirstName,
                MiddleName = customerDto.MiddleName,
                LastName = customerDto.LastName,
                ContactNumberList = customerDto.ContactNumberList == null ? null : this.CloneContactNumber(customerDto.ContactNumberList),
                Address = customerDto.Address,
                Email = customerDto.Email
            };
        }

        Dto IReservation.CloneReservaion(Dto reservationDto)
        {
            return new Dto
            {
                BookingFrom = reservationDto.BookingFrom,
                NoOfDays = reservationDto.NoOfDays,
                NoOfPersons = reservationDto.NoOfPersons,
                NoOfRooms = reservationDto.NoOfRooms,
                Advance = reservationDto.Advance,
                BookingStatusId = reservationDto.BookingStatusId,
                RoomCategory = reservationDto.RoomCategory == null ? null : new Table
                {
                    Id = reservationDto.RoomCategory.Id,
                    Name = reservationDto.RoomCategory.Name
                },
                RoomType = reservationDto.RoomType == null ? null : new Table
                {
                    Id = reservationDto.RoomType.Id,
                    Name = reservationDto.RoomType.Name
                },
                ACPreference = reservationDto.ACPreference,
                RoomList = reservationDto.RoomList == null ? null : this.CloneRoomList(reservationDto.RoomList)
            };
        }

        private List<Crystal.Customer.Component.Action.Data> RemoveDuplicateReservation(List<Crystal.Customer.Component.Action.Data> actionList)
        {
            List<Crystal.Customer.Component.Action.Data> lstAction = new List<CustCrys.Action.Data>();
            Boolean isExists;
            foreach (Crystal.Customer.Component.Action.Data roomData in actionList)
            {
                if (lstAction.Count == 0)
                {
                    lstAction.Add(roomData);
                }
                else
                {
                    isExists = false;
                    foreach (Crystal.Customer.Component.Action.Data uniqueRoomData in lstAction)
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

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeConfigFac.Room.Dto room, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            if (room.Id == 0) return false;
            if (categoryId > 0 && categoryId != room.Category.Id) return false;
            if (typeId > 0 && typeId != room.Type.Id) return false;

            if (acPreference > 0)
            {
                Boolean isAC = acPreference == 1 ? true : false;
                if (isAC != room.IsAirconditioned) return false;
            }

            return true;
        }

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeCrys.Room.Data room, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            if (room.Id == 0) return false;
            if (categoryId > 0 && categoryId != room.Category.Id) return false;
            if (typeId > 0 && typeId != room.Type.Id) return false;

            if (acPreference > 0)
            {
                Boolean isAC = acPreference == 1 ? true : false;
                if (isAC != room.IsAirConditioned) return false;
            }

            return true;
        }

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeCrys.Room.Reservation.Data reservationData, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            Int64 catId = reservationData.RoomCategory == null ? 0 : reservationData.RoomCategory.Id;
            Int64 typId = reservationData.RoomType == null ? 0 : reservationData.RoomType.Id;           

            Boolean retVal = true;
            if (categoryId != 0) retVal = catId == categoryId;
            if (retVal && typeId != 0) retVal = typId == typeId;
            if (retVal && acPreference != 0) retVal = reservationData.ACPreference == acPreference;

            return retVal;
        }
        
        private List<Table> CloneContactNumber(List<Table> contactNumberList)
        {
            List<Table> lstContactNumber = new List<Table>();
            foreach (Table contactNo in contactNumberList)
            {
                lstContactNumber.Add(new Table
                {
                    Id = contactNo.Id,
                    Name = contactNo.Name
                });
            }
            return lstContactNumber;
        }

        private List<LodgeConfigFac.Room.Dto> CloneRoomList(List<LodgeConfigFac.Room.Dto> roomList)
        {
            List<LodgeConfigFac.Room.Dto> lstRoom = new List<LodgeConfigFac.Room.Dto>();

            foreach (LodgeConfigFac.Room.Dto room in roomList)
                lstRoom.Add(new LodgeConfigFac.Room.Dto
                {
                    Id = room.Id,
                    Action = room.Action,
                    artifactPath = room.artifactPath,
                    Building = room.Building,
                    Category = room.Category,
                    Description = room.Description,
                    fileName = room.fileName,
                    Floor = room.Floor,
                    ImageList = room.ImageList,
                    IsAirconditioned = room.IsAirconditioned,
                    Name = room.Name,
                    Number = room.Number,
                    StatusId = room.StatusId,
                    trvForm = room.trvForm,
                    Type = room.Type
                });

            return lstRoom;
        }
        
        protected override ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData)
        {
            return new RoomRsvCrys.Navigator.Artifact.Server(artifactData as RoomRsvCrys.Navigator.Artifact.Data);
        }

        protected override ArtfCrys.Observer.DocumentComponent GetComponentServer()
        {
            this.componentServer = new RoomRsvCrys.Server(this.Convert((this.FormDto as FormDto).Dto) as RoomRsvCrys.Data);
            return this.componentServer as ArtfCrys.Observer.DocumentComponent;
        }

        protected override String GetComponentDataType()
        {
            return "Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact.Data, Crystal.Lodge.Component";
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
