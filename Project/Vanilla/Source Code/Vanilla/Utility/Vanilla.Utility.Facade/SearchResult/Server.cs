using System;

using UtilFac = Vanilla.Utility.Facade;

namespace Vanilla.Navigator.Facade.SearchResult
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
            formDto.ArtifactList = new UtilFac.Artifact.Server(null).Search(formDto.Dto.ArtifactName);
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
            UtilFac.Artifact.Dto artifact = (this.FormDto as FormDto).CurrentArtifact as UtilFac.Artifact.Dto;
            UtilFac.Module.FormDto moduleFormDto = new UtilFac.Module.FormDto
            {
                Dto = new UtilFac.Module.Dto
                {
                    Code = artifact.ComponentDefinition.Code,
                },
                CurrentArtifact = new UtilFac.Artifact.FormDto
                {
                    Dto = artifact,
                },
            };
            UtilFac.Module.Server module = new UtilFac.Module.Server(moduleFormDto)
            {
                Category = artifact.Category
            };
            module.ReadArtifact();
            if (this.IsError = module.IsError) this.DisplayMessageList = module.DisplayMessageList;
            (this.FormDto as FormDto).CurrentArtifact =  moduleFormDto.CurrentArtifact.Dto;
        }

    }

}
