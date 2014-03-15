using System;
using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Invoice.Component.Navigator.Artifact
{
    public class Server : CrystalNavigator.Artifact.Server
    {
        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Invoice form";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        protected override BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData)
        {
            throw new NotImplementedException();
        }
    }
}
