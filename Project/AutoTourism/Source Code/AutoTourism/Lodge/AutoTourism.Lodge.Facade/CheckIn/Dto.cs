using System;

using LodgeFacade = AutoTourism.Lodge.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {

        public DateTime Date { get; set; }
        public Int64 StatusId { get; set; }
        public String InvoiceNumber { get; set; }
        public LodgeFacade.RoomReservation.Dto Reservation { get; set; }
        public String CustomerDisplayName { get; set; }
        public String Purpose { get; set; }
        public String ArrivedFrom { get; set; }
        public String Remark { get; set; }

        
    }

}
