using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;

using ActivityCrys = Crystal.Activity.Component;
using ActionCrys = Crystal.Customer.Component.Action;
using RoomRsvCrys = Retinue.Lodge.Component.Room.Reservation;
using InvCrys = Crystal.Accountant.Component.Invoice;
using ArtfCrys = Crystal.Navigator.Component.Artifact;

namespace Retinue.Lodge.Component.Room.CheckIn
{

    public class Server : Crystal.Activity.Component.Server, ICheckIn
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
            base.AddChild(new InvCrys.Server((this.Data as Data).Invoice)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        protected override ReturnObject<Boolean> IsDependedDeletable(BinAff.Core.Data subject)
        {
            return (subject is Retinue.Lodge.Component.Room.Reservation.Data) ?
                base.MakeReturnObject((this.DataAccess as Dao).IsReservationDeletable(subject as RoomRsvCrys.Data)) :
                new ReturnObject<Boolean>
                {
                    MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                };
        }

        protected override System.Type GetProductType()
        {
            return typeof(Retinue.Lodge.Component.Room.Data);
        }

        protected override String GetMessage(ActionCrys.Data data )
        {
            Data d = data as Data;
            Navigator.Artifact.Data artf = new Navigator.Artifact.Data
            {
                ComponentData = d,
            };
            (new Navigator.Artifact.Server(artf) as ArtfCrys.IArtifact).ReadForComponent();
            return String.Format(" Room is already checked in from {0} to {1}. Depended form path: {2}.",
                d.Date.ToShortDateString(),
                d.Date.AddDays(d.Reservation.NoOfDays).ToShortDateString(),
                artf.FullPath);
        }

        //call reservation component and save the Reservation status to CheckIn
        protected override ReturnObject<Boolean> CreateAfter()
        {
            return (new RoomRsvCrys.Server((this.Data as Data).Reservation) as ActionCrys.IAction).UpdateStatus();            
        }

        //protected override ReturnObject<BinAff.Core.Data> ReadAfter()
        //{
        //    //(this.DataAccess as Dao).UpdateExtraRoomDetails();
        //    return new ReturnObject<BinAff.Core.Data>
        //    {
        //        Value = this.Data,
        //    };
        //}

        ReturnObject<Boolean> ICheckIn.LinkInvoice()
        {
            Boolean status = (this.DataAccess as Dao).LinkInvoice();
            return status ?
                new ReturnObject<Boolean>
                {
                    Value = true,
                } :
                new ReturnObject<Boolean>
                {
                    MessageList = new List<Message>
                    {
                        new Message("Unable to link invoice.", Message.Type.Error),
                    },
                };
        }

        ReturnObject<Boolean> ICheckIn.CheckOut()
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            using (TransactionScope t = new TransactionScope())
            {
                Data data = this.Data as Data;
                ret = (new RoomRsvCrys.Server(data.Reservation) as ICrud).Save();
                if (ret.Value)
                {
                    ret = (this as ActivityCrys.IActivity).Complete();
                    if (ret.Value) t.Complete();
                }
            }
            return ret;
        }

        public Int64 ReadCheckInId(Int64 artifactId)
        {
            return new Dao(this.Data as Data).ReadCheckInId(artifactId);
        }

        protected override ReturnObject<Boolean> DeleteAfter()
        {
            return (new RoomRsvCrys.Server(new RoomRsvCrys.Data
            {
                Id = (this.Data as Data).Reservation.Id,
                Status = new ActionCrys.Status.Data
                {
                    Id = 10001 // To make the reservation open
                },
            }) as ActionCrys.IAction).UpdateStatus();
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