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

            //if (formDto.InvoiceDto != null && !String.IsNullOrEmpty(formDto.InvoiceDto.invoiceNumber))
            //{
            //    (formDto.Dto as Payment.Dto).LineItemList = this.ReadPayments(formDto.InvoiceDto.invoiceNumber);
            //}
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            PayComp.Data paymentData = data as PayComp.Data;
            Payment.Dto paymentDto = new Payment.Dto
            {
                Id = paymentData.Id,
                Date = paymentData.Date,
            };
            if (paymentData.LineItemList != null && paymentData.LineItemList.Count > 0)
            {
                paymentDto.LineItemList = new List<LineItem>();
                foreach (PayComp.LineItem.Data lineItem in paymentData.LineItemList)
                {
                    paymentDto.LineItemList.Add(new LineItem
                    {
                        Id = lineItem.Id,
                        Type = new Table { Id = lineItem.Type.Id },
                        Reference = lineItem.Reference,
                        Remark = lineItem.Remark,
                        Amount = lineItem.Amount
                    });
                }
            }
            if (paymentData.Invoice != null)
            {
                //
            }
            return paymentDto;         
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Payment.Dto paymentDto = dto as Payment.Dto;
            PayComp.Data paymentData = new PayComp.Data
            {
                Id = paymentDto.Id,
                Date = paymentDto.Date,
            };
            if (paymentDto.LineItemList != null && paymentDto.LineItemList.Count > 0)
            {
                paymentData.LineItemList = new List<Data>();
                foreach (LineItem lineItem in paymentDto.LineItemList)
                {
                    paymentData.LineItemList.Add(new PayComp.LineItem.Data
                    {
                        Id = lineItem.Id,
                        Reference = lineItem.Reference,
                        Amount = lineItem.Amount,
                        Remark = lineItem.Remark,
                        Type = new PayComp.Type.Data
                        {
                            Id = lineItem.Type.Id
                        },
                    });
                }

            }
            return paymentData;
        }

        public override string GetComponentCode()
        {
            return "PAMT";
        }

        protected override ICrud GetComponentServer()
        {
            return new PayComp.Server(this.Convert((this.FormDto as FormDto).Dto) as PayComp.Data);
        }

        protected override string GetComponentDataType()
        {
            return "Crystal.Invoice.Component.Payment.Navigator.Artifact.Data, Crystal.Invoice.Component";
        }

        protected override ArtfCrys.Server GetArtifactServer(Data artifactData)
        {
            return new PayArtfComp.Server(artifactData as PayArtfComp.Data);
        }

        protected override ArtfCrys.Data GetArtifactData(Int64 artifactId)
        {
            return new PayArtfComp.Data { Id = artifactId };
        }

        protected override BinAff.Core.Observer.IRegistrar GetRegisterer()
        {
            return null;
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
            List<Dto> paymentDtoList = new List<Dto>();
            foreach (PayComp.Data data in paymentList)
            {
                paymentDtoList.Add(this.Convert(data) as Payment.Dto);
            }
            return paymentDtoList;
        }
        
        private List<Dto> ReadPayments(String invoiceNumber)
        {
            return (new Facade.Server(new Facade.FormDto()) as Facade.IInvoice).ReadPaymentListForInvoice(invoiceNumber);
        }
               
        public List<Table> ReadAllPaymentType()
        {
            List<Table> typeList = new List<Table>();
            ICrud crud = new PayComp.Type.Server(null);
            ReturnObject<List<Data>> typeDataList = crud.ReadAll();

            if (typeDataList != null && typeDataList.Value != null && typeDataList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in typeDataList.Value)
                {
                    PayComp.Type.Data typeData = data as PayComp.Type.Data;
                    typeList.Add(new Table
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

        public String GetPaymentName(Int64 paymentId, List<Table> paymentTypeList)
        {
            String typeName = String.Empty;
            foreach (Table dto in paymentTypeList)
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