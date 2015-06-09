USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInIsRoomDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInIsRoomDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInIsRoomDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadAllCheckInRooms]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadAllCheckInRooms]
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomImageRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomImageReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadBookedRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadBookedRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDetailsRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationSearch]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffModifyRate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffModifyRate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadCheckedInRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadCheckedInRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadClosedRoom]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadClosedRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadClosedRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadOpenRoom]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadOpenRoom]
GO
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsBuildingDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsBuildingDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingFloorDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsBuildingFloorDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsBuildingFloorDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomCategoryDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomCategoryDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsRoomCategoryDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomStatusDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomStatusDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsRoomStatusDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomTypeDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomIsRoomTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomIsRoomTypeDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomModifyStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomModifyStatus]
GO
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomCheckInId]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadRoomCheckInId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadRoomCheckInId]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerInvoiceLinkRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerInvoiceLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerInvoiceLinkRead]
GO
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsIdentityProofIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsIdentityProofIdDeletable]
GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsInitialDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsInitialDeletable]
GO
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[IsStateIdDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactDeleteLink]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactInsertLink]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactReadLink]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactReadLink]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactUpdateLink]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForComponent]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkReadForComponent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactComponentLinkReadForComponent]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactDeleteLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactInsertLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactReadLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactReadLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactUpdateLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberDelete]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberInsert]
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerContactNumberRead]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkDelete]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkInsert]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomCheckInLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkRead]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReadDuplicate]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkDelete]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkInsert]
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerRoomReservationLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[CustomerRoomReservationLinkRead]
GO
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[GetCustomerIdForReservation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AutoTourism].[GetCustomerIdForReservation]
GO
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerUpdate]
GO
/****** Object:  StoredProcedure [Customer].[DeleteCustomerReportForArtifact]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[DeleteCustomerReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[DeleteCustomerReportForArtifact]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReportArtifactInsertLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReportArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReportArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerDelete]
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerInsert]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactDeleteLink]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactInsertLink]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactReadForComponent]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactReadForComponent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceArtifactReadForComponent]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactReadLink]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceArtifactReadLink]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactUpdateLink]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxDelete]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemTaxDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemTaxDelete]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxInsert]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemTaxInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemTaxInsert]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxRead]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemTaxRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemTaxRead]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactDelete]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactSearchByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactSearchByName]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorDelete]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingFloorReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInDelete]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInInsert]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInLinkInvoice]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInLinkInvoice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInLinkInvoice]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInRead]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckInUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[CheckinUpdateCheckOut]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckinUpdateCheckOut]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckinUpdateCheckOut]
GO
/****** Object:  StoredProcedure [Lodge].[CheckinUpdateStatus]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckinUpdateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckinUpdateStatus]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkInsertForComponent]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkInsertForComponent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactComponentLinkInsertForComponent]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForArtifact]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactComponentLinkReadForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactComponentLinkReadForArtifact]
GO
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerRead]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[CustomerReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[CustomerReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportArtifactReadForArtifact]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReportArtifactReadForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceReportArtifactReadForArtifact]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentLineItemDelete]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentLineItemInsert]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentLineItemRead]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentLineItemReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentLineItemReadForParent]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentLineItemUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomReservationId]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[ReadRoomReservationId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[ReadRoomReservationId]
GO
/****** Object:  StoredProcedure [Lodge].[IsReservationDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsReservationDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsReservationDeletable]
GO
/****** Object:  StoredProcedure [Customer].[ReadCustomerReportForArtifact]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReadCustomerReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReadCustomerReportForArtifact]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactDeleteLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactInsertLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactReadLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentArtifactReadLink]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactUpdateLink]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberInsert]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberRead]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileContactNumberReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileContactNumberReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactDeleteLink]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactDeleteLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactDeleteLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactInsertLink]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactInsertLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactInsertLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadForComponent]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactReadForComponent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactReadForComponent]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadLink]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactReadLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactReadLink]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactUpdateLink]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactUpdateLink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationArtifactUpdateLink]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonDelete]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonRead]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonReadAll]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadForParent]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateCheckInStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateCheckInStatus]
GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationStatusToCheckIn]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[UpdateReservationStatusToCheckIn]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleDelete]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleRead]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRoleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRoleUpdate]
GO
/****** Object:  StoredProcedure [Accountant].[TaxSlabRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxSlabRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxSlabRead]
GO
/****** Object:  StoredProcedure [Accountant].[TaxSlabReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxSlabReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxSlabReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[TaxSlabReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxSlabReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxSlabReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffIsExist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffIsExist]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllCurrent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadAllCurrent]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadAllFuture]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadAllFuture]
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TariffReadDuplicate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationUpdateStatus]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTariffInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerDelete]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerRead]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityAnswerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityAnswerUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SearchUserByLoginId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SearchUserByLoginId]
GO
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateDelete]
GO
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateInsert]
GO
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateRead]
GO
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[StateUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[StateUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileDelete]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileRead]
GO
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[ProfileUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[ProfileUpdate]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentUpdate]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentAttachInvoice]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentAttachInvoice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentAttachInvoice]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentDelete]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentInsert]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentRead]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[IsInitialDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[IsInitialDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingStatusDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingStatusDeletable]
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingTypeDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[IsBuildingTypeDeletable]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryInsert]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryRead]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryReadForParent]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[LoginHistoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[LoginHistoryUpdate]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountRead]
GO
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentDelete]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentRead]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentSearch]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentSearchWithImportance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentSearchWithImportance]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberDelete]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberInsert]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberRead]
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[ContactNumberReadForParent]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingInsert]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingModifyStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingModifyStatus]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingRead]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactInsert]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactRead]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactReadAll]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadForPath]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactReadForPath]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactReadForPath]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[BuildingDelete]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemUpdate]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemDelete]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemDelete]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemInsert]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemInsert]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemRead]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemRead]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemReadAll]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemReadForParent]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceLineItemReadForParent]
GO
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailDelete]
GO
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailInsert]
GO
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailRead]
GO
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[EmailReadForParent]
GO
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxDelete]
GO
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxInsert]
GO
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxRead]
GO
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[FaxReadForParent]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceDelete]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceDelete]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceInsert]    Script Date: 06/09/2015 14:01:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceInsert]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceRead]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceReadDuplicate]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReadForSerialNumber]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReadForSerialNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceReadForSerialNumber]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeDelete]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeInsert]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeRead]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[IdentityProofTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[IdentityProofTypeUpdate]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceDelete]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceInsert]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceRead]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceReadAll]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceReadDuplicate]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[ImportanceUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[ImportanceUpdate]
GO
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialDelete]
GO
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialInsert]
GO
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialRead]
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialReadDuplicate]
GO
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[InitialUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[InitialUpdate]
GO
/****** Object:  StoredProcedure [Report].[CategoryRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Report].[CategoryRead]
GO
/****** Object:  StoredProcedure [Report].[CategoryReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report].[CategoryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Report].[CategoryReadAll]
GO
/****** Object:  StoredProcedure [Configuration].[CountryRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[CountryRead]
GO
/****** Object:  StoredProcedure [Configuration].[CountryReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[CountryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[CountryReadAll]
GO
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentDelete]
GO
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentInsert]
GO
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentRead]
GO
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentReadAll]
GO
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ComponentUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ComponentUpdate]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusDelete]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusInsert]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusRead]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusReadAll]
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ActionStatusUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdateLoginId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdateLoginId]
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountUpdatePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountUpdatePassword]
GO
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountDelete]
GO
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[AccountInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[AccountInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeDelete]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeInsert]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeRead]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeReadAll]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Utility].[AppointmentTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Utility].[AppointmentTypeUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactAttachmentLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactAttachmentLinkDelete]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactAttachmentLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactAttachmentLinkInsert]
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactAttachmentLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[ArtifactAttachmentLinkRead]
GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[IsStateIdDeletable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[IsStateIdDeletable]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceUpdate]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReportInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceReportInsert]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReportRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceReportRead]
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReportReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[InvoiceReportReadAll]
GO
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleDelete]
GO
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleInsert]
GO
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleRead]
GO
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleReadAll]
GO
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [License].[ModuleUpdate]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationDelete]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationInsert]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationRead]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[OrganizationUpdate]
GO
/****** Object:  StoredProcedure [Customer].[ReportInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportInsert]
GO
/****** Object:  StoredProcedure [Customer].[ReportRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportRead]
GO
/****** Object:  StoredProcedure [Customer].[ReportReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ReportReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[ReportReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentTypeDelete]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentTypeInsert]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentTypeRead]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentTypeReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentTypeReadDuplicate]
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[PaymentTypeUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionDelete]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionInsert]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionRead]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionReadAll]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionReadDuplicate]
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[SecurityQuestionUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[SecurityQuestionUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationStatusRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomReservationStatusReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomTypeUpdate]
GO
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[RuleInsert]
GO
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleInsert]
GO
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleInsert]
GO
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Configuration].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Configuration].[RuleRead]
GO
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleRead]
GO
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleRead]
GO
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[RuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Customer].[RuleUpdate]
GO
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Navigator].[RuleUpdate]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomStatusDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomStatusRead]
GO
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleRead]
GO
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[RoleReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[RoleReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryDelete]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryInsert]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryRead]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryReadAll]
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[RoomCategoryUpdate]
GO
/****** Object:  StoredProcedure [Accountant].[TaxDelete]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxDelete]
GO
/****** Object:  StoredProcedure [Accountant].[TaxInsert]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxInsert]
GO
/****** Object:  StoredProcedure [Accountant].[TaxRead]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxRead]
GO
/****** Object:  StoredProcedure [Accountant].[TaxReadAll]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxReadAll]
GO
/****** Object:  StoredProcedure [Accountant].[TaxReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxReadDuplicate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxReadDuplicate]
GO
/****** Object:  StoredProcedure [Accountant].[TaxUpdate]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Accountant].[TaxUpdate]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeDelete]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeInsert]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeRead]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeReadAll]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeUpdate]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusDelete]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusInsert]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusRead]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusReadAll]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusUpdate]
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRuleInsert]
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Guardian].[UserRuleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Guardian].[UserRuleRead]
GO
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TaxationRead]
GO
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TaxationReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[TaxationReadAll]
GO
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusDelete]
GO
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusInsert]
GO
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusRead]
GO
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusReadAll]
GO
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 06/09/2015 14:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Reservation].[StatusUpdate]
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadIdFromArtifact]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadIdFromArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[PaymentReadIdFromArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceReportForArtifact]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InsertInvoiceReportForArtifact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InsertInvoiceReportForArtifact]
GO
/****** Object:  StoredProcedure [Invoice].[ReadArtifactForInvoiceNumber]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadArtifactForInvoiceNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[ReadArtifactForInvoiceNumber]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationRead]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkDelete]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoiceTaxationLinkRead]
GO
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 06/09/2015 14:01:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CleanUpSchema]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CleanUpSchema]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkDelete]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkInsert]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 06/09/2015 14:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Invoice].[InvoicePaymentLinkRead]
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[ReadArtifactForInvoiceNumber]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceReportForArtifact]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Invoice].[PaymentReadIdFromArtifact]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Organization].[UnitStatusUpdate]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitStatusUpdate]
(	
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Organization.UnitStatus
	SET	
		Name = @Name
	WHERE Id = @Id
   
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusReadAll]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitStatusReadAll]
As
BEGIN

	SELECT Id,Name
	FROM Organization.UnitStatus WITH (NOLOCK)
	
End
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusRead]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Organization.UnitStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusInsert]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitStatusInsert]
(  
	@Name Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Organization.UnitStatus(Name)
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusDelete]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Organization].[UnitStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM Organization.UnitStatus
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeUpdate]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitTypeUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE Organization.UnitType
		SET	
			Name = @Name
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeReadAll]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitTypeReadAll]
As
BEGIN

	SELECT Id,Name
	FROM Organization.UnitType WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeRead]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Organization.UnitType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeInsert]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitTypeInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN
		
		INSERT INTO Organization.UnitType(Name)
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeDelete]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Organization].[UnitTypeDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM Organization.UnitType
		WHERE Id = @Id      
	END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxUpdate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[TaxUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50),
	@Amount Money,
	@IsPercentage Bit
)
AS
BEGIN
	
	UPDATE Accountant.Tax
	SET	
		Name = @Name,	
		Amount = @Amount,
		IsPercentage = @IsPercentage
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[TaxReadDuplicate]
(
	@Name VARCHAR(50)		
)
AS
BEGIN

	SELECT Id	
	FROM Accountant.Tax WITH (NOLOCK)
	WHERE Name = @Name
				
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxReadAll]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[TaxReadAll]
AS
BEGIN
	
	SELECT Id, Name, Amount, IsPercentage
	FROM Accountant.Tax WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxRead]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[TaxRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name, Amount, IsPercentage
	FROM Accountant.Tax WITH (NOLOCK)
	WHERE Id = @Id
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxInsert]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[TaxInsert]
(  
	@Name Varchar(50),
	@Amount Money,
	@IsPercentage Bit,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  Accountant.Tax([Name],[Amount],[IsPercentage])
	VALUES(@Name,@Amount,@IsPercentage)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxDelete]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[TaxDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Accountant.Tax
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Accountant].[PaymentTypeUpdate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[PaymentTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Accountant.PaymentType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[PaymentTypeReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN

	SELECT Id	
	FROM Accountant.PaymentType WITH (NOLOCK)
	WHERE Name = @Name
				
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeReadAll]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[PaymentTypeReadAll]
AS
BEGIN
	
	SELECT Id, [Name]
	FROM Accountant.PaymentType WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeRead]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[PaymentTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Name]
	FROM Accountant.PaymentType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeInsert]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[PaymentTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  Accountant.PaymentType([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeDelete]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[PaymentTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Accountant.PaymentType
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReportReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[ReportRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[ReportInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Accountant].[InvoiceReportReadAll]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReportReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceReportReadAll]
AS
BEGIN
	
	SELECT Id, [Date], ReportCategoryId	
	FROM Accountant.InvoiceReport WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportRead]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReportRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceReportRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Date], ReportCategoryId
	FROM Accountant.InvoiceReport WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportInsert]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReportInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceReportInsert]
(  
	@Date DateTime,	
	@CategoryId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Accountant.InvoiceReport([Date], ReportCategoryId)
	VALUES(@Date, @CategoryId)
   
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceUpdate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceUpdate]
(
	@Id Numeric(10,0),
	@Date DateTime,
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
	
	UPDATE Accountant.Invoice
	SET	
		[Date] = @Date,
		Advance = @Advance,
		Discount = @Discount,
		SellerName = @SellerName,
		SellerAddress = @SellerAddress,
		SellerContactNo = @SellerContactNo,
		SellerEmail = @SellerEmail,
		SellerLicence = @SellerLicence,
		BuyerName = @BuyerName,
		BuyerAddress = @BuyerAddress,
		BuyerContactNo = @BuyerContactNo,
		BuyerEmail = @BuyerEmail
	WHERE Id = @Id
   
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkRead]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactAttachmentLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactAttachmentLinkRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, AttachmentId
	FROM Navigator.ArtifactAttachmentLink WITH (NOLOCK)
	WHERE Id = @Id
	
END' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkInsert]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactAttachmentLinkInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactAttachmentLinkInsert]
(
	@Id Numeric(10,0),
	@AttachmentId Numeric(10,0)
)
AS
BEGIN
 
	INSERT INTO Navigator.ArtifactAttachmentLink(Id,AttachmentId)
	VALUES(@Id, @AttachmentId)
 
END' 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkDelete]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[ArtifactAttachmentLinkDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[ArtifactAttachmentLinkDelete]
(
	@Id Numeric(10,0),
	@AttachmentId Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Navigator.ArtifactAttachmentLink
	WHERE AttachmentId = @AttachmentId
		AND Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Configuration].[CountryReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[CountryRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Report].[CategoryReadAll]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Report].[CategoryRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Accountant].[InvoiceReadForSerialNumber]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReadForSerialNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceReadForSerialNumber]
(
	@SerialNumber Int,
	@Date Date
)
AS
BEGIN
	
	SELECT Id
	FROM Accountant.Invoice WITH (NOLOCK)
	WHERE SerialNumber = @SerialNumber
		AND Date = @Date
	
END' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReadDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceReadDuplicate]
(
	@SerialNumber int		
)
AS
BEGIN

	SELECT Id
	FROM Accountant.Invoice WITH (NOLOCK)
	WHERE SerialNumber = @SerialNumber
	
END' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReadAll]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceReadAll]
AS
BEGIN
	
	SELECT 
		Id, [Date], SerialNumber, Advance, Discount,
		SellerName, SellerAddress, SellerContactNo, SellerEmail, SellerLicence,
		BuyerName, BuyerAddress, BuyerContactNo, BuyerEmail
	FROM Accountant.Invoice WITH (NOLOCK)
   
END' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceRead]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN	
	
	SELECT 
		Id, [Date], SerialNumber, Advance, Discount,
		SellerName, SellerAddress, SellerContactNo, SellerEmail, SellerLicence,
		BuyerName, BuyerAddress, BuyerContactNo, BuyerEmail		
	FROM Accountant.Invoice WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceInsert]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceInsert]
(  
	@Date DateTime,
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
	
	BEGIN TRANSACTION
	
	DECLARE @Max Int
	SELECT @Max = MAX(SerialNumber) + 1 FROM Invoice.Invoice WHERE Date = @Date
	IF @Max IS Null SET @Max = 1
	INSERT INTO Accountant.Invoice([Date], SerialNumber, Advance, Discount,
		SellerName,  SellerAddress, SellerContactNo, SellerEmail, SellerLicence,
		BuyerName, BuyerAddress, BuyerContactNo, BuyerEmail)
	VALUES(@Date, @Max, @Advance, @Discount,
		@SellerName, @SellerAddress, @SellerContactNo, @SellerEmail, @SellerLicence,
		@BuyerName, @BuyerAddress, @BuyerContactNo, @BuyerEmail)
    
    COMMIT TRANSACTION
    
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceDelete]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Accountant.Invoice
	WHERE Id = @Id   
   
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemReadForParent]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Start, [End],
		[Description], UnitRate, [Count]
	FROM Accountant.InvoiceLineItem WITH (NOLOCK)
	WHERE InvoiceId = @ParentId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemReadAll]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemReadAll]
AS
BEGIN
	
	SELECT Id, Start, [End],
		[Description], UnitRate, [Count]
	FROM Accountant.InvoiceLineItem WITH (NOLOCK)
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemRead]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Start, [End],
		[Description], UnitRate, [Count],
		InvoiceId
	FROM Accountant.InvoiceLineItem WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemInsert]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemInsert]
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
	
	INSERT INTO Accountant.InvoiceLineItem(Start, [End], [Description], UnitRate,[Count], InvoiceId)
	VALUES(@Start,@End,@Description,@UnitRate,@Count,@InvoiceId)
   
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemDelete]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Accountant.InvoiceLineItem
	WHERE Id = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemUpdate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemUpdate]
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
	
	UPDATE Accountant.InvoiceLineItem
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
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactReadForPath]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
	UPDATE Lodge.Building
	SET	
		Name = @Name,
		TypeId = @TypeId
	WHERE Id = @Id
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Accountant].[PaymentReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, SerialNumber, [Date], InvoiceId
	FROM Accountant.Payment WITH (NOLOCK)
	WHERE InvoiceId = @ParentId
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentReadAll]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentReadAll]
AS
BEGIN
	
	SELECT Id, SerialNumber, [Date], InvoiceId
	FROM Accountant.Payment WITH (NOLOCK)
   
END' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentRead]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, SerialNumber, [Date], InvoiceId
	FROM Accountant.Payment WITH (NOLOCK)
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentInsert]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentInsert]
(  	
	@InvoiceId Numeric(10,0) = null,
	@Date DateTime,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	BEGIN TRANSACTION
	
	DECLARE @Max Int
	SELECT @Max = MAX(SerialNumber) + 1 FROM Accountant.Payment WHERE Date = @Date
	IF @Max IS Null SET @Max = 1
	INSERT INTO Accountant.Payment(SerialNumber, [Date], InvoiceId)
	VALUES(@Max, @Date, @InvoiceId)
    
    COMMIT TRANSACTION
    
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentDelete]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM Accountant.Payment
	WHERE Id = @Id   
   
END' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentAttachInvoice]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentAttachInvoice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentAttachInvoice]
(
	@Id Numeric(10,0),
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Accountant.Payment
	SET
		InvoiceId = @InvoiceId
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentUpdate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentUpdate]
(
	@Id Numeric(10,0),
	@Date DateTime,
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Accountant.Payment
	SET
		InvoiceId = @InvoiceId,
		[Date] = @Date
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 06/09/2015 14:01:49 ******/
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
	
	UPDATE Lodge.RoomReservation
	SET	StatusId = @StatusId
	WHERE Id = @ProductId 
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Accountant].[TaxSlabReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxSlabReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[TaxSlabReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId Id, Limit, Amount, StartDate, EndDate
	FROM Accountant.TaxSlab WITH (NOLOCK)
	WHERE TaxId = @ParentId	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxSlabReadAll]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxSlabReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[TaxSlabReadAll]
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Accountant.TaxSlab WITH (NOLOCK)	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxSlabRead]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[TaxSlabRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [Accountant].[TaxSlabRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Accountant.TaxSlab WITH (NOLOCK)
	WHERE TaxId = @Id	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationStatusToCheckIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[UpdateReservationStatusToCheckIn]
(
	@ReservationId Numeric(10,0)
)
As
BEGIN

	UPDATE Lodge.RoomReservation
	SET StatusId = 10004 --Check in status
	WHERE Lodge.RoomReservation.Id = @ReservationId
	
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonUpdate]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonUpdate]
(
	@Id Numeric(10,0),
	@Reason Varchar(50),
	@UnitId Numeric(10,0),
	@ClosedDate DateTime
)
AS
BEGIN
	
	UPDATE Organization.UnitClosureReason
	SET
		UnitId = @UnitId,
		Reason = @Reason,
		ClosedDate = @ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE Id = @Id
	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadForParent]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, UnitId, Reason, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE UnitId = @ParentId
	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadAll]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonReadAll]
