using System;

using BinAff.Core;

using Retinue.Lodge.Configuration.Facade.Building;

namespace Retinue.Lodge.Configuration.Facade.Room
{

    public interface IRoom
    {

        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Boolean> Open(Dto dto);
        ReturnObject<Boolean> Close(ReasonDto dto);
        //ReturnObject<Boolean> CloseWithNoCheck(ReasonDto dto);

    }

}
