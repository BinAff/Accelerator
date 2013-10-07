using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

using CrystalComponent = Crystal.Lodge.Component.Room.Type;

namespace AutoTourism.Lodge.Configuration.Facade.Room.Type
{

    public class Server : IRoomType
    {

        #region IRoomType

        ReturnObject<FormDto> IRoomType.LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CrystalComponent.Server(null) as ICrud).ReadAll();
            ReturnObject<FormDto> ret = new ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    RoomTypeList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (CrystalComponent.Data data in dataList.Value)
            {
                ret.Value.RoomTypeList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        ReturnObject<Boolean> IRoomType.Add(Dto dto)
        {
            BinAff.Core.ICrud crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        ReturnObject<Boolean> IRoomType.Delete(Dto dto)
        {
            CrystalComponent.Server crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Id = dto.Id
            });
            (new Crystal.Lodge.Observer.RoomType() as IRegistrar).Register(crud); //Register Observers

            return (crud as ICrud).Delete();
        }

        ReturnObject<Dto> IRoomType.Read(Dto dto)
        {
            ICrud crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Id = dto.Id
            });
            ReturnObject<BinAff.Core.Data> data = crud.Read();
            return new BinAff.Core.ReturnObject<Dto>
            {
                Value = new Dto
                {
                    Id = data.Value.Id,
                    Name = ((CrystalComponent.Data)data.Value).Name
                }
            };
        }

        ReturnObject<Boolean> IRoomType.Change(Dto dto)
        {
            BinAff.Core.ICrud crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Id = dto.Id,
                Name = dto.Name
            });
            return crud.Save();
        }

        #endregion

    }

}
