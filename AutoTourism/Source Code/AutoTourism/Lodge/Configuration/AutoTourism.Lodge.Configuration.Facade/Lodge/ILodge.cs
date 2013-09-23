using System;

using BinAff.Core;

namespace AutoTourism.Lodge.Configuration.Facade.Lodge
{
    public interface ILodge
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> SaveLodge(Dto dto);    
    }
}
