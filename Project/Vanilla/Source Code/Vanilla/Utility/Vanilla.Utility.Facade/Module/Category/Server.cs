using BinAff.Core;
using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Module.Category
{

    public class Server : BinAff.Facade.Library.Server
    {

        private Artifact.Category currentCategory;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }
        
        public override void LoadForm()
        {
            
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {            
            Dto dto = null;
            switch (this.currentCategory)
            {
                case Artifact.Category.Catalogue:
                    break;
                case Artifact.Category.Form:
                    break;
                case Artifact.Category.Report:
                    Crystal.Report.Component.Category.Data dt = data as Crystal.Report.Component.Category.Data;
                    dto = new Dto
                    {
                        Id = dt.Id,
                        Extension = dt.Extension,
                        Name = dt.Name,
                    };
                    break;
            }

            return dto;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto dt = dto as Dto;
            BinAff.Core.Data data = null;
            switch (this.currentCategory)
            {
                case Artifact.Category.Catalogue:
                    break;
                case Artifact.Category.Form:
                    break;
                case Artifact.Category.Report:
                    data = new Crystal.Report.Component.Category.Data
                    {
                        Id = dt.Id,
                        Extension = dt.Extension,
                        Name = dt.Name,
                    };
                    break;
            }

            return data;
        }

        internal List<Dto> ReadAll(Artifact.Category artifactCategory)
        {
            this.currentCategory = artifactCategory;
            List<Dto> ret = new List<Dto>();
            switch (artifactCategory)
            {
                case Artifact.Category.Catalogue:
                    break;
                case Artifact.Category.Form:
                    break;
                case Artifact.Category.Report:
                    ICrud server = new Crystal.Report.Component.Category.Server(null);
                    ReturnObject<List<Data>> categoryList = server.ReadAll();
                    if (categoryList.Value != null)
                    {
                        foreach (Data data in categoryList.Value)
                        {
                            ret.Add(this.Convert(data) as Dto);
                        }
                    }
                    break;
            }
            return ret;
        }

    }

}
