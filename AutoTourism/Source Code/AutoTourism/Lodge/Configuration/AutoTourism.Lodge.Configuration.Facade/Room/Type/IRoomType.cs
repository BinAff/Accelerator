﻿using System;

using BinAff.Core;

namespace AutoTourism.Lodge.Configuration.Facade.Room.Type
{

    public interface IRoomType
    {

        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Add(Dto dto);
        ReturnObject<Boolean> Delete(Dto dto);
        ReturnObject<Dto> Read(Dto dto);
        ReturnObject<Boolean> Change(Dto dto);

    }

}
