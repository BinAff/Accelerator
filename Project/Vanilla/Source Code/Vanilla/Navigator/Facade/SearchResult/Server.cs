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

    }

}
