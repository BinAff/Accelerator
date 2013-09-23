using System;

using BinAff.Core;
using AutoTourism.Lodge.Configuration.Facade.Building;
//using AutoTourism.Facade.Library;

namespace AutoTourism.Lodge.Configuration.Facade.Room
{
    public interface IRoom
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Add(Dto dto);
        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Boolean> Change(Dto dto);
        ReturnObject<Boolean> Open(Dto dto);
        ReturnObject<Boolean> Close(ReasonDto dto);
        ReturnObject<Boolean> CloseWithNoCheck(ReasonDto dto);
    }
}
