using System;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

using AccFac = Vanilla.Guardian.Facade.Account;
using DocFac = Vanilla.Utility.Facade.Document;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using System.Collections.Generic;

namespace Vanilla.Form.Facade.Document
{

    public abstract class Server : DocFac.Server
    {

        protected BinAff.Core.ICrud componentServer;

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
            (this.FormDto as FormDto).Dto.Id = (this.componentServer as Crud).Data.Id;
            this.UpdateAuditInformation();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
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

            ReturnObject<Boolean> ret = this.GetRegisterer().Register(this.componentServer as BinAff.Core.Observer.ISubject);
            return (this.componentServer as BinAff.Core.Observer.ISubject).NotifyObserver();
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
                    document.AuditInfo.CreatedBy.Name = acc.Profile.Name;
                }
                if (artf.ModifiedBy != null)
                {
                    document.AuditInfo.ModifiedAt = artf.ModifiedAt;
                    AccFac.Dto acc = new AccFac.Server(null).Convert(artf.ModifiedBy) as AccFac.Dto;
                    if (document.AuditInfo.ModifiedBy == null) document.AuditInfo.ModifiedBy = new Table();
                    document.AuditInfo.ModifiedBy.Id = acc.Id;
                    document.AuditInfo.ModifiedBy.Name = acc.Profile.Name;
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
