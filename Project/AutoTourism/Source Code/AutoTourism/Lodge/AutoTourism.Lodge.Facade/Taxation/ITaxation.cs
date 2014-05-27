using System;
using System.Collections.Generic;

namespace AutoTourism.Lodge.Facade.Taxation
{

    public interface ITaxation
    {

        List<Dto> ReadLodgeTaxation(Double value); 

    }

}
