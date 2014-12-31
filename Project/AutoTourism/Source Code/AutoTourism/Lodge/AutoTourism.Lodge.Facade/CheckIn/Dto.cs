﻿using System;

namespace AutoTourism.Lodge.Facade.CheckIn
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {

        public DateTime Date { get; set; }
        public Int64 StatusId { get; set; }
        public String InvoiceNumber { get; set; }
        public RoomReservation.Dto Reservation { get; set; }
        public String Purpose { get; set; }
        public String ArrivedFrom { get; set; }
        public String Remark { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone()as Dto;
            dto.Reservation = this.Reservation.Clone() as RoomReservation.Dto;
            return dto;
        }

    }

}
