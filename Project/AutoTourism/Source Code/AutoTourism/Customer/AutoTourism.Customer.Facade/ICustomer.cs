using System;

using BinAff.Core;


namespace AutoTourism.Customer.Facade
{
    public interface ICustomer
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<FormDto> LoadCustomerRegisterForm();
        ReturnObject<Boolean> Save(Dto dto);        
    }
}
