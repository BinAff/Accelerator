using System.Collections.Generic;

using BinAff.Core;
using System;
using BinAff.Core.Observer;
using System.Transactions;

namespace Crystal.Lodge.Component.Room
{

    public class Server : Product.Component.Server, IRoom
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

        //ReturnObject<Boolean> IRoom.UpdateRoomStatus()
        //{
        //    return this.UpdateStatus();
        //}

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

            base.AddChild(new Category.Server(((Data)this.Data).Category)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChildren(new ClosureReason.Server(null)
            {
                Type = ChildType.Dependent,
                IsReadOnly = true,
            }, ((Data)base.Data).ClosureReasonList);
            base.AddChildren(new Image.Server(null)
            {
                Type = ChildType.Dependent,
            }, ((Data)base.Data).ImageList);
            base.AddChild(new Status.Server(((Data)this.Data).Status)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Type.Server(((Data)this.Data).Type)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Building.Floor.Server(((Data)this.Data).Floor)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Building.Server(((Data)this.Data).Building)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        //protected override ReturnObject<List<BinAff.Core.Data>> ReadAll()
        //{           
        //    ReturnObject<List<BinAff.Core.Data>> retList = new ReturnObject<List<BinAff.Core.Data>>
        //    {
        //        Value = ((Dao)this.DataAccess).ReadAll()
        //    };

        //    foreach (BinAff.Core.Data data in retList.Value)
        //    {
        //        ICrud crud = new Server((Data)data);
        //        crud.Read();
        //    }

        //    return retList;
        //}
               
        private ReturnObject<Boolean> Close()
        {           

            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = false,
                MessageList = new List<Message>()
            };

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                ICrud crud = new Lodge.Component.Room.ClosureReason.Server(new Lodge.Component.Room.ClosureReason.Data()
                {
                    Reason = ((Lodge.Component.Room.ClosureReason.Data)((Data)this.Data).ClosureReasonList[0]).Reason
                })
                {
                    ParentData = this.Data,
                };
                ReturnObject<Boolean> ret = crud.Save();


                if (ret.Value)
                    retObj.Value = new Dao((Data)this.Data).ModifyStatus(CLOSE);


                if (retObj.Value)
                    retObj.MessageList.Add(new Message()
                    {
                        Category = Message.Type.Information,
                        Description = "Room is closed successfully."
                    });
                else
                    retObj.MessageList.Add(new Message()
                    {
                        Category = Message.Type.Error,
                        Description = "Error to closing room."
                    });


                if (retObj.Value) T.Complete();
            }

            return retObj;
        }

        private ReturnObject<Boolean> Open()
        {  
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = false,
                MessageList = new List<Message>()
            };

            retObj.Value = new Dao((Data)this.Data).ModifyStatus(OPEN);

            if (retObj.Value)
                retObj.MessageList.Add(new Message()
                {
                    Category = Message.Type.Information,
                    Description = "Room is opened successfully."
                });
            else
                retObj.MessageList.Add(new Message()
                {
                    Category = Message.Type.Error,
                    Description = "Error to opening room."
                });

            return retObj;
        }

        //private ReturnObject<Boolean> UpdateStatus()
        //{
        //    Boolean status = new Dao((Data)this.Data).UpdateStatus();
        //    return new ReturnObject<Boolean>()
        //    {
        //        Value = status,
        //        MessageList = new List<Message>
        //        {
        //            status ? new Message
        //            {
        //                Category = Message.Type.Information,
        //                Description = "Room status changed successfully"
        //            }:
        //            new Message
        //            {
        //                Category = Message.Type.Error,
        //                Description = "Error to room status change."
        //            }
        //        }
        //    };
        //}

        private List<Data> GetAllCheckedInRoomsForBuilding()
        {
            return new Dao((Data)this.Data).GetAllCheckedInRoomsForBuilding();
        }

        private List<Data> GetReservedRoomsForBuilding()
        {
            return new Dao((Data)this.Data).GetReservedRoomsForBuilding();
        }

        private List<Data> GetOpenRoomsForBuilding()
        {
            return new Dao((Data)this.Data).GetOpenRoomsForBuilding();
        }

        private List<Data> GetCloseRoomsForBuilding()
        {
            return new Dao((Data)this.Data).GetCloseRoomsForBuilding();
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            {
                case "Crystal.Lodge.Component.Building.Data":
                    return IsBuildingDeletable((Crystal.Lodge.Component.Building.Data)subject);
                case "Crystal.Lodge.Component.Room.Category.Data":
                    return IsRoomCategoryDeletable((Crystal.Lodge.Component.Room.Category.Data)subject);
                case "Crystal.Lodge.Component.Room.Type.Data":
                    return IsRoomTypeDeletable((Crystal.Lodge.Component.Room.Type.Data)subject);
                case "Crystal.Lodge.Component.Room.Status.Data":
                    return IsRoomStatusDeletable((Crystal.Lodge.Component.Room.Status.Data)subject);
                case "Crystal.Lodge.Component.Building.Floor.Data":
                    return IsBuildingFloorDeletable((Crystal.Lodge.Component.Building.Floor.Data)subject);

                default:
                    return new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
        }

        private ReturnObject<Boolean> IsBuildingDeletable(Crystal.Lodge.Component.Building.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsBuildingDeletable(subject));
        }

        private ReturnObject<Boolean> IsRoomCategoryDeletable(Crystal.Lodge.Component.Room.Category.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsRoomCategoryDeletable(subject));
        }

        private ReturnObject<Boolean> IsRoomTypeDeletable(Crystal.Lodge.Component.Room.Type.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsRoomTypeDeletable(subject));
        }

        private ReturnObject<Boolean> IsRoomStatusDeletable(Crystal.Lodge.Component.Room.Status.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsRoomStatusDeletable(subject));
        }

        private ReturnObject<Boolean> IsBuildingFloorDeletable(Crystal.Lodge.Component.Building.Floor.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsBuildingFloorDeletable(subject));
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

        private String GetMessage(Crystal.Lodge.Component.Room.Data data)
        {
            Data d = data as Data;
            return "Room " + data.Name + " has dependency.";
        }

        //protected override ReturnObject<Boolean> DeleteBefore()
        //{
        //    BinAff.Core.Observer.ISubject room = this;
        //    room.RegisterObserver(new Crystal.Lodge.Component.Room.CheckIn.Server(null));
        //    room.RegisterObserver(new Crystal.Lodge.Component.Room.Reservation.Server(null));
        //    room.RegisterObserver(new Crystal.Lodge.Component.Room.Tariff.Server(null));

        //    return new ReturnObject<Boolean> { Value = true };
        //}

    }

}
