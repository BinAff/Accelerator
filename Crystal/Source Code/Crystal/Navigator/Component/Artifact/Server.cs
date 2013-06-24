using System.Collections.Generic;

using BinAff.Core;

using GaurdianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public class Server : BinAff.Core.Observer.SubjectCrud
    {

        public Server(Data data)
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            this.Name = "Artifact";
            this.Validator = new Validator((Data)this.Data);
            this.DataAccess = new Dao((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override void CreateChildren()
        {

            base.AddChild(new GaurdianAcc.Server(((Data)Data).CreatedBy)
            {
                Type = ChildType.Independent,
            });
            base.AddChild(new GaurdianAcc.Server(((Data)Data).ModifiedBy)
            {
                Type = ChildType.Independent,
            });

        }

        protected override ReturnObject<List<BinAff.Core.Data>> ReadAll()
        {
            return new ReturnObject<List<BinAff.Core.Data>>
            {
                Value = ((Dao)this.DataAccess).ReadAll()
            };
        }


        protected override Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }
    }

}
