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
        Int64 ReadComponentId();

    }

}
