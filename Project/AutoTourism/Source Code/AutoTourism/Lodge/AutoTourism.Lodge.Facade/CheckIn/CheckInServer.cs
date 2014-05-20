using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;

using CrystalLodge = Crystal.Lodge.Component;
using CrystalCustomer = Crystal.Customer.Component;

using LodgeConfFac = AutoTourism.Lodge.Configuration.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using RoomChkCrys = Crystal.Lodge.Component.Room.CheckIn;
using CustAuto = AutoTourism.Component.Customer;
using InvFac = Vanilla.Invoice.Facade;
using TarrifFac = AutoTourism.Lodge.Configuration.Facade.Tariff;

namespace AutoTourism.Lodge.Facade.CheckIn
{

    public class CheckInServer : Vanilla.Form.Facade.Document.Server, ICheckIn
    {       

        public CheckInServer(FormDto formDto)
            : base(formDto)
        {

        }
        
        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.roomList = this.ReadAllRoom().Value;
            formDto.configurationRuleDto = this.ReadConfigurationRule().Value;
            formDto.CategoryList = new LodgeConfFac.Room.Server(null).ReadAllCategory().Value;
            formDto.TypeList = new LodgeConfFac.Room.Server(null).ReadAllType().Value;           
        }

        private ReturnObject<RuleFacade.ConfigurationRuleDto> ReadConfigurationRule()
        {
            return new RuleFacade.RuleServer().ReadConfigurationRule();
        }
        
        private ReturnObject<List<LodgeConfFac.Room.Dto>> ReadAllRoom()
        {
            return new LodgeConfFac.Room.Server(null).ReadAllRoom();
        }
        
        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto checkIn = dto as Dto;
            return new CrystalLodge.Room.CheckIn.Data
            {
                Id = dto.Id,
                Advance = checkIn.Reservation.Advance,
                Reservation = new RoomReservation.ReservationServer(null).Convert(checkIn.Reservation) as CrystalLodge.Room.Reservation.Data,
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
                StatusId = (checkIn.Status == null || checkIn.Status.Id == 0 ) ? 0 : checkIn.Status.Id,
                InvoiceNumber = checkIn.invoiceNumber,
                Reservation = reservation == null ? null : new RoomReservation.Dto
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
            Boolean isNew = (this.FormDto as FormDto).Dto.Id == 0;
            using (System.Transactions.TransactionScope T = new System.Transactions.TransactionScope())
            {
                CustAuto.Server custServer = new CustAuto.Server(this.ConvertCustomer());
                ReturnObject<Boolean> ret = (custServer as ICrud).Save();
                if (!ret.HasError())
                {
                    CustAuto.Data customer = (custServer as BinAff.Core.Crud).Data as CustAuto.Data;
                    if (customer.Checkin.Active != null)
                    {
                        (this.FormDto as FormDto).Dto.Id = customer.Checkin.Active.Id;
                    }

                    //Call observer...
                    //This is work around because for this form artifact is different than component server.
                    //Here customer component has to call bu need to update room reservation artifact
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
                    T.Complete();
                }
                this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            }
        }

