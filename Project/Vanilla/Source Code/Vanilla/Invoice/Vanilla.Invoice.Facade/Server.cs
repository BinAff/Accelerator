using System;
using System.Collections.Generic;
using BinAff.Core;

namespace Vanilla.Invoice.Facade
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
            formDto.paymentTypeList = this.ReadAllPaymentType();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }

        private List<Payment.Type.Dto> ReadAllPaymentType()
        {
            List<Payment.Type.Dto> paymentList = new List<Payment.Type.Dto>();
            ICrud crud = new Crystal.Invoice.Component.Payment.Type.Server(null);
            ReturnObject<List<Data>> paymentDataList = crud.ReadAll();

            if (paymentDataList != null && paymentDataList.Value != null && paymentDataList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in paymentDataList.Value)
                {
                    Crystal.Invoice.Component.Payment.Type.Data typeData = data as Crystal.Invoice.Component.Payment.Type.Data;
                    paymentList.Add(new Payment.Type.Dto { 
                        Id = typeData.Id,
                        Name = typeData.Name
                    });
                }
            }
            return paymentList;
        }
    }
}
