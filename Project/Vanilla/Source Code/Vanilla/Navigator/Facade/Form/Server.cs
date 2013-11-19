using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BinAff.Core;

using CrystalArtifact = Crystal.Navigator.Component.Artifact;

namespace Vanilla.Navigator.Facade.Form
{

    public class Server : Vanilla.Navigator.Facade.Artifact.Server
    {
        public BinAff.Facade.Library.Server ModuleFacade { get; set; }

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            Facade.Artifact.Dto artifact = base.Convert(data) as Facade.Artifact.Dto;
            Dto dto = new Dto
            {
                Id = artifact.Id,
                FileName = artifact.FileName,
                Path = artifact.Path,
                Style = artifact.Style,
                Version = artifact.Version,
                CreatedBy = artifact.CreatedBy,
                CreatedAt = artifact.CreatedAt,
                ModifiedBy = artifact.ModifiedBy,
                ModifiedAt = artifact.ModifiedAt,               
            };
            if ((data as Crystal.Navigator.Component.Form.Data).ModuleData != null)
            {
                dto.Module = this.ModuleFacade.Convert((data as Crystal.Navigator.Component.Form.Data).ModuleData);
            }
            return dto;
        }

    }

}
