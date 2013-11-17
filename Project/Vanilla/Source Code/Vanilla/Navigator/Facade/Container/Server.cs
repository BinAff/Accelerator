using BinAff.Core;
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

        protected override BinAff.Facade.Library.Dto Convert(Data data)
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

        protected override Data Convert(BinAff.Facade.Library.Dto dto)
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

        public void LoadArtifacts(string selectedModule)
        {
            switch (selectedModule)
            {
                case "Customer":

                    break;
            }
            Module.Server moduleFacade = new Module.Server(null);
        }

    }

}
