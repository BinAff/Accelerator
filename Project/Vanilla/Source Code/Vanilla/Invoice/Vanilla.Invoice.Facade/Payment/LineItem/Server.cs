using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CompCrys = Crystal.Invoice.Component.Payment.LineItem;

namespace Vanilla.Invoice.Facade.Payment.LineItem
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            throw new NotImplementedException();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CompCrys.Data comp = data as CompCrys.Data;
            if (comp == null) return null;
            return new Dto
            {
                Id = comp.Id,
                Amount = comp.Amount,
                Type = new BinAff.Core.Table
                {
                    Id = comp.Type.Id,
                    Name = comp.Type.Name,
                },
                Reference = comp.Reference,
                Remark = comp.Remark,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto comp = dto as Dto;
            if (comp == null) return null;
            return new CompCrys.Data
            {
                Id = comp.Id,
                Amount = comp.Amount,
                Type = new Crystal.Invoice.Component.Payment.Type.Data
                {
                    Id = comp.Type.Id,
                    Name = comp.Type.Name,
                },
                Reference = comp.Reference,
                Remark = comp.Remark,
            };
        }

    }
}
