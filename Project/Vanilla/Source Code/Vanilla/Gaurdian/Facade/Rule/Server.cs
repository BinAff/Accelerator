using System;

using BinAff.Core;

using GaurdianRule = Crystal.Guardian.Rule;

namespace Vanilla.Guardian.Facade.Rule
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
            ICrud server = new GaurdianRule.Server(this.Convert((this.FormDto as FormDto).Dto) as GaurdianRule.Data);
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
            GaurdianRule.Data rule = data as GaurdianRule.Data;
            return new Dto
            {
                Id = rule.Id,
                DefaultPassword = rule.DefaultPassword,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto rule = dto as Dto;
            return new GaurdianRule.Data
            {
                Id = rule.Id,
                DefaultPassword = rule.DefaultPassword,
            };
        }

        public override void Add()
        {
            FormDto formDto = this.FormDto as FormDto;
            ICrud server = new GaurdianRule.Server(this.Convert((this.FormDto as FormDto).Dto) as GaurdianRule.Data);
            ReturnObject<Boolean> rule = server.Save();
            if (rule.HasError())
            {
                this.IsError = true;
            }
            this.DisplayMessageList = rule.GetMessage(this.IsError ? Message.Type.Error : Message.Type.Information);
        }

    }

}
