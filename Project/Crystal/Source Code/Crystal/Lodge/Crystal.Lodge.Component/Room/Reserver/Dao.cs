using System;
using System.Collections.Generic;
using System.Data;
using BinAff.Core;

namespace Crystal.Lodge.Component.Room.Reserver
{

    public class Dao : Crystal.Reservation.Component.Reserver.Dao
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
            //base.AddInParameter("@ActivityDate", DbType.DateTime, ((Data)this.Data).ActivityDate);
            //base.AddInParameter("@StatusId", DbType.Int64, ((Data)this.Data).Status.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }
    }

}
