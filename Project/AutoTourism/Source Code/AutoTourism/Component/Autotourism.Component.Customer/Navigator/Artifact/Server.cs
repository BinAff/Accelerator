using BinAff.Core;
using System;
using CrystalArtifact = Crystal.Customer.Component.Navigator.Artifact;

namespace Autotourism.Component.Customer.Navigator.Artifact
{

    public class Server : CrystalArtifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Autotourism Customer Form";
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
            //Find out customer data from customer form
            return new Autotourism.Component.Customer.Server(moduleData as Autotourism.Component.Customer.Data);
        }               

        protected override ReturnObject<bool> DeleteAfter()
        {
            if ((this.Data as Data).ModuleData != null && (this.Data as Data).ModuleData.Id > 0)
            {
                ICrud crud = new Autotourism.Component.Customer.Server(new Autotourism.Component.Customer.Data() { Id = (this.Data as Data).ModuleData.Id });
                return crud.Delete();
            }

            return base.DeleteAfter();
        }
        
    }

}
