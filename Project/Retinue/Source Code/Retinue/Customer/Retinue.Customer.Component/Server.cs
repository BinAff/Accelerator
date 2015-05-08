using System;

using BinAff.Core;

using Comp = Crystal.Customer.Component;
using InvCrys = Crystal.Accountant.Component.Invoice;
using ChkInCrys = Retinue.Lodge.Component.Room.CheckIn;
using RoomRsvCrys = Retinue.Lodge.Component.Room.Reservation;

namespace Retinue.Customer.Component
{

    public class Server : Crystal.Customer.Component.Server, ICustomer
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
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
            base.AddChild(new RoomRsvCrys.Server((this.Data as Data).RoomReserver.Active as RoomRsvCrys.Data)
            {
                Type = ChildType.Independent,
            });
            base.AddChild(new ChkInCrys.Server((this.Data as Data).Checkin.Active as ChkInCrys.Data)
            {
                Type = ChildType.Independent,
            });
            base.AddChild(new InvCrys.Server((this.Data as Data).Invoice.Active as InvCrys.Data)
            {
                Type = ChildType.Independent,
            });
        }

        Comp.Data ICustomer.GetCustomerForReservation(Int64 reservationId)
        {
            return this.ReadCustomerForReservation(reservationId);           
        }

        private Data ReadCustomerForReservation(Int64 reservationId)
        {
            Int64 id = new Dao(null).ReadCustomerIdForReservation(reservationId);
            if (id > 0)
            {
                return new Server(new Data { Id = id }).Read().Value as Data;               
            }

            return null;
        }

        protected override ReturnObject<bool> GenerateInvoice()
        {
            InvCrys.Data invoiceData = ((this.Data as Data).Invoice as Comp.Characteristic.Data).Active as InvCrys.Data;
            ICrud crud = new InvCrys.Server(invoiceData);
          return crud.Save();
        }
                
    }

}