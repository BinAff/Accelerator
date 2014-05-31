using System;
using BinAff.Core;

namespace Vanilla.Invoice.Facade.Receipt
{
    public class Server
    {
        public Dto GetInvoice(String invoiceNumber)
        {
            Facade.IInvoice invoiceServer = new Facade.Server(new Facade.FormDto());
            Facade.Dto invoiceDto = invoiceServer.GetInvoice(invoiceNumber);

            return this.ConvertToReceiptDto(invoiceDto);            
        }

        private Dto ConvertToReceiptDto(Facade.Dto invoiceDto)
        {
            return new Dto 
            { 
                Date = invoiceDto.date,
                InvoiceNumber = invoiceDto.invoiceNumber,
                Advance = invoiceDto.advance,
                Discount = invoiceDto.discount,
                Buyer = invoiceDto.buyer,
                Seller= invoiceDto.seller,
                ProductList = invoiceDto.productList
            };
        }

      
    }
}
