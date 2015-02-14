using System;

using CompCrys = Crystal.Invoice.Component;

namespace Vanilla.Invoice.Facade.Seller
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
            CompCrys.Seller comp = data as CompCrys.Seller;
            if (comp == null) return null;
            return new Dto
            {
                Id = comp.Id,
                Name = comp.Name,
                Address = comp.Address,
                Email = comp.Email,
                Liscence = comp.Liscence,
                ContactNumber = comp.ContactNumber
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto comp = dto as Dto;
            if (comp == null) return null;
            return new CompCrys.Seller
            {
                Id = comp.Id,
                Name = comp.Name,
                Address = comp.Address,
                Liscence = comp.Liscence,
                Email = comp.Email,
                ContactNumber = comp.ContactNumber
            };
        }

    }

}
