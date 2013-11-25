﻿using System;
using System.Data;
using CrystalArtifact = Crystal.Customer.Component.Navigator.Artifact;

namespace Autotourism.Component.Customer.Navigator.Artifact
{

    public class Dao : CrystalArtifact.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
        }

        protected override bool ReadBefore()
        {
            base.CreateConnection();
            base.CreateCommand("Customer.ReadFormForArtifact");
            base.AddInParameter("@ArtifactId", DbType.Int64, this.Data.Id);
            base.AddInParameter("@Category", DbType.Int64, (this.Data as Data).Category);

            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();

            Int64 custId = Convert.IsDBNull(ds.Tables[0].Rows[0]["CustomerId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["CustomerId"]);
            if (custId > 0)
            {
                (this.Data as Data).ModuleData = new Autotourism.Component.Customer.Data
                {
                    Id = custId
                };
            }
            return true;
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, Crystal.Navigator.Component.Artifact.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

        protected override bool CreateAfterModuleArtifactLink()
        {
            bool status = true;

            Data artifactData = Data as Data;
            base.CreateCommand("[Customer].[InsertFormForArtifact]");
            base.AddInParameter("@CustomerId", DbType.Int64, artifactData.ModuleData.Id);
            base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            return status;
        }

    }

}
