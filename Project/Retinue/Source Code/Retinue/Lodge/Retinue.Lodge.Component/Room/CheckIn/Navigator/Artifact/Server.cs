using ArtfComp = Crystal.Navigator.Component.Artifact;
using PayArtfCrys = Crystal.Accountant.Component.Payment.Navigator.Artifact;

using ChkInRet = Retinue.Lodge.Component.Room.CheckIn;

namespace Retinue.Lodge.Component.Room.CheckIn.Navigator.Artifact
{

    public class Server : ArtfComp.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Lodge CheckIn " + (this.Data as Data).Category.ToString();
            (this.Data as Data).Extension = "frm";
            (this.Data as Data).IsAttachmentSupported = true;
            this.DataAccess = new Dao(this.Data as Data);
            this.Validator = new Validator(this.Data as Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data
            {
                Category = (this.Data as Data).Category
            };
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData)
        {
            //Find out CheckIn data from CheckIn form
            return new ChkInRet.Server(moduleData as ChkInRet.Data);
        }

        protected override ArtfComp.Server GetAttachmentServer(ArtfComp.Data attachment)
        {
            return new PayArtfCrys.Server(new PayArtfCrys.Data { Id = attachment.Id });
        }

    }

}
