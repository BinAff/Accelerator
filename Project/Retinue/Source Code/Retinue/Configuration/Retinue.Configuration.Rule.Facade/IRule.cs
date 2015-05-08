using System;

using BinAff.Core;

namespace Retinue.Configuration.Rule.Facade
{

    public interface IRule
    {

        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Save(Dto dto);

    }

}