AS
BEGIN
	
	SELECT Id, Reason, UnitId, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonRead]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reason, UnitId, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonInsert]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonInsert]
(  
	@Reason Varchar(50),
	@UnitId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Organization.UnitClosureReason(Reason, UnitId, ClosedDate)
	VALUES(@Reason, @UnitId, GETDATE())
   
	SET @Id = @@IDENTITY
	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonDelete]    Script Date: 06/09/2015 14:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Organization].[UnitClosureReasonDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Organization.UnitClosureReason
	WHERE Id = @Id      
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactUpdateLink]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadLink]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadForComponent]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationArtifactReadForComponent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationArtifactReadForComponent]
(
	@ComponentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT ArtifactId
	FROM Lodge.RoomReservationArtifact WITH (NOLOCK)
	WHERE RoomReservationId = @ComponentId
	
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactInsertLink]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactDeleteLink]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactUpdateLink]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentArtifactUpdateLink]
(
        @ComponentId Numeric(10,0),
        @ArtifactId Numeric(10,0)
)
AS
BEGIN

	UPDATE Accountant.PaymentArtifact
	SET PaymentId = @ComponentId
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactReadLink]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT PaymentId ComponentId
	FROM Accountant.PaymentArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactInsertLink]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentArtifactInsertLink]
