using System;
using System.Collections.Generic;

using BinAff.Core;

using PaymentComp = Crystal.Invoice.Component.Payment;
using PaymentTypComp = Crystal.Invoice.Component.Payment.Type;
using ArtfComp = Crystal.Navigator.Component.Artifact;

using DocFac = Vanilla.Form.Facade.Document;

namespace Vanilla.Invoice.Facade.AdvancePayment
{

    public class Server : DocFac.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.TypeList = this.ReadAllPaymentType();

            //if (formDto.InvoiceDto != null && !String.IsNullOrEmpty(formDto.InvoiceDto.invoiceNumber))
            //    formDto.PaymentList = this.ReadPayments(formDto.InvoiceDto.invoiceNumber);
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            PaymentComp.Data paymentData = data as PaymentComp.Data;
            return new Dto
            {
                Id = paymentData.Id,
                Type = new Table
                {
                    Id = paymentData.Type.Id,
                    Name = paymentData.Type.Name,
                },
                ReferenceNumber = paymentData.CardNumber,
                Remark = paymentData.Remark,
                Amount = paymentData.Amount
            };          
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Payment.Dto paymentDto = dto as Payment.Dto;
            return new Crystal.Invoice.Component.Payment.Data
            {
                Id = dto.Id,
                Type = new PaymentTypComp.Data
                {
                    Id = paymentDto.Type.Id,
                    Name = paymentDto.Type.Name,
                },
                CardNumber = paymentDto.cardNumber,
                Remark = paymentDto.remark,
                Amount = paymentDto.amount
            };
        }
               
        private List<Table> ReadAllPaymentType()
        {
            List<Table> typeDtoList = new List<Table>();
            ReturnObject<List<Data>> typeList = (new PaymentTypComp.Server(null) as ICrud).ReadAll();

            if (typeList != null && typeList.Value != null && typeList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in typeList.Value)
                {
                    PaymentTypComp.Data typeData = data as PaymentTypComp.Data;
                    typeDtoList.Add(new Table
                    {
                        Id = typeData.Id,
                        Name = typeData.Name
                    });
                }
            }
            return typeDtoList;
        }

        public ReturnObject<Boolean> MakePayment(List<Dto> paymentList, String invoiceNumber)
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool> { Value = true };
            //List<BinAff.Core.Data> paymentDataList = this.ConvertPayment(paymentList);
            
            //Facade.IInvoice invoiceServer = new Facade.Server(new Facade.FormDto());
            //Int64 invoiceId = invoiceServer.GetInvoiceId(invoiceNumber);

            //using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            //{
            //    foreach (BinAff.Core.Data payment in paymentDataList)
            //    {
            //        if (ret.Value)
            //        {
            //            (payment as PaymentComp.Data).Invoice = new CryInv.Data { Id = invoiceId };
            //            ICrud crud = new PaymentComp.Server(payment as PaymentComp.Data);
            //            ret = crud.Save();
            //        }
            //        break;
            //    }

            //    if (ret.Value)
            //        T.Complete();
            //}

            return ret;
        }

        public List<BinAff.Core.Data> ConvertPayment(List<Payment.Dto> paymentList)
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

        public List<Payment.Dto> ConvertPayment(List<PaymentComp.Data> paymentList)
        {
            List<Payment.Dto> paymentDtoList = new List<Payment.Dto>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (PaymentComp.Data data in paymentList)
                {
                    paymentDtoList.Add(this.Convert(data) as Payment.Dto);
                }
            }
            return paymentDtoList;
        }
        
        private List<Dto> ReadPayments(String invoiceNumber)
        {
            //Facade.IInvoice invoiceServer = new Facade.Server(new Facade.FormDto());
            //return invoiceServer.ReadPaymentForInvoice(invoiceNumber);
            throw new NotImplementedException();
        }

        public String GetPaymentName(Int64 paymentId, List<Table> typeList)
        {
            String typeName = String.Empty;
            foreach (Table dto in typeList)
            {
                if (dto.Id == paymentId)
                {
                    typeName = dto.Name;
                }
            }
            return typeName;
        }

        protected override ArtfComp.Server GetArtifactServer(Data artifactData)
        {
            throw new NotImplementedException();
        }

        protected override ArtfComp.Observer.DocumentComponent GetComponentServer()
        {
            throw new NotImplementedException();
        }

        protected override string GetComponentDataType()
        {
            throw new NotImplementedException();
        }

    }

}
