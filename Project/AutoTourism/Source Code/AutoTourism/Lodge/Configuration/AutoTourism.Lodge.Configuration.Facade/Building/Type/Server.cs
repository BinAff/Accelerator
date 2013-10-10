using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

using CrystalComponent = Crystal.Lodge.Component.Building.Type;

namespace AutoTourism.Lodge.Configuration.Facade.Building.Type
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {
            this.FormDto = formDto;
        }

        public override void LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CrystalComponent.Server(null) as ICrud).ReadAll();
            this.DisplayMessageList = dataList.GetMessage((this.IsError = dataList.HasError()) ? Message.Type.Error : Message.Type.Information);
            
            //Populate data in dto from business entity
            FormDto formDto = this.FormDto as FormDto;
            foreach (CrystalComponent.Data data in dataList.Value)
            {
                formDto.DtoList.Add(this.Convert(data) as Dto);
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
                Id = (this.FormDto as FormDto).Dto.Id
            });
            (new Crystal.Lodge.Observer.RoomCategory() as IRegistrar).Register(crud); //Register Observers

            ReturnObject<bool> ret = (crud as ICrud).Delete();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Read()
        {
            FormDto formDto = this.FormDto as FormDto;
            CrystalComponent.Data data = new CrystalComponent.Data
            {
                Id = formDto.Dto.Id
            };
            ReturnObject<BinAff.Core.Data> ret = (new CrystalComponent.Server(data) as ICrud).Read();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            formDto.Dto = this.Convert(data) as Dto;
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
            Dto dto = (this.FormDto as FormDto).Dto;
            ICrud crud = new CrystalComponent.Server(this.Convert(dto) as CrystalComponent.Data);
            ReturnObject<Boolean> ret = crud.Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

    }

}
