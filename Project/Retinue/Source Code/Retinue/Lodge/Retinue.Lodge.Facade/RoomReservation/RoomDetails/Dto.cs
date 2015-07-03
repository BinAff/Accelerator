using System;

namespace Retinue.Lodge.Facade.RoomReservation.RoomDetails
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name
        {
            get
            {
                return this.Room.Name;
            }
        }

        public Retinue.Lodge.Configuration.Facade.Room.Dto Room { get; set; }

        public Int16 ExtraRoom { get; set; }

    }

}