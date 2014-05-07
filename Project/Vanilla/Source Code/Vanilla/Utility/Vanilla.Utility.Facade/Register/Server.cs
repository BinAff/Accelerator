using System;
using System.Collections.Generic;
using System.Timers;

using BinAff.Core;

using RuleCrys = Crystal.Navigator.Rule;

using VanAcc = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Utility.Facade.Register
{

    public class Server : BinAff.Facade.Library.Server
    {

        private Artifact.Category currentCategory;
        public Artifact.Category Category
        {
            set { this.currentCategory = value; }
            get { return this.currentCategory; }
        }

        private Int16 loadPercentage;

        /// <summary>
        /// This is just required to give progress bar status
        /// </summary>
        private Module.Server moduleFacade;

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
            this.loadPercentage = 0;
            Timer t = new Timer { Interval = 10 };
            t.Elapsed += t_Elapsed;

            this.LoadRule();
            this.loadPercentage = 10;
            t.Start();
            (this.FormDto as FormDto).ModuleFormDto.Rule = (this.FormDto as FormDto).Rule;
            this.moduleFacade = new Module.Server((this.FormDto as FormDto).ModuleFormDto)
            {
                Category = this.currentCategory 
            };
            this.moduleFacade.LoadForm();
            t.Stop();
            this.loadPercentage = 90;
            this.GetCurrentModules(Artifact.Category.Form);
            this.loadPercentage = 100;
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Since this loading of modle is 80% of ccomplete loading
            this.loadPercentage = (Int16)Math.Abs(this.moduleFacade.GetStatus() * 0.8);
        }

        public Int16 GetStatus()
        {
            return this.loadPercentage;
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
            Module.Server moduleFacade = new Module.Server((this.FormDto as FormDto).ModuleFormDto)
            {
                Category = this.currentCategory
            };
            moduleFacade.Add();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public override void Change()
        {
            Module.Server moduleFacade = new Module.Server((this.FormDto as FormDto).ModuleFormDto)
            {
                Category = this.currentCategory,
            };
            moduleFacade.Change();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public void Paste(Boolean isCut)
        {
            Artifact.Dto originalArtifactDto = new Artifact.Server(null).CloneArtifact((this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto);
            originalArtifactDto.Children = new List<Artifact.Dto>();

            Artifact.Dto artifactDto = (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto;

            if (isCut)
            {
                this.Change();
                if (!this.IsError && artifactDto.Children != null && artifactDto.Children.Count > 0)
                {
                    this.PasteCutChild(artifactDto, originalArtifactDto);
                }
            }
            else
            {
                this.Add();
                originalArtifactDto.Id = artifactDto.Id;
                if (!this.IsError && artifactDto.Children != null && artifactDto.Children.Count > 0)
                {
                    this.PasteCopyChild(artifactDto, originalArtifactDto);
                }
            }

            (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact.Dto = originalArtifactDto;
        }

        private void PasteCutChild(Artifact.Dto artifactDto, Artifact.Dto actualArtifactDto)
        {
            foreach (Artifact.Dto artf in artifactDto.Children)
            {
                artf.Version++;
                artf.ModifiedAt = artifactDto.ModifiedAt;
                artf.ModifiedBy = artifactDto.ModifiedBy;

                artf.Path = artifactDto.Path + artf.FileName;
                if (artf.Style == Artifact.Type.Folder) artf.Path += (this.FormDto as FormDto).Rule.PathSeperator;

                Artifact.Dto childArtifactDto = new Artifact.Server(null).CloneArtifact(artf);
                childArtifactDto.Parent = actualArtifactDto;
                childArtifactDto.Children = new List<Artifact.Dto>();
                actualArtifactDto.Children.Add(childArtifactDto);

                (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Artifact.FormDto
                {
                    Dto = artf
                };
                this.Change();

                if (!this.IsError)
                {
                    if (artf.Children != null && artf.Children.Count > 0)
                    {
                        PasteCutChild(artf, childArtifactDto);
                    }
                }

            }
        }

        private void PasteCopyChild(Artifact.Dto artifactDto, Artifact.Dto actualArtifactDto)
        {
            for (int i = 0; i < artifactDto.Children.Count; i++)
            {
                Artifact.Dto artf = artifactDto.Children[i] as Artifact.Dto;

                if (artf.Style == Artifact.Type.Folder)
                {
                    Artifact.Dto childArtifactDto = this.GetArtifactDtoByValueForCopy(artf);
                    childArtifactDto.CreatedAt = artifactDto.CreatedAt;
                    childArtifactDto.CreatedBy = artifactDto.CreatedBy;
                    childArtifactDto.Parent = new BinAff.Facade.Library.Dto { Id = artifactDto.Id };
                    childArtifactDto.Path = artifactDto.Path + childArtifactDto.FileName + (this.FormDto as FormDto).Rule.PathSeperator;

                    childArtifactDto.Children = new List<Artifact.Dto>();
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
                        {
                            this.PasteCopyChild(artf, childArtifactDto);
                        }
                    }
                }
            }
        }

        private void LoadRule()
        {
            RuleCrys.Data data = new RuleCrys.Data();
            ICrud comp = new RuleCrys.Server(data);
            ReturnObject<Data> ret = comp.Read();
            if ((this.FormDto as FormDto).Rule == null) (this.FormDto as FormDto).Rule = new Rule.Dto();
            (this.FormDto as FormDto).Rule.ModuleSeperator = data.ModuleSeperator;
            (this.FormDto as FormDto).Rule.PathSeperator = data.PathSeperator;
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
            formDto.Dto = dto;
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
            Module.Server moduleFacade = new Module.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Delete();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public Artifact.Dto GetArtifactDtoByValueForCopy(Artifact.Dto data)
        {
            return new Artifact.Dto
            {
                FileName = data.FileName,
                Style = data.Style,
                Category = data.Category,
                Version = 1,
                Children = data.Children == null ? null : new Artifact.Server(null).GetChildren(data),
                Module = data.Module == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = data.Module.Id,
                    Action = data.Module.Action
                }
            };
        }

        #region "Menu Handle"

        public void Login()
        {

        }

        #endregion

        public BinAff.Facade.Library.Server GetReportFacade(Module.Dto dto, Artifact.Category category)
        {
            return new Module.Helper(dto, category).ModuleFacade;
        }

        public Artifact.Category SetCategory(String name)
        {
            switch (name)
            {
                case "Form":
                    this.currentCategory = Artifact.Category.Form;
                    break;
                case "Catalogue":
                    this.currentCategory = Artifact.Category.Catalogue;
                    break;
                case "Report":
                    this.currentCategory = Artifact.Category.Report;
                    break;
                default:
                    this.currentCategory = Artifact.Category.Form;
                    break;
            }
            return this.currentCategory;
        }

        public Artifact.Dto GetArtifactDtoByValue(Artifact.Dto data)
        {
            return new Artifact.Dto
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

        private List<Artifact.Dto> GetChildren(List<Artifact.Dto> children)
        {
            List<Artifact.Dto> childrenList = new List<Artifact.Dto>();
            for (int i = 0; i < children.Count; i++)
            {
                childrenList.Add(GetArtifactDtoByValue(children[i]));
            }

            return childrenList;
        }

        public Artifact.Dto ReadDocument(Artifact.Dto document)
        {
            Module.Server server = new Module.Server(new Module.FormDto
            {
                Dto = new Module.Dto
                {
                    Code = document.ComponentDefinition.Code,
                },
                CurrentArtifact = new Artifact.FormDto
                {
                    Dto = document,
                },
            });
            document = server.ReadArtifact();
            return document;
        }

    }

}
