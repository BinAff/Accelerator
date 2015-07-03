using System;

using RoomRet = Retinue.Lodge.Component.Room;
using RoomDtlsRet = Retinue.Lodge.Component.Room.Reservation.RoomDetails;
using RoomFac = Retinue.Lodge.Configuration.Facade.Room;

namespace Retinue.Lodge.Facade.RoomReservation.RoomDetails
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            throw new NotImplementedException();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            RoomDtlsRet.Data comp = data as RoomDtlsRet.Data;
            return new Dto
            {
                Id = data.Id,
                ExtraRoom = comp.ExtraAccomodation,
                Room = comp.Room == null ? null : new RoomFac.Server(null).Convert(comp.Room) as RoomFac.Dto,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto comp = dto as Dto;
            return new RoomDtlsRet.Data
            {
                Id = dto.Id,
                ExtraAccomodation = comp.ExtraRoom,
                Room = comp.Room == null ? null : new RoomFac.Server(null).Convert(comp.Room) as RoomRet.Data,
            };
        }

    }

}