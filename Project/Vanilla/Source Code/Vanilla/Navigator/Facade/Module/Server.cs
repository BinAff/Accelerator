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
            Facade.Artifact.Dto currentArtifact = (this.FormDto as FormDto).CurrentArtifact.Dto;
            Artifact.Server artifactServer = new Artifact.Server((this.FormDto as FormDto).CurrentArtifact);

            Helper helper = new Helper((this.FormDto as FormDto).Dto);
            helper.ArtifactData = artifactServer.Convert(currentArtifact, helper.ArtifactData as CrystalArtifact.Data);

            //moduleDefDto.Artifact.Module == null when folder gets added 
            //If Document is added in Customer Node : [helper.ModuleData.Id will carry the customer id for inserting into Customer.CustomerArtifact table]
            helper.ModuleData.Id = currentArtifact.Module == null ? 0 : currentArtifact.Module.Id;

            (helper.ArtifactData as CrystalArtifact.Data).ModuleDefinition = this.Convert((this.FormDto as FormDto).Dto) as Crystal.License.Module.Data;

            //(this.FormDto as FormDto).Dto.
            artifactServer.ModuleArtifactComponent = helper.ArtifactComponent;
            artifactServer.ModuleFacade = helper.ModuleFacade;
            artifactServer.Add();

            this.DisplayMessageList = artifactServer.DisplayMessageList;
            this.IsError = artifactServer.IsError;
            //Dto moduleDefDto = (this.FormDto as FormDto).Dto;
            //Facade.Artifact.Dto correntArtifact = (this.FormDto as FormDto).CurrentArtifact.Dto;
            //Artifact.Server artifactServer = new Artifact.Server((this.FormDto as FormDto).CurrentArtifact);

            //Helper helper = new Helper((this.FormDto as FormDto).Dto);
            //helper.ArtifactData = artifactServer.Convert(moduleDefDto.Artifact, helper.ArtifactData as CrystalArtifact.Data);

            ////moduleDefDto.Artifact.Module == null when folder gets added 
            ////I      f Document is added in Customer Node : [helper.ModuleData.Id will carry the customer id for inserting into Customer.CustomerArtifact table]
            //helper.ModuleData.Id = moduleDefDto.Artifact.Module == null ? 0 : moduleDefDto.Artifact.Module.Id; 

            //(helper.ArtifactData as CrystalArtifact.Data).ModuleDefinition = this.Convert((this.FormDto as FormDto).Dto) as Crystal.License.Module.Data;

            //artifactServer.ModuleArtifactComponent = helper.ArtifactComponent;
            //artifactServer.ModuleFacade = helper.ModuleFacade;
            //artifactServer.Add();

            //this.DisplayMessageList = artifactServer.DisplayMessageList;
            //this.IsError = artifactServer.IsError;
        }

        public void Delete()
        {          
            Facade.Artifact.Dto currentArtifact = (this.FormDto as FormDto).CurrentArtifact.Dto;
            Artifact.Server artifactServer = new Artifact.Server((this.FormDto as FormDto).CurrentArtifact);

            Helper helper = new Helper((this.FormDto as FormDto).Dto);
            helper.ArtifactData = artifactServer.Convert(currentArtifact, helper.ArtifactData as CrystalArtifact.Data);

            //moduleDefDto.Artifact.Module == null when folder gets added 
            //If Document is added in Customer Node : [helper.ModuleData.Id will carry the customer id for inserting into Customer.CustomerArtifact table]
            helper.ModuleData.Id = currentArtifact.Module == null ? 0 : currentArtifact.Module.Id;

            (helper.ArtifactData as CrystalArtifact.Data).ModuleDefinition = this.Convert((this.FormDto as FormDto).Dto) as Crystal.License.Module.Data;

            artifactServer.ModuleArtifactComponent = helper.ArtifactComponent;
            artifactServer.ModuleFacade = helper.ModuleFacade;
            artifactServer.Delete();

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
