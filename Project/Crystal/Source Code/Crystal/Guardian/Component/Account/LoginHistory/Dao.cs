namespace Crystal.Guardian.Component.Account.LoginHistory
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "";
            base.NumberOfRowsAffectedInCreate = 1;
            base.UpdateStoredProcedure = "";
            base.NumberOfRowsAffectedInUpdate = 1;
        }

    }

}
