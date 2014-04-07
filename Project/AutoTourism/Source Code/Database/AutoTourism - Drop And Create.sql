USE [master]
GO
/****** Object:  Database [AutoTourism]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'AutoTourism')
BEGIN
CREATE DATABASE [AutoTourism] ON  PRIMARY 
( NAME = N'AutoTourism', FILENAME = N'D:\Arpan\Personal\AutoTourism.mdb' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AutoTourism_log', FILENAME = N'D:\Arpan\Personal\AutoTourism.ldb' , SIZE = 20096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  ForeignKey [FK_UserRole_Account]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Account]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_Profile_Account]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Account]
GO
/****** Object:  ForeignKey [FK_Profile_Initial]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Initial]
GO
/****** Object:  ForeignKey [FK_LineItem_Invoice]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] DROP CONSTRAINT [FK_LineItem_Invoice]
GO
/****** Object:  ForeignKey [FK_LoginLogoutHistory_Account]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] DROP CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
/****** Object:  ForeignKey [FK_Payment_Invoice]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_Invoice]
GO
/****** Object:  ForeignKey [FK_Payment_PaymentType]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_PaymentType]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_Account]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_Account]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_SecurityQuestion]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomCategory]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomType]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Status]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] DROP CONSTRAINT [FK_RoomReservation_Status]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomCategory]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomType]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomType]
GO
/****** Object:  ForeignKey [FK_Building_Organization]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] DROP CONSTRAINT [FK_Building_Organization]
GO
/****** Object:  ForeignKey [FK_Artifact_Account]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Account]
GO
/****** Object:  ForeignKey [FK_Artifact_Account1]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Account1]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact]
GO
/****** Object:  ForeignKey [FK_Appointment_AppointmentType]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_AppointmentType]
GO
/****** Object:  ForeignKey [FK_Appointment_Importance]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_Importance]
GO
/****** Object:  ForeignKey [Customer_FK_IdentityProofId]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_IdentityProofId]
GO
/****** Object:  ForeignKey [Customer_FK_InitialId]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_InitialId]
GO
/****** Object:  ForeignKey [Customer_FK_StateId]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] DROP CONSTRAINT [Customer_FK_StateId]
GO
/****** Object:  ForeignKey [Organization_FK_ContactNumberId]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] DROP CONSTRAINT [Organization_FK_ContactNumberId]
GO
/****** Object:  ForeignKey [Organization_FK_Id]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] DROP CONSTRAINT [Organization_FK_Id]
GO
/****** Object:  ForeignKey [Organization_FK_FaxId]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] DROP CONSTRAINT [Organization_FK_FaxId]
GO
/****** Object:  ForeignKey [FK_InvoiceTaxation_Invoice]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] DROP CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_Customer]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_RoomReservation]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
/****** Object:  ForeignKey [CustomerContactNumber_FK_CustomerId]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] DROP CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Artifact]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [FK_CustomerForm_Artifact]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Customer]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] DROP CONSTRAINT [FK_CustomerForm_Customer]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact1]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact1]
GO
/****** Object:  ForeignKey [FK_Artifact_Invoice]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Invoice]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Artifact]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] DROP CONSTRAINT [FK_FormModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Module]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] DROP CONSTRAINT [FK_FormModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_BuildingFloor_Building]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] DROP CONSTRAINT [FK_BuildingFloor_Building]
GO
/****** Object:  ForeignKey [FK_CheckIn_ActionStatus]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_ActionStatus]
GO
/****** Object:  ForeignKey [FK_CheckIn_RoomReservation]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_RoomReservation]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Artifact]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Module]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] DROP CONSTRAINT [FK_BuildingClosureReason_Building]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_Artifact]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_RoomReservation]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Artifact]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Module]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_ProfileContactNumber_Profile]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] DROP CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
/****** Object:  ForeignKey [FK_Room_Building]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_Building]
GO
/****** Object:  ForeignKey [FK_Room_BuildingFloor]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_BuildingFloor]
GO
/****** Object:  ForeignKey [FK_Room_RoomCategory]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomCategory]
GO
/****** Object:  ForeignKey [FK_Room_RoomStatus]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomStatus]
GO
/****** Object:  ForeignKey [FK_Room_RoomType]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] DROP CONSTRAINT [FK_Room_RoomType]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_Artifact]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_CheckIn]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_CheckIn]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_Customer]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
/****** Object:  ForeignKey [FK_RoomClosureReason_Room]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] DROP CONSTRAINT [FK_RoomClosureReason_Room]
GO
/****** Object:  ForeignKey [FK_RoomImage_Room]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] DROP CONSTRAINT [FK_RoomImage_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_Room]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_RoomReservation]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
/****** Object:  StoredProcedure [Lodge].[IsCheckInDeletable]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsCheckInDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsCheckInDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadAllCheckInRooms]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadAllCheckInRooms]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomImageRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomImageReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadBookedRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadBookedRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsRead]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationSearch]
GO
/****** Object:  Table [Lodge].[RoomReservationDetails]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_Room]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservationDetails]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadCheckedInRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadCheckedInRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadOpenRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadOpenRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomModifyStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomModifyStatus]
GO
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomDelete]
GO
/****** Object:  Table [Lodge].[RoomImage]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] DROP CONSTRAINT [FK_RoomImage_Room]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImage]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomImage]
GO
/****** Object:  Table [Lodge].[RoomClosureReason]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] DROP CONSTRAINT [FK_RoomClosureReason_Room]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomClosureReason]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffModifyRate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffModifyRate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[ReadCheckInFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadCheckInFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadCheckInFormForArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomBuildingDeletable]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomBuildingDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsRoomBuildingDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomCategoryDeletable]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomCategoryDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsRoomCategoryDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomStatusDeletable]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomStatusDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsRoomStatusDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsRoomTypeDeletable]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsRoomTypeDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingFloorDeletable]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingFloorDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingFloorDeletable]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkInsert]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkRead]
GO
/****** Object:  StoredProcedure [Lodge].[DeleteCheckInFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[DeleteCheckInFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[DeleteCheckInFormForArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[InsertCheckInFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[InsertCheckInFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[InsertCheckInFormForArtifact]
GO
/****** Object:  StoredProcedure [Customer].[InsertFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[InsertFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[InsertFormForArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InsertInvoiceFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InsertInvoiceFormForArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[InsertReservationFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[InsertReservationFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[InsertReservationFormForArtifact]
GO
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[GetCustomerIdForReservation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[GetCustomerIdForReservation]
GO
/****** Object:  StoredProcedure [Customer].[DeleteFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[DeleteFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[DeleteFormForArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[DeleteInvoiceFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[DeleteInvoiceFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[DeleteInvoiceFormForArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[DeleteReservationFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[DeleteReservationFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[DeleteReservationFormForArtifact]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReadDuplicate]
GO
/****** Object:  Table [AutoTourism].[CustomerRoomCheckInLink]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] DROP CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]') AND type in (N'U'))
DROP TABLE [AutoTourism].[CustomerRoomCheckInLink]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkDelete]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkInsert]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkRead]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberDelete]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberInsert]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 04/07/2014 10:21:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberRead]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactDelete]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkInsertForModule]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkInsertForModule]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactModuleLinkInsertForModule]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkReadForArtifact]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkReadForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactModuleLinkReadForArtifact]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkReadForModule]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLinkReadForModule]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactModuleLinkReadForModule]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactSearchByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactSearchByName]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonInsert]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorReadForParent]
GO
/****** Object:  Table [Lodge].[CheckInArtifact]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] DROP CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]') AND type in (N'U'))
DROP TABLE [Lodge].[CheckInArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInDelete]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInInsert]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInRead]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInUpdate]
GO
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsStateIdDeletable]
GO
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsIdentityProofIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsIdentityProofIdDeletable]
GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsInitialDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsInitialDeletable]
GO
/****** Object:  StoredProcedure [Customer].[ReadFormForArtifact]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReadFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReadFormForArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[ReadInvoiceFormForArtifact]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadInvoiceFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadInvoiceFormForArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[ReadReservationFormForArtifact]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadReservationFormForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadReservationFormForArtifact]
GO
/****** Object:  Table [Lodge].[Room]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberInsert]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberRead]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateCheckInStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateCheckInStatus]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateInvoiceNumber]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateInvoiceNumber]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationStatusToCheckIn]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateReservationStatusToCheckIn]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerDelete]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerRead]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffIsExist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffIsExist]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllCurrent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadAllCurrent]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllFuture]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadAllFuture]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadDuplicate]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleDelete]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleRead]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileRead]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileUpdate]
GO
/****** Object:  Table [Guardian].[ProfileContactNumber]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] DROP CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]') AND type in (N'U'))
DROP TABLE [Guardian].[ProfileContactNumber]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentDelete]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentInsert]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentInsert]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentRead]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadAll]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentUpdate]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentUpdate]
GO
/****** Object:  Table [Navigator].[ReportModuleLink]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] DROP CONSTRAINT [FK_ReportModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]') AND type in (N'U'))
DROP TABLE [Navigator].[ReportModuleLink]
GO
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[IsInitialDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[IsInitialDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[IsPaymentTypeDeletable]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[IsPaymentTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[IsPaymentTypeDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsTariffDeletable]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsTariffDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsTariffDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemDelete]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemDelete]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemInsert]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemInsert]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemRead]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemRead]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadAll]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemReadForParent]
GO
/****** Object:  StoredProcedure [Invoice].[LineItemUpdate]    Script Date: 04/07/2014 10:21:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[LineItemUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryInsert]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryRead]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingStatusDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingStatusDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingTypeDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SearchUserByLoginId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SearchUserByLoginId]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationReadAll]
GO
/****** Object:  Table [Lodge].[RoomReservationArtifact]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] DROP CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomReservationArtifact]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationUpdateStatus]
GO
/****** Object:  Table [Lodge].[BuildingClosureReason]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] DROP CONSTRAINT [FK_BuildingClosureReason_Building]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingClosureReason]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingUpdate]
GO
/****** Object:  Table [Navigator].[CatalogueModuleLink]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] DROP CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]') AND type in (N'U'))
DROP TABLE [Navigator].[CatalogueModuleLink]
GO
/****** Object:  Table [Lodge].[CheckIn]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_ActionStatus]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] DROP CONSTRAINT [FK_CheckIn_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckIn]') AND type in (N'U'))
DROP TABLE [Lodge].[CheckIn]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingModifyStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingModifyStatus]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingDelete]
GO
/****** Object:  Table [Lodge].[BuildingFloor]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] DROP CONSTRAINT [FK_BuildingFloor_Building]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingFloor]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactRead]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactReadAll]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactInsert]
GO
/****** Object:  Table [Navigator].[ArtifactModuleLink]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] DROP CONSTRAINT [FK_FormModuleLink_Artifact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] DROP CONSTRAINT [FK_FormModuleLink_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]') AND type in (N'U'))
DROP TABLE [Navigator].[ArtifactModuleLink]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentUpdate]
GO
/****** Object:  Table [Invoice].[Artifact]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Artifact1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] DROP CONSTRAINT [FK_Artifact_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Artifact]') AND type in (N'U'))
DROP TABLE [Invoice].[Artifact]
GO
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountRead]
GO
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentDelete]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 04/07/2014 10:21:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentRead]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentSearch]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearchWithImportance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentSearchWithImportance]
GO
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerDelete]
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerInsert]
GO
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerRead]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReadAll]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberDelete]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberInsert]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberRead]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberReadForParent]
GO
/****** Object:  Table [Customer].[CustomerArtifact]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  Table [Customer].[CustomerContactNumber]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] DROP CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]') AND type in (N'U'))
DROP TABLE [Customer].[CustomerContactNumber]
GO
/****** Object:  Table [AutoTourism].[CustomerRoomReservationLink]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] DROP CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]') AND type in (N'U'))
DROP TABLE [AutoTourism].[CustomerRoomReservationLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerUpdate]
GO
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailDelete]
GO
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailInsert]
GO
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailReadForParent]
GO
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxDelete]
GO
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxInsert]
GO
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxRead]
GO
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxReadForParent]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentRead]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationInsert]
GO
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailRead]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationRead]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingDeletable]
GO
/****** Object:  Table [Invoice].[InvoiceTaxation]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] DROP CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]') AND type in (N'U'))
DROP TABLE [Invoice].[InvoiceTaxation]
GO
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialDelete]
GO
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialInsert]
GO
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialRead]
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[Insert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Insert]
GO
/****** Object:  Table [Organization].[Fax]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] DROP CONSTRAINT [Organization_FK_FaxId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Fax]') AND type in (N'U'))
DROP TABLE [Organization].[Fax]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeDelete]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeInsert]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeRead]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeUpdate]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceDelete]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceInsert]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceRead]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceReadAll]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceReadDuplicate]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountDelete]
GO
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountInsert]
GO
/****** Object:  Table [Organization].[Email]    Script Date: 04/07/2014 10:21:13 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] DROP CONSTRAINT [Organization_FK_Id]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Email]') AND type in (N'U'))
DROP TABLE [Organization].[Email]
GO
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentDelete]
GO
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentInsert]
GO
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentRead]
GO
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentReadAll]
GO
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentUpdate]
GO
/****** Object:  Table [Organization].[ContactNumber]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] DROP CONSTRAINT [Organization_FK_ContactNumberId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumber]') AND type in (N'U'))
DROP TABLE [Organization].[ContactNumber]
GO
/****** Object:  Table [Customer].[Customer]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusDelete]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusInsert]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusRead]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusReadAll]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusUpdate]
GO
/****** Object:  Table [Utility].[Appointment]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_AppointmentType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] DROP CONSTRAINT [FK_Appointment_Importance]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[Appointment]') AND type in (N'U'))
DROP TABLE [Utility].[Appointment]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdateLoginId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdateLoginId]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdatePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdatePassword]
GO
/****** Object:  Table [Navigator].[Artifact]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeDelete]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeRead]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeUpdate]
GO
/****** Object:  Table [Lodge].[Building]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] DROP CONSTRAINT [FK_Building_Organization]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[Building]') AND type in (N'U'))
DROP TABLE [Lodge].[Building]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusDelete]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusInsert]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusRead]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusReadAll]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusUpdate]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingStatusUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeDelete]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeInsert]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeRead]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeReadAll]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeUpdate]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingTypeUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationStatusRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationStatusReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomStatusDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomStatusRead]
GO
/****** Object:  Table [Lodge].[RoomTariff]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] DROP CONSTRAINT [FK_RoomTariff_RoomType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariff]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomTariff]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 04/07/2014 10:21:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryUpdate]
GO
/****** Object:  Table [Lodge].[RoomReservation]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  Table [Guardian].[SecurityAnswer]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] DROP CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]') AND type in (N'U'))
DROP TABLE [Guardian].[SecurityAnswer]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeUpdate]
GO
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[RuleInsert]
GO
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleInsert]
GO
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleInsert]
GO
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[RuleRead]
GO
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleRead]
GO
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleRead]
GO
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionDelete]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionRead]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionReadDuplicate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionUpdate]
GO
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateDelete]
GO
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateInsert]
GO
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateRead]
GO
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateUpdate]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationInsert]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationDelete]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationUpdate]
GO
/****** Object:  Table [Invoice].[Payment]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] DROP CONSTRAINT [FK_Payment_PaymentType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Payment]') AND type in (N'U'))
DROP TABLE [Invoice].[Payment]
GO
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleDelete]
GO
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleInsert]
GO
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleRead]
GO
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleReadAll]
GO
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleUpdate]
GO
/****** Object:  Table [Guardian].[LoginHistory]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] DROP CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistory]') AND type in (N'U'))
DROP TABLE [Guardian].[LoginHistory]
GO
/****** Object:  Table [Invoice].[LineItem]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] DROP CONSTRAINT [FK_LineItem_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItem]') AND type in (N'U'))
DROP TABLE [Invoice].[LineItem]
GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[IsStateIdDeletable]
GO
/****** Object:  StoredProcedure [Invoice].[ReadDuplicate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[ReadForInvoiceNumber]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadForInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadForInvoiceNumber]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationRead]
GO
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleRead]
GO
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleReadAll]
GO
/****** Object:  Table [Guardian].[Profile]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] DROP CONSTRAINT [FK_Profile_Initial]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Profile]') AND type in (N'U'))
DROP TABLE [Guardian].[Profile]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeDelete]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeDelete]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeInsert]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeInsert]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeRead]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeRead]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadAll]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadDuplicate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeUpdate]    Script Date: 04/07/2014 10:21:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentTypeUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[Read]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Read]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Read]
GO
/****** Object:  StoredProcedure [Invoice].[ReadAll]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRuleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRuleRead]
GO
/****** Object:  StoredProcedure [Invoice].[Delete]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Delete]
GO
/****** Object:  Table [Guardian].[UserRole]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRole]') AND type in (N'U'))
DROP TABLE [Guardian].[UserRole]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationDelete]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationDelete]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationInsert]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationInsert]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationRead]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationRead]
GO
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TaxationRead]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadAll]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TaxationReadAll]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationReadDuplicate]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationReadDuplicate]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationUpdate]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[TaxationUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[Update]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[Update]
GO
/****** Object:  Table [Invoice].[Taxation]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Taxation]') AND type in (N'U'))
DROP TABLE [Invoice].[Taxation]
GO
/****** Object:  Table [Guardian].[SecurityQuestion]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestion]') AND type in (N'U'))
DROP TABLE [Guardian].[SecurityQuestion]
GO
/****** Object:  Table [Guardian].[UserRule]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRule]') AND type in (N'U'))
DROP TABLE [Guardian].[UserRule]
GO
/****** Object:  Table [Invoice].[PaymentType]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentType]') AND type in (N'U'))
DROP TABLE [Invoice].[PaymentType]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationUpdate]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationUpdate]
GO
/****** Object:  Table [Guardian].[Role]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Role]') AND type in (N'U'))
DROP TABLE [Guardian].[Role]
GO
/****** Object:  Table [Lodge].[RoomCategory]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategory]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomCategory]
GO
/****** Object:  Table [License].[Module]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Module]') AND type in (N'U'))
DROP TABLE [License].[Module]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationInsert]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationInsert]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationRead]    Script Date: 04/07/2014 10:21:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationRead]
GO
/****** Object:  Table [Organization].[Organization]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Organization]') AND type in (N'U'))
DROP TABLE [Organization].[Organization]
GO
/****** Object:  StoredProcedure [dbo].[EmailInsert]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailInsert]
GO
/****** Object:  StoredProcedure [dbo].[EmailRead]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailRead]
GO
/****** Object:  StoredProcedure [dbo].[EmailReadForParent]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmailReadForParent]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationEmailRead]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationEmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrganizationEmailRead]
GO
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusDelete]
GO
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusInsert]
GO
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusRead]
GO
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusReadAll]
GO
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusUpdate]
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 04/07/2014 10:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Split]
GO
/****** Object:  Table [BinAff].[Stamp]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[BinAff].[Stamp]') AND type in (N'U'))
DROP TABLE [BinAff].[Stamp]
GO
/****** Object:  Table [Configuration].[State]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[State]') AND type in (N'U'))
DROP TABLE [Configuration].[State]
GO
/****** Object:  Table [Lodge].[RoomType]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomType]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomType]
GO
/****** Object:  Table [Configuration].[Rule]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Rule]') AND type in (N'U'))
DROP TABLE [Configuration].[Rule]
GO
/****** Object:  Table [Customer].[Rule]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[Rule]') AND type in (N'U'))
DROP TABLE [Customer].[Rule]
GO
/****** Object:  Table [Navigator].[Rule]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[Rule]') AND type in (N'U'))
DROP TABLE [Navigator].[Rule]
GO
/****** Object:  Table [Lodge].[RoomStatus]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatus]') AND type in (N'U'))
DROP TABLE [Lodge].[RoomStatus]
GO
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CleanUpSchema]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CleanUpSchema]
GO
/****** Object:  Table [License].[Component]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Component]') AND type in (N'U'))
DROP TABLE [License].[Component]
GO
/****** Object:  Table [Lodge].[BuildingType]    Script Date: 04/07/2014 10:21:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingType]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingType]
GO
/****** Object:  Table [Lodge].[BuildingStatus]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatus]') AND type in (N'U'))
DROP TABLE [Lodge].[BuildingStatus]
GO
/****** Object:  Table [Customer].[ActionStatus]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatus]') AND type in (N'U'))
DROP TABLE [Customer].[ActionStatus]
GO
/****** Object:  Table [Guardian].[Account]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[Account]') AND type in (N'U'))
DROP TABLE [Guardian].[Account]
GO
/****** Object:  Table [Utility].[AppointmentType]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentType]') AND type in (N'U'))
DROP TABLE [Utility].[AppointmentType]
GO
/****** Object:  Table [License].[Credential]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[Credential]') AND type in (N'U'))
DROP TABLE [License].[Credential]
GO
/****** Object:  Table [BinAff].[DateStamp]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[BinAff].[DateStamp]') AND type in (N'U'))
DROP TABLE [BinAff].[DateStamp]
GO
/****** Object:  Table [Configuration].[Initial]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[Initial]') AND type in (N'U'))
DROP TABLE [Configuration].[Initial]
GO
/****** Object:  Table [Utility].[Importance]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[Importance]') AND type in (N'U'))
DROP TABLE [Utility].[Importance]
GO
/****** Object:  Table [Configuration].[IdentityProofType]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofType]') AND type in (N'U'))
DROP TABLE [Configuration].[IdentityProofType]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkDelete]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkRead]
GO
/****** Object:  Table [Invoice].[Invoice]    Script Date: 04/07/2014 10:21:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Invoice]') AND type in (N'U'))
DROP TABLE [Invoice].[Invoice]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 04/07/2014 10:21:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkDelete]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 04/07/2014 10:21:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 04/07/2014 10:21:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkRead]
GO
/****** Object:  Schema [AutoTourism]    Script Date: 04/07/2014 10:20:51 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'AutoTourism')
DROP SCHEMA [AutoTourism]
GO
/****** Object:  Schema [BinAff]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'BinAff')
DROP SCHEMA [BinAff]
GO
/****** Object:  Schema [Configuration]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Configuration')
DROP SCHEMA [Configuration]
GO
/****** Object:  Schema [Customer]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Customer')
DROP SCHEMA [Customer]
GO
/****** Object:  Schema [Guardian]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Guardian')
DROP SCHEMA [Guardian]
GO
/****** Object:  Schema [Invoice]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Invoice')
DROP SCHEMA [Invoice]
GO
/****** Object:  Schema [License]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'License')
DROP SCHEMA [License]
GO
/****** Object:  Schema [Lodge]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Lodge')
DROP SCHEMA [Lodge]
GO
/****** Object:  Schema [Navigator]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Navigator')
DROP SCHEMA [Navigator]
GO
/****** Object:  Schema [Organization]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Organization')
DROP SCHEMA [Organization]
GO
/****** Object:  Schema [Reservation]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Reservation')
DROP SCHEMA [Reservation]
GO
/****** Object:  Schema [Utility]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Utility')
DROP SCHEMA [Utility]
GO
/****** Object:  User [AppUser]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AppUser')
DROP USER [AppUser]
GO
USE [master]
GO
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'##MS_PolicyEventProcessingLogin##')
DROP LOGIN [##MS_PolicyEventProcessingLogin##]
GO
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'##MS_PolicyTsqlExecutionLogin##')
DROP LOGIN [##MS_PolicyTsqlExecutionLogin##]
GO
/****** Object:  Login [AppUser]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'AppUser')
DROP LOGIN [AppUser]
GO
/****** Object:  Login [BinAffAdmin]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'BinAffAdmin')
DROP LOGIN [BinAffAdmin]
GO
/****** Object:  Login [BUILTIN\Users]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'BUILTIN\Users')
DROP LOGIN [BUILTIN\Users]
GO
/****** Object:  Login [INFOTECH\53235]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'INFOTECH\53235')
DROP LOGIN [INFOTECH\53235]
GO
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'NT AUTHORITY\SYSTEM')
DROP LOGIN [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Login [NT SERVICE\MSSQL$SQLEXPRESS]    Script Date: 04/07/2014 10:20:50 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'NT SERVICE\MSSQL$SQLEXPRESS')
DROP LOGIN [NT SERVICE\MSSQL$SQLEXPRESS]
GO
/****** Object:  Login [NT SERVICE\MSSQL$SQLEXPRESS]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'NT SERVICE\MSSQL$SQLEXPRESS')
CREATE LOGIN [NT SERVICE\MSSQL$SQLEXPRESS] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'NT AUTHORITY\SYSTEM')
CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [INFOTECH\53235]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'INFOTECH\53235')
CREATE LOGIN [INFOTECH\53235] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [BUILTIN\Users]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'BUILTIN\Users')
CREATE LOGIN [BUILTIN\Users] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [BinAffAdmin]    Script Date: 04/07/2014 10:20:50 ******/
/* For security reasons the login is created disabled and with a random password. */
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'BinAffAdmin')
CREATE LOGIN [BinAffAdmin] WITH PASSWORD=N'@5Ó÷cÚ­XÚtS*Ó²[,Èôxþ', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
EXEC sys.sp_addsrvrolemember @loginame = N'BinAffAdmin', @rolename = N'sysadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'BinAffAdmin', @rolename = N'securityadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'BinAffAdmin', @rolename = N'serveradmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'BinAffAdmin', @rolename = N'setupadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'BinAffAdmin', @rolename = N'processadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'BinAffAdmin', @rolename = N'diskadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'BinAffAdmin', @rolename = N'dbcreator'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'BinAffAdmin', @rolename = N'bulkadmin'
GO
ALTER LOGIN [BinAffAdmin] DISABLE
GO
/****** Object:  Login [AppUser]    Script Date: 04/07/2014 10:20:50 ******/
/* For security reasons the login is created disabled and with a random password. */
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'AppUser')
CREATE LOGIN [AppUser] WITH PASSWORD=N'ì¨ÇÙò-0>@ÁÂ{Á¬8H£ã,ÇoVw&V F', DEFAULT_DATABASE=[AutoTourism], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [AppUser] DISABLE
GO
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 04/07/2014 10:20:50 ******/
/* For security reasons the login is created disabled and with a random password. */
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'##MS_PolicyTsqlExecutionLogin##')
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'Õëæ{Ç_¹ÐÖè´¢,Ø¯c¸RFW', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 04/07/2014 10:20:50 ******/
/* For security reasons the login is created disabled and with a random password. */
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'##MS_PolicyEventProcessingLogin##')
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'#ÌÉIoÿIîz:è=pý¯|Öxnq1ïÉi;', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
USE [AutoTourism]
GO
/****** Object:  User [AppUser]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AppUser')
CREATE USER [AppUser] FOR LOGIN [AppUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [Utility]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Utility')
EXEC sys.sp_executesql N'CREATE SCHEMA [Utility] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Reservation]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Reservation')
EXEC sys.sp_executesql N'CREATE SCHEMA [Reservation] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Organization]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Organization')
EXEC sys.sp_executesql N'CREATE SCHEMA [Organization] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Navigator]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Navigator')
EXEC sys.sp_executesql N'CREATE SCHEMA [Navigator] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Lodge]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Lodge')
EXEC sys.sp_executesql N'CREATE SCHEMA [Lodge] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [License]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'License')
EXEC sys.sp_executesql N'CREATE SCHEMA [License] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Invoice]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Invoice')
EXEC sys.sp_executesql N'CREATE SCHEMA [Invoice] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Guardian]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Guardian')
EXEC sys.sp_executesql N'CREATE SCHEMA [Guardian] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Customer]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Customer')
EXEC sys.sp_executesql N'CREATE SCHEMA [Customer] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [Configuration]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Configuration')
EXEC sys.sp_executesql N'CREATE SCHEMA [Configuration] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [BinAff]    Script Date: 04/07/2014 10:20:50 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'BinAff')
EXEC sys.sp_executesql N'CREATE SCHEMA [BinAff] AUTHORIZATION [dbo]'
GO
/****** Object:  Schema [AutoTourism]    Script Date: 04/07/2014 10:20:51 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'AutoTourism')
EXEC sys.sp_executesql N'CREATE SCHEMA [AutoTourism] AUTHORIZATION [dbo]'
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 04/07/2014 10:21:00 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 04/07/2014 10:21:00 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 04/07/2014 10:21:00 ******/
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
/****** Object:  Table [Invoice].[Invoice]    Script Date: 04/07/2014 10:21:06 ******/
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
SET IDENTITY_INSERT [Invoice].[Invoice] OFF
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [Configuration].[IdentityProofType]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [Utility].[Importance]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [Configuration].[Initial]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [BinAff].[DateStamp]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [License].[Credential]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [Utility].[AppointmentType]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [Guardian].[Account]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [Customer].[ActionStatus]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [Lodge].[BuildingStatus]    Script Date: 04/07/2014 10:21:06 ******/
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
/****** Object:  Table [Lodge].[BuildingType]    Script Date: 04/07/2014 10:21:07 ******/
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
/****** Object:  Table [License].[Component]    Script Date: 04/07/2014 10:21:07 ******/
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
SET IDENTITY_INSERT [License].[Component] OFF
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 04/07/2014 10:21:07 ******/
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
/****** Object:  Table [Lodge].[RoomStatus]    Script Date: 04/07/2014 10:21:07 ******/
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
/****** Object:  Table [Navigator].[Rule]    Script Date: 04/07/2014 10:21:07 ******/
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
/****** Object:  Table [Customer].[Rule]    Script Date: 04/07/2014 10:21:07 ******/
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
INSERT [Customer].[Rule] ([Id], [IsPinNo], [IsAlternateContactNo], [IsEmail], [IsIdentityProof]) VALUES (CAST(1 AS Numeric(10, 0)), 0, 1, 0, 1)
SET IDENTITY_INSERT [Customer].[Rule] OFF
/****** Object:  Table [Configuration].[Rule]    Script Date: 04/07/2014 10:21:07 ******/
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
/****** Object:  Table [Lodge].[RoomType]    Script Date: 04/07/2014 10:21:07 ******/
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
/****** Object:  Table [Configuration].[State]    Script Date: 04/07/2014 10:21:07 ******/
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
INSERT [Configuration].[State] ([Id], [Name]) VALUES (CAST(1 AS Numeric(10, 0)), N'Karnataka')
INSERT [Configuration].[State] ([Id], [Name]) VALUES (CAST(3 AS Numeric(10, 0)), N'Kerela')
INSERT [Configuration].[State] ([Id], [Name]) VALUES (CAST(5 AS Numeric(10, 0)), N'Assam')
INSERT [Configuration].[State] ([Id], [Name]) VALUES (CAST(8 AS Numeric(10, 0)), N'West Bengal')
INSERT [Configuration].[State] ([Id], [Name]) VALUES (CAST(9 AS Numeric(10, 0)), N'Jharkhand')
SET IDENTITY_INSERT [Configuration].[State] OFF
/****** Object:  Table [BinAff].[Stamp]    Script Date: 04/07/2014 10:21:07 ******/
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
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [dbo].[OrganizationEmailRead]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [dbo].[EmailReadForParent]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [dbo].[EmailRead]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  StoredProcedure [dbo].[EmailInsert]    Script Date: 04/07/2014 10:21:09 ******/
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
/****** Object:  Table [Organization].[Organization]    Script Date: 04/07/2014 10:21:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Organization]') AND type in (N'U'))
BEGIN
CREATE TABLE [Organization].[Organization](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Logo] [varbinary](max) NULL,
	[LicenceNumber] [varchar](50) NULL,
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
INSERT [Organization].[Organization] ([Id], [Name], [Logo], [LicenceNumber], [Tan], [Address], [City], [StateId], [Pin], [ContactName]) VALUES (CAST(12 AS Numeric(10, 0)), N'ABC Lodge', NULL, N'ABC237B', N'ABCD12345E', N'Bangalore, Old Airport Road', N'Bangalore', CAST(1 AS Numeric(10, 0)), 560017, N'Manjunath')
SET IDENTITY_INSERT [Organization].[Organization] OFF
/****** Object:  StoredProcedure [dbo].[OrganizationRead]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [dbo].[OrganizationInsert]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  Table [License].[Module]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  Table [Lodge].[RoomCategory]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  Table [Guardian].[Role]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [dbo].[OrganizationUpdate]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  Table [Invoice].[PaymentType]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  Table [Guardian].[UserRule]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  Table [Guardian].[SecurityQuestion]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  Table [Invoice].[Taxation]    Script Date: 04/07/2014 10:21:10 ******/
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
INSERT [Invoice].[Taxation] ([Id], [Name], [Amount], [IsPercentage]) VALUES (CAST(1 AS Numeric(10, 0)), N'Service Tax', 1500.0000, 0)
INSERT [Invoice].[Taxation] ([Id], [Name], [Amount], [IsPercentage]) VALUES (CAST(2 AS Numeric(10, 0)), N'Luxuary Tax', 12.5000, 1)
SET IDENTITY_INSERT [Invoice].[Taxation] OFF
/****** Object:  StoredProcedure [Invoice].[Update]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[TaxationUpdate]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[TaxationReadDuplicate]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[TaxationReadAll]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[TaxationRead]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[TaxationInsert]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[TaxationDelete]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  Table [Guardian].[UserRole]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[Delete]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[ReadAll]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[Read]    Script Date: 04/07/2014 10:21:10 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeUpdate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadDuplicate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadAll]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentTypeDelete]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  Table [Guardian].[Profile]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 04/07/2014 10:21:11 ******/
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
		[Address],
		[City],
		[StateId],
		[Pin],
		[ContactName]
	FROM [Organization].[Organization]
END' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadForInvoiceNumber]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Invoice].[ReadDuplicate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  Table [Invoice].[LineItem]    Script Date: 04/07/2014 10:21:11 ******/
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
SET IDENTITY_INSERT [Invoice].[LineItem] OFF
/****** Object:  Table [Guardian].[LoginHistory]    Script Date: 04/07/2014 10:21:11 ******/
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
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(16 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D20101C67B AS DateTime), CAST(0x0000A2D20101E767 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(17 AS Numeric(10, 0)), CAST(12 AS Numeric(10, 0)), CAST(0x0000A2D20101FDCB AS DateTime), CAST(0x0000A2D201020564 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(18 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D201020DB9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(19 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D201055A00 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(20 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D2010597B2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D20105E6D9 AS DateTime), CAST(0x0000A2D20105EC56 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D20105F910 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D20107C719 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D20107EE43 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(25 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D20109B4B4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(26 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D2010A8297 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(27 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D2010C60DA AS DateTime), CAST(0x0000A2D2010C7953 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(28 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D2010C7B38 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(29 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D2010CF2A3 AS DateTime), CAST(0x0000A2D2010CFBAE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(30 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D2010D0565 AS DateTime), CAST(0x0000A2D2010D1FD6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(31 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D2010D29E6 AS DateTime), CAST(0x0000A2D2010D3989 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(32 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D501006FE8 AS DateTime), CAST(0x0000A2D501067467 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(33 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D7013E5062 AS DateTime), CAST(0x0000A2D70161C224 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(34 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D701643FE0 AS DateTime), CAST(0x0000A2D70164B319 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(35 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D9009C850B AS DateTime), CAST(0x0000A2D9009CEE11 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(36 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D9009E6FDD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(37 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D9009EAFBE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(38 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D9009F6D8C AS DateTime), CAST(0x0000A2D9009FC897 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(39 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D9009FF015 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(40 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A093E6 AS DateTime), CAST(0x0000A2D900A0EFD8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(41 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A16A44 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(42 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A1DACC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(43 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A20C5D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(44 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A33BA3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(45 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A3A45A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(46 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A4DB6B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(47 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A5B52F AS DateTime), CAST(0x0000A2D900A64B89 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(48 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A66278 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(49 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A6D3ED AS DateTime), CAST(0x0000A2D900A73385 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(50 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A89843 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(51 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A909F4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(52 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A9449B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(53 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A9872B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(54 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A9EDD5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(55 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900AAD5CD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(56 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900AB0310 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900AB760E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(58 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900AF6A5A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(59 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900B13E3D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900B1713B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(61 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900B1A4C8 AS DateTime), CAST(0x0000A2D900B1C85E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900B1D8B7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(63 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900B2011A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(64 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900B2CE93 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(65 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BAFC6A AS DateTime), CAST(0x0000A2D900BB6020 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(66 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BE2370 AS DateTime), CAST(0x0000A2D900BE3D7B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(67 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BF1430 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(68 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C34145 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(69 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E79893 AS DateTime), CAST(0x0000A2D900E82600 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(70 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900F13553 AS DateTime), CAST(0x0000A2D900F17385 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(71 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900F51CCA AS DateTime), CAST(0x0000A2D900F54A8C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(72 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D90104944C AS DateTime), CAST(0x0000A2D90104AA32 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(73 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D90106DE43 AS DateTime), CAST(0x0000A2D90107EAEA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(74 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D90108E4FD AS DateTime), CAST(0x0000A2D9010A55C6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(75 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA00883825 AS DateTime), CAST(0x0000A2DA0088A59F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(76 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA0088CFDE AS DateTime), CAST(0x0000A2DA0088DCE1 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(77 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008B102D AS DateTime), CAST(0x0000A2DA008B3781 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(78 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008B53F9 AS DateTime), CAST(0x0000A2DA008B5807 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008B7E78 AS DateTime), CAST(0x0000A2DA008B83AF AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(80 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008B98D4 AS DateTime), CAST(0x0000A2DA008BAABA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(81 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008D1D0A AS DateTime), CAST(0x0000A2DA008D3BE7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(82 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008EB4D8 AS DateTime), CAST(0x0000A2DA008EC9B4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008F61CD AS DateTime), CAST(0x0000A2DA008F858A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(84 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008F8787 AS DateTime), CAST(0x0000A2DA008F8D62 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(85 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA008F980D AS DateTime), CAST(0x0000A2DA008FA005 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB00D16075 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(87 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB00D2C2C5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(88 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB00D3BDBF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(89 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB00D422E7 AS DateTime), CAST(0x0000A2DB00D4706F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(90 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB00D59924 AS DateTime), CAST(0x0000A2DB00D5A045 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(91 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB00FD457E AS DateTime), CAST(0x0000A2DB01036EA6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(92 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB015F49D2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(93 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB015FDEAD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(94 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB01606F24 AS DateTime), CAST(0x0000A2DB016093EC AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB0160D109 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(96 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB0161E752 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(97 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016A381A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(98 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016A5ACF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(99 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016A8893 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016ABE16 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(101 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016B11A2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(102 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016B61AE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016B881B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(104 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016BC26E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(105 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016BF5CD AS DateTime), CAST(0x0000A2DB016C628C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(106 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016C7954 AS DateTime), CAST(0x0000A2DB016C988B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(107 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016CB6BD AS DateTime), CAST(0x0000A2DB016CBA7A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(108 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016CE683 AS DateTime), CAST(0x0000A2DB016CF623 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(109 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016D2BDF AS DateTime), CAST(0x0000A2DB016D4757 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(110 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016D5DD2 AS DateTime), CAST(0x0000A2DB016D6510 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(111 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DB016DDA66 AS DateTime), CAST(0x0000A2DB016E0579 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(112 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00A6DBAF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(113 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00A720D7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(114 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00A780AE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(115 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00A7CE7D AS DateTime), NULL)
GO
print 'Processed 100 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(116 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B02290 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(117 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B08160 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(118 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B0B4F2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(119 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B0DBB1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(120 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B128A9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(121 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B1E0A3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(122 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B37235 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(123 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B39340 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(124 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B41FDB AS DateTime), CAST(0x0000A2DC00B4C081 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(125 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B7E10D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(126 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B81EAD AS DateTime), CAST(0x0000A2DC00B8245B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(127 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B88CF2 AS DateTime), CAST(0x0000A2DC00B9380E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(128 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B93A23 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(129 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B9C95E AS DateTime), CAST(0x0000A2DC00B9D639 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00B9D8CB AS DateTime), CAST(0x0000A2DC00B9E2DE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(131 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BC0C0D AS DateTime), CAST(0x0000A2DC00BC1860 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(132 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BC1AE9 AS DateTime), CAST(0x0000A2DC00BC1FD2 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(133 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BC4D5F AS DateTime), CAST(0x0000A2DC00BC5B7D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(134 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BC5DBC AS DateTime), CAST(0x0000A2DC00BC60CB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(135 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BC7CFE AS DateTime), CAST(0x0000A2DC00BC9A31 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BC9C5C AS DateTime), CAST(0x0000A2DC00BC9FB5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(137 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BCCA90 AS DateTime), CAST(0x0000A2DC00BCCF9D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(138 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BCE5B6 AS DateTime), CAST(0x0000A2DC00BCEC5D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(139 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BD1954 AS DateTime), CAST(0x0000A2DC00BD2238 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(140 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BD2486 AS DateTime), CAST(0x0000A2DC00BD2D75 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(141 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BDC880 AS DateTime), CAST(0x0000A2DC00BDD3A1 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(142 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BDD5C3 AS DateTime), CAST(0x0000A2DC00BDDBC7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(143 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BE0D5D AS DateTime), CAST(0x0000A2DC00BE16AA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(144 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BE1895 AS DateTime), CAST(0x0000A2DC00BE2207 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(145 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BEABE3 AS DateTime), CAST(0x0000A2DC00BEBCEC AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(146 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BEC629 AS DateTime), CAST(0x0000A2DC00BED14E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(147 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00BF4017 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(148 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00C697C3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(149 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00EBBB21 AS DateTime), CAST(0x0000A2DC00EBCB71 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(150 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00EE95D6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(151 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00EECFEC AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(152 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00EEF308 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(153 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00EF3384 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(154 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00EF792A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(155 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00F04A6D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(156 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00F068AB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(157 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00F0F5A0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(158 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00F248C7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(159 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC00F351BA AS DateTime), CAST(0x0000A2DC00F39AB9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(160 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC010658C9 AS DateTime), CAST(0x0000A2DC0106D8AD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(161 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC015DA631 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(162 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC015F0742 AS DateTime), CAST(0x0000A2DC016470C8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(163 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DD00C3ECF2 AS DateTime), CAST(0x0000A2DD00C3FFAB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(164 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DD00C638A1 AS DateTime), CAST(0x0000A2DD00C665EA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(165 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E101237AF8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(166 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E101248F27 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(167 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E101317387 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(168 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E101318C8E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(169 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E20153E1DB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(170 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E20154345F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(171 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300AF39E1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(172 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300B03931 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(173 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300BC7213 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(174 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300BCC060 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(175 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300BCE7C6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(176 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300BDC082 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(177 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300C02A8B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(178 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300C0C753 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(179 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300C0E04E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(180 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300C11851 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(181 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300C16617 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(182 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300C1BC4C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(183 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E300CE79E2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(184 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400ACF8E2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(185 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400ADEF84 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(186 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400AEAB17 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(187 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400AFE10D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(188 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400BEC94D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(189 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400BEFE14 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(190 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400BF1788 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(191 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400BFFF5C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(192 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400C0B1F5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(193 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400C13B2C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(194 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400C16315 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(195 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E400C2A7C2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(196 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E600A3268B AS DateTime), CAST(0x0000A2E600A34CDE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(197 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E600A72668 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(198 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E600A77746 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(199 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E600A814B3 AS DateTime), CAST(0x0000A2E600A8365B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(200 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E600A93089 AS DateTime), CAST(0x0000A2E600A9B200 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(201 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E600B1EDD3 AS DateTime), CAST(0x0000A2E600B20DCB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(202 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EA00CBD55A AS DateTime), CAST(0x0000A2EA00E3AA1F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(203 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE00A37340 AS DateTime), CAST(0x0000A2EE00A3C3C6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(204 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE00A7581C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(205 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE00AB4DC4 AS DateTime), CAST(0x0000A2EE00AB9DF3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(206 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE00B245CB AS DateTime), CAST(0x0000A2EE00B2B73C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(207 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE00B59533 AS DateTime), CAST(0x0000A2EE00B5BD60 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(208 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE010A60E9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(209 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE010ABC8A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(210 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE010B6413 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(211 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE010BE196 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(212 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE010C4B2E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(213 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE010CCAC1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(214 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE010D03DF AS DateTime), CAST(0x0000A2EE010D12C8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(215 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE010D44B8 AS DateTime), CAST(0x0000A2EE010E962B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(216 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE0113D5AA AS DateTime), CAST(0x0000A2EE01143F05 AS DateTime))
GO
print 'Processed 200 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(217 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2EE0114513D AS DateTime), CAST(0x0000A2EE01184710 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(218 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F100B494D2 AS DateTime), CAST(0x0000A2F100B4C001 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(219 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F100BF24F9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(220 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F100BFABB2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(221 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F100C67B1B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(222 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F100CEA1C4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(223 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F100CF9630 AS DateTime), CAST(0x0000A2F100CFC640 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(224 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300DD5DA7 AS DateTime), CAST(0x0000A2F300DDA683 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(225 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E02C39 AS DateTime), CAST(0x0000A2F300E04D52 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(226 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E08913 AS DateTime), CAST(0x0000A2F300E09C44 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(227 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E13D22 AS DateTime), CAST(0x0000A2F300E15069 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(228 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E21403 AS DateTime), CAST(0x0000A2F300E23B13 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(229 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E27271 AS DateTime), CAST(0x0000A2F300E28977 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(230 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E2B8C5 AS DateTime), CAST(0x0000A2F300E2D158 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(231 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E3EA6A AS DateTime), CAST(0x0000A2F300E41430 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(232 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E48BFF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(233 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E508A1 AS DateTime), CAST(0x0000A2F300E51C19 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(234 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F300E69A13 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(235 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F400CDD8D2 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(236 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F400CF1739 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(237 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F400CF6021 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(238 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F400CFCAA4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(239 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F400D02230 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(240 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F400D18533 AS DateTime), CAST(0x0000A2F400D1BBA4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(241 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F500A9D38B AS DateTime), CAST(0x0000A2F500AA0EFE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(242 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800BD8096 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(243 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800BDAA1E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(244 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800BDE549 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(245 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800BE55C7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(246 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800BEB291 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(247 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800BF50CE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(248 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800C0EE57 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(249 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800C125B5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(250 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800C14576 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(251 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800C2B9D9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(252 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800C2EF95 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(253 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800C4CEF5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(254 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800CA88EC AS DateTime), CAST(0x0000A2F800CB568D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(255 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800CB64BD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(256 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800CD7360 AS DateTime), CAST(0x0000A2F800E1B574 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(257 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E5A782 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(258 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E61D00 AS DateTime), CAST(0x0000A2F800E658C6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(259 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E66B4D AS DateTime), CAST(0x0000A2F800E6A1F0 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(260 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E6AFFF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(261 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E71EDF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(262 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E78C7C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(263 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E80965 AS DateTime), CAST(0x0000A2F800E846F5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(264 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E86BEA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(265 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E8DE40 AS DateTime), CAST(0x0000A2F800E98C66 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(266 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800E996A0 AS DateTime), CAST(0x0000A2F800EB3B86 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(267 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EB76CE AS DateTime), CAST(0x0000A2F800EBF1B9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(268 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC08AC AS DateTime), CAST(0x0000A2F800EC69A2 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(269 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800ED4323 AS DateTime), CAST(0x0000A2F800ED89CB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(270 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EDDECB AS DateTime), CAST(0x0000A2F800EE522B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(271 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EE7F6C AS DateTime), CAST(0x0000A2F800EEBC5D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(272 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EF892D AS DateTime), CAST(0x0000A2F800F0418A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(273 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F092D7 AS DateTime), CAST(0x0000A2F800F126C8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(274 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F202F8 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(275 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F420F4 AS DateTime), CAST(0x0000A2F800F44395 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(276 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F462B0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(277 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F47677 AS DateTime), CAST(0x0000A2F800F49036 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(278 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F4BFDA AS DateTime), CAST(0x0000A2F800F4D901 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(279 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F521DE AS DateTime), CAST(0x0000A2F800F53993 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(280 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F58678 AS DateTime), CAST(0x0000A2F800F59EF7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(281 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F5C682 AS DateTime), CAST(0x0000A2F800F5E02E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(282 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F610E6 AS DateTime), CAST(0x0000A2F800F62AE4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(283 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F64482 AS DateTime), CAST(0x0000A2F800F661FB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(284 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F68581 AS DateTime), CAST(0x0000A2F800F69D5A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(285 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F6AE9E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(286 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F6DE04 AS DateTime), CAST(0x0000A2F800F7093F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(287 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F94791 AS DateTime), CAST(0x0000A2F800F9627E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(288 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800F9B96D AS DateTime), CAST(0x0000A2F800F9E082 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(289 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800FDCE89 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(290 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800FE4777 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(291 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800FE9AC3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(292 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800FEE413 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(293 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800FF4336 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(294 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800FFC8B3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(295 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F801003A1B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(296 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F80100717E AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(297 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F80100E118 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(298 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F9009F5113 AS DateTime), CAST(0x0000A2F9009F7955 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(299 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F900A3899F AS DateTime), CAST(0x0000A2F900A3AC21 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(300 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F900A7E473 AS DateTime), CAST(0x0000A2F900A812FB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(301 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F900A870BF AS DateTime), CAST(0x0000A2F900A8B46A AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(302 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F900AE63F8 AS DateTime), CAST(0x0000A2F900AEB1DB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(303 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F900AF19FD AS DateTime), CAST(0x0000A2F900AF7B8C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(304 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F900C08E26 AS DateTime), CAST(0x0000A2F900C12D7B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(305 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F900C1D18D AS DateTime), CAST(0x0000A2F900C1ED90 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(306 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F900C1FC5B AS DateTime), CAST(0x0000A2F900C35918 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(307 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C04063 AS DateTime), CAST(0x0000A2FB00C12AFB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(308 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C1C48A AS DateTime), CAST(0x0000A2FB00C2D6FA AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(309 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C34CC8 AS DateTime), CAST(0x0000A2FB00C3E9F9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(310 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C5F098 AS DateTime), CAST(0x0000A2FB00C61CCD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(311 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C65291 AS DateTime), CAST(0x0000A2FB00C67DE7 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(312 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C69D85 AS DateTime), CAST(0x0000A2FB00C6CD6F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(313 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C6EA2C AS DateTime), CAST(0x0000A2FB00C708E9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(314 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C7BFA5 AS DateTime), CAST(0x0000A2FB00C80969 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(315 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C84460 AS DateTime), CAST(0x0000A2FB00C87E29 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(316 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C8FD17 AS DateTime), CAST(0x0000A2FB00C9891E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(317 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00C9C344 AS DateTime), CAST(0x0000A2FB00C9EB18 AS DateTime))
GO
print 'Processed 300 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(318 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00CA1865 AS DateTime), CAST(0x0000A2FB00CA603F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(319 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00CB8A2E AS DateTime), CAST(0x0000A2FB00CBBA04 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(320 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00CBE049 AS DateTime), CAST(0x0000A2FB00D661D5 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(321 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00D67FBC AS DateTime), CAST(0x0000A2FB00D6DEEB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(322 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00D6F9BD AS DateTime), CAST(0x0000A2FB00D70DF8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(323 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00D7246B AS DateTime), CAST(0x0000A2FB00D74397 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(324 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00D76FC3 AS DateTime), CAST(0x0000A2FB00D79D36 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(325 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00D7C215 AS DateTime), CAST(0x0000A2FB00D807C6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(326 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00D81E45 AS DateTime), CAST(0x0000A2FB00D861D9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(327 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB00EFCD8D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(328 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB0100E183 AS DateTime), CAST(0x0000A2FB0100FB06 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(329 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB0101187A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(330 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB0102DE1A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(331 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB0103C131 AS DateTime), CAST(0x0000A2FB0103F11B AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(332 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB0117BD74 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(333 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB0117F416 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(334 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB01183C21 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(335 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB0118D452 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(336 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FB011B4A40 AS DateTime), CAST(0x0000A2FB011B7A14 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(337 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FD01169043 AS DateTime), CAST(0x0000A2FD0116A943 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(338 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FD0116E9D1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(339 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FD01182EFF AS DateTime), CAST(0x0000A2FD0118910F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(340 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FD01189E7E AS DateTime), CAST(0x0000A2FD0118B998 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(341 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FD0118D3D9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(342 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FD011B0D2F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(343 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FE00B4CF17 AS DateTime), CAST(0x0000A2FE00B51452 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(344 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FE00B58118 AS DateTime), CAST(0x0000A2FE00B5D543 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(345 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FE00B69229 AS DateTime), CAST(0x0000A2FE00B708D0 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(346 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2FE00BAEB88 AS DateTime), CAST(0x0000A2FE01109692 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(347 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000AFA3F1 AS DateTime), CAST(0x0000A30000AFE848 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(348 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000AFEB9F AS DateTime), CAST(0x0000A30000AFF25C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(349 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000AFF456 AS DateTime), CAST(0x0000A30000B000C4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(350 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000B0A595 AS DateTime), CAST(0x0000A30000B112DD AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(351 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000B2195B AS DateTime), CAST(0x0000A30000B23ABB AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(352 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000B33AB1 AS DateTime), CAST(0x0000A30000B35A0F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(353 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000B36FE1 AS DateTime), CAST(0x0000A30000B3888E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(354 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000B46C92 AS DateTime), CAST(0x0000A30000B4E723 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(355 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000C006A9 AS DateTime), CAST(0x0000A30000C03C7E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(356 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000C15AC5 AS DateTime), CAST(0x0000A30000C18091 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(357 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000C1F87A AS DateTime), CAST(0x0000A30000C21B1C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(358 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000C228F7 AS DateTime), CAST(0x0000A30000C24920 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(359 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000C25B40 AS DateTime), CAST(0x0000A30000C29886 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(360 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000C2B2EE AS DateTime), CAST(0x0000A30000C2EB9C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(361 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000C747C6 AS DateTime), CAST(0x0000A30000C79D05 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(362 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000C7A898 AS DateTime), CAST(0x0000A30000CB9FB8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(363 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000E5410F AS DateTime), CAST(0x0000A30000E5F08D AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(364 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000E611BB AS DateTime), CAST(0x0000A30000E6323E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(365 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000EA7312 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(366 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000EC95F6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(367 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000ED0534 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(368 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000EE2F74 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(369 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30000EF5A30 AS DateTime), CAST(0x0000A30000F03203 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(370 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30001069D30 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(371 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30001071E9C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(372 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A300010749A4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(373 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3000107C78F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(374 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30001080CF0 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(375 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3000113ADBA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(376 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30001145B31 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(377 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3000114D847 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(378 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30001158188 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(379 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3000116DAF9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(380 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100B4771D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(381 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E27C89 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(382 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E4B52F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(383 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E5A497 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(384 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E6296B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(385 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E73756 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(386 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E80948 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(387 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100EF0FC4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(388 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100F007CA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(389 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100F0B7BE AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(390 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100F8A6F9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(391 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100F8F036 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(392 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100F986CF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(393 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100FAF6E9 AS DateTime), CAST(0x0000A30100FB24A6 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(394 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100FB72C1 AS DateTime), CAST(0x0000A30100FBA204 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(395 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100FE0540 AS DateTime), CAST(0x0000A30100FE5B23 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(396 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100FF05C4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(397 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100FFB557 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(398 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3010100B157 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(399 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3010100FE57 AS DateTime), CAST(0x0000A30101015D10 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(400 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3010103956C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(401 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3010103DE9A AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(402 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3010104B394 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(403 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3010105CB99 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(404 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30101164F6C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(405 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200A23C2E AS DateTime), CAST(0x0000A30200A2B1CF AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(406 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200E918CB AS DateTime), CAST(0x0000A30200E9B4F3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(407 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F17101 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(408 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F1D9EB AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(409 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F20B74 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(410 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F2D5D1 AS DateTime), CAST(0x0000A30200F3406E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(411 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F42A8C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(412 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F45BAF AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(413 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F5186C AS DateTime), CAST(0x0000A30200F5696F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(414 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F64F28 AS DateTime), CAST(0x0000A30200F67C4F AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(415 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30200F71989 AS DateTime), CAST(0x0000A30200F799D9 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(416 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3020103E5D5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(417 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A302010482DD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(418 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3020104C57B AS DateTime), NULL)
GO
print 'Processed 400 total records'
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(419 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30201051BC9 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(420 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30201063554 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(421 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3020107194D AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(422 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3020107B5CD AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(423 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30201187801 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(424 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3020118C55C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(425 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30201193D85 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(426 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3020119D393 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(427 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A302011B1052 AS DateTime), CAST(0x0000A302011B4463 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(428 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A302011F084F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(429 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300A0496C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(430 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300A1C81C AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(431 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300A1FD27 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(432 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300A27306 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(433 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300A3BCFA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(434 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300A4D3D5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(435 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300A91A97 AS DateTime), CAST(0x0000A30300A9FC68 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(436 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300AA66BA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(437 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300ABF2B7 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(438 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300AC8903 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(439 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300AD2365 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(440 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300AE6F06 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(441 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300AFD6F4 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(442 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300B0C981 AS DateTime), CAST(0x0000A30300B0E531 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(443 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300B1A4FA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(444 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300B268F6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(445 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300B30E29 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(446 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300B41047 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(447 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300B4D8C3 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(448 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300B695A6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(449 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300B9CF6A AS DateTime), CAST(0x0000A30300BAD8B3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(450 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300BC663F AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(451 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300BD01B6 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(452 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300CE0873 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(453 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300E129CA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(454 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300E2EF58 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(455 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300E55239 AS DateTime), CAST(0x0000A30300E68740 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(456 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300E71C87 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(457 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300E86F3B AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(458 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300E9B8B1 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(459 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300EA34EA AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(460 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300EA8585 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(461 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300EB53D5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(462 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300EC0717 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(463 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300ECF515 AS DateTime), CAST(0x0000A30300EEE1B8 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(464 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300F0F2B5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(465 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30300F1CFCD AS DateTime), CAST(0x0000A30300FF8AD1 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(466 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3030100B79B AS DateTime), CAST(0x0000A303010106D4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(467 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30301018667 AS DateTime), CAST(0x0000A3030101CC3C AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(468 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30301022FB1 AS DateTime), CAST(0x0000A3030102910E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(469 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3030104F925 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(470 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30301058B53 AS DateTime), CAST(0x0000A3030105CBA3 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(471 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3030107C9B3 AS DateTime), CAST(0x0000A30301085396 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(472 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A303010868E5 AS DateTime), NULL)
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(473 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3030108EF35 AS DateTime), CAST(0x0000A30301094807 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(474 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A3030109E541 AS DateTime), CAST(0x0000A303010A3C1E AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(475 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30400DC20F6 AS DateTime), CAST(0x0000A30400DC45CE AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(476 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30400DC7D84 AS DateTime), CAST(0x0000A30400DC9AD4 AS DateTime))
INSERT [Guardian].[LoginHistory] ([Id], [AccountId], [LoginStamp], [LogoutStamp]) VALUES (CAST(477 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30400DCC4CB AS DateTime), CAST(0x0000A30500001A4B AS DateTime))
SET IDENTITY_INSERT [Guardian].[LoginHistory] OFF
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  Table [Invoice].[Payment]    Script Date: 04/07/2014 10:21:11 ******/
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
SET IDENTITY_INSERT [Invoice].[Payment] OFF
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 04/07/2014 10:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[OrganizationUpdate]
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
	
	UPDATE [Organization].Organization
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
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
	@Address Varchar(255) = null,
	@City Varchar(50) = null,
	@StateId Numeric(10,0) = null,
	@Pin Int = null,
	@ContactName Varchar(50) = null,
	@Id  Numeric(10,0) OUTPUT
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
			[Address] = @Address,
			[City] = @City,
			[StateId] = @StateId,
			[Pin] = @Pin,
			[ContactName] = @ContactName
	End
	Else
	Begin
		INSERT INTO [Organization].Organization([Name],[Logo],[LicenceNumber],[Tan],[Address],[City],[StateId],[Pin],[ContactName])
		VALUES(@Name,@Logo,@LicenceNumber,@Tan,@Address,@City,@StateId,@Pin,@ContactName)
   
	End
    
	SET @Id = @@IDENTITY
END' 
END
GO
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  Table [Guardian].[SecurityAnswer]    Script Date: 04/07/2014 10:21:11 ******/
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
/****** Object:  Table [Lodge].[RoomReservation]    Script Date: 04/07/2014 10:21:12 ******/
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
	[NoOfDays] [int] NOT NULL,
	[NoOfPersons] [int] NOT NULL,
	[NoOfRooms] [int] NOT NULL,
	[Description] [varchar](150) NULL,
	[RoomCategoryId] [numeric](10, 0) NULL,
	[RoomTypeId] [numeric](10, 0) NULL,
	[AcRoomPreference] [int] NULL,
	[Advance] [money] NOT NULL,
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
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(48 AS Numeric(10, 0)), CAST(0x0000A19A00000000 AS DateTime), 1, 1, 1, N'1 single bed, AC4', NULL, NULL, NULL, 1000.0000, CAST(0x0000A19500AB1B03 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(51 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), 2, 2, 2, N'1 single bed, AC4', NULL, NULL, NULL, 500.0000, CAST(0x0000A19A01013163 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(52 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), 2, 2, 2, N'1 single bed, AC4', NULL, NULL, NULL, 500.0000, CAST(0x0000A19A010C295B AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(53 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), 2, 2, 2, N'1 single bed, AC4', NULL, NULL, NULL, 500.0000, CAST(0x0000A19A0115A5E2 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(54 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), 2, 2, 2, N'1 single bed, AC4', NULL, NULL, NULL, 500.0000, CAST(0x0000A19A01161C77 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(55 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), 2, 2, 2, N'1 single bed, AC4', NULL, NULL, NULL, 500.0000, CAST(0x0000A19A01166AE6 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(56 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), 2, 2, 2, N'1 single bed, AC4', NULL, NULL, NULL, 500.0000, CAST(0x0000A19A0116C104 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(0x0000A19F00000000 AS DateTime), 2, 2, 2, N'1 single bed, AC4', NULL, NULL, NULL, 500.0000, CAST(0x0000A19A011B6B43 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(58 AS Numeric(10, 0)), CAST(0x0000A1B300000000 AS DateTime), 2, 2, 2, N'1 single bed, AC4', NULL, NULL, NULL, 500.0000, CAST(0x0000A1AE00C26C9A AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(59 AS Numeric(10, 0)), CAST(0x0000A1BB00000000 AS DateTime), 2, 2, 1, N'2 single bed, AC', NULL, NULL, NULL, 350.0000, CAST(0x0000A1B800C11C34 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(61 AS Numeric(10, 0)), CAST(0x0000A2E300B816F4 AS DateTime), 1, 1, 1, N'', NULL, NULL, NULL, 0.0000, CAST(0x0000A2CB00B826F9 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(62 AS Numeric(10, 0)), CAST(0x0000A2CD00BBB264 AS DateTime), 2, 2, 2, N'', NULL, NULL, NULL, 0.0000, CAST(0x0000A2CB00BBC012 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(63 AS Numeric(10, 0)), CAST(0x0000A2DA015F1E54 AS DateTime), 1, 1, 1, N'', NULL, NULL, NULL, 0.0000, CAST(0x0000A2CC015F472B AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(64 AS Numeric(10, 0)), CAST(0x0000A2D001712E8C AS DateTime), 1, 1, 2, N'', NULL, NULL, NULL, 0.0000, CAST(0x0000A2CC01714FF7 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(65 AS Numeric(10, 0)), CAST(0x0000A2D20179C754 AS DateTime), 1, 1, 1, N'', NULL, NULL, NULL, 0.0000, CAST(0x0000A2CC0179E146 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(66 AS Numeric(10, 0)), CAST(0x0000A2E0017A3EDC AS DateTime), 1, 1, 1, N'', NULL, NULL, NULL, 0.0000, CAST(0x0000A2CC017A5AE0 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(67 AS Numeric(10, 0)), CAST(0x0000A2D100A81998 AS DateTime), 1, 1, 1, N'', NULL, NULL, NULL, 0.0000, CAST(0x0000A2CE00A8319A AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(68 AS Numeric(10, 0)), CAST(0x0000A2CF00BBF8B4 AS DateTime), 1, 1, 1, N'', NULL, NULL, NULL, 0.0000, CAST(0x0000A2CE00BC1687 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(69 AS Numeric(10, 0)), CAST(0x0000A2D100CACB3C AS DateTime), 1, 1, 1, N'', CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, 0.0000, CAST(0x0000A2D100CAEEEC AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(70 AS Numeric(10, 0)), CAST(0x0000A2D100CB3BBC AS DateTime), 1, 1, 1, N'', CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, 0.0000, CAST(0x0000A2D100CB6115 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(71 AS Numeric(10, 0)), CAST(0x0000A2D300CB997C AS DateTime), 1, 1, 1, N'', CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, 0.0000, CAST(0x0000A2D100CBBB1B AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(72 AS Numeric(10, 0)), CAST(0x0000A2D5010137A8 AS DateTime), 1, 1, 1, N'', CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, 0.0000, CAST(0x0000A2D501016455 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(73 AS Numeric(10, 0)), CAST(0x0000A2D900C35D48 AS DateTime), 1, 1, 1, N'', CAST(3 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, 0.0000, CAST(0x0000A2D900C38DE0 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(74 AS Numeric(10, 0)), CAST(0x0000A2DA00C40608 AS DateTime), 1, 1, 1, N'', CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, 0.0000, CAST(0x0000A2D900C4233F AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(75 AS Numeric(10, 0)), CAST(0x0000A310015DE570 AS DateTime), 2, 1, 1, N'', CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), 1, 0.0000, CAST(0x0000A2DC015E7160 AS DateTime), CAST(10001 AS Numeric(10, 0)), 1)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(76 AS Numeric(10, 0)), CAST(0x0000A2F400CE67D8 AS DateTime), 1, 1, 1, N'', NULL, NULL, 0, 1000.0000, CAST(0x0000A2F400CE9049 AS DateTime), CAST(10001 AS Numeric(10, 0)), 0)
INSERT [Lodge].[RoomReservation] ([Id], [BookingFrom], [NoOfDays], [NoOfPersons], [NoOfRooms], [Description], [RoomCategoryId], [RoomTypeId], [AcRoomPreference], [Advance], [CreatedDate], [StatusId], [IsCheckedIn]) VALUES (CAST(77 AS Numeric(10, 0)), CAST(0x0000A30100E31AB6 AS DateTime), 1, 1, 1, N'', NULL, NULL, 0, 1000.0000, CAST(0x0000A30100E3054E AS DateTime), CAST(10002 AS Numeric(10, 0)), 1)
SET IDENTITY_INSERT [Lodge].[RoomReservation] OFF
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  Table [Lodge].[RoomTariff]    Script Date: 04/07/2014 10:21:12 ******/
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
SET IDENTITY_INSERT [Lodge].[RoomTariff] OFF
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingTypeUpdate]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingTypeReadAll]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingTypeRead]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingTypeInsert]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingTypeDelete]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingStatusUpdate]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingStatusReadAll]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingStatusRead]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingStatusInsert]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingStatusDelete]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  Table [Lodge].[Building]    Script Date: 04/07/2014 10:21:12 ******/
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
SET IDENTITY_INSERT [Lodge].[Building] OFF
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  Table [Navigator].[Artifact]    Script Date: 04/07/2014 10:21:12 ******/
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
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(60 AS Numeric(10, 0)), N'2009', N'Form:\\Customer\2009\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017997F1 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(61 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2009\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28501799ED6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(62 AS Numeric(10, 0)), N'2010', N'Form:\\Customer\2010\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2850179A5CE AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(63 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2009\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(61 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2850179AB2D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(64 AS Numeric(10, 0)), N'Rakhi Dey', N'Form:\\Customer\Rakhi Dey\', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2850179F764 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CE00BB5759 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(65 AS Numeric(10, 0)), N'Arpan Kar', N'Form:\\Customer\2009\Arpan Kar\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017A54BF AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B5D314 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(66 AS Numeric(10, 0)), N'Biraj', N'Form:\\Customer\2009\Jan\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(61 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017AAFE6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(67 AS Numeric(10, 0)), N'2011', N'Form:\\Customer\2011\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CCAEF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(68 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2011\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(67 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CD6E2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(69 AS Numeric(10, 0)), N'2012', N'Form:\\Customer\2012\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CE730 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(70 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2012\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(69 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CEFA3 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(71 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2012\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(70 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017CF843 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(72 AS Numeric(10, 0)), N'A', N'Form:\\Customer\2012\Jan\01\A\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(71 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017D0151 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A29001647FFF AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(73 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2010\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017DF3C2 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(74 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2010\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(73 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017DFC9C AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(75 AS Numeric(10, 0)), N'jjhjhj', N'Form:\\Customer\2010\Jan\01\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(74 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A285017E4884 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(77 AS Numeric(10, 0)), N'Rupun', N'Form:\\Customer\2012\Jan\01\A\Rupun\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(72 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A288009D5AC7 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A29001648002 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(79 AS Numeric(10, 0)), N'Feb', N'Form:\\Customer\2009\Feb\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2890099159A AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFCF AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(82 AS Numeric(10, 0)), N'2013', N'Form:\\Customer\2013\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A6094E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(83 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2013\Jan\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(82 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A61119 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A6C6FB AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(85 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2013\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A61F04 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00A6C6FC AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(86 AS Numeric(10, 0)), N'Feb', N'Form:\\Customer\2013\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(82 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A00AA6F9E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(87 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2013\Feb\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017BBD91 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(88 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2013\Feb\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017BBD9B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(89 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2013\Feb\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017BE40D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(90 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2013\Feb\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017BE40F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(91 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2013\Feb\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(86 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017C70FF AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(92 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2013\Feb\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(91 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28A017C7100 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(93 AS Numeric(10, 0)), N'02', N'Form:\\Customer\2013\Jan\02\', CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A28B017D741D AS DateTime), CAST(6 AS Numeric(10, 0)), CAST(0x0000A28B017DBD75 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(95 AS Numeric(10, 0)), N'2008', N'Form:\\Customer\2008\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B5014F9D41 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(96 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2008\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B5014FA403 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(97 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2008\Jan\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(96 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B5014FA405 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(98 AS Numeric(10, 0)), N'Sourav', N'Form:\\Customer\2008\Sourav\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B501604D26 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(99 AS Numeric(10, 0)), N'Sourav', N'Form:\\Customer\2009\Sourav\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2B501611EC8 AS DateTime), CAST(11 AS Numeric(10, 0)), CAST(0x0000A2B501619F71 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(100 AS Numeric(10, 0)), N'2007', N'Form:\\Customer\2007\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B3DDB5 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(101 AS Numeric(10, 0)), N'Jan', N'Form:\\Customer\2007\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B3EA79 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(102 AS Numeric(10, 0)), N'Arpan', N'Form:\\Customer\2007\Arpan\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B42477 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B634EA AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(103 AS Numeric(10, 0)), N'2014', N'Form:\\Room Reservation\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B434F0 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(104 AS Numeric(10, 0)), N'2013', N'Form:\\Room Reservation\2013\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B43D2C AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(105 AS Numeric(10, 0)), N'Jan', N'Form:\\Room Reservation\2014\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B44857 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(106 AS Numeric(10, 0)), N'Feb', N'Form:\\Room Reservation\2014\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B45388 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(107 AS Numeric(10, 0)), N'sss', N'Form:\\Room Reservation\sss\', CAST(2 AS Numeric(2, 0)), CAST(5 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00B82EFA AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CE00BB4A02 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(108 AS Numeric(10, 0)), N'Biraj', N'Form:\\Room Reservation\2014\Biraj\', CAST(2 AS Numeric(2, 0)), CAST(4 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CB00BBC4B3 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC015F0B60 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(109 AS Numeric(10, 0)), N'Arpan', N'Form:\\Room Reservation\2014\Arpan\', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC015F4C13 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC01606370 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(110 AS Numeric(10, 0)), N'bbbb', N'Form:\\Room Reservation\2014\bbbb\', CAST(2 AS Numeric(2, 0)), CAST(11 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC01715B2E AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC0106A6F4 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(111 AS Numeric(10, 0)), N'aaaa', N'Form:\\Room Reservation\2014\aaaa\', CAST(2 AS Numeric(2, 0)), CAST(5 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC0179E548 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CE00B7AEEA AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(112 AS Numeric(10, 0)), N'Rakhi', N'Form:\\Room Reservation\2014\Rakhi\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(103 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CC017A6021 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CF00C01374 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(116 AS Numeric(10, 0)), N'Arpan Kar', N'Form:\\Customer\2011\Arpan Kar\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(67 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2CE0103BD28 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(117 AS Numeric(10, 0)), N'Arpan Booking', N'Form:\\Room Reservation\Arpan Booking\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CAF8D5 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(118 AS Numeric(10, 0)), N'New', N'Form:\\Room Reservation\New\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CB6545 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(119 AS Numeric(10, 0)), N'aaaa', N'Form:\\Room Reservation\aaaa\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CBBFA0 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC010683F8 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(120 AS Numeric(10, 0)), N'Saptorshi', N'Form:\\Customer\Saptorshi\', CAST(2 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CC4AA5 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900A626C6 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(121 AS Numeric(10, 0)), N'New Form', N'Form:\\Customer\2010\New Form\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D100CCA2F5 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(122 AS Numeric(10, 0)), N'2014', N'Form:\\Check In\2014\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D5010083C1 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(123 AS Numeric(10, 0)), N'Jan', N'Form:\\Check In\2014\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(122 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D501009982 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(124 AS Numeric(10, 0)), N'Correct Reservation', N'Form:\\Room Reservation\Correct Reservation\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D5010170F6 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(125 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2009\Feb\01\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB250C AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFD2 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(126 AS Numeric(10, 0)), N'02', N'Form:\\Customer\2009\Feb\02\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB2B4D AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFD5 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(127 AS Numeric(10, 0)), N'03', N'Form:\\Customer\2009\Feb\03\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB306C AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFD8 AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(128 AS Numeric(10, 0)), N'04', N'Form:\\Customer\2009\Feb\04\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB3593 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFDB AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(129 AS Numeric(10, 0)), N'05', N'Form:\\Customer\2009\Feb\05\', CAST(1 AS Numeric(2, 0)), CAST(3 AS Numeric(4, 0)), CAST(79 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB3B19 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E7CFDD AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(130 AS Numeric(10, 0)), N'2012', N'Form:\\Room Reservation\2012\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900BB56A5 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(131 AS Numeric(10, 0)), N'January', N'Form:\\Room Reservation\2012\January\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C352AA AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(132 AS Numeric(10, 0)), N'New', N'Form:\\Room Reservation\2012\New\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C3FB3B AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(133 AS Numeric(10, 0)), N'New', N'Form:\\Room Reservation\2013\New\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(104 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C45BCC AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(134 AS Numeric(10, 0)), N'Jan', N'Form:\\Room Reservation\2013\Jan\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(104 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C466BC AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(135 AS Numeric(10, 0)), N'Feb', N'Form:\\Room Reservation\2013\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(104 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900C4BA59 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(136 AS Numeric(10, 0)), N'Feb', N'Form:\\Customer\2010\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E8077D AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(137 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2010\Feb\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80780 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(138 AS Numeric(10, 0)), N'02', N'Form:\\Customer\2010\Feb\02\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80781 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(139 AS Numeric(10, 0)), N'03', N'Form:\\Customer\2010\Feb\03\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80781 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(140 AS Numeric(10, 0)), N'04', N'Form:\\Customer\2010\Feb\04\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80782 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(141 AS Numeric(10, 0)), N'05', N'Form:\\Customer\2010\Feb\05\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(136 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900E80782 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(142 AS Numeric(10, 0)), N'2013', N'Form:\\Check In\2013\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D900F538EC AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(143 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2008\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2D90106FE55 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(144 AS Numeric(10, 0)), N'Mar', N'Form:\\Customer\2009\Mar\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(60 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DA00886492 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(145 AS Numeric(10, 0)), N'New Form', N'Form:\\Customer\New Form\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC015E50A4 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(146 AS Numeric(10, 0)), N'New Form', N'Form:\\Room Reservation\New Form\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC015E717F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(147 AS Numeric(10, 0)), N'Santro', N'Form:\\Check In\2014\Santro\', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(122 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2DC015EC4CB AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(148 AS Numeric(10, 0)), N'2', N'Form:\\Customer\2', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A2E600A9A0A3 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(149 AS Numeric(10, 0)), N'20-04', N'Form:\\Room Reservation\2012\20-04', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(130 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F400CE9BE3 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(150 AS Numeric(10, 0)), N'Feb', N'Form:\\Customer\2008\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC327F AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(151 AS Numeric(10, 0)), N'March', N'Form:\\Customer\2008\March\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(95 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC400E AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(152 AS Numeric(10, 0)), N'01', N'Form:\\Customer\2008\March\01\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(151 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC56E8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(153 AS Numeric(10, 0)), N'02', N'Form:\\Customer\2008\March\02\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(151 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EC64C8 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(154 AS Numeric(10, 0)), N'03', N'Form:\\Customer\2013\Jan\03\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(83 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800EFCCBD AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(155 AS Numeric(10, 0)), N'Feb', N'Form:\\Customer\2007\Feb\', CAST(1 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), CAST(100 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A2F800FF7567 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(156 AS Numeric(10, 0)), N'New Form (1)', N'Form:\\Room Reservation\New Form (1)', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E30A39 AS DateTime), NULL, NULL)
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(157 AS Numeric(10, 0)), N'Today', N'Form:\\Check In\2014\Today', CAST(2 AS Numeric(2, 0)), CAST(2 AS Numeric(4, 0)), CAST(122 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E32358 AS DateTime), CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E32EBA AS DateTime))
INSERT [Navigator].[Artifact] ([Id], [FileName], [Path], [Style], [Version], [ParentId], [CreatedByUserId], [CreatedAt], [ModifiedByUserId], [ModifiedAt]) VALUES (CAST(158 AS Numeric(10, 0)), N'New Form', N'Form:\\Invoice\New Form', CAST(2 AS Numeric(2, 0)), CAST(1 AS Numeric(4, 0)), NULL, CAST(1 AS Numeric(10, 0)), CAST(0x0000A30100E48981 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Navigator].[Artifact] OFF
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  Table [Utility].[Appointment]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  Table [Customer].[Customer]    Script Date: 04/07/2014 10:21:12 ******/
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
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(6 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), N'Arpan', N'', N'Kar', N'#6 S.K. Apts, Wind Tunnel Road
Bangalore-1', CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560017 AS Numeric(10, 0)), N'arpan.kar@3i-infotech.com', CAST(4 AS Numeric(10, 0)), N'12345ADRS')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'biraj', N'', N'', N'dasd', CAST(1 AS Numeric(10, 0)), N'asd', CAST(569874 AS Numeric(10, 0)), N'ccc@mm.com', CAST(2 AS Numeric(10, 0)), N'ASedd')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(30 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(40 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), N'Assam1', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(41 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), N'Assam1', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(42 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), N'Assam1', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(43 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), N'Assam12', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(44 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj-CheckIn', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), N'Assam12', CAST(560017 AS Numeric(10, 0)), N'biraj.dhekial@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'AIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(45 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Silvia', N'Kumar', N'Dhekial', N'#6 S.K. Apts, Wind Tunnel Road', CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(560017 AS Numeric(10, 0)), N'b.dk@3i-infotech.com', CAST(1 AS Numeric(10, 0)), N'BIOPD6173B')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(57 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Rakhi', N'Dey', N'Kar', N'Vijaya Nilaya1', CAST(1 AS Numeric(10, 0)), N'Bangalore', CAST(980765 AS Numeric(10, 0)), N'rakhi.dey@mnu.com', CAST(2 AS Numeric(10, 0)), N'NMH765NB6')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(58 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Arpan', N'', N'Kar', N'Vijaya Nilaya', CAST(3 AS Numeric(10, 0)), N'Bangalore', CAST(986543 AS Numeric(10, 0)), N'arpan@dfrt.com', CAST(2 AS Numeric(10, 0)), N'JU897NH6')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(59 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Biraj', N'', N'Dhekial', N'BTYUI', CAST(1 AS Numeric(10, 0)), N'Bangaore', CAST(786534 AS Numeric(10, 0)), N'biraj@jhihoi.com', CAST(2 AS Numeric(10, 0)), N'MN678YT1')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(62 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), N'Rupun', N'', N'', N'Boalia, Garia', CAST(3 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'rupun@binaff.com', CAST(5 AS Numeric(10, 0)), N'NM675ER7')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(63 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), N'Sourav', N'', N'', N'Sonarpure', CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(0 AS Numeric(10, 0)), N'', CAST(1 AS Numeric(10, 0)), N'mmmm1234t')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(64 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Sourav', N'', N'', N'Sonarpur', CAST(1 AS Numeric(10, 0)), N'Kolkata', CAST(0 AS Numeric(10, 0)), N'', CAST(2 AS Numeric(10, 0)), N'oi9875y6')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(65 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Arpan', N'', N'', N'Garia', CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(0 AS Numeric(10, 0)), N'', CAST(2 AS Numeric(10, 0)), N'OO00po98i')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(66 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'AAA', N'', N'', N'AAAA', CAST(3 AS Numeric(10, 0)), N'AAAA', CAST(123456 AS Numeric(10, 0)), N'aa@aa.aaa', CAST(2 AS Numeric(10, 0)), N'po0987')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(67 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Arpan', N'', N'Kar', N'Boalia, Garia', CAST(8 AS Numeric(10, 0)), N'Kolkata', CAST(700084 AS Numeric(10, 0)), N'arpan.forum@gmail.com', CAST(2 AS Numeric(10, 0)), N'ALPK082LKUS')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(68 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Saptorshi', N'', N'Kar', N'Thane', CAST(8 AS Numeric(10, 0)), N'Mumbai', CAST(0 AS Numeric(10, 0)), N'sapto.kar@gmail.kar', CAST(2 AS Numeric(10, 0)), N'MNY675M')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(69 AS Numeric(10, 0)), CAST(4 AS Numeric(10, 0)), N'BBB', N'', N'', N'NKL', CAST(3 AS Numeric(10, 0)), N'HKJ', CAST(0 AS Numeric(10, 0)), N'aaaaaaa@hvhg.com', CAST(2 AS Numeric(10, 0)), N'klo09jk')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(70 AS Numeric(10, 0)), CAST(6 AS Numeric(10, 0)), N'Santro', N'', N'', N'ADDD', CAST(3 AS Numeric(10, 0)), N'SADE', CAST(0 AS Numeric(10, 0)), N'', CAST(1 AS Numeric(10, 0)), N'lk78yutg')
INSERT [Customer].[Customer] ([Id], [InitialId], [FirstName], [MiddleName], [LastName], [Address], [StateId], [City], [Pin], [Email], [IdentityProofId], [IdentityProofName]) VALUES (CAST(71 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), N'Test', N'', N'', N'jhijhih', CAST(3 AS Numeric(10, 0)), N'jkjkj', CAST(908767 AS Numeric(10, 0)), N'aa@aaaa.com', CAST(2 AS Numeric(10, 0)), N'jkj5hhv')
SET IDENTITY_INSERT [Customer].[Customer] OFF
/****** Object:  Table [Organization].[ContactNumber]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 04/07/2014 10:21:12 ******/
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
/****** Object:  Table [Organization].[Email]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  Table [Organization].[Fax]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Invoice].[Insert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  Table [Invoice].[InvoiceTaxation]    Script Date: 04/07/2014 10:21:13 ******/
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
SET IDENTITY_INSERT [Invoice].[InvoiceTaxation] OFF
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentRead]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 04/07/2014 10:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerUpdate]
	(  
		@Id  Numeric(10,0),
		@InitialId Numeric(10,0),
		@FirstName Varchar(50),
		@MiddleName Varchar(50),
		@LastName Varchar(50),
		@Address Varchar(255),
		@StateId Numeric(10,0),
		@City Varchar(50),
		@Pin Int,
		@Email Varchar(50),
		@IdentityProofId Numeric(10,0),
		@IdentityProofName Varchar(50)	
	)
	AS
	BEGIN	
		IF @InitialId = 0
		Begin
			Set @InitialId = null
		End

		IF @IdentityProofId = 0
		Begin
			Set @IdentityProofId = null
		End
	
		UPDATE Customer.Customer
		Set [InitialId] = @InitialId,
			[FirstName] = @FirstName,
			[MiddleName] = @MiddleName,
			[LastName] = @LastName,
			[Address] = @Address,
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
/****** Object:  Table [AutoTourism].[CustomerRoomReservationLink]    Script Date: 04/07/2014 10:21:13 ******/
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
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(19 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(61 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(20 AS Numeric(10, 0)), CAST(59 AS Numeric(10, 0)), CAST(62 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(63 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(23 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(24 AS Numeric(10, 0)), CAST(57 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(25 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(61 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(26 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(67 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(27 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(61 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(28 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)), CAST(68 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(29 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(69 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(30 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)), CAST(70 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(31 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(71 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(32 AS Numeric(10, 0)), CAST(58 AS Numeric(10, 0)), CAST(72 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(33 AS Numeric(10, 0)), CAST(68 AS Numeric(10, 0)), CAST(73 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(34 AS Numeric(10, 0)), CAST(68 AS Numeric(10, 0)), CAST(74 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(36 AS Numeric(10, 0)), CAST(70 AS Numeric(10, 0)), CAST(75 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(37 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(76 AS Numeric(10, 0)))
INSERT [AutoTourism].[CustomerRoomReservationLink] ([Id], [CustomerId], [RoomReservationId]) VALUES (CAST(40 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)))
SET IDENTITY_INSERT [AutoTourism].[CustomerRoomReservationLink] OFF
/****** Object:  Table [Customer].[CustomerContactNumber]    Script Date: 04/07/2014 10:21:13 ******/
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
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(281 AS Numeric(10, 0)), N'+91-9886478746', CAST(6 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(282 AS Numeric(10, 0)), N'+91-33-24329896', CAST(6 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(285 AS Numeric(10, 0)), N'+91-55-76340978', CAST(59 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(286 AS Numeric(10, 0)), N'+91-7645230978', CAST(59 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(307 AS Numeric(10, 0)), N'+91-99-87963465', CAST(57 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(308 AS Numeric(10, 0)), N'+91-9234587654', CAST(57 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(313 AS Numeric(10, 0)), N'+91-44-24328896', CAST(67 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(314 AS Numeric(10, 0)), N'+91-9833078746', CAST(67 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(317 AS Numeric(10, 0)), N'+91-8765983465', CAST(66 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(318 AS Numeric(10, 0)), N'+91-12-09563852', CAST(66 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(323 AS Numeric(10, 0)), N'+91-23-12346543', CAST(69 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(324 AS Numeric(10, 0)), N'+91-8976509786', CAST(69 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(325 AS Numeric(10, 0)), N'+91-88-78654367', CAST(58 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(326 AS Numeric(10, 0)), N'+91-8745630987', CAST(58 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(331 AS Numeric(10, 0)), N'+91-11-78561234', CAST(68 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(332 AS Numeric(10, 0)), N'+91-9845754322', CAST(68 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(337 AS Numeric(10, 0)), N'+91-343-34326787', CAST(70 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(338 AS Numeric(10, 0)), N'+91-5432098745', CAST(70 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(339 AS Numeric(10, 0)), N'+91-87-89876765', CAST(71 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(340 AS Numeric(10, 0)), N'+91-8978676543', CAST(71 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(347 AS Numeric(10, 0)), N'+91-22-22222222', CAST(65 AS Numeric(10, 0)))
INSERT [Customer].[CustomerContactNumber] ([Id], [Number], [CustomerId]) VALUES (CAST(348 AS Numeric(10, 0)), N'+91-5555676798', CAST(65 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Customer].[CustomerContactNumber] OFF
/****** Object:  Table [Customer].[CustomerArtifact]    Script Date: 04/07/2014 10:21:13 ******/
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
SET IDENTITY_INSERT [Customer].[CustomerArtifact] OFF
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 04/07/2014 10:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerReadAll]
	As
	Begin
		Select Id,InitialId,FirstName,MiddleName,LastName,
			[Address],StateId,City,Pin,Email,IdentityProofId,
			IdentityProofName 
		From Customer.Customer
	End
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 04/07/2014 10:21:13 ******/
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
		Select  Id,InitialId,FirstName,MiddleName,LastName,
				[Address],StateId,City,Pin,Email,IdentityProofId,
				IdentityProofName 
		From Customer.Customer
		Where Id = @Id
	 End
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 04/07/2014 10:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[CustomerInsert]
	(  
		@InitialId Numeric(10,0),
		@FirstName Varchar(50),
		@MiddleName Varchar(50),
		@LastName Varchar(50),
		@Address Varchar(255),
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
		IF @InitialId = 0
		Begin
			Set @InitialId = null
		End

		IF @IdentityProofId = 0
		Begin
			Set @IdentityProofId = null
		End
	
		INSERT INTO Customer.Customer([InitialId],[FirstName],[MiddleName],[LastName],
			[Address],[StateId],[City],[Pin],[Email],[IdentityProofId],[IdentityProofName])
		VALUES(@InitialId,@FirstName,@MiddleName,@LastName,@Address,@StateId,@City,@Pin,@Email,@IdentityProofId,@IdentityProofName)
   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 04/07/2014 10:21:13 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  Table [Invoice].[Artifact]    Script Date: 04/07/2014 10:21:14 ******/
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
SET IDENTITY_INSERT [Invoice].[Artifact] OFF
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  Table [Navigator].[ArtifactModuleLink]    Script Date: 04/07/2014 10:21:14 ******/
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
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(87 AS Numeric(10, 0)), CAST(105 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(88 AS Numeric(10, 0)), CAST(106 AS Numeric(10, 0)), CAST(8 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
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
INSERT [Navigator].[ArtifactModuleLink] ([Id], [ArtifactId], [ModuleId], [Category]) VALUES (CAST(105 AS Numeric(10, 0)), CAST(123 AS Numeric(10, 0)), CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
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
SET IDENTITY_INSERT [Navigator].[ArtifactModuleLink] OFF
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 04/07/2014 10:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactInsert]
(  
	@FileName Varchar(50),
	@Path Varchar(50),
	@Style Numeric(2,0),
	@ParentId Numeric(10, 0),
	@CreatedByUserId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Navigator.Artifact([FileName], [Path], Style, [Version], ParentId, CreatedByUserId, CreatedAt)
	VALUES(@FileName, @Path, @Style, 1, @ParentId, @CreatedByUserId, GETDATE())
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 04/07/2014 10:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactReadAll]
AS
BEGIN	
	SELECT Id, [FileName], [Path], Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 04/07/2014 10:21:14 ******/
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
	SELECT Id, [FileName], [Path], Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact
	WHERE Id = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 04/07/2014 10:21:14 ******/
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
	@Path Varchar(50),
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
/****** Object:  Table [Lodge].[BuildingFloor]    Script Date: 04/07/2014 10:21:14 ******/
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
SET IDENTITY_INSERT [Lodge].[BuildingFloor] OFF
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  Table [Lodge].[CheckIn]    Script Date: 04/07/2014 10:21:14 ******/
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
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(11 AS Numeric(10, 0)), CAST(0x0000A310015DE570 AS DateTime), 0.0000, CAST(0x0000A2DC015EA92E AS DateTime), CAST(75 AS Numeric(10, 0)), CAST(10001 AS Numeric(10, 0)), NULL)
INSERT [Lodge].[CheckIn] ([Id], [CheckInDate], [Advance], [CreatedDate], [ReservationId], [StatusId], [InvoiceNumber]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(0x0000A30100E31AB6 AS DateTime), 1000.0000, CAST(0x0000A30100E31E54 AS DateTime), CAST(77 AS Numeric(10, 0)), CAST(10002 AS Numeric(10, 0)), N'INVO-02-04-201413524')
SET IDENTITY_INSERT [Lodge].[CheckIn] OFF
/****** Object:  Table [Navigator].[CatalogueModuleLink]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  Table [Lodge].[BuildingClosureReason]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 04/07/2014 10:21:14 ******/
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
		@NoOfDays Int,
		@NoOfPersons Int,
		@NoOfRooms	Int,
		@Description Varchar(150),
		@Advance Money,
		@RoomCategoryId Numeric(10,0) = Null,
		@RoomTypeId Numeric(10,0) = Null,
		@ACPreference Int
	)
	AS
	BEGIN
		
		UPDATE [Lodge].[RoomReservation]
		SET				
			[BookingFrom] = @ActivityDate,
			[StatusId] = @StatusId,
			[NoOfDays] = @NoOfDays,
			[NoOfPersons] = @NoOfPersons,
			[NoOfRooms] = @NoOfRooms,
			[Description] = @Description,
			[Advance] = @Advance,
			[RoomCategoryId] = @RoomCategoryId,
			[RoomTypeId] = @RoomTypeId,
			[AcRoomPreference] = @ACPreference
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  Table [Lodge].[RoomReservationArtifact]    Script Date: 04/07/2014 10:21:14 ******/
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
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(3 AS Numeric(10, 0)), NULL, CAST(105 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[RoomReservationArtifact] ([Id], [RoomReservationId], [ArtifactId], [Category]) VALUES (CAST(4 AS Numeric(10, 0)), NULL, CAST(106 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
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
SET IDENTITY_INSERT [Lodge].[RoomReservationArtifact] OFF
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 04/07/2014 10:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--select * from [Lodge].[RoomReservation]

Create PROCEDURE [Lodge].[RoomReservationReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,
			[BookingFrom],
			[StatusId],
			[NoOfDays],
			[NoOfPersons],
			[NoOfRooms],
			[Description],
			[Advance],
			[CreatedDate]
		FROM [Lodge].RoomReservation
		
	END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 04/07/2014 10:21:14 ******/
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
			Id,
			[BookingFrom],
			[StatusId],
			[NoOfDays],
			[NoOfPersons],
			[NoOfRooms],
			[Description],
			[Advance],
			[CreatedDate],
			[IsCheckedIn],
			[RoomCategoryId],
			[RoomTypeId],
			[AcRoomPreference]			
		FROM [Lodge].RoomReservation
		WHERE Id = @Id   
		
	END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 04/07/2014 10:21:14 ******/
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
		@NoOfDays Int,
		@NoOfPersons Int,
		@NoOfRooms	Int,
		@Description Varchar(150),
		@Advance Money,
		@RoomCategoryId Numeric(10,0) = Null,
		@RoomTypeId Numeric(10,0) = Null,
		@ACPreference Int,
		@Id  Numeric(10,0) OUTPUT	
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].[RoomReservation]([BookingFrom],[StatusId],[NoOfDays],[NoOfPersons],[NoOfRooms],[Description],[Advance],[RoomCategoryId],[RoomTypeId],[AcRoomPreference],[CreatedDate])
		VALUES(@ActivityDate,@StatusId,@NoOfDays,@NoOfPersons,@NoOfRooms,@Description,@Advance,@RoomCategoryId,@RoomTypeId,@ACPreference,GETDATE())
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 04/07/2014 10:21:14 ******/
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
/****** Object:  StoredProcedure [Invoice].[LineItemUpdate]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[LineItemReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[LineItemReadAll]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[LineItemRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[LineItemInsert]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[LineItemDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsTariffDeletable]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[IsPaymentTypeDeletable]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  Table [Navigator].[ReportModuleLink]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentUpdate]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentReadAll]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentInsert]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  Table [Guardian].[ProfileContactNumber]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[UpdateInvoiceNumber]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  Table [Lodge].[Room]    Script Date: 04/07/2014 10:21:15 ******/
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
SET IDENTITY_INSERT [Lodge].[Room] OFF
/****** Object:  StoredProcedure [Lodge].[ReadReservationFormForArtifact]    Script Date: 04/07/2014 10:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadReservationFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Lodge].[ReadReservationFormForArtifact]
(
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	
	SELECT 
		Id,
		RoomReservationId
	FROM Lodge.RoomReservationArtifact
	WHERE ArtifactId = @ArtifactId
		AND Category =  @Category
	
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[ReadInvoiceFormForArtifact]    Script Date: 04/07/2014 10:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadInvoiceFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [Invoice].[ReadInvoiceFormForArtifact]
(
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	
	SELECT 
		Id,
		InvoiceId
	FROM [Invoice].Artifact
	WHERE ArtifactId = @ArtifactId
		AND Category =  @Category
	
END


' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReadFormForArtifact]    Script Date: 04/07/2014 10:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReadFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[ReadFormForArtifact]
(
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	
	SELECT 
		Id,
		CustomerId
	FROM Customer.CustomerArtifact
	WHERE ArtifactId = @ArtifactId
		AND Category =  @Category
	
END

--Customer.ReadFormForArtifact 1
' 
END
GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  Table [Lodge].[CheckInArtifact]    Script Date: 04/07/2014 10:21:15 ******/
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
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(2 AS Numeric(10, 0)), NULL, CAST(123 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(3 AS Numeric(10, 0)), NULL, CAST(142 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), CAST(147 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
INSERT [Lodge].[CheckInArtifact] ([Id], [CheckInId], [ArtifactId], [Category]) VALUES (CAST(5 AS Numeric(10, 0)), CAST(12 AS Numeric(10, 0)), CAST(157 AS Numeric(10, 0)), CAST(1 AS Numeric(1, 0)))
SET IDENTITY_INSERT [Lodge].[CheckInArtifact] OFF
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonReadForParent]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonRead]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonInsert]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 04/07/2014 10:21:15 ******/
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
	SELECT A.Id, [FileName], [Path], Style, [Version], ParentId, 
		CreatedAt, CreatedByUserId,
		P1.FirstName AS CreatedByFirstName, P1.MiddleName AS CreatedByMiddleName, P1.LastName AS CreatedByLastName, 
		ModifiedAt, ModifiedByUserId,
		P2.FirstName AS ModifiedByFirstName, P2.MiddleName AS ModifiedByMiddleName, P2.LastName AS ModifiedByLastName,
		M.Id ModuleId, M.Code ModuleCode, M.Name ModuleName, Category
	FROM (SELECT * FROM Navigator.Artifact WHERE [FileName] LIKE ''%'' + @FileName + ''%'') As A
	LEFT OUTER JOIN Guardian.[Profile] AS P1 ON A.CreatedByUserId = P1.UserId
	LEFT OUTER JOIN Guardian.[Profile] AS P2 ON A.ModifiedByUserId = P2.UserId
	INNER JOIN Navigator.ArtifactModuleLink AS AML ON ArtifactId = A.Id
	INNER JOIN License.Module AS M ON M.Id = AML.ModuleId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkReadForModule]    Script Date: 04/07/2014 10:21:15 ******/
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
	SELECT ArtifactId
	FROM Navigator.ArtifactModuleLink
	WHERE ModuleId = @ModuleId
		AND Category = @Category
END
' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkReadForArtifact]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactModuleLinkInsertForModule]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 04/07/2014 10:21:15 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  Table [AutoTourism].[CustomerRoomCheckInLink]    Script Date: 04/07/2014 10:21:16 ******/
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
SET IDENTITY_INSERT [AutoTourism].[CustomerRoomCheckInLink] OFF
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[DeleteReservationFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[DeleteReservationFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





CREATE PROCEDURE [Lodge].[DeleteReservationFormForArtifact]
(
 @Id Numeric(10,0)
)
AS
BEGIN
 
 DELETE   
 FROM [Lodge].[RoomReservationArtifact]
 WHERE ArtifactId = @Id   
   
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[DeleteInvoiceFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[DeleteInvoiceFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Invoice].[DeleteInvoiceFormForArtifact]
(
 @Id Numeric(10,0)
)
AS
BEGIN
 
 DELETE   
 FROM [Invoice].[Artifact]
 WHERE ArtifactId = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[DeleteFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[DeleteFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[DeleteFormForArtifact]
(
 @Id Numeric(10,0)
)
AS
BEGIN
 
 DELETE   
 FROM [Customer].CustomerArtifact
 WHERE ArtifactId = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[InsertReservationFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[InsertReservationFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Lodge].[InsertReservationFormForArtifact]
(
        @ReservationId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO Lodge.RoomReservationArtifact([RoomReservationId],[ArtifactId], [Category])
        VALUES(@ReservationId, @ArtifactId, @Category)
 
END

' 
END
GO
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InsertInvoiceFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Invoice].[InsertInvoiceFormForArtifact]
(
        @InvoiceId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO [Invoice].Artifact([InvoiceId],[ArtifactId],[Category])
        VALUES(@InvoiceId, @ArtifactId, @Category)
 
END


' 
END
GO
/****** Object:  StoredProcedure [Customer].[InsertFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[InsertFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[InsertFormForArtifact]
(
        @CustomerId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO Customer.CustomerArtifact([CustomerId],[ArtifactId], [Category])
        VALUES(@CustomerId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[InsertCheckInFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[InsertCheckInFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [Lodge].[InsertCheckInFormForArtifact]
(
        @CheckInId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO Lodge.CheckInArtifact([CheckInId],[ArtifactId], [Category])
        VALUES(@CheckInId, @ArtifactId, @Category)
 
END

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[DeleteCheckInFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[DeleteCheckInFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [Lodge].[DeleteCheckInFormForArtifact]
(
 @Id Numeric(10,0)
)
AS
BEGIN
 
 DELETE   
 FROM [Lodge].[CheckInArtifact]
 WHERE ArtifactId = @Id   
   
END

' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsBuildingFloorDeletable]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsRoomTypeDeletable]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsRoomStatusDeletable]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsRoomCategoryDeletable]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsRoomBuildingDeletable]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[ReadCheckInFormForArtifact]    Script Date: 04/07/2014 10:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadCheckInFormForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [Lodge].[ReadCheckInFormForArtifact]
(
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	
	SELECT 
		Id,
		CheckInId
	FROM Lodge.CheckInArtifact
	WHERE ArtifactId = @ArtifactId
		AND Category =  @Category
	
END

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  Table [Lodge].[RoomClosureReason]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  Table [Lodge].[RoomImage]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  Table [Lodge].[RoomReservationDetails]    Script Date: 04/07/2014 10:21:16 ******/
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
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(62 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(63 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(8 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(64 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(9 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(65 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(66 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(13 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(67 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(14 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(61 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(15 AS Numeric(10, 0)), CAST(2 AS Numeric(10, 0)), CAST(72 AS Numeric(10, 0)))
INSERT [Lodge].[RoomReservationDetails] ([Id], [RoomId], [ReservationId]) VALUES (CAST(18 AS Numeric(10, 0)), CAST(1 AS Numeric(10, 0)), CAST(77 AS Numeric(10, 0)))
SET IDENTITY_INSERT [Lodge].[RoomReservationDetails] OFF
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 04/07/2014 10:21:16 ******/
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
			R.Id,
			[BookingFrom],
			[StatusId],
			[NoOfDays],
			[NoOfPersons],
			[NoOfRooms],
			[Description],
			[Advance],
			[CreatedDate],
			IsCheckedIn,
			R.RoomCategoryId,
			R.RoomTypeId,
			R.AcRoomPreference,
			RRD.RoomId AS ProductId
		FROM [Lodge].RoomReservation R
		LEFT OUTER JOIN Lodge.RoomReservationDetails RRD on R.Id = RRD.ReservationId
		Where R.statusId = @StatusId
		And cast(convert(char(11), R.BookingFrom, 113) as datetime) 
		Between cast(convert(char(11), @StartDate, 113) as datetime) 		 
		And cast(convert(char(11), @EndDate, 113) as datetime)		
		--And R.IsCheckedIn = 0
		order by R.Id,RRD.ReservationId
	End

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsRead]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsCheckInDeletable]    Script Date: 04/07/2014 10:21:16 ******/
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
/****** Object:  ForeignKey [FK_UserRole_Account]    Script Date: 04/07/2014 10:21:10 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] CHECK CONSTRAINT [FK_UserRole_Account]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 04/07/2014 10:21:10 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [Guardian].[Role] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_UserRole_Role]') AND parent_object_id = OBJECT_ID(N'[Guardian].[UserRole]'))
ALTER TABLE [Guardian].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_Profile_Account]    Script Date: 04/07/2014 10:21:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] CHECK CONSTRAINT [FK_Profile_Account]
GO
/****** Object:  ForeignKey [FK_Profile_Initial]    Script Date: 04/07/2014 10:21:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Initial] FOREIGN KEY([Initial])
REFERENCES [Configuration].[Initial] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_Profile_Initial]') AND parent_object_id = OBJECT_ID(N'[Guardian].[Profile]'))
ALTER TABLE [Guardian].[Profile] CHECK CONSTRAINT [FK_Profile_Initial]
GO
/****** Object:  ForeignKey [FK_LineItem_Invoice]    Script Date: 04/07/2014 10:21:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_LineItem_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[LineItem]'))
ALTER TABLE [Invoice].[LineItem] CHECK CONSTRAINT [FK_LineItem_Invoice]
GO
/****** Object:  ForeignKey [FK_LoginLogoutHistory_Account]    Script Date: 04/07/2014 10:21:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginLogoutHistory_Account] FOREIGN KEY([AccountId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_LoginLogoutHistory_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[LoginHistory]'))
ALTER TABLE [Guardian].[LoginHistory] CHECK CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
/****** Object:  ForeignKey [FK_Payment_Invoice]    Script Date: 04/07/2014 10:21:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] CHECK CONSTRAINT [FK_Payment_Invoice]
GO
/****** Object:  ForeignKey [FK_Payment_PaymentType]    Script Date: 04/07/2014 10:21:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentType] FOREIGN KEY([PaymentTypeId])
REFERENCES [Invoice].[PaymentType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Payment_PaymentType]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Payment]'))
ALTER TABLE [Invoice].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentType]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_Account]    Script Date: 04/07/2014 10:21:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAnswer_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_Account]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] CHECK CONSTRAINT [FK_SecurityAnswer_Account]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_SecurityQuestion]    Script Date: 04/07/2014 10:21:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAnswer_SecurityQuestion] FOREIGN KEY([QuestionId])
REFERENCES [Guardian].[SecurityQuestion] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_SecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[Guardian].[SecurityAnswer]'))
ALTER TABLE [Guardian].[SecurityAnswer] CHECK CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomCategory]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_RoomCategory] FOREIGN KEY([RoomCategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomType]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Status]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Status] FOREIGN KEY([StatusId])
REFERENCES [Customer].[ActionStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservation_Status]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservation]'))
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_Status]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomCategory]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_RoomCategory] FOREIGN KEY([CategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomType]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_RoomType] FOREIGN KEY([TypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomTariff_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomTariff]'))
ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_RoomType]
GO
/****** Object:  ForeignKey [FK_Building_Organization]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Building_Organization]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Building]'))
ALTER TABLE [Lodge].[Building] CHECK CONSTRAINT [FK_Building_Organization]
GO
/****** Object:  ForeignKey [FK_Artifact_Account]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account] FOREIGN KEY([CreatedByUserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account]
GO
/****** Object:  ForeignKey [FK_Artifact_Account1]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account1] FOREIGN KEY([ModifiedByUserId])
REFERENCES [Guardian].[Account] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Account1]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account1]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact] FOREIGN KEY([ParentId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_Artifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[Artifact]'))
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Artifact]
GO
/****** Object:  ForeignKey [FK_Appointment_AppointmentType]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_AppointmentType] FOREIGN KEY([TypeId])
REFERENCES [Utility].[AppointmentType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_AppointmentType]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] CHECK CONSTRAINT [FK_Appointment_AppointmentType]
GO
/****** Object:  ForeignKey [FK_Appointment_Importance]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Importance] FOREIGN KEY([ImportanceId])
REFERENCES [Utility].[Importance] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Utility].[FK_Appointment_Importance]') AND parent_object_id = OBJECT_ID(N'[Utility].[Appointment]'))
ALTER TABLE [Utility].[Appointment] CHECK CONSTRAINT [FK_Appointment_Importance]
GO
/****** Object:  ForeignKey [Customer_FK_IdentityProofId]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_IdentityProofId] FOREIGN KEY([IdentityProofId])
REFERENCES [Configuration].[IdentityProofType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_IdentityProofId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_IdentityProofId]
GO
/****** Object:  ForeignKey [Customer_FK_InitialId]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_InitialId] FOREIGN KEY([InitialId])
REFERENCES [Configuration].[Initial] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_InitialId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_InitialId]
GO
/****** Object:  ForeignKey [Customer_FK_StateId]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_StateId] FOREIGN KEY([StateId])
REFERENCES [Configuration].[State] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[Customer_FK_StateId]') AND parent_object_id = OBJECT_ID(N'[Customer].[Customer]'))
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_StateId]
GO
/****** Object:  ForeignKey [Organization_FK_ContactNumberId]    Script Date: 04/07/2014 10:21:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber]  WITH CHECK ADD  CONSTRAINT [Organization_FK_ContactNumberId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_ContactNumberId]') AND parent_object_id = OBJECT_ID(N'[Organization].[ContactNumber]'))
ALTER TABLE [Organization].[ContactNumber] CHECK CONSTRAINT [Organization_FK_ContactNumberId]
GO
/****** Object:  ForeignKey [Organization_FK_Id]    Script Date: 04/07/2014 10:21:13 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email]  WITH CHECK ADD  CONSTRAINT [Organization_FK_Id] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_Id]') AND parent_object_id = OBJECT_ID(N'[Organization].[Email]'))
ALTER TABLE [Organization].[Email] CHECK CONSTRAINT [Organization_FK_Id]
GO
/****** Object:  ForeignKey [Organization_FK_FaxId]    Script Date: 04/07/2014 10:21:13 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax]  WITH CHECK ADD  CONSTRAINT [Organization_FK_FaxId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[Organization_FK_FaxId]') AND parent_object_id = OBJECT_ID(N'[Organization].[Fax]'))
ALTER TABLE [Organization].[Fax] CHECK CONSTRAINT [Organization_FK_FaxId]
GO
/****** Object:  ForeignKey [FK_InvoiceTaxation_Invoice]    Script Date: 04/07/2014 10:21:13 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceTaxation_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_InvoiceTaxation_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxation]'))
ALTER TABLE [Invoice].[InvoiceTaxation] CHECK CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_Customer]    Script Date: 04/07/2014 10:21:13 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomReservationLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] CHECK CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_RoomReservation]    Script Date: 04/07/2014 10:21:13 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomReservationLink_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] CHECK CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
/****** Object:  ForeignKey [CustomerContactNumber_FK_CustomerId]    Script Date: 04/07/2014 10:21:13 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber]  WITH CHECK ADD  CONSTRAINT [CustomerContactNumber_FK_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber_FK_CustomerId]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerContactNumber]'))
ALTER TABLE [Customer].[CustomerContactNumber] CHECK CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Artifact]    Script Date: 04/07/2014 10:21:13 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerForm_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Artifact]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] CHECK CONSTRAINT [FK_CustomerForm_Artifact]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Customer]    Script Date: 04/07/2014 10:21:13 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerForm_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Customer].[FK_CustomerForm_Customer]') AND parent_object_id = OBJECT_ID(N'[Customer].[CustomerArtifact]'))
ALTER TABLE [Customer].[CustomerArtifact] CHECK CONSTRAINT [FK_CustomerForm_Customer]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact1]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact1] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Artifact1]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] CHECK CONSTRAINT [FK_Artifact_Artifact1]
GO
/****** Object:  ForeignKey [FK_Artifact_Invoice]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Invoice].[Invoice] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Invoice].[FK_Artifact_Invoice]') AND parent_object_id = OBJECT_ID(N'[Invoice].[Artifact]'))
ALTER TABLE [Invoice].[Artifact] CHECK CONSTRAINT [FK_Artifact_Invoice]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Artifact]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_FormModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] CHECK CONSTRAINT [FK_FormModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Module]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_FormModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_FormModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ArtifactModuleLink]'))
ALTER TABLE [Navigator].[ArtifactModuleLink] CHECK CONSTRAINT [FK_FormModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_BuildingFloor_Building]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor]  WITH CHECK ADD  CONSTRAINT [FK_BuildingFloor_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingFloor_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]'))
ALTER TABLE [Lodge].[BuildingFloor] CHECK CONSTRAINT [FK_BuildingFloor_Building]
GO
/****** Object:  ForeignKey [FK_CheckIn_ActionStatus]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_ActionStatus] FOREIGN KEY([StatusId])
REFERENCES [Customer].[ActionStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_ActionStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_ActionStatus]
GO
/****** Object:  ForeignKey [FK_CheckIn_RoomReservation]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_RoomReservation] FOREIGN KEY([ReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckIn_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckIn]'))
ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_RoomReservation]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Artifact]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_CatalogueModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] CHECK CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Module]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_CatalogueModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_CatalogueModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[CatalogueModuleLink]'))
ALTER TABLE [Navigator].[CatalogueModuleLink] CHECK CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_BuildingClosureReason_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]'))
ALTER TABLE [Lodge].[BuildingClosureReason] CHECK CONSTRAINT [FK_BuildingClosureReason_Building]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_Artifact]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] CHECK CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_RoomReservation]    Script Date: 04/07/2014 10:21:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationArtifact_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationArtifact_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifact]'))
ALTER TABLE [Lodge].[RoomReservationArtifact] CHECK CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Artifact]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_ReportModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Artifact]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] CHECK CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Module]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_ReportModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Navigator].[FK_ReportModuleLink_Module]') AND parent_object_id = OBJECT_ID(N'[Navigator].[ReportModuleLink]'))
ALTER TABLE [Navigator].[ReportModuleLink] CHECK CONSTRAINT [FK_ReportModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_ProfileContactNumber_Profile]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber]  WITH CHECK ADD  CONSTRAINT [FK_ProfileContactNumber_Profile] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Profile] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Guardian].[FK_ProfileContactNumber_Profile]') AND parent_object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumber]'))
ALTER TABLE [Guardian].[ProfileContactNumber] CHECK CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
/****** Object:  ForeignKey [FK_Room_Building]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_Building]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_Building]
GO
/****** Object:  ForeignKey [FK_Room_BuildingFloor]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_BuildingFloor] FOREIGN KEY([FloorId])
REFERENCES [Lodge].[BuildingFloor] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_BuildingFloor]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_BuildingFloor]
GO
/****** Object:  ForeignKey [FK_Room_RoomCategory]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomCategory] FOREIGN KEY([CategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomCategory]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomCategory]
GO
/****** Object:  ForeignKey [FK_Room_RoomStatus]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomStatus] FOREIGN KEY([StatusId])
REFERENCES [Lodge].[RoomStatus] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomStatus]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomStatus]
GO
/****** Object:  ForeignKey [FK_Room_RoomType]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([TypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_Room_RoomType]') AND parent_object_id = OBJECT_ID(N'[Lodge].[Room]'))
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_Artifact]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CheckInArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_Artifact]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] CHECK CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_CheckIn]    Script Date: 04/07/2014 10:21:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CheckInArtifact_CheckIn] FOREIGN KEY([CheckInId])
REFERENCES [Lodge].[CheckIn] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_CheckInArtifact_CheckIn]') AND parent_object_id = OBJECT_ID(N'[Lodge].[CheckInArtifact]'))
ALTER TABLE [Lodge].[CheckInArtifact] CHECK CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_CheckIn]    Script Date: 04/07/2014 10:21:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn] FOREIGN KEY([RoomCheckInId])
REFERENCES [Lodge].[CheckIn] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_CheckIn]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] CHECK CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_Customer]    Script Date: 04/07/2014 10:21:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomCheckInLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[AutoTourism].[FK_CustomerRoomCheckInLink_Customer]') AND parent_object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLink]'))
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] CHECK CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
/****** Object:  ForeignKey [FK_RoomClosureReason_Room]    Script Date: 04/07/2014 10:21:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_RoomClosureReason_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomClosureReason_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]'))
ALTER TABLE [Lodge].[RoomClosureReason] CHECK CONSTRAINT [FK_RoomClosureReason_Room]
GO
/****** Object:  ForeignKey [FK_RoomImage_Room]    Script Date: 04/07/2014 10:21:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage]  WITH CHECK ADD  CONSTRAINT [FK_RoomImage_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomImage_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomImage]'))
ALTER TABLE [Lodge].[RoomImage] CHECK CONSTRAINT [FK_RoomImage_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_Room]    Script Date: 04/07/2014 10:21:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_Room]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_RoomReservation]    Script Date: 04/07/2014 10:21:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_RoomReservation] FOREIGN KEY([ReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Lodge].[FK_RoomReservationDetails_RoomReservation]') AND parent_object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]'))
ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
