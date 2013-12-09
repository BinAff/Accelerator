using System;
using System.Collections.Generic;

using BinAff.Core;

using Crystal.Guardian;
using CrysGuardian = Crystal.Guardian.Component;

namespace Vanilla.Guardian.Facade.Account
{

    public class Server : BinAff.Facade.Library.Server
    {
        private CrysGuardian.Account.Data data;

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
            ICrud server = new CrysGuardian.Role.Server(null);
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
                                Name = ((CrysGuardian.Role.Data)role).Name,
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
                DefaultPassword = data.DefaultPassword
            };
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CrysGuardian.Account.Data accountdata = data as CrysGuardian.Account.Data;
            Dto accountDto = (this.FormDto as FormDto).Dto as Dto;
            accountDto.Id = accountdata.Id;
            accountDto.LoginId = accountdata.LoginId;
            accountDto.Password = accountdata.Password;
            if (accountdata.Profile != null)
            {
                accountDto.Profile = (new Facade.Profile.Server(new Profile.FormDto
                {
                    Dto = accountDto.Profile
                })).Convert(accountdata.Profile) as Profile.Dto;
            }
            if (accountdata.RoleList != null && accountdata.RoleList.Count > 0)
            {
                foreach (CrysGuardian.Role.Data role in accountdata.RoleList)
                {
                    accountDto.RoleList.Add(new Role.Dto
                    {
                        Id = role.Id,
                        Name = role.Name
                    });
                }
            }
            if (accountdata.SecurityAnswerList != null && accountdata.SecurityAnswerList.Count > 0)
            {
                CrysGuardian.Account.SecurityAnswer.Data securityAnswer = accountdata.SecurityAnswerList[0] as CrysGuardian.Account.SecurityAnswer.Data;
                accountDto.SecurityAnswer.Id = securityAnswer.Id;
                accountDto.SecurityAnswer.Answer = securityAnswer.Answer;
                if (securityAnswer.Question != null)
                {
                    accountDto.SecurityAnswer.SecurityQuestion.Id = securityAnswer.Question.Id;
                    accountDto.SecurityAnswer.SecurityQuestion.Name = securityAnswer.Question.Question;
                }
            }
            return accountDto;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Account.Dto accountDto = dto as Account.Dto;
            CrysGuardian.Account.Data accountdata = new CrysGuardian.Account.Data
            {
                Id = accountDto.Id,
                LoginId = accountDto.LoginId,
                Password = accountDto.Password
            };
            if (accountDto.Profile != null)
            {
                accountdata.Profile = new Profile.Server(null).Convert(accountDto.Profile) as CrysGuardian.Account.Profile.Data;
            }
            if (accountDto.RoleList != null && accountDto.RoleList.Count > 0)
            {
                accountdata.RoleList = new List<BinAff.Core.Data>();
                foreach (Role.Dto role in accountDto.RoleList)
                {
                    accountdata.RoleList.Add(new CrysGuardian.Role.Data
                    {
                        Id = role.Id,
                        Name = role.Name,
                    });
                }
            }
            if (accountDto.SecurityAnswer != null)
            {
                CrysGuardian.Account.SecurityAnswer.Data securityAnswer = new CrysGuardian.Account.SecurityAnswer.Data
                {
                    Id = accountDto.SecurityAnswer.Id,                    
                    Answer = accountDto.SecurityAnswer.Answer,
                };
                if (accountDto.SecurityAnswer.SecurityQuestion != null)
                {
                    securityAnswer.Question = new CrysGuardian.SecurityQuestion.Data
                    {
                        Id = accountDto.SecurityAnswer.SecurityQuestion.Id,
                        Question = accountDto.SecurityAnswer.SecurityQuestion.Name,
                    };
                }
                accountdata.SecurityAnswerList = new List<Data>
                {
                    { securityAnswer },
                };
            }
            return accountdata;
        }

        public override void Add()
        {
            //Dto dto = ((FormDto)this.FormDto).Dto;
            //CrysGuardian.Account.Data data = new CrysGuardian.Account.Data
            //{
            //    LoginId = dto.LoginId,
            //    Password = dto.Password,
            //};
            //if (dto.RoleList != null && dto.RoleList.Count > 0)
            //{
            //    data.RoleList = new List<Data>();
            //    foreach (Role.Dto role in dto.RoleList)
            //    {
            //        data.RoleList.Add(new Data
            //        {
            //            Id = role.Id,
            //        });
            //    }
            //}

            ReturnObject<Boolean> ret = (new CrysGuardian.Account.Server(this.Convert(((FormDto)this.FormDto).Dto) as CrysGuardian.Account.Data) as ICrud).Save();
            
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public void Login()
        {
            Dto dto = ((FormDto)this.FormDto).Dto;
            CrysGuardian.Account.Data data = this.Convert(dto) as CrysGuardian.Account.Data;
            ReturnObject<BinAff.Core.Data> ret = (new CrysGuardian.Account.Server(data) as CrysGuardian.Account.IUser).Login();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                (this.FormDto as FormDto).Dto = this.Convert(ret.Value) as Account.Dto;
            }
        }

    }

}
