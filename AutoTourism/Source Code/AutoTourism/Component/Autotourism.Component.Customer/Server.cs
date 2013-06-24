using Lodge = Crystal.Lodge.Component;

namespace Autotourism.Component.Customer
{

    public class Server : Crystal.Customer.Component.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Customer";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

        protected override void CreateChildren()
        {
            base.CreateChildren();
            
            base.AddChild(new Lodge.Room.Reservation.Server((this.Data as Data).RoomReserver.Active as Lodge.Room.Reservation.Data)
            {
                Type = ChildType.Independent,
            });

            base.AddChild(new Lodge.Room.CheckIn.Server((Lodge.Room.CheckIn.Data)(this.Data as Data).Checkin.Active)
            {
                Type = ChildType.Independent,
            });

        }

    }

}
