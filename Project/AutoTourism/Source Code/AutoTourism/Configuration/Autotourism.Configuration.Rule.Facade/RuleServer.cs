
using System;
using System.Transactions;

using BinAff.Core;

using CrystalCustomerRule = Crystal.Customer.Rule;
using CrystalConfigurationRule = Crystal.Configuration.Rule;
using CrystalGuardianRule = Crystal.Guardian.Rule;


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
            ICrud customerCrud = new CrystalCustomerRule.Server(new CrystalCustomerRule.Data() { Id =1 });           
            ReturnObject<BinAff.Core.Data> CustomerData = customerCrud.Read();

            if (CustomerData.HasError())
            {
                return new ReturnObject<CustomerRuleDto>
                {
                    Value = null,
                };
            }

            return new ReturnObject<CustomerRuleDto>()
            {
                Value = new CustomerRuleDto()
                {
                    IsAlternateContactNumber = ((CrystalCustomerRule.Data)CustomerData.Value).IsAlternateContactNumber,
                    IsEmail = ((CrystalCustomerRule.Data)CustomerData.Value).IsEmail,
                    IsIdentityProof = ((CrystalCustomerRule.Data)CustomerData.Value).IsIdentityProof,
                    IsPinNumber = ((CrystalCustomerRule.Data)CustomerData.Value).IsPinNumber,
                }
            };
        }

        private ReturnObject<UserRuleDto> ReadUserRule()
        {
            ICrud userCrud = new CrystalGuardianRule.Server(new CrystalGuardianRule.Data { Id = 1 });           
            ReturnObject<BinAff.Core.Data> UserData = userCrud.Read();

            if (UserData.HasError())
            {
                return new ReturnObject<UserRuleDto>
                {
                    Value = null,
                };
            }

            return new ReturnObject<UserRuleDto>()
            {
                Value = new UserRuleDto()
                {
                    DefaultUserPassword = ((CrystalGuardianRule.Data)UserData.Value).DefaultUserPassword,
                }
            };
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
            ICrud congurationfiRuleCrud = new CrystalConfigurationRule.Server(new CrystalConfigurationRule.Data { Id = 1 });            
            ReturnObject<BinAff.Core.Data> RuleData = congurationfiRuleCrud.Read();

            if (RuleData.HasError())
            {
                return new ReturnObject<ConfigurationRuleDto>
                {
                    Value = null,
                };
            }

            return new ReturnObject<ConfigurationRuleDto>()
            {
                Value = new ConfigurationRuleDto()
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
                ICrud Crud = new CrystalCustomerRule.Server(new CrystalCustomerRule.Data()
                {
                    IsPinNumber = dto.CustomerRule.IsPinNumber,
                    IsAlternateContactNumber = dto.CustomerRule.IsAlternateContactNumber,
                    IsEmail = dto.CustomerRule.IsEmail,
                    IsIdentityProof = dto.CustomerRule.IsIdentityProof
                });
                ret = Crud.Save();
                if (!ret.Value || ret.HasError()) return ret;

                //save user rule
                Crud = new CrystalGuardianRule.Server(new CrystalGuardianRule.Data()
                {
                    DefaultUserPassword = dto.UserRule.DefaultUserPassword,
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

                Crud = new CrystalConfigurationRule.Server(new CrystalConfigurationRule.Data()
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
