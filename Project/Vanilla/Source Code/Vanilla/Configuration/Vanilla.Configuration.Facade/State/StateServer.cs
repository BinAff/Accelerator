using System;
using System.Collections.Generic;

using BinAff.Core;

using Crystal.Configuration.Component.State;
using BinAff.Core.Observer;

namespace Vanilla.Configuration.Facade.State
{

    public class StateServer : IState
    {

        #region IState

        ReturnObject<FormDto> IState.LoadForm()
        {
            ICrud crud = new Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();
            ReturnObject<FormDto> ret = new ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    DtoList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (Crystal.Configuration.Component.State.Data data in dataList.Value)
            {
                ret.Value.DtoList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        ReturnObject<Boolean> IState.Add(Dto dto)
        {
            ICrud crud = new Server(new Crystal.Configuration.Component.State.Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        ReturnObject<Boolean> IState.Delete(Dto dto)
        {
            //Register Observers           
            Crystal.Configuration.Component.State.Server stateServer = new Crystal.Configuration.Component.State.Server(new Crystal.Configuration.Component.State.Data()
            {
                Id = dto.Id
            });
            IRegistrar reg = new Crystal.Configuration.Observer.State();
            ReturnObject<Boolean> ret = reg.Register(stateServer);
            BinAff.Core.ICrud state = stateServer;
            return state.Delete();
        }

        ReturnObject<Dto> IState.Read(Dto dto)
        {
            ICrud crud = new Server(new Crystal.Configuration.Component.State.Data
            {
                Id = dto.Id
            });
            ReturnObject<BinAff.Core.Data> data = crud.Read();
            return new ReturnObject<Dto>
            {
                Value = new Dto
                {
                    Id = data.Value.Id,
                    Name = ((Crystal.Configuration.Component.State.Data)data.Value).Name
                }
            };
        }

        ReturnObject<Boolean> IState.Change(Dto dto)
        {
            ICrud crud = new Server(new Crystal.Configuration.Component.State.Data
            {
                Id = dto.Id,
                Name = dto.Name
            });
            return crud.Save();
        }

        #endregion

    }

}
