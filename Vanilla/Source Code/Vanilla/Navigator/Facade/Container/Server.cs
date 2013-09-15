using System;
using System.Collections.Generic;

using Vanilla.Navigator.Facade;

namespace Vanilla.Navigator.Facade.Container
{

    public class Server : BinAff.Facade.Library.Server
    {

        private Crystal.License.Data data;
        private List<Module.Dto> formModules;
        private List<Module.Dto> catalogueModules;
        private List<Module.Dto> reportModules;

        public Server(FormDto formDto)
            :base(formDto)
        {

        }

        public override void LoadForm()
        {
            (new Crystal.License.Server(data = new Crystal.License.Data()) as Crystal.License.ILicense).Get();
            this.formModules = this.ConvertToDto(data.FormList);
            this.reportModules = this.ConvertToDto(data.ReportList);
            this.catalogueModules = this.ConvertToDto(data.CatalogueList);

            this.GetModules(Group.Form);
        }

        private List<Module.Dto> ConvertToDto(List<Crystal.License.Module.Data> dataList)
        {
            List<Module.Dto> ret = new List<Module.Dto>();

            foreach (Crystal.License.Module.Data doc in dataList)
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
            //Dto dto = (this.FormDto as FormDto).Dto;
            //dto.Group = Module.Group.Form;

            //foreach (Crystal.License.Module.Data doc in dataList)
            //{
            //    ret.Add(new Module.Dto
            //    {
            //        Id = doc.Id,
            //        Name = doc.Name,
            //    });
            //}
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

        public void GetModules(Group group)
        {
            Dto dto = new Dto
            {
                Group = group,
            };

            switch (group)
            {
                case Group.Form:
                    dto.Modules = this.formModules;
                    break;
                case Group.Report:
                    dto.Modules = this.reportModules;
                    break;
                case Group.Catalogue:
                    dto.Modules = this.catalogueModules;
                    break;
            }
            (this.FormDto as FormDto).Dto = dto;

        }

    }

}
