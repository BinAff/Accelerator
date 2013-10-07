using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Guardian.Component.Account.SecurityAnswer
{

    public class Server : ObserverCrud, ISecurityAnswer
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "User Security Answer";
            this.Validator = new Validator((Data)this.Data);
            this.DataAccess = new Dao((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

        protected override void CreateChildren()
        {
            base.AddChild(new SecurityQuestion.Server(((Data)this.Data).Question)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        ReturnObject<BinAff.Core.Data> ISecurityAnswer.GetLoggedInUserSecurityAnswer()
        {
            ReturnObject<BinAff.Core.Data> retVal = new ReturnObject<BinAff.Core.Data>();
            BinAff.Core.Data data = new Dao((Data)this.Data).GetLoggedInUserSecurityAnswer("ReadSecurityAnswerForLoggenInUser");
            retVal.Value = data;
            return retVal;            
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            {
                case "Crystal.UserManagement.SecurityQuestion.Data":
                    return IsSecurityQuestionDeletable((SecurityQuestion.Data)subject);
                default:
                    return new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
        }

        private ReturnObject<Boolean> IsSecurityQuestionDeletable(SecurityQuestion.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsSecurityQuestionDeletable(subject));
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Security question has historical data. ";
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
