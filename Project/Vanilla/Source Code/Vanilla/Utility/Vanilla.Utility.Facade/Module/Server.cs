using System;
using System.Collections.Generic;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

//using AutotourismCustomerArtifact = AutoTourism.Component.Customer.Navigator.Artifact;

namespace Vanilla.Utility.Facade.Module
{
    public class Server : BinAff.Facade.Library.Server
    {
        private Artifact.Category currentCategory;

        private Int16 loadPercentage;

        public Artifact.Category Category
        {
            set { this.currentCategory = value; }
            get { return this.currentCategory; }
        }

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            this.loadPercentage = 0;
            Crystal.License.Data data = new Crystal.License.Data();
            (new Crystal.License.Server(data) as Crystal.License.ILicense).Get();

            this.loadPercentage = 10;
            FormDto formDto = this.FormDto as FormDto;
            this.currentCategory = Artifact.Category.Form;
            formDto.FormModuleList = this.Convert(data.FormList);
            this.loadPercentage = 50;
            this.currentCategory = Artifact.Category.Catalogue;
            formDto.CatalogueModuleList = this.Convert(data.CatalogueList);
            this.loadPercentage = 60;
            this.currentCategory = Artifact.Category.Report;
            formDto.ReportModuleList = this.Convert(data.ReportList);
            this.loadPercentage = 100;
        }

        public Int16 GetStatus()
        {
            return this.loadPercentage;
        }

