using System;
using System.Collections.Generic;

namespace Crystal.Lodge.Component.Room.CheckIn
{

    public class Data : Crystal.Activity.Component.Data
    {   
        public Double Advance { get; set; }
        public Crystal.Lodge.Component.Room.Reservation.Data Reservation { get; set; }
    }

}
