using System;
using System.Collections.Generic;

using BinAff.Core;
using Crystal.Configuration.Component.Initial;
using BinAff.Core.Observer;


namespace Vanilla.Configuration.Facade.Initial
{

    public class InitialServer : IInitial
    {

        #region IInitial

        ReturnObject<FormDto> IInitial.LoadForm()
        {
            ICrud crud = new Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();
            ReturnObject<FormDto> ret = new ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    InitialList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (Crystal.Configuration.Component.Initial.Data data in dataList.Value)
            {
                ret.Value.InitialList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        ReturnObject<Boolean> IInitial.Add(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Crystal.Configuration.Component.Initial.Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        ReturnObject<Boolean> IInitial.Delete(Dto dto)
        {
            //Register Observers
            Crystal.Configuration.Component.Initial.Server initialServer = new Crystal.Configuration.Component.Initial.Server(new Crystal.Configuration.Component.Initial.Data()
            {
                Id = dto.Id
            });
            IRegistrar reg = new Crystal.Configuration.Observer.Initial();
            ReturnObject<Boolean> ret = reg.Register(initialServer);
            BinAff.Core.ICrud initial = initialServer;
            return initial.Delete();
        }

        ReturnObject<Dto> IInitial.Read(Dto dto)
        {
            ICrud crud = new Server(new Crystal.Configuration.Component.Initial.Data
            {
                Id = dto.Id
            });
            ReturnObject<BinAff.Core.Data> data = crud.Read();
            return new ReturnObject<Dto>
            {
                Value = new Dto
                {
                    Id = data.Value.Id,
                    Name = ((Crystal.Configuration.Component.Initial.Data)data.Value).Name
                }
            };
        }

        ReturnObject<Boolean> IInitial.Change(Dto dto)
        {
            ICrud crud = new Server(new Crystal.Configuration.Component.Initial.Data
            {
                Id = dto.Id,
                Name = dto.Name
            });
            return crud.Save();
        }

        #endregion

    }

}
