using System.Data;
using BinAff.Core;
using System;

namespace Crystal.Reservation.Component
{

    public abstract class Dao : Customer.Component.Action.Dao
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

        //public abstract ReturnObject<Boolean> ModifyReservationStatus();
    }

}
