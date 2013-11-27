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
            return new Data();
        }

        //protected override void CreateChildren()
        //{
        //    base.CreateChildren();
        //    thi
        //}

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData)
        {
            //Find out customer data from customer form
            return new Autotourism.Component.Customer.Server(moduleData as Autotourism.Component.Customer.Data);
        }

        protected override ReturnObject<bool> DeleteBefore()
        { 
            //Boolean retVal = new Dao((Data)this.Data).Delete();

            //if (retVal)
            //{
            //    ICrud crud = new Autotourism.Component.Customer.Server(new Autotourism.Component.Customer.Data() { Id = 5 });
            //    return crud.Delete();
            //}

            return new ReturnObject<bool> { 
                Value = true
            };
        }
        
    }

}
