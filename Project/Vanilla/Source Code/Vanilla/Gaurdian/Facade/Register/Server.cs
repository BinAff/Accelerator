using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Guardian.Facade.Register
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            this.LoadRoleList();
            this.LoadRule();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            Crystal.Guardian.Component.Account.Data account = data as Crystal.Guardian.Component.Account.Data;
            Dto dto = new Dto
            {
                Id = account.Id,
                LoginId = account.LoginId
            };
            if (account.RoleList != null && account.RoleList.Count > 0)
            {
                dto.RoleList = new List<Role.Dto>();
                foreach (Crystal.Guardian.Component.Role.Data role in account.RoleList)
                {
                    dto.RoleList.Add(new Role.Dto
                    {
                        Id = role.Id,
                        Name = role.Name,
                    });
                }
            }
            return dto;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto account = dto as Dto;
            Crystal.Guardian.Component.Account.Data ret = new Crystal.Guardian.Component.Account.Data
            {
                Id = account.Id,
                LoginId = account.LoginId,
                Password = account.Password,                
            };
            if (account.RoleList != null && account.RoleList.Count > 0)
            {
                ret.RoleList = new List<Data>();
                foreach (Role.Dto role in account.RoleList)
                {
                    ret.RoleList.Add(new Crystal.Guardian.Component.Role.Data
                    {
                        Id = role.Id,
                        Name = role.Name,
                    });
                }
            }

            return ret;
        }

        public override void Add()
        {
            ReturnObject<Boolean> ret = (new Crystal.Guardian.Component.Account.Server(this.Convert((this.FormDto as FormDto).Dto) as Crystal.Guardian.Component.Account.Data) as ICrud).Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        private void LoadRoleList()
        {
            ReturnObject<List<Data>> ret = (new Crystal.Guardian.Component.Role.Server(null) as ICrud).ReadAll();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                FormDto formDto = this.FormDto as FormDto;
                if (ret.Value != null && ret.Value.Count > 0)
                {
                    formDto.RoleList = new List<Role.Dto>();
                    foreach (Crystal.Guardian.Component.Role.Data role in ret.Value)
                    {
                        formDto.RoleList.Add(new Role.Dto
                        {
                            Id = role.Id,
                            Name = role.Name,
                        });
                    }
                }
            }
        }

        private void LoadRule()
        {
            Crystal.Guardian.Rule.Data rule;
            ReturnObject<Data> ret = (new Crystal.Guardian.Rule.Server(rule = new Crystal.Guardian.Rule.Data()) as ICrud).Read();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                (this.FormDto as FormDto as FormDto).Rule = new Rule.Dto
                {
                    DefaultPassword = rule.DefaultPassword,
                };
            }
        }

    }

}
