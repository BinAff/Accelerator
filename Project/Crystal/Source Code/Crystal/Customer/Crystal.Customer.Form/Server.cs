using System.Collections.Generic;

using BinAff.Core;

using Artf = Crystal.Navigator.Component.Artifact;
using Cust = Crystal.Customer.Component;

namespace Crystal.Navigator.Form.Customer
{

    public class Server : Component.Form.Server
    {

        public Server(Data data)
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            this.Name = "Customer Form";
            this.Validator = new Validator(this.Data as Data);
            this.DataAccess = new Dao(this.Data as Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

        protected override void CreateChildren()
        {
            //base.AddChild(new Cust.Server((this.Data as Data).ModuleData as Cust.Data)
            //{
            //    Type = ChildType.Independent,
            //});
        }

    }

}
