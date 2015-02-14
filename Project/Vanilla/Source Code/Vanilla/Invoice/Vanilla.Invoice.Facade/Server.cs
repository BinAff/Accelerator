﻿using System;
using System.Collections.Generic;

using BinAff.Core;
using FacLib = BinAff.Facade.Library;

using PayCrys = Crystal.Invoice.Component.Payment;
using CustCrys = Crystal.Customer.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using InvCrys = Crystal.Invoice.Component;
using InvArtfCrys = Crystal.Invoice.Component.Navigator.Artifact;
using TaxCrys = Crystal.Invoice.Component.Taxation;

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
            InvCrys.Data comp = data as InvCrys.Data;
            if (comp == null) return null;
            return new Dto 
            {
                Id = comp.Id,
                InvoiceNumber = comp.InvoiceNumber,
                Advance = comp.Advance,
                Discount = comp.Discount,
                Date = comp.Date,
                Seller = new SellerFac.Server(null).Convert(comp.Seller) as SellerFac.Dto,
                Buyer = new BuyerFac.Server(null).Convert(comp.Buyer) as BuyerFac.Dto,
                ProductList = new LineItemFac.Server(null).ConvertAll<Data, LineItemFac.Dto>(comp.LineItem),
                AdvancePaymentList = this.GetPayments(comp.ProductList) //????
            };
        }

        public override BinAff.Core.Data Convert(FacLib.Dto dto)
        {
            Dto comp = dto as Dto;
            if (comp == null) return null;
            return new InvCrys.Data
            {
                Id = comp.Id,
                Advance = comp.Advance,
                Discount = comp.Discount,
                Date = System.DateTime.Now,
                Seller = new SellerFac.Server(null).Convert(comp.Seller) as InvCrys.Seller,
                Buyer = new BuyerFac.Server(null).Convert(comp.Buyer) as InvCrys.Buyer,
                LineItem = comp.ProductList.ConvertAll((p) =>
                {
                    return new LineItemFac.Server(null).Convert(p);
                }),

            };
        }

        //public override void Add()
        //{
        //    Boolean isNew = (this.FormDto as FormDto).Dto.Id == 0;
        //    using (System.Transactions.TransactionScope T = new System.Transactions.TransactionScope())
        //    {
        //        Dto dto = (this.FormDto as DocFac.FormDto).Dto as Dto;
        //        //CustAuto.Data data = new CustAuto.Data
        //        //{
        //        //    Invoice = new InvCrys.InvoiceContainer.Data
        //        //    {
        //        //        Active = this.Convert(dto) as CustCrys.Action.Data
        //        //    }
        //        //};
        //        ////CustAuto.Data cust = new CustAuto.Server(null).Convert(dto.Customer) as CustAuto.Data;//Attach reservation
        //        ////cust.RoomReserver.Active = this.Convert(dto) as CustCrys.Action.Data;
        //        ////cust.RoomReserver.Active.ProductList = dto.RoomList == null ? null : this.GetRoomDataList(dto.RoomList);

        //        //ReturnObject<Boolean> ret = (new CustAuto.Server(data) as ICrud).Save();

        //        InvCrys.Data data = this.Convert(dto) as InvCrys.Data;
        //        ReturnObject<Boolean> ret = (new InvCrys.Server(data) as ICrud).Save();

        //        if (this.IsError = ret.HasError())
        //        {
        //            this.DisplayMessageList = ret.GetMessage((this.IsError) ? Message.Type.Error : Message.Type.Information);
        //            return;
        //        }

        //        if (data != null)
        //        {
        //            (this.FormDto as FormDto).Dto.Id = data.Id;
        //        }

        //        //Call observer...
        //        //This is work around because for this form artifact is different than component server.
        //        //Here customer component has to call bu need to update room reservation artifact
        //        if (this.componentServer == null) this.componentServer = this.GetComponentServer();
        //        if (isNew)
        //        {
        //            (this.componentServer as BinAff.Core.Crud).Data.Id = (this.FormDto as FormDto).Dto.Id;
        //            (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForCreate();
        //        }
        //        else
        //        {
        //            (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForUpdate();
        //        }
        //        this.UpdateAuditInformation();

        //        this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        //        T.Complete();
        //    }

        //    //this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);

        //    //if (ret.Value)
        //    //{
        //    //    invoiceDto.Date = DateTime.Now; // updating the dto with current date since in SP current date is getting updated
        //    //    if (this.componentServer == null) this.componentServer = this.GetComponentServer();
        //    //    (this.componentServer as BinAff.Core.Crud).Data.Id = autoCustomer.Invoice.Active.Id;
        //    //    ret = (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForCreate();
        //    //}
        //}

        public override string GetComponentCode()
        {
            return "INVO";
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

        protected override BinAff.Core.Observer.IRegistrar GetRegisterer()
        {
            return null;
        }

        protected override ArtfCrys.Data GetArtifactData(Int64 artifactId)
        {
            return new InvArtfCrys.Data { Id = artifactId };
        }

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
                    if (dto.IsPercentage)
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

        Dto IInvoice.GetInvoice(String invoiceNumber)
        {
            Dto dto = null;
            InvCrys.IInvoice invoice = new InvCrys.Server(new InvCrys.Data());
            ReturnObject<InvCrys.Data> retVal = invoice.GetInvoice(invoiceNumber);

            if (retVal != null) dto = this.Convert(retVal.Value) as Dto;

            return dto;
        }

        List<PayVan.Dto> IInvoice.ReadPaymentListForInvoice(String invoiceNumber)
        {
            InvCrys.IInvoice invoice = new InvCrys.Server(new InvCrys.Data());
            List<PayCrys.Data> paymentDataList = invoice.ReadInvoicePayment(invoiceNumber);

            return new Payment.Server(new Payment.FormDto()).Convert(paymentDataList);
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
                invoiceDto.Date = DateTime.Now; // updating the dto with current date since in SP current date is getting updated
                if (this.componentServer == null) this.componentServer = this.GetComponentServer();
                (this.componentServer as BinAff.Core.Crud).Data.Id = autoCustomer.Invoice.Active.Id;
                ret = (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForCreate();
            }

            return ret;
        }

        public ArtfFac.Dto GetArtifactForInvoiceNumber(String invoiceNumber)
        {
            ArtfCrys.Data data = new InvArtfCrys.Server(new InvArtfCrys.Data()).GetArtifactForInvoiceNumber(invoiceNumber);
            return new Utility.Facade.Artifact.Dto
            {
                Id = data == null ? 0 : data.Id
            };
        }

        public void AssignLineItemWiseTax(List<LineItemFac.Dto> list)
        {
            if (list != null && list.Count > 0)
            {
                Facade.Taxation.Server taxFacade = new TaxationFac.Server(null);
                foreach (LineItemFac.Dto lineItem in list)
                {
                    lineItem.ServiceTax = taxFacade.CalculateTax(lineItem.Total, lineItem.TaxList.FindLast((p) => { return (p as Taxation.Dto).Name == "Service Tax"; }));
                    lineItem.LuxuaryTax = taxFacade.CalculateTax(lineItem.Total, lineItem.TaxList.FindLast((p) => { return (p as Taxation.Dto).Name == "Luxury Tax"; }));
                }
            }
        }

        private List<PayVan.Dto> GetPayments(List<BinAff.Core.Data> paymentList)
        {
            List<PayVan.Dto> paymentDtoList = new List<PayVan.Dto>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (InvCrys.Payment.Data paymentData in paymentList)
                {
                    PayVan.Dto p = new PayVan.Dto
                    {
                        Id = paymentData.Id,
                        ReceiptNumber = paymentData.ReceiptNumber,
                        Date = paymentData.Date,
                    };
                    foreach (InvCrys.Payment.LineItem.Data line in paymentData.LineItemList)
                    {
                        p.LineItemList.Add(new PayVan.LineItem.Dto
                        {
                            Type = new Table { Id = line.Type.Id },
                            Reference = line.Reference,
                            Remark = line.Remark,
                            Amount = line.Amount,
                        });
                    }
                }
            }
            return paymentDtoList;
        }

    }

}