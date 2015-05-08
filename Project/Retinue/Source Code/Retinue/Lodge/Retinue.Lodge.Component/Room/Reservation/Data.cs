using System;

namespace Retinue.Lodge.Component.Room.Reservation
{

    public class Data : Crystal.Reservation.Component.Data
    {

        public Int32 NoOfDays { get; set; }
        public Int32 NoOfRooms { get; set; }
        //public Boolean IsCheckedIn { get; set; }

        public Category.Data RoomCategory { get; set; }
        public Room.Type.Data RoomType { get; set; }
        public Int32 ACPreference { get; set; }

        public Int32 NoOfMale { get; set; }
        public Int32 NoOfFemale { get; set; }
        public Int32 NoOfChild { get; set; }
        public Int32 NoOfInfant { get; set; }
        public String Remark { get; set; }
        public String ReservationNo { get; set; }

    }

}
