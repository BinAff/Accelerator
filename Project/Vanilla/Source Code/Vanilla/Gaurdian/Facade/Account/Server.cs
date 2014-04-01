using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysAcc = Crystal.Guardian.Component.Account;
using CrysRole = Crystal.Guardian.Component.Role;
using CrysSecQ = Crystal.Guardian.Component.SecurityQuestion;

namespace Vanilla.Guardian.Facade.Account
{

    public class Server : BinAff.Facade.Library.Server
    {

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
            ICrud server = new CrysRole.Server(null);
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
                                Name = ((CrysRole.Data)role).Name,
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
            CrysAcc.Data accData = data as CrysAcc.Data;
            Dto accDto = (this.FormDto as FormDto).Dto as Dto;
            accDto.Id = accData.Id;
            accDto.LoginId = accData.LoginId;
            accDto.Password = accData.Password;
            if (accData.Profile != null)
            {
                accDto.Profile = (new Facade.Profile.Server(new Profile.FormDto
                {
                    Dto = accDto.Profile
                })).Convert(accData.Profile) as Profile.Dto;
            }
            if (accData.RoleList != null && accData.RoleList.Count > 0)
            {
                accDto.RoleList = new List<Role.Dto>();
                foreach (CrysRole.Data role in accData.RoleList)
                {
                    accDto.RoleList.Add(new Role.Dto
                    {
                        Id = role.Id,
                        Name = role.Name
                    });
                }
            }
            if (accData.SecurityAnswerList != null && accData.SecurityAnswerList.Count > 0)
            {
                CrysAcc.SecurityAnswer.Data securityAnswer = accData.SecurityAnswerList[0] as CrysAcc.SecurityAnswer.Data;
                accDto.SecurityAnswer = new SecurityAnswer.Dto
                {
                    Id = securityAnswer.Id,
                    Answer = securityAnswer.Answer,
                };
                if (securityAnswer.Question != null)
                {
                    accDto.SecurityAnswer.SecurityQuestion = new Table
                    {
                        Id = securityAnswer.Question.Id,
                        Name = securityAnswer.Question.Question,
                    };
                }
            }
            if (accData.LoginInfo != null)
            {
                accDto.LoginInfo = new LoginHistory.Dto
                {
                    Id = accData.LoginInfo.Id,
                };
            }
            if (accData.LoginHistory != null)
            {
                accDto.LoginHistory = new List<LoginHistory.Dto>();
                foreach (CrysAcc.LoginHistory.Data loginHistroy in accData.LoginHistory)
                {
                    accDto.LoginHistory.Add(new LoginHistory.Dto
                    {
                        Id = loginHistroy.Id,
                        LoginStamp = loginHistroy.LoginStamp,
                        LogoutStamp = loginHistroy.LogoutStamp,
                    });
                }
            }
            return accDto;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Account.Dto accountDto = dto as Account.Dto;
            CrysAcc.Data accountData = new CrysAcc.Data
            {
                Id = accountDto.Id,
                LoginId = accountDto.LoginId,
                Password = accountDto.Password,
                
            };
            if (accountDto.Profile != null)
            {
                accountData.Profile = new Profile.Server(new Profile.FormDto
                {
                    Dto = accountDto.Profile,
                }).Convert(accountDto.Profile) as CrysAcc.Profile.Data;
            }
            if (accountDto.RoleList != null && accountDto.RoleList.Count > 0)
            {
                accountData.RoleList = new List<BinAff.Core.Data>();
                foreach (Role.Dto role in accountDto.RoleList)
                {
                    accountData.RoleList.Add(new CrysRole.Data
                    {
                        Id = role.Id,
                        Name = role.Name,
                    });
                }
            }
            if (accountDto.SecurityAnswer != null)
            {
                accountData.SecurityAnswerList = new List<Data>();
                CrysAcc.SecurityAnswer.Data secAns = new CrysAcc.SecurityAnswer.Data
                {
                    Id = accountDto.SecurityAnswer.Id,
                    Answer = accountDto.SecurityAnswer.Answer,
                };
                accountData.SecurityAnswerList.Add(secAns);
                if (accountDto.SecurityAnswer.SecurityQuestion != null)
                {
                    secAns.Question = new CrysSecQ.Data
                    {
                        Id = accountDto.SecurityAnswer.SecurityQuestion.Id,
                        Question = accountDto.SecurityAnswer.SecurityQuestion.Name,
                    };
                }
            }
            if (accountDto.LoginInfo != null)
            {
                accountData.LoginInfo = new CrysAcc.LoginHistory.Data
                {
                    Id = accountDto.LoginInfo.Id,
                };
            }
            return accountData;
        }

