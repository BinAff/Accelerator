using System;
using System.Collections.Generic;

using BinAff.Core;
using System.Transactions;

namespace Retinue.Lodge.Component.Room.Tariff
{

    public class Server : Crystal.Tariff.Component.Server, IRoomTariff
    {

        Data current;

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Room Tariff";
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

            base.AddChild(new Room.Server((this.Data as Data).Product as Room.Data)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
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

        protected override ReturnObject<Boolean> UpdateBefore()
        {
            current = this.Data.Clone() as Data;
            current.StartDate = DateTime.Today.AddDays(1);
            current.Id = 0;

            this.Read();
            (this.Data as Data).EndDate = DateTime.Today;
            
            //Calculation for 12am
            if ((this.Data as Data).EndDate.Date.CompareTo(current.StartDate.Date) == 0)
            {
                (this.Data as Data).EndDate.AddDays(-1);
            }

            return new ReturnObject<Boolean>
            {
                Value = true,
            };
        }

        protected override ReturnObject<Boolean> UpdateAfter()
        {
            this.Data = current;
            return (this as ICrud).Save();
        }

        ReturnObject<List<BinAff.Core.Data>> IRoomTariff.GetExistingTariff()
        {
            return new ReturnObject<List<BinAff.Core.Data>>
            {
                Value = (this.DataAccess as Dao).GetExistingTariff(),
            };
        }
        
        ReturnObject<List<BinAff.Core.Data>> IRoomTariff.ReadAllCurrentTariff()
        {
            return new ReturnObject<List<BinAff.Core.Data>>
            {
                Value = (this.DataAccess as Dao).ReadAllCurrentTariff(),
            };
        }
        
        ReturnObject<List<BinAff.Core.Data>> IRoomTariff.ReadAllFutureTariff()
        {
            return new ReturnObject<List<BinAff.Core.Data>>
            {
                Value = (this.DataAccess as Dao).ReadAllFutureTariff(),
            };
        }

    }

}