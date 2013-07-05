namespace Crystal.License.Module
{

    public class Server : BinAff.Core.Crud 
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "License Module";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

        //Need to delete this function. Hard coding
        protected override BinAff.Core.ReturnObject<System.Collections.Generic.List<BinAff.Core.Data>> ReadAll()
        {
            return new BinAff.Core.ReturnObject<System.Collections.Generic.List<BinAff.Core.Data>>
            {
                Value = new System.Collections.Generic.List<BinAff.Core.Data>
                {
                    new Data{Id = 1, Name = "Customer", IsForm = true, IsReport = true, },                
                    new Data{Id = 1, Name = "Room", IsCatalogue = true, IsReport = true, },
                    new Data{Id = 1, Name = "Room Reservation", IsForm = true, IsReport = true, },
                    new Data{Id = 1, Name = "Check In", IsForm = true, IsReport = true, },
                    new Data{Id = 1, Name = "Laundry", IsForm = true, IsReport = true, IsCatalogue = true },
                    new Data{Id = 1, Name = "Room Service", IsForm = true, IsReport = true, IsCatalogue = true },
                }
            };
        }
        //public override System.Collections.Generic.List<BinAff.Core.Data> ReadAll()
        //{
        //    return new System.Collections.Generic.List<BinAff.Core.Data>
        //    {
        //        new Data{Id = 1, Name = "Customer", IsForm = true, IsReport = true, },                
        //        new Data{Id = 1, Name = "Room", IsCatalogue = true, IsReport = true, },
        //        new Data{Id = 1, Name = "Room Reservation", IsForm = true, IsReport = true, },
        //        new Data{Id = 1, Name = "Check In", IsForm = true, IsReport = true, },
        //        new Data{Id = 1, Name = "Laundry", IsForm = true, IsReport = true, IsCatalogue = true },
        //        new Data{Id = 1, Name = "Room Service", IsForm = true, IsReport = true, IsCatalogue = true },
        //    };
        //}

    }

}
