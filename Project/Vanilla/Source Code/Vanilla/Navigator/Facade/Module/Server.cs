using System;
using System.Collections.Generic;

using BinAff.Core;

using CrystalArtifact = Crystal.Navigator.Component.Artifact;

using AutotourismCustomerArtifact = Autotourism.Component.Customer.Navigator.Artifact;

namespace Vanilla.Navigator.Facade.Module
{

    public class Server : BinAff.Facade.Library.Server
    {

        private Artifact.Category currentGroup;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            Crystal.License.Data data = new Crystal.License.Data();
            (new Crystal.License.Server(data) as Crystal.License.ILicense).Get();

            FormDto formDto = this.FormDto as FormDto;

            this.currentGroup = Artifact.Category.Form;
            formDto.FormModuleList = this.Convert(data.FormList);
            this.currentGroup = Artifact.Category.Catalogue;
            formDto.CatalogueModuleList = this.Convert(data.CatalogueList);
            this.currentGroup = Artifact.Category.Report;
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

        private Helper GetObjects(Dto module)
        {
            Helper helper = new Helper();
            switch (module.Code)
            {
                case "CUST":
                    helper.FormType = "AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm";

                    Type type = Type.GetType("Autotourism.Component.Customer.Navigator.Artifact.Data, Autotourism.Component.Customer", true);
                    CrystalArtifact.Data data = Activator.CreateInstance(type) as CrystalArtifact.Data;
                    type.GetProperty("FileName").SetValue(data, "Customer", null);
                    type.GetProperty("ModuleData").SetValue(data, this.Convert(module), null);

                    type = Type.GetType("Autotourism.Component.Customer.Navigator.Artifact.Server, Autotourism.Component.Customer", true);
                    helper.Artifact = Activator.CreateInstance(type, data) as CrystalArtifact.IArtifact;

                    //Some problem, objects are not getting instantiated -- Arpan
                    //type = Type.GetType("AutoTourism.Customer.Facade.FormDto, AutoTourism.Customer.Facade", true);
                    //BinAff.Facade.Library.FormDto formDto = Activator.CreateInstance(type) as BinAff.Facade.Library.FormDto;
                    //type = Type.GetType("AutoTourism.Customer.Facade.Server, AutoTourism.Customer.Facade", true);
                    //helper.ModuleFacade = Activator.CreateInstance(type, formDto) as Module.Server;
                    helper.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;

                case "LRSV"://Need to change
                    helper.FormType = "AutoTourism.Lodge.WinForm.Lodge, AutoTourism.Lodge.WinForm";
                    helper.Artifact = new AutotourismCustomerArtifact.Server(new AutotourismCustomerArtifact.Data
                    {
                        FileName = "Lodge Reservation",
                        ModuleData = this.Convert(module),
                    } as AutotourismCustomerArtifact.Data);
                    helper.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;

                default:
                    helper.FormType = "AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm";
                    helper.Artifact = new AutotourismCustomerArtifact.Server(new AutotourismCustomerArtifact.Data
                    {
                        FileName = "Customer",
                        ModuleData = this.Convert(module),
                    } as AutotourismCustomerArtifact.Data);
                    helper.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;
            }
            return helper;
        }

        public Artifact.Dto GetTree(Dto module, Artifact.Category category)
        {
            Artifact.Server artifactServer = new Artifact.Server(null);
            Helper helper = this.GetObjects(module);
            artifactServer.ModuleFacade = helper.ModuleFacade;
            ((helper.Artifact as CrystalArtifact.Server).Data as CrystalArtifact.Data).Category = this.Convert(category);
            return artifactServer.GetTree(helper.Artifact);
        }

        private CrystalArtifact.Category Convert(Artifact.Category category)
        {
            CrystalArtifact.Category ret;
            switch (category)
            {
                case Artifact.Category.Form:
                    ret = CrystalArtifact.Category.Form;
                    break;
                case Artifact.Category.Catalogue:
                    ret = CrystalArtifact.Category.Catelogue;
                    break;
                case Artifact.Category.Report:
                    ret = CrystalArtifact.Category.Report;
                    break;
                default:
                    ret = CrystalArtifact.Category.Form;
                    break;
            }
            return ret;
        }

    }

}
