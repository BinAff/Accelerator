using BinAff.Core;

namespace Retinue.Lodge.Component.CheckInReport.Navigator.Artifact
{

    public class Server : Crystal.Report.Component.Navigator.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "CheckIn Report";
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
            return new CheckInReport.Server(moduleData as CheckInReport.Data);
        }

        protected override ICrud GetComponentServer()
        {
            return new CheckInReport.Server(new CheckInReport.Data
            {
                Id = (this.Data as Data).ComponentData.Id
            });
        }

    }

}
