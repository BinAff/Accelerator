using System;

using BinAff.Core;

namespace Crystal.Organization.Component.Unit
{

    public interface IUnit
    {

        ReturnObject<Boolean> Open();
        ReturnObject<Boolean> Close();

    }

}
