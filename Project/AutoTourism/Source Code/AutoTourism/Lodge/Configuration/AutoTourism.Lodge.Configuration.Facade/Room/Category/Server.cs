using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;
using FacLib = BinAff.Facade.Library;

using CatCrys = Crystal.Lodge.Component.Room.Category;

namespace AutoTourism.Lodge.Configuration.Facade.Room.Category
{

    public class Server : FacLib.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CatCrys.Server(null) as ICrud).ReadAll();
            this.DisplayMessageList = dataList.GetMessage((this.IsError = dataList.HasError()) ? Message.Type.Error : Message.Type.Information);

            //Populate data in dto from business entity
            FormDto formDto = this.FormDto as FormDto;
            formDto.DtoList = new List<Dto>();
            foreach (CatCrys.Data data in dataList.Value)
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
            CatCrys.Server crud = new CatCrys.Server(new CatCrys.Data
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
            CatCrys.Data data = new CatCrys.Data
            {
                Id = formDto.Dto.Id
            };
            ReturnObject<BinAff.Core.Data> ret = (new CatCrys.Server(data) as ICrud).Read();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            formDto.Dto = this.Convert(data) as Dto;
        }

        protected override List<FacLib.Dto> ReadAllInternal()
        {
            ICrud crud = new CatCrys.Server(null);
            ReturnObject<List<BinAff.Core.Data>> categoryList = crud.ReadAll();
            this.IsError = categoryList.HasError();
            this.DisplayMessageList = categoryList.GetMessage(this.IsError? Message.Type.Error : Message.Type.Information);
            List<FacLib.Dto> ret = null;
            if (!this.IsError)
            {
                ret = new List<FacLib.Dto>();
                foreach (BinAff.Core.Data data in categoryList.Value)
                {
                    ret.Add(this.Convert(data as CatCrys.Data) as Dto);
                }
            }

            return ret;
        }

        //public override void ReadAll()
        //{
        //    ReturnObject<List<Room.Category.Dto>> retObj = new ReturnObject<List<Room.Category.Dto>>();
        //    ICrud crud = new ComponentRoom.Category.Server(null);
        //    ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

        //    if (lstData.HasError())
        //    {
        //        return new ReturnObject<List<Room.Category.Dto>>
        //        {
        //            MessageList = lstData.MessageList
        //        };
        //    }

        //    ReturnObject<List<Room.Category.Dto>> ret = new ReturnObject<List<Room.Category.Dto>>()
        //    {
        //        Value = new List<Room.Category.Dto>(),
        //    };

        //    //Populate data in dto from business entity
        //    foreach (BinAff.Core.Data data in lstData.Value)
        //    {
        //        ret.Value.Add(new Room.Category.Dto
        //        {
        //            Id = data.Id,
        //            Name = ((ComponentRoom.Category.Data)data).Name,
        //        });
        //    }

        //    return ret;
        //}

        public override FacLib.Dto Convert(Data data)
        {
            CatCrys.Data value = data as CatCrys.Data;
            return new Dto
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        public override Data Convert(FacLib.Dto dto)
        {
            Dto value = dto as Dto;
            return new CatCrys.Data
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        private void Save()
        {
            Dto dto = (this.FormDto as FormDto).Dto;
            ICrud crud = new CatCrys.Server(this.Convert(dto) as CatCrys.Data);
            ReturnObject<Boolean> ret = crud.Save();
            (this.FormDto as FormDto).Dto.Id = (crud as Crud).Data.Id;

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

    }

}
