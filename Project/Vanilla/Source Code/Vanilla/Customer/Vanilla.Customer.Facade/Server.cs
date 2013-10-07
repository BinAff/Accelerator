using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Customer.Facade
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

        public override void ConvertToDto()
        {
            throw new NotImplementedException();
        }

        public override void ConvertFromDto()
        {
            throw new NotImplementedException();
        }
    }
}
