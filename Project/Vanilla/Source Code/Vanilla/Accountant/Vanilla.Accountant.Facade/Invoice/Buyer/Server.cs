using System;

using CompCrys = Crystal.Accountant.Component.Invoice;

namespace Vanilla.Accountant.Facade.Invoice.Buyer
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
            CompCrys.Buyer comp = data as CompCrys.Buyer;
            if (comp == null) return null;
            return new Dto
            {
                Id = comp.Id,
                Name = comp.Name,
                Address = comp.Address,
                Email = comp.Email,
                ContactNumber = comp.ContactNumber
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto comp = dto as Dto;
            if (comp == null) return null;
            return new CompCrys.Buyer
            {
                Id = comp.Id,
                Name = comp.Name,
                Address = comp.Address,
                Email = comp.Email,
                ContactNumber = comp.ContactNumber
            };
        }

    }

}