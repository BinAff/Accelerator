using System;
using System.Collections.Generic;
using BinAff.Core;

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
            FormDto formDto = this.FormDto as FormDto;
            formDto.paymentTypeList = this.ReadAllPaymentType();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            Crystal.Invoice.Component.Data invoiceData = data as Crystal.Invoice.Component.Data;
            return new Dto 
            {
                invoiceNumber = invoiceData.InvoiceNumber,
                advance = invoiceData.Advance,
                discount = invoiceData.Discount,
                date = invoiceData.Date,
                seller = this.GetSeller(invoiceData.Seller),
                buyer = this.GetBuyer(invoiceData.Buyer),
                productList = this.GetProductList(invoiceData.LineItem),
                taxationList = this.GetTaxation(invoiceData.Taxation),
                paymentList = this.GetPayments(invoiceData.ProductList)
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            return new Data();
            //Dto invoiceDto = dto as Dto;

            //return new Crystal.Invoice.Component.Data()
            //{
            //    InvoiceNumber = invoiceDto.invoiceNumber,
            //    Advance = invoiceDto.advance,
            //    Discount = invoiceDto.discount,
            //    Date = System.DateTime.Now,
            //    Seller = this.GetSeller(invoiceDto.seller),
            //    Buyer = this.GetBuyer(invoiceDto.buyer),
            //    LineItem = this.GetLineItem(invoiceDto.productList),
            //    Taxation = this.GetTaxation(invoiceDto.taxationList),
            //    Payment = this.GetPayments(invoiceDto.paymentList)
            //};
        }

        public override void Add()
        {
            //AutoTourism.Component.Customer.Data autoCustomer = new AutoTourism.Component.Customer.Data
            //{
            //    Invoice = new Crystal.Invoice.Component.InvoiceContainer.Data
            //    {
            //        Active = this.Convert((this.FormDto as FormDto).dto) as CrystalCustomer.Action.Data
            //    }
            //};

            //CrystalCustomer.ICustomer customer = new AutoTourism.Component.Customer.Server(autoCustomer);
            //ReturnObject<Boolean> ret = customer.GenerateInvoice();

            //this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);             
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
                        total = lineItem.Total
                    });
                }
            }
            return productList;
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
    }
}
