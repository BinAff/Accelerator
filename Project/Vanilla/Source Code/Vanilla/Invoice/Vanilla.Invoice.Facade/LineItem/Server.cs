using System;

using CompCrys = Crystal.Invoice.Component.LineItem;

using TaxFac = Vanilla.Invoice.Facade.Taxation;

namespace Vanilla.Invoice.Facade.LineItem
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
            TaxFac.Server taxFac = new TaxFac.Server(null);
            return new Dto
            {
                Id = comp.Id,
                StartDate = comp.Start,
                EndDate = comp.End,
                Description = comp.Description,
                UnitRate = comp.UnitRate,
                Count = comp.Count,
                TaxList = comp.TaxList.ConvertAll<BinAff.Facade.Library.Dto>((p) =>
                {
                    return taxFac.Convert(p);
                })
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto comp = dto as Dto;
            if (comp == null) return null;
            TaxFac.Server taxFac = new TaxFac.Server(null);
            return new CompCrys.Data
            {
                Id = comp.Id,
                Start = comp.StartDate,
                End = comp.EndDate,
                Description = comp.Description,
                UnitRate = comp.UnitRate,
                Count = comp.Count,
                TaxList = comp.TaxList.ConvertAll<BinAff.Core.Data>((p) =>
                {
                    return taxFac.Convert(p);
                })
            };
        }

    }

}
