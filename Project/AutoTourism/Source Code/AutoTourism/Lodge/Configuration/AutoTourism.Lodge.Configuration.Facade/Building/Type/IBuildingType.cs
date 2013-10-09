using System;

using BinAff.Core;

namespace AutoTourism.Lodge.Configuration.Facade.Building.Type
{

    public interface IBuildingType
    {

        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Dto> Read(Dto dto);

    }

}
