using System;
using BinAff.Core;

namespace Crystal.Lodge.Component.Room.Tariff
{
    public interface IRoomTariff
    {
        ReturnObject<Boolean> UpdateForCategoryAndType(Category.Data category, Type.Data type, Double rate);
    }
}
