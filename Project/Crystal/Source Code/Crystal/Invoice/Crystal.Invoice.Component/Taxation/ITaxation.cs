using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Invoice.Component.Taxation
{

    public interface ITaxation
    {

        ReturnObject<List<BinAff.Core.Data>> ReadLodgeTaxation(Double value);
        ReturnObject<Double> Calculate(Double amount);

    }

}
