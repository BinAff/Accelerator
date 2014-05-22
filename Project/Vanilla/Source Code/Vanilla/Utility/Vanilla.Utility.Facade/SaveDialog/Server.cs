using System;

using BinAff.Core;

using ArtfFac = Vanilla.Utility.Facade.Artifact;
using AccFac = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Utility.Facade.SaveDialog
{
    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            throw new NotImplementedException();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }

        public override void Add()
        {
            Dto dto = (base.FormDto as FormDto).Dto;
            Rule.Dto navRule = (BinAff.Facade.Cache.Server.Current.Cache["Main"] as Cache.Dto).NavigatorRule;
            ArtfFac.Dto doc = new ArtfFac.Dto
            {
                FileName = dto.DocumentName,
                Style = ArtfFac.Type.Document,
                Category = dto.Parent.Category,
                ComponentDefinition = dto.Parent.ComponentDefinition,
                Parent = dto.Parent,
                Path = dto.Parent.Path + navRule.PathSeperator + dto.DocumentName,
                AuditInfo = new ArtfFac.Audit.Dto
                {
                    Version = 1,
                    CreatedBy = new Table
                    {
                        Id = (BinAff.Facade.Cache.Server.Current.Cache["User"] as AccFac.Dto).Id,
                        Name = (BinAff.Facade.Cache.Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
                    },
                    CreatedAt = DateTime.Now,
                },
            };
            Module.Server moduleFacade = new Module.Server(new Module.FormDto
            {
                Dto = new Module.Dto
                {
                    Id = doc.ComponentDefinition.Id,
                    Code = doc.ComponentDefinition.Code,
                },
                CurrentArtifact = new Artifact.FormDto
                {
                    Dto = doc,
                },                
            })
            {
                Category = doc.Category,
            };
            moduleFacade.Add();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

    }

}
