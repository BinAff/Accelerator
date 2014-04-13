using System;
using CrystalNavigator = Crystal.Navigator.Component;
using BinAff.Core;

namespace Crystal.Lodge.Component.RoomReservationReport.Navigator.Artifact
{
    public class Server : CrystalNavigator.Artifact.Server
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

        protected override ReturnObject<Boolean> DeleteAfter()
        {
            if ((this.Data as Data).ModuleData != null && (this.Data as Data).ModuleData.Id > 0)
            {
                ICrud crud = new RoomReservationReport.Server(new RoomReservationReport.Data
                {
                    Id = (this.Data as Data).ModuleData.Id
                });
                return crud.Delete();
            }

            return base.DeleteAfter();
        }
    }
}
