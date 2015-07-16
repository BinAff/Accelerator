using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

using TarrifComp = Retinue.Lodge.Component.Room.Tariff;
using CatComp = Retinue.Lodge.Component.Room.Category;
using TypeComp = Retinue.Lodge.Component.Room.Type;

namespace Retinue.Lodge.Configuration.Facade.Tariff
{

    public class TariffServer : BinAff.Facade.Library.Server, ITariff
    {

        public TariffServer(FormDto formDto)
            : base(formDto)
        {

        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            TarrifComp.Data comp = data as TarrifComp.Data;
            return new Dto
            {
                Id = comp.Id,
                Category = new Room.Category.Server(null).Convert(comp.Category) as Room.Category.Dto,
                Type = new Room.Type.Server(null).Convert(comp.Type) as Room.Type.Dto,
                IsAC = comp.IsAC,
                StartDate = comp.StartDate,
                EndDate = comp.EndDate,
                IsExtra = comp.IsExtra,
                Rate = comp.Rate
            };
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto comp = dto as Dto;
            return new TarrifComp.Data
            {
                Id = comp.Id,
                Category = new Room.Category.Server(null).Convert(comp.Category) as CatComp.Data,
                Type = new Room.Type.Server(null).Convert(comp.Type) as TypeComp.Data,
                IsAC = comp.IsAC,
                StartDate = comp.StartDate,
                EndDate = comp.EndDate,
                IsExtra = comp.IsExtra,
                Rate = comp.Rate
            };
        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            //Circuler reference
            //Retinue.Utility.Facade.Cache.Dto cache = BinAff.Facade.Cache.Server.Current.Cache["Main"] as Retinue.Utility.Facade.Cache.Dto;
            //formDto.CategoryList = cache.RoomCategoryList;
            //formDto.TypeList = cache.RoomTypeList;

            formDto.CategoryList = new Room.Category.Server(null).ReadAll<Room.Category.Dto>();
            formDto.TypeList = new Room.Type.Server(null).ReadAll<Room.Type.Dto>();
            formDto.TariffList = this.ReadAllCurrentTariff().Value;
        }

        ReturnObject<List<Dto>> ITariff.ReadAllTariff()
        {
            ReturnObject<List<BinAff.Core.Data>> lstData = (new TarrifComp.Server(null) as ICrud).ReadAll();
            if (lstData.HasError())
            {
                return new ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };
            }

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
            TarrifComp.Data tariffData = this.Convert((this.FormDto as FormDto).Dto) as TarrifComp.Data;

            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            TarrifComp.IRoomTariff iTariff = new TarrifComp.Server(tariffData);
            List<BinAff.Core.Data> isExsists = iTariff.GetExistingTariff().Value; //Why it is here? it should be in component

            if (action == "change")
            {
                if (isExsists != null && isExsists.Count == 1 && isExsists[0].Id == tariffData.Id) isExsists = null;
            }
            if (isExsists == null)
            {
                ret = (new TarrifComp.Server(tariffData) as ICrud).Save();
            }
            else
            {
                ret.Value = false;
                ret.MessageList = new List<Message> 
                {
                    new Message("Tariff conflicts for the period selected. Please update the existing tariff.", Message.Type.Error)
                };
            }
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        private ReturnObject<List<Dto>> ReadAllCurrentTariff()
        {
            TarrifComp.IRoomTariff iTariff = new TarrifComp.Server(null);
            ReturnObject<List<BinAff.Core.Data>> lstData = iTariff.ReadAllCurrentTariff();

            if (lstData.HasError())
            {
                return new ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };
            }

            return GetTariff(lstData.Value);
        }

        private ReturnObject<List<Dto>> ReadAllFutureTariff()
        {
            TarrifComp.IRoomTariff iTariff = new TarrifComp.Server(null);
            ReturnObject<List<BinAff.Core.Data>> lstData = iTariff.ReadAllFutureTariff();

            if (lstData.HasError())
            {
                return new ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };
            }

            return GetTariff(lstData.Value);
        }

        private ReturnObject<List<Dto>> GetTariff(List<BinAff.Core.Data> TariffList)
        {
            ReturnObject<List<Dto>> ret = new ReturnObject<List<Dto>>
            {
                Value = TariffList.ConvertAll<Dto>(p => this.Convert(p) as Dto),
            };

            //update category name and type name
            if (ret.Value != null && ret.Value.Count > 0)
            {
                FormDto formDto = this.FormDto as FormDto;
                //update category
                if (formDto != null && formDto.CategoryList != null && formDto.CategoryList.Count > 0)
                {
                    foreach (Dto dto in ret.Value)
                    {
                        foreach (Room.Category.Dto categoryDto in formDto.CategoryList)
                        {
                            if (dto.Category.Id == categoryDto.Id)
                            {
                                dto.Category.Name = categoryDto.Name;
                                break;
                            }
                        }
                    }
                }

                //update Type
                if (formDto != null && formDto.TypeList != null && formDto.TypeList.Count > 0)
                {
                    foreach (Dto dto in ret.Value)
                    {
                        foreach (Room.Type.Dto typeDto in formDto.TypeList)
                        {
                            if (dto.Type.Id == typeDto.Id)
                            {
                                dto.Type.Name = typeDto.Name;
                                break;
                            }
                        }
                    }
                }
                ret.Value.Sort(delegate(Dto x, Dto y)
                {
                    int compareResult = x.CategoryText.CompareTo(y.CategoryText);
                    if (compareResult != 0) return compareResult;
                    compareResult = x.TypeText.CompareTo(y.TypeText);
                    if (compareResult != 0) return compareResult;
                    compareResult = x.IsAC.CompareTo(y.IsAC);
                    if (compareResult != 0) return compareResult;
                    compareResult = x.IsExtra.CompareTo(y.IsExtra);
                    if (compareResult != 0) return compareResult;
                    compareResult = x.StartDate.CompareTo(y.StartDate);
                    if (compareResult != 0) return compareResult;
                    return x.EndDate.CompareTo(y.EndDate);
                });
            }
            return ret;
        }

    }

}