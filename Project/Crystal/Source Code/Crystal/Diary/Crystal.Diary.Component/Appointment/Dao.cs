using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Diary.Component.Appointment
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Utility.AppointmentInsert";
            base.NumberOfRowsAffectedInCreate = -1;
            base.ReadStoredProcedure = "Utility.AppointmentRead";
            base.ReadAllStoredProcedure = "Utility.AppointmentReadAll";
            base.UpdateStoredProcedure = "Utility.AppointmentUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Utility.AppointmentDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            Data data = this.Data as Data;
            base.AddInParameter("@ActorId", DbType.Int64, data.Actor.Id);
            base.AddInParameter("@Title", DbType.String, data.Title);
            base.AddInParameter("@TypeId", DbType.Int64, data.Type.Id);
            base.AddInParameter("@Start", DbType.DateTime, data.Start);
            base.AddInParameter("@End", DbType.DateTime, data.End);
            base.AddInParameter("@Location", DbType.String, data.Location);
            base.AddInParameter("@Description", DbType.String, data.Description);
            if (data.Importance != null)
            {
                base.AddInParameter("@ImportanceId", DbType.Int64, data.Importance.Id);
            }
            base.AddInParameter("@Reminder", DbType.DateTime, data.Reminder);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                dt.Id = data.Id;
                if(!Convert.IsDBNull(row["ActorId"]))
                {
                    dt.Actor = new BinAff.Core.Data
                    {
                        Id = Convert.ToInt64(row["ActorId"]),
                    };
                }
                dt.Title = Convert.IsDBNull(row["Title"]) ? String.Empty : Convert.ToString(row["Title"]);
                dt.Type = new Type.Data
                {
                    Id = Convert.IsDBNull(row["TypeId"]) ? 0 : Convert.ToInt64(row["TypeId"])
                };
                dt.Start = Convert.IsDBNull(row["Start"]) ? DateTime.MinValue : Convert.ToDateTime(row["Start"]);
                dt.End = Convert.IsDBNull(row["End"]) ? DateTime.MinValue : Convert.ToDateTime(row["End"]);
                dt.Location = Convert.IsDBNull(row["Location"]) ? String.Empty : Convert.ToString(row["Location"]);
                dt.Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]);
                if (!Convert.IsDBNull(row["ImportanceId"]))
                {
                    dt.Importance = new Importance.Data
                    {
                        Id = Convert.ToInt64(row["ImportanceId"]),
                    };
                }
                if (!Convert.IsDBNull(row["Title"]))
                {
                    dt.Reminder = Convert.ToDateTime(row["Reminder"]);
                }
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
                    Data dt = new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Title = Convert.IsDBNull(row["Title"]) ? String.Empty : Convert.ToString(row["Title"]),
                        Type = new Type.Data
                        {
                            Id = Convert.IsDBNull(row["TypeId"]) ? 0 : Convert.ToInt64(row["TypeId"])
                        },
                        Start = Convert.IsDBNull(row["Start"]) ? DateTime.MinValue : Convert.ToDateTime(row["Start"]),
                        End = Convert.IsDBNull(row["End"]) ? DateTime.MinValue : Convert.ToDateTime(row["End"]),
                        Location = Convert.IsDBNull(row["Location"]) ? String.Empty : Convert.ToString(row["Location"]),
                        Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]),
                    };
                    if (!Convert.IsDBNull(row["ActorId"]))
                    {
                        dt.Actor = new BinAff.Core.Data
                        {
                            Id = Convert.ToInt64(row["ActorId"]),
                        };
                    }
                    if (!Convert.IsDBNull(row["ImportanceId"]))
                    {
                        dt.Importance = new Importance.Data
                        {
                            Id = Convert.ToInt64(row["ImportanceId"]),
                        };
                    }
                    if (!Convert.IsDBNull(row["Reminder"]))
                    {
                        dt.Reminder = Convert.ToDateTime(row["Reminder"]);
                    }
                    ret.Add(dt);
                }
            }
            return ret;
        }

        internal List<BinAff.Core.Data> Search(System.DateTime start, System.DateTime end)
        {
            this.CreateConnection();
            this.CreateCommand("Utility.AppointmentSearch");
            base.AddInParameter("@Start", DbType.DateTime, start);
            base.AddInParameter("@End", DbType.DateTime, end);

            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> dataList = CreateDataObjectList(ds);
            this.CloseConnection();

            return dataList;
        }

        internal List<BinAff.Core.Data> Search(System.DateTime start, System.DateTime end, Importance.Data importance)
        {
            this.CreateConnection();
            this.CreateCommand("");

            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> dataList = CreateDataObjectList(ds);
            this.CloseConnection();

            return dataList;
        }

    }

}