        public List<Account.Dto> Convert(List<Data> dataList)
        {
            if (this.FormDto == null)
            {
                this.FormDto = new FormDto();
            }
            List<Account.Dto> dtoList = new List<Account.Dto>();
            foreach (Data data in dataList)
            {
                (this.FormDto as FormDto).Dto = new Account.Dto
                {
                    Profile = new Profile.Dto
                    {
                        Initial = new Table(),
                        ContactNumberList = new List<Table>(),
                    },
                    LoginHistory = new List<LoginHistory.Dto>(),
                };
                dtoList.Add(this.Convert(data) as Account.Dto);
            }
            return dtoList;
        }

        public override void Add()
        {
            //Dto dto = ((FormDto)this.FormDto).Dto;
            //CrysAcc.Data data = new CrysAcc.Data
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

            ReturnObject<Boolean> ret = (new CrysAcc.Server(this.Convert(((FormDto)this.FormDto).Dto) as CrysAcc.Data) as ICrud).Save();
            
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Delete()
        {
            Dto dto = ((FormDto)this.FormDto).Dto;
            CrysAcc.Data data = this.Convert(dto) as CrysAcc.Data;
            ReturnObject<Boolean> ret = (new CrysAcc.Server(data) as ICrud).Delete();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public void Login()
        {
            Dto dto = ((FormDto)this.FormDto).Dto;
            CrysAcc.Data data = this.Convert(dto) as CrysAcc.Data;
            ReturnObject<BinAff.Core.Data> ret = (new CrysAcc.Server(data) as CrysAcc.IUser).Login();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                (this.FormDto as FormDto).Dto = this.Convert(ret.Value) as Account.Dto;
            }
        }

        public void Logout()
        {
            if (BinAff.Facade.Cache.Server.Current.Cache["User"] != null)
            {
                Dto dto = BinAff.Facade.Cache.Server.Current.Cache["User"] as Dto;
                CrysAcc.Data data = this.Convert(dto) as CrysAcc.Data;
                ReturnObject<Boolean> ret = (new CrysAcc.Server(data) as CrysAcc.IUser).Logout();
                if (this.IsError = ret.HasError())
                {
                    this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
                }
                BinAff.Facade.Cache.Server.Current.Cache.RemoveAll();
            }
        }

        public void ChangeRoleAndLoginId()
        {
            Dto dto = ((FormDto)this.FormDto).Dto;
            CrysAcc.Data data = this.Convert(dto) as CrysAcc.Data;
            ReturnObject<Boolean> ret = (new CrysAcc.Server(data) as CrysAcc.IUser).ChangeRole();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            ret = (new CrysAcc.Server(data) as CrysAcc.IUser).ChangeLoginId();
            this.DisplayMessageList.AddRange(ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information));
        }

        public void ResetPassword()
        {
            Dto dto = ((FormDto)this.FormDto).Dto;
            CrysAcc.Data data = this.Convert(dto) as CrysAcc.Data;
            ReturnObject<Boolean> ret = (new CrysAcc.Server(data) as CrysAcc.IUser).ChangePassword();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

    }

}
