using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Customer.Component.Navigator.Artifact
{

    public abstract class Server : CrystalNavigator.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected abstract override void Compose();

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

    }

}
