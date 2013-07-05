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
                data.FormList = new List<Document.Data>();
                data.CatalogueList = new List<Document.Data>();
                data.ReportList = new List<Document.Data>();
                foreach (Module.Data module in moduleDataList)
                {
                    Document.Data doc = new Document.Data { Id = module.Id, Name = module.Name };
                    if (module.IsForm) data.FormList.Add(doc);
                    if (module.IsCatalogue) data.CatalogueList.Add(doc);
                    if (module.IsReport) data.ReportList.Add(doc);
                }
            }

            return this.Data as Data;
        }

    }

}
