using System.Collections.Generic;
using System;

using BinAff.Core;

using TaxCrys = Crystal.Invoice.Component.Taxation;

namespace AutoTourism.Lodge.Facade.Taxation
{

    public class Server : ITaxation
    {

        List<Dto> ITaxation.ReadLodgeTaxation(Double value)
        {
            List<Dto> taxationDtoList = new List<Dto>();
            ReturnObject<List<Data>> taxationDataList = (new TaxCrys.Server(null) as TaxCrys.ITaxation).ReadLodgeTaxation(value);
            if (taxationDataList != null && taxationDataList.Value != null && taxationDataList.Value.Count > 0)
            {
                foreach (TaxCrys.Data data in taxationDataList.Value)
                {
                    taxationDtoList.Add(new Dto 
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Amount = data.Amount,
                        IsPercentage = data.IsPercentage
                    });
                }

            }
            return taxationDtoList;
        }

    }

}
