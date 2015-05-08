using System;
using System.Collections.Generic;

namespace Retinue.Lodge.Component.Room.CheckIn
{

    public class Data : Crystal.Activity.Component.Data
    {

        public String invoiceNumber { get; set; }
        public String Purpose { get; set; }
        public String ArrivedFrom { get; set; }
        public String Remark { get; set; }
        public Retinue.Lodge.Component.Room.Reservation.Data Reservation { get; set; }
        public Crystal.Accountant.Component.Invoice.Data Invoice { get; set; }

    }

}