(
        @ComponentId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN

	INSERT INTO Accountant.PaymentArtifact(PaymentId, ArtifactId, Category)
    VALUES(@ComponentId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactDeleteLink]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Accountant.PaymentArtifact
	WHERE ArtifactId = @Id   
 
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[ReadCustomerReportForArtifact]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Lodge].[IsReservationDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[ReadRoomReservationId]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemUpdate]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentLineItemUpdate]
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
	
	UPDATE Accountant.PaymentLineItem
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
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemReadForParent]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentLineItemReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reference, Amount, PaymentTypeId,
		Remark, PaymentId
	FROM Accountant.PaymentLineItem WITH (NOLOCK)
	WHERE PaymentId = @ParentId	
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemReadAll]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentLineItemReadAll]
AS
BEGIN
	
	SELECT Id, Reference, Amount,
		PaymentTypeId, Remark, PaymentId
	FROM Accountant.PaymentLineItem WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemRead]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentLineItemRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reference, Amount,
		PaymentTypeId, Remark, PaymentId
	FROM Accountant.PaymentLineItem WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemInsert]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentLineItemInsert]
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
	
	INSERT INTO Accountant.PaymentLineItem(PaymentTypeId, Reference, Remark, Amount, PaymentId)
	VALUES(@PaymentTypeId, @Reference, @Remark, @Amount, @PaymentId)
    
	SET @Id = @@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemDelete]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[PaymentLineItemDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[PaymentLineItemDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE
	FROM Accountant.PaymentLineItem
	WHERE Id = @Id
   
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportArtifactReadForArtifact]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceReportArtifactReadForArtifact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceReportArtifactReadForArtifact]
(
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	
	SELECT Id, ReportId
	FROM Accountant.InvoiceReportArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
		AND Category =  @Category
	
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForArtifact]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkInsertForComponent]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckinUpdateStatus]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckinUpdateStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckinUpdateStatus]
(	
	@ProductId Numeric(10,0),
	@StatusId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Lodge.CheckIn
	SET	StatusId = @StatusId
	WHERE Id = @ProductId 
   
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckinUpdateCheckOut]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckinUpdateCheckOut]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [Lodge].[CheckinUpdateCheckOut]
(	
	@ProductId Numeric(10,0),
	@StatusId Numeric(10,0)
	--@CompletionTime DateTime OUTPUT
)
AS
BEGIN

	DECLARE @CompletionTime DateTime
	SET @CompletionTime = GETDATE()
	UPDATE Lodge.CheckIn
	SET	StatusId = @StatusId,
		CheckOutDate = @CompletionTime
	WHERE Id = @ProductId
	 
	SELECT @CompletionTime
	
