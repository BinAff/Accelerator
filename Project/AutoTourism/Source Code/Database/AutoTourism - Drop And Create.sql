USE [master]
GO
/****** Object:  Database [AutoTourism]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'AutoTourism')
BEGIN
CREATE DATABASE [AutoTourism] ON  PRIMARY 
( NAME = N'AutoTourism', FILENAME = N'D:\Arpan\Personal\AutoTourism.mdb' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AutoTourism_log', FILENAME = N'D:\Arpan\Personal\AutoTourism.ldb' , SIZE = 26816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [AutoTourism] SET RECOVERY FULL
GO
ALTER DATABASE [AutoTourism] SET  MULTI_USER
GO
ALTER DATABASE [AutoTourism] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [AutoTourism] SET DB_CHAINING OFF
GO
USE [AutoTourism]
GO
/****** Object:  ForeignKey [FK_UserRole_Account]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Account]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_State_Country]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Configuration].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[Configuration].[State]'))
ALTER TABLE [Configuration].[State] DROP CONSTRAINT [FK_State_Country]
GO
/****** Object:  ForeignKey [FK_TaxDetails_Taxation]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_TaxDetails_Taxation]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Slab]'))
ALTER TABLE [Invoice].[Slab] DROP CONSTRAINT [FK_TaxDetails_Taxation]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_Account]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_Account]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_SecurityQuestion]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomCategory]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomType]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomCategory]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomType]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Status]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_Status]
GO
/****** Object:  ForeignKey [FK_Profile_Account]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Account]
GO
/****** Object:  ForeignKey [FK_Profile_Initial]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Initial]
GO
/****** Object:  ForeignKey [FK_Payment_Invoice]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_Invoice]
GO
/****** Object:  ForeignKey [FK_Payment_PaymentType]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_PaymentType]
GO
/****** Object:  ForeignKey [FK_LoginLogoutHistory_Account]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] DROP CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
/****** Object:  ForeignKey [FK_LineItem_Invoice]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] DROP CONSTRAINT [FK_LineItem_Invoice]
GO
/****** Object:  ForeignKey [FK_InvoiceTaxation_Invoice]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] DROP CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
/****** Object:  ForeignKey [FK_Artifact_Account]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Account]
GO
/****** Object:  ForeignKey [FK_Artifact_Account1]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Account1]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact]
GO
/****** Object:  ForeignKey [FK_Appointment_AppointmentType]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_AppointmentType]
GO
/****** Object:  ForeignKey [FK_Appointment_Importance]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_Importance]
GO
/****** Object:  ForeignKey [FK_Building_Organization]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] DROP CONSTRAINT [FK_Building_Organization]
GO
/****** Object:  ForeignKey [Organization_FK_ContactNumberId]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] DROP CONSTRAINT [Organization_FK_ContactNumberId]
GO
/****** Object:  ForeignKey [Organization_FK_Id]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] DROP CONSTRAINT [Organization_FK_Id]
GO
/****** Object:  ForeignKey [Organization_FK_FaxId]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] DROP CONSTRAINT [Organization_FK_FaxId]
GO
/****** Object:  ForeignKey [Customer_FK_IdentityProofId]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_IdentityProofId]
GO
/****** Object:  ForeignKey [Customer_FK_InitialId]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_InitialId]
GO
/****** Object:  ForeignKey [Customer_FK_StateId]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_StateId]
GO
/****** Object:  ForeignKey [FK_CheckIn_ActionStatus]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_ActionStatus]
GO
/****** Object:  ForeignKey [FK_CheckIn_RoomReservation]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_RoomReservation]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Artifact]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Module]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] DROP CONSTRAINT [FK_BuildingClosureReason_Building]
GO
/****** Object:  ForeignKey [FK_BuildingFloor_Building]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] DROP CONSTRAINT [FK_BuildingFloor_Building]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact1]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact1]
GO
/****** Object:  ForeignKey [FK_Artifact_Invoice]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Invoice]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Artifact]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] DROP CONSTRAINT [FK_FormModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Module]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] DROP CONSTRAINT [FK_FormModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_LineItemTaxation_LineItem]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItemTaxation_LineItem]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]'))
ALTER TABLE [Invoice].[LineItemTaxation] DROP CONSTRAINT [FK_LineItemTaxation_LineItem]
GO
/****** Object:  ForeignKey [FK_ProfileContactNumber_Profile]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] DROP CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Artifact]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Module]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_Artifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_RoomReservation]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
/****** Object:  ForeignKey [FK_Room_Building]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_Building]
GO
/****** Object:  ForeignKey [FK_Room_BuildingFloor]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_BuildingFloor]
GO
/****** Object:  ForeignKey [FK_Room_RoomCategory]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomCategory]
GO
/****** Object:  ForeignKey [FK_Room_RoomStatus]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomStatus]
GO
/****** Object:  ForeignKey [FK_Room_RoomType]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomType]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Artifact]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [FK_CustomerForm_Artifact]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Customer]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [FK_CustomerForm_Customer]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_Artifact]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_CheckIn]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
/****** Object:  ForeignKey [CustomerContactNumber_FK_CustomerId]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] DROP CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_CheckIn]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_Customer]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_Customer]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_RoomReservation]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomClosureReason_Room]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] DROP CONSTRAINT [FK_RoomClosureReason_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_Room]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_RoomReservation]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomImage_Room]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] DROP CONSTRAINT [FK_RoomImage_Room]
GO
/****** Object:  StoredProcedure [Lodge].[IsCheckInDeletable]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsCheckInDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsCheckInDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadAllCheckInRooms]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadAllCheckInRooms]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadBookedRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadBookedRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomImageRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomImageReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsRead]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationSearch]
GO
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomModifyStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomModifyStatus]
GO
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomDelete]
GO
/****** Object:  Table [Lodge].[RoomImage]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] DROP CONSTRAINT [FK_RoomImage_Room]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImage]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomImage]
GO
/****** Object:  Table [Lodge].[RoomReservationDetails]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_Room]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservationDetails]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffModifyRate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffModifyRate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadCheckedInRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadCheckedInRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadOpenRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadOpenRoom]
GO
/****** Object:  StoredProcedure [Customer].[ReportCustomer]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportCustomer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportCustomer]
GO
/****** Object:  Table [Lodge].[RoomClosureReason]    Script Date: 07/22/2014 16:34:39 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] DROP CONSTRAINT [FK_RoomClosureReason_Room]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomClosureReason]
GO
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsIdentityProofIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsIdentityProofIdDeletable]
GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsInitialDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsInitialDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingFloorDeletable]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingFloorDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingFloorDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomBuildingDeletable]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomBuildingDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsRoomBuildingDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomCategoryDeletable]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomCategoryDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsRoomCategoryDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomStatusDeletable]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomStatusDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsRoomStatusDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomTypeDeletable]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsRoomTypeDeletable]
GO
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsStateIdDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactDeleteLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactInsertLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactReadLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactReadLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactUpdateLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactDeleteLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactInsertLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactReadLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactReadLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactUpdateLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberDelete]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberInsert]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberRead]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReadDuplicate]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkInsert]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkRead]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkDelete]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkInsert]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkRead]
GO
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[GetCustomerIdForReservation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[GetCustomerIdForReservation]
GO
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerUpdate]
GO
/****** Object:  StoredProcedure [Customer].[DeleteCustomerReportForArtifact]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[DeleteCustomerReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[DeleteCustomerReportForArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceReportForArtifact]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InsertInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InsertInvoiceReportForArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactDeleteLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactInsertLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactReadLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceArtifactReadLink]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactUpdateLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceArtifactUpdateLink]
GO
/****** Object:  Table [AutoTourism].[CustomerRoomReservationLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]') AND type in (N'U'))
DROP TABLE [AutoTourism].[CustomerRoomReservationLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReportArtifactInsertLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReportArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReportArtifactInsertLink]
GO
/****** Object:  Table [AutoTourism].[CustomerRoomCheckInLink]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]') AND type in (N'U'))
DROP TABLE [AutoTourism].[CustomerRoomCheckInLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerDelete]
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerInsert]
GO
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerRead]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReadAll]
GO
/****** Object:  Table [Customer].[CustomerContactNumber]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] DROP CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]') AND type in (N'U'))
DROP TABLE [Customer].[CustomerContactNumber]
GO
/****** Object:  Table [Lodge].[CheckInArtifact]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]') AND type in (N'U'))
DROP TABLE [Lodge].[CheckInArtifact]
GO
/****** Object:  Table [Customer].[CustomerArtifact]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 07/22/2014 16:34:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInDelete]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInInsert]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInRead]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactSearchByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactSearchByName]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorReadForParent]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactDelete]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkInsertForModule]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkInsertForModule]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactModuleLinkInsertForModule]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkReadForArtifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkReadForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactModuleLinkReadForArtifact]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkReadForModule]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkReadForModule]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactModuleLinkReadForModule]
GO
/****** Object:  StoredProcedure [Lodge].[IsReservationDeletable]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsReservationDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsReservationDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemTaxationInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemTaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemTaxationInsert]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberInsert]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberRead]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberReadForParent]
GO
/****** Object:  StoredProcedure [Invoice].[ReadInvoiceReportForArtifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadInvoiceReportForArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomReservationId]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadRoomReservationId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadRoomReservationId]
GO
/****** Object:  StoredProcedure [Invoice].[ReadArtifactForInvoiceNumber]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadArtifactForInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadArtifactForInvoiceNumber]
GO
/****** Object:  StoredProcedure [Customer].[ReadCustomerReportForArtifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReadCustomerReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReadCustomerReportForArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[ReservationArtifactDeleteLink]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReservationArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReservationArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Lodge].[ReservationArtifactInsertLink]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReservationArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReservationArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Lodge].[ReservationArtifactUpdateLink]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReservationArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReservationArtifactUpdateLink]
GO
/****** Object:  Table [Lodge].[Room]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadLink]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactReadLink]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateCheckInStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateCheckInStatus]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateInvoiceNumber]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateInvoiceNumber]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationStatusToCheckIn]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateReservationStatusToCheckIn]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleDelete]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleRead]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[SlabRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[SlabRead]
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadAll]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[SlabReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[SlabReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffInsert]
GO
/****** Object:  StoredProcedure [Invoice].[ReportSales]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportSales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReportSales]
GO
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SearchUserByLoginId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SearchUserByLoginId]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerDelete]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerRead]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerUpdate]
GO
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateDelete]
GO
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateInsert]
GO
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateRead]
GO
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffIsExist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffIsExist]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllCurrent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadAllCurrent]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllFuture]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadAllFuture]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadDuplicate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationUpdateStatus]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationReadAll]
GO
/****** Object:  Table [Lodge].[RoomReservationArtifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservationArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffUpdate]
GO
/****** Object:  Table [Customer].[ReportArtifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Report]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportArtifact]') AND type in (N'U'))
DROP TABLE [Customer].[ReportArtifact]
GO
/****** Object:  Table [Invoice].[ReportArtifact]    Script Date: 07/22/2014 16:34:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] DROP CONSTRAINT [FK_ReportArtifact_Report]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]') AND type in (N'U'))
DROP TABLE [Invoice].[ReportArtifact]
GO
/****** Object:  Table [Navigator].[ReportModuleLink]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]') AND type in (N'U'))
DROP TABLE [Navigator].[ReportModuleLink]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileRead]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentUpdate]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentUpdate]
GO
/****** Object:  Table [Guardian].[ProfileContactNumber]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] DROP CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]') AND type in (N'U'))
DROP TABLE [Guardian].[ProfileContactNumber]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemUpdate]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentDelete]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentDelete]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentInsert]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentInsert]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentRead]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentRead]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadAll]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingStatusDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingStatusDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingTypeDeletable]
GO
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[IsInitialDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[IsInitialDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[IsPaymentTypeDeletable]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[IsPaymentTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[IsPaymentTypeDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsTariffDeletable]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsTariffDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsTariffDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentRead]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentRead]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationInsert]
GO
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailRead]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationRead]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemDelete]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemDelete]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemInsert]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemInsert]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemRead]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemRead]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadAll]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadForParent]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemReadForParent]
GO
/****** Object:  Table [Invoice].[LineItemTaxation]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItemTaxation_LineItem]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]'))
ALTER TABLE [Invoice].[LineItemTaxation] DROP CONSTRAINT [FK_LineItemTaxation_LineItem]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]') AND type in (N'U'))
DROP TABLE [Invoice].[LineItemTaxation]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryInsert]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryRead]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactRead]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactReadAll]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadForPath]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadForPath]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactReadForPath]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactInsert]
GO
/****** Object:  Table [Navigator].[ArtifactModuleLink]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] DROP CONSTRAINT [FK_FormModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] DROP CONSTRAINT [FK_FormModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]') AND type in (N'U'))
DROP TABLE [Navigator].[ArtifactModuleLink]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentUpdate]
GO
/****** Object:  Table [Invoice].[Artifact]    Script Date: 07/22/2014 16:34:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Artifact]') AND type in (N'U'))
DROP TABLE [Invoice].[Artifact]
GO
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountRead]
GO
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentDelete]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentRead]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentSearch]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearchWithImportance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentSearchWithImportance]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingModifyStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingModifyStatus]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingDelete]
GO
/****** Object:  Table [Lodge].[BuildingFloor]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] DROP CONSTRAINT [FK_BuildingFloor_Building]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingFloor]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactUpdate]
GO
/****** Object:  Table [Lodge].[BuildingClosureReason]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] DROP CONSTRAINT [FK_BuildingClosureReason_Building]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingClosureReason]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingUpdate]
GO
/****** Object:  Table [Navigator].[CatalogueModuleLink]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]') AND type in (N'U'))
DROP TABLE [Navigator].[CatalogueModuleLink]
GO
/****** Object:  Table [Lodge].[CheckIn]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_ActionStatus]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckIn]') AND type in (N'U'))
DROP TABLE [Lodge].[CheckIn]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberDelete]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberInsert]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberRead]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberReadForParent]
GO
/****** Object:  Table [Customer].[Customer]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailDelete]
GO
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailInsert]
GO
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailReadForParent]
GO
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxDelete]
GO
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxInsert]
GO
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxRead]
GO
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxReadForParent]
GO
/****** Object:  Table [Organization].[Fax]    Script Date: 07/22/2014 16:34:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] DROP CONSTRAINT [Organization_FK_FaxId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Fax]') AND type in (N'U'))
DROP TABLE [Organization].[Fax]
GO
/****** Object:  Table [Organization].[Email]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] DROP CONSTRAINT [Organization_FK_Id]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Email]') AND type in (N'U'))
DROP TABLE [Organization].[Email]
GO
/****** Object:  StoredProcedure [Configuration].[CountryRead]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[CountryRead]
GO
/****** Object:  StoredProcedure [Configuration].[CountryReadAll]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[CountryReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeDelete]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeInsert]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeRead]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeUpdate]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceDelete]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceInsert]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceRead]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceReadAll]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceReadDuplicate]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceUpdate]
GO
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentDelete]
GO
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentInsert]
GO
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentRead]
GO
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentReadAll]
GO
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentUpdate]
GO
/****** Object:  Table [Organization].[ContactNumber]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] DROP CONSTRAINT [Organization_FK_ContactNumberId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumber]') AND type in (N'U'))
DROP TABLE [Organization].[ContactNumber]
GO
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountDelete]
GO
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountInsert]
GO
/****** Object:  StoredProcedure [Report].[CategoryRead]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Report].[CategoryRead]
GO
/****** Object:  StoredProcedure [Report].[CategoryReadAll]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Report].[CategoryReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeDelete]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeInsert]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeRead]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeReadAll]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeUpdate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeUpdate]
GO
/****** Object:  Table [Lodge].[Building]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] DROP CONSTRAINT [FK_Building_Organization]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[Building]') AND type in (N'U'))
DROP TABLE [Lodge].[Building]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusDelete]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusInsert]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusRead]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusReadAll]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusUpdate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusUpdate]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusDelete]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusInsert]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusRead]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusReadAll]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusUpdate]
GO
/****** Object:  Table [Utility].[Appointment]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_AppointmentType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_Importance]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[Appointment]') AND type in (N'U'))
DROP TABLE [Utility].[Appointment]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdateLoginId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdateLoginId]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 07/22/2014 16:34:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdatePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdatePassword]
GO
/****** Object:  Table [Navigator].[Artifact]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeDelete]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeRead]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeUpdate]
GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[IsStateIdDeletable]
GO
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleDelete]
GO
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleInsert]
GO
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleRead]
GO
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleReadAll]
GO
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleUpdate]
GO
/****** Object:  Table [Invoice].[InvoiceTaxation]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] DROP CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]') AND type in (N'U'))
DROP TABLE [Invoice].[InvoiceTaxation]
GO
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialDelete]
GO
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialInsert]
GO
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialRead]
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[Insert]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Insert]
GO
/****** Object:  Table [Invoice].[LineItem]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] DROP CONSTRAINT [FK_LineItem_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItem]') AND type in (N'U'))
DROP TABLE [Invoice].[LineItem]
GO
/****** Object:  StoredProcedure [Invoice].[Delete]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Delete]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationInsert]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationRead]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactDeleteLink]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactInsertLink]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactReadLink]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentArtifactReadLink]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactUpdateLink]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentArtifactUpdateLink]
GO
/****** Object:  Table [Guardian].[LoginHistory]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] DROP CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistory]') AND type in (N'U'))
DROP TABLE [Guardian].[LoginHistory]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationDelete]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationUpdate]
GO
/****** Object:  Table [Invoice].[Payment]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_PaymentType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Payment]') AND type in (N'U'))
DROP TABLE [Invoice].[Payment]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeDelete]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeDelete]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeInsert]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeInsert]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeRead]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeRead]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadAll]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadDuplicate]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeUpdate]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeUpdate]
GO
/****** Object:  Table [Guardian].[Profile]    Script Date: 07/22/2014 16:34:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Initial]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Profile]') AND type in (N'U'))
DROP TABLE [Guardian].[Profile]
GO
/****** Object:  StoredProcedure [Invoice].[Read]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Read]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Read]
GO
/****** Object:  StoredProcedure [Invoice].[ReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadAll]
GO
/****** Object:  StoredProcedure [Customer].[ReportRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportRead]
GO
/****** Object:  StoredProcedure [Invoice].[ReportRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReportRead]
GO
/****** Object:  StoredProcedure [Customer].[ReportReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[ReportReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReportReadAll]
GO
/****** Object:  StoredProcedure [Customer].[ReportInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportInsert]
GO
/****** Object:  StoredProcedure [Invoice].[ReportInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReportInsert]
GO
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleRead]
GO
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryUpdate]
GO
/****** Object:  Table [Lodge].[RoomReservation]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Invoice].[ReadDuplicate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[ReadForInvoiceNumber]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadForInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadForInvoiceNumber]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomStatusDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomStatusRead]
GO
/****** Object:  Table [Lodge].[RoomTariff]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariff]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomTariff]
GO
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[RuleInsert]
GO
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleInsert]
GO
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleInsert]
GO
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[RuleRead]
GO
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleRead]
GO
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleRead]
GO
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationStatusRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationStatusReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationDelete]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationDelete]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationInsert]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationRead]
GO
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TaxationRead]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TaxationReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadDuplicate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationUpdate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[Update]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Update]
GO
/****** Object:  Table [Guardian].[SecurityAnswer]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]') AND type in (N'U'))
DROP TABLE [Guardian].[SecurityAnswer]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionDelete]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionRead]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionReadDuplicate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionUpdate]
GO
/****** Object:  Table [Invoice].[Slab]    Script Date: 07/22/2014 16:34:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_TaxDetails_Taxation]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Slab]'))
ALTER TABLE [Invoice].[Slab] DROP CONSTRAINT [FK_TaxDetails_Taxation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Slab]') AND type in (N'U'))
DROP TABLE [Invoice].[Slab]
GO
/****** Object:  Table [Configuration].[State]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Configuration].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[Configuration].[State]'))
ALTER TABLE [Configuration].[State] DROP CONSTRAINT [FK_State_Country]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[State]') AND type in (N'U'))
DROP TABLE [Configuration].[State]
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRuleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRuleRead]
GO
/****** Object:  Table [Guardian].[UserRole]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRole]') AND type in (N'U'))
DROP TABLE [Guardian].[UserRole]
GO
/****** Object:  Table [Guardian].[UserRule]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRule]') AND type in (N'U'))
DROP TABLE [Guardian].[UserRule]
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 07/22/2014 16:34:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Split]
GO
/****** Object:  Table [BinAff].[Stamp]    Script Date: 07/22/2014 16:34:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[BinAff].[Stamp]') AND type in (N'U'))
DROP TABLE [BinAff].[Stamp]
GO
/****** Object:  Table [Guardian].[SecurityQuestion]    Script Date: 07/22/2014 16:34:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestion]') AND type in (N'U'))
DROP TABLE [Guardian].[SecurityQuestion]
GO
/****** Object:  Table [Invoice].[Taxation]    Script Date: 07/22/2014 16:34:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Taxation]') AND type in (N'U'))
DROP TABLE [Invoice].[Taxation]
GO
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusDelete]
GO
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusInsert]
GO
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusRead]
GO
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusReadAll]
GO
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusUpdate]
GO
/****** Object:  Table [Lodge].[RoomStatus]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatus]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomStatus]
GO
/****** Object:  Table [Configuration].[Rule]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Rule]') AND type in (N'U'))
DROP TABLE [Configuration].[Rule]
GO
/****** Object:  Table [Customer].[Rule]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Rule]') AND type in (N'U'))
DROP TABLE [Customer].[Rule]
GO
/****** Object:  Table [Navigator].[Rule]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[Rule]') AND type in (N'U'))
DROP TABLE [Navigator].[Rule]
GO
/****** Object:  Table [Lodge].[RoomType]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomType]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomType]
GO
/****** Object:  Table [Guardian].[Role]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Role]') AND type in (N'U'))
DROP TABLE [Guardian].[Role]
GO
/****** Object:  Table [Lodge].[RoomCategory]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategory]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomCategory]
GO
/****** Object:  Table [Customer].[Report]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Report]') AND type in (N'U'))
DROP TABLE [Customer].[Report]
GO
/****** Object:  Table [Invoice].[Report]    Script Date: 07/22/2014 16:34:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Report]') AND type in (N'U'))
DROP TABLE [Invoice].[Report]
GO
/****** Object:  Table [Invoice].[PaymentArtifact]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifact]') AND type in (N'U'))
DROP TABLE [Invoice].[PaymentArtifact]
GO
/****** Object:  StoredProcedure [dbo].[EmailInsert]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailInsert]
GO
/****** Object:  StoredProcedure [dbo].[EmailRead]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailRead]
GO
/****** Object:  StoredProcedure [dbo].[EmailReadForParent]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailReadForParent]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationEmailRead]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationEmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationEmailRead]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationInsert]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationInsert]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationUpdate]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationUpdate]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationRead]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationRead]
GO
/****** Object:  Table [Invoice].[PaymentType]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentType]') AND type in (N'U'))
DROP TABLE [Invoice].[PaymentType]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkDelete]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkRead]
GO
/****** Object:  Table [Organization].[Organization]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Organization]') AND type in (N'U'))
DROP TABLE [Organization].[Organization]
GO
/****** Object:  Table [License].[Module]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Module]') AND type in (N'U'))
DROP TABLE [License].[Module]
GO
/****** Object:  Table [Customer].[ActionStatus]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatus]') AND type in (N'U'))
DROP TABLE [Customer].[ActionStatus]
GO
/****** Object:  Table [Guardian].[Account]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Account]') AND type in (N'U'))
DROP TABLE [Guardian].[Account]
GO
/****** Object:  Table [Utility].[AppointmentType]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentType]') AND type in (N'U'))
DROP TABLE [Utility].[AppointmentType]
GO
/****** Object:  Table [Lodge].[BuildingType]    Script Date: 07/22/2014 16:34:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingType]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingType]
GO
/****** Object:  Table [Lodge].[BuildingStatus]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatus]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingStatus]
GO
/****** Object:  Table [Report].[Category]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[Category]') AND type in (N'U'))
DROP TABLE [Report].[Category]
GO
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CleanUpSchema]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CleanUpSchema]
GO
/****** Object:  Table [License].[Component]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Component]') AND type in (N'U'))
DROP TABLE [License].[Component]
GO
/****** Object:  Table [Configuration].[Country]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Country]') AND type in (N'U'))
DROP TABLE [Configuration].[Country]
GO
/****** Object:  Table [Configuration].[Initial]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Initial]') AND type in (N'U'))
DROP TABLE [Configuration].[Initial]
GO
/****** Object:  Table [Utility].[Importance]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[Importance]') AND type in (N'U'))
DROP TABLE [Utility].[Importance]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkDelete]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 07/22/2014 16:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkRead]
GO
/****** Object:  Table [Invoice].[Invoice]    Script Date: 07/22/2014 16:34:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Invoice]') AND type in (N'U'))
DROP TABLE [Invoice].[Invoice]
GO
/****** Object:  Table [License].[Credential]    Script Date: 07/22/2014 16:34:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Credential]') AND type in (N'U'))
DROP TABLE [License].[Credential]
GO
/****** Object:  Table [BinAff].[DateStamp]    Script Date: 07/22/2014 16:34:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[BinAff].[DateStamp]') AND type in (N'U'))
DROP TABLE [BinAff].[DateStamp]
GO
/****** Object:  Table [Configuration].[IdentityProofType]    Script Date: 07/22/2014 16:34:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofType]') AND type in (N'U'))
DROP TABLE [Configuration].[IdentityProofType]
GO
/****** Object:  Schema [AutoTourism]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'AutoTourism')
DROP SCHEMA [AutoTourism]
GO
/****** Object:  Schema [BinAff]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'BinAff')
DROP SCHEMA [BinAff]
GO
/****** Object:  Schema [Configuration]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Configuration')
DROP SCHEMA [Configuration]
GO
/****** Object:  Schema [Customer]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Customer')
DROP SCHEMA [Customer]
GO
/****** Object:  Schema [Guardian]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Guardian')
DROP SCHEMA [Guardian]
GO
/****** Object:  Schema [Invoice]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Invoice')
DROP SCHEMA [Invoice]
GO
/****** Object:  Schema [License]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'License')
DROP SCHEMA [License]
GO
/****** Object:  Schema [Lodge]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Lodge')
DROP SCHEMA [Lodge]
GO
/****** Object:  Schema [Navigator]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Navigator')
DROP SCHEMA [Navigator]
GO
/****** Object:  Schema [Organization]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Organization')
DROP SCHEMA [Organization]
GO
/****** Object:  Schema [Report]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Report')
DROP SCHEMA [Report]
GO
/****** Object:  Schema [Reservation]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Reservation')
DROP SCHEMA [Reservation]
GO
/****** Object:  Schema [Utility]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Utility')
DROP SCHEMA [Utility]
GO
/****** Object:  User [AppUser]    Script Date: 07/22/2014 16:34:09 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AppUser')
DROP USER [AppUser]
GO
/****** Object:  User [AppUser]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AppUser')
CREATE USER [AppUser] FOR LOGIN [AppUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [Utility]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Utility')
EXEC sys.sp_executesql N'CREATE SCHEMA [Utility] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Reservation]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Reservation')
EXEC sys.sp_executesql N'CREATE SCHEMA [Reservation] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Report]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Report')
EXEC sys.sp_executesql N'CREATE SCHEMA [Report] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Organization]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Organization')
EXEC sys.sp_executesql N'CREATE SCHEMA [Organization] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Navigator]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Navigator')
EXEC sys.sp_executesql N'CREATE SCHEMA [Navigator] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Lodge]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Lodge')
EXEC sys.sp_executesql N'CREATE SCHEMA [Lodge] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [License]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'License')
EXEC sys.sp_executesql N'CREATE SCHEMA [License] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Invoice]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Invoice')
EXEC sys.sp_executesql N'CREATE SCHEMA [Invoice] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Guardian]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Guardian')
EXEC sys.sp_executesql N'CREATE SCHEMA [Guardian] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Customer]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Customer')
EXEC sys.sp_executesql N'CREATE SCHEMA [Customer] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Configuration]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Configuration')
EXEC sys.sp_executesql N'CREATE SCHEMA [Configuration] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [BinAff]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'BinAff')
EXEC sys.sp_executesql N'CREATE SCHEMA [BinAff] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [AutoTourism]    Script Date: 07/22/2014 16:34:09 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'AutoTourism')
EXEC sys.sp_executesql N'CREATE SCHEMA [AutoTourism] AUTHORIZATION [dbo]'
GO
/****** Object:  Table [Configuration].[IdentityProofType]    Script Date: 07/22/2014 16:34:16 ******/
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
/****** Object:  Table [BinAff].[DateStamp]    Script Date: 07/22/2014 16:34:16 ******/
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
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [BinAff].[DateStamp] ([Stamp]) VALUES (N'7ERyagX6RydGhccM+e3OeA==')
/****** Object:  Table [License].[Credential]    Script Date: 07/22/2014 16:34:16 ******/
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
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Invoice].[Invoice]    Script Date: 07/22/2014 16:34:16 ******/
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
SET IDENTITY_INSERT [Invoice].[Invoice] ON
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(11 AS Numeric(10, 0)), N'A12345', CAST(0x0000A1E00138A10A AS DateTime), 0.0000, 0.0000, N'SL', N'HSR Layout', N'1236547896', N'bir@dd.com', N'A123', N'BY', N'', N'', N'')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(13 AS Numeric(10, 0)), N'B12345', CAST(0x0000A1F400E42C61 AS DateTime), 0.0000, 0.0000, N'SL', N'HSR Layout', N'1236547896', N'bir@dd.com', N'A123', N'BY', N'', N'', N'')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(14 AS Numeric(10, 0)), N'INVO-02-04-201413524', CAST(0x0000A30100E48970 AS DateTime), 1000.0000, 500.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Mr Arpan  ', N'Garia', N'+91-22-22222222', N'+91-22-22222222')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(15 AS Numeric(10, 0)), N'INVO-23-05-2014154016', CAST(0x0000A33401024311 AS DateTime), 0.0000, 2750.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Arpan  Kar', N'Vijaya Nilaya', N'+91-88-78654367', N'+91-88-78654367')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(16 AS Numeric(10, 0)), N'INVO-23-05-2014162258', CAST(0x0000A334010DFCFE AS DateTime), 0.0000, 2750.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Arpan  Kar', N'Vijaya Nilaya', N'+91-88-78654367', N'+91-88-78654367')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(17 AS Numeric(10, 0)), N'INVO-23-05-2014162722', CAST(0x0000A334010F3308 AS DateTime), 0.0000, 2750.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Arpan  Kar', N'Vijaya Nilaya', N'+91-88-78654367', N'+91-88-78654367')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(18 AS Numeric(10, 0)), N'INVO-23-05-2014225312', CAST(0x0000A334017929BB AS DateTime), 0.0000, 2750.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Abhi  Dey', N'iuob', N'+91-88-98653456', N'+91-88-98653456')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(19 AS Numeric(10, 0)), N'INVO-23-05-2014232441', CAST(0x0000A3340181CFF4 AS DateTime), 0.0000, 2750.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Binay  Halder', N'Kottaputtam', N'+91-80-98786545', N'+91-80-98786545')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(20 AS Numeric(10, 0)), N'INVO-23-05-2014232716', CAST(0x0000A33401828532 AS DateTime), 0.0000, 2750.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Ambalika  ', N'mnfjfdkjfd', N'+91-88-78905645', N'+91-88-78905645')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(21 AS Numeric(10, 0)), N'INVO-23-05-2014233251', CAST(0x0000A33401840DA1 AS DateTime), 0.0000, 0.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Ambalika  ', N'mnfjfdkjfd', N'+91-88-78905645', N'+91-88-78905645')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(22 AS Numeric(10, 0)), N'INVO-25-05-2014161653', CAST(0x0000A336010C4FE5 AS DateTime), 0.0000, 0.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Ambalika  ', N'mnfjfdkjfd', N'+91-88-78905645', N'+91-88-78905645')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(24 AS Numeric(10, 0)), N'INVO-30-05-2014111553', CAST(0x0000A33B00B9D38C AS DateTime), 0.0000, 1000.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Misti  Basu', N'Behala', N'+91-8978676543', N'+91-8978676543')
INSERT [Invoice].[Invoice] ([Id], [InvoiceNumber], [Date], [Advance], [Discount], [SellerName], [SellerAddress], [SellerContactNo], [SellerEmail], [SellerLicence], [BuyerName], [BuyerAddress], [BuyerContactNo], [BuyerEmail]) VALUES (CAST(28 AS Numeric(10, 0)), N'INVO-30-05-2014112744', CAST(0x0000A33B00BCFA75 AS DateTime), 0.0000, 100.0000, N'ABC Lodge', N'Bangalore, Old Airport Road', N'9876567824', N'xya@yahoo.com', N'ABC237B', N'Misti  Basu', N'Behala', N'+91-8978676543', N'+91-8978676543')
SET IDENTITY_INSERT [Invoice].[Invoice] OFF
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 07/22/2014 16:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Invoice].[InvoicePaymentLinkRead]
	 (
		@InvoiceId Numeric(10,0)
	 )
	 As
	 Begin
		Select  [InvoiceId],[PaymentId]
		From [Invoice].InvoicePaymentLink
		Where InvoiceId = @InvoiceId
	 End
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 07/22/2014 16:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Invoice].[InvoicePaymentLinkInsert]
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
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 07/22/2014 16:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[InvoicePaymentLinkDelete]
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
/****** Object:  Table [Utility].[Importance]    Script Date: 07/22/2014 16:34:26 ******/
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
/****** Object:  Table [Configuration].[Initial]    Script Date: 07/22/2014 16:34:26 ******/
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
/****** Object:  Table [Configuration].[Country]    Script Date: 07/22/2014 16:34:26 ******/
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
/****** Object:  Table [License].[Component]    Script Date: 07/22/2014 16:34:26 ******/
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
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 07/22/2014 16:34:26 ******/
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
END' 
END
GO
/****** Object:  Table [Report].[Category]    Script Date: 07/22/2014 16:34:26 ******/
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
/****** Object:  Table [Lodge].[BuildingStatus]    Script Date: 07/22/2014 16:34:26 ******/
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
/****** Object:  Table [Lodge].[BuildingType]    Script Date: 07/22/2014 16:34:27 ******/
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
/****** Object:  Table [Utility].[AppointmentType]    Script Date: 07/22/2014 16:34:27 ******/
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
/****** Object:  Table [Guardian].[Account]    Script Date: 07/22/2014 16:34:27 ******/
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
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[Guardian].[Account]') AND name = N'IX_Account')
CREATE NONCLUSTERED INDEX [IX_Account] ON [Guardian].[Account] 
(
	[LoginId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Guardian].[Account] ON
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(1 AS Numeric(10, 0)), N'ArpanKar', N'BinAff@1')
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(6 AS Numeric(10, 0)), N'BDhekial', N'BinAff@1')
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(7 AS Numeric(10, 0)), N'Biraj', N'BinAff@1')
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(11 AS Numeric(10, 0)), N'Recep', N'BinAff@1')
INSERT [Guardian].[Account] ([Id], [LoginId], [Password]) VALUES (CAST(12 AS Numeric(10, 0)), N'All', N'BinAff@1')
SET IDENTITY_INSERT [Guardian].[Account] OFF
/****** Object:  Table [Customer].[ActionStatus]    Script Date: 07/22/2014 16:34:27 ******/
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
/****** Object:  Table [License].[Module]    Script Date: 07/22/2014 16:34:27 ******/
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
/****** Object:  Table [Organization].[Organization]    Script Date: 07/22/2014 16:34:27 ******/
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
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Organization].[Organization] ON
INSERT [Organization].[Organization] ([Id], [Name], [Logo], [LicenceNumber], [ServiceTaxNumber], [LuxuaryTaxNumber], [Tan], [Address], [City], [StateId], [Pin], [ContactName]) VALUES (CAST(12 AS Numeric(10, 0)), N'ABC Lodge', NULL, N'ABC237B', NULL, NULL, N'ABCD12345E', N'Bangalore, Old Airport Road', N'Bangalore', CAST(1 AS Numeric(10, 0)), 560017, N'Manjunath')
SET IDENTITY_INSERT [Organization].[Organization] OFF
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkRead]
	 (
		@InvoiceId Numeric(10,0)
	 )
	 As
	 Begin
		Select  [InvoiceId],[TaxationId]
		From [Invoice].InvoiceTaxationLink
		Where InvoiceId = @InvoiceId
	 End' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkInsert]
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkDelete]
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
/****** Object:  Table [Invoice].[PaymentType]    Script Date: 07/22/2014 16:34:27 ******/
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
SET IDENTITY_INSERT [Invoice].[PaymentType] OFF
/****** Object:  StoredProcedure [dbo].[OrganizationRead]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--CREATE TABLE [dbo].[Organization](
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
	Begin
		SELECT Top 1
				Id,
				[Name],
				[Logo],
				[LicenceNumber],
				[Tan],
				[Address],
				[City],
				[StateId],
				[Pin],
				[ContactName]
			FROM Organization
	End
	Else
	Begin	
		SELECT 
			Id,
			[Name],
			[Logo],
			[LicenceNumber],
			[Tan],
			[Address],
			[City],
			[StateId],
			[Pin],
			[ContactName]
		FROM Organization
		WHERE Id = @Id   
	End
	
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationUpdate]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
Create PROCEDURE [dbo].[OrganizationUpdate]
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
	
	UPDATE Organization
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
   
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationInsert]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

Create PROCEDURE [dbo].[OrganizationInsert]
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
	
	INSERT INTO Organization([Name],[Logo],[LicenceNumber],[Tan],[Address],[City],[StateId],[Pin],[ContactName])
	VALUES(@Name,@Logo,@LicenceNumber,@Tan,@Address,@City,@StateId,@Pin,@ContactName)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationEmailRead]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationEmailRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--CREATE TABLE [dbo].[Organization](
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
	
	SELECT 
		Id,
		[LodgeId],
		[Email]
	FROM OrganizationEmail
	WHERE Id = @Id   
	
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[EmailReadForParent]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
Create PROCEDURE [dbo].[EmailReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[OrganizationId],
		[Email]
	FROM OrganizationEmail
	WHERE OrganizationId = @ParentId   
	
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[EmailRead]    Script Date: 07/22/2014 16:34:27 ******/
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
	
	SELECT 
		Id,
		[OrganizationId],
		[Email]
	FROM OrganizationEmail
	WHERE OrganizationId = @Id   
	
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[EmailInsert]    Script Date: 07/22/2014 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
Create PROCEDURE [dbo].[EmailInsert]
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
/****** Object:  Table [Invoice].[PaymentArtifact]    Script Date: 07/22/2014 16:34:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Invoice].[PaymentArtifact] ON
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(1 AS Numeric(10, 0)), NULL, CAST(412 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(2 AS Numeric(10, 0)), NULL, CAST(413 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(3 AS Numeric(10, 0)), NULL, CAST(414 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[PaymentArtifact] ([Id], [PaymentId], [ArtifactId], [Category]) VALUES (CAST(4 AS Numeric(10, 0)), NULL, CAST(415 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Invoice].[PaymentArtifact] OFF
/****** Object:  Table [Invoice].[Report]    Script Date: 07/22/2014 16:34:28 ******/
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
/****** Object:  Table [Customer].[Report]    Script Date: 07/22/2014 16:34:28 ******/
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
SET IDENTITY_INSERT [Customer].[Report] ON
INSERT [Customer].[Report] ([Id], [Date], [ReportCategoryId]) VALUES (CAST(28 AS Numeric(10, 0)), CAST(0x0000A31100000000 AS DateTime), CAST(10001 AS Numeric(10, 0)))
INSERT [Customer].[Report] ([Id], [Date], [ReportCategoryId]) VALUES (CAST(38 AS Numeric(10, 0)), CAST(0x0000A31B00000000 AS DateTime), CAST(10003 AS Numeric(10, 0)))
INSERT [Customer].[Report] ([Id], [Date], [ReportCategoryId]) VALUES (CAST(39 AS Numeric(10, 0)), CAST(0x0000A31C00000000 AS DateTime), CAST(10005 AS Numeric(10, 0)))
INSERT [Customer].[Report] ([Id], [Date], [ReportCategoryId]) VALUES (CAST(40 AS Numeric(10, 0)), CAST(0x0000A30D00000000 AS DateTime), CAST(10002 AS Numeric(10, 0)))
INSERT [Customer].[Report] ([Id], [Date], [ReportCategoryId]) VALUES (CAST(41 AS Numeric(10, 0)), CAST(0x0000A30D00000000 AS DateTime), CAST(10002 AS Numeric(10, 0)))
INSERT [Customer].[Report] ([Id], [Date], [ReportCategoryId]) VALUES (CAST(42 AS Numeric(10, 0)), CAST(0x0000A31100000000 AS DateTime), CAST(10001 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Customer].[Report] OFF
/****** Object:  Table [Lodge].[RoomCategory]    Script Date: 07/22/2014 16:34:28 ******/
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
/****** Object:  Table [Guardian].[Role]    Script Date: 07/22/2014 16:34:28 ******/
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
/****** Object:  Table [Lodge].[RoomType]    Script Date: 07/22/2014 16:34:28 ******/
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
INSERT [Lodge].[RoomType] ([Id], [Name]) VALUES (CAST(1 AS Numeric(10, 0)), N'Single Bed Room')
INSERT [Lodge].[RoomType] ([Id], [Name]) VALUES (CAST(2 AS Numeric(10, 0)), N'Double Bed Room')
SET IDENTITY_INSERT [Lodge].[RoomType] OFF
/****** Object:  Table [Navigator].[Rule]    Script Date: 07/22/2014 16:34:28 ******/
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
/****** Object:  Table [Customer].[Rule]    Script Date: 07/22/2014 16:34:28 ******/
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
/****** Object:  Table [Configuration].[Rule]    Script Date: 07/22/2014 16:34:28 ******/
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
/****** Object:  Table [Lodge].[RoomStatus]    Script Date: 07/22/2014 16:34:28 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 07/22/2014 16:34:28 ******/
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
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 07/22/2014 16:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Reservation].[StatusReadAll]	
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Reservation].[Status]		
		
	END' 
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 07/22/2014 16:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Reservation].[StatusRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Reservation].[Status]
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 07/22/2014 16:34:28 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 07/22/2014 16:34:28 ******/
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
   
