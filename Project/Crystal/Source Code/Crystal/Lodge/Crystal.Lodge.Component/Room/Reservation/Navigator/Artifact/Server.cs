using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact
{

    public class Server : ArtfComp.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Lodge Reservation " + (this.Data as Data).Category.ToString();
            (this.Data as Data).Extension = "frm";
            (this.Data as Data).IsAttachmentSupported = true;
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data
            {
                Category = (this.Data as Data).Category
            };
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData)
        {
            return new Room.Reservation.Server(moduleData as Room.Reservation.Data);
        }

    }

}
