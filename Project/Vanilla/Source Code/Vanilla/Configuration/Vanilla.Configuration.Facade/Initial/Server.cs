using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

using CrysComp = Crystal.Configuration.Component.Initial;

namespace Vanilla.Configuration.Facade.Initial
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new CrysComp.Server(null) as ICrud).ReadAll();
            this.DisplayMessageList = dataList.GetMessage((this.IsError = dataList.HasError()) ? Message.Type.Error : Message.Type.Information);

            //Populate data in dto from business entity
            FormDto formDto = this.FormDto as FormDto;
            formDto.DtoList = new List<Dto>();
            foreach (CrysComp.Data data in dataList.Value)
            {
                formDto.DtoList.Add(this.Convert(data) as Dto);
            }
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrysComp.Data value = data as CrysComp.Data;
            return new Dto
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto value = dto as Dto;
            return new CrysComp.Data
            {
                Id = value.Id,
                Name = value.Name
            };
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
            CrysComp.Server crud = new CrysComp.Server(new CrysComp.Data
            {
                Id = (this.FormDto as FormDto).Dto.Id
            });
            (new Crystal.Configuration.Observer.State() as IRegistrar).Register(crud); //Register Observers

            ReturnObject<bool> ret = (crud as ICrud).Delete();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Read()
        {
            FormDto formDto = this.FormDto as FormDto;
            CrysComp.Data data = new CrysComp.Data
            {
                Id = formDto.Dto.Id
            };
            ReturnObject<BinAff.Core.Data> ret = (new CrysComp.Server(data) as ICrud).Read();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            formDto.Dto = this.Convert(data) as Dto;
        }

        protected override ICrud AssignComponentServer(Data data)
        {
            return new CrysComp.Server(data as CrysComp.Data);
        }

        private void Save()
        {
            Dto dto = (this.FormDto as FormDto).Dto;
            ICrud crud = new CrysComp.Server(this.Convert(dto) as CrysComp.Data);
            ReturnObject<Boolean> ret = crud.Save();
            (this.FormDto as FormDto).Dto.Id = (crud as Crud).Data.Id;

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

    }

}
