using System.Collections.Generic;
using System;

using BinAff.Core;

namespace Crystal.Customer.Component.Characteristic
{

    public abstract class Server : BinAff.Core.Crud
    {

        protected List<BinAff.Core.Data> allAction;

        public Server(Data data)
            : base(data)
        {

        }

        protected abstract override void Compose();

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);
        
        protected override ReturnObject<Boolean> DeleteBefore()
        {
            //If there is any action attached with characteristic, it cannot be deleted
            if ((this.Data as Data).AllList != null && (this.Data as Data).AllList.Count > 0)
                return new ReturnObject<Boolean>();
            return new ReturnObject<Boolean> { Value = true, };
        }

    }

}
