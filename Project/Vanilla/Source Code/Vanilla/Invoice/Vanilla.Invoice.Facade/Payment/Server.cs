using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinAff.Core;
using ArtfCrys = Crystal.Navigator.Component.Artifact;

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

        //public Dto GetInvoice(String invoiceNumber)
        //{
        //    Facade.IInvoice invoiceServer = new Facade.Server(new Facade.FormDto());
        //    Facade.Dto invoiceDto = invoiceServer.GetInvoice(invoiceNumber);

        //    return this.ConvertToReceiptDto(invoiceDto);
        //}
                
    }
}
