
using System;
using System.Collections.Generic;

using BinAff.Core;
using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;


namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public DateTime Date { get; set; }
        public Int64 statusId { get; set; }
        public String invoiceNumber { get; set; }
        public LodgeFacade.RoomReservation.Dto reservationDto { get; set; }
        public String customerDisplayName { get; set; }
        
    }
}
