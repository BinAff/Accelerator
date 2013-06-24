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
            //Cal component for list of roles
            ICrud server = new Crystal.Guardian.Component.Role.Server(null);
            ReturnObject<List<BinAff.Core.Data>> roleList = server.ReadAll();
            if (roleList == null)
            {
                //Display error
            }
            else
            {
                if (roleList.HasError())
                {
                    //Display error
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

        public override void ConvertToDto()
        {
            this.data.Id = ((FormDto)this.FormDto).Dto.Id;
            this.data.LoginId = ((FormDto)this.FormDto).Dto.LoginId;
            this.data.Password = ((FormDto)this.FormDto).Dto.Password;
            this.data.RoleList = new System.Collections.Generic.List<BinAff.Core.Data>();
            foreach (Role.Dto dto in ((FormDto)this.FormDto).Dto.RoleList)
            {
                this.data.RoleList.Add(new Crystal.Guardian.Component.Role.Data
                {
                    Id = dto.Id,
                    Name = dto.Name,
                });
            }
        }

        public override void ConvertFromDto()
        {
            throw new System.NotImplementedException();
        }

        public override ReturnObject<Boolean> Save()
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

            ICrud server = new Crystal.Guardian.Component.Account.Server(data);
            ReturnObject<Boolean> ret = server.Save();

            return ret;
        }

    }

}
