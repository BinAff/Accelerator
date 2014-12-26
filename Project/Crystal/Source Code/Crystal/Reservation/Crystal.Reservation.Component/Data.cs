using System;

namespace Crystal.Reservation.Component
{

    public abstract class Data : Customer.Component.Action.Data
    {

        public Boolean IsBackDateEntry { get; set; }
        public DateTime ActivityDate { get; set; }

    }

}
