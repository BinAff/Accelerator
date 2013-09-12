using System;
using System.Collections.Generic;
using Crystal.Invoice.Component.Payment.Type;
using BinAff.Core.Observer;
using BinAff.Core;

namespace Vanilla.Configuration.Facade.PaymentType
{
    public class PaymentTypeServer : IPaymentType
    {
        BinAff.Core.ReturnObject<FormDto> IPaymentType.LoadForm()
        {
            BinAff.Core.ICrud crud = new Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    PaymentTypeList = new List<Dto>()                    
                }
            };

            //Populate data in dto from business entity
            foreach (Crystal.Invoice.Component.Payment.Type.Data data in dataList.Value)
            {
                ret.Value.PaymentTypeList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        BinAff.Core.ReturnObject<Boolean> IPaymentType.Add(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Crystal.Invoice.Component.Payment.Type.Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        BinAff.Core.ReturnObject<Boolean> IPaymentType.Delete(Dto dto)
        {
            Crystal.Invoice.Component.Payment.Type.Server paymentTypeServer = new Crystal.Invoice.Component.Payment.Type.Server(new Crystal.Invoice.Component.Payment.Type.Data()
            {
                Id = dto.Id
            });
            IRegistrar reg = new Crystal.Invoice.Observer.PaymentType();
            ReturnObject<Boolean> ret = reg.Register(paymentTypeServer);

            BinAff.Core.ICrud paymentType = paymentTypeServer;
            return paymentType.Delete();
        }

        BinAff.Core.ReturnObject<Dto> IPaymentType.Read(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Crystal.Invoice.Component.Payment.Type.Data
            {
                Id = dto.Id
            });
            BinAff.Core.ReturnObject<BinAff.Core.Data> data = crud.Read();
            return new BinAff.Core.ReturnObject<Dto>
            {
                Value = new Dto
                {
                    Id = data.Value.Id,
                    Name = ((Crystal.Invoice.Component.Payment.Type.Data)data.Value).Name
                }
            };
        }

        BinAff.Core.ReturnObject<Boolean> IPaymentType.Change(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Crystal.Invoice.Component.Payment.Type.Data
            {
                Id = dto.Id,
                Name = dto.Name
            });
            return crud.Save();
        }
    }
}
