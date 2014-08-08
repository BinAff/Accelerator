using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;
using InvComp = Crystal.Invoice.Component;
using PayComp = Crystal.Invoice.Component.Payment;
using PayArtfComp = Crystal.Invoice.Component.Payment.Navigator.Artifact;

using FrmFac = Vanilla.Form.Facade.Document;

namespace Vanilla.Invoice.Facade.Payment
{

    public class Server : FrmFac.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.TypeList = this.ReadAllPaymentType();

            if (formDto.InvoiceDto != null && !String.IsNullOrEmpty(formDto.InvoiceDto.invoiceNumber))
            {
                formDto.PaymentList = this.ReadPayments(formDto.InvoiceDto.invoiceNumber);
            }
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            PayComp.Data paymentData = data as PayComp.Data;
            return new Payment.Dto
            {
                Id = paymentData.Id,
                Type = new Table { Id = paymentData.Type.Id },
                ReferenceNumber = paymentData.CardNumber,
                Remark = paymentData.Remark,
                Amount = paymentData.Amount
            };

            //Add invoice if present
         
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Payment.Dto paymentDto = dto as Payment.Dto;
            return new PayComp.Data
            {
                Id = dto.Id,
                Type = new PayComp.Type.Data { Id = paymentDto.Type.Id },
                CardNumber = paymentDto.ReferenceNumber,
                Remark = paymentDto.Remark,
                Amount = paymentDto.Amount
            };
        }

        public override string GetComponentCode()
        {
            return "PAMT";
        }

        protected override ICrud GetComponentServer()
        {
            this.componentServer = new PayComp.Server(this.Convert((this.FormDto as FormDto).Dto) as PayComp.Data);
            return this.componentServer;
        }

        protected override string GetComponentDataType()
        {
            return "Crystal.Invoice.Component.Payment.Navigator.Artifact.Data, Crystal.Invoice.Component";
        }

        protected override Crystal.Navigator.Component.Artifact.Server GetArtifactServer(Data artifactData)
        {
            return new PayArtfComp.Server(artifactData as PayArtfComp.Data);
        }
        
        public override void Delete()
        {
            PayArtfComp.Data data = new PayArtfComp.Data
            {
                Id = this.Data.Id,
                Category = ArtfCrys.Category.Form,
                Children = new List<Data>()
            };
            ReturnObject<Boolean> retVal = (new PayArtfComp.Server(data) as BinAff.Core.ICrud).Delete();
        }

        public override ReturnObject<Boolean> ValidateDelete()
        {
            Int64 componentId = this.ReadComponentIdForArtifact(this.Data.Id);

            if (componentId == 0) return new ReturnObject<Boolean> { Value = true }; //No component attached with artifact

            //BinAff.Core.Observer.ISubject server = new PayComp.Server(new PayComp.Data { Id = componentId });
            BinAff.Core.Observer.ISubject server = this.GetComponentServer() as BinAff.Core.Observer.ISubject;
            server.RegisterObserver(new InvComp.Server(null));////////
            ReturnObject<Boolean> notify = server.NotifyObserver();

            return notify;
        }
        
        private List<Dto> ReadPayments(String invoiceNumber)
        {
            return (new Facade.Server(new Facade.FormDto()) as Facade.IInvoice).ReadPaymentForInvoice(invoiceNumber);
        }
               
        private List<Type.Dto> ReadAllPaymentType()
        {
            List<Type.Dto> typeList = new List<Type.Dto>();
            ICrud crud = new PayComp.Type.Server(null);
            ReturnObject<List<Data>> typeDataList = crud.ReadAll();

            if (typeDataList != null && typeDataList.Value != null && typeDataList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in typeDataList.Value)
                {
                    PayComp.Type.Data typeData = data as PayComp.Type.Data;
                    typeList.Add(new Payment.Type.Dto
                    {
                        Id = typeData.Id,
                        Name = typeData.Name
                    });
                }
            }
            return typeList;
        }

        public ReturnObject<Boolean> MakePayment(List<Dto> paymentList,String invoiceNumber)
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool> { Value = true };
            List<BinAff.Core.Data> paymentDataList = this.Convert(paymentList);
            
            Facade.IInvoice invoiceServer = new Facade.Server(new Facade.FormDto());
            Int64 invoiceId = invoiceServer.GetInvoiceId(invoiceNumber);

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                foreach (BinAff.Core.Data payment in paymentDataList)
                {
                    if (ret.Value)
                    {
                        (payment as PayComp.Data).Invoice = new InvComp.Data { Id = invoiceId };
                        ICrud crud = new PayComp.Server(payment as PayComp.Data);
                        ret = crud.Save();
                    }
                    break;
                }

                if (ret.Value)
                {
                    T.Complete();
                }
            }

            return ret;
        }

        public List<BinAff.Core.Data> Convert(List<Payment.Dto> paymentList)
        {
            List<BinAff.Core.Data> paymentDataList = new List<Data>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (Vanilla.Invoice.Facade.Payment.Dto dto in paymentList)
                {                 
                    paymentDataList.Add(this.Convert(dto));
                }
            }
            return paymentDataList;
        }

        public List<Payment.Dto> Convert(List<PayComp.Data> paymentList)
        {
            List<Payment.Dto> paymentDtoList = new List<Payment.Dto>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (PayComp.Data data in paymentList)
                {
                    paymentDtoList.Add(this.Convert(data) as Payment.Dto);
                }
            }
            return paymentDtoList;
        }
        
        public String GetPaymentName(Int64 paymentId, List<Type.Dto> paymentTypeList)
        {
            String typeName = String.Empty;
            foreach (Type.Dto dto in paymentTypeList)
            {
                if (dto.Id == paymentId)
                {
                    typeName = dto.Name;
                }
            }
            return typeName;
        }
        
        protected override ArtfCrys.Data GetArtifactData(long artifactId)
        {
            return new PayArtfComp.Data { Id = artifactId };
        }

    }

}