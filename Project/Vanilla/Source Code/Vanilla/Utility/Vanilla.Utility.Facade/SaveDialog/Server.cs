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
            FormDto formDto = base.FormDto as FormDto;
            Rule.Dto navRule = (BinAff.Facade.Cache.Server.Current.Cache["Main"] as Cache.Dto).NavigatorRule;
            formDto.Document = new ArtfFac.Dto
            {
                FileName = formDto.Dto.DocumentName,
                Extension = this.GetExtension(formDto.Dto.Parent.Category, ArtfFac.Type.Document),
                Style = ArtfFac.Type.Document,
                Category = formDto.Dto.Parent.Category,
                ComponentDefinition = formDto.Dto.Parent.ComponentDefinition,
                Parent = formDto.Dto.Parent,
                Path = formDto.Dto.Parent.Path + navRule.PathSeperator + formDto.Dto.DocumentName,
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
                    Id = formDto.Document.ComponentDefinition.Id,
                    Code = formDto.Document.ComponentDefinition.Code,
                },
                CurrentArtifact = new Artifact.FormDto
                {
                    Dto = formDto.Document,
                },                
            })
            {
                Category = formDto.Document.Category,
            };
            moduleFacade.Add();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        /// <summary>
        /// This should not be hard coded. It should handled using database
        /// </summary>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public String GetExtension(Artifact.Category category, Artifact.Type type)
        {
            if (type == Artifact.Type.Folder) return null;
            switch (category)
            {
                case Artifact.Category.Form:
                    return "frm";
                case Artifact.Category.Catalogue:
                    return "ctl";
                default:
                    return "binaff";
            }
        }

    }

}
