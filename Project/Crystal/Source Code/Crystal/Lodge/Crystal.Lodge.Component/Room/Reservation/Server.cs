using System.Collections.Generic;

using BinAff.Core;
using System;
using BinAff.Core.Observer;
using System.Transactions;

namespace Crystal.Lodge.Component.Room.Reservation
{

    public class Server : Crystal.Reservation.Component.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Room reservation";
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

            base.AddChildren(new Room.Server(null)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            }, ((Data)base.Data).ProductList);
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Following Reservations has this dependency: ";
                //Show max 4
                //for (Int16 i = 0; i < (count > 4 ? 4 : count); i++)
                //{
                //    msg += dataList[i].Number;
                //    if (i < 3 && i < count - 1) msg += ", ";
                //}
                //if (count > 4) msg += ",...";
                //ret.MessageList = new List<Message>
                //{
                //    new Message(msg, Message.Type.Error)
                //};
            }
            else
            {
                ret.Value = true;
            }
            return ret;
        }

        protected override String GetProductType()
        {
            return "Crystal.Lodge.Component.Room.Data";
        }

        protected override String GetMessage(Customer.Component.Action.Data data)
        {
            Data d = data as Data;            
            return "Room has reservation from " + d.Date.ToShortDateString() + " till " + d.Date.AddDays(d.NoOfDays).ToShortDateString();
        }

        public override ReturnObject<Boolean> ChangeReservationToOccupied()
        {
            return new Dao((Data)this.Data).ModifyReservationToOccupied();
        }

        public Int64 ReadReservationId(Int64 ArtifactId)
        {
            return new Dao((Data)this.Data).ReadReservationId(ArtifactId);
        }

    }

}
