using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

using CrystalRoomCategory = Crystal.Lodge.Component.Room.Category;

namespace AutoTourism.Lodge.Configuration.Facade.Room.Category
{

    public class Server : IRoomCategory
    {

        #region IRoomCategory

        BinAff.Core.ReturnObject<FormDto> IRoomCategory.LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CrystalRoomCategory.Server(null) as ICrud).ReadAll();
            ReturnObject<FormDto> ret = new ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    RoomCategoryList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (CrystalRoomCategory.Data data in dataList.Value)
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
            BinAff.Core.ICrud crud = new CrystalRoomCategory.Server(new CrystalRoomCategory.Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        BinAff.Core.ReturnObject<Boolean> IRoomCategory.Delete(Dto dto)
        {
            CrystalRoomCategory.Server crud = new CrystalRoomCategory.Server(new CrystalRoomCategory.Data
            {
                Id = dto.Id
            });
            (new Crystal.Lodge.Observer.RoomCategory() as IRegistrar).Register(crud); //Register Observers

            return (crud as ICrud).Delete();

        }

        BinAff.Core.ReturnObject<Dto> IRoomCategory.Read(Dto dto)
        {
            ICrud crud = new CrystalRoomCategory.Server(new CrystalRoomCategory.Data
            {
                Id = dto.Id
            });
            ReturnObject<BinAff.Core.Data> data = crud.Read();
            return new ReturnObject<Dto>
            {
                Value = new Dto
                {
                    Id = data.Value.Id,
                    Name = ((CrystalRoomCategory.Data)data.Value).Name
                }
            };
        }

        BinAff.Core.ReturnObject<Boolean> IRoomCategory.Change(Dto dto)
        {
            BinAff.Core.ICrud crud = new CrystalRoomCategory.Server(new CrystalRoomCategory.Data
            {
                Id = dto.Id,
                Name = dto.Name
            });
            return crud.Save();
        }

        #endregion

    }

}
