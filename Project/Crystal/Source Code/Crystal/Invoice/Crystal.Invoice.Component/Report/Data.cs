using System;

namespace Crystal.Invoice.Component.Report
{

    public class Data : Crystal.Report.Component.Data
    {

        public String InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Double AmountPaid { get; set; }
        public Double Discount { get; set; }
        public Double Tax { get; set; }
        
        public String SellerName { get; set; }
        public String SellerAddress { get; set; }
        public String SellerContactNo { get; set; }
        public String SellerEmail { get; set; }
        public String SellerLicence { get; set; }

        public String BuyerName { get; set; }
        public String BuyerAddress { get; set; }
        public String BuyerContactNo { get; set; }

    }

}
