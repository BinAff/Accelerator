using System;
using System.Collections.Generic;

using BinAff.Core;

using CustFac = AutoTourism.Customer.Facade;
using RoomAuto = AutoTourism.Lodge.Configuration.Facade.Room;

namespace AutoTourism.Lodge.Facade.RoomReservation
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {

        public Boolean IsBackDateEntry { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public Int32 NoOfDays { get; set; }
        public Int32 NoOfRooms { get; set; }

        public Table RoomCategory { get; set; }
        public Table RoomType { get; set; }
        public Int32 ACPreference { get; set; } //-- will use hard coded values 0- No Preference, 1- AC, 2- Non AC

        public Int32 NoOfMale { get; set; }
        public Int32 NoOfFemale { get; set; }
        public Int32 NoOfChild { get; set; }
        public Int32 NoOfInfant { get; set; }
        public String Remark { get; set; }
        public String ReservationNo { get; set; }

        public Status BookingStatus { get; set; }
        public Boolean IsCheckedIn { get; set; }

        public List<RoomAuto.Dto> RoomList { get; set; }
        public CustFac.Dto Customer { get; set; }

        public String ArtifactPath { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.RoomCategory != null) dto.RoomCategory = this.RoomCategory.Clone();
            if (this.RoomType != null) dto.RoomType = this.RoomType.Clone();
            if (this.Customer != null) dto.Customer = this.Customer.Clone() as CustFac.Dto;
            if (dto.RoomList != null)
            {
                dto.RoomList = new List<RoomAuto.Dto>();
                foreach (RoomAuto.Dto room in this.RoomList)
                {
                    dto.RoomList.Add((room != null) ? room.Clone() as RoomAuto.Dto : null);
                }
            }
            return dto;
        }

    }

}
