
using System;
using BinAff.Core;

using Vanilla.Utility.Facade.Module;

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
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }

        public Dto ReadRule()
        {
            Dto dto = new Dto();
            Crystal.Navigator.Rule.Data data = new Crystal.Navigator.Rule.Data();
            ICrud comp = new Crystal.Navigator.Rule.Server(data);
            ReturnObject<Data> ret = comp.Read();
            dto.ModuleSeperator = data.ModuleSeperator;
            dto.PathSeperator = data.PathSeperator;

            return dto;
        }
    }
}
