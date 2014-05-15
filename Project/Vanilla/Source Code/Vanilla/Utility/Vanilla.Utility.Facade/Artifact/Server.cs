﻿using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysArtf = Crystal.Navigator.Component.Artifact;
using GuardianAcc = Crystal.Guardian.Component.Account;

namespace Vanilla.Utility.Facade.Artifact
{

    public class Server : BinAff.Facade.Library.Server
    {

        public BinAff.Facade.Library.Server ModuleFacade { get; set; }
        internal BinAff.Core.ICrud ModuleArtifactComponent { get; set; }
        public String ModuleComponentDataType { get; set; }

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            //ReturnObject<List<Data>> returnObject = (new AutotourismCustomerForm.Server(new AutotourismCustomerForm.Data()) as ICrud).ReadAll();


            ////Crystal.Navigator.Component.Artifact.Data artifact = new Crystal.Navigator.Component.Artifact.Data();
            ////Crystal.Navigator.Component.Artifact.IArtifact artf = new Crystal.Navigator.Component.Artifact.Server(artifact);
            ////ReturnObject<Crystal.Navigator.Component.Artifact.Data> returnObject = artf.FormTree();

            ////ReturnObject<List<Data>> returnObject = (new Crystal.Navigator.Component.Artifact.Server(new Crystal.Navigator.Component.Artifact.Data()) as ICrud).ReadAll();
            //if (returnObject.HasError())
            //{
            //    this.DisplayMessageList = returnObject.GetMessage(Message.Type.Error);
            //}
            //else
            //{
            //    (this.FormDto as FormDto).Dto.ArtifactList =  this.Convert(returnObject.Value);
            //}
        }

        private List<Facade.Artifact.Dto> Convert(List<Data> dataList)
        {
            List<Artifact.Dto> dtoList = new List<Facade.Artifact.Dto>();
            foreach (Crystal.Navigator.Component.Artifact.Data data in dataList)
            {
                dtoList.Add(this.Convert(data) as Facade.Artifact.Dto);
            }
            return dtoList;
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            Crystal.Navigator.Component.Artifact.Data artifactData = data as Crystal.Navigator.Component.Artifact.Data;

            Facade.Artifact.Dto artifact = new Facade.Artifact.Dto
            {
                Id = artifactData.Id,
                FileName = artifactData.FileName,
                Extension = artifactData.Extension,
                Path = artifactData.Path,
                Style = (artifactData.Style == CrysArtf.Type.Directory) ? Type.Folder : Type.Document,
                Version = artifactData.Version,
                CreatedBy = artifactData.CreatedBy == null ? null : new Table
                {
                    Id = artifactData.CreatedBy.Id,
                    Name = artifactData.CreatedBy.Profile == null ? null : artifactData.CreatedBy.Profile.Name
                },
                CreatedAt = artifactData.CreatedAt,
                ModifiedBy = artifactData.ModifiedBy == null ? null : new Table
                {
                    Id = artifactData.ModifiedBy.Id,
                    Name = artifactData.CreatedBy.Profile == null ? null : artifactData.ModifiedBy.Profile.Name
                },
                ModifiedAt = artifactData.ModifiedAt,
                Category = (Category)artifactData.Category
            };

            if ((data as CrysArtf.Data).ComponentDefinition != null)
            {
                artifact.ComponentDefinition = new Module.Definition.Server(null).Convert((data as CrysArtf.Data).ComponentDefinition) as Module.Definition.Dto;
            }

            if (this.ModuleFacade == null)
            {
                this.ModuleFacade = new Module.Helper(new Module.Dto
                {
                    Code = artifact.ComponentDefinition.Code,
                }, artifact.Category).ModuleFacade;
            }
            if ((data as CrysArtf.Data).ComponentData != null)
            {
                artifact.Module = this.ModuleFacade.Convert((data as CrysArtf.Data).ComponentData);
            }

            return artifact;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Facade.Artifact.Dto artifactDto = dto as Facade.Artifact.Dto;

            System.Type dataType = System.Type.GetType(this.ModuleComponentDataType);
            CrysArtf.Data tree = Activator.CreateInstance(dataType) as CrysArtf.Data;
            tree.Id = artifactDto.Id;
            tree.FileName =  artifactDto.FileName;
            tree.Extension = artifactDto.Extension;
            tree.Path = artifactDto.Path;   
            tree.Category = (CrysArtf.Category)artifactDto.Category;
            tree.Style = (artifactDto.Style == Type.Folder) ? CrysArtf.Type.Directory : CrysArtf.Type.Document;
            tree.CreatedBy = new Crystal.Guardian.Component.Account.Data
            {
                Id = artifactDto.CreatedBy.Id,
            };
            tree.CreatedAt = artifactDto.CreatedAt;
            if (artifactDto.ModifiedBy != null)
            {
                tree.ModifiedBy = new Crystal.Guardian.Component.Account.Data
                {
                    Id = artifactDto.ModifiedBy.Id,
                };
                tree.ModifiedAt = artifactDto.ModifiedAt;
            }
            tree.ParentId = artifactDto.Parent.Id;
            return tree;
        }

