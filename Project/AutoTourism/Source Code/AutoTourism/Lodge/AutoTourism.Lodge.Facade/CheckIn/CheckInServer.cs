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
            Dto checkInDto = (this.FormDto as FormDto).dto;
           
            LodgeFacade.RoomReservation.Dto reservationDto = checkInDto.Reservation;

            AutoTourism.Component.Customer.Data autoCustomer = new Component.Customer.Data
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
                //Initial = new Crystal.Configuration.Component.Initial.Data
                //{
                //    Id = reservationDto.Customer.Initial.Id,
                //    Name = reservationDto.Customer.Initial.Name
                //},
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
                Dto = ((this.FormDto) as FormDto).dto.Reservation
            };
            new LodgeFacade.RoomReservation.ReservationServer(reservationFormDto).Change();

            //update checkIn status
            CrystalLodge.Room.CheckIn.ICheckIn checkIn = new CrystalLodge.Room.CheckIn.Server(new CrystalLodge.Room.CheckIn.Data { Id = ((this.FormDto) as FormDto).dto.Id });
            checkIn.ModifyCheckInStatus(System.Convert.ToInt64(CheckInStatus.CheckOut));
        }

        ReturnObject<bool> ICheckIn.PaymentInsert(Vanilla.Invoice.Facade.FormDto invoiceFormDto, Table currentUser, Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            return this.MakePayment(invoiceFormDto, currentUser, artifactDto);            
        }

        private ReturnObject<Boolean> MakePayment(Vanilla.Invoice.Facade.FormDto invoiceFormDto, Table currentUser, Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>();

            Vanilla.Invoice.Facade.Dto invoiceDto = invoiceFormDto.dto;
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
                        {
                            //Save to Artifact
                            invoiceFormDto.dto.Id = invoiceData.Id;
                            this.SaveArtifact(invoiceFormDto, currentUser, artifactDto);

                            T.Complete();
                        }
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
            CrystalLodge.Room.CheckIn.ICheckIn checkIn = new CrystalLodge.Room.CheckIn.Server(new CrystalLodge.Room.CheckIn.Data { Id = ((this.FormDto) as FormDto).dto.Id });
            return checkIn.UpdateInvoiceNumber(invoiceNumber);
        }

        private Boolean SaveArtifact(Vanilla.Invoice.Facade.FormDto invoiceFormDto, Table currentUser, Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            Vanilla.Invoice.Facade.Dto invoiceDto = invoiceFormDto.dto;
           
            artifactDto.Module = invoiceDto;
            artifactDto.Style = Vanilla.Utility.Facade.Artifact.Type.Document;
            artifactDto.AuditInfo.Version = 1;
            artifactDto.AuditInfo.CreatedBy = new Table
            {
                Id = currentUser.Id,
                Name = currentUser.Name
            };
            artifactDto.AuditInfo.CreatedAt = DateTime.Now;
            artifactDto.Category = Vanilla.Utility.Facade.Artifact.Category.Form;
            artifactDto.Path = invoiceDto.artifactPath;
            
            //Vanilla.Utility.Facade.Artifact.Dto artifactDto = new Vanilla.Utility.Facade.Artifact.Dto
            //{
            //    Module = invoiceDto,
            //    Style = Vanilla.Utility.Facade.Artifact.Type.Document,
            //    Version = 1,
            //    CreatedBy = new Table
            //    {
            //        Id = currentUser.Id,
            //        Name = currentUser.Name
            //    },
            //    CreatedAt = DateTime.Now,
            //    Category = Vanilla.Utility.Facade.Artifact.Category.Form,
            //    Path = invoiceDto.artifactPath
            //};
            
            new Vanilla.Invoice.Facade.Server(invoiceFormDto).SaveArtifactForReservation(artifactDto);
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

        public enum CheckInStatus
        {
            CheckIn = 10001,
            CheckOut = 10002
        }

    }

}
