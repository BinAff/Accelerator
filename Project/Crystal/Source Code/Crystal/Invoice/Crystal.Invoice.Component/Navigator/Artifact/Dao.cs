using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Invoice.Component.Navigator.Artifact
{
    public class Dao : CrystalNavigator.Artifact.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override BinAff.Core.Data CreateDataObject(long id, CrystalNavigator.Artifact.Category category)
        {
            throw new NotImplementedException();
        }
    }
}
