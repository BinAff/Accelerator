using BinAff.Core;
using System;
using System.Collections.Generic;

using AutotourismCustomerForm = Autotourism.Component.Customer.Navigator.Form;

namespace Vanilla.Navigator.Facade.Module
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            ReturnObject<List<Data>> returnObject = (new AutotourismCustomerForm.Server(new AutotourismCustomerForm.Data()) as ICrud).ReadAll();
            //ReturnObject<List<Data>> returnObject = (new Crystal.Navigator.Component.Artifact.Server(new Crystal.Navigator.Component.Artifact.Data()) as ICrud).ReadAll();
            if (returnObject.HasError())
            {
                this.DisplayMessageList = returnObject.GetMessage(Message.Type.Error);
            }
            else
            {
                (this.FormDto as FormDto).Dto.ArtifactList = this.Convert(returnObject.Value);
            }
            
        }

        private List<Facade.Artifact.Dto> Convert(List<Data> dataList)
        {
            List<Artifact.Dto> dtoList = new List<Facade.Artifact.Dto>();
            foreach (Crystal.Navigator.Component.Artifact.Data data in dataList)
            {
                dtoList.Add(this.Convert(data) as Facade.Artifact.Dto);
            }
            return dtoList;
        }

        protected override BinAff.Facade.Library.Dto Convert(Data data)
        {
            Facade.Artifact.Dto artifactDto = new Facade.Artifact.Dto();
            Crystal.Navigator.Component.Artifact.Data artifactData = data as Crystal.Navigator.Component.Artifact.Data;

            artifactDto.Id = artifactData.Id;
            artifactDto.FileName = artifactData.FileName;

            return artifactDto;
        }

        protected override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Facade.Artifact.Dto artifactDto = dto as Facade.Artifact.Dto;
            Crystal.Navigator.Component.Artifact.Data artifactData = new Crystal.Navigator.Component.Artifact.Data();

            artifactData.Id = artifactDto.Id;
            artifactData.FileName = artifactDto.FileName;

            return artifactData;
        }

    }

}
