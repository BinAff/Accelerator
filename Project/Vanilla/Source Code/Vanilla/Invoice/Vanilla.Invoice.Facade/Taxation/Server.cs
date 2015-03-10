using System;



using CompCrys = Crystal.Invoice.Component.Taxation;

namespace Vanilla.Invoice.Facade.Taxation
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
            CompCrys.Data tax = data as CompCrys.Data;
            if (tax == null) return null;
            return new Facade.Taxation.Dto
            {
                Id = tax.Id,
                Name = tax.Name,
                Amount = tax.Amount,
                IsPercentage = tax.IsPercentage,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Facade.Taxation.Dto tax = dto as Facade.Taxation.Dto;
            if (tax == null) return null;
            return new CompCrys.Data
            {
                Id = tax.Id,
                Name = tax.Name,
                Amount = tax.Amount,
                IsPercentage = tax.IsPercentage,
            };
        }

        public Double CalculateTax(Double amount, BinAff.Facade.Library.Dto tax)
        {
            Dto dto = tax as Dto;
            return (dto == null) ? 0 : (dto.IsPercentage) ? amount * (dto.Amount / 100) : dto.Amount;
        }

    }

}
