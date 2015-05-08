using System.Collections.Generic;
using System;

namespace Vanilla.Accountant.Facade.Invoice
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {

        public String InvoiceNumber { get; set; }
        public Buyer.Dto Buyer { get; set; }
        public Seller.Dto Seller { get; set; }
        public DateTime Date { get; set; }
        public List<LineItem.Dto> ProductList { get; set; }
        public List<Payment.Dto> AdvancePaymentList { get; set; }

        private Double advance;
        public Double Advance
        {
            get
            {
                Double totalAmount = 0;
                if (this.AdvancePaymentList != null && this.AdvancePaymentList.Count > 0)
                {
                    foreach (Payment.Dto lineItem in this.AdvancePaymentList)
                    {
                        totalAmount += lineItem.TotalAmount;
                    }
                }
                else
                {
                    totalAmount = this.advance;
                }
                return totalAmount;
            }
            internal set
            {
                this.advance = value;
            }
        }

        public Double Discount { get; set; }

        public Double Total
        {
            get
            {
                Double lineItemTotal = 0;
                if (this.ProductList != null && this.ProductList.Count > 0)
                {
                    foreach (LineItem.Dto line in this.ProductList)
                    {
                        lineItemTotal += line.GrandTotal;
                    }
                }
                return lineItemTotal;
            }
        }

        public Double Outstanding
        {
            get
            {
                
                return this.Total - this.Advance - this.Discount;
            }
        }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Buyer != null) dto.Buyer = this.Buyer.Clone() as Buyer.Dto;
            if (this.Seller != null) dto.Seller = this.Seller.Clone() as Seller.Dto;
            if (this.ProductList != null)
            {
                dto.ProductList = new List<LineItem.Dto>();
                foreach (LineItem.Dto product in this.ProductList)
                {
                    dto.ProductList.Add((product != null) ? product.Clone() as LineItem.Dto : null);
                }
            }
            if (this.AdvancePaymentList != null)
            {
                dto.AdvancePaymentList = new List<Payment.Dto>();
                foreach (Payment.Dto payment in this.AdvancePaymentList)
                {
                    dto.AdvancePaymentList.Add((payment != null) ? payment.Clone() as Payment.Dto : null);
                }
            }
            return dto;
        }

    }

}