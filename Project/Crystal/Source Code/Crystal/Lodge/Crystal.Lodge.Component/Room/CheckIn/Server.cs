using System.Collections.Generic;

using BinAff.Core;
using System;
using BinAff.Core.Observer;
using System.Transactions;

namespace Crystal.Lodge.Component.Room.CheckIn
{

    public class Server : Activity.Component.Server, ICheckIn
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Room checkin";
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

            base.AddChild(new Crystal.Lodge.Component.Room.Reservation.Server(((Data)this.Data).Reservation)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            ReturnObject<Boolean> ret = base.IsSubjectDeletable(subject);
            if (ret.MessageList == null || ret.MessageList.Count == 0)
            {
                ret = (subject.GetType().ToString() == "Crystal.Lodge.Component.Room.Reservation.Data") ?
                IsReservationDeletable((Crystal.Lodge.Component.Room.Reservation.Data)subject) :
                new ReturnObject<Boolean>
                {
                    MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                };
            }
            return ret;
        }

        private ReturnObject<bool> IsReservationDeletable(Crystal.Lodge.Component.Room.Reservation.Data data)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsReservationDeletable(data));
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {  
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Following " + this.Name + " has this dependency: "; 
                foreach (Data data in dataList)               
                    msg += GetMessage(data);                
               
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

        protected override String GetProductType()
        {
            return "Crystal.Lodge.Component.Room.Data";
        }

        protected override String GetMessage(Customer.Component.Action.Data data )
        {
            Data d = data as Data;
            return "Room has reservation from " + d.Date.ToShortDateString() + " till " + d.Date.AddDays(d.Reservation.NoOfDays).ToShortDateString();
        }

        //call reservation component and save the Reservation status to CheckIn
        protected override ReturnObject<bool> CreateAfter()
        {
            Reservation.Server resrevationServer = new Reservation.Server(((Data)this.Data).Reservation);
            return resrevationServer.ChangeReservationToOccupied();            
        }

        ReturnObject<Boolean> ICheckIn.ModifyCheckInStatus(long statusId)
        {            
            return ((Dao)this.dataAccess).ModifyCheckInStatus(statusId);
        }


        ReturnObject<bool> ICheckIn.UpdateInvoiceNumber(string invoiceNumber)
        {
            return ((Dao)this.dataAccess).UpdateInvoiceNumber(invoiceNumber);
        }
    }

}
