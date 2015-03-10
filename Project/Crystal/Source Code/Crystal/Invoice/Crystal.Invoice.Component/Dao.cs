using System;
using System.Data;
using System.Collections.Generic;

namespace Crystal.Invoice.Component
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Invoice.Insert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Invoice.Read";
            base.ReadAllStoredProcedure = "Invoice.ReadAll";
            base.UpdateStoredProcedure = "Invoice.Update";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Invoice.Delete";
            base.NumberOfRowsAffectedInDelete = -1;
        }
        
        protected override void AssignParameter(String procedureName)
        {
            Data data = this.Data as Data;
            base.AddInParameter("@Date", DbType.DateTime, data.Date);
            base.AddInParameter("@Advance", DbType.Double, data.Advance);
            base.AddInParameter("@Discount", DbType.Double, data.Discount);

            base.AddInParameter("@SellerName", DbType.String, data.Seller.Name);
            base.AddInParameter("@SellerAddress", DbType.String, data.Seller.Address);
            base.AddInParameter("@SellerLicence", DbType.String, data.Seller.Liscence);
            base.AddInParameter("@SellerEmail", DbType.String, data.Seller.Email == null ? String.Empty : data.Seller.Email);
            base.AddInParameter("@SellerContactNo", DbType.String, data.Seller.ContactNumber);


            base.AddInParameter("@BuyerName", DbType.String, data.Buyer.Name);
            base.AddInParameter("@BuyerAddress", DbType.String, data.Buyer.Address == null ? String.Empty : data.Buyer.Address);
            base.AddInParameter("@BuyerEmail", DbType.String, data.Buyer.ContactNumber == null ? String.Empty : data.Buyer.ContactNumber);
            base.AddInParameter("@BuyerContactNo", DbType.String, data.Buyer.ContactNumber == null ? String.Empty : data.Buyer.ContactNumber);            
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = data.Id;
            dt.Date = Convert.IsDBNull(dr["Date"]) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
            dt.SerialNumber = Convert.IsDBNull(dr["SerialNumber"]) ? 0 : Convert.ToInt32(dr["SerialNumber"]);
            dt.Advance = Convert.IsDBNull(dr["Advance"]) ? 0 : Convert.ToDouble(dr["Advance"]);
            dt.Discount = Convert.IsDBNull(dr["Discount"]) ? 0 : Convert.ToDouble(dr["Discount"]);

            dt.Seller = new Seller
            {
                Name = Convert.IsDBNull(dr["SellerName"]) ? String.Empty : Convert.ToString(dr["SellerName"]),
                Address = Convert.IsDBNull(dr["SellerAddress"]) ? String.Empty : Convert.ToString(dr["SellerAddress"]),
                Liscence = Convert.IsDBNull(dr["SellerLicence"]) ? String.Empty : Convert.ToString(dr["SellerLicence"]),
                Email = Convert.IsDBNull(dr["SellerEmail"]) ? String.Empty : Convert.ToString(dr["SellerEmail"]),
                ContactNumber = Convert.IsDBNull(dr["SellerContactNo"]) ? String.Empty : Convert.ToString(dr["SellerContactNo"]),
            };

            dt.Buyer = new Buyer
            {
                Name = Convert.IsDBNull(dr["BuyerName"]) ? String.Empty : Convert.ToString(dr["BuyerName"]),
                Address = Convert.IsDBNull(dr["BuyerAddress"]) ? String.Empty : Convert.ToString(dr["BuyerAddress"]),
                Email = Convert.IsDBNull(dr["BuyerEmail"]) ? String.Empty : Convert.ToString(dr["BuyerEmail"]),
                ContactNumber = Convert.IsDBNull(dr["BuyerContactNo"]) ? String.Empty : Convert.ToString(dr["BuyerContactNo"]),
            };

            return dt;
        }

        internal Boolean ReadDuplicate()
        {
            Data data = (Data)this.Data;
            this.CreateConnection();
            this.CreateCommand("Invoice.ReadDuplicate");
            this.AddInParameter("@SerialNumber", DbType.Int32, data.SerialNumber);

            DataSet ds = this.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(dr["Id"]) && Convert.ToInt64(dr["Id"]) != this.Data.Id) return true;
                }
            }

            return false;
        }

        internal List<BinAff.Core.Data> GetSalesData(DateTime startDate, DateTime endDate)
        {
            base.CreateConnection();

            this.CreateCommand("ReportSales");
            this.AddInParameter("@StartDate", DbType.DateTime, startDate);
            this.AddInParameter("@EndDate", DbType.DateTime, endDate);
            DataSet dsSales = this.ExecuteDataSet();
            List<BinAff.Core.Data> dataList = CreateDataObjectList(dsSales);

            base.CloseConnection();

            return dataList;
        }

        //protected override bool CreateAfter()
        //{
        //    Boolean retVal = false;
        //    retVal = this.InsertInvoiceTaxation();
        //    if (retVal) retVal = this.InsertInvoicePayment();
           
        //    return retVal;
        //}

        //protected override bool ReadAfter()
        //{
        //    this.ReadInvoiceTaxation();
        //    this.ReadInvoicePayment();

        //    return true;
        //}

        //protected override bool DeleteBefore()
        //{
        //    Boolean retVal = false;
        //    retVal = this.DeleteInvoiceTaxationLink();
        //    if (retVal) retVal = this.DeleteInvoicePaymentLink();

        //    return retVal;
        //}

        //private Boolean InsertInvoiceTaxation()
        //{
        //    Data data = this.Data as Data;
        //    Boolean retVal = true;
        //    Int64 InvoiceTaxationId = 0;            

        //    foreach (Invoice.Component.Taxation.Data taxationData in data.Taxation)
        //    {
        //        this.CreateCommand("[Invoice].[InvoiceTaxationInsert]");
        //        this.AddInParameter("@InvoiceId", DbType.Int64, data.Id);
        //        this.AddInParameter("@TaxName", DbType.String, taxationData.Name);
        //        this.AddInParameter("@TaxAmount", DbType.Currency, taxationData.Amount);
        //        this.AddInParameter("@IsPercentage", DbType.Boolean, taxationData.isPercentage);
        //        this.AddInParameter("@Id", DbType.Int64, InvoiceTaxationId);

        //        Int32 ret = this.ExecuteNonQuery();

        //        if (ret == -2146232060)               
        //            return false;//Foreign key violation  
        //        else
        //            retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //    }

        //    return retVal;
        //}

        //private Boolean InsertInvoicePayment()
        //{
        //    Data data = this.Data as Data;
        //    Boolean retVal = true;
        //    Int64 InvoicePaymentId = 0;   

        //    foreach (Invoice.Component.Payment.Data paymentData in data.Payment)
        //    {
        //        this.CreateCommand("[Invoice].[PaymentInsert]");
        //        this.AddInParameter("@InvoiceId", DbType.Int64, data.Id);
        //        this.AddInParameter("@PaymentTypeId", DbType.Int64, paymentData.Type.Id);
        //        this.AddInParameter("@CardNumber", DbType.String, paymentData.CardNumber);
        //        this.AddInParameter("@Remark", DbType.String, paymentData.Remark);
        //        this.AddInParameter("@Amount", DbType.Currency, paymentData.Amount);
        //        this.AddInParameter("@Id", DbType.Int64, InvoicePaymentId);

        //        Int32 ret = this.ExecuteNonQuery();

        //        if (ret == -2146232060)
        //            return false;//Foreign key violation  
        //        else
        //            retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //    }

        //    return retVal;
        //}

        //private void ReadInvoiceTaxation()
        //{
        //    this.CreateCommand("[Invoice].[InvoiceTaxationRead]");
        //    this.AddInParameter("@InvoiceId", DbType.Int64, this.Data.Id);

        //    DataSet ds = this.ExecuteDataSet();
        //    (this.Data as Data).Taxation = new List<BinAff.Core.Data>();
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {                
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            Invoice.Component.Taxation.Data data = new Taxation.Data {
        //                Id = Convert.IsDBNull(row["InvoiceId"]) ? 0 : Convert.ToInt64(row["InvoiceId"]),
        //                Name = Convert.IsDBNull(row["TaxName"]) ? String.Empty : Convert.ToString(row["TaxName"]),
        //                Amount = Convert.IsDBNull(row["TaxAmount"]) ? 0 : Convert.ToDouble(row["TaxAmount"]),
        //                isPercentage = Convert.IsDBNull(row["IsPercentage"]) ? true : Convert.ToBoolean(row["IsPercentage"])
        //            };

        //            (this.Data as Data).Taxation.Add(data);
        //        }
        //    }
        //}         

        //private void ReadInvoicePayment()
        //{
        //    this.CreateCommand("[Invoice].[InvoicePaymentRead]");
        //    this.AddInParameter("@InvoiceId", DbType.Int64, this.Data.Id);

        //    DataSet ds = this.ExecuteDataSet();
        //    (this.Data as Data).Payment = new List<BinAff.Core.Data>();
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            Invoice.Component.Payment.Data data = new Payment.Data
        //            {
        //                Id = Convert.IsDBNull(row["InvoiceId"]) ? 0 : Convert.ToInt64(row["InvoiceId"]),
        //                Type = new Payment.Type.Data
        //                {
        //                    Id = Convert.IsDBNull(row["PaymentTypeId"]) ? 0 : Convert.ToInt64(row["PaymentTypeId"])
        //                },
        //                CardNumber = Convert.IsDBNull(row["CardNumber"]) ? String.Empty : Convert.ToString(row["CardNumber"]),
        //                Remark =  Convert.IsDBNull(row["Remark"]) ? String.Empty : Convert.ToString(row["Remark"]),
        //                Amount =  Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDouble(row["Amount"]),
        //                Date =  Convert.IsDBNull(row["Amount"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"])
        //            };

        //            (this.Data as Data).Payment.Add(data);
        //        }
        //    }
        //}

        //private Boolean DeleteInvoiceTaxationLink()
        //{
        //    Data data = this.Data as Data;
        //    Boolean retVal = true;
          
        //    this.CreateCommand("[Invoice].[InvoiceTaxationLinkDelete]");
        //    this.AddInParameter("@Id", DbType.Int64, data.Id);

        //    Int32 ret = this.ExecuteNonQuery();

        //    if (ret == -2146232060)
        //        return false;//Foreign key violation  
        //    else
        //        retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //    return retVal;
        //}

        //private Boolean DeleteInvoicePaymentLink()
        //{
        //    Data data = this.Data as Data;
        //    Boolean retVal = true;

        //    this.CreateCommand("[Invoice].[InvoicePaymentLinkDelete]");
        //    this.AddInParameter("@Id", DbType.Int64, data.Id);

        //    Int32 ret = this.ExecuteNonQuery();

        //    if (ret == -2146232060)
        //        return false;//Foreign key violation  
        //    else
        //        retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
        //    return retVal;
        //}

        internal Int64 ReadInvoiceId()
        {
            Data data = this.Data as Data;
            this.CreateCommand("Invoice.InvoiceReadForSerialNumber");
            this.AddInParameter("@SerialNumber", DbType.Int32, data.SerialNumber);
            this.AddInParameter("@Date", DbType.Date, data.Date);
            DataSet ds = this.ExecuteDataSet();
            
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                this.Data.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);

            return this.Data.Id;
        }

    }

}