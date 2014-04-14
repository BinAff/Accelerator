using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Utility.Facade.Module.Category
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }
        
        public override void LoadForm()
        {
            
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }

        internal List<Dto> ReadAll(Artifact.Category artifactCategory)
        {
            List<Dto> ret = new List<Dto>();
            switch (artifactCategory)
            {
                case Artifact.Category.Catalogue:
                    break;
                case Artifact.Category.Form:
                    break;
                case Artifact.Category.Report:
                    //BinAff.Core.ICrud server = new Crystal.Report.Component.Category.s
                    break;
            }
            return ret;
        }

    }

}
