
using BinAff.Core;
using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact
{
    public class Server : CrystalNavigator.Artifact.Server
    {
        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Lodge CheckIn " + (this.Data as Data).Category.ToString();
            (this.Data as Data).Extension = "frm";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
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
            return new Crystal.Lodge.Component.Room.CheckIn.Server(moduleData as Crystal.Lodge.Component.Room.CheckIn.Data);
        }

        //protected override ReturnObject<bool> DeleteAfter()
        //{
        //    if ((this.Data as Data).ComponentData != null && (this.Data as Data).ComponentData.Id > 0)
        //    {
        //        ICrud crud = new Crystal.Lodge.Component.Room.CheckIn.Server(new Crystal.Lodge.Component.Room.CheckIn.Data() { Id = (this.Data as Data).ComponentData.Id });
        //        return crud.Delete();
        //    }

        //    return base.DeleteAfter();
        //}
    }
}
