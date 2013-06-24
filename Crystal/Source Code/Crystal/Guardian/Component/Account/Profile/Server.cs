using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;
using BinAff.Core.Observer;

//using Crystal.Extension;

namespace Crystal.Guardian.Component.Account.Profile
{

    /// <summary>
    /// Business class of User Profile 
    /// </summary>
    /// <remarks>
    /// Profile is depended on User component
    /// </remarks>
    public class Server : ObserverCrud
    {

        public Server(Data data)
            :base(data)
        {
            
        }

        protected override void Compose()
        {
            this.Name = "User Profile";
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
            base.CreateChildren();
            base.AddChild(new Crystal.Configuration.Component.Initial.Server(((Data)this.Data).Initial)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });

            base.AddChildren(new Profile.ContactNumber.Server(null)
            {
                Type = ChildType.Dependent,
            }, ((Data)base.Data).ContactNumberList);
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            {
                case "Crystal.Configuration.Initial.Data":
                    return IsInitialDeletable((Crystal.Configuration.Component.Initial.Data)subject);
                //case "Crystal.Configuration.IdentityProofType.Data":
                //    return IsIdentityProofTypeDeletable((Configuration.IdentityProofType.Data)subject);
                //case "Crystal.Configuration.State.Data":
                //    return IsStateDeletable((Configuration.State.Data)subject);
                default:
                    return new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
        }

        private ReturnObject<Boolean> IsInitialDeletable(Configuration.Component.Initial.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsInitialDeletable(subject));
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Following users has this dependency: ";
                //Show max 4
                for (Int16 i = 0; i < (count > 4 ? 4 : count); i++)
                {
                    msg += dataList[i].FirstName + " " + dataList[i].LastName;
                    if (i < 3 && i < count - 1) msg += ", ";
                }
                if (count > 4) msg += ",...";
                ret.MessageList = new List<Message>
                {
                    new Message(msg, Message.Type.Error)
                };
            }
            else
            {
                ret.Value = true;
            }
            return ret;
        }

    }

}