        public Data Convert(BinAff.Facade.Library.Dto dto, Crystal.Navigator.Component.Artifact.Data data)
        {
            Facade.Artifact.Dto artifactDto = dto as Facade.Artifact.Dto;
            data.Id = artifactDto.Id;
            data.FileName = artifactDto.FileName;
            data.Extension = artifactDto.Extension;
            data.Path = artifactDto.Path;
            data.Style = (artifactDto.Style == Type.Folder) ? CrysArtf.Type.Directory : CrysArtf.Type.Document;
            data.CreatedBy = new Crystal.Guardian.Component.Account.Data
            {
                Id = artifactDto.CreatedBy.Id,
            };
            data.CreatedAt = artifactDto.CreatedAt;
            data.ModifiedBy = artifactDto.ModifiedBy == null ? null : new Crystal.Guardian.Component.Account.Data
            {
                Id = artifactDto.ModifiedBy.Id,
            };
            data.ModifiedAt = artifactDto.ModifiedAt;
            data.ParentId = artifactDto.Parent == null ? null : (long?)artifactDto.Parent.Id;
            data.Category = (CrysArtf.Category)((Int32)artifactDto.Category);
            return data;
        }

        public Artifact.Dto GetTree(CrysArtf.IArtifact artifact)
        {
            artifact.FormTree();
            return this.ConvertTree((artifact as CrysArtf.Server).Data as CrysArtf.Data);
        }

        private Dto ConvertTree(CrysArtf.Data data)
        {
            Dto tree = new Dto
            {
                Id = data.Id,
                FileName = String.IsNullOrEmpty(data.FileName) ? "." : data.FileName,
                Children = new List<Dto>(),
                Path = data.Path,
                Extension = data.Extension,
                Category = (Category)data.Category,
                ComponentDefinition = new Module.Definition.Server(null).Convert(data.ComponentDefinition) as Module.Definition.Dto
            };
            if (data.Children != null && data.Children.Count > 0)
            {
                foreach (CrysArtf.Data artf in data.Children)
                {
                    Dto child = this.Convert(artf) as Dto;
                    child.Parent = tree;
                    if (artf.Children != null && artf.Children.Count > 0)
                    {
                        child.Children = this.ConvertTree(artf).Children;
                    }
                    tree.Children.Add(child);
                }
            }
            return tree;
        }

        public CrysArtf.Data ConvertTree(Dto dto)
        {
            CrysArtf.Data tree = Activator.CreateInstance(System.Type.GetType(this.ModuleComponentDataType)) as CrysArtf.Data;
            tree.Id = dto.Id;
            tree.FileName = dto.FileName;
            tree.Children = new List<Data>();
            tree.Path = dto.Path;
            tree.Extension = dto.Extension;
            tree.Category = (CrysArtf.Category)dto.Category;
            tree.ParentId = dto.Parent == null ? 0 : dto.Parent.Id;
            tree.CreatedBy = new GuardianAcc.Data { Id = dto.CreatedBy.Id };
            tree.CreatedAt = dto.CreatedAt;
            if (dto.ModifiedBy != null)
            {
                tree.ModifiedBy = new GuardianAcc.Data { Id = dto.ModifiedBy.Id };
                tree.ModifiedAt = dto.ModifiedAt;
            }

            tree.Style = dto.Style == Type.Folder ? CrysArtf.Type.Directory : CrysArtf.Type.Document;
            tree.IsDeletable = dto.Action == BinAff.Facade.Library.Dto.ActionType.Delete;

            if (dto.Children != null && dto.Children.Count > 0)
            {
                foreach (Dto artf in dto.Children)
                {
                    CrysArtf.Data child = this.Convert(artf) as CrysArtf.Data;
                    child.ParentId = tree.Id;
                    child.IsDeletable = tree.IsDeletable;
                    if (artf.Children != null && artf.Children.Count > 0)
                    {
                        child.Children = this.ConvertTree(artf).Children;
                    }
                    tree.Children.Add(child);
                }
            }

            return tree;
        }

        public override void Add()
        {
            this.Save();
        }

        public override void Change()
        {
            this.Save();
        }

