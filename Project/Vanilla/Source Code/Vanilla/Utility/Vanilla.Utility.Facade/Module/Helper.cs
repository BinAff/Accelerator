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
                    this.ModuleFormType = "Retinue.Customer.WinForm.CustomerForm, Retinue.Customer.WinForm";
                    this.ModuleFormDtoType = "Retinue.Customer.Facade.Dto, Retinue.Customer.Facade";
                    this.ArtifactComponentAssembly = "Retinue.Customer.Component";
                    this.ArtifactDataType = "Retinue.Customer.Component.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Retinue.Customer.Component.Navigator.Artifact.Server";
                    this.ModuleDataType = "Retinue.Customer.Component.Data, Retinue.Customer.Component";
                    this.facadeTypeName = "Retinue.Customer.Facade.Server,Retinue.Customer.Facade";
                    this.formDtoTypeName = "Retinue.Customer.Facade.FormDto,Retinue.Customer.Facade";
                    break;

                case "LRSV"://Need to change
                    this.ModuleFormType = "Retinue.Lodge.WinForm.RoomReservationForm, Retinue.Lodge.WinForm";
                    this.ModuleFormDtoType = "Retinue.Lodge.Facade.RoomReservation.Dto, Retinue.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Retinue.Lodge.Component";
                    this.ArtifactDataType = "Retinue.Lodge.Component.Room.Reservation.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Retinue.Lodge.Component.Room.Reservation.Navigator.Artifact.Server";
                    this.ModuleDataType = "Retinue.Lodge.Component.Room.Reservation.Data, Retinue.Lodge.Component";
                    this.facadeTypeName = "Retinue.Lodge.Facade.RoomReservation.Server,Retinue.Lodge.Facade";
                    this.formDtoTypeName = "Retinue.Lodge.Facade.RoomReservation.FormDto,Retinue.Lodge.Facade";
                    break;

                case "LCHK"://Need to change
                    this.ModuleFormType = "Retinue.Lodge.WinForm.CheckInForm, Retinue.Lodge.WinForm";
                    this.ModuleFormDtoType = "Retinue.Lodge.Facade.CheckIn.Dto, Retinue.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Retinue.Lodge.Component";
                    this.ArtifactDataType = "Retinue.Lodge.Component.Room.CheckIn.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Retinue.Lodge.Component.Room.CheckIn.Navigator.Artifact.Server";
                    this.ModuleDataType = "Retinue.Lodge.Component.Room.CheckIn.Data, Retinue.Lodge.Component";
                    this.facadeTypeName = "Retinue.Lodge.Facade.CheckIn.Server,Retinue.Lodge.Facade";
                    this.formDtoTypeName = "Retinue.Lodge.Facade.CheckIn.FormDto,Retinue.Lodge.Facade";
                    break;

                case "INVO":
                    this.ModuleFormType = "Vanilla.Accountant.WinForm.InvoiceForm, Vanilla.Accountant.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Accountant.Facade.Invoice.Dto, Vanilla.Accountant.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Accountant.Component";
                    this.ArtifactDataType = "Crystal.Accountant.Component.Invoice.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Accountant.Component.Invoice.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Accountant.Component.Invoice.Data, Crystal.Accountant.Component";
                    this.facadeTypeName = "Vanilla.Accountant.Facade.Invoice.Server,Vanilla.Accountant.Facade";
                    this.formDtoTypeName = "Vanilla.Accountant.Facade.Invoice.FormDto,Vanilla.Accountant.Facade";
                    break;

                case "PAMT":
                    this.ModuleFormType = "Vanilla.Accountant.WinForm.PaymentForm, Vanilla.Accountant.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Accountant.Facade.Payment.Dto, Vanilla.Accountant.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Accountant.Component";
                    this.ArtifactDataType = "Crystal.Accountant.Component.Payment.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Accountant.Component.Payment.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Accountant.Component.Payment.Data, Crystal.Accountant.Component";
                    this.facadeTypeName = "Vanilla.Accountant.Facade.Payment.Server, Vanilla.Accountant.Facade";
                    this.formDtoTypeName = "Vanilla.Accountant.Facade.Payment.FormDto, Vanilla.Accountant.Facade";
                    break;
                default: //Default is Customer
                    this.ModuleFormType = "Retinue.Customer.WinForm.CustomerForm, Retinue.Customer.WinForm";
                    this.ModuleFormDtoType = "Retinue.Customer.Facade.Dto, Retinue.Customer.Facade";
                    this.ArtifactComponentAssembly = "Retinue.Customer.Component";
                    this.ArtifactDataType = "Retinue.Customer.Component.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Retinue.Customer.Component.Navigator.Artifact.Server";
                    this.ModuleDataType = "Retinue.Customer.Component.Data, Retinue.Customer.Component";
                    this.facadeTypeName = "Retinue.Customer.Facade.Server,Retinue.Customer.Facade";
                    this.formDtoTypeName = "Retinue.Customer.Facade.FormDto,Retinue.Customer.Facade";
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
                    this.ModuleFormDtoType = "Retinue.Customer.Facade.Report.Dto, Retinue.Customer.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Customer.Component";
                    this.ArtifactDataType = "Crystal.Customer.Component.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Customer.Component.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Customer.Component.Report.Data, Crystal.Customer.Component";

                    this.facadeTypeName = "Retinue.Customer.Facade.Report.Server, Retinue.Customer.Facade";
                    this.formDtoTypeName = "Retinue.Customer.Facade.Report.FormDto, Retinue.Customer.Facade";
                    break;

                case "LRSV"://Need to change
                    //this.ModuleFormType = "Retinue.Lodge.WinForm.RoomReservationForm, Retinue.Lodge.WinForm";
                    this.ModuleFormDtoType = "Retinue.Lodge.Facade.RoomReservationReport.Dto, Retinue.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Retinue.Lodge.Component";
                    this.ArtifactDataType = "Retinue.Lodge.Component.RoomReservationReport.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Retinue.Lodge.Component.RoomReservationReport.Navigator.Artifact.Server";
                    this.ModuleDataType = "Retinue.Lodge.Component.RoomReservationReport.Data, Retinue.Lodge.Component";

                    this.facadeTypeName = "Retinue.Lodge.Facade.RoomReservationReport.Server, Retinue.Lodge.Facade";
                    this.formDtoTypeName = "Retinue.Lodge.Facade.RoomReservationReport.FormDto, Retinue.Lodge.Facade";
                    break;

                case "LCHK"://Need to change
                    //this.ModuleFormType = "Retinue.Lodge.WinForm.CheckInForm, Retinue.Lodge.WinForm";
                    this.ModuleFormDtoType = "Retinue.Lodge.Facade.CheckInReport.Dto, Retinue.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Retinue.Lodge.Component";
                    this.ArtifactDataType = "Retinue.Lodge.Component.CheckInReport.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Retinue.Lodge.Component.CheckInReport.Navigator.Artifact.Server";
                    this.ModuleDataType = "Retinue.Lodge.Component.CheckInReport.Data, Retinue.Lodge.Component";

                    this.facadeTypeName = "Retinue.Lodge.Facade.CheckInReport.Server, Retinue.Lodge.Facade";
                    this.formDtoTypeName = "Retinue.Lodge.Facade.CheckInReport.FormDto, Retinue.Lodge.Facade";
                    break;

                case "INVO":
                    //this.ModuleFormType = "Vanilla.Accountant.WinForm.Invoice, Vanilla.Accountant.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Accountant.Facade.Invoice.Report.Dto, Vanilla.Accountant.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Accountant.Component";
                    this.ArtifactDataType = "Crystal.Accountant.Component.Invoice.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Accountant.Component.Invoice.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Accountant.Component.Invoice.Report.Data, Crystal.Accountant.Component";

                    this.facadeTypeName = "Vanilla.Accountant.Facade.Invoice.Report.Server,Vanilla.Accountant.Facade";
                    this.formDtoTypeName = "Vanilla.Accountant.Facade.Invoice.Report.FormDto,Vanilla.Accountant.Facade";
                    break;
                default: //Default is customer
                    this.ModuleFormDtoType = "Retinue.Customer.Facade.Report.Dto, Retinue.Customer.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Customer.Component";
                    this.ArtifactDataType = "Crystal.Customer.Component.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Customer.Component.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Customer.Component.Report.Data, Crystal.Customer.Component";

                    this.facadeTypeName = "Retinue.Customer.Facade.Report.Server,Retinue.Customer.Facade";
                    this.formDtoTypeName = "Retinue.Customer.Facade.Report.FormDto,Retinue.Customer.Facade";
                    break;
            }

            //FacLib.FormDto reportDto = (FacLib.FormDto)Activator.CreateInstance(typeReportDto);
            //typeReportDto.GetProperty("Dto").SetValue(reportDto, Activator.CreateInstance(Type.GetType(this.ModuleFormDtoType)), null);

            //this.ModuleFacade = (FacLib.Server)Activator.CreateInstance(typeReportServer, reportDto);
            return this;
        }

    }

}