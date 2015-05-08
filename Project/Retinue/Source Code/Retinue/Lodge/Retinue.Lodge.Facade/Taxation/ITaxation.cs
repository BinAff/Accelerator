using System;
using System.Collections.Generic;

namespace Retinue.Lodge.Facade.Taxation
{

    public interface ITaxation
    {

        List<Dto> ReadLodgeTaxation(Double value); 

    }

}
