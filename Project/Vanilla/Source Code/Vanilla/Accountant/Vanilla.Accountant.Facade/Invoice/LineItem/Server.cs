using System;

using CompCrys = Crystal.Accountant.Component.Invoice.LineItem;

using TaxFac = Vanilla.Accountant.Facade.Taxation;

namespace Vanilla.Accountant.Facade.Invoice.LineItem
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
            Dto ret = new Dto
            {
                Id = comp.Id,
                StartDate = comp.Start,
                EndDate = comp.End,
                Description = comp.Description,
                UnitRate = comp.UnitRate,
                Count = comp.Count,                
            };
            if (comp.TaxList != null && comp.TaxList.Count > 0)
            {
                ret.TaxList = comp.TaxList.ConvertAll<BinAff.Facade.Library.Dto>((p) =>
                {
                    return taxFac.Convert(p);
                });
                this.AssignTaxes(ret);
            }
            return ret;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto comp = dto as Dto;
            if (comp == null) return null;
            TaxFac.Server taxFac = new TaxFac.Server(null);
            CompCrys.Data ret = new CompCrys.Data
            {
                Id = comp.Id,
                Start = comp.StartDate,
                End = comp.EndDate,
                Description = comp.Description,
                UnitRate = comp.UnitRate,
                Count = comp.Count,
            };
            if (comp.TaxList != null && comp.TaxList.Count > 0)
            {
                ret.TaxList = comp.TaxList.ConvertAll<BinAff.Core.Data>((p) =>
                {
                    return taxFac.Convert(p);
                });
            }
            return ret;
        }

        internal Dto AssignTaxes(Dto dto)
        {
            if (dto.TaxList != null)
            {
                TaxFac.Server taxFac = new TaxFac.Server(null);
                dto.ServiceTax = taxFac.CalculateTax(dto.Total, dto.TaxList.FindLast((p) => { return (p as Taxation.Dto).Name == "Service Tax"; }));
                dto.LuxuryTax = taxFac.CalculateTax(dto.Total, dto.TaxList.FindLast((p) => { return (p as Taxation.Dto).Name == "Luxury Tax"; }));
            }
            return dto;
        }

    }

}