using System;

using BinAff.Core;

namespace AutoTourism.Facade.Configuration.BuildingType
{

    public interface IBuildingType
    {

        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Add(Dto dto);
        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Dto> Read(Dto dto);
        ReturnObject<Boolean> Change(Dto dto);

    }

}
