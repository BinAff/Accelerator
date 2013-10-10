using System;

using BinAff.Core;


namespace AutoTourism.Lodge.Configuration.Facade.Building
{
    public interface IBuilding
    {
        ReturnObject<Boolean> Open(Dto dto);
        ReturnObject<Boolean> Close(ReasonDto dto);
        ReturnObject<Boolean> CloseWithNoCheck(ReasonDto dto);
    }
}
