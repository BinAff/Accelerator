using System.Data;

namespace Crystal.Customer.Component.Characteristic
{

    public abstract class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected abstract override void Compose();

        protected abstract override void AssignParameter(string procedureName);

        protected abstract override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data);

    }

}
