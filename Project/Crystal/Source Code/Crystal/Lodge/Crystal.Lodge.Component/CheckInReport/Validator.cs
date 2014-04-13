using System.Collections.Generic;
using BinAff.Core;

namespace Crystal.Lodge.Component.CheckInReport
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
