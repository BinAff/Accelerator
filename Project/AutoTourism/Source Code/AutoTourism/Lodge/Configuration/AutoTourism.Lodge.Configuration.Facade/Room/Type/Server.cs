using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

using CrystalComponent = Crystal.Lodge.Component.Room.Type;

namespace AutoTourism.Lodge.Configuration.Facade.Room.Type
{

    public class Server : BinAff.Facade.Library.Server //, IRoomType
    {

        //#region IRoomType

        //ReturnObject<FormDto> IRoomType.LoadForm()
        //{
        //    ReturnObject<List<BinAff.Core.Data>> dataList = (new CrystalComponent.Server(null) as ICrud).ReadAll();
        //    ReturnObject<FormDto> ret = new ReturnObject<FormDto>
        //    {
        //        Value = new FormDto
        //        {
        //            DtoList = new List<Dto>()
        //        }
        //    };

        //    //Populate data in dto from business entity
        //    foreach (CrystalComponent.Data data in dataList.Value)
        //    {
        //        ret.Value.DtoList.Add(new Dto
        //        {
        //            Id = data.Id,
        //            Name = data.Name
        //        });
        //    }

        //    return ret;
        //}

        //ReturnObject<Boolean> IRoomType.Add(Dto dto)
        //{
        //    BinAff.Core.ICrud crud = new CrystalComponent.Server(new CrystalComponent.Data
        //    {
        //        Name = dto.Name
        //    });
        //    return crud.Save();
        //}

        //ReturnObject<Boolean> IRoomType.Delete(Dto dto)
        //{
        //    CrystalComponent.Server crud = new CrystalComponent.Server(new CrystalComponent.Data
        //    {
        //        Id = dto.Id
        //    });
        //    (new Crystal.Lodge.Observer.RoomType() as IRegistrar).Register(crud); //Register Observers

        //    return (crud as ICrud).Delete();
        //}

        //ReturnObject<Dto> IRoomType.Read(Dto dto)
        //{
        //    ICrud crud = new CrystalComponent.Server(new CrystalComponent.Data
        //    {
        //        Id = dto.Id
        //    });
        //    ReturnObject<BinAff.Core.Data> data = crud.Read();
        //    return new BinAff.Core.ReturnObject<Dto>
        //    {
        //        Value = new Dto
        //        {
        //            Id = data.Value.Id,
        //            Name = ((CrystalComponent.Data)data.Value).Name
        //        }
        //    };
        //}

        //ReturnObject<Boolean> IRoomType.Change(Dto dto)
        //{
        //    BinAff.Core.ICrud crud = new CrystalComponent.Server(new CrystalComponent.Data
        //    {
        //        Id = dto.Id,
        //        Name = dto.Name
        //    });
        //    return crud.Save();
        //}

        //#endregion

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
            formDto.DtoList = new List<Dto>();
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
            if (!this.IsError)
            {
                FormDto formDto = this.FormDto as FormDto;
                formDto.DtoList.FindLast((p) => { return p.Id == formDto.Dto.Id; }).Name = formDto.Dto.Name;
            }
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
            (this.FormDto as FormDto).Dto.Id = (crud as Crud).Data.Id;

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }


    }

}