        private void Save()
        {
            FormDto formDto = this.FormDto as FormDto;
            ReturnObject<Boolean> ret = this.ModuleArtifactComponent.Save();
            formDto.Dto.Id = (this.ModuleArtifactComponent as Crud).Data.Id;
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Delete()
        {
            ReturnObject<Boolean> ret = this.ModuleArtifactComponent.Delete();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Read()
        {
            FormDto formDto = this.FormDto as FormDto;
            ReturnObject<BinAff.Core.Data> ret = this.ModuleArtifactComponent.Read();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            if (!this.IsError)
            {
                Module.Definition.Dto moduleDef = formDto.Dto.ComponentDefinition;
                BinAff.Facade.Library.Dto parent = formDto.Dto.Parent;
                formDto.Dto = this.Convert(ret.Value) as Dto;
                formDto.Dto.ComponentDefinition = moduleDef;
                formDto.Dto.Parent = parent;
            }
        }

        public Dto Read(String path, Category category, String code)
        {
            Dto artf = null;
            Module.Helper helper = new Module.Helper(new Module.Dto
            {
                Code = code,
            }, category);
            System.Type artifactComponentType = System.Type.GetType(helper.ArtifactComponentType + ", " + helper.ArtifactComponentAssembly, true);
            CrysArtf.Data data = Activator.CreateInstance(System.Type.GetType(helper.ArtifactDataType + ", " + helper.ArtifactComponentAssembly, true)) as CrysArtf.Data;
            data.Id = 1; //Just to call read method in data access
            data.Path = path;

            ReturnObject<BinAff.Core.Data> ret = (Activator.CreateInstance(artifactComponentType, data) as ICrud).Read();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            if (!this.IsError)
            {
                (data as CrysArtf.Data).Category = (CrysArtf.Category)category;
                (data as CrysArtf.Data).ComponentDefinition = new Crystal.License.Component.Data
                {
                    Code = code,
                };
                artf = this.Convert(ret.Value) as Dto;
            }
            return artf;
        }

        //GetDirectoryName :  this method needs to be updated in register.cs 
        public String GetArtifactName(Vanilla.Utility.Facade.Artifact.Dto artifactDto, Type type, String document)
        {
            String fileName = String.Empty;
            String appendText = "New Document";

            if (type.ToString() == Type.Document.ToString())
                appendText = "New " + document;

            if (artifactDto.Children == null)
                return appendText;

            Boolean isExists = false;
            for (int i = 0; i <= artifactDto.Children.Count; i++)
            {
                isExists = false;
                fileName = i == 0 ? appendText : appendText + " (" + i + ")";

                foreach (Vanilla.Utility.Facade.Artifact.Dto childArtifact in artifactDto.Children)
                {
                    if (childArtifact.FileName.ToUpper().Trim() == fileName.ToUpper().Trim())
                    {
                        isExists = true;
                        break;
                    }
                }

                if (!isExists)
                    break;
            }

            return fileName;
        }

        public List<Dto> Search(String artifactName)
        {
            return this.Convert((new Crystal.Navigator.Component.SearchAgent.Server(new Crystal.Navigator.Component.SearchAgent.Data
            {
                FileName = artifactName,
            }) as Crystal.Navigator.Component.SearchAgent.ISearchAgent).Search());
        }

        //public override void Read()
        //{
        //    FormDto formDto = this.FormDto as FormDto;
        //    ReturnObject<BinAff.Core.Data> ret = this.ModuleArtifactComponent.Read();
        //    this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        //}

        public void UpdateArtifactPath(String pathOfParent, Dto artifactDto, String pathSeperator)
        {
            if (artifactDto.Style == Facade.Artifact.Type.Folder)
                artifactDto.Path = pathOfParent + artifactDto.FileName + pathSeperator;
            else
                artifactDto.Path = pathOfParent + artifactDto.FileName;

            if (artifactDto.Children != null && artifactDto.Children.Count > 0)
            {
                foreach (Dto dto in artifactDto.Children)
                    UpdateArtifactPath(artifactDto.Path, dto, pathSeperator);
            }
        }
                
        public Dto CloneArtifact(Dto dto)
        {
            return new Dto
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
                Children = dto.Children == null ? null : GetChildren(dto),
                Extension = dto.Extension,
                Module = dto.Module == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = dto.Module.Id,
                    Action = dto.Module.Action
                },
                Parent = dto.Parent == null ? null : new BinAff.Facade.Library.Dto
                {
                    Id = dto.Parent.Id,
                    Action = dto.Parent.Action
                },
                ComponentDefinition = dto.ComponentDefinition
            };
        }

        public List<Dto> GetChildren(Dto dto)
        {
            List<Dto> children = dto.Children;
            List<Dto> childrenList = new List<Dto>();
            for (int i = 0; i < children.Count; i++)
            {
                Dto clone = CloneArtifact(children[i]);
                clone.Parent = dto;
                childrenList.Add(clone);
            }

            return childrenList;
        }

        public Dto GetParentArtifact(Dto artifactDto)
        {
            if (artifactDto.Parent.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                return ((Vanilla.Utility.Facade.Module.Dto)(artifactDto.Parent)).Artifact;

            return artifactDto.Parent as Dto;
        }

        public String GetParentArtifactPath(Dto artifactDto)
        {
            return this.GetParentArtifact(artifactDto).Path;
        }

    }

}
