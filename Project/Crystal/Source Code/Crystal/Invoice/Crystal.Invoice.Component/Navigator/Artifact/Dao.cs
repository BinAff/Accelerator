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

        public Data GetArtifactForInvoiceNumber(String invoiceNumber)
        {           
            Data artifactData = Data as Data;

            base.CreateCommand("[Invoice].[ReadArtifactForInvoiceNumber]");
            base.AddInParameter("@InvoiceNumber", DbType.String, invoiceNumber);          
            DataSet ds =  base.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                artifactData.Id = ds.Tables[0].Rows[0]["ArtifactId"] == null ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["ArtifactId"]);

            return artifactData;

        }

    }

}
