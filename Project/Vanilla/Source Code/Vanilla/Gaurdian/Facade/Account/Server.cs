using System;
using System.Collections.Generic;

using BinAff.Core;

using Crystal.Guardian;

namespace Vanilla.Guardian.Facade.Account
{

    public class Server : BinAff.Facade.Library.Server
    {
        private Crystal.Guardian.Component.Account.Data data;

        public Server(FormDto formDto)
            :base(formDto)
        {

        }

        public override void LoadForm()
        {
            ((FormDto)base.FormDto).RoleList = this.GetRoleList();
            ((FormDto)base.FormDto).Rule = this.GetRule();
        }
        
        /// <summary>
        /// Get role list from server
        /// </summary>
        /// <returns></returns>
        private List<Role.Dto> GetRoleList()
        {
            //Call component for list of roles
            ICrud server = new Crystal.Guardian.Component.Role.Server(null);
            ReturnObject<List<BinAff.Core.Data>> roleList = server.ReadAll();
            if (roleList == null)
            {
                this.DisplayMessageList = new List<String>
                {
                    "No role configured."
                };
            }
            else
            {
                if (roleList.HasError())
                {
                    this.DisplayMessageList = roleList.GetMessage(Message.Type.Error);
                }
                else
                {
                    if (roleList.Value != null && roleList.Value.Count > 0)
                    {
                        List<Role.Dto> retRoleList = new List<Role.Dto>();
                        foreach (BinAff.Core.Data role in roleList.Value)
                        {
                            retRoleList.Add(new Role.Dto
                            {
                                Id = role.Id,
                                Name = ((Crystal.Guardian.Component.Role.Data)role).Name,
                            });
                        }
                        return retRoleList;
                    }
                }
            }
            return null;
        }

        private Rule.Dto GetRule()
        {
            Crystal.Guardian.Rule.Data data = new Crystal.Guardian.Rule.Data();
            ICrud server = new Crystal.Guardian.Rule.Server(data);
            server.Read();

            return new Rule.Dto
            {
                DefaultPassword = data.DefaultUserPassword
            };
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            Crystal.Guardian.Component.Account.Data accountdata = data as Crystal.Guardian.Component.Account.Data;
            Facade.Account.Dto dto = new Dto();
            dto.Id = accountdata.Id;
            dto.LoginId = accountdata.LoginId;
            dto.Password = accountdata.Password;
            if (accountdata.RoleList != null && accountdata.RoleList.Count > 0)
            {
                dto.RoleList = new List<Role.Dto>();
                foreach (Crystal.Guardian.Component.Role.Data role in accountdata.RoleList)
                {
                    dto.RoleList.Add(new Role.Dto
                    {
                        Id = role.Id,
                        Name = role.Name
                    });
                }
            }
            return dto;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Crystal.Guardian.Component.Account.Data accountdata = new Crystal.Guardian.Component.Account.Data();
            Account.Dto account = dto as Account.Dto;
            accountdata.Id = account.Id;
            accountdata.LoginId = account.LoginId;
            accountdata.Password = account.Password;
            if (account.RoleList != null && account.RoleList.Count > 0)
            {
                accountdata.RoleList = new List<BinAff.Core.Data>();
                foreach (Role.Dto role in account.RoleList)
                {
                    accountdata.RoleList.Add(new Crystal.Guardian.Component.Role.Data
                    {
                        Id = role.Id,
                        Name = role.Name,
                    });
                }
            }
            return accountdata;
        }

        public override void Add()
        {
            Dto dto = ((FormDto)this.FormDto).Dto;
            Crystal.Guardian.Component.Account.Data data = new Crystal.Guardian.Component.Account.Data
            {
                LoginId = dto.LoginId,
                Password = dto.Password,
            };
            if (dto.RoleList != null && dto.RoleList.Count > 0)
            {
                data.RoleList = new List<Data>();
                foreach (Role.Dto role in dto.RoleList)
                {
                    data.RoleList.Add(new Data
                    {
                        Id = role.Id,
                    });
                }
            }

            ReturnObject<Boolean> ret = (new Crystal.Guardian.Component.Account.Server(data) as ICrud).Save();
            
            this.DisplayMessageList = ret.GetMessage(ret.HasError() ? Message.Type.Error : Message.Type.Information);
        }

        public void Login()
        {
            Dto dto = ((FormDto)this.FormDto).Dto;
            //Crystal.Guardian.Component.Account.Data data = new Crystal.Guardian.Component.Account.Data
            //{
            //    LoginId = dto.LoginId,
            //    Password = dto.Password,
            //};
            Crystal.Guardian.Component.Account.Data data = this.Convert(dto) as Crystal.Guardian.Component.Account.Data;
            ReturnObject<BinAff.Core.Data> ret = (new Crystal.Guardian.Component.Account.Server(data) as Crystal.Guardian.Component.Account.IUser).Login();
            if (ret.HasError())
            {
                this.IsError = true;
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                (this.FormDto as FormDto).Dto = this.Convert(ret.Value) as Account.Dto;
            }
        }

    }

}
