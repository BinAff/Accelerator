using System;
using System.Collections.Generic;

using InvContCrys = Crystal.Accountant.Component.InvoiceContainer;

using LodgeRet = Retinue.Lodge.Component;

namespace Retinue.Customer.Component
{

    public class Data : Crystal.Customer.Component.Data
    {

        public LodgeRet.Room.Reserver.Data RoomReserver
        {
            get
            {
                return this.CharacteristicList[0] as LodgeRet.Room.Reserver.Data;
            }
            set
            {
                this.CharacteristicList[0] = value;
            }
        }

        public LodgeRet.Room.CheckInContainer.Data Checkin
        {
            get
            {
                return this.CharacteristicList[1] as LodgeRet.Room.CheckInContainer.Data;
            }
            set
            {
                this.CharacteristicList[1] = value;
            }
        }

        public InvContCrys.Data Invoice
        {
            get
            {
                return this.CharacteristicList[2] as InvContCrys.Data;
            }
            set
            {
                this.CharacteristicList[2] = value;
            }
        }
        
        public Data()
        {
            this.CharacteristicList = new List<Crystal.Customer.Component.Characteristic.Data>();
            this.CharacteristicList.Add(new LodgeRet.Room.Reserver.Data());
            this.CharacteristicList.Add(new LodgeRet.Room.CheckInContainer.Data());
            this.CharacteristicList.Add(new InvContCrys.Data());
        }

    }

}
