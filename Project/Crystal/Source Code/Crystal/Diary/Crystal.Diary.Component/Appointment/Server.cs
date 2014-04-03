using System.Collections.Generic;

namespace Crystal.Diary.Component.Appointment
{

    public class Server : BinAff.Core.Crud, IAppointment
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Appointment";
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

        protected override void CreateChildren()
        {
            base.AddChild(new Type.Server(((Data)this.Data).Type)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Importance.Server(((Data)this.Data).Importance)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        BinAff.Core.ReturnObject<List<BinAff.Core.Data>> IAppointment.Search(System.DateTime start, System.DateTime end)
        {
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> ret = new BinAff.Core.ReturnObject<List<BinAff.Core.Data>>
            {
                Value = (base.DataAccess as Dao).Search(start, end)
            };

            if (ret.Value == null)
            {
                ret.MessageList = new List<BinAff.Core.Message>
                {
                    new BinAff.Core.Message("Cannot find any data.", BinAff.Core.Message.Type.Information)
                };
            }

            return ret;
        }

        BinAff.Core.ReturnObject<List<BinAff.Core.Data>> IAppointment.Search(System.DateTime start, System.DateTime end, Importance.Data importance)
        {
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> ret = new BinAff.Core.ReturnObject<List<BinAff.Core.Data>>
            {
                Value = (base.DataAccess as Dao).Search(start, end, importance)
            };

            if (ret.Value == null)
            {
                ret.MessageList = new List<BinAff.Core.Message>
                {
                    new BinAff.Core.Message("Cannot find any data.", BinAff.Core.Message.Type.Information)
                };
            }

            return ret;
        }

    }

}
