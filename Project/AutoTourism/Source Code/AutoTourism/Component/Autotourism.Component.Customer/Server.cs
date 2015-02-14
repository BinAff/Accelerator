using System;

using BinAff.Core;

using Comp = Crystal.Customer.Component;
using InvCrys = Crystal.Invoice.Component;
using ChkInCrys = Crystal.Lodge.Component.Room.CheckIn;
using RoomRsvCrys = Crystal.Lodge.Component.Room.Reservation;

namespace AutoTourism.Component.Customer
{

    public class Server : Crystal.Customer.Component.Server, ICustomer
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
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
                return new Server(new Data { Id = id }).Read().Value as Customer.Data;               
            }

            return null;
        }

        protected override ReturnObject<bool> GenerateInvoice()
        {
          Crystal.Invoice.Component.Data invoiceData = (((Data)this.Data).Invoice as Crystal.Customer.Component.Characteristic.Data).Active as Crystal.Invoice.Component.Data;
          ICrud crud = new Crystal.Invoice.Component.Server(invoiceData);
          return crud.Save();
        }
                
    }

}
