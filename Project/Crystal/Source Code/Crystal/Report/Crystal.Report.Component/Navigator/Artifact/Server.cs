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
