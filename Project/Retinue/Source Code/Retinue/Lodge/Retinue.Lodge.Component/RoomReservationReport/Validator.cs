using System.Collections.Generic;
using BinAff.Core;

namespace Retinue.Lodge.Component.RoomReservationReport
{
    public class Validator : Crystal.Report.Component.Validator
    {
        public Validator(Data data)
            : base(data)
        {

        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = (Data)base.Data;           

            return retMsg;
        }
    }
}
