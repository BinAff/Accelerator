using System;

using BinAff.Core;

namespace AutoTourism.Lodge.Configuration.Facade.Building
{

    public interface IBuilding
    {

        void Open();
        void Close(ReasonDto dto);
        void CloseWithNoCheck(ReasonDto dto);

    }

}
