using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Customer.Component.Navigator.Artifact
{

    public abstract class Server : CrystalNavigator.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            this.Name = "Customer " + (this.Data as Data).Category.ToString();
            (this.Data as Data).Extension = "frm";
        }

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

    }

}