        private CustAuto.Data ConvertCustomer()
        {
            //Dto dto1 = (this.FormDto as FormDto).Dto;
            //Dto dto = (base.FormDto as Facade.CheckIn.FormDto).dto;
            Dto dto = (this.FormDto as FormDto).Dto as Facade.CheckIn.Dto;
       

            AutoTourism.Component.Customer.Data autoCustomer = new Component.Customer.Data()
            {
                Id = dto.Reservation.Customer.Id,
                FirstName = dto.Reservation.Customer.FirstName,
                MiddleName = dto.Reservation.Customer.MiddleName,
                LastName = dto.Reservation.Customer.LastName,
                Address = dto.Reservation.Customer.Address,
                City = dto.Reservation.Customer.City,
                Pin = dto.Reservation.Customer.Pin,
                Email = dto.Reservation.Customer.Email,
                IdentityProof = dto.Reservation.Customer.IdentityProofName == null ? String.Empty : dto.Reservation.Customer.IdentityProofName,
                State = new Crystal.Configuration.Component.State.Data
                {
                    Id = dto.Reservation.Customer.State.Id,
                    Name = dto.Reservation.Customer.State.Name
                },
                ContactNumberList = this.ConvertToContactNumberData(dto.Reservation.Customer.ContactNumberList),
                //Initial = new Crystal.Configuration.Component.Initial.Data
                //{
                //    Id = reservationDto.Customer.Initial.Id,
                //    Name = reservationDto.Customer.Initial.Name
                //},
                IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data
                {
                    Id = dto.Reservation.Customer.IdentityProofType.Id,
                    Name = dto.Reservation.Customer.IdentityProofType.Name
                },                
                Checkin = new CrystalLodge.Room.CheckInContainer.Data()
            };

            autoCustomer.Checkin.Active = this.Convert(dto) as CrystalCustomer.Action.Data;
            autoCustomer.Checkin.Active.ProductList = dto.Reservation.RoomList == null ? null : this.GetRoomDataList(dto.Reservation.RoomList);

            return autoCustomer;
        }

        //--Duplicate function [exists in ReservationServer]
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

        //--Duplicate function [exists in ReservationServer]
        public List<Data> GetRoomDataList(List<LodgeConfFac.Room.Dto> RoomList)
        {
            List<Data> RoomDataList = new List<Data>();
            foreach (LodgeConfFac.Room.Dto dto in RoomList)
            {
                RoomDataList.Add(new CrystalLodge.Room.Data
                {
                    Id = dto.Id,
                    Number = dto.Number,
                });
            }
            return RoomDataList;
        }

        public void CheckOut()
        {
            Dto dto = (this.FormDto as FormDto).Dto as Facade.CheckIn.Dto;
            //updating reservation
            LodgeFacade.RoomReservation.FormDto reservationFormDto = new LodgeFacade.RoomReservation.FormDto
            {
                Dto = dto.Reservation
            };
            LodgeFacade.RoomReservation.ReservationServer roomReserver = new LodgeFacade.RoomReservation.ReservationServer(reservationFormDto);
            //roomReserver.RegisterArtifactObserver();//Artifact is missing. Need to attach that in Document
            roomReserver.Change();

            //update checkIn status
            CrystalLodge.Room.CheckIn.ICheckIn checkIn = new CrystalLodge.Room.CheckIn.Server(new CrystalLodge.Room.CheckIn.Data { Id = dto.Id });
            checkIn.ModifyCheckInStatus(System.Convert.ToInt64(CheckInStatus.CheckOut));
        }

        //ReturnObject<bool> ICheckIn.PaymentInsert(Vanilla.Invoice.Facade.FormDto invoiceFormDto, Table currentUser, Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        //{
        //    return this.MakePayment(invoiceFormDto, currentUser, artifactDto);            
        //}

        //private ReturnObject<Boolean> MakePayment(Vanilla.Invoice.Facade.FormDto invoiceFormDto, Table currentUser, Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        //{
        //    ReturnObject<Boolean> ret = new ReturnObject<bool>();

        //    Vanilla.Invoice.Facade.Dto invoiceDto = invoiceFormDto.dto;
        //    AutoTourism.Component.Customer.Data autoCustomer = new AutoTourism.Component.Customer.Data
        //    {
        //        Invoice = new Crystal.Invoice.Component.InvoiceContainer.Data
        //        {
        //            Active = this.ConvertToInvoiceData(invoiceDto) as CrystalCustomer.Action.Data
        //        }
        //    };

        //    using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
        //    {
        //        //Save Invoice Data
        //        CrystalCustomer.ICustomer customer = new AutoTourism.Component.Customer.Server(autoCustomer);
        //        ret = customer.GenerateInvoice();

        //        if (ret.Value)
        //        {
        //            Crystal.Invoice.Component.Data invoiceData = (autoCustomer.Invoice as Crystal.Invoice.Component.InvoiceContainer.Data).Active as Crystal.Invoice.Component.Data;
        //            if (invoiceData.Id > 0)
        //            {
        //                //Update invoice number to CheckIn table
        //                ret = this.UpdateInvoiceNumber(invoiceData.InvoiceNumber);

