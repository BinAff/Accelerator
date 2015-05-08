using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;
using FacLib = BinAff.Facade.Library;

using PayCrys = Crystal.Accountant.Component.Payment;
using CustCrys = Crystal.Customer.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using InvCrys = Crystal.Accountant.Component.Invoice;
using InvCntnCrys = Crystal.Accountant.Component.InvoiceContainer;
using InvArtfCrys = Crystal.Accountant.Component.Invoice.Navigator.Artifact;

using PayVan = Vanilla.Accountant.Facade.Payment;
using DocFac = Vanilla.Form.Facade.Document;
using ModFac = Vanilla.Utility.Facade.Module;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using SellerFac = Vanilla.Accountant.Facade.Seller;
using BuyerFac = Vanilla.Accountant.Facade.Buyer;
using LineItemFac = Vanilla.Accountant.Facade.LineItem;
using TaxationFac = Vanilla.Accountant.Facade.Taxation;

using CustRet = Retinue.Customer.Component;

namespace Vanilla.Accountant.Facade
{

    public class Server : DocFac.Server, IInvoice
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            Dto dto = (this.FormDto as FormDto).Dto as Dto;
            foreach(LineItem.Dto lineItem in dto.ProductList)
            {
                new LineItemFac.Server(null).AssignTaxes(lineItem);
            }
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
                ProductList = new LineItemFac.Server(null).ConvertAll<Data, LineItemFac.Dto>(comp.LineItemList),
                AdvancePaymentList = new PayVan.Server(null).ConvertAll<Data, PayVan.Dto>(comp.PaymentList),
            };
        }

        public override BinAff.Core.Data Convert(FacLib.Dto dto)
        {
            Dto comp = dto as Dto;
            if (comp == null) return null;
            InvCrys.Data data = new InvCrys.Data
            {
                Id = comp.Id,
                Advance = comp.Advance,
                Discount = comp.Discount,
                Date = System.DateTime.Now, //Current date time
            };
            if (comp.Seller != null) data.Seller = new SellerFac.Server(null).Convert(comp.Seller) as InvCrys.Seller;
            if (comp.Buyer != null) data.Buyer = new BuyerFac.Server(null).Convert(comp.Buyer) as InvCrys.Buyer;
            if (comp.ProductList != null) data.LineItemList = new LineItemFac.Server(null).ConvertAll<Data, LineItemFac.Dto>(comp.ProductList);
            if (comp.AdvancePaymentList != null) data.PaymentList = new PayVan.Server(null).ConvertAll<Data, PayVan.Dto>(comp.AdvancePaymentList);

            return data;
        }

        public override void Add()
        {
            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 5, 0)))
            {
                base.Add();
                if (!this.IsError)
                {
                    //Link invoice and payment
                    Dto dto = (this.FormDto as DocFac.FormDto).Dto as Dto;
                    foreach (PayVan.Dto payment in dto.AdvancePaymentList)
                    {
                        payment.Invoice = dto;
                        PayVan.Server paymentServer = new PayVan.Server(new PayVan.FormDto
                        {
                            Dto = payment,
                        });
                        paymentServer.AttachInvoice();
                        if (this.IsError = paymentServer.IsError)
                        {
                            this.DisplayMessageList = paymentServer.DisplayMessageList;
                        }
                    }
                    if (!this.IsError)
                    {
                        T.Complete();
                    }
                }
            }
        //    Boolean isNew = (this.FormDto as FormDto).Dto.Id == 0;
        //    using (System.Transactions.TransactionScope T = new System.Transactions.TransactionScope())
        //    {
        //        Dto dto = (this.FormDto as DocFac.FormDto).Dto as Dto;
        //        //CustRet.Data data = new CustRet.Data
        //        //{
        //        //    Invoice = new InvCrys.InvoiceContainer.Data
        //        //    {
        //        //        Active = this.Convert(dto) as CustCrys.Action.Data
        //        //    }
        //        //};
        //        ////CustRet.Data cust = new CustRet.Server(null).Convert(dto.Customer) as CustRet.Data;//Attach reservation
        //        ////cust.RoomReserver.Active = this.Convert(dto) as CustCrys.Action.Data;
        //        ////cust.RoomReserver.Active.ProductList = dto.RoomList == null ? null : this.GetRoomDataList(dto.RoomList);

        //        //ReturnObject<Boolean> ret = (new CustRet.Server(data) as ICrud).Save();

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
        }

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
            return "Crystal.Accountant.Component.Invoice.Navigator.Artifact.Data, Crystal.Accountant.Component";
        }

        protected override BinAff.Core.Observer.IRegistrar GetRegisterer()
        {
            return null;
        }

        protected override ArtfCrys.Data GetArtifactData(Int64 artifactId)
        {
            return new InvArtfCrys.Data { Id = artifactId };
        }

        protected override ICrud AssignComponentServer(Data data)
        {
            return base.AssignComponentServer(data);
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

            CustRet.Data autoCustomer = new CustRet.Data
            {
                Invoice = new InvCntnCrys.Data
                {
                    Active = this.Convert(invoiceDto) as CustCrys.Action.Data
                }
            };

            CustCrys.ICustomer customer = new CustRet.Server(autoCustomer);
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

        private List<PayVan.Dto> GetPayments(List<BinAff.Core.Data> paymentList)
        {
            List<PayVan.Dto> paymentDtoList = new List<PayVan.Dto>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (PayCrys.Data paymentData in paymentList)
                {
                    PayVan.Dto p = new PayVan.Dto
                    {
                        Id = paymentData.Id,
                        ReceiptNumber = paymentData.ReceiptNumber,
                        Date = paymentData.Date,
                    };
                    foreach (PayCrys.LineItem.Data line in paymentData.LineItemList)
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