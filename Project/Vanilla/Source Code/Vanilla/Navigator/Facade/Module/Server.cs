using System;
using System.Collections.Generic;

using BinAff.Core;

using CrystalArtifact = Crystal.Navigator.Component.Artifact;

using AutotourismCustomerForm = Autotourism.Component.Customer.Navigator.Form;

namespace Vanilla.Navigator.Facade.Module
{

    public class Server : BinAff.Facade.Library.Server
    {

        private Group currentGroup;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            Crystal.License.Data data = new Crystal.License.Data();
            (new Crystal.License.Server(data) as Crystal.License.ILicense).Get();

            FormDto formDto = this.FormDto as FormDto;

            this.currentGroup = Group.Form;
            formDto.FormModuleList = this.Convert(data.FormList);
            this.currentGroup = Group.Catalogue;
            formDto.ReportModuleList = this.Convert(data.CatalogueList);
            this.currentGroup = Group.Report;
            formDto.CatalogueModuleList = this.Convert(data.ReportList);
        }

        private List<Module.Dto> Convert(List<Data> dataList)
        {
            List<Module.Dto> ret = new List<Module.Dto>();
            foreach (Crystal.License.Module.Data module in dataList)
            {
                ret.Add(this.Convert(module) as Dto);
            }

            return ret;
        }

        protected override BinAff.Facade.Library.Dto Convert(Data data)
        {
            Module.Dto ret = new Module.Dto
            {
                Id = data.Id,
                Name = (data as Crystal.License.Module.Data).Name,
            };
            ret.Artifact = this.GetTree(ret, this.currentGroup);//mistake
            return ret;
        }

        protected override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            return new Crystal.License.Module.Data
            {
                Id = dto.Id,
                Name = (dto as Dto).Name,
            };
        }

        public Artifact.Dto GetTree(Dto module, Group group)
        {
            Artifact.Server artifactServer = new Artifact.Server(null);
            Data data;
            CrystalArtifact.IArtifact artf;
            switch (module.Name + group)
            {
                case "CustomerForm":
                    data = new AutotourismCustomerForm.Data
                    {
                        FileName = "Customer"
                    };
                    artf = new AutotourismCustomerForm.Server(data as AutotourismCustomerForm.Data);
                    break;
                default:
                    data = new AutotourismCustomerForm.Data();
                    artf = new AutotourismCustomerForm.Server(data as AutotourismCustomerForm.Data);
                    break;
            }
            return artifactServer.GetTree(artf);
        }

    }

}
