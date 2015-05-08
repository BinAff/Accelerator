using System;
using BinAff.Core;
using System.Collections.Generic;

namespace Retinue.Lodge.Component.Room.Tariff
{
    public interface IRoomTariff
    {
        ReturnObject<List<BinAff.Core.Data>> GetExistingTariff();
        ReturnObject<List<BinAff.Core.Data>> ReadAllCurrentTariff();
        ReturnObject<List<BinAff.Core.Data>> ReadAllFutureTariff();
        ReturnObject<Boolean> UpdateForCategoryAndType(Category.Data category, Type.Data type, Double rate);
    }
}
