using System;
using System.Collections.Generic;

using BinAff.Core;

using VanMod = Vanilla.Utility.Facade.Module;
using VanArtf = Vanilla.Utility.Facade.Artifact;
using VanAcc = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Navigator.Facade.Container
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            :base(formDto)
        {

        }

        public void Logout()
        {
            new VanAcc.Server(new VanAcc.FormDto()).Logout();
        }

        public override void LoadForm()
        {
            this.LoadRule();

            new Vanilla.Utility.Facade.Module.Server((this.FormDto as FormDto).ModuleFormDto) { Category = Utility.Facade.Artifact.Category.Form }.LoadForm();

            this.GetCurrentModules(VanArtf.Category.Form);
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

        public override void Add()
        {
            VanMod.Server moduleFacade = new VanMod.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public override void Change()
        {
            VanMod.Server moduleFacade = new VanMod.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Change();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public void Paste(Boolean isCut)
        {
            VanArtf.Dto originalArtifactDto = this.GetArtifactDtoByValue((this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto);
            originalArtifactDto.Children = new System.Collections.Generic.List<VanArtf.Dto>();

            VanArtf.Dto artifactDto = (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto;

            if (isCut)
            {
                this.Change();
                if (!this.IsError && artifactDto.Children != null && artifactDto.Children.Count > 0)
                    this.PasteCutChild(artifactDto, originalArtifactDto);
            }
            else
            {
                this.Add();
                originalArtifactDto.Id = artifactDto.Id;
                if (!this.IsError && artifactDto.Children != null && artifactDto.Children.Count > 0)
                    this.PasteCopyChild(artifactDto, originalArtifactDto);
            }

            (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto = originalArtifactDto;

        }

        private void PasteCutChild(VanArtf.Dto artifactDto, VanArtf.Dto actualArtifactDto)
        {
            foreach (VanArtf.Dto artf in artifactDto.Children)
            {
                artf.AuditInfo.Version++;
                artf.AuditInfo.ModifiedAt = artifactDto.AuditInfo.ModifiedAt;
                artf.AuditInfo.ModifiedBy = artifactDto.AuditInfo.ModifiedBy;
                artf.Path = artifactDto.Path + artf.FileName + "\\";

                VanArtf.Dto childArtifactDto = this.GetArtifactDtoByValue(artf);
                childArtifactDto.Children = new List<VanArtf.Dto>();
                actualArtifactDto.Children.Add(childArtifactDto);

                (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new VanArtf.FormDto { Dto = artf };
                this.Change();

                if (!this.IsError)
                {
                    if (artf.Children != null && artf.Children.Count > 0)
                        PasteCutChild(artf, childArtifactDto);
                }

            }
        }

        private void PasteCopyChild(VanArtf.Dto artifactDto, VanArtf.Dto actualArtifactDto)
        {
            for (int i = 0; i < artifactDto.Children.Count; i++)
            {
                VanArtf.Dto artf = artifactDto.Children[i] as VanArtf.Dto;

                if (artf.Style == VanArtf.Type.Folder)
                {
                    VanArtf.Dto childArtifactDto = this.GetArtifactDtoByValueForCopy(artf);
                    childArtifactDto.AuditInfo.CreatedAt = artifactDto.AuditInfo.CreatedAt;
                    childArtifactDto.AuditInfo.CreatedBy = artifactDto.AuditInfo.CreatedBy;
                    childArtifactDto.Parent = new BinAff.Facade.Library.Dto { Id = artifactDto.Id };
                    childArtifactDto.Path = artifactDto.Path + childArtifactDto.FileName + "\\";

                    childArtifactDto.Children = new List<VanArtf.Dto>();
                    actualArtifactDto.Children.Add(childArtifactDto);

                    (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto = childArtifactDto;
                    this.Add();

                    artf.Id = childArtifactDto.Id;
                    artf.AuditInfo.CreatedAt = childArtifactDto.AuditInfo.CreatedAt;
                    artf.AuditInfo.CreatedBy = childArtifactDto.AuditInfo.CreatedBy;
                    artf.Path = childArtifactDto.Path;

                    actualArtifactDto.Id = childArtifactDto.Id;

                    if (!this.IsError)
                    {
                        if (artf.Children != null && artf.Children.Count > 0)
                            this.PasteCopyChild(artf, childArtifactDto);
                    }
                }
            }
        }

        private void LoadRule()
        {
            Crystal.Navigator.Rule.Data data = new Crystal.Navigator.Rule.Data();
            ICrud comp = new Crystal.Navigator.Rule.Server(data);
            ReturnObject<Data> ret = comp.Read();
            if ((this.FormDto as FormDto).Rule == null) (this.FormDto as FormDto).Rule = new Vanilla.Utility.Facade.Rule.Dto();
            (this.FormDto as FormDto).Rule.ModuleSeperator = data.ModuleSeperator;
            (this.FormDto as FormDto).Rule.PathSeperator = data.PathSeperator;
        }

        public void GetCurrentModules(VanArtf.Category category)
        {
            Dto dto = new Dto
            {
                Category = category,
            };

            FormDto formDto = this.FormDto as FormDto;

            switch (category)
            {
                case VanArtf.Category.Form:
                    dto.Modules = formDto.ModuleFormDto.FormModuleList;
                    break;
                case VanArtf.Category.Report:
                    dto.Modules = formDto.ModuleFormDto.ReportModuleList;
                    break;
                case VanArtf.Category.Catalogue:
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
            Vanilla.Utility.Facade.Module.Server moduleFacade = new Vanilla.Utility.Facade.Module.Server(null);
        }

        public void GetTreeForCurrentModuleList()
        {

        }

        public override void Delete()
        {
            VanMod.Server moduleFacade = new VanMod.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Delete();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public VanArtf.Dto GetArtifactDtoByValue(VanArtf.Dto data)
        {
            return new VanArtf.Dto
            {
                Id = data.Id,
                FileName = data.FileName,
                Path = data.Path,
                Style = data.Style,
                Category = data.Category,
                AuditInfo = new VanArtf.Audit.Dto
                {
                    Version = data.AuditInfo.Version,
                    CreatedBy = data.AuditInfo.CreatedBy,
                    ModifiedBy = data.AuditInfo.ModifiedBy,
                    CreatedAt = data.AuditInfo.CreatedAt,
                    ModifiedAt = data.AuditInfo.ModifiedAt,
                },
                Children = data.Children == null ? null : this.GetChildren(data.Children),
                Module = data.Module == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = data.Module.Id,
                    Action = data.Module.Action
                },
                Parent = data.Parent == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = data.Parent.Id,
                    Action = data.Parent.Action
                }
            };
        }

        public VanArtf.Dto GetArtifactDtoByValueForCopy(VanArtf.Dto data)
        {
            return new VanArtf.Dto
            {
                FileName = data.FileName,
                Style = data.Style,
                Category = data.Category,
                AuditInfo = new VanArtf.Audit.Dto { Version = 1 },
                Children = data.Children == null ? null : this.GetChildren(data.Children),
                Module = data.Module == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = data.Module.Id,
                    Action = data.Module.Action
                }
            };
        }

        private List<VanArtf.Dto> GetChildren(List<VanArtf.Dto> children)
        {
            List<VanArtf.Dto> childrenList = new List<VanArtf.Dto>();
            for (int i = 0; i < children.Count; i++)
                childrenList.Add(GetArtifactDtoByValue(children[i]));

            return childrenList;
        }

        public VanArtf.Dto ReadDocument(VanArtf.Dto document)
        {
            VanMod.Server server = new VanMod.Server(new VanMod.FormDto
            {
                Dto = new VanMod.Dto
                {
                    Code = document.ComponentDefinition.Code,
                },
                CurrentArtifact = new VanArtf.FormDto
                {
                    Dto = document,
                },
            });
            document = server.ReadArtifact();            
            return document;
        }

        public Boolean IsConnected()
        {
            return BinAff.Utility.Connectivity.IsConnected();
        }

        #region "Menu Handle"

        public void Login()
        {

        }

        #endregion

    }

}
