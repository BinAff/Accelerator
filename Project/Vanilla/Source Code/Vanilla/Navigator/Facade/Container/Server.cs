using System;
using System.Collections.Generic;

using BinAff.Core;

using VanilaModule = Vanilla.Utility.Facade.Module;
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

            this.GetCurrentModules(Vanilla.Utility.Facade.Artifact.Category.Form);
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
            VanilaModule.Server moduleFacade = new VanilaModule.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public override void Change()
        {
            VanilaModule.Server moduleFacade = new VanilaModule.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Change();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public void Paste(Boolean isCut)
        {
            Vanilla.Utility.Facade.Artifact.Dto originalArtifactDto = this.GetArtifactDtoByValue((this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto);
            originalArtifactDto.Children = new System.Collections.Generic.List<Vanilla.Utility.Facade.Artifact.Dto>();

            Vanilla.Utility.Facade.Artifact.Dto artifactDto = (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto;

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

        private void PasteCutChild(Vanilla.Utility.Facade.Artifact.Dto artifactDto, Vanilla.Utility.Facade.Artifact.Dto actualArtifactDto)
        {
            foreach (Vanilla.Utility.Facade.Artifact.Dto artf in artifactDto.Children)
            {
                artf.Version = artf.Version + 1;
                artf.ModifiedAt = artifactDto.ModifiedAt;
                artf.ModifiedBy = artifactDto.ModifiedBy;
                artf.Path = artifactDto.Path + artf.FileName + "\\";

                Vanilla.Utility.Facade.Artifact.Dto childArtifactDto = this.GetArtifactDtoByValue(artf);
                childArtifactDto.Children = new List<Vanilla.Utility.Facade.Artifact.Dto>();
                actualArtifactDto.Children.Add(childArtifactDto);

                (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Vanilla.Utility.Facade.Artifact.FormDto { Dto = artf };
                this.Change();

                if (!this.IsError)
                {
                    if (artf.Children != null && artf.Children.Count > 0)
                        PasteCutChild(artf, childArtifactDto);
                }

            }
        }

        private void PasteCopyChild(Vanilla.Utility.Facade.Artifact.Dto artifactDto, Vanilla.Utility.Facade.Artifact.Dto actualArtifactDto)
        {
            for (int i = 0; i < artifactDto.Children.Count; i++)
            {
                Vanilla.Utility.Facade.Artifact.Dto artf = artifactDto.Children[i] as Vanilla.Utility.Facade.Artifact.Dto;

                if (artf.Style == Vanilla.Utility.Facade.Artifact.Type.Directory)
                {
                    Vanilla.Utility.Facade.Artifact.Dto childArtifactDto = this.GetArtifactDtoByValueForCopy(artf);
                    childArtifactDto.CreatedAt = artifactDto.CreatedAt;
                    childArtifactDto.CreatedBy = artifactDto.CreatedBy;
                    childArtifactDto.Parent = new BinAff.Facade.Library.Dto { Id = artifactDto.Id };
                    childArtifactDto.Path = artifactDto.Path + childArtifactDto.FileName + "\\";

                    childArtifactDto.Children = new List<Vanilla.Utility.Facade.Artifact.Dto>();
                    actualArtifactDto.Children.Add(childArtifactDto);

                    (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto = childArtifactDto;
                    this.Add();

                    artf.Id = childArtifactDto.Id;
                    artf.CreatedAt = childArtifactDto.CreatedAt;
                    artf.CreatedBy = childArtifactDto.CreatedBy;
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

        public void GetCurrentModules(Vanilla.Utility.Facade.Artifact.Category category)
        {
            Dto dto = new Dto
            {
                Category = category,
            };

            FormDto formDto = this.FormDto as FormDto;

            switch (category)
            {
                case Vanilla.Utility.Facade.Artifact.Category.Form:
                    dto.Modules = formDto.ModuleFormDto.FormModuleList;
                    break;
                case Vanilla.Utility.Facade.Artifact.Category.Report:
                    dto.Modules = formDto.ModuleFormDto.ReportModuleList;
                    break;
                case Vanilla.Utility.Facade.Artifact.Category.Catalogue:
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
            VanilaModule.Server moduleFacade = new VanilaModule.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Delete();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public Vanilla.Utility.Facade.Artifact.Dto GetArtifactDtoByValue(Vanilla.Utility.Facade.Artifact.Dto data)
        {
            return new Vanilla.Utility.Facade.Artifact.Dto
            {
                Id = data.Id,
                FileName = data.FileName,
                Path = data.Path,
                Style = data.Style,
                Category = data.Category,
                Version = data.Version,
                CreatedBy = data.CreatedBy,
                ModifiedBy = data.ModifiedBy,
                CreatedAt = data.CreatedAt,
                ModifiedAt = data.ModifiedAt,
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

        public Vanilla.Utility.Facade.Artifact.Dto GetArtifactDtoByValueForCopy(Vanilla.Utility.Facade.Artifact.Dto data)
        {
            return new Vanilla.Utility.Facade.Artifact.Dto
            {
                FileName = data.FileName,
                Style = data.Style,
                Category = data.Category,
                Version = 1,
                Children = data.Children == null ? null : this.GetChildren(data.Children),
                Module = data.Module == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = data.Module.Id,
                    Action = data.Module.Action
                }
            };
        }

        private List<Vanilla.Utility.Facade.Artifact.Dto> GetChildren(List<Vanilla.Utility.Facade.Artifact.Dto> children)
        {
            List<Vanilla.Utility.Facade.Artifact.Dto> childrenList = new List<Vanilla.Utility.Facade.Artifact.Dto>();
            for (int i = 0; i < children.Count; i++)
                childrenList.Add(GetArtifactDtoByValue(children[i]));

            return childrenList;
        }

        #region "Menu Handle"

        public void Login()
        {

        }

        #endregion

    }

}
