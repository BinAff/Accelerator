using System;
using System.Collections.Generic;

using BinAff.Core;

using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeConfFac = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {        
        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public Int32 NoOfDays { get; set; }
        //public Int32 NoOfPersons { get; set; }
        public Int32 NoOfRooms { get; set; }
        //public Double Advance { get; set; }

        public Table RoomCategory { get; set; }
        public Table RoomType { get; set; }
        public Int32 ACPreference { get; set; } //-- will use hard coded values 0- No Preference, 1- AC, 2- Non AC

        public Int32 NoOfMale { get; set; }
        public Int32 NoOfFemale { get; set; }
        public Int32 NoOfChild { get; set; }
        public Int32 NoOfInfant { get; set; }
        public String Remark { get; set; }
        public String ReservationNo { get; set; }

        public Int64 BookingStatusId { get; set; }
        public Boolean isCheckedIn { get; set; }        

        public List<LodgeConfFac.Room.Dto> RoomList { get; set; }
        public CustomerFacade.Dto Customer { get; set; }

        public String ArtifactPath { get; set; }

    }

}
