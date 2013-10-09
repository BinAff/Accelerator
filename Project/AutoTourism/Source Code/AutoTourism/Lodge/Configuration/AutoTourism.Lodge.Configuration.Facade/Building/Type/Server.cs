using BinAff.Core;
using BinAff.Core.Observer;
using System;
using System.Collections.Generic;
using CrystalComponent = Crystal.Lodge.Component.Building.Type;

namespace AutoTourism.Lodge.Configuration.Facade.Building.Type
{

    public class Server : BinAff.Facade.Library.Server, IBuildingType
    {

        public Server(FormDto formDto)
            : base(formDto)
        {
            this.FormDto = formDto;
        }

        #region IBuildingType
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

        #endregion

        public override void LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CrystalComponent.Server(null) as ICrud).ReadAll();
            this.DisplayMessageList = dataList.GetMessage((this.IsError = dataList.HasError()) ? Message.Type.Error : Message.Type.Information);
            
            //Populate data in dto from business entity
            FormDto formDto = this.FormDto as FormDto;
            foreach (CrystalComponent.Data data in dataList.Value)
            {
                formDto.BuildingTypeList.Add(this.Convert(data) as Dto);
            }
        }

        public override void Add()
        {
            this.Save();
        }

        public override void Change()
        {
            this.Save();
        }

        public override void Delete()
        {
            CrystalComponent.Server crud = new CrystalComponent.Server(new CrystalComponent.Data
            {
                Id = (this.FormDto as FormDto).BuildingType.Id
            });
            (new Crystal.Lodge.Observer.RoomCategory() as IRegistrar).Register(crud); //Register Observers

            ReturnObject<bool> ret = (crud as ICrud).Delete();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        protected override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrystalComponent.Data value = data as CrystalComponent.Data;
            return new Dto
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        protected override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto value = dto as Dto;
            return new CrystalComponent.Data
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        private void Save()
        {
            Dto dto = (this.FormDto as FormDto).BuildingType;
            ICrud crud = new CrystalComponent.Server(this.Convert(dto) as CrystalComponent.Data);
            ReturnObject<Boolean> ret = crud.Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

    }

}
