using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Navigator.Component.Artifact
{

    public interface IArtifact
    {

        ReturnObject<Data> FormTree();
        ReturnObject<Boolean> UpdaterModuleArtifactLink();
        ReturnObject<Data> ReadWithParent();
        ReturnObject<Data> ReadForComponent();
        Int64 ReadComponentId();

        ReturnObject<Boolean> CreateAttachmentLink(Data attachment);
        ReturnObject<List<Data>> ReadAttachmentLink();
        ReturnObject<Boolean> DeleteAttachmentLink(Data attachment);

        ReturnObject<Server> GetAttachmentServer(Data attachment);

    }

}
