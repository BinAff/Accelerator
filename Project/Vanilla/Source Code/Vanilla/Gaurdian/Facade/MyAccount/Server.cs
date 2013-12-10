using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysInitial = Crystal.Configuration.Component.Initial;
using CrysSecQ = Crystal.Guardian.Component.SecurityQuestion;
using CrysAcc = Crystal.Guardian.Component.Account;
using CrysProfile = Crystal.Guardian.Component.Account.Profile;

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
            if(accountData.Profile != null)
            {
                accountDto.Profile = new Profile.Server(new Profile.FormDto
                {
                    Dto = accountDto.Profile
                }).Convert(accountData.Profile as CrysProfile.Data) as Profile.Dto;
            }
            if (accountData.SecurityAnswerList != null && accountData.SecurityAnswerList.Count > 0)
            {
                accountDto.SecurityAnswer = new SecurityAnswer.Dto();
                this.Convert(accountDto.SecurityAnswer, accountData.SecurityAnswerList[0] as CrysAcc.SecurityAnswer.Data);
            }            
            return accountDto;
        }

        private BinAff.Facade.Library.Dto Convert(SecurityAnswer.Dto secDto, CrysAcc.SecurityAnswer.Data secData)
        {
            secDto.Id = secData.Id;
            secDto.Answer = secData.Answer;
            secDto.SecurityQuestion = new Table();
            if (secData.Question != null)
            {
                secDto.SecurityQuestion.Id = secData.Question.Id;
                secDto.SecurityQuestion.Name = secData.Question.Question;
            };
            return secDto;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            CrysAcc.Data accountData = new CrysAcc.Data();
            Dto accountDto = dto as Dto;

            accountData.Id = accountDto.Id;

            //Attach Login Id, since it is not present in screen
            accountData.LoginId = (BinAff.Facade.Cache.Server.Current.Cache["User"] as Account.Dto).LoginId;
            accountData.Password = (String.IsNullOrEmpty(accountDto.Password)) ? 
                (BinAff.Facade.Cache.Server.Current.Cache["User"] as Account.Dto).Password :
                accountDto.Password;
            accountData.Profile = new Profile.Server(new Profile.FormDto
            {
                Dto = accountDto.Profile,
            }).Convert(accountDto.Profile) as CrysProfile.Data;

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

            return accountData;
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
