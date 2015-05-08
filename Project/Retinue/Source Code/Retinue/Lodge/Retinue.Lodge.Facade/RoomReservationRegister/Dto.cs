using System;
using System.Collections.Generic;

using BinAff.Core;

using LodgeConfFac = Retinue.Lodge.Configuration.Facade;
using CustomerFacade = Retinue.Customer.Facade;
using Retinue.Lodge.Facade.RoomReservation;

namespace Retinue.Lodge.Facade.RoomReservationRegister
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {

        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public Int32 NoOfDays { get; set; }
        //public Int32 NoOfPersons { get; set; }
        public Int32 NoOfRooms { get; set; }
        //public Double Advance { get; set; }
        //public String AdvanceDisplay { get; set; }
       

        public Table RoomCategory { get; set; }
        public Table RoomType { get; set; }        
        public Int32 ACPreference { get; set; } //-- will use hard coded values 0- No Preference, 1- AC, 2- Non AC

        public Int32 NoOfMale { get; set; }
        public Int32 NoOfFemale { get; set; }
        public Int32 NoOfChild { get; set; }
        public Int32 NoOfInfant { get; set; }
        public String Remark { get; set; }
        public String ReservationNo { get; set; }
        public Boolean isCheckedIn { get; set; }      
        public Status BookingStatus { get; set; }

        public String Name { get; set; }
        public String ContactNumber { get; set; }
        public String Room { get; set; }

        public List<LodgeConfFac.Room.Dto> RoomList { get; set; }
        public CustomerFacade.Dto Customer { get; set; }

    }

}
