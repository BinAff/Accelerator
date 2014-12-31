using System;
using BinAff.Core;
using System.Collections.Generic;

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
                Date = invoiceDto.Date,
                InvoiceNumber = invoiceDto.InvoiceNumber,
                Advance = invoiceDto.Advance,
                Discount = invoiceDto.Discount,
                Buyer = invoiceDto.Buyer,
                Seller= invoiceDto.Seller,
                ProductList = invoiceDto.ProductList
            };
        }

        public Double CalculateTaxAmount(List<Taxation.Dto> taxList, String taxName, Double total)
        {
            Double taxValue = 0;

            foreach (Taxation.Dto dto in taxList)
            {
                if (taxName == dto.Name)
                {
                    if (dto.isPercentage)
                        taxValue = total * (dto.Amount / 100);
                    else
                        taxValue = dto.Amount;

                    break;
                }
            }

            return taxValue;
        }
      
    }
}
