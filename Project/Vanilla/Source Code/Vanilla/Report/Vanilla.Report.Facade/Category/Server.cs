using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Crys = Crystal.Report.Component.Category;

namespace Vanilla.Report.Facade.Category
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
            Crys.Data category = data as Crys.Data;
            return new Dto
            {
                Id = category.Id,
                Name = category.Name,
                Extension = category.Extension,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto category = dto as Dto;
            return new Crys.Data
            {
                Id = category.Id,
                Name = category.Name,
                Extension = category.Extension,
            };
        }

    }

}
