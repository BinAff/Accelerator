using System;
using System.Collections.Generic;

using GenTariff = Crystal.Tariff.Component;
using BinAff.Core;

namespace Retinue.Lodge.Component.Room.Tariff
{
    public class Validator : GenTariff.Validator
    {
        public Validator(Data data) : base(data) 
        {    
           
        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = base.Validate();

            if (this.IsExist((Data)this.Data))
                retMsg.Add(new Message("Same tariff already exists.", Message.Type.Error));

            return retMsg;
        }

        private Boolean IsExist(Data data)
        {
            return new Dao(data).ReadDuplicate();
       
        }
    }
}
