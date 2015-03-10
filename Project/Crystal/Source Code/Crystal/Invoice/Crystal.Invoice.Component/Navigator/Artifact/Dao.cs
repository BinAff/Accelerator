using System;
using System.Data;

using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Invoice.Component.Navigator.Artifact
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
            base.CreateComponentLinkSPName = "Invoice.InvoiceArtifactInsertLink";
            base.ReadComponentLinkSPName = "Invoice.InvoiceArtifactReadLink";
            base.UpdateComponentLinkSPName = "Invoice.InvoiceArtifactUpdateLink";
            base.DeleteComponentLinkSPName = "Invoice.InvoiceArtifactDeleteLink";
            base.ReadForComponentSPName = "Invoice.InvoiceArtifactReadForComponent";
        }

        protected override BinAff.Core.Data CreateDataObject(long id, ArtfComp.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

        protected override BinAff.Core.Data GetComponentData(Int64 componentId)
        {
            return new Invoice.Component.Data
            {
                Id = componentId
            };
        }

    }

}
