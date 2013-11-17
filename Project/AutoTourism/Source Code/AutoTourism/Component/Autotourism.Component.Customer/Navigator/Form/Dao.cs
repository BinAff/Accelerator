using System;
using System.Data;

using CrystalForm = Crystal.Customer.Component.Navigator.Form;

namespace Autotourism.Component.Customer.Navigator.Form
{

    public class Dao : CrystalForm.Dao
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
            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();

            Int64 custId = Convert.IsDBNull(ds.Tables[0].Rows[0]["CustomerId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["CustomerId"]);
            if (custId > 0)
            {
                (this.Data as Data).ModuleData = new Crystal.Customer.Component.Data
                {
                    Id = custId
                };
            }
            return true;
        }

        //protected override BinAff.Core.Data InstantiateModuleDataObject()
        //{
        //    //Find CustomerId
        //    //Find Customer
        //    return this.Data;
        //}

    }

}
