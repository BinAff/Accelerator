using System;

using BinAff.Core;

namespace Crystal.Navigator.Component.Artifact.Observer
{

    public interface IObserver
    {

        ReturnObject<Boolean> UpdateArtifactComponentLink(Data subject);
        ReturnObject<Boolean> UpdateAfterComponentUpdate(Data subject);

    }

}
