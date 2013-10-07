using System;
using BinAff.Core;

namespace Vanilla.Configuration.Facade.PaymentType
{
    public interface IPaymentType
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Add(Dto dto);
        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Dto> Read(Dto dto);
        ReturnObject<Boolean> Change(Dto dto);
    }
}
