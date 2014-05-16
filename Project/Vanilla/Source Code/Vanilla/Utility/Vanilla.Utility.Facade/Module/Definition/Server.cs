using BinAff.Core;
using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Module.Definition
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

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            Crystal.License.Component.Data comp = data as Crystal.License.Component.Data;
            Dto dto = new Dto
            {
                Id = data.Id,
                Code = comp.Code,
                Name = comp.Name,
                Description = comp.Description,
            };
            return dto;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            return new Crystal.License.Component.Data
            {
                Id = dto.Id,
                Code = (dto as Dto).Code,
                Name = (dto as Dto).Name,
            };
        }

        public List<Dto> ReadAll()
        {
            ReturnObject <List<BinAff.Core.Data>> licenseList = (new Crystal.License.Component.Server(null) as ICrud).ReadAll();

            List<Dto> ret = new List<Dto>();
            foreach (Crystal.License.Component.Data data in licenseList.Value)
            {
                ret.Add(this.Convert(data) as Dto);
            }

            return ret;
        }

    }

}
