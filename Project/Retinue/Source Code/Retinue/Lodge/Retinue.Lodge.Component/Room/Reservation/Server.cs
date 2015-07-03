﻿using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Component.Room.Reservation
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

            base.AddChildren(new RoomDetails.Server(null)
            {
                Type = ChildType.Dependent,
            }, (base.Data as Data).ProductList);
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
            return "Retinue.Lodge.Component.Room.Data";
        }

        protected override String GetMessage(Crystal.Customer.Component.Action.Data data)
        {
            Data d = data as Data;            
            return "Room has reservation from " + d.Date.ToShortDateString() + " till " + d.Date.AddDays(d.NoOfDays).ToShortDateString();
        }

        //public override ReturnObject<Boolean> ChangeReservationToOccupied()
        //{
        //    ReturnObject<Boolean> ret = new ReturnObject<bool>
        //    {
        //        Value = new Dao((Data)this.Data).UpdateStatus(),
        //    };
        //    if (!ret.Value)
        //    {
        //        ret.MessageList = new List<Message> { new Message("Unable to update status.", Message.Type.Error) };
        //    }
        //    return ret;
        //}

        public Int64 ReadIdForArtifact(Int64 artifactId)
        {
            return new Dao(this.Data as Data).ReadReservationId(artifactId);
        }

        //protected override ReturnObject<BinAff.Core.Data> ReadAfter()
        //{
        //    (this.DataAccess as Dao).UpdateExtraRoomDetails();
        //    return new ReturnObject<BinAff.Core.Data>
        //    {
        //        Value = this.Data,
        //    };
        //}

        //public ReturnObject<Boolean> RevertReservationAfterCheckIn()
        //{
        //    ReturnObject<Boolean> ret = new ReturnObject<bool>
        //    {
        //        Value = new Dao((Data)this.Data).UpdateStatus(),
        //    };
        //    if (!ret.Value)
        //    {
        //        ret.MessageList = new List<Message> { new Message("Unable to update status.", Message.Type.Error) };
        //    }
        //    return ret;
        //}

    }

}
