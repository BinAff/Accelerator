using System.Collections.Generic;
using BinAff.Core;
using System;
using BinAff.Utility;

using CrystalLodge = Crystal.Lodge.Component;

namespace AutoTourism.Lodge.Configuration.Facade.Tariff
{
    public class TariffServer : BinAff.Facade.Library.Server, ITariff
    {
        public TariffServer(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;           
            formDto.CategoryList = new Room.Server(null).ReadAllCategory().Value;
            formDto.TypeList = new Room.Server(null).ReadAllType().Value;
        }

        //ReturnObject<FormDto> ITariff.LoadForm()
        //{
        //    ReturnObject<FormDto> ret = new ReturnObject<FormDto>()
        //    {
        //        Value = new FormDto()
        //        {
        //            //TariffList = this.ReadAllCurrentTariff().Value,                    
        //            CategoryList = this.ReadAllCategory().Value,
        //            TypeList = this.ReadAllType().Value,
        //        }
        //    };

        //    return ret;     
        //}

        //ReturnObject<Boolean> ITariff.Add(Dto dto)
        //{
        //    //return this.Add(dto);
        //    return new ReturnObject<bool>();
        //}

        //ReturnObject<Boolean> ITariff.Change(Dto dto)
        //{
        //    //return this.Change(dto);
        //    return new ReturnObject<bool>();
        //}

        ReturnObject<List<Dto>> ITariff.ReadAllTariff()
        {
            return this.ReadAllTariff();
        }

        ReturnObject<List<Dto>> ITariff.ReadAllCurrentTariff()
        {
            //return this.ReadAllCurrentTariff();
            return new ReturnObject<List<Dto>>();
        }

        ReturnObject<List<Dto>> ITariff.ReadAllFutureTariff()
        {
            //return this.ReadAllFutureTariff();
            return new ReturnObject<List<Dto>>();
        }
        
        private ReturnObject<List<Dto>> ReadAllTariff()
        {
            //ICrud crud = new Crystal.Lodge.Component.Room.Tariff.Server(null);
            //ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            //if (lstData.HasError())
            //    return new ReturnObject<List<Dto>>
            //    {
            //        MessageList = lstData.MessageList
            //    };

            //return GetTariff(lstData.Value);

            return new ReturnObject<List<Dto>>();

        }

        public override void Add()
        {
            Dto tariffDto = (this.FormDto as FormDto).dto;
            CrystalLodge.Room.Tariff.Data data = new CrystalLodge.Room.Tariff.Data
            {
                StartDate = tariffDto.StartDate,
                EndDate = tariffDto.EndDate,
                Rate = tariffDto.Rate,
                Product = new Crystal.Product.Component.Data { }
            };
            

            //Crystal.Lodge.Tariff.Data data = new Crystal.Lodge.Tariff.Data
            //{
            //    Category = new Crystal.Lodge.Configuration.Room.Category.Data() { Id = dto.Category.Id },
            //    Type = new Crystal.Lodge.Configuration.Room.Type.Data() { Id = dto.Type.Id },
            //    IsAirConditioned = dto.IsAC,
            //    StartDate = dto.StartDate,
            //    EndDate = dto.EndDate,
            //    Rate = dto.Rate
            //};

            //    Crystal.Lodge.Tariff.ITariff crud = new Crystal.Lodge.Tariff.Server(data);

            //    ReturnObject<Boolean> ret = new ReturnObject<Boolean>();            
            //    if (crud.GetExistingTariff().Value == null)
            //    {
            //        //Insert
            //        ret = Save(data);
            //    }
            //    else
            //    {
            //        ret.Value = false;
            //        ret.MessageList = new List<Message> { 
            //            new Message("Tariff conflicts for the period selected. Please update the existing tariff.", Message.Type.Error)
            //        };
            //    }
            //    return ret; 
        }
       



        //private ReturnObject<List<Dto>> ReadAllCurrentTariff()
        //{            
        //    Crystal.Lodge.Tariff.ITariff crud = new Crystal.Lodge.Tariff.Server(null);
        //    ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAllCurrentTariff();

        //    if (lstData.HasError())
        //        return new ReturnObject<List<Dto>>
        //        {
        //            MessageList = lstData.MessageList
        //        };

        //    return GetTariff(lstData.Value); 

        //}

        //private ReturnObject<List<Dto>> ReadAllFutureTariff()
        //{
        //    Crystal.Lodge.Tariff.ITariff crud = new Crystal.Lodge.Tariff.Server(null);
        //    ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAllFutureTariff();

        //    if (lstData.HasError())
        //        return new ReturnObject<List<Dto>>
        //        {
        //            MessageList = lstData.MessageList
        //        };

        //    return GetTariff(lstData.Value);

        //}

        //private ReturnObject<List<Dto>> GetTariff(List<BinAff.Core.Data> TariffList)
        //{
        //    ReturnObject<List<Dto>> ret = new ReturnObject<List<Dto>>()
        //    {
        //        Value = new List<Dto>(),
        //    };

