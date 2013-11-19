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
            formDto.CatalogueModuleList = this.Convert(data.CatalogueList);
            this.currentGroup = Group.Report;
            formDto.ReportModuleList = this.Convert(data.ReportList);
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

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            Module.Dto ret = new Module.Dto
            {
                Id = data.Id,
                Code = (data as Crystal.License.Module.Data).Code,
                Name = (data as Crystal.License.Module.Data).Name,
            };
            ret.Artifact = this.GetTree(ret, this.currentGroup);//mistake
            return ret;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            return new Crystal.License.Module.Data
            {
                Id = dto.Id,
                Code = (dto as Dto).Code,
                Name = (dto as Dto).Name,
            };
        }

        public Artifact.Dto GetTree(Dto module, Group group)
        {
            Artifact.Server artifactServer = new Artifact.Server(null);
            switch (group)
            {
                case Group.Form:
                    artifactServer = new Form.Server(null);
                    break;
                case Group.Catalogue:
                    artifactServer = new Form.Server(null);//Need to change
                    break;
                case Group.Report:
                    artifactServer = new Form.Server(null);//Need to change
                    break;
            }

            Data data;
            CrystalArtifact.IArtifact artf;
            switch (module.Code + "-" + group)
            {
                case "CUST-Form":
                    data = new AutotourismCustomerForm.Data
                    {
                        FileName = "Customer",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerForm.Server(data as AutotourismCustomerForm.Data);
                    (artifactServer as Form.Server).ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;
                case "CUST-Report"://Need to change
                    data = new AutotourismCustomerForm.Data
                    {
                        FileName = "Customer",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerForm.Server(data as AutotourismCustomerForm.Data);
                    (artifactServer as Form.Server).ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;
                case "LRSV-Form"://Need to change
                    data = new AutotourismCustomerForm.Data
                    {
                        FileName = "Lodge Reservation",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerForm.Server(data as AutotourismCustomerForm.Data);
                    (artifactServer as Form.Server).ModuleFacade = new AutoTourism.Customer.Facade.Server(null);//Need to change
                    break;
                case "ROOM-Form"://Need to change
                    data = new AutotourismCustomerForm.Data
                    {
                        FileName = "Room",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerForm.Server(data as AutotourismCustomerForm.Data);
                    (artifactServer as Form.Server).ModuleFacade = new AutoTourism.Customer.Facade.Server(null);//Need to change
                    break;
                default://Need to change
                    data = new AutotourismCustomerForm.Data
                    {
                        FileName = "Customer",
                        ModuleData = this.Convert(module),
                    };
                    artf = new AutotourismCustomerForm.Server(data as AutotourismCustomerForm.Data);
                    (artifactServer as Form.Server).ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;
            }
            return artifactServer.GetTree(artf);
        }

    }

}
