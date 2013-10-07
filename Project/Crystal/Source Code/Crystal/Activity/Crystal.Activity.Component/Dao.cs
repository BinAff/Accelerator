using System.Data;

namespace Crystal.Activity.Component
{

    public abstract class Dao : Crystal.Customer.Component.Action.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@ActivityDate", DbType.DateTime, ((Data)this.Data).ActivityDate);
        }

    }

}
