using System;
using System.Collections.Generic;

using BinAff.Core;

using GenTariff = Crystal.Tariff.Component;

namespace Retinue.Lodge.Component.Room.Tariff
{

    public class Server : GenTariff.Server, IRoomTariff
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Room Tariff";
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

            base.AddChild(new Room.Server(((Data)this.Data).Product as Room.Data)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }        

        ReturnObject<bool> IRoomTariff.UpdateForCategoryAndType(Category.Data category, Type.Data type, double rate)
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = false,
                MessageList = new List<Message>()
            };

            retObj.Value = new Dao((Data)this.Data).ModifyForCategoryAndType(category, type, rate);

            if (retObj.Value)
                retObj.MessageList.Add(new Message()
                {
                    Category = Message.Type.Information,
                    Description = "Rates modified successfully."
                });
            else
                retObj.MessageList.Add(new Message()
                {
                    Category = Message.Type.Error,
                    Description = "Error to modifying rates."
                });

            return retObj;
        }

        protected override String GetProductType()
        {          
            return "Retinue.Lodge.Component.Room.Data";
        }

        protected override String GetMessage(Crystal.Tariff.Component.Data data)
        {
            Data d = data as Data;
            return "Room has tariff attached from " + d.StartDate.ToShortDateString() + " to " + d.EndDate.ToShortDateString();
        }

        ReturnObject<List<BinAff.Core.Data>> IRoomTariff.GetExistingTariff()
        {
            return new ReturnObject<List<BinAff.Core.Data>>()
            {
                Value = new Dao((Data)this.Data).GetExistingTariff(),
            };
        }
        
        ReturnObject<List<BinAff.Core.Data>> IRoomTariff.ReadAllCurrentTariff()
        {
            return new ReturnObject<List<BinAff.Core.Data>>()
            {
                Value = new Dao((Data)this.Data).ReadAllCurrentTariff(),
            };
        }
        
        ReturnObject<List<BinAff.Core.Data>> IRoomTariff.ReadAllFutureTariff()
        {
            return new ReturnObject<List<BinAff.Core.Data>>()
            {
                Value = new Dao((Data)this.Data).ReadAllFutureTariff(),
            };
        }
    }

}