        //    //Populate data in dto from business entity
        //    foreach (BinAff.Core.Data data in TariffList)
        //    {
        //        ret.Value.Add(new Dto
        //        {
        //            Id = data.Id,
        //            Category = new RoomCategory.Dto()
        //            {
        //                Id = ((Crystal.Lodge.Tariff.Data)data).Category.Id,
        //                Name = ((Crystal.Lodge.Tariff.Data)data).Category.Name,
        //            },
        //            Type = new RoomType.Dto()
        //            {
        //                Id = ((Crystal.Lodge.Tariff.Data)data).Type.Id,
        //                Name = ((Crystal.Lodge.Tariff.Data)data).Type.Name,
        //            },
        //            CategoryText = ((Crystal.Lodge.Tariff.Data)data).Category.Name,
        //            TypeText = ((Crystal.Lodge.Tariff.Data)data).Type.Name,
        //            IsACText = ((Crystal.Lodge.Tariff.Data)data).IsAirConditioned ? "Yes" : "No",

        //            IsAC = ((Crystal.Lodge.Tariff.Data)data).IsAirConditioned,
        //            StartDate = ((Crystal.Lodge.Tariff.Data)data).StartDate,
        //            EndDate = ((Crystal.Lodge.Tariff.Data)data).EndDate,
        //            Rate = ((Crystal.Lodge.Tariff.Data)data).Rate,
        //            RateText = Converter.ConvertToIndianCurrency( Convert.ToDecimal(((Crystal.Lodge.Tariff.Data)data).Rate)),
        //        });
        //    }

        //    return ret;
        //}

        //private ReturnObject<List<Room.Category.Dto>> ReadAllCategory()
        //{
        //   return new Room.Server(null).ReadAllCategory();
        //}


        //private ReturnObject<List<Room.Type.Dto>> ReadAllType()
        //{
        //    return new Room.Server(null).ReadAllType();
        //}

       

        //private ReturnObject<Boolean> Save(Crystal.Lodge.Tariff.Data data)
        //{
        //    ICrud crud = new Crystal.Lodge.Tariff.Server(data);
        //    return crud.Save();
        //}

        //private ReturnObject<Boolean> UpdateAndInsert(Dto dto)
        //{
        //    Crystal.Lodge.Tariff.Data data = new Crystal.Lodge.Tariff.Data
        //    {                
        //        Category = new Crystal.Lodge.Configuration.Room.Category.Data() { Id = dto.Category.Id },
        //        Type = new Crystal.Lodge.Configuration.Room.Type.Data() { Id = dto.Type.Id },
        //        IsAirConditioned = dto.IsAC,
        //        StartDate = dto.StartDate,
        //        EndDate = dto.EndDate,
        //        Rate = dto.Rate
        //    };

        //    Crystal.Lodge.Tariff.ITariff crud = new Crystal.Lodge.Tariff.Server(data);
        //    data = crud.GetExistingTariff().Value;

        //    ReturnObject<Boolean> ret;

        //    using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
        //    {
        //        //update
        //        ret = Save(data);
        //        if (!ret.Value || ret.HasError()) return ret;

        //        //Insert
        //        data.Id = 0;
        //        ret = Save(data);
        //        if (!ret.Value || ret.HasError()) return ret;

        //        T.Complete();
        //    }

        //    return ret;

        //}

        //private ReturnObject<Boolean> Change(Dto dto)
        //{
        //    ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
        //    Crystal.Lodge.Tariff.ITariff crudTariff = new Crystal.Lodge.Tariff.Server(new Crystal.Lodge.Tariff.Data
        //                    {
        //                        Id = dto.Id,
        //                        Category = new Crystal.Lodge.Configuration.Room.Category.Data() { Id = dto.Category.Id },
        //                        Type = new Crystal.Lodge.Configuration.Room.Type.Data() { Id = dto.Type.Id },
        //                        IsAirConditioned = dto.IsAC,
        //                        StartDate = dto.StartDate,
        //                        EndDate = dto.EndDate,
        //                        Rate = dto.Rate
        //                    });

        //    //Crystal.Lodge.Tariff.Data existData = crudTariff.GetExistingTariff().Value;

        //    List<BinAff.Core.Data> existData = crudTariff.GetExistingTariff().Value;
            
        //    //condition for change record
        //    if (existData != null && existData.Count == 1 && existData[0].Id == dto.Id) existData = null;

        //    if (existData == null)
        //    {
        //        ICrud crud = new Crystal.Lodge.Tariff.Server(new Crystal.Lodge.Tariff.Data
        //                                {
        //                                    Id = dto.Id,
        //                                    Category = new Crystal.Lodge.Configuration.Room.Category.Data() { Id = dto.Category.Id },
        //                                    Type = new Crystal.Lodge.Configuration.Room.Type.Data() { Id = dto.Type.Id },
        //                                    IsAirConditioned = dto.IsAC,
        //                                    StartDate = dto.StartDate,
        //                                    EndDate = dto.EndDate,
        //                                    Rate = dto.Rate
        //                                });
        //        ret = crud.Save();
        //    }
        //    else
        //    {
        //        ret.Value = false;
        //        ret.MessageList = new List<Message> { 
        //            new Message("Tariff exists for the given period.\n\rCannot replace the existing tariff.", Message.Type.Error)
        //        };            
        //    }

        //    return ret;
        //}


        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            throw new NotImplementedException();
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }
    }
}
