using System;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

using DocFac = Vanilla.Utility.Facade.Document;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Form.Facade.Document
{

    public abstract class Server : DocFac.Server
    {
        protected BinAff.Core.ICrud componentServer;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public void RegisterArtifactObserver()
        {
            ArtfCrys.Observer.DocumentComponent module = this.GetComponentServer();
            (module as ArtfCrys.Observer.ISubject).RegisterObserver(this.GetArtifactServer(new ArtfFac.Server(null)
            {
                ModuleComponentDataType = this.GetComponentDataType(),
            }.Convert((base.FormDto as FormDto).Document)));
        }

        protected abstract ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData);
        protected abstract ArtfCrys.Observer.DocumentComponent GetComponentServer();
        protected abstract String GetComponentDataType();

    }

}
