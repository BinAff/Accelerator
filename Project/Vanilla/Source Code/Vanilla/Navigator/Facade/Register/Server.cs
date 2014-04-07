using System;
using System.Collections.Generic;

using BinAff.Core;

using UtilFac = Vanilla.Utility.Facade;
using VanAcc = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Navigator.Facade.Register
{

    public class Server : BinAff.Facade.Library.Server
    {
        private Vanilla.Utility.Facade.Artifact.Category currentCategory;

        public Vanilla.Utility.Facade.Artifact.Category Category
        {
            set { this.currentCategory = value; }
            get { return this.currentCategory; }
        }

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public void Logout()
        {
            new VanAcc.Server(new VanAcc.FormDto()).Logout();
        }

        public override void LoadForm()
        {
            this.LoadRule();

            new Vanilla.Utility.Facade.Module.Server((this.FormDto as FormDto).ModuleFormDto) { Category = this.currentCategory }.LoadForm();

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
            UtilFac.Module.Server moduleFacade = new UtilFac.Module.Server((this.FormDto as FormDto).ModuleFormDto) { Category = this.currentCategory };
            moduleFacade.Add();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public override void Change()
        {
            UtilFac.Module.Server moduleFacade = new UtilFac.Module.Server((this.FormDto as FormDto).ModuleFormDto) { Category = this.currentCategory };
            moduleFacade.Change();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public void Paste(Boolean isCut)
        {
            UtilFac.Artifact.Dto originalArtifactDto = this.CloneArtifact((this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto);
            originalArtifactDto.Children = new System.Collections.Generic.List<UtilFac.Artifact.Dto>();

            UtilFac.Artifact.Dto artifactDto = (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto;

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

        private void PasteCutChild(UtilFac.Artifact.Dto artifactDto, UtilFac.Artifact.Dto actualArtifactDto)
        {
            foreach (UtilFac.Artifact.Dto artf in artifactDto.Children)
            {
                artf.Version = artf.Version + 1;
                artf.ModifiedAt = artifactDto.ModifiedAt;
                artf.ModifiedBy = artifactDto.ModifiedBy;
                artf.Path = artifactDto.Path + artf.FileName + "\\";

                UtilFac.Artifact.Dto childArtifactDto = this.CloneArtifact(artf);
                childArtifactDto.Children = new List<UtilFac.Artifact.Dto>();
                actualArtifactDto.Children.Add(childArtifactDto);

                (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new UtilFac.Artifact.FormDto { Dto = artf };
                this.Change();

                if (!this.IsError)
                {
                    if (artf.Children != null && artf.Children.Count > 0)
                        PasteCutChild(artf, childArtifactDto);
                }

            }
        }

        private void PasteCopyChild(UtilFac.Artifact.Dto artifactDto, UtilFac.Artifact.Dto actualArtifactDto)
        {
            for (int i = 0; i < artifactDto.Children.Count; i++)
            {
                UtilFac.Artifact.Dto artf = artifactDto.Children[i] as UtilFac.Artifact.Dto;

                if (artf.Style == UtilFac.Artifact.Type.Directory)
                {
                    UtilFac.Artifact.Dto childArtifactDto = this.GetArtifactDtoByValueForCopy(artf);
                    childArtifactDto.CreatedAt = artifactDto.CreatedAt;
                    childArtifactDto.CreatedBy = artifactDto.CreatedBy;
                    childArtifactDto.Parent = new BinAff.Facade.Library.Dto { Id = artifactDto.Id };
                    childArtifactDto.Path = artifactDto.Path + childArtifactDto.FileName + "\\";

                    childArtifactDto.Children = new List<UtilFac.Artifact.Dto>();
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
            if ((this.FormDto as FormDto).Rule == null) (this.FormDto as FormDto).Rule = new UtilFac.Rule.Dto();
            (this.FormDto as FormDto).Rule.ModuleSeperator = data.ModuleSeperator;
            (this.FormDto as FormDto).Rule.PathSeperator = data.PathSeperator;
        }

        public void GetCurrentModules(UtilFac.Artifact.Category category)
        {
            Dto dto = new Dto
            {
                Category = category,
            };

            FormDto formDto = this.FormDto as FormDto;

            switch (category)
            {
                case UtilFac.Artifact.Category.Form:
                    dto.Modules = formDto.ModuleFormDto.FormModuleList;
                    break;
                case UtilFac.Artifact.Category.Report:
                    dto.Modules = formDto.ModuleFormDto.ReportModuleList;
                    break;
                case UtilFac.Artifact.Category.Catalogue:
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
            UtilFac.Module.Server moduleFacade = new UtilFac.Module.Server(null);
        }

        public void GetTreeForCurrentModuleList()
        {

        }

        public override void Delete()
        {
            UtilFac.Module.Server moduleFacade = new UtilFac.Module.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Delete();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public UtilFac.Artifact.Dto CloneArtifact(UtilFac.Artifact.Dto dto)
        {
            return new UtilFac.Artifact.Dto
            {
                Id = dto.Id,
                FileName = dto.FileName,
                Path = dto.Path,
                Style = dto.Style,
                Category = dto.Category,
                Version = dto.Version,
                CreatedBy = dto.CreatedBy,
                ModifiedBy = dto.ModifiedBy,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
                Children = dto.Children == null ? null : this.GetChildren(dto.Children),
                Module = dto.Module == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = dto.Module.Id,
                    Action = dto.Module.Action
                },
                Parent = dto.Parent == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = dto.Parent.Id,
                    Action = dto.Parent.Action
                }
            };
        }

        public UtilFac.Artifact.Dto GetArtifactDtoByValueForCopy(UtilFac.Artifact.Dto data)
        {
            return new UtilFac.Artifact.Dto
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

        private List<UtilFac.Artifact.Dto> GetChildren(List<UtilFac.Artifact.Dto> children)
        {
            List<UtilFac.Artifact.Dto> childrenList = new List<UtilFac.Artifact.Dto>();
            for (int i = 0; i < children.Count; i++)
                childrenList.Add(CloneArtifact(children[i]));

            return childrenList;
        }

        #region "Menu Handle"

        public void Login()
        {

        }

        #endregion
        
    }

}
