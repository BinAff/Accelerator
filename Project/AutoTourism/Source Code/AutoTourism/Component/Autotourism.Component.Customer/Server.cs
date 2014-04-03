using System;

using BinAff.Core;

using Lodge = Crystal.Lodge.Component;
using Customer = Crystal.Customer.Component;

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
            this.Name = "Customer";
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
            base.AddChild(new Lodge.Room.Reservation.Server((this.Data as Data).RoomReserver.Active as Lodge.Room.Reservation.Data)
            {
                Type = ChildType.Independent,
            });
            base.AddChild(new Lodge.Room.CheckIn.Server((Lodge.Room.CheckIn.Data)(this.Data as Data).Checkin.Active)
            {
                Type = ChildType.Independent,
            });
        }

        Crystal.Customer.Component.Data ICustomer.GetCustomerForReservation(long reservationId)
        {
            return this.ReadCustomerForReservation(reservationId);
        }

        private Customer.Data ReadCustomerForReservation(Int64 reservationId)
        {
            Int64 customerId = new Dao(null).ReadCustomerIdForReservation(reservationId);
            if (customerId > 0)
            {
                ICrud customer = new Server(new Data { Id = customerId });
                return customer.Read().Value as Customer.Data;               
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
