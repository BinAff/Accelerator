using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Lodge.Configuration.Facade.Tariff
{

    public interface ITariff
    {

        //ReturnObject<FormDto> LoadForm();
        //ReturnObject<Boolean> Add(Dto dto);
        //ReturnObject<Boolean> UpdateAndInsert(Dto dto);
        //ReturnObject<Boolean> Change(Dto dto);
        ReturnObject<List<Dto>> ReadAllTariff();
        ReturnObject<List<Dto>> ReadAllCurrentTariff();
        ReturnObject<List<Dto>> ReadAllFutureTariff();

    }

}
