using System;
using BinAff.Core;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public interface ICheckIn
    {       
        ReturnObject<Boolean> Save(Dto dto);
    }
}
