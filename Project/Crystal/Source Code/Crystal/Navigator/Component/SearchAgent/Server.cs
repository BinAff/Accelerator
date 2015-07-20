using System.Collections.Generic;

namespace Crystal.Navigator.Component.SearchAgent
{

    public class Server: Artifact.Server, ISearchAgent
    {

        public Server(Artifact.Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.DataAccess = new Dao(base.Data as Data);
        }

        List<BinAff.Core.Data> ISearchAgent.Search()
        {
            return (this.DataAccess as Dao).Search();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(this.Data as Data);
        }

        protected override BinAff.Core.Crud CreateComponentServerInstance(BinAff.Core.Data componentData)
        {
            throw new System.NotImplementedException();
        }

        protected override BinAff.Core.Data CreateComponentDataObject()
        {
            throw new System.NotImplementedException();
        }

    }

}