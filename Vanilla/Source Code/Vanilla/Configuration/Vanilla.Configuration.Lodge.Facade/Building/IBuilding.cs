using System;

using BinAff.Core;
using AutoTourism.Facade.Library;

namespace AutoTourism.Facade.Configuration.Building
{
    public interface IBuilding
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
