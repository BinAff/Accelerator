USE [master]
GO
/****** Object:  Database [AutoTourism]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'AutoTourism')
BEGIN
CREATE DATABASE [AutoTourism] ON  PRIMARY 
( NAME = N'AutoTourism', FILENAME = N'D:\Arpan\Personal\Splash\DB\AutoTourism.mdf' , SIZE = 12288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AutoTourism_log', FILENAME = N'D:\Arpan\Personal\Splash\DB\AutoTourism.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [AutoTourism] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutoTourism].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutoTourism] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [AutoTourism] SET ANSI_NULLS OFF
GO
ALTER DATABASE [AutoTourism] SET ANSI_PADDING OFF
GO
ALTER DATABASE [AutoTourism] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [AutoTourism] SET ARITHABORT OFF
GO
ALTER DATABASE [AutoTourism] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [AutoTourism] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [AutoTourism] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [AutoTourism] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [AutoTourism] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [AutoTourism] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [AutoTourism] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [AutoTourism] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [AutoTourism] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [AutoTourism] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [AutoTourism] SET  DISABLE_BROKER
GO
ALTER DATABASE [AutoTourism] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [AutoTourism] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [AutoTourism] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [AutoTourism] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [AutoTourism] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [AutoTourism] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [AutoTourism] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [AutoTourism] SET  READ_WRITE
GO
ALTER DATABASE [AutoTourism] SET RECOVERY SIMPLE
GO
ALTER DATABASE [AutoTourism] SET  MULTI_USER
GO
ALTER DATABASE [AutoTourism] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [AutoTourism] SET DB_CHAINING OFF
GO
USE [AutoTourism]
GO
/****** Object:  ForeignKey [FK_UserRole_Account]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Account]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_State_Country]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Configuration].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[Configuration].[State]'))
ALTER TABLE [Configuration].[State] DROP CONSTRAINT [FK_State_Country]
GO
/****** Object:  ForeignKey [FK_TaxDetails_Taxation]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_TaxDetails_Taxation]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Slab]'))
ALTER TABLE [Invoice].[Slab] DROP CONSTRAINT [FK_TaxDetails_Taxation]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_Account]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_Account]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_SecurityQuestion]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomCategory]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomType]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomCategory]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomType]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Status]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_Status]
GO
/****** Object:  ForeignKey [FK_Profile_Account]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Account]
GO
/****** Object:  ForeignKey [FK_Profile_Initial]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Initial]
GO
/****** Object:  ForeignKey [FK_LoginLogoutHistory_Account]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] DROP CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
/****** Object:  ForeignKey [FK_LineItem_Invoice]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] DROP CONSTRAINT [FK_LineItem_Invoice]
GO
/****** Object:  ForeignKey [FK_Payment_Invoice]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_Invoice]
GO
/****** Object:  ForeignKey [FK_InvoiceTaxation_Invoice]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] DROP CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
/****** Object:  ForeignKey [FK_Building_Organization]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] DROP CONSTRAINT [FK_Building_Organization]
GO
/****** Object:  ForeignKey [FK_Appointment_AppointmentType]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_AppointmentType]
GO
/****** Object:  ForeignKey [FK_Appointment_Importance]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_Importance]
GO
/****** Object:  ForeignKey [FK_Artifact_Account]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Account]
GO
/****** Object:  ForeignKey [FK_Artifact_Account1]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Account1]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact]
GO
/****** Object:  ForeignKey [Organization_FK_ContactNumberId]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] DROP CONSTRAINT [Organization_FK_ContactNumberId]
GO
/****** Object:  ForeignKey [Organization_FK_Id]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] DROP CONSTRAINT [Organization_FK_Id]
GO
/****** Object:  ForeignKey [Organization_FK_FaxId]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] DROP CONSTRAINT [Organization_FK_FaxId]
GO
/****** Object:  ForeignKey [FK_CheckIn_ActionStatus]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_ActionStatus]
GO
/****** Object:  ForeignKey [FK_CheckIn_RoomReservation]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_RoomReservation]
GO
/****** Object:  ForeignKey [Customer_FK_IdentityProofId]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_IdentityProofId]
GO
/****** Object:  ForeignKey [Customer_FK_InitialId]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_InitialId]
GO
/****** Object:  ForeignKey [Customer_FK_StateId]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_StateId]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact1]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact1]
GO
/****** Object:  ForeignKey [FK_Artifact_Invoice]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Invoice]
GO
/****** Object:  ForeignKey [FK_AdvancePaymentArtifact_AdvancePayment]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_AdvancePaymentArtifact_AdvancePayment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]'))
ALTER TABLE [Invoice].[AdvancePaymentArtifact] DROP CONSTRAINT [FK_AdvancePaymentArtifact_AdvancePayment]
GO
/****** Object:  ForeignKey [FK_AdvancePaymentArtifact_Artifact]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_AdvancePaymentArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]'))
ALTER TABLE [Invoice].[AdvancePaymentArtifact] DROP CONSTRAINT [FK_AdvancePaymentArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] DROP CONSTRAINT [FK_BuildingClosureReason_Building]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Artifact]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]'))
ALTER TABLE [Navigator].[ArtifactComponentLink] DROP CONSTRAINT [FK_FormModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Module]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]'))
ALTER TABLE [Navigator].[ArtifactComponentLink] DROP CONSTRAINT [FK_FormModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Artifact]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Module]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_BuildingFloor_Building]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] DROP CONSTRAINT [FK_BuildingFloor_Building]
GO
/****** Object:  ForeignKey [FK_PaymentLineItem_Payment]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentLineItem_Payment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]'))
ALTER TABLE [Invoice].[PaymentLineItem] DROP CONSTRAINT [FK_PaymentLineItem_Payment]
GO
/****** Object:  ForeignKey [FK_PaymentLineItem_PaymentType]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentLineItem_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]'))
ALTER TABLE [Invoice].[PaymentLineItem] DROP CONSTRAINT [FK_PaymentLineItem_PaymentType]
GO
/****** Object:  ForeignKey [FK_LineItemTaxation_LineItem]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItemTaxation_LineItem]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]'))
ALTER TABLE [Invoice].[LineItemTaxation] DROP CONSTRAINT [FK_LineItemTaxation_LineItem]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Module]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_ProfileContactNumber_Profile]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] DROP CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
/****** Object:  ForeignKey [FK_PaymentArtifact_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]'))
ALTER TABLE [Invoice].[PaymentArtifact] DROP CONSTRAINT [FK_PaymentArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_PaymentArtifact_Payment]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentArtifact_Payment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]'))
ALTER TABLE [Invoice].[PaymentArtifact] DROP CONSTRAINT [FK_PaymentArtifact_Payment]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_RoomReservation]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomReservationPayment_Payment]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationPayment_Payment]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]'))
ALTER TABLE [Lodge].[RoomReservationPayment] DROP CONSTRAINT [FK_RoomReservationPayment_Payment]
GO
/****** Object:  ForeignKey [FK_RoomReservationPayment_RoomReservation]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationPayment_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]'))
ALTER TABLE [Lodge].[RoomReservationPayment] DROP CONSTRAINT [FK_RoomReservationPayment_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomReservationAttachment_PaymentArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationAttachment_PaymentArtifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]'))
ALTER TABLE [Lodge].[RoomReservationAttachment] DROP CONSTRAINT [FK_RoomReservationAttachment_PaymentArtifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationAttachment_RoomReservationArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationAttachment_RoomReservationArtifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]'))
ALTER TABLE [Lodge].[RoomReservationAttachment] DROP CONSTRAINT [FK_RoomReservationAttachment_RoomReservationArtifact]
GO
/****** Object:  ForeignKey [FK_Room_Building]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_Building]
GO
/****** Object:  ForeignKey [FK_Room_BuildingFloor]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_BuildingFloor]
GO
/****** Object:  ForeignKey [FK_Room_RoomCategory]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomCategory]
GO
/****** Object:  ForeignKey [FK_Room_RoomStatus]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomStatus]
GO
/****** Object:  ForeignKey [FK_Room_RoomType]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomType]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_Artifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_CheckIn]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
/****** Object:  ForeignKey [CustomerContactNumber_FK_CustomerId]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] DROP CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Artifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [FK_CustomerForm_Artifact]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Customer]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [FK_CustomerForm_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_Customer]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_RoomReservation]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_CheckIn]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_Customer]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
/****** Object:  ForeignKey [FK_RoomClosureReason_Room]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] DROP CONSTRAINT [FK_RoomClosureReason_Room]
GO
/****** Object:  ForeignKey [FK_RoomImage_Room]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] DROP CONSTRAINT [FK_RoomImage_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_Room]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_RoomReservation]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInIsRoomDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInIsRoomDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInIsRoomDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadAllCheckInRooms]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadAllCheckInRooms]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadBookedRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadBookedRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomImageRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomImageReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRoomLinkRead]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRoomLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationRoomLinkRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationSearch]
GO
/****** Object:  Table [Lodge].[RoomReservationDetails]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_Room]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservationDetails]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffModifyRate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffModifyRate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsBuildingDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsBuildingDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingFloorDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsBuildingFloorDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsBuildingFloorDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomCategoryDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomCategoryDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsRoomCategoryDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomStatusDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomStatusDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsRoomStatusDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomTypeDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsRoomTypeDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomModifyStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomModifyStatus]
GO
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactAttachmentDeleteLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactAttachmentDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactAttachmentDeleteLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactAttachmentInsertLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactAttachmentInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactAttachmentInsertLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactAttachmentReadLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactAttachmentReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactAttachmentReadLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadCheckedInRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadCheckedInRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadClosedRoom]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadClosedRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadClosedRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadOpenRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadOpenRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomDelete]
GO
/****** Object:  Table [Lodge].[RoomImage]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] DROP CONSTRAINT [FK_RoomImage_Room]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImage]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomImage]
GO
/****** Object:  Table [Lodge].[RoomClosureReason]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] DROP CONSTRAINT [FK_RoomClosureReason_Room]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomClosureReason]
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomCheckInId]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadRoomCheckInId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadRoomCheckInId]
GO
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsStateIdDeletable]
GO
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsIdentityProofIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsIdentityProofIdDeletable]
GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsInitialDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsInitialDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactDeleteLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactInsertLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactReadLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactReadLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactUpdateLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactDeleteLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactInsertLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactReadLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactReadLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactUpdateLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberDelete]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberInsert]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberRead]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkDelete]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkDelete]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkInsert]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkRead]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReadDuplicate]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkDelete]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkInsert]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkRead]
GO
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[GetCustomerIdForReservation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[GetCustomerIdForReservation]
GO
/****** Object:  StoredProcedure [Customer].[DeleteCustomerReportForArtifact]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[DeleteCustomerReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[DeleteCustomerReportForArtifact]
GO
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerUpdate]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReportArtifactInsertLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReportArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReportArtifactInsertLink]
GO
/****** Object:  Table [AutoTourism].[CustomerRoomCheckInLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]') AND type in (N'U'))
DROP TABLE [AutoTourism].[CustomerRoomCheckInLink]
GO
/****** Object:  Table [AutoTourism].[CustomerRoomReservationLink]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]') AND type in (N'U'))
DROP TABLE [AutoTourism].[CustomerRoomReservationLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 01/01/2015 10:50:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerDelete]
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerInsert]
GO
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerRead]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReadAll]
GO
/****** Object:  Table [Customer].[CustomerArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [FK_CustomerForm_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [FK_CustomerForm_Customer]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_CustomerArtifact_Category]') AND type = 'D')
BEGIN
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [DF_CustomerArtifact_Category]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]') AND type in (N'U'))
DROP TABLE [Customer].[CustomerArtifact]
GO
/****** Object:  Table [Customer].[CustomerContactNumber]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] DROP CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]') AND type in (N'U'))
DROP TABLE [Customer].[CustomerContactNumber]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInRead]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInUpdate]
GO
/****** Object:  Table [Lodge].[CheckInArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]') AND type in (N'U'))
DROP TABLE [Lodge].[CheckInArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInDelete]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInInsert]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentArtifactDeleteLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentArtifactInsertLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentArtifactReadLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentArtifactReadLink]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentArtifactUpdateLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkInsertForComponent]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkInsertForComponent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactComponentLinkInsertForComponent]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkReadForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactComponentLinkReadForArtifact]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForComponent]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkReadForComponent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactComponentLinkReadForComponent]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactDelete]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactSearchByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactSearchByName]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorReadForParent]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactDeleteLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactInsertLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactReadLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentArtifactReadLink]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactUpdateLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentLineItemDelete]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentLineItemInsert]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentLineItemRead]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemReadAll]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentLineItemReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentLineItemReadForParent]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemUpdate]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentLineItemUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemTaxationInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemTaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemTaxationInsert]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemTaxationRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemTaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemTaxationRead]
GO
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceReportForArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InsertInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InsertInvoiceReportForArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactDeleteLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactInsertLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactReadLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceArtifactReadLink]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactUpdateLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomReservationId]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadRoomReservationId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadRoomReservationId]
GO
/****** Object:  StoredProcedure [Invoice].[ReadArtifactForInvoiceNumber]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadArtifactForInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadArtifactForInvoiceNumber]
GO
/****** Object:  StoredProcedure [Customer].[ReadCustomerReportForArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReadCustomerReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReadCustomerReportForArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadIdFromArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadIdFromArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentReadIdFromArtifact]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberInsert]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberRead]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[IsReservationDeletable]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsReservationDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsReservationDeletable]
GO
/****** Object:  Table [Lodge].[Room]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_Building]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_BuildingFloor]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomCategory]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomStatus]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[Room]') AND type in (N'U'))
DROP TABLE [Lodge].[Room]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactDeleteLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactInsertLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactReadLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactUpdateLink]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactUpdateLink]
GO
/****** Object:  Table [Lodge].[RoomReservationAttachment]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationAttachment_PaymentArtifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]'))
ALTER TABLE [Lodge].[RoomReservationAttachment] DROP CONSTRAINT [FK_RoomReservationAttachment_PaymentArtifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationAttachment_RoomReservationArtifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]'))
ALTER TABLE [Lodge].[RoomReservationAttachment] DROP CONSTRAINT [FK_RoomReservationAttachment_RoomReservationArtifact]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservationAttachment]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateCheckInStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateCheckInStatus]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateInvoiceNumber]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateInvoiceNumber]
GO
/****** Object:  StoredProcedure [Invoice].[ReadInvoiceReportForArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadInvoiceReportForArtifact]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleDelete]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleRead]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[SlabRead]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[SlabRead]
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadAll]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[SlabReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[SlabReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffInsert]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationAfterCheckIn]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationAfterCheckIn]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateReservationAfterCheckIn]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationStatusToCheckIn]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateReservationStatusToCheckIn]
GO
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffIsExist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffIsExist]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllCurrent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadAllCurrent]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllFuture]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadAllFuture]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadDuplicate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 01/01/2015 10:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerDelete]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerRead]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerUpdate]
GO
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateDelete]
GO
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateInsert]
GO
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateRead]
GO
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SearchUserByLoginId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SearchUserByLoginId]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationInsert]
GO
/****** Object:  Table [Lodge].[RoomReservationPayment]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationPayment_Payment]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]'))
ALTER TABLE [Lodge].[RoomReservationPayment] DROP CONSTRAINT [FK_RoomReservationPayment_Payment]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationPayment_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]'))
ALTER TABLE [Lodge].[RoomReservationPayment] DROP CONSTRAINT [FK_RoomReservationPayment_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservationPayment]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationReadAll]
GO
/****** Object:  Table [Lodge].[RoomReservationArtifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservationArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationUpdateStatus]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileRead]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentUpdate]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentUpdate]
GO
/****** Object:  Table [Invoice].[PaymentArtifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]'))
ALTER TABLE [Invoice].[PaymentArtifact] DROP CONSTRAINT [FK_PaymentArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentArtifact_Payment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]'))
ALTER TABLE [Invoice].[PaymentArtifact] DROP CONSTRAINT [FK_PaymentArtifact_Payment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]') AND type in (N'U'))
DROP TABLE [Invoice].[PaymentArtifact]
GO
/****** Object:  Table [Guardian].[ProfileContactNumber]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] DROP CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]') AND type in (N'U'))
DROP TABLE [Guardian].[ProfileContactNumber]
GO
/****** Object:  Table [Customer].[ReportArtifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Report]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportArtifact]') AND type in (N'U'))
DROP TABLE [Customer].[ReportArtifact]
GO
/****** Object:  Table [Invoice].[ReportArtifact]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Report]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]') AND type in (N'U'))
DROP TABLE [Invoice].[ReportArtifact]
GO
/****** Object:  Table [Navigator].[ReportModuleLink]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]') AND type in (N'U'))
DROP TABLE [Navigator].[ReportModuleLink]
GO
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxDelete]
GO
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxInsert]
GO
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxRead]
GO
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxReadForParent]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemUpdate]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemDelete]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemDelete]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemInsert]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemInsert]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemRead]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemRead]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadAll]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadForParent]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemReadForParent]
GO
/****** Object:  Table [Invoice].[LineItemTaxation]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItemTaxation_LineItem]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]'))
ALTER TABLE [Invoice].[LineItemTaxation] DROP CONSTRAINT [FK_LineItemTaxation_LineItem]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]') AND type in (N'U'))
DROP TABLE [Invoice].[LineItemTaxation]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 01/01/2015 10:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationRead]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingStatusDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingStatusDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingTypeDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentRead]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadAll]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentDelete]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentDelete]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentInsert]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentInsert]
GO
/****** Object:  Table [Invoice].[PaymentLineItem]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentLineItem_Payment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]'))
ALTER TABLE [Invoice].[PaymentLineItem] DROP CONSTRAINT [FK_PaymentLineItem_Payment]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentLineItem_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]'))
ALTER TABLE [Invoice].[PaymentLineItem] DROP CONSTRAINT [FK_PaymentLineItem_PaymentType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]') AND type in (N'U'))
DROP TABLE [Invoice].[PaymentLineItem]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationEmailRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationEmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationEmailRead]
GO
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[IsInitialDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[IsInitialDeletable]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryInsert]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryRead]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingModifyStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingModifyStatus]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingDelete]
GO
/****** Object:  Table [Lodge].[BuildingFloor]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] DROP CONSTRAINT [FK_BuildingFloor_Building]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingFloor]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingUpdate]
GO
/****** Object:  Table [Navigator].[CatalogueModuleLink]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]') AND type in (N'U'))
DROP TABLE [Navigator].[CatalogueModuleLink]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactUpdate]
GO
/****** Object:  Table [Navigator].[ArtifactComponentLink]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]'))
ALTER TABLE [Navigator].[ArtifactComponentLink] DROP CONSTRAINT [FK_FormModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]'))
ALTER TABLE [Navigator].[ArtifactComponentLink] DROP CONSTRAINT [FK_FormModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]') AND type in (N'U'))
DROP TABLE [Navigator].[ArtifactComponentLink]
GO
/****** Object:  Table [Lodge].[BuildingClosureReason]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] DROP CONSTRAINT [FK_BuildingClosureReason_Building]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingClosureReason]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactInsert]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactRead]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactReadAll]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadForPath]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadForPath]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactReadForPath]
GO
/****** Object:  Table [Invoice].[AdvancePaymentArtifact]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_AdvancePaymentArtifact_AdvancePayment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]'))
ALTER TABLE [Invoice].[AdvancePaymentArtifact] DROP CONSTRAINT [FK_AdvancePaymentArtifact_AdvancePayment]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_AdvancePaymentArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]'))
ALTER TABLE [Invoice].[AdvancePaymentArtifact] DROP CONSTRAINT [FK_AdvancePaymentArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]') AND type in (N'U'))
DROP TABLE [Invoice].[AdvancePaymentArtifact]
GO
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountRead]
GO
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentDelete]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentRead]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentSearch]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearchWithImportance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentSearchWithImportance]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentUpdate]
GO
/****** Object:  Table [Invoice].[Artifact]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Artifact]') AND type in (N'U'))
DROP TABLE [Invoice].[Artifact]
GO
/****** Object:  Table [Customer].[Customer]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_IdentityProofId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_InitialId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_StateId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Customer]') AND type in (N'U'))
DROP TABLE [Customer].[Customer]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberDelete]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberInsert]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberRead]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberReadForParent]
GO
/****** Object:  Table [Lodge].[CheckIn]    Script Date: 01/01/2015 10:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_ActionStatus]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckIn]') AND type in (N'U'))
DROP TABLE [Lodge].[CheckIn]
GO
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailDelete]
GO
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailInsert]
GO
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailRead]
GO
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailReadForParent]
GO
/****** Object:  Table [Organization].[Fax]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] DROP CONSTRAINT [Organization_FK_FaxId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Fax]') AND type in (N'U'))
DROP TABLE [Organization].[Fax]
GO
/****** Object:  Table [Organization].[Email]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] DROP CONSTRAINT [Organization_FK_Id]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Email]') AND type in (N'U'))
DROP TABLE [Organization].[Email]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeDelete]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeInsert]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeRead]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactAttachmentDeleteLink]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactAttachmentDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactAttachmentDeleteLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactAttachmentInsertLink]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactAttachmentInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactAttachmentInsertLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactAttachmentReadLink]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactAttachmentReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactAttachmentReadLink]
GO
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentDelete]
GO
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentInsert]
GO
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentRead]
GO
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentReadAll]
GO
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentUpdate]
GO
/****** Object:  Table [Organization].[ContactNumber]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] DROP CONSTRAINT [Organization_FK_ContactNumberId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumber]') AND type in (N'U'))
DROP TABLE [Organization].[ContactNumber]
GO
/****** Object:  StoredProcedure [Configuration].[CountryRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[CountryRead]
GO
/****** Object:  StoredProcedure [Configuration].[CountryReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[CountryReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountDelete]
GO
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountInsert]
GO
/****** Object:  StoredProcedure [Report].[CategoryRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Report].[CategoryRead]
GO
/****** Object:  StoredProcedure [Report].[CategoryReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Report].[CategoryReadAll]
GO
/****** Object:  Table [Navigator].[Artifact]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Account1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[Artifact]') AND type in (N'U'))
DROP TABLE [Navigator].[Artifact]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusDelete]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusInsert]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusRead]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusReadAll]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdateLoginId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdateLoginId]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdatePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdatePassword]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentDelete]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentInsert]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentIsTypeDeletable]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentIsTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentIsTypeDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentRead]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentUpdate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[AdvancePaymentUpdate]
GO
/****** Object:  Table [Utility].[Appointment]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_AppointmentType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_Importance]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[Appointment]') AND type in (N'U'))
DROP TABLE [Utility].[Appointment]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeDelete]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeRead]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeUpdate]
GO
/****** Object:  Table [Lodge].[Building]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] DROP CONSTRAINT [FK_Building_Organization]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[Building]') AND type in (N'U'))
DROP TABLE [Lodge].[Building]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeUpdate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusDelete]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusInsert]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusRead]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusReadAll]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusUpdate]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusUpdate]
GO
/****** Object:  Table [Invoice].[InvoiceTaxation]    Script Date: 01/01/2015 10:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] DROP CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]') AND type in (N'U'))
DROP TABLE [Invoice].[InvoiceTaxation]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationDelete]
GO
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleDelete]
GO
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleInsert]
GO
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleRead]
GO
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleReadAll]
GO
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleUpdate]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationInsert]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationInsert]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationRead]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationRead]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationUpdate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationUpdate]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationUpdate]
GO
/****** Object:  Table [Invoice].[Payment]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Payment]') AND type in (N'U'))
DROP TABLE [Invoice].[Payment]
GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[IsStateIdDeletable]
GO
/****** Object:  Table [Invoice].[LineItem]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] DROP CONSTRAINT [FK_LineItem_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItem]') AND type in (N'U'))
DROP TABLE [Invoice].[LineItem]
GO
/****** Object:  Table [Guardian].[LoginHistory]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] DROP CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistory]') AND type in (N'U'))
DROP TABLE [Guardian].[LoginHistory]
GO
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialDelete]
GO
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialInsert]
GO
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialRead]
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[Insert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Insert]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceDelete]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceInsert]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceRead]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceReadAll]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceReadDuplicate]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceUpdate]
GO
/****** Object:  StoredProcedure [Customer].[ReportRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportRead]
GO
/****** Object:  StoredProcedure [Invoice].[ReportRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReportRead]
GO
/****** Object:  StoredProcedure [Customer].[ReportReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[ReportReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReportReadAll]
GO
/****** Object:  StoredProcedure [Customer].[ReportInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportInsert]
GO
/****** Object:  StoredProcedure [Invoice].[ReportInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReportInsert]
GO
/****** Object:  StoredProcedure [Invoice].[ReadDuplicate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[ReadForInvoiceNumber]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadForInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadForInvoiceNumber]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeDelete]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeDelete]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeInsert]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeRead]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadDuplicate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeUpdate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeUpdate]
GO
/****** Object:  Table [Guardian].[Profile]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Initial]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Profile]') AND type in (N'U'))
DROP TABLE [Guardian].[Profile]
GO
/****** Object:  StoredProcedure [Invoice].[Read]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Read]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Read]
GO
/****** Object:  StoredProcedure [Invoice].[ReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadAll]
GO
/****** Object:  Table [Lodge].[RoomReservation]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_RoomCategory]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_RoomType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_Status]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_RoomReservation_IsCheckedIn]') AND type = 'D')
BEGIN
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [DF_RoomReservation_IsCheckedIn]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservation]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservation]
GO
/****** Object:  StoredProcedure [Invoice].[Delete]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Delete]
GO
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleRead]
GO
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationStatusRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationStatusReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomStatusDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomStatusRead]
GO
/****** Object:  Table [Lodge].[RoomTariff]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariff]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomTariff]
GO
/****** Object:  Table [Guardian].[SecurityAnswer]    Script Date: 01/01/2015 10:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]') AND type in (N'U'))
DROP TABLE [Guardian].[SecurityAnswer]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeUpdate]
GO
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[RuleInsert]
GO
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleInsert]
GO
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleInsert]
GO
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[RuleRead]
GO
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleRead]
GO
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleRead]
GO
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionDelete]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionRead]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionReadDuplicate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionUpdate]
GO
/****** Object:  Table [Invoice].[Slab]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_TaxDetails_Taxation]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Slab]'))
ALTER TABLE [Invoice].[Slab] DROP CONSTRAINT [FK_TaxDetails_Taxation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Slab]') AND type in (N'U'))
DROP TABLE [Invoice].[Slab]
GO
/****** Object:  Table [Configuration].[State]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Configuration].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[Configuration].[State]'))
ALTER TABLE [Configuration].[State] DROP CONSTRAINT [FK_State_Country]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[State]') AND type in (N'U'))
DROP TABLE [Configuration].[State]
GO
/****** Object:  Table [Guardian].[UserRole]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRole]') AND type in (N'U'))
DROP TABLE [Guardian].[UserRole]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationDelete]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationDelete]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationInsert]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationInsert]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationRead]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationRead]
GO
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TaxationRead]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadAll]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TaxationReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadDuplicate]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationUpdate]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[Update]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Update]
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRuleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRuleRead]
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 01/01/2015 10:50:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Split]
GO
/****** Object:  Table [BinAff].[Stamp]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[BinAff].[Stamp]') AND type in (N'U'))
DROP TABLE [BinAff].[Stamp]
GO
/****** Object:  Table [Guardian].[UserRule]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRule]') AND type in (N'U'))
DROP TABLE [Guardian].[UserRule]
GO
/****** Object:  Table [Invoice].[Taxation]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Taxation]') AND type in (N'U'))
DROP TABLE [Invoice].[Taxation]
GO
/****** Object:  Table [Guardian].[SecurityQuestion]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestion]') AND type in (N'U'))
DROP TABLE [Guardian].[SecurityQuestion]
GO
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusDelete]
GO
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusInsert]
GO
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusRead]
GO
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusReadAll]
GO
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusUpdate]
GO
/****** Object:  Table [Lodge].[RoomType]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomType]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomType]
GO
/****** Object:  Table [Configuration].[Rule]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Rule]') AND type in (N'U'))
DROP TABLE [Configuration].[Rule]
GO
/****** Object:  Table [Customer].[Rule]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Rule]') AND type in (N'U'))
DROP TABLE [Customer].[Rule]
GO
/****** Object:  Table [Navigator].[Rule]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[Rule]') AND type in (N'U'))
DROP TABLE [Navigator].[Rule]
GO
/****** Object:  Table [Lodge].[RoomStatus]    Script Date: 01/01/2015 10:50:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatus]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomStatus]
GO
/****** Object:  Table [Lodge].[RoomCategory]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategory]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomCategory]
GO
/****** Object:  Table [Invoice].[PaymentType]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentType]') AND type in (N'U'))
DROP TABLE [Invoice].[PaymentType]
GO
/****** Object:  Table [Customer].[Report]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Report]') AND type in (N'U'))
DROP TABLE [Customer].[Report]
GO
/****** Object:  Table [Invoice].[Report]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Report]') AND type in (N'U'))
DROP TABLE [Invoice].[Report]
GO
/****** Object:  Table [Guardian].[Role]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Role]') AND type in (N'U'))
DROP TABLE [Guardian].[Role]
GO
/****** Object:  Table [Configuration].[Initial]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Initial]') AND type in (N'U'))
DROP TABLE [Configuration].[Initial]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkDelete]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkRead]
GO
/****** Object:  Table [Invoice].[Invoice]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Invoice]') AND type in (N'U'))
DROP TABLE [Invoice].[Invoice]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkDelete]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkRead]
GO
/****** Object:  Table [Organization].[Organization]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Organization]') AND type in (N'U'))
DROP TABLE [Organization].[Organization]
GO
/****** Object:  StoredProcedure [dbo].[EmailInsert]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailInsert]
GO
/****** Object:  StoredProcedure [dbo].[EmailRead]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailRead]
GO
/****** Object:  StoredProcedure [dbo].[EmailReadForParent]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailReadForParent]
GO
/****** Object:  Table [License].[Module]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Module]') AND type in (N'U'))
DROP TABLE [License].[Module]
GO
/****** Object:  Table [Lodge].[BuildingType]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingType]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingType]
GO
/****** Object:  Table [Report].[Category]    Script Date: 01/01/2015 10:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[Category]') AND type in (N'U'))
DROP TABLE [Report].[Category]
GO
/****** Object:  Table [Lodge].[BuildingStatus]    Script Date: 01/01/2015 10:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatus]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingStatus]
GO
/****** Object:  Table [Customer].[ActionStatus]    Script Date: 01/01/2015 10:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatus]') AND type in (N'U'))
DROP TABLE [Customer].[ActionStatus]
GO
/****** Object:  Table [Guardian].[Account]    Script Date: 01/01/2015 10:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Account]') AND type in (N'U'))
DROP TABLE [Guardian].[Account]
GO
/****** Object:  Table [Invoice].[AdvancePayment]    Script Date: 01/01/2015 10:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePayment]') AND type in (N'U'))
DROP TABLE [Invoice].[AdvancePayment]
GO
/****** Object:  Table [Utility].[AppointmentType]    Script Date: 01/01/2015 10:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentType]') AND type in (N'U'))
DROP TABLE [Utility].[AppointmentType]
GO
/****** Object:  Table [License].[Credential]    Script Date: 01/01/2015 10:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Credential]') AND type in (N'U'))
DROP TABLE [License].[Credential]
GO
/****** Object:  Table [Configuration].[Country]    Script Date: 01/01/2015 10:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Country]') AND type in (N'U'))
DROP TABLE [Configuration].[Country]
GO
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 01/01/2015 10:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CleanUpSchema]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CleanUpSchema]
GO
/****** Object:  Table [License].[Component]    Script Date: 01/01/2015 10:50:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Component]') AND type in (N'U'))
DROP TABLE [License].[Component]
GO
/****** Object:  Table [Lodge].[CheckInAttachment]    Script Date: 01/01/2015 10:50:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInAttachment]') AND type in (N'U'))
DROP TABLE [Lodge].[CheckInAttachment]
GO
/****** Object:  Table [Utility].[Importance]    Script Date: 01/01/2015 10:50:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[Importance]') AND type in (N'U'))
DROP TABLE [Utility].[Importance]
GO
/****** Object:  Table [Configuration].[IdentityProofType]    Script Date: 01/01/2015 10:50:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofType]') AND type in (N'U'))
DROP TABLE [Configuration].[IdentityProofType]
GO
/****** Object:  Table [BinAff].[DateStamp]    Script Date: 01/01/2015 10:50:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[BinAff].[DateStamp]') AND type in (N'U'))
DROP TABLE [BinAff].[DateStamp]
GO
/****** Object:  Schema [AutoTourism]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'AutoTourism')
DROP SCHEMA [AutoTourism]
GO
/****** Object:  Schema [BinAff]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'BinAff')
DROP SCHEMA [BinAff]
GO
/****** Object:  Schema [Configuration]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Configuration')
DROP SCHEMA [Configuration]
GO
/****** Object:  Schema [Customer]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Customer')
DROP SCHEMA [Customer]
GO
/****** Object:  Schema [Guardian]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Guardian')
DROP SCHEMA [Guardian]
GO
/****** Object:  Schema [Invoice]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Invoice')
DROP SCHEMA [Invoice]
GO
/****** Object:  Schema [License]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'License')
DROP SCHEMA [License]
GO
/****** Object:  Schema [Lodge]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Lodge')
DROP SCHEMA [Lodge]
GO
/****** Object:  Schema [Navigator]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Navigator')
DROP SCHEMA [Navigator]
GO
/****** Object:  Schema [Organization]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Organization')
DROP SCHEMA [Organization]
GO
/****** Object:  Schema [Report]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Report')
DROP SCHEMA [Report]
GO
/****** Object:  Schema [Reservation]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Reservation')
DROP SCHEMA [Reservation]
GO
/****** Object:  Schema [Utility]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Utility')
DROP SCHEMA [Utility]
GO
/****** Object:  User [AppUser]    Script Date: 01/01/2015 10:50:26 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AppUser')
DROP USER [AppUser]
GO
/****** Object:  User [AppUser]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AppUser')
CREATE USER [AppUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [Utility]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Utility')
EXEC sys.sp_executesql N'CREATE SCHEMA [Utility] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Reservation]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Reservation')
EXEC sys.sp_executesql N'CREATE SCHEMA [Reservation] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Report]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Report')
EXEC sys.sp_executesql N'CREATE SCHEMA [Report] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Organization]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Organization')
EXEC sys.sp_executesql N'CREATE SCHEMA [Organization] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Navigator]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Navigator')
EXEC sys.sp_executesql N'CREATE SCHEMA [Navigator] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Lodge]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Lodge')
EXEC sys.sp_executesql N'CREATE SCHEMA [Lodge] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [License]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'License')
EXEC sys.sp_executesql N'CREATE SCHEMA [License] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Invoice]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Invoice')
EXEC sys.sp_executesql N'CREATE SCHEMA [Invoice] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Guardian]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Guardian')
EXEC sys.sp_executesql N'CREATE SCHEMA [Guardian] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Customer]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Customer')
EXEC sys.sp_executesql N'CREATE SCHEMA [Customer] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Configuration]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Configuration')
EXEC sys.sp_executesql N'CREATE SCHEMA [Configuration] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [BinAff]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'BinAff')
EXEC sys.sp_executesql N'CREATE SCHEMA [BinAff] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [AutoTourism]    Script Date: 01/01/2015 10:50:26 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'AutoTourism')
EXEC sys.sp_executesql N'CREATE SCHEMA [AutoTourism] AUTHORIZATION [dbo]'
GO
/****** Object:  Table [BinAff].[DateStamp]    Script Date: 01/01/2015 10:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[BinAff].[DateStamp]') AND type in (N'U'))
BEGIN
CREATE TABLE [BinAff].[DateStamp](
	[Stamp] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [BinAff].[DateStamp] ([Stamp]) VALUES (N'7ERyagX6RydGhccM+e3OeA==')
/****** Object:  Table [Configuration].[IdentityProofType]    Script Date: 01/01/2015 10:50:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofType]') AND type in (N'U'))
BEGIN
CREATE TABLE [Configuration].[IdentityProofType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IdentityProofType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Configuration].[IdentityProofType] ON
INSERT [Configuration].[IdentityProofType] ([Id], [Name]) VALUES (CAST(1 AS Numeric(10, 0)), N'Pan Card')
INSERT [Configuration].[IdentityProofType] ([Id], [Name]) VALUES (CAST(2 AS Numeric(10, 0)), N'Driving Licence')
INSERT [Configuration].[IdentityProofType] ([Id], [Name]) VALUES (CAST(4 AS Numeric(10, 0)), N'Ration Card')
INSERT [Configuration].[IdentityProofType] ([Id], [Name]) VALUES (CAST(5 AS Numeric(10, 0)), N'Voter ID Crad')
INSERT [Configuration].[IdentityProofType] ([Id], [Name]) VALUES (CAST(6 AS Numeric(10, 0)), N'Aadhar Card')
SET IDENTITY_INSERT [Configuration].[IdentityProofType] OFF
/****** Object:  Table [Utility].[Importance]    Script Date: 01/01/2015 10:50:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[Importance]') AND type in (N'U'))
BEGIN
CREATE TABLE [Utility].[Importance](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Importance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Utility].[Importance] ON
INSERT [Utility].[Importance] ([Id], [Name]) VALUES (CAST(1 AS Numeric(10, 0)), N'Critical')
INSERT [Utility].[Importance] ([Id], [Name]) VALUES (CAST(2 AS Numeric(10, 0)), N'High')
INSERT [Utility].[Importance] ([Id], [Name]) VALUES (CAST(3 AS Numeric(10, 0)), N'Medium')
INSERT [Utility].[Importance] ([Id], [Name]) VALUES (CAST(4 AS Numeric(10, 0)), N'Low')
SET IDENTITY_INSERT [Utility].[Importance] OFF
/****** Object:  Table [Lodge].[CheckInAttachment]    Script Date: 01/01/2015 10:50:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInAttachment]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[CheckInAttachment](
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[AttachmentId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CheckInAttachment] PRIMARY KEY CLUSTERED 
(
	[ArtifactId] ASC,
	[AttachmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [Lodge].[CheckInAttachment] ([ArtifactId], [AttachmentId]) VALUES (CAST(717 AS Numeric(10, 0)), CAST(718 AS Numeric(10, 0)))
INSERT [Lodge].[CheckInAttachment] ([ArtifactId], [AttachmentId]) VALUES (CAST(717 AS Numeric(10, 0)), CAST(719 AS Numeric(10, 0)))
INSERT [Lodge].[CheckInAttachment] ([ArtifactId], [AttachmentId]) VALUES (CAST(721 AS Numeric(10, 0)), CAST(728 AS Numeric(10, 0)))
/****** Object:  Table [License].[Component]    Script Date: 01/01/2015 10:50:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Component]') AND type in (N'U'))
BEGIN
CREATE TABLE [License].[Component](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Code] [char](4) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsForm] [bit] NULL,
	[IsCatalogue] [bit] NULL,
	[IsReport] [bit] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [License].[Component] ON
INSERT [License].[Component] ([Id], [Code], [Name], [Description], [IsForm], [IsCatalogue], [IsReport]) VALUES (CAST(1 AS Numeric(10, 0)), N'CUST', N'Customer', N'Customer Management', 1, 0, 1)
INSERT [License].[Component] ([Id], [Code], [Name], [Description], [IsForm], [IsCatalogue], [IsReport]) VALUES (CAST(4 AS Numeric(10, 0)), N'INVO', N'Invoice', N'Invoice', 1, 1, 1)
INSERT [License].[Component] ([Id], [Code], [Name], [Description], [IsForm], [IsCatalogue], [IsReport]) VALUES (CAST(7 AS Numeric(10, 0)), N'LCHK', N'Check In', N'Lodge check in', 1, 0, 1)
INSERT [License].[Component] ([Id], [Code], [Name], [Description], [IsForm], [IsCatalogue], [IsReport]) VALUES (CAST(8 AS Numeric(10, 0)), N'LRSV', N'Room Reservation', N'Reserving rooms in lodge', 1, 0, 1)
INSERT [License].[Component] ([Id], [Code], [Name], [Description], [IsForm], [IsCatalogue], [IsReport]) VALUES (CAST(10 AS Numeric(10, 0)), N'PAMT', N'Payment', N'Payment Management System', 1, 0, 0)
SET IDENTITY_INSERT [License].[Component] OFF
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 01/01/2015 10:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CleanUpSchema]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/********************************************************
 COPYRIGHTS http://www.ranjithk.com
*********************************************************/  
CREATE PROCEDURE [dbo].[CleanUpSchema]
(
  @SchemaName varchar(100)
 ,@WorkTest char(1) = ''w''  -- use ''w'' to work and ''t'' to print
)
AS
/*-----------------------------------------------------------------------------------------
  
  Author : Ranjith Kumar S
  Date:    31/01/10
  
  Description: It drop all the objects in a schema and then the schema itself
  
  Limitations:
   
    1. If a table has a PK with XML or a Spatial Index then it wont work 
       (workaround: drop that table manually and re run it)
    2. If the schema is referred by a XML Schema collection then it wont work

If it is helpful, Please send your comments ranjith_842@hotmail.com or visit http://www.ranjithk.com
 
-------------------------------------------------------------------------------------------*/
BEGIN    

