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
            formDto.TariffList = this.ReadAllCurrentTariff().Value;
        }
        
        ReturnObject<List<Dto>> ITariff.ReadAllTariff()
        {
            ICrud crud = new CrystalLodge.Room.Tariff.Server(null);
            ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
                return new ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };

            return GetTariff(lstData.Value);
        }

        ReturnObject<List<Dto>> ITariff.ReadAllCurrentTariff()
        {
            return this.ReadAllCurrentTariff();            
        }

        ReturnObject<List<Dto>> ITariff.ReadAllFutureTariff()
        {
            return this.ReadAllFutureTariff();            
        }
              
        public override void Add()
        {
            this.Save("add");
        }

        public override void Change()
        {
            this.Save("change");
        }

        private void Save(String action)
        {
            Dto tariffDto = (this.FormDto as FormDto).dto;
            CrystalLodge.Room.Tariff.Data tariffData = new CrystalLodge.Room.Tariff.Data
            {
                Id = action == "add" ? 0 :  tariffDto.Id,
                category = new CrystalLodge.Room.Category.Data { Id = tariffDto.Category.Id },
                type = new CrystalLodge.Room.Type.Data { Id = tariffDto.Type.Id },
                isAC = tariffDto.IsAC,
                StartDate = tariffDto.StartDate,
                EndDate = tariffDto.EndDate,
                Rate = tariffDto.Rate
            };

            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            CrystalLodge.Room.Tariff.IRoomTariff iTariff = new CrystalLodge.Room.Tariff.Server(tariffData);
            List<BinAff.Core.Data> existData = iTariff.GetExistingTariff().Value;

            if (action == "add")
            {
                if (existData == null)
                {
                    //save
                    ICrud crud = new CrystalLodge.Room.Tariff.Server(tariffData);
                    crud.Save();

                    ret.Value = true;
                    ret.MessageList = new List<Message> { 
                            new Message("Tariff added successfully.", Message.Type.Information)
                        };
                }
                else
                {
                    this.IsError = true;
                    ret.Value = false;
                    ret.MessageList = new List<Message> { 
                            new Message("Tariff conflicts for the period selected. Please update the existing tariff.", Message.Type.Error)
                        };
                }
            }

            else //action is change
            {
                //condition for change record
                if (existData != null && existData.Count == 1 && existData[0].Id == tariffData.Id) existData = null;

                if (existData == null)
                {
                    //save
                    ICrud crud = new CrystalLodge.Room.Tariff.Server(tariffData);
                    crud.Save();

                    ret.Value = true;
                    ret.MessageList = new List<Message> { 
                            new Message("Tariff changed successfully.", Message.Type.Information)
                        };
                }
                else
                {
                    this.IsError = true;
                    ret.Value = false;
                    ret.MessageList = new List<Message> { 
                            new Message("Tariff exists for the given period.\n\rCannot replace the existing tariff.", Message.Type.Error)
                        };
                }
            }

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);  
           
        }
        
        private ReturnObject<List<Dto>> ReadAllCurrentTariff()
        {
            CrystalLodge.Room.Tariff.IRoomTariff iTariff = new CrystalLodge.Room.Tariff.Server(null);
            ReturnObject<List<BinAff.Core.Data>> lstData = iTariff.ReadAllCurrentTariff();

            if (lstData.HasError())
                return new ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };

            return GetTariff(lstData.Value);

        }

        private ReturnObject<List<Dto>> ReadAllFutureTariff()
        {
            CrystalLodge.Room.Tariff.IRoomTariff iTariff = new CrystalLodge.Room.Tariff.Server(null);
            ReturnObject<List<BinAff.Core.Data>> lstData = iTariff.ReadAllFutureTariff();

            if (lstData.HasError())
                return new ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };

            return GetTariff(lstData.Value);

        }
        
        private ReturnObject<List<Dto>> GetTariff(List<BinAff.Core.Data> TariffList)
        {
            ReturnObject<List<Dto>> ret = new ReturnObject<List<Dto>>()
            {
                Value = new List<Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in TariffList)
            {
                ret.Value.Add(new Dto
                {
                    Id = data.Id,
                    Category = new Room.Category.Dto
                    {
                        Id = ((Crystal.Lodge.Component.Room.Tariff.Data)data).category.Id                        
                    },
                    Type = new Room.Type.Dto()
                    {
                        Id = ((Crystal.Lodge.Component.Room.Tariff.Data)data).type.Id                        
                    },
                    IsAC = ((CrystalLodge.Room.Tariff.Data)data).isAC,
                    Rate = ((CrystalLodge.Room.Tariff.Data)data).Rate,
                    StartDate = ((CrystalLodge.Room.Tariff.Data)data).StartDate,
                    EndDate = ((CrystalLodge.Room.Tariff.Data)data).EndDate,
                    IsACText = ((CrystalLodge.Room.Tariff.Data)data).isAC ? "Yes" : "No",
                    RateText = Converter.ConvertToIndianCurrency(System.Convert.ToDecimal(((CrystalLodge.Room.Tariff.Data)data).Rate)),
                });
            }

            //update category name and type name
            if (ret.Value != null && ret.Value.Count > 0)
            {
                FormDto formDto = this.FormDto as FormDto;

                //update category
                if (formDto.CategoryList != null && formDto.CategoryList.Count > 0)
                {
                    foreach (Dto dto in ret.Value)
                    {
                        foreach (Room.Category.Dto categoryDto in formDto.CategoryList)
                        {
                            if (dto.Category.Id == categoryDto.Id)
                            {
                                dto.Category.Name = categoryDto.Name;
                                dto.CategoryText = categoryDto.Name;
                                break;
                            }
                        }
                    }
                }

                //update Type
                if (formDto.TypeList != null && formDto.TypeList.Count > 0)
                {
                    foreach (Dto dto in ret.Value)
                    {
                        foreach (Room.Type.Dto typeDto in formDto.TypeList)
                        {
                            if (dto.Type.Id == typeDto.Id)
                            {
                                dto.Type.Name = typeDto.Name;
                                dto.TypeText = typeDto.Name;
                                break;
                            }
                        }
                    }
                }
            }

            return ret;
        }

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
