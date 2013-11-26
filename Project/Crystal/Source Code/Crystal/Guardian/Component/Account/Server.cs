using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Guardian.Component.Account
{

    public class Server : Crud, IUser
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "User";
            this.Validator = new Validator((Data)this.Data);
            this.DataAccess = new Dao((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

        protected override void CreateChildren()
        {
            base.AddChildren(new Role.Server(null)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            }, ((Data)base.Data).RoleList);

            base.AddChild(new Profile.Server(((Data)Data).Profile)
            {
                Type = ChildType.Dependent,
            });

            base.AddChildren(new SecurityAnswer.Server(null)
            {
                Type = ChildType.Dependent,
            }, ((Data)base.Data).SecurityAnswerList);

            

            #region 1
            //if (((Data)Data).Roles != null && ((Data)this.Data).Roles.Count > 0)
            //{
            //    foreach (Role.Data role in ((Data)this.Data).Roles)
            //    {
            //        base.AddChild(new Crystal.UserManagement.Role.Server(role)
            //        {
            //            Type = ChildType.Independent,
            //            IsReadOnly = true,
            //        });
            //    }
            //}
            //base.AddChild(new Crystal.UserManagement.User.Profile.Server(((Data)Data).Profile)
            //{
            //    Type = ChildType.Dependent,
            //});
            //if (((Data)Data).SecurityAnswers != null && ((Data)Data).SecurityAnswers.Count > 0)
            //{
            //    foreach (SecurityAnswer.Data ans in ((Data)Data).SecurityAnswers)
            //    {
            //        base.AddChild(new Crystal.UserManagement.User.SecurityAnswer.Server(ans)
            //        {
            //            Type = ChildType.Dependent,
            //        });
            //    }
            //}
            //else //This is for read, delete
            //{
            //    base.AddChild(new Crystal.UserManagement.User.SecurityAnswer.Server(null)
            //    {
            //        Type = ChildType.Dependent,
            //    });
            //}
            //if (((Data)Data).ProfileContactNumber != null && ((Data)Data).ProfileContactNumber.Count > 0)
            //{
            //    foreach (ProfileContactNumber.Data ans in ((Data)Data).ProfileContactNumber)
            //    {
            //        base.AddChild(new Crystal.UserManagement.User.ProfileContactNumber.Server(ans)
            //        {
            //            Type = ChildType.Dependent,
            //        });
            //    }
            //}
            //else //This is for read, delete
            //{
            //    base.AddChild(new Crystal.UserManagement.User.ProfileContactNumber.Server(null)
            //    {
            //        Type = ChildType.Dependent,
            //    });
            //}
            #endregion

            #region 2
            //if (((Data)base.Data).Roles != null && ((Data)base.Data).Roles.Count > 0)
            //{
            //    List<BinAff.Core.Data> roleList = new List<BinAff.Core.Data>();
            //    foreach (BinAff.Core.Data data in ((Data)base.Data).Roles)
            //    {
            //        roleList.Add(data);
            //    }
            //    base.AddChildren(new Crystal.UserManagement.Role.Server(null)
            //    {
            //        Type = ChildType.Independent,
            //        IsReadOnly = true,
            //    }, roleList);
            //}

            //base.AddChild(new Crystal.UserManagement.User.Profile.Server(((Data)Data).Profile)
            //{
            //    Type = ChildType.Dependent,
            //});

            //if (((Data)base.Data).SecurityAnswers != null && ((Data)base.Data).SecurityAnswers.Count > 0)
            //{
            //    List<BinAff.Core.Data> securityAnswersList = new List<BinAff.Core.Data>();
            //    foreach (BinAff.Core.Data data in ((Data)base.Data).SecurityAnswers)
            //    {
            //        securityAnswersList.Add(data);
            //    }
            //    base.AddChildren(new Crystal.UserManagement.User.SecurityAnswer.Server(null)
            //    {
            //        Type = ChildType.Dependent,
            //    }, securityAnswersList);
            //}

            //if (((Data)base.Data).ProfileContactNumber != null && ((Data)base.Data).ProfileContactNumber.Count > 0)
            //{
            //    List<BinAff.Core.Data> profileContactNumber = new List<BinAff.Core.Data>();
            //    foreach (BinAff.Core.Data data in ((Data)base.Data).ProfileContactNumber)
            //    {
            //        profileContactNumber.Add(data);
            //    }
            //    base.AddChildren(new Crystal.UserManagement.User.ProfileContactNumber.Server(null)
            //    {
            //        Type = ChildType.Dependent,
            //    }, profileContactNumber);

            //}
            #endregion
        }

        #region IUser

        void IUser.Logout()
        {
            throw new System.Exception("Not implemented");
        }

        ReturnObject<BinAff.Core.Data> IUser.Login()
        {
            String pswd = ((Data)this.Data).Password;
            ((Dao)this.DataAccess).GetUserByLoginId();
            if (this.Data.Id == 0 || pswd != ((Data)this.Data).Password)
            {
                return new BinAff.Core.ReturnObject<BinAff.Core.Data>
                {
                    MessageList = new List<BinAff.Core.Message>
                    { 
                        new BinAff.Core.Message("Wrong user name or password!!", BinAff.Core.Message.Type.Error) 
                    }
                };
            }

            return this.Read();
        }

        ReturnObject<Boolean> IUser.ChangePassword()
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>
            {
                Value = new Dao((Data)this.Data).ChangePassword()
            };
            ret.MessageList = ret.Value ? new List<Message> 
            { 
                new Message 
                {
                    Category = Message.Type.Information,
                    Description = "Password reset."
                }
            } :
            new List<Message> 
            { 
                new Message 
                {
                    Category = Message.Type.Error,
                    Description = "Password not reset."
                }                
            };
            return ret;
        }

        ReturnObject<Boolean> IUser.ChangeRole()
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>
            {
                Value = new Dao((Data)this.Data).ChangeRoles()
            };
            ret.MessageList = ret.Value ? new List<Message> 
            { 
                new Message 
                {
                    Category = Message.Type.Information,
                    Description = "User roles changed."
                }
            } :
            new List<Message> 
            { 
                new Message 
                {
                    Category = Message.Type.Error,
                    Description = "Unable to change user roles."
                }                
            };
            return ret;
        }

        #endregion

        //protected override ReturnObject<List<BinAff.Core.Data>> ReadAll()
        //{
        //    //ReturnObject<List<BinAff.Core.Data>> lstData = new ReturnObject<List<BinAff.Core.Data>>();
        //    //List<BinAff.Core.Data> data = new List<BinAff.Core.Data>();

        //    //Dao dao = new Dao(new Data());
        //    //data = dao.ReadAll();

        //    //lstData.Value = data;
        //    //return lstData;

        //    ReturnObject<List<BinAff.Core.Data>> retList = new ReturnObject<List<BinAff.Core.Data>>
        //    {
        //        Value = ((Dao)this.DataAccess).ReadAll()
        //    };

        //    foreach (BinAff.Core.Data data in retList.Value)
        //    {
        //        ICrud crud = new Server((Data)data);
        //        crud.Read();
        //    }
        //    return retList;
        //}

    }

}
