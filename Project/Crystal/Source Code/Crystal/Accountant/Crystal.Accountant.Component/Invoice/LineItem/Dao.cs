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
            base.CreateStoredProcedure = "Invoice.LineItemInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Invoice.LineItemRead";
            base.ReadForParentStoredProcedure = "Invoice.LineItemReadForParent";
            base.ReadAllStoredProcedure = "Invoice.LineItemReadAll";
            base.UpdateStoredProcedure = "Invoice.LineItemUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Invoice.LineItemDelete";
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
        
        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.Start = Convert.IsDBNull(row["Start"]) ? DateTime.MinValue : Convert.ToDateTime(row["Start"]);
                dt.End = Convert.IsDBNull(row["End"]) ? DateTime.MinValue : Convert.ToDateTime(row["End"]);
                dt.Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]);
                dt.UnitRate = Convert.IsDBNull(row["UnitRate"]) ? 0 : Convert.ToDouble(row["UnitRate"]);
                dt.Count = Convert.IsDBNull(row["Count"]) ? 0 : Convert.ToInt32(row["Count"]);
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
                        Start = Convert.IsDBNull(row["Start"]) ? DateTime.MinValue : Convert.ToDateTime(row["Start"]),
                        End = Convert.IsDBNull(row["End"]) ? DateTime.MinValue : Convert.ToDateTime(row["End"]),
                        Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]),
                        UnitRate = Convert.IsDBNull(row["UnitRate"]) ? 0 : Convert.ToDouble(row["UnitRate"]),
                        Count = Convert.IsDBNull(row["Count"]) ? 0 : Convert.ToInt32(row["Count"]),
                    });
                }
            }
            return ret;
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

            foreach (Taxation.Data taxationData in data.TaxList)
            {
                this.CreateCommand("Invoice.LineItemTaxationInsert");
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
            this.CreateCommand("Invoice.LineItemTaxationRead");
            this.AddInParameter("@LineItemId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            (this.Data as Data).TaxList = new List<BinAff.Core.Data>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Taxation.Data data = new Taxation.Data
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

            foreach (Taxation.Data taxationData in data.TaxList)
            {
                this.CreateCommand("Invoice.LineItemTaxationDelete");
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
