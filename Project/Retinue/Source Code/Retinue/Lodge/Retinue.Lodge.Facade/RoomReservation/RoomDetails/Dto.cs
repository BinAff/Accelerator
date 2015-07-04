using System;

namespace Retinue.Lodge.Facade.RoomReservation.RoomDetails
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Int64 RoomId
        {
            get
            {
                return this.Room.Id;
            }
        }

        public String Name
        {
            get
            {
                return this.Room.Name;
            }
        }

        public String Number
        {
            get
            {
                return this.Room.Number;
            }
        }

        public String Style
        {
            get
            {
                return this.Room.Style;
            }
        }

        public Int16 Accomodation
        {
            get
            {
                return this.Room.Accomodation;
            }
        }

        public Int16 ExtraAccomodationAvailable
        {
            get
            {
                return this.Room.ExtraAccomodation;
            }
        }

        public Retinue.Lodge.Configuration.Facade.Room.Dto Room { get; set; }

        public Int16 ExtraAccomodation { get; set; }

    }

}