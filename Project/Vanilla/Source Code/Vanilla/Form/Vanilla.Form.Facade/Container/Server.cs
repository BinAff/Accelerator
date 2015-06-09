using System;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

using VanAcc = Vanilla.Guardian.Facade.Account;
using ContFac = Vanilla.Utility.Facade.Container;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Form.Facade.Container
{

    public class Server : ContFac.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        protected override String GetRecentFileNodeName()
        {
            return "Form";
        }

        public override ArtfFac.Category GetCategory()
        {
            return ArtfFac.Category.Form;
        }

        public virtual void DeleteAttachment(ArtfFac.Dto attachment, Vanilla.Form.Facade.Document.Server facade)
        {
            //Not correct way
            facade.DeleteAttachment(attachment);
        }

    }

}
