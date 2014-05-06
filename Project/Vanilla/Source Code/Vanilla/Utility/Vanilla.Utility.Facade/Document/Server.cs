using System;

namespace Vanilla.Utility.Facade.Document
{
    public class Server : BinAff.Facade.Library.Server
    {
        public Artifact.Dto ArtifactDto { get; set; }
        protected String ModuleArtifactLinkSP { get; set; }

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            throw new NotImplementedException();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }

        protected Boolean UpdateModuleArtifactLink()
        {
            Boolean status = true;

            //Data artifactData = Data as Data;
            //base.CreateCommand("[Customer].[InsertFormForArtifact]");
            //if (artifactData.ComponentData.Id == 0)
            //{
            //    base.AddInParameter("@CustomerId", DbType.Int64, DBNull.Value);
            //}
            //else
            //{
            //    base.AddInParameter("@CustomerId", DbType.Int64, artifactData.ComponentData.Id);
            //}
            //base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            //base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
            //Int32 ret = base.ExecuteNonQuery();
            //if (ret == -2146232060) status = false;//Foreign key violation

            return status;
        }

        public Dto GetModule()
        {
            return (this.FormDto as FormDto).Dto;
        }

    }
}
