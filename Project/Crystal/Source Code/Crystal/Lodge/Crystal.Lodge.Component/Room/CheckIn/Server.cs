using System;
using System.Collections.Generic;

using BinAff.Core;

using RoomRsvCrys = Crystal.Lodge.Component.Room.Reservation;

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
            this.DataAccess = new Dao(this.Data as Data);
            this.Validator = new Validator(this.Data as Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override void CreateChildren()
        {
            base.CreateChildren();

            base.AddChild(new RoomRsvCrys.Server((this.Data as Data).Reservation)
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
                    this.MakeReturnObject((this.DataAccess as Dao).IsReservationDeletable(subject as RoomRsvCrys.Data)) :
                    new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
            return ret;
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {  
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Following " + this.Name + " has this dependency: ";
                foreach (Data data in dataList)
                {
                    msg += GetMessage(data);
                }               
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
        protected override ReturnObject<Boolean> CreateAfter()
        {
            RoomRsvCrys.Server server = new RoomRsvCrys.Server((this.Data as Data).Reservation);
            return server.ChangeReservationToOccupied();            
        }

        ReturnObject<Boolean> ICheckIn.ModifyCheckInStatus(Customer.Component.Action.Status.Data status)
        {            
            return (this.dataAccess as Dao).ModifyCheckInStatus(status);
        }
        
        ReturnObject<Boolean> ICheckIn.UpdateInvoiceNumber(String invoiceNumber)
        {
            return (this.dataAccess as Dao).UpdateInvoiceNumber(invoiceNumber);
        }

        public Int64 ReadCheckInId(Int64 artifactId)
        {
            return new Dao(this.Data as Data).ReadCheckInId(artifactId);
        }

        protected override ReturnObject<Boolean> DeleteAfter()
        {            
            return new RoomRsvCrys.Server(new RoomRsvCrys.Data
            {
                Id = (this.Data as Data).Reservation.Id
            }).RevertReservationAfterCheckIn();
        }

        public ReturnObject<Boolean> IsCheckInDeletable()
        {
            ReturnObject<Boolean> retVal = new ReturnObject<Boolean> 
            { 
                MessageList = new List<Message>()
            };
            ReturnObject<BinAff.Core.Data> retObj = base.Read();

            Data data = retObj.Value as Data;
            if (data.Status.Id == 10002)
            {
                retVal.MessageList.Add(new Message
                {
                    Category = Message.Type.Error,
                    Description = "Checkin is changed to checkout."
                });
            }
            if (DateTime.Compare(data.Date, DateTime.Today) != 0)
            {
                retVal.MessageList.Add(new Message
                {
                    Category = Message.Type.Error,
                    Description = "Checkin is more than a day."
                });
            }
            if (retVal.MessageList != null && retVal.MessageList.Count > 0) retVal.Value = false;

            return retVal;
        }
            
    }

}