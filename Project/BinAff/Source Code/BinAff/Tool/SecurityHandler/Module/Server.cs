using System.Collections.Generic;

namespace BinAff.Tool.SecurityHandler.Module
{

    public class Server : BinAff.Core.Crud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Name = "Module";
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

        protected override void CreateChildren()
        {
            base.AddChildren(new Component.Server(null)
            {
                Type = ChildType.Dependent,
                IsReadOnly = true,
            }, (this.Data as Data).ComponentList);
        }

    }

}
