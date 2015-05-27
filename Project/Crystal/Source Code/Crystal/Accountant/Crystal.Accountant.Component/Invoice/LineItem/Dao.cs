using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Accountant.Component.Invoice.LineItem
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Accountant.InvoiceLineItemInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Accountant.InvoiceLineItemRead";
            base.ReadForParentStoredProcedure = "Accountant.InvoiceLineItemReadForParent";
            base.ReadAllStoredProcedure = "Accountant.InvoiceLineItemReadAll";
            base.UpdateStoredProcedure = "Accountant.InvoiceLineItemUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Accountant.InvoiceLineItemDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Start", DbType.DateTime, ((Data)this.Data).Start);
            base.AddInParameter("@End", DbType.DateTime, ((Data)this.Data).End);
            base.AddInParameter("@Description", DbType.String, ((Data)this.Data).Description);
            base.AddInParameter("@UnitRate", DbType.Double, ((Data)this.Data).UnitRate);
            base.AddInParameter("@Count", DbType.Int32, ((Data)this.Data).Count);
            base.AddInParameter("@InvoiceId", DbType.Int64, this.ParentData.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.Start = Convert.IsDBNull(dr["Start"]) ? DateTime.MinValue : Convert.ToDateTime(dr["Start"]);
            dt.End = Convert.IsDBNull(dr["End"]) ? DateTime.MinValue : Convert.ToDateTime(dr["End"]);
            dt.Description = Convert.IsDBNull(dr["Description"]) ? String.Empty : Convert.ToString(dr["Description"]);
            dt.UnitRate = Convert.IsDBNull(dr["UnitRate"]) ? 0 : Convert.ToDouble(dr["UnitRate"]);
            dt.Count = Convert.IsDBNull(dr["Count"]) ? 0 : Convert.ToInt32(dr["Count"]);
            return dt;
        }

        protected override void AttachChildDataToParent()
        {
            ((Invoice.Data)this.ParentData).LineItemList = new List<BinAff.Core.Data> { (Data)this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                ((Invoice.Data)this.ParentData).LineItemList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    ((Invoice.Data)this.ParentData).LineItemList.Add((Data)data);
                }
            }

        }

        protected override Boolean CreateAfter()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;
            Int64 LineItemTaxationId = 0;

            foreach (Tax.Data taxationData in data.TaxList)
            {
                this.CreateCommand("Accountant.InvoiceLineItemTaxInsert");
                this.AddInParameter("@LineItemId", DbType.Int64, data.Id);
                this.AddInParameter("@TaxName", DbType.String, taxationData.Name);
                this.AddInParameter("@TaxAmount", DbType.Currency, taxationData.Amount);
                this.AddInParameter("@IsPercentage", DbType.Boolean, taxationData.IsPercentage);
                this.AddOutParameter("@Id", DbType.Int64, LineItemTaxationId);

                Int32 ret = this.ExecuteNonQuery();

                if (ret == -2146232060)
                    return false; //Foreign key violation  
                else
                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
            }

            return retVal;
        }

        protected override Boolean ReadAfter()
        {
            this.CreateCommand("Accountant.InvoiceLineItemTaxRead");
            this.AddInParameter("@LineItemId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            (this.Data as Data).TaxList = new List<BinAff.Core.Data>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Tax.Data data = new Tax.Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Name = Convert.IsDBNull(row["TaxName"]) ? String.Empty : Convert.ToString(row["TaxName"]),
                        Amount = Convert.IsDBNull(row["TaxAmount"]) ? 0 : Convert.ToDouble(row["TaxAmount"]),
                        IsPercentage = Convert.IsDBNull(row["IsPercentage"]) ? true : Convert.ToBoolean(row["IsPercentage"])
                    };

                    (this.Data as Data).TaxList.Add(data);
                }
            }

            return true;
        }

        protected override Boolean DeleteBefore()
        {
            Data data = this.Data as Data;
            Boolean retVal = true;

            foreach (Tax.Data taxationData in data.TaxList)
            {
                this.CreateCommand("Accountant.InvoiceLineItemTaxDelete");
                this.AddInParameter("@Id", DbType.Int64, taxationData.Id);

                Int32 ret = this.ExecuteNonQuery();

                if (ret == -2146232060)
                {
                    return false;//Foreign key violation 
                }
                else
                {
                    retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;
                }
            }
            return retVal;
        }

    }

}