declare @SQL varchar(4000)
declare @msg varchar(500)
 
IF OBJECT_ID(''tempdb..#dropcode'') IS NOT NULL DROP TABLE #dropcode
CREATE TABLE #dropcode
(
   ID int identity(1,1)
  ,SQLstatement varchar(1000) 
 )

-- removes all the foreign keys that reference a PK in the target schema
 SELECT @SQL = 
  ''select 
       '''' ALTER TABLE ''''+SCHEMA_NAME(fk.schema_id)+''''.''''+OBJECT_NAME(fk.parent_object_id)+'''' DROP CONSTRAINT ''''+ fk.name
  FROM sys.foreign_keys fk
  join sys.tables t on t.object_id = fk.referenced_object_id
  where t.schema_id = schema_id('''''' + @SchemaName+'''''')
    and fk.schema_id <> t.schema_id 
  order by fk.name desc''
 
 IF @WorkTest = ''t'' PRINT (@SQL )
 INSERT INTO #dropcode
 EXEC (@SQL)
   
 -- drop all default constraints, check constraints and Foreign Keys
 SELECT @SQL = 
 ''SELECT 
       '''' ALTER TABLE ''''+schema_name(t.schema_id)+''''.''''+OBJECT_NAME(fk.parent_object_id)+'''' DROP CONSTRAINT ''''+ fk.[Name]
  FROM sys.objects fk
  join sys.tables t on t.object_id = fk.parent_object_id
  where t.schema_id = schema_id('''''' + @SchemaName+'''''')
   and fk.type IN (''''D'''', ''''C'''', ''''F'''')''
   
 IF @WorkTest = ''t'' PRINT (@SQL )
 INSERT INTO #dropcode
 EXEC (@SQL)
  
 -- drop all other objects in order    
 SELECT @SQL =   
 ''SELECT 
      CASE WHEN SO.type=''''PK'''' THEN '''' ALTER TABLE ''''+SCHEMA_NAME(SO.schema_id)+''''.''''+OBJECT_NAME(SO.parent_object_id)+'''' DROP CONSTRAINT ''''+ SO.name
           WHEN SO.type=''''U'''' THEN '''' DROP TABLE ''''+SCHEMA_NAME(SO.schema_id)+''''.''''+ SO.[Name]
           WHEN SO.type=''''V'''' THEN '''' DROP VIEW  ''''+SCHEMA_NAME(SO.schema_id)+''''.''''+ SO.[Name]
           WHEN SO.type=''''P'''' THEN '''' DROP PROCEDURE  ''''+SCHEMA_NAME(SO.schema_id)+''''.''''+ SO.[Name]          
           WHEN SO.type=''''TR'''' THEN ''''  DROP TRIGGER  ''''+SCHEMA_NAME(SO.schema_id)+''''.''''+ SO.[Name]
           WHEN SO.type  IN (''''FN'''', ''''TF'''',''''IF'''',''''FS'''',''''FT'''') THEN '''' DROP FUNCTION  ''''+SCHEMA_NAME(SO.schema_id)+''''.''''+ SO.[Name]
       END
FROM sys.objects SO
WHERE SO.schema_id = schema_id(''''''+ @SchemaName +'''''')
  AND SO.type IN (''''PK'''', ''''FN'''', ''''TF'''', ''''TR'''', ''''V'''', ''''U'''', ''''P'''')
ORDER BY CASE WHEN type = ''''PK'''' THEN 1 
              WHEN type in (''''FN'''', ''''TF'''', ''''P'''',''''IF'''',''''FS'''',''''FT'''') THEN 2
              WHEN type = ''''TR'''' THEN 3
              WHEN type = ''''V'''' THEN 4
              WHEN type = ''''U'''' THEN 5
            ELSE 6 
          END''

IF @WorkTest = ''t'' PRINT (@SQL )
INSERT INTO #dropcode
EXEC (@SQL)
  
DECLARE @ID int, @statement varchar(1000)
DECLARE statement_cursor CURSOR
FOR SELECT SQLstatement
      FROM #dropcode
  ORDER BY ID ASC
     
 OPEN statement_cursor
 FETCH statement_cursor INTO @statement 
 WHILE (@@FETCH_STATUS = 0)
 BEGIN
 
 IF @WorkTest = ''t'' PRINT (@statement)
 ELSE
  BEGIN
    PRINT (@statement)
    EXEC(@statement) 
  END
   
 FETCH statement_cursor INTO @statement     
END
  
CLOSE statement_cursor
DEALLOCATE statement_cursor
  
IF @WorkTest = ''t'' PRINT (''DROP SCHEMA ''+@SchemaName)
ELSE
 BEGIN
   PRINT (''DROP SCHEMA ''+@SchemaName)
   EXEC (''DROP SCHEMA ''+@SchemaName)
 END  
 
PRINT ''------- ALL - DONE -------''    
END
' 
END
GO
/****** Object:  Table [Configuration].[Country]    Script Date: 01/01/2015 10:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Country]') AND type in (N'U'))
BEGIN
CREATE TABLE [Configuration].[Country](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Configuration].[Country] ON
INSERT [Configuration].[Country] ([Id], [Name]) VALUES (CAST(1 AS Numeric(10, 0)), N'India')
SET IDENTITY_INSERT [Configuration].[Country] OFF
/****** Object:  Table [License].[Credential]    Script Date: 01/01/2015 10:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Credential]') AND type in (N'U'))
BEGIN
CREATE TABLE [License].[Credential](
	[LicenseNo] [varchar](max) NOT NULL,
	[LicenseDate] [date] NOT NULL,
	[AuthToken] [varbinary](50) NOT NULL,
	[FingurePrint] [varchar](max) NOT NULL,
	[InstallationDate] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Utility].[AppointmentType]    Script Date: 01/01/2015 10:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentType]') AND type in (N'U'))
BEGIN
CREATE TABLE [Utility].[AppointmentType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AppointmentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Utility].[AppointmentType] ON
INSERT [Utility].[AppointmentType] ([Id], [Name]) VALUES (CAST(1 AS Numeric(10, 0)), N'Meeting')
INSERT [Utility].[AppointmentType] ([Id], [Name]) VALUES (CAST(2 AS Numeric(10, 0)), N'To Do')
INSERT [Utility].[AppointmentType] ([Id], [Name]) VALUES (CAST(3 AS Numeric(10, 0)), N'Anniversary')
SET IDENTITY_INSERT [Utility].[AppointmentType] OFF
/****** Object:  Table [Invoice].[AdvancePayment]    Script Date: 01/01/2015 10:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePayment]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[AdvancePayment](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CardNumber] [varchar](16) NULL,
	[Remark] [varchar](255) NULL,
	[PaymentTypeId] [numeric](10, 0) NOT NULL,
	[InvoiceId] [numeric](10, 0) NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_AdvancPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Guardian].[Account]    Script Date: 01/01/2015 10:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[Account](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[LoginId] [varchar](63) NOT NULL,
	[Password] [varchar](31) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Guardian].[Account] ON
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(1 AS Numeric(10, 0)), N'ArpanKar', N'BinAff@1')
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(6 AS Numeric(10, 0)), N'BDhekial', N'BinAff@1')
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(7 AS Numeric(10, 0)), N'Biraj', N'BinAff@1')
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(11 AS Numeric(10, 0)), N'Recep', N'BinAff@1')
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(12 AS Numeric(10, 0)), N'All', N'BinAff@1')
SET IDENTITY_INSERT [Guardian].[Account] OFF
/****** Object:  Table [Customer].[ActionStatus]    Script Date: 01/01/2015 10:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customer].[ActionStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [Customer].[ActionStatus] ([Id], [Name]) VALUES (CAST(10001 AS Numeric(10, 0)), N'Open')
INSERT [Customer].[ActionStatus] ([Id], [Name]) VALUES (CAST(10002 AS Numeric(10, 0)), N'Close')
INSERT [Customer].[ActionStatus] ([Id], [Name]) VALUES (CAST(10003 AS Numeric(10, 0)), N'Cancel')
INSERT [Customer].[ActionStatus] ([Id], [Name]) VALUES (CAST(10004 AS Numeric(10, 0)), N'CheckIn')
INSERT [Customer].[ActionStatus] ([Id], [Name]) VALUES (CAST(10005 AS Numeric(10, 0)), N'Modify')
/****** Object:  Table [Lodge].[BuildingStatus]    Script Date: 01/01/2015 10:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[BuildingStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BuildingStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [Lodge].[BuildingStatus] ([Id], [Name]) VALUES (CAST(10001 AS Numeric(10, 0)), N'Open')
INSERT [Lodge].[BuildingStatus] ([Id], [Name]) VALUES (CAST(10002 AS Numeric(10, 0)), N'Close')
/****** Object:  Table [Report].[Category]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [Report].[Category](
	[Id] [numeric](10, 0) NOT NULL,
	[Extension] [varchar](15) NULL,
	[Name] [varchar](63) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [Report].[Category] ([Id], [Extension], [Name]) VALUES (CAST(10001 AS Numeric(10, 0)), N'drpt', N'Daily')
INSERT [Report].[Category] ([Id], [Extension], [Name]) VALUES (CAST(10002 AS Numeric(10, 0)), N'wrpt', N'Weekly')
INSERT [Report].[Category] ([Id], [Extension], [Name]) VALUES (CAST(10003 AS Numeric(10, 0)), N'mrpt', N'Monthly')
INSERT [Report].[Category] ([Id], [Extension], [Name]) VALUES (CAST(10004 AS Numeric(10, 0)), N'qrpt', N'Quarterly')
INSERT [Report].[Category] ([Id], [Extension], [Name]) VALUES (CAST(10005 AS Numeric(10, 0)), N'yrpt', N'Yearly')
/****** Object:  Table [Lodge].[BuildingType]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingType]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[BuildingType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BuildingType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[BuildingType] ON
INSERT [Lodge].[BuildingType] ([Id], [Name]) VALUES (CAST(2 AS Numeric(10, 0)), N'Cottage')
INSERT [Lodge].[BuildingType] ([Id], [Name]) VALUES (CAST(4 AS Numeric(10, 0)), N'Tent')
INSERT [Lodge].[BuildingType] ([Id], [Name]) VALUES (CAST(5 AS Numeric(10, 0)), N'Economy')
INSERT [Lodge].[BuildingType] ([Id], [Name]) VALUES (CAST(6 AS Numeric(10, 0)), N'Spanish Tent')
INSERT [Lodge].[BuildingType] ([Id], [Name]) VALUES (CAST(19 AS Numeric(10, 0)), N'Log House')
SET IDENTITY_INSERT [Lodge].[BuildingType] OFF
/****** Object:  Table [License].[Module]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Module]') AND type in (N'U'))
BEGIN
CREATE TABLE [License].[Module](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Code] [char](4) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsMandatory] [bit] NULL,
 CONSTRAINT [PK_Module_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [License].[Module] ON
INSERT [License].[Module] ([Id], [Code], [Name], [Description], [IsMandatory]) VALUES (CAST(1 AS Numeric(10, 0)), N'CUST', N'Customer Management', N'Customer management system', 1)
INSERT [License].[Module] ([Id], [Code], [Name], [Description], [IsMandatory]) VALUES (CAST(2 AS Numeric(10, 0)), N'LODG', N'Lodge Management', N'Lodge management system', 0)
INSERT [License].[Module] ([Id], [Code], [Name], [Description], [IsMandatory]) VALUES (CAST(3 AS Numeric(10, 0)), N'ACCT', N'Accountant', N'Invoice management system', 1)
INSERT [License].[Module] ([Id], [Code], [Name], [Description], [IsMandatory]) VALUES (CAST(4 AS Numeric(10, 0)), N'GUAR', N'Guardian', N'User management System', 1)
SET IDENTITY_INSERT [License].[Module] OFF
/****** Object:  StoredProcedure [dbo].[EmailReadForParent]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[EmailReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, OrganizationId, Email
	FROM OrganizationEmail WITH (NOLOCK)
	WHERE OrganizationId = @ParentId   
	
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[EmailRead]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[EmailRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, OrganizationId, Email
	FROM OrganizationEmail WITH (NOLOCK)
	WHERE OrganizationId = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EmailInsert]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [dbo].[EmailInsert]
(  
	@Email Varchar(50),
	@OrganizationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO OrganizationEmail([Email],[OrganizationId])
	VALUES(@Email,@OrganizationId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  Table [Organization].[Organization]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Organization]') AND type in (N'U'))
BEGIN
CREATE TABLE [Organization].[Organization](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Logo] [varbinary](max) NULL,
	[LicenceNumber] [varchar](50) NULL,
	[ServiceTaxNumber] [varchar](50) NULL,
	[LuxuaryTaxNumber] [varchar](50) NULL,
	[Tan] [varchar](50) NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](50) NULL,
	[StateId] [numeric](10, 0) NULL,
	[Pin] [int] NULL,
	[ContactName] [varchar](50) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Organization].[Organization] ON
INSERT [Organization].[Organization] ([Id], [Name], [Logo], [LicenceNumber], [ServiceTaxNumber], [LuxuaryTaxNumber], [Tan], [Address], [City], [StateId], [Pin], [ContactName]) VALUES (CAST(12 AS Numeric(10, 0)), N'ABC Lodge', NULL, N'ABC237B', NULL, NULL, N'ABCD12345E', N'Bangalore, Old Airport Road', N'Bangalore', CAST(1 AS Numeric(10, 0)), 560017, N'Manjunath')
SET IDENTITY_INSERT [Organization].[Organization] OFF
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkRead]
(
	@InvoiceId Numeric(10,0)
)
As
BEGIN

	SELECT [InvoiceId],[TaxationId]
	FROM [Invoice].InvoiceTaxationLink WITH (NOLOCK)
	WHERE InvoiceId = @InvoiceId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkInsert]
(  
	@InvoiceId Numeric(10,0),
	@TaxationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  [Invoice].InvoiceTaxationLink([InvoiceId],[TaxationId])
	VALUES(@InvoiceId,@TaxationId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].InvoiceTaxationLink
	WHERE InvoiceId = @Id   
   
END
' 
END
GO
/****** Object:  Table [Invoice].[Invoice]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Invoice]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[Invoice](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Advance] [money] NULL,
	[Discount] [money] NULL,
	[SellerName] [varchar](50) NOT NULL,
	[SellerAddress] [varchar](250) NULL,
	[SellerContactNo] [varchar](50) NULL,
	[SellerEmail] [varchar](50) NULL,
	[SellerLicence] [varchar](50) NULL,
	[BuyerName] [varchar](50) NOT NULL,
	[BuyerAddress] [varchar](250) NULL,
	[BuyerContactNo] [varchar](50) NULL,
	[BuyerEmail] [varchar](50) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoicePaymentLinkRead]
(
	@InvoiceId Numeric(10,0)
)
As
BEGIN

	SELECT  [InvoiceId],[PaymentId]
	FROM [Invoice].InvoicePaymentLink WITH (NOLOCK)
	WHERE InvoiceId = @InvoiceId

END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoicePaymentLinkInsert]
(  
	@InvoiceId Numeric(10,0),
	@PaymentId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  [Invoice].InvoicePaymentLink([InvoiceId],[PaymentId])
	VALUES(@InvoiceId,@PaymentId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoicePaymentLinkDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].InvoicePaymentLink
	WHERE InvoiceId = @Id   
   
END
' 
END
GO
/****** Object:  Table [Configuration].[Initial]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Initial]') AND type in (N'U'))
BEGIN
CREATE TABLE [Configuration].[Initial](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Initial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Configuration].[Initial] ON
INSERT [Configuration].[Initial] ([Id], [Name]) VALUES (CAST(1 AS Numeric(10, 0)), N'Miss')
INSERT [Configuration].[Initial] ([Id], [Name]) VALUES (CAST(2 AS Numeric(10, 0)), N'Mrs')
INSERT [Configuration].[Initial] ([Id], [Name]) VALUES (CAST(4 AS Numeric(10, 0)), N'Col')
INSERT [Configuration].[Initial] ([Id], [Name]) VALUES (CAST(5 AS Numeric(10, 0)), N'Dr')
INSERT [Configuration].[Initial] ([Id], [Name]) VALUES (CAST(6 AS Numeric(10, 0)), N'Mr')
SET IDENTITY_INSERT [Configuration].[Initial] OFF
/****** Object:  Table [Guardian].[Role]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[Role](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](63) NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Guardian].[Role] ON
INSERT [Guardian].[Role] ([Id], [Name], [Description]) VALUES (CAST(0 AS Numeric(10, 0)), N'SuperAdmin', N'Internal IT Support Login')
INSERT [Guardian].[Role] ([Id], [Name], [Description]) VALUES (CAST(1 AS Numeric(10, 0)), N'Admin', N'System Administrator')
INSERT [Guardian].[Role] ([Id], [Name], [Description]) VALUES (CAST(2 AS Numeric(10, 0)), N'Receptionist', N'Front Desk Operator')
INSERT [Guardian].[Role] ([Id], [Name], [Description]) VALUES (CAST(3 AS Numeric(10, 0)), N'Cashier', N'Accounting Department')
SET IDENTITY_INSERT [Guardian].[Role] OFF
/****** Object:  Table [Invoice].[Report]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Report]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[Report](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[ReportCategoryId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [Customer].[Report]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Report]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customer].[Report](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[ReportCategoryId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Report_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [Invoice].[PaymentType]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentType]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[PaymentType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_InvoicePaymentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Invoice].[PaymentType] ON
INSERT [Invoice].[PaymentType] ([Id], [Name]) VALUES (CAST(2 AS Numeric(10, 0)), N'Debit card')
INSERT [Invoice].[PaymentType] ([Id], [Name]) VALUES (CAST(4 AS Numeric(10, 0)), N'Credit card')
INSERT [Invoice].[PaymentType] ([Id], [Name]) VALUES (CAST(5 AS Numeric(10, 0)), N'Cash')
SET IDENTITY_INSERT [Invoice].[PaymentType] OFF
/****** Object:  Table [Lodge].[RoomCategory]    Script Date: 01/01/2015 10:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomCategory](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoomCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[RoomCategory] ON
INSERT [Lodge].[RoomCategory] ([Id], [Name]) VALUES (CAST(2 AS Numeric(10, 0)), N'Suit')
INSERT [Lodge].[RoomCategory] ([Id], [Name]) VALUES (CAST(3 AS Numeric(10, 0)), N'Economy')
INSERT [Lodge].[RoomCategory] ([Id], [Name]) VALUES (CAST(4 AS Numeric(10, 0)), N'Delux')
SET IDENTITY_INSERT [Lodge].[RoomCategory] OFF
/****** Object:  Table [Lodge].[RoomStatus]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoomStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [Lodge].[RoomStatus] ([Id], [Name]) VALUES (CAST(10001 AS Numeric(10, 0)), N'Open')
INSERT [Lodge].[RoomStatus] ([Id], [Name]) VALUES (CAST(10002 AS Numeric(10, 0)), N'Closed')
/****** Object:  Table [Navigator].[Rule]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[Rule]') AND type in (N'U'))
BEGIN
CREATE TABLE [Navigator].[Rule](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ModuleSeperator] [char](1) NOT NULL,
	[PathSeperator] [char](1) NOT NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Navigator].[Rule] ON
INSERT [Navigator].[Rule] ([Id], [ModuleSeperator], [PathSeperator]) VALUES (CAST(1 AS Numeric(10, 0)), N':', N'\')
SET IDENTITY_INSERT [Navigator].[Rule] OFF
/****** Object:  Table [Customer].[Rule]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Rule]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customer].[Rule](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[IsPinNo] [bit] NULL,
	[IsAlternateContactNo] [bit] NULL,
	[IsEmail] [bit] NULL,
	[IsIdentityProof] [bit] NULL
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Customer].[Rule] ON
INSERT [Customer].[Rule] ([Id], [IsPinNo], [IsAlternateContactNo], [IsEmail], [IsIdentityProof]) VALUES (CAST(1 AS Numeric(10, 0)), 0, 0, 0, 1)
SET IDENTITY_INSERT [Customer].[Rule] OFF
/****** Object:  Table [Configuration].[Rule]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Rule]') AND type in (N'U'))
BEGIN
CREATE TABLE [Configuration].[Rule](
	[DateFormat] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Lodge].[RoomType]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomType]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Accomodation] [smallint] NOT NULL,
	[ExtraAccomodation] [smallint] NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[RoomType] ON
INSERT [Lodge].[RoomType] ([Id], [Name], [Accomodation], [ExtraAccomodation]) VALUES (CAST(1 AS Numeric(10, 0)), N'Single Bed Room', 1, 0)
INSERT [Lodge].[RoomType] ([Id], [Name], [Accomodation], [ExtraAccomodation]) VALUES (CAST(2 AS Numeric(10, 0)), N'Double Bed Room', 2, 1)
INSERT [Lodge].[RoomType] ([Id], [Name], [Accomodation], [ExtraAccomodation]) VALUES (CAST(3 AS Numeric(10, 0)), N'Two Single Bed Room', 2, 2)
SET IDENTITY_INSERT [Lodge].[RoomType] OFF
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Reservation].[StatusUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Reservation].[Status]
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Reservation].[StatusReadAll]	
AS
BEGIN
	
	SELECT Id, Name
	FROM Reservation.Status WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Reservation].[StatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Reservation.Status WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Reservation].[StatusInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Reservation].Status([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Reservation].[StatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Reservation].[Status]
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Guardian].[SecurityQuestion]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestion]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[SecurityQuestion](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Question] [varchar](155) NULL,
 CONSTRAINT [PK_SecurityQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Guardian].[SecurityQuestion] ON
INSERT [Guardian].[SecurityQuestion] ([Id], [Question]) VALUES (CAST(2 AS Numeric(10, 0)), N'What is your pet name at home ?')
INSERT [Guardian].[SecurityQuestion] ([Id], [Question]) VALUES (CAST(3 AS Numeric(10, 0)), N'What is your mother''s maiden name ?')
SET IDENTITY_INSERT [Guardian].[SecurityQuestion] OFF
/****** Object:  Table [Invoice].[Taxation]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Taxation]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[Taxation](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Amount] [money] NOT NULL,
	[IsPercentage] [bit] NOT NULL,
 CONSTRAINT [PK_Taxation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Invoice].[Taxation] ON
INSERT [Invoice].[Taxation] ([Id], [Name], [Amount], [IsPercentage]) VALUES (CAST(1 AS Numeric(10, 0)), N'Service Tax', 15.0000, 1)
INSERT [Invoice].[Taxation] ([Id], [Name], [Amount], [IsPercentage]) VALUES (CAST(2 AS Numeric(10, 0)), N'Luxury Tax', 12.5000, 1)
SET IDENTITY_INSERT [Invoice].[Taxation] OFF
/****** Object:  Table [Guardian].[UserRule]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRule]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[UserRule](
	[DefaultPassword] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [Guardian].[UserRule] ([DefaultPassword]) VALUES (N'BinAff@1')
/****** Object:  Table [BinAff].[Stamp]    Script Date: 01/01/2015 10:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[BinAff].[Stamp]') AND type in (N'U'))
BEGIN
CREATE TABLE [BinAff].[Stamp](
	[ProductId] [varchar](max) NOT NULL,
	[ProductName] [varchar](max) NOT NULL,
	[FingurePrint] [varchar](max) NOT NULL,
	[LicenseDate] [varchar](max) NOT NULL,
	[RegistrationDate] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [BinAff].[Stamp] ([ProductId], [ProductName], [FingurePrint], [LicenseDate], [RegistrationDate]) VALUES (N'PD-WIN-001', N'Splash', N'R4tZ4idF5mQTwug938uR+6Ekh883C5evDqaXFHpvAJJUeyYPvQ3pUv2ljnBnPITK', N'd+sexjE11ls81ltPP/LjRA==', N'd+sexjE11ls81ltPP/LjRA==')
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE Function [dbo].[Split](@Text Text, @Delimitor Char(1)) 
RETURNS
@Table TABLE
(
    [Index] int Identity(0,1),
    [SplitText] varchar(20)
)
AS

BEGIN
    DECLARE @Current varchar(20)
    DECLARE @EndIndex int
    DECLARE @TextLength int
    DECLARE @StartIndex int
       
    SET @StartIndex = 1
       
    IF(@Text IS NOT NULL)
    BEGIN
        SET @TextLength = DataLength(@Text)
              
        WHILE(1 = 1)
        BEGIN
            SET @EndIndex = CharIndex(@Delimitor, @Text, @StartIndex) 
            IF(@EndIndex != 0)
            BEGIN
                SET @Current = SubString(@Text, @StartIndex, @EndIndex - @StartIndex)
                INSERT INTO @table ([SplitText]) VALUES(@Current)
                SET @StartIndex = @EndIndex + 1   
            END
            ELSE
            BEGIN
                SET @Current = substring(@Text, @StartIndex, DataLength(@Text) - @StartIndex + 1)
                INSERT INTO @table ([SplitText]) VALUES(@Current)
                BREAK
            END
        END 
    END
       
    RETURN
END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[UserRuleRead] 
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	SELECT DefaultPassword	
	FROM UserRule WITH (NOLOCK)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[UserRuleInsert]
(  
	@DefaultUserPwd Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	Declare @Cnt Int
	Select @Cnt = COUNT(*) From UserRule
	
	if(@Cnt > 0)
	Begin	
		update UserRule
		set [DefaultPassword] = @DefaultUserPwd	
	End
	Else
	Begin
		INSERT INTO UserRule([DefaultPassword])
		VALUES(@DefaultUserPwd)
    End
    
	SET @Id = 1
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[Update]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[Update]
(
	@Id Numeric(10,0),
	@InvoiceNumber Varchar(50),
	@Advance Money,
	@Discount Money,
	
	@SellerName Varchar(50),
	@SellerAddress Varchar(250),
	@SellerContactNo Varchar(50),
	@SellerEmail Varchar(50),
	@SellerLicence Varchar(50),
	
	@BuyerName Varchar(50),
	@BuyerAddress Varchar(250),
	@BuyerContactNo Varchar(50),
	@BuyerEmail Varchar(50)
)
AS
BEGIN
	
	UPDATE [Invoice].Invoice
	SET	
		[Date] = GETDATE(),
		[InvoiceNumber] = @InvoiceNumber,
		[Advance] = @Advance,
		[Discount] = @Discount,
		[SellerName] = @SellerName,
		[SellerAddress] = @SellerAddress,
		[SellerContactNo] = @SellerContactNo,
		[SellerEmail] = @SellerEmail,
		[SellerLicence] = @SellerLicence,
		[BuyerName] = @BuyerName,
		[BuyerAddress] = @BuyerAddress,
		[BuyerContactNo] = @BuyerContactNo,
		[BuyerEmail] = @BuyerEmail
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationUpdate]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50),
	@Amount Money,
	@IsPercentage Bit
)
AS
BEGIN
	
	UPDATE [Invoice].Taxation
	SET	
		[Name] = @Name,	
		[Amount] = @Amount,
		[IsPercentage] = @IsPercentage
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadDuplicate]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationReadDuplicate]
(
	@Name VARCHAR(50)		
)
AS
BEGIN

	SELECT Id	
	FROM [Invoice].Taxation WITH (NOLOCK)
	WHERE Name = @Name
				
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[TaxationReadAll]
AS
BEGIN
	
	SELECT 
		Id,		
		[Name],
		[Amount],
		[IsPercentage]
	FROM [Invoice].Taxation WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadAll]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationReadAll]
AS
BEGIN
	
	SELECT 
		Id,		
		[Name],
		[Amount],
		[IsPercentage]
	FROM [Invoice].Taxation WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[TaxationRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,		
		[Name],
		[Amount],
		[IsPercentage]
	FROM [Invoice].Taxation WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationRead]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id,	Name, Amount, IsPercentage
	FROM Invoice.Taxation WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationInsert]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationInsert]
(  
	@Name Varchar(50),
	@Amount Money,
	@IsPercentage Bit,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  [Invoice].Taxation([Name],[Amount],[IsPercentage])
	VALUES(@Name,@Amount,@IsPercentage)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationDelete]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].Taxation
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Guardian].[UserRole]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRole]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[UserRole](
	[UserId] [numeric](10, 0) NOT NULL,
	[RoleId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [Guardian].[UserRole] ([UserId], [RoleId]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)))
INSERT [Guardian].[UserRole] ([UserId], [RoleId]) VALUES (CAST(6 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)))
INSERT [Guardian].[UserRole] ([UserId], [RoleId]) VALUES (CAST(6 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)))
INSERT [Guardian].[UserRole] ([UserId], [RoleId]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)))
INSERT [Guardian].[UserRole] ([UserId], [RoleId]) VALUES (CAST(11 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)))
INSERT [Guardian].[UserRole] ([UserId], [RoleId]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)))
INSERT [Guardian].[UserRole] ([UserId], [RoleId]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)))
INSERT [Guardian].[UserRole] ([UserId], [RoleId]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)))
/****** Object:  Table [Configuration].[State]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[State]') AND type in (N'U'))
BEGIN
CREATE TABLE [Configuration].[State](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CountryId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Configuration].[State] ON
INSERT [Configuration].[State] ([Id], [Name], [CountryId]) VALUES (CAST(1 AS Numeric(10, 0)), N'Karnataka', CAST(1 AS Numeric(10, 0)))
INSERT [Configuration].[State] ([Id], [Name], [CountryId]) VALUES (CAST(3 AS Numeric(10, 0)), N'Kerela', CAST(1 AS Numeric(10, 0)))
INSERT [Configuration].[State] ([Id], [Name], [CountryId]) VALUES (CAST(5 AS Numeric(10, 0)), N'Assam', CAST(1 AS Numeric(10, 0)))
INSERT [Configuration].[State] ([Id], [Name], [CountryId]) VALUES (CAST(8 AS Numeric(10, 0)), N'West Bengal', CAST(1 AS Numeric(10, 0)))
INSERT [Configuration].[State] ([Id], [Name], [CountryId]) VALUES (CAST(9 AS Numeric(10, 0)), N'Jharkhand', CAST(1 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Configuration].[State] OFF
/****** Object:  Table [Invoice].[Slab]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Slab]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[Slab](
	[TaxId] [numeric](10, 0) NOT NULL,
	[Limit] [numeric](10, 0) NOT NULL,
	[Amount] [numeric](4, 2) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_TaxDetails] PRIMARY KEY CLUSTERED 
(
	[TaxId] ASC,
	[Limit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [Invoice].[Slab] ([TaxId], [Limit], [Amount], [StartDate], [EndDate]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(1000 AS Numeric(10, 0)), CAST(12.50 AS Numeric(4, 2)), CAST(0x5B380B00 AS Date), CAST(0xC7390B00 AS Date))
INSERT [Invoice].[Slab] ([TaxId], [Limit], [Amount], [StartDate], [EndDate]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(500 AS Numeric(10, 0)), CAST(4.00 AS Numeric(4, 2)), CAST(0x5B380B00 AS Date), CAST(0xC7390B00 AS Date))
INSERT [Invoice].[Slab] ([TaxId], [Limit], [Amount], [StartDate], [EndDate]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(1000 AS Numeric(10, 0)), CAST(8.00 AS Numeric(4, 2)), CAST(0x5B380B00 AS Date), CAST(0xC7390B00 AS Date))
INSERT [Invoice].[Slab] ([TaxId], [Limit], [Amount], [StartDate], [EndDate]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(2000 AS Numeric(10, 0)), CAST(12.00 AS Numeric(4, 2)), CAST(0x5B380B00 AS Date), CAST(0xC7390B00 AS Date))
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityQuestionUpdate]
(
	@Id Numeric(10,0),  
	@Question Varchar(127)
)
AS
BEGIN
	
	UPDATE SecurityQuestion
	SET	
		Question = @Question		
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityQuestionReadDuplicate]
(
	@Name VARCHAR(250)		
)
AS
BEGIN

	SELECT Id,Question	
	FROM [Guardian].securityQuestion WITH (NOLOCK)
	WHERE Question = @Name
			
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityQuestionReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		Question	
	FROM SecurityQuestion WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityQuestionRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Question		
	FROM SecurityQuestion WITH (NOLOCK)
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityQuestionInsert]
(  
	@Question Varchar(155),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO SecurityQuestion(Question)
	VALUES(@Question)
   
	SET @Id = @@IDENTITY

END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityQuestionDelete]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	
   DELETE 		
   FROM SecurityQuestion
   WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[RuleUpdate]
(  
	@ModuleSeperator Char(1),
	@PathSeperator Char(1)
)
AS
BEGIN
	UPDATE Navigator.[Rule]
	SET ModuleSeperator = @ModuleSeperator,
		PathSeperator = @PathSeperator
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[RuleUpdate]
	(  
		@Id Numeric(10,0),  
		@IsPinNumber Bit,
		@IsAlternateContactNumber Bit,
		@IsEmail Bit,
		@IsIdentityProof Bit		
	)
	AS
	BEGIN
		update Customer.[Rule]
		Set [IsPinNo] = @IsPinNumber,		
			[IsAlternateContactNo] = @IsAlternateContactNumber,
			[IsEmail] = @IsEmail,
			[IsIdentityProof] = @IsIdentityProof		
	END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[RuleRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		ModuleSeperator,
		PathSeperator
	FROM Navigator.[Rule] WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[RuleRead]  
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	SELECT 
		IsNull(IsPinNo,0) IsPinNo,
		IsNull(IsAlternateContactNo,0) IsAlternateContactNo,
		IsNull(IsEmail,0) IsEmail,
		IsNull(IsIdentityProof,0) IsIdentityProof 
	FROM Customer.[Rule] WITH (NOLOCK)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[RuleRead]
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	Select DateFormat	
	From Configuration.[Rule] WITH (NOLOCK)
 
END' 
END
GO
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[RuleInsert]
(  
	@ModuleSeperator Char(1),
	@PathSeperator Char(1),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Navigator.[Rule](ModuleSeperator, PathSeperator)
	VALUES(@ModuleSeperator, @PathSeperator)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Customer].[RuleInsert]
	(  
		@IsPinNumber Bit,
		@IsAlternateContactNumber Bit,
		@IsEmail Bit,
		@IsIdentityProof Bit,	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		Declare @Cnt Int
		Select @Cnt = COUNT(*) From Customer.[Rule]
		
		if(@Cnt > 0)
		Begin	
			update Customer.CustomerRule
			set [IsPinNo] = @IsPinNumber,		
				[IsAlternateContactNo] = @IsAlternateContactNumber,
				[IsEmail] = @IsEmail,
				[IsIdentityProof] = @IsIdentityProof		
		End
		Else
		Begin
			INSERT INTO CustomerRule([IsPinNo],[IsAlternateContactNo],[IsEmail],[IsIdentityProof])
			VALUES(@IsPinNumber,@IsAlternateContactNumber, @IsEmail,@IsIdentityProof)
		End
	    
		SET @Id = 1
	END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[RuleInsert]
(  
	@DateFormat Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	Declare @Cnt Int
	Select @Cnt = COUNT(*) From [Configuration].[Rule]
	
	if(@Cnt > 0)
	Begin	
		update [Configuration].[Rule]
		set [DateFormat] = @DateFormat
	End
	Else
	Begin
		INSERT INTO [Configuration].[Rule]([DateFormat])
		VALUES(@DateFormat)
    End
    
	SET @Id = 1
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeUpdate]
(	
	@Id Numeric(10,0),
	@Name Varchar(50),
	@Accomodation SmallInt,
	@ExtraAccomodation SmallInt
)
AS
BEGIN
	
	UPDATE Lodge.RoomType
	SET	
		Name = @Name,
		Accomodation = @Accomodation,
		ExtraAccomodation = @ExtraAccomodation
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeReadAll]
AS
BEGIN

	SELECT Id, Name, Accomodation, ExtraAccomodation
	FROM Lodge.RoomType WITH (NOLOCK)
	
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name, Accomodation, ExtraAccomodation
	FROM Lodge.RoomType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeInsert]
(  
	@Name Varchar(50),
	@Accomodation SmallInt,
	@ExtraAccomodation SmallInt,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
	
	INSERT INTO Lodge.RoomType(Name, Accomodation, ExtraAccomodation)
	VALUES(@Name, @Accomodation, @ExtraAccomodation)
   
	SET @Id = @@IDENTITY
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 01/01/2015 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Lodge].[RoomTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Lodge.RoomType
	WHERE Id = @Id      
END
' 
END
GO
/****** Object:  Table [Guardian].[SecurityAnswer]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[SecurityAnswer](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[UserId] [numeric](10, 0) NOT NULL,
	[QuestionId] [numeric](10, 0) NOT NULL,
	[Answer] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Security__3214EC07529933DA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Guardian].[SecurityAnswer] ON
INSERT [Guardian].[SecurityAnswer] ([Id], [UserId], [QuestionId], [Answer]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Bumba')
INSERT [Guardian].[SecurityAnswer] ([Id], [UserId], [QuestionId], [Answer]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(12 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), N'Try')
SET IDENTITY_INSERT [Guardian].[SecurityAnswer] OFF
/****** Object:  Table [Lodge].[RoomTariff]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariff]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomTariff](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CategoryId] [numeric](10, 0) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[IsAirConditioned] [bit] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Rate] [money] NOT NULL,
 CONSTRAINT [PK_RoomTariff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Lodge].[RoomTariff] ON
INSERT [Lodge].[RoomTariff] ([Id], [CategoryId], [TypeId], [IsAirConditioned], [StartDate], [EndDate], [Rate]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, CAST(0x0000A2F400000000 AS DateTime), CAST(0x0000A2F400000000 AS DateTime), 10000.0000)
INSERT [Lodge].[RoomTariff] ([Id], [CategoryId], [TypeId], [IsAirConditioned], [StartDate], [EndDate], [Rate]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, CAST(0x0000A2F400000000 AS DateTime), CAST(0x0000A46100000000 AS DateTime), 10000.0000)
INSERT [Lodge].[RoomTariff] ([Id], [CategoryId], [TypeId], [IsAirConditioned], [StartDate], [EndDate], [Rate]) VALUES (CAST(3 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, CAST(0x0000A30100000000 AS DateTime), CAST(0x0000A47100000000 AS DateTime), 20000.0000)
INSERT [Lodge].[RoomTariff] ([Id], [CategoryId], [TypeId], [IsAirConditioned], [StartDate], [EndDate], [Rate]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), 1, CAST(0x0000A33400000000 AS DateTime), CAST(0x0000A46100000000 AS DateTime), 10000.0000)
SET IDENTITY_INSERT [Lodge].[RoomTariff] OFF
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Lodge].RoomStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Lodge].[RoomStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].RoomStatus
	WHERE Id = @Id      
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationStatusReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Customer.ActionStatus WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
		
	SELECT Id, Name
	FROM Customer.ActionStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomCategoryUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].RoomCategory
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomCategoryReadAll]
As
BEGIN

	SELECT Id,Name
	FROM [Lodge].RoomCategory WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomCategoryRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Lodge].RoomCategory WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomCategoryInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomCategory([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Lodge].[RoomCategoryDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].RoomCategory
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[RoleReadAll]
AS
BEGIN

	SELECT Id, Name, Description
	FROM Guardian.Role WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[RoleRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN

	SELECT Id, Name, [Description]
	FROM  Guardian.[Role] WITH (NOLOCK)
	WHERE Id = @Id
	
END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[RoleInsert]
(
	@Name Varchar(63),
	@Description Varchar(255),
	@Id Numeric(10,0) OUT
)
AS
BEGIN
	INSERT INTO Guardian.[Role](Name, [Description])
	VALUES(@Name, @Description)
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[Delete]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[Delete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].Invoice
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Lodge].[RoomReservation]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservation]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomReservation](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[BookingFrom] [datetime] NOT NULL,
	[NoOfDays] [numeric](3, 0) NOT NULL,
	[NoOfMale] [tinyint] NULL,
	[NoOfFemale] [tinyint] NULL,
	[NoOfChild] [tinyint] NULL,
	[NoOfInfant] [tinyint] NOT NULL,
	[NoOfRooms] [tinyint] NOT NULL,
	[RoomCategoryId] [numeric](10, 0) NULL,
	[RoomTypeId] [numeric](10, 0) NULL,
	[AcRoomPreference] [int] NULL,
	[Remark] [varchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	[IsCheckedIn] [bit] NOT NULL CONSTRAINT [DF_RoomReservation_IsCheckedIn]  DEFAULT ((0)),
 CONSTRAINT [PK_RoomReservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[RoomReservation] ON
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(169 AS Numeric(10, 0)), CAST(0x0000A407009CB148 AS DateTime), CAST(2 AS Numeric(3, 0)), 2, 2, 1, 1, 2, CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), 1, N'Need railway station pickup', CAST(0x0000A3FE0109D6BE AS DateTime), CAST(10003 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(170 AS Numeric(10, 0)), CAST(0x0000A4030116FD18 AS DateTime), CAST(10 AS Numeric(3, 0)), 1, 1, 0, 0, 1, CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, N'Lunch request', CAST(0x0000A40300E46230 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(171 AS Numeric(10, 0)), CAST(0x0000A405009450C0 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 1, 0, 0, 1, CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), 1, N'', CAST(0x0000A4040096166B AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(172 AS Numeric(10, 0)), CAST(0x0000A40400975C0C AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 1, 0, 1, 1, CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), 1, N'', CAST(0x0000A4040097E8B2 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(175 AS Numeric(10, 0)), CAST(0x0000A40500C5C100 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), 1, N'', CAST(0x0000A40500D0C634 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(176 AS Numeric(10, 0)), CAST(0x0000A40700F73140 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 1, 0, 0, 1, CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), 1, N'', CAST(0x0000A4050104CFD7 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(177 AS Numeric(10, 0)), CAST(0x0000A40500A4CB80 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, N'', CAST(0x0000A405010C0BAA AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(178 AS Numeric(10, 0)), CAST(0x0000A40D00B54640 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 1, 0, 0, 1, CAST(3 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), 2, N'', CAST(0x0000A40D00B4D501 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(179 AS Numeric(10, 0)), CAST(0x0000A40D00E6B680 AS DateTime), CAST(1 AS Numeric(3, 0)), 2, 2, 1, 0, 2, CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), 1, N'', CAST(0x0000A40D00F28149 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(180 AS Numeric(10, 0)), CAST(0x0000A41501206420 AS DateTime), CAST(1 AS Numeric(3, 0)), 2, 2, 0, 0, 2, CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), 1, N'', CAST(0x0000A410010B2AC2 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
SET IDENTITY_INSERT [Lodge].[RoomReservation] OFF
/****** Object:  StoredProcedure [Invoice].[ReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[ReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Date],
		[InvoiceNumber],
		[Advance],
		[Discount],
		[SellerName],
		[SellerAddress],
		[SellerContactNo],
		[SellerEmail],
		[SellerLicence],
		[BuyerName],
		[BuyerAddress],
		[BuyerContactNo],
		[BuyerEmail]
	FROM [Invoice].Invoice WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[Read]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Read]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[Read]
(
	@Id Numeric(10,0)
)
AS
BEGIN	
	
	SELECT 
		Id,
		[Date],
		[InvoiceNumber],
		[Advance],
		[Discount],
		[SellerName],
		[SellerAddress],
		[SellerContactNo],
		[SellerEmail],
		[SellerLicence],
		[BuyerName],
		[BuyerAddress],
		[BuyerContactNo],
		[BuyerEmail]		
	FROM [Invoice].Invoice WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  Table [Guardian].[Profile]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Profile]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[Profile](
	[UserId] [numeric](10, 0) NOT NULL,
	[Initial] [numeric](10, 0) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[Dob] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [Guardian].[Profile] ([UserId], [Initial], [FirstName], [MiddleName], [LastName], [Dob]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Arpan', N'', N'Kar', CAST(0x00006E2600000000 AS DateTime))
INSERT [Guardian].[Profile] ([UserId], [Initial], [FirstName], [MiddleName], [LastName], [Dob]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), N'All', N'In', N'One', CAST(0x0000A29200000000 AS DateTime))
/****** Object:  StoredProcedure [Invoice].[PaymentTypeUpdate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE [Invoice].PaymentType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadDuplicate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN

	SELECT Id	
	FROM [Invoice].PaymentType WITH (NOLOCK)
	WHERE Name = @Name
				
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Invoice].PaymentType WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Name]
	FROM [Invoice].PaymentType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  [Invoice].PaymentType([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeDelete]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].PaymentType
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadForInvoiceNumber]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadForInvoiceNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[ReadForInvoiceNumber]
(
	@InvoiceNumber Varchar(50)
)
AS
BEGIN		
	SELECT 
		Id
	FROM [Invoice].Invoice WITH (NOLOCK)
	WHERE InvoiceNumber = @InvoiceNumber
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadDuplicate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[ReadDuplicate]
(
	@InvoiceNumber VARCHAR(50)		
)
AS
BEGIN

	SELECT Id	
	FROM [Invoice].Invoice WITH (NOLOCK)
	WHERE InvoiceNumber = @InvoiceNumber
			
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReportInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[ReportInsert]
(  
	@Date DateTime,	
	@CategoryId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Invoice].Report([Date],[ReportCategoryId])
	VALUES(@Date,@CategoryId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReportInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ReportInsert]
(  
	@Date DateTime,	
	@CategoryId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Customer].Report([Date],[ReportCategoryId])
	VALUES(@Date,@CategoryId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReportReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[ReportReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Date],
		[ReportCategoryId]	
	FROM [Invoice].Report WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReportReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ReportReadAll]
AS
BEGIN
	
	SELECT Id, [Date], ReportCategoryId		
	FROM Customer.Report WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReportRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[ReportRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Date],
		[ReportCategoryId]	
	FROM [Invoice].Report WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReportRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ReportRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Date], ReportCategoryId
	FROM Customer.Report WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[ImportanceUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Utility.Importance
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[ImportanceReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN
	SELECT Id	
	FROM Utility.Importance
	WHERE Name = @Name				
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[ImportanceReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Utility.Importance WITH (NOLOCK)
   
END' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[ImportanceRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Utility.Importance WITH (NOLOCK)
	WHERE Id = @Id   
	
END' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[ImportanceInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Utility.Importance([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[ImportanceDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Utility.Importance
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[Insert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[Insert]
(  
	@InvoiceNumber Varchar(50),
	@Advance Money,
	@Discount Money,
	
	@SellerName Varchar(50),
	@SellerAddress Varchar(250),
	@SellerContactNo Varchar(50),
	@SellerEmail Varchar(50),
	@SellerLicence Varchar(50),
	
	@BuyerName Varchar(50),
	@BuyerAddress Varchar(250),
	@BuyerContactNo Varchar(50),
	@BuyerEmail Varchar(50),	
	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  [Invoice].Invoice([Date],[InvoiceNumber],[Advance],[Discount],[SellerName],[SellerAddress],[SellerContactNo],[SellerEmail],[SellerLicence],[BuyerName],[BuyerAddress],[BuyerContactNo],[BuyerEmail])
	VALUES(GETDATE(),@InvoiceNumber,@Advance,@Discount,@SellerName,@SellerAddress,@SellerContactNo,@SellerEmail,@SellerLicence,@BuyerName,@BuyerAddress,@BuyerContactNo,@BuyerEmail)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[InitialUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE [Configuration].Initial
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[InitialReadDuplicate]
(
	@Name VARCHAR(50)		
)
AS
BEGIN

	SELECT Id	
	FROM Configuration.Initial WITH (NOLOCK)
	WHERE Name = @Name
					
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[InitialReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.Initial WITH (NOLOCK)
   
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[InitialRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.Initial WITH (NOLOCK)
	WHERE Id = @Id   
	
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[InitialInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Configuration].Initial([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[InitialDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Configuration].Initial
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Guardian].[LoginHistory]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[LoginHistory](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[AccountId] [numeric](10, 0) NOT NULL,
	[LoginStamp] [datetime] NULL,
	[LogoutStamp] [datetime] NULL,
 CONSTRAINT [PK_LoginLogoutHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Guardian].[LoginHistory] ON
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2108 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D003DEEF7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2109 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D003EC8BB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2110 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D003F108F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2111 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D003F4D2B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2112 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D003F9285 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2113 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D004028B1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2114 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D0042487F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2115 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D0042CFF3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2116 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37200E6E3B2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2117 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37200E72867 AS DateTime), CAST(0x0000A37200E83340 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2118 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37200ED44CD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2119 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37200EDE9B5 AS DateTime), CAST(0x0000A37200EEE9CF AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2120 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37201225784 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2121 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3720123742E AS DateTime), CAST(0x0000A37201238F2D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2122 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3720124EC9D AS DateTime), CAST(0x0000A372016D2804 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2123 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A372016D6A64 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2124 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A372016E9532 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2125 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37201803DC9 AS DateTime), CAST(0x0000A3720180C046 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2126 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3720180CB57 AS DateTime), CAST(0x0000A3720180D9F5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2127 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3770116F07A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2128 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3770128249C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2129 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37701289EC0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3770129CD3F AS DateTime), CAST(0x0000A37800A32296 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2131 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800A473B3 AS DateTime), CAST(0x0000A37800A55891 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2132 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800BF40DC AS DateTime), CAST(0x0000A37800BF4E94 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2133 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800BF6F00 AS DateTime), CAST(0x0000A37800BF8A09 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2134 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800CF6DA9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2135 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800D030B3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800D06BEB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2137 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800E772D2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2138 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800E7ABC3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2139 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800E83CC3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2140 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800E89353 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2141 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800E9A874 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2142 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800EB6F2D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2143 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800EBA906 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2144 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800EC236B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2145 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800F9B9D1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2146 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800FA293B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2147 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800FAA567 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2148 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800FB2D4D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2149 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800FBCF97 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2150 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37800FC5244 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2151 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37801081137 AS DateTime), CAST(0x0000A37801083363 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2152 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3780108A2BC AS DateTime), CAST(0x0000A3780108CF6D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2153 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A379013429B0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2154 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37901360A53 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2155 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37901370BEF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2156 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A379013AD385 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2157 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A379013DA3BA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2158 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00B15E30 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2159 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00B1CBBD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2160 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00B32524 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2161 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00B44E98 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2162 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00B4E1F6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2163 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00BFD47A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2164 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00EAE41E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2165 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00EB42AE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00ED1002 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2167 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00EF77D1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2168 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00F11D81 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2169 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A00F5CA8B AS DateTime), CAST(0x0000A37A00F6066D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2170 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A01626F3F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2171 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A01657DE6 AS DateTime), CAST(0x0000A37A01674ECE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2172 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37A01675F3C AS DateTime), CAST(0x0000A37A0169B5B6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2173 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00148D6D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2174 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B0015B43B AS DateTime), CAST(0x0000A37B00182464 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00C75531 AS DateTime), CAST(0x0000A37B00C83157 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2176 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00C83D84 AS DateTime), CAST(0x0000A37B00C88A0E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2177 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00C8C12A AS DateTime), CAST(0x0000A37B00C8E7C8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2178 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00C8F294 AS DateTime), CAST(0x0000A37B00C95CEE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2179 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00CB99BD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00CBE70C AS DateTime), CAST(0x0000A37B00CBF391 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2181 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00CC3D69 AS DateTime), CAST(0x0000A37B00CC5CBF AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2182 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00CC681C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2183 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00CE1687 AS DateTime), CAST(0x0000A37B00CEA26C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2184 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00CEACF2 AS DateTime), CAST(0x0000A37B00CEB27C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2185 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00CF44E9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2186 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00D0391A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2187 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00D0815E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2188 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00D326B4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2189 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00D370DD AS DateTime), CAST(0x0000A37B00D3B520 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2190 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00D3C488 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00D44C66 AS DateTime), CAST(0x0000A37B00D4DE37 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2192 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00D4EE51 AS DateTime), CAST(0x0000A37B00D5EAC9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2193 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00D7EDEB AS DateTime), CAST(0x0000A37B00D831CD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2194 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00E0C924 AS DateTime), CAST(0x0000A37B00E0FDC3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2195 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00E3FA54 AS DateTime), CAST(0x0000A37B00E47D8B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2196 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00EC1D4B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2197 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00ED2B33 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2198 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00ED7725 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2199 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00EDB5C9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2200 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00EF04D3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2201 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B00EF93BA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2202 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B0135C8E9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2203 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B01385D81 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2204 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B0138A72C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2205 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37B013C7DCE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2206 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A37D0121FBD8 AS DateTime), CAST(0x0000A37D0123A063 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2207 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100BDD3D9 AS DateTime), NULL)
GO
print 'Processed 100 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2208 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100C39494 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2209 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100C4AD08 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2210 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100C692E8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2211 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100C7832E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100C91C49 AS DateTime), CAST(0x0000A38100C988AA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2213 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100CA1CA0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2214 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100CCBD47 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2215 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100CCF4E6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2216 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100CD4662 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2217 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100E20FE4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2218 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100E52901 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2219 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38100E5AFD0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2220 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3810134B64A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2221 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3810135FEB2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2222 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3810136A3D9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2223 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A381013722FB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2224 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A381013822D2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2225 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3810138ED46 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2226 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A381013B12E3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2227 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A381013B3D90 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2228 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A381013BE76F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2229 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3820161A419 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2230 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3820187BA01 AS DateTime), CAST(0x0000A3820187E8D8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2231 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38201889CAB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2232 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A382018937FE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A383000219D5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2234 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3830005E9C9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2235 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38300138E7E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2236 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38300150FF2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2237 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3830015CFEE AS DateTime), CAST(0x0000A3830015E00D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2238 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38300161A4B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2239 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3830016634D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38300180435 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2241 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A383001BBF35 AS DateTime), CAST(0x0000A383001BCB24 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2242 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A383001BD495 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2243 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A383001CB831 AS DateTime), CAST(0x0000A383001CD969 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2244 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400BBA985 AS DateTime), CAST(0x0000A38400BD0C5C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2245 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400C2E81E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2246 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400C343D9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400C3A292 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2248 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400C68B72 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2249 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400C70CE8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2250 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400C76D82 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2251 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400C7F8FB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2252 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400CBF4D2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2253 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400CCFBAF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2254 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400CDAA4D AS DateTime), CAST(0x0000A38400CE2632 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2255 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400CF5B2D AS DateTime), CAST(0x0000A38400CF78AB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2256 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400EBB363 AS DateTime), CAST(0x0000A38400EBCF7A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2257 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400EF2994 AS DateTime), CAST(0x0000A38400EF6CFE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2258 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F0C06A AS DateTime), CAST(0x0000A38400F1BCC3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2259 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F0F6C1 AS DateTime), CAST(0x0000A38400F10545 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2260 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F32121 AS DateTime), CAST(0x0000A38400F3765F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F3F648 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2262 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F44CC5 AS DateTime), CAST(0x0000A38400F50535 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2263 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F597BA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2264 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F763D5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2265 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F85DCD AS DateTime), CAST(0x0000A38400F88C1D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2266 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F8BACC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2267 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400F94BF7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2268 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400FF60EB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2269 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38400FFEFCE AS DateTime), CAST(0x0000A384010004DE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2270 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3840100829F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2271 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3840100DCA5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2272 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A384010265AC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2273 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38401484493 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2274 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500099F9D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2275 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A385000FAA48 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2276 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500128911 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2277 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500A70435 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2278 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500AB44DE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500B02E5C AS DateTime), CAST(0x0000A38500B0EF88 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2280 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500B119A6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2281 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500B1F1B6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2282 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500B4A90A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2283 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500B6B1FA AS DateTime), CAST(0x0000A38500B6F258 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2284 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500F1CA9D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2285 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500F412E4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2286 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500F52F3F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2287 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500F5D912 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2288 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500F8C450 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2289 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38500FBA87C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2290 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3850113E0C2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2291 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3850114F48D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2292 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38501158461 AS DateTime), CAST(0x0000A3850115B5A9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2293 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38501164FE2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2294 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3850116E58E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2295 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38700B95984 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2296 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38700B9F850 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2297 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38700BA775E AS DateTime), CAST(0x0000A38700BA839B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2298 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38700BAD9F0 AS DateTime), CAST(0x0000A38700BB4339 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2299 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38700C9B6A6 AS DateTime), CAST(0x0000A38700C9D0F3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2300 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38700D6A697 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2301 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3870186505B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2302 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38701881E8B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2303 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A389016865AF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2304 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A389016A4D28 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2305 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A00DD9504 AS DateTime), CAST(0x0000A38A00F62987 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2306 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A00FE2C31 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2307 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A01067B29 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2308 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A0120FDAD AS DateTime), NULL)
GO
print 'Processed 200 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2309 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A012232BC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2310 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A0122678E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2311 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A012308DD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2312 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A0127D960 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2313 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A01282D4D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2314 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A012E806C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2315 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A01483BDF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2316 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A0149D5E2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2317 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A014BF815 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2318 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A01650B4E AS DateTime), CAST(0x0000A38A017173AD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2319 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A0171DE8D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2320 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A0172099E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2321 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A0172E325 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2322 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A01730B53 AS DateTime), CAST(0x0000A38A01732762 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2323 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38A01748DD5 AS DateTime), CAST(0x0000A38A0174A4C6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2324 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00D01CDC AS DateTime), CAST(0x0000A38B00D09644 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2325 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00D24568 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2326 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E3B53F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2327 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E422CF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2328 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E4DC9F AS DateTime), CAST(0x0000A38B00E523DB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2329 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E529CF AS DateTime), CAST(0x0000A38B00E64A47 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2330 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E656D7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2331 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E6AAF5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2332 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E737D6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2333 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E87B86 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2334 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00E99658 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2335 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00EA6C09 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2336 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00EB78F7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00EC9ABA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2338 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00ED4EE7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2339 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B00EE680D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2340 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B01026511 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2341 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B010A8419 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2342 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B010B73EF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2343 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A38B010C43D6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2344 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390000E7222 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2345 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390000F900B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2346 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A39000102A45 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3900013BB1F AS DateTime), CAST(0x0000A3900013DBA3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2348 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A39000154B0B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2349 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3900019F6CB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2350 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390001AD783 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2351 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390001D2227 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2352 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A39000CACB38 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2353 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A39000E95E5A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2354 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A39000EA37FE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2355 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390010BA41E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2356 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390010D946A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2357 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390010E252F AS DateTime), CAST(0x0000A3900112443F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2358 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3900129F658 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2359 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390012A98B8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2360 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A390012CEF61 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2361 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A39100E62A99 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2362 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3A300C95BC9 AS DateTime), CAST(0x0000A3A300C98046 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2363 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3A300C992EA AS DateTime), CAST(0x0000A3A300C9C73F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2364 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3A300CC2040 AS DateTime), CAST(0x0000A3A300CC4CC8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2365 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3A300CD1DEF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2366 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3A301071AE2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2367 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3A30107511F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2368 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3A30107EF3C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2369 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00BCFDCC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2370 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00BD95D2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2371 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00BE0AA0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2372 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00BE7716 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2373 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00BEC94D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2374 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00BFBEBF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2375 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C05B21 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2376 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C0FBB5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2377 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C1450F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2378 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C238A5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2379 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C2593E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2380 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C2EF89 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2381 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C3FAFA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2382 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C49B36 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2383 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C51A95 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2384 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C6BAF9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2385 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3AA00C79F38 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2386 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B3014CE783 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2387 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B3014F52F1 AS DateTime), CAST(0x0000A3B3014F5870 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2388 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B3014F7658 AS DateTime), CAST(0x0000A3B3014F8883 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2389 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B3014F8E12 AS DateTime), CAST(0x0000A3B30150F2A3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2390 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B30150F92A AS DateTime), CAST(0x0000A3B301544C84 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2391 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B301545797 AS DateTime), CAST(0x0000A3B30154D538 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2392 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B30154DA67 AS DateTime), CAST(0x0000A3B301550417 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2393 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B301550829 AS DateTime), CAST(0x0000A3B3015547AD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2394 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B301555104 AS DateTime), CAST(0x0000A3B301712ECB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2395 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3B5009C2540 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2396 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3DC00F9CCDB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2397 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3DC00FD6E61 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2398 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3DC00FDFE32 AS DateTime), CAST(0x0000A3DC00FE1E2C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2399 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100DCBBFF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2400 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100DFB1EF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2401 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100E335D8 AS DateTime), CAST(0x0000A3E100E3FF5A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2402 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100E456A7 AS DateTime), CAST(0x0000A3E100E498D5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2403 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100E50E60 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2404 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100EC2088 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2405 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100ED8DFD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2406 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100F006C8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2407 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100F68A44 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2408 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100F71889 AS DateTime), CAST(0x0000A3E100F74273 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2409 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100F7B027 AS DateTime), CAST(0x0000A3E100F7EF3C AS DateTime))
GO
print 'Processed 300 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2410 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100F889D9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2411 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100FC6683 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2412 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100FCDACB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2413 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E100FE89A5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2414 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E101009E2A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2415 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1010336F1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2416 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E10103F710 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2417 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E10104552A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2418 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E101052E37 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2419 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E101083E89 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2420 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E10108DC99 AS DateTime), CAST(0x0000A3E1010917E6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2421 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E101093E16 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2422 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E10109F312 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2423 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1010A3152 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2424 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1010AC8D8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2425 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1010BA20B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2426 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1010C2974 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2427 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1010CBBDF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2428 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1010DA8E5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2429 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1010FE3C6 AS DateTime), CAST(0x0000A3E1010FFE18 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2430 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E101102144 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2431 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1011097BA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2432 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E101111448 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2433 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1011A9B85 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2434 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1011AF140 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2435 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1011B8DE9 AS DateTime), CAST(0x0000A3E1011BFAC4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2436 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E1011FC472 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2437 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E10120E797 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2438 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200AC6E8A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2439 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200AE7C76 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2440 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200AFA313 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2441 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200B1EF49 AS DateTime), CAST(0x0000A3E200B20C95 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2442 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200B2CACD AS DateTime), CAST(0x0000A3E200B37173 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2443 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200B38E58 AS DateTime), CAST(0x0000A3E200B3A5D3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2444 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200B3D741 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2445 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200B672A2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2446 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200B7E0D5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2447 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200BAA79E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2448 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200BAD349 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2449 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200BB6AF9 AS DateTime), CAST(0x0000A3E200BE96DC AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2450 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200BEDCEE AS DateTime), CAST(0x0000A3E200D4D357 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2451 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200D58393 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2452 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200D61499 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2453 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200D8A669 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2454 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200DAEB65 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2455 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200DB6C1D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2456 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200DD8977 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2457 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200DE396F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2458 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200DFD3D5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2459 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200E03070 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2460 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200E0EAE6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2461 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200E2F8C8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2462 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200E4C3C8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2463 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200E6A13B AS DateTime), CAST(0x0000A3E200E7C894 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2464 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200E89558 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2465 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200EB0A35 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2466 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200EBEC0C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2467 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200ED0473 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2468 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200EE03AC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2469 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200F86D11 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2470 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200FB5747 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2471 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E200FD1E3D AS DateTime), CAST(0x0000A3E200FDE29D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2472 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E2010837B1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2473 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E20108B28A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2474 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E20109125A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2475 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E20109B07C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2476 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E2010E2EE4 AS DateTime), CAST(0x0000A3E2010E761C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2477 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E20111B048 AS DateTime), CAST(0x0000A3E20111F72C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2478 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E2011598C6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2479 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E20120486E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2480 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E20120BB0D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2481 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E300F7E5F5 AS DateTime), CAST(0x0000A3E300F8888C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2482 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E301094A7C AS DateTime), CAST(0x0000A3E3010B8AB2 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2483 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E3010D186C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2484 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E30110E8C0 AS DateTime), CAST(0x0000A3E301111473 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2485 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E30113335D AS DateTime), CAST(0x0000A3E30113391C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2486 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E301171CBB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2487 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E30117E1A6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2488 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E30119F17E AS DateTime), CAST(0x0000A3E3011A357C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2489 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E600E11453 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2490 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E600E1C167 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2491 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E600E2C4E8 AS DateTime), CAST(0x0000A3E600ED6ABC AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2492 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700B93A1B AS DateTime), CAST(0x0000A3E700B960F6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2493 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700BAD20A AS DateTime), CAST(0x0000A3E700BBC9D7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2494 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700BBFD58 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2495 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700BF2D08 AS DateTime), CAST(0x0000A3E700BF535C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2496 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700BF862C AS DateTime), CAST(0x0000A3E700BFE60A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2497 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700C33499 AS DateTime), CAST(0x0000A3E700C38CB3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2498 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700C3B034 AS DateTime), CAST(0x0000A3E700C3DD1A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2499 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700C56608 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2500 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700C5EC32 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2501 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700C7CC07 AS DateTime), CAST(0x0000A3E700C801AF AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2502 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700C87369 AS DateTime), CAST(0x0000A3E700C8FB09 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2503 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700C94B6C AS DateTime), CAST(0x0000A3E700C9663F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2504 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700C97F51 AS DateTime), CAST(0x0000A3E700C9A4CB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2505 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700D215ED AS DateTime), CAST(0x0000A3E700D279E3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2506 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700D3C0BB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2507 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700D539DF AS DateTime), CAST(0x0000A3E700D70F1F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2508 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700D8C675 AS DateTime), CAST(0x0000A3E700D94909 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2509 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700D9A399 AS DateTime), CAST(0x0000A3E700D9F806 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2510 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700DAEF26 AS DateTime), CAST(0x0000A3E700DB29DC AS DateTime))
GO
print 'Processed 400 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2511 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700E3BAD2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2512 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700E7A916 AS DateTime), CAST(0x0000A3E700E7C76C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2513 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700E7EBE1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2514 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700E9B675 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2515 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700ED25A1 AS DateTime), CAST(0x0000A3E700ED6AFD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2516 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700FAE24F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2517 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700FBC8B0 AS DateTime), CAST(0x0000A3E700FBEB5E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2518 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700FC1864 AS DateTime), CAST(0x0000A3E700FC4247 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2519 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700FCE761 AS DateTime), CAST(0x0000A3E700FD04DA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2520 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700FDA99F AS DateTime), CAST(0x0000A3E700FDC8F8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2521 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700FF0CD6 AS DateTime), CAST(0x0000A3E700FF2B04 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2522 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E700FF608A AS DateTime), CAST(0x0000A3E700FFAEB5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2523 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E701019D42 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2524 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E701027064 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2525 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E70102EE97 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2526 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E70103EB51 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2527 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E70104386A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2528 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E701049117 AS DateTime), CAST(0x0000A3E70104B5CA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2529 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E701061D66 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2530 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E70106958E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2531 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E701079A44 AS DateTime), CAST(0x0000A3E70107E05F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2532 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E701084774 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2533 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E70108EF9A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2534 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E701099824 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2535 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7010DBFA0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2536 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7010E290E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2537 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7010EEEC7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2538 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7010F5665 AS DateTime), CAST(0x0000A3E7010F72D7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2539 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7010FBE1A AS DateTime), CAST(0x0000A3E7010FE3F5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2540 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E701123FAF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2541 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7011619E4 AS DateTime), CAST(0x0000A3E701163863 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2542 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E70116D632 AS DateTime), CAST(0x0000A3E70116F2DD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2543 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7011DDE34 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2544 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7011E5762 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2545 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7011E9584 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2546 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E7011F74B8 AS DateTime), CAST(0x0000A3E7011F95C2 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2547 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900A5EA83 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2548 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900A64664 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2549 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900B3EA71 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2550 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900B49E43 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2551 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900BDA328 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2552 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900BE5A1D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2553 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900BEAB22 AS DateTime), CAST(0x0000A3E900BF25B6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2554 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900BFF86D AS DateTime), CAST(0x0000A3E900C0389F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2555 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900C47E03 AS DateTime), CAST(0x0000A3E900C4FDA7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2556 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900C6F0D4 AS DateTime), CAST(0x0000A3E900C76C3A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2557 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900E24D84 AS DateTime), CAST(0x0000A3E900E26EA3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2558 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3E900E66162 AS DateTime), CAST(0x0000A3E900E68566 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2559 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EA00BB4D1A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2560 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EA00BBCE62 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2561 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EA00BC3267 AS DateTime), CAST(0x0000A3EA00BC6502 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2562 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00E3B0C5 AS DateTime), CAST(0x0000A3ED00E3DC45 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2563 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00E692C8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2564 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00E835BA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2565 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00E93636 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2566 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00E98858 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2567 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00EDEA31 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2568 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00EF6139 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2569 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00F0A02F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2570 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00F59DB7 AS DateTime), CAST(0x0000A3ED00F5FF30 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2571 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00F6597B AS DateTime), CAST(0x0000A3ED00F6850A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2572 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00F72DE4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2573 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00F7F57E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2574 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED00FD1C3F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2575 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED01002376 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2576 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED0100D771 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2577 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED0101727D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2578 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED0102033E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2579 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED01030B69 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2580 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED0103A085 AS DateTime), CAST(0x0000A3ED0103C39D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2581 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED0108B667 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2582 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED01097A6A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2583 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED0109EFC7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2584 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED010F4A5D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2585 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED01108147 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2586 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED011239E6 AS DateTime), CAST(0x0000A3ED01125954 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2587 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED011931F7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2588 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED01199B02 AS DateTime), CAST(0x0000A3ED0119DFC5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2589 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED011BCFD9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2590 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED011CBB83 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2591 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED011D478E AS DateTime), CAST(0x0000A3ED011D66A7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2592 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED011F0576 AS DateTime), CAST(0x0000A3ED011F1A30 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2593 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED011F9628 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2594 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED012153C1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2595 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3ED0122E7AF AS DateTime), CAST(0x0000A3ED01230C6C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2596 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00ADBD49 AS DateTime), CAST(0x0000A3EE00B42860 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2597 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00B49531 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2598 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00B5E76B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2599 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D008CF AS DateTime), CAST(0x0000A3EE00D02E3F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2600 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D04BE5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2601 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D096FB AS DateTime), CAST(0x0000A3EE00D09BA4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2602 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D0BEE6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2603 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D15574 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2604 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D18C29 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2605 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D23FF5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2606 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D3481E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2607 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D3908B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2608 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D41AE9 AS DateTime), CAST(0x0000A3EE00D433B1 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2609 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D4FC1A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2610 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D63239 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2611 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D84BD2 AS DateTime), CAST(0x0000A3EE00D8A042 AS DateTime))
GO
print 'Processed 500 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2612 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D8BA6B AS DateTime), CAST(0x0000A3EE00D8EDB2 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2613 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D9028E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2614 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D937AD AS DateTime), CAST(0x0000A3EE00D94351 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2615 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00D9C074 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2616 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00DC6D79 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2617 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00DD2FA4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2618 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00DFD7BB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2619 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00F3E1A4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2620 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00F6F232 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2621 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00F8ECA2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2622 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00F98B7D AS DateTime), CAST(0x0000A3EE00F9E4AF AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2623 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00FA32C6 AS DateTime), CAST(0x0000A3EE00FAA059 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2624 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00FC3A71 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2625 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EE00FF457D AS DateTime), CAST(0x0000A3EE00FFC5E4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2626 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00A5F5D6 AS DateTime), CAST(0x0000A3EF00A61091 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2627 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00BB598D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2628 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00BDD766 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2629 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00BF8F30 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2630 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00C4B7DB AS DateTime), CAST(0x0000A3EF00C4D5F1 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2631 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00C4FC26 AS DateTime), CAST(0x0000A3EF00C50D76 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2632 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00C569DB AS DateTime), CAST(0x0000A3EF00C5957E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2633 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00C95571 AS DateTime), CAST(0x0000A3EF00C9B80B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2634 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00D1FE00 AS DateTime), CAST(0x0000A3EF00D229FB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2635 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00D25B14 AS DateTime), CAST(0x0000A3EF00D2B952 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2636 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00D84CED AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2637 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00E2152E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2638 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00E48090 AS DateTime), CAST(0x0000A3EF00E4E53E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2639 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00E52B1F AS DateTime), CAST(0x0000A3EF00E54749 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2640 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00E82C1B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2641 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00E9DB53 AS DateTime), CAST(0x0000A3EF00E9F071 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2642 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00EAE6F2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2643 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00EC5E01 AS DateTime), CAST(0x0000A3EF00EC8164 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2644 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00ED3066 AS DateTime), CAST(0x0000A3EF00EE0D14 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2645 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00EFA11C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2646 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00F18AF5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2647 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00F26283 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2648 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00F33537 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2649 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00F4FA06 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2650 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00F6719E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2651 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00F7B9D1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2652 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00F90FAB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2653 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00FB5F59 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2654 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00FC0947 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2655 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00FC98A5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2656 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF00FD2A29 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2657 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF01008168 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2658 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF01025C62 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2659 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF0102946C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2660 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF0102D8F4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2661 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF01084069 AS DateTime), CAST(0x0000A3EF01089606 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2662 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF0108A5BA AS DateTime), CAST(0x0000A3EF01094B42 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2663 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF010A14BA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2664 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF010A9C7B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2665 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF010C4227 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2666 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF010CC144 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2667 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF010D7F98 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2668 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF010EFBD5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2669 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF0111A809 AS DateTime), CAST(0x0000A3EF01125147 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2670 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF0112F8C9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2671 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF011508F5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2672 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF0115A005 AS DateTime), CAST(0x0000A3EF01163328 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2673 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF0117176F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2674 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF011834CE AS DateTime), CAST(0x0000A3EF0118499C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2675 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF0118B167 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2676 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF011AD69C AS DateTime), CAST(0x0000A3EF011AF8ED AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2677 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF011CB210 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2678 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF011F7218 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2679 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF01215A26 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2680 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3EF01224DB7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2681 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100F01B9D AS DateTime), CAST(0x0000A3F100F21496 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2682 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100F23970 AS DateTime), CAST(0x0000A3F100F262B3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2683 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100F85A92 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2684 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100F95F8E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2685 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100F9C5A0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100FA870C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2687 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100FBB338 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2688 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100FC3BE2 AS DateTime), CAST(0x0000A3F100FC5F6A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2689 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100FCB931 AS DateTime), CAST(0x0000A3F100FCDAFD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2690 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F100FD4CF5 AS DateTime), CAST(0x0000A3F100FD68DD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2691 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10101C3FC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2692 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101022CD7 AS DateTime), CAST(0x0000A3F101023C67 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2693 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1010285DB AS DateTime), CAST(0x0000A3F101029B40 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2694 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10102BC26 AS DateTime), CAST(0x0000A3F10102D169 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2695 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1010301B2 AS DateTime), CAST(0x0000A3F101031691 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2696 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101038C97 AS DateTime), CAST(0x0000A3F10103A5DE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2697 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1010414C8 AS DateTime), CAST(0x0000A3F10104313F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101058BFA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2699 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10106620B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2700 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10106B8BA AS DateTime), CAST(0x0000A3F10106CFFE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10107B910 AS DateTime), CAST(0x0000A3F10107D29D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2702 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101084E8A AS DateTime), CAST(0x0000A3F101086DF6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2703 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10108A8DC AS DateTime), CAST(0x0000A3F10108DCA3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2704 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10109013C AS DateTime), CAST(0x0000A3F101092AC6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2705 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10109CAC4 AS DateTime), CAST(0x0000A3F10109FC8A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2706 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1010AC614 AS DateTime), CAST(0x0000A3F1010AFBE9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2707 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1010E6A07 AS DateTime), CAST(0x0000A3F1010E7B10 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2708 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1010EBDA2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2709 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101116CA8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2710 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101121EBE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2711 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1011252DE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2712 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101129C92 AS DateTime), NULL)
GO
print 'Processed 600 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2713 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101131EBC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2714 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101162D77 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2715 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10116D43B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2716 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F101186C9B AS DateTime), CAST(0x0000A3F101197E58 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2717 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F10119C758 AS DateTime), CAST(0x0000A3F10119E622 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2718 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1011A1C7C AS DateTime), CAST(0x0000A3F1011A2AC6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2719 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1011A7458 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2720 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1011ABD43 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2721 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1011C4B41 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2722 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1011DD3B0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2723 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1011E0812 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2724 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F1011E8785 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2725 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F400D90FD2 AS DateTime), CAST(0x0000A3F400D97A29 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2726 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F400D9F2D6 AS DateTime), CAST(0x0000A3F400DA832F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2727 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F400DAF104 AS DateTime), CAST(0x0000A3F400DBBEDE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2728 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F400DBD68F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2729 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F900C0B58A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2730 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F900C188DD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2731 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F900C1E45E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2732 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3F900C5EDBC AS DateTime), CAST(0x0000A3F900C66546 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2733 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FB01100A98 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2734 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FB01113637 AS DateTime), CAST(0x0000A3FB011187B9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2735 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FB0111AFBA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2736 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FB011294FD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2737 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FB01188C17 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2738 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FB011902B0 AS DateTime), CAST(0x0000A3FB011AFFF2 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2739 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FB011B2515 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2740 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00A61DB3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2741 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00A6A241 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2742 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00A6FBCF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2743 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00A73B25 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2744 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00B2614E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2745 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00B2F5CE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2746 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00B32247 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2747 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00B8A2AD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2748 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00B8F317 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2749 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00BFDB67 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2750 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00C0A4A6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2751 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00C124DA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2752 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00C19EE4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2753 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00C2E033 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2754 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00C478E6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2755 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00C57843 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2756 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00CEEDA5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2757 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00D87087 AS DateTime), CAST(0x0000A3FC00D89895 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2758 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00D8A099 AS DateTime), CAST(0x0000A3FC00D8C05D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2759 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC00D8C777 AS DateTime), CAST(0x0000A3FC00EFA505 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2760 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC0101EE38 AS DateTime), CAST(0x0000A3FC01024DB2 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2761 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FC0106A8FA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2762 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE00F5253C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2763 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE00F76A6D AS DateTime), CAST(0x0000A3FE01027C10 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2764 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE010291C1 AS DateTime), CAST(0x0000A3FE0103DEC8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2765 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0103E685 AS DateTime), CAST(0x0000A3FE0104DF5B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2766 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0107D6B7 AS DateTime), CAST(0x0000A3FE010C3F4D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2767 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE010D1255 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2768 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01180194 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2769 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0142C000 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2770 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0149872A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2771 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FF0096AC3B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2772 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FF0097B61B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2773 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FF0097E2D3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2774 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FF00985995 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2775 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FF009CED62 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2776 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A403009C858A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2777 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300A5748C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2778 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300ACD1E6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2779 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300AED5CD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2780 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300AFCDFA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2781 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300B0272F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2782 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300B2DA36 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2783 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300D94DFE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2784 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300D9A576 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2785 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300DCC719 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2786 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300E1591F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2787 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300E3B795 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2788 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300EC6DC1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2789 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300F3D813 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2790 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A403010ABA01 AS DateTime), CAST(0x0000A403010BF92F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2791 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4030112A8F7 AS DateTime), CAST(0x0000A4030112BFE1 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2792 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400943200 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2793 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400BC9838 AS DateTime), CAST(0x0000A40400BD206E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2794 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500B2FCA4 AS DateTime), CAST(0x0000A40500BB87E1 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2795 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500BBC4BB AS DateTime), CAST(0x0000A40500BC5A2D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2796 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500C32F0C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2797 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500C3AF52 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2798 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500C5A10B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2799 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500CA67A9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2800 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500CD0004 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2801 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500D0396B AS DateTime), CAST(0x0000A40500DB3416 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2802 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500DBC3D7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2803 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500DCFAA6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2804 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4050103C938 AS DateTime), CAST(0x0000A4050104DD14 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2805 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A405010B693D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2806 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A405010D5C36 AS DateTime), CAST(0x0000A405010FB94E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2807 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4060099EA90 AS DateTime), CAST(0x0000A406009A06E8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2808 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600A10076 AS DateTime), CAST(0x0000A40600A12591 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2809 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600A155A3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2810 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600A1B952 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2811 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600A487EA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2812 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600A57045 AS DateTime), CAST(0x0000A40600A59085 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2813 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600A5AD19 AS DateTime), CAST(0x0000A40600A5F856 AS DateTime))
GO
print 'Processed 700 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2814 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600A69B78 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2815 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600B07509 AS DateTime), CAST(0x0000A40600B0B0B4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2816 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600F3A4E4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2817 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600F53F7B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2818 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600F878F3 AS DateTime), CAST(0x0000A40600F95BB4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2819 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600FB49FD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2820 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40600FD64B2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2821 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A406010153EF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2822 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4060102C861 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2823 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4060103DBE4 AS DateTime), CAST(0x0000A40601043DF7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2824 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4060109CFC0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2825 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4060113866C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2826 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40601148619 AS DateTime), CAST(0x0000A406011635C5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2827 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40601185DA7 AS DateTime), CAST(0x0000A40601191DCB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2828 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A406011941CA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2829 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D0098E4E5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2830 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D0099D153 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2831 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00A049D6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2832 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00A0CCAE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2833 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00A27573 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2834 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00A5F434 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2835 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00A76749 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2836 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00A972E5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2837 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00AD639A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2838 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00AEC8D4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2839 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00AF7D70 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2840 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00B20BAD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2841 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00BB237B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2842 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00BC5858 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2843 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00BCCD93 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2844 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00D1984F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2845 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00D402A7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2846 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00D449F5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2847 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00D75C67 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2848 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00DA7E40 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2849 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00DB03E7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2850 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00DBEB03 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2851 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00F152F9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2852 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00F3BBEB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2853 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00F63E19 AS DateTime), CAST(0x0000A40D00FA3523 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2854 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00FA8CBA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2855 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00FB9D8A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2856 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00FF2C08 AS DateTime), CAST(0x0000A40D010013FD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2857 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D010063CE AS DateTime), CAST(0x0000A40D0100BED9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2858 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D0103293C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2859 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D0103DB03 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2860 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D0108518C AS DateTime), CAST(0x0000A40D010A0236 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2861 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D010A18B7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2862 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D010ACEB9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2863 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D010D74CD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2864 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D010F93BF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2865 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D0111322C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2866 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D0115908F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2867 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D0116EA85 AS DateTime), CAST(0x0000A40D0117D2EA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2868 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000994A36 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2869 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A410009C6B21 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2870 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000A0AF3C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2871 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000A3CB1A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2872 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000AE3044 AS DateTime), CAST(0x0000A41000AE7025 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2873 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000B43FEB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2874 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000B4B07E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2875 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000B51B75 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2876 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000B8F737 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2877 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000D35372 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2878 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000D3EF40 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2879 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000D4B8E4 AS DateTime), CAST(0x0000A41000D4F3C5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2880 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000D569D1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2881 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000D6ACA4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2882 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000D7548E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2883 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000DBE41B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2884 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000DD52D2 AS DateTime), CAST(0x0000A41000DD83B5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2885 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000DDBF6A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2886 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000E90FA7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2887 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000EA3E32 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2888 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000EB571F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2889 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000EC0436 AS DateTime), CAST(0x0000A41000EC6BB3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2890 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000F4EDEF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2891 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000F57927 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2892 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000F8F8D4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2893 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000FB6E5F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2894 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000FBD53F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2895 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000FC4ACF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2896 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000FCAB66 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2897 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000FE4F85 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2898 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000FFFAD4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2899 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A410010182A2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2900 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A410010A8DDD AS DateTime), CAST(0x0000A410010BE293 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2901 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4100111ED05 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2902 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41001172E4D AS DateTime), CAST(0x0000A410011800B9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2903 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41001189776 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2904 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4100119FCE8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2905 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A410011A6A8E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2906 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A410011BA9D7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2907 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A410011D87C9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2908 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A410011DF904 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2909 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41100BB9E0B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2910 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41100CF764A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2911 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41100D166BE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2912 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41100D3BF4B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2913 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41100F59E4C AS DateTime), CAST(0x0000A41100F5D718 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2914 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41100F64E9D AS DateTime), CAST(0x0000A41100F6C3C3 AS DateTime))
GO
print 'Processed 800 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2915 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41100F84C48 AS DateTime), CAST(0x0000A41100F94878 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2916 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4110116DCCD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2917 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4110118E5E3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2918 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41101194CDA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2919 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41200BA3518 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2920 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41200BC3593 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2921 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41200FC4DF8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2922 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A412011BE550 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2923 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A412011CBE32 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2924 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A412011D9021 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2925 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A412011EA759 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2926 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A412011F4748 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2927 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4130097449E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2928 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A413009C7150 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2929 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A413009DB192 AS DateTime), CAST(0x0000A413009DFD32 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2930 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A413009E76F8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(2931 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41300A494FA AS DateTime), NULL)
SET IDENTITY_INSERT [Guardian].[LoginHistory] OFF
/****** Object:  Table [Invoice].[LineItem]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[LineItem](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[InvoiceId] [numeric](10, 0) NOT NULL,
	[Start] [datetime] NULL,
	[End] [datetime] NULL,
	[Description] [varchar](250) NOT NULL,
	[UnitRate] [money] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_LineItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[IsStateIdDeletable]
(
	@StateId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  Name
	FROM [Organization].Organization
	WHERE StateId = @StateId

 END
' 
END
GO
/****** Object:  Table [Invoice].[Payment]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Payment]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[Payment](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[InvoiceId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Invoice].[Payment] ON
INSERT [Invoice].[Payment] ([Id], [Date], [InvoiceId]) VALUES (CAST(75 AS Numeric(10, 0)), CAST(0x0000A3FE010A3059 AS DateTime), NULL)
INSERT [Invoice].[Payment] ([Id], [Date], [InvoiceId]) VALUES (CAST(76 AS Numeric(10, 0)), CAST(0x0000A40400966FCF AS DateTime), NULL)
INSERT [Invoice].[Payment] ([Id], [Date], [InvoiceId]) VALUES (CAST(77 AS Numeric(10, 0)), CAST(0x0000A4040098410B AS DateTime), NULL)
INSERT [Invoice].[Payment] ([Id], [Date], [InvoiceId]) VALUES (CAST(78 AS Numeric(10, 0)), CAST(0x0000A404009DF10F AS DateTime), NULL)
INSERT [Invoice].[Payment] ([Id], [Date], [InvoiceId]) VALUES (CAST(79 AS Numeric(10, 0)), CAST(0x0000A40500B67838 AS DateTime), NULL)
INSERT [Invoice].[Payment] ([Id], [Date], [InvoiceId]) VALUES (CAST(80 AS Numeric(10, 0)), CAST(0x0000A40500DA63B1 AS DateTime), NULL)
SET IDENTITY_INSERT [Invoice].[Payment] OFF
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[OrganizationUpdate]
(
@Id Numeric(10,0),
@Name Varchar(50),
@Logo Varbinary(max) = null,
@LicenceNumber Varchar(50) = null,
@Tan Varchar(50) = null,
@ServiceTaxNumber Varchar(50) = null,
@LuxuaryTaxNumber Varchar(50) = null,
@Address Varchar(255) = null,
@City Varchar(50) = null,
@StateId Numeric(10,0) = null,
@Pin Int = null,
@ContactName Varchar(50) = null
)
AS
BEGIN

UPDATE [Organization].Organization
SET
[Name] = @Name,
[Logo] = @Logo,
[LicenceNumber] = @LicenceNumber,
[Tan] = @Tan,
[ServiceTaxNumber] = @ServiceTaxNumber,
[LuxuaryTaxNumber] = @LuxuaryTaxNumber,
[Address] = @Address,
[City] = @City,
[StateId] = @StateId,
[Pin] = @Pin,
[ContactName] = @ContactName
WHERE Id = @Id

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationUpdate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[OrganizationUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50),
	@Logo Varbinary(max) = null,
	@LicenceNumber Varchar(50) = null,
	@Tan Varchar(50) = null,
	@Address Varchar(255) = null,
	@City Varchar(50) = null,
	@StateId Numeric(10,0) = null,
	@Pin Int = null,
	@ContactName Varchar(50) = null
)
AS
BEGIN
	
	UPDATE Organization.Organization
	SET	
		[Name] = @Name,	
		[Logo] = @Logo,
		[LicenceNumber] = @LicenceNumber,
		[Tan] = @Tan,
		[Address] = @Address,
		[City] = @City,
		[StateId] = @StateId,
		[Pin] = @Pin,
		[ContactName] = @ContactName
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[OrganizationRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN

	SELECT Top 1
		Id,
		[Name],
		[Logo],
		[LicenceNumber],
		[Tan],
		[ServiceTaxNumber],
		[LuxuaryTaxNumber],
		[Address],
		[City],
		[StateId],
		[Pin],
		[ContactName]
	FROM [Organization].[Organization] WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--CREATE TABLE [dbo].[Organization](
--	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
--	[Name] [varchar](50) NOT NULL,
--	[Logo] [varbinary](max) NULL,
--	[LicenceNumber] [varchar](50) NULL,
--	[Tan] [varchar](50) NULL,
--	[Address] [varchar](255) NULL,
--	[City] [varchar](50) NULL,
--	[StateId] [numeric](10, 0) NULL,
--	[Pin] [int] NULL,
--	[ContactName] [varchar](50) NULL,
-- )

CREATE PROCEDURE [dbo].[OrganizationRead] 
(
	@Id Numeric(10,0) = null
)
AS
BEGIN
	
	if(ISNULL(@Id,0) = 0)
		BEGIN
			SELECT TOP 1 Id, Name, Logo, LicenceNumber, Tan, Address,
				City, StateId, Pin, ContactName
			FROM Organization.Organization WITH (NOLOCK)
		END
	Else
		BEGIN	
			SELECT TOP 1 Id, Name, Logo, LicenceNumber, Tan, Address,
				City, StateId, Pin, ContactName
			FROM Organization.Organization WITH (NOLOCK)
			WHERE Id = @Id   
		END
	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[OrganizationInsert]
(
@Name Varchar(50),
@Logo Varbinary(max) = null,
@LicenceNumber Varchar(50) = null,
@Tan Varchar(50) = null,
@ServiceTaxNumber Varchar(50) = null,
@LuxuaryTaxNumber Varchar(50) = null,
@Address Varchar(255) = null,
@City Varchar(50) = null,
@StateId Numeric(10,0) = null,
@Pin Int = null,
@ContactName Varchar(50) = null,
@Id Numeric(10,0) OUTPUT
)
AS
BEGIN

Declare @Cnt Int
Select @Cnt = COUNT(*) From [Organization].Organization

if(@Cnt > 0)
Begin
UPDATE [Organization].Organization
SET
[Name] = @Name,
[Logo] = @Logo,
[LicenceNumber] = @LicenceNumber,
[Tan] = @Tan,
[ServiceTaxNumber] = @ServiceTaxNumber,
[LuxuaryTaxNumber] = @LuxuaryTaxNumber,
[Address] = @Address,
[City] = @City,
[StateId] = @StateId,
[Pin] = @Pin,
[ContactName] = @ContactName
End
Else
Begin
INSERT INTO [Organization].Organization([Name],[Logo],[LicenceNumber],[Tan],[ServiceTaxNumber],[LuxuaryTaxNumber],[Address],[City],[StateId],[Pin],[ContactName])
VALUES(@Name,@Logo,@LicenceNumber,@Tan,@ServiceTaxNumber,@LuxuaryTaxNumber,@Address,@City,@StateId,@Pin,@ContactName)

End

SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[OrganizationInsert]
(  
	@Name Varchar(50),
	@Logo Varbinary(max) = null,
	@LicenceNumber Varchar(50) = null,
	@Tan Varchar(50) = null,
	@Address Varchar(255) = null,
	@City Varchar(50) = null,
	@StateId Numeric(10,0) = null,
	@Pin Int = null,
	@ContactName Varchar(50) = null,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Organization.Organization([Name],[Logo],[LicenceNumber],[Tan],[Address],[City],[StateId],[Pin],[ContactName])
	VALUES(@Name,@Logo,@LicenceNumber,@Tan,@Address,@City,@StateId,@Pin,@ContactName)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ModuleUpdate]
(
	@Id  Numeric(10,0),
	@Code Varchar(50),
	@Name Varchar(50),
	@Description Varchar(50),
	@IsMandatory Bit
)
As
Begin
	UPDATE License.Module
	SET Code = @Code,
		Name = @Name,
		[Description] = @Description,
		IsMandatory = @IsMandatory
	WHERE Id = @Id
End
' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ModuleReadAll]
As
BEGIN

	SELECT Id, Code, Name, [Description], IsMandatory
	FROM License.Module WITH (NOLOCK)
	
END' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ModuleRead]
(
	@Id  Numeric(10,0)
)
As
BEGIN

	SELECT Id, Code, Name, [Description], IsMandatory
	FROM License.Module WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ModuleInsert]
(
	@Name Varchar(50),
	@Code Varchar(50),
	@Description Varchar(50),
	@IsMandatory Bit,
	@Id  Numeric(10,0) OUTPUT
)
As
Begin
	INSERT INTO License.Module(Code, Name, [Description], IsMandatory)
	VALUES(@Code, @Name, @Description, @IsMandatory)
	
	SET @Id = @@IDENTITY
End
' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ModuleDelete]
(
	@Id  Numeric(10,0)
)
As
Begin
	DELETE FROM License.Module
	WHERE Id = @Id
End
' 
END
GO
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 01/01/2015 10:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[OrganizationDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].Organization
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Invoice].[InvoiceTaxation]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[InvoiceTaxation](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[TaxName] [varchar](50) NULL,
	[TaxAmount] [money] NULL,
	[IsPercentage] [bit] NULL,
	[InvoiceId] [numeric](10, 0) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusUpdate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingStatusUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].BuildingStatus
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingStatusReadAll]
As
BEGIN

	SELECT Id,Name
	FROM Lodge.BuildingStatus WITH (NOLOCK)
	
End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Lodge].BuildingStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingStatusInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingStatus([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingStatusDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingStatus
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeUpdate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingTypeUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].BuildingType
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingTypeReadAll]
As
BEGIN

	SELECT Id,Name
	FROM Lodge.BuildingType WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Lodge].BuildingType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingTypeInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingType([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingTypeDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingType
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  Table [Lodge].[Building]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[Building]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[Building](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[Building] ON
INSERT [Lodge].[Building] ([Id], [Name], [TypeId], [StatusId], [OrganizationId]) VALUES (CAST(16 AS Numeric(10, 0)), N'Vijaya Nilaya', CAST(2 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[Building] ([Id], [Name], [TypeId], [StatusId], [OrganizationId]) VALUES (CAST(22 AS Numeric(10, 0)), N'RMZ Centinial', CAST(4 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[Building] ([Id], [Name], [TypeId], [StatusId], [OrganizationId]) VALUES (CAST(23 AS Numeric(10, 0)), N'Barsha', CAST(19 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
SET IDENTITY_INSERT [Lodge].[Building] OFF
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Utility.AppointmentType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Utility].[AppointmentTypeReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN
	SELECT Id	
	FROM Utility.AppointmentType
	WHERE Name = @Name				
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentTypeReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Utility.AppointmentType WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Utility.AppointmentType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Utility].[AppointmentTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Utility.AppointmentType([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Utility].[AppointmentTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Utility.AppointmentType
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Utility].[Appointment]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[Appointment]') AND type in (N'U'))
BEGIN
CREATE TABLE [Utility].[Appointment](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ActorId] [numeric](10, 0) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[ImportanceId] [numeric](10, 0) NULL,
	[Reminder] [datetime] NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Utility].[Appointment] ON
INSERT [Utility].[Appointment] ([Id], [ActorId], [Title], [TypeId], [Start], [End], [Location], [Description], [ImportanceId], [Reminder]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Client Meeting', CAST(2 AS Numeric(10, 0)), CAST(0x0000A31E00E297D0 AS DateTime), CAST(0x0000A31E00EAD530 AS DateTime), N'Bangalore', N'New pospect. Need to visit at Marathahalli', CAST(2 AS Numeric(10, 0)), CAST(0x0000A31E00D63BC0 AS DateTime))
INSERT [Utility].[Appointment] ([Id], [ActorId], [Title], [TypeId], [Start], [End], [Location], [Description], [ImportanceId], [Reminder]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Teem meeting', CAST(1 AS Numeric(10, 0)), CAST(0x0000A31E004A2860 AS DateTime), CAST(0x0000A31E005265C0 AS DateTime), N'Bangalore', N'Daily standup meeting for progress', NULL, CAST(0x0000A31E003DCC50 AS DateTime))
INSERT [Utility].[Appointment] ([Id], [ActorId], [Title], [TypeId], [Start], [End], [Location], [Description], [ImportanceId], [Reminder]) VALUES (CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Client visit', CAST(1 AS Numeric(10, 0)), CAST(0x0000A31E0083D600 AS DateTime), CAST(0x0000A31E008C1360 AS DateTime), N'Bangalore', N'Client visit at Marathahalli', NULL, CAST(0x0000A31E007FB750 AS DateTime))
SET IDENTITY_INSERT [Utility].[Appointment] OFF
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentUpdate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentUpdate]
(
	@Id Numeric(10,0),
	@CardNumber Varchar(4),
	@Remark Varchar(255),
	@PaymentTypeId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE [Invoice].[AdvancePayment]
	SET			
		[CardNumber] = @CardNumber,
		[Remark] = @Remark,
		[PaymentTypeId] = @PaymentTypeId,
		[Date] = GETDATE()
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Date],
		[CardNumber],
		[Remark],
		[PaymentTypeId]
	FROM [Invoice].AdvancePayment WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Date],
		[CardNumber],
		[Remark],
		[PaymentTypeId]
	FROM [Invoice].AdvancePayment WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentIsTypeDeletable]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentIsTypeDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentIsTypeDeletable]
(
	@PaymentTypeId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  Id,CardNumber,[Date],Remark
	FROM [Invoice].AdvancePayment
	WHERE PaymentTypeId = @paymentTypeId

 END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentInsert]
(  	
	@InvoiceId Numeric(10,0),
	@PaymentTypeId Numeric(10,0),
	@CardNumber Varchar(4),
	@Remark Varchar(255),
	@Amount money,	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Invoice].[AdvancePayment]([InvoiceId],[PaymentTypeId],[CardNumber],[Remark],[Amount],[Date])
	VALUES(@InvoiceId,@PaymentTypeId,@CardNumber,@Remark,@Amount,GETDATE())
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].[AdvancePayment]
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdatePassword]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[AccountUpdatePassword]
(
	@Id Numeric(10,0),
	@Password Varchar(50)
)
AS
BEGIN
	
	UPDATE Guardian.Account
	SET	
		[Password] = @Password	
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdateLoginId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[AccountUpdateLoginId]
(
   @Id Numeric(10,0),
   @LoginId Varchar(15)
)
AS
BEGIN	
	UPDATE Guardian.Account
	SET	
		LoginId = @LoginId
	WHERE Id = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[AccountUpdate]
(
   @Id Numeric(10,0),
   @LoginId Varchar(15),
   @Password Varchar(127)
   --@RoleId Numeric(10,0)
)
AS
BEGIN	
	UPDATE Guardian.Account
	SET	
		LoginId = @LoginId,
		[Password] = @Password	
	WHERE Id = @Id
	--UPDATE User_Role
	--SET
	--	RoleId	= @RoleId
	--WHERE UserId = @Id   
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ActionStatusUpdate]
(	
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE [Customer].[ActionStatus]
	SET	
		[Name] = @Name
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ActionStatusReadAll]	
AS
BEGIN
	
	SELECT Id, Name
	FROM Customer.ActionStatus WITH (NOLOCK)
	
END' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ActionStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Customer.ActionStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ActionStatusInsert]
(  
	@Name Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Customer].ActionStatus([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ActionStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM [Customer].[ActionStatus]
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Navigator].[Artifact]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[Artifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Navigator].[Artifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](50) NOT NULL,
	[Extension] [varchar](5) NULL,
	[Path] [varchar](max) NULL,
	[Style] [numeric](2, 0) NOT NULL,
	[Version] [numeric](4, 0) NOT NULL,
	[ParentId] [numeric](10, 0) NULL,
	[CreatedByUserId] [numeric](10, 0) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedByUserId] [numeric](10, 0) NULL,
	[ModifiedAt] [datetime] NULL,
 CONSTRAINT [PK_Artifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'Navigator', N'TABLE',N'Artifact', N'COLUMN',N'Style'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 - Directory, 2 - File' , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'TABLE',@level1name=N'Artifact', @level2type=N'COLUMN',@level2name=N'Style'
GO
SET IDENTITY_INSERT [Navigator].[Artifact] ON
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(678 AS Numeric(10, 0)), N'2010', NULL, N'Form:\\Customer\2010\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0107F1BA AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(679 AS Numeric(10, 0)), N'01 Jan', NULL, N'Form:\\Customer\2010\01 Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(678 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0107FC73 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(680 AS Numeric(10, 0)), N'02 Feb', NULL, N'Form:\\Customer\2010\02 Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(678 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0108070D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(681 AS Numeric(10, 0)), N'03 Mar', NULL, N'Form:\\Customer\2010\03 Mar\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(678 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE010810F7 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(682 AS Numeric(10, 0)), N'04 Apr', NULL, N'Form:\\Customer\2010\04 Apr\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(678 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01081AB6 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE010821CE AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(683 AS Numeric(10, 0)), N'2011', NULL, N'Form:\\Customer\2011\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01083146 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(684 AS Numeric(10, 0)), N'2012', NULL, N'Form:\\Customer\2012\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01083A65 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(685 AS Numeric(10, 0)), N'2013', NULL, N'Form:\\Customer\2013\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0108435C AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(686 AS Numeric(10, 0)), N'2014', NULL, N'Form:\\Customer\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01084B46 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(687 AS Numeric(10, 0)), N'01 Jan', NULL, N'Form:\\Customer\2014\01 Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01085328 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(688 AS Numeric(10, 0)), N'02 Feb', NULL, N'Form:\\Customer\2014\02 Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01085C30 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(689 AS Numeric(10, 0)), N'03 Mar', NULL, N'Form:\\Customer\2014\03 Mar\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01086AC0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(690 AS Numeric(10, 0)), N'04 Apr', NULL, N'Form:\\Customer\2014\04 Apr\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE010872F0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(691 AS Numeric(10, 0)), N'05 May', NULL, N'Form:\\Customer\2014\05 May\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01087C5F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(692 AS Numeric(10, 0)), N'06 Jun', NULL, N'Form:\\Customer\2014\06 Jun\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE010889AF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(693 AS Numeric(10, 0)), N'07 Jul', NULL, N'Form:\\Customer\2014\07 Jul\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01089385 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(694 AS Numeric(10, 0)), N'08 Aug', NULL, N'Form:\\Customer\2014\08 Aug\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01089CD4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(695 AS Numeric(10, 0)), N'09 Sep', NULL, N'Form:\\Customer\2014\09 Sep\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0108A7B0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(696 AS Numeric(10, 0)), N'10 Oct', NULL, N'Form:\\Customer\2014\10 Oct\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0108B065 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(697 AS Numeric(10, 0)), N'11 Nov', NULL, N'Form:\\Customer\2014\11 Nov\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0108B826 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(698 AS Numeric(10, 0)), N'12 Dec', NULL, N'Form:\\Customer\2014\12 Dec\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0108BFCE AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(699 AS Numeric(10, 0)), N'Arpan Kar', N'frm', N'Form:\\Customer\2014\12 Dec\Arpan Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0108CB76 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(700 AS Numeric(10, 0)), N'2014', NULL, N'Form:\\Room Reservation\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01093614 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(701 AS Numeric(10, 0)), N'12 Dec', NULL, N'Form:\\Room Reservation\2014\12 Dec\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(700 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01093F5D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(702 AS Numeric(10, 0)), N'Arpan Kar Reservation', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Arpan Kar Reservation', CAST(2 AS Numeric(2, 0)), CAST(8 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE01094F7A AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400948283 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(703 AS Numeric(10, 0)), N'2014', NULL, N'Form:\\Payment\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0109EEC8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(704 AS Numeric(10, 0)), N'12 Dec', NULL, N'Form:\\Payment\2014\12 Dec\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(703 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE0109F68F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(705 AS Numeric(10, 0)), N'Arpan Kar', N'frm', N'Form:\\Payment\2014\12 Dec\Arpan Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(704 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3FE010A0F63 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(706 AS Numeric(10, 0)), N'Arpan Kar New', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Arpan Kar New', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300E3CF20 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(707 AS Numeric(10, 0)), N'Arpan Checkin', N'frm', N'Form:\\Check In\Arpan Checkin', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A40300E495C3 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(708 AS Numeric(10, 0)), N'Rakhi Reservation', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Rakhi Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A404009511FF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(709 AS Numeric(10, 0)), N'Rakhi Dey Kar', N'frm', N'Form:\\Customer\2014\12 Dec\Rakhi Dey Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400953B90 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(710 AS Numeric(10, 0)), N'Rakhi Dey Advance Payment', N'frm', N'Form:\\Payment\2014\12 Dec\Rakhi Dey Advance Payment', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(704 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400965906 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(711 AS Numeric(10, 0)), N'Saptorshi Kar Reservation', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Saptorshi Kar Reservation', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400975B8F AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400984E02 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(712 AS Numeric(10, 0)), N'Saptorshi Kar', N'frm', N'Form:\\Customer\2014\12 Dec\Saptorshi Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400977164 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(713 AS Numeric(10, 0)), N'Saptorshi Kar Adv Payment', N'frm', N'Form:\\Payment\2014\12 Dec\Saptorshi Kar Adv Payment', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(704 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40400981B41 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(714 AS Numeric(10, 0)), N'2012', NULL, N'Form:\\Check In\2012\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A4040098B838 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(715 AS Numeric(10, 0)), N'12 Dec', NULL, N'Form:\\Check In\2012\12 Dec\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(714 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4040098C219 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(716 AS Numeric(10, 0)), N'11 Nov', NULL, N'Form:\\Check In\2012\11 Nov\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(714 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4040098CE52 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(717 AS Numeric(10, 0)), N'Saptorshi Kar Check In', N'frm', N'Form:\\Check In\2012\12 Dec\Saptorshi Kar Check In', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(715 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4040098EF8C AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500B6A0D2 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(718 AS Numeric(10, 0)), N'Rakhi Dey Checkin Advance Payment', N'frm', N'Form:\\Payment\2014\12 Dec\Rakhi Dey Checkin Advance Payment', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(704 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A404009DE644 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(719 AS Numeric(10, 0)), N'Saptorshi kar Part Payment', N'frm', N'Form:\\Payment\2014\12 Dec\Saptorshi kar Part Payment', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(704 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500B66A20 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(720 AS Numeric(10, 0)), N'10 Oct', NULL, N'Form:\\Check In\2012\10 Oct\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(714 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500BBDD09 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(721 AS Numeric(10, 0)), N'Arighna Kar Check In', N'frm', N'Form:\\Check In\2012\12 Dec\Arighna Kar Check In', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(715 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500BC1ED4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(726 AS Numeric(10, 0)), N'Arighna Kar', N'frm', N'Form:\\Customer\2014\12 Dec\Arighna Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500CD6888 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(727 AS Numeric(10, 0)), N'Arighna Kar Reservation', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Arighna Kar Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500D083F6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(728 AS Numeric(10, 0)), N'Arighna Kar Advance Payment', N'frm', N'Form:\\Payment\2014\12 Dec\Arighna Kar Advance Payment', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(704 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40500DA579E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(729 AS Numeric(10, 0)), N'Ajoy Kar Reservation', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Ajoy Kar Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4050103E9CF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(730 AS Numeric(10, 0)), N'Ajoy Kar', N'frm', N'Form:\\Customer\2014\12 Dec\Ajoy Kar', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A4050104031D AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41200BABCC1 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(731 AS Numeric(10, 0)), N'Arighna Kar Reservation 2', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Arighna Kar Reservation 2', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A405010B9B07 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(733 AS Numeric(10, 0)), N'Rakhi Dey Check In', N'frm', N'Form:\\Check In\2012\12 Dec\Rakhi Dey Check In', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(715 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A405010EEDCB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(734 AS Numeric(10, 0)), N'Priti Kar Checkin', N'frm', N'Form:\\Check In\2012\12 Dec\Priti Kar Checkin', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(715 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00B3B811 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(735 AS Numeric(10, 0)), N'Priti Kar Reservation', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Priti Kar Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00B418C9 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(736 AS Numeric(10, 0)), N'Priti Kar', N'frm', N'Form:\\Customer\2014\12 Dec\Priti Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00B46454 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(737 AS Numeric(10, 0)), N'Baishali Kar Checkin', N'frm', N'Form:\\Check In\2012\12 Dec\Baishali Kar Checkin', CAST(2 AS Numeric(2, 0)), CAST(5 AS Numeric(4, 0)), CAST(715 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00F1877A AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00FFD3D9 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(738 AS Numeric(10, 0)), N'Baishali Kar Reservation', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Baishali Kar Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00F1B559 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(739 AS Numeric(10, 0)), N'Baishali Kar', N'frm', N'Form:\\Customer\2014\12 Dec\Baishali Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A40D00F1D3B3 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(740 AS Numeric(10, 0)), N'Arpan Kar Checkin 2', N'frm', N'Form:\\Check In\2012\12 Dec\Arpan Kar Checkin 2', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(715 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A410009C8CB1 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(741 AS Numeric(10, 0)), N'Priti Kar Reservation 2', N'frm', N'Form:\\Room Reservation\2014\12 Dec\Priti Kar Reservation 2', CAST(2 AS Numeric(2, 0)), CAST(12 AS Numeric(4, 0)), CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A41000F5C051 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A411011756B8 AS DateTime))
SET IDENTITY_INSERT [Navigator].[Artifact] OFF
/****** Object:  StoredProcedure [Report].[CategoryReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Report].[CategoryReadAll]
AS
BEGIN
	
	SELECT Id, Extension, Name
	FROM Report.Category WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Report].[CategoryRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Report].[CategoryRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id
		,Extension
		,Name
	FROM Report.Category WITH (NOLOCK)
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[AccountInsert]
(  
   @LoginId Varchar(15),   
   @Password Varchar(127),
   --@RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
   INSERT INTO Guardian.Account(LoginId, [Password])
   VALUES (@LoginId, @Password)   
   SET @Id = @@IDENTITY   
   --INSERT INTO User_Role (UserId, RoleId)
   --VALUES(@Id, @RoleId)
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[AccountDelete]
(
   @Id Numeric(10,0)
)
AS
BEGIN
   DELETE FROM Guardian.Account
   WHERE Id = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[CountryReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[CountryReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.Country WITH (NOLOCK)
   
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[CountryRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[CountryRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	
   SELECT Id, Name
   FROM Configuration.Country WITH (NOLOCK)
   WHERE Id = @Id
   
END' 
END
GO
/****** Object:  Table [Organization].[ContactNumber]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumber]') AND type in (N'U'))
BEGIN
CREATE TABLE [Organization].[ContactNumber](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_ContactNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Organization].[ContactNumber] ON
INSERT [Organization].[ContactNumber] ([Id], [ContactNumber], [OrganizationId]) VALUES (CAST(53 AS Numeric(10, 0)), N'9876567824', CAST(12 AS Numeric(10, 0)))
INSERT [Organization].[ContactNumber] ([Id], [ContactNumber], [OrganizationId]) VALUES (CAST(54 AS Numeric(10, 0)), N'+91-088-555555555', CAST(12 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Organization].[ContactNumber] OFF
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ComponentUpdate]
(
	@Id  Numeric(10,0),
	@Code Varchar(50),
	@Name Varchar(50),
	@Description Varchar(50),
	@IsForm Bit,
	@IsReport Bit,
	@IsCatalogue Bit
)
As
Begin
	UPDATE License.Component
	SET Code = @Code,
		Name = @Name,
		[Description] = @Description,
		IsForm = @IsForm,
		IsReport = @IsReport,
		IsCatalogue = @IsCatalogue
	WHERE Id = @Id
End
' 
END
GO
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ComponentReadAll]
As
BEGIN

	SELECT Id, Code, Name, [Description], IsForm, IsReport, IsCatalogue
	FROM License.Component WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ComponentRead]
(
	@Id  Numeric(10,0)
)
As
BEGIN

	SELECT Id, Code, Name, [Description], IsForm, IsReport, IsCatalogue
	FROM License.Component WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ComponentInsert]
(
	@Name Varchar(50),
	@Code Varchar(50),
	@Description Varchar(50),
	@IsForm Bit,
	@IsReport Bit,
	@IsCatalogue Bit,
	@Id  Numeric(10,0) OUTPUT
)
As
Begin
	INSERT INTO License.Component(Code, Name, [Description], IsForm, IsReport, IsCatalogue)
	VALUES(@Code, @Name, @Description, @IsForm, @IsReport, @IsCatalogue)
	
	SET @Id = @@IDENTITY
End
' 
END
GO
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [License].[ComponentDelete]
(
	@Id  Numeric(10,0)
)
As
Begin
	DELETE FROM License.Component
	WHERE Id = @Id
End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactAttachmentReadLink]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactAttachmentReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInArtifactAttachmentReadLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT AttachmentId
	FROM Lodge.CheckInAttachment WITH (NOLOCK)
	WHERE ArtifactId = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactAttachmentInsertLink]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactAttachmentInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInArtifactAttachmentInsertLink]
(
	@Id Numeric(10,0),
	@AttachmentId Numeric(10,0)
)
AS
BEGIN
 
	INSERT INTO Lodge.CheckInAttachment(ArtifactId,AttachmentId)
	VALUES(@Id, @AttachmentId)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactAttachmentDeleteLink]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactAttachmentDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInArtifactAttachmentDeleteLink]
(
	@AttachmentId Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM [Lodge].CheckInAttachment
	WHERE AttachmentId = @AttachmentId   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[IdentityProofTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE [Configuration].IdentityProofType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[IdentityProofTypeReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN

	SELECT Id
	FROM Configuration.IdentityProofType WITH (NOLOCK)
	WHERE Name = @Name
				
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[IdentityProofTypeReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.IdentityProofType WITH (NOLOCK)
   
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[IdentityProofTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.IdentityProofType WITH (NOLOCK)
	WHERE Id = @Id   
	
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[IdentityProofTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Configuration].IdentityProofType([Name])
	VALUES(@Name)
	
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[IdentityProofTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM [Configuration].IdentityProofType
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Organization].[Email]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Email]') AND type in (N'U'))
BEGIN
CREATE TABLE [Organization].[Email](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Organization].[Email] ON
INSERT [Organization].[Email] ([Id], [Email], [OrganizationId]) VALUES (CAST(44 AS Numeric(10, 0)), N'xya@yahoo.com', CAST(12 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Organization].[Email] OFF
/****** Object:  Table [Organization].[Fax]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Fax]') AND type in (N'U'))
BEGIN
CREATE TABLE [Organization].[Fax](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Fax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Organization].[Fax] ON
INSERT [Organization].[Fax] ([Id], [Fax], [OrganizationId]) VALUES (CAST(25 AS Numeric(10, 0)), N'1263546475', CAST(12 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Organization].[Fax] OFF
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[EmailReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id, OrganizationId, Email
	FROM Organization.Email
	WHERE OrganizationId = @ParentId
	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[EmailRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN

	SELECT Id, Email, OrganizationId
	FROM Organization.Email WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[EmailInsert]
(  
	@Email Varchar(50),
	@OrganizationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Organization].Email([Email],[OrganizationId])
	VALUES(@Email,@OrganizationId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 01/01/2015 10:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[EmailDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[Email]
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Lodge].[CheckIn]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckIn]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[CheckIn](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CheckInDate] [datetime] NOT NULL,
	[Purpose] [varchar](max) NULL,
	[ArrivedFrom] [varchar](max) NULL,
	[Remark] [varchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ReservationId] [numeric](10, 0) NULL,
	[StatusId] [numeric](10, 0) NULL,
	[InvoiceNumber] [varchar](50) NULL,
 CONSTRAINT [PK_CheckIn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[CheckIn] ON
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Purpose], [ArrivedFrom], [Remark], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(36 AS Numeric(10, 0)), CAST(0x0000A40300E51817 AS DateTime), N'Recreation', N'Kolkata', N'Need airport drop', CAST(0x0000A40300E52D0E AS DateTime), CAST(170 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Purpose], [ArrivedFrom], [Remark], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(37 AS Numeric(10, 0)), CAST(0x0000A404009C1F79 AS DateTime), N'Travel', N'Kolkata', N'Need cab for site seeing', CAST(0x0000A404009C2718 AS DateTime), CAST(172 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Purpose], [ArrivedFrom], [Remark], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(38 AS Numeric(10, 0)), CAST(0x0000A40500D916AB AS DateTime), N'Tour', N'Kolkata', N'Need lunch at room', CAST(0x0000A40500D91AE4 AS DateTime), CAST(175 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Purpose], [ArrivedFrom], [Remark], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(40 AS Numeric(10, 0)), CAST(0x0000A405010F55D6 AS DateTime), N'', N'', N'', CAST(0x0000A405010F5D80 AS DateTime), CAST(171 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Purpose], [ArrivedFrom], [Remark], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(48 AS Numeric(10, 0)), CAST(0x0000A40D00DC92E6 AS DateTime), N'Tour', N'Kolkata', N'', CAST(0x0000A40D00DC9805 AS DateTime), CAST(178 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Purpose], [ArrivedFrom], [Remark], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(49 AS Numeric(10, 0)), CAST(0x0000A40D00FFCA51 AS DateTime), N'Tour', N'Kolkata', N'', CAST(0x0000A40D00F2BC1A AS DateTime), CAST(179 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
SET IDENTITY_INSERT [Lodge].[CheckIn] OFF
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[ContactNumberReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, OrganizationId, ContactNumber
	FROM Organization.ContactNumber WITH (NOLOCK)
	WHERE OrganizationId = @ParentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[ContactNumberRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN

	SELECT  Id, ContactNumber, OrganizationId
	FROM Organization.ContactNumber WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[ContactNumberInsert]
(  
	@ContactNumber Varchar(50),
	@OrganizationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Organization].ContactNumber(ContactNumber,[OrganizationId])
	VALUES(@ContactNumber,@OrganizationId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[ContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[ContactNumber]
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  Table [Customer].[Customer]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customer].[Customer](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[InitialId] [numeric](10, 0) NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](255) NOT NULL,
	[CountryId] [numeric](10, 0) NULL,
	[StateId] [numeric](10, 0) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Pin] [numeric](10, 0) NULL,
	[Email] [varchar](50) NULL,
	[IdentityProofId] [numeric](10, 0) NULL,
	[IdentityProofName] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Customer].[Customer] ON
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(126 AS Numeric(10, 0)), NULL, N'Arpan', N'', N'Kar', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'arpan.kar@gmail.com', CAST(1 AS Numeric(10, 0)), N'AMLPK3126A')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(127 AS Numeric(10, 0)), NULL, N'Rakhi', N'Dey', N'Kar', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'rakhi.dey@gmail.com', CAST(1 AS Numeric(10, 0)), N'MNTYG5601U')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(128 AS Numeric(10, 0)), NULL, N'Saptorshi', N'', N'Kar', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'sapto.kar@gmail.com', CAST(1 AS Numeric(10, 0)), N'MNERD5619F')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(130 AS Numeric(10, 0)), NULL, N'Arighna', N'', N'Kar', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'arighna.kar@binaff.com', CAST(1 AS Numeric(10, 0)), N'AMLPK7209A')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(131 AS Numeric(10, 0)), NULL, N'Ajoy', N'', N'Kar', N'Boalia Saha Kalibari,
Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'ajoy.kar@binaff.com', CAST(1 AS Numeric(10, 0)), N'AMNTF5199B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(132 AS Numeric(10, 0)), NULL, N'Priti', N'', N'Kar', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'priti.kar@binaff.in', CAST(1 AS Numeric(10, 0)), N'MNERD3409F')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(133 AS Numeric(10, 0)), NULL, N'Baishali', N'', N'Kar', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'baishali.gupta@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNEWR3409R')
SET IDENTITY_INSERT [Customer].[Customer] OFF
/****** Object:  Table [Invoice].[Artifact]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Artifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[Artifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[InvoiceId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentUpdate]
(
	@Id Numeric(10,0),
	@ActorId Numeric(10,0),
	@Title Varchar(50),
	@TypeId Numeric(10,0),
	@Start Datetime,
	@End Datetime,
	@Location Varchar(50),
	@Description Varchar(250),
	@ImportanceId Numeric(10,0) = null,
	@Reminder Datetime = null
)
AS
BEGIN
	UPDATE [Utility].[Appointment]
	SET ActorId = @ActorId
		,[Title] = @Title
		,[TypeId] = @TypeId
		,[Start] = @Start
		,[End] = @End
		,[Location] = @Location
		,[Description] = @Description
		,[ImportanceId] = @ImportanceId
		,[Reminder] = @Reminder
	WHERE Id = @Id   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearchWithImportance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentSearchWithImportance]
( 
	@Start Datetime,
	@End Datetime,
	@Importance Numeric(1,0)
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
           ,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment
	WHERE [Start] >= @Start AND [Start] <= @End AND [End] <= @End AND ImportanceId = @Importance
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentSearch]
( 
	@Start Datetime,
	@End Datetime
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
           ,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment
	WHERE [Start] >= @Start AND [Start] <= @End AND [End] <= @End
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentReadAll]
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
		,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
		,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[AppointmentInsert]
(  
	@ActorId Numeric(10, 0),
	@Title Varchar(50),
	@TypeId Numeric(10,0),
	@Start Datetime,
	@End Datetime,
	@Location Varchar(50),
	@Description Varchar(250),
	@ImportanceId Numeric(10,0) = null,
	@Reminder Datetime = null,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	INSERT INTO [AutoTourism].[Utility].[Appointment]
		(ActorId, Title, TypeId, Start, [End], Location, [Description], ImportanceId, Reminder)
    VALUES
		(@ActorId, @Title, @TypeId, @Start, @End, @Location, @Description, @ImportanceId, @Reminder)
		
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Utility].[AppointmentDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Utility.Appointment
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[AccountReadAll]
AS
BEGIN

	SELECT 
		Id,
		LoginId,
		[Password]
	FROM Guardian.Account WITH (NOLOCK)
	WHERE LoginId != ''support''   
	SELECT 
		UserId, 
		RoleId
	FROM Guardian.UserRole WITH (NOLOCK)
	
END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[AccountRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	SELECT 
		Id,
		LoginId,
		[Password]
	FROM Guardian.Account WITH (NOLOCK)
	WHERE Id = @Id
	
	SELECT RoleId 
	FROM Guardian.UserRole WITH (NOLOCK)
	WHERE UserId = @Id
	
END
--Guardian.AccountRead 1
' 
END
GO
/****** Object:  Table [Invoice].[AdvancePaymentArtifact]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[AdvancePaymentArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[AdvancePaymentId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_AdvancePaymentArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AdvancePaymentArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadForPath]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadForPath]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactReadForPath]
(  
	@Path Varchar(1024)
)
AS
BEGIN	
	SELECT Id, [FileName], [Path], Extension, Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact
	WHERE [Path] + ''.'' +  Extension = @Path --OR ParentId = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactReadAll]
AS
BEGIN

	SELECT Id, [FileName], [Path], Extension, Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactRead]
(  
	@Id  Numeric(10,0)
)
AS
BEGIN

	SELECT Id, [FileName], [Path], Extension, Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact WITH (NOLOCK)
	WHERE Id = @Id --OR ParentId = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactInsert]
(  
	@FileName Varchar(50),
	@Path Varchar(MAX),
	@Extension Varchar(5),
	@Style Numeric(2,0),
	@ParentId Numeric(10, 0),
	@CreatedByUserId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Navigator.Artifact([FileName], [Path], Extension, Style, [Version], ParentId, CreatedByUserId, CreatedAt)
	VALUES(@FileName, @Path, @Extension, @Style, 1, @ParentId, @CreatedByUserId, GETDATE())
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  Table [Lodge].[BuildingClosureReason]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[BuildingClosureReason](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Reason] [varchar](50) NOT NULL,
	[BuildingId] [numeric](10, 0) NOT NULL,
	[ClosedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_BuildingClosureReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Navigator].[ArtifactComponentLink]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [Navigator].[ArtifactComponentLink](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[ComponentId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_FormModuleLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'Navigator', N'TABLE',N'ArtifactComponentLink', N'COLUMN',N'Category'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Form = 1, Catalogue = 2, Report = 3' , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'TABLE',@level1name=N'ArtifactComponentLink', @level2type=N'COLUMN',@level2name=N'Category'
GO
SET IDENTITY_INSERT [Navigator].[ArtifactComponentLink] ON
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(654 AS Numeric(10, 0)), CAST(678 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(655 AS Numeric(10, 0)), CAST(679 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(656 AS Numeric(10, 0)), CAST(680 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(657 AS Numeric(10, 0)), CAST(681 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(658 AS Numeric(10, 0)), CAST(682 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(659 AS Numeric(10, 0)), CAST(683 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(660 AS Numeric(10, 0)), CAST(684 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(661 AS Numeric(10, 0)), CAST(685 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(662 AS Numeric(10, 0)), CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(663 AS Numeric(10, 0)), CAST(687 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(664 AS Numeric(10, 0)), CAST(688 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(665 AS Numeric(10, 0)), CAST(689 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(666 AS Numeric(10, 0)), CAST(690 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(667 AS Numeric(10, 0)), CAST(691 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(668 AS Numeric(10, 0)), CAST(692 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(669 AS Numeric(10, 0)), CAST(693 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(670 AS Numeric(10, 0)), CAST(694 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(671 AS Numeric(10, 0)), CAST(695 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(672 AS Numeric(10, 0)), CAST(696 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(673 AS Numeric(10, 0)), CAST(697 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(674 AS Numeric(10, 0)), CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(675 AS Numeric(10, 0)), CAST(699 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(676 AS Numeric(10, 0)), CAST(700 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(677 AS Numeric(10, 0)), CAST(701 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(678 AS Numeric(10, 0)), CAST(702 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(679 AS Numeric(10, 0)), CAST(703 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(680 AS Numeric(10, 0)), CAST(704 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(681 AS Numeric(10, 0)), CAST(705 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(682 AS Numeric(10, 0)), CAST(706 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(683 AS Numeric(10, 0)), CAST(707 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(684 AS Numeric(10, 0)), CAST(708 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(685 AS Numeric(10, 0)), CAST(709 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(686 AS Numeric(10, 0)), CAST(710 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(687 AS Numeric(10, 0)), CAST(711 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(688 AS Numeric(10, 0)), CAST(712 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(689 AS Numeric(10, 0)), CAST(713 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(690 AS Numeric(10, 0)), CAST(714 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(691 AS Numeric(10, 0)), CAST(715 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(692 AS Numeric(10, 0)), CAST(716 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(693 AS Numeric(10, 0)), CAST(717 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(694 AS Numeric(10, 0)), CAST(718 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(695 AS Numeric(10, 0)), CAST(719 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(696 AS Numeric(10, 0)), CAST(720 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(697 AS Numeric(10, 0)), CAST(721 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(702 AS Numeric(10, 0)), CAST(726 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(703 AS Numeric(10, 0)), CAST(727 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(704 AS Numeric(10, 0)), CAST(728 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(705 AS Numeric(10, 0)), CAST(729 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(706 AS Numeric(10, 0)), CAST(730 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(707 AS Numeric(10, 0)), CAST(731 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(709 AS Numeric(10, 0)), CAST(733 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(710 AS Numeric(10, 0)), CAST(734 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(711 AS Numeric(10, 0)), CAST(735 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(712 AS Numeric(10, 0)), CAST(736 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(713 AS Numeric(10, 0)), CAST(737 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(714 AS Numeric(10, 0)), CAST(738 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(715 AS Numeric(10, 0)), CAST(739 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(716 AS Numeric(10, 0)), CAST(740 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactComponentLink] ([Id], [ArtifactId], [ComponentId], [Category]) VALUES (CAST(717 AS Numeric(10, 0)), CAST(741 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Navigator].[ArtifactComponentLink] OFF
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactUpdate]
(  
	@Id  Numeric(10,0),
	@FileName Varchar(50),
	@Path Varchar(MAX),
	@ParentId Numeric(10, 0),
	@ModifiedByUserId  Numeric(10,0)
)
AS
BEGIN	
	
	UPDATE Navigator.Artifact
	SET [FileName] = @FileName,
		[Path] = @Path,
		[Version] = [Version] + 1,
		ParentId = @ParentId,
		ModifiedByUserId = @ModifiedByUserId,
		ModifiedAt = GETDATE()
	WHERE Id = @Id
END
' 
END
GO
/****** Object:  Table [Navigator].[CatalogueModuleLink]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [Navigator].[CatalogueModuleLink](
	[Id] [numeric](10, 0) NOT NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[ModuleId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CatalogueModuleLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingUpdate]
	(  
		@Id Numeric(10,0),
		@Name Varchar(50),	
		@TypeId Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN	
		UPDATE [Lodge].Building
		SET	
			[Name] = @Name,
			[TypeId] = @TypeId
		WHERE Id = @Id
	END
' 
END
GO
/****** Object:  Table [Lodge].[BuildingFloor]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[BuildingFloor](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Floor] [varchar](50) NOT NULL,
	[BuildingId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_BuildingFloor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[BuildingFloor] ON
INSERT [Lodge].[BuildingFloor] ([Id], [Floor], [BuildingId]) VALUES (CAST(71 AS Numeric(10, 0)), N'1', CAST(22 AS Numeric(10, 0)))
INSERT [Lodge].[BuildingFloor] ([Id], [Floor], [BuildingId]) VALUES (CAST(72 AS Numeric(10, 0)), N'5', CAST(22 AS Numeric(10, 0)))
INSERT [Lodge].[BuildingFloor] ([Id], [Floor], [BuildingId]) VALUES (CAST(76 AS Numeric(10, 0)), N'1', CAST(16 AS Numeric(10, 0)))
INSERT [Lodge].[BuildingFloor] ([Id], [Floor], [BuildingId]) VALUES (CAST(77 AS Numeric(10, 0)), N'2', CAST(16 AS Numeric(10, 0)))
INSERT [Lodge].[BuildingFloor] ([Id], [Floor], [BuildingId]) VALUES (CAST(78 AS Numeric(10, 0)), N'1', CAST(23 AS Numeric(10, 0)))
INSERT [Lodge].[BuildingFloor] ([Id], [Floor], [BuildingId]) VALUES (CAST(79 AS Numeric(10, 0)), N'2', CAST(23 AS Numeric(10, 0)))
INSERT [Lodge].[BuildingFloor] ([Id], [Floor], [BuildingId]) VALUES (CAST(80 AS Numeric(10, 0)), N'3', CAST(23 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Lodge].[BuildingFloor] OFF
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].Building
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name],
		[TypeId],
		[StatusId],
		[OrganizationId]
	FROM [Lodge].Building WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name],
		[TypeId],
		[StatusId],
		[OrganizationId]
	FROM [Lodge].Building WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingModifyStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingModifyStatus]
	(	
		@Id Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].Building
		SET	
			[StatusId] = @StatusId			
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingInsert]
	(  
		@Name Varchar(50),	
		@TypeId Numeric(10,0),
		@StatusId Numeric(10,0),		
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		INSERT INTO [Lodge].Building([Name],[TypeId],[StatusId])
		VALUES(@Name,@TypeId,@StatusId)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[LoginHistoryUpdate]
(
   @Id Numeric(10,0)
)
AS
BEGIN
   UPDATE Guardian.LoginHistory 
   SET LogoutStamp = GETDATE()
   WHERE Id = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[LoginHistoryReadForParent]
(
   @ParentId Numeric(10,0)
)
AS
BEGIN

   SELECT Id, LoginStamp, LogoutStamp
   FROM Guardian.LoginHistory WITH (NOLOCK)
   WHERE AccountId = @ParentId
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[LoginHistoryRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN

   SELECT Id, AccountId, LoginStamp, LogoutStamp
   FROM Guardian.LoginHistory WITH (NOLOCK)
   WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[LoginHistoryInsert]
(  
   @AccountId Numeric(10,0),
   @Id Numeric(10,0) OUT
)
AS
BEGIN
   INSERT INTO Guardian.LoginHistory (AccountId, LoginStamp, LogoutStamp)
   VALUES(@AccountId, GETDATE(), null)
   SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[IsInitialDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[IsInitialDeletable]
(
	@InitialId NUMERIC(10,0)
)
AS
BEGIN
	SELECT (SELECT LoginId 
		FROM Guardian.Account WITH (NOLOCK)
		WHERE Id = UserId) LoginId, FirstName, LastName
	FROM Guardian.[Profile] WITH (NOLOCK)
	WHERE Initial = @InitialId

 END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationEmailRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationEmailRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--CREATE TABLE [dbo].[Organization](
--	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
--	[Name] [varchar](50) NOT NULL,
--	[Logo] [varbinary](max) NULL,
--	[LicenceNumber] [varchar](50) NULL,
--	[Tan] [varchar](50) NULL,
--	[Address] [varchar](255) NULL,
--	[City] [varchar](50) NULL,
--	[StateId] [numeric](10, 0) NULL,
--	[Pin] [int] NULL,
--	[ContactName] [varchar](50) NULL,
-- )


--CREATE PROCEDURE [dbo].[OrganizationRead] 
--(
--	@Id Numeric(10,0) = null
--)
--AS
--BEGIN
	
--	if(ISNULL(@Id,0) = 0)
--	Begin
--		SELECT Top 1
--				Id,
--				[Name],
--				[Logo],
--				[LicenceNumber],
--				[Tan],
--				[Address],
--				[City],
--				[StateId],
--				[Pin],
--				[ContactName]
--			FROM Organization
--	End
--	Else
--	Begin	
--		SELECT 
--			Id,
--			[Name],
--			[Logo],
--			[LicenceNumber],
--			[Tan],
--			[Address],
--			[City],
--			[StateId],
--			[Pin],
--			[ContactName]
--		FROM Organization
--		WHERE Id = @Id   
--	End
	
--END

--CREATE TABLE [dbo].[OrganizationEmail](
--	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
--	[LodgeId] [numeric](10, 0) NOT NULL,
--	[Email] [varchar](50) NOT NULL,
-- )

CREATE PROCEDURE [dbo].[OrganizationEmailRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, OrganizationId, Email
	FROM Organization.Email WITH (NOLOCK)
	WHERE Id = @Id   
	
END' 
END
GO
/****** Object:  Table [Invoice].[PaymentLineItem]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[PaymentLineItem](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Reference] [varchar](16) NOT NULL,
	[Amount] [numeric](10, 2) NOT NULL,
	[PaymentTypeId] [numeric](10, 0) NOT NULL,
	[Remark] [varchar](255) NULL,
	[PaymentId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_PaymentLineItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Invoice].[PaymentLineItem] ON
INSERT [Invoice].[PaymentLineItem] ([Id], [Reference], [Amount], [PaymentTypeId], [Remark], [PaymentId]) VALUES (CAST(55 AS Numeric(10, 0)), N'2352', CAST(2000.00 AS Numeric(10, 2)), CAST(4 AS Numeric(10, 0)), N'', CAST(75 AS Numeric(10, 0)))
INSERT [Invoice].[PaymentLineItem] ([Id], [Reference], [Amount], [PaymentTypeId], [Remark], [PaymentId]) VALUES (CAST(56 AS Numeric(10, 0)), N'6756', CAST(2000.00 AS Numeric(10, 2)), CAST(4 AS Numeric(10, 0)), N'', CAST(76 AS Numeric(10, 0)))
INSERT [Invoice].[PaymentLineItem] ([Id], [Reference], [Amount], [PaymentTypeId], [Remark], [PaymentId]) VALUES (CAST(57 AS Numeric(10, 0)), N'4230', CAST(1000.00 AS Numeric(10, 2)), CAST(4 AS Numeric(10, 0)), N'', CAST(77 AS Numeric(10, 0)))
INSERT [Invoice].[PaymentLineItem] ([Id], [Reference], [Amount], [PaymentTypeId], [Remark], [PaymentId]) VALUES (CAST(58 AS Numeric(10, 0)), N'', CAST(1000.00 AS Numeric(10, 2)), CAST(5 AS Numeric(10, 0)), N'', CAST(77 AS Numeric(10, 0)))
INSERT [Invoice].[PaymentLineItem] ([Id], [Reference], [Amount], [PaymentTypeId], [Remark], [PaymentId]) VALUES (CAST(59 AS Numeric(10, 0)), N'', CAST(1000.00 AS Numeric(10, 2)), CAST(5 AS Numeric(10, 0)), N'', CAST(78 AS Numeric(10, 0)))
INSERT [Invoice].[PaymentLineItem] ([Id], [Reference], [Amount], [PaymentTypeId], [Remark], [PaymentId]) VALUES (CAST(60 AS Numeric(10, 0)), N'', CAST(1000.00 AS Numeric(10, 2)), CAST(5 AS Numeric(10, 0)), N'', CAST(79 AS Numeric(10, 0)))
INSERT [Invoice].[PaymentLineItem] ([Id], [Reference], [Amount], [PaymentTypeId], [Remark], [PaymentId]) VALUES (CAST(61 AS Numeric(10, 0)), N'', CAST(1000.00 AS Numeric(10, 2)), CAST(5 AS Numeric(10, 0)), N'', CAST(80 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Invoice].[PaymentLineItem] OFF
/****** Object:  StoredProcedure [Invoice].[PaymentInsert]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentInsert]
(  	
	@InvoiceId Numeric(10,0) = null,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Invoice.Payment(InvoiceId, [Date])
	VALUES(@InvoiceId,GETDATE())
   
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentDelete]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].[Payment]
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadAll]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentReadAll]
AS
BEGIN
	
	SELECT Id, [Date], InvoiceId
	FROM Invoice.Payment WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Date], InvoiceId
	FROM Invoice.Payment WITH (NOLOCK)
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingTypeDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[IsBuildingTypeDeletable] 
(
	@TypeId NUMERIC(10,0)
)
As
BEGIN

	SELECT Name 
	FROM Lodge.Building WITH (NOLOCK)
	WHERE TypeId = @TypeId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingStatusDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[IsBuildingStatusDeletable]
(
	@StatusId NUMERIC(10,0)
)
As
BEGIN

	SELECT Name,StatusId 
	FROM [Lodge].Building WITH (NOLOCK)
	WHERE StatusId = @StatusId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[IsBuildingDeletable]
(
	@OrganizationId NUMERIC(10,0)
)
As
BEGIN

	SELECT Name,StatusId
	FROM [Lodge].Building WITH (NOLOCK)
	WHERE OrganizationId = @OrganizationId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 01/01/2015 10:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceTaxationRead]
(
	@InvoiceId Numeric(10,0)
)
As
BEGIN

	SELECT  
		[TaxName],
		[TaxAmount],
		[IsPercentage],
		[InvoiceId]
	FROM [Invoice].InvoiceTaxation WITH (NOLOCK)
	WHERE InvoiceId = @InvoiceId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceTaxationInsert]
(  	
	@InvoiceId Numeric(10,0),
	@TaxName Varchar(50),	
	@TaxAmount money,	
	@IsPercentage Bit,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Invoice].[InvoiceTaxation]([TaxName],[TaxAmount],[IsPercentage],[InvoiceId])
	VALUES(@TaxName,@TaxAmount,@IsPercentage,@InvoiceId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  Table [Invoice].[LineItemTaxation]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[LineItemTaxation](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[TaxName] [varchar](50) NULL,
	[TaxAmount] [money] NULL,
	[IsPercentage] [bit] NULL,
	[LineItemId] [numeric](10, 0) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadForParent]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[LineItemReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Start],
		[End],
		[Description],
		[UnitRate],
		[Count]
	FROM [Invoice].LineItem WITH (NOLOCK)
	WHERE InvoiceId = @ParentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadAll]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[LineItemReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Start],
		[End],
		[Description],
		[UnitRate],
		[Count]
	FROM [Invoice].LineItem WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemRead]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[LineItemRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Start],
		[End],
		[Description],
		[UnitRate],
		[Count],
		[InvoiceId]
	FROM [Invoice].LineItem WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemInsert]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[LineItemInsert]
(  
	@Start DateTime,
	@End DateTime,
	@Description Varchar(250),
	@UnitRate Money,
	@Count Int,
	@InvoiceId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  [Invoice].LineItem([Start],[End],[Description],[UnitRate],[Count],[InvoiceId])
	VALUES(@Start,@End,@Description,@UnitRate,@Count,@InvoiceId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemDelete]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[LineItemDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].LineItem
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemUpdate]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[LineItemUpdate]
(
	@Id Numeric(10,0),
	@Start DateTime,
	@End DateTime,
	@Description Varchar(250),
	@UnitRate Money,
	@Count Int
)
AS
BEGIN
	
	UPDATE [Invoice].LineItem
	SET	
		[Start] = @Start,
		[End] = @End,
		[Description] = @Description,
		[UnitRate] = @UnitRate,
		[Count] = @Count
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[FaxReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[OrganizationId],
			[Fax]
		FROM [Organization].Fax
		WHERE OrganizationId = @ParentId   
	END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[FaxRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN

	SELECT Id, Fax,	OrganizationId
	FROM Organization.Fax WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[FaxInsert]
(  
	@Fax Varchar(50),
	@OrganizationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Organization].Fax(Fax,[OrganizationId])
	VALUES(@Fax,@OrganizationId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[FaxDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[Fax]
	WHERE Id = @Id 
END
' 
END
GO
/****** Object:  Table [Navigator].[ReportModuleLink]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [Navigator].[ReportModuleLink](
	[Id] [numeric](10, 0) NOT NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[ModuleId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_ReportModuleLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [Invoice].[ReportArtifact]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[ReportArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ReportId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_ReportArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_ReportArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [Customer].[ReportArtifact]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportArtifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customer].[ReportArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ReportId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_ReportArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_ReportArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [Guardian].[ProfileContactNumber]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]') AND type in (N'U'))
BEGIN
CREATE TABLE [Guardian].[ProfileContactNumber](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[UserId] [numeric](10, 0) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProfileContactNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Guardian].[ProfileContactNumber] ON
INSERT [Guardian].[ProfileContactNumber] ([Id], [UserId], [ContactNumber]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'+91-6666666666')
INSERT [Guardian].[ProfileContactNumber] ([Id], [UserId], [ContactNumber]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'+91-44-23456789')
INSERT [Guardian].[ProfileContactNumber] ([Id], [UserId], [ContactNumber]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(12 AS Numeric(10, 0)), N'+91-99-99999999')
SET IDENTITY_INSERT [Guardian].[ProfileContactNumber] OFF
/****** Object:  Table [Invoice].[PaymentArtifact]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[PaymentArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[PaymentId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_PaymentArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_PaymentArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Invoice].[PaymentArtifact] ON
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(113 AS Numeric(10, 0)), NULL, CAST(703 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(114 AS Numeric(10, 0)), NULL, CAST(704 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(115 AS Numeric(10, 0)), CAST(75 AS Numeric(10, 0)), CAST(705 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(116 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)), CAST(710 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(117 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)), CAST(713 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(118 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), CAST(718 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(119 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), CAST(719 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(120 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), CAST(728 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Invoice].[PaymentArtifact] OFF
/****** Object:  StoredProcedure [Invoice].[PaymentUpdate]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentUpdate]
(
	@Id Numeric(10,0),
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Invoice.Payment
	SET
		InvoiceId = @InvoiceId,
		[Date] = GETDATE()
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[ProfileUpdate]
(
	@Initial Numeric(10,0),
	@FirstName Varchar(50),
	@MiddleName Varchar(50) = Null,
	@LastName Varchar(50),
	@Dob DateTime,
	@Id Numeric(10,0)
)
AS
BEGIN

	Declare @Cnt Int
	Select @Cnt = COUNT(*) From [Profile] Where UserId = @Id
	If @Cnt > 0
	Begin	
		UPDATE Guardian.[Profile]
		SET	
			Initial = @Initial,
			FirstName = @FirstName,
			MiddleName = @MiddleName,
			LastName = @LastName,
			Dob = @Dob
		WHERE UserId = @Id
	End
	Else
	Begin
		Insert into [Profile](UserId,Initial,FirstName,MiddleName,LastName,Dob)
		values(@Id,@Initial,@FirstName,ISNULL(@MiddleName,''''),@LastName,@Dob)
	End
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[ProfileRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT UserId, Initial, FirstName, MiddleName, LastName, Dob
	FROM Guardian.[Profile] WITH (NOLOCK)
	WHERE UserId = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[ProfileDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 
	FROM Guardian.[Profile]
	WHERE UserId = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].RoomReservation
	WHERE Id = @Id 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdateStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationUpdateStatus]
	(	
		@ProductId Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].[RoomReservation]
		SET	
			[StatusId] = @StatusId
		WHERE Id = @ProductId 
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationUpdate]
	(	
		@Id Numeric(10,0),
		@ActivityDate DateTime,
		@StatusId Numeric(10,0),
		@NoOfDays Numeric(3,0),	
		@NoOfRooms	TinyInt,
		@RoomCategoryId Numeric(10,0) = Null,
		@RoomTypeId Numeric(10,0) = Null,
		@ACPreference Int,		
		@NoOfMale TinyInt,
		@NoOfFemale	TinyInt,
		@NoOfChild TinyInt,
		@NoOfInfant	TinyInt,
		@Remark Varchar(MAX)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].[RoomReservation]
		SET				
			[BookingFrom] = @ActivityDate,
			[StatusId] = @StatusId,
			[NoOfDays] = @NoOfDays,		
			[NoOfRooms] = @NoOfRooms,		
			[RoomCategoryId] = @RoomCategoryId,
			[RoomTypeId] = @RoomTypeId,
			[AcRoomPreference] = @ACPreference,
			[NoOfMale] = @NoOfMale,
			[NoOfFemale] = @NoOfFemale,
			[NoOfChild] = @NoOfChild,
			[NoOfInfant] = @NoOfInfant,
			[Remark] = @Remark
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  Table [Lodge].[RoomReservationArtifact]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomReservationArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[RoomReservationId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_RoomReservationArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_RoomReservationArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Lodge].[RoomReservationArtifact] ON
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(146 AS Numeric(10, 0)), NULL, CAST(700 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(147 AS Numeric(10, 0)), NULL, CAST(701 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(148 AS Numeric(10, 0)), CAST(169 AS Numeric(10, 0)), CAST(702 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(149 AS Numeric(10, 0)), CAST(170 AS Numeric(10, 0)), CAST(706 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(150 AS Numeric(10, 0)), CAST(171 AS Numeric(10, 0)), CAST(708 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(151 AS Numeric(10, 0)), CAST(172 AS Numeric(10, 0)), CAST(711 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(155 AS Numeric(10, 0)), CAST(175 AS Numeric(10, 0)), CAST(727 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(156 AS Numeric(10, 0)), CAST(176 AS Numeric(10, 0)), CAST(729 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(157 AS Numeric(10, 0)), CAST(177 AS Numeric(10, 0)), CAST(731 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(158 AS Numeric(10, 0)), CAST(178 AS Numeric(10, 0)), CAST(735 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(159 AS Numeric(10, 0)), CAST(179 AS Numeric(10, 0)), CAST(738 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(160 AS Numeric(10, 0)), CAST(180 AS Numeric(10, 0)), CAST(741 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Lodge].[RoomReservationArtifact] OFF
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--select * from [Lodge].[RoomReservation]

CREATE PROCEDURE [Lodge].[RoomReservationReadAll]
AS
BEGIN
	
	SELECT 
		Id, BookingFrom, StatusId, NoOfDays, NoOfRooms, CreatedDate,
		IsCheckedIn, RoomCategoryId, RoomTypeId, AcRoomPreference,
		NoOfMale, NoOfFemale, NoOfChild, NoOfInfant,
		Remark
	FROM Lodge.RoomReservation WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
		
	SELECT
		Id, BookingFrom, StatusId, NoOfDays, NoOfRooms, CreatedDate,
		IsCheckedIn, RoomCategoryId, RoomTypeId, AcRoomPreference,
		NoOfMale, NoOfFemale, NoOfChild, NoOfInfant,
		Remark	
	FROM Lodge.RoomReservation WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  Table [Lodge].[RoomReservationPayment]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomReservationPayment](
	[RoomReservationId] [numeric](10, 0) NOT NULL,
	[PaymentId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_RoomReservationPayment] PRIMARY KEY CLUSTERED 
(
	[RoomReservationId] ASC,
	[PaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationInsert]
	(  
		@ActivityDate DateTime,
		@StatusId Numeric(10,0),
		@NoOfDays numeric(3, 0),		
		@NoOfRooms	tinyint,
		@RoomCategoryId Numeric(10,0) = Null,
		@RoomTypeId Numeric(10,0) = Null,
		@ACPreference Int,		
		@NoOfMale tinyint,
		@NoOfFemale	tinyint,
		@NoOfChild tinyint,
		@NoOfInfant	tinyint,
		@Remark varchar(MAX),		
		@Id  Numeric(10,0) OUTPUT	
	)
	AS
	BEGIN	
		
		INSERT INTO Lodge.RoomReservation(BookingFrom, StatusId, NoOfDays, NoOfRooms,
			RoomCategoryId, RoomTypeId, AcRoomPreference,
			NoOfMale, NoOfFemale, NoOfChild, NoOfInfant,
			Remark, CreatedDate)
		VALUES(@ActivityDate, @StatusId, @NoOfDays, @NoOfRooms,
			@RoomCategoryId, @RoomTypeId, @ACPreference,
			@NoOfMale, @NoOfFemale, @NoOfChild, @NoOfInfant,
			@Remark, GETDATE())
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SearchUserByLoginId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SearchUserByLoginId]
(
	@LoginId Varchar(15)
)
AS
BEGIN
	
	SELECT 
		Id, LoginId, [Password]
	FROM Guardian.Account
	WHERE LoginId = @LoginId
	
	SELECT UserId, RoleId
	FROM Guardian.UserRole
	WHERE UserId = (SELECT Id
		FROM Guardian.Account
		WHERE LoginId = @LoginId)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffUpdate]
(
	@Id Numeric(10,0),
	@CategoryId Numeric(10,0),
	@TypeId Numeric(10,0),
	@IsAC Bit,
	@StartDate DateTime,
	@EndDate DateTime,
	@Rate Money	
)
AS
BEGIN
	
	UPDATE [Lodge].RoomTariff
	SET	
		CategoryId = @CategoryId,	
		TypeId = TypeId,
		IsAirConditioned = @IsAC,
		StartDate = Convert(varchar(11), @StartDate,101), -- Removing Time,
		EndDate = Convert(varchar(11), @EndDate,101),	-- Removing Time,
		Rate = @Rate
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffReadAll]
As
BEGIN

	SELECT   
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate
	FROM [Lodge].RoomTariff WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT   
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate
	FROM [Lodge].RoomTariff WITH (NOLOCK)
	WHERE Id = @Id     
	
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[StateUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE [Configuration].State
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[StateReadDuplicate]
(
	@Name VARCHAR(50)		
)
AS
BEGIN

	SELECT Id	
	FROM Configuration.State WITH (NOLOCK)
	WHERE Name = @Name	
				
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[StateReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.State WITH (NOLOCK)
   
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[StateRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	
   SELECT Id, Name
   FROM Configuration.State WITH (NOLOCK)
   WHERE Id = @Id   
   
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[StateInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Configuration].State([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[StateDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Configuration].State
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityAnswerUpdate]
(
	@UserId Numeric(10,0),
	@QuestionId Numeric(10,0),
	@Answer Varchar(50),
	@Id  Numeric(10,0) 
)
AS
BEGIN
	Declare @cnt Int
	Select @cnt=COUNT(*) from Guardian.SecurityAnswer where UserId = @UserId
	
	if @cnt>0
	Begin	
		UPDATE Guardian.SecurityAnswer
		SET	
			--UserId = @UserId,
			QuestionId = @QuestionId,
			Answer = @Answer
		WHERE UserId = @UserId
   End
   Else
   Begin
		Insert Into Guardian.SecurityAnswer(UserId,QuestionId,Answer)
		values(@UserId,@QuestionId,@Answer)
   End
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityAnswerReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		UserId,
		QuestionId,
		Answer
	FROM Guardian.SecurityAnswer WITH (NOLOCK)
	WHERE UserId = @ParentId
	   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityAnswerRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, UserId, QuestionId, Answer 		
	FROM Guardian.SecurityAnswer WITH (NOLOCK)
	WHERE UserId = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 01/01/2015 10:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityAnswerInsert]
(
	@UserId Numeric(10,0),
	@QuestionId Numeric(10,0),
	@Answer Varchar(50),
	@Id Numeric(10,0) OUT
)
AS
BEGIN

	INSERT INTO Guardian.SecurityAnswer (UserId, QuestionId, Answer)
	VALUES(@UserId, @QuestionId, @Answer)   
	SET @Id = @@IDENTITY
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[SecurityAnswerDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Guardian.SecurityAnswer
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--		[Lodge].[TariffReadDuplicate] 4,''03-12-2013'', ''03-24-2013''

CREATE PROCEDURE [Lodge].[TariffReadDuplicate]
(
	@RoomId Numeric(10,0),
	@StartDate DateTime,
	@EndDate DateTime
)
AS
BEGIN

	SELECT 
		RT.Id,
		RT.Rate,
		RT.StartDate,
		RT.EndDate,
		RT.Id
	FROM [Lodge].RoomTariff RT WITH (NOLOCK)
	WHERE Id = @RoomId
		AND (
			cast(convert(char(11), @StartDate, 113) as datetime) BETWEEN cast(convert(char(11), StartDate, 113) as datetime) AND cast(convert(char(11), EndDate, 113) as datetime)
			OR cast(convert(char(11), @EndDate, 113) as datetime) BETWEEN cast(convert(char(11), StartDate, 113) as datetime) AND cast(convert(char(11), EndDate, 113) as datetime)
			OR cast(convert(char(11), StartDate, 113) as datetime) BETWEEN cast(convert(char(11), @StartDate, 113) as datetime) AND cast(convert(char(11), @EndDate, 113) as datetime)
			OR cast(convert(char(11), EndDate, 113) as datetime) BETWEEN cast(convert(char(11), @StartDate, 113) as datetime) AND cast(convert(char(11), @EndDate, 113) as datetime)
		)
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllFuture]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[TariffReadAllFuture]
AS
BEGIN
	
	SELECT 
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate
	FROM RoomTariff WITH (NOLOCK)
	WHERE CAST(FLOOR(CAST(EndDate AS float)) AS datetime) > CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllCurrent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[TariffReadAllCurrent]
AS
BEGIN
	
	SELECT 
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate
	FROM [Lodge].RoomTariff WITH (NOLOCK)
	WHERE CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime) >= CAST(FLOOR(CAST(StartDate AS float)) AS datetime)
		AND CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime) <= CAST(FLOOR(CAST(EndDate AS float)) AS datetime)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffIsExist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[TariffIsExist]
(  
	@CategoryId Numeric(10,0),
	@TypeId Numeric(10,0),
	@IsAC Bit,
	@StartDate DateTime,
	@EndDate DateTime
)
AS
BEGIN	
	
	-- removing time from date
	Set @StartDate = cast(convert(char(11), @StartDate, 113) as datetime) 
	Set @EndDate = cast(convert(char(11), @EndDate, 113) as datetime) 
	
	Select 
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate 
	From RoomTariff
	Where CategoryId = @CategoryId
	And TypeId = @TypeId
	And IsAirConditioned = @IsAC
	And 
	(
		(
			(CAST(FLOOR(CAST(StartDate AS float)) AS datetime) >= @StartDate)
			And
			(CAST(FLOOR(CAST(StartDate AS float)) AS datetime) <= @EndDate)
		)
	Or
		(
			(CAST(FLOOR(CAST(EndDate AS float)) AS datetime) >= @StartDate)
			And
			(CAST(FLOOR(CAST(EndDate AS float)) AS datetime) <= @EndDate)
		)
	Or
		(
			(@StartDate >= CAST(FLOOR(CAST(StartDate AS float)) AS datetime))
			And
			(@EndDate <=CAST(FLOOR(CAST(StartDate AS float)) AS datetime))
		)
	Or
		(
			(@StartDate >= CAST(FLOOR(CAST(EndDate AS float)) AS datetime))
			And
			(@EndDate <= CAST(FLOOR(CAST(EndDate AS float)) AS datetime))
		)
	)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationStatusToCheckIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create Procedure [Lodge].[UpdateReservationStatusToCheckIn]
(
	@ReservationId Numeric(10,0)
)
As
Begin
	Update [Lodge].RoomReservation
	Set IsCheckedIn = 1
	Where [Lodge].RoomReservation.Id = @ReservationId
End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationAfterCheckIn]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationAfterCheckIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [Lodge].[UpdateReservationAfterCheckIn]
(
	@ReservationId Numeric(10,0)
)
As
Begin
	Update Lodge.RoomReservation 
	Set IsCheckedIn = 0
	where ID = @ReservationId
End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffInsert]
	(  
		@CategoryId Numeric(10,0),
		@TypeId Numeric(10,0),
		@IsAC Bit,
		@StartDate DateTime,
		@EndDate DateTime,
		@Rate Money,
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		INSERT INTO [Lodge].RoomTariff(CategoryId,TypeId,IsAirConditioned,StartDate,EndDate,Rate)
		VALUES(
			@CategoryId, 
			@TypeId, 
			@IsAC, 
			Convert(varchar(11), @StartDate,101), -- Removing Time
			Convert(varchar(11), @EndDate,101),	-- Removing Time	
			@Rate)	
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].RoomTariff
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[SlabReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId Id, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab WITH (NOLOCK)
	WHERE TaxId = @ParentId	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadAll]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[SlabReadAll]
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab WITH (NOLOCK)	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[SlabRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[SlabRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab WITH (NOLOCK)
	WHERE TaxId = @Id	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[UserRoleUpdate]
(  
   @UserId Numeric(10,0),
   @RoleId Numeric(10,0)
)
AS
BEGIN
	UPDATE Guardian.UserRole
	SET RoleId = @RoleId  
	WHERE UserId = @UserId
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[UserRoleReadAll]
AS
BEGIN

	SELECT UserId, RoleId		
	FROM Guardian.UserRole WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[UserRoleRead]
(
	@UserId Numeric(10,0)
)
AS
BEGIN

	SELECT UserId, RoleId		
	FROM Guardian.UserRole WITH (NOLOCK)
	WHERE UserId = @UserId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[UserRoleInsert]
(  
   @UserId Numeric(10,0),
   @RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
   INSERT INTO Guardian.UserRole (UserId, RoleId)
   VALUES(@UserId, @RoleId)
   SET @Id = 0
   --SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[UserRoleDelete]
(
	@UserId Numeric(10,0)
)
AS
BEGIN	
	DELETE 		
	FROM Guardian.UserRole
	WHERE UserId = @UserId
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadInvoiceReportForArtifact]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[ReadInvoiceReportForArtifact]
(
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	
	SELECT 
		Id,
		ReportId
	FROM [Invoice].ReportArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
		AND Category =  @Category
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[UpdateInvoiceNumber]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateInvoiceNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[UpdateInvoiceNumber]
	(	
		@Id Numeric(10,0),
		@InvoiceNumber Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].CheckIn
		SET	
			[InvoiceNumber] = @InvoiceNumber
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateCheckInStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[UpdateCheckInStatus]
	(	
		@Id Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].CheckIn
		SET	
			[StatusId] = @StatusId
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  Table [Lodge].[RoomReservationAttachment]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomReservationAttachment](
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[AttachmentId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_RoomReservationAttachment] PRIMARY KEY CLUSTERED 
(
	[ArtifactId] ASC,
	[AttachmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [Lodge].[RoomReservationAttachment] ([ArtifactId], [AttachmentId]) VALUES (CAST(702 AS Numeric(10, 0)), CAST(705 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationAttachment] ([ArtifactId], [AttachmentId]) VALUES (CAST(708 AS Numeric(10, 0)), CAST(710 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationAttachment] ([ArtifactId], [AttachmentId]) VALUES (CAST(711 AS Numeric(10, 0)), CAST(713 AS Numeric(10, 0)))
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactUpdateLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0)        
)
AS
BEGIN
 
	UPDATE Lodge.RoomReservationArtifact
	SET [RoomReservationId] = @ComponentId
	WHERE [ArtifactId] = @ArtifactId
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT RoomReservationId ComponentId
	FROM Lodge.RoomReservationArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactInsertLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Lodge.RoomReservationArtifact([RoomReservationId],[ArtifactId], [Category])
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactDeleteLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM [Lodge].RoomReservationArtifact
	WHERE ArtifactId = @Id   
   
END
' 
END
GO
/****** Object:  Table [Lodge].[Room]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[Room]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[Room](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[CategoryId] [numeric](10, 0) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[BuildingId] [numeric](10, 0) NOT NULL,
	[FloorId] [numeric](10, 0) NOT NULL,
	[IsAirConditioned] [bit] NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	[Accomodation] [smallint] NOT NULL,
	[ExtraAccomodation] [smallint] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[Room] ON
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(1 AS Numeric(10, 0)), N'101', N'Holud', N'Yellow tiles floor', CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(22 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 1, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(2 AS Numeric(10, 0)), N'102', N'Lal', N'Read interior room', CAST(3 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(22 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 2)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(3 AS Numeric(10, 0)), N'101', N'Baishakh', N'Full sun paint in roof', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(4 AS Numeric(10, 0)), N'102', N'Jaistha', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(5 AS Numeric(10, 0)), N'103', N'Aashadh', N'Room with cloudy sky painting on roof', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(6 AS Numeric(10, 0)), N'104', N'Shraban', N'Rainy wall painting', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(7 AS Numeric(10, 0)), N'201', N'Bhaadra', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 2)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(8 AS Numeric(10, 0)), N'202', N'Aashin', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(9 AS Numeric(10, 0)), N'203', N'Kartik', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 2)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(10 AS Numeric(10, 0)), N'204', N'Aghran', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(11 AS Numeric(10, 0)), N'301', N'Paush', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(12 AS Numeric(10, 0)), N'302', N'Maagh', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 2)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(13 AS Numeric(10, 0)), N'303', N'Falgun', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(14 AS Numeric(10, 0)), N'304', N'Chaitra', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)), 2, 1)
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId], [Accomodation], [ExtraAccomodation]) VALUES (CAST(17 AS Numeric(10, 0)), N'101', N'Service Room 01', N'', CAST(3 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), CAST(16 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)), 0, CAST(10001 AS Numeric(10, 0)), 2, 2)
SET IDENTITY_INSERT [Lodge].[Room] OFF
/****** Object:  StoredProcedure [Lodge].[IsReservationDeletable]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsReservationDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[IsReservationDeletable] 
(	
	@ReservationId Numeric(10,0)
)
AS
BEGIN
	
	SELECT C.CheckInDate, R.NoOfDays 
	FROM Lodge.CheckIn C WITH (NOLOCK)
	Inner Join Lodge.RoomReservation R WITH (NOLOCK) On C.ReservationId = R.Id
	WHERE C.ReservationId = @ReservationId
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[ProfileContactNumberReadForParent] 
(
	@ParentId Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		UserId,		
		ContactNumber
	FROM Guardian.ProfileContactNumber
	WHERE UserId = @ParentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[ProfileContactNumberRead] 
(
	@Id Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		UserId,		
		ContactNumber
	FROM Guardian.ProfileContactNumber WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Guardian].[ProfileContactNumberInsert]
(  
   @UserId Numeric(10,0),
   @ContactNumber Varchar(50),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN   
   INSERT INTO Guardian.ProfileContactNumber(UserId, ContactNumber)
   VALUES(@UserId, @ContactNumber)   
   SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[ProfileContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN	
	DELETE 		
	FROM ProfileContactNumber
	WHERE Id = @Id   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadIdFromArtifact]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadIdFromArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentReadIdFromArtifact]
( 
	@ArtifactId Numeric(10,0)
)
AS
BEGIN

	SELECT PaymentId
	FROM Invoice.PaymentArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId

END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReadCustomerReportForArtifact]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReadCustomerReportForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ReadCustomerReportForArtifact]
(
	@ArtifactId Numeric(10,0)--,
	--@Category Numeric(1)
)
AS
BEGIN
	
	SELECT  Id, ReportId
	FROM Customer.ReportArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
		--AND Category =  @Category
	
END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadArtifactForInvoiceNumber]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadArtifactForInvoiceNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[ReadArtifactForInvoiceNumber] 
(
	@InvoiceNumber Varchar(50)
)
AS
BEGIN

	SELECT ArtifactId
	FROM [Invoice].Artifact WITH (NOLOCK)
	WHERE InvoiceId = (SELECT ID 
		FROM Invoice.Invoice WITH (NOLOCK)
		WHERE InvoiceNumber = @InvoiceNumber)

END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomReservationId]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadRoomReservationId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[ReadRoomReservationId]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN

	SELECT RoomReservationId
	FROM Lodge.RoomReservationArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId

END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactUpdateLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	UPDATE [Invoice].Artifact
	SET [InvoiceId] = @ComponentId
	WHERE [ArtifactId] = @ArtifactId
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactReadLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT InvoiceId ComponentId
	FROM Invoice.Artifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactInsertLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO [Invoice].Artifact([InvoiceId],[ArtifactId],[Category])
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactDeleteLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM [Invoice].[Artifact]
	WHERE ArtifactId = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceReportForArtifact]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InsertInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InsertInvoiceReportForArtifact]
(
        @ReportId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO [Invoice].ReportArtifact([ReportId],[ArtifactId],[Category])
        VALUES(@ReportId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemTaxationRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemTaxationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[LineItemTaxationRead]
( 
	@LineItemId Numeric(10,0)
)
AS
BEGIN 

	SELECT * --Id, TaxName,TaxAmount,IsPercentage,LineItemId
	FROM Invoice.LineItemTaxation WITH (NOLOCK)
	WHERE LineItemId = @LineItemId

END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemTaxationInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemTaxationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Invoice].[LineItemTaxationInsert]
( 
@LineItemId Numeric(10,0),
@TaxName Varchar(50), 
@TaxAmount money, 
@IsPercentage Bit,
@Id Numeric(10,0) OUTPUT
)
AS
BEGIN 

INSERT INTO [Invoice].[LineItemTaxation]([TaxName],[TaxAmount],[IsPercentage],[LineItemId])
VALUES(@TaxName,@TaxAmount,@IsPercentage,@LineItemId)

SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemUpdate]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentLineItemUpdate]
(
	@Id Numeric(10,0),
	@Reference Varchar(16),
	@Amount Numeric(10,2),
	@PaymentTypeId Numeric(10,0),
	@Remark Varchar(255),
	@PaymentId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Invoice.PaymentLineItem
	SET			
		Reference = @Reference,
		Amount = @Amount,
		PaymentTypeId = @PaymentTypeId,
		Remark = @Remark,
		PaymentId = @PaymentId
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentLineItemReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reference, Amount, PaymentTypeId,
		Remark, PaymentId
	FROM Invoice.PaymentLineItem WITH (NOLOCK)
	WHERE PaymentId = @ParentId	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemReadAll]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentLineItemReadAll]
AS
BEGIN
	
	SELECT
		Id,
		Reference,
		Amount,
		PaymentTypeId,
		Remark,
		PaymentId
	FROM Invoice.PaymentLineItem WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentLineItemRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		Reference,
		Amount,
		PaymentTypeId,
		Remark,
		PaymentId
	FROM Invoice.PaymentLineItem WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentLineItemInsert]
(  	
	@Reference Varchar(16),
	@Remark Varchar(255),
	@Amount money,
	@PaymentTypeId Numeric(10,0),
	@PaymentId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
	
	INSERT INTO Invoice.PaymentLineItem(PaymentTypeId, Reference, Remark, Amount, PaymentId)
	VALUES(@PaymentTypeId, @Reference, @Remark, @Amount, @PaymentId)
    
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentLineItemDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentLineItemDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentLineItemDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE
	FROM Invoice.PaymentLineItem
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactUpdateLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentArtifactUpdateLink]
(
        @ComponentId Numeric(10,0),
        @ArtifactId Numeric(10,0)
)
AS
BEGIN
	UPDATE Invoice.PaymentArtifact
	SET PaymentId = @ComponentId
	WHERE ArtifactId = @ArtifactId
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactReadLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT PaymentId ComponentId
	FROM Invoice.PaymentArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactInsertLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentArtifactInsertLink]
(
        @ComponentId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO Invoice.PaymentArtifact(PaymentId, ArtifactId, Category)
        VALUES(@ComponentId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactDeleteLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
 DELETE FROM [Invoice].[PaymentArtifact]
 WHERE ArtifactId = @Id   
 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingFloorReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[BuildingId],
		[FLOOR]
	FROM [Lodge].BuildingFloor WITH (NOLOCK)
	WHERE BuildingId = @ParentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingFloorRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[FLOOR],			
		[BuildingId]
	FROM [Lodge].BuildingFloor WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingFloorInsert]
	(  
		@Name Varchar(50),	
		@BuildingId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingFloor([Floor],[BuildingId])
		VALUES(@Name,@BuildingId)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingFloorDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingFloor
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonReadForParent]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingClosureReasonReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[BuildingId],
		[Reason],
		[ClosedDate]
	FROM [Lodge].BuildingClosureReason WITH (NOLOCK)
	WHERE BuildingId = @ParentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingClosureReasonRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Reason],			
		[BuildingId],
		[ClosedDate]
	FROM [Lodge].BuildingClosureReason WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingClosureReasonInsert]
	(  
		@Reason Varchar(50),	
		@BuildingId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingClosureReason([Reason],[BuildingId],ClosedDate)
		VALUES(@Reason,@BuildingId,GETDATE())
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingClosureReasonDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingClosureReason
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactSearchByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactSearchByName]
(  
	@FileName Varchar(50)
)
AS
BEGIN	
	SELECT A.Id, [FileName], [Path], Extension, Style, [Version], ParentId, 
		CreatedAt, CreatedByUserId,
		P1.FirstName AS CreatedByFirstName, P1.MiddleName AS CreatedByMiddleName, P1.LastName AS CreatedByLastName, 
		ModifiedAt, ModifiedByUserId,
		P2.FirstName AS ModifiedByFirstName, P2.MiddleName AS ModifiedByMiddleName, P2.LastName AS ModifiedByLastName,
		M.Id ModuleId, M.Code ModuleCode, M.Name ModuleName, Category
	FROM (SELECT * FROM Navigator.Artifact WHERE [FileName] LIKE ''%'' + @FileName + ''%'') As A
	LEFT OUTER JOIN Guardian.[Profile] AS P1 ON A.CreatedByUserId = P1.UserId
	LEFT OUTER JOIN Guardian.[Profile] AS P2 ON A.ModifiedByUserId = P2.UserId
	INNER JOIN Navigator.ArtifactComponentLink AS AML ON ArtifactId = A.Id
	INNER JOIN License.Component AS M ON M.Id = AML.ComponentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactDelete]
(  
	@Id Numeric(10,0)
)
AS
BEGIN 
 
	DELETE FROM [Navigator].ArtifactComponentLink
	WHERE ArtifactId = @Id
 
	DELETE FROM [Navigator].Artifact
	WHERE ID = @Id
	   
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForComponent]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkReadForComponent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactComponentLinkReadForComponent]
(  
	@ComponentId  Numeric(10,0),
	@Category Numeric(1,0)
)
AS
BEGIN

	SELECT Artf.Id, [FileName], [Path], Extension, Style, [Version], ParentId,
		CreatedByUserId, CP.FirstName CreatedByFirstName, CP.MiddleName CreatedByMiddleName, CP.LastName CreatedByLastName, CreatedAt,
		ModifiedByUserId, MP.FirstName ModifiedByFirstName, MP.MiddleName ModifiedByMiddleName, Mp.LastName ModifiedByLastName, ModifiedAt,
		Comp.Id ComponentId, Comp.Code ComponentCode, Comp.Name ComponentName
	FROM Navigator.ArtifactComponentLink AML WITH (NOLOCK)
		INNER JOIN Navigator.Artifact Artf WITH (NOLOCK) ON AML.ArtifactId = Artf.Id
		INNER JOIN Guardian.Profile CP WITH (NOLOCK) ON UserId = CreatedByUserId
		LEFT OUTER JOIN Guardian.Profile MP WITH (NOLOCK) ON MP.UserId = ModifiedByUserId
		INNER JOIN License.Component Comp WITH (NOLOCK) ON AML.ComponentId = Comp.Id
	WHERE ComponentId = @ComponentId
		AND Category = @Category
		--AND A.ParentId IS NULL
		
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForArtifact]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkReadForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactComponentLinkReadForArtifact]
(
	@ArtifactId Numeric(10, 0)
)
AS
BEGIN

	SELECT ComponentId, Category
	FROM Navigator.ArtifactComponentLink WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkInsertForComponent]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkInsertForComponent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactComponentLinkInsertForComponent]
(
	@ArtifactId  Numeric(10,0),
    @ComponentId  Numeric(10,0),
    @Category Numeric(1,0)
)
AS
BEGIN
	
	INSERT INTO Navigator.ArtifactComponentLink(ArtifactId,ComponentId, Category)
    VALUES(@ArtifactId, @ComponentId, @Category)
 
END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentArtifactUpdateLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	UPDATE Invoice.AdvancePaymentArtifact
	SET AdvancePaymentId = @ComponentId
	WHERE ArtifactId = @ArtifactId
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentArtifactReadLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN

	SELECT Id, AdvancePaymentId
	FROM Invoice.AdvancePaymentArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentArtifactInsertLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	INSERT INTO Invoice.AdvancePaymentArtifact(AdvancePaymentId, ArtifactId)
	VALUES(@ComponentId, @ArtifactId) 
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[AdvancePaymentArtifactDeleteLink]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[AdvancePaymentArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN 
	DELETE FROM Invoice.AdvancePaymentArtifact
	WHERE ArtifactId = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--"[Lodge].[CheckInInsert]"
CREATE PROCEDURE [Lodge].[CheckInInsert]
	(  
		--@Advance Money,
		@ReservationId Numeric(10,0),		
		@ActivityDate DateTime,		
		@StatusId Numeric(10,0),
		@Purpose Varchar(Max),
		@ArrivedFrom Varchar(Max),
		@Remark Varchar(Max),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].CheckIn([CheckInDate],
		--[Advance],
		[CreatedDate],[ReservationId],[StatusId],[Purpose],[ArrivedFrom],[Remark])
		VALUES(@ActivityDate,
		--@Advance,
		GETDATE(),@ReservationId,@StatusId,@Purpose,@ArrivedFrom,@Remark)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].CheckIn
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  Table [Lodge].[CheckInArtifact]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[CheckInArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CheckInId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_CheckInArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_CheckInArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Lodge].[CheckInArtifact] ON
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(53 AS Numeric(10, 0)), CAST(36 AS Numeric(10, 0)), CAST(707 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(54 AS Numeric(10, 0)), NULL, CAST(714 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(55 AS Numeric(10, 0)), NULL, CAST(715 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(56 AS Numeric(10, 0)), NULL, CAST(716 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(37 AS Numeric(10, 0)), CAST(717 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(58 AS Numeric(10, 0)), NULL, CAST(720 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(59 AS Numeric(10, 0)), CAST(38 AS Numeric(10, 0)), CAST(721 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(61 AS Numeric(10, 0)), CAST(40 AS Numeric(10, 0)), CAST(733 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(62 AS Numeric(10, 0)), CAST(48 AS Numeric(10, 0)), CAST(734 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(63 AS Numeric(10, 0)), CAST(49 AS Numeric(10, 0)), CAST(737 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(64 AS Numeric(10, 0)), NULL, CAST(740 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Lodge].[CheckInArtifact] OFF
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInUpdate]
	(	
		@Id Numeric(10,0),		
		--@Advance Money,
		@ReservationId Numeric(10,0),		
		@ActivityDate DateTime,		
		@StatusId Numeric(10,0),
		@Purpose Varchar(Max),
		@ArrivedFrom Varchar(Max),
		@Remark Varchar(Max)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].CheckIn
		SET				
			[CheckInDate] = @ActivityDate,
			--[Advance] = @Advance,
			[ReservationId] = @ReservationId,
			[StatusId] = @StatusId,
			[Purpose] = @Purpose,
			[ArrivedFrom] = @ArrivedFrom,
			[Remark] = @Remark
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN		
	SELECT 
		Id,
		[CheckInDate],
		--[Advance],
		[CreatedDate],
		[ReservationId],
		[StatusId],
		[Purpose],
		[ArrivedFrom],
		[Remark],
		[InvoiceNumber]
	FROM [Lodge].CheckIn WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  Table [Customer].[CustomerContactNumber]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customer].[CustomerContactNumber](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[CustomerId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CustomerContactNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Customer].[CustomerContactNumber] ON
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1105 AS Numeric(10, 0)), N'+91-9827634058', CAST(128 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1106 AS Numeric(10, 0)), N'+91-9820982765', CAST(128 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1125 AS Numeric(10, 0)), N'+91-6523097856', CAST(130 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1126 AS Numeric(10, 0)), N'+91-6109452309', CAST(130 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1127 AS Numeric(10, 0)), N'+91-7829908746', CAST(127 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1128 AS Numeric(10, 0)), N'+91-9845610987', CAST(127 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1159 AS Numeric(10, 0)), N'+91-7865209809', CAST(133 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1160 AS Numeric(10, 0)), N'+91-9845017510', CAST(133 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1161 AS Numeric(10, 0)), N'+91-33-24328896', CAST(126 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1162 AS Numeric(10, 0)), N'+91-9886408746', CAST(126 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1185 AS Numeric(10, 0)), N'+91-9878765665', CAST(132 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1186 AS Numeric(10, 0)), N'+91-4509129845', CAST(132 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1187 AS Numeric(10, 0)), N'+91-8498092735', CAST(131 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(1188 AS Numeric(10, 0)), N'+91-8209275049', CAST(131 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Customer].[CustomerContactNumber] OFF
/****** Object:  Table [Customer].[CustomerArtifact]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customer].[CustomerArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CustomerId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL CONSTRAINT [DF_CustomerArtifact_Category]  DEFAULT ((1)),
 CONSTRAINT [PK_CustomerArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_CustomerArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'Customer', N'TABLE',N'CustomerArtifact', N'COLUMN',N'Category'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Form, 2 = Catalogue, 3 = Report' , @level0type=N'SCHEMA',@level0name=N'Customer', @level1type=N'TABLE',@level1name=N'CustomerArtifact', @level2type=N'COLUMN',@level2name=N'Category'
GO
SET IDENTITY_INSERT [Customer].[CustomerArtifact] ON
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(274 AS Numeric(10, 0)), NULL, CAST(678 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(275 AS Numeric(10, 0)), NULL, CAST(679 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(276 AS Numeric(10, 0)), NULL, CAST(680 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(277 AS Numeric(10, 0)), NULL, CAST(681 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(278 AS Numeric(10, 0)), NULL, CAST(682 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(279 AS Numeric(10, 0)), NULL, CAST(683 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(280 AS Numeric(10, 0)), NULL, CAST(684 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(281 AS Numeric(10, 0)), NULL, CAST(685 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(282 AS Numeric(10, 0)), NULL, CAST(686 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(283 AS Numeric(10, 0)), NULL, CAST(687 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(284 AS Numeric(10, 0)), NULL, CAST(688 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(285 AS Numeric(10, 0)), NULL, CAST(689 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(286 AS Numeric(10, 0)), NULL, CAST(690 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(287 AS Numeric(10, 0)), NULL, CAST(691 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(288 AS Numeric(10, 0)), NULL, CAST(692 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(289 AS Numeric(10, 0)), NULL, CAST(693 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(290 AS Numeric(10, 0)), NULL, CAST(694 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(291 AS Numeric(10, 0)), NULL, CAST(695 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(292 AS Numeric(10, 0)), NULL, CAST(696 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(293 AS Numeric(10, 0)), NULL, CAST(697 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(294 AS Numeric(10, 0)), NULL, CAST(698 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(295 AS Numeric(10, 0)), CAST(126 AS Numeric(10, 0)), CAST(699 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(296 AS Numeric(10, 0)), CAST(127 AS Numeric(10, 0)), CAST(709 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(297 AS Numeric(10, 0)), CAST(128 AS Numeric(10, 0)), CAST(712 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(299 AS Numeric(10, 0)), CAST(130 AS Numeric(10, 0)), CAST(726 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(300 AS Numeric(10, 0)), CAST(131 AS Numeric(10, 0)), CAST(730 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(301 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)), CAST(736 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(302 AS Numeric(10, 0)), CAST(133 AS Numeric(10, 0)), CAST(739 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Customer].[CustomerArtifact] OFF
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerReadAll]
As
BEGIN

	SELECT Id,
		--InitialId,
		FirstName,MiddleName,LastName,
		Address,CountryId,StateId,City,Pin,Email,
		IdentityProofId, IdentityProofName 
	FROM Customer.Customer WITH (NOLOCK)
	
END' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerRead]
(
	@Id Numeric(10,0)
)
As
BEGIN

	SELECT  Id,
		--InitialId,
		FirstName, MiddleName, LastName,
		Address, CountryId, StateId, City, Pin, Email,
		IdentityProofId, IdentityProofName 
	FROM Customer.Customer WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 01/01/2015 10:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerInsert]
	(  
		--@InitialId Numeric(10,0),
		@FirstName Varchar(50),
		@MiddleName Varchar(50),
		@LastName Varchar(50),
		@Address Varchar(255),
		@CountryId Numeric(10,0),
		@StateId Numeric(10,0),
		@City Varchar(50),
		@Pin Int,
		@Email Varchar(50),
		@IdentityProofId Numeric(10,0),
		@IdentityProofName Varchar(50),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		--IF @InitialId = 0
		--Begin
		--	Set @InitialId = null
		--End

		IF @IdentityProofId = 0
		Begin
			Set @IdentityProofId = null
		End
	
		INSERT INTO Customer.Customer(--[InitialId],
		[FirstName],[MiddleName],[LastName],
			[Address],[CountryId],[StateId],[City],[Pin],[Email],[IdentityProofId],[IdentityProofName])
		VALUES(--@InitialId,
		@FirstName,@MiddleName,@LastName,@Address,@CountryId,@StateId,@City,@Pin,@Email,@IdentityProofId,@IdentityProofName)
   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerDelete]
 (
	@Id Numeric(10,0)
 )
 As
 Begin
	Delete From Customer.Customer
	Where Id = @Id
 End
' 
END
GO
/****** Object:  Table [AutoTourism].[CustomerRoomReservationLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [AutoTourism].[CustomerRoomReservationLink](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CustomerId] [numeric](10, 0) NOT NULL,
	[RoomReservationId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CustomerRoomReservationLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [AutoTourism].[CustomerRoomReservationLink] ON
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(235 AS Numeric(10, 0)), CAST(126 AS Numeric(10, 0)), CAST(169 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(241 AS Numeric(10, 0)), CAST(128 AS Numeric(10, 0)), CAST(172 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(245 AS Numeric(10, 0)), CAST(130 AS Numeric(10, 0)), CAST(175 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(246 AS Numeric(10, 0)), CAST(131 AS Numeric(10, 0)), CAST(176 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(248 AS Numeric(10, 0)), CAST(130 AS Numeric(10, 0)), CAST(177 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(249 AS Numeric(10, 0)), CAST(127 AS Numeric(10, 0)), CAST(171 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(257 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)), CAST(178 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(263 AS Numeric(10, 0)), CAST(133 AS Numeric(10, 0)), CAST(179 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(264 AS Numeric(10, 0)), CAST(126 AS Numeric(10, 0)), CAST(170 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(276 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)), CAST(180 AS Numeric(10, 0)))
SET IDENTITY_INSERT [AutoTourism].[CustomerRoomReservationLink] OFF
/****** Object:  Table [AutoTourism].[CustomerRoomCheckInLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [AutoTourism].[CustomerRoomCheckInLink](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CustomerId] [numeric](10, 0) NOT NULL,
	[RoomCheckInId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CustomerRoomCheckInLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [AutoTourism].[CustomerRoomCheckInLink] ON
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(126 AS Numeric(10, 0)), CAST(36 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(128 AS Numeric(10, 0)), CAST(37 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(25 AS Numeric(10, 0)), CAST(130 AS Numeric(10, 0)), CAST(38 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(27 AS Numeric(10, 0)), CAST(127 AS Numeric(10, 0)), CAST(40 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(35 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)), CAST(48 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(36 AS Numeric(10, 0)), CAST(133 AS Numeric(10, 0)), CAST(49 AS Numeric(10, 0)))
SET IDENTITY_INSERT [AutoTourism].[CustomerRoomCheckInLink] OFF
/****** Object:  StoredProcedure [Customer].[CustomerReportArtifactInsertLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReportArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerReportArtifactInsertLink]
(
	@ReportId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO [Customer].ReportArtifact([ReportId],[ArtifactId],[Category])
	VALUES(@ReportId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerUpdate]
	(  
		@Id  Numeric(10,0),
		--@InitialId Numeric(10,0),
		@FirstName Varchar(50),
		@MiddleName Varchar(50),
		@LastName Varchar(50),
		@Address Varchar(255),
		@CountryId Numeric(10,0),
		@StateId Numeric(10,0),
		@City Varchar(50),
		@Pin Int,
		@Email Varchar(50),
		@IdentityProofId Numeric(10,0),
		@IdentityProofName Varchar(50)	
	)
	AS
	BEGIN	
		--IF @InitialId = 0
		--Begin
		--	Set @InitialId = null
		--End

		IF @IdentityProofId = 0
		Begin
			Set @IdentityProofId = null
		End
	
		UPDATE Customer.Customer
		Set --[InitialId] = @InitialId,
			[FirstName] = @FirstName,
			[MiddleName] = @MiddleName,
			[LastName] = @LastName,
			[Address] = @Address,
			[CountryId] = @CountryId,
			[StateId] = @StateId,
			[City] = @City,
			[Pin] = @Pin,
			[Email] = @Email,
			[IdentityProofId] = @IdentityProofId,
			[IdentityProofName] = @IdentityProofName
		Where Id = @Id
   
	END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[DeleteCustomerReportForArtifact]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[DeleteCustomerReportForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Customer].[DeleteCustomerReportForArtifact]
(
        @ReportId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO [Customer].ReportArtifact([ReportId],[ArtifactId],[Category])
        VALUES(@ReportId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[GetCustomerIdForReservation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [AutoTourism].[GetCustomerIdForReservation]
(  
	@ReservationId  Numeric(10,0)
)
AS
BEGIN	
	
	SELECT CustomerId
	FROM AutoTourism.CustomerRoomReservationLink WITH (NOLOCK)
	WHERE RoomReservationId = @ReservationId
	
END
' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [AutoTourism].[CustomerRoomReservationLinkRead]
(
	@CustomerId Numeric(10,0)
)
AS
BEGIN

	SELECT CustomerId, RoomReservationId
	FROM AutoTourism.CustomerRoomReservationLink WITH (NOLOCK)
	WHERE CustomerId = @CustomerId
	
END' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [AutoTourism].[CustomerRoomReservationLinkInsert]
(  
	@CustomerId  Numeric(10,0),
	@RoomReservationId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [AutoTourism].[CustomerRoomReservationLink]([CustomerId],[RoomReservationId])
	VALUES(@CustomerId,@RoomReservationId)
   
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [AutoTourism].[CustomerRoomReservationLinkDelete]
(  		
	@RoomReservationId  Numeric(10,0)
)
AS
BEGIN
	
	DELETE AutoTourism.CustomerRoomReservationLink
	WHERE RoomReservationId = @RoomReservationId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerReadDuplicate]
(
	@ContactNumber VARCHAR(100),
	@Email VARCHAR(50),
	@IdentityProofId INT,
	@IdentityProofName VARCHAR(50)
)
AS
BEGIN

	SELECT Id
	FROM Customer.Customer WITH (NOLOCK)
		WHERE (IdentityProofId = @IdentityProofId	
		AND IdentityProofName = @IdentityProofName)
		OR (Email = @Email AND @Email != '''')
		OR ID IN (SELECT CustomerId FROM CustomerContactNumber WITH (NOLOCK)
			WHERE Number IN (SELECT SplitText FROM Split(@ContactNumber, '','')))
END
' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkRead]
(
	@CustomerId Numeric(10,0)
)
As
BEGIN

	SELECT  CustomerId, RoomCheckInId
	FROM AutoTourism.CustomerRoomCheckInLink WITH (NOLOCK)
	WHERE CustomerId = @CustomerId
	
END
' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkInsert]
	(  
		@CustomerId  Numeric(10,0),
		@RoomCheckInId  Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [AutoTourism].[CustomerRoomCheckInLink]([CustomerId],[RoomCheckInId])
		VALUES(@CustomerId,@RoomCheckInId)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkDelete]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkDelete]
(  		
	@RoomCheckInId  Numeric(10,0)
)
AS
BEGIN
	
	DELETE AutoTourism.CustomerRoomCheckInLink
	WHERE RoomCheckInId = @RoomCheckInId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerContactNumberRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN

	SELECT Id, Number, CustomerId
	FROM Customer.CustomerContactNumber WITH (NOLOCK)
	WHERE CustomerId = @Id
	
END' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerContactNumberInsert]
(  
	@CustomerId Numeric(10,0),
	@ContactNumber Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN		

	INSERT INTO Customer.CustomerContactNumber([Number],[CustomerId])
	VALUES(@ContactNumber,@CustomerId)

	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN

	DELETE FROM Customer.CustomerContactNumber
	WHERE CustomerId = @Id
	  
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactUpdateLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
    @ArtifactId Numeric(10,0)        
)
AS
BEGIN
 
	UPDATE Customer.CustomerArtifact
    SET [CustomerId] = @ComponentId
    WHERE [ArtifactId] = @ArtifactId
    
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactReadLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT CustomerId ComponentId
	FROM Customer.CustomerArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactInsertLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Customer.CustomerArtifact([CustomerId],[ArtifactId], [Category])
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactDeleteLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Customer.CustomerArtifact
	WHERE ArtifactId = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactUpdateLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInArtifactUpdateLink]
(
    @ComponentId Numeric(10,0),
    @ArtifactId Numeric(10,0)
)
AS
BEGIN
 
	UPDATE Lodge.CheckInArtifact
	SET [CheckInId] = @ComponentId
	WHERE [ArtifactId] = @ArtifactId
 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactReadLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT CheckInId ComponentId
	FROM Lodge.CheckInArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactInsertLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Lodge.CheckInArtifact([CheckInId],[ArtifactId], [Category])
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactDeleteLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Lodge.CheckInArtifact
	WHERE ArtifactId = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsInitialDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[IsInitialDeletable]
(
	@InitialId NUMERIC(10,0)
)
AS
BEGIN

	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WITH (NOLOCK) WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer WITH (NOLOCK)
	WHERE InitialId = @InitialId

 END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsIdentityProofIdDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[IsIdentityProofIdDeletable]
(
	@IdentityProofId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WITH (NOLOCK) WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer WITH (NOLOCK)
	WHERE IdentityProofId = @IdentityProofId

 END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[IsStateIdDeletable]
(
	@StateId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WITH (NOLOCK) WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer WITH (NOLOCK)
	WHERE StateId = @StateId

 END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomCheckInId]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadRoomCheckInId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[ReadRoomCheckInId]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT CheckInId
	FROM Lodge.CheckInArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  Table [Lodge].[RoomClosureReason]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomClosureReason](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ClosedDate] [datetime] NOT NULL,
	[Reason] [varchar](256) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_RoomClosureReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Lodge].[RoomImage]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImage]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomImage](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Image] [image] NOT NULL,
 CONSTRAINT [PK_RoomImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].Room
	WHERE Id = @Id 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadOpenRoom]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReadOpenRoom] 
(
	@BuildingId numeric(10,0)
)
As
BEGIN

	SELECT id,Number,Name,StatusId 
	FROM Lodge.Room  WITH (NOLOCK)
	WHERE BuildingId = @BuildingId
		AND StatusId != 10002 -- Closed Room
		
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadClosedRoom]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadClosedRoom]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReadClosedRoom]
(
	@BuildingId numeric(10,0)
)
As
BEGIN	
	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room 
	WHERE BuildingId = @BuildingId
		AND StatusId = 10002 -- Closed Room
		
End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadCheckedInRoom]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Lodge].[RoomReadCheckedInRoom]
(
	@BuildingId numeric(10,0)
)
As
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK) 
	WHERE BuildingId = @BuildingId
		AND StatusId = 10003 -- Occupied Room
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactAttachmentReadLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactAttachmentReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationArtifactAttachmentReadLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT AttachmentId
	FROM Lodge.RoomReservationAttachment WITH (NOLOCK)
	WHERE ArtifactId = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactAttachmentInsertLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactAttachmentInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationArtifactAttachmentInsertLink]
(
	@Id Numeric(10,0),
	@AttachmentId Numeric(10,0)
)
AS
BEGIN
 
	INSERT INTO Lodge.RoomReservationAttachment(ArtifactId,AttachmentId)
	VALUES(@Id, @AttachmentId)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactAttachmentDeleteLink]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactAttachmentDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Lodge].[RoomReservationArtifactAttachmentDeleteLink]
(
	@AttachmentId Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM [Lodge].RoomReservationAttachment
	WHERE AttachmentId = @AttachmentId   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReadAll]
As
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE Id = @Id   
	
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomModifyStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomModifyStatus]
	(	
		@Id Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].Room
		SET	
			[StatusId] = @StatusId			
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomTypeDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomTypeDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [Lodge].[RoomIsRoomTypeDeletable]
(
	@TypeId NUMERIC(10,0)
)
As
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE TypeId = @TypeId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomStatusDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomStatusDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Lodge].[RoomIsRoomStatusDeletable]
(
	@RoomStatusId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE StatusId = @RoomStatusId

END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomCategoryDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomCategoryDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Lodge].[RoomIsRoomCategoryDeletable]
(
	@RoomCategoryId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE CategoryId = @RoomCategoryId

END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingFloorDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsBuildingFloorDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Lodge].[RoomIsBuildingFloorDeletable] 
(
	@FloorId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE FloorId = @FloorId

 END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsBuildingDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomIsBuildingDeletable]
(
	@BuildingId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE BuildingId = @BuildingId

END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomInsert]
(  
	@Number Varchar(50),	
	@Name Varchar(50),
	@Description Varchar(50),
	@CategoryId Numeric(10,0),		
	@TypeId Numeric(10,0),
	@BuildingId Numeric(10,0),
	@FloorId Numeric(10,0),
	@IsAirConditioned Bit,
	@Accomodation Smallint,
	@ExtraAccomodation Smallint,
	@StatusId Numeric(10,0),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Lodge.Room(Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned, Accomodation, ExtraAccomodation,
		StatusId)
	VALUES(@Number,@Name,@Description,@BuildingId,@FloorId,
		@CategoryId,@TypeId,@IsAirConditioned,@Accomodation, @ExtraAccomodation,
		@StatusId)
	
	SET @Id = @@IDENTITY
	
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomUpdate]
(	
	@Id Numeric(10,0),
	@Number Varchar(50),	
	@Name Varchar(50),
	@Description Varchar(50),
	@CategoryId Numeric(10,0),		
	@TypeId Numeric(10,0),
	@BuildingId Numeric(10,0),
	@FloorId Numeric(10,0),
	@IsAirConditioned Bit,
	@Accomodation Smallint,
	@ExtraAccomodation Smallint,		
	@StatusId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Lodge.Room
	SET	
		Number = @Number,
		Name = @Name,
		Description = @Description,
		CategoryId = @CategoryId,
		TypeId = @TypeId,
		BuildingId = @BuildingId,
		FloorId = @FloorId,
		IsAirConditioned = @IsAirConditioned,
		Accomodation = @Accomodation,
		ExtraAccomodation = @ExtraAccomodation
	WHERE Id = @Id
   
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffModifyRate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffModifyRate]
	(	
		@CategoryId Numeric(10,0),
		@TypeId Numeric(10,0),
		@Rate Money
	)
	AS
	BEGIN
		
		Update [Lodge].[RoomTariff]
		Set Rate = @Rate
		Where id in (
		Select id From [Lodge].[Room]
		Where CategoryId = @CategoryId
		And TypeId = @TypeId
		)
	   
	END
' 
END
GO
/****** Object:  Table [Lodge].[RoomReservationDetails]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [Lodge].[RoomReservationDetails](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
	[ReservationId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_RoomReservationDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Lodge].[RoomReservationDetails] ON
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(66 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), CAST(169 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(67 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(169 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(75 AS Numeric(10, 0)), CAST(14 AS Numeric(10, 0)), CAST(172 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(76 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), CAST(175 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(77 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(177 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(78 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(171 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(87 AS Numeric(10, 0)), CAST(17 AS Numeric(10, 0)), CAST(178 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(94 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(179 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(95 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(179 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(107 AS Numeric(10, 0)), CAST(14 AS Numeric(10, 0)), CAST(180 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(108 AS Numeric(10, 0)), CAST(13 AS Numeric(10, 0)), CAST(180 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Lodge].[RoomReservationDetails] OFF
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[RoomReservationSearch] 
	(
		@StartDate DateTime,
		@EndDate DateTime,
		@StatusId Numeric(10,0)
	)
	As
	Begin
		SELECT 
			R.Id, BookingFrom, StatusId, NoOfDays, NoOfRooms, CreatedDate, IsCheckedIn,
			R.RoomCategoryId, R.RoomTypeId, R.AcRoomPreference,
			RRD.RoomId AS ProductId,
			R.[NoOfMale], R.[NoOfFemale], R.[NoOfChild], R.[NoOfInfant],
			R.[Remark]
		FROM [Lodge].RoomReservation R WITH (NOLOCK)
		LEFT OUTER JOIN Lodge.RoomReservationDetails RRD WITH (NOLOCK) ON R.Id = RRD.ReservationId
		Where R.statusId = @StatusId
		And cast(convert(Char(11), R.BookingFrom, 113) AS DateTime) 
		Between cast(convert(Char(11), @StartDate, 113) AS DateTime) 		 
		And cast(convert(Char(11), @EndDate, 113) AS DateTime)		
		--And R.IsCheckedIn = 0
		order by R.Id, RRD.ReservationId
	End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRoomLinkRead]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRoomLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationRoomLinkRead]
(
   @ReservationId Numeric(10,0)
)
AS
BEGIN
	
   SELECT Id, RoomId, ReservationId
   FROM Lodge.RoomReservationDetails WITH (NOLOCK)
   WHERE ReservationId = @ReservationId   
   
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationDetailsInsert]
(  
	@RoomId  Numeric(10,0),
	@ReservationId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Lodge].[RoomReservationDetails]([RoomId],[ReservationId])
	VALUES(@RoomId,@ReservationId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[RoomReservationDetailsDelete]
	(
		@ReservationId  Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].[RoomReservationDetails]
		WHERE ReservationId = @ReservationId      
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomImageReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		[RoomId],
		[Name],
		[Image]
	FROM [Lodge].RoomImage WITH (NOLOCK)
	WHERE RoomId = @ParentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomImageRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		[RoomId],
		[Name],
		[Image]
	FROM [Lodge].RoomImage WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadBookedRoom]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReadBookedRoom]
(
      @BuildingId Numeric(10,0),
      @RoomCategoryId Numeric(10,0),
      @RoomTypeId Numeric(10,0),
      @IsAc Bit
)
AS
BEGIN

	DECLARE @CurrentDate Date = GETDATE();
	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
    WHERE BuildingId = @BuildingId
		AND StatusId != 10002 --Closed Room
        AND Id IN (
			SELECT RRD.RoomId  
            FROM Lodge.RoomReservationDetails RRD WITH (NOLOCK)
				INNER JOIN (SELECT * 
					FROM Lodge.RoomReservation WITH (NOLOCK)
					WHERE RoomCategoryId = ISNULL(@RoomCategoryId,RoomCategoryId)
						AND RoomTypeId = IsNull(@RoomTypeId,RoomTypeId)
						AND AcRoomPreference = @IsAc) RR 
					ON  RR.Id = RRD.ReservationId
                INNER JOIN  AutoTourism.CustomerRoomReservationLink CRRL WITH (NOLOCK) ON CRRL.RoomReservationId = RR.Id
            WHERE RR.StatusId = 10001 --Open room 
				AND(DATEADD(DAY, -1, RR.BookingFrom) > @CurrentDate
				OR DATEADD(DAY, RR.NoOfDays, RR.BookingFrom) > @CurrentDate))     

END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomClosureReasonReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		[ClosedDate],
		[Reason],			
		[RoomId]
	FROM [Lodge].RoomClosureReason WITH (NOLOCK)
	WHERE RoomId = @ParentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomClosureReasonRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Reason],			
		[RoomId],
		[ClosedDate]
	FROM [Lodge].RoomClosureReason WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomClosureReasonInsert]
	(  
		@Reason Varchar(50),	
		@RoomId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomClosureReason([Reason],[RoomId],ClosedDate)
		VALUES(@Reason,@RoomId,GETDATE())
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadAllCheckInRooms]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[ReadAllCheckInRooms]
(
	@ReservationId Numeric(10,0)
)
As
BEGIN

	SELECT distinct(RoomId)
	FROM Lodge.RoomReservationDetails WITH (NOLOCK)
	WHERE ReservationId In
		(SELECT DISTINCT(C.ReservationId)
		FROM Lodge.CheckIn C WITH (NOLOCK)
		INNER JOIN Lodge.RoomReservation R WITH (NOLOCK)ON C.ReservationId = R.Id
		WHERE C.StatusId = 10001
			And R.IsCheckedIn = 1)
		AND ReservationId <> @ReservationId
		
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInIsRoomDeletable]    Script Date: 01/01/2015 10:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInIsRoomDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInIsRoomDeletable]
(
	@RoomId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, CheckInDate, Purpose, ArrivedFrom, Remark, CreatedDate, ReservationId,
		StatusId, InvoiceNumber
	FROM Lodge.CheckIn WITH (NOLOCK)
	WHERE ReservationId IN (SELECT Id
		FROM Lodge.RoomReservationDetails WITH (NOLOCK)
		WHERE ReservationId = @RoomId)

END
' 
END
GO
/****** Object:  ForeignKey [FK_UserRole_Account]    Script Date: 01/01/2015 10:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] CHECK CONSTRAINT [FK_UserRole_Account]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 01/01/2015 10:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [Guardian].[Role] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_State_Country]    Script Date: 01/01/2015 10:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Configuration].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[Configuration].[State]'))
ALTER TABLE [Configuration].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [Configuration].[Country] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Configuration].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[Configuration].[State]'))
ALTER TABLE [Configuration].[State] CHECK CONSTRAINT [FK_State_Country]
GO
/****** Object:  ForeignKey [FK_TaxDetails_Taxation]    Script Date: 01/01/2015 10:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_TaxDetails_Taxation]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Slab]'))
ALTER TABLE [Invoice].[Slab]  WITH CHECK ADD  CONSTRAINT [FK_TaxDetails_Taxation] FOREIGN KEY([TaxId])
REFERENCES [Invoice].[Taxation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_TaxDetails_Taxation]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Slab]'))
ALTER TABLE [Invoice].[Slab] CHECK CONSTRAINT [FK_TaxDetails_Taxation]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_Account]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAnswer_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] CHECK CONSTRAINT [FK_SecurityAnswer_Account]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_SecurityQuestion]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAnswer_SecurityQuestion] FOREIGN KEY([QuestionId])
REFERENCES [Guardian].[SecurityQuestion] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] CHECK CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomCategory]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_RoomCategory] FOREIGN KEY([CategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomType]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_RoomType] FOREIGN KEY([TypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomCategory]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_RoomCategory] FOREIGN KEY([RoomCategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomType]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Status]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Status] FOREIGN KEY([StatusId])
REFERENCES [Customer].[ActionStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_Status]
GO
/****** Object:  ForeignKey [FK_Profile_Account]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] CHECK CONSTRAINT [FK_Profile_Account]
GO
/****** Object:  ForeignKey [FK_Profile_Initial]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Initial] FOREIGN KEY([Initial])
REFERENCES [Configuration].[Initial] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] CHECK CONSTRAINT [FK_Profile_Initial]
GO
/****** Object:  ForeignKey [FK_LoginLogoutHistory_Account]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginLogoutHistory_Account] FOREIGN KEY([AccountId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] CHECK CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
/****** Object:  ForeignKey [FK_LineItem_Invoice]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] CHECK CONSTRAINT [FK_LineItem_Invoice]
GO
/****** Object:  ForeignKey [FK_Payment_Invoice]    Script Date: 01/01/2015 10:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] CHECK CONSTRAINT [FK_Payment_Invoice]
GO
/****** Object:  ForeignKey [FK_InvoiceTaxation_Invoice]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceTaxation_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] CHECK CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
/****** Object:  ForeignKey [FK_Building_Organization]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] CHECK CONSTRAINT [FK_Building_Organization]
GO
/****** Object:  ForeignKey [FK_Appointment_AppointmentType]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_AppointmentType] FOREIGN KEY([TypeId])
REFERENCES [Utility].[AppointmentType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] CHECK CONSTRAINT [FK_Appointment_AppointmentType]
GO
/****** Object:  ForeignKey [FK_Appointment_Importance]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Importance] FOREIGN KEY([ImportanceId])
REFERENCES [Utility].[Importance] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] CHECK CONSTRAINT [FK_Appointment_Importance]
GO
/****** Object:  ForeignKey [FK_Artifact_Account]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account] FOREIGN KEY([CreatedByUserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account]
GO
/****** Object:  ForeignKey [FK_Artifact_Account1]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account1] FOREIGN KEY([ModifiedByUserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account1]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact] FOREIGN KEY([ParentId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Artifact]
GO
/****** Object:  ForeignKey [Organization_FK_ContactNumberId]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber]  WITH CHECK ADD  CONSTRAINT [Organization_FK_ContactNumberId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] CHECK CONSTRAINT [Organization_FK_ContactNumberId]
GO
/****** Object:  ForeignKey [Organization_FK_Id]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email]  WITH CHECK ADD  CONSTRAINT [Organization_FK_Id] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] CHECK CONSTRAINT [Organization_FK_Id]
GO
/****** Object:  ForeignKey [Organization_FK_FaxId]    Script Date: 01/01/2015 10:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax]  WITH CHECK ADD  CONSTRAINT [Organization_FK_FaxId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] CHECK CONSTRAINT [Organization_FK_FaxId]
GO
/****** Object:  ForeignKey [FK_CheckIn_ActionStatus]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_ActionStatus] FOREIGN KEY([StatusId])
REFERENCES [Customer].[ActionStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_ActionStatus]
GO
/****** Object:  ForeignKey [FK_CheckIn_RoomReservation]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_RoomReservation] FOREIGN KEY([ReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_RoomReservation]
GO
/****** Object:  ForeignKey [Customer_FK_IdentityProofId]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_IdentityProofId] FOREIGN KEY([IdentityProofId])
REFERENCES [Configuration].[IdentityProofType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_IdentityProofId]
GO
/****** Object:  ForeignKey [Customer_FK_InitialId]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_InitialId] FOREIGN KEY([InitialId])
REFERENCES [Configuration].[Initial] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_InitialId]
GO
/****** Object:  ForeignKey [Customer_FK_StateId]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_StateId] FOREIGN KEY([StateId])
REFERENCES [Configuration].[State] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_StateId]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact1]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact1] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] CHECK CONSTRAINT [FK_Artifact_Artifact1]
GO
/****** Object:  ForeignKey [FK_Artifact_Invoice]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] CHECK CONSTRAINT [FK_Artifact_Invoice]
GO
/****** Object:  ForeignKey [FK_AdvancePaymentArtifact_AdvancePayment]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_AdvancePaymentArtifact_AdvancePayment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]'))
ALTER TABLE [Invoice].[AdvancePaymentArtifact]  WITH CHECK ADD  CONSTRAINT [FK_AdvancePaymentArtifact_AdvancePayment] FOREIGN KEY([AdvancePaymentId])
REFERENCES [Invoice].[AdvancePayment] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_AdvancePaymentArtifact_AdvancePayment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]'))
ALTER TABLE [Invoice].[AdvancePaymentArtifact] CHECK CONSTRAINT [FK_AdvancePaymentArtifact_AdvancePayment]
GO
/****** Object:  ForeignKey [FK_AdvancePaymentArtifact_Artifact]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_AdvancePaymentArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]'))
ALTER TABLE [Invoice].[AdvancePaymentArtifact]  WITH CHECK ADD  CONSTRAINT [FK_AdvancePaymentArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_AdvancePaymentArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[AdvancePaymentArtifact]'))
ALTER TABLE [Invoice].[AdvancePaymentArtifact] CHECK CONSTRAINT [FK_AdvancePaymentArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_BuildingClosureReason_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] CHECK CONSTRAINT [FK_BuildingClosureReason_Building]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Artifact]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]'))
ALTER TABLE [Navigator].[ArtifactComponentLink]  WITH CHECK ADD  CONSTRAINT [FK_FormModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]'))
ALTER TABLE [Navigator].[ArtifactComponentLink] CHECK CONSTRAINT [FK_FormModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Module]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]'))
ALTER TABLE [Navigator].[ArtifactComponentLink]  WITH CHECK ADD  CONSTRAINT [FK_FormModuleLink_Module] FOREIGN KEY([ComponentId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLink]'))
ALTER TABLE [Navigator].[ArtifactComponentLink] CHECK CONSTRAINT [FK_FormModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Artifact]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_CatalogueModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] CHECK CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Module]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_CatalogueModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] CHECK CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_BuildingFloor_Building]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor]  WITH CHECK ADD  CONSTRAINT [FK_BuildingFloor_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] CHECK CONSTRAINT [FK_BuildingFloor_Building]
GO
/****** Object:  ForeignKey [FK_PaymentLineItem_Payment]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentLineItem_Payment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]'))
ALTER TABLE [Invoice].[PaymentLineItem]  WITH CHECK ADD  CONSTRAINT [FK_PaymentLineItem_Payment] FOREIGN KEY([PaymentId])
REFERENCES [Invoice].[Payment] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentLineItem_Payment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]'))
ALTER TABLE [Invoice].[PaymentLineItem] CHECK CONSTRAINT [FK_PaymentLineItem_Payment]
GO
/****** Object:  ForeignKey [FK_PaymentLineItem_PaymentType]    Script Date: 01/01/2015 10:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentLineItem_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]'))
ALTER TABLE [Invoice].[PaymentLineItem]  WITH CHECK ADD  CONSTRAINT [FK_PaymentLineItem_PaymentType] FOREIGN KEY([PaymentTypeId])
REFERENCES [Invoice].[PaymentType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentLineItem_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentLineItem]'))
ALTER TABLE [Invoice].[PaymentLineItem] CHECK CONSTRAINT [FK_PaymentLineItem_PaymentType]
GO
/****** Object:  ForeignKey [FK_LineItemTaxation_LineItem]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItemTaxation_LineItem]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]'))
ALTER TABLE [Invoice].[LineItemTaxation]  WITH CHECK ADD  CONSTRAINT [FK_LineItemTaxation_LineItem] FOREIGN KEY([LineItemId])
REFERENCES [Invoice].[LineItem] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItemTaxation_LineItem]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]'))
ALTER TABLE [Invoice].[LineItemTaxation] CHECK CONSTRAINT [FK_LineItemTaxation_LineItem]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_ReportModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] CHECK CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Module]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_ReportModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] CHECK CONSTRAINT [FK_ReportModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Report] FOREIGN KEY([ReportId])
REFERENCES [Invoice].[Report] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Report] FOREIGN KEY([ReportId])
REFERENCES [Customer].[Report] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_ProfileContactNumber_Profile]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber]  WITH CHECK ADD  CONSTRAINT [FK_ProfileContactNumber_Profile] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Profile] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] CHECK CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
/****** Object:  ForeignKey [FK_PaymentArtifact_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]'))
ALTER TABLE [Invoice].[PaymentArtifact]  WITH CHECK ADD  CONSTRAINT [FK_PaymentArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]'))
ALTER TABLE [Invoice].[PaymentArtifact] CHECK CONSTRAINT [FK_PaymentArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_PaymentArtifact_Payment]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentArtifact_Payment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]'))
ALTER TABLE [Invoice].[PaymentArtifact]  WITH CHECK ADD  CONSTRAINT [FK_PaymentArtifact_Payment] FOREIGN KEY([PaymentId])
REFERENCES [Invoice].[Payment] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_PaymentArtifact_Payment]') AND parent_object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]'))
ALTER TABLE [Invoice].[PaymentArtifact] CHECK CONSTRAINT [FK_PaymentArtifact_Payment]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_Artifact]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] CHECK CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_RoomReservation]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationArtifact_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] CHECK CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomReservationPayment_Payment]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationPayment_Payment]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]'))
ALTER TABLE [Lodge].[RoomReservationPayment]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationPayment_Payment] FOREIGN KEY([PaymentId])
REFERENCES [Invoice].[Payment] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationPayment_Payment]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]'))
ALTER TABLE [Lodge].[RoomReservationPayment] CHECK CONSTRAINT [FK_RoomReservationPayment_Payment]
GO
/****** Object:  ForeignKey [FK_RoomReservationPayment_RoomReservation]    Script Date: 01/01/2015 10:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationPayment_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]'))
ALTER TABLE [Lodge].[RoomReservationPayment]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationPayment_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationPayment_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationPayment]'))
ALTER TABLE [Lodge].[RoomReservationPayment] CHECK CONSTRAINT [FK_RoomReservationPayment_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomReservationAttachment_PaymentArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationAttachment_PaymentArtifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]'))
ALTER TABLE [Lodge].[RoomReservationAttachment]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationAttachment_PaymentArtifact] FOREIGN KEY([AttachmentId])
REFERENCES [Invoice].[PaymentArtifact] ([ArtifactId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationAttachment_PaymentArtifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]'))
ALTER TABLE [Lodge].[RoomReservationAttachment] CHECK CONSTRAINT [FK_RoomReservationAttachment_PaymentArtifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationAttachment_RoomReservationArtifact]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationAttachment_RoomReservationArtifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]'))
ALTER TABLE [Lodge].[RoomReservationAttachment]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationAttachment_RoomReservationArtifact] FOREIGN KEY([ArtifactId])
REFERENCES [Lodge].[RoomReservationArtifact] ([ArtifactId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationAttachment_RoomReservationArtifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationAttachment]'))
ALTER TABLE [Lodge].[RoomReservationAttachment] CHECK CONSTRAINT [FK_RoomReservationAttachment_RoomReservationArtifact]
GO
/****** Object:  ForeignKey [FK_Room_Building]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_Building]
GO
/****** Object:  ForeignKey [FK_Room_BuildingFloor]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_BuildingFloor] FOREIGN KEY([FloorId])
REFERENCES [Lodge].[BuildingFloor] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_BuildingFloor]
GO
/****** Object:  ForeignKey [FK_Room_RoomCategory]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomCategory] FOREIGN KEY([CategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomCategory]
GO
/****** Object:  ForeignKey [FK_Room_RoomStatus]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomStatus] FOREIGN KEY([StatusId])
REFERENCES [Lodge].[RoomStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomStatus]
GO
/****** Object:  ForeignKey [FK_Room_RoomType]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([TypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_Artifact]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CheckInArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] CHECK CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_CheckIn]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CheckInArtifact_CheckIn] FOREIGN KEY([CheckInId])
REFERENCES [Lodge].[CheckIn] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] CHECK CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
/****** Object:  ForeignKey [CustomerContactNumber_FK_CustomerId]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber]  WITH CHECK ADD  CONSTRAINT [CustomerContactNumber_FK_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] CHECK CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Artifact]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerForm_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] CHECK CONSTRAINT [FK_CustomerForm_Artifact]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Customer]    Script Date: 01/01/2015 10:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerForm_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] CHECK CONSTRAINT [FK_CustomerForm_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_Customer]    Script Date: 01/01/2015 10:50:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomReservationLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] CHECK CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_RoomReservation]    Script Date: 01/01/2015 10:50:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] CHECK CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_CheckIn]    Script Date: 01/01/2015 10:50:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn] FOREIGN KEY([RoomCheckInId])
REFERENCES [Lodge].[CheckIn] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] CHECK CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_Customer]    Script Date: 01/01/2015 10:50:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomCheckInLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] CHECK CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
/****** Object:  ForeignKey [FK_RoomClosureReason_Room]    Script Date: 01/01/2015 10:50:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_RoomClosureReason_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] CHECK CONSTRAINT [FK_RoomClosureReason_Room]
GO
/****** Object:  ForeignKey [FK_RoomImage_Room]    Script Date: 01/01/2015 10:50:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage]  WITH CHECK ADD  CONSTRAINT [FK_RoomImage_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] CHECK CONSTRAINT [FK_RoomImage_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_Room]    Script Date: 01/01/2015 10:50:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_RoomReservation]    Script Date: 01/01/2015 10:50:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_RoomReservation] FOREIGN KEY([ReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
