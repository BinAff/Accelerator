using System;

namespace BinAff.Utility
{
    public static class Common
    {
        public static String GenerateInvoiceNumber()
        {
            String invoiceNo = "INVO-";
            invoiceNo += DateTime.Now.ToShortDateString().Replace("/", "");
            invoiceNo += DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            return invoiceNo;
        }
    }
}
