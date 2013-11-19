using BinAff.Core;
using System;
using System.Collections.Generic;
using Vanilla.Navigator.Facade;

namespace Vanilla.Navigator.Facade.Container
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            :base(formDto)
        {

        }

        public override void LoadForm()
        {
            new Module.Server((this.FormDto as FormDto).ModuleFormDto = new Module.FormDto()).LoadForm();

            this.GetCurrentModules(Group.Form);
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
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
            return null;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            
            //foreach (Role.Dto dto in ((FormDto)this.FormDto).Dto.RoleList)
            //{
            //    this.data.RoleList.Add(new Crystal.Guardian.Component.Role.Data
            //    {
            //        Id = dto.Id,
            //        Name = dto.Name,
            //    });
            //}
            return null;
        }

        public void GetCurrentModules(Group group)
        {
            Dto dto = new Dto
            {
                Group = group,
            };

            FormDto formDto = this.FormDto as FormDto;

            switch (group)
            {
                case Group.Form:
                    dto.Modules = formDto.ModuleFormDto.FormModuleList;
                    break;
                case Group.Report:
                    dto.Modules = formDto.ModuleFormDto.ReportModuleList;
                    break;
                case Group.Catalogue:
                    dto.Modules = formDto.ModuleFormDto.CatalogueModuleList;
                    break;
            }
            (this.FormDto as FormDto).Dto = dto;

        }

        public void LoadArtifacts(string selectedModule)
        {
            switch (selectedModule)
            {
                case "Customer":

                    break;
            }
            Module.Server moduleFacade = new Module.Server(null);
        }

        public void GetTreeForCurrentModuleList()
        {

        }

    }

}
