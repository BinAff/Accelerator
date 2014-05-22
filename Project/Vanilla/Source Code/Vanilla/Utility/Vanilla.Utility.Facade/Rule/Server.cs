using System;
using BinAff.Core;

using Crys = Crystal.Navigator.Rule;

namespace Vanilla.Utility.Facade.Rule
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
            Crys.Data rule = data as Crys.Data;
            return new Dto
            {
                ModuleSeperator = rule.ModuleSeperator,
                PathSeperator = rule.PathSeperator,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto rule = dto as Dto;
            return new Crys.Data
            {
                ModuleSeperator = rule.ModuleSeperator,
                PathSeperator = rule.PathSeperator,
            };
        }

        public override void Read()
        {
            Crys.Data data = new Crys.Data();
            ICrud comp = new Crys.Server(data);
            ReturnObject<Data> ret = comp.Read();

            (this.FormDto as FormDto).Dto = this.Convert(ret.Value) as Dto;
        }

    }

}
