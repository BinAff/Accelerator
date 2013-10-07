using System;

using BinAff.Core;

namespace Vanilla.Configuration.Facade.IdentityProofType
{

    public interface IIdentityProofType
    {

        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Add(Dto dto);
        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Dto> Read(Dto dto);
        ReturnObject<Boolean> Change(Dto dto);

    }

}
