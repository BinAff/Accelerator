using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Guardian.Facade.Login
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            Account.Server accountServer = new Account.Server(new Account.FormDto
            {
                Dto = (this.FormDto as FormDto).AccountFormDto.Dto,
            });
            return accountServer.Convert(data);
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Account.Server accountServer = new Account.Server(new Account.FormDto
            {
                Dto = (this.FormDto as FormDto).AccountFormDto.Dto,
            });
            return accountServer.Convert(dto);
        }

        public void Login()
        {
            Account.Server accountServer = new Account.Server((this.FormDto as FormDto).AccountFormDto);
            accountServer.Login();
            this.IsError = accountServer.IsError;
            this.DisplayMessageList = accountServer.DisplayMessageList;
        }

    }

}
