using System;
using System.Transactions;

using BinAff.Core;

using CustRuleCrys = Crystal.Customer.Rule;
using ConfRuleCrys = Crystal.Configuration.Rule;
using GuardRuleCrys = Crystal.Guardian.Rule;

namespace Retinue.Configuration.Rule.Facade
{

    public class RuleServer : IRule
    {

        ReturnObject<FormDto> IRule.LoadForm()
        {
            return new BinAff.Core.ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    RuleDto = new Dto
                    {
                        CustomerRule = this.ReadCustomerRule().Value,
                        UserRule = this.ReadUserRule().Value,
                        TaxRule = this.ReadTaxRule().Value,
                        ConfigurationRule = this.ReadConfigurationRule().Value
                    }
                }
            };
        }

        ReturnObject<Boolean> IRule.Save(Dto dto)
        {
            return this.Save(dto);
        }

        public ReturnObject<CustomerRuleDto> ReadCustomerRule()
        {
            ICrud customerCrud = new CustRuleCrys.Server(new CustRuleCrys.Data() { Id =1 });           
            ReturnObject<BinAff.Core.Data> CustomerData = customerCrud.Read();

            if (CustomerData.HasError())
            {
                return new ReturnObject<CustomerRuleDto>
                {
                    Value = null,
                };
            }

            return new ReturnObject<CustomerRuleDto>
            {
                Value = new CustomerRuleDto
                {
                    IsAlternateContactNumber = ((CustRuleCrys.Data)CustomerData.Value).IsAlternateContactNumber,
                    IsEmail = ((CustRuleCrys.Data)CustomerData.Value).IsEmail,
                    IsIdentityProof = ((CustRuleCrys.Data)CustomerData.Value).IsIdentityProof,
                    IsPinNumber = ((CustRuleCrys.Data)CustomerData.Value).IsPinNumber,
                }
            };
        }

        public ReturnObject<UserRuleDto> ReadUserRule()
        {
            ICrud userCrud = new GuardRuleCrys.Server(new GuardRuleCrys.Data { Id = 1 });           
            ReturnObject<BinAff.Core.Data> UserData = userCrud.Read();

            if (UserData.HasError())
            {
                return new ReturnObject<UserRuleDto>
                {
                    Value = null,
                };
            }

            return new ReturnObject<UserRuleDto>
            {
                Value = new UserRuleDto
                {
                    DefaultUserPassword = ((GuardRuleCrys.Data)UserData.Value).DefaultPassword,
                }
            };
        }

        public ReturnObject<TaxRuleDto> ReadTaxRule()
        {
            //ICrud taxRuleCrud = new Crystal.Invoice.Rule.Server(new Crystal.Invoice.Rule.Data() { Id = 1 });
            //ReturnObject<BinAff.Core.Data> RuleData = taxRuleCrud.Read();

            //if (RuleData.HasError())
            //{
            //    return new ReturnObject<Retinue.Facade.Rule.TaxRuleDto>
            //    {
            //        Value = null,
            //    };
            //}

            //return new ReturnObject<Retinue.Facade.Rule.TaxRuleDto>()
            //{
            //    Value = new Retinue.Facade.Rule.TaxRuleDto()
            //    {
            //        ServiceTax = ((Crystal.Invoice.Rule.Data)RuleData.Value).ServiceTax,
            //        LuxuryTax = ((Crystal.Invoice.Rule.Data)RuleData.Value).LuxuryTax

            //    }
            //};

            return new ReturnObject<TaxRuleDto>();
        }

        public ReturnObject<ConfigurationRuleDto> ReadConfigurationRule()
        {
            ICrud congurationfiRuleCrud = new ConfRuleCrys.Server(new ConfRuleCrys.Data { Id = 1 });            
            ReturnObject<BinAff.Core.Data> RuleData = congurationfiRuleCrud.Read();

            if (RuleData.HasError())
            {
                return new ReturnObject<ConfigurationRuleDto>
                {
                    Value = null,
                };
            }

            return new ReturnObject<ConfigurationRuleDto>
            {
                Value = new ConfigurationRuleDto
                {
                    DateFormat = ((Crystal.Configuration.Rule.Data)RuleData.Value).DateFormat
                }
            };
          
        }

        private ReturnObject<Boolean> Save(Dto dto)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                //save customer rule
                ICrud Crud = new CustRuleCrys.Server(new CustRuleCrys.Data
                {
                    IsPinNumber = dto.CustomerRule.IsPinNumber,
                    IsAlternateContactNumber = dto.CustomerRule.IsAlternateContactNumber,
                    IsEmail = dto.CustomerRule.IsEmail,
                    IsIdentityProof = dto.CustomerRule.IsIdentityProof
                });
                ret = Crud.Save();
                if (!ret.Value || ret.HasError()) return ret;

                //save user rule
                Crud = new GuardRuleCrys.Server(new GuardRuleCrys.Data
                {
                    DefaultPassword = dto.UserRule.DefaultUserPassword,
                });
                ret = Crud.Save();
                if (!ret.Value || ret.HasError()) return ret;

            //    //save tax rule
            //    Crud = new Crystal.Invoice.Rule.Server(new Crystal.Invoice.Rule.Data()
            //    {
            //        ServiceTax = dto.TaxRule.ServiceTax,
            //        LuxuryTax = dto.TaxRule.LuxuryTax
            //    });
            //    ret = Crud.Save();
            //    if (!ret.Value || ret.HasError()) return ret;

                Crud = new ConfRuleCrys.Server(new ConfRuleCrys.Data
                {
                    DateFormat = dto.ConfigurationRule.DateFormat
                });
                ret = Crud.Save();
                if (!ret.Value || ret.HasError()) return ret;

                T.Complete();
            }

            return ret;
        }

    }

}