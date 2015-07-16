using System;

using GenTariff = Crystal.Tariff.Component;

namespace Retinue.Lodge.Component.Room.Tariff
{

    public class Data : GenTariff.Data
    {

        public Category.Data Category { get; set; }
        public Type.Data Type { get; set; }
        public Boolean IsAC { get; set; }

        public override BinAff.Core.Data Clone()
        {
            Data data = base.Clone() as Data;
            if (this.Category != null) data.Category = this.Category.Clone() as Category.Data;
            if (this.Type != null) data.Type = this.Type.Clone() as Type.Data;
            return data;
        }

    }

}