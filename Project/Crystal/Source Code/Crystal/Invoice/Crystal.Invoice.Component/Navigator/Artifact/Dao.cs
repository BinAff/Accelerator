using BinAff.Core;
using System;
using System.Data;
using CrysNav = Crystal.Navigator.Component;

namespace Crystal.Invoice.Component.Navigator.Artifact
{

    public class Dao : CrysNav.Artifact.Dao
    {

        private String DeleteArtifactLinkSPName;

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            this.DeleteArtifactLinkSPName = "[Invoice].[DeleteInvoiceFormForArtifact]";
        }

        protected override Boolean ReadBefore()
        {
            base.CreateConnection();
            base.CreateCommand("[Invoice].[ReadInvoiceFormForArtifact]");
            base.AddInParameter("@ArtifactId", DbType.Int64, this.Data.Id);
            base.AddInParameter("@Category", DbType.Int64, (this.Data as Data).Category);

            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();

            Int64 invoiceId = Convert.IsDBNull(ds.Tables[0].Rows[0]["InvoiceId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["InvoiceId"]);
            if (invoiceId > 0)
            {
                (this.Data as Data).ComponentData = new Invoice.Component.Data
                {
                    Id = invoiceId
                };
            }
            return true;
        }

        protected override BinAff.Core.Data CreateDataObject(long id, CrysNav.Artifact.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

        protected override Boolean CreateAfterModuleArtifactLink()
        {
            Boolean status = true;

            Data artifactData = Data as Data;
            base.CreateCommand("[Invoice].[InsertInvoiceFormForArtifact]");
            if (artifactData.ComponentData.Id == 0)
            {
                base.AddInParameter("@InvoiceId", DbType.Int64, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@InvoiceId", DbType.Int64, artifactData.ComponentData.Id);
            }
            base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            return status;
        }

        protected override bool DeleteBefore()
        {
            return this.DeleteArtifactLink();
        }

        public bool DeleteArtifactLink()
        {
            Boolean status = true;
            base.CreateCommand(this.DeleteArtifactLinkSPName);
            base.AddInParameter("@Id", DbType.Int64, this.Data.Id);

            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            base.CloseConnection();

            return status;

        }

        protected override ReturnObject<Boolean> UpdateArtifactModuleLink()
        {
            Boolean status = true;
            Data artifactData = Data as Data;

            base.CreateCommand("[Invoice].[UpdateInvoiceFormForArtifact]");
            base.AddInParameter("@InvoiceId", DbType.Int64, artifactData.ComponentData.Id);
            base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            return new ReturnObject<Boolean> { Value = status };
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
