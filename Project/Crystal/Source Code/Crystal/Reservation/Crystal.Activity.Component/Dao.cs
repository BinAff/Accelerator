using System;
using System.Collections.Generic;
using System.Data;
using BinAff.Core;

namespace Crystal.Activity.Component
{

    public abstract class Dao : Crystal.Customer.Component.Action.Dao
    {
        
        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            throw new NotImplementedException();
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@ActivityDate", DbType.DateTime, ((Data)this.Data).ActivityDate);            
        }

        public abstract override Crystal.Customer.Component.Action.Data CreateDataObjectInstance();

    }

}
