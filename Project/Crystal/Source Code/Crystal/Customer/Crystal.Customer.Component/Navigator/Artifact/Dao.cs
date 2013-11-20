using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Customer.Component.Navigator.Artifact
{

    public abstract class Dao : CrystalNavigator.Artifact.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }
        
        //protected abstract override BinAff.Core.Data InstantiateModuleDataObject();

    }

}
