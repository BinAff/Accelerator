using System;
using System.Collections.Generic;

namespace Crystal.Lodge.Component.Room.CheckIn
{

    public class Data : Crystal.Activity.Component.Data
    {

        public String invoiceNumber { get; set; }
        public String Purpose { get; set; }
        public String ArrivedFrom { get; set; }
        public String Remark { get; set; }
        public Crystal.Lodge.Component.Room.Reservation.Data Reservation { get; set; }
        public Crystal.Invoice.Component.Data Invoice { get; set; }

    }

}
