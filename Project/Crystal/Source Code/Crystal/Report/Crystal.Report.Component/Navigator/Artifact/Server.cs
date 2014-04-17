using System;

using BinAff.Core;

namespace Crystal.Report.Component.Navigator.Artifact
{

    public abstract class Server : Crystal.Navigator.Component.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected abstract override void Compose();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

        protected abstract override BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData);

        protected override ReturnObject<Boolean> DeleteAfter()
        {
            if ((this.Data as Data).ComponentData != null && (this.Data as Data).ComponentData.Id > 0)
            {
                return GetComponentServer().Delete();
            }
            return base.DeleteAfter();
        }

        protected abstract ICrud GetComponentServer();        

    }

}
