using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinAff.Core;
using ArtfCrys = Crystal.Navigator.Component.Artifact;

namespace Vanilla.Invoice.Facade.Payment
{
    public class Server : Vanilla.Form.Facade.Document.Server
    {
        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.typeList = this.ReadAllPaymentType();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            //throw new NotImplementedException();
            return new BinAff.Facade.Library.Dto();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            //throw new NotImplementedException();
            return new Data();
        }
               
        private List<Type.Dto> ReadAllPaymentType()
        {
            List<Type.Dto> paymentList = new List<Type.Dto>();
            ICrud crud = new Crystal.Invoice.Component.Payment.Type.Server(null);
            ReturnObject<List<Data>> paymentDataList = crud.ReadAll();

            if (paymentDataList != null && paymentDataList.Value != null && paymentDataList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in paymentDataList.Value)
                {
                    Crystal.Invoice.Component.Payment.Type.Data typeData = data as Crystal.Invoice.Component.Payment.Type.Data;
                    paymentList.Add(new Payment.Type.Dto
                    {
                        Id = typeData.Id,
                        Name = typeData.Name
                    });
                }
            }
            return paymentList;
        }

        protected override ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData)
        {
            return null; 
            //return new RoomChkCrys.Navigator.Artifact.Server(artifactData as RoomChkCrys.Navigator.Artifact.Data);
        }

        protected override ArtfCrys.Observer.DocumentComponent GetComponentServer()
        {
            return null;
            //this.componentServer = new RoomChkCrys.Server(this.Convert((this.FormDto as FormDto).Dto) as RoomChkCrys.Data);
            //return this.componentServer as ArtfCrys.Observer.DocumentComponent;
        }

        protected override String GetComponentDataType()
        {
            return String.Empty;
            //return "Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact.Data, Crystal.Lodge.Component";
        }
    }
}
