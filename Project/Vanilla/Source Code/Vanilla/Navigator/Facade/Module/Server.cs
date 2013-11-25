using System;
using System.Collections.Generic;

using BinAff.Core;

using CrystalArtifact = Crystal.Navigator.Component.Artifact;

using AutotourismCustomerArtifact = Autotourism.Component.Customer.Navigator.Artifact;

namespace Vanilla.Navigator.Facade.Module
{

    public class Server : BinAff.Facade.Library.Server
    {

        private Artifact.Category currentGroup;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            Crystal.License.Data data = new Crystal.License.Data();
            (new Crystal.License.Server(data) as Crystal.License.ILicense).Get();

            FormDto formDto = this.FormDto as FormDto;

            this.currentGroup = Artifact.Category.Form;
            formDto.FormModuleList = this.Convert(data.FormList);
            this.currentGroup = Artifact.Category.Catalogue;
            formDto.CatalogueModuleList = this.Convert(data.CatalogueList);
            this.currentGroup = Artifact.Category.Report;
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
            Dto dto = new Module.Dto
            {
                Id = data.Id,
                Code = (data as Crystal.License.Module.Data).Code,
                Name = (data as Crystal.License.Module.Data).Name,
            };

            dto.Artifact = this.GetTree(dto, this.currentGroup);//mistake
            dto.ComponentFormType = new Helper(dto).ModuleFormType;

            return dto;
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

        public Artifact.Dto GetTree(Dto module, Artifact.Category category)
        {
            Artifact.Server artifactServer = new Artifact.Server(null);
            Helper helper = new Helper(module);
            artifactServer.ModuleFacade = helper.ModuleFacade;
            CrystalArtifact.Data artifactData = (helper.Artifact as CrystalArtifact.Server).Data as CrystalArtifact.Data;
            artifactData.Category = this.Convert(category);
            artifactData.Path = category.ToString();
            artifactData.ModuleDefinition = this.Convert(module) as Crystal.License.Module.Data;
            return artifactServer.GetTree(helper.Artifact);
        }

        public void Add()
        {
            Dto moduleDefDto = (this.FormDto as FormDto).Dto;
            Artifact.Server artifactServer = new Artifact.Server(new Artifact.FormDto
            {
                Dto = moduleDefDto.Artifact
            });

            Helper helper = new Helper((this.FormDto as FormDto).Dto);
            helper.ArtifactData = artifactServer.Convert(moduleDefDto.Artifact, helper.ArtifactData as CrystalArtifact.Data);
            helper.ModuleData.Id = moduleDefDto.Artifact.Module.Id;
            (helper.ArtifactData as CrystalArtifact.Data).ModuleDefinition = this.Convert((this.FormDto as FormDto).Dto) as Crystal.License.Module.Data;

            artifactServer.ModuleArtifactComponent = helper.ArtifactComponent;
            artifactServer.ModuleFacade = helper.ModuleFacade;
            artifactServer.Add();

            this.DisplayMessageList = artifactServer.DisplayMessageList;
            this.IsError = artifactServer.IsError;
        }

        private CrystalArtifact.Category Convert(Artifact.Category category)
        {
            CrystalArtifact.Category ret;
            switch (category)
            {
                case Artifact.Category.Form:
                    ret = CrystalArtifact.Category.Form;
                    break;
                case Artifact.Category.Catalogue:
                    ret = CrystalArtifact.Category.Catelogue;
                    break;
                case Artifact.Category.Report:
                    ret = CrystalArtifact.Category.Report;
                    break;
                default:
                    ret = CrystalArtifact.Category.Form;
                    break;
            }
            return ret;
        }

        public BinAff.Facade.Library.Dto InstantiateDto(Module.Dto dto)
        {
            Type typeDto = Type.GetType(new Helper(dto).ModuleFormDtoType, true);
            return Activator.CreateInstance(typeDto) as BinAff.Facade.Library.Dto;
        }

    }

}
