﻿using System;
using System.Collections.Generic;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

using AccFac = Vanilla.Guardian.Facade.Account;
using DocFac = Vanilla.Utility.Facade.Document;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using ModDefFac = Vanilla.Utility.Facade.Module.Definition;

namespace Vanilla.Form.Facade.Document
{

    public abstract class Server : DocFac.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {
            //if (formDto != null) this.componentServer = this.GetComponentServer();
        }

        public void RegisterArtifactObserver()
        {
            this.componentServer = this.GetComponentServer();
            (this.componentServer as ArtfCrys.Observer.ISubject).RegisterObserver(this.GetArtifactServer(new ArtfFac.Server(null)
            {
                ModuleComponentDataType = this.GetComponentDataType(),
            }.Convert((base.FormDto as FormDto).Document)));
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
            ReturnObject<Boolean> ret = this.componentServer.Save();
            this.IsError = ret.HasError();
            if(!this.IsError)
            {
                (this.FormDto as FormDto).Dto.Id = (this.componentServer as Crud).Data.Id;
                this.UpdateAuditInformation();
            }
            this.DisplayMessageList = ret.GetMessage((this.IsError) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Delete()
        {
            if(this.Data == null) this.Data = new Data { Id = (this.FormDto as FormDto).Document.Id };
            ArtfCrys.Server artfactServer = this.GetArtifactServer(this.GetArtifactData(this.Data.Id));
            (artfactServer.Data as ArtfCrys.Data).Category = ArtfCrys.Category.Form;
            (artfactServer.Data as ArtfCrys.Data).Children = new List<Data>();

            this.ValidateAttachmentList(artfactServer);
            if (this.IsError) return;

            ReturnObject<Boolean> ret = this.ValidateDelete();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                ReturnObject<Boolean> retVal = (artfactServer as BinAff.Core.ICrud).Delete();
                this.AttachMessage(retVal);
            }
        }

        public override void Read()
        {
            FormDto formDto = this.FormDto as FormDto;
            if (formDto == null)
            {
                throw new ArgumentException("FormDto is not assigned to read document from facade: " + this.ToString());
            }
            if (formDto.Dto != null)
            {
                ReturnObject<Data> data = this.GetComponentServer().Read();
                this.IsError = data.HasError();
                this.DisplayMessageList = data.GetMessage(this.IsError ? Message.Type.Error : Message.Type.Information);
                formDto.Dto = this.Convert(data.Value) as Dto;
            }
        }

        public virtual ReturnObject<Boolean> ValidateDelete()
        {
            BinAff.Core.Data comp = this.ReadComponentForArtifact(this.Data.Id);
            if (comp.Id == 0) return new ReturnObject<Boolean> { Value = true }; //No component attached with artifact
            this.componentServer = this.GetComponentServer();
            (this.componentServer as Crud).Data.Id = comp.Id;
            BinAff.Core.Observer.IRegistrar registrar = this.GetRegisterer();
            if (registrar == null) return new ReturnObject<Boolean> { Value = true };
            ReturnObject<Boolean> ret = registrar.Register(this.componentServer as BinAff.Core.Observer.ISubject);
            return (this.componentServer as BinAff.Core.Observer.ISubject).NotifyObserver();
        }

        public void ValidateAttachmentList(ArtfCrys.Server artfactServer)
        {
            ReturnObject<List<ArtfCrys.Data>> ret = (artfactServer as ArtfCrys.IArtifact).ReadAttachmentLink();
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
                    String message = "Delete the attachments before deleting the form - "
                        + (artfactServer.Data as ArtfCrys.Data).FullPath
                        + ". List of attachments:"
                        + Environment.NewLine;
                    Int16 i = 1;
                    foreach (ArtfCrys.Data attachment in ret.Value)
                    {
                        message += "  " + i.ToString() + ": " + attachment.FullPath + Environment.NewLine;
                        i++;
                    }
                    if (this.DisplayMessageList == null) this.DisplayMessageList = new List<String>();
                    this.DisplayMessageList.Add(message);
                }
            }
        }

        public virtual void AddAttachmentLink(ArtfFac.Dto attachment)
        {
            ArtfCrys.IArtifact artifactServer = this.GetArtifactServer(this.GetArtifactData((this.FormDto as FormDto).Document.Id));
            ReturnObject<Boolean> ret = artifactServer.CreateAttachmentLink(new ArtfCrys.Data { Id = attachment.Id });
            this.AttachMessage(ret);
        }

        public virtual void RetrieveAttachmentList()
        {
            ArtfCrys.IArtifact artifactServer = this.GetArtifactServer(this.GetArtifactData((this.FormDto as FormDto).Document.Id));
            ReturnObject<List<ArtfCrys.Data>> ret = artifactServer.ReadAttachmentLink();
            this.AttachMessage(ret);
            (this.FormDto as FormDto).Document.AttachmentList = new List<ArtfFac.Dto>();
            foreach (ArtfCrys.Data attachment in ret.Value)
            {
                ICrud attachmentServer = this.GetAttachmentServer(artifactServer, attachment);
                ArtfCrys.Data attachmentData = (attachmentServer as ArtfCrys.Server).Data as ArtfCrys.Data;
                attachmentData.ComponentDefinition = new Crystal.License.Component.Data
                {
                    Code = this.GetAttachmentComponentCode(),
                };
                attachmentServer.Read();
                (this.FormDto as FormDto).Document.AttachmentList.Add(new ArtfFac.Server(null).Convert(attachmentData) as ArtfFac.Dto);
            }
        }

        private ArtfCrys.Server GetAttachmentServer(ArtfCrys.IArtifact artifactServer, ArtfCrys.Data attachment)
        {
            return artifactServer.GetAttachmentServer(attachment).Value;
        }

        public virtual void DeleteAttachment(ArtfFac.Dto attachment)
        {
            ArtfCrys.IArtifact artifactServer = this.GetArtifactServer(this.GetArtifactData((this.FormDto as FormDto).Document.Id));
            ReturnObject<Boolean> ret = artifactServer.DeleteAttachmentLink(new ArtfCrys.Data { Id = attachment.Id });
            this.AttachMessage(ret);
        }

        protected virtual ArtfFac.Dto GetAttachmentArtifact(Int64 attachmentId)
        {
            throw new NotImplementedException();
        }

        protected virtual String GetAttachmentComponentCode()
        {
            throw new NotImplementedException();
        }

        public virtual ModDefFac.Dto GetAncestorComponentCode()
        {
            throw new NotImplementedException();
        }

        protected virtual BinAff.Core.Observer.IRegistrar GetRegisterer()
        {
            throw new NotImplementedException();
        }

        protected void UpdateAuditInformation()
        {
            if ((this.componentServer as ArtfCrys.Observer.DocumentComponent).Observers.Count > 0)
            {
                ArtfCrys.Data artf = ((this.componentServer as ArtfCrys.Observer.DocumentComponent).Observers[0].Data as ArtfCrys.Data);
                ArtfFac.Dto document = (this.FormDto as FormDto).Document;
                document.AuditInfo.Version = artf.Version;
                if (artf.CreatedBy != null)
                {
                    document.AuditInfo.CreatedAt = artf.CreatedAt;
                    AccFac.Dto acc = new AccFac.Server(null).Convert(artf.CreatedBy) as AccFac.Dto;
                    if (document.AuditInfo.CreatedBy == null) document.AuditInfo.CreatedBy = new Table();
                    document.AuditInfo.CreatedBy.Id = acc.Id;
                    if (acc.Profile != null)
                    {
                        document.AuditInfo.CreatedBy.Name = acc.Profile.Name;
                    }
                }
                if (artf.ModifiedBy != null)
                {
                    document.AuditInfo.ModifiedAt = artf.ModifiedAt;
                    AccFac.Dto acc = new AccFac.Server(null).Convert(artf.ModifiedBy) as AccFac.Dto;
                    if (document.AuditInfo.ModifiedBy == null) document.AuditInfo.ModifiedBy = new Table();
                    document.AuditInfo.ModifiedBy.Id = acc.Id;
                    if (acc.Profile != null)
                    {
                        document.AuditInfo.ModifiedBy.Name = acc.Profile.Name;
                    }
                }
            }
        }

        protected BinAff.Core.Data ReadComponentForArtifact(Int64 artifactId)
        {
            ReturnObject<BinAff.Core.Data> ret = (this.GetArtifactServer(this.GetArtifactData(artifactId)) as Crystal.Navigator.Component.Artifact.IArtifact).ReadLinkedComponent();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
                return null;
            }
            else
            {
                return ret.Value;
            }
        }

        protected abstract ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData);
        protected abstract ArtfCrys.Data GetArtifactData(Int64 artifactId);
        protected abstract ICrud GetComponentServer();
        protected abstract String GetComponentDataType();
       
    }

}