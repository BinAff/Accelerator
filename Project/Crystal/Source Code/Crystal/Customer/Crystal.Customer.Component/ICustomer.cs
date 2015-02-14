using System;

using BinAff.Core;

namespace Crystal.Customer.Component
{

    public interface ICustomer
    {

        ReturnObject<Boolean> GenerateInvoice();
        ReturnObject<Boolean> SaveAction();
        ReturnObject<Boolean> DeleteAction();

    }

}
