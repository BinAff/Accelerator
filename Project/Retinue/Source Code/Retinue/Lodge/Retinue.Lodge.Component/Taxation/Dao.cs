using System.Data;
using System.Collections.Generic;

namespace Retinue.Lodge.Component.Taxation
{

    public class Dao : Crystal.Accountant.Component.Tax.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.ReadStoredProcedure = "Lodge.TaxationRead";
            base.ReadAllStoredProcedure = "Lodge.TaxationReadAll";          
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            return base.CreateDataObject(ds, data);
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {           
            return base.CreateDataObjectList(ds);
        }

    }

}