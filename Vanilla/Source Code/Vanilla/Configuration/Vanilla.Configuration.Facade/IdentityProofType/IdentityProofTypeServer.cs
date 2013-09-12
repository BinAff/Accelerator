using System;
using System.Collections.Generic;

using BinAff.Core;
using Crystal.Configuration.Component.IdentityProofType;
using BinAff.Core.Observer;


namespace Vanilla.Configuration.Facade.IdentityProofType
{

    public class IdentityProofTypeServer : IIdentityProofType
    {

        #region IIdentityProofType

        ReturnObject<FormDto> IIdentityProofType.LoadForm()
        {
            ICrud crud = new Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();
            ReturnObject<FormDto> ret = new ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    IdentityProofList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (Crystal.Configuration.Component.IdentityProofType.Data data in dataList.Value)
            {
                ret.Value.IdentityProofList.Add(new Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        ReturnObject<Boolean> IIdentityProofType.Add(Dto dto)
        {
            ICrud crud = new Server(new Crystal.Configuration.Component.IdentityProofType.Data
            {
                Name = dto.Name
            });
            return crud.Save();
        }

        ReturnObject<Boolean> IIdentityProofType.Delete(Dto dto)
        {
            Crystal.Configuration.Component.IdentityProofType.Server identityProofTypeServer = new Crystal.Configuration.Component.IdentityProofType.Server(new Crystal.Configuration.Component.IdentityProofType.Data()
            {
                Id = dto.Id
            });
            IRegistrar reg = new Crystal.Configuration.Observer.IdentityProofType();
            ReturnObject<Boolean> ret = reg.Register(identityProofTypeServer);
            BinAff.Core.ICrud identityProofType = identityProofTypeServer;
            return identityProofType.Delete();
        }

        ReturnObject<Dto> IIdentityProofType.Read(Dto dto)
        {
            ICrud crud = new Server(new Crystal.Configuration.Component.IdentityProofType.Data
            {
                Id = dto.Id
            });
            ReturnObject<BinAff.Core.Data> data = crud.Read();
            return new ReturnObject<Dto>
            {
                Value = new Dto
                {
                    Id = data.Value.Id,
                    Name = ((Crystal.Configuration.Component.IdentityProofType.Data)data.Value).Name
                }
            };
        }

        ReturnObject<Boolean> IIdentityProofType.Change(Dto dto)
        {
            ICrud crud = new Server(new Crystal.Configuration.Component.IdentityProofType.Data
            {
                Id = dto.Id,
                Name = dto.Name
            });
            return crud.Save();
        }

        #endregion

    }

}