END' 
END
GO
/****** Object:  Table [Invoice].[Taxation]    Script Date: 07/22/2014 16:34:29 ******/
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
INSERT [Invoice].[Taxation] ([Id], [Name], [Amount], [IsPercentage]) VALUES (CAST(1 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 1)
INSERT [Invoice].[Taxation] ([Id], [Name], [Amount], [IsPercentage]) VALUES (CAST(2 AS Numeric(10, 0)), N'Luxury Tax', 12.5000, 1)
SET IDENTITY_INSERT [Invoice].[Taxation] OFF
/****** Object:  Table [Guardian].[SecurityQuestion]    Script Date: 07/22/2014 16:34:29 ******/
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
/****** Object:  Table [BinAff].[Stamp]    Script Date: 07/22/2014 16:34:29 ******/
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
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [BinAff].[Stamp] ([ProductId], [ProductName], [FingurePrint], [LicenseDate], [RegistrationDate]) VALUES (N'PD-WIN-001', N'Splash', N'R4tZ4idF5mQTwug938uR+6Ekh883C5evDqaXFHpvAJJUeyYPvQ3pUv2ljnBnPITK', N'd+sexjE11ls81ltPP/LjRA==', N'd+sexjE11ls81ltPP/LjRA==')
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 07/22/2014 16:34:31 ******/
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
END

' 
END
GO
/****** Object:  Table [Guardian].[UserRule]    Script Date: 07/22/2014 16:34:31 ******/
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
/****** Object:  Table [Guardian].[UserRole]    Script Date: 07/22/2014 16:34:31 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 07/22/2014 16:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Guardian].[UserRuleRead] 
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	Select 
		DefaultPassword	
	From UserRule
 
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 07/22/2014 16:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Guardian].[UserRuleInsert]
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
/****** Object:  Table [Configuration].[State]    Script Date: 07/22/2014 16:34:31 ******/
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
/****** Object:  Table [Invoice].[Slab]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 07/22/2014 16:34:32 ******/
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
	FROM [Guardian].securityQuestion 
	WHERE Question = @Name				
END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 07/22/2014 16:34:32 ******/
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
	FROM SecurityQuestion   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 07/22/2014 16:34:32 ******/
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
	FROM SecurityQuestion
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].RoomType
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeReadAll]
	As
	Begin
		Select Id,Name
		From [Lodge].RoomType
	End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 07/22/2014 16:34:32 ******/
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
		
		SELECT 
			Id,
			[Name]
		FROM [Lodge].RoomType
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomType([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 07/22/2014 16:34:32 ******/
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
		FROM [Lodge].RoomType
		WHERE Id = @Id      
	END' 
END
GO
/****** Object:  Table [Guardian].[SecurityAnswer]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Invoice].[Update]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

Create PROCEDURE [Invoice].[Update]
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
/****** Object:  StoredProcedure [Invoice].[TaxationUpdate]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[TaxationUpdate]
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
/****** Object:  StoredProcedure [Invoice].[TaxationReadDuplicate]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[TaxationReadDuplicate]
(
	@Name VARCHAR(50)		
)
AS
BEGIN
	SELECT Id	
	FROM [Invoice].Taxation 
	WHERE Name = @Name				
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


create PROCEDURE [Lodge].[TaxationReadAll]
AS
BEGIN
	
	SELECT 
		Id,		
		[Name],
		[Amount],
		[IsPercentage]
	FROM [Invoice].Taxation
   
END


' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadAll]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[TaxationReadAll]
AS
BEGIN
	
	SELECT 
		Id,		
		[Name],
		[Amount],
		[IsPercentage]
	FROM [Invoice].Taxation
   
END

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




Create PROCEDURE [Lodge].[TaxationRead]
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
	FROM [Invoice].Taxation
	WHERE Id = @Id   
	
END


' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Invoice].[TaxationRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id,	Name, Amount, IsPercentage
	FROM Invoice.Taxation
	WHERE Id = @Id
	
	
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[TaxationInsert]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Invoice].[TaxationInsert]
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
/****** Object:  StoredProcedure [Invoice].[TaxationDelete]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[TaxationDelete]
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[RoomReservationStatusReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Customer].ActionStatus
		
	END

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

create PROCEDURE [Lodge].[RoomReservationStatusRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN		
		SELECT 
			Id,
			[Name]
		FROM [Customer].ActionStatus
		WHERE Id = @Id   
		
	END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 07/22/2014 16:34:32 ******/
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
	FROM Navigator.[Rule]
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Customer].[RuleRead]  
	(  
	   @Id Numeric(10,0)  
	)  
	AS  
	BEGIN  
	   
		Select 
		IsNull(IsPinNo,0) IsPinNo,
		IsNull(IsAlternateContactNo,0) IsAlternateContactNo,
		IsNull(IsEmail,0) IsEmail,
		IsNull(IsIdentityProof,0) IsIdentityProof 
		From Customer.[Rule]
	 
	END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Configuration].[RuleRead]
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	Select 
	[DateFormat]		
	From [Configuration].[Rule]
 
END

