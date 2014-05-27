using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Invoice.Component.Taxation.Slab
{

    public class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            : base(data)
        {

        }

        protected override List<Message> Validate()
        {
            //TO DO :: Need to write validation properly
            List<Message> retMsg = new List<Message>();
            Data data = (Data)base.Data;

            if (data.Limit <= 0)
                retMsg.Add(new Message("Slab limit cannot be 0 or negative.", Message.Type.Error));
            
            if (data.Amount <= 0 )
                retMsg.Add(new Message("Slab amount cannot be 0 or negative.", Message.Type.Error));
            
            if (this.IsExist(data))
                retMsg.Add(new Message("Same Taxation name already exists.", Message.Type.Error));

            return retMsg;
        }

        private Boolean IsExist(Data data)
        {
            return true;
            //return new Dao(data).ReadDuplicate();
        }

    }

}
