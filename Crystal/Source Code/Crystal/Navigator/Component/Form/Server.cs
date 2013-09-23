namespace Crystal.Navigator.Component.Form
{

    public abstract class Server : Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override abstract void Compose();

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

    }

}
