using System;

using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Invoice.Component.AdvancePayment.Navigator.Artifact
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
            base.CreateComponentLinkSPName = "Invoice.AdvancePaymentArtifactInsertLink";
            base.ReadComponentLinkSPName = "Invoice.AdvancePaymentArtifactReadLink";
            base.UpdateComponentLinkSPName = "Invoice.AdvancePaymentArtifactUpdateLink";
            this.DeleteComponentLinkSPName = "Invoice.AdvancePaymentArtifactDeleteLink";
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
            return new AdvancePayment.Data
            {
                Id = componentId
            };
        }

    }

}
