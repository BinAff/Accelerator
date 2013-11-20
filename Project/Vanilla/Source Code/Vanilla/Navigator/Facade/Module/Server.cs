using System;
using System.Collections.Generic;

using BinAff.Core;

using CrystalArtifact = Crystal.Navigator.Component.Artifact;

using AutotourismCustomerArtifact = Autotourism.Component.Customer.Navigator.Artifact;

namespace Vanilla.Navigator.Facade.Module
{

    public class Server : BinAff.Facade.Library.Server
    {

        private Category currentGroup;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            Crystal.License.Data data = new Crystal.License.Data();
            (new Crystal.License.Server(data) as Crystal.License.ILicense).Get();

            FormDto formDto = this.FormDto as FormDto;

            this.currentGroup = Category.Form;
            formDto.FormModuleList = this.Convert(data.FormList);
            this.currentGroup = Category.Catalogue;
            formDto.CatalogueModuleList = this.Convert(data.CatalogueList);
            this.currentGroup = Category.Report;
            formDto.ReportModuleList = this.Convert(data.ReportList);
        }

        private List<Module.Dto> Convert(List<Data> dataList)
        {
            List<Module.Dto> ret = new List<Module.Dto>();
            foreach (Crystal.License.Module.Data module in dataList)
            {
                ret.Add(this.Convert(module) as Dto);
            }

            return ret;
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            Module.Dto ret = new Module.Dto
            {
                Id = data.Id,
                Code = (data as Crystal.License.Module.Data).Code,
                Name = (data as Crystal.License.Module.Data).Name,
            };
            ret.Artifact = this.GetTree(ret, this.currentGroup);//mistake
            return ret;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            return new Crystal.License.Module.Data
            {
                Id = dto.Id,
                Code = (dto as Dto).Code,
                Name = (dto as Dto).Name,
            };
        }

        public Artifact.Dto GetTree(Dto module, Category category)
        {
            Artifact.Server artifactServer = new Artifact.Server(null);

            CrystalArtifact.Data data;
            CrystalArtifact.IArtifact artf;
            switch (module.Code)
            {
                case "CUST":
                    data = new AutotourismCustomerArtifact.Data
                    {
                        FileName = "Customer",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerArtifact.Server(data as AutotourismCustomerArtifact.Data);
                    artifactServer.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;
                case "LRSV"://Need to change
                    data = new AutotourismCustomerArtifact.Data
                    {
                        FileName = "Lodge Reservation",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerArtifact.Server(data as AutotourismCustomerArtifact.Data);
                    artifactServer.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);//Need to change
                    break;
                case "ROOM"://Need to change
                    data = new AutotourismCustomerArtifact.Data
                    {
                        FileName = "Room",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerArtifact.Server(data as AutotourismCustomerArtifact.Data);
                    artifactServer.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);//Need to change
                    break;
                default://Need to change
                    data = new AutotourismCustomerArtifact.Data
                    {
                        FileName = "Customer",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerArtifact.Server(data as AutotourismCustomerArtifact.Data);
                    artifactServer.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;
            }
            switch(category)
            {
                case Category.Form:
                    data.Category = CrystalArtifact.Category.Form;
                    break;
                case Category.Catalogue:
                    data.Category = CrystalArtifact.Category.Catelogue;
                    break;
                case Category.Report:
                    data.Category = CrystalArtifact.Category.Report;
                    break;
                default:
                    data.Category = CrystalArtifact.Category.Form;
                    break;
            }
            return artifactServer.GetTree(artf);
        }

    }

}
