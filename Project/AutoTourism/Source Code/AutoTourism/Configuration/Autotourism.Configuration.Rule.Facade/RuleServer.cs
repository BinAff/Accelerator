
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BinAff.Core;

namespace Autotourism.Configuration.Rule.Facade
{
    public class RuleServer : IRule
    {
        ReturnObject<FormDto> IRule.LoadForm()
        {
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    RuleDto = new Dto()
                    {
                        CustomerRule = this.ReadCustomerRule().Value,
                        UserRule = this.ReadUserRule().Value,
                        TaxRule = this.ReadTaxRule().Value,
                        ConfigurationRule = this.ReadConfigurationRule().Value
                    }
                }
            };

            return ret;
        }

        ReturnObject<Boolean> IRule.Save(Dto dto)
        {
            return this.Save(dto);
        }

        private ReturnObject<CustomerRuleDto> ReadCustomerRule()
        {
            //ICrud customerCrud = new Crystal.CustomerManagement.Rule.Server(new Crystal.CustomerManagement.Rule.Data() { Id = 1 });
            //ReturnObject<BinAff.Core.Data> CustomerData = customerCrud.Read();

            //if (CustomerData.HasError())
            //{
            //    return new ReturnObject<AutoTourism.Facade.CustomerManagement.Rule.Dto>
            //    {
            //        Value = null,
            //    };
            //}

            //return new ReturnObject<CustomerManagement.Rule.Dto>()
            //{
            //    Value = new CustomerManagement.Rule.Dto()
            //    {
            //        IsAlternateContactNumber = ((Crystal.CustomerManagement.Rule.Data)CustomerData.Value).IsAlternateContactNumber,
            //        IsEmail = ((Crystal.CustomerManagement.Rule.Data)CustomerData.Value).IsEmail,
            //        IsIdentityProof = ((Crystal.CustomerManagement.Rule.Data)CustomerData.Value).IsIdentityProof,
            //        IsPinNumber = ((Crystal.CustomerManagement.Rule.Data)CustomerData.Value).IsPinNumber,
            //    }
            //};

            return new ReturnObject<CustomerRuleDto>();
        }

        private ReturnObject<UserRuleDto> ReadUserRule()
        {
            //ICrud userCrud = new Crystal.UserManagement.Rule.Server(new Crystal.UserManagement.Rule.Data() { Id = 1 });
            //ReturnObject<BinAff.Core.Data> UserData = userCrud.Read();

            //if (UserData.HasError())
            //{
            //    return new ReturnObject<AutoTourism.Facade.UserManagement.Rule.Dto>
            //    {
            //        Value = null,
            //    };
            //}

            //return new ReturnObject<UserManagement.Rule.Dto>()
            //{
            //    Value = new UserManagement.Rule.Dto()
            //    {
            //        DefaultUserPassword = ((Crystal.UserManagement.Rule.Data)UserData.Value).DefaultUserPassword,

            //    }
            //};

            return new ReturnObject<UserRuleDto>();
        }

        private ReturnObject<TaxRuleDto> ReadTaxRule()
        {
            //ICrud taxRuleCrud = new Crystal.Invoice.Rule.Server(new Crystal.Invoice.Rule.Data() { Id = 1 });
            //ReturnObject<BinAff.Core.Data> RuleData = taxRuleCrud.Read();

            //if (RuleData.HasError())
            //{
            //    return new ReturnObject<AutoTourism.Facade.Rule.TaxRuleDto>
            //    {
            //        Value = null,
            //    };
            //}

            //return new ReturnObject<AutoTourism.Facade.Rule.TaxRuleDto>()
            //{
            //    Value = new AutoTourism.Facade.Rule.TaxRuleDto()
            //    {
            //        ServiceTax = ((Crystal.Invoice.Rule.Data)RuleData.Value).ServiceTax,
            //        LuxuryTax = ((Crystal.Invoice.Rule.Data)RuleData.Value).LuxuryTax

            //    }
            //};

            return new ReturnObject<TaxRuleDto>();
        }

        private ReturnObject<ConfigurationRuleDto> ReadConfigurationRule()
        {
            //ICrud congurationfiRuleCrud = new Crystal.Configuration.Rule.Server(new Crystal.Configuration.Rule.Data() { Id = 1 });
            //ReturnObject<BinAff.Core.Data> RuleData = congurationfiRuleCrud.Read();

            //if (RuleData.HasError())
            //{
            //    return new ReturnObject<AutoTourism.Facade.Configuration.Rule.Dto>
            //    {
            //        Value = null,
            //    };
            //}

            //return new ReturnObject<AutoTourism.Facade.Configuration.Rule.Dto>()
            //{
            //    Value = new AutoTourism.Facade.Configuration.Rule.Dto()
            //    {
            //        DateFormat = ((Crystal.Configuration.Rule.Data)RuleData.Value).DateFormat
            //    }
            //};

            return new ReturnObject<ConfigurationRuleDto>();
        }

        private ReturnObject<Boolean> Save(Dto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            //using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            //{
            //    //save customer rule
            //    ICrud Crud = new Crystal.CustomerManagement.Rule.Server(new Crystal.CustomerManagement.Rule.Data()
            //    {
            //        IsPinNumber = dto.CustomerRule.IsPinNumber,
            //        IsAlternateContactNumber = dto.CustomerRule.IsAlternateContactNumber,
            //        IsEmail = dto.CustomerRule.IsEmail,
            //        IsIdentityProof = dto.CustomerRule.IsIdentityProof
            //    });
            //    ret = Crud.Save();
            //    if (!ret.Value || ret.HasError()) return ret;

            //    //save user rule
            //    Crud = new Crystal.UserManagement.Rule.Server(new Crystal.UserManagement.Rule.Data()
            //    {
            //        DefaultUserPassword = dto.UserRule.DefaultUserPassword,
            //    });
            //    ret = Crud.Save();
            //    if (!ret.Value || ret.HasError()) return ret;

            //    //save tax rule
            //    Crud = new Crystal.Invoice.Rule.Server(new Crystal.Invoice.Rule.Data()
            //    {
            //        ServiceTax = dto.TaxRule.ServiceTax,
            //        LuxuryTax = dto.TaxRule.LuxuryTax
            //    });
            //    ret = Crud.Save();
            //    if (!ret.Value || ret.HasError()) return ret;

            //    Crud = new Crystal.Configuration.Rule.Server(new Crystal.Configuration.Rule.Data()
            //    {
            //        DateFormat = dto.ConfigurationRule.DateFormat
            //    });
            //    ret = Crud.Save();
            //    if (!ret.Value || ret.HasError()) return ret;

            //    T.Complete();
            //}

            return ret;
        }
    }
}
