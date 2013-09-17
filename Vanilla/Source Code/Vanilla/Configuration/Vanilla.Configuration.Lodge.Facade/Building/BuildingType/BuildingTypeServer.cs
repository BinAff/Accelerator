using System;
using System.Collections.Generic;
using Crystal.Lodge.Component.Building.Type;

namespace AutoTourism.Facade.Configuration.BuildingType
{

    public class BuildingTypeServer : IBuildingType
    {

        #region IBuildingType

        BinAff.Core.ReturnObject<FormDto> IBuildingType.LoadForm()
        {
            BinAff.Core.ICrud crud = new Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    BuildingTypeList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (Data data in dataList.Value)
            {
                ret.Value.BuildingTypeList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        BinAff.Core.ReturnObject<Boolean> IBuildingType.Add(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        BinAff.Core.ReturnObject<Boolean> IBuildingType.Delete(Dto dto)
        {
            //Register Observers
            Crystal.Lodge.Configuration.Observer.BuildingType buildingType = new Crystal.Lodge.Configuration.Observer.BuildingType();

            BinAff.Core.ICrud crud = buildingType.RegisterObserver(new Crystal.Lodge.Configuration.Building.Type.Data
            {
                Id = dto.Id
            });

            return crud.Delete();
            
        }

        BinAff.Core.ReturnObject<Dto> IBuildingType.Read(Dto dto)
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

        BinAff.Core.ReturnObject<Boolean> IBuildingType.Change(Dto dto)
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