' 
END
GO
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Configuration].[RuleInsert]
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
/****** Object:  Table [Lodge].[RoomTariff]    Script Date: 07/22/2014 16:34:32 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomStatusRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Lodge].RoomStatus
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE  [Lodge].[RoomStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].RoomStatus
	WHERE Id = @Id      
END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadForInvoiceNumber]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadForInvoiceNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[ReadForInvoiceNumber]
(
	@InvoiceNumber Varchar(50)
)
AS
BEGIN		
	SELECT 
		Id
	FROM [Invoice].Invoice
	WHERE InvoiceNumber = @InvoiceNumber 
	
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadDuplicate]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

Create PROCEDURE [Invoice].[ReadDuplicate]
(
	@InvoiceNumber VARCHAR(50)		
)
AS
BEGIN
	SELECT Id	
	FROM [Invoice].Invoice
	WHERE InvoiceNumber = @InvoiceNumber		
END' 
END
GO
/****** Object:  Table [Lodge].[RoomReservation]    Script Date: 07/22/2014 16:34:32 ******/
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
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[RoomReservation] ON
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(48 AS Numeric(10, 0)), CAST(0x0000A19A00000000 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, NULL, NULL, CAST(0x0000A19500AB1B03 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(51 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 1, 1, 0, 1, 2, NULL, NULL, NULL, NULL, CAST(0x0000A19A01013163 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(52 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 1, 1, 0, 2, 2, NULL, NULL, NULL, NULL, CAST(0x0000A19A010C295B AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(53 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 1, 1, 0, 0, 2, NULL, NULL, NULL, NULL, CAST(0x0000A19A0115A5E2 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(54 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 2, 0, 0, 0, 2, NULL, NULL, NULL, NULL, CAST(0x0000A19A01161C77 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(55 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 0, 2, 0, 0, 2, NULL, NULL, NULL, NULL, CAST(0x0000A19A01166AE6 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(56 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 1, 1, 0, 0, 2, NULL, NULL, NULL, NULL, CAST(0x0000A19A0116C104 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 1, 1, 0, 1, 2, NULL, NULL, NULL, NULL, CAST(0x0000A19A011B6B43 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(58 AS Numeric(10, 0)), CAST(0x0000A1B300000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 1, 1, 0, 0, 2, NULL, NULL, NULL, NULL, CAST(0x0000A1AE00C26C9A AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(59 AS Numeric(10, 0)), CAST(0x0000A1BB00000000 AS DateTime), CAST(2 AS Numeric(3, 0)), 1, 1, 0, 0, 1, NULL, NULL, NULL, NULL, CAST(0x0000A1B800C11C34 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(61 AS Numeric(10, 0)), CAST(0x0000A31900B816F4 AS DateTime), CAST(1 AS Numeric(3, 0)), 0, 1, 0, 0, 1, NULL, NULL, 0, NULL, CAST(0x0000A2CB00B826F9 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(62 AS Numeric(10, 0)), CAST(0x0000A31100AB37A4 AS DateTime), CAST(2 AS Numeric(3, 0)), 0, 2, 0, 2, 2, NULL, NULL, 0, NULL, CAST(0x0000A2CB00BBC012 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(63 AS Numeric(10, 0)), CAST(0x0000A2DA015F1E54 AS DateTime), CAST(1 AS Numeric(3, 0)), 0, 1, 0, 1, 1, NULL, NULL, NULL, NULL, CAST(0x0000A2CC015F472B AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(64 AS Numeric(10, 0)), CAST(0x0000A2D001712E8C AS DateTime), CAST(1 AS Numeric(3, 0)), 0, 1, 0, 1, 2, NULL, NULL, NULL, NULL, CAST(0x0000A2CC01714FF7 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(65 AS Numeric(10, 0)), CAST(0x0000A2D20179C754 AS DateTime), CAST(1 AS Numeric(3, 0)), 0, 1, 0, 0, 1, NULL, NULL, NULL, NULL, CAST(0x0000A2CC0179E146 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(66 AS Numeric(10, 0)), CAST(0x0000A2E0017A3EDC AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, NULL, NULL, CAST(0x0000A2CC017A5AE0 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(67 AS Numeric(10, 0)), CAST(0x0000A2D100A81998 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, NULL, NULL, CAST(0x0000A2CE00A8319A AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(68 AS Numeric(10, 0)), CAST(0x0000A2CF00BBF8B4 AS DateTime), CAST(1 AS Numeric(3, 0)), 0, 1, 0, 1, 1, NULL, NULL, NULL, NULL, CAST(0x0000A2CE00BC1687 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(69 AS Numeric(10, 0)), CAST(0x0000A2D100CACB3C AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, NULL, CAST(0x0000A2D100CAEEEC AS DateTime), CAST(10003 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(70 AS Numeric(10, 0)), CAST(0x0000A2D100CB3BBC AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 1, 1, 0, 1, CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, NULL, CAST(0x0000A2D100CB6115 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(71 AS Numeric(10, 0)), CAST(0x0000A2D300CB997C AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, NULL, CAST(0x0000A2D100CBBB1B AS DateTime), CAST(10003 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(72 AS Numeric(10, 0)), CAST(0x0000A35A010A0D60 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, N'', CAST(0x0000A2D501016455 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(73 AS Numeric(10, 0)), CAST(0x0000A2D900C35D48 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, NULL, CAST(0x0000A2D900C38DE0 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(74 AS Numeric(10, 0)), CAST(0x0000A2DA00C40608 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, NULL, CAST(0x0000A2D900C4233F AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(75 AS Numeric(10, 0)), CAST(0x0000A310015DE570 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, NULL, CAST(0x0000A2DC015E7160 AS DateTime), CAST(10002 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(76 AS Numeric(10, 0)), CAST(0x0000A2F400CE67D8 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, NULL, CAST(0x0000A2F400CE9049 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(77 AS Numeric(10, 0)), CAST(0x0000A30100E31AB6 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, NULL, CAST(0x0000A30100E3054E AS DateTime), CAST(10002 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(78 AS Numeric(10, 0)), CAST(0x0000A30A00ACAEA4 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, NULL, CAST(0x0000A30A00AD01F6 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(79 AS Numeric(10, 0)), CAST(0x0000A31000C8DDE0 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, NULL, CAST(0x0000A31000C90E95 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(80 AS Numeric(10, 0)), CAST(0x0000A311017FD234 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 1, 0, 0, 1, NULL, NULL, 0, NULL, CAST(0x0000A3100180096C AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(81 AS Numeric(10, 0)), CAST(0x0000A31700CC24F0 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A31700CCAF4C AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(87 AS Numeric(10, 0)), CAST(0x0000A32A00C58B18 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A00C5A33A AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(88 AS Numeric(10, 0)), CAST(0x0000A32A00C58B18 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A00CACCC6 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(89 AS Numeric(10, 0)), CAST(0x0000A32A00C58B18 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A00CB4BC4 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(90 AS Numeric(10, 0)), CAST(0x0000A32A00C58B18 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A00CD04A5 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(108 AS Numeric(10, 0)), CAST(0x0000A32A0101C8F8 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A0101DB05 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(109 AS Numeric(10, 0)), CAST(0x0000A32A00C58B18 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A0117E2E4 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(110 AS Numeric(10, 0)), CAST(0x0000A32A00C58B18 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A01183BD4 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(111 AS Numeric(10, 0)), CAST(0x0000A32A00C58B18 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A01194C54 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(112 AS Numeric(10, 0)), CAST(0x0000A32A00C58B18 AS DateTime), CAST(2 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A011D3EB1 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(113 AS Numeric(10, 0)), CAST(0x0000A32D00C58B18 AS DateTime), CAST(2 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32A011D64F1 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(114 AS Numeric(10, 0)), CAST(0x0000A32C010E8070 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32C010EA97B AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(118 AS Numeric(10, 0)), CAST(0x0000A32F00AD6DA8 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32D00AD80C3 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(119 AS Numeric(10, 0)), CAST(0x0000A32D01793154 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32D0179482F AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(120 AS Numeric(10, 0)), CAST(0x0000A32F016526DC AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A32F016541D1 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(121 AS Numeric(10, 0)), CAST(0x0000A3300096C990 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A3300096DC72 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(122 AS Numeric(10, 0)), CAST(0x0000A33000C0FE40 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A33000C11790 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(123 AS Numeric(10, 0)), CAST(0x0000A3340178A004 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A3340178B74B AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(124 AS Numeric(10, 0)), CAST(0x0000A334018162FC AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A33401817821 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(125 AS Numeric(10, 0)), CAST(0x0000A334018220D4 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A33401822C81 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(126 AS Numeric(10, 0)), CAST(0x0000A3360108C8C4 AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A336010B8381 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(127 AS Numeric(10, 0)), CAST(0x0000A33800ECF26F AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A33800ECB979 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(128 AS Numeric(10, 0)), CAST(0x0000A345011E458C AS DateTime), CAST(1 AS Numeric(3, 0)), NULL, NULL, NULL, 1, 1, NULL, NULL, 0, NULL, CAST(0x0000A345011E6C43 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(131 AS Numeric(10, 0)), CAST(0x0000A3570116DFCC AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, N'', CAST(0x0000A3570116F43A AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(132 AS Numeric(10, 0)), CAST(0x0000A35701175754 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, N'', CAST(0x0000A35701175213 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(133 AS Numeric(10, 0)), CAST(0x0000A35A00FBFD60 AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, N'', CAST(0x0000A35A00FC1706 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfMale], [NoOfFemale], [NoOfChild], [NoOfInfant], [NoOfRooms], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Remark], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(134 AS Numeric(10, 0)), CAST(0x0000A36D002739CC AS DateTime), CAST(1 AS Numeric(3, 0)), 1, 0, 0, 0, 1, NULL, NULL, 0, N'', CAST(0x0000A36D0027724C AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
SET IDENTITY_INSERT [Lodge].[RoomReservation] OFF
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 07/22/2014 16:34:32 ******/
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
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomCategoryReadAll]
	As
	Begin
		Select Id,Name
		From [Lodge].RoomCategory
	End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomCategoryRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Lodge].RoomCategory
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 07/22/2014 16:34:32 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 07/22/2014 16:34:32 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 07/22/2014 16:34:32 ******/
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
	FROM Guardian.Role
END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 07/22/2014 16:34:32 ******/
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
	FROM  Guardian.[Role]
	WHERE Id = @Id
END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 07/22/2014 16:34:32 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReportInsert]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [Invoice].[ReportInsert]
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
/****** Object:  StoredProcedure [Customer].[ReportInsert]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

Create PROCEDURE [Customer].[ReportInsert]
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
/****** Object:  StoredProcedure [Invoice].[ReportReadAll]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Invoice].[ReportReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Date],
		[ReportCategoryId]		
	FROM [Invoice].Report
   
END


' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReportReadAll]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


create PROCEDURE [Customer].[ReportReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Date],
		[ReportCategoryId]		
	FROM [Customer].Report
   
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReportRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [Invoice].[ReportRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	
	SELECT 
		Id,
		[Date],
		[ReportCategoryId]	
	FROM [Invoice].Report
	WHERE Id = @Id   
	
END


' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReportRead]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

create PROCEDURE [Customer].[ReportRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	
	SELECT 
		Id,
		[Date],
		[ReportCategoryId]	
	FROM [Customer].Report
	WHERE Id = @Id   
	
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadAll]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


Create PROCEDURE [Invoice].[ReadAll]
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
	FROM [Invoice].Invoice
   
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[Read]    Script Date: 07/22/2014 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Read]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


Create PROCEDURE [Invoice].[Read]
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
		
	FROM [Invoice].Invoice
	WHERE Id = @Id   
	
END

' 
END
GO
/****** Object:  Table [Guardian].[Profile]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeUpdate]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Invoice].[PaymentTypeUpdate]
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadDuplicate]    Script Date: 07/22/2014 16:34:33 ******/
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
	FROM [Invoice].PaymentType 
	WHERE Name = @Name				
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadAll]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Invoice].[PaymentTypeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Invoice].PaymentType
   
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeRead]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Invoice].[PaymentTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Invoice].PaymentType
	WHERE Id = @Id   
	
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeInsert]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[PaymentTypeInsert]
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeDelete]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Invoice].[PaymentTypeDelete]
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
/****** Object:  Table [Invoice].[Payment]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Payment]') AND type in (N'U'))
BEGIN
CREATE TABLE [Invoice].[Payment](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CardNumber] [varchar](16) NULL,
	[Remark] [varchar](255) NULL,
	[PaymentTypeId] [numeric](10, 0) NOT NULL,
	[InvoiceId] [numeric](10, 0) NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Invoice].[Payment] ON
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E48979 AS DateTime), N'', N'', CAST(2 AS Numeric(10, 0)), CAST(14 AS Numeric(10, 0)), 10000.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(0x0000A30100E48979 AS DateTime), N'9876', N'', CAST(2 AS Numeric(10, 0)), CAST(14 AS Numeric(10, 0)), 12500.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(3 AS Numeric(10, 0)), CAST(0x0000A3340102431E AS DateTime), N'2345', N'', CAST(2 AS Numeric(10, 0)), CAST(15 AS Numeric(10, 0)), 10000.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(0x0000A334010DFD00 AS DateTime), N'2334', N'', CAST(2 AS Numeric(10, 0)), CAST(16 AS Numeric(10, 0)), 10000.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(5 AS Numeric(10, 0)), CAST(0x0000A334010F330A AS DateTime), N'2765', N'', CAST(2 AS Numeric(10, 0)), CAST(17 AS Numeric(10, 0)), 10000.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(6 AS Numeric(10, 0)), CAST(0x0000A334017929BC AS DateTime), N'4534', N'', CAST(2 AS Numeric(10, 0)), CAST(18 AS Numeric(10, 0)), 10000.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(0x0000A3340181CFF5 AS DateTime), N'2987', N'', CAST(2 AS Numeric(10, 0)), CAST(19 AS Numeric(10, 0)), 10000.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(8 AS Numeric(10, 0)), CAST(0x0000A33401828532 AS DateTime), N'5433', N'', CAST(2 AS Numeric(10, 0)), CAST(20 AS Numeric(10, 0)), 10000.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(9 AS Numeric(10, 0)), CAST(0x0000A33401840DA2 AS DateTime), N'2222', N'', CAST(2 AS Numeric(10, 0)), CAST(21 AS Numeric(10, 0)), 24000.0000)
INSERT [Invoice].[Payment] ([Id], [Date], [CardNumber], [Remark], [PaymentTypeId], [InvoiceId], [Amount]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(0x0000A336010C4FFB AS DateTime), N'2342', N'', CAST(4 AS Numeric(10, 0)), CAST(22 AS Numeric(10, 0)), 12750.0000)
SET IDENTITY_INSERT [Invoice].[Payment] OFF
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 07/22/2014 16:34:33 ******/
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

END' 
END
GO
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 07/22/2014 16:34:33 ******/
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
   
END' 
END
GO
/****** Object:  Table [Guardian].[LoginHistory]    Script Date: 07/22/2014 16:34:33 ******/
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
SET IDENTITY_INSERT [Guardian].[LoginHistory] OFF
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactUpdateLink]    Script Date: 07/22/2014 16:34:33 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactReadLink]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [Invoice].[PaymentArtifactReadLink]
(
	@ArtifactId Numeric(10,0)--,
	--@Category Numeric(1)
)
AS
BEGIN
	
	SELECT Id, PaymentId ComponentId
	FROM Invoice.PaymentArtifact
	WHERE ArtifactId = @ArtifactId
		--AND Category =  @Category
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactInsertLink]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Invoice].[PaymentArtifactInsertLink]
(
        @ComponentId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO Invoice.PaymentArtifact(PaymentId, ArtifactId, Category)
        VALUES(@ComponentId, @ArtifactId, @Category)
 
END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentArtifactDeleteLink]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[PaymentArtifactDeleteLink]
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
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 07/22/2014 16:34:33 ******/
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
	FROM [Organization].[Organization]
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  StoredProcedure [Invoice].[Delete]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
Create PROCEDURE [Invoice].[Delete]
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
/****** Object:  Table [Invoice].[LineItem]    Script Date: 07/22/2014 16:34:33 ******/
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
SET IDENTITY_INSERT [Invoice].[LineItem] ON
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(16 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), CAST(0x0000A1E000000000 AS DateTime), CAST(0x0000A1E000000000 AS DateTime), N'Bx 150', 1572.7500, 3)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(17 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), CAST(0x0000A1E000000000 AS DateTime), CAST(0x0000A1E000000000 AS DateTime), N'Zx 750', 1572.7500, 2)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(20 AS Numeric(10, 0)), CAST(13 AS Numeric(10, 0)), CAST(0x0000A1F400000000 AS DateTime), CAST(0x0000A1F400000000 AS DateTime), N'Bx 150', 1572.7500, 3)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(13 AS Numeric(10, 0)), CAST(0x0000A1F400000000 AS DateTime), CAST(0x0000A1F400000000 AS DateTime), N'Zx 750', 1572.7500, 2)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(14 AS Numeric(10, 0)), CAST(0x0000A30100E31AB6 AS DateTime), CAST(0x0000A30200E31AB6 AS DateTime), N'Suit, Single Bed Room, AC', 20000.0000, 1)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(15 AS Numeric(10, 0)), CAST(0x0000A3300096C990 AS DateTime), CAST(0x0000A3310096C990 AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 1)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(16 AS Numeric(10, 0)), CAST(0x0000A3300096C990 AS DateTime), CAST(0x0000A3310096C990 AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 1)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(25 AS Numeric(10, 0)), CAST(17 AS Numeric(10, 0)), CAST(0x0000A3300096C990 AS DateTime), CAST(0x0000A3310096C990 AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 1)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(26 AS Numeric(10, 0)), CAST(18 AS Numeric(10, 0)), CAST(0x0000A3340178A004 AS DateTime), CAST(0x0000A3350178A004 AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 1)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(27 AS Numeric(10, 0)), CAST(19 AS Numeric(10, 0)), CAST(0x0000A334018162FC AS DateTime), CAST(0x0000A335018162FC AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 1)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(28 AS Numeric(10, 0)), CAST(20 AS Numeric(10, 0)), CAST(0x0000A334018220D4 AS DateTime), CAST(0x0000A335018220D4 AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 1)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(29 AS Numeric(10, 0)), CAST(21 AS Numeric(10, 0)), CAST(0x0000A334018220D4 AS DateTime), CAST(0x0000A335018220D4 AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 2)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(30 AS Numeric(10, 0)), CAST(22 AS Numeric(10, 0)), CAST(0x0000A3360108C8C4 AS DateTime), CAST(0x0000A3370108C8C4 AS DateTime), N'Economy, Single Bed Room, AC', 10000.0000, 1)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(32 AS Numeric(10, 0)), CAST(24 AS Numeric(10, 0)), CAST(0x0000A33800ECF26F AS DateTime), CAST(0x0000A33900ECF26F AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 2)
INSERT [Invoice].[LineItem] ([Id], [InvoiceId], [Start], [End], [Description], [UnitRate], [Count]) VALUES (CAST(35 AS Numeric(10, 0)), CAST(28 AS Numeric(10, 0)), CAST(0x0000A33800ECF26F AS DateTime), CAST(0x0000A33900ECF26F AS DateTime), N'Delux, Double Bed Room, AC', 10000.0000, 2)
SET IDENTITY_INSERT [Invoice].[LineItem] OFF
/****** Object:  StoredProcedure [Invoice].[Insert]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
	
	

CREATE PROCEDURE [Invoice].[Insert]
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
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 07/22/2014 16:34:33 ******/
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
	FROM [Configuration].Initial 
	WHERE Name = @Name				
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[InitialReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].Initial
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 07/22/2014 16:34:33 ******/
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
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].Initial
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  Table [Invoice].[InvoiceTaxation]    Script Date: 07/22/2014 16:34:33 ******/
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
SET IDENTITY_INSERT [Invoice].[InvoiceTaxation] ON
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(1 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(14 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(2 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(14 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(3 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(15 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(4 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(15 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(5 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(16 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(6 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(16 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(7 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(17 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(8 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(17 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(9 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(18 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(10 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(18 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(11 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(19 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(12 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(19 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(15 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(21 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(16 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(21 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(13 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(20 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(14 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(20 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(17 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0, CAST(22 AS Numeric(10, 0)))
INSERT [Invoice].[InvoiceTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [InvoiceId]) VALUES (CAST(18 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1, CAST(22 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Invoice].[InvoiceTaxation] OFF
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ModuleUpdate]
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
End' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ModuleReadAll]
As
Begin
	SELECT Id, Code, Name, [Description], IsMandatory
	FROM License.Module
End' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ModuleRead]
(
	@Id  Numeric(10,0)
)
As
Begin
	SELECT Id, Code, Name, [Description], IsMandatory
	FROM License.Module
	WHERE Id = @Id
End' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ModuleInsert]
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
End' 
END
GO
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ModuleDelete]
(
	@Id  Numeric(10,0)
)
As
Begin
	DELETE FROM License.Module
	WHERE Id = @Id
End' 
END
GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 07/22/2014 16:34:33 ******/
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

 END' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Utility].[AppointmentTypeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM Utility.AppointmentType
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 07/22/2014 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Utility].[AppointmentTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,	[Name]
	FROM Utility.AppointmentType
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 07/22/2014 16:34:33 ******/
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
/****** Object:  Table [Navigator].[Artifact]    Script Date: 07/22/2014 16:34:34 ******/
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
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'Navigator', N'TABLE',N'Artifact', N'COLUMN',N'Style'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 - Directory, 2 - File' , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'TABLE',@level1name=N'Artifact', @level2type=N'COLUMN',@level2name=N'Style'
GO
SET IDENTITY_INSERT [Navigator].[Artifact] ON
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(60 AS Numeric(10, 0)), N'2009', NULL, N'Form:\\Customer\2009\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017997F1 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(61 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2009\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28501799ED6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(62 AS Numeric(10, 0)), N'2010', NULL, N'Form:\\Customer\2010\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2850179A5CE AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(63 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2009\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(61 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2850179AB2D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(64 AS Numeric(10, 0)), N'Rakhi Dey', N'frm', N'Form:\\Customer\Rakhi Dey', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2850179F764 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CE00BB5759 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(65 AS Numeric(10, 0)), N'Arpan Kar', N'frm', N'Form:\\Customer\2009\Arpan Kar', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017A54BF AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B5D314 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(66 AS Numeric(10, 0)), N'Biraj', N'frm', N'Form:\\Customer\2009\Jan\Biraj', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(61 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017AAFE6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(67 AS Numeric(10, 0)), N'2011', NULL, N'Form:\\Customer\2011\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CCAEF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(68 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2011\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(67 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CD6E2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(69 AS Numeric(10, 0)), N'2012', NULL, N'Form:\\Customer\2012\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CE730 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(70 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2012\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(69 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CEFA3 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(71 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2012\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(70 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CF843 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(72 AS Numeric(10, 0)), N'A', NULL, N'Form:\\Customer\2012\Jan\01\A\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(71 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017D0151 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A29001647FFF AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(73 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2010\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017DF3C2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(74 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2010\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(73 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017DFC9C AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(75 AS Numeric(10, 0)), N'jjhjhj', N'frm', N'Form:\\Customer\2010\Jan\01\jjhjhj', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(74 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017E4884 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(77 AS Numeric(10, 0)), N'Rupun', N'frm', N'Form:\\Customer\2012\Jan\01\A\Rupun', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(72 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A288009D5AC7 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A29001648002 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(79 AS Numeric(10, 0)), N'Feb', NULL, N'Form:\\Customer\2009\Feb\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2890099159A AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFCF AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(82 AS Numeric(10, 0)), N'2013', NULL, N'Form:\\Customer\2013\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A6094E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(83 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2013\Jan\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(82 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A61119 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A6C6FB AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(85 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2013\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A61F04 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A6C6FC AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(86 AS Numeric(10, 0)), N'Feb', NULL, N'Form:\\Customer\2013\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(82 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00AA6F9E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(87 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2013\Feb\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017BBD91 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(88 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2013\Feb\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017BBD9B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(89 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2013\Feb\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017BE40D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(90 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2013\Feb\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017BE40F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(91 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2013\Feb\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017C70FF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(92 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2013\Feb\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(91 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017C7100 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(93 AS Numeric(10, 0)), N'02', NULL, N'Form:\\Customer\2013\Jan\02\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28B017D741D AS DateTime), CAST(6 AS Numeric(10, 0)), CAST(0x0000A28B017DBD75 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(95 AS Numeric(10, 0)), N'2008', NULL, N'Form:\\Customer\2008\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B5014F9D41 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(96 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2008\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B5014FA403 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(97 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2008\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(96 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B5014FA405 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(98 AS Numeric(10, 0)), N'Sourav', N'frm', N'Form:\\Customer\2008\Sourav\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B501604D26 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(99 AS Numeric(10, 0)), N'Sourav', N'frm', N'Form:\\Customer\2009\Sourav\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B501611EC8 AS DateTime), CAST(11 AS Numeric(10, 0)), CAST(0x0000A2B501619F71 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(100 AS Numeric(10, 0)), N'2007', NULL, N'Form:\\Customer\2007\Feb\2007\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(155 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B3DDB5 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D01341302 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(101 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2007\Feb\2007\Jan\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B3EA79 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D013413E8 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(102 AS Numeric(10, 0)), N'Arpan', N'frm', N'Form:\\Customer\2007\Feb\2007\Arpan', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B42477 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D0134177D AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(103 AS Numeric(10, 0)), N'2011', NULL, N'Form:\\Room Reservation\2011\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B434F0 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A333011AC89B AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(104 AS Numeric(10, 0)), N'2013', NULL, N'Form:\\Room Reservation\2013\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B43D2C AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(107 AS Numeric(10, 0)), N'sss', N'frm', N'Form:\\Room Reservation\sss\', CAST(2 AS Numeric(2, 0)), CAST(5 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B82EFA AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CE00BB4A02 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(108 AS Numeric(10, 0)), N'Biraj', N'frm', N'Form:\\Room Reservation\2014\Biraj', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00BBC4B3 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC015F0B60 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(109 AS Numeric(10, 0)), N'Arpan', N'frm', N'Form:\\Room Reservation\2014\Arpan', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC015F4C13 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC01606370 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(110 AS Numeric(10, 0)), N'bbbb', N'frm', N'Form:\\Room Reservation\2014\bbbb', CAST(2 AS Numeric(2, 0)), CAST(11 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC01715B2E AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC0106A6F4 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(111 AS Numeric(10, 0)), N'aaaa', N'frm', N'Form:\\Room Reservation\2014\aaaa', CAST(2 AS Numeric(2, 0)), CAST(5 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC0179E548 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CE00B7AEEA AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(112 AS Numeric(10, 0)), N'Rakhi', N'frm', N'Form:\\Room Reservation\2014\Rakhi', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC017A6021 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CF00C01374 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(116 AS Numeric(10, 0)), N'Arpan Kar', N'frm', N'Form:\\Customer\2011\Arpan Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(67 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CE0103BD28 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(117 AS Numeric(10, 0)), N'Arpan Booking', N'frm', N'Form:\\Room Reservation\Arpan Booking', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CAF8D5 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(118 AS Numeric(10, 0)), N'New', N'frm', N'Form:\\Room Reservation\New\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CB6545 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(119 AS Numeric(10, 0)), N'Arpan Old Single Room', N'frm', N'Form:\\Room Reservation\Arpan Old Single Room', CAST(2 AS Numeric(2, 0)), CAST(5 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CBBFA0 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300C0DBED AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(120 AS Numeric(10, 0)), N'Saptorshi', N'frm', N'Form:\\Customer\Saptorshi\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CC4AA5 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A626C6 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(121 AS Numeric(10, 0)), N'Bisu', N'frm', N'Form:\\Customer\2014\Bisu', CAST(2 AS Numeric(2, 0)), CAST(8 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CCA2F5 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A34C00B4903A AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(122 AS Numeric(10, 0)), N'2012', NULL, N'Form:\\Check In\2012\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D5010083C1 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33800ED6C43 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(124 AS Numeric(10, 0)), N'Correct Reservation', N'frm', N'Form:\\Room Reservation\Correct Reservation\', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D5010170F6 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A35A010A6B05 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(125 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2009\Feb\01\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB250C AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFD2 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(126 AS Numeric(10, 0)), N'02', NULL, N'Form:\\Customer\2009\Feb\02\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB2B4D AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFD5 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(127 AS Numeric(10, 0)), N'03', NULL, N'Form:\\Customer\2009\Feb\03\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB306C AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFD8 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(128 AS Numeric(10, 0)), N'04', NULL, N'Form:\\Customer\2009\Feb\04\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB3593 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFDB AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(129 AS Numeric(10, 0)), N'05', NULL, N'Form:\\Customer\2009\Feb\05\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB3B19 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFDD AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(130 AS Numeric(10, 0)), N'2012', NULL, N'Form:\\Room Reservation\2012\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB56A5 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(131 AS Numeric(10, 0)), N'January', NULL, N'Form:\\Room Reservation\2012\January\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C352AA AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(132 AS Numeric(10, 0)), N'New', N'frm', N'Form:\\Room Reservation\2012\New\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C3FB3B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(133 AS Numeric(10, 0)), N'New', N'frm', N'Form:\\Room Reservation\2013\New\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(104 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C45BCC AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(134 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Room Reservation\2013\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(104 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C466BC AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(135 AS Numeric(10, 0)), N'Feb', NULL, N'Form:\\Room Reservation\2013\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(104 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C4BA59 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(136 AS Numeric(10, 0)), N'Feb', NULL, N'Form:\\Customer\2010\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E8077D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(137 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2010\Feb\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80780 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(138 AS Numeric(10, 0)), N'02', NULL, N'Form:\\Customer\2010\Feb\02\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80781 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(139 AS Numeric(10, 0)), N'03', NULL, N'Form:\\Customer\2010\Feb\03\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80781 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(140 AS Numeric(10, 0)), N'04', NULL, N'Form:\\Customer\2010\Feb\04\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80782 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(141 AS Numeric(10, 0)), N'05', NULL, N'Form:\\Customer\2010\Feb\05\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80782 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(142 AS Numeric(10, 0)), N'2013', NULL, N'Form:\\Check In\2013\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900F538EC AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(143 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2008\April\01\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(224 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D90106FE55 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32E0002CEDD AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(144 AS Numeric(10, 0)), N'Mar', NULL, N'Form:\\Customer\2009\Mar\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA00886492 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(145 AS Numeric(10, 0)), N'Santro Sanad', N'frm', N'Form:\\Customer\New FormSantro Sanad', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC015E50A4 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32500CC740A AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(146 AS Numeric(10, 0)), N'New Form', N'frm', N'Form:\\Room Reservation\New Form', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC015E717F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(147 AS Numeric(10, 0)), N'Santro', N'frm', N'Form:\\Check In\2014\Santro', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(122 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC015EC4CB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(148 AS Numeric(10, 0)), N'Misti Basu', N'frm', N'Form:\\Customer\Misti Basu', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E600A9A0A3 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32500E41E2F AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(149 AS Numeric(10, 0)), N'Arpan Reservation 20-04', N'frm', N'Form:\\Room Reservation\2012\Arpan Reservation 20-04', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F400CE9BE3 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100AEB9AB AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(150 AS Numeric(10, 0)), N'Feb', NULL, N'Form:\\Customer\2008\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC327F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(151 AS Numeric(10, 0)), N'March', NULL, N'Form:\\Customer\2008\March\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC400E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(152 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2008\March\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(151 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC56E8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(153 AS Numeric(10, 0)), N'02', NULL, N'Form:\\Customer\2008\March\02\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(151 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC64C8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(154 AS Numeric(10, 0)), N'03', NULL, N'Form:\\Customer\2013\Jan\03\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EFCCBD AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(155 AS Numeric(10, 0)), N'Feb', NULL, N'Form:\\Customer\2007\Feb\2007\Feb\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800FF7567 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D0134185F AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(156 AS Numeric(10, 0)), N'Arpan April', N'frm', N'Form:\\Room Reservation\Arpan April', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E30A39 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32C01143212 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(157 AS Numeric(10, 0)), N'Today', N'frm', N'Form:\\Check In\2014\Today', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(122 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E32358 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E32EBA AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(158 AS Numeric(10, 0)), N'New Form', N'frm', N'Form:\\Invoice\New Form', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E48981 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(161 AS Numeric(10, 0)), N'2014', NULL, N'Report:\\Invoice\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30900B2CFC2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(162 AS Numeric(10, 0)), N'2014-04-10', N'drpt', N'Report:\\Invoice\2014\2014-04-10', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(161 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30900B59A84 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30900B5E2AC AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(163 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2009\Mar\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(144 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30900CE3C60 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(164 AS Numeric(10, 0)), N'02', NULL, N'Form:\\Customer\2009\Mar\02\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(144 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30900CE44C9 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(165 AS Numeric(10, 0)), N'03', NULL, N'Form:\\Customer\2009\Mar\03\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(144 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30900CE4D12 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(166 AS Numeric(10, 0)), N'2014', NULL, N'Form:\\Customer\2014\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A0071533C AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00715ED1 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(167 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Customer\2014\Jan\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A0071693F AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00717215 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(168 AS Numeric(10, 0)), N'Feb', NULL, N'Form:\\Customer\2014\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A007179B0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(169 AS Numeric(10, 0)), N'Mar', NULL, N'Form:\\Customer\2014\Mar\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00729343 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(170 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2014\Mar\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(169 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A0072A059 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(171 AS Numeric(10, 0)), N'Arpan Kar', N'frm', N'Form:\\Customer\2014\Mar\01\Arpan Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(170 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A007381CB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(172 AS Numeric(10, 0)), N'2014', NULL, N'Form:\\Check In\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00AC5996 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(173 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Check In\2014\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(172 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00AC663D AS DateTime), NULL, NULL)
GO
print 'Processed 100 total records'
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(174 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Check In\2014\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(173 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00AC70E2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(175 AS Numeric(10, 0)), N'2014', NULL, N'Form:\\Room Reservation\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00AC89CF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(176 AS Numeric(10, 0)), N'Jan', NULL, N'Form:\\Room Reservation\2014\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00AC9551 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(177 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Room Reservation\2014\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(176 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00AC9F99 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(178 AS Numeric(10, 0)), N'Arpan Booking', N'frm', N'Form:\\Room Reservation\2014\Jan\01\Arpan Booking', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(177 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A00AD0E78 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(180 AS Numeric(10, 0)), N'Apr', NULL, N'Form:\\Customer\2014\Apr\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30A01705DFB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(191 AS Numeric(10, 0)), N'2014', N'frm', N'Form:\\Invoice\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30F011D93B4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(192 AS Numeric(10, 0)), N'2013', N'frm', N'Form:\\Invoice\2013.12\2013\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30F011D9F4A AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32500AEBBB1 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(193 AS Numeric(10, 0)), N'aRPAN', N'frm', N'Form:\\Customer\2009\Jan\Form:\\Customer\2009\Jan\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(61 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30F011E9D8A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(194 AS Numeric(10, 0)), N'Baishali', N'frm', N'Form:\\Customer\2009\Mar\01\Baishali', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(163 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31000C37A1B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(195 AS Numeric(10, 0)), N'Apr', N'frm', N'Form:\\Room Reservation\2014\Apr\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31000C39792 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(196 AS Numeric(10, 0)), N'17', N'frm', N'Form:\\Room Reservation\2014\Apr\17\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(195 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31000C3A48E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(197 AS Numeric(10, 0)), N'Baishali', N'frm', N'Form:\\Room Reservation\2014\Apr\17\Baishali', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(196 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31000C912E2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(198 AS Numeric(10, 0)), N'Apr', N'frm', N'Form:\\Check In\2014\Apr\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(172 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31000D6DF5B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(199 AS Numeric(10, 0)), N'Arpan Kar', N'frm', N'Form:\\Customer\2014\Arpan Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A310017FB1CD AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(200 AS Numeric(10, 0)), N'Arpan Kar', N'frm', N'Form:\\Room Reservation\2014\Apr\Arpan Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(196 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31001801026 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(201 AS Numeric(10, 0)), N'Arpan Kar', N'frm', N'Form:\\Check In\2014\Arpan Kar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(198 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A311018064F2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(203 AS Numeric(10, 0)), N'24', N'frm', N'Form:\\Check In\2014\Apr\24\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(198 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31700CC192D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(204 AS Numeric(10, 0)), N'Binay Halder', N'frm', N'Form:\\Customer\Binay Halder', CAST(2 AS Numeric(2, 0)), CAST(38 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A31700CC848D AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32C00FA6247 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(205 AS Numeric(10, 0)), N'New Form (2)', N'frm', N'Form:\\Check InNew Form (2)', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A31700CCAF57 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(206 AS Numeric(10, 0)), N'Binay', N'frm', N'Form:\\Check In\2014\Apr\Binay', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(203 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31700CCD035 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(207 AS Numeric(10, 0)), N'Abhay Dey', N'frm', N'Form:\\Customer\2014\New FormAbhay Dey', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31800E617C1 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32500E71940 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(208 AS Numeric(10, 0)), N'25', N'frm', N'Form:\\Customer\2014\Apr\25\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31800ED93C7 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(209 AS Numeric(10, 0)), N'01', N'frm', N'Form:\\Customer\2014\Feb\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(168 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31800EE780A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(210 AS Numeric(10, 0)), N'02', N'frm', N'Form:\\Customer\2014\Feb\02\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(168 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31800EE8D0E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(212 AS Numeric(10, 0)), N'2014', NULL, N'Report:\\Customer\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00CD414B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(213 AS Numeric(10, 0)), N'April', NULL, N'Report:\\Customer\2014\April\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00EF9DC9 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(214 AS Numeric(10, 0)), N'2013', NULL, N'Report:\\Customer\2013\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00F16740 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(215 AS Numeric(10, 0)), N'2012', NULL, N'Report:\\Customer\2012\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00F1DCE2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(216 AS Numeric(10, 0)), N'January', NULL, N'Report:\\Customer\2012\January\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(215 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00F1F8E7 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(217 AS Numeric(10, 0)), N'January', NULL, N'Report:\\Customer\2013\January\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(214 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00F22EBD AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(218 AS Numeric(10, 0)), N'2011', NULL, N'Report:\\Customer\2011\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00F260CB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(219 AS Numeric(10, 0)), N'January', NULL, N'Report:\\Customer\2011\January\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(218 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00F2802F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(220 AS Numeric(10, 0)), N'February', NULL, N'Report:\\Customer\2011\February\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(218 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00F2970D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(221 AS Numeric(10, 0)), N'24', N'drpt', N'Report:\\Customer\2014\April\24', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(213 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B00F410B0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(223 AS Numeric(10, 0)), N'Monthly', N'mrpt', N'Report:\\Customer\2014\April\Monthly', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(213 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B01042A14 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(224 AS Numeric(10, 0)), N'April', NULL, N'Form:\\Customer\2008\April\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B0104937F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(225 AS Numeric(10, 0)), N'2006', NULL, N'Form:\\Customer\2009\Feb\2006\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B01064E21 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D013432DF AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(226 AS Numeric(10, 0)), N'January', NULL, N'Form:\\Customer\2009\Feb\2006\January\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(225 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B01068895 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D013433AF AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(227 AS Numeric(10, 0)), N'Binay Sarkar', N'frm', N'Form:\\Customer\2014\May\Binay Sarkar', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31B0106FF5E AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D0106A02A AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(228 AS Numeric(10, 0)), N'Yearly Report', N'yrpt', N'Report:\\Customer\2014\Yearly Report', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31C00C18888 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(229 AS Numeric(10, 0)), N'14', N'drpt', N'Report:\\Customer\2014\14', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31C011D1915 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(230 AS Numeric(10, 0)), N'29', N'frm', N'Form:\\Customer\2014\Apr\29\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31C011D9A56 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(231 AS Numeric(10, 0)), N'Bidyut Bose', N'frm', N'Form:\\Customer\2014\Apr\29\Bidyut Bose', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(230 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A31C011E0040 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(232 AS Numeric(10, 0)), N'18', N'drpt', N'Report:\\Customer\2014\April\18', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(213 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32100A3F144 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(233 AS Numeric(10, 0)), N'2005', N'frm', N'Form:\\Customer\2005\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A32300C553B1 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(234 AS Numeric(10, 0)), N'January', N'frm', N'Form:\\Customer\2005\January\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32300C562BB AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33200EF5514 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(236 AS Numeric(10, 0)), N'May', N'', N'Report:\\Customer\2014\May\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32300C67516 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(237 AS Numeric(10, 0)), N'New Report', N'drpt', N'Report:\\Customer\2014\May\New Report', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(236 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32300C7820D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(238 AS Numeric(10, 0)), N'January', N'frm', N'Form:\\Check In\2013\January\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(142 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32400AC5E86 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(239 AS Numeric(10, 0)), N'March', N'', N'Report:\\Customer\2014\March\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32400AF30FB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(240 AS Numeric(10, 0)), N'May', N'frm', N'Form:\\Customer\2014\May\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32400F82DEA AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(241 AS Numeric(10, 0)), N'Anirban Chakroborti', N'frm', N'Form:\\Customer\2014\May\Anirban Chakroborti', CAST(2 AS Numeric(2, 0)), CAST(9 AS Numeric(4, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32400F8E8D0 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D00CD7159 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(242 AS Numeric(10, 0)), N'Manotosh', N'frm', N'Form:\\Customer\2014\Manotosh', CAST(2 AS Numeric(2, 0)), CAST(8 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32500089147 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A34500FC433F AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(243 AS Numeric(10, 0)), N'Bipul', N'frm', N'Form:\\Customer\2005\January\Temp\January\Temp\Bipul', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(258 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32500B46753 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33200EF57D0 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(244 AS Numeric(10, 0)), N'New Form', N'frm', N'Form:\\Customer\2014\May\New Form', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32500EECE39 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(245 AS Numeric(10, 0)), N'New Report', N'binaf', N'Report:\\Customer\2014\New Report', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A326017C5A51 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(246 AS Numeric(10, 0)), N'13', N'binaf', N'Report:\\Customer\2014\May\13', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(236 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32A00A99418 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(247 AS Numeric(10, 0)), N'May', NULL, N'Form:\\Room Reservation\2014\May\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32A00B079F4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(248 AS Numeric(10, 0)), N'Feb', NULL, N'Form:\\Room Reservation\2014\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32A00B0849D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(249 AS Numeric(10, 0)), N'Binay Reservation', N'frm', N'Form:\\Room Reservation\2014\May\Binay Reservation', CAST(2 AS Numeric(2, 0)), CAST(5 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A32A00B0C04D AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32A0124A53A AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(250 AS Numeric(10, 0)), N'Misti Reservation', N'frm', N'Form:\\Room Reservation\2014\May\Misti Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32A00E69EE2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(251 AS Numeric(10, 0)), N'15', NULL, N'Form:\\Room Reservation\2014\May\15\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32C010E69ED AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(252 AS Numeric(10, 0)), N'Arpan Reservation', N'frm', N'Form:\\Room Reservation\2014\May\15\Arpan Reservat', CAST(2 AS Numeric(2, 0)), CAST(11 AS Numeric(4, 0)), CAST(251 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32C010E7D01 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32C011DCAD1 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(253 AS Numeric(10, 0)), N'Rep', N'frm', N'Form:\\Room Reservation\Rep', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D00A40AED AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(254 AS Numeric(10, 0)), N'New Form', N'frm', N'Form:\\Check In\2014\New Form', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(172 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D00A853C2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(255 AS Numeric(10, 0)), N'16', NULL, N'Form:\\Room Reservation\2014\May\16\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D00AB021A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(256 AS Numeric(10, 0)), N'Bishu Reservation', N'frm', N'Form:\\Room Reservation\2014\May\16\Bishu Reservation', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(255 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D00AB1175 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32F00AA3E14 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(257 AS Numeric(10, 0)), N'Indu', N'frm', N'Form:\\Customer\2014\May\Indu', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D00ABEF17 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D00ACC4F5 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(258 AS Numeric(10, 0)), N'Temp', NULL, N'Form:\\Customer\2005\January\Temp\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(234 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D0105DCC5 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33200EF55F8 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(259 AS Numeric(10, 0)), N'Temp', NULL, N'Form:\\Customer\2014\May\Temp\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D01061900 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(260 AS Numeric(10, 0)), N'Temp 2', NULL, N'Form:\\Customer\2005\Temp 2\', CAST(1 AS Numeric(2, 0)), CAST(11 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D0123D4BE AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33200EF83E5 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(261 AS Numeric(10, 0)), N'Temp 3', NULL, N'Form:\\Customer\2005\Temp 3\', CAST(1 AS Numeric(2, 0)), CAST(12 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D0126221C AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300C25CDD AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(262 AS Numeric(10, 0)), N'Temp 4', NULL, N'Form:\\Customer\2005\Temp 2\Temp 4\', CAST(1 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(260 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D0134DE21 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33200EF85BA AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(263 AS Numeric(10, 0)), N'3rd Rev', N'frm', N'Form:\\Room Reservation\2014\May\16\3rd Rev', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(255 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D01792CE6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(264 AS Numeric(10, 0)), N'May', NULL, N'Form:\\Check In\2014\May\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(172 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D01798076 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(265 AS Numeric(10, 0)), N'16', NULL, N'Form:\\Check In\2014\May\16\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(264 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D017989E0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(266 AS Numeric(10, 0)), N'3rd Checkin', N'frm', N'Form:\\Check In\2014\May\16\3rd Checkin', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(265 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32D01799EB7 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(267 AS Numeric(10, 0)), N'18', NULL, N'Form:\\Check In\2014\May\18\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(264 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32F00AA7684 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(268 AS Numeric(10, 0)), N'e', N'frm', N'Form:\\Check In\2014\May\18\e', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(267 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32F00AA7DC4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(269 AS Numeric(10, 0)), N'18', NULL, N'Form:\\Room Reservation\2014\May\18\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32F01651903 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(270 AS Numeric(10, 0)), N'Aditya', N'frm', N'Form:\\Room Reservation\2014\May\18\Aditya', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(269 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32F016523BB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(271 AS Numeric(10, 0)), N'Aditya', N'frm', N'Form:\\Check In\2014\May\18\Aditya', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(267 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A32F0165627D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(272 AS Numeric(10, 0)), N'19', NULL, N'Form:\\Room Reservation\2014\May\19\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3300096B67C AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(273 AS Numeric(10, 0)), N'Arpan Reservation', N'frm', N'Form:\\Room Reservation\2014\May\19\Arpan Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(272 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3300096C5DB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(274 AS Numeric(10, 0)), N'19', NULL, N'Form:\\Check In\2014\May\19\', CAST(1 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(264 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3300096F2FF AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3300097191A AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(275 AS Numeric(10, 0)), N'Arpan Checkin', N'frm', N'Form:\\Check In\2014\May\19\Arpan Checkin', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(274 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3300097289E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(276 AS Numeric(10, 0)), N'Biraj Reservation', N'frm', N'Form:\\Room Reservation\2014\May\19\Biraj Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(272 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33000C0FAC4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(277 AS Numeric(10, 0)), N'19', N'binaf', N'Report:\\Customer\2014\May\19', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(236 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33000E70C1B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(278 AS Numeric(10, 0)), N'February', NULL, N'Form:\\Room Reservation\2012\February\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100AECA65 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100AED406 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(279 AS Numeric(10, 0)), N'20', NULL, N'Form:\\Customer\2014\May\20\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100B64DF6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(280 AS Numeric(10, 0)), N'Arpan', N'frm', N'Form:\\Customer\2014\May\20\Arpan', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100B71763 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100B721C4 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(281 AS Numeric(10, 0)), N'Bijay', N'frm', N'Form:\\Customer\2014\May\20\Bijay', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100B7675A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(282 AS Numeric(10, 0)), N'Akash', N'frm', N'Form:\\Customer\2014\May\20\Akash', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100BAF9CC AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100C86D2A AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(283 AS Numeric(10, 0)), N'Bikash', N'frm', N'Form:\\Customer\2014\May\20\Bikash', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100BE233F AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100BE2EA2 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(284 AS Numeric(10, 0)), N'Hemanta', N'frm', N'Form:\\Customer\2014\May\20\Hemanta', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100BE3BAB AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100D04F3B AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(285 AS Numeric(10, 0)), N'Anamika', N'frm', N'Form:\\Customer\2014\May\20\Anamika', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100C1F0B9 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(286 AS Numeric(10, 0)), N'Subrata', N'frm', N'Form:\\Customer\2014\May\20\Subrata', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100C3A50A AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100CFEB62 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(287 AS Numeric(10, 0)), N'Indra', N'frm', N'Form:\\Customer\2014\May\20\Indra', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100C3FA5C AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100D046D0 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(288 AS Numeric(10, 0)), N'Ayan', N'frm', N'Form:\\Customer\2014\May\20\Ayan', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100CD6426 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(289 AS Numeric(10, 0)), N'Bishu', N'frm', N'Form:\\Customer\2014\May\20\Bishu', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33100D09FBD AS DateTime), NULL, NULL)
GO
print 'Processed 200 total records'
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(290 AS Numeric(10, 0)), N'02', NULL, N'Form:\\Customer\2014\Apr\02\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33201210D30 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320121B0AF AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(291 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2014\Apr\01\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33201214A79 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320121825B AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(292 AS Numeric(10, 0)), N'30', NULL, N'Form:\\Customer\2014\Apr\30\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320121BF30 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(293 AS Numeric(10, 0)), N'03', NULL, N'Form:\\Customer\2014\Apr\03\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320121CB84 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(294 AS Numeric(10, 0)), N'04', NULL, N'Form:\\Customer\2014\Apr\04\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33201225C6B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(295 AS Numeric(10, 0)), N'05', NULL, N'Form:\\Customer\2014\Apr\05\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332015E8F3E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(296 AS Numeric(10, 0)), N'Mintu', N'frm', N'Form:\\Customer\2014\May\20\Mintu', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332015EB972 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(297 AS Numeric(10, 0)), N'06', NULL, N'Form:\\Customer\2014\Apr\06\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33201705C25 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(298 AS Numeric(10, 0)), N'07', NULL, N'Form:\\Customer\2014\Apr\07\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33201726057 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(299 AS Numeric(10, 0)), N'08', NULL, N'Form:\\Customer\2014\Apr\08\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320172DC2E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(300 AS Numeric(10, 0)), N'09', NULL, N'Form:\\Customer\2014\Apr\09\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320174C4FD AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(301 AS Numeric(10, 0)), N'10', NULL, N'Form:\\Customer\2014\Apr\10\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320175F017 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(302 AS Numeric(10, 0)), N'12', NULL, N'Form:\\Customer\2014\Apr\12\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332017684A3 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332017696AA AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(303 AS Numeric(10, 0)), N'11', NULL, N'Form:\\Customer\2014\Apr\11\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332017779E4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(304 AS Numeric(10, 0)), N'13', NULL, N'Form:\\Customer\2014\Apr\13\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33201778694 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(305 AS Numeric(10, 0)), N'14', NULL, N'Form:\\Customer\2014\Apr\14\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33201797063 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(306 AS Numeric(10, 0)), N'Apurba', N'frm', N'Form:\\Customer\2014\Apr\01\Apurba', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(291 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332017A72C4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(307 AS Numeric(10, 0)), N'Anupama', N'frm', N'Form:\\Customer\2014\Apr\01\Anupama', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(291 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332017E7460 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(308 AS Numeric(10, 0)), N'Biju', N'frm', N'Form:\\Customer\2014\Apr\01\Biju', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(291 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332017E8954 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(309 AS Numeric(10, 0)), N'Hari', N'frm', N'Form:\\Customer\2014\Apr\01\Hari', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(291 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332017F1DEB AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A332017F8E6C AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(310 AS Numeric(10, 0)), N'15', NULL, N'Form:\\Customer\2014\Apr\15\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320189DA74 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(311 AS Numeric(10, 0)), N'16', NULL, N'Form:\\Customer\2014\Apr\16\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320189E759 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(312 AS Numeric(10, 0)), N'Gin', N'frm', N'Form:\\Customer\2014\Apr\01\Gin', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(291 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3320189F96A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(313 AS Numeric(10, 0)), N'Maithili', N'frm', N'Form:\\Customer\2005\Maithili', CAST(2 AS Numeric(2, 0)), CAST(6 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300B2B847 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300C25159 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(314 AS Numeric(10, 0)), N'Zamal', N'frm', N'Form:\\Customer\2014\Zamal', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300C83526 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300CAA7B6 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(315 AS Numeric(10, 0)), N'Manjula', N'frm', N'Form:\\Customer\2014\Manjula', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300CD82EF AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300CE2B8E AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(316 AS Numeric(10, 0)), N'Anindita', N'frm', N'Form:\\Customer\2014\Anindita', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300CEABEE AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(317 AS Numeric(10, 0)), N'Anita', N'frm', N'Form:\\Customer\2014\Anita', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300CF39E5 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300CF490D AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(318 AS Numeric(10, 0)), N'17', NULL, N'Form:\\Customer\2014\Apr\17\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300D0CB49 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300D1009E AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(319 AS Numeric(10, 0)), N'18', NULL, N'Form:\\Customer\2014\Apr\17\18\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(318 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300D117A3 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(320 AS Numeric(10, 0)), N'February', NULL, N'Form:\\Customer\2005\February\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300E4E4A3 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(321 AS Numeric(10, 0)), N'March', NULL, N'Form:\\Customer\2005\March\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300E4F0D1 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(322 AS Numeric(10, 0)), N'April', NULL, N'Form:\\Customer\2005\April\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300E4FC08 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(323 AS Numeric(10, 0)), N'Annapurna', N'frm', N'Form:\\Customer\2005\Annapurna', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300E510C6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(324 AS Numeric(10, 0)), N'Manjusha', N'frm', N'Form:\\Customer\2005\Manjusha', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300E6B212 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(325 AS Numeric(10, 0)), N'No', NULL, N'Form:\\Customer\2005\Temp 3\No\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300EB2F5A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(326 AS Numeric(10, 0)), N'Misi', NULL, N'Form:\\Customer\2005\Temp 3\Misi\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300EB5EE6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(327 AS Numeric(10, 0)), N'Miki', NULL, N'Form:\\Customer\2005\Temp 3\Miki\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300EC59EF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(328 AS Numeric(10, 0)), N'Misc', NULL, N'Form:\\Customer\2005\Temp 3\Misc\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300EC617F AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300EC7C11 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(329 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2005\March\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(321 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300EC8C5B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(330 AS Numeric(10, 0)), N'2006', NULL, N'Form:\\Customer\2006\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300ECE30B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(331 AS Numeric(10, 0)), N'Manotosh', N'frm', N'Form:\\Customer\Manotosh', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300ECF209 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300ED6D0B AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(332 AS Numeric(10, 0)), N'Ritu', N'frm', N'Form:\\Customer\2005\Temp 3\Ritu', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300ED87D8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(333 AS Numeric(10, 0)), N'Bishnu', N'frm', N'Form:\\Customer\2005\Temp 3\Bishnu', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300ED964A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(334 AS Numeric(10, 0)), N'Raghu', N'frm', N'Form:\\Customer\2005\Temp 3\Raghu', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300EDA8ED AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(335 AS Numeric(10, 0)), N'21', NULL, N'Form:\\Room Reservation\2014\May\21\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300F0F15B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(336 AS Numeric(10, 0)), N'Mithun Reservation', N'frm', N'Form:\\Room Reservation\2014\May\21\Mithun Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(335 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300F0FF05 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(337 AS Numeric(10, 0)), N'22', NULL, N'Form:\\Customer\2014\May\22\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33300FE8B3F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(338 AS Numeric(10, 0)), N'Mithun', N'frm', N'Form:\\Customer\2014\May\22\\Mithun', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33301035AAB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(339 AS Numeric(10, 0)), N'Mintu', N'frm', N'Form:\\Customer\2014\May\22\\Mithun\Mintu', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(338 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3330106D239 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(340 AS Numeric(10, 0)), N'Miki', N'frm', N'Form:\\Customer\2014\May\22\\Miki', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33301192691 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(341 AS Numeric(10, 0)), N'Malati', N'frm', N'Form:\\Customer\2014\May\22\\Malati', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A333011AEABA AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(342 AS Numeric(10, 0)), N'Manju', N'frm', N'Form:\\Customer\2014\May\22\\Manju', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A333011C1683 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(343 AS Numeric(10, 0)), N'Akul', N'frm', N'Form:\\Customer\2014\May\22\\Akul', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A333011CDFB0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(344 AS Numeric(10, 0)), N'Anju', N'frm', N'Form:\\Customer\2014\May\22\\Anju', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A333011D33ED AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(345 AS Numeric(10, 0)), N'Ananta', N'frm', N'Form:\\Customer\2014\May\22\\Ananta', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A333011D7FDE AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(346 AS Numeric(10, 0)), N'Sagar', N'frm', N'Form:\\Customer\2014\May\22\\Sagar', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A333011DF53F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(347 AS Numeric(10, 0)), N'23', NULL, N'Form:\\Customer\2014\May\23\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400DEB0C0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(348 AS Numeric(10, 0)), N'Badal', N'frm', N'Form:\\Customer\2014\May\23\\Badal', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400DFD86C AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(349 AS Numeric(10, 0)), N'Bakul', N'frm', N'Form:\\Customer\2014\May\23\\Bakul', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400E2D69D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(350 AS Numeric(10, 0)), N'Manas Das', N'frm', N'Form:\\Customer\2014\May\23\\Manas Das', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400E7A557 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(351 AS Numeric(10, 0)), N'Mani Bose', N'frm', N'Form:\\Customer\2014\May\23\\Mani Bose', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400E88177 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400EB212D AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(352 AS Numeric(10, 0)), N'Sourabh Saha', N'frm', N'Form:\\Customer\2014\May\23\\Sourabh Saha', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400EB6AF8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(353 AS Numeric(10, 0)), N'Bibi', N'frm', N'Form:\\Customer\2014\May\23\\Bibi', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400EC52A7 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(354 AS Numeric(10, 0)), N'Minakshi Dey', N'frm', N'Form:\\Customer\2014\May\23\\Minakshi Dey', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400F02DC8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(355 AS Numeric(10, 0)), N'Mandira', N'frm', N'Form:\\Customer\2014\Mandira', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400F4F044 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(356 AS Numeric(10, 0)), N'Baibhabi', N'frm', N'Form:\\Customer\2014\May\23\\Baibhabi', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400F54AF7 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(357 AS Numeric(10, 0)), N'Indu Mistri', N'frm', N'Form:\\Customer\2014\May\23\\Indu Mistri', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400F7559F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(358 AS Numeric(10, 0)), N'Indu Mistri', N'frm', N'Form:\\Customer\2014\May\23\\Indu Mistri', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400F75BAD AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(359 AS Numeric(10, 0)), N'Abhi Dey', N'frm', N'Form:\\Customer\2014\May\23\\Abhi Dey', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33400FC7E0D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(360 AS Numeric(10, 0)), N'23rd Payment', N'frm', N'Form:\\Invoice\2014\\23rd Payment', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A334010C5354 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(361 AS Numeric(10, 0)), N'Next', N'frm', N'Form:\\Invoice\2014\\Next', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A334010E1CFD AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(362 AS Numeric(10, 0)), N'Now', N'frm', N'Form:\\Invoice\2014\\Now', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A334010F482A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(363 AS Numeric(10, 0)), N'AND', N'frm', N'Form:\\Invoice\2014\\AND', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A334011081BF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(364 AS Numeric(10, 0)), N'ngt', N'frm', N'Form:\\Invoice\2014\\ngt', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33401116BC7 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(365 AS Numeric(10, 0)), N'guj', N'frm', N'Form:\\Invoice\2014\\guj', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A334017380D2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(366 AS Numeric(10, 0)), N'ambalica res', N'frm', N'Form:\\Room Reservation\2014\May\ambalica res', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33401753180 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(367 AS Numeric(10, 0)), N'Ambalika', N'frm', N'Form:\\Customer\2014\May\23\\Ambalika', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3340175532A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(368 AS Numeric(10, 0)), N'23', NULL, N'Form:\\Check In\2014\May\23\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(264 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3340178CEC1 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(369 AS Numeric(10, 0)), N'AR', N'frm', N'Form:\\Check In\2014\May\23\AR', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(368 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3340178D7E6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(370 AS Numeric(10, 0)), N'bik', N'frm', N'Form:\\Invoice\2014\\bik', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A334017EC9EC AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(371 AS Numeric(10, 0)), N'23', NULL, N'Form:\\Room Reservation\2014\May\23\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33401815430 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(372 AS Numeric(10, 0)), N'Binay', N'frm', N'Form:\\Room Reservation\2014\May\23\Binay', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(371 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3340181631F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(373 AS Numeric(10, 0)), N'Binay', N'frm', N'Form:\\Check In\2014\May\23\Binay', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(368 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33401818DAF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(374 AS Numeric(10, 0)), N'ins', N'frm', N'Form:\\Invoice\2014\\ins', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3340181FEBE AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(375 AS Numeric(10, 0)), N'aaa', N'frm', N'Form:\\Room Reservation\2014\May\23\aaa', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(371 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33401822176 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(376 AS Numeric(10, 0)), N'aaaa', N'frm', N'Form:\\Check In\2014\May\23\aaaa', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(368 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33401823CC8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(377 AS Numeric(10, 0)), N'ddsd', N'frm', N'Form:\\Invoice\2014\\ddsd', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3340183342A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(378 AS Numeric(10, 0)), N'bgt', N'frm', N'Form:\\Check In\2014\May\23\bgt', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(368 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33401834F11 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(379 AS Numeric(10, 0)), N'2004', NULL, N'Form:\\Customer\2004\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A3360107C4CB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(380 AS Numeric(10, 0)), N'25', NULL, N'Form:\\Room Reservation\2014\May\25\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3360108BDB4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(381 AS Numeric(10, 0)), N'Abc', N'frm', N'Form:\\Room Reservation\2014\May\25\Abc', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(380 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3360108C92F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(382 AS Numeric(10, 0)), N'Abc', N'frm', N'Form:\\Check In\2014\Abc', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(172 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A336010B8F6A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(383 AS Numeric(10, 0)), N'Abc', N'frm', N'Form:\\Invoice\2014\\Abc', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A336010C7191 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(384 AS Numeric(10, 0)), N'27', NULL, N'Form:\\Room Reservation\2014\May\27\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33800EAFF92 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(385 AS Numeric(10, 0)), N'Misti Reservation', N'frm', N'Form:\\Room Reservation\2014\May\27\Misti Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(384 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33800EB0F60 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(386 AS Numeric(10, 0)), N'27', NULL, N'Form:\\Check In\2014\May\27\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(264 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33800ECD308 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(387 AS Numeric(10, 0)), N'Misti Stay', N'frm', N'Form:\\Check In\2014\May\27\Misti Stay', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(386 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33800ECE07F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(390 AS Numeric(10, 0)), N'My Form', N'frm', N'Form:\\Invoice\2013.12\2013\\My Form', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(192 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33B00B9CD5F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(395 AS Numeric(10, 0)), N'my inv', N'frm', N'Form:\\Invoice\2013.12\2013\\my inv', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(192 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A33B00BCF0FB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(396 AS Numeric(10, 0)), N'June', NULL, N'Form:\\Customer\2014\June\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3450101763C AS DateTime), NULL, NULL)
GO
print 'Processed 300 total records'
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(397 AS Numeric(10, 0)), N'Bidisha', N'frm', N'Form:\\Customer\2014\June\Bidisha', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(396 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A345010181A9 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A345011DDD04 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(398 AS Numeric(10, 0)), N'June', NULL, N'Form:\\Room Reservation\2014\June\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A345011E3B4F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(399 AS Numeric(10, 0)), N'Bidisha', N'frm', N'Form:\\Room Reservation\2014\June\Bidisha', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(398 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A345011E45CF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(401 AS Numeric(10, 0)), N'My', N'frm', N'Form:\\Room Reservation\2014\June\My', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(398 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A34C00B6E129 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(402 AS Numeric(10, 0)), N'MyNew', N'frm', N'Form:\\Customer\2014\June\\MyNew', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(396 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A34C00B707E6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(403 AS Numeric(10, 0)), N'Test', N'frm', N'Form:\\Customer\2014\Test', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A34C00BA8045 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A34C00BABCD0 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(404 AS Numeric(10, 0)), N'aaaa', N'frm', N'Form:\\Customer\2014\\aaaa', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A34C00D14AC7 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(405 AS Numeric(10, 0)), N'Arpan', N'frm', N'Form:\\Room Reservation\2014\Arpan', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A35701144477 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(406 AS Numeric(10, 0)), N'Biraj', N'frm', N'Form:\\Room Reservation\2014\Biraj', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A357011719D0 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A35A00FF5219 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(407 AS Numeric(10, 0)), N'Rakhi', N'frm', N'Form:\\Room Reservation\2014\Rakhi', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A35701178390 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(408 AS Numeric(10, 0)), N'June30', N'frm', N'Form:\\Room Reservation\2014\June30', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A35A00FBFD48 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(412 AS Numeric(10, 0)), N'2014', NULL, N'Form:\\Payment\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A36200F94259 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(413 AS Numeric(10, 0)), N'July', NULL, N'Form:\\Payment\2014\July\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(412 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36C0176A076 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(414 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Payment\2014\July\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(413 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D000313AF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(415 AS Numeric(10, 0)), N'May', NULL, N'Form:\\Payment\2014\May\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(412 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D00032172 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(422 AS Numeric(10, 0)), N'July', NULL, N'Form:\\Customer\2014\July\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D000FAA28 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(423 AS Numeric(10, 0)), N'01', NULL, N'Form:\\Customer\2014\July\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(422 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D000FB24A AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(424 AS Numeric(10, 0)), N'Arighna Kar', N'frm', N'Form:\\Customer\2014\July\Arighna Kar', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(422 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D000FBF66 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D002685F0 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(425 AS Numeric(10, 0)), N'02', NULL, N'Form:\\Customer\2014\July\02\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(422 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D00269D78 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(426 AS Numeric(10, 0)), N'Sourav Saha', N'frm', N'Form:\\Customer\2014\July\Sourav Saha', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(422 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D0026ABD2 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D0026FFB9 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(427 AS Numeric(10, 0)), N'July', NULL, N'Form:\\Room Reservation\2014\July\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D00272D90 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(428 AS Numeric(10, 0)), N'Sourav Reservation', N'frm', N'Form:\\Room Reservation\2014\July\Sourav Reservation', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(427 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D002739F5 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(429 AS Numeric(10, 0)), N'July', NULL, N'Form:\\Check In\2014\July\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(172 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D002789DB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Extension], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(430 AS Numeric(10, 0)), N'Sourav Checkin', N'frm', N'Form:\\Check In\2014\July\Sourav Checkin', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(429 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A36D002795AF AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Navigator].[Artifact] OFF
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  Table [Utility].[Appointment]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusUpdate]
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
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusReadAll]	
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Customer].[ActionStatus]
		
	END' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Customer].[ActionStatus]
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Customer].ActionStatus([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END' 
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Customer].[ActionStatus]
	WHERE Id = @Id   
   
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusUpdate]    Script Date: 07/22/2014 16:34:34 ******/
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
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusReadAll]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingStatusReadAll]
	As
	Begin
		Select Id,Name
		From [Lodge].BuildingStatus
	End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusRead]    Script Date: 07/22/2014 16:34:34 ******/
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
		FROM [Lodge].BuildingStatus
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusInsert]    Script Date: 07/22/2014 16:34:34 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusDelete]    Script Date: 07/22/2014 16:34:34 ******/
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
	END' 
END
GO
/****** Object:  Table [Lodge].[Building]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingTypeUpdate]    Script Date: 07/22/2014 16:34:34 ******/
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
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeReadAll]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingTypeReadAll]
	As
	Begin
		Select Id,Name
		From [Lodge].BuildingType
	End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeRead]    Script Date: 07/22/2014 16:34:34 ******/
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
		FROM [Lodge].BuildingType
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeInsert]    Script Date: 07/22/2014 16:34:34 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeDelete]    Script Date: 07/22/2014 16:34:34 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Report].[CategoryReadAll]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Report].[CategoryReadAll]
AS
BEGIN
	
	SELECT Id
      ,Extension
      ,Name
  FROM Report.Category
   
END
' 
END
GO
/****** Object:  StoredProcedure [Report].[CategoryRead]    Script Date: 07/22/2014 16:34:34 ******/
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
	FROM Report.Category
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  Table [Organization].[ContactNumber]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ComponentUpdate]
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
End' 
END
GO
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ComponentReadAll]
As
Begin
	SELECT Id, Code, Name, [Description], IsForm, IsReport, IsCatalogue
	FROM License.Component
End' 
END
GO
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ComponentRead]
(
	@Id  Numeric(10,0)
)
As
Begin
	SELECT Id, Code, Name, [Description], IsForm, IsReport, IsCatalogue
	FROM License.Component
	WHERE Id = @Id
End' 
END
GO
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ComponentInsert]
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
End' 
END
GO
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [License].[ComponentDelete]
(
	@Id  Numeric(10,0)
)
As
Begin
	DELETE FROM License.Component
	WHERE Id = @Id
End' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Utility].[ImportanceReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM Utility.Importance
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 07/22/2014 16:34:34 ******/
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
	
	SELECT 
		Id,	[Name]
	FROM Utility.Importance
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 07/22/2014 16:34:34 ******/
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
	FROM [Configuration].IdentityProofType 
	WHERE Name = @Name				
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[IdentityProofTypeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].IdentityProofType
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 07/22/2014 16:34:34 ******/
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
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].IdentityProofType
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 07/22/2014 16:34:34 ******/
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
	
	DELETE 		
	FROM [Configuration].IdentityProofType
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[CountryReadAll]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

create PROCEDURE [Configuration].[CountryReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].Country
   
END

' 
END
GO
/****** Object:  StoredProcedure [Configuration].[CountryRead]    Script Date: 07/22/2014 16:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



create PROCEDURE [Configuration].[CountryRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	
   Select 
		Id,
		[Name]
   From [Configuration].Country
   Where Id = @Id   
   
END

' 
END
GO
/****** Object:  Table [Organization].[Email]    Script Date: 07/22/2014 16:34:34 ******/
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
/****** Object:  Table [Organization].[Fax]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 07/22/2014 16:34:35 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 07/22/2014 16:34:35 ******/
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
		SELECT 
			Id,
			[Fax],			
			[OrganizationId]
		FROM [Organization].[Fax]
		WHERE Id = @Id	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 07/22/2014 16:34:35 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 07/22/2014 16:34:35 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 07/22/2014 16:34:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[EmailReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[OrganizationId],
			[Email]
		FROM [Organization].Email
		WHERE OrganizationId = @ParentId   
	END' 
END
GO
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 07/22/2014 16:34:35 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 07/22/2014 16:34:35 ******/
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
   
END' 
END
GO
/****** Object:  Table [Customer].[Customer]    Script Date: 07/22/2014 16:34:35 ******/
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
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(6 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), N'Arpan', N'', N'Kar', N'#6 S.K. Apts, Wind Tunnel Road
Bangalore-1', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560017 AS Numeric(10, 0)), N'arpan.kar@3i-infotech.com', CAST(4 AS Numeric(10, 0)), N'12345ADRS')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'biraj', N'', N'', N'dasd', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'asd', CAST(569874 AS Numeric(10, 0)), N'ccc@mm.com', CAST(2 AS Numeric(10, 0)), N'ASedd')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(30 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(40 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Assam1', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(41 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Assam1', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(42 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Assam1', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(43 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Assam12', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(44 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Assam12', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(45 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Silvia', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560017 AS Numeric(10, 0)), N'b.dk@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'BIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Rakhi', N'Dey', N'Kar', N'Vijaya Nilaya1', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(980765 AS Numeric(10, 0)), N'rakhi.dey@mnu.com', CAST(2 AS Numeric(10, 0)), N'NMH765NB6')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(58 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Arpan', N'', N'Kar', N'Vijaya Nilaya', CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), N'Bangalore', CAST(986543 AS Numeric(10, 0)), N'arpan@dfrt.com', CAST(2 AS Numeric(10, 0)), N'JU897NH6')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(59 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj', N'', N'Dhekial', N'BTYUI', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bangaore', CAST(786534 AS Numeric(10, 0)), N'biraj@jhihoi.com', CAST(2 AS Numeric(10, 0)), N'MN678YT1')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Rupun', N'', N'', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'rupun@binaff.com', CAST(5 AS Numeric(10, 0)), N'NM675ER7')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(63 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), N'Sourav', N'', N'', N'Sonarpure', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(0 AS Numeric(10, 0)), N'', CAST(1 AS Numeric(10, 0)), N'mmmm1234t')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(64 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Sourav', N'', N'', N'Sonarpur', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Kolkata', CAST(0 AS Numeric(10, 0)), N'', CAST(2 AS Numeric(10, 0)), N'oi9875y6')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(65 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Arpan', N'', N'', N'Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(0 AS Numeric(10, 0)), N'', CAST(2 AS Numeric(10, 0)), N'OO00po98i')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(66 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'AAA', N'', N'', N'AAAA', CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), N'AAAA', CAST(123456 AS Numeric(10, 0)), N'aa@aa.aaa', CAST(2 AS Numeric(10, 0)), N'po0987')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(67 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Arpan', N'', N'Kar', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'arpan.forum@gmail.com', CAST(2 AS Numeric(10, 0)), N'ALPK082LKUS')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(68 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Saptorshi', N'', N'Kar', N'Thane', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Mumbai', CAST(0 AS Numeric(10, 0)), N'sapto.kar@gmail.kar', CAST(2 AS Numeric(10, 0)), N'MNY675M')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(69 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), N'Bisu', N'', N'', N'Mantur', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Kochi', CAST(0 AS Numeric(10, 0)), N'bisu@binaff.com', CAST(1 AS Numeric(10, 0)), N'AMLUJ9856G')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(70 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Santro', N'', N'Sanad', N'ADDD', CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), N'SADE', CAST(0 AS Numeric(10, 0)), N'', CAST(1 AS Numeric(10, 0)), N'BGRTY6345V')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(71 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Misti', N'', N'Basu', N'Behala', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700048 AS Numeric(10, 0)), N'misti.basu@binaff.com', CAST(2 AS Numeric(10, 0)), N'ABNDR8767A')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(72 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Arpan', N'', N'Kar', N'63/1 Nagraj Building, Room No - 3', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560067 AS Numeric(10, 0)), N'arpan.kar@gmail.com', CAST(1 AS Numeric(10, 0)), N'AMLPK3126A')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(73 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'aRPAN', N'', N'kkkk', N'ahghusy', CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), N'jkbjbj', CAST(879876 AS Numeric(10, 0)), N'AAA@MNYH.COM', CAST(4 AS Numeric(10, 0)), N'BJOUOLB')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(74 AS Numeric(10, 0)), NULL, N'Baishali', N'', N'Kar', N'Mumbai', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Mumbai', CAST(897656 AS Numeric(10, 0)), N'baishali@binaff.com', CAST(2 AS Numeric(10, 0)), N'MNGT65TH77')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(75 AS Numeric(10, 0)), NULL, N'Arpan', N'', N'Kar', N'63/4C', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560067 AS Numeric(10, 0)), N'', CAST(5 AS Numeric(10, 0)), N'KJUY6567T')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(76 AS Numeric(10, 0)), NULL, N'Binay', N'', N'Halder', N'Kottaputtam', CAST(1 AS Numeric(10, 0)), CAST(5 AS Numeric(10, 0)), N'Belari', CAST(569878 AS Numeric(10, 0)), N'binay.halder@gmail.com', CAST(1 AS Numeric(10, 0)), N'MNYLP4352H')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(77 AS Numeric(10, 0)), NULL, N'Abhay', N'', N'Dey', N'Murshidabad', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Beldanga', CAST(767865 AS Numeric(10, 0)), N'abhay@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNYTR8756Z')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(78 AS Numeric(10, 0)), NULL, N'Ajitesh', N'', N'Kar', N'Ballygaunge', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700123 AS Numeric(10, 0)), N'ajitesh@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNTHF5409S')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(79 AS Numeric(10, 0)), NULL, N'Binay', N'', N'Sarkar', N'Madhyamgram', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(709878 AS Numeric(10, 0)), N'binay.sarkar@gmail.com', CAST(1 AS Numeric(10, 0)), N'MNTFM7656Y')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(80 AS Numeric(10, 0)), NULL, N'Bidyut', N'', N'Bose', N'Krishnanagar', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(765098 AS Numeric(10, 0)), N'bidyut@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNTRF4534V')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(87 AS Numeric(10, 0)), NULL, N'Anirban', N'', N'Chakroborti', N'Chansandra', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560098 AS Numeric(10, 0)), N'anirban@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNTRF4534N')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(88 AS Numeric(10, 0)), NULL, N'Manotosh', N'', N'Bagchi', N'Bishnupur', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Bishnupur', CAST(723409 AS Numeric(10, 0)), N'mano@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNUYT6745J')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(89 AS Numeric(10, 0)), NULL, N'Indu', N'', N'Paramanik', N'Mirzapur, Mathurapur', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Paraganas', CAST(780098 AS Numeric(10, 0)), N'indu@gmail.com', CAST(1 AS Numeric(10, 0)), N'MNTHY6734F')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(91 AS Numeric(10, 0)), NULL, N'Akash', N'', N'Ghosh', N'Baruipur', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700198 AS Numeric(10, 0)), N'akash.ghosh@binaff.com', CAST(1 AS Numeric(10, 0)), N'AMLPK1234V')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(92 AS Numeric(10, 0)), NULL, N'Subrata', N'', N'Das', N'Paschimpra', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Joynagar', CAST(763523 AS Numeric(10, 0)), N'subrata.das@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNTHY5438N')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(93 AS Numeric(10, 0)), NULL, N'Indranath', N'', N'Bhattachariya', N'South Bishnupur', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Mathurapur', CAST(763423 AS Numeric(10, 0)), N'indra@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNYTH6734V')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(94 AS Numeric(10, 0)), NULL, N'Hemanta', N'', N'Bose', N'Mirzapur', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Mathurapur', CAST(760080 AS Numeric(10, 0)), N'hemanta.bose@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNTHG5609U')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(95 AS Numeric(10, 0)), NULL, N'Ayan', N'', N'Biswas', N'Bghajatin', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700102 AS Numeric(10, 0)), N'ayan@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNTHY9867H')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(96 AS Numeric(10, 0)), NULL, N'Hari', N'', N'Biswas', N'Majherhat', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700145 AS Numeric(10, 0)), N'hari.biswas@binaff.com', CAST(1 AS Numeric(10, 0)), N'AMTYF5098C')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(97 AS Numeric(10, 0)), NULL, N'Manjusa', N'', N'Patra', N'Bhubaneswar', CAST(1 AS Numeric(10, 0)), CAST(5 AS Numeric(10, 0)), N'Bhubaneswar', CAST(726252 AS Numeric(10, 0)), N'amanjusha.patra@binaff.com', CAST(1 AS Numeric(10, 0)), N'AMJHY9564N')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(98 AS Numeric(10, 0)), NULL, N'Manotosh', N'', N'Bagchi', N'Baruipure', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700298 AS Numeric(10, 0)), N'manotosh@binaff.com', CAST(1 AS Numeric(10, 0)), N'MNTFR5420N')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(99 AS Numeric(10, 0)), NULL, N'Sagar', N'', N'', N'sss', CAST(1 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), N'sssssss', CAST(777777 AS Numeric(10, 0)), N'aa.aaaaa@dddd.com', CAST(1 AS Numeric(10, 0)), N'AMNHY5643V')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(100 AS Numeric(10, 0)), NULL, N'Bakul', N'', N'Das', N'SSSS', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Maldah', CAST(734509 AS Numeric(10, 0)), N'bakul.das@gmail.com', CAST(1 AS Numeric(10, 0)), N'MNTHU10978G')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(101 AS Numeric(10, 0)), NULL, N'Manas', N'', N'Das', N'Mandirbazar', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Mathurapur', CAST(760086 AS Numeric(10, 0)), N'manas.das@binaff.com', CAST(1 AS Numeric(10, 0)), N'RTDER9856B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(102 AS Numeric(10, 0)), NULL, N'Mani', N'', N'Bose', N'Majher Para', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Baruuipur', CAST(753402 AS Numeric(10, 0)), N'mani@bin.com', CAST(1 AS Numeric(10, 0)), N'MNTRE4523V')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(103 AS Numeric(10, 0)), NULL, N'Bibi', N'', N'Choudhary', N'mmmm', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'jjjj', CAST(767898 AS Numeric(10, 0)), N'bibi@ddd.com', CAST(1 AS Numeric(10, 0)), N'mmmmmmmm')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(104 AS Numeric(10, 0)), NULL, N'Minakshi', N'', N'Dey', N'iwdoijbwe', CAST(1 AS Numeric(10, 0)), CAST(5 AS Numeric(10, 0)), N'lkblknbkln', CAST(875322 AS Numeric(10, 0)), N'mina@bft.com', CAST(1 AS Numeric(10, 0)), N'jkhioh')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(105 AS Numeric(10, 0)), NULL, N'Mandira', N'', N'', N'ujb', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'bb', CAST(873423 AS Numeric(10, 0)), N'aaaa@bgt.com', CAST(1 AS Numeric(10, 0)), N'klkn')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(106 AS Numeric(10, 0)), NULL, N'Baibhabi', N'', N'', N'iiuuib', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'yyvvy', CAST(999999 AS Numeric(10, 0)), N'nnn@vhjv.com', CAST(1 AS Numeric(10, 0)), N'jbjb')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(107 AS Numeric(10, 0)), NULL, N'Indu', N'', N'Mistri', N'Mathurapur Hat', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Mathurapur', CAST(765432 AS Numeric(10, 0)), N'indu@bina.com', CAST(1 AS Numeric(10, 0)), N'MTREW4097B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(108 AS Numeric(10, 0)), NULL, N'Abhi', N'', N'Dey', N'iuob', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'blklknl', CAST(876543 AS Numeric(10, 0)), N'abi@bgt.com', CAST(1 AS Numeric(10, 0)), N'mjbjhb')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(109 AS Numeric(10, 0)), NULL, N'Ambalika', N'', N'', N'mnfjfdkjfd', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'jjn', CAST(987654 AS Numeric(10, 0)), N'aaa@vcy.com', CAST(1 AS Numeric(10, 0)), N'AMLy83')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(110 AS Numeric(10, 0)), NULL, N'Bidisha', N'', N'Patra', N'Banibihar', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Bhubaneswar', CAST(786756 AS Numeric(10, 0)), N'bidisha.patra@binaff.com', CAST(1 AS Numeric(10, 0)), N'NHTFR4509R')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(112 AS Numeric(10, 0)), NULL, N'Name', N'', N'', N'joijpwe', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'JIJs', CAST(0 AS Numeric(10, 0)), N'', CAST(1 AS Numeric(10, 0)), N'MNHTY6545R')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(113 AS Numeric(10, 0)), NULL, N'Test', N'', N'', N'MBNAijs', CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'MNTHa', CAST(0 AS Numeric(10, 0)), N'', CAST(1 AS Numeric(10, 0)), N'MNTHY4543E')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(114 AS Numeric(10, 0)), NULL, N'Arighna', N'', N'Kar', N'Boalia, Garia', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'arighna.kar@binaff.com', CAST(1 AS Numeric(10, 0)), N'AMLPK3287E')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [CountryId], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(115 AS Numeric(10, 0)), NULL, N'Sourav', N'', N'Saha', N'Sonarpur', CAST(1 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(765567 AS Numeric(10, 0)), N's.saha@binaff.com', CAST(1 AS Numeric(10, 0)), N'AMNHT6576S')
SET IDENTITY_INSERT [Customer].[Customer] OFF
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 07/22/2014 16:34:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[ContactNumberReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[OrganizationId],
			[ContactNumber]
		FROM [Organization].ContactNumber
		WHERE OrganizationId = @ParentId   
	END' 
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 07/22/2014 16:34:35 ******/
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
		SELECT 
			Id,
			[ContactNumber],			
			[OrganizationId]
		FROM [Organization].[ContactNumber]
		WHERE Id = @Id	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 07/22/2014 16:34:35 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 07/22/2014 16:34:35 ******/
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
   
END' 
END
GO
/****** Object:  Table [Lodge].[CheckIn]    Script Date: 07/22/2014 16:34:35 ******/
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
	[Advance] [money] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ReservationId] [numeric](10, 0) NULL,
	[StatusId] [numeric](10, 0) NULL,
	[InvoiceNumber] [varchar](50) NULL,
 CONSTRAINT [PK_CheckIn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Lodge].[CheckIn] ON
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(0x0000A19600000000 AS DateTime), 570.7500, CAST(0x0000A19601135A07 AS DateTime), CAST(48 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(3 AS Numeric(10, 0)), CAST(0x0000A19A00000000 AS DateTime), 700.0000, CAST(0x0000A19A01013165 AS DateTime), CAST(48 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(0x0000A19A00000000 AS DateTime), 700.0000, CAST(0x0000A19A010C295D AS DateTime), CAST(48 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(5 AS Numeric(10, 0)), CAST(0x0000A19A00000000 AS DateTime), 200.0000, CAST(0x0000A19A01161C78 AS DateTime), CAST(48 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(0x0000A1BE00000000 AS DateTime), 666.7500, CAST(0x0000A1BE00CFE7EE AS DateTime), CAST(51 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(11 AS Numeric(10, 0)), CAST(0x0000A310015DE570 AS DateTime), 0.0000, CAST(0x0000A2DC015EA92E AS DateTime), CAST(75 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(0x0000A30100E31AB6 AS DateTime), 1000.0000, CAST(0x0000A30100E31E54 AS DateTime), CAST(77 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-02-04-201413524')
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(13 AS Numeric(10, 0)), CAST(0x0000A31100D7F4B4 AS DateTime), 0.0000, CAST(0x0000A31100D7F5CE AS DateTime), CAST(62 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(14 AS Numeric(10, 0)), CAST(0x0000A31101805E01 AS DateTime), 1000.0000, CAST(0x0000A31101805FB8 AS DateTime), CAST(80 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(15 AS Numeric(10, 0)), CAST(0x0000A31700CCC868 AS DateTime), 1000.0000, CAST(0x0000A31700CCCBE8 AS DateTime), CAST(81 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(18 AS Numeric(10, 0)), CAST(0x0000A32D00C58B18 AS DateTime), 1000.0000, CAST(0x0000A32D00ADC32A AS DateTime), CAST(113 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(19 AS Numeric(10, 0)), CAST(0x0000A32F0155F2FB AS DateTime), 1000.0000, CAST(0x0000A32F0155FBB0 AS DateTime), CAST(118 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(20 AS Numeric(10, 0)), CAST(0x0000A32F016588A1 AS DateTime), 1000.0000, CAST(0x0000A32F01658EEC AS DateTime), CAST(120 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(0x0000A330009745C8 AS DateTime), 1000.0000, CAST(0x0000A33000974A4D AS DateTime), CAST(121 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-23-05-2014162722')
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(0x0000A3340178F31D AS DateTime), 1000.0000, CAST(0x0000A3340178F45E AS DateTime), CAST(123 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-23-05-2014225312')
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(0x0000A3340181A3BE AS DateTime), 100.0000, CAST(0x0000A3340181A3D1 AS DateTime), CAST(124 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-23-05-2014232441')
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(0x0000A33401825F69 AS DateTime), 0.0000, CAST(0x0000A33401825F6B AS DateTime), CAST(125 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-23-05-2014232716')
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(25 AS Numeric(10, 0)), CAST(0x0000A33401836218 AS DateTime), 0.0000, CAST(0x0000A3340183621B AS DateTime), CAST(125 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-23-05-2014233251')
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(26 AS Numeric(10, 0)), CAST(0x0000A336010BDA42 AS DateTime), 0.0000, CAST(0x0000A336010BDC3C AS DateTime), CAST(126 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-25-05-2014161653')
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(27 AS Numeric(10, 0)), CAST(0x0000A33800ECF26F AS DateTime), 0.0000, CAST(0x0000A33800ECF5BC AS DateTime), CAST(127 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-30-05-2014112744')
SET IDENTITY_INSERT [Lodge].[CheckIn] OFF
/****** Object:  Table [Navigator].[CatalogueModuleLink]    Script Date: 07/22/2014 16:34:35 ******/
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
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]') AND name = N'IX_CatalogueModuleLink')
CREATE NONCLUSTERED INDEX [IX_CatalogueModuleLink] ON [Navigator].[CatalogueModuleLink] 
(
	[ModuleId] ASC,
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 07/22/2014 16:34:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[BuildingUpdate]
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
/****** Object:  Table [Lodge].[BuildingClosureReason]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  Table [Lodge].[BuildingFloor]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 07/22/2014 16:34:35 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 07/22/2014 16:34:35 ******/
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
		FROM [Lodge].Building
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 07/22/2014 16:34:35 ******/
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
		FROM [Lodge].Building
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 07/22/2014 16:34:35 ******/
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
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 07/22/2014 16:34:35 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 07/22/2014 16:34:35 ******/
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
	FROM Utility.Appointment
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 07/22/2014 16:34:35 ******/
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
	FROM Utility.Appointment
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 07/22/2014 16:34:35 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 07/22/2014 16:34:35 ******/
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
	FROM Guardian.Account
	WHERE LoginId != ''support''   
	SELECT 
		UserId, 
		RoleId
	FROM Guardian.UserRole   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 07/22/2014 16:34:35 ******/
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
	FROM Guardian.Account
	WHERE Id = @Id
	
	SELECT RoleId 
	FROM Guardian.UserRole 
	WHERE UserId = @Id
	
END
--Guardian.AccountRead 1' 
END
GO
/****** Object:  Table [Invoice].[Artifact]    Script Date: 07/22/2014 16:34:36 ******/
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
SET IDENTITY_INSERT [Invoice].[Artifact] ON
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(14 AS Numeric(10, 0)), CAST(158 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(2 AS Numeric(10, 0)), NULL, CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(3 AS Numeric(10, 0)), NULL, CAST(192 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(4 AS Numeric(10, 0)), NULL, CAST(360 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(5 AS Numeric(10, 0)), NULL, CAST(361 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(6 AS Numeric(10, 0)), NULL, CAST(362 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(7 AS Numeric(10, 0)), NULL, CAST(363 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(8 AS Numeric(10, 0)), NULL, CAST(364 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(9 AS Numeric(10, 0)), CAST(17 AS Numeric(10, 0)), CAST(365 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(18 AS Numeric(10, 0)), CAST(370 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(16 AS Numeric(10, 0)), NULL, CAST(390 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(11 AS Numeric(10, 0)), CAST(19 AS Numeric(10, 0)), CAST(374 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(20 AS Numeric(10, 0)), CAST(377 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(13 AS Numeric(10, 0)), CAST(22 AS Numeric(10, 0)), CAST(383 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Invoice].[Artifact] ([Id], [InvoiceId], [ArtifactId], [Category]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(28 AS Numeric(10, 0)), CAST(395 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Invoice].[Artifact] OFF
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 07/22/2014 16:34:36 ******/
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
/****** Object:  Table [Navigator].[ArtifactModuleLink]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [Navigator].[ArtifactModuleLink](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[ModuleId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_FormModuleLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]') AND name = N'IX_FormModuleLink')
CREATE NONCLUSTERED INDEX [IX_FormModuleLink] ON [Navigator].[ArtifactModuleLink] 
(
	[ModuleId] ASC,
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'Navigator', N'TABLE',N'ArtifactModuleLink', N'COLUMN',N'Category'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Form = 1, Catalogue = 2, Report = 3' , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'TABLE',@level1name=N'ArtifactModuleLink', @level2type=N'COLUMN',@level2name=N'Category'
GO
SET IDENTITY_INSERT [Navigator].[ArtifactModuleLink] ON
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(51 AS Numeric(10, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(52 AS Numeric(10, 0)), CAST(61 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(53 AS Numeric(10, 0)), CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(54 AS Numeric(10, 0)), CAST(63 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(55 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(56 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(58 AS Numeric(10, 0)), CAST(67 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(59 AS Numeric(10, 0)), CAST(68 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(60 AS Numeric(10, 0)), CAST(69 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(61 AS Numeric(10, 0)), CAST(70 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(62 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(63 AS Numeric(10, 0)), CAST(72 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(64 AS Numeric(10, 0)), CAST(73 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(65 AS Numeric(10, 0)), CAST(74 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(68 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(69 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(70 AS Numeric(10, 0)), CAST(82 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(71 AS Numeric(10, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(73 AS Numeric(10, 0)), CAST(85 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(74 AS Numeric(10, 0)), CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(75 AS Numeric(10, 0)), CAST(93 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(77 AS Numeric(10, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(78 AS Numeric(10, 0)), CAST(96 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(79 AS Numeric(10, 0)), CAST(97 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(80 AS Numeric(10, 0)), CAST(98 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(81 AS Numeric(10, 0)), CAST(99 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(82 AS Numeric(10, 0)), CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(83 AS Numeric(10, 0)), CAST(101 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(84 AS Numeric(10, 0)), CAST(102 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(85 AS Numeric(10, 0)), CAST(103 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(86 AS Numeric(10, 0)), CAST(104 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(89 AS Numeric(10, 0)), CAST(107 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(90 AS Numeric(10, 0)), CAST(108 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(91 AS Numeric(10, 0)), CAST(109 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(92 AS Numeric(10, 0)), CAST(110 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(93 AS Numeric(10, 0)), CAST(111 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(94 AS Numeric(10, 0)), CAST(112 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(98 AS Numeric(10, 0)), CAST(116 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(99 AS Numeric(10, 0)), CAST(117 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(100 AS Numeric(10, 0)), CAST(118 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(101 AS Numeric(10, 0)), CAST(119 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(102 AS Numeric(10, 0)), CAST(120 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(103 AS Numeric(10, 0)), CAST(121 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(104 AS Numeric(10, 0)), CAST(122 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(106 AS Numeric(10, 0)), CAST(124 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(107 AS Numeric(10, 0)), CAST(125 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(108 AS Numeric(10, 0)), CAST(126 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(109 AS Numeric(10, 0)), CAST(127 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(110 AS Numeric(10, 0)), CAST(128 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(111 AS Numeric(10, 0)), CAST(129 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(112 AS Numeric(10, 0)), CAST(130 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(113 AS Numeric(10, 0)), CAST(131 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(114 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(115 AS Numeric(10, 0)), CAST(133 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(116 AS Numeric(10, 0)), CAST(134 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(117 AS Numeric(10, 0)), CAST(135 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(118 AS Numeric(10, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(119 AS Numeric(10, 0)), CAST(137 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(120 AS Numeric(10, 0)), CAST(138 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(121 AS Numeric(10, 0)), CAST(139 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(122 AS Numeric(10, 0)), CAST(140 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(123 AS Numeric(10, 0)), CAST(141 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(124 AS Numeric(10, 0)), CAST(142 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(125 AS Numeric(10, 0)), CAST(143 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(126 AS Numeric(10, 0)), CAST(144 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(127 AS Numeric(10, 0)), CAST(145 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(128 AS Numeric(10, 0)), CAST(146 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(129 AS Numeric(10, 0)), CAST(147 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(130 AS Numeric(10, 0)), CAST(148 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(131 AS Numeric(10, 0)), CAST(149 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(132 AS Numeric(10, 0)), CAST(150 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(133 AS Numeric(10, 0)), CAST(151 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(134 AS Numeric(10, 0)), CAST(152 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(135 AS Numeric(10, 0)), CAST(153 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(136 AS Numeric(10, 0)), CAST(154 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(137 AS Numeric(10, 0)), CAST(155 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(138 AS Numeric(10, 0)), CAST(156 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(139 AS Numeric(10, 0)), CAST(157 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(140 AS Numeric(10, 0)), CAST(158 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(142 AS Numeric(10, 0)), CAST(161 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(143 AS Numeric(10, 0)), CAST(162 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(144 AS Numeric(10, 0)), CAST(163 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(145 AS Numeric(10, 0)), CAST(164 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(146 AS Numeric(10, 0)), CAST(165 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(147 AS Numeric(10, 0)), CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(148 AS Numeric(10, 0)), CAST(167 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(149 AS Numeric(10, 0)), CAST(168 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(150 AS Numeric(10, 0)), CAST(169 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(151 AS Numeric(10, 0)), CAST(170 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(152 AS Numeric(10, 0)), CAST(171 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(153 AS Numeric(10, 0)), CAST(172 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(154 AS Numeric(10, 0)), CAST(173 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(155 AS Numeric(10, 0)), CAST(174 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(156 AS Numeric(10, 0)), CAST(175 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(157 AS Numeric(10, 0)), CAST(176 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(158 AS Numeric(10, 0)), CAST(177 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(159 AS Numeric(10, 0)), CAST(178 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(161 AS Numeric(10, 0)), CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(171 AS Numeric(10, 0)), CAST(191 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
GO
print 'Processed 100 total records'
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(172 AS Numeric(10, 0)), CAST(192 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(173 AS Numeric(10, 0)), CAST(193 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(174 AS Numeric(10, 0)), CAST(194 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(175 AS Numeric(10, 0)), CAST(195 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(176 AS Numeric(10, 0)), CAST(196 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(177 AS Numeric(10, 0)), CAST(197 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(178 AS Numeric(10, 0)), CAST(198 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(179 AS Numeric(10, 0)), CAST(199 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(180 AS Numeric(10, 0)), CAST(200 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(181 AS Numeric(10, 0)), CAST(201 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(183 AS Numeric(10, 0)), CAST(203 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(184 AS Numeric(10, 0)), CAST(204 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(185 AS Numeric(10, 0)), CAST(205 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(186 AS Numeric(10, 0)), CAST(206 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(187 AS Numeric(10, 0)), CAST(207 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(188 AS Numeric(10, 0)), CAST(208 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(192 AS Numeric(10, 0)), CAST(212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(193 AS Numeric(10, 0)), CAST(213 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(194 AS Numeric(10, 0)), CAST(214 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(195 AS Numeric(10, 0)), CAST(215 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(196 AS Numeric(10, 0)), CAST(216 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(197 AS Numeric(10, 0)), CAST(217 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(198 AS Numeric(10, 0)), CAST(218 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(199 AS Numeric(10, 0)), CAST(219 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(200 AS Numeric(10, 0)), CAST(220 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(201 AS Numeric(10, 0)), CAST(221 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(203 AS Numeric(10, 0)), CAST(223 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(204 AS Numeric(10, 0)), CAST(224 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(205 AS Numeric(10, 0)), CAST(225 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(206 AS Numeric(10, 0)), CAST(226 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(207 AS Numeric(10, 0)), CAST(227 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(208 AS Numeric(10, 0)), CAST(228 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(209 AS Numeric(10, 0)), CAST(229 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(210 AS Numeric(10, 0)), CAST(230 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(211 AS Numeric(10, 0)), CAST(231 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(212 AS Numeric(10, 0)), CAST(232 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(213 AS Numeric(10, 0)), CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(214 AS Numeric(10, 0)), CAST(234 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(216 AS Numeric(10, 0)), CAST(236 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(217 AS Numeric(10, 0)), CAST(237 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(218 AS Numeric(10, 0)), CAST(238 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(219 AS Numeric(10, 0)), CAST(239 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(220 AS Numeric(10, 0)), CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(221 AS Numeric(10, 0)), CAST(241 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(222 AS Numeric(10, 0)), CAST(242 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(223 AS Numeric(10, 0)), CAST(243 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(224 AS Numeric(10, 0)), CAST(244 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(225 AS Numeric(10, 0)), CAST(245 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(226 AS Numeric(10, 0)), CAST(246 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(227 AS Numeric(10, 0)), CAST(247 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(228 AS Numeric(10, 0)), CAST(248 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(229 AS Numeric(10, 0)), CAST(249 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(230 AS Numeric(10, 0)), CAST(250 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(231 AS Numeric(10, 0)), CAST(251 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(232 AS Numeric(10, 0)), CAST(252 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(233 AS Numeric(10, 0)), CAST(253 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(234 AS Numeric(10, 0)), CAST(254 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(235 AS Numeric(10, 0)), CAST(255 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(236 AS Numeric(10, 0)), CAST(256 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(237 AS Numeric(10, 0)), CAST(257 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(238 AS Numeric(10, 0)), CAST(258 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(239 AS Numeric(10, 0)), CAST(259 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(240 AS Numeric(10, 0)), CAST(260 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(241 AS Numeric(10, 0)), CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(242 AS Numeric(10, 0)), CAST(262 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(243 AS Numeric(10, 0)), CAST(263 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(244 AS Numeric(10, 0)), CAST(264 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(245 AS Numeric(10, 0)), CAST(265 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(246 AS Numeric(10, 0)), CAST(266 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(247 AS Numeric(10, 0)), CAST(267 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(248 AS Numeric(10, 0)), CAST(268 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(249 AS Numeric(10, 0)), CAST(269 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(250 AS Numeric(10, 0)), CAST(270 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(251 AS Numeric(10, 0)), CAST(271 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(252 AS Numeric(10, 0)), CAST(272 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(253 AS Numeric(10, 0)), CAST(273 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(254 AS Numeric(10, 0)), CAST(274 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(255 AS Numeric(10, 0)), CAST(275 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(256 AS Numeric(10, 0)), CAST(276 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(257 AS Numeric(10, 0)), CAST(277 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(258 AS Numeric(10, 0)), CAST(278 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(259 AS Numeric(10, 0)), CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(260 AS Numeric(10, 0)), CAST(280 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(261 AS Numeric(10, 0)), CAST(281 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(262 AS Numeric(10, 0)), CAST(282 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(263 AS Numeric(10, 0)), CAST(283 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(264 AS Numeric(10, 0)), CAST(284 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(265 AS Numeric(10, 0)), CAST(285 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(266 AS Numeric(10, 0)), CAST(286 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(267 AS Numeric(10, 0)), CAST(287 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(268 AS Numeric(10, 0)), CAST(288 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(269 AS Numeric(10, 0)), CAST(289 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(270 AS Numeric(10, 0)), CAST(290 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(271 AS Numeric(10, 0)), CAST(291 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(272 AS Numeric(10, 0)), CAST(292 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(273 AS Numeric(10, 0)), CAST(293 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(274 AS Numeric(10, 0)), CAST(294 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(275 AS Numeric(10, 0)), CAST(295 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(276 AS Numeric(10, 0)), CAST(296 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(277 AS Numeric(10, 0)), CAST(297 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(278 AS Numeric(10, 0)), CAST(298 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
GO
print 'Processed 200 total records'
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(279 AS Numeric(10, 0)), CAST(299 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(280 AS Numeric(10, 0)), CAST(300 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(281 AS Numeric(10, 0)), CAST(301 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(282 AS Numeric(10, 0)), CAST(302 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(283 AS Numeric(10, 0)), CAST(303 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(284 AS Numeric(10, 0)), CAST(304 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(285 AS Numeric(10, 0)), CAST(305 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(286 AS Numeric(10, 0)), CAST(306 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(287 AS Numeric(10, 0)), CAST(307 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(288 AS Numeric(10, 0)), CAST(308 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(289 AS Numeric(10, 0)), CAST(309 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(290 AS Numeric(10, 0)), CAST(310 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(291 AS Numeric(10, 0)), CAST(311 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(292 AS Numeric(10, 0)), CAST(312 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(293 AS Numeric(10, 0)), CAST(313 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(294 AS Numeric(10, 0)), CAST(314 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(295 AS Numeric(10, 0)), CAST(315 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(296 AS Numeric(10, 0)), CAST(316 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(297 AS Numeric(10, 0)), CAST(317 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(298 AS Numeric(10, 0)), CAST(318 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(299 AS Numeric(10, 0)), CAST(319 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(300 AS Numeric(10, 0)), CAST(320 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(301 AS Numeric(10, 0)), CAST(321 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(302 AS Numeric(10, 0)), CAST(322 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(303 AS Numeric(10, 0)), CAST(323 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(304 AS Numeric(10, 0)), CAST(324 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(305 AS Numeric(10, 0)), CAST(325 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(306 AS Numeric(10, 0)), CAST(326 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(307 AS Numeric(10, 0)), CAST(327 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(308 AS Numeric(10, 0)), CAST(328 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(309 AS Numeric(10, 0)), CAST(329 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(310 AS Numeric(10, 0)), CAST(330 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(311 AS Numeric(10, 0)), CAST(331 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(312 AS Numeric(10, 0)), CAST(332 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(313 AS Numeric(10, 0)), CAST(333 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(314 AS Numeric(10, 0)), CAST(334 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(315 AS Numeric(10, 0)), CAST(335 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(316 AS Numeric(10, 0)), CAST(336 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(317 AS Numeric(10, 0)), CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(318 AS Numeric(10, 0)), CAST(338 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(319 AS Numeric(10, 0)), CAST(339 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(320 AS Numeric(10, 0)), CAST(340 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(321 AS Numeric(10, 0)), CAST(341 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(322 AS Numeric(10, 0)), CAST(342 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(323 AS Numeric(10, 0)), CAST(343 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(324 AS Numeric(10, 0)), CAST(344 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(325 AS Numeric(10, 0)), CAST(345 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(326 AS Numeric(10, 0)), CAST(346 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(327 AS Numeric(10, 0)), CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(328 AS Numeric(10, 0)), CAST(348 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(329 AS Numeric(10, 0)), CAST(349 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(330 AS Numeric(10, 0)), CAST(350 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(331 AS Numeric(10, 0)), CAST(351 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(332 AS Numeric(10, 0)), CAST(352 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(333 AS Numeric(10, 0)), CAST(353 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(334 AS Numeric(10, 0)), CAST(354 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(335 AS Numeric(10, 0)), CAST(355 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(336 AS Numeric(10, 0)), CAST(356 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(337 AS Numeric(10, 0)), CAST(357 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(338 AS Numeric(10, 0)), CAST(358 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(339 AS Numeric(10, 0)), CAST(359 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(340 AS Numeric(10, 0)), CAST(360 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(341 AS Numeric(10, 0)), CAST(361 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(342 AS Numeric(10, 0)), CAST(362 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(343 AS Numeric(10, 0)), CAST(363 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(344 AS Numeric(10, 0)), CAST(364 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(345 AS Numeric(10, 0)), CAST(365 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(346 AS Numeric(10, 0)), CAST(366 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(347 AS Numeric(10, 0)), CAST(367 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(348 AS Numeric(10, 0)), CAST(368 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(349 AS Numeric(10, 0)), CAST(369 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(350 AS Numeric(10, 0)), CAST(370 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(351 AS Numeric(10, 0)), CAST(371 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(352 AS Numeric(10, 0)), CAST(372 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(353 AS Numeric(10, 0)), CAST(373 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(354 AS Numeric(10, 0)), CAST(374 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(355 AS Numeric(10, 0)), CAST(375 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(356 AS Numeric(10, 0)), CAST(376 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(357 AS Numeric(10, 0)), CAST(377 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(358 AS Numeric(10, 0)), CAST(378 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(359 AS Numeric(10, 0)), CAST(379 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(360 AS Numeric(10, 0)), CAST(380 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(361 AS Numeric(10, 0)), CAST(381 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(362 AS Numeric(10, 0)), CAST(382 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(363 AS Numeric(10, 0)), CAST(383 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(364 AS Numeric(10, 0)), CAST(384 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(365 AS Numeric(10, 0)), CAST(385 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(366 AS Numeric(10, 0)), CAST(386 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(367 AS Numeric(10, 0)), CAST(387 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(370 AS Numeric(10, 0)), CAST(390 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(375 AS Numeric(10, 0)), CAST(395 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(376 AS Numeric(10, 0)), CAST(396 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(377 AS Numeric(10, 0)), CAST(397 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(378 AS Numeric(10, 0)), CAST(398 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(379 AS Numeric(10, 0)), CAST(399 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(381 AS Numeric(10, 0)), CAST(401 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(382 AS Numeric(10, 0)), CAST(402 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(383 AS Numeric(10, 0)), CAST(403 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(384 AS Numeric(10, 0)), CAST(404 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(385 AS Numeric(10, 0)), CAST(405 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(386 AS Numeric(10, 0)), CAST(406 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
GO
print 'Processed 300 total records'
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(387 AS Numeric(10, 0)), CAST(407 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(388 AS Numeric(10, 0)), CAST(408 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(392 AS Numeric(10, 0)), CAST(412 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(393 AS Numeric(10, 0)), CAST(413 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(394 AS Numeric(10, 0)), CAST(414 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(395 AS Numeric(10, 0)), CAST(415 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(399 AS Numeric(10, 0)), CAST(422 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(400 AS Numeric(10, 0)), CAST(423 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(401 AS Numeric(10, 0)), CAST(424 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(402 AS Numeric(10, 0)), CAST(425 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(403 AS Numeric(10, 0)), CAST(426 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(404 AS Numeric(10, 0)), CAST(427 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(405 AS Numeric(10, 0)), CAST(428 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(406 AS Numeric(10, 0)), CAST(429 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(407 AS Numeric(10, 0)), CAST(430 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Navigator].[ArtifactModuleLink] OFF
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 07/22/2014 16:34:36 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactReadForPath]    Script Date: 07/22/2014 16:34:36 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 07/22/2014 16:34:36 ******/
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
	FROM Navigator.Artifact
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 07/22/2014 16:34:36 ******/
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
	FROM Navigator.Artifact
	WHERE Id = @Id --OR ParentId = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 07/22/2014 16:34:36 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 07/22/2014 16:34:36 ******/
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
   FROM Guardian.LoginHistory 
   WHERE AccountId = @ParentId
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Guardian].[LoginHistoryRead]
(
   @Id Numeric(10,0) OUT
)
AS
BEGIN
   SELECT Id, AccountId, LoginStamp, LogoutStamp
   FROM Guardian.LoginHistory
   WHERE Id = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 07/22/2014 16:34:36 ******/
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
/****** Object:  Table [Invoice].[LineItemTaxation]    Script Date: 07/22/2014 16:34:36 ******/
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
SET IDENTITY_INSERT [Invoice].[LineItemTaxation] ON
INSERT [Invoice].[LineItemTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [LineItemId]) VALUES (CAST(3 AS Numeric(10, 0)), N'Service Tax', 12.5000, 1, CAST(32 AS Numeric(10, 0)))
INSERT [Invoice].[LineItemTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [LineItemId]) VALUES (CAST(4 AS Numeric(10, 0)), N'Luxury Tax', 12.0000, 1, CAST(32 AS Numeric(10, 0)))
INSERT [Invoice].[LineItemTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [LineItemId]) VALUES (CAST(9 AS Numeric(10, 0)), N'Service Tax', 12.5000, 1, CAST(35 AS Numeric(10, 0)))
INSERT [Invoice].[LineItemTaxation] ([Id], [TaxName], [TaxAmount], [IsPercentage], [LineItemId]) VALUES (CAST(10 AS Numeric(10, 0)), N'Luxury Tax', 12.0000, 1, CAST(35 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Invoice].[LineItemTaxation] OFF
/****** Object:  StoredProcedure [Invoice].[LineItemReadForParent]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[LineItemReadForParent]
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
		FROM [Invoice].LineItem
		WHERE InvoiceId = @ParentId   
	END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadAll]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



Create PROCEDURE [Invoice].[LineItemReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Start],
		[End],
		[Description],
		[UnitRate],
		[Count]
	FROM [Invoice].LineItem
   
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemRead]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





CREATE PROCEDURE [Invoice].[LineItemRead]
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
	FROM [Invoice].LineItem
	WHERE Id = @Id   
	
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[LineItemInsert]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[LineItemInsert]
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
/****** Object:  StoredProcedure [Invoice].[LineItemDelete]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


Create PROCEDURE [Invoice].[LineItemDelete]
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
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


Create Procedure [Lodge].[IsBuildingDeletable]
(
	@OrganizationId NUMERIC(10,0)
)
As
Begin
	select Name,StatusId from [Lodge].Building
	where OrganizationId = @OrganizationId
End' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Invoice].[InvoiceTaxationRead]
	 (
		@InvoiceId Numeric(10,0)
	 )
	 As
	 Begin
		Select  
			[TaxName],
			[TaxAmount],
			[IsPercentage],
			[InvoiceId]
		From [Invoice].InvoiceTaxation
		Where InvoiceId = @InvoiceId
	 End
	 
' 
END
GO
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[EmailRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN	
		SELECT 
			Id,
			[Email],			
			[OrganizationId]
		FROM [Organization].[Email]
		WHERE Id = @Id	
END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[InvoiceTaxationInsert]
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
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentRead]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Invoice].[InvoicePaymentRead]
	 (
		@InvoiceId Numeric(10,0)
	 )
	 As
	 Begin
		Select  
			[InvoiceId],
			[PaymentTypeId],
			[CardNumber],
			[Remark],
			[Amount],
			[Date]
		From [Invoice].[Payment]
		Where InvoiceId = @InvoiceId
	 End
	 
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsTariffDeletable]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsTariffDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[IsTariffDeletable] 
(
	@RoomId NUMERIC(10,0)
)
AS
BEGIN
	Select 
		StartDate,
		EndDate	
	From [lodge].RoomTariff
	Where RoomId = @RoomId

 END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[IsPaymentTypeDeletable]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[IsPaymentTypeDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Invoice].[IsPaymentTypeDeletable]
(
	@PaymentTypeId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  Id,CardNumber,[Date],Remark
	FROM [Invoice].[Payment]
	WHERE PaymentTypeId = @paymentTypeId

 END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 07/22/2014 16:34:36 ******/
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
	SELECT (SELECT LoginId FROM Guardian.Account WHERE Id = UserId) LoginId, FirstName, LastName
	FROM Guardian.[Profile]
	WHERE Initial = @InitialId

 END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingTypeDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE Procedure [Lodge].[IsBuildingTypeDeletable] 
(
	@TypeId NUMERIC(10,0)
)
As
Begin
	select Name from [Lodge].Building
	where TypeId = @TypeId
End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingStatusDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

Create Procedure [Lodge].[IsBuildingStatusDeletable]
(
	@StatusId NUMERIC(10,0)
)
As
Begin
	select Name,StatusId from [Lodge].Building
	where StatusId = @StatusId
End' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadAll]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Invoice].[PaymentReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Date],
		[CardNumber],
		[Remark],
		[PaymentTypeId]
	FROM [Invoice].Payment
   
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentRead]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[PaymentRead]
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
	FROM [Invoice].Payment
	WHERE Id = @Id   
	
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentInsert]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Invoice].[PaymentInsert]
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
	
	INSERT INTO [Invoice].[Payment]([InvoiceId],[PaymentTypeId],[CardNumber],[Remark],[Amount],[Date])
	VALUES(@InvoiceId,@PaymentTypeId,@CardNumber,@Remark,@Amount,GETDATE())
   
	SET @Id = @@IDENTITY
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[PaymentDelete]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Invoice].[PaymentDelete]
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
/****** Object:  StoredProcedure [Invoice].[LineItemUpdate]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



Create PROCEDURE [Invoice].[LineItemUpdate]
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
/****** Object:  Table [Guardian].[ProfileContactNumber]    Script Date: 07/22/2014 16:34:36 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentUpdate]    Script Date: 07/22/2014 16:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[PaymentUpdate]
(
	@Id Numeric(10,0),
	@CardNumber Varchar(4),
	@Remark Varchar(255),
	@PaymentTypeId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE [Invoice].[Payment]
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
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 07/22/2014 16:34:36 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 07/22/2014 16:34:36 ******/
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
	FROM Guardian.[Profile]
	WHERE UserId = @Id
   
END

' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 07/22/2014 16:34:36 ******/
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
/****** Object:  Table [Navigator].[ReportModuleLink]    Script Date: 07/22/2014 16:34:36 ******/
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
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]') AND name = N'IX_ReportModuleLink')
CREATE NONCLUSTERED INDEX [IX_ReportModuleLink] ON [Navigator].[ReportModuleLink] 
(
	[ModuleId] ASC,
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [Invoice].[ReportArtifact]    Script Date: 07/22/2014 16:34:37 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [Customer].[ReportArtifact]    Script Date: 07/22/2014 16:34:37 ******/
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
 CONSTRAINT [PK_ReportArtifact_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Customer].[ReportArtifact] ON
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(10 AS Numeric(10, 0)), NULL, CAST(212 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(11 AS Numeric(10, 0)), NULL, CAST(213 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(12 AS Numeric(10, 0)), NULL, CAST(214 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(13 AS Numeric(10, 0)), NULL, CAST(215 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(14 AS Numeric(10, 0)), NULL, CAST(216 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(15 AS Numeric(10, 0)), NULL, CAST(217 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(16 AS Numeric(10, 0)), NULL, CAST(218 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(17 AS Numeric(10, 0)), NULL, CAST(219 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(18 AS Numeric(10, 0)), NULL, CAST(220 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(19 AS Numeric(10, 0)), CAST(28 AS Numeric(10, 0)), CAST(221 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(38 AS Numeric(10, 0)), CAST(223 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(39 AS Numeric(10, 0)), CAST(228 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(42 AS Numeric(10, 0)), CAST(229 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(24 AS Numeric(10, 0)), NULL, CAST(232 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(25 AS Numeric(10, 0)), NULL, CAST(236 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(26 AS Numeric(10, 0)), NULL, CAST(237 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(27 AS Numeric(10, 0)), NULL, CAST(239 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(28 AS Numeric(10, 0)), NULL, CAST(245 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(29 AS Numeric(10, 0)), NULL, CAST(246 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
INSERT [Customer].[ReportArtifact] ([Id], [ReportId], [ArtifactId], [Category]) VALUES (CAST(30 AS Numeric(10, 0)), NULL, CAST(277 AS Numeric(10, 0)), CAST(3 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Customer].[ReportArtifact] OFF
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[RoomTariffUpdate]
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[RoomTariffReadAll]
	As
	Begin
		Select   
			Id,
			CategoryId,
			TypeId,
			IsAirConditioned,
			StartDate,
			EndDate,
			Rate
		From [Lodge].RoomTariff  
	End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[RoomTariffRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		Select   
			Id,
			CategoryId,
			TypeId,
			IsAirConditioned,
			StartDate,
			EndDate,
			Rate
		From [Lodge].RoomTariff  
		Where Id = @Id     
		
	END
' 
END
GO
/****** Object:  Table [Lodge].[RoomReservationArtifact]    Script Date: 07/22/2014 16:34:37 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Lodge].[RoomReservationArtifact] ON
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(1 AS Numeric(10, 0)), NULL, CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(2 AS Numeric(10, 0)), NULL, CAST(104 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(5 AS Numeric(10, 0)), CAST(61 AS Numeric(10, 0)), CAST(107 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(6 AS Numeric(10, 0)), CAST(62 AS Numeric(10, 0)), CAST(108 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(63 AS Numeric(10, 0)), CAST(109 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(8 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)), CAST(110 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(9 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(111 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)), CAST(112 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(11 AS Numeric(10, 0)), CAST(69 AS Numeric(10, 0)), CAST(117 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(70 AS Numeric(10, 0)), CAST(118 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(13 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)), CAST(119 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(14 AS Numeric(10, 0)), CAST(72 AS Numeric(10, 0)), CAST(124 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(15 AS Numeric(10, 0)), NULL, CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(16 AS Numeric(10, 0)), NULL, CAST(131 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(17 AS Numeric(10, 0)), CAST(73 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(18 AS Numeric(10, 0)), CAST(74 AS Numeric(10, 0)), CAST(133 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(19 AS Numeric(10, 0)), NULL, CAST(134 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(20 AS Numeric(10, 0)), NULL, CAST(135 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(75 AS Numeric(10, 0)), CAST(146 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)), CAST(149 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)), CAST(156 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(24 AS Numeric(10, 0)), NULL, CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(25 AS Numeric(10, 0)), NULL, CAST(176 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(26 AS Numeric(10, 0)), NULL, CAST(177 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(27 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), CAST(178 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(29 AS Numeric(10, 0)), NULL, CAST(195 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(30 AS Numeric(10, 0)), NULL, CAST(196 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(31 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), CAST(197 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(32 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), CAST(200 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(33 AS Numeric(10, 0)), CAST(81 AS Numeric(10, 0)), CAST(205 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(34 AS Numeric(10, 0)), NULL, CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(35 AS Numeric(10, 0)), NULL, CAST(248 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(36 AS Numeric(10, 0)), CAST(113 AS Numeric(10, 0)), CAST(249 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(37 AS Numeric(10, 0)), CAST(108 AS Numeric(10, 0)), CAST(250 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(38 AS Numeric(10, 0)), NULL, CAST(251 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(39 AS Numeric(10, 0)), CAST(114 AS Numeric(10, 0)), CAST(252 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(40 AS Numeric(10, 0)), NULL, CAST(253 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(41 AS Numeric(10, 0)), NULL, CAST(255 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(42 AS Numeric(10, 0)), CAST(118 AS Numeric(10, 0)), CAST(256 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(43 AS Numeric(10, 0)), CAST(119 AS Numeric(10, 0)), CAST(263 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(44 AS Numeric(10, 0)), NULL, CAST(269 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(45 AS Numeric(10, 0)), CAST(120 AS Numeric(10, 0)), CAST(270 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(46 AS Numeric(10, 0)), NULL, CAST(272 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(47 AS Numeric(10, 0)), CAST(121 AS Numeric(10, 0)), CAST(273 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(48 AS Numeric(10, 0)), CAST(122 AS Numeric(10, 0)), CAST(276 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(49 AS Numeric(10, 0)), NULL, CAST(278 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(50 AS Numeric(10, 0)), NULL, CAST(335 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(51 AS Numeric(10, 0)), CAST(123 AS Numeric(10, 0)), CAST(336 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(52 AS Numeric(10, 0)), NULL, CAST(366 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(53 AS Numeric(10, 0)), NULL, CAST(371 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(54 AS Numeric(10, 0)), CAST(124 AS Numeric(10, 0)), CAST(372 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(55 AS Numeric(10, 0)), CAST(125 AS Numeric(10, 0)), CAST(375 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(56 AS Numeric(10, 0)), NULL, CAST(380 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(126 AS Numeric(10, 0)), CAST(381 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(58 AS Numeric(10, 0)), NULL, CAST(384 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(59 AS Numeric(10, 0)), CAST(127 AS Numeric(10, 0)), CAST(385 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(60 AS Numeric(10, 0)), NULL, CAST(398 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(61 AS Numeric(10, 0)), CAST(128 AS Numeric(10, 0)), CAST(399 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(62 AS Numeric(10, 0)), NULL, CAST(401 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(63 AS Numeric(10, 0)), CAST(131 AS Numeric(10, 0)), CAST(405 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(64 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)), CAST(406 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(65 AS Numeric(10, 0)), NULL, CAST(407 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(66 AS Numeric(10, 0)), CAST(133 AS Numeric(10, 0)), CAST(408 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(67 AS Numeric(10, 0)), NULL, CAST(427 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(68 AS Numeric(10, 0)), CAST(134 AS Numeric(10, 0)), CAST(428 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Lodge].[RoomReservationArtifact] OFF
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--select * from [Lodge].[RoomReservation]

CREATE PROCEDURE [Lodge].[RoomReservationReadAll]
	AS
	BEGIN
		
		SELECT 
			Id, BookingFrom, StatusId, NoOfDays, NoOfRooms, CreatedDate,
			IsCheckedIn, RoomCategoryId, RoomTypeId, AcRoomPreference,
			NoOfMale, NoOfFemale, NoOfChild, NoOfInfant,
			Remark
		FROM Lodge.RoomReservation
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[RoomReservationRead]
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
		FROM Lodge.RoomReservation
		WHERE Id = @Id   
		
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[RoomReservationInsert]
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdateStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[RoomReservationUpdateStatus]
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
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
		
CREATE PROCEDURE [Lodge].[RoomReservationUpdate]
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 07/22/2014 16:34:37 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

 --		[Lodge].[TariffReadDuplicate] 4,''03-12-2013'', ''03-24-2013''

CREATE PROCEDURE [Lodge].[TariffReadDuplicate]
	(
		@RoomId Numeric(10,0),
		@StartDate DateTime,
		@EndDate DateTime
	)
AS
BEGIN

	Select 
		RT.Id,
		RT.Rate,
		RT.StartDate,
		RT.EndDate,
		RT.RoomId
	From [Lodge].RoomTariff RT
	Where RoomId = @RoomId
	And 
	(
	cast(convert(char(11), @StartDate, 113) as datetime)  between cast(convert(char(11), StartDate, 113) as datetime) and cast(convert(char(11), EndDate, 113) as datetime)
	Or cast(convert(char(11), @EndDate, 113) as datetime) between cast(convert(char(11), StartDate, 113) as datetime) and cast(convert(char(11), EndDate, 113) as datetime)
	or cast(convert(char(11), StartDate, 113) as datetime) between cast(convert(char(11), @StartDate, 113) as datetime) and cast(convert(char(11), @EndDate, 113) as datetime)
	or cast(convert(char(11), EndDate, 113) as datetime) between cast(convert(char(11), @StartDate, 113) as datetime) and cast(convert(char(11), @EndDate, 113) as datetime)
	)
END
	' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllFuture]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[TariffReadAllFuture]
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
	FROM RoomTariff
	Where CAST(FLOOR(CAST(EndDate AS float)) AS datetime) > CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime) 

   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllCurrent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Lodge].[TariffReadAllCurrent]
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
	FROM [Lodge].RoomTariff
	Where CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime) >= CAST(FLOOR(CAST(StartDate AS float)) AS datetime)
	And CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime) <= CAST(FLOOR(CAST(EndDate AS float)) AS datetime)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffIsExist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[TariffIsExist]
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
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 07/22/2014 16:34:37 ******/
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
	FROM [Configuration].State 
	WHERE Name = @Name				
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Configuration].[StateReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].State
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 07/22/2014 16:34:37 ******/
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
	
   Select 
		Id,
		[Name]
   From [Configuration].State
   Where Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Guardian].[SecurityAnswerUpdate]
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
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
		FROM Guardian.SecurityAnswer
		WHERE UserId = @ParentId   
	END' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 07/22/2014 16:34:37 ******/
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
	FROM Guardian.SecurityAnswer
	WHERE UserId = @Id   
   
END

' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Invoice].[ReportSales]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReportSales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE Procedure [Invoice].[ReportSales]
(
	@StartDate DateTime,
	@EndDate DateTime
)
As
Begin
	
	SELECT 
		Inv.Id, [Date],
		SellerName, SellerAddress, SellerContactNo, SellerEmail, SellerLicence,
		BuyerName, BuyerAddress, BuyerContactNo, BuyerEmail,
		InvoiceNumber,
		(SELECT SUM(Amount) FROM [Invoice].Payment WHERE InvoiceId =  Inv.Id) AS AmountPaid,
		Amount, Discount, Tax
	FROM [Invoice].Invoice AS Inv
	LEFT OUTER JOIN (SELECT 
		IT.InvoiceId, Amount, SUM(
			CASE WHEN IsPercentage = 0
			THEN TaxAmount
			ELSE InvAmt.Amount * TaxAmount / 100
			END) AS Tax
			FROM Invoice.InvoiceTaxation IT
		INNER JOIN (SELECT 
			InvoiceId, SUM(UnitRate * [Count]) AS Amount 
			FROM Invoice.LineItem
			GROUP BY InvoiceId) AS InvAmt ON InvAmt.InvoiceId =  IT.InvoiceId
		GROUP BY IT.InvoiceId, Amount) AS T ON T.InvoiceId =  Inv.Id
	WHERE DATEADD(dd, DATEDIFF(dd, 0, [Date]), 0) -- removing time part from CreatedDate
	BETWEEN DATEADD(dd, DATEDIFF(dd, 0, @StartDate ), 0) AND DATEADD(dd, DATEDIFF(dd, 0, @EndDate ), 0)

End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 07/22/2014 16:34:37 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 07/22/2014 16:34:37 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Invoice].[SlabReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId Id, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab
	WHERE TaxId = @ParentId	
	
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadAll]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Invoice].[SlabReadAll]
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[SlabRead]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[SlabRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Invoice].[SlabRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab
	WHERE TaxId = @Id	
	
END

' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 07/22/2014 16:34:37 ******/
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
	FROM Guardian.UserRole
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 07/22/2014 16:34:37 ******/
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
	FROM Guardian.UserRole
	WHERE UserId = @UserId
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationStatusToCheckIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
Create Procedure [Lodge].[UpdateReservationStatusToCheckIn]
(
	@ReservationId Numeric(10,0)
)
As
Begin
	Update [Lodge].RoomReservation
	Set IsCheckedIn = 1
	Where [Lodge].RoomReservation.Id = @ReservationId
End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[UpdateInvoiceNumber]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateInvoiceNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Lodge].[UpdateInvoiceNumber]
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
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateCheckInStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


Create PROCEDURE [Lodge].[UpdateCheckInStatus]
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadLink]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


--DROP PROCEDURE [Lodge].[ReadReservationFormForArtifact]
--GO
CREATE PROCEDURE [Lodge].[RoomReservationArtifactReadLink]
(
	@ArtifactId Numeric(10,0)--,
	--@Category Numeric(1)
)
AS
BEGIN
	
	SELECT Id, RoomReservationId ComponentId
	FROM Lodge.RoomReservationArtifact
	WHERE ArtifactId = @ArtifactId
		--AND Category =  @Category
	
END
' 
END
GO
/****** Object:  Table [Lodge].[Room]    Script Date: 07/22/2014 16:34:37 ******/
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
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(1 AS Numeric(10, 0)), N'101', N'AA', N'', CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(16 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(2 AS Numeric(10, 0)), N'102', N'BB', N'', CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(16 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(3 AS Numeric(10, 0)), N'101', N'Baishakh', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(4 AS Numeric(10, 0)), N'102', N'Jaistha', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(5 AS Numeric(10, 0)), N'103', N'Aashadh', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(6 AS Numeric(10, 0)), N'104', N'Shraban', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(7 AS Numeric(10, 0)), N'201', N'Bhaadra', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(8 AS Numeric(10, 0)), N'202', N'Aashin', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(9 AS Numeric(10, 0)), N'203', N'Kartik', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(10 AS Numeric(10, 0)), N'204', N'Aghran', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(11 AS Numeric(10, 0)), N'301', N'Paush', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(12 AS Numeric(10, 0)), N'302', N'Maagh', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(13 AS Numeric(10, 0)), N'303', N'Falgun', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
INSERT [Lodge].[Room] ([Id], [Number], [Name], [Description], [CategoryId], [TypeId], [BuildingId], [FloorId], [IsAirConditioned], [StatusId]) VALUES (CAST(14 AS Numeric(10, 0)), N'304', N'Chaitra', N'', CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), 1, CAST(10001 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Lodge].[Room] OFF
/****** Object:  StoredProcedure [Lodge].[ReservationArtifactUpdateLink]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReservationArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[ReservationArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0)        
)
AS
BEGIN
 
	UPDATE Lodge.RoomReservationArtifact
	SET [RoomReservationId] = @ComponentId
	WHERE [ArtifactId] = @ArtifactId
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[ReservationArtifactInsertLink]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReservationArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[ReservationArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Lodge.RoomReservationArtifact([RoomReservationId],[ArtifactId], [Category])
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[ReservationArtifactDeleteLink]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReservationArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[ReservationArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM [Lodge].[RoomReservationArtifact]
	WHERE ArtifactId = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReadCustomerReportForArtifact]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReadCustomerReportForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Customer].[ReadCustomerReportForArtifact]
(
	@ArtifactId Numeric(10,0)--,
	--@Category Numeric(1)
)
AS
BEGIN
	
	SELECT 
		Id,
		ReportId
	FROM [Customer].ReportArtifact
	WHERE ArtifactId = @ArtifactId
		--AND Category =  @Category
	
END


' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadArtifactForInvoiceNumber]    Script Date: 07/22/2014 16:34:37 ******/
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
Declare @InvoiceId Numeric(10,0)
Select @InvoiceId = ID from Invoice.Invoice where InvoiceNumber = @InvoiceNumber

SELECT 
ArtifactId
FROM [Invoice].Artifact
WHERE InvoiceId = @InvoiceId 

END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomReservationId]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadRoomReservationId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[ReadRoomReservationId] ( @ArtifactId Numeric(10,0)
)
AS
BEGIN

Select RoomReservationId
From Lodge.RoomReservationArtifact
Where ArtifactId = @ArtifactId

END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadInvoiceReportForArtifact]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [Invoice].[ReadInvoiceReportForArtifact]
(
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	
	SELECT 
		Id,
		ReportId
	FROM [Invoice].ReportArtifact
	WHERE ArtifactId = @ArtifactId
		AND Category =  @Category
	
END


' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 07/22/2014 16:34:37 ******/
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
	FROM Guardian.ProfileContactNumber
	WHERE Id = @Id   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Invoice].[LineItemTaxationInsert]    Script Date: 07/22/2014 16:34:37 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsReservationDeletable]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsReservationDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[IsReservationDeletable] 
	(	
		@ReservationId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT C.CheckInDate, R.NoOfDays 
		FROM Lodge.CheckIn C
		Inner Join Lodge.RoomReservation R On C.ReservationId = R.Id
		WHERE C.ReservationId = @ReservationId
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkReadForModule]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkReadForModule]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactModuleLinkReadForModule]
(  
	@ModuleId  Numeric(10,0),
	@Category Numeric(1,0)
)
AS
BEGIN
	SELECT Artf.Id, [FileName], [Path], Extension, Style, [Version], ParentId,
		CreatedByUserId, CP.FirstName CreatedByFirstName, CP.MiddleName CreatedByMiddleName, CP.LastName CreatedByLastName, CreatedAt,
		ModifiedByUserId, MP.FirstName ModifiedByFirstName, MP.MiddleName ModifiedByMiddleName, Mp.LastName ModifiedByLastName, ModifiedAt,
		Comp.Id ComponentId, Comp.Code ComponentCode, Comp.Name ComponentName
	FROM Navigator.ArtifactModuleLink AML
	INNER JOIN Navigator.Artifact Artf ON AML.ArtifactId = Artf.Id
	INNER JOIN Guardian.Profile CP ON UserId = CreatedByUserId
	LEFT OUTER JOIN Guardian.Profile MP ON MP.UserId = ModifiedByUserId
	INNER JOIN License.Component Comp ON AML.ModuleId = Comp.Id
	WHERE ModuleId = @ModuleId
		AND Category = @Category
		--AND A.ParentId IS NULL
END' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkReadForArtifact]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkReadForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactModuleLinkReadForArtifact]
(
	@ArtifactId Numeric(10, 0)
)
AS
BEGIN
	SELECT ModuleId, Category
	FROM Navigator.ArtifactModuleLink
	WHERE ArtifactId = @ArtifactId
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkInsertForModule]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkInsertForModule]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactModuleLinkInsertForModule]
(
        @ArtifactId  Numeric(10,0),
        @ModuleId  Numeric(10,0),
        @Category Numeric(1,0)
)
AS
BEGIN
        INSERT INTO Navigator.ArtifactModuleLink([ArtifactId],[ModuleId], [Category])
        VALUES(@ArtifactId, @ModuleId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Navigator].[ArtifactDelete]
(  
 @Id Numeric(10,0)
)
AS
BEGIN 
 
 DELETE   
 FROM [Navigator].ArtifactModuleLink
 WHERE ArtifactId = @Id   
 
 DELETE   
 FROM [Navigator].Artifact
 WHERE ID = @Id    
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingFloorReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[BuildingId],
			[FLOOR]
		FROM [Lodge].BuildingFloor
		WHERE BuildingId = @ParentId   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingFloorRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[FLOOR],			
			[BuildingId]
		FROM [Lodge].BuildingFloor
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 07/22/2014 16:34:37 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 07/22/2014 16:34:37 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonReadForParent]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingClosureReasonReadForParent]
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
		FROM [Lodge].BuildingClosureReason
		WHERE BuildingId = @ParentId   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonRead]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[BuildingClosureReasonRead]
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
		FROM [Lodge].BuildingClosureReason
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonInsert]    Script Date: 07/22/2014 16:34:37 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonDelete]    Script Date: 07/22/2014 16:34:37 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 07/22/2014 16:34:37 ******/
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
	INNER JOIN Navigator.ArtifactModuleLink AS AML ON ArtifactId = A.Id
	INNER JOIN License.Component AS M ON M.Id = AML.ModuleId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[CheckInUpdate]
	(	
		@Id Numeric(10,0),		
		@Advance Money,
		@ReservationId Numeric(10,0),		
		@ActivityDate DateTime,		
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].CheckIn
		SET				
			[CheckInDate] = @ActivityDate,
			[Advance] = @Advance,
			[ReservationId] = @ReservationId,
			[StatusId] = @StatusId
		WHERE Id = @Id
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[CheckInRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN		
	SELECT 
		Id,
		[CheckInDate],
		[Advance],
		[CreatedDate],
		[ReservationId],
		[StatusId],
		[InvoiceNumber]
	FROM [Lodge].CheckIn
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 07/22/2014 16:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'  --"[Lodge].[CheckInInsert]"
CREATE PROCEDURE [Lodge].[CheckInInsert]
	(  
		@Advance Money,
		@ReservationId Numeric(10,0),		
		@ActivityDate DateTime,		
		@StatusId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].CheckIn([CheckInDate],[Advance],[CreatedDate],[ReservationId],[StatusId])
		VALUES(@ActivityDate,@Advance,GETDATE(),@ReservationId,@StatusId)
	   
		SET @Id = @@IDENTITY
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Lodge].[CheckInDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].CheckIn
		WHERE Id = @Id      
	END' 
END
GO
/****** Object:  Table [Customer].[CustomerArtifact]    Script Date: 07/22/2014 16:34:38 ******/
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
 CONSTRAINT [PK_CustomerForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]') AND name = N'IX_CustomerForm')
CREATE NONCLUSTERED INDEX [IX_CustomerForm] ON [Customer].[CustomerArtifact] 
(
	[CustomerId] ASC,
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'Customer', N'TABLE',N'CustomerArtifact', N'COLUMN',N'Category'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Form, 2 = Catalogue, 3 = Report' , @level0type=N'SCHEMA',@level0name=N'Customer', @level1type=N'TABLE',@level1name=N'CustomerArtifact', @level2type=N'COLUMN',@level2name=N'Category'
GO
SET IDENTITY_INSERT [Customer].[CustomerArtifact] ON
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(51 AS Numeric(10, 0)), NULL, CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(52 AS Numeric(10, 0)), NULL, CAST(61 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(53 AS Numeric(10, 0)), NULL, CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(54 AS Numeric(10, 0)), NULL, CAST(63 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(55 AS Numeric(10, 0)), CAST(57 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(56 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(59 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(58 AS Numeric(10, 0)), NULL, CAST(67 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(59 AS Numeric(10, 0)), NULL, CAST(68 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(60 AS Numeric(10, 0)), NULL, CAST(69 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(61 AS Numeric(10, 0)), NULL, CAST(70 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(62 AS Numeric(10, 0)), NULL, CAST(71 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(63 AS Numeric(10, 0)), NULL, CAST(72 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(64 AS Numeric(10, 0)), NULL, CAST(73 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(65 AS Numeric(10, 0)), NULL, CAST(74 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(68 AS Numeric(10, 0)), CAST(62 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(69 AS Numeric(10, 0)), NULL, CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(70 AS Numeric(10, 0)), NULL, CAST(82 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(71 AS Numeric(10, 0)), NULL, CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(73 AS Numeric(10, 0)), NULL, CAST(85 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(74 AS Numeric(10, 0)), NULL, CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(75 AS Numeric(10, 0)), NULL, CAST(93 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(77 AS Numeric(10, 0)), NULL, CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(78 AS Numeric(10, 0)), NULL, CAST(96 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(79 AS Numeric(10, 0)), NULL, CAST(97 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(80 AS Numeric(10, 0)), CAST(63 AS Numeric(10, 0)), CAST(98 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(81 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)), CAST(99 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(82 AS Numeric(10, 0)), NULL, CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(83 AS Numeric(10, 0)), NULL, CAST(101 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(84 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(102 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(85 AS Numeric(10, 0)), CAST(67 AS Numeric(10, 0)), CAST(116 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(86 AS Numeric(10, 0)), CAST(68 AS Numeric(10, 0)), CAST(120 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(87 AS Numeric(10, 0)), CAST(69 AS Numeric(10, 0)), CAST(121 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(88 AS Numeric(10, 0)), NULL, CAST(125 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(89 AS Numeric(10, 0)), NULL, CAST(126 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(90 AS Numeric(10, 0)), NULL, CAST(127 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(91 AS Numeric(10, 0)), NULL, CAST(128 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(92 AS Numeric(10, 0)), NULL, CAST(129 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(93 AS Numeric(10, 0)), NULL, CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(94 AS Numeric(10, 0)), NULL, CAST(137 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(95 AS Numeric(10, 0)), NULL, CAST(138 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(96 AS Numeric(10, 0)), NULL, CAST(139 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(97 AS Numeric(10, 0)), NULL, CAST(140 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(98 AS Numeric(10, 0)), NULL, CAST(141 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(99 AS Numeric(10, 0)), NULL, CAST(143 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(100 AS Numeric(10, 0)), NULL, CAST(144 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(101 AS Numeric(10, 0)), CAST(70 AS Numeric(10, 0)), CAST(145 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(102 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)), CAST(148 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(103 AS Numeric(10, 0)), NULL, CAST(150 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(104 AS Numeric(10, 0)), NULL, CAST(151 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(105 AS Numeric(10, 0)), NULL, CAST(152 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(106 AS Numeric(10, 0)), NULL, CAST(153 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(107 AS Numeric(10, 0)), NULL, CAST(154 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(108 AS Numeric(10, 0)), NULL, CAST(155 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(109 AS Numeric(10, 0)), NULL, CAST(163 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(110 AS Numeric(10, 0)), NULL, CAST(164 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(111 AS Numeric(10, 0)), NULL, CAST(165 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(112 AS Numeric(10, 0)), NULL, CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(113 AS Numeric(10, 0)), NULL, CAST(167 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(114 AS Numeric(10, 0)), NULL, CAST(168 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(115 AS Numeric(10, 0)), NULL, CAST(169 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(116 AS Numeric(10, 0)), NULL, CAST(170 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(117 AS Numeric(10, 0)), CAST(72 AS Numeric(10, 0)), CAST(171 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(118 AS Numeric(10, 0)), NULL, CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(119 AS Numeric(10, 0)), CAST(73 AS Numeric(10, 0)), CAST(193 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(120 AS Numeric(10, 0)), CAST(74 AS Numeric(10, 0)), CAST(194 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(121 AS Numeric(10, 0)), CAST(75 AS Numeric(10, 0)), CAST(199 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(122 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)), CAST(204 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(123 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)), CAST(207 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(124 AS Numeric(10, 0)), NULL, CAST(208 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(125 AS Numeric(10, 0)), NULL, CAST(209 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(126 AS Numeric(10, 0)), NULL, CAST(210 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(127 AS Numeric(10, 0)), NULL, CAST(224 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(128 AS Numeric(10, 0)), NULL, CAST(225 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(129 AS Numeric(10, 0)), NULL, CAST(226 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(130 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), CAST(227 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(131 AS Numeric(10, 0)), NULL, CAST(230 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(132 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), CAST(231 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(133 AS Numeric(10, 0)), NULL, CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(134 AS Numeric(10, 0)), NULL, CAST(234 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(136 AS Numeric(10, 0)), NULL, CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(137 AS Numeric(10, 0)), CAST(87 AS Numeric(10, 0)), CAST(241 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(138 AS Numeric(10, 0)), CAST(88 AS Numeric(10, 0)), CAST(242 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(139 AS Numeric(10, 0)), NULL, CAST(243 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(140 AS Numeric(10, 0)), NULL, CAST(244 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(141 AS Numeric(10, 0)), CAST(89 AS Numeric(10, 0)), CAST(257 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(142 AS Numeric(10, 0)), NULL, CAST(258 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(143 AS Numeric(10, 0)), NULL, CAST(259 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(144 AS Numeric(10, 0)), NULL, CAST(260 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(145 AS Numeric(10, 0)), NULL, CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(146 AS Numeric(10, 0)), NULL, CAST(262 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(147 AS Numeric(10, 0)), NULL, CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(148 AS Numeric(10, 0)), NULL, CAST(280 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(149 AS Numeric(10, 0)), NULL, CAST(281 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(150 AS Numeric(10, 0)), CAST(91 AS Numeric(10, 0)), CAST(282 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(151 AS Numeric(10, 0)), NULL, CAST(283 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(152 AS Numeric(10, 0)), CAST(94 AS Numeric(10, 0)), CAST(284 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(153 AS Numeric(10, 0)), NULL, CAST(285 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(154 AS Numeric(10, 0)), CAST(92 AS Numeric(10, 0)), CAST(286 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(155 AS Numeric(10, 0)), CAST(93 AS Numeric(10, 0)), CAST(287 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
GO
print 'Processed 100 total records'
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(156 AS Numeric(10, 0)), CAST(95 AS Numeric(10, 0)), CAST(288 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(157 AS Numeric(10, 0)), NULL, CAST(289 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(158 AS Numeric(10, 0)), NULL, CAST(290 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(159 AS Numeric(10, 0)), NULL, CAST(291 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(160 AS Numeric(10, 0)), NULL, CAST(292 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(161 AS Numeric(10, 0)), NULL, CAST(293 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(162 AS Numeric(10, 0)), NULL, CAST(294 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(163 AS Numeric(10, 0)), NULL, CAST(295 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(164 AS Numeric(10, 0)), NULL, CAST(296 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(165 AS Numeric(10, 0)), NULL, CAST(297 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(166 AS Numeric(10, 0)), NULL, CAST(298 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(167 AS Numeric(10, 0)), NULL, CAST(299 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(168 AS Numeric(10, 0)), NULL, CAST(300 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(169 AS Numeric(10, 0)), NULL, CAST(301 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(170 AS Numeric(10, 0)), NULL, CAST(302 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(171 AS Numeric(10, 0)), NULL, CAST(303 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(172 AS Numeric(10, 0)), NULL, CAST(304 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(173 AS Numeric(10, 0)), NULL, CAST(305 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(174 AS Numeric(10, 0)), NULL, CAST(306 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(175 AS Numeric(10, 0)), NULL, CAST(307 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(176 AS Numeric(10, 0)), NULL, CAST(308 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(177 AS Numeric(10, 0)), CAST(96 AS Numeric(10, 0)), CAST(309 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(178 AS Numeric(10, 0)), NULL, CAST(310 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(179 AS Numeric(10, 0)), NULL, CAST(311 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(180 AS Numeric(10, 0)), NULL, CAST(312 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(181 AS Numeric(10, 0)), NULL, CAST(313 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(182 AS Numeric(10, 0)), NULL, CAST(314 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(183 AS Numeric(10, 0)), NULL, CAST(315 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(184 AS Numeric(10, 0)), NULL, CAST(316 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(185 AS Numeric(10, 0)), NULL, CAST(317 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(186 AS Numeric(10, 0)), NULL, CAST(318 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(187 AS Numeric(10, 0)), NULL, CAST(319 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(188 AS Numeric(10, 0)), NULL, CAST(320 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(189 AS Numeric(10, 0)), NULL, CAST(321 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(190 AS Numeric(10, 0)), NULL, CAST(322 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(191 AS Numeric(10, 0)), NULL, CAST(323 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(192 AS Numeric(10, 0)), CAST(97 AS Numeric(10, 0)), CAST(324 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(193 AS Numeric(10, 0)), NULL, CAST(325 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(194 AS Numeric(10, 0)), NULL, CAST(326 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(195 AS Numeric(10, 0)), NULL, CAST(327 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(196 AS Numeric(10, 0)), NULL, CAST(328 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(197 AS Numeric(10, 0)), NULL, CAST(329 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(198 AS Numeric(10, 0)), NULL, CAST(330 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(199 AS Numeric(10, 0)), CAST(98 AS Numeric(10, 0)), CAST(331 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(200 AS Numeric(10, 0)), NULL, CAST(332 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(201 AS Numeric(10, 0)), NULL, CAST(333 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(202 AS Numeric(10, 0)), NULL, CAST(334 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(203 AS Numeric(10, 0)), NULL, CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(204 AS Numeric(10, 0)), NULL, CAST(338 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(205 AS Numeric(10, 0)), NULL, CAST(339 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(206 AS Numeric(10, 0)), NULL, CAST(340 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(207 AS Numeric(10, 0)), NULL, CAST(341 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(208 AS Numeric(10, 0)), NULL, CAST(342 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(209 AS Numeric(10, 0)), NULL, CAST(343 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(210 AS Numeric(10, 0)), NULL, CAST(344 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(211 AS Numeric(10, 0)), NULL, CAST(345 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(212 AS Numeric(10, 0)), CAST(99 AS Numeric(10, 0)), CAST(346 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(213 AS Numeric(10, 0)), NULL, CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(214 AS Numeric(10, 0)), NULL, CAST(348 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(215 AS Numeric(10, 0)), CAST(100 AS Numeric(10, 0)), CAST(349 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(216 AS Numeric(10, 0)), CAST(101 AS Numeric(10, 0)), CAST(350 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(217 AS Numeric(10, 0)), CAST(102 AS Numeric(10, 0)), CAST(351 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(218 AS Numeric(10, 0)), NULL, CAST(352 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(219 AS Numeric(10, 0)), CAST(103 AS Numeric(10, 0)), CAST(353 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(220 AS Numeric(10, 0)), CAST(104 AS Numeric(10, 0)), CAST(354 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(221 AS Numeric(10, 0)), CAST(105 AS Numeric(10, 0)), CAST(355 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(222 AS Numeric(10, 0)), CAST(106 AS Numeric(10, 0)), CAST(356 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(223 AS Numeric(10, 0)), NULL, CAST(357 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(224 AS Numeric(10, 0)), CAST(107 AS Numeric(10, 0)), CAST(358 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(225 AS Numeric(10, 0)), CAST(108 AS Numeric(10, 0)), CAST(359 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(226 AS Numeric(10, 0)), CAST(109 AS Numeric(10, 0)), CAST(367 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(227 AS Numeric(10, 0)), NULL, CAST(379 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(228 AS Numeric(10, 0)), NULL, CAST(396 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(229 AS Numeric(10, 0)), CAST(110 AS Numeric(10, 0)), CAST(397 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(231 AS Numeric(10, 0)), CAST(112 AS Numeric(10, 0)), CAST(402 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(232 AS Numeric(10, 0)), CAST(113 AS Numeric(10, 0)), CAST(403 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(233 AS Numeric(10, 0)), NULL, CAST(404 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(234 AS Numeric(10, 0)), NULL, CAST(422 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(235 AS Numeric(10, 0)), NULL, CAST(423 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(236 AS Numeric(10, 0)), CAST(114 AS Numeric(10, 0)), CAST(424 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(237 AS Numeric(10, 0)), NULL, CAST(425 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Customer].[CustomerArtifact] ([Id], [CustomerId], [ArtifactId], [Category]) VALUES (CAST(238 AS Numeric(10, 0)), CAST(115 AS Numeric(10, 0)), CAST(426 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Customer].[CustomerArtifact] OFF
/****** Object:  Table [Lodge].[CheckInArtifact]    Script Date: 07/22/2014 16:34:38 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [Lodge].[CheckInArtifact] ON
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(1 AS Numeric(10, 0)), NULL, CAST(122 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(3 AS Numeric(10, 0)), NULL, CAST(142 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), CAST(147 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(5 AS Numeric(10, 0)), CAST(12 AS Numeric(10, 0)), CAST(157 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(6 AS Numeric(10, 0)), NULL, CAST(172 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(7 AS Numeric(10, 0)), NULL, CAST(173 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(8 AS Numeric(10, 0)), NULL, CAST(174 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(9 AS Numeric(10, 0)), NULL, CAST(198 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(14 AS Numeric(10, 0)), CAST(201 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(11 AS Numeric(10, 0)), NULL, CAST(203 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(15 AS Numeric(10, 0)), CAST(206 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(13 AS Numeric(10, 0)), NULL, CAST(238 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(14 AS Numeric(10, 0)), CAST(18 AS Numeric(10, 0)), CAST(254 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(15 AS Numeric(10, 0)), NULL, CAST(264 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(16 AS Numeric(10, 0)), NULL, CAST(265 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(17 AS Numeric(10, 0)), NULL, CAST(266 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(18 AS Numeric(10, 0)), NULL, CAST(267 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(19 AS Numeric(10, 0)), CAST(19 AS Numeric(10, 0)), CAST(268 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(20 AS Numeric(10, 0)), CAST(20 AS Numeric(10, 0)), CAST(271 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(21 AS Numeric(10, 0)), NULL, CAST(274 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(21 AS Numeric(10, 0)), CAST(275 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(23 AS Numeric(10, 0)), NULL, CAST(368 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(22 AS Numeric(10, 0)), CAST(369 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(25 AS Numeric(10, 0)), CAST(23 AS Numeric(10, 0)), CAST(373 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(26 AS Numeric(10, 0)), CAST(24 AS Numeric(10, 0)), CAST(376 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(27 AS Numeric(10, 0)), CAST(25 AS Numeric(10, 0)), CAST(378 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(28 AS Numeric(10, 0)), CAST(26 AS Numeric(10, 0)), CAST(382 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(29 AS Numeric(10, 0)), NULL, CAST(386 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(30 AS Numeric(10, 0)), CAST(27 AS Numeric(10, 0)), CAST(387 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(31 AS Numeric(10, 0)), NULL, CAST(429 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(32 AS Numeric(10, 0)), NULL, CAST(430 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Lodge].[CheckInArtifact] OFF
/****** Object:  Table [Customer].[CustomerContactNumber]    Script Date: 07/22/2014 16:34:38 ******/
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
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(173 AS Numeric(10, 0)), N'08041128956', CAST(40 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(174 AS Numeric(10, 0)), N'9875469857', CAST(40 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(175 AS Numeric(10, 0)), N'08041128956', CAST(41 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(176 AS Numeric(10, 0)), N'9875469857', CAST(41 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(177 AS Numeric(10, 0)), N'08041128956', CAST(42 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(178 AS Numeric(10, 0)), N'9875469857', CAST(42 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(179 AS Numeric(10, 0)), N'08041128956', CAST(43 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(180 AS Numeric(10, 0)), N'9875469857', CAST(43 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(185 AS Numeric(10, 0)), N'08041128956', CAST(44 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(186 AS Numeric(10, 0)), N'9875469857', CAST(44 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(193 AS Numeric(10, 0)), N'08041128956', CAST(30 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(194 AS Numeric(10, 0)), N'9875469857', CAST(30 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(225 AS Numeric(10, 0)), N'41128956', CAST(45 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(226 AS Numeric(10, 0)), N'9740650689', CAST(45 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(255 AS Numeric(10, 0)), N'+91-33-24328896', CAST(62 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(256 AS Numeric(10, 0)), N'+91-9887409876', CAST(62 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(259 AS Numeric(10, 0)), N'+91-33-34234565', CAST(63 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(260 AS Numeric(10, 0)), N'+91-6756453498', CAST(63 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(265 AS Numeric(10, 0)), N'+91-7865434587', CAST(64 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(266 AS Numeric(10, 0)), N'+91-99-76540987', CAST(64 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(307 AS Numeric(10, 0)), N'+91-99-87963465', CAST(57 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(308 AS Numeric(10, 0)), N'+91-9234587654', CAST(57 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(313 AS Numeric(10, 0)), N'+91-44-24328896', CAST(67 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(314 AS Numeric(10, 0)), N'+91-9833078746', CAST(67 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(317 AS Numeric(10, 0)), N'+91-8765983465', CAST(66 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(318 AS Numeric(10, 0)), N'+91-12-09563852', CAST(66 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(331 AS Numeric(10, 0)), N'+91-11-78561234', CAST(68 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(332 AS Numeric(10, 0)), N'+91-9845754322', CAST(68 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(347 AS Numeric(10, 0)), N'+91-22-22222222', CAST(65 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(348 AS Numeric(10, 0)), N'+91-5555676798', CAST(65 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(351 AS Numeric(10, 0)), N'+91-9878654543', CAST(72 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(352 AS Numeric(10, 0)), N'+91-9845653454', CAST(72 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(353 AS Numeric(10, 0)), N'+91-9886478746', CAST(6 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(354 AS Numeric(10, 0)), N'+91-33-24329896', CAST(6 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(355 AS Numeric(10, 0)), N'+91-76-76876587', CAST(73 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(356 AS Numeric(10, 0)), N'+91-9867565432', CAST(73 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(393 AS Numeric(10, 0)), N'+91-33-54328790', CAST(75 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(394 AS Numeric(10, 0)), N'+91-9867543454', CAST(75 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(421 AS Numeric(10, 0)), N'+91-343-34326787', CAST(70 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(422 AS Numeric(10, 0)), N'+91-5432098745', CAST(70 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(483 AS Numeric(10, 0)), N'+91-345-90876787', CAST(77 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(484 AS Numeric(10, 0)), N'+91-9867854234', CAST(77 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(681 AS Numeric(10, 0)), N'+91-345-54654567', CAST(89 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(682 AS Numeric(10, 0)), N'+91-8967230978', CAST(89 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(697 AS Numeric(10, 0)), N'+91-33-67874543', CAST(79 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(698 AS Numeric(10, 0)), N'+91-9876897656', CAST(79 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(709 AS Numeric(10, 0)), N'+91-344-47650978', CAST(80 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(710 AS Numeric(10, 0)), N'+91-9450978659', CAST(80 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(713 AS Numeric(10, 0)), N'+91-98-98765676', CAST(74 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(714 AS Numeric(10, 0)), N'+91-9878653456', CAST(74 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(717 AS Numeric(10, 0)), N'+91-33-45653234', CAST(78 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(718 AS Numeric(10, 0)), N'+91-9867543234', CAST(78 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(727 AS Numeric(10, 0)), N'+91-33-34094567', CAST(91 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(728 AS Numeric(10, 0)), N'+91-7898709567', CAST(91 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(735 AS Numeric(10, 0)), N'+91-33-24350978', CAST(95 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(736 AS Numeric(10, 0)), N'+91-7890452309', CAST(95 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(737 AS Numeric(10, 0)), N'+91-33-35343434', CAST(92 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(738 AS Numeric(10, 0)), N'+91-7867345202', CAST(92 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(739 AS Numeric(10, 0)), N'+91-33-456670987', CAST(93 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(740 AS Numeric(10, 0)), N'+91-4534097856', CAST(93 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(741 AS Numeric(10, 0)), N'+91-345-67894564', CAST(94 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(742 AS Numeric(10, 0)), N'+91-8909786756', CAST(94 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(745 AS Numeric(10, 0)), N'+91-33-29870978', CAST(96 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(746 AS Numeric(10, 0)), N'+91-9457602343', CAST(96 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(759 AS Numeric(10, 0)), N'+91-32-92827262', CAST(97 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(760 AS Numeric(10, 0)), N'+91-9282726353', CAST(97 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(775 AS Numeric(10, 0)), N'+91-33-92726242', CAST(99 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(776 AS Numeric(10, 0)), N'+91-7809564309', CAST(99 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(777 AS Numeric(10, 0)), N'+91-354-56741098', CAST(100 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(778 AS Numeric(10, 0)), N'+91-7089653419', CAST(100 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(779 AS Numeric(10, 0)), N'+91-342-82726252', CAST(101 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(780 AS Numeric(10, 0)), N'+91-9282726252', CAST(101 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(783 AS Numeric(10, 0)), N'+91-323-97652345', CAST(102 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(784 AS Numeric(10, 0)), N'+91-8723095634', CAST(102 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(785 AS Numeric(10, 0)), N'+91-309-65786767', CAST(103 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(786 AS Numeric(10, 0)), N'+91-5645398767', CAST(103 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(787 AS Numeric(10, 0)), N'+91-453-87345432', CAST(104 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(788 AS Numeric(10, 0)), N'+91-9453098745', CAST(104 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(793 AS Numeric(10, 0)), N'+91-88-67654567', CAST(105 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(794 AS Numeric(10, 0)), N'+91-8966239087', CAST(105 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(795 AS Numeric(10, 0)), N'+91-897-87654309', CAST(106 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(796 AS Numeric(10, 0)), N'+91-6784560985', CAST(106 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(797 AS Numeric(10, 0)), N'+91-309-98674532', CAST(107 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(798 AS Numeric(10, 0)), N'+91-8765098734', CAST(107 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(805 AS Numeric(10, 0)), N'+91-88-98653456', CAST(108 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(806 AS Numeric(10, 0)), N'+91-9845340967', CAST(108 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(819 AS Numeric(10, 0)), N'+91-88-78905645', CAST(109 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(820 AS Numeric(10, 0)), N'+91-6543098767', CAST(109 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(823 AS Numeric(10, 0)), N'+91-8978676543', CAST(71 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(824 AS Numeric(10, 0)), N'+91-33-25349867', CAST(71 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(829 AS Numeric(10, 0)), N'+91-345-90785645', CAST(88 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(830 AS Numeric(10, 0)), N'+91-9867452056', CAST(88 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(837 AS Numeric(10, 0)), N'+91-87-76340978', CAST(110 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(838 AS Numeric(10, 0)), N'+91-9087567687', CAST(110 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(841 AS Numeric(10, 0)), N'+91-80-98786545', CAST(76 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(842 AS Numeric(10, 0)), N'+91-8767098789', CAST(76 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(843 AS Numeric(10, 0)), N'+91-23-12346543', CAST(69 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(844 AS Numeric(10, 0)), N'+91-8976509786', CAST(69 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(845 AS Numeric(10, 0)), N'+91-33-34095634', CAST(98 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(846 AS Numeric(10, 0)), N'+91-9845230978', CAST(98 AS Numeric(10, 0)))
GO
print 'Processed 100 total records'
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(850 AS Numeric(10, 0)), N'+91-33-98743098', CAST(112 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(852 AS Numeric(10, 0)), N'+91-99-99967675', CAST(113 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(859 AS Numeric(10, 0)), N'+91-55-76340978', CAST(59 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(860 AS Numeric(10, 0)), N'+91-7645230978', CAST(59 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(861 AS Numeric(10, 0)), N'+91-80-34562345', CAST(87 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(862 AS Numeric(10, 0)), N'+91-7654098756', CAST(87 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(863 AS Numeric(10, 0)), N'+91-88-78654367', CAST(58 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(864 AS Numeric(10, 0)), N'+91-8745630987', CAST(58 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(867 AS Numeric(10, 0)), N'+91-33-43256787', CAST(114 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(868 AS Numeric(10, 0)), N'+91-9867567987', CAST(114 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(873 AS Numeric(10, 0)), N'+91-33-54320987', CAST(115 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(874 AS Numeric(10, 0)), N'+91-5645342309', CAST(115 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Customer].[CustomerContactNumber] OFF
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerReadAll]
	As
	Begin
		Select Id,
		--InitialId,
		FirstName,MiddleName,LastName,
			[Address],CountryId,StateId,City,Pin,Email,IdentityProofId,
			IdentityProofName 
		From Customer.Customer
	End
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 07/22/2014 16:34:38 ******/
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
	 Begin
		Select  Id,
			--InitialId,
			FirstName,MiddleName,LastName,
				[Address],CountryId,StateId,City,Pin,Email,IdentityProofId,
				IdentityProofName 
		From Customer.Customer
		Where Id = @Id
	 End
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Customer].[CustomerDelete]
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
/****** Object:  Table [AutoTourism].[CustomerRoomCheckInLink]    Script Date: 07/22/2014 16:34:38 ******/
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
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(40 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(41 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(3 AS Numeric(10, 0)), CAST(42 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(43 AS Numeric(10, 0)), CAST(5 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(5 AS Numeric(10, 0)), CAST(44 AS Numeric(10, 0)), CAST(5 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(6 AS Numeric(10, 0)), CAST(70 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(12 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(8 AS Numeric(10, 0)), CAST(59 AS Numeric(10, 0)), CAST(13 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(9 AS Numeric(10, 0)), CAST(75 AS Numeric(10, 0)), CAST(14 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)), CAST(15 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(13 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)), CAST(18 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomCheckInLink] ([Id], [CustomerId], [RoomCheckInId]) VALUES (CAST(14 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)), CAST(27 AS Numeric(10, 0)))
SET IDENTITY_INSERT [AutoTourism].[CustomerRoomCheckInLink] OFF
/****** Object:  StoredProcedure [Customer].[CustomerReportArtifactInsertLink]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  Table [AutoTourism].[CustomerRoomReservationLink]    Script Date: 07/22/2014 16:34:38 ******/
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
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(8 AS Numeric(10, 0)), CAST(30 AS Numeric(10, 0)), CAST(48 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(40 AS Numeric(10, 0)), CAST(51 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(11 AS Numeric(10, 0)), CAST(41 AS Numeric(10, 0)), CAST(52 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(42 AS Numeric(10, 0)), CAST(53 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(13 AS Numeric(10, 0)), CAST(43 AS Numeric(10, 0)), CAST(54 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(14 AS Numeric(10, 0)), CAST(44 AS Numeric(10, 0)), CAST(55 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(15 AS Numeric(10, 0)), CAST(44 AS Numeric(10, 0)), CAST(56 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(16 AS Numeric(10, 0)), CAST(44 AS Numeric(10, 0)), CAST(57 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(17 AS Numeric(10, 0)), CAST(30 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(18 AS Numeric(10, 0)), CAST(45 AS Numeric(10, 0)), CAST(59 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(63 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(57 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(26 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(67 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(28 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)), CAST(68 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(29 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(69 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(30 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)), CAST(70 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(31 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(33 AS Numeric(10, 0)), CAST(68 AS Numeric(10, 0)), CAST(73 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(34 AS Numeric(10, 0)), CAST(68 AS Numeric(10, 0)), CAST(74 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(37 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(40 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(41 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(52 AS Numeric(10, 0)), CAST(74 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(54 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(61 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(55 AS Numeric(10, 0)), CAST(70 AS Numeric(10, 0)), CAST(75 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(56 AS Numeric(10, 0)), CAST(59 AS Numeric(10, 0)), CAST(62 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(58 AS Numeric(10, 0)), CAST(75 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(76 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)), CAST(108 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(80 AS Numeric(10, 0)), CAST(79 AS Numeric(10, 0)), CAST(112 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(97 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), CAST(114 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(98 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)), CAST(113 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(134 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)), CAST(119 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(135 AS Numeric(10, 0)), CAST(74 AS Numeric(10, 0)), CAST(118 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(136 AS Numeric(10, 0)), CAST(78 AS Numeric(10, 0)), CAST(120 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(137 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(121 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(138 AS Numeric(10, 0)), CAST(59 AS Numeric(10, 0)), CAST(122 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(139 AS Numeric(10, 0)), CAST(108 AS Numeric(10, 0)), CAST(123 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(140 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)), CAST(124 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(141 AS Numeric(10, 0)), CAST(109 AS Numeric(10, 0)), CAST(125 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(142 AS Numeric(10, 0)), CAST(109 AS Numeric(10, 0)), CAST(126 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(144 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)), CAST(127 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(145 AS Numeric(10, 0)), CAST(110 AS Numeric(10, 0)), CAST(128 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(146 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(131 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(148 AS Numeric(10, 0)), CAST(59 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(149 AS Numeric(10, 0)), CAST(87 AS Numeric(10, 0)), CAST(133 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(150 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(72 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(151 AS Numeric(10, 0)), CAST(115 AS Numeric(10, 0)), CAST(134 AS Numeric(10, 0)))
SET IDENTITY_INSERT [AutoTourism].[CustomerRoomReservationLink] OFF
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactUpdateLink]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactReadLink]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[InvoiceArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, InvoiceId ComponentId
	FROM Invoice.Artifact
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactInsertLink]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceArtifactDeleteLink]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceReportForArtifact]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InsertInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [Invoice].[InsertInvoiceReportForArtifact]
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
/****** Object:  StoredProcedure [Customer].[DeleteCustomerReportForArtifact]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[DeleteCustomerReportForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [Customer].[DeleteCustomerReportForArtifact]
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
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[GetCustomerIdForReservation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [AutoTourism].[GetCustomerIdForReservation]
	(  
		@ReservationId  Numeric(10,0)
	)
	AS
	BEGIN	
		
		Select CustomerId From AutoTourism.CustomerRoomReservationLink
		Where RoomReservationId = @ReservationId
	END' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 07/22/2014 16:34:38 ******/
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
	 As
	 Begin
		Select  [CustomerId],[RoomReservationId]
		From [AutoTourism].[CustomerRoomReservationLink]
		Where CustomerId = @CustomerId
	 End' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 07/22/2014 16:34:38 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [AutoTourism].[CustomerRoomReservationLinkDelete]
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkRead]
	 (
		@CustomerId Numeric(10,0)
	 )
	 As
	 Begin
		Select  [CustomerId],[RoomCheckInId]
		From [AutoTourism].[CustomerRoomCheckInLink]
		Where CustomerId = @CustomerId
	 End' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkInsert]
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
	END' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 07/22/2014 16:34:38 ******/
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
		FROM Customer.Customer 
			WHERE (IdentityProofId = @IdentityProofId	
			AND IdentityProofName = @IdentityProofName)
			OR (Email = @Email AND @Email != '''')
			OR ID IN (SELECT CustomerId FROM CustomerContactNumber 
				WHERE Number IN (SELECT SplitText FROM Split(@ContactNumber, '','')))
	END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 07/22/2014 16:34:38 ******/
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
	As
	Begin
		Select Id,Number,CustomerId From Customer.CustomerContactNumber
		Where CustomerId = @Id
	End
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 07/22/2014 16:34:38 ******/
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
	
		DELETE 		
		FROM Customer.CustomerContactNumber
		WHERE CustomerId = @Id   
	END
	
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactUpdateLink]    Script Date: 07/22/2014 16:34:38 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactReadLink]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--DROP PROCEDURE [Customer].[ReadFormForArtifact]
--GO
CREATE PROCEDURE [Customer].[CustomerArtifactReadLink]
(
	@ArtifactId Numeric(10,0)--,
	--@Category Numeric(1)
)
AS
BEGIN
	
	SELECT Id, CustomerId ComponentId
	FROM Customer.CustomerArtifact
	WHERE ArtifactId = @ArtifactId
		--AND Category =  @Category
	
END

--Customer.ReadFormForArtifact 1
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactInsertLink]    Script Date: 07/22/2014 16:34:38 ******/
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
 
END' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactDeleteLink]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactUpdateLink]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactReadLink]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--DROP PROCEDURE [Lodge].[ReadCheckInFormForArtifact]
--GO
CREATE PROCEDURE [Lodge].[CheckInArtifactReadLink]
(
	@ArtifactId Numeric(10,0)--,
	--@Category Numeric(1)
)
AS
BEGIN
	
	SELECT Id, CheckInId ComponentId
	FROM Lodge.CheckInArtifact
	WHERE ArtifactId = @ArtifactId
		--AND Category =  @Category
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactInsertLink]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactDeleteLink]    Script Date: 07/22/2014 16:34:38 ******/
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
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Customer].[IsStateIdDeletable]
(
	@StateId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer
	WHERE StateId = @StateId

 END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomTypeDeletable]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomTypeDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE Procedure [Lodge].[IsRoomTypeDeletable]
(
	@TypeId NUMERIC(10,0)
)
As
Begin
	select Name,Number from [lodge].Room
	where TypeId = @TypeId
End



' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomStatusDeletable]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomStatusDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

Create PROCEDURE [Lodge].[IsRoomStatusDeletable] 
(
	@RoomStatusId NUMERIC(10,0)
)
AS
BEGIN
	Select Name,Number 
	from [lodge].Room
	Where StatusId = @RoomStatusId

 END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomCategoryDeletable]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomCategoryDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[IsRoomCategoryDeletable]
		(
			@RoomCategoryId NUMERIC(10,0)
		)
	AS
	BEGIN
		Select Name,Number
		from [lodge].Room
		Where CategoryId = @RoomCategoryId

	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomBuildingDeletable]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomBuildingDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[IsRoomBuildingDeletable]
		(
			@BuildingId NUMERIC(10,0)
		)
	AS
	BEGIN
		Select Name,Number
		from [lodge].Room
		Where BuildingId = @BuildingId

	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingFloorDeletable]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingFloorDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Lodge].[IsBuildingFloorDeletable] 
(
	@FloorId NUMERIC(10,0)
)
AS
BEGIN
	Select Name,Number
	from [lodge].Room
	Where FloorId = @FloorId

 END' 
END
GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsInitialDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Customer].[IsInitialDeletable]
(
	@InitialId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer
	WHERE InitialId = @InitialId

 END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 07/22/2014 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsIdentityProofIdDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Customer].[IsIdentityProofIdDeletable]
(
	@IdentityProofId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer
	WHERE IdentityProofId = @IdentityProofId

 END
' 
END
GO
/****** Object:  Table [Lodge].[RoomClosureReason]    Script Date: 07/22/2014 16:34:39 ******/
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
/****** Object:  StoredProcedure [Customer].[ReportCustomer]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportCustomer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


--[Customer].[ReportCustomer] ''01-01-2013'',''05-01-2014''


CREATE Procedure [Customer].[ReportCustomer]
(
	@StartDate DateTime,
	@EndDate DateTime
)
As
Begin
	
	Declare @Customer Table
	(
		Id Int IDENTITY(1,1),
		CustomerId Numeric(10,0),
		ContactNo Varchar(150)
	)
	
	Declare @CustomerCheckIn Table
	(
		--Id Int IDENTITY(1,1),
		CustomerId Numeric(10,0),
		CheckInDate DateTime,
		RoomCheckInId Numeric(10,0),
		ReservationId Numeric(10,0),
		CheckInStatusId Numeric(10,0),		
		InvoiceNumber Varchar(50),
		BookingFrom DateTime,
		NoOfDays Int,
		NoOfPersons Int,
		NoOfRooms Int,
		Description Varchar(150),
		RoomCategoryId Numeric(10,0),
		RoomTypeId Numeric(10,0),
		Advance Money,			
		ContactNo Varchar(150)
	)
	
	Insert into @CustomerCheckIn(CustomerId,CheckInDate,RoomCheckInId,ReservationId,CheckInStatusId,InvoiceNumber,Advance)
	Select A.CustomerId,C.CheckInDate,A.RoomCheckInId,C.ReservationId, 
	C.StatusId ,C.InvoiceNumber, C.Advance
	from [Lodge].checkin C 	
	inner join [AutoTourism].CustomerRoomCheckInLink A on C.Id = A.RoomCheckInId
	Where DATEADD(dd, DATEDIFF(dd, 0, [CheckInDate]), 0) -- removing time part from CreatedDate
	between DATEADD(dd, DATEDIFF(dd, 0, @StartDate ), 0)
	And DATEADD(dd, DATEDIFF(dd, 0, @EndDate ), 0)
	
	Update C
	Set C.BookingFrom = R.BookingFrom,
		C.NoOfDays = R.NoOfDays,
		C.NoOfPersons = R.NoOfPersons,
		C.NoOfRooms = R.NoOfRooms,
		C.Description = R.Description,
		C.RoomCategoryId = R.RoomCategoryId,
		C.RoomTypeId = R.RoomTypeId
		
	From @CustomerCheckIn C Inner Join [Lodge].RoomReservation R
	on C.ReservationId = R.Id
	
	Insert into @Customer(CustomerId)
	Select Distinct(CustomerId) from @CustomerCheckIn
	
	Declare @Min Int
	Declare @Max Int
	Declare @CustomerId Numeric(10,0)
	DECLARE @listStr VARCHAR(MAX)
	
	select @Min = Min(Id), @Max = Max(Id) from @Customer
	
	While (@Min < @Max + 1)
	Begin
		Set @listStr = ''''
		Select @CustomerId = CustomerId From @Customer Where Id = @Min			

		SELECT @listStr = COALESCE(@listStr+'', '' ,'''') + Number
		FROM Customer.CustomerContactNumber
		WHERE CustomerId = @CustomerId
	
		Update @Customer
		Set ContactNo = SUBSTRING(@listStr,2,len(@listStr)-1) 
		Where Id = @Min
		
		Set @Min = @Min + 1
	End
	
	Update C
	Set C.ContactNo = Cus.ContactNo
	From @CustomerCheckIn C Inner Join @Customer Cus
	on C.CustomerId = Cus.CustomerId
	
	select 
		C.CustomerId, 
		C.CheckInDate,
		C.RoomCheckInId,
		C.ReservationId,
		C.CheckInStatusId,		
		C.InvoiceNumber,
		C.BookingFrom,
		C.NoOfDays,
		C.NoOfPersons,
		C.NoOfRooms,
		C.Description,
		C.RoomCategoryId,
		C.RoomTypeId,
		C.Advance,			
		C.ContactNo,
		--(select Name from Configuration.Initial where Id = Cus.InitialId) As InitialName,
		Cus.FirstName, 
		Cus.MiddleName,
		Cus.LastName, 
		Cus.Address, 
		(select Name from Configuration.State where Id = Cus.StateId) As StateName,
		Cus.City, 
		Cus.Pin,
		Cus.Email, 
		(select Name from Configuration.IdentityProofType where Id = Cus.IdentityProofId) As IdentityProofType,
		Cus.IdentityProofName
	From @CustomerCheckIn C  Inner Join [Customer].Customer Cus
	On Cus.Id = C.CustomerId
	
End

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadOpenRoom]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[RoomReadOpenRoom] 
(
	@BuildingId numeric(10,0)
)
As
Begin
	Select id,Number,Name,StatusId from 
	[Lodge].Room 
	where BuildingId = @BuildingId
	And StatusId != 10002 -- Closed Room
End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadCheckedInRoom]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
  
CREATE PROCEDURE [Lodge].[RoomReadCheckedInRoom]
(
	@BuildingId numeric(10,0)
)
As
Begin
	SELECT Number,Name FROM [Lodge].[Room] 
	WHERE BuildingId = @BuildingId
	And StatusId = 10003 -- Occupied Room
End

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 07/22/2014 16:34:39 ******/
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
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].Room
		SET	
			[Number] = @Number,
			[Name] = @Name,
			[Description] = @Description,
			[CategoryId] = @CategoryId,
			[TypeId] = @TypeId,
			[BuildingId] = @BuildingId,
			[FloorId] = @FloorId,
			[IsAirConditioned] = @IsAirConditioned			
		WHERE Id = @Id
	   
	END
	

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 07/22/2014 16:34:39 ******/
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
	   
	END' 
END
GO
/****** Object:  Table [Lodge].[RoomReservationDetails]    Script Date: 07/22/2014 16:34:39 ******/
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
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(63 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(8 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(9 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(13 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(67 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(18 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(20 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(61 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(62 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(80 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(3 AS Numeric(10, 0)), CAST(81 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(28 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(118 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(29 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), CAST(120 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(30 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(121 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(31 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), CAST(123 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(32 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), CAST(124 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(33 AS Numeric(10, 0)), CAST(5 AS Numeric(10, 0)), CAST(125 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(34 AS Numeric(10, 0)), CAST(5 AS Numeric(10, 0)), CAST(125 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(35 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(126 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(36 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(127 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(37 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(127 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(38 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(132 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(39 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(72 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Lodge].[RoomReservationDetails] OFF
/****** Object:  Table [Lodge].[RoomImage]    Script Date: 07/22/2014 16:34:39 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 07/22/2014 16:34:39 ******/
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
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReadAll]
	As
	Begin
		SELECT 
			Id,
			[Number],
			[Name],
			[Description],
			[CategoryId],
			[TypeId],
			[BuildingId],
			[FloorId],
			[IsAirConditioned],
			[StatusId]
		FROM [Lodge].Room
	End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 07/22/2014 16:34:39 ******/
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
		
		SELECT 
			Id,
			[Number],
			[Name],
			[Description],
			[CategoryId],
			[TypeId],
			[BuildingId],
			[FloorId],
			[IsAirConditioned],
			[StatusId]
		FROM [Lodge].Room
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 07/22/2014 16:34:39 ******/
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
	   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 07/22/2014 16:34:39 ******/
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
		@StatusId Numeric(10,0),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].Room([Number],[Name],[Description],[CategoryId],
		[TypeId],[BuildingId],[FloorId],[IsAirConditioned],[StatusId])
		VALUES(@Number,@Name,@Description,@CategoryId,@TypeId,@BuildingId,@FloorId,
		@IsAirConditioned,@StatusId)
	   
		SET @Id = @@IDENTITY
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE Procedure [Lodge].[RoomReservationSearch] 
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
		FROM [Lodge].RoomReservation R
		LEFT OUTER JOIN Lodge.RoomReservationDetails RRD ON R.Id = RRD.ReservationId
		Where R.statusId = @StatusId
		And cast(convert(Char(11), R.BookingFrom, 113) AS DateTime) 
		Between cast(convert(Char(11), @StartDate, 113) AS DateTime) 		 
		And cast(convert(Char(11), @EndDate, 113) AS DateTime)		
		--And R.IsCheckedIn = 0
		order by R.Id, RRD.ReservationId
	End' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsRead]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[RoomReservationDetailsRead]
(
   @ReservationId Numeric(10,0)
)
AS
BEGIN
	
   Select 
		Id,
		RoomId,
		ReservationId
   From [Lodge].RoomReservationDetails
   Where ReservationId = @ReservationId   
   
END

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
Create PROCEDURE [Lodge].[RoomReservationDetailsInsert]
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

Create PROCEDURE  [Lodge].[RoomReservationDetailsDelete]
	(
		@ReservationId  Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].[RoomReservationDetails]
		WHERE ReservationId = @ReservationId      
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 07/22/2014 16:34:39 ******/
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
		FROM [Lodge].RoomImage
		WHERE RoomId = @ParentId   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 07/22/2014 16:34:39 ******/
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
		FROM [Lodge].RoomImage
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 07/22/2014 16:34:39 ******/
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
		FROM [Lodge].RoomClosureReason
		WHERE RoomId = @ParentId   
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 07/22/2014 16:34:39 ******/
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
		FROM [Lodge].RoomClosureReason
		WHERE Id = @Id   
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 07/22/2014 16:34:39 ******/
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
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadBookedRoom]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Lodge].[RoomReadBookedRoom]
(
      @BuildingId Numeric(10,0),
      @RoomCategoryId Numeric(10,0),
      @RoomTypeId Numeric(10,0),
      @IsAc Bit
)
AS
BEGIN

      DECLARE @CurrentDate Date = GETDATE();      

      SELECT Id, Name, Number
      FROM Lodge.Room

      WHERE BuildingId = @BuildingId
            AND StatusId != 10002 --Closed Room
            AND Id IN (
                  SELECT RRD.RoomId  
                  FROM Lodge.RoomReservationDetails RRD
                        INNER JOIN (SELECT * FROM Lodge.RoomReservation
                              WHERE RoomCategoryId = ISNULL(@RoomCategoryId,RoomCategoryId)
                              AND RoomTypeId = IsNull(@RoomTypeId,RoomTypeId)
                              AND IsAcRoom = @IsAc) RR 
                              ON  RR.Id = RRD.ReservationId
                        INNER JOIN  [AutoTourism].CustomerRoomReservationLink CRRL ON CRRL.RoomReservationId = RR.Id

                  WHERE RR.StatusId = 10001 --Open room 
                  AND(DATEADD(DAY, -1, RR.BookingFrom) > @CurrentDate
                  OR DATEADD(DAY, RR.NoOfDays, RR.BookingFrom) > @CurrentDate))     

END

 

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadAllCheckInRooms]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


Create Procedure [Lodge].[ReadAllCheckInRooms]
As
Begin
	select distinct(RoomId) from Lodge.RoomReservationDetails 
	where ReservationId In
		(
		select Distinct(C.ReservationId)
		from Lodge.CheckIn C inner join Lodge.RoomReservation R
		on C.ReservationId = R.Id
		where C.StatusId = 10001
		And R.IsCheckedIn = 1
		)

End
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[IsCheckInDeletable]    Script Date: 07/22/2014 16:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsCheckInDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[IsCheckInDeletable]
(
	@RoomId NUMERIC(10,0)
)
AS
BEGIN
	Select 
			C.CheckInDate,
			C.Advance,
			C.CreatedDate,
			C.StatusId As ''CheckInStatusId'',
			R.Advance As ''Reservation Advance'',
			R.BookingFrom,
			R.NoOfDays,
			R.NoOfPersons,
			R.NoOfRooms,
			R.Description,
			R.CreatedDate As ''Reservation Date'',
			R.StatusId As ''ReservationStatusId''
	 from [lodge].CheckIn C Inner Join [lodge].RoomReservation R
	 on C.ReservationId = R.Id
	 Where ReservationId In (
		 Select ReservationId From [lodge].RoomReservationDetails
		 Where RoomId = @RoomId	 )

 END' 
END
GO
/****** Object:  ForeignKey [FK_UserRole_Account]    Script Date: 07/22/2014 16:34:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] CHECK CONSTRAINT [FK_UserRole_Account]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 07/22/2014 16:34:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [Guardian].[Role] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_State_Country]    Script Date: 07/22/2014 16:34:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Configuration].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[Configuration].[State]'))
ALTER TABLE [Configuration].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [Configuration].[Country] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Configuration].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[Configuration].[State]'))
ALTER TABLE [Configuration].[State] CHECK CONSTRAINT [FK_State_Country]
GO
/****** Object:  ForeignKey [FK_TaxDetails_Taxation]    Script Date: 07/22/2014 16:34:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_TaxDetails_Taxation]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Slab]'))
ALTER TABLE [Invoice].[Slab]  WITH CHECK ADD  CONSTRAINT [FK_TaxDetails_Taxation] FOREIGN KEY([TaxId])
REFERENCES [Invoice].[Taxation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_TaxDetails_Taxation]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Slab]'))
ALTER TABLE [Invoice].[Slab] CHECK CONSTRAINT [FK_TaxDetails_Taxation]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_Account]    Script Date: 07/22/2014 16:34:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAnswer_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] CHECK CONSTRAINT [FK_SecurityAnswer_Account]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_SecurityQuestion]    Script Date: 07/22/2014 16:34:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAnswer_SecurityQuestion] FOREIGN KEY([QuestionId])
REFERENCES [Guardian].[SecurityQuestion] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] CHECK CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomCategory]    Script Date: 07/22/2014 16:34:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_RoomCategory] FOREIGN KEY([CategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomType]    Script Date: 07/22/2014 16:34:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_RoomType] FOREIGN KEY([TypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomCategory]    Script Date: 07/22/2014 16:34:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_RoomCategory] FOREIGN KEY([RoomCategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomType]    Script Date: 07/22/2014 16:34:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Status]    Script Date: 07/22/2014 16:34:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Status] FOREIGN KEY([StatusId])
REFERENCES [Customer].[ActionStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_Status]
GO
/****** Object:  ForeignKey [FK_Profile_Account]    Script Date: 07/22/2014 16:34:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] CHECK CONSTRAINT [FK_Profile_Account]
GO
/****** Object:  ForeignKey [FK_Profile_Initial]    Script Date: 07/22/2014 16:34:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Initial] FOREIGN KEY([Initial])
REFERENCES [Configuration].[Initial] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] CHECK CONSTRAINT [FK_Profile_Initial]
GO
/****** Object:  ForeignKey [FK_Payment_Invoice]    Script Date: 07/22/2014 16:34:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] CHECK CONSTRAINT [FK_Payment_Invoice]
GO
/****** Object:  ForeignKey [FK_Payment_PaymentType]    Script Date: 07/22/2014 16:34:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentType] FOREIGN KEY([PaymentTypeId])
REFERENCES [Invoice].[PaymentType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentType]
GO
/****** Object:  ForeignKey [FK_LoginLogoutHistory_Account]    Script Date: 07/22/2014 16:34:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginLogoutHistory_Account] FOREIGN KEY([AccountId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] CHECK CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
/****** Object:  ForeignKey [FK_LineItem_Invoice]    Script Date: 07/22/2014 16:34:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] CHECK CONSTRAINT [FK_LineItem_Invoice]
GO
/****** Object:  ForeignKey [FK_InvoiceTaxation_Invoice]    Script Date: 07/22/2014 16:34:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceTaxation_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] CHECK CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
/****** Object:  ForeignKey [FK_Artifact_Account]    Script Date: 07/22/2014 16:34:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account] FOREIGN KEY([CreatedByUserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account]
GO
/****** Object:  ForeignKey [FK_Artifact_Account1]    Script Date: 07/22/2014 16:34:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account1] FOREIGN KEY([ModifiedByUserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account1]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact]    Script Date: 07/22/2014 16:34:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact] FOREIGN KEY([ParentId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Artifact]
GO
/****** Object:  ForeignKey [FK_Appointment_AppointmentType]    Script Date: 07/22/2014 16:34:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_AppointmentType] FOREIGN KEY([TypeId])
REFERENCES [Utility].[AppointmentType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] CHECK CONSTRAINT [FK_Appointment_AppointmentType]
GO
/****** Object:  ForeignKey [FK_Appointment_Importance]    Script Date: 07/22/2014 16:34:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Importance] FOREIGN KEY([ImportanceId])
REFERENCES [Utility].[Importance] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] CHECK CONSTRAINT [FK_Appointment_Importance]
GO
/****** Object:  ForeignKey [FK_Building_Organization]    Script Date: 07/22/2014 16:34:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] CHECK CONSTRAINT [FK_Building_Organization]
GO
/****** Object:  ForeignKey [Organization_FK_ContactNumberId]    Script Date: 07/22/2014 16:34:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber]  WITH CHECK ADD  CONSTRAINT [Organization_FK_ContactNumberId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] CHECK CONSTRAINT [Organization_FK_ContactNumberId]
GO
/****** Object:  ForeignKey [Organization_FK_Id]    Script Date: 07/22/2014 16:34:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email]  WITH CHECK ADD  CONSTRAINT [Organization_FK_Id] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] CHECK CONSTRAINT [Organization_FK_Id]
GO
/****** Object:  ForeignKey [Organization_FK_FaxId]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax]  WITH CHECK ADD  CONSTRAINT [Organization_FK_FaxId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] CHECK CONSTRAINT [Organization_FK_FaxId]
GO
/****** Object:  ForeignKey [Customer_FK_IdentityProofId]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_IdentityProofId] FOREIGN KEY([IdentityProofId])
REFERENCES [Configuration].[IdentityProofType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_IdentityProofId]
GO
/****** Object:  ForeignKey [Customer_FK_InitialId]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_InitialId] FOREIGN KEY([InitialId])
REFERENCES [Configuration].[Initial] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_InitialId]
GO
/****** Object:  ForeignKey [Customer_FK_StateId]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_StateId] FOREIGN KEY([StateId])
REFERENCES [Configuration].[State] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_StateId]
GO
/****** Object:  ForeignKey [FK_CheckIn_ActionStatus]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_ActionStatus] FOREIGN KEY([StatusId])
REFERENCES [Customer].[ActionStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_ActionStatus]
GO
/****** Object:  ForeignKey [FK_CheckIn_RoomReservation]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_RoomReservation] FOREIGN KEY([ReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_RoomReservation]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Artifact]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_CatalogueModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] CHECK CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Module]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_CatalogueModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] CHECK CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_BuildingClosureReason_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] CHECK CONSTRAINT [FK_BuildingClosureReason_Building]
GO
/****** Object:  ForeignKey [FK_BuildingFloor_Building]    Script Date: 07/22/2014 16:34:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor]  WITH CHECK ADD  CONSTRAINT [FK_BuildingFloor_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] CHECK CONSTRAINT [FK_BuildingFloor_Building]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact1]    Script Date: 07/22/2014 16:34:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact1] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] CHECK CONSTRAINT [FK_Artifact_Artifact1]
GO
/****** Object:  ForeignKey [FK_Artifact_Invoice]    Script Date: 07/22/2014 16:34:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] CHECK CONSTRAINT [FK_Artifact_Invoice]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Artifact]    Script Date: 07/22/2014 16:34:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_FormModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] CHECK CONSTRAINT [FK_FormModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Module]    Script Date: 07/22/2014 16:34:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_FormModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] CHECK CONSTRAINT [FK_FormModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_LineItemTaxation_LineItem]    Script Date: 07/22/2014 16:34:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItemTaxation_LineItem]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]'))
ALTER TABLE [Invoice].[LineItemTaxation]  WITH CHECK ADD  CONSTRAINT [FK_LineItemTaxation_LineItem] FOREIGN KEY([LineItemId])
REFERENCES [Invoice].[LineItem] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItemTaxation_LineItem]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItemTaxation]'))
ALTER TABLE [Invoice].[LineItemTaxation] CHECK CONSTRAINT [FK_LineItemTaxation_LineItem]
GO
/****** Object:  ForeignKey [FK_ProfileContactNumber_Profile]    Script Date: 07/22/2014 16:34:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber]  WITH CHECK ADD  CONSTRAINT [FK_ProfileContactNumber_Profile] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Profile] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] CHECK CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Artifact]    Script Date: 07/22/2014 16:34:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_ReportModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] CHECK CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Module]    Script Date: 07/22/2014 16:34:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_ReportModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] CHECK CONSTRAINT [FK_ReportModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Report] FOREIGN KEY([ReportId])
REFERENCES [Invoice].[Report] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Invoice].[ReportArtifact]'))
ALTER TABLE [Invoice].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Report] FOREIGN KEY([ReportId])
REFERENCES [Customer].[Report] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_ReportArtifact_Report]') AND parent_object_id = OBJECT_ID(N'[Customer].[ReportArtifact]'))
ALTER TABLE [Customer].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_Artifact]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] CHECK CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_RoomReservation]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationArtifact_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] CHECK CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
/****** Object:  ForeignKey [FK_Room_Building]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_Building]
GO
/****** Object:  ForeignKey [FK_Room_BuildingFloor]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_BuildingFloor] FOREIGN KEY([FloorId])
REFERENCES [Lodge].[BuildingFloor] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_BuildingFloor]
GO
/****** Object:  ForeignKey [FK_Room_RoomCategory]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomCategory] FOREIGN KEY([CategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomCategory]
GO
/****** Object:  ForeignKey [FK_Room_RoomStatus]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomStatus] FOREIGN KEY([StatusId])
REFERENCES [Lodge].[RoomStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomStatus]
GO
/****** Object:  ForeignKey [FK_Room_RoomType]    Script Date: 07/22/2014 16:34:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([TypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Artifact]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerForm_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] CHECK CONSTRAINT [FK_CustomerForm_Artifact]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Customer]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerForm_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] CHECK CONSTRAINT [FK_CustomerForm_Customer]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_Artifact]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CheckInArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] CHECK CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_CheckIn]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CheckInArtifact_CheckIn] FOREIGN KEY([CheckInId])
REFERENCES [Lodge].[CheckIn] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] CHECK CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
/****** Object:  ForeignKey [CustomerContactNumber_FK_CustomerId]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber]  WITH CHECK ADD  CONSTRAINT [CustomerContactNumber_FK_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] CHECK CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_CheckIn]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn] FOREIGN KEY([RoomCheckInId])
REFERENCES [Lodge].[CheckIn] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] CHECK CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_Customer]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomCheckInLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] CHECK CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_Customer]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomReservationLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] CHECK CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_RoomReservation]    Script Date: 07/22/2014 16:34:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] CHECK CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomClosureReason_Room]    Script Date: 07/22/2014 16:34:39 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_RoomClosureReason_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] CHECK CONSTRAINT [FK_RoomClosureReason_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_Room]    Script Date: 07/22/2014 16:34:39 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_RoomReservation]    Script Date: 07/22/2014 16:34:39 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_RoomReservation] FOREIGN KEY([ReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomImage_Room]    Script Date: 07/22/2014 16:34:39 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage]  WITH CHECK ADD  CONSTRAINT [FK_RoomImage_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] CHECK CONSTRAINT [FK_RoomImage_Room]
GO
