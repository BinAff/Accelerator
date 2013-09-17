using System;
using System.Collections.Generic;
using Crystal.Lodge.Component.Room.Type;

namespace AutoTourism.Facade.Configuration.RoomType
{

    public class RoomTypeServer : IRoomType
    {

        #region IRoomType

        BinAff.Core.ReturnObject<FormDto> IRoomType.LoadForm()
        {
            BinAff.Core.ICrud crud = new Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    RoomTypeList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (Data data in dataList.Value)
            {
                ret.Value.RoomTypeList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        BinAff.Core.ReturnObject<Boolean> IRoomType.Add(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        BinAff.Core.ReturnObject<Boolean> IRoomType.Delete(Dto dto)
        {
            //Register Observers
            Crystal.Lodge.Configuration.Observer.RoomType roomType = new Crystal.Lodge.Configuration.Observer.RoomType();

            BinAff.Core.ICrud crud = roomType.RegisterObserver(new Crystal.Lodge.Configuration.Room.Type.Data
            {
                Id = dto.Id
            });
            return crud.Delete();
        }

        BinAff.Core.ReturnObject<Dto> IRoomType.Read(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Id = dto.Id
            });
            BinAff.Core.ReturnObject<BinAff.Core.Data> data = crud.Read();
            return new BinAff.Core.ReturnObject<Dto>
            {
                Value = new Dto
                {
                    Id = data.Value.Id,
                    Name = ((Data)data.Value).Name
                }
            };
        }

        BinAff.Core.ReturnObject<Boolean> IRoomType.Change(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Id = dto.Id,
                Name = dto.Name
            });
            return crud.Save();
        }

        #endregion

    }

}
