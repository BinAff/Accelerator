using System;
using BinAff.Core;

namespace Crystal.Lodge.Component.Room.CheckIn
{
    public interface ICheckIn
    {
        ReturnObject<Boolean> ModifyCheckInStatus(Crystal.Customer.Component.Action.Status.Data status);
        ReturnObject<Boolean> UpdateInvoiceNumber(String invoiceNumber);
    }
}
