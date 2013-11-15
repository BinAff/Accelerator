namespace Crystal.Navigator.Component.Form
{

    public abstract class Server : Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override abstract void Compose();

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

        protected override void CreateChildren()
        {
            base.CreateChildren();

            BinAff.Core.Crud module = this.CreateModuleServerInstance((this.Data as Data).ModuleData);
            module.Type = ChildType.Independent;
            module.IsReadOnly = true;
            base.AddChild(module);

            //Another read only child for module definition
        }

        protected abstract BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData);

    }

}
