using System;
using BinAff.Core;

namespace Crystal.Lodge.Component.Building
{
    public interface IBuilding
    {
        ReturnObject<Boolean> Open();
        ReturnObject<Boolean> Close();
    }
}
