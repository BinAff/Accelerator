using System;
using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Container
{

    public class Server : BinAff.Facade.Library.Server
    {

        private Crystal.License.Data data;

        public Server(FormDto formDto)
            :base(formDto)
        {

        }

        public override void LoadForm()
        {
            Crystal.License.Data data = new Crystal.License.Data();
            (new Crystal.License.Server(data) as Crystal.License.ILicense).Get();
            ((FormDto)this.FormDto).FormModules = this.ConvertToDto(data.FormList);
            ((FormDto)this.FormDto).ReportModules = this.ConvertToDto(data.ReportList);
            ((FormDto)this.FormDto).CatalogueModules = this.ConvertToDto(data.CatalogueList);
            ((FormDto)this.FormDto).CurrentModules = ((FormDto)this.FormDto).FormModules;
        }

        private List<Module.Dto> ConvertToDto(List<Crystal.License.Document.Data> dataList)
        {
            List<Module.Dto> ret = new List<Module.Dto>();

            foreach (Crystal.License.Document.Data doc in dataList)
            {
                ret.Add(new Module.Dto
                {
                    Id = doc.Id,
                    Name = doc.Name,
                });
            }

            return ret;
        }

        public override void ConvertToDto()
        {
           
        }

        public override void ConvertFromDto()
        {
            
            //foreach (Role.Dto dto in ((FormDto)this.FormDto).Dto.RoleList)
            //{
            //    this.data.RoleList.Add(new Crystal.Guardian.Component.Role.Data
            //    {
            //        Id = dto.Id,
            //        Name = dto.Name,
            //    });
            //}
        }

    }

}