END

' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
	@Remark Varchar(Max),
	@InvoiceId Numeric(10,0) = null
)
AS
BEGIN
	
	UPDATE [Lodge].CheckIn
	SET				
		CheckInDate = @ActivityDate,
		ReservationId = @ReservationId,
		StatusId = @StatusId,
		Purpose = @Purpose,
		ArrivedFrom = @ArrivedFrom,
		Remark = @Remark,
		InvoiceId = @InvoiceId
	WHERE Id = @Id
   
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 06/09/2015 14:01:49 ******/
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
	SELECT Id, CheckInDate, CheckOutDate CompletionTime,
		CreatedDate, ReservationId, StatusId,
		Purpose, ArrivedFrom, Remark,
		InvoiceId, InvoiceNumber
	FROM Lodge.CheckIn WITH (NOLOCK)
	WHERE Id = @Id
	
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInLinkInvoice]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInLinkInvoice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[CheckInLinkInvoice]
(	
	@Id Numeric(10,0),
	@StatusId Numeric(10,0),
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Lodge.CheckIn
	SET
		StatusId = @StatusId,
		InvoiceId = @InvoiceId
	WHERE Id = @Id
   
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
	FROM Lodge.CheckIn
	WHERE Id = @Id      
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 06/09/2015 14:01:50 ******/
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
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxRead]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemTaxRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemTaxRead]
( 
	@LineItemId Numeric(10,0)
)
AS
BEGIN 

	SELECT Id, TaxName, TaxAmount, IsPercentage, LineItemId
	FROM Accountant.InvoiceLineItemTax WITH (NOLOCK)
	WHERE LineItemId = @LineItemId

