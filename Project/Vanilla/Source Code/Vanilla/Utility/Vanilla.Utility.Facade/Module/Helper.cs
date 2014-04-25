﻿using System;

using CrystalArtifact = Crystal.Navigator.Component.Artifact;

namespace Vanilla.Utility.Facade.Module
{

    public class Helper
    {

        Module.Dto moduleDef;
        public Helper(Module.Dto moduleDef, Artifact.Category artifactCategory)
        {
            this.moduleDef = moduleDef;
            //if (artifactCategory == Facade.Artifact.Category.Form)
            //    this.GetObjects();
            if (artifactCategory == Facade.Artifact.Category.Report)
                this.GetObjectsForReport();
            else
                this.GetObjects();
        }

        public CrystalArtifact.IArtifact Artifact
        {
            get
            {
                Type type = Type.GetType(this.ArtifactComponentType + ", " + this.ArtifactComponentAssembly, true);
                CrystalArtifact.Server artifact = Activator.CreateInstance(type, this.ArtifactData) as CrystalArtifact.Server;
                (artifact.Data as CrystalArtifact.Data).ComponentData = this.ModuleData;
                return artifact;
            }
        }

        public BinAff.Core.ICrud ArtifactComponent
        {
            get
            {
                Type type = Type.GetType(this.ArtifactComponentType + ", " + this.ArtifactComponentAssembly, true);
                CrystalArtifact.Server artifact = Activator.CreateInstance(type, this.ArtifactData) as CrystalArtifact.Server;
                (artifact.Data as CrystalArtifact.Data).ComponentData = this.ModuleData;
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
                    Type type = Type.GetType(this.ArtifactDataType + ", " + this.ArtifactComponentAssembly, true);
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
                    //this.ModuleFacade = new AutoTourism.Customer.Facade.Server(null);

                    Type typeCustomerServer = Type.GetType("AutoTourism.Customer.Facade.Server,AutoTourism.Customer.Facade", true);
                    Type typeCustomerDto = Type.GetType("AutoTourism.Customer.Facade.FormDto,AutoTourism.Customer.Facade", true);
                    BinAff.Facade.Library.FormDto customerDto = (BinAff.Facade.Library.FormDto)Activator.CreateInstance(typeCustomerDto);
                    this.ModuleFacade = (BinAff.Facade.Library.Server)Activator.CreateInstance(typeCustomerServer, customerDto);


                    break;

                case "LRSV"://Need to change
                    this.ModuleFormType = "AutoTourism.Lodge.WinForm.RoomReservationForm, AutoTourism.Lodge.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Lodge.Facade.RoomReservation.Dto, AutoTourism.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Lodge.Component";
                    this.ArtifactDataType = "Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Lodge.Component.Room.Reservation.Data, Crystal.Lodge.Component";
                    //this.ModuleFacade = new AutoTourism.Lodge.Facade.RoomReservation.ReservationServer(null);                  

                    Type typeReservationServer = Type.GetType("AutoTourism.Lodge.Facade.RoomReservation.ReservationServer,AutoTourism.Lodge.Facade", true);
                    Type typeReservationDto = Type.GetType("AutoTourism.Lodge.Facade.RoomReservation.FormDto,AutoTourism.Lodge.Facade", true);
                    BinAff.Facade.Library.FormDto reservationDto = (BinAff.Facade.Library.FormDto)Activator.CreateInstance(typeReservationDto);
                    this.ModuleFacade = (BinAff.Facade.Library.Server)Activator.CreateInstance(typeReservationServer, reservationDto);

                    break;

                case "LCHK"://Need to change
                    this.ModuleFormType = "AutoTourism.Lodge.WinForm.CheckInForm, AutoTourism.Lodge.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Lodge.Facade.CheckIn.Dto, AutoTourism.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Lodge.Component";
                    this.ArtifactDataType = "Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Lodge.Component.Room.CheckIn.Data, Crystal.Lodge.Component";
                    //this.ModuleFacade = new AutoTourism.Lodge.Facade.CheckIn.CheckInServer(null);

                    Type typeCheckInServer = Type.GetType("AutoTourism.Lodge.Facade.CheckIn.CheckInServer,AutoTourism.Lodge.Facade", true);
                    Type typeCheckInDto = Type.GetType("AutoTourism.Lodge.Facade.CheckIn.FormDto,AutoTourism.Lodge.Facade", true);
                    BinAff.Facade.Library.FormDto checkInDto = (BinAff.Facade.Library.FormDto)Activator.CreateInstance(typeCheckInDto);
                    this.ModuleFacade = (BinAff.Facade.Library.Server)Activator.CreateInstance(typeCheckInServer, checkInDto);
                    break;

                case "INVO":                   
                    this.ModuleFormType = "Vanilla.Invoice.WinForm.Invoice, Vanilla.Invoice.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Invoice.Facade.Dto, Vanilla.Invoice.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Invoice.Component";
                    this.ArtifactDataType = "Crystal.Invoice.Component.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Invoice.Component.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Invoice.Component.Data, Crystal.Invoice.Component";
                    
                    Type typeInvoiceServer = Type.GetType("Vanilla.Invoice.Facade.Server,Vanilla.Invoice.Facade", true);
                    Type typeInvoiceDto = Type.GetType("Vanilla.Invoice.Facade.FormDto,Vanilla.Invoice.Facade", true);
                    BinAff.Facade.Library.FormDto invoiceDto = (BinAff.Facade.Library.FormDto)Activator.CreateInstance(typeInvoiceDto);
                    this.ModuleFacade = (BinAff.Facade.Library.Server)Activator.CreateInstance(typeInvoiceServer, invoiceDto);
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

        internal Helper GetObjectsForReport()
        {
            Type typeReportServer;
            Type typeReportDto;
            switch (this.moduleDef.Code)
            {
                case "CUST":
                    this.ModuleFormDtoType = "AutoTourism.Customer.Facade.Report.Dto, AutoTourism.Customer.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Customer.Component";
                    this.ArtifactDataType = "Crystal.Customer.Component.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Customer.Component.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Customer.Component.Report.Data, Crystal.Customer.Component";

                    typeReportServer = Type.GetType("AutoTourism.Customer.Facade.Report.Server,AutoTourism.Customer.Facade", true);
                    typeReportDto = Type.GetType("AutoTourism.Customer.Facade.Report.FormDto,AutoTourism.Customer.Facade", true);
                    break;

                case "LRSV"://Need to change
                    //this.ModuleFormType = "AutoTourism.Lodge.WinForm.RoomReservationForm, AutoTourism.Lodge.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Lodge.Facade.RoomReservationReport.Dto, AutoTourism.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Lodge.Component";
                    this.ArtifactDataType = "Crystal.Lodge.Component.RoomReservationReport.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Lodge.Component.RoomReservationReport.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Lodge.Component.RoomReservationReport.Data, Crystal.Lodge.Component";

                    typeReportServer = Type.GetType("AutoTourism.Lodge.Facade.RoomReservationReport.Server,AutoTourism.Lodge.Facade", true);
                    typeReportDto = Type.GetType("AutoTourism.Lodge.Facade.RoomReservationReport.FormDto,AutoTourism.Lodge.Facade", true);
                    break;

                case "LCHK"://Need to change
                    //this.ModuleFormType = "AutoTourism.Lodge.WinForm.CheckInForm, AutoTourism.Lodge.WinForm";
                    this.ModuleFormDtoType = "AutoTourism.Lodge.Facade.CheckInReport.Dto, AutoTourism.Lodge.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Lodge.Component";
                    this.ArtifactDataType = "Crystal.Lodge.Component.CheckInReport.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Lodge.Component.CheckInReport.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Lodge.Component.CheckInReport.Data, Crystal.Lodge.Component";

                    typeReportServer = Type.GetType("AutoTourism.Lodge.Facade.CheckInReport.Server,AutoTourism.Lodge.Facade", true);
                    typeReportDto = Type.GetType("AutoTourism.Lodge.Facade.CheckInReport.FormDto,AutoTourism.Lodge.Facade", true);
                    break;

                case "INVO":
                    //this.ModuleFormType = "Vanilla.Invoice.WinForm.Invoice, Vanilla.Invoice.WinForm";
                    this.ModuleFormDtoType = "Vanilla.Invoice.Facade.Report.Dto, Vanilla.Invoice.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Invoice.Component";
                    this.ArtifactDataType = "Crystal.Invoice.Component.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Invoice.Component.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Invoice.Component.Report.Data, Crystal.Invoice.Component";

                    typeReportServer = Type.GetType("Vanilla.Invoice.Facade.Report.Server,Vanilla.Invoice.Facade", true);
                    typeReportDto = Type.GetType("Vanilla.Invoice.Facade.Report.FormDto,Vanilla.Invoice.Facade", true);
                    break;
                default: //Default is customer
                    this.ModuleFormDtoType = "AutoTourism.Customer.Facade.Report.Dto, AutoTourism.Customer.Facade";
                    this.ArtifactComponentAssembly = "Crystal.Customer.Component";
                    this.ArtifactDataType = "Crystal.Customer.Component.Report.Navigator.Artifact.Data";
                    this.ArtifactComponentType = "Crystal.Customer.Component.Report.Navigator.Artifact.Server";
                    this.ModuleDataType = "Crystal.Customer.Component.Report.Data, Crystal.Customer.Component";

                    typeReportServer = Type.GetType("AutoTourism.Customer.Facade.Report.Server,AutoTourism.Customer.Facade", true);
                    typeReportDto = Type.GetType("AutoTourism.Customer.Facade.Report.FormDto,AutoTourism.Customer.Facade", true);
                    break;
            }

            BinAff.Facade.Library.FormDto reportDto = (BinAff.Facade.Library.FormDto)Activator.CreateInstance(typeReportDto);
            typeReportDto.GetProperty("Dto").SetValue(reportDto, Activator.CreateInstance(Type.GetType(this.ModuleFormDtoType)), null);

            this.ModuleFacade = (BinAff.Facade.Library.Server)Activator.CreateInstance(typeReportServer, reportDto);
            return this;
        }

    }

}