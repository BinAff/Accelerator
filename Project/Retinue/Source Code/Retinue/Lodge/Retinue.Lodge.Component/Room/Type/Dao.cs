using System;
using System.Data;

namespace Retinue.Lodge.Component.Room.Type
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Lodge.RoomTypeInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Lodge.RoomTypeRead";
            base.ReadAllStoredProcedure = "Lodge.RoomTypeReadAll";
            base.UpdateStoredProcedure = "Lodge.RoomTypeUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Lodge.RoomTypeDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@Name", DbType.String, (this.Data as Data).Name);
            base.AddInParameter("@Accomodation", DbType.Int16, (this.Data as Data).Accomodation);
            base.AddInParameter("@ExtraAccomodation", DbType.Int16, (this.Data as Data).ExtraAccomodation);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            if (dr != null)
            {
                dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
                dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);
                dt.Accomodation = Convert.IsDBNull(dr["Accomodation"]) ? (Int16)0 : Convert.ToInt16(dr["Accomodation"]);
                dt.ExtraAccomodation = Convert.IsDBNull(dr["ExtraAccomodation"]) ? (Int16)0 : Convert.ToInt16(dr["ExtraAccomodation"]);
            }
            return dt;
        }

    }

}
