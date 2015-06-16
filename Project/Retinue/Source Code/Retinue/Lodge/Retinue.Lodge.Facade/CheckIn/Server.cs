using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;
using BinAff.Utility;

using ActCrys = Crystal.Customer.Component.Action;
using LodgeCrys = Retinue.Lodge.Component;
using CustCrys = Crystal.Customer.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using RoomChkCrys = Retinue.Lodge.Component.Room.CheckIn;
using RoomRsvCrys = Retinue.Lodge.Component.Room.Reservation;
using ChkArtfCrys = Retinue.Lodge.Component.Room.CheckIn.Navigator.Artifact;
using ConfCrys = Crystal.Configuration.Component;
using InvCrys = Crystal.Accountant.Component.Invoice;

using InvFac = Vanilla.Accountant.Facade.Invoice;
using PayFac = Vanilla.Accountant.Facade.Payment;
using TaxFac = Vanilla.Accountant.Facade.Taxation;
using DocFac = Vanilla.Form.Facade.Document;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

using CustAuto = Retinue.Customer.Component;

using RuleFac = Retinue.Configuration.Rule.Facade;
using CustFac = Retinue.Customer.Facade;
using LodgeFac = Retinue.Lodge.Facade;
using RoomRsvFac = Retinue.Lodge.Facade.RoomReservation;
using TarrifFac = Retinue.Lodge.Configuration.Facade.Tariff;
using RoomFac = Retinue.Lodge.Configuration.Facade.Room;
using RoomCatFac = Retinue.Lodge.Configuration.Facade.Room.Category;
using RoomTypeFac = Retinue.Lodge.Configuration.Facade.Room.Type;

namespace Retinue.Lodge.Facade.CheckIn
{

