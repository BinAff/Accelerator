using System;
using System.Collections.Generic;

using BinAff.Core;
using VanilaModule = Vanilla.Navigator.Facade.Module;


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
            new Module.Server((this.FormDto as FormDto).ModuleFormDto).LoadForm();

            this.GetCurrentModules(Artifact.Category.Form);
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

        public void Paste(bool isCut)
        {            
            Facade.Artifact.Dto originalArtifactDto = this.GetArtifactDtoByValue((this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto);
            originalArtifactDto.Children = new System.Collections.Generic.List<Artifact.Dto>();          

            Facade.Artifact.Dto artifactDto = (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto;

            if (isCut)
            {
                this.Change();

                if (!this.IsError)
                {
                    if (artifactDto.Children != null && artifactDto.Children.Count > 0)
                        PasteCutChild(artifactDto);
                }
            }
            else
            {
                this.Add();
                if (!this.IsError)
                {
                    if (artifactDto.Children != null && artifactDto.Children.Count > 0)
                        PasteCopyChild(artifactDto, originalArtifactDto);
                }

                (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto = originalArtifactDto;
            }

        }

        private void PasteCutChild(Facade.Artifact.Dto artifactDto)
        {
            foreach (Facade.Artifact.Dto artf in artifactDto.Children)
            {
                artf.Version = artf.Version + 1;
                artf.ModifiedAt = artifactDto.ModifiedAt;
                artf.ModifiedBy = artifactDto.ModifiedBy;
                artf.Path = artifactDto.Path + artf.FileName + "\\";

                (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Artifact.FormDto { Dto = artf };
                this.Change();

                if (!this.IsError)
                {
                    if (artf.Children != null && artf.Children.Count > 0)
                        PasteCutChild(artf);
                }

            }
        }

        private void PasteCopyChild(Facade.Artifact.Dto artifactDto, Facade.Artifact.Dto actualArtifactDto)
        {
            for (int i = 0; i < artifactDto.Children.Count; i++)
            {
                Facade.Artifact.Dto artf = artifactDto.Children[i] as Facade.Artifact.Dto;

                if (artf.Style == Artifact.Type.Directory)
                {
                    artf.Id = 0;
                    artf.Version = 1;
                    artf.Path = artifactDto.Path + artf.FileName + "\\";
                    artf.Parent = new BinAff.Facade.Library.Dto { Id = artifactDto.Id };
                    artf.CreatedAt = DateTime.Now;
                    artf.CreatedBy = new Table { Id = 1, Name = "Biraj K" }; //Read from Cahce
                    artf.ModifiedBy = null;
                  
                    (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto = artf;
                    this.Add();                  

                    Facade.Artifact.Dto childArtifactDto = this.GetArtifactDtoByValue(artf);
                    childArtifactDto.Children = new List<Artifact.Dto>();
                    actualArtifactDto.Children.Add(childArtifactDto);


                    if (!this.IsError)
                    {
                        if (artf.Children != null && artf.Children.Count > 0)
                            PasteCopyChild(artf, childArtifactDto);
                    }
                }
            }
        }

        public void GetCurrentModules(Artifact.Category category)
        {
            Dto dto = new Dto
            {
                Category = category,
            };

            FormDto formDto = this.FormDto as FormDto;

            switch (category)
            {
                case Artifact.Category.Form:
                    dto.Modules = formDto.ModuleFormDto.FormModuleList;
                    break;
                case Artifact.Category.Report:
                    dto.Modules = formDto.ModuleFormDto.ReportModuleList;
                    break;
                case Artifact.Category.Catalogue:
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

        public override void Delete()
        {
            VanilaModule.Server moduleFacade = new VanilaModule.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Delete();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public Facade.Artifact.Dto GetArtifactDtoByValue(Facade.Artifact.Dto data)
        {
            return new Artifact.Dto
            {
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

        private List<Facade.Artifact.Dto> GetChildren(List<Facade.Artifact.Dto> children)
        {
            List<Facade.Artifact.Dto> childrenList = new List<Artifact.Dto>();
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
