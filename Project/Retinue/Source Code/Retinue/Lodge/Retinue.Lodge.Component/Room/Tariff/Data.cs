using System;

using GenTariff = Crystal.Tariff.Component;

namespace Retinue.Lodge.Component.Room.Tariff
{
    public class Data : GenTariff.Data
    {
        public Category.Data category { get; set; }
        public Type.Data type { get; set; }
        public Boolean isAC { get; set; }
    }
}