END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxInsert]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemTaxInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemTaxInsert]
( 
	@LineItemId Numeric(10,0),
	@TaxName Varchar(50), 
	@TaxAmount money, 
	@IsPercentage Bit,
	@Id Numeric(10,0) OUTPUT
)
AS
BEGIN 

	INSERT INTO Accountant.InvoiceLineItemTax(TaxName, TaxAmount, IsPercentage, LineItemId)
	VALUES(@TaxName, @TaxAmount, @IsPercentage, @LineItemId)

	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxDelete]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceLineItemTaxDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceLineItemTaxDelete]
( 
	@Id Numeric(10,0)
)
AS
BEGIN 

	DELETE FROM Accountant.InvoiceLineItemTax
	WHERE Id = @Id
	
END' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactUpdateLink]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactUpdateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0)
)
AS
BEGIN

	UPDATE Accountant.InvoiceArtifact
	SET InvoiceId = @ComponentId
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactReadLink]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactReadLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT InvoiceId ComponentId
	FROM Accountant.InvoiceArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactReadForComponent]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactReadForComponent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceArtifactReadForComponent]
(
	@ComponentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT *, ArtifactId
	FROM Accountant.InvoiceArtifact WITH (NOLOCK)
	WHERE InvoiceId = @ComponentId
	
END' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactInsertLink]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactInsertLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Accountant.InvoiceArtifact(InvoiceId, ArtifactId, Category)
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
' 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactDeleteLink]    Script Date: 06/09/2015 14:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Accountant].[InvoiceArtifactDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Accountant].[InvoiceArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Accountant.InvoiceArtifact
	WHERE ArtifactId = @Id   
   
END
' 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerReportArtifactInsertLink]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[DeleteCustomerReportForArtifact]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 06/09/2015 14:01:48 ******/
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

	SELECT Id, FirstName, MiddleName, LastName, Email,
		(SELECT Name 
		FROM Configuration.IdentityProofType 
		WHERE Id = IdentityProofId) IdentityProofType, IdentityProofName
	FROM Customer.Customer C WITH (NOLOCK)
	WHERE (IdentityProofId = @IdentityProofId	
		AND IdentityProofName = @IdentityProofName)
		OR (Email = @Email AND @Email != '''')
		OR ID IN (SELECT CustomerId FROM Customer.CustomerContactNumber WITH (NOLOCK)
			WHERE Number IN (SELECT SplitText FROM Split(@ContactNumber, '','')))

END
' 
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerArtifactUpdateLink]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerArtifactReadLink]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerArtifactInsertLink]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[CustomerArtifactDeleteLink]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForComponent]    Script Date: 06/09/2015 14:01:50 ******/
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

	SELECT Id, FileName, Path, Extension, Style, Version, ParentId, CreatedByUserId, 
		CreatedByFirstName, CreatedByMiddleName, CreatedByLastName, CreatedAt, ModifiedByUserId, 
		ModifiedByFirstName, ModifiedByMiddleName, ModifiedByLastName, ModifiedAt, 
		ComponentId, ComponentCode, ComponentName, AttachmentCount
	FROM Navigator.ArtifactSummary
	WHERE ComponentId = @ComponentId
		AND Category = @Category
		--AND A.ParentId IS NULL
		
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactUpdateLink]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactReadLink]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactInsertLink]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactDeleteLink]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 06/09/2015 14:01:48 ******/
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
/****** Object:  StoredProcedure [AutoTourism].[CustomerInvoiceLinkRead]    Script Date: 06/09/2015 14:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoTourism].[CustomerInvoiceLinkRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [AutoTourism].[CustomerInvoiceLinkRead]
(
	@CustomerId Numeric(10,0)
)
As
BEGIN

	SELECT  CustomerId, InvoiceId as ActionId
	FROM AutoTourism.CustomerInvoiceLink WITH (NOLOCK)
	WHERE CustomerId = @CustomerId
	
END
' 
END
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomCheckInId]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomTypeDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomStatusDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomCategoryDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingFloorDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadClosedRoom]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsRead]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationDetailsRead]
(
   @ReservationId Numeric(10,0)
)
AS
BEGIN
	
   SELECT Id, RoomId, ReservationId, ExtraAccomodation
   FROM Lodge.RoomReservationDetails WITH (NOLOCK)
   WHERE ReservationId = @ReservationId   
   
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReservationDetailsInsert]
(  
	@RoomId  Numeric(10,0),
	@ReservationId  Numeric(10,0),
	@ExtraAccomodation Int = 0,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Lodge.RoomReservationDetails(RoomId, ReservationId, ExtraAccomodation)
	VALUES(@RoomId, @ReservationId, @ExtraAccomodation)
   
	SET @Id = @@IDENTITY
	
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 06/09/2015 14:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Lodge].[RoomReservationDetailsDelete]
(
	@ReservationId  Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Lodge.RoomReservationDetails
	WHERE ReservationId = @ReservationId
	
END' 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 06/09/2015 14:01:49 ******/
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
/****** Object:  StoredProcedure [Lodge].[CheckInIsRoomDeletable]    Script Date: 06/09/2015 14:01:49 ******/
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