        private List<Module.Dto> Convert(List<Data> dataList)
        {
            List<Module.Dto> ret = new List<Module.Dto>();
            foreach (Crystal.License.Component.Data module in dataList)
            {
                Dto moduleDto = this.Convert(module) as Dto;
                ret.Add(moduleDto);
            }

            return ret;
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            Dto dto = new Module.Dto
            {
                Id = data.Id,
                Code = (data as Crystal.License.Component.Data).Code,
                Name = (data as Crystal.License.Component.Data).Name,
            };
            dto.Artifact = this.GetTree(dto, this.currentCategory);//mistake
            //dto.ComponentFormType = new Helper(dto).ModuleFormType;
            dto.ComponentFormType = new Helper(dto, this.currentCategory).ModuleFormType;

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

        public Artifact.Dto GetTree(Dto module, Artifact.Category category)
        {
            Artifact.Server artifactServer = new Artifact.Server(null);
            Helper helper = new Helper(module, category);
            artifactServer.ModuleFacade = helper.ModuleFacade;
            ArtfCrys.Data artifactData = (helper.Artifact as ArtfCrys.Server).Data as ArtfCrys.Data;
            artifactData.Category = (ArtfCrys.Category)category;
            artifactData.Path = category.ToString() + (this.FormDto as FormDto).Rule.ModuleSeperator
                + (this.FormDto as FormDto).Rule.PathSeperator + (this.FormDto as FormDto).Rule.PathSeperator
                + module.Name + (this.FormDto as FormDto).Rule.PathSeperator;
            artifactData.ComponentDefinition = this.Convert(module) as Crystal.License.Component.Data;
            Artifact.Dto tree = artifactServer.GetTree(helper.Artifact);
            //Assign parent of root lavel artifacts, which are directly under module, to module
            foreach (Artifact.Dto child in tree.Children)
            {
                child.Parent = module;
            }
            return tree;
        }

        public override void Add()
        {
            Artifact.Server artifactServer = GetArtifactFacade(Dto.ActionType.Create);;
            artifactServer.Add();

            this.DisplayMessageList = artifactServer.DisplayMessageList;
            this.IsError = artifactServer.IsError;
        }

        public override void Change()
        {
            Artifact.Server artifactServer = GetArtifactFacade(Dto.ActionType.Update);
            artifactServer.Change();

            this.DisplayMessageList = artifactServer.DisplayMessageList;
            this.IsError = artifactServer.IsError;
        }

        public override void Delete()
        {
            Artifact.Server artifactServer = GetArtifactFacade(Dto.ActionType.Delete);
            this.ValidateAttachmentList(artifactServer);
            if (this.IsError) return;
            artifactServer.Delete();

            this.DisplayMessageList = artifactServer.DisplayMessageList;
            this.IsError = artifactServer.IsError;
        }

        public void ValidateAttachmentList(Artifact.Server artifactFacade)
        {
            ReturnObject<List<ArtfCrys.Data>> ret = (artifactFacade.ModuleArtifactComponent as ArtfCrys.IArtifact).ReadAttachmentLink();
            if (this.IsError = ret.HasError())
            {
                if (this.DisplayMessageList == null) this.DisplayMessageList = new List<String>();
                this.DisplayMessageList.AddRange(ret.GetMessage(Message.Type.Error));
            }
            else
            {
                if (ret.Value != null && ret.Value.Count > 0)
                {
                    this.IsError = true;
                    String message = "Delete following attachments before to delete this "
                        + (artifactFacade.ModuleArtifactComponent as BinAff.Core.Crud).Name
                        + ". List of attachments:"
                        + Environment.NewLine;
                    Int16 i = 1;
                    foreach (ArtfCrys.Data attachment in ret.Value)
                    {
                        message += "  " + i.ToString() + ": " + attachment.Path + "." + attachment.Extension + Environment.NewLine;
                        i++;
                    }
                    if (this.DisplayMessageList == null) this.DisplayMessageList = new List<String>();
                    this.DisplayMessageList.Add(message);
                }
            }
        }

        private ArtfCrys.Category Convert(Artifact.Category category)
        {
            ArtfCrys.Category ret;
            switch (category)
            {
                case Artifact.Category.Form:
                    ret = ArtfCrys.Category.Form;
                    break;
                case Artifact.Category.Catalogue:
                    ret = ArtfCrys.Category.Catelogue;
                    break;
                case Artifact.Category.Report:
                    ret = ArtfCrys.Category.Report;
                    break;
                default:
                    ret = ArtfCrys.Category.Form;
                    break;
            }
            return ret;
        }

        public BinAff.Facade.Library.Dto InstantiateDto(Module.Dto dto)
        {
            //if (this.currentCategory == null)
            //    throw ;

            Type typeDto = Type.GetType(new Helper(dto, this.currentCategory).ModuleFormDtoType, true);
            return Activator.CreateInstance(typeDto) as BinAff.Facade.Library.Dto;
        }

        private Artifact.Server GetArtifactFacade(Dto.ActionType type)
        {
            Facade.Artifact.Dto currentArtifact = (this.FormDto as FormDto).CurrentArtifact.Dto;
            currentArtifact.Action = type;
            
            this.currentCategory = currentArtifact.Category; //line added by Biraj to add the current category

            Helper helper = new Helper((this.FormDto as FormDto).Dto, this.currentCategory);

            Artifact.Server artifactServer = new Artifact.Server((this.FormDto as FormDto).CurrentArtifact);
            artifactServer.ModuleComponentDataType = helper.ArtifactDataType + ", " + helper.ArtifactComponentAssembly;
            if (currentArtifact.ComponentDefinition != null)
            {
                currentArtifact.ComponentDefinition.ComponentFormType = helper.ModuleFormType;
            }
            helper.ArtifactData = artifactServer.ConvertTree(currentArtifact);

            //moduleDefDto.Artifact.Module == null when folder gets added 
            //If Document is added in Customer Node : [helper.ModuleData.Id will carry the customer id for inserting into Customer.CustomerArtifact table]
            helper.ModuleData.Id = currentArtifact.Module == null ? 0 : currentArtifact.Module.Id;

            (helper.ArtifactData as ArtfCrys.Data).ComponentDefinition = this.Convert((this.FormDto as FormDto).Dto) as Crystal.License.Component.Data;

            artifactServer.ModuleArtifactComponent = helper.ArtifactComponent;
            artifactServer.ModuleFacade = helper.ModuleFacade;

            return artifactServer;
        }

        public Dto GetModule(String moduleCode, List<Dto> moduleList)
        {
            Vanilla.Utility.Facade.Module.Dto moduleDto = null;
            if (moduleList != null)
            {
                foreach (Dto dto in moduleList)
                {
                    if (dto.Code == moduleCode)
                    {
                        moduleDto = dto;
                        break;
                    }
                }
            }

            return moduleDto;
        }

        public String GetRootLevelModulePath(String moduleCode, List<Dto> moduleList, String documentType)
        {
            Dto dto = this.GetModule(moduleCode, moduleList);
            String fileName = new Artifact.Server(null).GetArtifactName(dto.Artifact, Artifact.Type.Document, documentType);
            return dto.Artifact.Path + fileName;
        }

        public Artifact.Dto ReadArtifact()
        {
            Artifact.Server artf = this.GetArtifactFacade(BinAff.Facade.Library.Dto.ActionType.Read);
            artf.Read();
            if(this.IsError = artf.IsError) this.DisplayMessageList = artf.DisplayMessageList;
            return (this.FormDto as FormDto).CurrentArtifact.Dto;
        }

    }

}
