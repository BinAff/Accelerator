using System;
using System.Collections.Generic;
using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Customer.Component
{

    public abstract class Server : Crystal.Navigator.Component.Artifact.Observer.DocumentComponent, ICustomer
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Customer";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

        protected override void CreateChildren()
        {
            //base.AddChild(new Crystal.Configuration.Component.Initial.Server(((Data)Data).Initial)
            //{
            //    Type = ChildType.Independent,
            //    IsReadOnly = true,
            //});

            base.AddChild(new Crystal.Configuration.Component.State.Server(((Data)Data).State)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });

            base.AddChild(new Crystal.Configuration.Component.IdentityProofType.Server(((Data)Data).IdentityProofType)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        //will implement the below method during checkin or reservation module integration
        //protected override ReturnObject<Boolean> DeleteBefore()
        //{
            //If there is any characteristics attached with customer, it cannot be deleted
            //if ((this.Data as Data).CharacteristicList != null && (this.Data as Data).CharacteristicList.Count == 0)
            //    return new ReturnObject<Boolean> { Value = true, };

            //if ((this.Data as Data).CharacteristicList != null && (this.Data as Data).CharacteristicList.Count > 0)
            //{
            //    foreach (Characteristic.Data data in (this.Data as Data).CharacteristicList)
            //    {
            //        if (data.AllList != null && data.AllList.Count > 0)
            //        {
            //            return new ReturnObject<Boolean>
            //            {
            //                MessageList = new List<Message>
            //                {
            //                    new Message("Customer has some transactions. Cannot be deleted.", Message.Type.Error),
            //                },
            //            };
            //        }
            //    }
            //}

            //return new ReturnObject<Boolean>
            //{
            //    MessageList = GenerateMessageForDependency(),
            //};
        //}

        protected virtual List<Message> GenerateMessageForDependency()
        {
            throw new NotImplementedException();
        }
        
        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            {
                case "Crystal.Configuration.Component.Initial.Data":
                    return IsInitialDeletable((Configuration.Component.Initial.Data)subject);
                case "Crystal.Configuration.Component.IdentityProofType.Data":
                    return IsIdentityProofTypeDeletable((Configuration.Component.IdentityProofType.Data)subject);
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

        private ReturnObject<Boolean> IsIdentityProofTypeDeletable(Configuration.Component.IdentityProofType.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsIdentityProofTypeDeletable(subject));
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
                String msg = "Unable to delete. Following customers has this dependency: ";
                //Show max 4
                for (Int16 i = 0; i < (count > 4 ? 4 : count); i++)
                {
                    msg += dataList[i].FirstName + " " + dataList[i].LastName + "(" + dataList[i].ContactNumberList[0].ContactNumber + ")";
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

        ReturnObject<bool> ICustomer.GenerateInvoice()
        {
            return this.GenerateInvoice();            
        }

        protected virtual ReturnObject<bool> GenerateInvoice()
        {
            return new ReturnObject<bool>();
        }

    }

}
