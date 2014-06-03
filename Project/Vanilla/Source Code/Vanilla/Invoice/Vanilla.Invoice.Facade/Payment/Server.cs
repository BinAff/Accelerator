using System;
using System.Collections.Generic;
using BinAff.Core;

using CryInv = Crystal.Invoice.Component;
using System.Transactions;

namespace Vanilla.Invoice.Facade.Payment
{
    public class Server : BinAff.Facade.Library.Server
    {
        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.typeList = this.ReadAllPaymentType();

            if (formDto.InvoiceDto != null && !String.IsNullOrEmpty(formDto.InvoiceDto.invoiceNumber))
                formDto.PaymentList = this.ReadPayments(formDto.InvoiceDto.invoiceNumber);
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CryInv.Payment.Data paymentData = data as CryInv.Payment.Data;
            return new Payment.Dto
                                {
                                    Id = paymentData.Id,
                                    Type = new Type.Dto { Id = paymentData.Type.Id },
                                    cardNumber = paymentData.CardNumber,
                                    remark = paymentData.Remark,
                                    amount = paymentData.Amount
                                };

            //Payment.Dto dto = new Payment.Dto
            //                    {
            //                        Id = paymentData.Id,
            //                        Type = new Type.Dto { Id = paymentData.Type.Id },
            //                        cardNumber = paymentData.CardNumber,
            //                        remark = paymentData.Remark,
            //                        amount = paymentData.Amount
            //                    };

            //if ((this.FormDto as FormDto).typeList != null && (this.FormDto as FormDto).typeList.Count > 0)
            //{
            //    foreach (Type.Dto type in (this.FormDto as FormDto).typeList)
            //    {
            //        if (type.Id == dto.Type.Id)
            //        {
            //            dto.paymentType = type.Name;
            //            break;
            //        }
            //    }
            //}

            //return dto;            
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Payment.Dto paymentDto = dto as Payment.Dto;
            return new Crystal.Invoice.Component.Payment.Data
            {
                Id = dto.Id,
                Type = new Crystal.Invoice.Component.Payment.Type.Data { Id = paymentDto.Type.Id },
                CardNumber = paymentDto.cardNumber,
                Remark = paymentDto.remark,
                Amount = paymentDto.amount
            };
        }
               
        private List<Type.Dto> ReadAllPaymentType()
        {
            List<Type.Dto> paymentList = new List<Type.Dto>();
            ICrud crud = new Crystal.Invoice.Component.Payment.Type.Server(null);
            ReturnObject<List<Data>> paymentDataList = crud.ReadAll();

            if (paymentDataList != null && paymentDataList.Value != null && paymentDataList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in paymentDataList.Value)
                {
                    Crystal.Invoice.Component.Payment.Type.Data typeData = data as Crystal.Invoice.Component.Payment.Type.Data;
                    paymentList.Add(new Payment.Type.Dto
                    {
                        Id = typeData.Id,
                        Name = typeData.Name
                    });
                }
            }
            return paymentList;
        }

        public ReturnObject<Boolean> MakePayment(List<Dto> paymentList,String invoiceNumber)
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool> { Value = true };
            List<BinAff.Core.Data> paymentDataList = this.ConvertPayment(paymentList);
            
            Facade.IInvoice invoiceServer = new Facade.Server(new Facade.FormDto());
            Int64 invoiceId = invoiceServer.GetInvoiceId(invoiceNumber);

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                foreach (BinAff.Core.Data payment in paymentDataList)
                {
                    if (ret.Value)
                    {
                        (payment as CryInv.Payment.Data).Invoice = new CryInv.Data { Id = invoiceId };
                        ICrud crud = new CryInv.Payment.Server(payment as CryInv.Payment.Data);
                        ret = crud.Save();
                    }
                    break;
                }

                if (ret.Value)
                    T.Complete();
            }

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

        public List<Payment.Dto> ConvertPayment(List<CryInv.Payment.Data> paymentList)
        {
            List<Payment.Dto> paymentDtoList = new List<Payment.Dto>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (CryInv.Payment.Data data in paymentList)
                {
                    paymentDtoList.Add(this.Convert(data) as Payment.Dto);
                }
            }
            return paymentDtoList;
        }
        
        private List<Dto> ReadPayments(String invoiceNumber)
        {
            Facade.IInvoice invoiceServer = new Facade.Server(new Facade.FormDto());
            return invoiceServer.ReadPaymentForInvoice(invoiceNumber);
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

    }
}
