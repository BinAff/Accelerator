using System;

using BinAff.Core;

namespace Vanilla.Configuration.Lodge.Facade.Lodge
{
    public interface ILodge
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> SaveLodge(Dto dto);    
    }
}
