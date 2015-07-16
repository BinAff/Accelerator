using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Component.Room.Tariff
{

    public interface IRoomTariff
    {

        ReturnObject<List<BinAff.Core.Data>> GetExistingTariff();
        ReturnObject<List<BinAff.Core.Data>> ReadAllCurrentTariff();
        ReturnObject<List<BinAff.Core.Data>> ReadAllFutureTariff();

    }

}