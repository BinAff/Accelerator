using System;
using System.Collections.Generic;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

namespace Crystal.Navigator.Component.Artifact
{

    public interface IArtifact
    {

        ReturnObject<Data> FormTree();
        ReturnObject<Boolean> UpdaterModuleArtifactLink();
        ReturnObject<Data> ReadWithParent();
        Int64 ReadComponentId();
        ReturnObject<Boolean> CreateAttachmentLink(ArtfCrys.Data attachment);
        ReturnObject<List<Data>> ReadAttachmentLink();
        ReturnObject<Boolean> DeleteAttachmentLink(ArtfCrys.Data attachment);

    }

}
