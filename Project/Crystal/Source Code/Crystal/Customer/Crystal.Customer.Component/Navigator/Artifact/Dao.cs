using System;
using System.Data;

using BinAff.Core;
using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Customer.Component.Navigator.Artifact
{

    public abstract class Dao : CrystalNavigator.Artifact.Dao
    {

        protected String DeleteArtifactLinkSPName;

        public Dao(Data data)
            : base(data)
        {

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

    }

}
