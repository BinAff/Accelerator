using System;
using System.Collections.Generic;

using BinAff.Core;
using FacLib = BinAff.Facade.Library;

using PayCrys = Crystal.Invoice.Component.Payment;
using CustCrys = Crystal.Customer.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using InvCrys = Crystal.Invoice.Component;
using InvArtfCrys = Crystal.Invoice.Component.Navigator.Artifact;

using PayVan = Vanilla.Invoice.Facade.Payment;
using InvFac = Vanilla.Invoice.Facade;
using DocFac = Vanilla.Form.Facade.Document;
using ModFac = Vanilla.Utility.Facade.Module;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using SellerFac = Vanilla.Invoice.Facade.Seller;
using BuyerFac = Vanilla.Invoice.Facade.Buyer;
using LineItemFac = Vanilla.Invoice.Facade.LineItem;
using TaxationFac = Vanilla.Invoice.Facade.Taxation;

using CustAuto = AutoTourism.Component.Customer;

namespace Vanilla.Invoice.Facade
{

    public class Server : DocFac.Server, IInvoice
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            //FormDto formDto = this.FormDto as FormDto;
            //formDto.paymentTypeList = this.ReadAllPaymentType();
        }

        public override FacLib.Dto Convert(BinAff.Core.Data data)
        {
            InvCrys.Data invoiceData = data as InvCrys.Data;
            return new Dto 
            {
                Id = invoiceData.Id,
                invoiceNumber = invoiceData.InvoiceNumber,
                advance = invoiceData.Advance,
                discount = invoiceData.Discount,
                date = invoiceData.Date,
                seller = this.GetSeller(invoiceData.Seller),
                buyer = this.GetBuyer(invoiceData.Buyer),
                productList = this.GetProductList(invoiceData.LineItem),
                //taxationList = this.GetTaxation(invoiceData.Taxation),
                //paymentList = this.GetPayments(invoiceData.ProductList)
            };
        }

        public override BinAff.Core.Data Convert(FacLib.Dto dto)
        {
            InvFac.Dto invoiceDto = dto as InvFac.Dto;

            return new InvCrys.Data
            {
                InvoiceNumber = invoiceDto.invoiceNumber,
                Advance = invoiceDto.advance,
                Discount = invoiceDto.discount,
                Date = System.DateTime.Now,
                Seller = this.GetSeller(invoiceDto.seller),
                Buyer = this.GetBuyer(invoiceDto.buyer),
                LineItem = this.GetLineItem(invoiceDto.productList)                
            };
        }

        public override void Add()
        {
            Dto invoiceDto = (this.FormDto as DocFac.FormDto).Dto as Dto;
            CustAuto.Data autoCustomer = new CustAuto.Data
            {
                Invoice = new InvCrys.InvoiceContainer.Data
                {
                    Active = this.Convert(invoiceDto) as CustCrys.Action.Data
                }
            };

            CustCrys.ICustomer customer = new CustAuto.Server(autoCustomer);
            ReturnObject<Boolean> ret = customer.GenerateInvoice();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);             
        }

        private List<Table> ReadAllPaymentType()
        {
            return new Payment.Server(null).ReadAllPaymentType();
            //List<Table> paymentList = new List<Table>();
            //ICrud crud = new Crystal.Invoice.Component.Payment.Type.Server(null);
            //ReturnObject<List<Data>> paymentDataList = crud.ReadAll();

            //if (paymentDataList != null && paymentDataList.Value != null && paymentDataList.Value.Count > 0)
            //{
            //    foreach (BinAff.Core.Data data in paymentDataList.Value)
            //    {
            //        Crystal.Invoice.Component.Payment.Type.Data typeData = data as Crystal.Invoice.Component.Payment.Type.Data;
            //        paymentList.Add(new Payment.Type.Dto { 
            //            Id = typeData.Id,
            //            Name = typeData.Name
            //        });
            //    }
            //}
            //return paymentList;
        }
               
        public void SaveArtifactForReservation(ArtfFac.Dto artifact)
        {
            ModFac.Dto invoiceModuleDto = new ModFac.Server(null).GetModule("INVO", (this.FormDto as FormDto).ModuleFormDto.FormModuleList);
            String fileName = new ArtfFac.Server(null).GetArtifactName(invoiceModuleDto.Artifact, ArtfFac.Type.Document, "Form");
            artifact.FileName = fileName;

            if (invoiceModuleDto != null)
            {
                invoiceModuleDto.Artifact.Children.Add(artifact);
            }

            (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new ArtfFac.FormDto
            {
                Dto = artifact
            };

            (this.FormDto as FormDto).ModuleFormDto.Dto = invoiceModuleDto;
            ModFac.Server moduleFacade = new ModFac.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();

        }

        private SellerFac.Dto GetSeller(InvCrys.Seller seller)
        {
            return seller == null ? null : new SellerFac.Dto
            {
                Name = seller.Name,
                Address = seller.Address,
                Liscence = seller.Liscence,
                Email = seller.Email,
                ContactNumber = seller.ContactNumber
            };
        }
                
        private BuyerFac.Dto GetBuyer(InvCrys.Buyer buyer)
        {
            return buyer == null ? null : new BuyerFac.Dto
            {
                Name = buyer.Name,
                Address = buyer.Address,
                Email = buyer.Email,
                ContactNumber = buyer.ContactNumber
            };
        }
             
        private List<LineItemFac.Dto> GetProductList(List<BinAff.Core.Data> lineItemList)
        {
            List<LineItemFac.Dto> productList = new List<LineItemFac.Dto>();
            if (lineItemList != null && lineItemList.Count > 0)
            {
                foreach (InvCrys.LineItem.Data lineItem in lineItemList)
                {
                    productList.Add(new LineItemFac.Dto
                    {
                        startDate = lineItem.Start,
                        endDate = lineItem.End,
                        description = lineItem.Description,
                        unitRate = lineItem.UnitRate,
                        count = lineItem.Count,
                        total = lineItem.Total,
                        TaxList = this.PopulateTaxToLineItem(lineItem.TaxList)
                    });
                }
            }
            return productList;
        }

        private List<Taxation.Dto> PopulateTaxToLineItem(List<BinAff.Core.Data> taxList)
        {
            List<Taxation.Dto> taxLst = new List<Taxation.Dto>();
            if (taxList != null && taxList.Count > 0)
            {
                foreach (InvCrys.Taxation.Data tax in taxList)
                {
                    if (tax != null)
                    {
                        taxLst.Add(new Taxation.Dto
                        {
                            Name = tax.Name,
                            isPercentage = tax.isPercentage,
                            Amount = tax.Amount
                        });
                    }
                }
            }
            return taxLst;
        }

        private List<TaxationFac.Dto> GetTaxation(List<BinAff.Core.Data> taxationList)
        {
            List<TaxationFac.Dto> taxationDtoList = new List<TaxationFac.Dto>();
            if (taxationList != null && taxationList.Count > 0)
            {
                foreach (InvCrys.Taxation.Data tax in taxationList)
                {
                    if (tax != null)
                    {
                        taxationDtoList.Add(new TaxationFac.Dto
                        {
                            Id = tax.Id,
                            Name = tax.Name,
                            Amount = tax.Amount,
                            isPercentage = tax.isPercentage
                        });
                    }
                }
            }
            return taxationDtoList;
        }

        //private PayVan.Dto GetPayments(List<BinAff.Core.Data> paymentList)
        //{
        //    List<PayVan.LineItem> paymentDtoList = new List<PayVan.LineItem>();
        //    if (paymentList != null && paymentList.Count > 0)
        //    {
        //        foreach (InvCrys.Payment.Data paymentData in paymentList)
        //        {
        //            paymentDtoList.Add(new Vanilla.Invoice.Facade.Payment.LineItem
        //            {
        //                Id = paymentData.Id,
        //                Type = new Table { Id = paymentData.Type.Id },
        //                Reference = paymentData.CardNumber,
        //                Remark = paymentData.Remark,
        //                Amount = paymentData.Amount,
        //            });
        //        }
        //    }
        //    return new PayVan.Dto
        //    {
        //        PaymentList = paymentDtoList
        //    };
        //}

        List<Table> IInvoice.CalulateTaxList(Double total, List<Taxation.Dto> taxationList)
        {
            List<Table> taxList = new List<Table>();
            String taxName = String.Empty;
            Double taxValue = 0;

            if (taxationList != null && taxationList.Count > 0)
            {
                foreach (TaxationFac.Dto dto in taxationList)
                {
                    taxName = dto.Name;
                    if (dto.isPercentage)
                    {
                        taxName += " (" + dto.Amount + " %)";
                        taxValue = total * (dto.Amount / 100);
                    }
                    else
                    {
                        taxValue = dto.Amount;
                    }

                    taxList.Add(new Table
                    {
                        Name = taxName,
                        Value = taxValue
                    });
                }
            }
            return taxList;
        }

        //ReturnObject<InvCrys.Data> IInvoice.GetInvoice(String invoiceNumber)
        //{            
        //    InvCrys.IInvoice invoice = new InvCrys.Server(new InvCrys.Data());
        //    return invoice.GetInvoice(invoiceNumber);
        //}

        Dto IInvoice.GetInvoice(String invoiceNumber)
        {
            Dto dto = null;
            InvCrys.IInvoice invoice = new InvCrys.Server(new InvCrys.Data());
            ReturnObject<InvCrys.Data> retVal = invoice.GetInvoice(invoiceNumber);

            if (retVal != null) dto =  this.Convert(retVal.Value) as Dto;

            return dto;
        }

        Int64 IInvoice.GetInvoiceId(String invoiceNumber)
        {           
            InvCrys.IInvoice invoice = new InvCrys.Server(new InvCrys.Data());
            return invoice.GetInvoiceId(invoiceNumber);
        }

        List<PayVan.Dto> IInvoice.ReadPaymentListForInvoice(String invoiceNumber)
        {           
            InvCrys.IInvoice invoice = new InvCrys.Server(new InvCrys.Data());
            List<PayCrys.Data> paymentDataList = invoice.ReadInvoicePayment(invoiceNumber);
          
            return new Payment.Server(new Payment.FormDto()).Convert(paymentDataList);
        }

        public ReturnObject<Boolean> GenerateInvoice()
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>();

            Dto invoiceDto = (base.FormDto as Facade.FormDto).Dto as Facade.Dto;
            //invoiceDto.invoiceNumber = Common.GenerateInvoiceNumber();

            CustAuto.Data autoCustomer = new CustAuto.Data
            {
                Invoice = new InvCrys.InvoiceContainer.Data
                {
                    Active = this.Convert(invoiceDto) as CustCrys.Action.Data
                }
            };

            CustCrys.ICustomer customer = new CustAuto.Server(autoCustomer);
            ret = customer.GenerateInvoice();

            if (ret.Value)
            {
                invoiceDto.date = DateTime.Now; // updating the dto with current date since in SP current date is getting updated
                if (this.componentServer == null) this.componentServer = this.GetComponentServer();
                (this.componentServer as BinAff.Core.Crud).Data.Id = autoCustomer.Invoice.Active.Id;
                ret = (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForCreate();
            }

            return ret;         
        }

        //private BinAff.Core.Data ConvertToInvoiceData(FacLib.Dto dto)
        //{
        //    Vanilla.Invoice.Facade.Dto invoiceDto = dto as Vanilla.Invoice.Facade.Dto;

        //    return new InvCrys.Data()
        //    {
        //        InvoiceNumber = invoiceDto.invoiceNumber,
        //        Advance = invoiceDto.advance,
        //        Discount = invoiceDto.discount,
        //        Date = System.DateTime.Now,
        //        Seller = this.GetSeller(invoiceDto.seller),
        //        Buyer = this.GetBuyer(invoiceDto.buyer),
        //        LineItem = this.GetLineItem(invoiceDto.productList),
        //        //Taxation = this.GetTaxation(invoiceDto.taxationList),
        //        //Payment = this.GetPayments(invoiceDto.paymentList)
        //    };
        //}

        private InvCrys.Seller GetSeller(SellerFac.Dto seller)
        {
            if (seller == null) return null;
            return new InvCrys.Seller
            {
                Name = seller.Name,
                Address = seller.Address,
                Liscence = seller.Liscence,
                Email = seller.Email,
                ContactNumber = seller.ContactNumber
            };
        }

        private InvCrys.Buyer GetBuyer(BuyerFac.Dto buyer)
        {
            if (buyer == null) return null;
            return new InvCrys.Buyer
            {
                Name = buyer.Name,
                Address = buyer.Address,
                Email = buyer.Email,
                ContactNumber = buyer.ContactNumber
            };
        }

        private List<BinAff.Core.Data> GetLineItem(List<LineItemFac.Dto> roomList)
        {
            List<BinAff.Core.Data> lineItemList = new List<Data>();
            if (roomList != null && roomList.Count > 0)
            {
                foreach (LineItemFac.Dto lineItem in roomList)
                {
                    if (lineItem != null)
                    {
                        lineItemList.Add(new InvCrys.LineItem.Data
                        {
                            Start = lineItem.startDate,
                            End = lineItem.endDate,
                            Description = lineItem.description,
                            UnitRate = lineItem.unitRate,
                            Count = lineItem.count,
                            Total = lineItem.total,
                            TaxList = this.ConvertTaxList(lineItem.TaxList)
                        });
                    }
                }
            }
            return lineItemList;
        }

        //private List<BinAff.Core.Data> GetTaxation(List<TaxationFac.Dto> taxationList)
        //{
        //    List<BinAff.Core.Data> taxationDataList = new List<Data>();
        //    if (taxationList != null && taxationList.Count > 0)
        //    {
        //        foreach (TaxationFac.Dto dto in taxationList)
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

        //private List<BinAff.Core.Data> GetPayments(List<PayVan.Dto> paymentList)
        //{
        //    List<BinAff.Core.Data> paymentDataList = new List<Data>();
        //    if (paymentList != null && paymentList.Count > 0)
        //    {
        //        foreach (PayVan.Dto dto in paymentList)
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

        //private BinAff.Core.Data ConvertToInvoiceData(FacLib.Dto dto)
        //{
        //    Vanilla.Invoice.Facade.Dto invoiceDto = dto as Vanilla.Invoice.Facade.Dto;

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

        //private Crystal.Invoice.Component.Seller GetSeller(SellerFac.Dto seller)
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

        //private Crystal.Invoice.Component.Buyer GetBuyer(BuyerFac.Dto buyer)
        //{
        //    return new Crystal.Invoice.Component.Buyer
        //    {
        //        Name = buyer.Name,
        //        Address = buyer.Address,
        //        Email = buyer.Email,
        //        ContactNumber = buyer.ContactNumber
        //    };
        //}

        //private List<BinAff.Core.Data> GetLineItem(List<LineItemFac.Dto> roomList)
        //{
        //    List<BinAff.Core.Data> lineItemList = new List<Data>();
        //    if (roomList != null && roomList.Count > 0)
        //    {
        //        foreach (LineItemFac.Dto lineItem in roomList)
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

        //private List<BinAff.Core.Data> GetTaxation(List<TaxationFac.Dto> taxationList)
        //{
        //    List<BinAff.Core.Data> taxationDataList = new List<Data>();
        //    if (taxationList != null && taxationList.Count > 0)
        //    {
        //        foreach (TaxationFac.Dto dto in taxationList)
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

        //private List<BinAff.Core.Data> GetPayments(List<PayVan.Dto> paymentList)
        //{
        //    List<BinAff.Core.Data> paymentDataList = new List<Data>();
        //    if (paymentList != null && paymentList.Count > 0)
        //    {
        //        foreach (PayVan.Dto dto in paymentList)
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

        public ArtfFac.Dto GetArtifactForInvoiceNumber(String invoiceNumber)
        {
            ArtfCrys.Data data = new InvArtfCrys.Server(new InvArtfCrys.Data()).GetArtifactForInvoiceNumber(invoiceNumber);
           return new Utility.Facade.Artifact.Dto 
           {
               Id = data == null ? 0 : data.Id
           };
        }

        protected override ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifact)
        {
            return new InvArtfCrys.Server(artifact as InvArtfCrys.Data);
        }

        protected override ICrud GetComponentServer()
        {
            this.componentServer = new InvCrys.Server(this.Convert((this.FormDto as FormDto).Dto) as InvCrys.Data);
            return this.componentServer;
        }

        protected override String GetComponentDataType()
        {
            return "Crystal.Invoice.Component.Navigator.Artifact.Data, Crystal.Invoice.Component";
        }

        public override string GetComponentCode()
        {
            return "INVO";
        }

        protected override BinAff.Core.Observer.IRegistrar GetRegisterer()
        {
            return null;
        }

        protected override ArtfCrys.Data GetArtifactData(Int64 artifactId)
        {
            return new InvArtfCrys.Data { Id = artifactId };
        }

        private List<BinAff.Core.Data> ConvertTaxList(List<Taxation.Dto> taxList)
        {
            List<BinAff.Core.Data> taxLst = new List<Data>();            
            if (taxList != null && taxList.Count > 0)
            {
                foreach (Taxation.Dto dto in taxList)
                {
                    if (dto != null)
                    {
                        taxLst.Add(new InvCrys.Taxation.Data
                        {
                            Name = dto.Name,
                            Amount = dto.Amount,
                            isPercentage = dto.isPercentage
                        });
                    }
                }
            }            
            return taxLst;
        }
             
    }

}



































































