using System.Collections.Generic;

namespace BinAff.Tool.SecurityHandler.Component
{

    public class Server : BinAff.Core.Crud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Name = "Component";
            base.DataAccess = new Dao(this.Data as Data)
            {
                ConnectionString = Properties.Settings.Default.License,
            };
        }

        protected override Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override Core.Crud CreateInstance(Core.Data data)
        {
            return new Server(data as Data);
        }

    }

}
