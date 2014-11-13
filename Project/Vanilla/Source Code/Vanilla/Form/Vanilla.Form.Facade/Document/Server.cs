using System;
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
            ReturnObject<Boolean> ret = this.ValidateDelete();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                ArtfCrys.Server artfactServer = this.GetArtifactServer(this.GetArtifactData(this.Data.Id));
                (artfactServer.Data as ArtfCrys.Data).Category = ArtfCrys.Category.Form;
                (artfactServer.Data as ArtfCrys.Data).Children = new List<Data>();
                ReturnObject<Boolean> retVal = (artfactServer as BinAff.Core.ICrud).Delete();
                if (this.IsError = retVal.HasError())
                {
                    this.DisplayMessageList = retVal.GetMessage(Message.Type.Error);
                }
            }
        }

        public virtual ReturnObject<Boolean> ValidateDelete()
        {
            Int64 componentId = this.ReadComponentIdForArtifact(this.Data.Id);
            if (componentId == 0) return new ReturnObject<Boolean> { Value = true }; //No component attached with artifact
            this.componentServer = this.GetComponentServer();
            (this.componentServer as Crud).Data.Id = componentId;
            BinAff.Core.Observer.IRegistrar registrar = this.GetRegisterer();
            if (registrar == null) return new ReturnObject<Boolean> { Value = true };
            ReturnObject<Boolean> ret = registrar.Register(this.componentServer as BinAff.Core.Observer.ISubject);
            return (this.componentServer as BinAff.Core.Observer.ISubject).NotifyObserver();
        }

        public virtual void AddAttachmentLink(ArtfFac.Dto attachment)
        {
            ArtfCrys.IArtifact artifactServer = this.GetArtifactServer(this.GetArtifactData((this.FormDto as FormDto).Document.Id));
            ReturnObject<Boolean> ret = artifactServer.CreateAttachmentLink(new ArtfCrys.Data { Id = attachment.Id });
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public virtual void RetrieveAttachmentList()
        {
            ArtfCrys.IArtifact artifactServer = this.GetArtifactServer(this.GetArtifactData((this.FormDto as FormDto).Document.Id));
            ReturnObject<List<ArtfCrys.Data>> ret = artifactServer.ReadAttachmentLink();
            (this.FormDto as FormDto).AttachmentSummeryList = new List<DocFac.AttachmentSummery>();
            foreach (ArtfCrys.Data attachment in ret.Value)
            {
                attachment.ComponentDefinition = new Crystal.License.Component.Data
                {
                    Code = this.GetAttachmentComponentCode(),
                };
                attachment.Category = ArtfCrys.Category.Form;
                (this.FormDto as FormDto).AttachmentSummeryList.Add(new DocFac.AttachmentSummery
                {
                    Artifact = new Vanilla.Utility.Facade.Artifact.Server(null).Convert(attachment) as Vanilla.Utility.Facade.Artifact.Dto,
                    Action = "Delete",
                    Path = attachment.Path + "." + attachment.Extension,
                });
            }
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

        protected Int64 ReadComponentIdForArtifact(Int64 artifactId)
        {
            return (this.GetArtifactServer(this.GetArtifactData(artifactId)) as Crystal.Navigator.Component.Artifact.IArtifact).ReadComponentId();
        }

        protected abstract ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData);
        protected abstract ArtfCrys.Data GetArtifactData(Int64 artifactId);
        protected abstract ICrud GetComponentServer();
        protected abstract String GetComponentDataType();
       
    }

}
