using System;

using BinAff.Core;

namespace AutoTourism.Facade.Configuration.Lodge
{
    public interface ILodge
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> SaveLodge(Dto dto);    
    }
}
