using System;

using BinAff.Core;

namespace Vanilla.Configuration.Lodge.Facade.Room.RoomType
{

    public interface IRoomType
    {

        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Add(Dto dto);
        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Dto> Read(Dto dto);
        ReturnObject<Boolean> Change(Dto dto);

    }

}
