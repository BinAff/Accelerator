using System;

using ArtfComp = Crystal.Navigator.Component.Artifact;
using CustArtfComp = Crystal.Customer.Component.Navigator.Artifact;

namespace Retinue.Customer.Component.Navigator.Artifact
{

    public class Dao : CustArtfComp.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            base.CreateComponentLinkSPName = "Customer.CustomerArtifactInsertLink";
            base.ReadComponentLinkSPName = "Customer.CustomerArtifactReadLink";
            base.UpdateComponentLinkSPName = "Customer.CustomerArtifactUpdateLink";
            base.DeleteComponentLinkSPName = "Customer.CustomerArtifactDeleteLink";
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, ArtfComp.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

        protected override BinAff.Core.Data GetComponentData(Int64 componentId)
        {
            return new Retinue.Customer.Component.Data
            {
                Id = componentId
            };
        }
        
    }

}
