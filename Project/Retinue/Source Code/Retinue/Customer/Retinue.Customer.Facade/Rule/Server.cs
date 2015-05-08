using BinAff.Core;
using System;

using CrystalCustomerRule = Crystal.Customer.Rule;

namespace Retinue.Customer.Facade.Rule
{
    
    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            ICrud server = new CrystalCustomerRule.Server(this.Convert((this.FormDto as FormDto).Dto) as CrystalCustomerRule.Data);
            ReturnObject<BinAff.Core.Data> rule = server.Read();

            if (rule.HasError())
            {
                this.DisplayMessageList = rule.GetMessage(Message.Type.Error);
                this.IsError = true;
            }
            else
            {
                formDto.Dto = this.Convert(rule.Value) as Dto;
            }
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CrystalCustomerRule.Data rule = data as CrystalCustomerRule.Data;
            return new Dto
            {
                Id = rule.Id,
                IsAlternateContactNumber = rule.IsAlternateContactNumber,
                IsEmail = rule.IsEmail,
                IsIdentityProof = rule.IsIdentityProof,
                IsPinNumber = rule.IsPinNumber,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto rule = dto as Dto;
            return new CrystalCustomerRule.Data
            {
                Id = rule.Id,
                IsAlternateContactNumber = rule.IsAlternateContactNumber,
                IsEmail = rule.IsEmail,
                IsIdentityProof = rule.IsIdentityProof,
                IsPinNumber = rule.IsPinNumber,
            };
        }

        public override void Add()
        {
            FormDto formDto = this.FormDto as FormDto;
            ICrud server = new CrystalCustomerRule.Server(this.Convert((this.FormDto as FormDto).Dto) as CrystalCustomerRule.Data);
            ReturnObject<Boolean> rule = server.Save();
            if (rule.HasError())
            {   
                this.IsError = true;
            }
            this.DisplayMessageList = rule.GetMessage(this.IsError? Message.Type.Error: Message.Type.Information);
        }

    }

}
