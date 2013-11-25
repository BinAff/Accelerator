using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrystalArtifact = Crystal.Navigator.Component.Artifact;

namespace Vanilla.Navigator.Facade.Module
{

    public class Helper
    {

        Module.Dto moduleDef;
        public Helper(Module.Dto moduleDef)
        {
            this.moduleDef = moduleDef;
            this.GetObjects();
        }

        public CrystalArtifact.IArtifact Artifact
        {
            get
            {
                Type type = Type.GetType(this.ArtifacComponentType + ", " + this.ArtifacComponentAssembly, true);
                CrystalArtifact.Server artifact = Activator.CreateInstance(type, this.ArtifactData) as CrystalArtifact.Server;
                (artifact.Data as CrystalArtifact.Data).ModuleData = this.ModuleData;
                return artifact;
            }
        }

        public BinAff.Core.ICrud ArtifactComponent 
        {
            get
            {
                Type type = Type.GetType(this.ArtifacComponentType + ", " + this.ArtifacComponentAssembly, true);
                CrystalArtifact.Server artifact = Activator.CreateInstance(type, this.ArtifactData) as CrystalArtifact.Server;
                (artifact.Data as CrystalArtifact.Data).ModuleData = this.ModuleData;
                return artifact;
            }
        }

        private BinAff.Core.Data artfactData;
        public BinAff.Core.Data ArtifactData
        {
            get
            {
                if (this.artfactData == null)
                {
                    Type type = Type.GetType(this.ArtifactDataType + ", " + this.ArtifacComponentAssembly, true);
                    this.artfactData = Activator.CreateInstance(type) as CrystalArtifact.Data;
                    if (this.artfactData == null)
                    {
                        type.GetProperty("FileName").SetValue(artfactData, "Customer", null);
                    }
                    else
                    {
                    }
                }
                return this.artfactData;
            }
            set
            {
                Type type = Type.GetType(this.ArtifactDataType + ", " + this.ArtifacComponentAssembly, true);
                this.artfactData = Activator.CreateInstance(type) as CrystalArtifact.Data;
                this.artfactData = value;
            }
        }

        public BinAff.Facade.Library.Server ModuleFacade { get; set; }

        private BinAff.Core.Data moduleData;
        public BinAff.Core.Data ModuleData
        {
            get
            {
                if (this.moduleData == null)
                {
                    Type type = Type.GetType(this.ModuleDataType, true);
                    this.moduleData = Activator.CreateInstance(type) as BinAff.Core.Data;
                }
                return this.moduleData;
            }
        }

        public String ModuleFormType { get; set; }
        public String ModuleFormDtoType { get; set; }
        public String ArtifactDataType { get; set; }
        public String ArtifacComponentType { get; set; }
        public String ArtifacComponentAssembly { get; set; }
        public String ModuleDataType { get; set; }

        internal Helper GetObjects()
        {
            switch (this.moduleDef.Code)
            {
                case "CUST":
                    this.ModuleFormType = "AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Customer.Facade.Dto, AutoTourism.Customer.Facade";
                    this.ArtifacComponentAssembly = "Autotourism.Component.Customer";
                    this.ArtifactDataType = "Autotourism.Component.Customer.Navigator.Artifact.Data";
                    this.ArtifacComponentType = "Autotourism.Component.Customer.Navigator.Artifact.Server";
                    this.ModuleDataType = "Autotourism.Component.Customer.Data, Autotourism.Component.Customer";
                    //if (helper.ModuleData == null)
                    //{
                    //(this.ModuleData as CrystalArtifact.Data).ModuleData = this.Convert(module);
                    //}
                    //Type type;
                    //if (helper.ModuleData == null)
                    //{
                    //    type = Type.GetType("Autotourism.Component.Customer.Navigator.Artifact.Data, Autotourism.Component.Customer", true);
                    //    helper.ModuleData = Activator.CreateInstance(type) as CrystalArtifact.Data;
                    //    type.GetProperty("FileName").SetValue(helper.ModuleData, "Customer", null);
                    //    type.GetProperty("ModuleData").SetValue(helper.ModuleData, this.Convert(module), null);
                    //}
                    //else
                    //{
                    //}
                    //type = Type.GetType("Autotourism.Component.Customer.Navigator.Artifact.Server, Autotourism.Component.Customer", true);
                    //helper.Artifact = Activator.CreateInstance(type, helper.ModuleData) as CrystalArtifact.IArtifact;

                    //Some problem, objects are not getting instantiated -- Arpan
                    //type = Type.GetType("AutoTourism.Customer.Facade.FormDto, AutoTourism.Customer.Facade", true);
                    //BinAff.Facade.Library.FormDto formDto = Activator.CreateInstance(type) as BinAff.Facade.Library.FormDto;
                    //type = Type.GetType("AutoTourism.Customer.Facade.Server, AutoTourism.Customer.Facade", true);
                    //helper.ModuleFacade = Activator.CreateInstance(type, formDto) as Module.Server;
                    this.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;

                case "LRSV"://Need to change
                    //helper.FormType = "AutoTourism.Lodge.WinForm.Lodge, AutoTourism.Lodge.WinForm";
                    //helper.Artifact = new AutotourismCustomerArtifact.Server(new AutotourismCustomerArtifact.Data
                    //{
                    //    FileName = "Lodge Reservation",
                    //    ModuleData = this.Convert(module),
                    //} as AutotourismCustomerArtifact.Data);
                    //helper.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;

                default:
                    //helper.FormType = "AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm";
                    //helper.Artifact = new AutotourismCustomerArtifact.Server(new AutotourismCustomerArtifact.Data
                    //{
                    //    FileName = "Customer",
                    //    ModuleData = this.Convert(module),
                    //} as AutotourismCustomerArtifact.Data);
                    //helper.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);
                    break;
            }
            return this;
        }

    }

}
