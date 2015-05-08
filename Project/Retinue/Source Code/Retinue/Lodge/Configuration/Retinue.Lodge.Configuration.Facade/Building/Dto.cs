using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Configuration.Facade.Building
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }
        public List<Table> FloorList { get; set; }        

        public Type.Dto Type { get; set; }
        //public Int32 DefaultFloor { get; set; }
        //public Boolean IsDefault { get; set; }
        public Table Status { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.FloorList != null)
            {
                dto.FloorList = new List<Table>();
                foreach (Table floor in this.FloorList)
                {
                    dto.FloorList.Add((floor != null) ? floor.Clone() : null);
                }
            }
            if (dto.Type != null) dto.Type = this.Type.Clone() as Type.Dto;
            if (dto.Status != null) dto.Status = this.Status.Clone();
            return dto;
        }
       
    }

}