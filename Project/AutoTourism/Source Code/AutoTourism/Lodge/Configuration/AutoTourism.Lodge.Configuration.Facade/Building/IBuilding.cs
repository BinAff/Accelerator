using System;

using BinAff.Core;


namespace AutoTourism.Lodge.Configuration.Facade.Building
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
