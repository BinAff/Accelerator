using System;
using System.Collections.Generic;
using BinAff.Core;
using BinAff.Utility;

using CrystalCustomer = Crystal.Customer.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using InvoiceCrys = Crystal.Invoice.Component;


namespace Vanilla.Invoice.Facade
{
    public class Server : Vanilla.Form.Facade.Document.Server, IInvoice
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

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            Crystal.Invoice.Component.Data invoiceData = data as Crystal.Invoice.Component.Data;
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

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
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
                LineItem = this.GetLineItem(invoiceDto.productList)                
            };
        }

        public override void Add()
        {
            Dto invoiceDto = (this.FormDto as Vanilla.Form.Facade.Document.FormDto).Dto as Dto;
            AutoTourism.Component.Customer.Data autoCustomer = new AutoTourism.Component.Customer.Data
            {
                Invoice = new Crystal.Invoice.Component.InvoiceContainer.Data
                {
                    Active = this.Convert(invoiceDto) as CrystalCustomer.Action.Data
                }
            };

            CrystalCustomer.ICustomer customer = new AutoTourism.Component.Customer.Server(autoCustomer);
            ReturnObject<Boolean> ret = customer.GenerateInvoice();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);             
        }

        private List<Payment.Type.Dto> ReadAllPaymentType()
        {
            List<Payment.Type.Dto> paymentList = new List<Payment.Type.Dto>();
            ICrud crud = new Crystal.Invoice.Component.Payment.Type.Server(null);
            ReturnObject<List<Data>> paymentDataList = crud.ReadAll();

            if (paymentDataList != null && paymentDataList.Value != null && paymentDataList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in paymentDataList.Value)
                {
                    Crystal.Invoice.Component.Payment.Type.Data typeData = data as Crystal.Invoice.Component.Payment.Type.Data;
                    paymentList.Add(new Payment.Type.Dto { 
                        Id = typeData.Id,
                        Name = typeData.Name
                    });
                }
            }
            return paymentList;
        }
               
        public void SaveArtifactForReservation(Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            Vanilla.Utility.Facade.Module.Dto invoiceModuleDto = new Vanilla.Utility.Facade.Module.Server(null).GetModule("INVO", (this.FormDto as FormDto).ModuleFormDto.FormModuleList);
            String fileName = new Vanilla.Utility.Facade.Artifact.Server(null).GetArtifactName(invoiceModuleDto.Artifact, Vanilla.Utility.Facade.Artifact.Type.Document, "Form");
            artifactDto.FileName = fileName;

            if (invoiceModuleDto != null)
                invoiceModuleDto.Artifact.Children.Add(artifactDto);

            (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Vanilla.Utility.Facade.Artifact.FormDto
            {
                Dto = artifactDto
            };

            (this.FormDto as FormDto).ModuleFormDto.Dto = invoiceModuleDto;
            Vanilla.Utility.Facade.Module.Server moduleFacade = new Vanilla.Utility.Facade.Module.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();

        }

        private Vanilla.Invoice.Facade.Seller.Dto GetSeller(Crystal.Invoice.Component.Seller seller)
        {
            return seller == null ? null : new Vanilla.Invoice.Facade.Seller.Dto
            {
                Name = seller.Name,
                Address = seller.Address,
                Liscence = seller.Liscence,
                Email = seller.Email,
                ContactNumber = seller.ContactNumber
            };
        }
                
        private Vanilla.Invoice.Facade.Buyer.Dto GetBuyer(Crystal.Invoice.Component.Buyer buyer)
        {
            return buyer == null ? null : new Vanilla.Invoice.Facade.Buyer.Dto
            {
                Name = buyer.Name,
                Address = buyer.Address,
                Email = buyer.Email,
                ContactNumber = buyer.ContactNumber
            };
        }
             
        private List<Vanilla.Invoice.Facade.LineItem.Dto> GetProductList(List<BinAff.Core.Data> lineItemList)
        {
            List<Vanilla.Invoice.Facade.LineItem.Dto> productList = new List<Vanilla.Invoice.Facade.LineItem.Dto>();
            if (lineItemList != null && lineItemList.Count > 0)
            {
                foreach (Crystal.Invoice.Component.LineItem.Data lineItem in lineItemList)
                {
                    productList.Add(new Vanilla.Invoice.Facade.LineItem.Dto
                    {
                        startDate = lineItem.Start,
                        endDate = lineItem.End,
                        description = lineItem.Description,
                        unitRate = lineItem.UnitRate,
                        count = lineItem.Count,
                        total = lineItem.Total,
                        TaxList = PopulateTaxToLineItem(lineItem.TaxList)
                    });
                }
            }
            return productList;
        }

        private List<Taxation.Dto> PopulateTaxToLineItem(List<BinAff.Core.Data> taxList)
        {
            List<Taxation.Dto> taxLst = new List<Taxation.Dto>();
            foreach (BinAff.Core.Data data in taxList)
            {
                Crystal.Invoice.Component.Taxation.Data taxData = data as Crystal.Invoice.Component.Taxation.Data;
                taxLst.Add(new Taxation.Dto 
                {
                    Name = taxData.Name,
                    isPercentage = taxData.isPercentage,
                    Amount = taxData.Amount
                });
            }
            return taxLst;
        }

        private List<Vanilla.Invoice.Facade.Taxation.Dto> GetTaxation(List<BinAff.Core.Data> taxationList)
        {
            List<Vanilla.Invoice.Facade.Taxation.Dto> taxationDtoList = new List<Vanilla.Invoice.Facade.Taxation.Dto>();
            if (taxationList != null && taxationList.Count > 0)
            {
                foreach (Crystal.Invoice.Component.Taxation.Data taxData in taxationList)
                {
                    taxationDtoList.Add(new Vanilla.Invoice.Facade.Taxation.Dto
                    {
                        Id = taxData.Id,
                        Name = taxData.Name,
                        Amount = taxData.Amount,
                        isPercentage = taxData.isPercentage
                    });
                }
            }
            return taxationDtoList;
        }

        private List<Vanilla.Invoice.Facade.Payment.Dto> GetPayments(List<BinAff.Core.Data> paymentList)
        {
            List<Vanilla.Invoice.Facade.Payment.Dto> paymentDtoList = new List<Vanilla.Invoice.Facade.Payment.Dto>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (Crystal.Invoice.Component.Payment.Data paymentData in paymentList)
                {
                    paymentDtoList.Add(new Vanilla.Invoice.Facade.Payment.Dto
                    {
                        Id = paymentData.Id,
                        Type = new Payment.Type.Dto { Id = paymentData.Type.Id },
                        cardNumber = paymentData.CardNumber,
                        remark = paymentData.Remark,
                        amount = paymentData.Amount,
                    });
                }
            }
            return paymentDtoList;
        }

        List<Table> IInvoice.CalulateTaxList(double total, List<Taxation.Dto> taxationList)
        {
            List<Table> taxList = new List<Table>();
            String taxName = String.Empty;
            Double taxValue = 0;

            if (taxationList != null && taxationList.Count > 0)
            {
                foreach (Facade.Taxation.Dto dto in taxationList)
                {
                    taxName = dto.Name;
                    if (dto.isPercentage)
                    {
                        taxName += " (" + dto.Amount + " %)";
                        taxValue = total * (dto.Amount / 100);
                    }
                    else                    
                        taxValue = dto.Amount;

                    taxList.Add(new Table
                    {
                        Name = taxName,
                        Value = taxValue
                    });
                }
            }
            return taxList;
        }

        //ReturnObject<Crystal.Invoice.Component.Data> IInvoice.GetInvoice(String invoiceNumber)
        //{            
        //    InvoiceCrys.IInvoice invoice = new InvoiceCrys.Server(new InvoiceCrys.Data());
        //    return invoice.GetInvoice(invoiceNumber);
        //}

        Dto IInvoice.GetInvoice(String invoiceNumber)
        {
            Dto dto = null;
            InvoiceCrys.IInvoice invoice = new InvoiceCrys.Server(new InvoiceCrys.Data());
            ReturnObject<Crystal.Invoice.Component.Data> retVal = invoice.GetInvoice(invoiceNumber);

            if (retVal != null)            
              dto =  this.Convert(retVal.Value) as Dto;

            return dto;
        }

        public ReturnObject<Boolean> GenerateInvoice()
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>();

            Dto invoiceDto = (base.FormDto as Facade.FormDto).Dto as Facade.Dto;
            //invoiceDto.invoiceNumber = Common.GenerateInvoiceNumber();

            AutoTourism.Component.Customer.Data autoCustomer = new AutoTourism.Component.Customer.Data
            {
                Invoice = new Crystal.Invoice.Component.InvoiceContainer.Data
                {
                    Active = this.Convert(invoiceDto) as CrystalCustomer.Action.Data
                }
            };

            CrystalCustomer.ICustomer customer = new AutoTourism.Component.Customer.Server(autoCustomer);
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

        //private BinAff.Core.Data ConvertToInvoiceData(BinAff.Facade.Library.Dto dto)
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
        //        //Taxation = this.GetTaxation(invoiceDto.taxationList),
        //        //Payment = this.GetPayments(invoiceDto.paymentList)
        //    };
        //}

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
                        Total = lineItem.total,
                        TaxList = ConvertTaxList(lineItem.TaxList)
                    });
                }
            }
            return lineItemList;
        }

        //private List<BinAff.Core.Data> GetTaxation(List<Vanilla.Invoice.Facade.Taxation.Dto> taxationList)
        //{
        //    List<BinAff.Core.Data> taxationDataList = new List<Data>();
        //    if (taxationList != null && taxationList.Count > 0)
        //    {
        //        foreach (Vanilla.Invoice.Facade.Taxation.Dto dto in taxationList)
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

        //private List<BinAff.Core.Data> GetPayments(List<Vanilla.Invoice.Facade.Payment.Dto> paymentList)
        //{
        //    List<BinAff.Core.Data> paymentDataList = new List<Data>();
        //    if (paymentList != null && paymentList.Count > 0)
        //    {
        //        foreach (Vanilla.Invoice.Facade.Payment.Dto dto in paymentList)
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

        //private BinAff.Core.Data ConvertToInvoiceData(BinAff.Facade.Library.Dto dto)
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

        //private Crystal.Invoice.Component.Seller GetSeller(Vanilla.Invoice.Facade.Seller.Dto seller)
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

        //private Crystal.Invoice.Component.Buyer GetBuyer(Vanilla.Invoice.Facade.Buyer.Dto buyer)
        //{
        //    return new Crystal.Invoice.Component.Buyer
        //    {
        //        Name = buyer.Name,
        //        Address = buyer.Address,
        //        Email = buyer.Email,
        //        ContactNumber = buyer.ContactNumber
        //    };
        //}

        //private List<BinAff.Core.Data> GetLineItem(List<Vanilla.Invoice.Facade.LineItem.Dto> roomList)
        //{
        //    List<BinAff.Core.Data> lineItemList = new List<Data>();
        //    if (roomList != null && roomList.Count > 0)
        //    {
        //        foreach (Vanilla.Invoice.Facade.LineItem.Dto lineItem in roomList)
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

        //private List<BinAff.Core.Data> GetTaxation(List<Vanilla.Invoice.Facade.Taxation.Dto> taxationList)
        //{
        //    List<BinAff.Core.Data> taxationDataList = new List<Data>();
        //    if (taxationList != null && taxationList.Count > 0)
        //    {
        //        foreach (Vanilla.Invoice.Facade.Taxation.Dto dto in taxationList)
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

        //private List<BinAff.Core.Data> GetPayments(List<Vanilla.Invoice.Facade.Payment.Dto> paymentList)
        //{
        //    List<BinAff.Core.Data> paymentDataList = new List<Data>();
        //    if (paymentList != null && paymentList.Count > 0)
        //    {
        //        foreach (Vanilla.Invoice.Facade.Payment.Dto dto in paymentList)
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

        public Vanilla.Utility.Facade.Artifact.Dto GetArtifactForInvoiceNumber(String invoiceNumber)
        {            
           Crystal.Navigator.Component.Artifact.Data  data =  new InvoiceCrys.Navigator.Artifact.Server(new InvoiceCrys.Navigator.Artifact.Data()).GetArtifactForInvoiceNumber(invoiceNumber);
           return new Utility.Facade.Artifact.Dto 
           {
               Id = data == null ? 0 : data.Id
           };
        }

        protected override ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData)
        {
            return new InvoiceCrys.Navigator.Artifact.Server(artifactData as InvoiceCrys.Navigator.Artifact.Data);
        }

        protected override ArtfCrys.Observer.DocumentComponent GetComponentServer()
        {
            this.componentServer = new InvoiceCrys.Server(this.Convert((this.FormDto as FormDto).Dto) as InvoiceCrys.Data);
            return this.componentServer as ArtfCrys.Observer.DocumentComponent;
        }

        protected override String GetComponentDataType()
        {
            return "Crystal.Invoice.Component.Navigator.Artifact.Data, Crystal.Invoice.Component";
        }

        private List<BinAff.Core.Data> ConvertTaxList(List<Taxation.Dto> taxList)
        {
            List<BinAff.Core.Data> taxLst = new List<Data>();
            
            if (taxList != null && taxList.Count > 0)
            {
                foreach (Taxation.Dto dto in taxList)
                {
                    taxLst.Add(new InvoiceCrys.Taxation.Data 
                    { 
                        Name = dto.Name,
                        Amount = dto.Amount,
                        isPercentage = dto.isPercentage
                    });
                }
            }
            
            return taxLst;
        }
    }
}



































































