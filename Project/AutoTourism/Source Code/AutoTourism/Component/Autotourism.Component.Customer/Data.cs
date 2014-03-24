using System;
using System.Collections.Generic;

using Lodge = Crystal.Lodge.Component;
using InvoiceContainer = Crystal.Invoice.Component.InvoiceContainer;

namespace AutoTourism.Component.Customer
{

    public class Data : Crystal.Customer.Component.Data
    {

        public Lodge.Room.Reserver.Data RoomReserver
        {
            get
            {
                return this.CharacteristicList[0] as Lodge.Room.Reserver.Data;
            }
            set
            {
                this.CharacteristicList[0] = value;
            }
        }

        public Lodge.Room.CheckInContainer.Data Checkin
        {
            get
            {
                return this.CharacteristicList[1] as Lodge.Room.CheckInContainer.Data;
            }
            set
            {
                this.CharacteristicList[1] = value;
            }
        }

        public InvoiceContainer.Data Invoice
        {
            get
            {
                return this.CharacteristicList[2] as InvoiceContainer.Data;
            }
            set
            {
                this.CharacteristicList[2] = value;
            }
        }
        
        public Data()
        {
            this.CharacteristicList = new List<Crystal.Customer.Component.Characteristic.Data>();
            this.CharacteristicList.Add(new Lodge.Room.Reserver.Data());
            this.CharacteristicList.Add(new Lodge.Room.CheckInContainer.Data());
            this.CharacteristicList.Add(new InvoiceContainer.Data());
        }

    }

}
