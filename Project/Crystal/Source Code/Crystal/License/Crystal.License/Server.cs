using System.Collections.Generic;

using BinAff.Core;
namespace Crystal.License
{

    public class Server : BinAff.Core.Crud, ILicense
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "License";
            //this.DataAccess = new Dao((Data)this.Data);
            //this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

        Data ILicense.Get()
        {
            ICrud server = new Module.Server(null);
            List<BinAff.Core.Data> moduleDataList = server.ReadAll().Value;
            if (moduleDataList != null && moduleDataList.Count > 0)
            {
                Data data = this.Data as Data;
                data.FormList = new List<BinAff.Core.Data>();
                data.CatalogueList = new List<BinAff.Core.Data>();
                data.ReportList = new List<BinAff.Core.Data>();
                foreach (Module.Data module in moduleDataList)
                {
                    if (module.IsForm) data.FormList.Add(module);
                    if (module.IsCatalogue) data.CatalogueList.Add(module);
                    if (module.IsReport) data.ReportList.Add(module);
                }
            }

            return this.Data as Data;
        }

    }

}
