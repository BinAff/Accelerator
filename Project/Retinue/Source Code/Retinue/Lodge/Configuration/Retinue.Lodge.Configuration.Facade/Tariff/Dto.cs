using System;

namespace Retinue.Lodge.Configuration.Facade.Tariff
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Room.Category.Dto Category { get; set; }
        public Room.Type.Dto Type { get; set; }
        public Boolean IsAC { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Double Rate { get; set; }

        public String RateText { get; set; }
        public String IsACText { get; set; }
        public String CategoryText { get; set; }
        public String TypeText { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (dto.Category != null) dto.Category = this.Category.Clone() as Room.Category.Dto;
            if (dto.Type != null) dto.Type = this.Type.Clone() as Room.Type.Dto;
            return dto;
        }

    }

}