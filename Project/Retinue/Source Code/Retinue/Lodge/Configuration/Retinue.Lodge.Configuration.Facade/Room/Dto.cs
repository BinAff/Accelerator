using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Configuration.Facade.Room
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Number { get; set; }

        public String Name { get; set; }

        public String Display
        {
            get
            {
                return this.Building.Name + ":" + this.Number + "-" + this.Name;
            }
        }

        public String Description { get; set; }

        public Room.Category.Dto Category { get; set; }

        public Room.Type.Dto Type { get; set; }

        public Building.Dto Building { get; set; }

        public Table Floor { get; set; }

        public Boolean IsAirconditioned { get; set; }

        public Int16 Accomodation { get; set; }

        public Int16 ExtraAccomodation { get; set; }

        public Int64 StatusId { get; set; }

        public List<Image.Dto> ImageList { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (dto.Category != null) dto.Category = this.Category.Clone() as Room.Category.Dto;
            if (dto.Type != null) dto.Type = this.Type.Clone() as Room.Type.Dto;
            if (dto.Building != null) dto.Building = this.Building.Clone() as Building.Dto;
            if (dto.Floor != null) dto.Floor = this.Floor.Clone();
            if (this.ImageList != null)
            {
                dto.ImageList = new List<Image.Dto>();
                foreach (Image.Dto image in this.ImageList)
                {
                    dto.ImageList.Add((image != null) ? image.Clone() as Image.Dto : null);
                }
            }
            return dto;
        }

    }

}