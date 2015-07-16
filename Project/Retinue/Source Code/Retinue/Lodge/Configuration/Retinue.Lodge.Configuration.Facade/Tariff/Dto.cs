using BinAff.Utility;
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
        public Boolean IsExtra { get; set; }
        public Double Rate { get; set; }

        public String RateText
        {
            get
            {
                return Converter.ConvertToIndianCurrency(this.Rate);
            }
        }
        public String IsACText
        {
            get
            {
                return this.IsAC ? "Yes" : "No";
            }
        }
        public String CategoryText
        {
            get
            {
                return this.Category == null ? String.Empty : this.Category.Name;
            }
        }
        public String TypeText
        {
            get
            {
                return this.Type == null ? String.Empty : this.Type.Name;
            }
        }
        public String IsExtraText
        {
            get
            {
                return this.IsExtra ? "Yes" : "No";
            }
        }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (dto.Category != null) dto.Category = this.Category.Clone() as Room.Category.Dto;
            if (dto.Type != null) dto.Type = this.Type.Clone() as Room.Type.Dto;
            return dto;
        }

    }

}