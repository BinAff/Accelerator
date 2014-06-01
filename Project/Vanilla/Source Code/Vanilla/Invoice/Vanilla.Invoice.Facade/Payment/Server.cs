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
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            //throw new NotImplementedException();
            return new BinAff.Facade.Library.Dto();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            //throw new NotImplementedException();
            return new Data();
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

        private List<BinAff.Core.Data> ConvertPayment(List<Payment.Dto> paymentList)
        {
            List<BinAff.Core.Data> paymentDataList = new List<Data>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (Vanilla.Invoice.Facade.Payment.Dto dto in paymentList)
                {
                    paymentDataList.Add(new Crystal.Invoice.Component.Payment.Data
                    {
                        //Id = dto.Id,
                        Type = new Crystal.Invoice.Component.Payment.Type.Data { Id = dto.Type.Id },
                        CardNumber = dto.cardNumber,
                        Remark = dto.remark,
                        Amount = dto.amount,
                    });
                }
            }
            return paymentDataList;
        }

                
    }
}
