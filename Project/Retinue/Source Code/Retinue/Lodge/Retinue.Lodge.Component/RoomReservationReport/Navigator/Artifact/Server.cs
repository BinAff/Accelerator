using BinAff.Core;

namespace Retinue.Lodge.Component.RoomReservationReport.Navigator.Artifact
{
    public class Server : Crystal.Report.Component.Navigator.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "RoomReservation Report";
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
            return new RoomReservationReport.Server(moduleData as RoomReservationReport.Data);
        }

        protected override ICrud GetComponentServer()
        {
            return new RoomReservationReport.Server(new RoomReservationReport.Data
            {
                Id = (this.Data as Data).ComponentData.Id
            });
        }

    }

}
