using BinAff.Core;
using System;
using System.Data;
using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Invoice.Component.Payment.Navigator.Artifact
{

    public class Dao : ArtfComp.Dao
    {

        private String deleteArtifactLinkSPName;

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            this.deleteArtifactLinkSPName = "Invoice.PaymentArtifactDeleteLink";
            base.CreateComponentLinkSPName = "Invoice.PaymentArtifactInsertLink";
            base.UpdateComponentLinkSPName = "Invoice.PaymentArtifactUpdateLink";
        }

        protected override Boolean ReadBefore()
        {
            base.CreateConnection();
            base.CreateCommand("Invoice.PaymentArtifactReadLink");
            base.AddInParameter("@ArtifactId", DbType.Int64, this.Data.Id);
            base.AddInParameter("@Category", DbType.Int64, (this.Data as Data).Category);

            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();

            Int64 paymentId = Convert.IsDBNull(ds.Tables[0].Rows[0]["PaymentId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["PaymentId"]);
            if (paymentId > 0)
            {
                (this.Data as Data).ComponentData = new Invoice.Component.Data
                {
                    Id = paymentId
                };
            }
            return true;
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, ArtfComp.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

        //protected override Boolean CreateAfterModuleArtifactLink()
        //{
        //    Boolean status = true;

        //    Data artifactData = Data as Data;
        //    base.CreateCommand("Invoice.PaymentArtifactInsertLink");
        //    if (artifactData.ComponentData.Id == 0)
        //    {
        //        base.AddInParameter("@PaymentId", DbType.Int64, DBNull.Value);
        //    }
        //    else
        //    {
        //        base.AddInParameter("@PaymentId", DbType.Int64, artifactData.ComponentData.Id);
        //    }
        //    base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
        //    base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
        //    Int32 ret = base.ExecuteNonQuery();
        //    if (ret == -2146232060) status = false;//Foreign key violation
        //    return status;
        //}

        protected override Boolean DeleteBefore()
        {
            return this.DeleteArtifactLink();
        }

        public Boolean DeleteArtifactLink()
        {
            Boolean status = true;
            base.CreateCommand(this.deleteArtifactLinkSPName);
            base.AddInParameter("@Id", DbType.Int64, this.Data.Id);

            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            base.CloseConnection();
            return status;
        }

        //protected override ReturnObject<Boolean> UpdateArtifactModuleLink()
        //{
        //    Boolean status = true;
        //    Data artifactData = Data as Data;

        //    base.CreateCommand("Invoice.PaymentArtifactUpdateLink");
        //    base.AddInParameter("@PaymentId", DbType.Int64, artifactData.ComponentData.Id);
        //    base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
        //    Int32 ret = base.ExecuteNonQuery();
        //    if (ret == -2146232060) status = false;//Foreign key violation

        //    return new ReturnObject<Boolean> { Value = status };
        //}

        //public Data GetArtifactForInvoiceNumber(String invoiceNumber)
        //{           
        //    Data artifactData = Data as Data;

        //    base.CreateCommand("[Invoice].[ReadArtifactForInvoiceNumber]");
        //    base.AddInParameter("@InvoiceNumber", DbType.String, invoiceNumber);          
        //    DataSet ds =  base.ExecuteDataSet();

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        artifactData.Id = ds.Tables[0].Rows[0]["ArtifactId"] == null ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["ArtifactId"]);

        //    return artifactData;

        //}

    }

}
