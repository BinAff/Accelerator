using System;

using BinAff.Core;

namespace AutoTourism.Facade.Configuration.RoomCategory
{
    public interface IRoomCategory
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Add(Dto dto);
        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Dto> Read(Dto dto);
        ReturnObject<Boolean> Change(Dto dto);
    }
}
