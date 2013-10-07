using System;
using System.Collections.Generic;

namespace BinAff.Core
{
    public interface ICrud
    {
        ReturnObject<Boolean> Save();
        ReturnObject<Boolean> Delete();
        ReturnObject<Data> Read();
        ReturnObject<List<Data>> ReadAll();
    }
}
