using DocFac = Vanilla.Utility.Facade.Document;

namespace Vanilla.Form.Facade.Document
{
    public class Server : DocFac.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        //public override void LoadForm()
        //{
        //    throw new NotImplementedException();
        //}

        //public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        //{
        //    throw new NotImplementedException();
        //}

        //public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