        //                if (ret.Value)
        //                {
        //                    //Save to Artifact
        //                    invoiceFormDto.dto.Id = invoiceData.Id;
        //                    this.SaveArtifact(invoiceFormDto, currentUser, artifactDto);

        //                    T.Complete();
        //                }
        //            }
        //        }
        //    }

        //    return ret;
        //}

        ReturnObject<bool> ICheckIn.PaymentInsert(Vanilla.Invoice.Facade.Dto invoiceDto)
        {
            return this.MakePayment(invoiceDto);
        }

        private ReturnObject<Boolean> MakePayment(Vanilla.Invoice.Facade.Dto invoiceDto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>();
                        
            AutoTourism.Component.Customer.Data autoCustomer = new AutoTourism.Component.Customer.Data
            {
                Invoice = new Crystal.Invoice.Component.InvoiceContainer.Data
                {
                    Active = this.ConvertToInvoiceData(invoiceDto) as CrystalCustomer.Action.Data
                }
            };

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                //Save Invoice Data
                CrystalCustomer.ICustomer customer = new AutoTourism.Component.Customer.Server(autoCustomer);
                ret = customer.GenerateInvoice();

                if (ret.Value)
                {
                    Crystal.Invoice.Component.Data invoiceData = (autoCustomer.Invoice as Crystal.Invoice.Component.InvoiceContainer.Data).Active as Crystal.Invoice.Component.Data;
                    if (invoiceData.Id > 0)
                    {
                        //Update invoice number to CheckIn table
                        ret = this.UpdateInvoiceNumber(invoiceData.InvoiceNumber);
                        if (ret.Value) 
                            T.Complete();
                        
                    }
                }
            }

