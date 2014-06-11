using System;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

using AccFac = Vanilla.Guardian.Facade.Account;
using DocFac = Vanilla.Utility.Facade.Document;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

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
            ArtfCrys.Observer.DocumentComponent module = this.GetComponentServer();
            (module as ArtfCrys.Observer.ISubject).RegisterObserver(this.GetArtifactServer(new ArtfFac.Server(null)
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

        protected abstract ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData);
        protected abstract ArtfCrys.Observer.DocumentComponent GetComponentServer();
        protected abstract String GetComponentDataType();        
       
    }

}
