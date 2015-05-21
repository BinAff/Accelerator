using System;

using BinAff.Core;

namespace Crystal.Activity.Component
{

    public abstract class Server : Customer.Component.Action.Server, IActivity
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void CreateChildren()
        {
            base.CreateChildren();
        }

        ReturnObject<Boolean> IActivity.Complete()
        {
            return new ReturnObject<Boolean>
            {
                Value = (this.DataAccess as Dao).UpdateComplition()
            };
        }

    }

}
