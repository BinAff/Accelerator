﻿using System;
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
            PayComp.Data comp = data as PayComp.Data;
            Payment.Dto dto = new Payment.Dto
            {
                Id = comp.Id,
                ReceiptNumber = comp.ReceiptNumber,
                Date = comp.Date,

            };
            if (comp.LineItemList != null && comp.LineItemList.Count > 0)
            {
                LineItem.Server lineItemServer = new LineItem.Server(null);
                dto.LineItemList = comp.LineItemList.ConvertAll<LineItem.Dto>((p) =>
                {
                    return lineItemServer.Convert(p) as LineItem.Dto;
                });
            }
            if (comp.Invoice != null)
            {
                //
            }
            return dto;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Payment.Dto comp = dto as Payment.Dto;
            PayComp.Data data = new PayComp.Data
            {
                Id = comp.Id,
                Date = comp.Date,
            };
            if (comp.LineItemList != null && comp.LineItemList.Count > 0)
            {
                LineItem.Server lineItemServer = new LineItem.Server(null);
                data.LineItemList = comp.LineItemList.ConvertAll<Data>((p) =>
                {
                    return lineItemServer.Convert(p);
                });
            }
            return data;
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

        // need to remove convert list
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

        private List<Table> ReadAllPaymentType()
        {
            ReturnObject<List<Data>> typeDataList = (new PayComp.Type.Server(null) as ICrud).ReadAll();
            if (typeDataList != null && typeDataList.Value != null && typeDataList.Value.Count > 0)
            {
                return typeDataList.Value.ConvertAll((p) =>
                {
                    return new Table
                    {
                        Id = p.Id,
                        Name = (p as Crystal.Invoice.Component.Payment.Type.Data).Name,
                    };
                });
            }
            return null;
        }

        public ReturnObject<Boolean> MakePayment(List<Dto> paymentList, String invoiceNumber)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean> { Value = true };
            List<BinAff.Core.Data> paymentDataList = this.Convert(paymentList);


            //Need to check
            //Facade.Dto invoice = (new Facade.Server(new Facade.FormDto()) as Facade.IInvoice).GetInvoice(invoiceNumber);

            //using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            //{
            //    foreach (BinAff.Core.Data payment in paymentDataList)
            //    {
            //        if (ret.Value)
            //        {
            //            (payment as PayComp.Data).Invoice = new InvComp.Data { Id = invoice.Id };
            //            ICrud crud = new PayComp.Server(payment as PayComp.Data);
            //            ret = crud.Save();
            //        }
            //        break;
            //    }

            //    if (ret.Value)
            //    {
            //        T.Complete();
            //    }
            //}

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