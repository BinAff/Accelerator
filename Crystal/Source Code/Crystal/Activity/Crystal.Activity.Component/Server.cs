namespace Crystal.Activity.Component
{

    public abstract class Server : Customer.Component.Action.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void CreateChildren()
        {
            base.CreateChildren();
        }

    }

}
