using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysInitial = Crystal.Configuration.Component.Initial;
using CrysSecQ = Crystal.Guardian.Component.SecurityQuestion;
using CrysAcc = Crystal.Guardian.Component.Account;
using CrysProfile = Crystal.Guardian.Component.Account.Profile;
using CrysRole = Crystal.Guardian.Component.Role;

namespace Vanilla.Guardian.Facade.MyAccount
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            this.LoadInitialList();
            this.LoadSecurityQuestionList();

            CrysAcc.Data account = this.Convert(((FormDto)this.FormDto).Dto) as CrysAcc.Data;
            ReturnObject<Data> ret = (new CrysAcc.Server(account) as ICrud).Read();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            if (!this.IsError) (this.FormDto as FormDto).Dto = this.Convert(ret.Value) as Dto;
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrysAcc.Data accountData = data as CrysAcc.Data;
            Dto accountDto = (this.FormDto as FormDto).Dto;
            if (accountData.Profile != null)
            {
                accountDto.Profile = new Profile.Server(new Profile.FormDto
                {
                    Dto = accountDto.Profile
                }).Convert(accountData.Profile as CrysProfile.Data) as Profile.Dto;
            }
            if (accountData.SecurityAnswerList != null && accountData.SecurityAnswerList.Count > 0)
            {
                accountDto.SecurityAnswer = new SecurityAnswer.Dto();
                //Taking one security Answer
                this.Convert(accountDto.SecurityAnswer, accountData.SecurityAnswerList[0] as CrysAcc.SecurityAnswer.Data);
            }
            return accountDto;
        }

        private BinAff.Facade.Library.Dto Convert(SecurityAnswer.Dto secDto, CrysAcc.SecurityAnswer.Data secData)
        {
            secDto.Id = secData.Id;
            secDto.Answer = secData.Answer;
            if (secData.Question != null)
            {
                secDto.SecurityQuestion = new Table
                {
                    Id = secData.Question.Id,
                    Name = secData.Question.Question,
                };
            };
            return secDto;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            CrysAcc.Data accData = new CrysAcc.Data();
            Dto accDto = dto as Dto;

            accData.Id = accDto.Id;

            //Attach Login Id, Password(if not entered) and role list; since it is not present in screen
            Account.Dto currentUser = BinAff.Facade.Cache.Server.Current.Cache["User"] as Account.Dto;
            accData.LoginId = currentUser.LoginId;
            accData.Password = (String.IsNullOrEmpty(accDto.Password)) ?
                currentUser.Password : accDto.Password;
            accData.RoleList = new List<Data>();
            foreach (Role.Dto role in currentUser.RoleList)
            {
                accData.RoleList.Add(new CrysRole.Data
                {
                    Id = role.Id,
                    Name = role.Name,
                });
            }

            accData.Profile = new Profile.Server(new Profile.FormDto
            {
                Dto = accDto.Profile,
            }).Convert(accDto.Profile) as CrysProfile.Data;

            if (accDto.SecurityAnswer != null)
            {
                accData.SecurityAnswerList = new List<Data>();
                CrysAcc.SecurityAnswer.Data secAns = new CrysAcc.SecurityAnswer.Data
                {
                    Id = accDto.SecurityAnswer.Id,
                    Answer = accDto.SecurityAnswer.Answer,
                };
                accData.SecurityAnswerList.Add(secAns);
                if (accDto.SecurityAnswer.SecurityQuestion != null)
                {
                    secAns.Question = new CrysSecQ.Data
                    {
                        Id = accDto.SecurityAnswer.SecurityQuestion.Id,
                        Question = accDto.SecurityAnswer.SecurityQuestion.Name,
                    };
                }
            }

            return accData;
        }

        public override void Change()
        {
            CrysAcc.Data account = this.Convert(((FormDto)this.FormDto).Dto) as CrysAcc.Data;
            ReturnObject<Boolean> ret = (new CrysAcc.Server(account) as ICrud).Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        private void LoadInitialList()
        {
            ICrud component = new CrysInitial.Server(null);
            ReturnObject<List<Data>> ret = component.ReadAll();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                if (ret.Value != null && ret.Value.Count > 0)
                {
                    (this.FormDto as FormDto).InitialList = new List<Table>();
                    foreach (CrysInitial.Data data in ret.Value)
                    {
                        (this.FormDto as FormDto).InitialList.Add(new Table
                        {
                            Id = data.Id,
                            Name = data.Name,
                        });
                    }
                }
            }
        }

        private void LoadSecurityQuestionList()
        {
            ICrud component = new CrysSecQ.Server(null);
            ReturnObject<List<Data>> ret = component.ReadAll();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                if (ret.Value != null && ret.Value.Count > 0)
                {
                    (this.FormDto as FormDto).SecurityQuestionList = new List<Table>();
                    foreach (CrysSecQ.Data data in ret.Value)
                    {
                        (this.FormDto as FormDto).SecurityQuestionList.Add(new Table
                        {
                            Id = data.Id,
                            Name = data.Question,
                        });
                    }
                }
            }
        }

    }

}
