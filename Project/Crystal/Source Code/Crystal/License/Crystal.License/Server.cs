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
            ICrud server = new Component.Server(null);
            List<BinAff.Core.Data> componentDataList = server.ReadAll().Value;
            if (componentDataList != null && componentDataList.Count > 0)
            {
                Data data = this.Data as Data;
                data.FormList = new List<BinAff.Core.Data>();
                data.CatalogueList = new List<BinAff.Core.Data>();
                data.ReportList = new List<BinAff.Core.Data>();
                foreach (Component.Data component in componentDataList)
                {
                    if (component.IsForm) data.FormList.Add(component);
                    if (component.IsCatalogue) data.CatalogueList.Add(component);
                    if (component.IsReport) data.ReportList.Add(component);
                }
            }

            return this.Data as Data;
        }

    }

}
