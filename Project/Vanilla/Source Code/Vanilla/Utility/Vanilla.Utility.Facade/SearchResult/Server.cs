using System;

namespace Vanilla.Utility.Facade.SearchResult
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.ArtifactList = new Artifact.Server(null).Search(formDto.Dto.ArtifactName);
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }

        public override void Read()
        {
            Artifact.Dto artifact = (this.FormDto as FormDto).CurrentArtifact as Artifact.Dto;
            Module.FormDto moduleFormDto = new Module.FormDto
            {
                Dto = new Module.Dto
                {
                    Code = artifact.ComponentDefinition.Code,
                },
                CurrentArtifact = new Artifact.FormDto
                {
                    Dto = artifact,
                },
            };
            Module.Server module = new Module.Server(moduleFormDto)
            {
                Category = artifact.Category
            };
            module.ReadArtifact();
            if (this.IsError = module.IsError) this.DisplayMessageList = module.DisplayMessageList;
            (this.FormDto as FormDto).CurrentArtifact =  moduleFormDto.CurrentArtifact.Dto;
        }

    }

}
