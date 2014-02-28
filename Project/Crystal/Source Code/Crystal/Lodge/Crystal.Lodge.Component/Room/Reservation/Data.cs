﻿using System;
using System.Collections.Generic;

namespace Crystal.Lodge.Component.Room.Reservation
{

    public class Data : Crystal.Reservation.Component.Data
    {
        public Int16 NoOfDays { get; set; }
        public Int16 NoOfPersons { get; set; }
        public Int16 NoOfRooms { get; set; }      
        public String Description { get; set; }
        public Double Advance { get; set; }
        public Boolean IsCheckedIn { get; set; }

        public Category.Data RoomCategory { get; set; }
        public Room.Type.Data RoomType { get; set; }
        //public Boolean IsAC { get; set; }
        public Int32 ACPreference { get; set; }
    }

}
