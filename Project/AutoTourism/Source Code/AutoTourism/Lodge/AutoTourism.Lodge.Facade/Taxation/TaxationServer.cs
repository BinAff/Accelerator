using System;
using System.Collections.Generic;
using BinAff.Core;
using CrystalInvoice = Crystal.Invoice.Component;

namespace AutoTourism.Lodge.Facade.Taxation
{
    public class TaxationServer : ITaxation
    {
        List<Dto> ITaxation.ReadLodgeTaxation()
        {
            List<Dto> taxationDtoList = new List<Dto>();
            ICrud crud = new Crystal.Lodge.Component.Taxation.Server(null);
            ReturnObject<List<Data>> taxationDataList =  crud.ReadAll();
            if (taxationDataList != null && taxationDataList.Value != null && taxationDataList.Value.Count > 0)
            {
                foreach (CrystalInvoice.Taxation.Data data in taxationDataList.Value)
                {
                    taxationDtoList.Add(new Dto 
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Amount = data.Amount,
                        isPercentage = data.isPercentage
                    });
                }

            }
            return taxationDtoList;
        }
    }
}