            return ret;
        }

        private BinAff.Core.Data ConvertToInvoiceData(BinAff.Facade.Library.Dto dto)
        {
            Vanilla.Invoice.Facade.Dto invoiceDto = dto as Vanilla.Invoice.Facade.Dto;

            return new Crystal.Invoice.Component.Data()
            {
                InvoiceNumber = invoiceDto.invoiceNumber,
                Advance = invoiceDto.advance,
                Discount = invoiceDto.discount,
                Date = System.DateTime.Now,
                Seller = this.GetSeller(invoiceDto.seller),
                Buyer = this.GetBuyer(invoiceDto.buyer),
                LineItem = this.GetLineItem(invoiceDto.productList),
                Taxation = this.GetTaxation(invoiceDto.taxationList),
                Payment = this.GetPayments(invoiceDto.paymentList)
            };
        }

        private Crystal.Invoice.Component.Seller GetSeller(Vanilla.Invoice.Facade.Seller.Dto seller)
        {
            return new Crystal.Invoice.Component.Seller
            {
                Name = seller.Name,
                Address = seller.Address,
                Liscence = seller.Liscence,
                Email = seller.Email,
                ContactNumber = seller.ContactNumber
            };
        }

        private Crystal.Invoice.Component.Buyer GetBuyer(Vanilla.Invoice.Facade.Buyer.Dto buyer)
        {
            return new Crystal.Invoice.Component.Buyer
            {
                Name = buyer.Name,
                Address = buyer.Address,
                Email = buyer.Email,
                ContactNumber = buyer.ContactNumber
            };
        }

        private List<BinAff.Core.Data> GetLineItem(List<Vanilla.Invoice.Facade.LineItem.Dto> roomList)
        {
            List<BinAff.Core.Data> lineItemList = new List<Data>();
            if (roomList != null && roomList.Count > 0)
            {
                foreach (Vanilla.Invoice.Facade.LineItem.Dto lineItem in roomList)
                {
                    lineItemList.Add(new Crystal.Invoice.Component.LineItem.Data
                    {
                        Start = lineItem.startDate,
                        End = lineItem.endDate,
                        Description = lineItem.description,
                        UnitRate = lineItem.unitRate,
                        Count = lineItem.count,
                        Total = lineItem.total
                    });
                }
            }
            return lineItemList;
        }

        private List<BinAff.Core.Data> GetTaxation(List<Vanilla.Invoice.Facade.Taxation.Dto> taxationList)
        {
            List<BinAff.Core.Data> taxationDataList = new List<Data>();
            if (taxationList != null && taxationList.Count > 0)
            {
                foreach (Vanilla.Invoice.Facade.Taxation.Dto dto in taxationList)
                {
                    taxationDataList.Add(new Crystal.Invoice.Component.Taxation.Data
                    {
                        Id = dto.Id,
                        Name = dto.Name,
                        Amount = dto.Amount,
                        isPercentage = dto.isPercentage
                    });
                }
            }
            return taxationDataList;
        }

        private List<BinAff.Core.Data> GetPayments(List<Vanilla.Invoice.Facade.Payment.Dto> paymentList)
        {
            List<BinAff.Core.Data> paymentDataList = new List<Data>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (Vanilla.Invoice.Facade.Payment.Dto dto in paymentList)
                {
                    paymentDataList.Add(new Crystal.Invoice.Component.Payment.Data
                    {
                        Id = dto.Id,
                        Type = new Crystal.Invoice.Component.Payment.Type.Data { Id = dto.Type.Id },
                        CardNumber = dto.cardNumber,
                        Remark = dto.remark,
                        Amount = dto.amount,
                    });
                }
            }
            return paymentDataList;
        }

        ReturnObject<bool> UpdateInvoiceNumber(String invoiceNumber)
        {
            Dto dto = (this.FormDto as FormDto).Dto as Facade.CheckIn.Dto;
            CrystalLodge.Room.CheckIn.ICheckIn checkIn = new CrystalLodge.Room.CheckIn.Server(new CrystalLodge.Room.CheckIn.Data { Id = dto.Id });
            return checkIn.UpdateInvoiceNumber(invoiceNumber);
        }

        private Boolean SaveArtifact(Vanilla.Invoice.Facade.FormDto invoiceFormDto, Table currentUser, Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            //Vanilla.Invoice.Facade.Dto invoiceDto = invoiceFormDto.dto;
           
            //artifactDto.Module = invoiceDto;
            //artifactDto.Style = Vanilla.Utility.Facade.Artifact.Type.Document;
            //artifactDto.AuditInfo.Version = 1;
            //artifactDto.AuditInfo.CreatedBy = new Table
            //{
            //    Id = currentUser.Id,
            //    Name = currentUser.Name
            //};
            //artifactDto.AuditInfo.CreatedAt = DateTime.Now;
            //artifactDto.Category = Vanilla.Utility.Facade.Artifact.Category.Form;
            //artifactDto.Path = invoiceDto.artifactPath;
            
            ////Vanilla.Utility.Facade.Artifact.Dto artifactDto = new Vanilla.Utility.Facade.Artifact.Dto
            ////{
            ////    Module = invoiceDto,
            ////    Style = Vanilla.Utility.Facade.Artifact.Type.Document,
            ////    Version = 1,
            ////    CreatedBy = new Table
            ////    {
            ////        Id = currentUser.Id,
            ////        Name = currentUser.Name
            ////    },
            ////    CreatedAt = DateTime.Now,
            ////    Category = Vanilla.Utility.Facade.Artifact.Category.Form,
            ////    Path = invoiceDto.artifactPath
            ////};
            
            //new Vanilla.Invoice.Facade.Server(invoiceFormDto).SaveArtifactForReservation(artifactDto);
            return true;
        }

        private Vanilla.Invoice.Facade.Dto ReadInvoice(String invoiceNumber)
        {
            Vanilla.Invoice.Facade.Dto invoiceDto = null;
            Crystal.Invoice.Component.IInvoice invoice = new Crystal.Invoice.Component.Server(new Crystal.Invoice.Component.Data());
            ReturnObject<Crystal.Invoice.Component.Data> retVal = invoice.GetInvoice(invoiceNumber);

            if (retVal != null)
                invoiceDto = new Vanilla.Invoice.Facade.Server(null).Convert(retVal.Value) as Vanilla.Invoice.Facade.Dto;

            return invoiceDto;
        }
        
        Vanilla.Invoice.Facade.Dto ICheckIn.ReadInvoice(string invoiceNumber)
        {
            return this.ReadInvoice(invoiceNumber);
        }

        protected override ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData)
        {
            return new RoomChkCrys.Navigator.Artifact.Server(artifactData as RoomChkCrys.Navigator.Artifact.Data);
        }

        protected override ArtfCrys.Observer.DocumentComponent GetComponentServer()
        {
            this.componentServer = new RoomChkCrys.Server(this.Convert((this.FormDto as FormDto).Dto) as RoomChkCrys.Data);
            return this.componentServer as ArtfCrys.Observer.DocumentComponent;
        }

        protected override String GetComponentDataType()
        {
            return "Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact.Data, Crystal.Lodge.Component";
        }

        public void PopulateInvoiceDto(Vanilla.Invoice.Facade.Dto invoiceDto)
        {
            Dto dto = (this.FormDto as Vanilla.Form.Facade.Document.FormDto).Dto as Dto;
            Facade.Taxation.ITaxation taxation = new Facade.Taxation.TaxationServer();
            List<Facade.Taxation.Dto> taxationList = taxation.ReadLodgeTaxation();

            //Vanilla.Invoice.Facade.Dto invoiceDto = new Vanilla.Invoice.Facade.Dto();
            invoiceDto.advance = dto.Reservation.Advance;
            invoiceDto.buyer = dto.Reservation.Customer == null ? null : new Vanilla.Invoice.Facade.Buyer.Dto
            {
                Name = dto.Reservation.Customer.Name,
                Address = dto.Reservation.Customer.Address,
                Email = dto.Reservation.Customer.Email,
                ContactNumber = dto.Reservation.Customer.ContactNumberList == null ? null : dto.Reservation.Customer.ContactNumberList[0].Name
            };
            this.PopulateSellerInfo(invoiceDto);
            List<LodgeConfFac.Room.Dto> roomList = dto.Reservation.RoomList;
            this.SetRoomDetail(roomList);
            invoiceDto.productList = this.GroupRoomList(roomList);
            this.AttachTariff(invoiceDto.productList);
            invoiceDto.taxationList = this.ConvertToInvoiceTaxationDto(taxationList);

        }

        private void PopulateSellerInfo(Vanilla.Invoice.Facade.Dto invoiceDto)
        {
            //populate seller info
            LodgeFacade.FormDto formDto = new LodgeFacade.FormDto();
            LodgeFacade.Server facade = new LodgeFacade.Server(formDto);
            facade.LoadForm();

            invoiceDto.seller = formDto.Lodge == null ? null : new Vanilla.Invoice.Facade.Seller.Dto
            {
                Id = formDto.Lodge.Id,
                Name = formDto.Lodge.Name,
                Address = formDto.Lodge.Address,
                Liscence = formDto.Lodge.LicenceNumber,
                Email = formDto.Lodge.EmailList == null ? null : formDto.Lodge.EmailList[0].Name,
                ContactNumber = formDto.Lodge.ContactNumberList == null ? null : formDto.Lodge.ContactNumberList[0].Name
            };

        }

        private void SetRoomDetail(List<LodgeConfFac.Room.Dto> roomList)
        {
            FormDto formDto = (this.FormDto as Vanilla.Form.Facade.Document.FormDto) as FormDto;

            foreach (LodgeConfFac.Room.Dto dto in roomList)
            {
                foreach (LodgeConfFac.Room.Dto roomDto in formDto.roomList)
                {
                    if (dto.Id == roomDto.Id)
                    {
                        dto.Category = new LodgeConfFac.Room.Category.Dto { Id = roomDto.Category.Id };
                        dto.Type = new LodgeConfFac.Room.Type.Dto { Id = roomDto.Type.Id };
                        dto.IsAirconditioned = roomDto.IsAirconditioned;
                        break;
                    }
                }
            }
        }

        private List<InvFac.LineItem.Dto> GroupRoomList(List<LodgeConfFac.Room.Dto> roomList)
        {
            Dto dto = (this.FormDto as Vanilla.Form.Facade.Document.FormDto).Dto as Dto;
            List<InvFac.LineItem.Dto> productList = new List<InvFac.LineItem.Dto>();
            Boolean blnAdd = false;

            if (roomList != null && roomList.Count > 0)
            {
                foreach (LodgeConfFac.Room.Dto dtoRoom in roomList)
                {
                    Vanilla.Invoice.Facade.LineItem.Dto productDto = new InvFac.LineItem.Dto()
                    {
                        Id = dtoRoom.Id,
                        startDate = dto.Reservation.BookingFrom,
                        roomCategoryId = dtoRoom.Category == null ? 0 : dtoRoom.Category.Id,
                        roomTypeId = dtoRoom.Type == null ? 0 : dtoRoom.Type.Id,
                        roomIsAC = dtoRoom.IsAirconditioned,
                        description = this.GetRoomDescription(dtoRoom.Id),
                        count = 1, //count is basically rooms of same type [i.e. same typeid, categoryId, and Ac] 
                        endDate = dto.Reservation.BookingFrom.AddDays(dto.Reservation.NoOfDays)
                    };

                    if (productList.Count == 0)
                    {
                        productList.Add(productDto);
                    }
                    else
                    {
                        blnAdd = true;
                        foreach (InvFac.LineItem.Dto roomDto in productList)
                        {
                            if (productDto.roomCategoryId == roomDto.roomCategoryId && productDto.roomTypeId == roomDto.roomTypeId && productDto.roomIsAC == roomDto.roomIsAC)
                            {
                                roomDto.count++;
                                blnAdd = false;
                                break;
                            }
                        }
                        if (blnAdd)
                        {
                            productList.Add(productDto);
                        }
                    }
                }
            }

            return productList;
        }

        private String GetRoomDescription(Int64 roomId)
        {
            FormDto formDto = (this.FormDto as Vanilla.Form.Facade.Document.FormDto) as FormDto;

            String roomDescription = String.Empty;
            if (formDto.roomList != null && formDto.roomList.Count > 0)
            {
                foreach (LodgeConfFac.Room.Dto dto in formDto.roomList)
                {
                    if (dto.Id == roomId)
                    {
                        roomDescription = dto.Category.Name + ", " + dto.Type.Name + ", " + (dto.IsAirconditioned ? "AC" : "Non AC");
                        break;
                    }
                }
            }

            return roomDescription;
        }

        private void AttachTariff(List<InvFac.LineItem.Dto> roomList)
        {
            //hit Lodge Room Tariff component
            TarrifFac.ITariff tariff = new TarrifFac.TariffServer(null);
            List<TarrifFac.Dto> tariffList = tariff.ReadAllCurrentTariff().Value;

            if (tariffList != null && tariffList.Count > 0)
            {
                foreach (Vanilla.Invoice.Facade.LineItem.Dto roomDto in roomList)
                {
                    foreach (TarrifFac.Dto tariffDto in tariffList)
                    {
                        if (roomDto.roomCategoryId == tariffDto.Category.Id && roomDto.roomTypeId == tariffDto.Type.Id && roomDto.roomIsAC == tariffDto.IsAC)
                        {
                            roomDto.unitRate = tariffDto.Rate;
                            roomDto.total = roomDto.unitRate * roomDto.count;
                            break;
                        }
                    }
                }
            }
        }

        private List<InvFac.Taxation.Dto> ConvertToInvoiceTaxationDto(List<Facade.Taxation.Dto> taxationList)
        {
            List<InvFac.Taxation.Dto> taxationDtoList = new List<InvFac.Taxation.Dto>();
            if (taxationList != null && taxationList.Count > 0)
            {
                foreach (Facade.Taxation.Dto dto in taxationList)
                {
                    taxationDtoList.Add(new InvFac.Taxation.Dto
                    {
                        Id = dto.Id,
                        Name = dto.Name,
                        Amount = dto.Amount,
                        isPercentage = dto.isPercentage
                    });
                }
            }

            return taxationDtoList;
        }

        public enum CheckInStatus
        {
            CheckIn = 10001,
            CheckOut = 10002
        }

    }

}
