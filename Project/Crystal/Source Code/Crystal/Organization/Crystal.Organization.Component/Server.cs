using BinAff.Core;
using System;
using System.Collections.Generic;
namespace Crystal.Organization.Component
{
    public class Server : BinAff.Core.Observer.ObserverSubjectCrud
    {
        public Server(Data data)
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            this.Name = "Organization";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
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

            base.AddChildren(new ContactNumber.Server(null)
            {
                Type = ChildType.Dependent,
            }, ((Data)base.Data).ContactNumberList);

            base.AddChildren(new Email.Server(null)
            {
                Type = ChildType.Dependent,
            }, ((Data)base.Data).EmailList);

            base.AddChildren(new Fax.Server(null)
            {
                Type = ChildType.Dependent,
            }, ((Data)base.Data).FaxList);
           
        }

        //protected override ReturnObject<Boolean> DeleteBefore()
        //{
        //    BinAff.Core.Observer.ISubject organization = this;
        //    organization.RegisterObserver(new Crystal.l.Component.Room.CheckIn.Server(null));
         
        //    return new ReturnObject<Boolean> { Value = true };
        //}

        protected override ReturnObject<bool> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            { 
                case "Crystal.Configuration.Component.State.Data":
                    return IsStateDeletable((Configuration.Component.State.Data)subject);
                default:
                    return new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
        }

        private ReturnObject<Boolean> IsStateDeletable(Configuration.Component.State.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsStateDeletable(subject));
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Following organizations has this dependency: ";
                //Show max 4
                for (Int16 i = 0; i < (count > 4 ? 4 : count); i++)
                {
                    msg += dataList[i].Name;
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
