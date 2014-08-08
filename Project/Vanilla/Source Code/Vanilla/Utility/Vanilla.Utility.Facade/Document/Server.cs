using System;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Utility.Facade.Document
{

    public class Server : BinAff.Facade.Library.Server
    {

        protected BinAff.Core.ICrud componentServer;

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

        public Dto GetModule()
        {
            return (this.FormDto as FormDto).Dto;
        }

        public virtual String GetComponentCode()
        {
            throw new NotImplementedException();
        }

    }

}
