using System;

using FacLib = BinAff.Facade.Library;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

namespace Vanilla.Utility.Facade.Module
{

    public class Helper
    {

        Module.Dto moduleDef;
        String facadeTypeName;
        String formDtoTypeName;
        Artifact.Category artifactCategory;

        public Helper(Module.Dto moduleDef, Artifact.Category artifactCategory)
        {
            this.moduleDef = moduleDef;
            this.artifactCategory = artifactCategory;
            //if (artifactCategory == Facade.Artifact.Category.Form)
            //    this.GetObjects();
            if (artifactCategory == Facade.Artifact.Category.Report)
                this.GetObjectsForReport();
            else
                this.GetObjects();


            Type facadeType = Type.GetType(this.facadeTypeName, true);
            Type formDtoType = Type.GetType(this.formDtoTypeName, true);

            FacLib.FormDto formDto = (FacLib.FormDto)Activator.CreateInstance(formDtoType);
            formDtoType.GetProperty("Dto").SetValue(formDto, Activator.CreateInstance(Type.GetType(this.ModuleFormDtoType)), null);
            this.ModuleFacade = (FacLib.Server)Activator.CreateInstance(facadeType, formDto);

            Type type = Type.GetType(this.ArtifactDataType + ", " + this.ArtifactComponentAssembly, true);
            this.ArtifactData = Activator.CreateInstance(type) as ArtfCrys.Data;
            this.ArtifactData.Category = (ArtfCrys.Category)this.artifactCategory;
            if (this.ArtifactData == null)
            {
                type.GetProperty("FileName").SetValue(this.ArtifactData, "Customer", null);
            }
            else
            {
            }

        }

        public ArtfCrys.IArtifact Artifact
        {
            get
            {
                return this.GetArtifactServer();
            }
        }

        public BinAff.Core.ICrud ArtifactComponent
        {
            get
            {
                return this.GetArtifactServer();
            }
        }

        private ArtfCrys.Server GetArtifactServer()
        {
            Type type = Type.GetType(this.ArtifactComponentType + ", " + this.ArtifactComponentAssembly, true);
            ArtfCrys.Server artifact = Activator.CreateInstance(type, this.ArtifactData) as ArtfCrys.Server;
            (artifact.Data as ArtfCrys.Data).ComponentData = this.ModuleData;
            return artifact;
        }

        public ArtfCrys.Data ArtifactData { get; set; }

        public FacLib.Server ModuleFacade { get; set; }

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
        public String ArtifactComponentType { get; set; }
        public String ArtifactComponentAssembly { get; set; }
        public String ModuleDataType { get; set; }

