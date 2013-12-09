using System;
using System.Data;
using System.Collections.Generic;

namespace Crystal.Guardian.Component.Account.SecurityAnswer
{

    public class Dao : BinAff.Core.Dao
    {
        
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Guardian.SecurityAnswerInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Guardian.SecurityAnswerRead";
            base.ReadForParentStoredProcedure = "Guardian.SecurityAnswerReadForParent";
            base.UpdateStoredProcedure = "Guardian.SecurityAnswerUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Guardian.SecurityAnswerDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@UserId", DbType.Int64, this.ParentData.Id);
            base.AddInParameter("@QuestionId", DbType.Int64, ((Data)this.Data).Question.Id);      
            base.AddInParameter("@Answer", DbType.String, ((Data)this.Data).Answer);             
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            System.Data.DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = Convert.IsDBNull(ds.Tables[0].Rows[0]["Id"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);
                if (!Convert.IsDBNull(row["QuestionId"]))
                {
                    dt.Question = new SecurityQuestion.Data()
                    {
                        Id = Convert.ToInt64(row["QuestionId"]),
                    };
                }
                dt.Answer = Convert.IsDBNull(row["Answer"]) ? String.Empty : Convert.ToString(row["Answer"]);
            }
            this.Data = dt;
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
                            Question = new SecurityQuestion.Data()
                            {
                                Id = Convert.IsDBNull(row["QuestionId"]) ? 0 : Convert.ToInt64(row["QuestionId"]),
                            },
                            Answer = Convert.IsDBNull(row["Answer"]) ? String.Empty : Convert.ToString(row["Answer"])
                        });
                }
            }
            return ret;
        }
        
        public override BinAff.Core.Data ReadForParent()
        {
            return base.ReadForParent();
            ////This is the special case. Here Profile is weak entity. So this function
            ////is overriden.
            //if (this.ReadForParentStoredProcedure == null) throw new Exception("Read for parent stored procedure not specified");
            //this.CreateConnection();
            //this.CreateCommand(this.ReadForParentStoredProcedure);
            //this.AddInParameter("Id", DbType.Int64, this.ParentData.Id);

            //DataSet ds = this.ExecuteDataSet();
            //this.Data = CreateDataObject(ds, this.Data);
            //this.CloseConnection();
            //this.Data.Id = this.ParentData.Id;
            //this.AttachChildDataToParent();
            //return this.Data;
        }

        protected override void AttachChildDataToParent()
        {
            ((Account.Data)this.ParentData).SecurityAnswerList = new List<BinAff.Core.Data> { (Data)this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                ((Account.Data)this.ParentData).SecurityAnswerList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    ((Account.Data)this.ParentData).SecurityAnswerList.Add((Data)data);
                }
            }

            
        }

        public BinAff.Core.Data GetLoggedInUserSecurityAnswer(String SPReadSecurityAnswer)
        {
            if (this.ReadStoredProcedure == null) throw new Exception("Read stored procedure not specified");
            this.CreateConnection();
            this.CreateCommand(SPReadSecurityAnswer);
            this.AddInParameter("@UserId", DbType.Int64, this.ParentData.Id);

            DataSet ds = this.ExecuteDataSet();
            if(ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                this.Data = CreateDataObject(ds, this.Data);

            this.CloseConnection();
            return this.Data;
        }

        public List<Data> IsSecurityQuestionDeletable(SecurityQuestion.Data securityQuestion)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("Guardian.SecurityAnswerIsSecurityQuestionDeletable");
            this.AddInParameter("@SecurityQuestionId", DbType.Int64, securityQuestion.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Answer = Convert.IsDBNull(row["Answer"]) ? String.Empty : Convert.ToString(row["Answer"]),
                        
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

    }

}
