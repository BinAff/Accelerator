using System.Collections.Generic;

using BinAff.Core;
using System;
using System.Transactions;

namespace Retinue.Lodge.Component.Room
{

    public class Server : Crystal.Product.Component.Server, IRoom
    {

        private const Int64 OPEN = 10001;
        private const Int64 CLOSE = 10002;

        public Server(Data data)
            : base(data)
        {

        }

        #region IRoom

        ReturnObject<Boolean> IRoom.Open()
        {
            return this.Open();
        }

        ReturnObject<Boolean> IRoom.Close()
        {
            return this.Close();
        }

        List<Data> IRoom.GetCheckedInRoomsForBuilding()
        {
            return this.GetAllCheckedInRoomsForBuilding();
        }

        List<Data> IRoom.GetBookedRoomsForBuilding()
        {
            return this.GetReservedRoomsForBuilding();
        }

        List<Data> IRoom.GetOpenRoomsForBuilding()
        {
            return this.GetOpenRoomsForBuilding();
        }

        List<Data> IRoom.GetCloseRoomsForBuilding()
        {
            return this.GetCloseRoomsForBuilding();
        }

        #endregion

        protected override void Compose()
        {
            this.Name = "Room";
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

            base.AddChild(new Category.Server((this.Data as Data).Category)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChildren(new ClosureReason.Server(null)
            {
                Type = ChildType.Dependent,
                IsReadOnly = true,
            }, (this.Data as Data).ClosureReasonList);
            base.AddChildren(new Image.Server(null)
            {
                Type = ChildType.Dependent,
            }, (this.Data as Data).ImageList);
            base.AddChild(new Status.Server((this.Data as Data).Status)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Type.Server((this.Data as Data).Type)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Building.Floor.Server((this.Data as Data).Floor)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Building.Server((this.Data as Data).Building)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }
               
        private ReturnObject<Boolean> Close()
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>
            {
                MessageList = new List<Message>()
            };

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                ICrud crud = new Room.ClosureReason.Server(new Room.ClosureReason.Data
                {
                    Reason = ((this.Data as Data).ClosureReasonList[0] as Room.ClosureReason.Data).Reason
                })
                {
                    ParentData = this.Data,
                };
                ReturnObject<Boolean> ret = crud.Save();
                if (ret.Value) retObj.Value = (this.DataAccess as Dao).ModifyStatus(CLOSE);
                retObj.MessageList.Add(retObj.Value ?
                    new Message("Room is closed successfully.", Message.Type.Information) :
                    new Message("Error to closing room.", Message.Type.Error));

                if (retObj.Value) T.Complete();
            }
            return retObj;
        }

        private ReturnObject<Boolean> Open()
        {  
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>
            {
                Value = (this.DataAccess as Dao).ModifyStatus(OPEN),
                MessageList = new List<Message>()
            };
            retObj.MessageList.Add(retObj.Value ?
                    new Message("Room is open successfully.", Message.Type.Information) :
                    new Message("Error to opening room.", Message.Type.Error));
            return retObj;
        }

        private List<Data> GetAllCheckedInRoomsForBuilding()
        {
            return (this.DataAccess as Dao).GetAllCheckedInRoomsForBuilding();
        }

        private List<Data> GetReservedRoomsForBuilding()
        {
            return (this.DataAccess as Dao).GetReservedRoomsForBuilding();
        }

        private List<Data> GetOpenRoomsForBuilding()
        {
            return (this.DataAccess as Dao).GetOpenRoomsForBuilding();
        }

        private List<Data> GetCloseRoomsForBuilding()
        {
            return (this.DataAccess as Dao).GetCloseRoomsForBuilding();
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            {
                case "Retinue.Lodge.Component.Building.Data":
                    return this.IsBuildingDeletable((Retinue.Lodge.Component.Building.Data)subject);
                case "Retinue.Lodge.Component.Room.Category.Data":
                    return this.IsRoomCategoryDeletable((Retinue.Lodge.Component.Room.Category.Data)subject);
                case "Retinue.Lodge.Component.Room.Type.Data":
                    return this.IsRoomTypeDeletable((Retinue.Lodge.Component.Room.Type.Data)subject);
                case "Retinue.Lodge.Component.Room.Status.Data":
                    return this.IsRoomStatusDeletable((Retinue.Lodge.Component.Room.Status.Data)subject);
                case "Retinue.Lodge.Component.Building.Floor.Data":
                    return this.IsBuildingFloorDeletable((Retinue.Lodge.Component.Building.Floor.Data)subject);

                default:
                    return new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
        }

        private ReturnObject<Boolean> IsBuildingDeletable(Building.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsBuildingDeletable(subject));
        }

        private ReturnObject<Boolean> IsRoomCategoryDeletable(Category.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsRoomCategoryDeletable(subject));
        }

        private ReturnObject<Boolean> IsRoomTypeDeletable(Type.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsRoomTypeDeletable(subject));
        }

        private ReturnObject<Boolean> IsRoomStatusDeletable(Status.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsRoomStatusDeletable(subject));
        }

        private ReturnObject<Boolean> IsBuildingFloorDeletable(Building.Floor.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsBuildingFloorDeletable(subject));
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

        private String GetMessage(Data data)
        {
            return "Room " + data.Name + " has dependency.";
        }

        //protected override ReturnObject<Boolean> DeleteBefore()
        //{
        //    BinAff.Core.Observer.ISubject room = this;
        //    room.RegisterObserver(new Retinue.Lodge.Component.Room.CheckIn.Server(null));
        //    room.RegisterObserver(new Retinue.Lodge.Component.Room.Reservation.Server(null));
        //    room.RegisterObserver(new Retinue.Lodge.Component.Room.Tariff.Server(null));

        //    return new ReturnObject<Boolean> { Value = true };
        //}

    }

}