using System;

using BinAff.Core;

namespace AutoTourism.Lodge.Facade.CheckIn
{

    public interface ICheckIn
    {

        void CheckOut();
        //ReturnObject<Boolean> UpdateInvoiceNumber(String invoiceNumber);
        ReturnObject<Boolean> PaymentInsert(Vanilla.Invoice.Facade.FormDto invoiceFormDto, Table currentUser, Vanilla.Utility.Facade.Artifact.Dto artifactDto);
        Vanilla.Invoice.Facade.Dto ReadInvoice(String invoiceNumber);

    }

}
