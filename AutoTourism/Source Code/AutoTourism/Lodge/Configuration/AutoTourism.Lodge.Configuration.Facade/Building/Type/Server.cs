using BinAff.Core;
using System;
using System.Collections.Generic;
using CrystalComponent = Crystal.Lodge.Component.Building.Type;

namespace AutoTourism.Lodge.Configuration.Facade.Building.Type
{

    public class Server : IBuildingType
    {

        #region IBuildingType

        BinAff.Core.ReturnObject<FormDto> IBuildingType.LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CrystalComponent.Server(null) as ICrud).ReadAll();

            ReturnObject<FormDto> ret = new ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    BuildingTypeList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (CrystalComponent.Data data in dataList.Value)
            {
                ret.Value.BuildingTypeList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        ReturnObject<Boolean> IBuildingType.Add(Dto dto)
        {
            BinAff.Core.ICrud crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        ReturnObject<Boolean> IBuildingType.Delete(Dto dto)
        {
            ////Register Observers
            //Crystal.Lodge.Configuration.Observer.BuildingType buildingType = new Crystal.Lodge.Configuration.Observer.BuildingType();

            //BinAff.Core.ICrud crud = buildingType.RegisterObserver(new Crystal.Lodge.Configuration.Building.Type.Data
            //{
            //    Id = dto.Id
            //});

            //return crud.Delete();
            return null;
            
        }

        ReturnObject<Dto> IBuildingType.Read(Dto dto)
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

        ReturnObject<Boolean> IBuildingType.Change(Dto dto)
        {
            ICrud crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Id = dto.Id,
                Name = dto.Name
            });
            return crud.Save();
        }

        #endregion

    }

}
