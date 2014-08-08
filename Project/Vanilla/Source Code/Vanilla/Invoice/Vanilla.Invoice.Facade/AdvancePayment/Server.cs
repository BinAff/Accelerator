using System;
using System.Collections.Generic;

using BinAff.Core;

using AdvPmtComp = Crystal.Invoice.Component.AdvancePayment;
using AdvPmtArtfComp = Crystal.Invoice.Component.AdvancePayment.Navigator.Artifact;
using PmtTypeComp = Crystal.Invoice.Component.Payment.Type;
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
            AdvPmtComp.Data advPmt = data as AdvPmtComp.Data;
            return new Dto
            {
                Id = advPmt.Id,
                Type = new Table
                {
                    Id = advPmt.Type.Id,
                    Name = advPmt.Type.Name,
                },
                ReferenceNumber = advPmt.CardNumber,
                Remark = advPmt.Remark,
                Amount = advPmt.Amount
            };          
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto paymentDto = dto as Dto;
            return new AdvPmtComp.Data
            {
                Id = dto.Id,
                Type = new PmtTypeComp.Data
                {
                    Id = paymentDto.Type.Id,
                    Name = paymentDto.Type.Name,
                },
                CardNumber = paymentDto.ReferenceNumber,
                Remark = paymentDto.Remark,
                Amount = paymentDto.Amount
            };
        }
               
        private List<Table> ReadAllPaymentType()
        {
            List<Table> typeDtoList = new List<Table>();
            ReturnObject<List<Data>> typeList = (new PmtTypeComp.Server(null) as ICrud).ReadAll();

            if (typeList != null && typeList.Value != null && typeList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in typeList.Value)
                {
                    PmtTypeComp.Data typeData = data as PmtTypeComp.Data;
                    typeDtoList.Add(new Table
                    {
                        Id = typeData.Id,
                        Name = typeData.Name
                    });
                }
            }
            return typeDtoList;
        }

        public ReturnObject<Boolean> MakePayment(List<Dto> advancePaymentList, String invoiceNumber)
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool> { Value = true };
            List<BinAff.Core.Data> advancePaymentDataList = this.ConvertPayment(advancePaymentList);
            
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

        public List<BinAff.Core.Data> ConvertPayment(List<Dto> advancePaymentList)
        {
            List<BinAff.Core.Data> advancePaymentDataList = new List<Data>();
            if (advancePaymentList != null && advancePaymentList.Count > 0)
            {
                foreach (Dto dto in advancePaymentList)
                {
                    advancePaymentDataList.Add(this.Convert(dto));
                }
            }
            return advancePaymentDataList;
        }

        public List<Dto> ConvertPayment(List<AdvPmtComp.Data> advancePaymentList)
        {
            List<Dto> advancePaymentDtoList = new List<Dto>();
            if (advancePaymentList != null && advancePaymentList.Count > 0)
            {
                foreach (AdvPmtComp.Data data in advancePaymentList)
                {
                    advancePaymentDtoList.Add(this.Convert(data) as Dto);
                }
            }
            return advancePaymentDtoList;
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
            return new AdvPmtArtfComp.Server(artifactData as AdvPmtArtfComp.Data);
        }

        protected override ICrud GetComponentServer()
        {
            this.componentServer = new AdvPmtComp.Server(this.Convert((this.FormDto as FormDto).Dto) as AdvPmtComp.Data);
            return this.componentServer;
        }

        protected override string GetComponentDataType()
        {
            return "Crystal.Invoice.Component.AdvancePayment.Navigator.Artifact.Data, Crystal.Invoice.Component";
        }
        
        public override String GetComponentCode()
        {
            return "APMT";
        }
        
        protected override ArtfComp.Data GetArtifactData(Int64 artifactId)
        {
            return new AdvPmtArtfComp.Data { Id = artifactId };
        }

    }

}
