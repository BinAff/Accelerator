using System;

using CrystalForm = Crystal.Customer.Component.Navigator.Form;

namespace Autotourism.Component.Customer.Navigator.Form
{

    public class Server : CrystalForm.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Autotourism Customer Form";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData)
        {
            //Find out customer data from customer form
            return new Autotourism.Component.Customer.Server(moduleData as Autotourism.Component.Customer.Data);
        }
    }

}
