using System;

using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Invoice.Component.Payment.Navigator.Artifact
{

    public class Dao : ArtfComp.Dao
    {
        
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            base.CreateComponentLinkSPName = "Invoice.PaymentArtifactInsertLink";
            base.ReadComponentLinkSPName = "Invoice.PaymentArtifactReadLink";
            base.UpdateComponentLinkSPName = "Invoice.PaymentArtifactUpdateLink";
            this.DeleteComponentLinkSPName = "Invoice.PaymentArtifactDeleteLink";
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
            return new Invoice.Component.Payment.Data
            {
                Id = componentId
            };
        }

    }

}
