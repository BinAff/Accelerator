using System;

using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Accountant.Component.Invoice.Navigator.Artifact
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
            base.CreateComponentLinkSPName = "Accountant.InvoiceArtifactInsertLink";
            base.ReadComponentLinkSPName = "Accountant.InvoiceArtifactReadLink";
            base.UpdateComponentLinkSPName = "Accountant.InvoiceArtifactUpdateLink";
            base.DeleteComponentLinkSPName = "Accountant.InvoiceArtifactDeleteLink";
            base.ReadForComponentSPName = "Accountant.InvoiceArtifactReadForComponent";
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
            return new Invoice.Data
            {
                Id = componentId
            };
        }

    }

}