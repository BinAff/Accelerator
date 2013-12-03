using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

using CrystalComponent = Crystal.Lodge.Component.Building.Type;

namespace AutoTourism.Lodge.Configuration.Facade.Base
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CrystalComponent.Server(null) as ICrud).ReadAll();
            this.DisplayMessageList = dataList.GetMessage((this.IsError = dataList.HasError()) ? Message.Type.Error : Message.Type.Information);
            
            //Populate data in dto from business entity
            FormDto formDto = this.FormDto as FormDto;
            formDto.DtoList = new List<AutoTourism.Lodge.Configuration.Facade.Base.Dto>();
            foreach (CrystalComponent.Data data in dataList.Value)
            {
                formDto.DtoList.Add(this.Convert(data) as Dto);
            }
        }

        public override void Add()
        {
            this.Save();
            if (!this.IsError) (this.FormDto as FormDto).DtoList.Add((this.FormDto as FormDto).Dto);
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
            ReturnObject<BinAff.Core.Data> ret = this.CreateInstance(data).Read();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            formDto.Dto = this.Convert(data) as Dto;
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrystalComponent.Data value = data as CrystalComponent.Data;
            return new Dto
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto value = dto as Dto;
            BinAff.Core.Data ret = this.CreateDataObject();
            ret.Id = value.Id;
            ret.Name = value.Name;
            return ret;
        }

        private void Save()
        {
            FormDto formDto = this.FormDto as FormDto;
            ICrud crud = this.CreateInstance(this.Convert(formDto.Dto));
            ReturnObject<Boolean> ret = crud.Save();
            formDto.Dto.Id = (crud as Crud).Data.Id;

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        protected virtual BinAff.Core.ICrud CreateInstance(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        protected virtual BinAff.Core.Data CreateDataObject()
        {
            throw new NotImplementedException();
        }

        protected virtual BinAff.Facade.Library.Dto CreateDtoObject()
        {
            throw new NotImplementedException();
        }

    }

}
