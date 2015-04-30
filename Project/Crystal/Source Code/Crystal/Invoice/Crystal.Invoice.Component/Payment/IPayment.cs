using System;

using BinAff.Core;

namespace Crystal.Invoice.Component.Payment
{

    public interface IPayment
    {

        ReturnObject<Boolean> AttachInvoice();

    }

}