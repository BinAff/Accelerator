using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoTourism.Lodge.Facade.RoomReservationRegister
{
    public class FormDto
    {
        public List<Dto> RoomReservationDtoList { get; set; }
        public List<Table> StatusList { get; set; }
    }
}
