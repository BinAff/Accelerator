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
            if (this.Data == null) this.Data = new Data { Id = (this.FormDto as FormDto).Document.Id };
            ReturnObject<Boolean> ret = this.ValidateDelete();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                if (this.Data == null) this.Data = new Data { Id = (this.FormDto as FormDto).Document.Id };
                ArtfCrys.Server artfactServer = this.GetArtifactServer(this.GetArtifactData(this.Data.Id));
                (artfactServer.Data as ArtfCrys.Data).Category = ArtfCrys.Category.Form;
                (artfactServer.Data as ArtfCrys.Data).Children = new List<Data>();
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
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            ArtfCrys.IArtifact artfactServer = this.GetArtifactServer(this.GetArtifactData(this.Data.Id));
            ret = this.ValidateAttachmentList(artfactServer as ArtfCrys.Server);
            if (!ret.Value) return ret;
            //TO DO :: Need to check attachment link when attachment is getting deleted..............
            ret = this.ValidateAttacherList(artfactServer as ArtfCrys.Server).MergeMessageList(ret);
            if (!ret.Value) return ret;

            BinAff.Core.Data comp = this.ReadComponentForArtifact(this.Data.Id);
            if (comp.Id == 0) return new ReturnObject<Boolean> { Value = true }; //No component attached with artifact
            this.componentServer = this.GetComponentServer();
            (this.componentServer as Crud).Data.Id = comp.Id;
            BinAff.Core.Observer.IRegistrar registrar = this.GetRegisterer();
            if (registrar == null) return new ReturnObject<Boolean> { Value = true };
            ret = registrar.Register(this.componentServer as BinAff.Core.Observer.ISubject).MergeMessageList(ret);
            return (this.componentServer as BinAff.Core.Observer.ISubject).NotifyObserver();
        }

        private ReturnObject<Boolean> ValidateAttachmentList(ArtfCrys.Server artfactServer)
        {
            ReturnObject<List<ArtfCrys.Data>> attachmentLink = (artfactServer as ArtfCrys.IArtifact).ReadAttachmentLink();
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>
            {
                Value = attachmentLink.Value.Count == 0,
                MessageList = new List<Message>(),
            };
            if (ret.Value)
            {
                ret.MessageList = attachmentLink.MessageList;
            }
            else
            {
                if (attachmentLink.Value != null && attachmentLink.Value.Count > 0)
                {
                    this.IsError = true;
                    String message = "Delete the attachments before deleting the form. List of attachments:"
                        + Environment.NewLine;
                    Int16 i = 1;
                    foreach (ArtfCrys.Data attachment in attachmentLink.Value)
                    {
                        message += "  " + i.ToString() + ": " + attachment.FullPath + Environment.NewLine;
                        i++;
                    }
                    if (this.DisplayMessageList == null) this.DisplayMessageList = new List<String>();
                    ret.MessageList.Add(new Message(message, Message.Type.Error));
                }
            }
            return ret;
        }

        private ReturnObject<Boolean> ValidateAttacherList(ArtfCrys.Server artfactServer)
        {
            ReturnObject<List<ArtfCrys.Data>> attacherLink = (artfactServer as ArtfCrys.IArtifact).ReadAttacher();
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>
            {
                Value = attacherLink.Value.Count == 0,
                MessageList = new List<Message>(),
            };
            if (ret.Value)
            {
                ret.MessageList = attacherLink.MessageList;
            }
            else
            {
                if (attacherLink.Value != null && attacherLink.Value.Count > 0)
                {
                    this.IsError = true;
                    String message = "This document is attached with following documents:"
                        + Environment.NewLine;
                    Int16 i = 1;
                    foreach (ArtfCrys.Data attachment in attacherLink.Value)
                    {
                        message += "  " + i.ToString() + ": " + attachment.FullPath + Environment.NewLine;
                        i++;
                    }
                    message += Environment.NewLine + "Remove link before deleting this document.";

                    if (this.DisplayMessageList == null) this.DisplayMessageList = new List<String>();
                    ret.MessageList.Add(new Message(message, Message.Type.Error));
                }
            }
            return ret;
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