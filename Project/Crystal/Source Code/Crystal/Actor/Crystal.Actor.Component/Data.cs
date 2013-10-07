using System;
using System.Collections.Generic;

namespace Crystal.Actor.Component
{

    public abstract class Data : BinAff.Core.Data
    {

        public String Name { get; set; }

        /// <summary>
        /// Current reservation for actor
        /// </summary>
        public Reservation.Component.Data CurrentReservation { get; set; }

        /// <summary>
        /// Current 
        /// </summary>
        public List<Activity.Component.Data> CurrentActivities { get; set; }

        /// <summary>
        /// List of reservation
        /// </summary>
        public List<Reservation.Component.Data> Reservations { get; set; }

        /// <summary>
        /// List of activities
        /// </summary>
        /// <remarks>
        /// As for example, Checkin, food consumption, tour, etc.
        /// </remarks>
        public List<Activity.Component.Data> ClosedActivities { get; set; }

    }

}
