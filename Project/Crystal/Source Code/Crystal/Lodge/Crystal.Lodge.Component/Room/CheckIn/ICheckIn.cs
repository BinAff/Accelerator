using System;
using BinAff.Core;

namespace Crystal.Lodge.Component.Room.CheckIn
{
    public interface ICheckIn
    {
        ReturnObject<Boolean> ModifyCheckInStatus(Int64 statusId);
        ReturnObject<Boolean> UpdateInvoiceNumber(String invoiceNumber);
    }
}