    public class Server : DocFac.Server, ICheckIn
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }
        
        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            Retinue.Utility.Facade.Cache.Dto cache = BinAff.Facade.Cache.Server.Current.Cache["Main"] as Retinue.Utility.Facade.Cache.Dto;
            formDto.AllRoomList = cache.RoomList;
            formDto.ConfigurationRuleDto = this.ReadConfigurationRule().Value;
            formDto.CategoryList = cache.RoomCategoryList;
            formDto.TypeList = cache.RoomTypeList;
        }

        private ReturnObject<RuleFac.ConfigurationRuleDto> ReadConfigurationRule()
        {
            return new RuleFac.RuleServer().ReadConfigurationRule();
        }
        
        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto checkIn = dto as Dto;
            RoomChkCrys.Data data = new RoomChkCrys.Data
            {
                Id = dto.Id,
                ActivityDate = checkIn.Date,
                Status = new CustCrys.Action.Status.Data
                {
                    Id = System.Convert.ToInt64(RoomReservation.Status.CheckedIn)
                },
                Purpose = checkIn.Purpose,
                ArrivedFrom = checkIn.ArrivedFrom,
                Remark = checkIn.Remark,
                CompletionTime = checkIn.CheckOutTime,
            };
            if (checkIn.Reservation != null)
            {
                data.Reservation = new RoomReservation.Server(null).Convert(checkIn.Reservation) as LodgeCrys.Room.Reservation.Data;
            }
            if (checkIn.Invoice != null)
            {
                data.Invoice = new InvFac.Server(null).Convert(checkIn.Invoice) as InvCrys.Data;
            }
            return data;
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            LodgeCrys.Room.CheckIn.Data comp = data as LodgeCrys.Room.CheckIn.Data;
            Dto dto = new Dto
            {
                Id = data.Id,
                Date = comp.ActivityDate,
                InvoiceNumber = comp.invoiceNumber,
                Purpose = comp.Purpose,
                ArrivedFrom = comp.ArrivedFrom,
                Remark = comp.Remark,
                CheckOutTime = comp.CompletionTime,
                
                Invoice = comp.Invoice == null?
                    null : new InvFac.Server(null).Convert(comp.Invoice) as InvFac.Dto,
            };
            dto.Remarks = comp.Remark;
            if(comp.Reservation != null)
            {
                dto.Reservation = new RoomRsvFac.Server(null).Convert(comp.Reservation) as RoomReservation.Dto;
                dto.Reservation.To = dto.CheckOutTime;
            }
            if (comp.Status != null && comp.Status.Id != 0)
            {
                dto.Status = (RoomRsvFac.Status)comp.Status.Id;
                if (dto.Reservation != null) dto.Reservation.Status = dto.Status;
            }
            return dto;
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
                Facade.CheckIn.Dto dto = (this.FormDto as FormDto).Dto as Facade.CheckIn.Dto;
                CustAuto.Data cust = new CustFac.Server(null).Convert(dto.Reservation.Customer) as CustAuto.Data;
                cust.Checkin.Active = this.Convert(dto) as CustCrys.Action.Data;
                cust.RoomReserver.Active = (cust.Checkin.Active as RoomChkCrys.Data).Reservation as CustCrys.Action.Data;
                cust.Checkin.Active.ProductList = dto.Reservation.RoomList == null ? null : this.GetRoomDataList(dto.Reservation.RoomList);

                CustAuto.Server custServer = new CustAuto.Server(cust);
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

        public List<Data> GetRoomDataList(List<RoomFac.Dto> RoomList)
        {
            List<Data> RoomDataList = new List<Data>();
            foreach (RoomFac.Dto dto in RoomList)
            {
                RoomDataList.Add(new LodgeCrys.Room.Data
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

            //To Do :: This code will be moved to WinForm
            Int32 noOfDays = new Calender().DaysBetweenTwoDays(dto.Reservation.BookingFrom, DateTime.Today);
            if (noOfDays != dto.Reservation.NoOfDays)
            {
                this.DisplayMessageList = new List<String>
                {
                    "Check out date is not matching with reservation end date. Reservation end date will be changed with checkout.",
                };
            }

            dto.Reservation.NoOfDays = noOfDays == 0 ? 1 : noOfDays;
            dto.Reservation.Status = RoomRsvFac.Status.CheckOut;
            dto.Reservation.IsBackDateEntry = true;
            RoomChkCrys.Data checkinData = this.Convert(dto) as RoomChkCrys.Data;
            ReturnObject<Boolean> ret = (new RoomChkCrys.Server(checkinData) as RoomChkCrys.ICheckIn).CheckOut();

            if (this.IsError = !ret.Value)
            {
                this.DisplayMessageList = new List<String> { "Customer checked out failed." };
            }
            else
            {
                this.DisplayMessageList = new List<String> { "Customer successfully checked out." };
                dto.Status = RoomRsvFac.Status.CheckOut;
                dto.CheckOutTime = checkinData.CompletionTime;
            }
        }

        //ReturnObject<bool> ICheckIn.PaymentInsert(InvFac.FormDto invoiceFormDto, Table currentUser, ArtfFac.Dto artifactDto)
        //{
        //    return this.MakePayment(invoiceFormDto, currentUser, artifactDto);            
        //}

        //private ReturnObject<Boolean> MakePayment(InvFac.FormDto invoiceFormDto, Table currentUser, ArtfFac.Dto artifactDto)
        //{
        //    ReturnObject<Boolean> ret = new ReturnObject<bool>();

        //    InvFac.Dto invoiceDto = invoiceFormDto.dto;
        //    CustAuto.Data autoCustomer = new CustAuto.Data
        //    {
        //        Invoice = new Crystal.Accountant.Component.InvoiceContainer.Data
        //        {
        //            Active = this.ConvertToInvoiceData(invoiceDto) as CustCrys.Action.Data
        //        }
        //    };

        //    using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
        //    {
        //        //Save Invoice Data
        //        CustCrys.ICustomer customer = new CustAuto.Server(autoCustomer);
        //        ret = customer.GenerateInvoice();

        //        if (ret.Value)
        //        {
        //            Crystal.Accountant.Component.Invoice.Data invoiceData = (autoCustomer.Invoice as Crystal.Invoice.Component.InvoiceContainer.Data).Active as Crystal.Invoice.Component.Data;
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

        //ReturnObject<bool> ICheckIn.PaymentInsert(InvFac.Dto invoiceDto)
        //{
        //    return this.MakePayment(invoiceDto);
        //}

        //private ReturnObject<Boolean> MakePayment(InvFac.Dto invoiceDto)
        //{
        //    ReturnObject<Boolean> ret = new ReturnObject<bool>();
                        
        //    CustAuto.Data autoCustomer = new CustAuto.Data
        //    {
        //        Invoice = new Crystal.Invoice.Component.InvoiceContainer.Data
        //        {
        //            //Active = this.ConvertToInvoiceData(invoiceDto) as CustCrys.Action.Data
        //        }
        //    };

        //    using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
        //    {
        //        //Save Invoice Data
        //        CustCrys.ICustomer customer = new CustAuto.Server(autoCustomer);
        //        ret = customer.GenerateInvoice();

        //        if (ret.Value)
        //        {
        //            Crystal.Invoice.Component.Data invoiceData = (autoCustomer.Invoice as Crystal.Invoice.Component.InvoiceContainer.Data).Active as Crystal.Invoice.Component.Data;
        //            if (invoiceData.Id > 0)
        //            {
        //                //Update invoice number to CheckIn table
        //                ret = this.UpdateInvoiceNumber(invoiceData.InvoiceNumber);
        //                if (ret.Value) 
        //                    T.Complete();
                        
        //            }
        //        }
        //    }

        //    return ret;
        //}

        //private BinAff.Core.Data ConvertToInvoiceData(BinAff.Facade.Library.Dto dto)
        //{
        //    InvFac.Dto invoiceDto = dto as InvFac.Dto;

        //    return new Crystal.Invoice.Component.Data()
        //    {
        //        InvoiceNumber = invoiceDto.invoiceNumber,
        //        Advance = invoiceDto.advance,
        //        Discount = invoiceDto.discount,
        //        Date = System.DateTime.Now,
        //        Seller = this.GetSeller(invoiceDto.seller),
        //        Buyer = this.GetBuyer(invoiceDto.buyer),
        //        LineItem = this.GetLineItem(invoiceDto.productList),
        //        Taxation = this.GetTaxation(invoiceDto.taxationList),
        //        Payment = this.GetPayments(invoiceDto.paymentList)
        //    };
        //}

        //private Crystal.Invoice.Component.Seller GetSeller(InvFac.Seller.Dto seller)
        //{
        //    return new Crystal.Invoice.Component.Seller
        //    {
        //        Name = seller.Name,
        //        Address = seller.Address,
        //        Liscence = seller.Liscence,
        //        Email = seller.Email,
        //        ContactNumber = seller.ContactNumber
        //    };
        //}

        //private Crystal.Invoice.Component.Buyer GetBuyer(InvFac.Buyer.Dto buyer)
        //{
        //    return new Crystal.Invoice.Component.Buyer
        //    {
        //        Name = buyer.Name,
        //        Address = buyer.Address,
        //        Email = buyer.Email,
        //        ContactNumber = buyer.ContactNumber
        //    };
        //}

        //private List<BinAff.Core.Data> GetLineItem(List<InvFac.LineItem.Dto> roomList)
        //{
        //    List<BinAff.Core.Data> lineItemList = new List<Data>();
        //    if (roomList != null && roomList.Count > 0)
        //    {
        //        foreach (InvFac.LineItem.Dto lineItem in roomList)
        //        {
        //            lineItemList.Add(new Crystal.Invoice.Component.LineItem.Data
        //            {
        //                Start = lineItem.startDate,
        //                End = lineItem.endDate,
        //                Description = lineItem.description,
        //                UnitRate = lineItem.unitRate,
        //                Count = lineItem.count,
        //                Total = lineItem.total
        //            });
        //        }
        //    }
        //    return lineItemList;
        //}

        //private List<BinAff.Core.Data> GetTaxation(List<InvFac.Taxation.Dto> taxationList)
        //{
        //    List<BinAff.Core.Data> taxationDataList = new List<Data>();
        //    if (taxationList != null && taxationList.Count > 0)
        //    {
        //        foreach (InvFac.Taxation.Dto dto in taxationList)
        //        {
        //            taxationDataList.Add(new Crystal.Invoice.Component.Taxation.Data
        //            {
        //                Id = dto.Id,
        //                Name = dto.Name,
        //                Amount = dto.Amount,
        //                isPercentage = dto.isPercentage
        //            });
        //        }
        //    }
        //    return taxationDataList;
        //}

        //private List<BinAff.Core.Data> GetPayments(List<InvFac.Payment.Dto> paymentList)
        //{
        //    List<BinAff.Core.Data> paymentDataList = new List<Data>();
        //    if (paymentList != null && paymentList.Count > 0)
        //    {
        //        foreach (InvFac.Payment.Dto dto in paymentList)
        //        {
        //            paymentDataList.Add(new Crystal.Invoice.Component.Payment.Data
        //            {
        //                Id = dto.Id,
        //                Type = new Crystal.Invoice.Component.Payment.Type.Data { Id = dto.Type.Id },
        //                CardNumber = dto.cardNumber,
        //                Remark = dto.remark,
        //                Amount = dto.amount,
        //            });
        //        }
        //    }
        //    return paymentDataList;
        //}

        public ReturnObject<Boolean> LinkInvoice()
        {
            Dto dto = (this.FormDto as FormDto).Dto as Facade.CheckIn.Dto;
            this.componentServer = this.GetComponentServer();
            ((this.componentServer as Crud).Data as RoomChkCrys.Data).Invoice = new InvFac.Server(null).Convert(((base.FormDto as FormDto).Dto as Dto).Invoice) as InvCrys.Data;
            ((this.componentServer as Crud).Data as RoomChkCrys.Data).Status = new ActCrys.Status.Data
            {
                Id = 10007, //Invoiced
            };
            return (this.componentServer as RoomChkCrys.ICheckIn).LinkInvoice();
        }

        private Boolean SaveArtifact(InvFac.FormDto invoiceFormDto, Table currentUser, ArtfFac.Dto artifactDto)
        {
            //InvFac.Dto invoiceDto = invoiceFormDto.dto;
           
            //artifactDto.Module = invoiceDto;
            //artifactDto.Style = ArtfFac.Type.Document;
            //artifactDto.AuditInfo.Version = 1;
            //artifactDto.AuditInfo.CreatedBy = new Table
            //{
            //    Id = currentUser.Id,
            //    Name = currentUser.Name
            //};
            //artifactDto.AuditInfo.CreatedAt = DateTime.Now;
            //artifactDto.Category = ArtfFac.Category.Form;
            //artifactDto.Path = invoiceDto.artifactPath;
            
            ////ArtfFac.Dto artifactDto = new ArtfFac.Dto
            ////{
            ////    Module = invoiceDto,
            ////    Style = ArtfFac.Type.Document,
            ////    Version = 1,
            ////    CreatedBy = new Table
            ////    {
            ////        Id = currentUser.Id,
            ////        Name = currentUser.Name
            ////    },
            ////    CreatedAt = DateTime.Now,
            ////    Category = ArtfFac.Category.Form,
            ////    Path = invoiceDto.artifactPath
            ////};
            
            //new InvFac.Server(invoiceFormDto).SaveArtifactForReservation(artifactDto);
            return true;
        }

        //private InvFac.Dto ReadInvoice(String invoiceNumber)
        //{
        //    InvFac.Dto invoiceDto = null;
        //    //Crystal.Invoice.Component.IInvoice invoice = new Crystal.Invoice.Component.Server(new Crystal.Invoice.Component.Data());
        //    //ReturnObject<Crystal.Invoice.Component.Data> retVal = invoice.GetInvoice(invoiceNumber);

        //    InvFac.IInvoice invoice = new InvFac.Server(null);
        //    invoice.GetInvoice(invoiceNumber);
        //    //ReturnObject<Crystal.Invoice.Component.Data> retVal = invoice.GetInvoice(invoiceNumber);

        //    //if (retVal != null)
        //    //    invoiceDto = new InvFac.Server(null).Convert(retVal.Value) as InvFac.Dto;

        //    return invoiceDto;
        //}
        
        //InvFac.Dto ICheckIn.ReadInvoice(string invoiceNumber)
        //{
        //    return this.ReadInvoice(invoiceNumber);
        //}

        protected override ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData)
        {
            return new ChkArtfCrys.Server(artifactData as ChkArtfCrys.Data);
        }

        protected override ICrud GetComponentServer()
        {
            this.componentServer = new RoomChkCrys.Server(this.Convert((this.FormDto as FormDto).Dto) as RoomChkCrys.Data);
            return this.componentServer;
        }

        protected override String GetComponentDataType()
        {
            return "Retinue.Lodge.Component.Room.CheckIn.Navigator.Artifact.Data, Retinue.Lodge.Component";
        }

        protected override ArtfCrys.Data GetArtifactData(Int64 artifactId)
        {
            return new ChkArtfCrys.Data { Id = artifactId };
        }

        protected override BinAff.Core.Observer.IRegistrar GetRegisterer()
        {
            return new Retinue.Lodge.Observer.RoomCheckIn();
        }

        protected override String GetAttachmentComponentCode()
        {
            return "PAMT";
        }

        public override Vanilla.Utility.Facade.Module.Definition.Dto GetAncestorComponentCode()
        {
            return (BinAff.Facade.Cache.Server.Current.Cache["Main"] as Vanilla.Utility.Facade.Cache.Dto).ComponentDefinitionList.FindLast((
                    (p) => { return p.Code == new RoomRsvFac.Server(null).GetComponentCode(); }));
        }

        public void PopulateInvoiceDto(InvFac.Dto invoiceDto)
        {
            Dto dto = (this.FormDto as DocFac.FormDto).Dto as Dto;
            invoiceDto.Buyer = this.GetBuyer(dto.Reservation.Customer);
            this.PopulateSeller(invoiceDto);
            invoiceDto.Date = DateTime.Now;
            invoiceDto.ProductList = this.GroupRoomList(dto.Reservation.RoomList);
            if (dto.Reservation.NoOfDays > 1)
            {
                invoiceDto.ProductList = this.GenerateLineItemsForEachDay(dto.Reservation.NoOfDays, invoiceDto.ProductList);
            }

            this.AttachTariff(invoiceDto.ProductList);
            this.AttachAdvancePaymentList(invoiceDto);
            this.AttachTaxList(invoiceDto);
        }

        private InvFac.Buyer.Dto GetBuyer(CustFac.Dto customer)
        {
            return customer == null ? null : new InvFac.Buyer.Dto
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                Email = customer.Email,
                ContactNumber = customer.ContactNumberList == null ? null : customer.ContactNumberList[0].Name
            };
        }

        private void PopulateSeller(InvFac.Dto invoiceDto)
        {
            //////////////////////////
            //Should come from cahe
            //////////////////////////
            //populate seller info
            LodgeFac.FormDto formDto = new LodgeFac.FormDto();
            LodgeFac.Server facade = new LodgeFac.Server(formDto);
            facade.LoadForm();

            invoiceDto.Seller = formDto.Lodge == null ? null : new InvFac.Seller.Dto
            {
                Id = formDto.Lodge.Id,
                Name = formDto.Lodge.Name,
                Address = formDto.Lodge.Address,
                Liscence = formDto.Lodge.LicenceNumber,
                Email = formDto.Lodge.EmailList == null ? null : formDto.Lodge.EmailList[0].Name,
                ContactNumber = formDto.Lodge.ContactNumberList == null ? null : formDto.Lodge.ContactNumberList[0].Name
            };

        }

        private List<InvFac.LineItem.Dto> GroupRoomList(List<RoomFac.Dto> roomList)
        {
            Dto dto = (this.FormDto as DocFac.FormDto).Dto as Dto;
            List<InvFac.LineItem.Dto> productList = new List<InvFac.LineItem.Dto>();
            Boolean blnAdd = false;

            if (roomList != null && roomList.Count > 0)
            {
                foreach (RoomFac.Dto dtoRoom in roomList)
                {
                    //String roomDetails = String.Empty;
                    InvFac.LineItem.Dto productDto = new InvFac.LineItem.Dto
                    {
                        StartDate = dto.Reservation.BookingFrom,
                        RoomCategoryId = dtoRoom.Category == null ? 0 : dtoRoom.Category.Id,
                        RoomTypeId = dtoRoom.Type == null ? 0 : dtoRoom.Type.Id,
                        RoomIsAC = dtoRoom.IsAirconditioned,
                        Count = 1, //count is basically rooms of same type [i.e. same typeid, categoryId, and Ac] 
                        EndDate = dto.Reservation.BookingFrom.AddDays(1), //Every time one day for daywise bill - This will be configurable for 24 hours or check out fix time
                    };

                    if (productList.Count == 0)
                    {
                        productList.Add(productDto);
                        productDto.Description = this.GetRoomDescription(dtoRoom);
                    }
                    else
                    {
                        blnAdd = true;
                        foreach (InvFac.LineItem.Dto roomDto in productList)
                        {
                            if (productDto.RoomCategoryId == roomDto.RoomCategoryId
                                && productDto.RoomTypeId == roomDto.RoomTypeId
                                && productDto.RoomIsAC == roomDto.RoomIsAC)
                            {
                                roomDto.Count++;
                                productList.FindLast((p) =>
                                {
                                    return p.RoomCategoryId == roomDto.RoomCategoryId
                                        && p.RoomTypeId == roomDto.RoomTypeId
                                        && p.RoomIsAC == roomDto.RoomIsAC;
                                }).Description = this.AppendRoomDescription(roomDto.Description, dtoRoom.Number, dtoRoom.Name);
                                blnAdd = false;
                                break;
                            }
                            else
                            {
                                productDto.Description = this.GetRoomDescription(dtoRoom);
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

        //private void SetRoomDetail(List<RoomFac.Dto> roomList)
        //{
        //    FormDto formDto = (this.FormDto as DocFac.FormDto) as FormDto;

        //    foreach (LRoomFac.Dto dto in roomList)
        //    {
        //        foreach (RoomFac.Dto roomDto in formDto.roomList)
        //        {
        //            if (dto.Id == roomDto.Id)
        //            {
        //                dto.Category = new RoomFac.Category.Dto { Id = roomDto.Category.Id };
        //                dto.Type = new RoomFac.Type.Dto { Id = roomDto.Type.Id };
        //                dto.IsAirconditioned = roomDto.IsAirconditioned;
        //                break;
        //            }
        //        }
        //    }
        //}

        //private List<InvFac.LineItem.Dto> GroupRoomList(List<RoomFac.Dto> roomList)
        //{
        //    Dto dto = (this.FormDto as DocFac.FormDto).Dto as Dto;
        //    List<InvFac.LineItem.Dto> productList = new List<InvFac.LineItem.Dto>();
        //    Boolean blnAdd = false;

        //    if (roomList != null && roomList.Count > 0)
        //    {
        //        foreach (RoomFac.Dto dtoRoom in roomList)
        //        {
        //            InvFac.LineItem.Dto productDto = new InvFac.LineItem.Dto
        //            {
        //                Id = dtoRoom.Id,
        //                StartDate = dto.Reservation.BookingFrom,
        //                RoomCategoryId = dtoRoom.Category == null ? 0 : dtoRoom.Category.Id,
        //                RoomTypeId = dtoRoom.Type == null ? 0 : dtoRoom.Type.Id,
        //                RoomIsAC = dtoRoom.IsAirconditioned,
        //                Description = this.GetRoomDescription(dtoRoom),
        //                Count = 1, //count is basically rooms of same type [i.e. same typeid, categoryId, and Ac] 
        //                EndDate = dto.Reservation.BookingFrom.AddDays(1), //Every time one day for daywise bill
        //            };

        //            if (productList.Count == 0)
        //            {
        //                productList.Add(productDto);
        //            }
        //            else
        //            {
        //                blnAdd = true;
        //                foreach (InvFac.LineItem.Dto roomDto in productList)
        //                {
        //                    if (productDto.RoomCategoryId == roomDto.RoomCategoryId 
        //                        && productDto.RoomTypeId == roomDto.RoomTypeId && productDto.RoomIsAC == roomDto.RoomIsAC)
        //                    {
        //                        roomDto.Count++;
        //                        blnAdd = false;
        //                        break;
        //                    }
        //                }
        //                if (blnAdd)
        //                {
        //                    productList.Add(productDto);
        //                }
        //            }
        //        }
        //    }

        //    return productList;
        //}

        private List<InvFac.LineItem.Dto> GenerateLineItemsForEachDay(int noOfdays,List<InvFac.LineItem.Dto> lineItems)
        {
            List<InvFac.LineItem.Dto> productList = new List<InvFac.LineItem.Dto>();
            DateTime stDate = DateTime.MinValue;

            for (int i = 0; i < noOfdays; i++)
            {
                foreach (InvFac.LineItem.Dto lineItem in lineItems)
                {
                    if(i == 0)
                        stDate = lineItem.StartDate;

                    InvFac.LineItem.Dto productDto = new InvFac.LineItem.Dto()
                    {
                        Id = lineItem.Id,
                        StartDate = stDate,
                        RoomCategoryId = lineItem.RoomCategoryId,
                        RoomTypeId = lineItem.RoomTypeId,
                        RoomIsAC = lineItem.RoomIsAC,
                        Description = lineItem.Description,
                        Count = lineItem.Count,
                        EndDate = stDate.AddDays(1)
                    };

                    productList.Add(productDto);
                    stDate = stDate.AddDays(1);
                }
            }

            return productList;
        }

        private String GetRoomDescription(RoomFac.Dto room)
        {
            String roomList = String.Empty;

            return String.Format("{0}, {1}, {2} : Room - {3}({4})",
                room.Category.Name, room.Type.Name, room.IsAirconditioned ? "AC" : "Non AC",
                room.Number, room.Name);
        }

        private String AppendRoomDescription(String exisitng, String roomNumber, String roomName)
        {
            return String.Format("{0}, {1}({2})", exisitng, roomNumber, roomName);
        }

        private void AttachAdvancePaymentList(InvFac.Dto invoiceDto)
        {
            //Get advances from reservation
            List<PayFac.Dto> advancePaymentList = new Facade.RoomReservation.Server(new Facade.RoomReservation.FormDto
            {
                Dto = ((base.FormDto as FormDto).Document.Module as Dto).Reservation,
                Document = new ArtfFac.Dto
                {
                    Module = ((base.FormDto as FormDto).Document.Module as Dto).Reservation
                },
            }).GetAdvancePaymentList();
            if (advancePaymentList != null && advancePaymentList.Count > 0)
            {
                invoiceDto.AdvancePaymentList = advancePaymentList;
            }
            if ((base.FormDto as FormDto).Document.AttachmentList != null && (base.FormDto as FormDto).Document.AttachmentList.Count > 0)
            {
                if (invoiceDto.AdvancePaymentList == null) invoiceDto.AdvancePaymentList = new List<PayFac.Dto>();
                invoiceDto.AdvancePaymentList.AddRange((base.FormDto as FormDto).Document.AttachmentList.ConvertAll((p) =>
                {
                    return p.Module as PayFac.Dto;
                }));
            }
            //Reservation advances
        }

        private void AttachTariff(List<InvFac.LineItem.Dto> roomList)
        {
            //hit Lodge Room Tariff component
            TarrifFac.ITariff tariff = new TarrifFac.TariffServer(null);
            List<TarrifFac.Dto> tariffList = tariff.ReadAllCurrentTariff().Value;

            if (tariffList != null && tariffList.Count > 0)
            {
                foreach (InvFac.LineItem.Dto roomDto in roomList)
                {
                    foreach (TarrifFac.Dto tariffDto in tariffList)
                    {
                        if (roomDto.RoomCategoryId == tariffDto.Category.Id && roomDto.RoomTypeId == tariffDto.Type.Id && roomDto.RoomIsAC == tariffDto.IsAC)
                        {
                            roomDto.UnitRate = tariffDto.Rate;
                            break;
                        }
                    }
                }
            }
        }

        private void AttachTaxList(InvFac.Dto invoiceDto)
        {
            this.AssignLineItemWiseTax(invoiceDto.ProductList);
            //Add over all tax, not line item wise
        }

        private void AssignLineItemWiseTax(List<InvFac.LineItem.Dto> itemList)
        {
            foreach (InvFac.LineItem.Dto lineItem in itemList)
            {
                List<Taxation.Dto> taxationList = (new Taxation.Server() as Taxation.ITaxation).ReadLodgeTaxation(lineItem.UnitRate * lineItem.Count);

                lineItem.TaxList = taxationList.ConvertAll<BinAff.Facade.Library.Dto>((p) =>
                {
                    return new TaxFac.Dto
                    {
                        Name = p.Name,
                        Amount = p.Amount,
                        IsPercentage = p.IsPercentage
                    };
                });
            }
        }

        //private List<InvFac.Taxation.Dto> ConvertToInvoiceTaxationDto(List<Taxation.Dto> taxationList)
        //{
        //    List<InvFac.Taxation.Dto> taxationDtoList = new List<InvFac.Taxation.Dto>();
        //    if (taxationList != null && taxationList.Count > 0)
        //    {
        //        foreach (Taxation.Dto dto in taxationList)
        //        {
        //            taxationDtoList.Add(new InvFac.Taxation.Dto
        //            {
        //                Id = dto.Id,
        //                Name = dto.Name,
        //                Amount = dto.Amount,
        //                isPercentage = dto.IsPercentage
        //            });
        //        }
        //    }

        //    return taxationDtoList;
        //}

        public ReturnObject<Boolean> GenerateInvoice()
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //CustAuto.Data autoCustomer = new CustAuto.Data
            //{
            //    Invoice = new Crystal.Accountant.Component.InvoiceContainer.Data
            //    {
            //        Active = this.ConvertToInvoiceData(invoiceDto) as CustCrys.Action.Data
            //    }
            //};

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                InvFac.FormDto invoiceFormDto = new InvFac.FormDto();
                invoiceFormDto.Dto = (base.FormDto as Facade.CheckIn.FormDto).InvoiceDto;
                InvFac.Server invoiceServer = new InvFac.Server(invoiceFormDto);
                ret = invoiceServer.GenerateInvoice();
                
                ////Save Invoice Data
                //CustCrys.ICustomer customer = new CustAuto.Server(autoCustomer);
                //ret = customer.GenerateInvoice();

                if (ret.Value)
                {
                    //Crystal.Accountant.Component.Invoice.Data invoiceData = (autoCustomer.Invoice as Crystal.Invoice.Component.InvoiceContainer.Data).Active as Crystal.Invoice.Component.Data;
                                                
                    //Update invoice number to CheckIn table
                    ((base.FormDto as FormDto).Dto as Dto).Invoice = invoiceFormDto.Dto as InvFac.Dto;
                    ret = this.LinkInvoice();
                    if (ret.Value)
                        T.Complete();
                   
                }
            }

            return ret;
        }

        public override string GetComponentCode()
        {
            return "LCHK";
        }

        public void RemoveAllBookedRoom()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            RoomRsvFac.FormDto reservFormDto = new RoomReservation.FormDto
            {
                Dto = new RoomRsvFac.Dto
                {
                    Id = dto.Reservation.Id,
                    BookingFrom = dto.Reservation.BookingFrom,
                    NoOfDays = dto.Reservation.NoOfDays
                },
                FilteredRoomList = formDto.FilteredRoomList,
                AllRoomList = formDto.AllRoomList
            };
            reservFormDto = new RoomRsvFac.Server(reservFormDto).RemoveAllBookedRoom();
            formDto.FilteredRoomList = reservFormDto.FilteredRoomList;
            formDto.AvailableRoomCount = reservFormDto.AvailableRoomCount;
        }

        public void PopulateRoomWithCriteria()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            if (formDto.FilteredRoomList == null)
                return;

            RoomRsvFac.FormDto reservFormDto = new RoomReservation.FormDto
            {                
                FilteredRoomList = formDto.FilteredRoomList,
                RoomList = formDto.RoomList,  
                AllRoomList = formDto.AllRoomList,
                SelectedRoomList = formDto.SelectedRoomList,
                Dto = new RoomRsvFac.Dto
                {
                    Id = dto.Reservation.Id,
                    RoomCategory = dto.Reservation.RoomCategory,
                    RoomType = dto.Reservation.RoomType,
                    ACPreference = dto.Reservation.ACPreference,
                    NoOfDays = dto.Reservation.NoOfDays,
                    BookingFrom = dto.Reservation.BookingFrom,
                }
            };
            reservFormDto = new RoomRsvFac.Server(reservFormDto).PopulateRoomWithCriteria();
            formDto.RoomList = reservFormDto.RoomList;
            formDto.AvailableRoomCount = reservFormDto.AvailableRoomCount;
        }

        public Int32 GetTotalNoRooms()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            RoomRsvFac.FormDto reservFormDto = new RoomReservation.FormDto
            {               
                Dto = new RoomRsvFac.Dto
                {
                    RoomCategory = dto.Reservation.RoomCategory,
                    RoomType = dto.Reservation.RoomType,
                    ACPreference = dto.Reservation.ACPreference
                },
                FilteredRoomList = formDto.FilteredRoomList
            };
            return new RoomRsvFac.Server(reservFormDto).GetTotalNoRooms();
        }

        public void RemoveRoomFromAllRoomList(RoomFac.Dto room)
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.RoomList.Remove(room);

            if (formDto.SelectedRoomList == null)
                formDto.SelectedRoomList = new List<RoomFac.Dto>();

            formDto.SelectedRoomList.Add(room);            

            if (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 1)
                formDto.SelectedRoomList = new RoomRsvFac.Server(null).SortRoomListByRoomNo(formDto.SelectedRoomList);
        }

        public void AddRoomToAllRoomList(RoomFac.Dto room)
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;
         
            RoomRsvFac.FormDto reservFormDto = new RoomReservation.FormDto
            {
                SelectedRoomList = formDto.SelectedRoomList,
                RoomList = formDto.RoomList,               
            };
            reservFormDto = new RoomRsvFac.Server(reservFormDto).AddRoomToAllRoomList(room);
            formDto.SelectedRoomList = reservFormDto.SelectedRoomList;
            formDto.RoomList = reservFormDto.RoomList;           
        }

        public ArtfFac.Dto ReadInvoice()
        {
            InvCrys.Data inv = new InvFac.Server(null).Convert(((base.FormDto as FormDto).Dto as Facade.CheckIn.Dto).Invoice) as InvCrys.Data;
            ArtfCrys.IArtifact artf = new InvCrys.Navigator.Artifact.Server(new InvCrys.Navigator.Artifact.Data
            {
                ComponentData = inv,
            });
            ReturnObject<ArtfCrys.Data> ret = artf.ReadForComponent();
            return new ArtfFac.Server(null)
            {
                ModuleFacade = new InvFac.Server(this.FormDto as InvFac.FormDto)
            }.Convert(ret.Value) as ArtfFac.Dto;
        }
        
        private Int64 ReadCheckInId(Int64 artifactId)
        {
            RoomChkCrys.Server server = new RoomChkCrys.Server(null);
            return server.ReadCheckInId(artifactId);
        }
        
    }

}