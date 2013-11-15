using CrystalNavigatorForm = Crystal.Navigator.Component.Form;

namespace Crystal.Customer.Component.Navigator.Form
{

    public abstract class Dao : CrystalNavigatorForm.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }
        
        protected abstract override BinAff.Core.Data InstantiateModuleDataObject();

    }

}
