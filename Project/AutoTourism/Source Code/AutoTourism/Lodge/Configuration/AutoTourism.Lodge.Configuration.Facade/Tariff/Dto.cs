using System;

namespace AutoTourism.Lodge.Configuration.Facade.Tariff
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public Int64 Id { get; set; }
        public Room.Category.Dto Category { get; set; }
        public Room.Type.Dto Type { get; set; }

        public String CategoryText { get; set; }
        public String TypeText { get; set; }
        public String IsACText { get; set; }

        public Boolean IsAC { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Double Rate { get; set; }
        public String RateText { get; set; }
    }
}