        internal Helper GetObjects()
        {
            switch (this.moduleDef.Code)
            {
                case "CUST":
                    this.ModuleFormType = "AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Customer.Facade.Dto, AutoTourism.Customer.Facade";
                    this.ArtifactComponentAssembly = "AutoTourism.Component.Customer";
                    this.ArtifactDataType = "AutoTourism.Component.Customer.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "AutoTourism.Component.Customer.Navigator.Artifact.Server";
                    this.ModuleDataType = "AutoTourism.Component.Customer.Data, AutoTourism.Component.Customer";
                    this.facadeTypeName = "AutoTourism.Customer.Facade.Server,AutoTourism.Customer.Facade";
                    this.formDtoTypeName = "AutoTourism.Customer.Facade.FormDto,AutoTourism.Customer.Facade";
                    break;

                case "LRSV"://Need to change
                    this.ModuleFormType = "AutoTourism.Lodge.WinForm.RoomReservationForm, AutoTourism.Lodge.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Lodge.Facade.RoomReservation.Dto, AutoTourism.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Lodge.Component";
                    this.ArtifactDataType = "Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Lodge.Component.Room.Reservation.Data, Crystal.Lodge.Component";
                    this.facadeTypeName = "AutoTourism.Lodge.Facade.RoomReservation.Server,AutoTourism.Lodge.Facade";
                    this.formDtoTypeName = "AutoTourism.Lodge.Facade.RoomReservation.FormDto,AutoTourism.Lodge.Facade";
                    break;

                case "LCHK"://Need to change
                    this.ModuleFormType = "AutoTourism.Lodge.WinForm.CheckInForm, AutoTourism.Lodge.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Lodge.Facade.CheckIn.Dto, AutoTourism.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Lodge.Component";
                    this.ArtifactDataType = "Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Lodge.Component.Room.CheckIn.Data, Crystal.Lodge.Component";
                    this.facadeTypeName = "AutoTourism.Lodge.Facade.CheckIn.Server,AutoTourism.Lodge.Facade";
                    this.formDtoTypeName = "AutoTourism.Lodge.Facade.CheckIn.FormDto,AutoTourism.Lodge.Facade";
                    break;

                case "INVO":                   
                    this.ModuleFormType = "Vanilla.Invoice.WinForm.Invoice, Vanilla.Invoice.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Invoice.Facade.Dto, Vanilla.Invoice.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Invoice.Component";
                    this.ArtifactDataType = "Crystal.Invoice.Component.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Invoice.Component.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Invoice.Component.Data, Crystal.Invoice.Component";
                    this.facadeTypeName = "Vanilla.Invoice.Facade.Server,Vanilla.Invoice.Facade";
                    this.formDtoTypeName = "Vanilla.Invoice.Facade.FormDto,Vanilla.Invoice.Facade";
                    break;

                case "PAMT":
                    this.ModuleFormType = "Vanilla.Invoice.WinForm.PaymentForm, Vanilla.Invoice.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Invoice.Facade.Payment.Dto, Vanilla.Invoice.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Invoice.Component";
                    this.ArtifactDataType = "Crystal.Invoice.Component.Payment.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Invoice.Component.Payment.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Invoice.Component.Payment.Data, Crystal.Invoice.Component";
                    this.facadeTypeName = "Vanilla.Invoice.Facade.Payment.Server, Vanilla.Invoice.Facade";
                    this.formDtoTypeName = "Vanilla.Invoice.Facade.Payment.FormDto, Vanilla.Invoice.Facade";
                    break;

                case "APMT":
                    this.ModuleFormType = "Vanilla.Invoice.WinForm.AdvancePaymentForm, Vanilla.Invoice.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Invoice.Facade.AdvancePayment.Dto, Vanilla.Invoice.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Invoice.Component";
                    this.ArtifactDataType = "Crystal.Invoice.Component.AdvancePayment.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Invoice.Component.AdvancePayment.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Invoice.Component.AdvancePayment.Data, Crystal.Invoice.Component";
                    this.facadeTypeName = "Vanilla.Invoice.Facade.AdvancePayment.Server, Vanilla.Invoice.Facade";
                    this.formDtoTypeName = "Vanilla.Invoice.Facade.AdvancePayment.FormDto, Vanilla.Invoice.Facade";
                    break;
                default: //Default is Customer
                    this.ModuleFormType = "AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Customer.Facade.Dto, AutoTourism.Customer.Facade";
                    this.ArtifactComponentAssembly = "AutoTourism.Component.Customer";
                    this.ArtifactDataType = "AutoTourism.Component.Customer.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "AutoTourism.Component.Customer.Navigator.Artifact.Server";
                    this.ModuleDataType = "AutoTourism.Component.Customer.Data, AutoTourism.Component.Customer";
                    this.facadeTypeName = "AutoTourism.Customer.Facade.Server,AutoTourism.Customer.Facade";
                    this.formDtoTypeName = "AutoTourism.Customer.Facade.FormDto,AutoTourism.Customer.Facade";
                    break;
            }

            return this;
        }

