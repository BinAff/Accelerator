using System;
using System.Collections.Generic;
using Crystal.Lodge.Component.Room.Category;

namespace Vanilla.Configuration.Lodge.Facade.Room.RoomCategory
{

    public class RoomCategoryServer : IRoomCategory
    {

        #region IRoomCategory

        BinAff.Core.ReturnObject<FormDto> IRoomCategory.LoadForm()
        {
            BinAff.Core.ICrud crud = new Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    RoomCategoryList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (Data data in dataList.Value)
            {
                ret.Value.RoomCategoryList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        BinAff.Core.ReturnObject<Boolean> IRoomCategory.Add(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        BinAff.Core.ReturnObject<Boolean> IRoomCategory.Delete(Dto dto)
        {
            ////Register Observers
            //Crystal.Lodge.Component.Lodge.Observer.RoomCategory roomCategory = new Crystal.Lodge.Configuration.Observer.RoomCategory();

            //BinAff.Core.ICrud crud = roomCategory.RegisterObserver(new Crystal.Lodge.Configuration.Room.Category.Data
            //{
            //    Id = dto.Id
            //});
            //return crud.Delete();
            return null;
        }

        BinAff.Core.ReturnObject<Dto> IRoomCategory.Read(Dto dto)
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

        BinAff.Core.ReturnObject<Boolean> IRoomCategory.Change(Dto dto)
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
