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
            base.CreateStoredProcedure = "[Invoice].[Insert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Invoice].[Read]";
            base.ReadAllStoredProcedure = "[Invoice].[ReadAll]";
            base.UpdateStoredProcedure = "[Invoice].[Update]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Invoice].[Delete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }
                
        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@InvoiceNumber", DbType.String, ((Data)this.Data).InvoiceNumber);
            base.AddInParameter("@Advance", DbType.Double, ((Data)this.Data).Advance);
            base.AddInParameter("@Discount", DbType.Double, ((Data)this.Data).Discount);

            base.AddInParameter("@SellerName", DbType.String, ((Data)this.Data).Seller.Name);
            base.AddInParameter("@SellerAddress", DbType.String, ((Data)this.Data).Seller.Address);
            base.AddInParameter("@SellerLicence", DbType.String, ((Data)this.Data).Seller.Liscence);
            base.AddInParameter("@SellerEmail", DbType.String, ((Data)this.Data).Seller.Email == null ? String.Empty : ((Data)this.Data).Seller.Email);
            base.AddInParameter("@SellerContactNo", DbType.String, ((Data)this.Data).Seller.ContactNumber);


            base.AddInParameter("@BuyerName", DbType.String, ((Data)this.Data).Buyer.Name);
            base.AddInParameter("@BuyerAddress", DbType.String, ((Data)this.Data).Buyer.Address == null ? String.Empty : ((Data)this.Data).Buyer.Address);
            base.AddInParameter("@BuyerEmail", DbType.String, ((Data)this.Data).Buyer.ContactNumber == null ? String.Empty : ((Data)this.Data).Buyer.ContactNumber);
            base.AddInParameter("@BuyerContactNo", DbType.String, ((Data)this.Data).Buyer.ContactNumber == null ? String.Empty : ((Data)this.Data).Buyer.ContactNumber);            
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.InvoiceNumber = Convert.IsDBNull(row["InvoiceNumber"]) ? String.Empty : Convert.ToString(row["InvoiceNumber"]);
                dt.Advance = Convert.IsDBNull(row["Advance"]) ? 0 : Convert.ToDouble(row["Advance"]);
                dt.Discount = Convert.IsDBNull(row["Discount"]) ? 0 : Convert.ToDouble(row["Discount"]);

                dt.Seller = new Seller()
                {
                    Name = Convert.IsDBNull(row["SellerName"]) ? String.Empty : Convert.ToString(row["SellerName"]),
                    Address = Convert.IsDBNull(row["SellerAddress"]) ? String.Empty : Convert.ToString(row["SellerAddress"]),
                    Liscence = Convert.IsDBNull(row["SellerLicence"]) ? String.Empty : Convert.ToString(row["SellerLicence"]),
                    Email = Convert.IsDBNull(row["SellerEmail"]) ? String.Empty : Convert.ToString(row["SellerEmail"]),
                    ContactNumber = Convert.IsDBNull(row["SellerContactNo"]) ? String.Empty : Convert.ToString(row["SellerContactNo"])
                };

               
                dt.Buyer = new Buyer(){
                    Name = Convert.IsDBNull(row["BuyerName"]) ? String.Empty : Convert.ToString(row["BuyerName"]),
                    Address = Convert.IsDBNull(row["BuyerAddress"]) ? String.Empty : Convert.ToString(row["BuyerAddress"]),
                    Email = Convert.IsDBNull(row["BuyerEmail"]) ? String.Empty : Convert.ToString(row["BuyerEmail"]),
                    ContactNumber = Convert.IsDBNull(row["BuyerContactNo"]) ? String.Empty : Convert.ToString(row["BuyerContactNo"])
                };
                
            }

            return dt;
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ret.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        InvoiceNumber = Convert.IsDBNull(row["InvoiceNumber"]) ? String.Empty : Convert.ToString(row["InvoiceNumber"]),
                        Advance = Convert.IsDBNull(row["Advance"]) ? 0 : Convert.ToDouble(row["Advance"]),
                        Discount = Convert.IsDBNull(row["Discount"]) ? 0 : Convert.ToDouble(row["Discount"]),

                        Seller = new Seller()
                        {
                            Name = Convert.IsDBNull(row["SellerName"]) ? String.Empty : Convert.ToString(row["SellerName"]),
                            Address = Convert.IsDBNull(row["SellerAddress"]) ? String.Empty : Convert.ToString(row["SellerAddress"]),
                            Liscence = Convert.IsDBNull(row["SellerLicence"]) ? String.Empty : Convert.ToString(row["SellerLicence"]),
                            Email = Convert.IsDBNull(row["SellerEmail"]) ? String.Empty : Convert.ToString(row["SellerEmail"]),
                            ContactNumber = Convert.IsDBNull(row["SellerContactNo"]) ? String.Empty : Convert.ToString(row["SellerContactNo"]),
                        },

                        Buyer = new Buyer() {
                            Name = Convert.IsDBNull(row["BuyerName"]) ? String.Empty : Convert.ToString(row["BuyerName"]),
                            Address = Convert.IsDBNull(row["BuyerAddress"]) ? String.Empty : Convert.ToString(row["BuyerAddress"]),
                            Email = Convert.IsDBNull(row["BuyerEmail"]) ? String.Empty : Convert.ToString(row["BuyerEmail"]),
                            ContactNumber = Convert.IsDBNull(row["BuyerContactNo"]) ? String.Empty : Convert.ToString(row["BuyerContactNo"]),
                        }
                    });
                }
            }
            return ret;
        }

        internal Boolean ReadDuplicate()
        {
            Data data = (Data)this.Data;
            this.CreateConnection();
            this.CreateCommand("[Invoice].[ReadDuplicate]");
            this.AddInParameter("@InvoiceNumber", DbType.String, data.InvoiceNumber);

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

        public List<BinAff.Core.Data> GetSalesData(DateTime startDate, DateTime endDate)
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

        protected override bool CreateAfter()
        {
            Boolean retVal = false;
            retVal = this.InsertInvoiceTaxationLink();
            if (retVal) retVal = this.InsertInvoicePaymentLink();
           
            return retVal;
        }

        protected override bool ReadAfter()
        {
            this.ReadInvoiceTaxationLink();
            this.ReadInvoicePaymentLink();

            return true;
        }

        protected override bool DeleteBefore()
        {
            Boolean retVal = false;
            retVal = this.DeleteInvoiceTaxationLink();
            if (retVal) retVal = this.DeleteInvoicePaymentLink();

            return retVal;
        }

        private Boolean InsertInvoiceTaxationLink()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;
            Int64 InvoiceTaxationId = 0;            

            foreach (Invoice.Component.Taxation.Data taxationData in data.Taxation)
            {
                this.CreateCommand("[Invoice].[InvoiceTaxationLinkInsert]");
                this.AddInParameter("@InvoiceId", DbType.Int64, data.Id);
                this.AddInParameter("@TaxationId", DbType.Int64, taxationData.Id);
                this.AddInParameter("@Id", DbType.Int64, InvoiceTaxationId);

                Int32 ret = this.ExecuteNonQuery();

                if (ret == -2146232060)               
                    return false;//Foreign key violation  
                else
                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
            }

            return retVal;
        }

        private Boolean InsertInvoicePaymentLink()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;
            Int64 InvoicePaymentId = 0;   

            foreach (Invoice.Component.Payment.Data paymentData in data.Payment)
            {
                this.CreateCommand("[Invoice].[InvoicePaymentLinkInsert]");
                this.AddInParameter("@InvoiceId", DbType.Int64, data.Id);
                this.AddInParameter("@PaymentId", DbType.Int64, paymentData.Id);
                this.AddInParameter("@Id", DbType.Int64, InvoicePaymentId);

                Int32 ret = this.ExecuteNonQuery();

                if (ret == -2146232060)
                    return false;//Foreign key violation  
                else
                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
            }

            return retVal;
        }

        private void ReadInvoiceTaxationLink()
        {
            this.CreateCommand("[Invoice].[InvoiceTaxationLinkRead]");
            this.AddInParameter("@InvoiceId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            (this.Data as Data).Taxation = new List<BinAff.Core.Data>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {                
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Invoice.Component.Taxation.Data data = new Taxation.Data {
                        Id = Convert.IsDBNull(row["TaxationId"]) ? 0 : Convert.ToInt64(row["TaxationId"]),
                    };

                    (this.Data as Data).Taxation.Add(data);
                }
            }
        }

        private void ReadInvoicePaymentLink()
        {
            this.CreateCommand("[Invoice].[InvoicePaymentLinkRead]");
            this.AddInParameter("@InvoiceId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            (this.Data as Data).Payment = new List<BinAff.Core.Data>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Invoice.Component.Payment.Data data = new Payment.Data
                    {
                        Id = Convert.IsDBNull(row["PaymentId"]) ? 0 : Convert.ToInt64(row["PaymentId"]),
                    };

                    (this.Data as Data).Payment.Add(data);
                }
            }
        }

        private Boolean DeleteInvoiceTaxationLink()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;
          
            this.CreateCommand("[Invoice].[InvoiceTaxationLinkDelete]");
            this.AddInParameter("@Id", DbType.Int64, data.Id);

            Int32 ret = this.ExecuteNonQuery();

            if (ret == -2146232060)
                return false;//Foreign key violation  
            else
                retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
            return retVal;
        }

        private Boolean DeleteInvoicePaymentLink()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;

            this.CreateCommand("[Invoice].[InvoicePaymentLinkDelete]");
            this.AddInParameter("@Id", DbType.Int64, data.Id);

            Int32 ret = this.ExecuteNonQuery();

            if (ret == -2146232060)
                return false;//Foreign key violation  
            else
                retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
            return retVal;
        }

    }

}