        internal Helper GetObjectsForReport()
        {
            this.ModuleFormType = "Vanilla.Report.WinForm.Document, Vanilla.Report.WinForm";
            switch (this.moduleDef.Code)
            {
                case "CUST":
                    this.ModuleFormDtoType = "AutoTourism.Customer.Facade.Report.Dto, AutoTourism.Customer.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Customer.Component";
                    this.ArtifactDataType = "Crystal.Customer.Component.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Customer.Component.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Customer.Component.Report.Data, Crystal.Customer.Component";

                    this.facadeTypeName = "AutoTourism.Customer.Facade.Report.Server,AutoTourism.Customer.Facade";
                    this.formDtoTypeName = "AutoTourism.Customer.Facade.Report.FormDto,AutoTourism.Customer.Facade";
                    break;

                case "LRSV"://Need to change
                    //this.ModuleFormType = "AutoTourism.Lodge.WinForm.RoomReservationForm, AutoTourism.Lodge.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Lodge.Facade.RoomReservationReport.Dto, AutoTourism.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Lodge.Component";
                    this.ArtifactDataType = "Crystal.Lodge.Component.RoomReservationReport.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Lodge.Component.RoomReservationReport.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Lodge.Component.RoomReservationReport.Data, Crystal.Lodge.Component";

                    this.facadeTypeName = "AutoTourism.Lodge.Facade.RoomReservationReport.Server,AutoTourism.Lodge.Facade";
                    this.formDtoTypeName = "AutoTourism.Lodge.Facade.RoomReservationReport.FormDto,AutoTourism.Lodge.Facade";
                    break;

                case "LCHK"://Need to change
                    //this.ModuleFormType = "AutoTourism.Lodge.WinForm.CheckInForm, AutoTourism.Lodge.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Lodge.Facade.CheckInReport.Dto, AutoTourism.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Lodge.Component";
                    this.ArtifactDataType = "Crystal.Lodge.Component.CheckInReport.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Lodge.Component.CheckInReport.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Lodge.Component.CheckInReport.Data, Crystal.Lodge.Component";

                    this.facadeTypeName = "AutoTourism.Lodge.Facade.CheckInReport.Server,AutoTourism.Lodge.Facade";
                    this.formDtoTypeName = "AutoTourism.Lodge.Facade.CheckInReport.FormDto,AutoTourism.Lodge.Facade";
                    break;

                case "INVO":
                    //this.ModuleFormType = "Vanilla.Invoice.WinForm.Invoice, Vanilla.Invoice.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Invoice.Facade.Report.Dto, Vanilla.Invoice.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Invoice.Component";
                    this.ArtifactDataType = "Crystal.Invoice.Component.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Invoice.Component.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Invoice.Component.Report.Data, Crystal.Invoice.Component";

                    this.facadeTypeName = "Vanilla.Invoice.Facade.Report.Server,Vanilla.Invoice.Facade";
                    this.formDtoTypeName = "Vanilla.Invoice.Facade.Report.FormDto,Vanilla.Invoice.Facade";
                    break;
                default: //Default is customer
                    this.ModuleFormDtoType = "AutoTourism.Customer.Facade.Report.Dto, AutoTourism.Customer.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Customer.Component";
                    this.ArtifactDataType = "Crystal.Customer.Component.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Customer.Component.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Customer.Component.Report.Data, Crystal.Customer.Component";

                    this.facadeTypeName = "AutoTourism.Customer.Facade.Report.Server,AutoTourism.Customer.Facade";
                    this.formDtoTypeName = "AutoTourism.Customer.Facade.Report.FormDto,AutoTourism.Customer.Facade";
                    break;
            }

            //FacLib.FormDto reportDto = (FacLib.FormDto)Activator.CreateInstance(typeReportDto);
            //typeReportDto.GetProperty("Dto").SetValue(reportDto, Activator.CreateInstance(Type.GetType(this.ModuleFormDtoType)), null);

            //this.ModuleFacade = (FacLib.Server)Activator.CreateInstance(typeReportServer, reportDto);
            return this;
        }

    }

}