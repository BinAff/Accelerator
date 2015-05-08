using System;

namespace Retinue.Lodge.Facade.CheckIn
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {

        public DateTime Date { get; set; }
        public RoomReservation.Status Status { get; set; }
        public String InvoiceNumber { get; set; }
        public RoomReservation.Dto Reservation { get; set; }
        public String Purpose { get; set; }
        public String ArrivedFrom { get; set; }
        public String Remark { get; set; }
        public Vanilla.Accountant.Facade.Invoice.Dto Invoice { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone()as Dto;
            if(this.Reservation != null) dto.Reservation = this.Reservation.Clone() as RoomReservation.Dto;
            return dto;
        }

    }

}
