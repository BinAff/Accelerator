using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysAcc = Crystal.Guardian.Component.Account;

namespace Vanilla.Guardian.Facade.UserRegister
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

            ReturnObject<List<Data>> ret = (new CrysAcc.Server(null)
            {
                IsLoginHistoryIncluded = true,
            } as ICrud).ReadAll();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError())? Message.Type.Error : Message.Type.Information);
            if (!this.IsError)
            {
                (this.FormDto as FormDto).DtoList = new Account.Server(null).Convert(ret.Value);
            }
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            return new Account.Server(new Account.FormDto
            {
                Dto = new Account.Dto
                {
                    Profile = new Profile.Dto
                    {
                        Initial = new Table(),
                        ContactNumberList = new List<Table>(),
                    },
                },
            }).Convert(data);
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            return new Account.Server(null).Convert(dto);
        }

        public override void Change()
        {
            Account.Server accFacade = new Account.Server(new Account.FormDto
            {
                Dto = new Account.Dto
                {
                    Id = (this.FormDto as FormDto).Dto.Id,
                    LoginId = (this.FormDto as FormDto).Dto.LoginId,
                    RoleList = (this.FormDto as FormDto).Dto.RoleList,
                }
            });
            accFacade.ChangeRoleAndLoginId();
            this.IsError = accFacade.IsError;
            this.DisplayMessageList = accFacade.DisplayMessageList;
        }

        public override void Delete()
        {
            Account.Server accFacade = new Account.Server(new Account.FormDto
            {
                Dto = new Account.Dto
                {
                    Id = (this.FormDto as FormDto).Dto.Id,
                }
            });
            accFacade.Delete();
            this.IsError = accFacade.IsError;
            this.DisplayMessageList = accFacade.DisplayMessageList;
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

        public List<Account.Dto> Convert(List<Data> dataList)
        {
            List<Account.Dto> dtoList = new List<Account.Dto>();
            foreach (Data data in dataList)
            {
                dtoList.Add(this.Convert(data) as Account.Dto);
            }
            return dtoList;
        }

        public void ResetPassword()
        {
            Account.Server accFacade = new Account.Server(new Account.FormDto
            {
                Dto = new Account.Dto
                {
                    Id = (this.FormDto as FormDto).Dto.Id,
                    Password = (this.FormDto as FormDto).Rule.DefaultPassword,
                }
            });
            accFacade.ResetPassword();
            this.IsError = accFacade.IsError;
            this.DisplayMessageList = accFacade.DisplayMessageList;
        }

    }

}