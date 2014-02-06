﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BinAff.Core;
using CrystalArtifact = Crystal.Navigator.Component.Artifact;
using CustomerArtifact = AutoTourism.Component.Customer.Navigator.Artifact;
using GuardianAcc = Crystal.Guardian.Component.Account;

namespace Vanilla.Utility.Facade.Artifact
{
    public class Server : BinAff.Facade.Library.Server
    {
        public BinAff.Facade.Library.Server ModuleFacade { get; set; }
        internal BinAff.Core.ICrud ModuleArtifactComponent { get; set; }
        internal String ModuleComponentDataType { get; set; }

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
                Path = artifactData.Path,
                Style = (artifactData.Style == CrystalArtifact.Type.Directory) ? Type.Directory : Type.Document,
                Version = artifactData.Version,
                CreatedBy = artifactData.CreatedBy == null ? null : new Table
                {
                    Id = artifactData.CreatedBy.Id,
                    Name = artifactData.CreatedBy.Profile.Name
                },
                CreatedAt = artifactData.CreatedAt,
                ModifiedBy = artifactData.ModifiedBy == null ? null : new Table
                {
                    Id = artifactData.ModifiedBy.Id,
                    Name = artifactData.ModifiedBy.Profile.Name
                },
                ModifiedAt = artifactData.ModifiedAt,
                Category = (Category)artifactData.Category
            };

            if ((data as CrystalArtifact.Data).ModuleData != null)
            {
                artifact.Module = this.ModuleFacade.Convert((data as CrystalArtifact.Data).ModuleData);
            }

            return artifact;

        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Facade.Artifact.Dto artifactDto = dto as Facade.Artifact.Dto;

            System.Type dataType = System.Type.GetType(this.ModuleComponentDataType);
            CrystalArtifact.Data tree = Activator.CreateInstance(dataType) as CrystalArtifact.Data;
            dataType.GetProperty("Id").SetValue(tree, artifactDto.Id, null);
            dataType.GetProperty("FileName").SetValue(tree, artifactDto.FileName, null);
            dataType.GetProperty("Path").SetValue(tree, artifactDto.Path, null);
            dataType.GetProperty("Category").SetValue(tree, (CrystalArtifact.Category)artifactDto.Category, null);
            dataType.GetProperty("Style").SetValue(tree, (artifactDto.Style == Type.Directory) ? CrystalArtifact.Type.Directory : CrystalArtifact.Type.Document, null);
            dataType.GetProperty("CreatedBy").SetValue(tree, new Crystal.Guardian.Component.Account.Data
            {
                Id = artifactDto.CreatedBy.Id,
            }, null);
            dataType.GetProperty("CreatedAt").SetValue(tree, artifactDto.CreatedAt, null);

            dataType.GetProperty("ModifiedBy").SetValue(tree, artifactDto.ModifiedBy == null ? null : new Crystal.Guardian.Component.Account.Data
            {
                Id = artifactDto.ModifiedBy.Id,
            }, null);
            dataType.GetProperty("ModifiedAt").SetValue(tree, artifactDto.ModifiedAt, null);

            return tree;
        }

        public Data Convert(BinAff.Facade.Library.Dto dto, Crystal.Navigator.Component.Artifact.Data data)
        {
            Facade.Artifact.Dto artifactDto = dto as Facade.Artifact.Dto;
            data.Id = artifactDto.Id;
            data.FileName = artifactDto.FileName;
            data.Path = artifactDto.Path;
            data.Style = (artifactDto.Style == Type.Directory) ? CrystalArtifact.Type.Directory : CrystalArtifact.Type.Document;
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
            data.Category = (CrystalArtifact.Category)((Int32)artifactDto.Category);
            return data;
        }

        public Artifact.Dto GetTree(CrystalArtifact.IArtifact artifact)
        {
            artifact.FormTree();
            return this.ConvertTree((artifact as CrystalArtifact.Server).Data as CrystalArtifact.Data);
        }

        private Dto ConvertTree(CrystalArtifact.Data data)
        {
            Dto tree = new Dto
            {
                Id = data.Id,
                FileName = String.IsNullOrEmpty(data.FileName) ? "." : data.FileName,
                Children = new List<Dto>(),
                Path = data.Path,
                Category = (Category)data.Category,
            };
            if (data.Children != null && data.Children.Count > 0)
            {
                foreach (CrystalArtifact.Data artf in data.Children)
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

        public CrystalArtifact.Data ConvertTree(Dto dto)
        {
            System.Type dataType = System.Type.GetType(this.ModuleComponentDataType);
            CrystalArtifact.Data tree = Activator.CreateInstance(dataType) as CrystalArtifact.Data;
            dataType.GetProperty("Id").SetValue(tree, dto.Id, null);
            dataType.GetProperty("FileName").SetValue(tree, dto.FileName, null);
            dataType.GetProperty("Children").SetValue(tree, new List<Data>(), null);
            dataType.GetProperty("Path").SetValue(tree, dto.Path, null);
            dataType.GetProperty("Category").SetValue(tree, (CrystalArtifact.Category)dto.Category, null);
            dataType.GetProperty("ParentId").SetValue(tree, dto.Parent == null ? 0 : dto.Parent.Id, null);
            dataType.GetProperty("CreatedBy").SetValue(tree, new GuardianAcc.Data { Id = dto.CreatedBy.Id }, null);
            dataType.GetProperty("CreatedAt").SetValue(tree, dto.CreatedAt, null);


            if (dto.ModifiedBy != null)
            {
                dataType.GetProperty("ModifiedBy").SetValue(tree, new GuardianAcc.Data { Id = dto.ModifiedBy.Id }, null);
                dataType.GetProperty("ModifiedAt").SetValue(tree, dto.ModifiedAt, null);
            }

            dataType.GetProperty("Style").SetValue(tree, dto.Style == Type.Directory ? CrystalArtifact.Type.Directory : CrystalArtifact.Type.Document, null);


            tree.IsDeletable = dto.Action == BinAff.Facade.Library.Dto.ActionType.Delete;

            if (dto.Children != null && dto.Children.Count > 0)
            {
                foreach (Dto artf in dto.Children)
                {
                    CrystalArtifact.Data child = this.Convert(artf) as CrystalArtifact.Data;
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

    }
}
