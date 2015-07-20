using System;

using BinAff.Core;

namespace Retinue.Customer.Component.Navigator.Artifact
{

    public class Server : Crystal.Customer.Component.Navigator.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data
            {
                Category = (this.Data as Data).Category
            };
        }
        
        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override BinAff.Core.Crud CreateComponentServerInstance(BinAff.Core.Data componentData)
        {
            //Find out customer data from customer form
            return new Retinue.Customer.Component.Server(componentData as Retinue.Customer.Component.Data);
        }

        protected override BinAff.Core.Data CreateComponentDataObject()
        {
            return new Retinue.Customer.Component.Data();
        }

        protected override ReturnObject<bool> DeleteAfter()
        {
            if ((this.Data as Data).ComponentData != null && (this.Data as Data).ComponentData.Id > 0)
            {
                ICrud crud = new Retinue.Customer.Component.Server(new Retinue.Customer.Component.Data() { Id = (this.Data as Data).ComponentData.Id });
                return crud.Delete();
            }

            return base.DeleteAfter();
        }
        
    }

}