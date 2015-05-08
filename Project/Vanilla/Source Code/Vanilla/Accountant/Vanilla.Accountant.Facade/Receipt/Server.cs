using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Vanilla.Accountant.Facade.Receipt
{

    public class Server
    {

        public Dto GetInvoice(String invoiceNumber)
        {
            Invoice.IInvoice invoiceServer = new Invoice.Server(new Invoice.FormDto());
            //Facade.Dto invoiceDto = invoiceServer.GetInvoice(invoiceNumber);

            //return this.ConvertToReceiptDto(invoiceDto);
            return null;
        }

        private Dto ConvertToReceiptDto(Invoice.Dto invoiceDto)
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
                    if (dto.IsPercentage)
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