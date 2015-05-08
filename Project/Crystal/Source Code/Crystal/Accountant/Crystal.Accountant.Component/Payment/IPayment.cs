using System;

using BinAff.Core;

namespace Crystal.Accountant.Component.Payment
{

    public interface IPayment
    {

        ReturnObject<Boolean> AttachInvoice();

    }

}